namespace SealSignSQSClient
{
    partial class DTUDocumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DTUDocumentForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRePag = new System.Windows.Forms.Button();
            this.btnAvPag = new System.Windows.Forms.Button();
            this.btnBioSign = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(36)))), ((int)(((byte)(37)))));
            this.panel2.Controls.Add(this.axAcroPDF1);
            this.panel2.Name = "panel2";
            // 
            // axAcroPDF1
            // 
            resources.ApplyResources(this.axAcroPDF1, "axAcroPDF1");
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(36)))), ((int)(((byte)(37)))));
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnRePag);
            this.panel1.Controls.Add(this.btnAvPag);
            this.panel1.Controls.Add(this.btnBioSign);
            this.panel1.Name = "panel1";
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::SealSignSQSClient.Properties.Resources.delete;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnRePag
            // 
            resources.ApplyResources(this.btnRePag, "btnRePag");
            this.btnRePag.BackColor = System.Drawing.Color.Gray;
            this.btnRePag.ForeColor = System.Drawing.Color.White;
            this.btnRePag.Image = global::SealSignSQSClient.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_go_previous_view_page;
            this.btnRePag.Name = "btnRePag";
            this.btnRePag.UseVisualStyleBackColor = false;
            this.btnRePag.Click += new System.EventHandler(this.btnRePag_Click);
            // 
            // btnAvPag
            // 
            resources.ApplyResources(this.btnAvPag, "btnAvPag");
            this.btnAvPag.BackColor = System.Drawing.Color.Gray;
            this.btnAvPag.ForeColor = System.Drawing.Color.White;
            this.btnAvPag.Image = global::SealSignSQSClient.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_go_next_view_page;
            this.btnAvPag.Name = "btnAvPag";
            this.btnAvPag.UseVisualStyleBackColor = false;
            this.btnAvPag.Click += new System.EventHandler(this.btnAvPag_Click);
            // 
            // btnBioSign
            // 
            resources.ApplyResources(this.btnBioSign, "btnBioSign");
            this.btnBioSign.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBioSign.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBioSign.ForeColor = System.Drawing.Color.White;
            this.btnBioSign.Image = global::SealSignSQSClient.Properties.Resources.Icojam_Blue_Bits_Symbol_check__1_;
            this.btnBioSign.Name = "btnBioSign";
            this.btnBioSign.UseVisualStyleBackColor = false;
            this.btnBioSign.Click += new System.EventHandler(this.btnBioSign_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::SealSignSQSClient.Properties.Resources.Logo;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // DTUDocumentForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DTUDocumentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.DTUDocumentForm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRePag;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Button btnBioSign;
        private System.Windows.Forms.Button btnAvPag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;


    }
}