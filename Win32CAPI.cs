using System;
using System.IO;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Principal;

namespace Native
{
    public class Win32
    {
        [ComImport]
        [Guid("00000114-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleWindow
        {
            void GetWindow(out IntPtr phwnd);
            void ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
        }

		internal const long CRYPT_NEWKEYSET = 0x8;
		internal const long CRYPT_DELETEKEYSET = 0x10;
		internal const long CRYPT_MACHINE_KEYSET = 0x20;
		internal const long CRYPT_SILENT = 0x40;
		internal const long CRYPT_DEFAULT_CONTAINER_OPTIONAL = 0x80;
		internal const long CRYPT_VERIFYCONTEXT = 0xF0000000;
		internal const int PROV_RSA_FULL = 1;
		internal const uint NTE_BAD_KEYSET = 0x80090016;
		internal const uint NTE_EXISTS = 0x8009000F;
		internal const uint NTE_KEYSET_ENTRY_BAD = 0x8009001A;

		internal const string MS_ENHANCED_PROV = "Microsoft Enhanced Cryptographic Provider v1.0";
        internal const string SMARTACCESS_ENHACED_PROV = "SmartAccess Enhanced Cryptographic Provider v1.0";

		internal const int NO_ERROR = 0;
		internal const int MIB_TCP_STATE_CLOSED = 1;
		internal const int MIB_TCP_STATE_LISTEN = 2;
		internal const int MIB_TCP_STATE_SYN_SENT = 3;
		internal const int MIB_TCP_STATE_SYN_RCVD = 4;
		internal const int MIB_TCP_STATE_ESTAB = 5;
		internal const int MIB_TCP_STATE_FIN_WAIT1 = 6;
		internal const int MIB_TCP_STATE_FIN_WAIT2 = 7;
		internal const int MIB_TCP_STATE_CLOSE_WAIT = 8;
		internal const int MIB_TCP_STATE_CLOSING = 9;
		internal const int MIB_TCP_STATE_LAST_ACK = 10;
		internal const int MIB_TCP_STATE_TIME_WAIT = 11;
		internal const int MIB_TCP_STATE_DELETE_TCB = 12;

        internal enum AlgorithmClass : uint
        {
            ALG_CLASS_ANY = (0),
            ALG_CLASS_SIGNATURE = (1 << 13),
            ALG_CLASS_MSG_ENCRYPT = (2 << 13),
            ALG_CLASS_DATA_ENCRYPT = (3 << 13),
            ALG_CLASS_HASH = (4 << 13),
            ALG_CLASS_KEY_EXCHANGE = (5 << 13),
            ALG_CLASS_ALL = (7 << 13),
        }

        internal enum AlgorithmType : uint
        {
            ALG_TYPE_ANY = (0),
            ALG_TYPE_DSS = (1 << 9),
            ALG_TYPE_RSA = (2 << 9),
            ALG_TYPE_BLOCK = (3 << 9),
            ALG_TYPE_STREAM = (4 << 9),
            ALG_TYPE_DH = (5 << 9),
            ALG_TYPE_SECURECHANNEL = (6 << 9),
        }

        internal enum GenericSubID : uint
        {
            ALG_SID_ANY = 0,
        }

        internal enum RSASubID : uint
        {
            ALG_SID_RSA_ANY = 0,
            ALG_SID_RSA_PKCS = 1,
            ALG_SID_RSA_MSATWORK = 2,
            ALG_SID_RSA_ENTRUST = 3,
            ALG_SID_RSA_PGP = 4,
        }

        internal enum DSSSubID : uint
        {
            ALG_SID_DSS_ANY = 0,
            ALG_SID_DSS_PKCS = 1,
            ALG_SID_DSS_DMS = 2,
        }

        internal enum BlockCipherSubID : uint
        {
            ALG_SID_DES = 1,
            ALG_SID_RC2 = 2,
            ALG_SID_3DES = 3,
            ALG_SID_DESX = 4,
            ALG_SID_IDEA = 5,
            ALG_SID_CAST = 6,
            ALG_SID_SAFERSK64 = 7,
            ALG_SID_SAFERSK128 = 8,
            ALG_SID_3DES_112 = 9,
            ALG_SID_SKIPJACK = 10,
            ALG_SID_TEK = 11,
            ALG_SID_CYLINK_MEK = 12,
            ALG_SID_RC5 = 13,
            ALG_SID_AES_128 = 14,
            ALG_SID_AES_192 = 15,
            ALG_SID_AES_256 = 16,
            ALG_SID_AES = 17,
        }

        internal enum StreamCipherSubID : uint
        {
            ALG_SID_RC4 = 1,
            ALG_SID_SEAL = 2,
        }

        internal enum DHSubID : uint
        {
            ALG_SID_DH_SANDF = 1,
            ALG_SID_DH_EPHEM = 2,
            ALG_SID_AGREED_KEY_ANY = 3,
            ALG_SID_KEA = 4,
        }

        internal enum HashSubID : uint
        {
            ALG_SID_MD2 = 1,
            ALG_SID_MD4 = 2,
            ALG_SID_MD5 = 3,
            ALG_SID_SHA = 4,
            ALG_SID_SHA1 = 4,
            ALG_SID_MAC = 5,
            ALG_SID_RIPEMD = 6,
            ALG_SID_RIPEMD160 = 7,
            ALG_SID_SSL3SHAMD5 = 8,
            ALG_SID_HMAC = 9,
            ALG_SID_TLS1PRF = 10,
            ALG_SID_HASH_REPLACE_OWF = 11,
            ALG_SID_SHA_256 = 12,
            ALG_SID_SHA_384 = 13,
            ALG_SID_SHA_512 = 14,
        }

        internal enum SChannelSubID : uint
        {
            ALG_SID_SSL3_MASTER = 1,
            ALG_SID_SCHANNEL_MASTER_HASH = 2,
            ALG_SID_SCHANNEL_MAC_KEY = 3,
            ALG_SID_PCT1_MASTER = 4,
            ALG_SID_SSL2_MASTER = 5,
            ALG_SID_TLS1_MASTER = 6,
            ALG_SID_SCHANNEL_ENC_KEY = 7,
        }

        internal enum ALG_ID : uint
        {
            CALG_MD2 = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_MD2),
            CALG_MD4 = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_MD4),
            CALG_MD5 = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_MD5),
            CALG_SHA = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_SHA),
            CALG_SHA1 = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_SHA1),
            CALG_MAC = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_MAC),
            CALG_RSA_SIGN = (AlgorithmClass.ALG_CLASS_SIGNATURE | AlgorithmType.ALG_TYPE_RSA | RSASubID.ALG_SID_RSA_ANY),
            CALG_DSS_SIGN = (AlgorithmClass.ALG_CLASS_SIGNATURE | AlgorithmType.ALG_TYPE_DSS | DSSSubID.ALG_SID_DSS_ANY),
            CALG_NO_SIGN = (AlgorithmClass.ALG_CLASS_SIGNATURE | AlgorithmType.ALG_TYPE_ANY | GenericSubID.ALG_SID_ANY),
            CALG_RSA_KEYX = (AlgorithmClass.ALG_CLASS_KEY_EXCHANGE | AlgorithmType.ALG_TYPE_RSA | RSASubID.ALG_SID_RSA_ANY),
            CALG_DES = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_DES),
            CALG_3DES_112 = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_3DES_112),
            CALG_3DES = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_3DES),
            CALG_DESX = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_DESX),
            CALG_RC2 = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_RC2),
            CALG_RC4 = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_STREAM | StreamCipherSubID.ALG_SID_RC4),
            CALG_SEAL = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_STREAM | StreamCipherSubID.ALG_SID_SEAL),
            CALG_DH_SF = (AlgorithmClass.ALG_CLASS_KEY_EXCHANGE | AlgorithmType.ALG_TYPE_DH | DHSubID.ALG_SID_DH_SANDF),
            CALG_DH_EPHEM = (AlgorithmClass.ALG_CLASS_KEY_EXCHANGE | AlgorithmType.ALG_TYPE_DH | DHSubID.ALG_SID_DH_EPHEM),
            CALG_AGREEDKEY_ANY = (AlgorithmClass.ALG_CLASS_KEY_EXCHANGE | AlgorithmType.ALG_TYPE_DH | DHSubID.ALG_SID_AGREED_KEY_ANY),
            CALG_KEA_KEYX = (AlgorithmClass.ALG_CLASS_KEY_EXCHANGE | AlgorithmType.ALG_TYPE_DH | DHSubID.ALG_SID_KEA),
            CALG_HUGHES_MD5 = (AlgorithmClass.ALG_CLASS_KEY_EXCHANGE | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_MD5),
            CALG_SKIPJACK = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_SKIPJACK),
            CALG_TEK = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_TEK),
            CALG_CYLINK_MEK = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_CYLINK_MEK),
            CALG_SSL3_SHAMD5 = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_SSL3SHAMD5),
            CALG_SSL3_MASTER = (AlgorithmClass.ALG_CLASS_MSG_ENCRYPT | AlgorithmType.ALG_TYPE_SECURECHANNEL | SChannelSubID.ALG_SID_SSL3_MASTER),
            CALG_SCHANNEL_MASTER_HASH = (AlgorithmClass.ALG_CLASS_MSG_ENCRYPT | AlgorithmType.ALG_TYPE_SECURECHANNEL | SChannelSubID.ALG_SID_SCHANNEL_MASTER_HASH),
            CALG_SCHANNEL_MAC_KEY = (AlgorithmClass.ALG_CLASS_MSG_ENCRYPT | AlgorithmType.ALG_TYPE_SECURECHANNEL | SChannelSubID.ALG_SID_SCHANNEL_MAC_KEY),
            CALG_SCHANNEL_ENC_KEY = (AlgorithmClass.ALG_CLASS_MSG_ENCRYPT | AlgorithmType.ALG_TYPE_SECURECHANNEL | SChannelSubID.ALG_SID_SCHANNEL_ENC_KEY),
            CALG_PCT1_MASTER = (AlgorithmClass.ALG_CLASS_MSG_ENCRYPT | AlgorithmType.ALG_TYPE_SECURECHANNEL | SChannelSubID.ALG_SID_PCT1_MASTER),
            CALG_SSL2_MASTER = (AlgorithmClass.ALG_CLASS_MSG_ENCRYPT | AlgorithmType.ALG_TYPE_SECURECHANNEL | SChannelSubID.ALG_SID_SSL2_MASTER),
            CALG_TLS1_MASTER = (AlgorithmClass.ALG_CLASS_MSG_ENCRYPT | AlgorithmType.ALG_TYPE_SECURECHANNEL | SChannelSubID.ALG_SID_TLS1_MASTER),
            CALG_RC5 = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_RC5),
            CALG_HMAC = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_HMAC),
            CALG_TLS1PRF = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_TLS1PRF),
            CALG_HASH_REPLACE_OWF = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_HASH_REPLACE_OWF),
            CALG_AES_128 = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_AES_128),
            CALG_AES_192 = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_AES_192),
            CALG_AES_256 = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_AES_256),
            CALG_AES = (AlgorithmClass.ALG_CLASS_DATA_ENCRYPT | AlgorithmType.ALG_TYPE_BLOCK | BlockCipherSubID.ALG_SID_AES),
            CALG_SHA_256 = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_SHA_256),
            CALG_SHA_384 = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_SHA_384),
            CALG_SHA_512 = (AlgorithmClass.ALG_CLASS_HASH | AlgorithmType.ALG_TYPE_ANY | HashSubID.ALG_SID_SHA_512), s
        }

        internal const int HP_ALGID = 0x0001;
        internal const int HP_HASHVAL = 0x0002;
        internal const int HP_HASHSIZE = 0x0004;

        internal const uint CERT_KEY_PROV_INFO_PROP_ID = 0x00000002;

		internal const int MAXSIZE = 16384; // size _does_ matter

		internal const int TOKEN_QUERY = 0X00000008;

		internal const int ERROR_NO_MORE_ITEMS = 259;

		internal enum SID_NAME_USE
		{
			SidTypeUser = 1,
			SidTypeGroup,
			SidTypeDomain,
			SidTypeAlias,
			SidTypeWellKnownGroup,
			SidTypeDeletedAccount,
			SidTypeInvalid,
			SidTypeUnknown,
			SidTypeComputer
		}

		internal enum TOKEN_INFORMATION_CLASS
		{
			TokenUser = 1,
			TokenGroups,
			TokenPrivileges,
			TokenOwner,
			TokenPrimaryGroup,
			TokenDefaultDacl,
			TokenSource,
			TokenType,
			TokenImpersonationLevel,
			TokenStatistics,
			TokenRestrictedSids,
			TokenSessionId
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct TOKEN_USER
		{
			public _SID_AND_ATTRIBUTES User;
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct _SID_AND_ATTRIBUTES
		{
			public IntPtr Sid;
			public int Attributes;
		}

        [StructLayout(LayoutKind.Sequential)]
		internal struct CRYPT_KEY_PROV_INFO
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public String ContainerName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public String ProvName;
            public uint ProvType;
            public uint Flags;
            public uint ProvParam;
            public IntPtr rgProvParam;
            public uint KeySpec;
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptAcquireContext(
        ref IntPtr hProv,
        string pszContainer,
        string pszProvider,
        uint dwProvType,
        uint dwFlags);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptReleaseContext(
        IntPtr hProv,
        uint dwFlags);


        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptCreateHash(
        IntPtr hProv,
        uint Algid,
        IntPtr hKey,
        uint dwFlags,
        ref IntPtr pHash);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptHashData(
        IntPtr pHash,
        byte[] pData,
        int dwDataLen,
        uint dwFlags);


        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptGetHashParam(
        IntPtr pHash,
        uint dwParam,
        [Out] byte[] hashvalue,
        ref uint hashvaluesize,
        uint dwFlags);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptSetHashParam(
            IntPtr hHash,
            Int32 dwParam,
            Byte[] pbData,
            Int32 dwFlags
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptDestroyHash(
        IntPtr pHash);

        [DllImport("Crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptAcquireCertificatePrivateKey(
            IntPtr pCert,
            Int32 dwFlags,
            IntPtr pvReserved,
            ref IntPtr phCryptProv,
            ref Int32 pdwKeySpec,
            ref Boolean pfCallerFreeProv
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptSignHash(
            IntPtr hHash,
            Int32 dwKeySpec,
            String sDescription,
            Int32 dwFlags,
            Byte[] pbSignature,
            ref Int32 pdwSigLen
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptGetUserKey(
            IntPtr hProv,
            Int32 dwKeySpec,
            ref IntPtr phUserKey
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptDecrypt(
            IntPtr hKey, 
            IntPtr hHash, 
            int Final, 
            uint dwFlags, 
            byte[] pbData, 
            ref uint pdwDataLen);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CryptDestroyKey(IntPtr phKey);

        [DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool CertGetCertificateContextProperty(
        IntPtr pCertContext, uint dwPropId, IntPtr pvData, ref uint pcbData);

		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool OpenProcessToken(IntPtr ProcessHandle,
			UInt32 DesiredAccess, out IntPtr TokenHandle);

		[DllImport("kernel32.dll")]
		internal static extern IntPtr GetCurrentProcess();

		[DllImport("advapi32.dll", SetLastError = true)]
		internal static extern bool GetTokenInformation(
			IntPtr TokenHandle,
			TOKEN_INFORMATION_CLASS TokenInformationClass,
			IntPtr TokenInformation,
			uint TokenInformationLength,
			out uint ReturnLength);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool CloseHandle(IntPtr hObject);

		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool LookupAccountSid(
			string lpSystemName,
			[MarshalAs(UnmanagedType.LPArray)] byte[] Sid,
			System.Text.StringBuilder lpName,
			ref uint cchName,
			System.Text.StringBuilder ReferencedDomainName,
			ref uint cchReferencedDomainName,
			out SID_NAME_USE peUse);

		[DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool ConvertSidToStringSid(
			[MarshalAs(UnmanagedType.LPArray)] byte[] pSID,
			out IntPtr ptrSid);

		[DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool ConvertSidToStringSid(IntPtr pSid, out string strSid);

		[DllImport("advapi32.dll", SetLastError = true)]
		internal static extern bool ConvertStringSidToSid(
					string StringSid,
					out IntPtr ptrSid
					);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern IntPtr LocalFree(IntPtr hMem);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [Flags]
        internal enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        internal static extern bool QueryFullProcessImageName(IntPtr hProcess, uint dwFlags, StringBuilder lpExeName, ref uint lpdwSize);

		internal static void DeletePKCert(IntPtr hCertCntxt)
        {
            uint provinfosize = 0;
            IntPtr pProvInfo = IntPtr.Zero;

            if (CertGetCertificateContextProperty(hCertCntxt, CERT_KEY_PROV_INFO_PROP_ID, IntPtr.Zero, ref provinfosize))
            {
                pProvInfo = Marshal.AllocHGlobal((int)provinfosize);
                if (CertGetCertificateContextProperty(hCertCntxt, CERT_KEY_PROV_INFO_PROP_ID, pProvInfo, ref provinfosize))
                {
                    CRYPT_KEY_PROV_INFO ckinfo = (CRYPT_KEY_PROV_INFO)Marshal.PtrToStructure(pProvInfo, typeof(CRYPT_KEY_PROV_INFO));
                    IntPtr hProv = IntPtr.Zero;
                    if (CryptAcquireContext(ref hProv, ckinfo.ContainerName, ckinfo.ProvName, ckinfo.ProvType, (uint)CRYPT_DELETEKEYSET))
                    {
                        if (hProv != IntPtr.Zero)
                        {
                            CryptReleaseContext(hProv, 0);
                        }
                    }
                    Marshal.FreeHGlobal(pProvInfo);
                }
                else
                    Marshal.FreeHGlobal(pProvInfo);
            }
        }

		/// <summary>
		/// Collect User Info
		/// </summary>
		/// <param name="pToken">Process Handle</param>
		internal static bool DumpUserInfo(IntPtr pToken, out IntPtr SID)
		{
			uint Access = TOKEN_QUERY;
			IntPtr procToken = IntPtr.Zero;
			bool ret = false;
			SID = IntPtr.Zero;
			try
			{
				if (OpenProcessToken(pToken, Access, out procToken))
				{
					ret = ProcessTokenToSid(procToken, out SID);
					CloseHandle(procToken);
				}
				return ret;
			}
			catch
			{
				return false;
			}
		}

		internal static bool ProcessTokenToSid(IntPtr token, out IntPtr SID)
		{
			TOKEN_USER tokUser;
			const int bufLength = 256;
			IntPtr tu = Marshal.AllocHGlobal(bufLength);
			bool ret = false;
			SID = IntPtr.Zero;
			try
			{
				uint cb = bufLength;
				ret = GetTokenInformation(token, TOKEN_INFORMATION_CLASS.TokenUser, tu, cb, out cb);
				if (ret)
				{
					tokUser = (TOKEN_USER)Marshal.PtrToStructure(tu, typeof(TOKEN_USER));
					SID = tokUser.User.Sid;
				}
				return ret;
			}
			catch
			{
				return false;
			}
			finally
			{
				Marshal.FreeHGlobal(tu);
			}
		}

		internal static string ExGetProcessInfoByPID(int PID, out string SID)//, out string OwnerSID)
		{
			IntPtr _SID = IntPtr.Zero;
			SID = String.Empty;
			try
			{
				Process process = Process.GetProcessById(PID);
				if (DumpUserInfo(process.Handle, out _SID))
				{
					ConvertSidToStringSid(_SID, out SID);
				}
				return process.ProcessName;
			}
			catch
			{
				return "Unknown";
			}
		}

		internal static string GetOwnerProcess()
		{
			uint Access = 0X00000008;
			IntPtr procToken = IntPtr.Zero;

			try
			{
				if (OpenProcessToken(Process.GetCurrentProcess().Handle, Access, out procToken))
				{
					WindowsIdentity wi = new WindowsIdentity(procToken);
					CloseHandle(procToken);
					return wi.Name;
				}
			}
			catch
			{
			}

			return "";
		}

		internal static bool CreateKeyContainer(string name)
		{
			uint dwError = 0;
			IntPtr hProv = IntPtr.Zero;

            if (CryptAcquireContext(ref hProv, name, (!isVistaOrLaterFamily()) ? MS_ENHANCED_PROV : SMARTACCESS_ENHACED_PROV, PROV_RSA_FULL, (uint)CRYPT_DELETEKEYSET))
            {
                CryptReleaseContext(hProv, 0);
            }

            if (!CryptAcquireContext(ref hProv, name, (!isVistaOrLaterFamily())?MS_ENHANCED_PROV:SMARTACCESS_ENHACED_PROV, PROV_RSA_FULL, 0))
			{
				dwError = (uint)Marshal.GetLastWin32Error();
				if (dwError == NTE_BAD_KEYSET)
				{
                    if (!CryptAcquireContext(ref hProv, name, (!isVistaOrLaterFamily()) ? MS_ENHANCED_PROV : SMARTACCESS_ENHACED_PROV, PROV_RSA_FULL, (uint)CRYPT_NEWKEYSET))
						goto cleanup;
				}
				else
					goto cleanup;
			}

cleanup:

			if (hProv!=IntPtr.Zero)
			{
				CryptReleaseContext(hProv, 0);
				return true;
			}
			else
				return true;
		}

        internal static string GetExecutablePath(int dwProcessId)
        {
            if (isVistaOrLaterFamily())
            {
                StringBuilder buffer = new StringBuilder(1024);
                IntPtr hprocess = OpenProcess(ProcessAccessFlags.QueryLimitedInformation, false, dwProcessId);
                if (hprocess != IntPtr.Zero)
                {
                    try
                    {
                        uint size = (uint)buffer.Capacity;
                        if (QueryFullProcessImageName(hprocess, 0, buffer, ref size))
                        {
                            return System.IO.Path.GetFileName(buffer.ToString());
                        }
                    }
                    finally
                    {
                        CloseHandle(hprocess);
                    }
                }
            }
            else
            {
                return System.IO.Path.GetFileName(Process.GetProcessById(dwProcessId).MainModule.FileName);
            }

            return string.Empty;
        }

        internal static bool isVistaOrLaterFamily()
        {
            bool bRet = false;

            OperatingSystem os = System.Environment.OSVersion;
            if (os.Version.Major >= 6)
            {
                bRet = true;
            }

            return bRet;
        }
    }
}