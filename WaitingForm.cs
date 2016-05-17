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

namespace SealSignSQSClient
{
    public partial class WaitingForm : Form
    {
        internal string m_message;
        private int m_monitorNumber = -1;

        public WaitingForm(int monitorNumber, string message)
        {
            InitializeComponent();

            m_monitorNumber = monitorNumber;
            m_message = message;
            lblProgress.Text = m_message;
        }

        public WaitingForm(string message)
        {
            InitializeComponent();

            m_monitorNumber = -1;
            m_message = message;
            lblProgress.Text = m_message;
        }

        public void SetMessage(string message)
        {
            this.m_message = message;
            lblProgress.Text = m_message;
        }

        public void SetMessage(string message, int timeout)
        {
            this.m_message = message;
            lblProgress.Text = m_message;            
            lblProgress.AutoSize = false;
            lblProgress.Left = 0;
            lblProgress.Width = this.Width;
            lblProgress.TextAlign = ContentAlignment.MiddleCenter;
            lblProgress.Refresh();
            progressBar1.Visible = false;
            Thread.Sleep(timeout);
        }


        private void showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = sc.Length - 1;
            }

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left +
                (sc[showOnMonitor].Bounds.Right - sc[showOnMonitor].Bounds.Left - this.Width) / 2,
                sc[showOnMonitor].Bounds.Top +
                (sc[showOnMonitor].Bounds.Bottom - sc[showOnMonitor].Bounds.Top - this.Height) / 2);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;

        }

        private void WaitingForm_Load(object sender, EventArgs e)
        {
            if (m_monitorNumber != -1)
            {
                showOnMonitor(m_monitorNumber);
            }
        }
    }
}
