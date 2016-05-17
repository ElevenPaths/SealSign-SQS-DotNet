namespace SealSignSQSClient
{
    partial class STUSignatureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STUSignatureForm));
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.framePanel = new System.Windows.Forms.Panel();
            this.sealSignBSSWacomSTUPanel1 = new SealSignBSSClientLibrary.SealSignBSSWacomSTUPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.framePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BackColor = System.Drawing.Color.White;
            this.backgroundPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundPanel.Controls.Add(this.buttonsPanel);
            this.backgroundPanel.Controls.Add(this.lblTitle);
            this.backgroundPanel.Controls.Add(this.framePanel);
            this.backgroundPanel.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.backgroundPanel, "backgroundPanel");
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.backgroundPanel_Paint);
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(36)))), ((int)(((byte)(37)))));
            this.buttonsPanel.Controls.Add(this.btnCancel);
            this.buttonsPanel.Controls.Add(this.btnSign);
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = global::SealSignSQSClient.Properties.Resources.delete;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSign
            // 
            resources.ApplyResources(this.btnSign, "btnSign");
            this.btnSign.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSign.ForeColor = System.Drawing.Color.White;
            this.btnSign.Image = global::SealSignSQSClient.Properties.Resources.Icojam_Blue_Bits_Symbol_check__1_;
            this.btnSign.Name = "btnSign";
            this.btnSign.UseVisualStyleBackColor = false;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // framePanel
            // 
            this.framePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(36)))), ((int)(((byte)(37)))));
            this.framePanel.Controls.Add(this.sealSignBSSWacomSTUPanel1);
            resources.ApplyResources(this.framePanel, "framePanel");
            this.framePanel.Name = "framePanel";
            // 
            // sealSignBSSWacomSTUPanel1
            // 
            resources.ApplyResources(this.sealSignBSSWacomSTUPanel1, "sealSignBSSWacomSTUPanel1");
            this.sealSignBSSWacomSTUPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sealSignBSSWacomSTUPanel1.Name = "sealSignBSSWacomSTUPanel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::SealSignSQSClient.Properties.Resources.Logo;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // STUSignatureForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.backgroundPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "STUSignatureForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSignature_FormClosed);
            this.Load += new System.EventHandler(this.frmSignature_Load);
            this.backgroundPanel.ResumeLayout(false);
            this.buttonsPanel.ResumeLayout(false);
            this.framePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel framePanel;
        private SealSignBSSClientLibrary.SealSignBSSWacomSTUPanel sealSignBSSWacomSTUPanel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSign;
    }
}

