using System;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;
using YakSys;
using YakSys.ConnectingServiceXMLConfigImporter;
using YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingService;
using YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingService.Version10;

namespace YakSys
{
    namespace ConnectingServiceXMLConfigImporter
    {
        namespace YakSysConnectingService
        {
            namespace Version10
            {
                public class CSSettingsEnvironment : MarshalByRefObject
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

                    static string string_AppVersion = string.Empty, string_LocalSecurityPassword = string.Empty;

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

                    static int int_ServerPort = 5545;
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

                    static string string_SMTPServer = string.Empty, string_SenderMailAddress = string.Empty, string_SMTPLogin = string.Empty, string_SMTPPassword = string.Empty;
                    public static string SMTPServer
                    {
                        get
                        {
                            return string_SMTPServer;
                        }

                        set
                        {
                            string_SMTPServer = value;
                        }
                    }

                    public static string SenderMailAddress
                    {
                        get
                        {
                            return string_SenderMailAddress;
                        }

                        set
                        {
                            string_SenderMailAddress = value;
                        }
                    }
                    public static string SMTPLogin
                    {
                        get
                        {
                            return string_SMTPLogin;
                        }

                        set
                        {
                            string_SMTPLogin = value;
                        }
                    }
                    public static string SMTPPassword
                    {
                        get
                        {
                            return string_SMTPPassword;
                        }

                        set
                        {
                            string_SMTPPassword = value;
                        }
                    }

                    static int int_SMTPPort = 25;
                    public static int SMTPPort
                    {
                        get
                        {
                            return int_SMTPPort;
                        }

                        set
                        {
                            int_SMTPPort = value;
                        }
                    }


                    static bool
                        bool_ShowToolTips = true,
                        bool_ShowAdvancedSettings = false,

                        bool_AutoRun = false,
                        bool_StartServerAtRun = false,
                        bool_MinimizeToNotifyAreaAtRun = false,
                        bool_ShowIconInNotifyArea = true,

                        bool_CompressSettingsDataBase = true,
                        bool_EncryptSettingsDataBase = false,

                        bool_ActivateHiddenModeAtStartUp = false,

                        bool_IsClientAccessRestrictionRuleEnable = false,
                        bool_IsServerAccessRestrictionRuleEnable = false;

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

                    public static bool bool_IsProductRegistered = false;
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

                    public static string string_ProductLicenceName = "";
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

                    public static string string_ProductSerialNumber = "";
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

                    public static bool IsClientAccessRestrictionRuleEnable
                    {
                        get
                        {
                            return bool_IsClientAccessRestrictionRuleEnable;
                        }

                        set
                        {
                            bool_IsClientAccessRestrictionRuleEnable = value;
                        }
                    }
                    public static bool IsServerAccessRestrictionRuleEnable
                    {
                        get
                        {
                            return bool_IsServerAccessRestrictionRuleEnable;
                        }

                        set
                        {
                            bool_IsServerAccessRestrictionRuleEnable = value;
                        }
                    }
                }
            }
        }
    }
}