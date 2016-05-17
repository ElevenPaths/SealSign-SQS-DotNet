using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Reflection;
using SealSignSQSService;


namespace SealSignSQSClient
{
    public partial class DTUSignatureForm : Form
    {
        SignatureClientBehaviour m_SignatureClientBehaviour = null;
        private JobReferenceEx m_jobReferenceEx = null;
        private byte[] m_signedDocument = null;
        private int m_signatureIndex = 0;


        private ProgressWindow m_progressWindow = null;
        SealSignBSSClientLibrary.SealSignBSSPanel.ErrorCapture m_ErrorCaptureEvent;

        public byte[] signedDocument
        {
            get { return m_signedDocument; }
            set
            {
                m_signedDocument = value;
            }
        }

        public DTUSignatureForm(int signatureIndex, SignatureClientBehaviour signatureClientBehaviour, JobReferenceEx jobReferenceEx)
        {
            try
            {
                m_SignatureClientBehaviour = signatureClientBehaviour;
                m_jobReferenceEx = jobReferenceEx;
                m_signatureIndex = signatureIndex;

                m_ErrorCaptureEvent += new SealSignBSSClientLibrary.SealSignBSSPanel.ErrorCapture(sealSignBSSPanel1_ErrorCaptureEvent);

                m_progressWindow = new ProgressWindow(Convert.ToInt32(Tools.GetAppSettings("wacom_dtu_screen_number")) - 1);

                InitializeComponent();
            }
            catch (Exception ex)
            {
                if (m_progressWindow != null)
                {
                    m_progressWindow.Close();
                }

                Tools.ShowUnexpectedError(this, ex);
            }
        }

        private void sealSignBSSPanel1_ErrorCaptureEvent(object sender, EventArgs e)
        {
            m_progressWindow.Close();

            Tools.ShowUnexpectedError(this, ((Exception)((System.UnhandledExceptionEventArgs)e).ExceptionObject));

            /*this.DialogResult = DialogResult.Cancel;
            this.CloseWindow(); */
        }

        private void SignatureForm_Load(object sender, EventArgs e)
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
                    panel1.BackColor = System.Drawing.ColorTranslator.FromHtml(WindowColor);
                    pictureBox1.BackColor = panel1.BackColor;
                    lblTitle.BackColor = panel1.BackColor;
                }

                string TitleColor = Tools.GetAppSettings("TitleColor").ToString();
                if (TitleColor != "") lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(TitleColor);

                string FrameColor = Tools.GetAppSettings("FrameColor").ToString();
                if (FrameColor != "")
                {
                    panel3.BackColor = System.Drawing.ColorTranslator.FromHtml(FrameColor);
                    panel2.BackColor = panel3.BackColor;
                }

                string CancelButtonColor = Tools.GetAppSettings("CancelButtonColor").ToString();
                if (CancelButtonColor != "")
                {
                    btnCancel.BackColor = System.Drawing.ColorTranslator.FromHtml(CancelButtonColor);
                }
                
                string OKButtonColor = Tools.GetAppSettings("OKButtonColor").ToString();
                if (OKButtonColor != "")
                {
                    btnOK.BackColor = System.Drawing.ColorTranslator.FromHtml(OKButtonColor);
                }
                
                if (!String.IsNullOrEmpty(m_SignatureClientBehaviour.signatureWindowTitle))
                {
                    lblTitle.Text = m_SignatureClientBehaviour.signatureWindowTitle;
                }

                sealSignBSSPanel1.ErrorCaptureEvent += m_ErrorCaptureEvent;
                sealSignBSSPanel1.Start();

                this.Activate();
            }
            catch (Exception exc)
            {
                Tools.ShowUnexpectedError(this, exc);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SignatureQueueServiceClient service = null;
            try
            {
                m_progressWindow.Show(null, Tools.GetLocalizedString("Signing"));

                service = WSTools.GetSignatureQueueServiceClient();

                BiometricSignatureContext context = service.BeginBiometricSignatureProvider(
                    m_jobReferenceEx.id,
                    m_signatureIndex,
                    m_jobReferenceEx.queueName,
                    m_SignatureClientBehaviour.signatureId,
                    m_SignatureClientBehaviour.signatureAccount,
                    m_SignatureClientBehaviour.uri,
                    m_SignatureClientBehaviour.providerParameter,
                    null);
                if (context != null && context.instance != null)
                {
                    byte[] biometricFinalState = sealSignBSSPanel1.GetSignature(context.instance, context.biometricState);
                    if (biometricFinalState != null)
                    {
                        m_signedDocument = service.EndBiometricSignatureProvider(
                            context.instance,
                            biometricFinalState,
                            m_jobReferenceEx.id,
                            m_signatureIndex,
                            m_jobReferenceEx.queueName,
                            m_SignatureClientBehaviour.uri,
                            m_SignatureClientBehaviour.providerParameter);
                    }
                    else
                    {
                        service.Close();
                        return;
                    }
                }

                m_progressWindow.SetMessage(Tools.GetLocalizedString("SignatureSuccess"), 2000);
                this.DialogResult = DialogResult.OK;

                sealSignBSSPanel1.CleanSignature();
                m_progressWindow.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                sealSignBSSPanel1.CleanSignature();
                m_progressWindow.Close();
                Tools.ShowUnexpectedError(this, ex);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            finally
            {
                try
                {
                    if (service != null)
                    {
                        service.Close();
                    }
                }
                catch { }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                sealSignBSSPanel1.CleanSignature();
                m_progressWindow.Close();
            }
            catch { }
        }

        private void SignatureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sealSignBSSPanel1.ErrorCaptureEvent -= m_ErrorCaptureEvent;
        }
    }
}
