using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SealSignSQSClient
{
    public class ProgressWindow
    {
        internal WaitingForm waitForm = null;
        internal IWin32Window m_owner = null;
        Thread windowThread = null;
        private int m_monitorNumber = -1;

        public ProgressWindow(int monitorNumber)
        {
            m_monitorNumber = monitorNumber;
        }

        public ProgressWindow()
        {
            m_monitorNumber = -1;
        }

        private void WindowWorkerThread()
        {
            if (m_owner != null)
                waitForm.ShowDialog(m_owner);
            else
                waitForm.ShowDialog();
        }

        public void Show(IWin32Window owner, string message)
        {
            m_owner = owner;
            if (m_monitorNumber != -1)
            {
                waitForm = new WaitingForm(m_monitorNumber, message);
            }
            else
            {
                waitForm = new WaitingForm(message);
            }
            waitForm.Activate();
            windowThread = new Thread(new ThreadStart(WindowWorkerThread));
            windowThread.Start();
        }

        delegate void HideDelegate();
        public void Hide()
        {
            if (waitForm != null)
            {
                if (waitForm.InvokeRequired)
                    waitForm.Invoke(new HideDelegate(Hide), null);
                else
                    waitForm.Hide();
            }
            //if (waitForm != null) waitForm.Hide();
        }

        delegate void CloseDelegate();
        public void Close()
        {
            if (waitForm != null)
            {
                if (waitForm.InvokeRequired)
                    waitForm.Invoke(new CloseDelegate(Close), null);
                else
                    waitForm.Close();
                waitForm = null;
            }
            //if (waitForm != null) waitForm.Close();
        }

        delegate void SetMessageDelegate(string message);
        public void SetMessage(string message)
        {
            if (waitForm != null)
            {
                if (waitForm.InvokeRequired)
                    waitForm.Invoke(new SetMessageDelegate(SetMessage), new object[] { message });
                else
                    waitForm.SetMessage(message);
            }
            //if (waitForm != null) waitForm.SetMessage(message);
        }

        delegate void SetMessageDelegate2(string message, int timeout);
        public void SetMessage(string message, int timeout)
        {
            if (waitForm != null)
            {
                if (waitForm.InvokeRequired)
                    waitForm.Invoke(new SetMessageDelegate2(SetMessage), new object[] { message, timeout });
                else
                    waitForm.SetMessage(message, timeout);
            }
            //if (waitForm != null) waitForm.SetMessage(message);
        }

    }
}
