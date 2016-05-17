using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Security.Principal;
using System.Security.AccessControl;
using Native;
using System.Diagnostics;

namespace SealSignSQSClient
{
    static class Program
    {
        private static Mutex mutex = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bCreated = false;
            try
            {
                string mutexName = @"Local\SQSClient_" + Win32.GetOwnerProcess().ToUpper().Replace(@"\", "_");
                SecurityIdentifier AuthSid = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);

                MutexSecurity mSec = new MutexSecurity();
                MutexAccessRule rule = new MutexAccessRule(AuthSid, MutexRights.FullControl, AccessControlType.Allow);
                mSec.AddAccessRule(rule);
                mutex = new Mutex(false, mutexName, out bCreated, mSec);
            }
            catch (UnauthorizedAccessException ex)
            {
                //MessageBox.Show(WindowTools.GetForegroundWnd(), ex.Message);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(WindowTools.GetForegroundWnd(), ex.Message);
            }

            if (!bCreated || mutex == null)
            {
                EventLog.WriteEntry("SealSignSQSClient", "Another SealSignSQSClient instance is running.", EventLogEntryType.Warning, 1);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new JobListForm());

            GC.KeepAlive(mutex);
        }
    }
}
