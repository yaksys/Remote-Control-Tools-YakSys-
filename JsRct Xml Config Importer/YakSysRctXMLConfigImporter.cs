using System;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;
using YakSys;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctServer;
using YakSys.XMLConfigImporter.YakSysRctServer.Version110;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;
using YakSysRct_Xml_Config_Importer.Client_DataSet_ver_090;
using YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110;
using YakSysRct_Xml_Config_Importer.ConnectingService_DataSet_ver_10;

//using YakSys.XMLConfigImporter.YakSysConnectingService;
//using YakSys.XMLConfigImporter.YakSysConnectingService.Version10;

    

namespace YakSys
{
    namespace XMLConfigImporter
    {

        public class YakSysServerDBEnvironment : MarshalByRefObject
        {
            static string string_DBVersion = string.Empty;

            public static string DBVersion
            {
                get
                {
                    return string_DBVersion;
                }

                set
                {
                    string_DBVersion = value;
                }
            }

            public static void WriteXMLDataToFile(string string_XMLFilePath, string string_VersionHeader, DataSet dataSet_YakSysServerDB)
            {
                FileStream fileStream_ServerDB = File.Create(string_XMLFilePath);

                MemoryStream memoryStream_XMLData = new MemoryStream(), memoryStream_EncryptedXMLData = new MemoryStream();

                SHA256Managed sHA256Managed_obj = new SHA256Managed();

                RijndaelManaged rijndaelManaged_obj = new RijndaelManaged();

                CryptoStream cryptoStream_obj = null;

                byte[] byteArray_ComputedXMLDataHash = new byte[32], byteArray_PasswordHash = new byte[32],
                        byteArray_EncryptedData = null, byteArray_CompressedXMLData,
                        byteArray_HashOfPasswordHash = new byte[32];

                byte byte_ToEncryptServerDataBase = 0, byte_ToCompressSettingsDataBase = 0;

                dataSet_YakSysServerDB.WriteXml(memoryStream_XMLData);


                if (ServerSettingsEnvironment.EncryptSettingsDataBase == true) byte_ToEncryptServerDataBase = 1;
                if (ServerSettingsEnvironment.CompressSettingsDataBase == true) byte_ToCompressSettingsDataBase = 1;


                if (ServerSettingsEnvironment.CompressSettingsDataBase == true)
                {
                    YakSys.Compression.LZSS lZSS_obj = new YakSys.Compression.LZSS(16, true, true, false, 65536);

                    byteArray_CompressedXMLData = lZSS_obj.Compress(memoryStream_XMLData.ToArray(), false);

                    memoryStream_XMLData = new MemoryStream(byteArray_CompressedXMLData);
                }

                byteArray_ComputedXMLDataHash = sHA256Managed_obj.ComputeHash(memoryStream_XMLData);

                if (ServerSettingsEnvironment.LocalSecurityPassword.Length > 5 && ServerSettingsEnvironment.EncryptSettingsDataBase == true)
                {
                    byteArray_PasswordHash = sHA256Managed_obj.ComputeHash(System.Text.Encoding.Default.GetBytes(ServerSettingsEnvironment.LocalSecurityPassword));
                    byteArray_HashOfPasswordHash = sHA256Managed_obj.ComputeHash(byteArray_PasswordHash);

                    rijndaelManaged_obj.KeySize = 256;

                    rijndaelManaged_obj.Key = byteArray_PasswordHash;
                    rijndaelManaged_obj.IV = new byte[rijndaelManaged_obj.BlockSize / 8];

                    cryptoStream_obj = new CryptoStream(memoryStream_EncryptedXMLData, rijndaelManaged_obj.CreateEncryptor(), CryptoStreamMode.Write);

                    cryptoStream_obj.Write(memoryStream_XMLData.ToArray(), 0, memoryStream_XMLData.ToArray().Length);

                    memoryStream_XMLData.SetLength(0);

                    cryptoStream_obj.FlushFinalBlock();

                    byteArray_EncryptedData = memoryStream_EncryptedXMLData.ToArray();

                    cryptoStream_obj.Close();

                    memoryStream_XMLData = new MemoryStream(byteArray_EncryptedData);
                }

                fileStream_ServerDB.Write(System.Text.Encoding.Default.GetBytes(string_VersionHeader), 0, System.Text.Encoding.Default.GetBytes(string_VersionHeader).Length); // string_VersionHeader must be 20 bytes! in JurikSoftClientDB110 ver for example

                fileStream_ServerDB.WriteByte(byte_ToEncryptServerDataBase);
                fileStream_ServerDB.WriteByte(byte_ToCompressSettingsDataBase);

                fileStream_ServerDB.Write(byteArray_ComputedXMLDataHash, 0, byteArray_ComputedXMLDataHash.Length);
                fileStream_ServerDB.Write(byteArray_HashOfPasswordHash, 0, byteArray_HashOfPasswordHash.Length);

                fileStream_ServerDB.Write(memoryStream_XMLData.ToArray(), 0, memoryStream_XMLData.ToArray().Length);

                fileStream_ServerDB.Close();
            }


            public void WriteServerSettingsData(string string_XMLFilePath)
            {
                try
                {
                    DataRow dataRow_NewRecord = null;

                    YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.MainSettingsDataTable mainSettingsDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.MainSettings;

                    YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.CommonSecuritySettingsDataTable commonSecuritySettingsDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.CommonSecuritySettings;

                    new YakSysRctServerV110XMLConfigImporter().InitMainServerSettingsXmlDB();
                    new YakSysRctServerV110XMLConfigImporter().InitCommonSecuritySettingsXmlDB();

                    /////////////////////////

                    dataRow_NewRecord = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.MainSettings.Rows[0];

                    dataRow_NewRecord[mainSettingsDataTable_obj.ServerPortColumn] = ServerSettingsEnvironment.ServerPort;

                    dataRow_NewRecord[mainSettingsDataTable_obj.AppVersionColumn] = ServerSettingsEnvironment.AppVersion;

                    dataRow_NewRecord[mainSettingsDataTable_obj.ShowToolTipsColumn] = ServerSettingsEnvironment.ShowToolTips;

                    dataRow_NewRecord[mainSettingsDataTable_obj.ShowAdvancedSettingsColumn] = ServerSettingsEnvironment.ShowAdvancedSettings;

                    dataRow_NewRecord[mainSettingsDataTable_obj.AutoRunColumn] = ServerSettingsEnvironment.AutoRun;
                    dataRow_NewRecord[mainSettingsDataTable_obj.StartServerAtRunColumn] = ServerSettingsEnvironment.StartServerAtRun;
                    dataRow_NewRecord[mainSettingsDataTable_obj.MinimizeToNotifyAreaAtRunColumn] = ServerSettingsEnvironment.MinimizeToNotifyAreaAtRun;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ShowIconInNotifyAreaColumn] = ServerSettingsEnvironment.ShowIconInNotifyArea;

                    dataRow_NewRecord[mainSettingsDataTable_obj.ActivateHiddenModeAtStartUpColumn] = ServerSettingsEnvironment.ActivateHiddenModeAtStartUp;

                    dataRow_NewRecord[mainSettingsDataTable_obj.CurrentAppLanguageColumn] = ServerSettingsEnvironment.CurrentLanguage;

                    ////////////////////////////

                    dataRow_NewRecord = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.CommonSecuritySettings.Rows[0];

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxConnectionsColumn] = ServerSettingsEnvironment.MaxConnections;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxConnectionPerAccountColumn] = ServerSettingsEnvironment.MaxConnectionsPerAccount;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.EnableAccessRestrictionsColumn] = ServerSettingsEnvironment.EnableAccessRestrictionRules;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.AllowWindowsAccountsColumn] = ServerSettingsEnvironment.IsWindowsAuthenticationAllowed;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MinRSAKeySizeColumn] = ServerSettingsEnvironment.MinRSAPublicKeyLength;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxRSAKeySizeColumn] = ServerSettingsEnvironment.MaxRSAPublicKeyLength;


                    WriteXMLDataToFile(string_XMLFilePath, "YakSysServerDB110", YakSysRctServerV110XMLConfigImporter.YakSysServerDB);
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("YakSysServerDB")) File.Delete("YakSysServerDB");

                    MessageBox.Show(ServerStringFactory.GetString(125, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                    return;
                }

            }

            public static void LoadXMLDataFile(string string_XMLFilePath, bool bool_UseDBImportMode)
            {
                FileStream fileStream_YakSysXMLDB = null;

                MemoryStream memoryStream_XMLData = new MemoryStream(),
                            memoryStream_UnprocessedXMLData = new MemoryStream(),
                            memoryStream_DecryptedXMLData = new MemoryStream(),
                            memoryStream_EncryptedXMLData = null;

                SHA256Managed sHA256Managed_obj = new SHA256Managed();

                RijndaelManaged rijndaelManaged_obj = new RijndaelManaged();

                CryptoStream cryptoStream_obj = null;

                try
                {
                    if (File.Exists(string_XMLFilePath) == false)
                    {
                        new YakSysRctServerV110XMLConfigImporter().InitMainServerSettingsXmlDB();
                        new YakSysRctServerV110XMLConfigImporter().InitCommonSecuritySettingsXmlDB();

                        new YakSysRctServerV110XMLConfigImporter().ApplyDBSettings();

                        return;
                    }

                    fileStream_YakSysXMLDB = File.Open(string_XMLFilePath, FileMode.Open, FileAccess.Read);

                    byte[]
                        byteArray_UnprocessedXMLData = new byte[fileStream_YakSysXMLDB.Length - 83], // 83 depends from "YakSysServerDB090" header
                        byteArray_ComputedXMLDataHash = new byte[32], byteArray_ComputedHashOfPasswordHash = new byte[32],
                        byteArray_StoredXMLDataHash = new byte[32], byteArray_StoredHashOfPasswordHash = new byte[32],
                        byteArray_DecompressedXMLData = null, byteArray_ComputedPasswordHash, byteArray_YakSysServerDBHeader = new byte[17], //!!! "YakSysServerDB090" header is 17 bytes long
                        byteArray_EncryptedXMLData = new byte[fileStream_YakSysXMLDB.Length - 83];// 83 depends from "YakSysServerDB090" header

                    byte byte_IsServerDataBaseEncrypted = 0, byte_IsSettingsDataBaseCompressed = 0;

                    fileStream_YakSysXMLDB.Read(byteArray_YakSysServerDBHeader, 0, byteArray_YakSysServerDBHeader.Length);

                    DBVersion = System.Text.Encoding.Default.GetString(byteArray_YakSysServerDBHeader);

                    if (
                        DBVersion != ("YakSysServerDB090") &&
                        DBVersion != ("YakSysServerDB010") &&
                        DBVersion != ("YakSysServerDB110")
                        )
                    {
                        fileStream_YakSysXMLDB.Close();

                        new YakSysRctServerV110XMLConfigImporter().InitMainServerSettingsXmlDB();
                        new YakSysRctServerV110XMLConfigImporter().InitCommonSecuritySettingsXmlDB();

                        new YakSysRctServerV110XMLConfigImporter().ApplyDBSettings();

                        MessageBox.Show(ServerStringFactory.GetString(124, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                        return;
                    }

                    byte_IsServerDataBaseEncrypted = (byte)fileStream_YakSysXMLDB.ReadByte();
                    byte_IsSettingsDataBaseCompressed = (byte)fileStream_YakSysXMLDB.ReadByte();

                    fileStream_YakSysXMLDB.Position = 83; // 83 depends from "YakSysServerDB090" header

                    fileStream_YakSysXMLDB.Read(byteArray_UnprocessedXMLData, 0, byteArray_UnprocessedXMLData.Length);

                    memoryStream_XMLData = new MemoryStream(byteArray_UnprocessedXMLData);

                    if (byte_IsServerDataBaseEncrypted == 1)
                    {
                        DialogResult dialogResult_PasswordDialog = new DialogResult();

                        if (bool_UseDBImportMode == false)
                        {
                            PasswordVerificationForm passwordVerificationForm_obj = new PasswordVerificationForm();

                            passwordVerificationForm_obj.CallerID = 0;

                            dialogResult_PasswordDialog = passwordVerificationForm_obj.ShowDialog();

                            ServerSettingsEnvironment.LocalSecurityPassword = passwordVerificationForm_obj.DBPassword;

                            passwordVerificationForm_obj.Close();
                        }

                        if (bool_UseDBImportMode == true)
                        {
                            PasswordPromptForm passwordPromptForm_obj = new PasswordPromptForm();

                            dialogResult_PasswordDialog = passwordPromptForm_obj.ShowDialog();

                            ServerSettingsEnvironment.LocalSecurityPassword = passwordPromptForm_obj.DBPassword;

                            passwordPromptForm_obj.Close();
                        }

                        if (dialogResult_PasswordDialog == DialogResult.Abort || dialogResult_PasswordDialog == DialogResult.Ignore || dialogResult_PasswordDialog == DialogResult.Cancel)
                        {
                            return;
                        }

                        fileStream_YakSysXMLDB.Position = 22;

                        fileStream_YakSysXMLDB.Read(byteArray_StoredXMLDataHash, 0, byteArray_StoredXMLDataHash.Length);
                        fileStream_YakSysXMLDB.Read(byteArray_StoredHashOfPasswordHash, 0, byteArray_StoredHashOfPasswordHash.Length);

                        byteArray_ComputedPasswordHash = sHA256Managed_obj.ComputeHash(System.Text.Encoding.Default.GetBytes(ServerSettingsEnvironment.LocalSecurityPassword));
                        byteArray_ComputedHashOfPasswordHash = sHA256Managed_obj.ComputeHash(byteArray_ComputedPasswordHash);

                        if (CommonMethods.IsBytesArraysEquals(byteArray_ComputedHashOfPasswordHash, byteArray_StoredHashOfPasswordHash) == false)
                        {
                            MessageBox.Show(ServerStringFactory.GetString(126, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            if (fileStream_YakSysXMLDB != null) fileStream_YakSysXMLDB.Close();

                            if (memoryStream_XMLData != null) memoryStream_XMLData.Close();
                            if (memoryStream_UnprocessedXMLData != null) memoryStream_UnprocessedXMLData.Close();
                            if (memoryStream_DecryptedXMLData != null) memoryStream_DecryptedXMLData.Close();
                            if (memoryStream_EncryptedXMLData != null) memoryStream_EncryptedXMLData.Close();

                            if (sHA256Managed_obj != null) sHA256Managed_obj.Clear();
                            if (rijndaelManaged_obj != null) rijndaelManaged_obj.Clear();

                            if (cryptoStream_obj != null) cryptoStream_obj.Close();

                            LoadXMLDataFile(string_XMLFilePath, bool_UseDBImportMode);

                            return;
                        }

                        rijndaelManaged_obj.KeySize = 256;

                        rijndaelManaged_obj.Key = byteArray_ComputedPasswordHash;
                        rijndaelManaged_obj.IV = new byte[rijndaelManaged_obj.BlockSize / 8];

                        memoryStream_EncryptedXMLData = new MemoryStream(byteArray_UnprocessedXMLData);

                        cryptoStream_obj = new CryptoStream(memoryStream_EncryptedXMLData, rijndaelManaged_obj.CreateDecryptor(), CryptoStreamMode.Read);

                        while (true)
                        {
                            int int_Byte = cryptoStream_obj.ReadByte();

                            if (int_Byte == -1) break;

                            memoryStream_DecryptedXMLData.WriteByte((byte)int_Byte);
                        }

                        memoryStream_EncryptedXMLData.Close();

                        cryptoStream_obj.Flush();
                        cryptoStream_obj.Clear();
                        cryptoStream_obj.Close();

                        ServerSettingsEnvironment.EncryptSettingsDataBase = true;

                        memoryStream_XMLData = new MemoryStream(memoryStream_DecryptedXMLData.ToArray());

                        memoryStream_DecryptedXMLData.Close();

                        ServerSettingsEnvironment.EncryptSettingsDataBase = true;
                    }
                    else
                    {
                        ServerSettingsEnvironment.EncryptSettingsDataBase = false;
                    }

                    if (byte_IsSettingsDataBaseCompressed == 1)
                    {
                        byteArray_DecompressedXMLData = new YakSys.Compression.CommonEnvironment().Decompress(memoryStream_XMLData.ToArray(), false);

                        memoryStream_XMLData = new MemoryStream(byteArray_DecompressedXMLData);

                        ServerSettingsEnvironment.CompressSettingsDataBase = true;
                    }
                    else
                    {
                        ServerSettingsEnvironment.CompressSettingsDataBase = false;
                    }

                    fileStream_YakSysXMLDB.Close();

                    if (DBVersion == "YakSysServerDB090")
                    {
                        new YakSysRctServer.Version090.YakSysRctServerV090XMLConfigImporter().RetriveServerSettingsData(memoryStream_XMLData);

                        SyncIdentTables();
                    }

                    if (DBVersion == "YakSysServerDB110")
                    {
                        new YakSysRctServerV110XMLConfigImporter().RetriveServerSettingsData(memoryStream_XMLData);
                    }

                    memoryStream_XMLData.Close();
                }

                catch
                {
                }
                finally
                {
                    if (fileStream_YakSysXMLDB != null) fileStream_YakSysXMLDB.Close();

                    if (memoryStream_XMLData != null) memoryStream_XMLData.Close();
                    if (memoryStream_UnprocessedXMLData != null) memoryStream_UnprocessedXMLData.Close();
                    if (memoryStream_DecryptedXMLData != null) memoryStream_DecryptedXMLData.Close();
                    if (memoryStream_EncryptedXMLData != null) memoryStream_EncryptedXMLData.Close();

                    if (sHA256Managed_obj != null) sHA256Managed_obj.Clear();
                    if (rijndaelManaged_obj != null) rijndaelManaged_obj.Clear();

                    if (cryptoStream_obj != null) cryptoStream_obj.Close();
                }
            }
            public void RemotingWrapper_LoadXMLDataFile(string string_XMLFilePath, bool bool_UseDBImportMode)
            {
                YakSysServerDBEnvironment.LoadXMLDataFile(string_XMLFilePath, bool_UseDBImportMode);
            }

            public static void SyncIdentTables()
            {
                if (DBVersion == "YakSysServerDB090")
                {
                    YakSysRctServerV110XMLConfigImporter.YakSysServerDB.EventsLog.Rows.Clear();

                    for (int int_CycleCount = 0; int_CycleCount != YakSys.XMLConfigImporter.YakSysRctServer.Version090.YakSysRctServerV090XMLConfigImporter.YakSysServerDB.EventsLog.Rows.Count; int_CycleCount++)
                    {
                        YakSysRctServerV110XMLConfigImporter.YakSysServerDB.EventsLog.Rows.Add(YakSysRctServer.Version090.YakSysRctServerV090XMLConfigImporter.YakSysServerDB.EventsLog.Rows[int_CycleCount].ItemArray);
                    }

                    YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase.Rows.Clear();

                    for (int int_CycleCount = 0; int_CycleCount != YakSys.XMLConfigImporter.YakSysRctServer.Version090.YakSysRctServerV090XMLConfigImporter.YakSysServerDB.SecurityDataBase.Rows.Count; int_CycleCount++)
                    {
                        YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase.Rows.Add(YakSysRctServer.Version090.YakSysRctServerV090XMLConfigImporter.YakSysServerDB.SecurityDataBase.Rows[int_CycleCount].ItemArray);
                    }

                    YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules.Rows.Clear();

                    for (int int_CycleCount = 0; int_CycleCount != YakSys.XMLConfigImporter.YakSysRctServer.Version090.YakSysRctServerV090XMLConfigImporter.YakSysServerDB.AccessRestrictionRules.Rows.Count; int_CycleCount++)
                    {
                        YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules.Rows.Add(YakSysRctServer.Version090.YakSysRctServerV090XMLConfigImporter.YakSysServerDB.AccessRestrictionRules.Rows[int_CycleCount].ItemArray);
                    }
                }
            }


            public class SecurityDataBase : MarshalByRefObject
            {
                string string_UserName = string.Empty;
                public string UserName
                {
                    get
                    {
                        return string_UserName;
                    }

                    set
                    {
                        string_UserName = value;
                    }
                }

                string string_Login = string.Empty;
                public string Login
                {
                    get
                    {
                        return string_Login;
                    }

                    set
                    {
                        string_Login = value;
                    }
                }

                string string_Password = string.Empty;
                public string Password
                {
                    get
                    {
                        return string_Password;
                    }

                    set
                    {
                        string_Password = value;
                    }
                }

                DateTime dateTime_CreationTime = new DateTime();
                public DateTime CreationTime
                {
                    get
                    {
                        return dateTime_CreationTime;
                    }

                    set
                    {
                        dateTime_CreationTime = value;
                    }
                }

                bool bool_IsAccountEnabled = true;
                public bool IsAccountEnabled
                {
                    get
                    {
                        return bool_IsAccountEnabled;
                    }

                    set
                    {
                        bool_IsAccountEnabled = value;
                    }
                }
            }

            public class AccessRestrictionRule : MarshalByRefObject
            {
                IPAddress iPAddress_IPAddressesRangeStartValue = null;
                IPAddress iPAddress_IPAddressesRangeEndValue = null;
                IPAddress iPAddress_IPAddress = null;

                string string_IPAddressesRangeStartValueText = string.Empty, string_IPAddressesRangeEndValueText = string.Empty,
                       string_IPAddressText = string.Empty, string_MACAddress = string.Empty, string_IPAddressesRangeValueText = string.Empty,
                       string_RuleTypeStringRepresentation = string.Empty;

                bool bool_ComplementaryUseMACAddress, bool_IsRuleEnabled;

                int int_RuleTypeIndex = 0;

                DateTime dateTime_CreationTime;



                public IPAddress IPAddressesRangeStartValue
                {
                    get
                    {
                        return iPAddress_IPAddressesRangeStartValue;
                    }

                    set
                    {
                        iPAddress_IPAddressesRangeStartValue = value;
                    }
                }

                public IPAddress IPAddressesRangeEndValue
                {
                    get
                    {
                        return iPAddress_IPAddressesRangeEndValue;
                    }

                    set
                    {
                        iPAddress_IPAddressesRangeEndValue = value;
                    }
                }

                public IPAddress IPAddress
                {
                    get
                    {
                        return iPAddress_IPAddress;
                    }

                    set
                    {
                        iPAddress_IPAddress = value;
                    }
                }


                public string IPAddressesRangeStartValueText
                {
                    get
                    {
                        return string_IPAddressesRangeStartValueText;
                    }

                    set
                    {
                        string_IPAddressesRangeStartValueText = value;
                    }
                }

                public string IPAddressesRangeEndValueText
                {
                    get
                    {
                        return string_IPAddressesRangeEndValueText;
                    }

                    set
                    {
                        string_IPAddressesRangeEndValueText = value;
                    }
                }

                public string IPAddressText
                {
                    get
                    {
                        return string_IPAddressText;
                    }

                    set
                    {
                        string_IPAddressText = value;
                    }
                }

                public string MACAddress
                {
                    get
                    {
                        return string_MACAddress;
                    }

                    set
                    {
                        string_MACAddress = value;
                    }
                }

                public string IPAddressesRangeValueText
                {
                    get
                    {
                        return string_IPAddressesRangeValueText;
                    }

                    set
                    {
                        string_IPAddressesRangeValueText = value;
                    }
                }

                public string RuleTypeStringRepresentation
                {
                    get
                    {
                        return string_RuleTypeStringRepresentation;
                    }

                    set
                    {
                        string_RuleTypeStringRepresentation = value;
                    }
                }

                public bool ComplementaryUseMACAddress
                {
                    get
                    {
                        return bool_ComplementaryUseMACAddress;
                    }

                    set
                    {
                        bool_ComplementaryUseMACAddress = value;
                    }
                }

                public bool IsRuleEnabled
                {
                    get
                    {
                        return bool_IsRuleEnabled;
                    }

                    set
                    {
                        bool_IsRuleEnabled = value;
                    }
                }

                public int RuleTypeIndex
                {
                    get
                    {
                        return int_RuleTypeIndex;
                    }

                    set
                    {
                        int_RuleTypeIndex = value;
                    }
                }

                public DateTime CreationTime
                {
                    get
                    {
                        return dateTime_CreationTime;
                    }

                    set
                    {
                        dateTime_CreationTime = value;
                    }
                }
            }


            public ListViewItem[] GetEventsLog()
            {
                if (YakSysRctServerV110XMLConfigImporter.YakSysServerDB.EventsLog.Rows.Count < 0) return null;

                DataRow dataRow_NewRecord = null;

                YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.EventsLogDataTable eventsLogDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.EventsLog;

                ////////////////////////////////////////////////////////////////////////////////

                ListViewItem[] listViewItemArray_Logs = new ListViewItem[eventsLogDataTable_obj.Rows.Count];

                string string_LogType, string_LogDate, string_LogTime, string_LogSource, string_LogDescription;

                for (int int_CycleCount = 0; int_CycleCount != eventsLogDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.EventsLog.Rows[int_CycleCount];

                    string_LogSource = (string)dataRow_NewRecord[eventsLogDataTable_obj.SourceColumn];
                    string_LogType = (string)dataRow_NewRecord[eventsLogDataTable_obj.TypeColumn];
                    string_LogDescription = (string)dataRow_NewRecord[eventsLogDataTable_obj.DescriptionColumn];
                    string_LogDate = (string)dataRow_NewRecord[eventsLogDataTable_obj.DateColumn];
                    string_LogTime = (string)dataRow_NewRecord[eventsLogDataTable_obj.TimeColumn];

                    listViewItemArray_Logs[int_CycleCount] = new ListViewItem(string_LogType, 0);

                    listViewItemArray_Logs[int_CycleCount].SubItems.Add(string_LogDate);
                    listViewItemArray_Logs[int_CycleCount].SubItems.Add(string_LogTime);
                    listViewItemArray_Logs[int_CycleCount].SubItems.Add(string_LogSource);
                    listViewItemArray_Logs[int_CycleCount].SubItems.Add(string_LogDescription);
                }

                return listViewItemArray_Logs;
            }

            public SecurityDataBase[] GetSecurityDataBase()
            {
                if (YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase.Rows.Count < 0) return new YakSys.XMLConfigImporter.YakSysServerDBEnvironment.SecurityDataBase[0];

                DataRow dataRow_NewRecord = null;

                YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase;

                /////////////////////////////////////////

                XMLConfigImporter.YakSysServerDBEnvironment.SecurityDataBase[] securityDataBaseArray_obj = new YakSys.XMLConfigImporter.YakSysServerDBEnvironment.SecurityDataBase[securityDataBaseDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != securityDataBaseDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase.Rows[int_CycleCount];

                    securityDataBaseArray_obj[int_CycleCount] = new YakSys.XMLConfigImporter.YakSysServerDBEnvironment.SecurityDataBase();

                    securityDataBaseArray_obj[int_CycleCount].UserName = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserNameColumn];
                    securityDataBaseArray_obj[int_CycleCount].Login = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserLoginColumn];
                    securityDataBaseArray_obj[int_CycleCount].Password = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserPasswordColumn];

                    securityDataBaseArray_obj[int_CycleCount].CreationTime = (DateTime)dataRow_NewRecord[securityDataBaseDataTable_obj.CreationTimeColumn];

                    securityDataBaseArray_obj[int_CycleCount].IsAccountEnabled = (bool)dataRow_NewRecord[securityDataBaseDataTable_obj.EnabledAccountStateColumn];
                }

                return securityDataBaseArray_obj;
            }

            public AccessRestrictionRule[] GetAccessRestrictionRules()
            {
                if (YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules.Rows.Count < 0) return new AccessRestrictionRule[0];

                DataRow dataRow_NewRecord = null;

                YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules;

                ////////////////////////////////////////////////////////////////////////////////

                AccessRestrictionRule[] accessRestrictionRuleArray_obj = new AccessRestrictionRule[accessRestrictionRulesDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != accessRestrictionRulesDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules.Rows[int_CycleCount];

                    accessRestrictionRuleArray_obj[int_CycleCount] = new AccessRestrictionRule();

                    accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValueText = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
                    accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValueText = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].IPAddressText = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPAddressColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].MACAddress = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.MACAddressColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].CreationTime = (DateTime)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.CreationTimeColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].ComplementaryUseMACAddress = (bool)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeIndex = (int)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.RuleTypeColumn];

                    if (accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValueText != string.Empty && accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValueText != string.Empty)
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValue = IPAddress.Parse(accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValueText);

                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValue = IPAddress.Parse(accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValueText);

                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeValueText = accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValue + " - " + accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValue;
                    }

                    if (accessRestrictionRuleArray_obj[int_CycleCount].IPAddressText != string.Empty)
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddress = IPAddress.Parse(accessRestrictionRuleArray_obj[int_CycleCount].IPAddressText);
                    }

                    if (accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeIndex == 0)
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeStringRepresentation = ServerStringFactory.GetString(197, ServerSettingsEnvironment.CurrentLanguage);
                    }

                    else
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeStringRepresentation = ServerStringFactory.GetString(198, ServerSettingsEnvironment.CurrentLanguage);
                    }

                    accessRestrictionRuleArray_obj[int_CycleCount].IsRuleEnabled = (bool)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn];
                }

                return accessRestrictionRuleArray_obj;

            }


            public void RemoveSecurityDataBaseRow(int int_RowIndex)
            {
                YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveAccessRestrictionRulesDataBaseRow(int int_RowIndex)
            {
                YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveEventsLogDataBaseRow(int int_RowIndex)
            {
                YakSysRctServerV110XMLConfigImporter.YakSysServerDB.EventsLog.Rows.RemoveAt(int_RowIndex);
            }


            public void ClearSecurityDataBase()
            {
                YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase.Rows.Clear();
            }

            public void ClearAccessRestrictionRulesDataBase()
            {
                YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules.Rows.Clear();
            }

            public void ClearEventsLogDataBase()
            {
                YakSysRctServerV110XMLConfigImporter.YakSysServerDB.EventsLog.Rows.Clear();
            }
        }

        public class YakSysClientDBEnvironment
        {
            static string string_DBVersion = string.Empty;

            public static string DBVersion
            {
                get
                {
                    return string_DBVersion;
                }

                set
                {
                    string_DBVersion = value;
                }
            }

            public static void WriteXMLDataToFile(string string_XMLFilePath, string string_VersionHeader, DataSet dataSet_YakSysClientDB)
            {
                FileStream fileStream_ClientDB = File.Create(string_XMLFilePath);

                MemoryStream memoryStream_XMLData = new MemoryStream(), memoryStream_EncryptedXMLData = new MemoryStream();

                SHA256Managed sHA256Managed_obj = new SHA256Managed();

                RijndaelManaged rijndaelManaged_obj = new RijndaelManaged();

                CryptoStream cryptoStream_obj = null;

                byte[] byteArray_ComputedXMLDataHash = new byte[32], byteArray_PasswordHash = new byte[32],
                        byteArray_EncryptedData = null, byteArray_CompressedXMLData,
                        byteArray_HashOfPasswordHash = new byte[32];

                byte byte_ToEncryptClientDataBase = 0, byte_ToCompressClientDataBase = 0;

                dataSet_YakSysClientDB.WriteXml(memoryStream_XMLData);


                if (ClientSettingsEnvironment.EncryptSettingsDataBase == true) byte_ToEncryptClientDataBase = 1;
                if (ClientSettingsEnvironment.CompressSettingsDataBase == true) byte_ToCompressClientDataBase = 1;


                if (ClientSettingsEnvironment.CompressSettingsDataBase == true)
                {
                    YakSys.Compression.LZSS lZSS_obj = new YakSys.Compression.LZSS(16, true, true, false, 65536);

                    byteArray_CompressedXMLData = lZSS_obj.Compress(memoryStream_XMLData.ToArray(), false);

                    memoryStream_XMLData = new MemoryStream(byteArray_CompressedXMLData);
                }

                byteArray_ComputedXMLDataHash = sHA256Managed_obj.ComputeHash(memoryStream_XMLData);

                if (ClientSettingsEnvironment.LocalSecurityPassword.Length > 5 && ClientSettingsEnvironment.EncryptSettingsDataBase == true)
                {
                    byteArray_PasswordHash = sHA256Managed_obj.ComputeHash(System.Text.Encoding.Default.GetBytes(ClientSettingsEnvironment.LocalSecurityPassword));
                    byteArray_HashOfPasswordHash = sHA256Managed_obj.ComputeHash(byteArray_PasswordHash);

                    rijndaelManaged_obj.KeySize = 256;

                    rijndaelManaged_obj.Key = byteArray_PasswordHash;
                    rijndaelManaged_obj.IV = new byte[rijndaelManaged_obj.BlockSize / 8];

                    cryptoStream_obj = new CryptoStream(memoryStream_EncryptedXMLData, rijndaelManaged_obj.CreateEncryptor(), CryptoStreamMode.Write);

                    cryptoStream_obj.Write(memoryStream_XMLData.ToArray(), 0, memoryStream_XMLData.ToArray().Length);

                    memoryStream_XMLData.SetLength(0);

                    cryptoStream_obj.FlushFinalBlock();

                    byteArray_EncryptedData = memoryStream_EncryptedXMLData.ToArray();

                    cryptoStream_obj.Close();

                    memoryStream_XMLData = new MemoryStream(byteArray_EncryptedData);
                }

                fileStream_ClientDB.Write(System.Text.Encoding.Default.GetBytes(string_VersionHeader), 0, System.Text.Encoding.Default.GetBytes(string_VersionHeader).Length); // string_VersionHeader must be 20 bytes!

                fileStream_ClientDB.WriteByte(byte_ToEncryptClientDataBase);
                fileStream_ClientDB.WriteByte(byte_ToCompressClientDataBase);

                fileStream_ClientDB.Write(byteArray_ComputedXMLDataHash, 0, byteArray_ComputedXMLDataHash.Length);
                fileStream_ClientDB.Write(byteArray_HashOfPasswordHash, 0, byteArray_HashOfPasswordHash.Length);

                fileStream_ClientDB.Write(memoryStream_XMLData.ToArray(), 0, memoryStream_XMLData.ToArray().Length);

                fileStream_ClientDB.Close();
            }

            public void WriteClientSettingsData(string string_XMLFilePath)
            {
                try
                {
                    DataRow dataRow_NewRecord = null;

                    YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.MainSettingsDataTable mainSettingsDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.MainSettings;

                    YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ProxyServersSettingsDataTable proxyServersSettingsDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings;

                    /////////////////////////

                    dataRow_NewRecord = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.MainSettings.Rows[0];

                    dataRow_NewRecord[mainSettingsDataTable_obj.AppVersionColumn] = ClientSettingsEnvironment.AppVersion;

                    dataRow_NewRecord[mainSettingsDataTable_obj.ToEncryptSentFilesColumn] = ClientSettingsEnvironment.ToEncryptSentFiles;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ToEncryptSentSystemDataColumn] = ClientSettingsEnvironment.ToEncryptSentSystemData;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ToEncryptReceivedScreenshotsColumn] = ClientSettingsEnvironment.ToEncryptReceivedScreenshots;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ToEncryptDownloadedFilesColumn] = ClientSettingsEnvironment.ToEncryptDownloadedFiles;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ToEncryptReceivedSystemDataColumn] = ClientSettingsEnvironment.ToEncryptReceivedSystemData;

                    dataRow_NewRecord[mainSettingsDataTable_obj.ToCompressSentFilesColumn] = ClientSettingsEnvironment.ToCompressSentFiles;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ToCompressSentSystemDataColumn] = ClientSettingsEnvironment.ToCompressSentSystemData;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ToCompressReceivedScreenshotsColumn] = ClientSettingsEnvironment.ToEncryptReceivedScreenshots;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ToCompressDownloadedFilesColumn] = ClientSettingsEnvironment.ToCompressDownloadedFiles;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ToCompressReceivedSystemDataColumn] = ClientSettingsEnvironment.ToCompressReceivedSystemData;

                    dataRow_NewRecord[mainSettingsDataTable_obj.UseProxyServerColumn] = ClientSettingsEnvironment.UseProxyServer;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ShowToolTipsColumn] = ClientSettingsEnvironment.ShowToolTips;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ShowAdvancedSettingsColumn] = ClientSettingsEnvironment.ShowAdvancedSettings;

                    dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedFilesPathColumn] = ClientSettingsEnvironment.DownloadedFilesPath;
                    dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedScreenShotsPathColumn] = ClientSettingsEnvironment.DownloadedScreenShotsPath;

                    dataRow_NewRecord[mainSettingsDataTable_obj.CurrentAppLanguageColumn] = ClientSettingsEnvironment.CurrentLanguage;

                    dataRow_NewRecord[mainSettingsDataTable_obj.ServerHostColumn] = ClientSettingsEnvironment.ServerHost;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ServerPortColumn] = ClientSettingsEnvironment.ServerPort;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ServerLoginColumn] = ClientSettingsEnvironment.LoginForConnection;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ServerPasswordColumn] = ClientSettingsEnvironment.PasswordForConnection;

                    /*
                        0 - AES 128 bit
                        1 - AES 256 bit
                        2 - DES 64 bit
                        3 - RC2 40 bit
                        4 - RC2 128 bit
                        5 - TripleDES 128 bit
                        6 - TripleDES 192 bit
                    */

                    dataRow_NewRecord[mainSettingsDataTable_obj.SentFilesEncryptAlgorithmIndexColumn] = ClientSettingsEnvironment.SentFilesEncryptAlgorithmIndex;
                    dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedFilesEncryptAlgorithmIndexColumn] = ClientSettingsEnvironment.DownloadedFilesEncryptAlgorithmIndex;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedScreenshotsEncryptAlgorithmIndexColumn] = ClientSettingsEnvironment.ReceivedScreenshotsEncryptAlgorithmIndex;
                    dataRow_NewRecord[mainSettingsDataTable_obj.SendingSystemDataEncryptAlgorithmIndexColumn] = ClientSettingsEnvironment.SendingSystemDataEncryptAlgorithmIndex;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedSystemDataEncryptAlgorithmIndexColumn] = ClientSettingsEnvironment.ReceivedSystemDataEncryptAlgorithmIndex;


                    /*
                        0 - Adaptive Prefix Codes
                        1 - Non-Adaptive Prefix Codes
                        2 - LZSS
                        3 - RLE
                        4 - MS Deflate
                    */

                    dataRow_NewRecord[mainSettingsDataTable_obj.SentFilesCompressAlgorithmIndexColumn] = ClientSettingsEnvironment.SentFilesCompressAlgorithmIndex;
                    dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedFilesCompressAlgorithmIndexColumn] = ClientSettingsEnvironment.DownloadedFilesCompressAlgorithmIndex;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedScreenshotsCompressAlgorithmIndexColumn] = ClientSettingsEnvironment.ReceivedScreenshotsCompressAlgorithmIndex;
                    dataRow_NewRecord[mainSettingsDataTable_obj.SendingSystemDataCompressAlgorithmIndexColumn] = ClientSettingsEnvironment.SendingSystemDataCompressAlgorithmIndex;
                    dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedSystemDataCompressAlgorithmIndexColumn] = ClientSettingsEnvironment.ReceivedSystemDataCompressAlgorithmIndex;

                    dataRow_NewRecord[mainSettingsDataTable_obj.RememberLoginsColumn] = ClientSettingsEnvironment.RememberLogins;
                    dataRow_NewRecord[mainSettingsDataTable_obj.RememberPasswordsColumn] = ClientSettingsEnvironment.RememberPasswords;


                    /////////////////////////

                    dataRow_NewRecord = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings.Rows[0];

                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.ProxyHostColumn] = ClientSettingsEnvironment.ProxyServerHost;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.ProxyPortColumn] = ClientSettingsEnvironment.ProxyServerPort;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.ProxyTimeOutColumn] = ClientSettingsEnvironment.ProxyServerTimeOut;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.ProxyTypeColumn] = ClientSettingsEnvironment.ProxyServerType;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn] = ClientSettingsEnvironment.UseProxyToResolveHostNames;

                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.UseAuthenticationColumn] = ClientSettingsEnvironment.UseProxyAuthentication;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.LoginColumn] = ClientSettingsEnvironment.ProxyLogin;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.PasswordColumn] = ClientSettingsEnvironment.ProxyPassword;

                    WriteXMLDataToFile(string_XMLFilePath, "YakSysClientDB110", YakSysRctClientV110XMLConfigImporter.YakSysClientDB);
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("YakSysClientDB")) File.Delete("YakSysClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(481, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return;
                }

            }

            public static void LoadXMLDataFile(string string_XMLFilePath, bool bool_UseDBImportMode)
            {
                FileStream fileStream_YakSysXMLDB = null;

                MemoryStream memoryStream_XMLData = new MemoryStream(),
                            memoryStream_UnprocessedXMLData = new MemoryStream(),
                            memoryStream_DecryptedXMLData = new MemoryStream(),
                            memoryStream_EncryptedXMLData = null;

                SHA256Managed sHA256Managed_obj = new SHA256Managed();

                RijndaelManaged rijndaelManaged_obj = new RijndaelManaged();

                CryptoStream cryptoStream_obj = null;

                try
                {
                    if (File.Exists(string_XMLFilePath) == false)
                    {
                        new YakSysRctClientV110XMLConfigImporter().InitProxyServersSettingsXmlDB();
                        new YakSysRctClientV110XMLConfigImporter().InitMainClientSettingsXmlDB();

                        new YakSysRctClientV110XMLConfigImporter().ApplyDBSettings();

                        return;
                    }

                    fileStream_YakSysXMLDB = File.Open(string_XMLFilePath, FileMode.Open, FileAccess.Read);

                    byte[]
                        byteArray_UnprocessedXMLData = new byte[fileStream_YakSysXMLDB.Length - 83],// 83 depends from "YakSysServerDB090" header
                        byteArray_ComputedXMLDataHash = new byte[32], byteArray_ComputedHashOfPasswordHash = new byte[32],
                        byteArray_StoredXMLDataHash = new byte[32], byteArray_StoredHashOfPasswordHash = new byte[32],
                        byteArray_DecompressedXMLData = null, byteArray_ComputedPasswordHash, byteArray_YakSysClientDBHeader = new byte[17],
                        byteArray_EncryptedXMLData = new byte[fileStream_YakSysXMLDB.Length - 83];// 83 depends from "YakSysServerDB090" header

                    byte byte_IsClientDataBaseEncrypted = 0, byte_IsSettingsDataBaseCompressed = 0;

                    fileStream_YakSysXMLDB.Read(byteArray_YakSysClientDBHeader, 0, byteArray_YakSysClientDBHeader.Length);

                    DBVersion = System.Text.Encoding.Default.GetString(byteArray_YakSysClientDBHeader);

                    if (
                        DBVersion != ("YakSysClientDB090") &&
                        DBVersion != ("YakSysClientDB010") &&
                        DBVersion != ("YakSysClientDB110")
                        )
                    {
                        fileStream_YakSysXMLDB.Close();

                        new YakSysRctClientV110XMLConfigImporter().InitProxyServersSettingsXmlDB();
                        new YakSysRctClientV110XMLConfigImporter().InitMainClientSettingsXmlDB();

                        new YakSysRctClientV110XMLConfigImporter().ApplyDBSettings();

                        MessageBox.Show(ClientStringFactory.GetString(542, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                        return;
                    }

                    byte_IsClientDataBaseEncrypted = (byte)fileStream_YakSysXMLDB.ReadByte();
                    byte_IsSettingsDataBaseCompressed = (byte)fileStream_YakSysXMLDB.ReadByte();

                    fileStream_YakSysXMLDB.Position = 83;// 83 depends from "YakSysServerDB090" header

                    fileStream_YakSysXMLDB.Read(byteArray_UnprocessedXMLData, 0, byteArray_UnprocessedXMLData.Length);

                    memoryStream_XMLData = new MemoryStream(byteArray_UnprocessedXMLData);

                    if (byte_IsClientDataBaseEncrypted == 1)
                    {
                        DialogResult dialogResult_PasswordDialog = new DialogResult();

                        if (bool_UseDBImportMode == false)
                        {
                            PasswordVerificationForm passwordVerificationForm_obj = new PasswordVerificationForm();

                            passwordVerificationForm_obj.CallerID = 1;

                            dialogResult_PasswordDialog = passwordVerificationForm_obj.ShowDialog();

                            ClientSettingsEnvironment.LocalSecurityPassword = passwordVerificationForm_obj.DBPassword;

                            passwordVerificationForm_obj.Close();
                        }

                        if (bool_UseDBImportMode == true)
                        {
                            PasswordPromptForm passwordPromptForm_obj = new PasswordPromptForm();

                            dialogResult_PasswordDialog = passwordPromptForm_obj.ShowDialog();

                            ClientSettingsEnvironment.LocalSecurityPassword = passwordPromptForm_obj.DBPassword;

                            passwordPromptForm_obj.Close();
                        }

                        if (dialogResult_PasswordDialog == DialogResult.Abort || dialogResult_PasswordDialog == DialogResult.Ignore || dialogResult_PasswordDialog == DialogResult.Cancel)
                        {
                            return;
                        }

                        fileStream_YakSysXMLDB.Position = 22;

                        fileStream_YakSysXMLDB.Read(byteArray_StoredXMLDataHash, 0, byteArray_StoredXMLDataHash.Length);
                        fileStream_YakSysXMLDB.Read(byteArray_StoredHashOfPasswordHash, 0, byteArray_StoredHashOfPasswordHash.Length);

                        byteArray_ComputedPasswordHash = sHA256Managed_obj.ComputeHash(System.Text.Encoding.Default.GetBytes(ClientSettingsEnvironment.LocalSecurityPassword));
                        byteArray_ComputedHashOfPasswordHash = sHA256Managed_obj.ComputeHash(byteArray_ComputedPasswordHash);

                        if (CommonMethods.IsBytesArraysEquals(byteArray_ComputedHashOfPasswordHash, byteArray_StoredHashOfPasswordHash) == false)
                        {
                            MessageBox.Show(ClientStringFactory.GetString(541, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            if (fileStream_YakSysXMLDB != null) fileStream_YakSysXMLDB.Close();

                            if (memoryStream_XMLData != null) memoryStream_XMLData.Close();
                            if (memoryStream_UnprocessedXMLData != null) memoryStream_UnprocessedXMLData.Close();
                            if (memoryStream_DecryptedXMLData != null) memoryStream_DecryptedXMLData.Close();
                            if (memoryStream_EncryptedXMLData != null) memoryStream_EncryptedXMLData.Close();

                            if (sHA256Managed_obj != null) sHA256Managed_obj.Clear();
                            if (rijndaelManaged_obj != null) rijndaelManaged_obj.Clear();

                            if (cryptoStream_obj != null) cryptoStream_obj.Close();

                            LoadXMLDataFile(string_XMLFilePath, bool_UseDBImportMode);

                            return;
                        }

                        rijndaelManaged_obj.KeySize = 256;

                        rijndaelManaged_obj.Key = byteArray_ComputedPasswordHash;
                        rijndaelManaged_obj.IV = new byte[rijndaelManaged_obj.BlockSize / 8];

                        memoryStream_EncryptedXMLData = new MemoryStream(byteArray_UnprocessedXMLData);

                        cryptoStream_obj = new CryptoStream(memoryStream_EncryptedXMLData, rijndaelManaged_obj.CreateDecryptor(), CryptoStreamMode.Read);

                        while (true)
                        {
                            int int_Byte = cryptoStream_obj.ReadByte();

                            if (int_Byte == -1) break;

                            memoryStream_DecryptedXMLData.WriteByte((byte)int_Byte);
                        }

                        memoryStream_EncryptedXMLData.Close();

                        cryptoStream_obj.Flush();
                        cryptoStream_obj.Clear();
                        cryptoStream_obj.Close();

                        ClientSettingsEnvironment.EncryptSettingsDataBase = true;

                        memoryStream_XMLData = new MemoryStream(memoryStream_DecryptedXMLData.ToArray());

                        memoryStream_DecryptedXMLData.Close();

                        ClientSettingsEnvironment.EncryptSettingsDataBase = true;
                    }
                    else
                    {
                        ClientSettingsEnvironment.EncryptSettingsDataBase = false;
                    }

                    if (byte_IsSettingsDataBaseCompressed == 1)
                    {
                        byteArray_DecompressedXMLData = new YakSys.Compression.CommonEnvironment().Decompress(memoryStream_XMLData.ToArray(), false);

                        memoryStream_XMLData = new MemoryStream(byteArray_DecompressedXMLData);

                        ClientSettingsEnvironment.CompressSettingsDataBase = true;
                    }
                    else
                    {
                        ClientSettingsEnvironment.CompressSettingsDataBase = false;
                    }

                    fileStream_YakSysXMLDB.Close();

                    if (DBVersion == "YakSysClientDB090")
                    {
                        new YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter().RetriveCleintSettingsData(memoryStream_XMLData);

                        SyncIdentTables();
                    }

                    if (DBVersion == "YakSysClientDB110")
                    {
                        new YakSysRctClientV110XMLConfigImporter().RetriveClientSettingsData(memoryStream_XMLData);
                    }

                    memoryStream_XMLData.Close();
                }

                catch (Exception exception_obj)
                {

                }
                finally
                {
                    if (fileStream_YakSysXMLDB != null) fileStream_YakSysXMLDB.Close();

                    if (memoryStream_XMLData != null) memoryStream_XMLData.Close();
                    if (memoryStream_UnprocessedXMLData != null) memoryStream_UnprocessedXMLData.Close();
                    if (memoryStream_DecryptedXMLData != null) memoryStream_DecryptedXMLData.Close();
                    if (memoryStream_EncryptedXMLData != null) memoryStream_EncryptedXMLData.Close();

                    if (sHA256Managed_obj != null) sHA256Managed_obj.Clear();
                    if (rijndaelManaged_obj != null) rijndaelManaged_obj.Clear();

                    if (cryptoStream_obj != null) cryptoStream_obj.Close();
                }
            }

            public static void SyncIdentTables()
            {
                try
                {
                    if (DBVersion == "YakSysClientDB090")
                    {
                        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.ProxyServersSettings.Rows.Count; int_CycleCount++)
                        {
                            YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings.Rows.Add(YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.ProxyServersSettings.Rows[int_CycleCount].ItemArray);
                        }

                        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.MainSettings.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.MainSettings.Rows.Count; int_CycleCount++)
                        {
                            YakSysRctClientV110XMLConfigImporter.YakSysClientDB.MainSettings.Rows.Add(YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.MainSettings.Rows[int_CycleCount].ItemArray);
                        }

                        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.YakSysServers.Rows.Count; int_CycleCount++)
                        {
                            YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers.Rows.Add(YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.YakSysServers.Rows[int_CycleCount].ItemArray);
                        }

                        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows.Count; int_CycleCount++)
                        {
                            YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows.Add(YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows[int_CycleCount].ItemArray);
                        }

                        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServerUsers.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.YakSysServerUsers.Rows.Count; int_CycleCount++)
                        {
                            YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServerUsers.Rows.Add(YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.YakSysServerUsers.Rows[int_CycleCount].ItemArray);
                        }

                        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServerUserEMails.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.YakSysServerUserEMails.Rows.Count; int_CycleCount++)
                        {
                            YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServerUserEMails.Rows.Add(YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.YakSysServerUserEMails.Rows[int_CycleCount].ItemArray);
                        }

                        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ICQList.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.ICQList.Rows.Count; int_CycleCount++)
                        {
                            YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ICQList.Rows.Add(YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.ICQList.Rows[int_CycleCount].ItemArray);
                        }

                        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServerEMails.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.YakSysServerEMails.Rows.Count; int_CycleCount++)
                        {
                            YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServerEMails.Rows.Add(YakSysRctClient.Version090.YakSysRctClientV090XMLConfigImporter.YakSysClientDB.YakSysServerEMails.Rows[int_CycleCount].ItemArray);
                        }
                    }
                }
                catch (Exception exception_obj)
                {
                }
            }


            public ListViewItem[] GetYakSysServersGroups()
            {
                try
                {
                    if (YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows.Count < 0) return null;

                    DataRow dataRow_NewRecord = null;

                    YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ServerGroupTypesDataTable serverGroupTypesDataTableDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes;

                    ////////////////////////////////////////////////////////////////////////////////

                    ListViewItem[] listViewItemArray_YakSysServersGroups = new ListViewItem[serverGroupTypesDataTableDataTable_obj.Rows.Count];

                    string string_GroupName = string.Empty;

                    for (int int_CycleCount = 0; int_CycleCount != serverGroupTypesDataTableDataTable_obj.Rows.Count; int_CycleCount++)
                    {
                        dataRow_NewRecord = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows[int_CycleCount];

                        string_GroupName = (string)dataRow_NewRecord[serverGroupTypesDataTableDataTable_obj.GroupNameColumn];

                        listViewItemArray_YakSysServersGroups[int_CycleCount] = new ListViewItem(string_GroupName, 0);

                        listViewItemArray_YakSysServersGroups[int_CycleCount].Tag = int_CycleCount;
                    }

                    return listViewItemArray_YakSysServersGroups;
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("YakSysClientDB")) File.Delete("YakSysClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(490, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return null;
                }
            }

            public ListViewItem[] GetProxyServersList()
            {
                try
                {
                    if (YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings.Rows.Count < 2) return null;

                    DataRow dataRow_NewRecord = null;

                    YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ProxyServersSettingsDataTable proxyServersSettingsDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings;

                    ////////////////////////////////////////////////////////////////////////////////

                    ListViewItem[] listViewItemArray_ProxyServersList = new ListViewItem[proxyServersSettingsDataTable_obj.Rows.Count - 1];

                    if (listViewItemArray_ProxyServersList.Length < 1) return null;

                    string string_ProxyServerTitle, string_ProxyHost, string_ProxyPort;

                    for (int int_CycleCount = 0; int_CycleCount != listViewItemArray_ProxyServersList.Length; int_CycleCount++)
                    {
                        dataRow_NewRecord = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings.Rows[int_CycleCount + 1];

                        string_ProxyServerTitle = (string)dataRow_NewRecord[proxyServersSettingsDataTable_obj.ProxyServerTitleColumn];
                        string_ProxyHost = (string)dataRow_NewRecord[proxyServersSettingsDataTable_obj.ProxyHostColumn];
                        string_ProxyPort = (string)dataRow_NewRecord[proxyServersSettingsDataTable_obj.ProxyPortColumn].ToString();

                        listViewItemArray_ProxyServersList[int_CycleCount] = new ListViewItem(string_ProxyServerTitle, 0);

                        listViewItemArray_ProxyServersList[int_CycleCount].Tag = int_CycleCount;

                        listViewItemArray_ProxyServersList[int_CycleCount].SubItems.Add(string_ProxyHost);
                        listViewItemArray_ProxyServersList[int_CycleCount].SubItems.Add(string_ProxyPort);
                    }

                    return listViewItemArray_ProxyServersList;
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("YakSysClientDB")) File.Delete("YakSysClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(490, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return null;
                }
            }

            public ListViewItem[] GetYakSysServersList(int int_SelectedGroupID)
            {
                try
                {
                    if (YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows.Count < 0) return null;

                    YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersRow[] dataRowArray_YakSysServersRows = null;

                    YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersRow dataRow_CurrentYakSysServerRow = null;

                    YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ServerGroupTypesDataTable serverGroupTypesDataTableDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes;
                    YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersDataTable YakSysServersDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers;

                    ////////////////////////////////////////////////////////////////////////////////

                    dataRowArray_YakSysServersRows = (YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersRow[])YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows[int_SelectedGroupID].GetChildRows("ServerGroupTypes_YakSysServerInfo");

                    ListViewItem[] listViewItemArray_YakSysServersList = new ListViewItem[dataRowArray_YakSysServersRows.Length];

                    string string_ServerName = string.Empty, string_ServerHost = string.Empty, string_ServerPort = string.Empty,
                            string_ServerLocation = string.Empty, string_GroupName = string.Empty;

                    for (int int_CycleCount = 0; int_CycleCount != dataRowArray_YakSysServersRows.Length; int_CycleCount++)
                    {
                        dataRow_CurrentYakSysServerRow = (YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersRow)dataRowArray_YakSysServersRows[int_CycleCount];

                        string_ServerName = (string)dataRow_CurrentYakSysServerRow.ServerName;
                        string_ServerHost = (string)dataRow_CurrentYakSysServerRow.ServerHost;
                        string_ServerPort = (string)dataRow_CurrentYakSysServerRow.ServerPort.ToString();
                        string_ServerLocation = (string)dataRow_CurrentYakSysServerRow.ServerLocation;
                        string_GroupName = (string)serverGroupTypesDataTableDataTable_obj[int_SelectedGroupID][serverGroupTypesDataTableDataTable_obj.GroupNameColumn];

                        listViewItemArray_YakSysServersList[int_CycleCount] = new ListViewItem(string_ServerName, 0);

                        listViewItemArray_YakSysServersList[int_CycleCount].SubItems.Add(string_ServerHost);
                        listViewItemArray_YakSysServersList[int_CycleCount].SubItems.Add(string_ServerPort);
                        listViewItemArray_YakSysServersList[int_CycleCount].SubItems.Add(string_ServerLocation);
                        listViewItemArray_YakSysServersList[int_CycleCount].SubItems.Add(string_GroupName);
                    }

                    return listViewItemArray_YakSysServersList;
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("YakSysClientDB")) File.Delete("YakSysClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(490, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return null;
                }
            }

            public ListViewItem[] GetYakSysServersList()
            {
                try
                {
                    if (YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers.Rows.Count == 0) return null;

                    DataRow dataRow_NewRecord = null;

                    YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersDataTable YakSysServersDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers;

                    ////////////////////////////////////////////////////////////////////////////////

                    ListViewItem[] listViewItemArray_YakSysServersList = new ListViewItem[YakSysServersDataTable_obj.Rows.Count];

                    string string_ServerName = string.Empty, string_ServerHost = string.Empty, string_ServerPort = string.Empty,
                            string_ServerLocation = string.Empty, string_GroupName = string.Empty;

                    for (int int_CycleCount = 0; int_CycleCount != YakSysServersDataTable_obj.Rows.Count; int_CycleCount++)
                    {
                        dataRow_NewRecord = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers.Rows[int_CycleCount];

                        string_ServerName = (string)dataRow_NewRecord[YakSysServersDataTable_obj.ServerNameColumn];
                        string_ServerHost = (string)dataRow_NewRecord[YakSysServersDataTable_obj.ServerHostColumn];
                        string_ServerPort = (string)dataRow_NewRecord[YakSysServersDataTable_obj.ServerPortColumn].ToString();
                        string_ServerLocation = (string)dataRow_NewRecord[YakSysServersDataTable_obj.ServerLocationColumn];
                        string_GroupName = (string)((YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ServerGroupTypesRow)dataRow_NewRecord.GetParentRow("ServerGroupTypes_YakSysServerInfo")).GroupName;

                        listViewItemArray_YakSysServersList[int_CycleCount] = new ListViewItem(string_ServerName, 0);

                        listViewItemArray_YakSysServersList[int_CycleCount].SubItems.Add(string_ServerHost);
                        listViewItemArray_YakSysServersList[int_CycleCount].SubItems.Add(string_ServerPort);
                        listViewItemArray_YakSysServersList[int_CycleCount].SubItems.Add(string_ServerLocation);
                        listViewItemArray_YakSysServersList[int_CycleCount].SubItems.Add(string_GroupName);

                        listViewItemArray_YakSysServersList[int_CycleCount].Tag = int_CycleCount;
                    }

                    return listViewItemArray_YakSysServersList;
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("YakSysClientDB")) File.Delete("YakSysClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(490, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return null;
                }
            }


            public string[] GetServersGroupsItems()
            {
                try
                {
                    if (YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows.Count == 0) return null;

                    YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ServerGroupTypesDataTable serverGroupTypesDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes;

                    ////////////////////////////////////////////////////////////////////////////////

                    string[] stringArray_ServersGroupsNames = new string[YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows.Count];

                    for (int int_CycleCount = 0; int_CycleCount != serverGroupTypesDataTable_obj.Rows.Count; int_CycleCount++)
                    {
                        stringArray_ServersGroupsNames[int_CycleCount] = (string)YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows[int_CycleCount][serverGroupTypesDataTable_obj.GroupNameColumn];
                    }

                    return stringArray_ServersGroupsNames;
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("YakSysClientDB")) File.Delete("YakSysClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(490, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return null;
                }
            }

            public void ClearYakSysServersDataBase()
            {
                YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers.Rows.Clear();
            }


            public void RemoveYakSysServersDataBaseRow(int int_RowIndex)
            {
                YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveProxyServerRecord(int int_RecordIndex)
            {
                YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersRow[] YakSysServersRowArray_ProxyChilds = null;

                YakSysServersRowArray_ProxyChilds = (YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersRow[])YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings.Rows[int_RecordIndex].GetChildRows("ProxyServersSettings_YakSysServersList");

                foreach (YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersRow YakSysServersRow_Current in YakSysServersRowArray_ProxyChilds)
                {
                    YakSysServersRow_Current.ProxyServerID = 0;
                    YakSysServersRow_Current.UseProxyServer = false;
                }

                YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings.Rows.RemoveAt(int_RecordIndex);
            }


            public void DeleteAllLogins()
            {
                YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.MainSettingsDataTable mainSettingsDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.MainSettings;

                YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ProxyServersSettingsDataTable proxyServersSettingsDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings;

                YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersDataTable YakSysServersDataTableDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers;


                mainSettingsDataTable_obj[0][mainSettingsDataTable_obj.ServerLoginColumn] = String.Empty;

                for (int int_CycleCount = 0; int_CycleCount != proxyServersSettingsDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    proxyServersSettingsDataTable_obj[int_CycleCount][proxyServersSettingsDataTable_obj.LoginColumn] = String.Empty;
                }

                for (int int_CycleCount = 0; int_CycleCount != YakSysServersDataTableDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    YakSysServersDataTableDataTable_obj[int_CycleCount][YakSysServersDataTableDataTable_obj.LoginColumn] = String.Empty;
                }
            }

            public void DeleteAllPasswords()
            {
                YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.MainSettingsDataTable mainSettingsDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.MainSettings;

                YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ProxyServersSettingsDataTable proxyServersSettingsDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings;

                YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersDataTable YakSysServersDataTableDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers;

                mainSettingsDataTable_obj[0][mainSettingsDataTable_obj.ServerPasswordColumn] = String.Empty;

                for (int int_CycleCount = 0; int_CycleCount != proxyServersSettingsDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    proxyServersSettingsDataTable_obj[int_CycleCount][proxyServersSettingsDataTable_obj.PasswordColumn] = String.Empty;
                }

                for (int int_CycleCount = 0; int_CycleCount != YakSysServersDataTableDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    YakSysServersDataTableDataTable_obj[int_CycleCount][YakSysServersDataTableDataTable_obj.PasswordColumn] = String.Empty;
                }
            }
        }
        
        






















        namespace YakSysRctClient
        {
            namespace Version090
            {
                public class YakSysRctClientV090XMLConfigImporter
                {
                    static YakSysRct_Xml_Config_Importer.Client_DataSet_ver_090.DataSet_YakSysClientDB dataSet_YakSysClientDB = new YakSysRct_Xml_Config_Importer.Client_DataSet_ver_090.DataSet_YakSysClientDB();

                    public static YakSysRct_Xml_Config_Importer.Client_DataSet_ver_090.DataSet_YakSysClientDB YakSysClientDB
                    {
                        get
                        {
                            return dataSet_YakSysClientDB;
                        }

                        set
                        {
                            dataSet_YakSysClientDB = value;
                        }
                    }

                    public void ApplyDBSettings()
                    {
                        if (YakSysClientDB.Tables["MainSettings"].Rows.Count < 1) throw (new Exception());

                        if (YakSysClientDB.Tables["MainSettings"].Rows.Count < 1) return;

                        YakSysRct_Xml_Config_Importer.Client_DataSet_ver_090.DataSet_YakSysClientDB.MainSettingsDataTable mainSettingsDataTable_obj = YakSysClientDB.MainSettings;

                        YakSysRct_Xml_Config_Importer.Client_DataSet_ver_090.DataSet_YakSysClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = YakSysClientDB.ProxyServersSettings;


                        ClientSettingsEnvironment.AppVersion = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.AppVersionColumn];

                        ClientSettingsEnvironment.ToEncryptSentFiles = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToEncryptSentFilesColumn];
                        ClientSettingsEnvironment.ToEncryptSentSystemData = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToEncryptSentSystemDataColumn];
                        ClientSettingsEnvironment.ToEncryptDownloadedFiles = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToEncryptDownloadedFilesColumn];
                        ClientSettingsEnvironment.ToEncryptReceivedSystemData = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToEncryptReceivedSystemDataColumn];
                        ClientSettingsEnvironment.ToEncryptReceivedScreenshots = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToEncryptReceivedScreenshotsColumn];

                        ClientSettingsEnvironment.ToCompressSentFiles = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToCompressSentFilesColumn];
                        ClientSettingsEnvironment.ToCompressSentSystemData = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToCompressSentSystemDataColumn];
                        ClientSettingsEnvironment.ToCompressDownloadedFiles = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToCompressDownloadedFilesColumn];
                        ClientSettingsEnvironment.ToCompressReceivedSystemData = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToCompressReceivedSystemDataColumn];
                        ClientSettingsEnvironment.ToCompressReceivedScreenshots = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToCompressReceivedScreenshotsColumn];

                        ClientSettingsEnvironment.ShowToolTips = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowToolTipsColumn];
                        ClientSettingsEnvironment.ShowAdvancedSettings = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowAdvancedSettingsColumn];
                        ClientSettingsEnvironment.UseProxyServer = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.UseProxyServerColumn];


                        ClientSettingsEnvironment.DownloadedFilesPath = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.DownloadedFilesPathColumn];
                        ClientSettingsEnvironment.DownloadedScreenShotsPath = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.DownloadedScreenShotsPathColumn];


                        ClientSettingsEnvironment.ServerPort = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerPortColumn];
                        ClientSettingsEnvironment.ServerHost = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerHostColumn];

                        ClientSettingsEnvironment.LoginForConnection = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerLoginColumn];
                        ClientSettingsEnvironment.PasswordForConnection = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerPasswordColumn];

                        ClientSettingsEnvironment.SentFilesEncryptAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.SentFilesEncryptAlgorithmIndexColumn];
                        ClientSettingsEnvironment.SendingSystemDataEncryptAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.SendingSystemDataEncryptAlgorithmIndexColumn];
                        ClientSettingsEnvironment.ReceivedSystemDataEncryptAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ReceivedSystemDataEncryptAlgorithmIndexColumn];
                        ClientSettingsEnvironment.ReceivedScreenshotsEncryptAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ReceivedScreenshotsEncryptAlgorithmIndexColumn];
                        ClientSettingsEnvironment.DownloadedFilesEncryptAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.DownloadedFilesEncryptAlgorithmIndexColumn];

                        ClientSettingsEnvironment.SentFilesCompressAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.SentFilesCompressAlgorithmIndexColumn];
                        ClientSettingsEnvironment.SendingSystemDataCompressAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.SendingSystemDataCompressAlgorithmIndexColumn];
                        ClientSettingsEnvironment.ReceivedSystemDataCompressAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ReceivedSystemDataCompressAlgorithmIndexColumn];
                        ClientSettingsEnvironment.ReceivedScreenshotsCompressAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ReceivedScreenshotsCompressAlgorithmIndexColumn];
                        ClientSettingsEnvironment.DownloadedFilesCompressAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.DownloadedFilesCompressAlgorithmIndexColumn];

                        ClientSettingsEnvironment.RememberLogins = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.RememberLoginsColumn];
                        ClientSettingsEnvironment.RememberPasswords = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.RememberPasswordsColumn];



                        ClientSettingsEnvironment.CurrentLanguage = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.CurrentAppLanguageColumn];


                        ClientSettingsEnvironment.ProxyServerHost = (string)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.ProxyHostColumn];
                        ClientSettingsEnvironment.ProxyServerPort = (int)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.ProxyPortColumn];

                        ClientSettingsEnvironment.ProxyServerTimeOut = (int)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn];
                        ClientSettingsEnvironment.ProxyServerType = (int)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.ProxyTypeColumn];

                        ClientSettingsEnvironment.UseProxyToResolveHostNames = (bool)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn];

                        ClientSettingsEnvironment.UseProxyAuthentication = (bool)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.UseAuthenticationColumn];
                        ClientSettingsEnvironment.ProxyLogin = (string)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.LoginColumn];
                        ClientSettingsEnvironment.ProxyPassword = (string)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.PasswordColumn];
                    }

                    public void RetriveCleintSettingsData(MemoryStream memoryStream_XMLData)
                    {
                        try
                        {
                            YakSysRctClientV090XMLConfigImporter.YakSysClientDB.Clear();

                            YakSysRctClientV090XMLConfigImporter.YakSysClientDB.ReadXml(memoryStream_XMLData);

                            ApplyDBSettings();
                        }

                        catch (Exception exception_obj)
                        {
                            new YakSysRctClientV110XMLConfigImporter().RetriveClientSettingsData(memoryStream_XMLData);
                        }
                    }
                }
            }

            namespace Version110
            {
                public class YakSysRctClientV110XMLConfigImporter
                {
                    static YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB dataSet_YakSysClientDB = new YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB();

                    public static YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB YakSysClientDB
                    {
                        get
                        {
                            return dataSet_YakSysClientDB;
                        }

                        set
                        {
                            dataSet_YakSysClientDB = value;
                        }
                    }

                    public void ApplyDBSettings()
                    {
                        if (YakSysClientDB.Tables["MainSettings"].Rows.Count < 1) throw (new Exception());

                        if (YakSysClientDB.Tables["MainSettings"].Rows.Count < 1) return;

                        YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.MainSettingsDataTable mainSettingsDataTable_obj = YakSysClientDB.MainSettings;

                        YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = YakSysClientDB.ProxyServersSettings;
                        
                        ClientSettingsEnvironment.AppVersion = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.AppVersionColumn];

                        ClientSettingsEnvironment.ToEncryptSentFiles = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToEncryptSentFilesColumn];
                        ClientSettingsEnvironment.ToEncryptSentSystemData = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToEncryptSentSystemDataColumn];
                        ClientSettingsEnvironment.ToEncryptDownloadedFiles = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToEncryptDownloadedFilesColumn];
                        ClientSettingsEnvironment.ToEncryptReceivedSystemData = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToEncryptReceivedSystemDataColumn];
                        ClientSettingsEnvironment.ToEncryptReceivedScreenshots = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToEncryptReceivedScreenshotsColumn];

                        ClientSettingsEnvironment.ToCompressSentFiles = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToCompressSentFilesColumn];
                        ClientSettingsEnvironment.ToCompressSentSystemData = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToCompressSentSystemDataColumn];
                        ClientSettingsEnvironment.ToCompressDownloadedFiles = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToCompressDownloadedFilesColumn];
                        ClientSettingsEnvironment.ToCompressReceivedSystemData = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToCompressReceivedSystemDataColumn];
                        ClientSettingsEnvironment.ToCompressReceivedScreenshots = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ToCompressReceivedScreenshotsColumn];

                        ClientSettingsEnvironment.ShowToolTips = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowToolTipsColumn];
                        ClientSettingsEnvironment.ShowAdvancedSettings = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowAdvancedSettingsColumn];
                        ClientSettingsEnvironment.UseProxyServer = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.UseProxyServerColumn];


                        ClientSettingsEnvironment.DownloadedFilesPath = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.DownloadedFilesPathColumn];
                        ClientSettingsEnvironment.DownloadedScreenShotsPath = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.DownloadedScreenShotsPathColumn];


                        ClientSettingsEnvironment.ServerPort = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerPortColumn];
                        ClientSettingsEnvironment.ServerHost = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerHostColumn];

                        ClientSettingsEnvironment.LoginForConnection = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerLoginColumn];
                        ClientSettingsEnvironment.PasswordForConnection = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerPasswordColumn];

                        ClientSettingsEnvironment.SentFilesEncryptAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.SentFilesEncryptAlgorithmIndexColumn];
                        ClientSettingsEnvironment.SendingSystemDataEncryptAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.SendingSystemDataEncryptAlgorithmIndexColumn];
                        ClientSettingsEnvironment.ReceivedSystemDataEncryptAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ReceivedSystemDataEncryptAlgorithmIndexColumn];
                        ClientSettingsEnvironment.ReceivedScreenshotsEncryptAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ReceivedScreenshotsEncryptAlgorithmIndexColumn];
                        ClientSettingsEnvironment.DownloadedFilesEncryptAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.DownloadedFilesEncryptAlgorithmIndexColumn];

                        ClientSettingsEnvironment.SentFilesCompressAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.SentFilesCompressAlgorithmIndexColumn];
                        ClientSettingsEnvironment.SendingSystemDataCompressAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.SendingSystemDataCompressAlgorithmIndexColumn];
                        ClientSettingsEnvironment.ReceivedSystemDataCompressAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ReceivedSystemDataCompressAlgorithmIndexColumn];
                        ClientSettingsEnvironment.ReceivedScreenshotsCompressAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ReceivedScreenshotsCompressAlgorithmIndexColumn];
                        ClientSettingsEnvironment.DownloadedFilesCompressAlgorithmIndex = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.DownloadedFilesCompressAlgorithmIndexColumn];

                        ClientSettingsEnvironment.RememberLogins = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.RememberLoginsColumn];
                        ClientSettingsEnvironment.RememberPasswords = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.RememberPasswordsColumn];
                        

                        ClientSettingsEnvironment.CurrentLanguage = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.CurrentAppLanguageColumn];


                        ClientSettingsEnvironment.ProxyServerHost = (string)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.ProxyHostColumn];
                        ClientSettingsEnvironment.ProxyServerPort = (int)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.ProxyPortColumn];

                        ClientSettingsEnvironment.ProxyServerTimeOut = (int)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn];
                        ClientSettingsEnvironment.ProxyServerType = (int)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.ProxyTypeColumn];

                        ClientSettingsEnvironment.UseProxyToResolveHostNames = (bool)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn];

                        ClientSettingsEnvironment.UseProxyAuthentication = (bool)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.UseAuthenticationColumn];
                        ClientSettingsEnvironment.ProxyLogin = (string)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.LoginColumn];
                        ClientSettingsEnvironment.ProxyPassword = (string)ProxyServersSettingsDataTable_obj.Rows[0][ProxyServersSettingsDataTable_obj.PasswordColumn];

                        try
                        {

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_ProxySettingsDataTable cSPForm_ProxySettingsDataTable_obj = YakSysClientDB.CSPForm_ProxySettings;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = YakSysClientDB.CSPForm_ServerAuthentication;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = YakSysClientDB.CSPForm_UINAccountStateSettings;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_CSPServersListDataTable cSPForm_CSPServersListDataTable_obj = YakSysClientDB.CSPForm_CSPServersList;
                            

                            ClientSettingsEnvironment.CSP_CSPServersList_Password = (string)cSPForm_CSPServersListDataTable_obj.Rows[0][cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_PasswordColumn];
                            ClientSettingsEnvironment.CSP_CSPServersList_UIN = (string)cSPForm_CSPServersListDataTable_obj.Rows[0][cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UINColumn];
                            ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServiceIPAddress = (string)cSPForm_CSPServersListDataTable_obj.Rows[0][cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServiceIPAddressColumn];
                            ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServicePort = (int)cSPForm_CSPServersListDataTable_obj.Rows[0][cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServicePortColumn];
                            ClientSettingsEnvironment.CSP_CSPServersList_UseYakSysCSPServer = (bool)cSPForm_CSPServersListDataTable_obj.Rows[0][cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UseYakSysCSPServerColumn];

                            ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort = (int)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_YakSysRctLogin = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_YakSysRctLoginColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_YakSysRctPassword = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_YakSysRctPasswordColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_CSPServerUIN = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPServerUINColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_UseYakSysCSPServer = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseYakSysCSPServerColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_WaitForServer = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_WaitForServerColumn];

                            ClientSettingsEnvironment.CSP_ProxySettings_Authentication = (bool)cSPForm_ProxySettingsDataTable_obj.Rows[0][cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_UseAuthenticationColumn];
                            ClientSettingsEnvironment.CSP_ProxySettings_ResolveHostNames = (bool)cSPForm_ProxySettingsDataTable_obj.Rows[0][cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ResolveHostNamesColumn];
                            ClientSettingsEnvironment.CSP_ProxySettings_UseProxy = (bool)cSPForm_ProxySettingsDataTable_obj.Rows[0][cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_UseProxyColumn];
                            ClientSettingsEnvironment.CSP_ProxySettings_ProxyHost = (string)cSPForm_ProxySettingsDataTable_obj.Rows[0][cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyHostColumn];
                            ClientSettingsEnvironment.CSP_ProxySettings_ProxyPort = (int)cSPForm_ProxySettingsDataTable_obj.Rows[0][cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyPortColumn];
                            ClientSettingsEnvironment.CSP_ProxySettings_Socks5UserName = (string)cSPForm_ProxySettingsDataTable_obj.Rows[0][cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_Socks5UserNameColumn];
                            ClientSettingsEnvironment.CSP_ProxySettings_Socks5Password = (string)cSPForm_ProxySettingsDataTable_obj.Rows[0][cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_Socks5PasswordColumn];
                            ClientSettingsEnvironment.CSP_ProxySettings_ProxyTimeOutIndex = (int)cSPForm_ProxySettingsDataTable_obj.Rows[0][cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyTimeOutIndexColumn];
                            ClientSettingsEnvironment.CSP_ProxySettings_ProxyTypeIndex = (int)cSPForm_ProxySettingsDataTable_obj.Rows[0][cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyTypeIndexColumn];

                            ClientSettingsEnvironment.CSP_ChangeUINAccountState_GetActivationCode = (bool)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_GetActivationCodeColumn];
                            ClientSettingsEnvironment.CSP_ChangeUINAccountState_UseYakSysCSPServer = (bool)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseYakSysCSPServerColumn];
                            ClientSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServiceIPAddress = (string)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServiceIPAddressColumn];
                            ClientSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServicePort = (int)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServicePortColumn];
                            ClientSettingsEnvironment.CSP_ChangeUINAccountState_UIN = (string)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINColumn];
                            ClientSettingsEnvironment.CSP_ChangeUINAccountState_Password = (string)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_PasswordColumn];
                            ClientSettingsEnvironment.CSP_ChangeUINAccountState_UINActivationCode = (string)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINActivationCodeColumn];
                            ClientSettingsEnvironment.CSP_ChangeUINAccountState_NewAccountStateIndex = (int)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_NewAccountStateIndexColumn];

                        }
                        catch (Exception ex)
                        {
                            InitCSPSettingsXmlDB();
                        }
                    }

                    public void InitProxyServersSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = YakSysClientDB.ProxyServersSettings;

                            YakSysClientDB.ProxyServersSettings.Rows.Clear();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysClientDB.ProxyServersSettings.NewRow();

                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.IDColumn] = 0;

                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyHostColumn] = String.Empty;
                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyPortColumn] = 1080;
                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn] = 5000;
                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyTypeColumn] = 1;
                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn] = false;
                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyServerTitleColumn] = String.Empty;
                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyServerLocationColumn] = String.Empty;
                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyServerDescriptionColumn] = String.Empty;

                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.UseAuthenticationColumn] = false;
                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.LoginColumn] = String.Empty;
                            dataRow_NewRecord[ProxyServersSettingsDataTable_obj.PasswordColumn] = String.Empty;

                            YakSysClientDB.ProxyServersSettings.Rows.Add(dataRow_NewRecord);

                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("YakSysClientDB")) File.Delete("YakSysClientDB");

                            MessageBox.Show(ClientStringFactory.GetString(480, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                    public void InitMainClientSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.MainSettingsDataTable mainSettingsDataTable_obj = YakSysClientDB.MainSettings;

                            dataRow_NewRecord = YakSysClientDB.MainSettings.NewRow();

                            dataRow_NewRecord[mainSettingsDataTable_obj.IDColumn] = 0;

                            dataRow_NewRecord[mainSettingsDataTable_obj.AppVersionColumn] = "1.1.0";

                            dataRow_NewRecord[mainSettingsDataTable_obj.ToEncryptSentFilesColumn] = true;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ToEncryptSentSystemDataColumn] = true;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ToEncryptReceivedScreenshotsColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ToEncryptDownloadedFilesColumn] = true;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ToEncryptReceivedSystemDataColumn] = true;

                            dataRow_NewRecord[mainSettingsDataTable_obj.ToCompressSentFilesColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ToCompressSentSystemDataColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ToCompressReceivedScreenshotsColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ToCompressDownloadedFilesColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ToCompressReceivedSystemDataColumn] = false;

                            dataRow_NewRecord[mainSettingsDataTable_obj.UseProxyServerColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ShowToolTipsColumn] = true;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ShowAdvancedSettingsColumn] = false;

                            dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedFilesPathColumn] = "C:\\YakSys\\downloads\\files\\";
                            dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedScreenShotsPathColumn] = "C:\\YakSys\\downloads\\images\\";

                            dataRow_NewRecord[mainSettingsDataTable_obj.ProxyServerIDColumn] = 0;

                            dataRow_NewRecord[mainSettingsDataTable_obj.CurrentAppLanguageColumn] = ClientSettingsEnvironment.CurrentLanguage;

                            dataRow_NewRecord[mainSettingsDataTable_obj.ServerHostColumn] = "localhost";
                            dataRow_NewRecord[mainSettingsDataTable_obj.ServerPortColumn] = 5544;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ServerLoginColumn] = String.Empty;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ServerPasswordColumn] = String.Empty;

                            /*
                                0 - AES 128 bit
                                1 - AES 256 bit
                                2 - DES 64 bit
                                3 - RC2 40 bit
                                4 - RC2 128 bit
                                5 - TripleDES 128 bit
                                6 - TripleDES 192 bit
                            */

                            dataRow_NewRecord[mainSettingsDataTable_obj.SentFilesEncryptAlgorithmIndexColumn] = 1;
                            dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedFilesEncryptAlgorithmIndexColumn] = 1;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedScreenshotsEncryptAlgorithmIndexColumn] = 0;
                            dataRow_NewRecord[mainSettingsDataTable_obj.SendingSystemDataEncryptAlgorithmIndexColumn] = 1;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedSystemDataEncryptAlgorithmIndexColumn] = 1;


                            /*
                                0 - Adaptive Prefix codes
                                1 - Non-Adaptive Prefix codes
                                2 - LZSS
                                3 - RLE
                            */

                            dataRow_NewRecord[mainSettingsDataTable_obj.SentFilesCompressAlgorithmIndexColumn] = 3;
                            dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedFilesCompressAlgorithmIndexColumn] = 3;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedScreenshotsCompressAlgorithmIndexColumn] = 3;
                            dataRow_NewRecord[mainSettingsDataTable_obj.SendingSystemDataCompressAlgorithmIndexColumn] = 0;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedSystemDataCompressAlgorithmIndexColumn] = 3;

                            dataRow_NewRecord[mainSettingsDataTable_obj.RememberLoginsColumn] = ClientSettingsEnvironment.RememberLogins;
                            dataRow_NewRecord[mainSettingsDataTable_obj.RememberPasswordsColumn] = ClientSettingsEnvironment.RememberPasswords;

                            YakSysClientDB.MainSettings.Rows.Add(dataRow_NewRecord);

                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("YakSysClientDB")) File.Delete("YakSysClientDB");

                            MessageBox.Show(ClientStringFactory.GetString(480, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                    public void InitCSPSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_ProxySettingsDataTable cSPForm_ProxySettingsDataTable_obj = YakSysClientDB.CSPForm_ProxySettings;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = YakSysClientDB.CSPForm_ServerAuthentication;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = YakSysClientDB.CSPForm_UINAccountStateSettings;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_CSPServersListDataTable cSPForm_CSPServersListDataTable_obj = YakSysClientDB.CSPForm_CSPServersList;

                            YakSysClientDB.CSPForm_ProxySettings.Rows.Clear();
                            YakSysClientDB.CSPForm_ServerAuthentication.Rows.Clear();
                            YakSysClientDB.CSPForm_UINAccountStateSettings.Rows.Clear();
                            YakSysClientDB.CSPForm_CSPServersList.Rows.Clear();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysClientDB.CSPForm_ProxySettings.NewRow();

                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_UseAuthenticationColumn] = true;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ResolveHostNamesColumn] = true;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_UseProxyColumn] = true;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyHostColumn] = "";
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyPortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_Socks5UserNameColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_Socks5PasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyTimeOutIndexColumn] = 0;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyTypeIndexColumn] = 0;

                            YakSysClientDB.CSPForm_ProxySettings.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysClientDB.CSPForm_CSPServersList.NewRow();

                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_PasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServiceIPAddressColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServicePortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UseYakSysCSPServerColumn] = true;

                            YakSysClientDB.CSPForm_CSPServersList.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysClientDB.CSPForm_UINAccountStateSettings.NewRow();

                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_GetActivationCodeColumn] = true;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseYakSysCSPServerColumn] = true;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServiceIPAddressColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServicePortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_PasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINActivationCodeColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_NewAccountStateIndexColumn] = 0;

                            YakSysClientDB.CSPForm_UINAccountStateSettings.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysClientDB.CSPForm_ServerAuthentication.NewRow();

                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_YakSysRctLoginColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_YakSysRctPasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPServerUINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseYakSysCSPServerColumn] = true;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_WaitForServerColumn] = true;
                            
                            YakSysClientDB.CSPForm_ServerAuthentication.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();
                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("YakSysClientDB")) File.Delete("YakSysClientDB");

                            MessageBox.Show(ClientStringFactory.GetString(480, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }
                    public void SaveCSPSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_ProxySettingsDataTable cSPForm_ProxySettingsDataTable_obj = YakSysClientDB.CSPForm_ProxySettings;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = YakSysClientDB.CSPForm_ServerAuthentication;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = YakSysClientDB.CSPForm_UINAccountStateSettings;

                            YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.CSPForm_CSPServersListDataTable cSPForm_CSPServersListDataTable_obj = YakSysClientDB.CSPForm_CSPServersList;

                            YakSysClientDB.CSPForm_ProxySettings.Rows.Clear();
                            YakSysClientDB.CSPForm_ServerAuthentication.Rows.Clear();
                            YakSysClientDB.CSPForm_UINAccountStateSettings.Rows.Clear();
                            YakSysClientDB.CSPForm_CSPServersList.Rows.Clear();

                  
                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysClientDB.CSPForm_ServerAuthentication.NewRow();

                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn] = ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn] = ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn] = ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn] = ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_YakSysRctLoginColumn] = ClientSettingsEnvironment.CSP_ServerAuth_YakSysRctLogin;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_YakSysRctPasswordColumn] = ClientSettingsEnvironment.CSP_ServerAuth_YakSysRctPassword;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPServerUINColumn] = ClientSettingsEnvironment.CSP_ServerAuth_CSPServerUIN;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseYakSysCSPServerColumn] = ClientSettingsEnvironment.CSP_ServerAuth_UseYakSysCSPServer;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_WaitForServerColumn] = ClientSettingsEnvironment.CSP_ServerAuth_WaitForServer;

                            YakSysClientDB.CSPForm_ServerAuthentication.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysClientDB.CSPForm_ProxySettings.NewRow();

                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_UseAuthenticationColumn] = ClientSettingsEnvironment.CSP_ProxySettings_Authentication;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ResolveHostNamesColumn] = ClientSettingsEnvironment.CSP_ProxySettings_ResolveHostNames;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_UseProxyColumn] = ClientSettingsEnvironment.CSP_ProxySettings_UseProxy;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyHostColumn] = ClientSettingsEnvironment.CSP_ProxySettings_ProxyHost;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyPortColumn] = ClientSettingsEnvironment.CSP_ProxySettings_ProxyPort;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_Socks5UserNameColumn] = ClientSettingsEnvironment.CSP_ProxySettings_Socks5UserName;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_Socks5PasswordColumn] = ClientSettingsEnvironment.CSP_ProxySettings_Socks5Password;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyTimeOutIndexColumn] = ClientSettingsEnvironment.CSP_ProxySettings_ProxyTimeOutIndex;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyTypeIndexColumn] = ClientSettingsEnvironment.CSP_ProxySettings_ProxyTypeIndex;

                            YakSysClientDB.CSPForm_ProxySettings.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysClientDB.CSPForm_CSPServersList.NewRow();

                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_PasswordColumn] = ClientSettingsEnvironment.CSP_CSPServersList_Password;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UINColumn] = ClientSettingsEnvironment.CSP_CSPServersList_UIN;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServiceIPAddressColumn] = ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServiceIPAddress;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServicePortColumn] = ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServicePort;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UseYakSysCSPServerColumn] = ClientSettingsEnvironment.CSP_CSPServersList_UseYakSysCSPServer;

                            YakSysClientDB.CSPForm_CSPServersList.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysClientDB.CSPForm_UINAccountStateSettings.NewRow();

                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_GetActivationCodeColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_GetActivationCode;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseYakSysCSPServerColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_UseYakSysCSPServer;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServiceIPAddressColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServiceIPAddress;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServicePortColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServicePort;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_UIN;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_PasswordColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_Password;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINActivationCodeColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_UINActivationCode;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_NewAccountStateIndexColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_NewAccountStateIndex;

                            YakSysClientDB.CSPForm_UINAccountStateSettings.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();
           
                        }
                        catch (Exception exception_obj)
                        {
                            return;
                        }
                    }

                    public void RetriveClientSettingsData(MemoryStream memoryStream_XMLData)
                    {
                        try
                        {
                            YakSysClientDB.Clear();

                            YakSysClientDB.ReadXml(memoryStream_XMLData);
                        }
                        catch (Exception exception_obj)
                        {
                            YakSysClientDB.Clear();

                            InitProxyServersSettingsXmlDB();
                            InitMainClientSettingsXmlDB();
                            InitCSPSettingsXmlDB();

                            MessageBox.Show(ClientStringFactory.GetString(480, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                            return;
                        }

                        try
                        {
                            ApplyDBSettings();
                        }
                        catch (Exception exception_obj)
                        {
                            MessageBox.Show(ClientStringFactory.GetString(490, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));
                        }
                    }
                }
            }
        }

        namespace YakSysRctServer
        {
            namespace Version090
            {
                public class YakSysRctServerV090XMLConfigImporter
                {
                    static YakSysRct_Xml_Config_Importer.Server_DataSet_ver_090.DataSet_YakSysServerDB dataSet_YakSysServerDB = new YakSysRct_Xml_Config_Importer.Server_DataSet_ver_090.DataSet_YakSysServerDB();
             
                    public static YakSysRct_Xml_Config_Importer.Server_DataSet_ver_090.DataSet_YakSysServerDB YakSysServerDB
                    {
                        get
                        {
                            return dataSet_YakSysServerDB;
                        }

                        set
                        {
                            dataSet_YakSysServerDB = value;
                        }
                    }

                    public void ApplyDBSettings()
                    {
                        if (dataSet_YakSysServerDB.Tables["MainSettings"].Rows.Count < 1) throw (new Exception());

                        if (dataSet_YakSysServerDB.Tables["MainSettings"].Rows.Count < 1) return;

                        YakSysRct_Xml_Config_Importer.Server_DataSet_ver_090.DataSet_YakSysServerDB.MainSettingsDataTable mainSettingsDataTable_obj = dataSet_YakSysServerDB.MainSettings;

                        ServerSettingsEnvironment.ServerPort = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerPortColumn];

                        ServerSettingsEnvironment.AppVersion = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.AppVersionColumn];

                        ServerSettingsEnvironment.ShowToolTips = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowToolTipsColumn];
                        ServerSettingsEnvironment.ShowAdvancedSettings = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowAdvancedSettingsColumn];

                        ServerSettingsEnvironment.AutoRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.AutoRunColumn];
                        ServerSettingsEnvironment.StartServerAtRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.StartServerAtRunColumn];
                        ServerSettingsEnvironment.MinimizeToNotifyAreaAtRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.MinimizeToNotifyAreaAtRunColumn];
                        ServerSettingsEnvironment.ShowIconInNotifyArea = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowIconInNotifyAreaColumn];

                        ServerSettingsEnvironment.MaxConnections = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.MaxConnectionsColumn];

                        ServerSettingsEnvironment.MaxConnectionsPerAccount = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.MaxConnectionPerAccountColumn];

                        ServerSettingsEnvironment.EnableAccessRestrictionRules = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.EnableAccessRestrictionsColumn];

                        ServerSettingsEnvironment.ActivateHiddenModeAtStartUp = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ActivateHiddenModeAtStartUpColumn];

                        ServerSettingsEnvironment.CurrentLanguage = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.CurrentAppLanguageColumn];
                    }

                    public void RetriveServerSettingsData(MemoryStream memoryStream_XMLData)
                    {
                        try
                        {
                            YakSysRctServerV090XMLConfigImporter.YakSysServerDB.Clear();

                            YakSysRctServerV090XMLConfigImporter.YakSysServerDB.ReadXml(memoryStream_XMLData);

                            ApplyDBSettings();
                        }

                        catch (Exception exception_obj)
                        {
                            new YakSysRctServerV110XMLConfigImporter().RetriveServerSettingsData(memoryStream_XMLData);
                        }
                    }
                }
            }

            namespace Version110
            {
                public class YakSysRctServerV110XMLConfigImporter : MarshalByRefObject
                {
                    static YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB dataSet_YakSysServerDB = new YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB();

                    public static YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB YakSysServerDB
                    {
                        get
                        {
                            return dataSet_YakSysServerDB;
                        }

                        set
                        {
                            dataSet_YakSysServerDB = value;
                        }
                    }

                    public YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB RemotingWrapper_YakSysServerDB
                    {
                        get
                        {
                            return YakSysRctServerV110XMLConfigImporter.YakSysServerDB;
                        }

                        set
                        {
                            YakSysRctServerV110XMLConfigImporter.YakSysServerDB = value;
                        }
                    }

                    public void ApplyDBSettings()
                    {
                        if (dataSet_YakSysServerDB.Tables["MainSettings"].Rows.Count < 1) InitMainServerSettingsXmlDB();

                        if (dataSet_YakSysServerDB.Tables["MainSettings"].Rows.Count < 1) return;

                        YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.MainSettingsDataTable mainSettingsDataTable_obj = dataSet_YakSysServerDB.MainSettings;

                        ServerSettingsEnvironment.ServerPort = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerPortColumn];

                        ServerSettingsEnvironment.AppVersion = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.AppVersionColumn];

                        ServerSettingsEnvironment.ShowToolTips = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowToolTipsColumn];
                        ServerSettingsEnvironment.ShowAdvancedSettings = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowAdvancedSettingsColumn];

                        ServerSettingsEnvironment.AutoRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.AutoRunColumn];
                        ServerSettingsEnvironment.StartServerAtRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.StartServerAtRunColumn];
                        ServerSettingsEnvironment.MinimizeToNotifyAreaAtRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.MinimizeToNotifyAreaAtRunColumn];
                        ServerSettingsEnvironment.ShowIconInNotifyArea = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowIconInNotifyAreaColumn];

                        ServerSettingsEnvironment.ActivateHiddenModeAtStartUp = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ActivateHiddenModeAtStartUpColumn];

                        ServerSettingsEnvironment.CurrentLanguage = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.CurrentAppLanguageColumn];

                        if (dataSet_YakSysServerDB.Tables["CommonSecuritySettings"].Rows.Count < 1) InitCommonSecuritySettingsXmlDB();

                        if (dataSet_YakSysServerDB.Tables["CommonSecuritySettings"].Rows.Count < 1) return;

                        YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.CommonSecuritySettingsDataTable commonSecuritySettingsDataTable_obj = dataSet_YakSysServerDB.CommonSecuritySettings;


                        ServerSettingsEnvironment.MaxConnections = (int)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.MaxConnectionsColumn];

                        ServerSettingsEnvironment.MaxConnectionsPerAccount = (int)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.MaxConnectionPerAccountColumn];

                        ServerSettingsEnvironment.EnableAccessRestrictionRules = (bool)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.EnableAccessRestrictionsColumn];

                        ServerSettingsEnvironment.IsWindowsAuthenticationAllowed = (bool)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.AllowWindowsAccountsColumn];

                        ServerSettingsEnvironment.MinRSAPublicKeyLength = (int)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.MinRSAKeySizeColumn];
                        ServerSettingsEnvironment.MaxRSAPublicKeyLength = (int)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.MaxRSAKeySizeColumn];


                        try
                        {
                            YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = YakSysServerDB.CSPForm_ServerAuthentication;

                            YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = YakSysServerDB.CSPForm_UINAccountStateSettings;

                            ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort = (int)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_UseYakSysCSPServer = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseYakSysCSPServerColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_IsPublicServer = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_IsPublicServerColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_HideIP = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_HideIPColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_KeepConnectionAlive = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_KeepConnectionAliveColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_ConnectAtStartUp = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_ConnectAtStartUpColumn];
                            
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_GetActivationCode = (bool)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_GetActivationCodeColumn];
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_UseYakSysCSPServer = (bool)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseYakSysCSPServerColumn];
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServiceIPAddress = (string)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServiceIPAddressColumn];
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServicePort = (int)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServicePortColumn];
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_UIN = (string)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINColumn];
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_Password = (string)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_PasswordColumn];
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_UINActivationCode = (string)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINActivationCodeColumn];
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_NewAccountStateIndex = (int)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_NewAccountStateIndexColumn];

                        }
                        catch (Exception ex)
                        {
                            InitCSPSettingsXmlDB();
                        }
                    
                    }

                    public void InitCSPSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = YakSysServerDB.CSPForm_ServerAuthentication;

                            YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = YakSysServerDB.CSPForm_UINAccountStateSettings;

                            YakSysServerDB.CSPForm_ServerAuthentication.Rows.Clear();
                            YakSysServerDB.CSPForm_UINAccountStateSettings.Rows.Clear();
                                                                                 
                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysServerDB.CSPForm_UINAccountStateSettings.NewRow();

                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_GetActivationCodeColumn] = true;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseYakSysCSPServerColumn] = true;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServiceIPAddressColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServicePortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_PasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINActivationCodeColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_NewAccountStateIndexColumn] = 0;

                            YakSysServerDB.CSPForm_UINAccountStateSettings.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysServerDB.CSPForm_ServerAuthentication.NewRow();

                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseYakSysCSPServerColumn] = true;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_IsPublicServerColumn] = true;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_HideIPColumn] = true;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_KeepConnectionAliveColumn] = true;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_ConnectAtStartUpColumn] = true;                            

                            YakSysServerDB.CSPForm_ServerAuthentication.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();
                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("YakSysServerDB")) File.Delete("YakSysServerDB");

                            MessageBox.Show(ServerStringFactory.GetString(480, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }
                    public void SaveCSPSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = YakSysServerDB.CSPForm_ServerAuthentication;

                            YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = YakSysServerDB.CSPForm_UINAccountStateSettings;

                            YakSysServerDB.CSPForm_ServerAuthentication.Rows.Clear();
                            YakSysServerDB.CSPForm_UINAccountStateSettings.Rows.Clear();
                            
                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = YakSysServerDB.CSPForm_ServerAuthentication.NewRow();

                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn] = ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn] = ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn] = ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn] = ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseYakSysCSPServerColumn] = ServerSettingsEnvironment.CSP_ServerAuth_UseYakSysCSPServer;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_IsPublicServerColumn] = ServerSettingsEnvironment.CSP_ServerAuth_IsPublicServer;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_HideIPColumn] = ServerSettingsEnvironment.CSP_ServerAuth_HideIP;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_KeepConnectionAliveColumn] = ServerSettingsEnvironment.CSP_ServerAuth_KeepConnectionAlive;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_ConnectAtStartUpColumn] = ServerSettingsEnvironment.CSP_ServerAuth_ConnectAtStartUp;   

                            YakSysServerDB.CSPForm_ServerAuthentication.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////
                       
                            dataRow_NewRecord = YakSysServerDB.CSPForm_UINAccountStateSettings.NewRow();

                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_GetActivationCodeColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_GetActivationCode;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseYakSysCSPServerColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_UseYakSysCSPServer;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServiceIPAddressColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServiceIPAddress;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServicePortColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServicePort;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_UIN;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_PasswordColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_Password;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINActivationCodeColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_UINActivationCode;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_NewAccountStateIndexColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_NewAccountStateIndex;

                            YakSysServerDB.CSPForm_UINAccountStateSettings.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                        }
                        catch (Exception exception_obj)
                        {
                            return;
                        }
                    }

                    public void InitMainServerSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.MainSettingsDataTable mainSettingsDataTable_obj = YakSysServerDB.MainSettings;

                            YakSysServerDB.MainSettings.Clear();

                            dataRow_NewRecord = dataSet_YakSysServerDB.MainSettings.NewRow();

                            dataRow_NewRecord.ItemArray.Initialize();

                            dataRow_NewRecord[mainSettingsDataTable_obj.IDColumn] = 0;

                            dataRow_NewRecord[mainSettingsDataTable_obj.ServerPortColumn] = 5544;

                            dataRow_NewRecord[mainSettingsDataTable_obj.AppVersionColumn] = "1.1.0";

                            dataRow_NewRecord[mainSettingsDataTable_obj.ShowToolTipsColumn] = true;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ShowAdvancedSettingsColumn] = false;

                            dataRow_NewRecord[mainSettingsDataTable_obj.AutoRunColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.StartServerAtRunColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.MinimizeToNotifyAreaAtRunColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ShowIconInNotifyAreaColumn] = true;

                            dataRow_NewRecord[mainSettingsDataTable_obj.PromptPasswordAfterUnHideColumn] = false;

                            dataRow_NewRecord[mainSettingsDataTable_obj.CurrentAppLanguageColumn] = ServerSettingsEnvironment.CurrentLanguage;

                            dataRow_NewRecord[mainSettingsDataTable_obj.ActivateHiddenModeAtStartUpColumn] = false;

                            YakSysServerDB.MainSettings.Rows.Add(dataRow_NewRecord);
                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("YakSysServerDB")) File.Delete("YakSysServerDB");

                            MessageBox.Show(ServerStringFactory.GetString(127, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                    public void InitCommonSecuritySettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.CommonSecuritySettingsDataTable commonSecuritySettingsDataTable_obj = dataSet_YakSysServerDB.CommonSecuritySettings;

                            dataSet_YakSysServerDB.CommonSecuritySettings.Clear();

                            dataRow_NewRecord = dataSet_YakSysServerDB.CommonSecuritySettings.NewRow();

                            dataRow_NewRecord.ItemArray.Initialize();

                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.AllowWindowsAccountsColumn] = false;
                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.EnableAccessRestrictionsColumn] = false;

                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MinRSAKeySizeColumn] = 256;
                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxRSAKeySizeColumn] = 8192;

                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxConnectionsColumn] = 255;
                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxConnectionPerAccountColumn] = 255;

                            dataSet_YakSysServerDB.CommonSecuritySettings.Rows.Add(dataRow_NewRecord);

                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("YakSysServerDB")) File.Delete("YakSysServerDB");

                            MessageBox.Show(ServerStringFactory.GetString(127, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                    public void RetriveServerSettingsData(MemoryStream memoryStream_XMLData)
                    {
                        try
                        {
                            YakSysServerDB.Clear();

                            YakSysServerDB.ReadXml(memoryStream_XMLData);
                        }
                        catch (Exception exception_obj)
                        {
                            InitMainServerSettingsXmlDB();

                            InitCommonSecuritySettingsXmlDB();

                            MessageBox.Show(ServerStringFactory.GetString(127, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                            return;
                        }

                        try
                        {
                            ApplyDBSettings();
                        }
                        catch (Exception exception_obj)
                        {
                            MessageBox.Show(ServerStringFactory.GetString(128, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));
                        }
                    }
                }
            }
        }
    }
}