namespace SealSignSQSClient
{
    partial class JobListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobListForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNotifyOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNotifyExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripTotalJobs = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPendingJobs = new System.Windows.Forms.TabPage();
            this.lstPendingJobs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuPendingJobs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextSign = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextChangeOwner = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextDeletePending = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabSignedJobs = new System.Windows.Forms.TabPage();
            this.lstSignedJobs = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuSignedJobs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextOpenSigned = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextDeleteSigned = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddJob = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpenJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSignJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangeOwner = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserCredentials = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuParameters = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.contextMenuNotifyIcon.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPendingJobs.SuspendLayout();
            this.contextMenuPendingJobs.SuspendLayout();
            this.tabSignedJobs.SuspendLayout();
            this.contextMenuSignedJobs.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuNotifyIcon;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuNotifyIcon
            // 
            this.contextMenuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNotifyOpen,
            this.mnuNotifyExit});
            this.contextMenuNotifyIcon.Name = "contextMenuNotifyIcon";
            resources.ApplyResources(this.contextMenuNotifyIcon, "contextMenuNotifyIcon");
            // 
            // mnuNotifyOpen
            // 
            this.mnuNotifyOpen.Name = "mnuNotifyOpen";
            resources.ApplyResources(this.mnuNotifyOpen, "mnuNotifyOpen");
            this.mnuNotifyOpen.Click += new System.EventHandler(this.mnuNotifyOpen_Click);
            // 
            // mnuNotifyExit
            // 
            this.mnuNotifyExit.Name = "mnuNotifyExit";
            resources.ApplyResources(this.mnuNotifyExit, "mnuNotifyExit");
            this.mnuNotifyExit.Click += new System.EventHandler(this.mnuNotifyExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTotalJobs,
            this.toolStripCurrentUser});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripTotalJobs
            // 
            this.toolStripTotalJobs.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripTotalJobs.Name = "toolStripTotalJobs";
            resources.ApplyResources(this.toolStripTotalJobs, "toolStripTotalJobs");
            // 
            // toolStripCurrentUser
            // 
            this.toolStripCurrentUser.DoubleClickEnabled = true;
            this.toolStripCurrentUser.Name = "toolStripCurrentUser";
            resources.ApplyResources(this.toolStripCurrentUser, "toolStripCurrentUser");
            this.toolStripCurrentUser.DoubleClick += new System.EventHandler(this.toolStripCurrentUser_DoubleClick);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPendingJobs);
            this.tabControl1.Controls.Add(this.tabSignedJobs);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPendingJobs
            // 
            this.tabPendingJobs.Controls.Add(this.lstPendingJobs);
            resources.ApplyResources(this.tabPendingJobs, "tabPendingJobs");
            this.tabPendingJobs.Name = "tabPendingJobs";
            this.tabPendingJobs.UseVisualStyleBackColor = true;
            // 
            // lstPendingJobs
            // 
            this.lstPendingJobs.AllowDrop = true;
            resources.ApplyResources(this.lstPendingJobs, "lstPendingJobs");
            this.lstPendingJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstPendingJobs.ContextMenuStrip = this.contextMenuPendingJobs;
            this.lstPendingJobs.FullRowSelect = true;
            this.lstPendingJobs.LargeImageList = this.imageList1;
            this.lstPendingJobs.Name = "lstPendingJobs";
            this.lstPendingJobs.SmallImageList = this.imageList1;
            this.lstPendingJobs.UseCompatibleStateImageBehavior = false;
            this.lstPendingJobs.View = System.Windows.Forms.View.Details;
            this.lstPendingJobs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstPendingJobs_ColumnClick);
            this.lstPendingJobs.SelectedIndexChanged += new System.EventHandler(this.lstPendingJobs_SelectedIndexChanged);
            this.lstPendingJobs.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstPendingJobs_DragDrop);
            this.lstPendingJobs.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstPendingJobs_DragEnter);
            this.lstPendingJobs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstPendingJobs_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // contextMenuPendingJobs
            // 
            this.contextMenuPendingJobs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContextSign,
            this.mnuContextChangeOwner,
            this.mnuContextDeletePending});
            this.contextMenuPendingJobs.Name = "contextMenuPendingJobs";
            resources.ApplyResources(this.contextMenuPendingJobs, "contextMenuPendingJobs");
            this.contextMenuPendingJobs.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuPendingJobs_Opening);
            // 
            // mnuContextSign
            // 
            this.mnuContextSign.Name = "mnuContextSign";
            resources.ApplyResources(this.mnuContextSign, "mnuContextSign");
            this.mnuContextSign.Click += new System.EventHandler(this.mnuContextSign_Click);
            // 
            // mnuContextChangeOwner
            // 
            this.mnuContextChangeOwner.Name = "mnuContextChangeOwner";
            resources.ApplyResources(this.mnuContextChangeOwner, "mnuContextChangeOwner");
            this.mnuContextChangeOwner.Click += new System.EventHandler(this.mnuContextChangeOwner_Click);
            // 
            // mnuContextDeletePending
            // 
            this.mnuContextDeletePending.Name = "mnuContextDeletePending";
            resources.ApplyResources(this.mnuContextDeletePending, "mnuContextDeletePending");
            this.mnuContextDeletePending.Click += new System.EventHandler(this.mnuContextDeletePending_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pdficon_small.png");
            // 
            // tabSignedJobs
            // 
            this.tabSignedJobs.Controls.Add(this.lstSignedJobs);
            resources.ApplyResources(this.tabSignedJobs, "tabSignedJobs");
            this.tabSignedJobs.Name = "tabSignedJobs";
            this.tabSignedJobs.UseVisualStyleBackColor = true;
            // 
            // lstSignedJobs
            // 
            resources.ApplyResources(this.lstSignedJobs, "lstSignedJobs");
            this.lstSignedJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lstSignedJobs.ContextMenuStrip = this.contextMenuSignedJobs;
            this.lstSignedJobs.FullRowSelect = true;
            this.lstSignedJobs.Name = "lstSignedJobs";
            this.lstSignedJobs.SmallImageList = this.imageList1;
            this.lstSignedJobs.UseCompatibleStateImageBehavior = false;
            this.lstSignedJobs.View = System.Windows.Forms.View.Details;
            this.lstSignedJobs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstSignedJobs_ColumnClick);
            this.lstSignedJobs.SelectedIndexChanged += new System.EventHandler(this.lstSignedJobs_SelectedIndexChanged);
            this.lstSignedJobs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSignedJobs_MouseDoubleClick);
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // columnHeader7
            // 
            resources.ApplyResources(this.columnHeader7, "columnHeader7");
            // 
            // contextMenuSignedJobs
            // 
            this.contextMenuSignedJobs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContextOpenSigned,
            this.mnuContextDeleteSigned});
            this.contextMenuSignedJobs.Name = "contextMenuSignedJobs";
            resources.ApplyResources(this.contextMenuSignedJobs, "contextMenuSignedJobs");
            this.contextMenuSignedJobs.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuSignedJobs_Opening);
            // 
            // mnuContextOpenSigned
            // 
            this.mnuContextOpenSigned.Name = "mnuContextOpenSigned";
            resources.ApplyResources(this.mnuContextOpenSigned, "mnuContextOpenSigned");
            this.mnuContextOpenSigned.Click += new System.EventHandler(this.mnuContextOpenSigned_Click);
            // 
            // mnuContextDeleteSigned
            // 
            this.mnuContextDeleteSigned.Name = "mnuContextDeleteSigned";
            resources.ApplyResources(this.mnuContextDeleteSigned, "mnuContextDeleteSigned");
            this.mnuContextDeleteSigned.Click += new System.EventHandler(this.mnuContextDeleteSigned_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJob,
            this.mnuView,
            this.configurationToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // mnuJob
            // 
            this.mnuJob.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddJob,
            this.toolStripSeparator1,
            this.mnuOpenJob,
            this.mnuSignJob,
            this.mnuChangeOwner,
            this.mnuDeleteJob});
            this.mnuJob.Name = "mnuJob";
            resources.ApplyResources(this.mnuJob, "mnuJob");
            // 
            // mnuAddJob
            // 
            this.mnuAddJob.Name = "mnuAddJob";
            resources.ApplyResources(this.mnuAddJob, "mnuAddJob");
            this.mnuAddJob.Click += new System.EventHandler(this.mnuAddJob_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // mnuOpenJob
            // 
            resources.ApplyResources(this.mnuOpenJob, "mnuOpenJob");
            this.mnuOpenJob.Name = "mnuOpenJob";
            this.mnuOpenJob.Click += new System.EventHandler(this.mnuOpenJob_Click);
            // 
            // mnuSignJob
            // 
            resources.ApplyResources(this.mnuSignJob, "mnuSignJob");
            this.mnuSignJob.Name = "mnuSignJob";
            this.mnuSignJob.Click += new System.EventHandler(this.mnuSignJob_Click);
            // 
            // mnuChangeOwner
            // 
            resources.ApplyResources(this.mnuChangeOwner, "mnuChangeOwner");
            this.mnuChangeOwner.Name = "mnuChangeOwner";
            this.mnuChangeOwner.Click += new System.EventHandler(this.mnuChangeOwner_Click);
            // 
            // mnuDeleteJob
            // 
            resources.ApplyResources(this.mnuDeleteJob, "mnuDeleteJob");
            this.mnuDeleteJob.Name = "mnuDeleteJob";
            this.mnuDeleteJob.Click += new System.EventHandler(this.mnuDeleteJob_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRefresh});
            this.mnuView.Name = "mnuView";
            resources.ApplyResources(this.mnuView, "mnuView");
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            resources.ApplyResources(this.mnuRefresh, "mnuRefresh");
            this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUserCredentials,
            this.mnuParameters});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            resources.ApplyResources(this.configurationToolStripMenuItem, "configurationToolStripMenuItem");
            // 
            // mnuUserCredentials
            // 
            this.mnuUserCredentials.Name = "mnuUserCredentials";
            resources.ApplyResources(this.mnuUserCredentials, "mnuUserCredentials");
            this.mnuUserCredentials.Click += new System.EventHandler(this.mnuUserCredentials_Click);
            // 
            // mnuParameters
            // 
            this.mnuParameters.Name = "mnuParameters";
            resources.ApplyResources(this.mnuParameters, "mnuParameters");
            this.mnuParameters.Click += new System.EventHandler(this.mnuParameters_Click);
            // 
            // addFileDialog
            // 
            this.addFileDialog.DefaultExt = "pdf";
            resources.ApplyResources(this.addFileDialog, "addFileDialog");
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 5000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // JobListForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MinimizeBox = false;
            this.Name = "JobListForm";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JobListForm_FormClosing);
            this.Load += new System.EventHandler(this.JobListForm_Load);
            this.Shown += new System.EventHandler(this.JobListForm_Shown);
            this.contextMenuNotifyIcon.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPendingJobs.ResumeLayout(false);
            this.contextMenuPendingJobs.ResumeLayout(false);
            this.tabSignedJobs.ResumeLayout(false);
            this.contextMenuSignedJobs.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTotalJobs;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCurrentUser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPendingJobs;
        private System.Windows.Forms.TabPage tabSignedJobs;
        private System.Windows.Forms.ListView lstPendingJobs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuJob;
        private System.Windows.Forms.ToolStripMenuItem mnuAddJob;
        private System.Windows.Forms.ToolStripMenuItem mnuSignJob;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteJob;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lstSignedJobs;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenJob;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeOwner;
        private System.Windows.Forms.ContextMenuStrip contextMenuPendingJobs;
        private System.Windows.Forms.ToolStripMenuItem mnuContextSign;
        private System.Windows.Forms.ToolStripMenuItem mnuContextDeletePending;
        private System.Windows.Forms.ToolStripMenuItem mnuContextChangeOwner;
        private System.Windows.Forms.ContextMenuStrip contextMenuSignedJobs;
        private System.Windows.Forms.ToolStripMenuItem mnuContextOpenSigned;
        private System.Windows.Forms.ToolStripMenuItem mnuContextDeleteSigned;
        private System.Windows.Forms.OpenFileDialog addFileDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuNotifyOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuNotifyExit;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUserCredentials;
        private System.Windows.Forms.ToolStripMenuItem mnuParameters;
    }
}