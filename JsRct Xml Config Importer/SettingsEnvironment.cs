using System;
using System.Collections.Generic;
using System.Text;

namespace JurikSoft
{
    namespace XMLConfigImporer
    {
        namespace JsRctClient
        {
            namespace Version110
            {
                public class ClientSettingsEnvironment
                {

                    static int int_CurrentLanguage = 0;
                    public static int CurrentLanguage
                    {
                        get
                        {
                            return int_CurrentLanguage;
                        }

                        set
                        {
                            int_CurrentLanguage = value;
                        }
                    }



                    public static int int_SentFilesEncryptAlgorithmIndex = 0;
                    public static int SentFilesEncryptAlgorithmIndex
                    {
                        get
                        {
                            return int_SentFilesEncryptAlgorithmIndex;
                        }

                        set
                        {
                            int_SentFilesEncryptAlgorithmIndex = value;
                        }
                    }

                    public static int int_DownloadedFilesEncryptAlgorithmIndex = 0;
                    public static int DownloadedFilesEncryptAlgorithmIndex
                    {
                        get
                        {
                            return int_DownloadedFilesEncryptAlgorithmIndex;
                        }

                        set
                        {
                            int_DownloadedFilesEncryptAlgorithmIndex = value;
                        }
                    }

                    public static int int_ReceivedScreenshotsEncryptAlgorithmIndex = 0;
                    public static int ReceivedScreenshotsEncryptAlgorithmIndex
                    {
                        get
                        {
                            return int_ReceivedScreenshotsEncryptAlgorithmIndex;
                        }

                        set
                        {
                            int_ReceivedScreenshotsEncryptAlgorithmIndex = value;
                        }
                    }

                    public static int int_SendingSystemDataEncryptAlgorithmIndex = 0;
                    public static int SendingSystemDataEncryptAlgorithmIndex
                    {
                        get
                        {
                            return int_SendingSystemDataEncryptAlgorithmIndex;
                        }

                        set
                        {
                            int_SendingSystemDataEncryptAlgorithmIndex = value;
                        }
                    }

                    public static int int_ReceivedSystemDataEncryptAlgorithmIndex = 0;
                    public static int ReceivedSystemDataEncryptAlgorithmIndex
                    {
                        get
                        {
                            return int_ReceivedSystemDataEncryptAlgorithmIndex;
                        }

                        set
                        {
                            int_ReceivedSystemDataEncryptAlgorithmIndex = value;
                        }
                    }


                    public static int int_SentFilesCompressAlgorithmIndex = 0;
                    public static int SentFilesCompressAlgorithmIndex
                    {
                        get
                        {
                            return int_SentFilesCompressAlgorithmIndex;
                        }

                        set
                        {
                            int_SentFilesCompressAlgorithmIndex = value;
                        }
                    }

                    public static int int_DownloadedFilesCompressAlgorithmIndex = 0;
                    public static int DownloadedFilesCompressAlgorithmIndex
                    {
                        get
                        {
                            return int_DownloadedFilesCompressAlgorithmIndex;
                        }

                        set
                        {
                            int_DownloadedFilesCompressAlgorithmIndex = value;
                        }
                    }

                    public static int int_ReceivedScreenshotsCompressAlgorithmIndex = 0;
                    public static int ReceivedScreenshotsCompressAlgorithmIndex
                    {
                        get
                        {
                            return int_ReceivedScreenshotsCompressAlgorithmIndex;
                        }

                        set
                        {
                            int_ReceivedScreenshotsCompressAlgorithmIndex = value;
                        }
                    }

                    public static int int_SendingSystemDataCompressAlgorithmIndex = 0;
                    public static int SendingSystemDataCompressAlgorithmIndex
                    {
                        get
                        {
                            return int_SendingSystemDataCompressAlgorithmIndex;
                        }

                        set
                        {
                            int_SendingSystemDataCompressAlgorithmIndex = value;
                        }
                    }

                    public static int int_ReceivedSystemDataCompressAlgorithmIndex = 0;
                    public static int ReceivedSystemDataCompressAlgorithmIndex
                    {
                        get
                        {
                            return int_ReceivedSystemDataCompressAlgorithmIndex;
                        }

                        set
                        {
                            int_ReceivedSystemDataCompressAlgorithmIndex = value;
                        }
                    }


                    public static bool bool_ToEncryptSentFiles = true;
                    public static bool ToEncryptSentFiles
                    {
                        get
                        {
                            return bool_ToEncryptSentFiles;
                        }

                        set
                        {
                            bool_ToEncryptSentFiles = value;
                        }
                    }

                    public static bool bool_ToEncryptDownloadedFiles = true;
                    public static bool ToEncryptDownloadedFiles
                    {
                        get
                        {
                            return bool_ToEncryptDownloadedFiles;
                        }

                        set
                        {
                            bool_ToEncryptDownloadedFiles = value;
                        }
                    }

                    public static bool bool_ToEncryptReceivedScreenshots = false;
                    public static bool ToEncryptReceivedScreenshots
                    {
                        get
                        {
                            return bool_ToEncryptReceivedScreenshots;
                        }

                        set
                        {
                            bool_ToEncryptReceivedScreenshots = value;
                        }
                    }

                    public static bool bool_ToEncryptSentSystemData = true;
                    public static bool ToEncryptSentSystemData
                    {
                        get
                        {
                            return bool_ToEncryptSentSystemData;
                        }

                        set
                        {
                            bool_ToEncryptSentSystemData = value;
                        }
                    }

                    public static bool bool_ToEncryptReceivedSystemData = true;
                    public static bool ToEncryptReceivedSystemData
                    {
                        get
                        {
                            return bool_ToEncryptReceivedSystemData;
                        }

                        set
                        {
                            bool_ToEncryptReceivedSystemData = value;
                        }
                    }


                    public static bool bool_ToCompressSentFiles = false;
                    public static bool ToCompressSentFiles
                    {
                        get
                        {
                            return bool_ToCompressSentFiles;
                        }

                        set
                        {
                            bool_ToCompressSentFiles = value;
                        }
                    }

                    public static bool bool_ToCompressDownloadedFiles = false;
                    public static bool ToCompressDownloadedFiles
                    {
                        get
                        {
                            return bool_ToCompressDownloadedFiles;
                        }

                        set
                        {
                            bool_ToCompressDownloadedFiles = value;
                        }
                    }

                    public static bool bool_ToCompressReceivedScreenshots = false;
                    public static bool ToCompressReceivedScreenshots
                    {
                        get
                        {
                            return bool_ToCompressReceivedScreenshots;
                        }

                        set
                        {
                            bool_ToCompressReceivedScreenshots = value;
                        }
                    }

                    public static bool bool_ToCompressSentSystemData = false;
                    public static bool ToCompressSentSystemData
                    {
                        get
                        {
                            return bool_ToCompressSentSystemData;
                        }

                        set
                        {
                            bool_ToCompressSentSystemData = value;
                        }
                    }

                    public static bool bool_ToCompressReceivedSystemData = false;
                    public static bool ToCompressReceivedSystemData
                    {
                        get
                        {
                            return bool_ToCompressReceivedSystemData;
                        }

                        set
                        {
                            bool_ToCompressReceivedSystemData = value;
                        }
                    }


                    public static bool bool_ShowToolTips = true;
                    public static bool ShowToolTips
                    {
                        get
                        {
                            return bool_ShowToolTips;
                        }

                        set
                        {
                            bool_ShowToolTips = value;
                        }
                    }

                    public static bool bool_ShowAdvancedSettings = false;
                    public static bool ShowAdvancedSettings
                    {
                        get
                        {
                            return bool_ShowAdvancedSettings;
                        }

                        set
                        {
                            bool_ShowAdvancedSettings = value;
                        }
                    }

                    public static bool bool_UseProxyServer = false;
                    public static bool UseProxyServer
                    {
                        get
                        {
                            return bool_UseProxyServer;
                        }

                        set
                        {
                            bool_UseProxyServer = value;
                        }
                    }


                    public static bool bool_UseProxyToResolveHostNames = false;
                    public static bool UseProxyToResolveHostNames
                    {
                        get
                        {
                            return bool_UseProxyToResolveHostNames;
                        }

                        set
                        {
                            bool_UseProxyToResolveHostNames = value;
                        }
                    }

                    public static bool bool_UseProxyAuthentication = false;
                    public static bool UseProxyAuthentication
                    {
                        get
                        {
                            return bool_UseProxyAuthentication;
                        }

                        set
                        {
                            bool_UseProxyAuthentication = value;
                        }
                    }


                    public static bool bool_RememberLogins = true;
                    public static bool RememberLogins
                    {
                        get
                        {
                            return bool_RememberLogins;
                        }

                        set
                        {
                            bool_RememberLogins = value;
                        }
                    }

                    public static bool bool_RememberPasswords = true;
                    public static bool RememberPasswords
                    {
                        get
                        {
                            return bool_RememberPasswords;
                        }

                        set
                        {
                            bool_RememberPasswords = value;
                        }
                    }

                    public static bool bool_EncryptSettingsDataBase = false;
                    public static bool EncryptSettingsDataBase
                    {
                        get
                        {
                            return bool_EncryptSettingsDataBase;
                        }

                        set
                        {
                            bool_EncryptSettingsDataBase = value;
                        }
                    }

                    public static bool bool_CompressSettingsDataBase = true;
                    public static bool CompressSettingsDataBase
                    {
                        get
                        {
                            return bool_CompressSettingsDataBase;
                        }

                        set
                        {
                            bool_CompressSettingsDataBase = value;
                        }
                    }


                    public static bool bool_HideLocalCursorOnMiniRTDV = false;
                    public static bool HideLocalCursorOnMiniRTDV
                    {
                        get
                        {
                            return bool_HideLocalCursorOnMiniRTDV;
                        }

                        set
                        {
                            bool_HideLocalCursorOnMiniRTDV = value;
                        }
                    }

                    public static bool bool_ShowRemoteCursorInRTDV = false;
                    public static bool ShowRemoteCursorInRTDV
                    {
                        get
                        {
                            return bool_ShowRemoteCursorInRTDV;
                        }

                        set
                        {
                            bool_ShowRemoteCursorInRTDV = value;
                        }
                    }


                    public static int int_ServerPort = 5544;
                    public static int ServerPort
                    {
                        get
                        {
                            return int_ServerPort;
                        }

                        set
                        {
                            int_ServerPort = value;
                        }
                    }

                    public static int int_ProxyServerPort = 1080;
                    public static int ProxyServerPort
                    {
                        get
                        {
                            return int_ProxyServerPort;
                        }

                        set
                        {
                            int_ProxyServerPort = value;
                        }
                    }

                    public static int int_ProxyServerTimeOut = 5000;
                    public static int ProxyServerTimeOut
                    {
                        get
                        {
                            return int_ProxyServerTimeOut;
                        }

                        set
                        {
                            int_ProxyServerTimeOut = value;
                        }
                    }

                    public static int int_ProxyServerType = 1;
                    public static int ProxyServerType
                    {
                        get
                        {
                            return int_ProxyServerType;
                        }

                        set
                        {
                            int_ProxyServerType = value;
                        }
                    }



                    static int int_ScreenshotsTransferMethod = 0;
                    public static int ScreenshotsTransferMethod
                    {
                        get
                        {
                            return int_ScreenshotsTransferMethod;
                        }

                        set
                        {
                            int_ScreenshotsTransferMethod = value;
                        }
                    }



                    static string string_AppVersion = String.Empty;
                    public static string AppVersion
                    {
                        get
                        {
                            return string_AppVersion;
                        }

                        set
                        {
                            string_AppVersion = value;
                        }
                    }

                    static string string_LocalSecurityPassword = String.Empty;
                    public static string LocalSecurityPassword
                    {
                        get
                        {
                            return string_LocalSecurityPassword;
                        }

                        set
                        {
                            string_LocalSecurityPassword = value;
                        }
                    }

                    static string string_LoginForConnection = String.Empty;
                    public static string LoginForConnection
                    {
                        get
                        {
                            return string_LoginForConnection;
                        }

                        set
                        {
                            string_LoginForConnection = value;
                        }
                    }

                    static string string_PasswordForConnection = String.Empty;
                    public static string PasswordForConnection
                    {
                        get
                        {
                            return string_PasswordForConnection;
                        }

                        set
                        {
                            string_PasswordForConnection = value;
                        }
                    }

                    static string string_ServerHost = "localhost";
                    public static string ServerHost
                    {
                        get
                        {
                            return string_ServerHost;
                        }

                        set
                        {
                            string_ServerHost = value;
                        }
                    }

                    static string string_ProxyServerHost = String.Empty;
                    public static string ProxyServerHost
                    {
                        get
                        {
                            return string_ProxyServerHost;
                        }

                        set
                        {
                            string_ProxyServerHost = value;
                        }
                    }

                    static string string_ProxyServerLogin = String.Empty;
                    public static string ProxyLogin
                    {
                        get
                        {
                            return string_ProxyServerLogin;
                        }

                        set
                        {
                            string_ProxyServerLogin = value;
                        }
                    }

                    static string string_ProxyServerPassword = String.Empty;
                    public static string ProxyPassword
                    {
                        get
                        {
                            return string_ProxyServerPassword;
                        }

                        set
                        {
                            string_ProxyServerPassword = value;
                        }
                    }

                    static string string_DownloadedFilesPath = String.Empty;
                    public static string DownloadedFilesPath
                    {
                        get
                        {
                            return string_DownloadedFilesPath;
                        }

                        set
                        {
                            string_DownloadedFilesPath = value;
                        }
                    }

                    static string string_DownloadedScreenShotsPath = String.Empty;
                    public static string DownloadedScreenShotsPath
                    {
                        get
                        {
                            return string_DownloadedScreenShotsPath;
                        }

                        set
                        {
                            string_DownloadedScreenShotsPath = value;
                        }
                    }

                    static bool bool_IsProductRegistered = false;
                    public static bool IsProductRegistered
                    {
                        get
                        {
                            return bool_IsProductRegistered;
                        }

                        set
                        {
                            bool_IsProductRegistered = value;
                        }
                    }

                    static string string_ProductLicenceName = String.Empty;
                    public static string ProductLicenceName
                    {
                        get
                        {
                            return string_ProductLicenceName;
                        }

                        set
                        {
                            string_ProductLicenceName = value;
                        }
                    }

                    static string string_ProductSerialNumber = String.Empty;
                    public static string ProductSerialNumber
                    {
                        get
                        {
                            return string_ProductSerialNumber;
                        }

                        set
                        {
                            string_ProductSerialNumber = value;
                        }
                    }

                    //--------------------------------------------------------------------------------------------------   CSP

                    static string string_CSP_ServerAuth_CustomCSPServiceIPAddress = String.Empty;
                    public static string CSP_ServerAuth_CustomCSPServiceIPAddress
                    {
                        get
                        {
                            return string_CSP_ServerAuth_CustomCSPServiceIPAddress;
                        }

                        set
                        {
                            string_CSP_ServerAuth_CustomCSPServiceIPAddress = value;
                        }
                    }

                     static string string_CSP_ServerAuth_CSPLoginPassword = String.Empty;
                    public static string CSP_ServerAuth_CSPLoginPassword
                    {
                        get
                        {
                            return string_CSP_ServerAuth_CSPLoginPassword;
                        }

                        set
                        {
                            string_CSP_ServerAuth_CSPLoginPassword = value;
                        }
                    }

                    static string string_CSP_ServerAuth_CSPLoginUIN = String.Empty;
                    public static string CSP_ServerAuth_CSPLoginUIN
                    {
                        get
                        {
                            return string_CSP_ServerAuth_CSPLoginUIN;
                        }

                        set
                        {
                            string_CSP_ServerAuth_CSPLoginUIN = value;
                        }
                    }

                    static string string_CSP_ServerAuth_JSRCTLogin = String.Empty;
                    public static string CSP_ServerAuth_JSRCTLogin
                    {
                        get
                        {
                            return string_CSP_ServerAuth_JSRCTLogin;
                        }

                        set
                        {
                            string_CSP_ServerAuth_JSRCTLogin = value;
                        }
                    }

                    static string string_CSP_ServerAuth_JSRCTPassword = String.Empty;
                    public static string CSP_ServerAuth_JSRCTPassword
                    {
                        get
                        {
                            return string_CSP_ServerAuth_JSRCTPassword;
                        }

                        set
                        {
                            string_CSP_ServerAuth_JSRCTPassword = value;
                        }
                    }

                    static string string_CSP_ServerAuth_CSPServerUIN = String.Empty;
                    public static string CSP_ServerAuth_CSPServerUIN
                    {
                        get
                        {
                            return string_CSP_ServerAuth_CSPServerUIN;
                        }

                        set
                        {
                            string_CSP_ServerAuth_CSPServerUIN = value;
                        }
                    }
                                        
                    static bool bool_CSP_ServerAuth_UseJurikSoftCSPServer = true;
                    public static bool CSP_ServerAuth_UseJurikSoftCSPServer
                    {
                        get
                        {
                            return bool_CSP_ServerAuth_UseJurikSoftCSPServer;
                        }

                        set
                        {
                            bool_CSP_ServerAuth_UseJurikSoftCSPServer = value;
                        }
                    }

                    static bool bool_CSP_ServerAuth_WaitForServer = true;
                    public static bool CSP_ServerAuth_WaitForServer
                    {
                        get
                        {
                            return bool_CSP_ServerAuth_WaitForServer;
                        }

                        set
                        {
                            bool_CSP_ServerAuth_WaitForServer = value;
                        }
                    }

                    static int int_CSP_ServerAuth_CustomCSPServicePort = 5545;
                    public static int CSP_ServerAuth_CustomCSPServicePort
                    {
                        get
                        {
                            return int_CSP_ServerAuth_CustomCSPServicePort;
                        }

                        set
                        {
                            int_CSP_ServerAuth_CustomCSPServicePort = value;
                        }
                    }

                    //--------------------------------------------------------------------------------------------------   CSP

                    static bool bool_CSP_CSPServersList_UseJurikSoftCSPServer = true;
                    public static bool CSP_CSPServersList_UseJurikSoftCSPServer
                    {
                        get
                        {
                            return bool_CSP_CSPServersList_UseJurikSoftCSPServer;
                        }

                        set
                        {
                            bool_CSP_CSPServersList_UseJurikSoftCSPServer = value;
                        }
                    }

                    static string string_CSP_CSPServersList_Password = String.Empty;
                    public static string CSP_CSPServersList_Password
                    {
                        get
                        {
                            return string_CSP_CSPServersList_Password;
                        }

                        set
                        {
                            string_CSP_CSPServersList_Password = value;
                        }
                    }

                    static string string_CSP_CSPServersList_UIN = String.Empty;
                    public static string CSP_CSPServersList_UIN
                    {
                        get
                        {
                            return string_CSP_CSPServersList_UIN;
                        }

                        set
                        {
                            string_CSP_CSPServersList_UIN = value;
                        }
                    }
                    
                    static string string_CSP_CSPServersList_CustomCSPServiceIPAddress = String.Empty;
                    public static string CSP_CSPServersList_CustomCSPServiceIPAddress
                    {
                        get
                        {
                            return string_CSP_CSPServersList_CustomCSPServiceIPAddress;
                        }

                        set
                        {
                            string_CSP_CSPServersList_CustomCSPServiceIPAddress = value;
                        }
                    }

                    static int int_CSP_CSPServersList_CustomCSPServicePort = 5545;
                    public static int CSP_CSPServersList_CustomCSPServicePort
                    {
                        get
                        {
                            return int_CSP_CSPServersList_CustomCSPServicePort;
                        }

                        set
                        {
                            int_CSP_CSPServersList_CustomCSPServicePort = value;
                        }
                    }

                    //--------------------------------------------------------------------------------------------------   CSP
                                        
                    static int int_CSP_ProxySettings_ProxyPort = 5545;
                    public static int CSP_ProxySettings_ProxyPort
                    {
                        get
                        {
                            return int_CSP_ProxySettings_ProxyPort;
                        }

                        set
                        {
                            int_CSP_ProxySettings_ProxyPort = value;
                        }
                    }
                                    
                    static string string_CSP_ProxySettings_ProxyHost = String.Empty;
                    public static string CSP_ProxySettings_ProxyHost
                    {
                        get
                        {
                            return string_CSP_ProxySettings_ProxyHost;
                        }

                        set
                        {
                            string_CSP_ProxySettings_ProxyHost = value;
                        }
                    }
                                       
                    static string string_CSP_ProxySettings_Socks5UserName = String.Empty;
                    public static string CSP_ProxySettings_Socks5UserName
                    {
                        get
                        {
                            return string_CSP_ProxySettings_Socks5UserName;
                        }

                        set
                        {
                            string_CSP_ProxySettings_Socks5UserName = value;
                        }
                    }
                           
                    static string string_CSP_ProxySettings_Socks5Password = String.Empty;
                    public static string CSP_ProxySettings_Socks5Password
                    {
                        get
                        {
                            return string_CSP_ProxySettings_Socks5Password;
                        }

                        set
                        {
                            string_CSP_ProxySettings_Socks5Password = value;
                        }
                    }
               
                    static bool bool_CSP_ProxySettings_Authentication = true;
                    public static bool CSP_ProxySettings_Authentication
                    {
                        get
                        {
                            return bool_CSP_ProxySettings_Authentication;
                        }

                        set
                        {
                            bool_CSP_ProxySettings_Authentication = value;
                        }
                    }

                    static bool bool_CSP_ProxySettings_ResolveHostNames = true;
                    public static bool CSP_ProxySettings_ResolveHostNames
                    {
                        get
                        {
                            return bool_CSP_ProxySettings_ResolveHostNames;
                        }

                        set
                        {
                            bool_CSP_ProxySettings_ResolveHostNames = value;
                        }
                    }

                    static bool bool_CSP_ProxySettings_UseProxy = false;
                    public static bool CSP_ProxySettings_UseProxy
                    {
                        get
                        {
                            return bool_CSP_ProxySettings_UseProxy;
                        }

                        set
                        {
                            bool_CSP_ProxySettings_UseProxy = value;
                        }
                    }
                                        
                    static int int_CSP_ProxySettings_ProxyTypeIndex = 0;
                    public static int CSP_ProxySettings_ProxyTypeIndex
                    {
                        get
                        {
                            return int_CSP_ProxySettings_ProxyTypeIndex;
                        }

                        set
                        {
                            int_CSP_ProxySettings_ProxyTypeIndex = value;
                        }
                    }  
                                      
                    static int int_CSP_ProxySettings_ProxyTimeOutIndex = 0;
                    public static int CSP_ProxySettings_ProxyTimeOutIndex
                    {
                        get
                        {
                            return int_CSP_ProxySettings_ProxyTimeOutIndex;
                        }

                        set
                        {
                            int_CSP_ProxySettings_ProxyTimeOutIndex = value;
                        }
                    }  



                    //--------------------------------------------------------------------------------------------------   CSP ChangeUINAccountState
                     
                    static string string_CSP_ChangeUINAccountState_CustomCSPServiceIPAddress = String.Empty;
                    public static string CSP_ChangeUINAccountState_CustomCSPServiceIPAddress
                    {
                        get
                        {
                            return string_CSP_ChangeUINAccountState_CustomCSPServiceIPAddress;
                        }

                        set
                        {
                            string_CSP_ChangeUINAccountState_CustomCSPServiceIPAddress = value;
                        }
                    }
                      
                    static int int_CSP_ChangeUINAccountState_CustomCSPServicePort = 5545;
                    public static int CSP_ChangeUINAccountState_CustomCSPServicePort
                    {
                        get
                        {
                            return int_CSP_ChangeUINAccountState_CustomCSPServicePort;
                        }

                        set
                        {
                            int_CSP_ChangeUINAccountState_CustomCSPServicePort = value;
                        }
                    }

                    static string string_CSP_ChangeUINAccountState_UIN = String.Empty;
                    public static string CSP_ChangeUINAccountState_UIN
                    {
                        get
                        {
                            return string_CSP_ChangeUINAccountState_UIN;
                        }

                        set
                        {
                            string_CSP_ChangeUINAccountState_UIN = value;
                        }
                    }

                    static string string_CSP_ChangeUINAccountState_Password = String.Empty;
                    public static string CSP_ChangeUINAccountState_Password
                    {
                        get
                        {
                            return string_CSP_ChangeUINAccountState_Password;
                        }

                        set
                        {
                            string_CSP_ChangeUINAccountState_Password = value;
                        }
                    }

                    static string string_CSP_ChangeUINAccountState_UINActivationCode = String.Empty;
                    public static string CSP_ChangeUINAccountState_UINActivationCode
                    {
                        get
                        {
                            return string_CSP_ChangeUINAccountState_UINActivationCode;
                        }

                        set
                        {
                            string_CSP_ChangeUINAccountState_UINActivationCode = value;
                        }
                    }

                    static bool bool_CSP_ChangeUINAccountState_UseJurikSoftCSPServer = true;
                    public static bool CSP_ChangeUINAccountState_UseJurikSoftCSPServer
                    {
                        get
                        {
                            return bool_CSP_ChangeUINAccountState_UseJurikSoftCSPServer;
                        }

                        set
                        {
                            bool_CSP_ChangeUINAccountState_UseJurikSoftCSPServer = value;
                        }
                    }

                    static bool bool_CSP_ChangeUINAccountState_GetActivationCode = false;
                    public static bool CSP_ChangeUINAccountState_GetActivationCode
                    {
                        get
                        {
                            return bool_CSP_ChangeUINAccountState_GetActivationCode;
                        }

                        set
                        {
                            bool_CSP_ChangeUINAccountState_GetActivationCode = value;
                        }
                    }

                    static int int_CSP_ChangeUINAccountState_NewAccountStateIndex = 0;
                    public static int CSP_ChangeUINAccountState_NewAccountStateIndex
                    {
                        get
                        {
                            return int_CSP_ChangeUINAccountState_NewAccountStateIndex;
                        }

                        set
                        {
                            int_CSP_ChangeUINAccountState_NewAccountStateIndex = value;
                        }
                    }  


















                }
            }
        }

        namespace JsRctServer
        {
            namespace Version110
            {
                public class ServerSettingsEnvironment : MarshalByRefObject
                {
                    static int int_CurrentLanguage = 0;
                    public static int CurrentLanguage
                    {
                        get
                        {
                            return int_CurrentLanguage;
                        }

                        set
                        {
                            int_CurrentLanguage = value;
                        }
                    }
                    public int RemotingWrapper_CurrentLanguage
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CurrentLanguage;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CurrentLanguage = value;
                        }
                    }

                    static int int_MaxConnections = 0;
                    public static int MaxConnections
                    {
                        get
                        {
                            return int_MaxConnections;
                        }

                        set
                        {
                            int_MaxConnections = value;
                        }
                    }
                    public int RemotingWrapper_MaxConnections
                    {
                        get
                        {
                            return ServerSettingsEnvironment.MaxConnections;
                        }

                        set
                        {
                            ServerSettingsEnvironment.MaxConnections = value;
                        }
                    }

                    static int int_MaxConnectionsPerAccount = 0;
                    public static int MaxConnectionsPerAccount
                    {
                        get
                        {
                            return int_MaxConnectionsPerAccount;
                        }

                        set
                        {
                            int_MaxConnectionsPerAccount = value;
                        }
                    }
                    public int RemotingWrapper_MaxConnectionsPerAccount
                    {
                        get
                        {
                            return ServerSettingsEnvironment.MaxConnectionsPerAccount;
                        }

                        set
                        {
                            ServerSettingsEnvironment.MaxConnectionsPerAccount = value;
                        }
                    }

                    static int int_MaxRSAPublicKeyLength = 2048;
                    public static int MaxRSAPublicKeyLength
                    {
                        get
                        {
                            return int_MaxRSAPublicKeyLength;
                        }

                        set
                        {
                            int_MaxRSAPublicKeyLength = value;
                        }
                    }
                    public int RemotingWrapper_MaxRSAPublicKeyLength
                    {
                        get
                        {
                            return ServerSettingsEnvironment.MaxRSAPublicKeyLength;
                        }

                        set
                        {
                            ServerSettingsEnvironment.MaxRSAPublicKeyLength = value;
                        }
                    }

                    static int int_MinRSAPublicKeyLength = 512;
                    public static int MinRSAPublicKeyLength
                    {
                        get
                        {
                            return int_MinRSAPublicKeyLength;
                        }

                        set
                        {
                            int_MinRSAPublicKeyLength = value;
                        }
                    }
                    public int RemotingWrapper_MinRSAPublicKeyLength
                    {
                        get
                        {
                            return ServerSettingsEnvironment.MinRSAPublicKeyLength;
                        }

                        set
                        {
                            ServerSettingsEnvironment.MinRSAPublicKeyLength = value;
                        }
                    }

                    static bool bool_IsWindowsAuthenticationAllowed = false;
                    public static bool IsWindowsAuthenticationAllowed
                    {
                        get
                        {
                            return bool_IsWindowsAuthenticationAllowed;
                        }

                        set
                        {
                            bool_IsWindowsAuthenticationAllowed = value;
                        }
                    }
                    public bool RemotingWrapper_IsWindowsAuthenticationAllowed
                    {
                        get
                        {
                            return ServerSettingsEnvironment.IsWindowsAuthenticationAllowed;
                        }

                        set
                        {
                            ServerSettingsEnvironment.IsWindowsAuthenticationAllowed = value;
                        }
                    }

                    static int int_ServerPort = 5544;
                    public static int ServerPort
                    {
                        set
                        {
                            int_ServerPort = value;
                        }
                        get
                        {
                            return int_ServerPort;
                        }
                    }
                    public int RemotingWrapper_ServerPort
                    {
                        set
                        {
                            ServerSettingsEnvironment.ServerPort = value;
                        }
                        get
                        {
                            return ServerSettingsEnvironment.ServerPort;
                        }
                    }

                    static string string_AppVersion = String.Empty;
                    public static string AppVersion
                    {
                        get
                        {
                            return string_AppVersion;
                        }

                        set
                        {
                            string_AppVersion = value;
                        }
                    }
                    public string RemotingWrapper_AppVersion
                    {
                        get
                        {
                            return ServerSettingsEnvironment.AppVersion;
                        }

                        set
                        {
                            ServerSettingsEnvironment.AppVersion = value;
                        }
                    }

                    static string string_LocalSecurityPassword = String.Empty;
                    public static string LocalSecurityPassword
                    {
                        get
                        {
                            return string_LocalSecurityPassword;
                        }

                        set
                        {
                            string_LocalSecurityPassword = value;
                        }
                    }
                    public string RemotingWrapper_LocalSecurityPassword
                    {
                        get
                        {
                            return ServerSettingsEnvironment.LocalSecurityPassword;
                        }

                        set
                        {
                            ServerSettingsEnvironment.LocalSecurityPassword = value;
                        }
                    }

                    static bool bool_ShowToolTips = true;
                    public static bool ShowToolTips
                    {
                        get
                        {
                            return bool_ShowToolTips;
                        }

                        set
                        {
                            bool_ShowToolTips = value;
                        }
                    }
                    public bool RemotingWrapper_ShowToolTips
                    {
                        get
                        {
                            return ServerSettingsEnvironment.ShowToolTips;
                        }

                        set
                        {
                            ServerSettingsEnvironment.ShowToolTips = value;
                        }
                    }

                    static bool bool_ShowAdvancedSettings = false;
                    public static bool ShowAdvancedSettings
                    {
                        get
                        {
                            return bool_ShowAdvancedSettings;
                        }

                        set
                        {
                            bool_ShowAdvancedSettings = value;
                        }
                    }
                    public bool RemotingWrapper_ShowAdvancedSettings
                    {
                        get
                        {
                            return ServerSettingsEnvironment.ShowAdvancedSettings;
                        }

                        set
                        {
                            ServerSettingsEnvironment.ShowAdvancedSettings = value;
                        }
                    }

                    static bool bool_AutoRun = false;
                    public static bool AutoRun
                    {
                        get
                        {
                            return bool_AutoRun;
                        }

                        set
                        {
                            bool_AutoRun = value;
                        }
                    }
                    public bool RemotingWrapper_AutoRun
                    {
                        get
                        {
                            return ServerSettingsEnvironment.AutoRun;
                        }

                        set
                        {
                            ServerSettingsEnvironment.AutoRun = value;
                        }
                    }

                    static bool bool_StartServerAtRun = false;
                    public static bool StartServerAtRun
                    {
                        get
                        {
                            return bool_StartServerAtRun;
                        }

                        set
                        {
                            bool_StartServerAtRun = value;
                        }
                    }
                    public bool RemotingWrapper_StartServerAtRun
                    {
                        get
                        {
                            return ServerSettingsEnvironment.StartServerAtRun;
                        }

                        set
                        {
                            ServerSettingsEnvironment.StartServerAtRun = value;
                        }
                    }

                    static bool bool_MinimizeToNotifyAreaAtRun = false;
                    public static bool MinimizeToNotifyAreaAtRun
                    {
                        get
                        {
                            return bool_MinimizeToNotifyAreaAtRun;
                        }

                        set
                        {
                            bool_MinimizeToNotifyAreaAtRun = value;
                        }
                    }
                    public bool RemotingWrapper_MinimizeToNotifyAreaAtRun
                    {
                        get
                        {
                            return ServerSettingsEnvironment.MinimizeToNotifyAreaAtRun;
                        }

                        set
                        {
                            ServerSettingsEnvironment.MinimizeToNotifyAreaAtRun = value;
                        }
                    }

                    static bool bool_ShowIconInNotifyArea = true;
                    public static bool ShowIconInNotifyArea
                    {
                        get
                        {
                            return bool_ShowIconInNotifyArea;
                        }

                        set
                        {
                            bool_ShowIconInNotifyArea = value;
                        }
                    }
                    public bool RemotingWrapper_ShowIconInNotifyArea
                    {
                        get
                        {
                            return ServerSettingsEnvironment.ShowIconInNotifyArea;
                        }

                        set
                        {
                            ServerSettingsEnvironment.ShowIconInNotifyArea = value;
                        }
                    }

                    static bool bool_ActivateHiddenModeAtStartUp = false;
                    public static bool ActivateHiddenModeAtStartUp
                    {
                        get
                        {
                            return bool_ActivateHiddenModeAtStartUp;
                        }

                        set
                        {
                            bool_ActivateHiddenModeAtStartUp = value;
                        }
                    }
                    public bool RemotingWrapper_ActivateHiddenModeAtStartUp
                    {
                        get
                        {
                            return ServerSettingsEnvironment.ActivateHiddenModeAtStartUp;
                        }

                        set
                        {
                            ServerSettingsEnvironment.ActivateHiddenModeAtStartUp = value;
                        }
                    }

                    static bool bool_EncryptSettingsDataBase = false;
                    public static bool EncryptSettingsDataBase
                    {
                        get
                        {
                            return bool_EncryptSettingsDataBase;
                        }

                        set
                        {
                            bool_EncryptSettingsDataBase = value;
                        }
                    }
                    public bool RemotingWrapper_EncryptSettingsDataBase
                    {
                        get
                        {
                            return ServerSettingsEnvironment.EncryptSettingsDataBase;
                        }

                        set
                        {
                            ServerSettingsEnvironment.EncryptSettingsDataBase = value;
                        }
                    }

                    static bool bool_CompressSettingsDataBase = true;
                    public static bool CompressSettingsDataBase
                    {
                        get
                        {
                            return bool_CompressSettingsDataBase;
                        }

                        set
                        {
                            bool_CompressSettingsDataBase = value;
                        }
                    }
                    public bool RemotingWrapper_CompressSettingsDataBase
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CompressSettingsDataBase;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CompressSettingsDataBase = value;
                        }
                    }

                    static bool bool_EnableAccessRestrictionRules = false;
                    public static bool EnableAccessRestrictionRules
                    {
                        get
                        {
                            return bool_EnableAccessRestrictionRules;
                        }

                        set
                        {
                            bool_EnableAccessRestrictionRules = value;
                        }
                    }
                    public bool RemotingWrapper_EnableAccessRestrictionRules
                    {
                        get
                        {
                            return ServerSettingsEnvironment.EnableAccessRestrictionRules;
                        }

                        set
                        {
                            ServerSettingsEnvironment.EnableAccessRestrictionRules = value;
                        }
                    }

                    static bool bool_IsProductRegistered = false;
                    public static bool IsProductRegistered
                    {
                        get
                        {
                            return bool_IsProductRegistered;
                        }

                        set
                        {
                            bool_IsProductRegistered = value;
                        }
                    }
                    public bool RemotingWrapper_IsProductRegistered
                    {
                        get
                        {
                            return ServerSettingsEnvironment.IsProductRegistered;
                        }

                        set
                        {
                            ServerSettingsEnvironment.IsProductRegistered = value;
                        }
                    }

                    static string string_ProductLicenceName = String.Empty;
                    public static string ProductLicenceName
                    {
                        get
                        {
                            return string_ProductLicenceName;
                        }

                        set
                        {
                            string_ProductLicenceName = value;
                        }
                    }
                    public string RemotingWrapper_ProductLicenceName
                    {
                        get
                        {
                            return ServerSettingsEnvironment.ProductLicenceName;
                        }

                        set
                        {
                            ServerSettingsEnvironment.ProductLicenceName = value;
                        }
                    }

                    static string string_ProductSerialNumber = String.Empty;
                    public static string ProductSerialNumber
                    {
                        get
                        {
                            return string_ProductSerialNumber;
                        }

                        set
                        {
                            string_ProductSerialNumber = value;
                        }
                    }
                    public string RemotingWrapper_ProductSerialNumber
                    {
                        get
                        {
                            return ServerSettingsEnvironment.ProductSerialNumber;
                        }

                        set
                        {
                            ServerSettingsEnvironment.ProductSerialNumber = value;
                        }
                    }



                    //--------------------------------------------------------------------------------------------------   CSP ChangeUINAccountState

                    static string string_CSP_ChangeUINAccountState_CustomCSPServiceIPAddress = String.Empty;
                    public static string CSP_ChangeUINAccountState_CustomCSPServiceIPAddress
                    {
                        get
                        {
                            return string_CSP_ChangeUINAccountState_CustomCSPServiceIPAddress;
                        }

                        set
                        {
                            string_CSP_ChangeUINAccountState_CustomCSPServiceIPAddress = value;
                        }
                    }
                    public string RemotingWrapper_CSP_ChangeUINAccountState_CustomCSPServiceIPAddress
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServiceIPAddress;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServiceIPAddress = value;
                        }
                    }

                    static int int_CSP_ChangeUINAccountState_CustomCSPServicePort = 5545;
                    public static int CSP_ChangeUINAccountState_CustomCSPServicePort
                    {
                        get
                        {
                            return int_CSP_ChangeUINAccountState_CustomCSPServicePort;
                        }

                        set
                        {
                            int_CSP_ChangeUINAccountState_CustomCSPServicePort = value;
                        }
                    }
                    public int RemotingWrapper_CSP_ChangeUINAccountState_CustomCSPServicePort
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServicePort;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServicePort = value;
                        }
                    }

                    static string string_CSP_ChangeUINAccountState_UIN = String.Empty;
                    public static string CSP_ChangeUINAccountState_UIN
                    {
                        get
                        {
                            return string_CSP_ChangeUINAccountState_UIN;
                        }

                        set
                        {
                            string_CSP_ChangeUINAccountState_UIN = value;
                        }
                    }
                    public string RemotingWrapper_CSP_ChangeUINAccountState_UIN
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ChangeUINAccountState_UIN;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_UIN = value;
                        }
                    }

                    static string string_CSP_ChangeUINAccountState_Password = String.Empty;
                    public static string CSP_ChangeUINAccountState_Password
                    {
                        get
                        {
                            return string_CSP_ChangeUINAccountState_Password;
                        }

                        set
                        {
                            string_CSP_ChangeUINAccountState_Password = value;
                        }
                    }
                    public string RemotingWrapper_CSP_ChangeUINAccountState_Password
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ChangeUINAccountState_Password;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_Password = value;
                        }
                    }

                    static string string_CSP_ChangeUINAccountState_UINActivationCode = String.Empty;
                    public static string CSP_ChangeUINAccountState_UINActivationCode
                    {
                        get
                        {
                            return string_CSP_ChangeUINAccountState_UINActivationCode;
                        }

                        set
                        {
                            string_CSP_ChangeUINAccountState_UINActivationCode = value;
                        }
                    }
                    public string RemotingWrapper_CSP_ChangeUINAccountState_UINActivationCode
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ChangeUINAccountState_UINActivationCode;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_UINActivationCode = value;
                        }
                    }

                    static bool bool_CSP_ChangeUINAccountState_UseJurikSoftCSPServer = true;
                    public static bool CSP_ChangeUINAccountState_UseJurikSoftCSPServer
                    {
                        get
                        {
                            return bool_CSP_ChangeUINAccountState_UseJurikSoftCSPServer;
                        }

                        set
                        {
                            bool_CSP_ChangeUINAccountState_UseJurikSoftCSPServer = value;
                        }
                    }
                    public bool RemotingWrapper_CSP_ChangeUINAccountState_UseJurikSoftCSPServer
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ChangeUINAccountState_UseJurikSoftCSPServer;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_UseJurikSoftCSPServer = value;
                        }
                    }

                    static bool bool_CSP_ChangeUINAccountState_GetActivationCode = false;
                    public static bool CSP_ChangeUINAccountState_GetActivationCode
                    {
                        get
                        {
                            return bool_CSP_ChangeUINAccountState_GetActivationCode;
                        }

                        set
                        {
                            bool_CSP_ChangeUINAccountState_GetActivationCode = value;
                        }
                    }
                    public bool RemotingWrapper_CSP_ChangeUINAccountState_GetActivationCode
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ChangeUINAccountState_GetActivationCode;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_GetActivationCode = value;
                        }
                    }

                    static int int_CSP_ChangeUINAccountState_NewAccountStateIndex = 0;
                    public static int CSP_ChangeUINAccountState_NewAccountStateIndex
                    {
                        get
                        {
                            return int_CSP_ChangeUINAccountState_NewAccountStateIndex;
                        }

                        set
                        {
                            int_CSP_ChangeUINAccountState_NewAccountStateIndex = value;
                        }
                    }
                    public int RemotingWrapper_CSP_ChangeUINAccountState_NewAccountStateIndex
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ChangeUINAccountState_NewAccountStateIndex;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_NewAccountStateIndex = value;
                        }
                    }

                    //--------------------------------------------------------------------------------------------------   CSP

                    static string string_CSP_ServerAuth_CustomCSPServiceIPAddress = String.Empty;
                    public static string CSP_ServerAuth_CustomCSPServiceIPAddress
                    {
                        get
                        {
                            return string_CSP_ServerAuth_CustomCSPServiceIPAddress;
                        }

                        set
                        {
                            string_CSP_ServerAuth_CustomCSPServiceIPAddress = value;
                        }
                    }
                    public string RemotingWrapper_CSP_ServerAuth_CustomCSPServiceIPAddress
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress = value;
                        }
                    }

                    static int int_CSP_ServerAuth_CustomCSPServicePort = 5545;
                    public static int CSP_ServerAuth_CustomCSPServicePort
                    {
                        get
                        {
                            return int_CSP_ServerAuth_CustomCSPServicePort;
                        }

                        set
                        {
                            int_CSP_ServerAuth_CustomCSPServicePort = value;
                        }
                    }
                    public int RemotingWrapper_CSP_ServerAuth_CustomCSPServicePort
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort = value;
                        }
                    }

                    static string string_CSP_ServerAuth_CSPLoginPassword = String.Empty;
                    public static string CSP_ServerAuth_CSPLoginPassword
                    {
                        get
                        {
                            return string_CSP_ServerAuth_CSPLoginPassword;
                        }

                        set
                        {
                            string_CSP_ServerAuth_CSPLoginPassword = value;
                        }
                    }
                    public string RemotingWrapper_CSP_ServerAuth_CSPLoginPassword
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword = value;
                        }
                    }

                    static string string_CSP_ServerAuth_CSPLoginUIN = String.Empty;
                    public static string CSP_ServerAuth_CSPLoginUIN
                    {
                        get
                        {
                            return string_CSP_ServerAuth_CSPLoginUIN;
                        }

                        set
                        {
                            string_CSP_ServerAuth_CSPLoginUIN = value;
                        }
                    }
                    public string RemotingWrapper_CSP_ServerAuth_CSPLoginUIN
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN = value;
                        }
                    }

                    static bool bool_CSP_ServerAuth_UseJurikSoftCSPServer = true;
                    public static bool CSP_ServerAuth_UseJurikSoftCSPServer
                    {
                        get
                        {
                            return bool_CSP_ServerAuth_UseJurikSoftCSPServer;
                        }

                        set
                        {
                            bool_CSP_ServerAuth_UseJurikSoftCSPServer = value;
                        }
                    }
                    public bool RemotingWrapper_CSP_ServerAuth_UseJurikSoftCSPServer
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ServerAuth_UseJurikSoftCSPServer;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ServerAuth_UseJurikSoftCSPServer = value;
                        }
                    }

                    static bool bool_CSP_ServerAuth_IsPublicPublic = true;
                    public static bool CSP_ServerAuth_IsPublicServer
                    {
                        get
                        {
                            return bool_CSP_ServerAuth_IsPublicPublic;
                        }

                        set
                        {
                            bool_CSP_ServerAuth_IsPublicPublic = value;
                        }
                    }
                    public bool RemotingWrapper_CSP_ServerAuth_IsPublicServer
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ServerAuth_IsPublicServer;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ServerAuth_IsPublicServer = value;
                        }
                    }

                    static bool bool_CSP_ServerAuth_HideIP = true;
                    public static bool CSP_ServerAuth_HideIP
                    {
                        get
                        {
                            return bool_CSP_ServerAuth_HideIP;
                        }

                        set
                        {
                            bool_CSP_ServerAuth_HideIP = value;
                        }
                    }
                    public bool RemotingWrapper_CSP_ServerAuth_HideIP
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ServerAuth_HideIP;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ServerAuth_HideIP = value;
                        }
                    }

                    static bool bool_CSP_ServerAuth_KeepConnectionAlive = true;
                    public static bool CSP_ServerAuth_KeepConnectionAlive
                    {
                        get
                        {
                            return bool_CSP_ServerAuth_KeepConnectionAlive;
                        }

                        set
                        {
                            bool_CSP_ServerAuth_KeepConnectionAlive = value;
                        }
                    }
                    public bool RemotingWrapper_CSP_ServerAuth_KeepConnectionAlive
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ServerAuth_KeepConnectionAlive;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ServerAuth_KeepConnectionAlive = value;
                        }
                    }

                    static bool bool_CSP_ServerAuth_ConnectAtStartUp = true;
                    public static bool CSP_ServerAuth_ConnectAtStartUp
                    {
                        get
                        {
                            return bool_CSP_ServerAuth_ConnectAtStartUp;
                        }

                        set
                        {
                            bool_CSP_ServerAuth_ConnectAtStartUp = value;
                        }
                    }
                    public bool RemotingWrapper_CSP_ServerAuth_ConnectAtStartUp
                    {
                        get
                        {
                            return ServerSettingsEnvironment.CSP_ServerAuth_ConnectAtStartUp;
                        }

                        set
                        {
                            ServerSettingsEnvironment.CSP_ServerAuth_ConnectAtStartUp = value;
                        }
                    }


                }
            }
        }
    }
}