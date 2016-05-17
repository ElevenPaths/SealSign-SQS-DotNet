using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Security.Permissions;
using System.Security.Principal;
using SealSignSQSService;

using System.IO;

namespace SealSignSQSClient
{
    public partial class JobListForm : Form
    {
        private bool m_bLoading;
        private ListViewColumnSorter m_lvwColumnSorter;

        public JobListForm()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Show();
            this.Activate();
        }

        private void lstPendingJobsRefresh(bool bForce)
        {
            SignatureQueueServiceClient service = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (tabControl1.SelectedTab == tabPendingJobs)
                {
                    toolStripTotalJobs.Text = Tools.GetLocalizedString("RefreshingList");
                }
                service = WSTools.GetSignatureQueueServiceClient();
                JobReference[] jobReferences = service.GetPendingJobs(null, null, null);
                if ((jobReferences.Length > lstPendingJobs.Items.Count) && !m_bLoading)
                {
                    // There are new pending jobs and is not the first loading of the list
                    if (this.Visible == false/*this.WindowState == FormWindowState.Minimized*/ || tabControl1.SelectedTab != tabPendingJobs)
                    {
                        notifyIcon1.ShowBalloonTip(10, Tools.GetLocalizedString("Title"), string.Format(Tools.GetLocalizedString("NewPendingDocs"), jobReferences.Length - lstPendingJobs.Items.Count), ToolTipIcon.Info);
                    }
                }

                if (!bForce)
                {
                    if (jobReferences.Length == lstPendingJobs.Items.Count)
                    {
                        // No hay nuevos trabajos ==> no actualizar la lista
                        if (tabControl1.SelectedTab == tabPendingJobs)
                        {
                            toolStripTotalJobs.Text = "" + jobReferences.Length + Tools.GetLocalizedString("PendingDocs");
                        }

                        timerRefresh.Start();
                        return;
                    }
                }

                lstPendingJobs.Items.Clear();

                foreach (JobReference jobReference in jobReferences)
                {
                    ListViewItem lstViewItem = new ListViewItem();
                    lstViewItem.ImageIndex = 0;
                    lstViewItem.Tag = jobReference.id.ToString();
                    lstViewItem.Text = jobReference.jobTitle;
                    lstViewItem.SubItems.Add(jobReference.owner);
                    lstViewItem.SubItems.Add(jobReference.time.ToShortDateString() + ' ' + jobReference.time.ToLongTimeString());
                    lstViewItem.SubItems.Add(jobReference.computerName);
                    lstPendingJobs.Items.Add(lstViewItem);
                }

                if (tabControl1.SelectedTab == tabPendingJobs)
                {
                    toolStripTotalJobs.Text = "" + jobReferences.Length + Tools.GetLocalizedString("PendingDocs");
                }
                notifyIcon1.Text = toolStripTotalJobs.Text;
                timerRefresh.Start();
            }
            catch (Exception exc)
            {
                toolStripTotalJobs.Text = "";
                toolStripCurrentUser.Text = "";
                timerRefresh.Stop();
                this.Cursor = Cursors.Default;
                this.Show();
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

        private void lstSignedJobsRefresh()
        {
            SignatureQueueServiceClient service = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                toolStripTotalJobs.Text = Tools.GetLocalizedString("RefreshingList");
                service = WSTools.GetSignatureQueueServiceClient();
                JobReference[] jobReferences = service.GetProcessedJobs(null, null, null);
                lstSignedJobs.Items.Clear();

                foreach (JobReference jobReference in jobReferences)
                {
                    ListViewItem lstViewItem = new ListViewItem();
                    lstViewItem.ImageIndex = 0;
                    lstViewItem.Tag = jobReference.id.ToString();
                    lstViewItem.Text = jobReference.jobTitle;
                    lstViewItem.SubItems.Add(jobReference.owner);
                    lstViewItem.SubItems.Add(jobReference.time.ToShortDateString() + ' ' + jobReference.time.ToLongTimeString());
                    lstSignedJobs.Items.Add(lstViewItem);
                }
                toolStripTotalJobs.Text = "" + jobReferences.Length + Tools.GetLocalizedString("SignedDocs");
                timerRefresh.Start();
            }
            catch (Exception exc)
            {
                timerRefresh.Stop();
                toolStripTotalJobs.Text = "";
                toolStripCurrentUser.Text = "";
                this.Cursor = Cursors.Default;
                this.Show();
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

        private void lstDeletePendingJobs()
        {
            SignatureQueueServiceClient service = null;

            try
            {
                if (lstPendingJobs.SelectedItems.Count == 0)
                {
                    return;
                }
                if (MessageBox.Show(this, Tools.GetLocalizedString("RemoveSelectedJobs"), Tools.GetLocalizedString("Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                service = WSTools.GetSignatureQueueServiceClient();
                foreach (ListViewItem lstViewItem in lstPendingJobs.SelectedItems)
                {
                    service.RemoveJob(Convert.ToInt32(lstViewItem.Tag));
                    lstPendingJobs.Items.Remove(lstViewItem);
                }

                toolStripTotalJobs.Text = "" + lstPendingJobs.Items.Count + Tools.GetLocalizedString("PendingDocs");
            }
            catch (Exception exc)
            {
                this.Cursor = Cursors.Default;
                this.Show();
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

        private void lstDeleteSignedJobs()
        {
            SignatureQueueServiceClient service = null;

            try
            {
                if (lstSignedJobs.SelectedItems.Count == 0)
                {
                    return;
                }
                if (MessageBox.Show(this, Tools.GetLocalizedString("RemoveSelectedJobs"), Tools.GetLocalizedString("Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                service = WSTools.GetSignatureQueueServiceClient();
                foreach (ListViewItem lstViewItem in lstSignedJobs.SelectedItems)
                {
                    service.RemoveJob(Convert.ToInt32(lstViewItem.Tag));
                    lstSignedJobs.Items.Remove(lstViewItem);
                }

                toolStripTotalJobs.Text = "" + lstSignedJobs.Items.Count + Tools.GetLocalizedString("SignedDocs");
            }
            catch (Exception exc)
            {
                this.Cursor = Cursors.Default;
                this.Show();
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

        private void changeOwner()
        {
            SignatureQueueServiceClient service = null;

            try
            {
                if (lstPendingJobs.SelectedItems.Count == 0)
                {
                    return;
                }
                string newOwner = Microsoft.VisualBasic.Interaction.InputBox(
                    Tools.GetLocalizedString("ChangeOwnerText"),
                    Tools.GetLocalizedString("ChangeOwnerTitle"), System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                if (newOwner == "")
                {
                    // User press cancel button
                    return;
                }

                if (newOwner.IndexOf('\\') == -1)
                {
                    // Concat the name of the user with the domain
                    newOwner = SystemInformation.UserDomainName + "\\" + newOwner;
                }

                this.Cursor = Cursors.WaitCursor;
                service = WSTools.GetSignatureQueueServiceClient();
                foreach (ListViewItem lstViewItem in lstPendingJobs.SelectedItems)
                {
                    service.ChangeJobOwner(Convert.ToInt32(lstViewItem.Tag), newOwner);
                }
                lstPendingJobsRefresh(true);
            }
            catch (Exception exc)
            {
                this.Cursor = Cursors.Default;
                this.Show();
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

        private void addJob()
        {
            try
            {
                if (addFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string[] newFiles = new string[1];
                newFiles[0] = addFileDialog.FileName;
                addJob(newFiles);
            }
            catch (Exception exc)
            {
                this.Cursor = Cursors.Default;
                this.Show();
                Tools.ShowUnexpectedError(this, exc);
            }
        }

        private void addJob(string[] newFiles)
        {
            SignatureQueueServiceClient service = null;
            Stream newJobStream = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                service = WSTools.GetSignatureQueueServiceClient();
                foreach (string filePath in newFiles)
                {
                    if (System.IO.Path.GetExtension(filePath).ToUpper() == ".PDF")
                    {
                        newJobStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        service.AddJob("SealSignSQSClient",
                                       0,
                                       System.IO.Path.GetFileName(filePath),
                                       Tools.StreamToByteArray(newJobStream),
                                       "");
                        newJobStream.Close();
                    }
                }
                if (service != null)
                {
                    service.Close();
                    service = null;
                }
                lstPendingJobsRefresh(true);
            }
            catch (Exception exc)
            {
                this.Cursor = Cursors.Default;
                this.Show();
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

        private void showPendingJob()
        {
            DialogResult result = System.Windows.Forms.DialogResult.Cancel;

            if (lstPendingJobs.SelectedItems.Count != 1)
            {
                return;
            }
            timerRefresh.Stop();
            try
            {
                DocumentForm documentForm = new DocumentForm(Convert.ToInt32(lstPendingJobs.SelectedItems[0].Tag));
                result = documentForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Tools.ShowUnexpectedError(this, ex);
            }
            timerRefresh.Start();
            if (result == DialogResult.OK)
            {
                lstPendingJobsRefresh(true);
                /*lstPendingJobs.Items.Remove(lstPendingJobs.SelectedItems[0]);
                toolStripTotalJobs.Text = "" + lstPendingJobs.Items.Count + Tools.GetLocalizedString("PendingDocs");*/
            }
        }

        private void showSignedJob()
        {
            DialogResult result = System.Windows.Forms.DialogResult.Cancel;
            if (lstSignedJobs.SelectedItems.Count != 1)
            {
                return;
            }

            timerRefresh.Stop();
            try
            {
                DocumentForm documentForm = new DocumentForm(Convert.ToInt32(lstSignedJobs.SelectedItems[0].Tag));
                result = documentForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Tools.ShowUnexpectedError(this, ex);
            }
            timerRefresh.Start();
            if (result == DialogResult.OK)
            {
                lstSignedJobsRefresh();
                /*lstSignedJobs.Items.Remove(lstSignedJobs.SelectedItems[0]);
                toolStripTotalJobs.Text = "" + lstSignedJobs.Items.Count + Tools.GetLocalizedString("SignedDocs");*/
            }
        }

        private void showUserCredentialsForm()
        {
            UserCredentialsForm userForm = new UserCredentialsForm();
            DialogResult result = userForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                if (tabControl1.SelectedTab == tabPendingJobs)
                {
                    lstSignedJobsRefresh();
                }
                else
                {
                    lstSignedJobsRefresh();
                }
                toolStripCurrentUser.Text = WSTools.GetServiceCurrentUser();
            }
        }


        private void showConfigurationForm()
        {
            ConfigurationForm configForm = new ConfigurationForm();
            DialogResult result = configForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                if (tabControl1.SelectedTab == tabPendingJobs)
                {
                    lstSignedJobsRefresh();
                }
                else
                {
                    lstSignedJobsRefresh();
                }

                int interval = Convert.ToInt32(Tools.GetAppSettings("RefreshTimeout")) * 1000;
                if (interval == 0)
                {
                    //timerRefresh.Interval = 60000;
                    timerRefresh.Stop();
                }
                else
                {
                    timerRefresh.Interval = interval;
                    timerRefresh.Start();
                }
            }
        }

        private void JobListForm_Load(object sender, EventArgs e)
        {
            m_bLoading = true;

            /*try
            {
                AppDomain myDomain = Thread.GetDomain();

                myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                WindowsPrincipal myPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;

                PrincipalPermission adminPermission = new PrincipalPermission(null, "SealSignSQS Admins");
                adminPermission.Demand();
                // Si el usuario es admin mostramos el menú de parámetros de firma
                mnuParameters.Visible = true;
            }
            catch
            {
            }*/

            m_lvwColumnSorter = new ListViewColumnSorter();
            lstPendingJobs.ListViewItemSorter = m_lvwColumnSorter;
            lstSignedJobs.ListViewItemSorter = m_lvwColumnSorter;

            //this.WindowState = FormWindowState.Minimized;
            this.Hide();
            int interval = Convert.ToInt32(Tools.GetAppSettings("RefreshTimeout")) * 1000;
            if (interval == 0)
            {
                //timerRefresh.Interval = 60000;
                timerRefresh.Stop();
            }
            else
            {
                timerRefresh.Interval = interval;
                timerRefresh.Start();
            }
            lstPendingJobsRefresh(true);
            toolStripCurrentUser.Text = WSTools.GetServiceCurrentUser();
            m_bLoading = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedTab == tabPendingJobs)
            {
                lstPendingJobs.SelectedItems.Clear();
                mnuAddJob.Enabled = true;
                mnuOpenJob.Visible = false;
                mnuSignJob.Visible = true;
                mnuSignJob.Enabled = false;
                mnuDeleteJob.Enabled = false;
                mnuChangeOwner.Enabled = false;
                lstPendingJobsRefresh(true);
            }
            else
            {
                lstSignedJobs.SelectedItems.Clear();
                mnuAddJob.Enabled = false;
                mnuSignJob.Visible = false;
                mnuSignJob.Enabled = false;
                mnuOpenJob.Visible = true;
                mnuOpenJob.Enabled = false;
                mnuDeleteJob.Enabled = false;
                mnuChangeOwner.Enabled = false;
                lstSignedJobsRefresh();
            }
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPendingJobs)
            {
                lstPendingJobsRefresh(true);
            }
            else
            {
                lstSignedJobsRefresh();
            }
        }

        private void toolStripCurrentUser_DoubleClick(object sender, EventArgs e)
        {
            showUserCredentialsForm();
        }

        private void lstPendingJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstPendingJobs.SelectedItems.Count)
            {
                case 0:
                    mnuAddJob.Enabled = true;
                    mnuOpenJob.Visible = false;
                    mnuSignJob.Enabled = false;
                    mnuDeleteJob.Enabled = false;
                    mnuChangeOwner.Enabled = false;
                    break;
                case 1:
                    mnuAddJob.Enabled = true;
                    mnuOpenJob.Visible = false;
                    mnuSignJob.Enabled = true;
                    mnuChangeOwner.Enabled = true;
                    mnuDeleteJob.Enabled = true;

                    mnuContextSign.Visible = true;
                    mnuContextChangeOwner.Visible = true;
                    mnuContextDeletePending.Visible = true;
                    break;
                default:    // Multiple selection
                    mnuAddJob.Enabled = true;
                    mnuOpenJob.Visible = false;
                    mnuSignJob.Enabled = false;
                    mnuChangeOwner.Enabled = true;
                    mnuDeleteJob.Enabled = true;

                    mnuContextSign.Visible = false;
                    mnuContextChangeOwner.Visible = true;
                    mnuContextDeletePending.Visible = true;
                    break;
            }
        }

        private void lstSignedJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            mnuAddJob.Enabled = false;
            mnuSignJob.Visible = false;
            mnuOpenJob.Visible = true;
            mnuChangeOwner.Enabled = false;

            switch (lstSignedJobs.SelectedItems.Count)
            {
                case 0:
                    mnuOpenJob.Enabled = false;
                    mnuDeleteJob.Enabled = false;
                    break;
                case 1:
                    mnuOpenJob.Enabled = true;
                    mnuDeleteJob.Enabled = true;

                    mnuContextOpenSigned.Visible = true;
                    mnuContextDeleteSigned.Visible = true;
                    break;
                default:    // Multiple selection
                    mnuOpenJob.Enabled = false;
                    mnuDeleteJob.Enabled = true;

                    mnuContextOpenSigned.Visible = false;
                    mnuContextDeleteSigned.Visible = true;
                    break;
            }
        }

        private void mnuDeleteJob_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPendingJobs)
            {
                lstDeletePendingJobs();
            }
            else
            {
                lstDeleteSignedJobs();
            }
        }

        private void mnuContextDeletePending_Click(object sender, EventArgs e)
        {
            lstDeletePendingJobs();
        }

        private void mnuContextDeleteSigned_Click(object sender, EventArgs e)
        {
            lstDeleteSignedJobs();
        }

        private void contextMenuPendingJobs_Opening(object sender, CancelEventArgs e)
        {
            if (lstPendingJobs.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void contextMenuSignedJobs_Opening(object sender, CancelEventArgs e)
        {
            if (lstSignedJobs.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void mnuChangeOwner_Click(object sender, EventArgs e)
        {
            changeOwner();
        }

        private void mnuContextChangeOwner_Click(object sender, EventArgs e)
        {
            changeOwner();
        }

        private void mnuAddJob_Click(object sender, EventArgs e)
        {
            addJob();
        }

        private void mnuNotifyExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void mnuNotifyOpen_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Show();
            this.Activate();
        }

        private void JobListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void lstPendingJobs_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (string fileName in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    if (System.IO.Path.GetExtension(fileName).ToUpper() == ".PDF")
                    {
                        e.Effect = DragDropEffects.Copy;
                        break;
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
                }
            }
        }

        private void lstPendingJobs_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                addJob((string[])e.Data.GetData(DataFormats.FileDrop));
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            lstPendingJobsRefresh(false);
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Show();
            tabControl1.SelectedTab = tabPendingJobs;
            this.Activate();
        }

        private void mnuContextSign_Click(object sender, EventArgs e)
        {
            showPendingJob();
        }

        private void mnuSignJob_Click(object sender, EventArgs e)
        {
            showPendingJob();
        }

        private void lstPendingJobs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showPendingJob();
        }

        private void mnuOpenJob_Click(object sender, EventArgs e)
        {
            showSignedJob();
        }

        private void mnuContextOpenSigned_Click(object sender, EventArgs e)
        {
            showSignedJob();
        }

        private void lstSignedJobs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showSignedJob();
        }

        private void JobListForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lstPendingJobs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == m_lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (m_lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    m_lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    m_lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                m_lvwColumnSorter.SortColumn = e.Column;
                m_lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstPendingJobs.Sort();
        }

        private void lstSignedJobs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == m_lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (m_lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    m_lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    m_lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                m_lvwColumnSorter.SortColumn = e.Column;
                m_lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lstSignedJobs.Sort();
        }

        private void mnuUserCredentials_Click(object sender, EventArgs e)
        {
            showUserCredentialsForm();
        }

        private void mnuParameters_Click(object sender, EventArgs e)
        {
            showConfigurationForm();
        }
    }
}
