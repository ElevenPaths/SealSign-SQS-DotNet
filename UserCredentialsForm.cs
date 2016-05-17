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
    public partial class UserCredentialsForm : Form
    {
        public UserCredentialsForm()
        {
            InitializeComponent();
        }

        private void UserCredentialsForm_Load(object sender, EventArgs e)
        {
            RegistryKey policyKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Policies\SmartAccess\SealSignSQSClient\Authentication", false);
            if (policyKey != null)
            {
                chkUseWindowsCredential.Checked = Convert.ToBoolean(policyKey.GetValue("UseWindowsCredential", false));
                if (!chkUseWindowsCredential.Checked)
                {
                    txtUsername.Text = policyKey.GetValue("SealSignSQSUserName", "").ToString();
                    txtPassword.Text = policyKey.GetValue("SealSignSQSPassword", "").ToString();
                    txtDomain.Text = policyKey.GetValue("SealSignSQSDomain", "").ToString();
                }
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                txtDomain.Enabled = false;
                chkUseWindowsCredential.Enabled = false;
                btnOK.Enabled = false;
                policyKey.Close();
            }
            else
            {
                RegistryKey userKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SmartAccess\SealSignSQSClient\Authentication", false);
                if (userKey != null)
                {
                    chkUseWindowsCredential.Checked = Convert.ToBoolean(userKey.GetValue("UseWindowsCredential", true));
                    if (!chkUseWindowsCredential.Checked)
                    {
                        txtUsername.Text = userKey.GetValue("SealSignSQSUserName", "").ToString();
                        txtPassword.Text = CryptTools.Decrypt(userKey.GetValue("SealSignSQSPassword", "").ToString());
                        txtDomain.Text = userKey.GetValue("SealSignSQSDomain", "").ToString();
                    }
                    txtUsername.Enabled = !chkUseWindowsCredential.Checked;
                    txtPassword.Enabled = !chkUseWindowsCredential.Checked;
                    txtDomain.Enabled = !chkUseWindowsCredential.Checked;
                    userKey.Close();
                }
            }
        }

        private void chkUseWindowsCredential_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = !chkUseWindowsCredential.Checked;
            txtPassword.Enabled = !chkUseWindowsCredential.Checked;
            txtDomain.Enabled = !chkUseWindowsCredential.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!chkUseWindowsCredential.Checked && txtUsername.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, Tools.GetLocalizedString("UsernameMandatory"), Tools.GetLocalizedString("Title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }
            if (!chkUseWindowsCredential.Checked && txtPassword.Text.Length == 0)
            {
                MessageBox.Show(this, Tools.GetLocalizedString("PasswordMandatory"), Tools.GetLocalizedString("Title"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }

            RegistryKey userKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SmartAccess\SealSignSQSClient\Authentication");
            if (userKey != null)
            {
                userKey.SetValue("UseWindowsCredential", chkUseWindowsCredential.Checked, RegistryValueKind.DWord);
                userKey.SetValue("SealSignSQSUserName", txtUsername.Text.Trim(), RegistryValueKind.String);
                userKey.SetValue("SealSignSQSPassword", (txtPassword.Text == "") ? "" : CryptTools.Encrypt(txtPassword.Text), RegistryValueKind.String);
                userKey.SetValue("SealSignSQSDomain", txtDomain.Text.Trim(), RegistryValueKind.String);
                userKey.Close();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
