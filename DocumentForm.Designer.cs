namespace SealSignSQSClient
{
    partial class DocumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripOwner = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripComputer = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSignDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOwner,
            this.toolStripTime,
            this.toolStripComputer});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripOwner
            // 
            this.toolStripOwner.DoubleClickEnabled = true;
            this.toolStripOwner.Name = "toolStripOwner";
            resources.ApplyResources(this.toolStripOwner, "toolStripOwner");
            // 
            // toolStripTime
            // 
            this.toolStripTime.Name = "toolStripTime";
            resources.ApplyResources(this.toolStripTime, "toolStripTime");
            // 
            // toolStripComputer
            // 
            this.toolStripComputer.Name = "toolStripComputer";
            resources.ApplyResources(this.toolStripComputer, "toolStripComputer");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSignDocument,
            this.mnuDeleteDocument});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // mnuSignDocument
            // 
            this.mnuSignDocument.Name = "mnuSignDocument";
            resources.ApplyResources(this.mnuSignDocument, "mnuSignDocument");
            this.mnuSignDocument.Click += new System.EventHandler(this.mnuSignDocument_Click);
            // 
            // mnuDeleteDocument
            // 
            this.mnuDeleteDocument.Name = "mnuDeleteDocument";
            resources.ApplyResources(this.mnuDeleteDocument, "mnuDeleteDocument");
            this.mnuDeleteDocument.Click += new System.EventHandler(this.mnuDeleteDocument_Click);
            // 
            // axAcroPDF1
            // 
            resources.ApplyResources(this.axAcroPDF1, "axAcroPDF1");
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            // 
            // DocumentForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DocumentForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DocumentForm_FormClosed);
            this.Load += new System.EventHandler(this.DocumentForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripOwner;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripComputer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSignDocument;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteDocument;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
    }
}