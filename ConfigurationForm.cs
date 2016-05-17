using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SealSignSQSClient
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void btnWindow_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.Color = btnWindow.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                btnWindow.BackColor = colorDialog1.Color;
                btnPicture.BackColor = colorDialog1.Color;
                btnTitle.BackColor = colorDialog1.Color;
            }
        }

        private void btnTitle_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.Color = btnTitle.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                btnTitle.ForeColor = colorDialog1.Color;
            }
        }

        private void btnFrame1_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.Color = btnFrame1.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                btnFrame1.BackColor = colorDialog1.Color;
                btnFrame2.BackColor = colorDialog1.Color;
            }
        }

        private void btnFrame2_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.Color = btnFrame2.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                btnFrame1.BackColor = colorDialog1.Color;
                btnFrame2.BackColor = colorDialog1.Color;
            }
        }

        private void btnScrollBackground_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.Color = btnScrollBackground.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                btnScrollBackground.BackColor = colorDialog1.Color;
            }
        }

        private void btnCancelBackground_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.Color = btnCancelBackground.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                btnCancelBackground.BackColor = colorDialog1.Color;
            }
        }

        private void btnOKBackground_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.Color = btnOKBackground.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                btnOKBackground.BackColor = colorDialog1.Color;
            }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                pictureBox1.Load(openFileDialog1.FileName);
                btnPicture.BackgroundImage = pictureBox1.Image;
                toolTipLogo.SetToolTip(btnPicture, openFileDialog1.FileName);
            }
            catch (Exception exc)
            {
                this.Cursor = Cursors.Default;
                this.Show();
                Tools.ShowUnexpectedError(this, exc);
            }

        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            string Logo = "";
            string TitleColor = "";
            string WindowColor = "";
            string FrameColor = "";
            string ScrollButtonColor = "";
            string CancelButtonColor = "";
            string OKButtonColor = "";

            RegistryKey policyKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Policies\SmartAccess\SealSignSQSClient\SignatureParameters", false);
            if (policyKey != null)
            {
                txtServiceUrl.Text = policyKey.GetValue("SealSignSQSServiceURL", "").ToString();
                numericOpenTimeout.Value = Convert.ToInt32(policyKey.GetValue("OpenTimeout", 60));
                numericSendTimeout.Value = Convert.ToInt32(policyKey.GetValue("SendTimeout", 60));
                numericReceiveTimeout.Value = Convert.ToInt32(policyKey.GetValue("ReceiveTimeout", 60));
                numericClientRefresh.Value = Convert.ToInt32(policyKey.GetValue("RefreshTimeout", 60));

                chkDTUMode.Checked = Convert.ToBoolean(policyKey.GetValue("wacom_dtu_mode", false));
                numericWacomScreen.Value = Convert.ToInt32(policyKey.GetValue("wacom_dtu_screen_number", 2));

                Logo = policyKey.GetValue("Logo", "").ToString();
                WindowColor = policyKey.GetValue("WindowColor", "").ToString();
                TitleColor = policyKey.GetValue("TitleColor", "").ToString();
                FrameColor = policyKey.GetValue("FrameColor", "").ToString();
                ScrollButtonColor = policyKey.GetValue("ScrollButtonColor", "").ToString();
                CancelButtonColor = policyKey.GetValue("CancelButtonColor", "").ToString();
                OKButtonColor = policyKey.GetValue("OKButtonColor", "").ToString();

                txtServiceUrl.Enabled = false;
                numericOpenTimeout.Enabled = false;
                numericSendTimeout.Enabled = false;
                numericReceiveTimeout.Enabled = false;
                numericClientRefresh.Enabled = false;
                chkDTUMode.Enabled = false;
                numericWacomScreen.Enabled = false;
                btnPicture.Enabled = false;
                btnWindow.Enabled = false;
                btnTitle.Enabled = false;
                btnFrame1.Enabled = false;
                btnFrame2.Enabled = false;
                btnScrollBackground.Enabled = false;
                btnCancelBackground.Enabled = false;
                btnOKBackground.Enabled = false;
                btnOK.Enabled = false;
                policyKey.Close();
            }
            else
            {
                RegistryKey userKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SmartAccess\SealSignSQSClient\SignatureParameters", false);
                if (userKey != null)
                {
                    txtServiceUrl.Text = userKey.GetValue("SealSignSQSServiceURL", "").ToString();
                    numericOpenTimeout.Value = Convert.ToInt32(userKey.GetValue("OpenTimeout", 60));
                    numericSendTimeout.Value = Convert.ToInt32(userKey.GetValue("SendTimeout", 60));
                    numericReceiveTimeout.Value = Convert.ToInt32(userKey.GetValue("ReceiveTimeout", 60));
                    numericClientRefresh.Value = Convert.ToInt32(userKey.GetValue("RefreshTimeout", 60));

                    chkDTUMode.Checked = Convert.ToBoolean(userKey.GetValue("wacom_dtu_mode", false));
                    numericWacomScreen.Value = Convert.ToInt32(userKey.GetValue("wacom_dtu_screen_number", 2));

                    Logo = userKey.GetValue("Logo", "").ToString();
                    WindowColor = userKey.GetValue("WindowColor", "").ToString();
                    TitleColor = userKey.GetValue("TitleColor", "").ToString();
                    FrameColor = userKey.GetValue("FrameColor", "").ToString();
                    ScrollButtonColor = userKey.GetValue("ScrollButtonColor", "").ToString();
                    CancelButtonColor = userKey.GetValue("CancelButtonColor", "").ToString();
                    OKButtonColor = userKey.GetValue("OKButtonColor", "").ToString();

                    txtServiceUrl.Enabled = true;
                    numericOpenTimeout.Enabled = true;
                    numericSendTimeout.Enabled = true;
                    numericReceiveTimeout.Enabled = true;
                    numericClientRefresh.Enabled = true;
                    chkDTUMode.Enabled = true;
                    numericWacomScreen.Enabled = true;
                    btnPicture.Enabled = true;
                    btnWindow.Enabled = true;
                    btnTitle.Enabled = true;
                    btnFrame1.Enabled = true;
                    btnFrame2.Enabled = true;
                    btnScrollBackground.Enabled = true;
                    btnCancelBackground.Enabled = true;
                    btnOKBackground.Enabled = true;
                    btnOK.Enabled = true;
                    userKey.Close();
                }
            }

            if (Logo != "")
            {
                try
                {
                    pictureBox1.Load(Logo);
                    btnPicture.BackgroundImage = pictureBox1.Image;
                    toolTipLogo.SetToolTip(btnPicture, Logo);
                    openFileDialog1.FileName = Logo;
                }
                catch { }
            }

            if (WindowColor != "")
            {
                btnWindow.BackColor = System.Drawing.ColorTranslator.FromHtml(WindowColor);
                btnTitle.BackColor = btnWindow.BackColor;
                btnPicture.BackColor = btnWindow.BackColor;
            }
            if (TitleColor != "") btnTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml(TitleColor);
            if (FrameColor != "")
            {
                btnFrame1.BackColor = System.Drawing.ColorTranslator.FromHtml(FrameColor);
                btnFrame2.BackColor = btnFrame1.BackColor;
            }
            if (ScrollButtonColor != "") btnScrollBackground.BackColor = System.Drawing.ColorTranslator.FromHtml(ScrollButtonColor);
            if (CancelButtonColor != "") btnCancelBackground.BackColor = System.Drawing.ColorTranslator.FromHtml(CancelButtonColor);
            if (OKButtonColor != "") btnOKBackground.BackColor = System.Drawing.ColorTranslator.FromHtml(OKButtonColor);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtServiceUrl.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, Tools.GetLocalizedString("ServiceUrlMandatory"), Tools.GetLocalizedString("Title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServiceUrl.Focus();
                tabControl1.Select();
                return;
            }

            RegistryKey userKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SmartAccess\SealSignSQSClient\SignatureParameters");
            if (userKey != null)
            {
                userKey.SetValue("SealSignSQSServiceURL", txtServiceUrl.Text, RegistryValueKind.String);
                userKey.SetValue("OpenTimeout", numericOpenTimeout.Value, RegistryValueKind.DWord);
                userKey.SetValue("SendTimeout", numericSendTimeout.Value, RegistryValueKind.DWord);
                userKey.SetValue("ReceiveTimeout", numericReceiveTimeout.Value, RegistryValueKind.DWord);
                userKey.SetValue("RefreshTimeout", numericClientRefresh.Value, RegistryValueKind.DWord);

                userKey.SetValue("wacom_dtu_mode", chkDTUMode.Checked, RegistryValueKind.DWord);
                userKey.SetValue("wacom_dtu_screen_number", numericWacomScreen.Value, RegistryValueKind.DWord);

                userKey.SetValue("Logo", openFileDialog1.FileName, RegistryValueKind.String);
                userKey.SetValue("WindowColor", System.Drawing.ColorTranslator.ToHtml(btnWindow.BackColor), RegistryValueKind.String);
                userKey.SetValue("TitleColor", System.Drawing.ColorTranslator.ToHtml(btnTitle.ForeColor), RegistryValueKind.String);
                userKey.SetValue("FrameColor", System.Drawing.ColorTranslator.ToHtml(btnFrame1.BackColor), RegistryValueKind.String);
                userKey.SetValue("ScrollButtonColor", System.Drawing.ColorTranslator.ToHtml(btnScrollBackground.BackColor), RegistryValueKind.String);
                userKey.SetValue("CancelButtonColor", System.Drawing.ColorTranslator.ToHtml(btnCancelBackground.BackColor), RegistryValueKind.String);
                userKey.SetValue("OKButtonColor", System.Drawing.ColorTranslator.ToHtml(btnOKBackground.BackColor), RegistryValueKind.String);

                userKey.Close();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
