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
using SealSignSQSService;


namespace SealSignSQSClient
{
    public partial class DocumentForm : Form
    {
        private int m_JobId;
        private Job m_Job;
        private string m_tempFilename;

        public DocumentForm(int jobId)
        {
            try
            {
                m_JobId = jobId;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Tools.ShowUnexpectedError(this, ex);
            }
        }

        private void DocumentForm_Load(object sender, EventArgs e)
        {
            SignatureQueueServiceClient service = null;
            WaitingForm progressWindow = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                progressWindow = new WaitingForm(Tools.GetLocalizedString("GettingJobInfo"));
                progressWindow.Show();
                service = WSTools.GetSignatureQueueServiceClient();
                m_Job = service.GetJob(m_JobId);
                this.Text = m_Job.jobReferenceEx.jobTitle;

                toolStripOwner.Text = String.Format(Tools.GetLocalizedString("Owner"), m_Job.jobReferenceEx.owner);
                if (m_Job.jobReferenceEx.processed)
                {
                    mnuSignDocument.Visible = false;
                    toolStripTime.Text = String.Format(Tools.GetLocalizedString("SubmissionTime"), m_Job.jobReferenceEx.time.ToShortDateString(), m_Job.jobReferenceEx.time.ToLongTimeString());
                    toolStripComputer.Text = String.Format(Tools.GetLocalizedString("SourceComputer"), m_Job.jobReferenceEx.computerName);
                }
                else
                {
                    mnuSignDocument.Visible = true;
                    toolStripTime.Text = String.Format(Tools.GetLocalizedString("SigningTime"), m_Job.jobReferenceEx.time.ToShortDateString(), m_Job.jobReferenceEx.time.ToLongTimeString());
                    toolStripComputer.Text = "";
                }

                m_tempFilename = System.IO.Path.GetTempFileName();
                FileStream f = new FileStream(m_tempFilename, FileMode.Create, FileAccess.Write);
                f.Write(m_Job.jobReferenceEx.blob, 0, m_Job.jobReferenceEx.blob.Length);
                f.Close();
                axAcroPDF1.LoadFile(m_tempFilename);
                axAcroPDF1.setShowToolbar(false);

                this.WindowState = FormWindowState.Maximized;
                this.Activate();
            }
            catch (Exception ex)
            {
                Tools.ShowUnexpectedError(this, ex);
            }
            finally
            {
                if (progressWindow != null)
                {
                    progressWindow.Close();
                }
                try
                {
                    if (service != null)
                    {
                        service.Close();
                    }
                }
                catch { }
                this.Cursor = Cursors.Default;
            }
        }

        private void DocumentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                File.Delete(m_tempFilename);
            }
            catch
            {
            }
        }

        private void mnuDeleteDocument_Click(object sender, EventArgs e)
        {
            SignatureQueueServiceClient service = null;

            try
            {
                if (MessageBox.Show(this,
                        m_Job.jobReferenceEx.processed ? Tools.GetLocalizedString("RemoveSignedJob") : Tools.GetLocalizedString("RemovePendingJob"), 
                        this.Text, 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                service = WSTools.GetSignatureQueueServiceClient();
                service.RemoveJob(m_JobId);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exc)
            {
                this.Cursor = Cursors.Default;
                Tools.ShowUnexpectedError(this, exc);
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
                this.Cursor = Cursors.Default;
            }
        }

        private void mnuSignDocument_Click(object sender, EventArgs e)
        {
            WaitingForm progressWindow = null;
            bool canceled = false;

            try
            {
                // Firma biométrica
                if (m_Job.signatureClientBehaviour != null)
                {
                    if (Convert.ToInt32(Tools.GetAppSettings("wacom_dtu_mode")) != 0)
                    {
                        //this.Hide();
                        progressWindow = new WaitingForm(Tools.GetLocalizedString("WaitingForSignature"));
                        progressWindow.Show();
                        DTUDocumentForm signatureForm = new DTUDocumentForm(m_tempFilename, m_Job);
                        if (signatureForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            m_Job.jobReferenceEx.blob = signatureForm.signedDocument;
                            progressWindow.SetMessage(Tools.GetLocalizedString("SignatureSuccess"), 2000);
                        }
                        else
                        {
                            //this.Show();
                            canceled = true;
                        }
                    }
                    else
                    {
                        int signatureIndex = 0;
                        foreach (SignatureClientBehaviour signature in m_Job.signatureClientBehaviour)
                        {
                            STUSignatureForm signatureForm = new STUSignatureForm(signatureIndex, signature, m_Job.jobReferenceEx);
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
                }
                if (!canceled)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                Tools.ShowUnexpectedError(this, ex);
            }
            finally
            {
                if (progressWindow != null)
                {
                    progressWindow.Close();
                }
            }
        }
    }
}
