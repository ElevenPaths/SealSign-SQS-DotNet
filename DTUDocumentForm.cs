using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using SealSignSQSService;


namespace SealSignSQSClient
{
    public partial class DTUDocumentForm : Form
    {
        private Job m_Job = null;
        private byte[] m_signedDocument = null;
        private string m_fileName;

        public byte[] signedDocument
        {
            get { return m_signedDocument; }
            set
            {
                m_signedDocument = value;
            }
        }

        public DTUDocumentForm(string fileName, Job job)
        {
            m_Job = job;
            m_fileName = fileName;
            InitializeComponent();
            showOnMonitor(Convert.ToInt32(Tools.GetAppSettings("wacom_dtu_screen_number")) - 1);
        }

        private void showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = sc.Length - 1;
            }

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            this.Height = sc[showOnMonitor].Bounds.Height;
            this.Width = sc[showOnMonitor].Bounds.Width;
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }

        private void DTUDocumentForm_Load(object sender, EventArgs e)
        {
            try
            {
                string Logo = Tools.GetAppSettings("Logo").ToString();
                if (Logo != "")
                {
                    try
                    {
                        pictureBox1.Load(Logo);
                    }
                    catch { }
                }

                string WindowColor = Tools.GetAppSettings("WindowColor").ToString();
                if (WindowColor != "")
                {
                    this.BackColor = System.Drawing.ColorTranslator.FromHtml(WindowColor);
                    pictureBox1.BackColor = this.BackColor;
                }

                string FrameColor = Tools.GetAppSettings("FrameColor").ToString();
                if (FrameColor != "")
                {
                    panel1.BackColor = System.Drawing.ColorTranslator.FromHtml(FrameColor);
                    panel2.BackColor = panel1.BackColor;
                }

                string ScrollButtonColor = Tools.GetAppSettings("ScrollButtonColor").ToString();
                if (ScrollButtonColor != "")
                {
                    btnRePag.BackColor = System.Drawing.ColorTranslator.FromHtml(ScrollButtonColor);
                    btnAvPag.BackColor = System.Drawing.ColorTranslator.FromHtml(ScrollButtonColor);
                }

                string CancelButtonColor = Tools.GetAppSettings("CancelButtonColor").ToString();
                if (CancelButtonColor != "")
                {
                    btnCancelar.BackColor = System.Drawing.ColorTranslator.FromHtml(CancelButtonColor);
                }

                string OKButtonColor = Tools.GetAppSettings("OKButtonColor").ToString();
                if (OKButtonColor != "")
                {
                    btnBioSign.BackColor = System.Drawing.ColorTranslator.FromHtml(OKButtonColor);
                }

                axAcroPDF1.setShowToolbar(false);
                axAcroPDF1.LoadFile(m_fileName);
                axAcroPDF1.Focus();

            }
            catch (Exception ex)
            {
                Tools.ShowUnexpectedError(this, ex);
            }
        }

        private void btnRePag_Click(object sender, EventArgs e)
        {
            axAcroPDF1.gotoPreviousPage();
        }

        private void btnAvPag_Click(object sender, EventArgs e)
        {
            axAcroPDF1.gotoNextPage();
        }

        private void btnBioSign_Click(object sender, EventArgs e)
        {
            bool canceled = false;

            // Biometric signature
            if (m_Job.signatureClientBehaviour != null)
            {
                int signatureIndex = 0;
                foreach (SignatureClientBehaviour signature in m_Job.signatureClientBehaviour)
                {
                    DTUSignatureForm signatureForm = new DTUSignatureForm(signatureIndex, signature, m_Job.jobReferenceEx);
                    if (signatureForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        m_Job.jobReferenceEx.blob = signatureForm.signedDocument;
                    }
                    else
                    {
                        canceled = true;
                        break;
                    }
                    signatureIndex++;
                }
            }

            if (!canceled)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
