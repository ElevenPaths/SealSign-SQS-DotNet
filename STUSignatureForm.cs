using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;
using SealSignSQSService;

using System.Windows.Forms.VisualStyles;

namespace SealSignSQSClient
{
    public partial class STUSignatureForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        private const int BM_CLICK = 0x00F5;
        private IntPtr CancelHwnd = IntPtr.Zero;
        private IntPtr SignHwnd = IntPtr.Zero;

        SignatureClientBehaviour m_SignatureClientBehaviour = null;
        private JobReferenceEx m_jobReferenceEx = null;
        private byte[] m_signedDocument = null;
        private int m_signatureIndex = 0;

        private ProgressWindow m_progressWindow = null;
        private ProgressWindow m_otherProgressWindow = null;
        private bool m_bDeviceConnected = true;
        private bool bSigning = false;

        SealSignBSSClientLibrary.SealSignBSSWacomSTUPanel.ErrorCapture m_ErrorCaptureEvent;
        SealSignBSSClientLibrary.SealSignBSSWacomSTUPanel.ErrorDeviceNotConnected m_ErrorDeviceNotConnectedEvent;
        SealSignBSSClientLibrary.SealSignBSSWacomSTUPanel.OkButtonClick m_OkButtonClickEvent;
        SealSignBSSClientLibrary.SealSignBSSWacomSTUPanel.CancelButtonClick m_CancelButtonClickEvent;

        public byte[] signedDocument
        {
            get { return m_signedDocument; }
            set
            {
                m_signedDocument = value;
            }
        }

        public STUSignatureForm(int signatureIndex, SignatureClientBehaviour signatureClientBehaviour, JobReferenceEx jobReferenceEx)
        {
            try
            {
                m_SignatureClientBehaviour = signatureClientBehaviour;
                m_jobReferenceEx = jobReferenceEx;
                m_signatureIndex = signatureIndex;

                m_ErrorCaptureEvent += new SealSignBSSClientLibrary.SealSignBSSWacomSTUPanel.ErrorCapture(sealSignBSSWacomSTUPanel1_ErrorCaptureEvent);
                m_ErrorDeviceNotConnectedEvent += new SealSignBSSClientLibrary.SealSignBSSWacomSTUPanel.ErrorDeviceNotConnected(sealSignBSSWacomSTUPanel1_ErrorDeviceNotConnectedEvent);
                m_OkButtonClickEvent = new SealSignBSSClientLibrary.SealSignBSSWacomSTUPanel.OkButtonClick(sealSignBSSWacomSTUPanel1_OkButtonClickEvent);
                m_CancelButtonClickEvent += new SealSignBSSClientLibrary.SealSignBSSWacomSTUPanel.CancelButtonClick(sealSignBSSWacomSTUPanel1_CancelButtonClickEvent);

                m_progressWindow = new ProgressWindow();

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

        private void frmSignature_Load(object sender, EventArgs e)
        {
            bSigning = false;
            CancelHwnd = btnCancel.Handle;
            SignHwnd = btnSign.Handle;

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
                backgroundPanel.BackColor = System.Drawing.ColorTranslator.FromHtml(WindowColor);
                lblTitle.BackColor = backgroundPanel.BackColor;
                pictureBox1.BackColor = backgroundPanel.BackColor;
            }

            string TitleColor = Tools.GetAppSettings("TitleColor").ToString();
            if (TitleColor != "") lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(TitleColor);

            string FrameColor = Tools.GetAppSettings("FrameColor").ToString();
            if (FrameColor != "")
            {
                framePanel.BackColor = System.Drawing.ColorTranslator.FromHtml(FrameColor);
                buttonsPanel.BackColor = framePanel.BackColor;
            }

            string CancelButtonColor = Tools.GetAppSettings("CancelButtonColor").ToString();
            if (CancelButtonColor != "")
            {
                btnCancel.BackColor = System.Drawing.ColorTranslator.FromHtml(CancelButtonColor);
            }

            string OKButtonColor = Tools.GetAppSettings("OKButtonColor").ToString();
            if (OKButtonColor != "")
            {
                btnSign.BackColor = System.Drawing.ColorTranslator.FromHtml(OKButtonColor);
            }

            m_progressWindow.Show(null, Tools.GetLocalizedString("InitializingDevice"));
            m_bDeviceConnected = true;

            sealSignBSSWacomSTUPanel1.ErrorCaptureEvent += m_ErrorCaptureEvent;
            sealSignBSSWacomSTUPanel1.ErrorDeviceNotConnectedEvent += m_ErrorDeviceNotConnectedEvent;
            sealSignBSSWacomSTUPanel1.Start();

            if (m_SignatureClientBehaviour.stuConfiguration != null)
            {
                if (m_SignatureClientBehaviour.stuConfiguration.OKButton != null)
                {
                    sealSignBSSWacomSTUPanel1.OkButtonClickEvent += m_OkButtonClickEvent;
                    sealSignBSSWacomSTUPanel1.SetOkButtonArea(m_SignatureClientBehaviour.stuConfiguration.OKButton.x1,
                        m_SignatureClientBehaviour.stuConfiguration.OKButton.y1,
                        m_SignatureClientBehaviour.stuConfiguration.OKButton.x2,
                        m_SignatureClientBehaviour.stuConfiguration.OKButton.y2);
                }
                if (m_SignatureClientBehaviour.stuConfiguration.CancelButton != null)
                {
                    sealSignBSSWacomSTUPanel1.CancelButtonClickEvent += m_CancelButtonClickEvent;
                    sealSignBSSWacomSTUPanel1.SetCancelButtonArea(m_SignatureClientBehaviour.stuConfiguration.CancelButton.x1,
                        m_SignatureClientBehaviour.stuConfiguration.CancelButton.y1,
                        m_SignatureClientBehaviour.stuConfiguration.CancelButton.x2,
                        m_SignatureClientBehaviour.stuConfiguration.CancelButton.y2);
                }
                if (m_SignatureClientBehaviour.stuConfiguration.Image != null)
                {
                    MemoryStream imageStream = new MemoryStream(m_SignatureClientBehaviour.stuConfiguration.Image);
                    imageStream.Seek(0, SeekOrigin.Begin);
                    sealSignBSSWacomSTUPanel1.SetImage(imageStream);
                }
            }

            btnSign.Enabled = m_bDeviceConnected;
            m_progressWindow.Close();

            if (!String.IsNullOrEmpty(m_SignatureClientBehaviour.signatureWindowTitle))
            {
                this.Text = m_SignatureClientBehaviour.signatureWindowTitle;
                lblTitle.Text = m_SignatureClientBehaviour.signatureWindowTitle;
            }

            //Load the Form At Position of Main Form
            int WidthOfMain = this.Owner.Width;
            int HeightofMain = this.Owner.Height;
            int LocationMainX = this.Owner.Location.X;
            int locationMainy = this.Owner.Location.Y;
            this.Location = new Point(LocationMainX + WidthOfMain - this.Width - 50, locationMainy + HeightofMain - this.Height - 55);

            this.Activate();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            SignatureQueueServiceClient service = null;
            try
            {
                if (bSigning)
                    return;
                bSigning = true;

                sealSignBSSWacomSTUPanel1.Stop();

                m_otherProgressWindow = new ProgressWindow();
                m_otherProgressWindow.Show(null, Tools.GetLocalizedString("Signing"));

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
                    byte[] biometricFinalState = sealSignBSSWacomSTUPanel1.GetSignature(context.instance, context.biometricState);
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
                        // Te error has already reported on the error handler
                        return;
                    }
                }

                m_otherProgressWindow.SetMessage(Tools.GetLocalizedString("SignatureSuccess"), 1500);

                m_otherProgressWindow.Close();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                sealSignBSSWacomSTUPanel1.Stop();
                m_otherProgressWindow.Close();

                Tools.ShowUnexpectedError(this, ex);
            }
            finally
            {
                if (service != null)
                {
                    try
                    {
                        service.Close();
                    }
                    catch { }
                }

                this.CloseWindow();
                bSigning = false;
            }
        }

        private void sealSignBSSWacomSTUPanel1_OkButtonClickEvent(object sender, EventArgs e)
        {
            // We send a click to the cancel button because if we call directly to the method the operation of stop takes much longer
            PostMessage(SignHwnd, BM_CLICK, IntPtr.Zero, IntPtr.Zero);

            //if (m_bOkButtonClickEventFired)
            //    return;
            //m_bOkButtonClickEventFired = true;

            //// Firma desde el evento (asincrono)
            //Sign();
            //m_bOkButtonClickEventFired = false;
        }

        private void sealSignBSSWacomSTUPanel1_CancelButtonClickEvent(object sender, EventArgs e)
        {
            // We send a click to the cancel button because if we call directly to the method the operation of stop takes much longer
            PostMessage(CancelHwnd, BM_CLICK, IntPtr.Zero, IntPtr.Zero);

            /*if (btnCancel.InvokeRequired)
            {
                btnCancel.Invoke(new buttonClickDelegate(btnCancel_Click), new object[] { null, null });
            }
            else
            {
                btnCancel_Click(null, null);
            }*/
        }

        private void sealSignBSSWacomSTUPanel1_ErrorCaptureEvent(object sender, EventArgs e)
        {
            m_progressWindow.Close();
            m_otherProgressWindow.Close();

            if (((Exception)((System.UnhandledExceptionEventArgs)e).ExceptionObject).Message == "La firma no puede estar vacía")
            {
                MessageBox.Show(this, ((Exception)((System.UnhandledExceptionEventArgs)e).ExceptionObject).Message, Tools.GetLocalizedString("Title"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Tools.ShowUnexpectedError(this, ((Exception)((System.UnhandledExceptionEventArgs)e).ExceptionObject));
                this.DialogResult = DialogResult.Cancel;
                this.CloseWindow();
            }
            /*this.DialogResult = DialogResult.Cancel;
            this.Close();*/
        }

        private void sealSignBSSWacomSTUPanel1_ErrorDeviceNotConnectedEvent(object sender, EventArgs e)
        {
            m_bDeviceConnected = false;
            m_progressWindow.Close();

            MessageBox.Show(this, Tools.GetLocalizedString("DeviceNotConnected"), Tools.GetLocalizedString("Title"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000); //MB_TOPMOST

            this.DialogResult = DialogResult.Cancel;
            this.CloseWindow();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            sealSignBSSWacomSTUPanel1.SetImage(null);
            //sealSignBSSWacomSTUPanel1.CleanSignature();
            sealSignBSSWacomSTUPanel1.Stop();
            this.Cursor = Cursors.Arrow;
            this.DialogResult = DialogResult.Cancel;
            this.CloseWindow();
        }

        private void CloseWindow()
        {
            sealSignBSSWacomSTUPanel1.Disconnect();
            this.Close();
        }

        private void FrmSignature_FormClosed(object sender, FormClosedEventArgs e)
        {
            sealSignBSSWacomSTUPanel1.OkButtonClickEvent -= m_OkButtonClickEvent;
            sealSignBSSWacomSTUPanel1.CancelButtonClickEvent -= m_CancelButtonClickEvent;
            sealSignBSSWacomSTUPanel1.ErrorCaptureEvent -= m_ErrorCaptureEvent;
            sealSignBSSWacomSTUPanel1.ErrorDeviceNotConnectedEvent -= m_ErrorDeviceNotConnectedEvent;
        }

        VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Normal);
        private void backgroundPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.backgroundPanel.ClientRectangle,
                Color.Gray, 4, ButtonBorderStyle.Solid,
                Color.Gray, 4, ButtonBorderStyle.Solid,
                Color.Gray, 4, ButtonBorderStyle.Solid,
                Color.Gray, 4, ButtonBorderStyle.Solid);
        }
    }
}
