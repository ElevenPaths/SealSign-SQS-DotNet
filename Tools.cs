using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Configuration;
using Microsoft.Win32;

namespace SealSignSQSClient
{
    class Tools
    {
        public static void ShowUnexpectedError(Form parent, Exception ex)
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager("SealSignSQSClient.SealSignSQSClient", Assembly.GetExecutingAssembly());
            MessageBox.Show(parent, GetLocalizedString("GenericError") + ex.Message, GetLocalizedString("Title"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string GetLocalizedString(string name)
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager("SealSignSQSClient.SealSignSQSClient", Assembly.GetExecutingAssembly());
            return resources.GetString(name, System.Globalization.CultureInfo.CurrentUICulture);
        }

        public static byte[] StreamToByteArray(Stream input)
        {
            try
            {
                if (input.CanSeek)
                    input.Seek(0, SeekOrigin.Begin);
            }
            catch { }

            byte[] buffer = new byte[16 * 1024];

            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

        public static object GetAppSettings(string valueName)
        {
            object returnValue = null;
            RegistryKey policiesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Policies\SmartAccess\SealSignSQSClient\SignatureParameters", false);
            if (policiesKey == null)
            {
                policiesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SmartAccess\SealSignSQSClient\SignatureParameters", false);
            }
            if (policiesKey != null)
            {
                returnValue = policiesKey.GetValue(valueName, "").ToString();
                policiesKey.Close();
            }

            return returnValue;
        }
    }
}
