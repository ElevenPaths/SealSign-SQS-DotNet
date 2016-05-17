using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Microsoft.Win32;
using System.Configuration;
using SealSignSQSService;


namespace SealSignSQSClient
{
    class WSTools
    {
        private static void GetServiceUserCredentials(ref bool useWindowsCredentials, ref string userName, ref string password, ref string domainName)
        {
            RegistryKey policyKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Policies\SmartAccess\SealSignSQSClient\Authentication", false);
            if (policyKey != null)
            {
                useWindowsCredentials = Convert.ToBoolean(policyKey.GetValue("UseWindowsCredential", false));
                if (!useWindowsCredentials)
                {
                    userName = policyKey.GetValue("SealSignSQSUserName", "").ToString();
                    password = policyKey.GetValue("SealSignSQSPassword", "").ToString();
                    domainName = policyKey.GetValue("SealSignSQSDomain", "").ToString();
                }
                else
                {
                    userName = "";
                    password = "";
                    domainName = "";
                }
                policyKey.Close();
            }
            else
            {
                RegistryKey userKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SmartAccess\SealSignSQSClient\Authentication", false);
                if (userKey != null)
                {
                    useWindowsCredentials = Convert.ToBoolean(userKey.GetValue("UseWindowsCredential", true));
                    if (!useWindowsCredentials)
                    {
                        userName = userKey.GetValue("SealSignSQSUserName", "").ToString();
                        password =CryptTools.Decrypt(userKey.GetValue("SealSignSQSPassword", "").ToString());
                        domainName = userKey.GetValue("SealSignSQSDomain", "").ToString();
                    }
                    else
                    {
                        userName = "";
                        password = "";
                        domainName = "";
                    }                    
                    userKey.Close();
                }
            }
        }

        public static string GetServiceCurrentUser()
        {
            bool useWindowsCredentials = true;
            string userName = "";
            string password = "";
            string domainName = "";

            GetServiceUserCredentials(ref useWindowsCredentials, ref userName, ref password, ref domainName);

            if (useWindowsCredentials)
            {
                return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            }
            else
            {
                if (domainName.Length == 0)
                {
                    return userName;
                }
                else
                {
                    return domainName + "\\" + userName;
                }
            }
        }

        public static SignatureQueueServiceClient GetSignatureQueueServiceClient()
        {
            bool useWindowsCredentials = true;
            string userName = "";
            string password = "";
            string domainName = "";

            SignatureQueueServiceClient returnValue = new SignatureQueueServiceClient();
            string UrlSQS = "";
            TimeSpan SendTimeout = new TimeSpan(0, 0, 60);
            TimeSpan OpenTimeout = new TimeSpan(0, 0, 60);
            TimeSpan ReceiveTimeout = new TimeSpan(0, 0, 60);

            RegistryKey policiesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Policies\SmartAccess\SealSignSQSClient\SignatureParameters", false);
            if (policiesKey == null)
            {
                policiesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SmartAccess\SealSignSQSClient\SignatureParameters", false);
            }
            if (policiesKey != null)
            {
                UrlSQS = policiesKey.GetValue("SealSignSQSServiceURL", "").ToString();
                SendTimeout = new TimeSpan(0, 0, Convert.ToInt32(policiesKey.GetValue("SendTimeout", 60)));
                OpenTimeout = new TimeSpan(0, 0, Convert.ToInt32(policiesKey.GetValue("OpenTimeout", 60)));
                ReceiveTimeout = new TimeSpan(0, 0, Convert.ToInt32(policiesKey.GetValue("ReceiveTimeout", 60)));
                policiesKey.Close();
            }

            returnValue.Endpoint.Binding.OpenTimeout = OpenTimeout;
            returnValue.Endpoint.Binding.SendTimeout = SendTimeout;
            returnValue.Endpoint.Binding.ReceiveTimeout = ReceiveTimeout;

            ((WSHttpBinding)returnValue.Endpoint.Binding).MaxReceivedMessageSize = Int32.MaxValue;
            ((WSHttpBinding)returnValue.Endpoint.Binding).MaxBufferPoolSize = Int32.MaxValue;
            ((WSHttpBinding)returnValue.Endpoint.Binding).ReaderQuotas.MaxArrayLength = Int32.MaxValue;

            if (UrlSQS != "")
            {
                returnValue.Endpoint.Address = new System.ServiceModel.EndpointAddress(UrlSQS + "/SignatureQueueService.svc");
            }

            GetServiceUserCredentials(ref useWindowsCredentials, ref userName, ref password, ref domainName);

            if (!useWindowsCredentials)
            {
                if (((WSHttpBinding)returnValue.Endpoint.Binding).Security.Transport.ClientCredentialType == HttpClientCredentialType.Basic ||
                                ((WSHttpBinding)returnValue.Endpoint.Binding).Security.Message.ClientCredentialType == MessageCredentialType.UserName)
                {
                    returnValue.ClientCredentials.UserName.UserName = (string.IsNullOrEmpty(domainName)) ? userName : domainName + @"\" + userName;
                    returnValue.ClientCredentials.UserName.Password = password;
                }
                else
                {
                    returnValue.ClientCredentials.Windows.ClientCredential.Domain = domainName;
                    returnValue.ClientCredentials.Windows.ClientCredential.UserName = userName;
                    returnValue.ClientCredentials.Windows.ClientCredential.Password = password;
                }
            }

            return returnValue;
        }
    }
}
