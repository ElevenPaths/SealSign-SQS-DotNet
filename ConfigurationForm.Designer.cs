namespace SealSignSQSClient
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTipLogo = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPicture = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericWacomScreen = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.chkDTUMode = new System.Windows.Forms.CheckBox();
            this.btnOKBackground = new System.Windows.Forms.Button();
            this.btnCancelBackground = new System.Windows.Forms.Button();
            this.btnScrollBackground = new System.Windows.Forms.Button();
            this.btnFrame2 = new System.Windows.Forms.Button();
            this.btnTitle = new System.Windows.Forms.Button();
            this.btnFrame1 = new System.Windows.Forms.Button();
            this.btnWindow = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numericClientRefresh = new System.Windows.Forms.NumericUpDown();
            this.numericReceiveTimeout = new System.Windows.Forms.NumericUpDown();
            this.numericSendTimeout = new System.Windows.Forms.NumericUpDown();
            this.numericOpenTimeout = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServiceUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWacomScreen)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericClientRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReceiveTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSendTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOpenTimeout)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // openFileDialog1
            // 
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.btnPicture);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.numericWacomScreen);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.chkDTUMode);
            this.tabPage3.Controls.Add(this.btnOKBackground);
            this.tabPage3.Controls.Add(this.btnCancelBackground);
            this.tabPage3.Controls.Add(this.btnScrollBackground);
            this.tabPage3.Controls.Add(this.btnFrame2);
            this.tabPage3.Controls.Add(this.btnTitle);
            this.tabPage3.Controls.Add(this.btnFrame1);
            this.tabPage3.Controls.Add(this.btnWindow);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnPicture
            // 
            this.btnPicture.BackColor = System.Drawing.Color.White;
            this.btnPicture.BackgroundImage = global::SealSignSQSClient.Properties.Resources.Logo;
            resources.ApplyResources(this.btnPicture, "btnPicture");
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.UseVisualStyleBackColor = false;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // numericWacomScreen
            // 
            resources.ApplyResources(this.numericWacomScreen, "numericWacomScreen");
            this.numericWacomScreen.Name = "numericWacomScreen";
            this.numericWacomScreen.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // chkDTUMode
            // 
            resources.ApplyResources(this.chkDTUMode, "chkDTUMode");
            this.chkDTUMode.Name = "chkDTUMode";
            this.chkDTUMode.UseVisualStyleBackColor = true;
            // 
            // btnOKBackground
            // 
            this.btnOKBackground.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOKBackground.BackgroundImage = global::SealSignSQSClient.Properties.Resources.Actions_dialog_ok_icon;
            resources.ApplyResources(this.btnOKBackground, "btnOKBackground");
            this.btnOKBackground.Name = "btnOKBackground";
            this.btnOKBackground.UseVisualStyleBackColor = false;
            this.btnOKBackground.Click += new System.EventHandler(this.btnOKBackground_Click);
            // 
            // btnCancelBackground
            // 
            this.btnCancelBackground.BackColor = System.Drawing.Color.Red;
            this.btnCancelBackground.BackgroundImage = global::SealSignSQSClient.Properties.Resources.Actions_edit_delete_icon;
            resources.ApplyResources(this.btnCancelBackground, "btnCancelBackground");
            this.btnCancelBackground.Name = "btnCancelBackground";
            this.btnCancelBackground.UseVisualStyleBackColor = false;
            this.btnCancelBackground.Click += new System.EventHandler(this.btnCancelBackground_Click);
            // 
            // btnScrollBackground
            // 
            this.btnScrollBackground.BackColor = System.Drawing.Color.Gray;
            this.btnScrollBackground.BackgroundImage = global::SealSignSQSClient.Properties.Resources.Actions_go_next_view_page_icon;
            resources.ApplyResources(this.btnScrollBackground, "btnScrollBackground");
            this.btnScrollBackground.Name = "btnScrollBackground";
            this.btnScrollBackground.UseVisualStyleBackColor = false;
            this.btnScrollBackground.Click += new System.EventHandler(this.btnScrollBackground_Click);
            // 
            // btnFrame2
            // 
            this.btnFrame2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(36)))), ((int)(((byte)(37)))));
            resources.ApplyResources(this.btnFrame2, "btnFrame2");
            this.btnFrame2.Name = "btnFrame2";
            this.btnFrame2.UseVisualStyleBackColor = false;
            this.btnFrame2.Click += new System.EventHandler(this.btnFrame2_Click);
            // 
            // btnTitle
            // 
            this.btnTitle.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnTitle, "btnTitle");
            this.btnTitle.Name = "btnTitle";
            this.btnTitle.UseVisualStyleBackColor = false;
            this.btnTitle.Click += new System.EventHandler(this.btnTitle_Click);
            // 
            // btnFrame1
            // 
            this.btnFrame1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(36)))), ((int)(((byte)(37)))));
            resources.ApplyResources(this.btnFrame1, "btnFrame1");
            this.btnFrame1.Name = "btnFrame1";
            this.btnFrame1.UseVisualStyleBackColor = false;
            this.btnFrame1.Click += new System.EventHandler(this.btnFrame1_Click);
            // 
            // btnWindow
            // 
            this.btnWindow.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnWindow, "btnWindow");
            this.btnWindow.Name = "btnWindow";
            this.btnWindow.UseVisualStyleBackColor = false;
            this.btnWindow.Click += new System.EventHandler(this.btnWindow_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numericClientRefresh);
            this.tabPage1.Controls.Add(this.numericReceiveTimeout);
            this.tabPage1.Controls.Add(this.numericSendTimeout);
            this.tabPage1.Controls.Add(this.numericOpenTimeout);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtServiceUrl);
            this.tabPage1.Controls.Add(this.label1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numericClientRefresh
            // 
            resources.ApplyResources(this.numericClientRefresh, "numericClientRefresh");
            this.numericClientRefresh.Name = "numericClientRefresh";
            this.numericClientRefresh.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numericReceiveTimeout
            // 
            resources.ApplyResources(this.numericReceiveTimeout, "numericReceiveTimeout");
            this.numericReceiveTimeout.Name = "numericReceiveTimeout";
            this.numericReceiveTimeout.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numericSendTimeout
            // 
            resources.ApplyResources(this.numericSendTimeout, "numericSendTimeout");
            this.numericSendTimeout.Name = "numericSendTimeout";
            this.numericSendTimeout.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numericOpenTimeout
            // 
            resources.ApplyResources(this.numericOpenTimeout, "numericOpenTimeout");
            this.numericOpenTimeout.Name = "numericOpenTimeout";
            this.numericOpenTimeout.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtServiceUrl
            // 
            resources.ApplyResources(this.txtServiceUrl, "txtServiceUrl");
            this.txtServiceUrl.Name = "txtServiceUrl";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWacomScreen)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericClientRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericReceiveTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSendTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOpenTimeout)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTipLogo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericWacomScreen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkDTUMode;
        private System.Windows.Forms.Button btnOKBackground;
        private System.Windows.Forms.Button btnCancelBackground;
        private System.Windows.Forms.Button btnScrollBackground;
        private System.Windows.Forms.Button btnFrame2;
        private System.Windows.Forms.Button btnTitle;
        private System.Windows.Forms.Button btnFrame1;
        private System.Windows.Forms.Button btnWindow;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown numericClientRefresh;
        private System.Windows.Forms.NumericUpDown numericReceiveTimeout;
        private System.Windows.Forms.NumericUpDown numericSendTimeout;
        private System.Windows.Forms.NumericUpDown numericOpenTimeout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServiceUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;

    }
}