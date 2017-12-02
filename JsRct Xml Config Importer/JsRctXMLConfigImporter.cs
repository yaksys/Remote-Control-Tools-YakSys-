using System;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;
using JurikSoft;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctServer;
using JurikSoft.XMLConfigImporer.JsRctServer.Version110;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;
//using JurikSoft.XMLConfigImporer.JSCconnectingService;
//using JurikSoft.XMLConfigImporer.JSCconnectingService.Version10;



//DataSet_ConnectingServiceDB.xsd

namespace JurikSoft
{
    namespace XMLConfigImporer
    {
        public class JSServerDBEnvironment : MarshalByRefObject
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

            public static void WriteXMLDataToFile(string string_XMLFilePath, string string_VersionHeader, DataSet dataSet_JurikSoftServerDB)
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

                dataSet_JurikSoftServerDB.WriteXml(memoryStream_XMLData);


                if (ServerSettingsEnvironment.EncryptSettingsDataBase == true) byte_ToEncryptServerDataBase = 1;
                if (ServerSettingsEnvironment.CompressSettingsDataBase == true) byte_ToCompressSettingsDataBase = 1;


                if (ServerSettingsEnvironment.CompressSettingsDataBase == true)
                {
                    JurikSoft.Compression.LZSS lZSS_obj = new JurikSoft.Compression.LZSS(16, true, true, false, 65536);

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

                fileStream_ServerDB.Write(System.Text.Encoding.Default.GetBytes(string_VersionHeader), 0, 20); // string_VersionHeader must be 20 bytes!

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

                    DataSet_Server_Ver110.DataSet_JurikSoftServerDB.MainSettingsDataTable mainSettingsDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.MainSettings;

                    DataSet_Server_Ver110.DataSet_JurikSoftServerDB.CommonSecuritySettingsDataTable commonSecuritySettingsDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.CommonSecuritySettings;

                    new JsRctServerV110XMLConfigImporter().InitMainServerSettingsXmlDB();
                    new JsRctServerV110XMLConfigImporter().InitCommonSecuritySettingsXmlDB();

                    /////////////////////////

                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.MainSettings.Rows[0];

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

                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.CommonSecuritySettings.Rows[0];

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxConnectionsColumn] = ServerSettingsEnvironment.MaxConnections;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxConnectionPerAccountColumn] = ServerSettingsEnvironment.MaxConnectionsPerAccount;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.EnableAccessRestrictionsColumn] = ServerSettingsEnvironment.EnableAccessRestrictionRules;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.AllowWindowsAccountsColumn] = ServerSettingsEnvironment.IsWindowsAuthenticationAllowed;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MinRSAKeySizeColumn] = ServerSettingsEnvironment.MinRSAPublicKeyLength;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxRSAKeySizeColumn] = ServerSettingsEnvironment.MaxRSAPublicKeyLength;


                    WriteXMLDataToFile(string_XMLFilePath, "JurikSoftServerDB110", JsRctServerV110XMLConfigImporter.JurikSoftServerDB);
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("JurikSoftServerDB")) File.Delete("JurikSoftServerDB");

                    MessageBox.Show(ServerStringFactory.GetString(125, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                    return;
                }

            }

            public static void LoadXMLDataFile(string string_XMLFilePath, bool bool_UseDBImportMode)
            {
                FileStream fileStream_JurikSoftXMLDB = null;

                MemoryStream memoryStream_XMLData = new MemoryStream(),
                            memoryStream_UnprocessedXMLData = new MemoryStream(),
                            memoryStream_DecryptedXMLData = new MemoryStream(),
                            memoryStream_EncryptedXMLData = null;

                SHA256Managed sHA256Managed_obj = new SHA256Managed();

                RijndaelManaged rijndaelManaged_obj = new RijndaelManaged();

                CryptoStream cryptoStream_obj = null;

                try
                {
                    if (File.Exists(string_XMLFilePath) == false || new FileInfo(string_XMLFilePath).Length < 500)
                    {
                        new JsRctServerV110XMLConfigImporter().InitMainServerSettingsXmlDB();
                        new JsRctServerV110XMLConfigImporter().InitCommonSecuritySettingsXmlDB();

                        new JsRctServerV110XMLConfigImporter().ApplyDBSettings();

                        return;
                    }

                    fileStream_JurikSoftXMLDB = File.Open(string_XMLFilePath, FileMode.Open, FileAccess.Read);

                    byte[]
                        byteArray_UnprocessedXMLData = new byte[fileStream_JurikSoftXMLDB.Length - 86],
                        byteArray_ComputedXMLDataHash = new byte[32], byteArray_ComputedHashOfPasswordHash = new byte[32],
                        byteArray_StoredXMLDataHash = new byte[32], byteArray_StoredHashOfPasswordHash = new byte[32],
                        byteArray_DecompressedXMLData = null, byteArray_ComputedPasswordHash, byteArray_JurikSoftServerDBHeader = new byte[20],
                        byteArray_EncryptedXMLData = new byte[fileStream_JurikSoftXMLDB.Length - 86];

                    byte byte_IsServerDataBaseEncrypted = 0, byte_IsSettingsDataBaseCompressed = 0;

                    fileStream_JurikSoftXMLDB.Read(byteArray_JurikSoftServerDBHeader, 0, byteArray_JurikSoftServerDBHeader.Length);

                    DBVersion = System.Text.Encoding.Default.GetString(byteArray_JurikSoftServerDBHeader);

                    if (
                        DBVersion != ("JurikSoftServerDB090") &&
                        DBVersion != ("JurikSoftServerDB010") &&
                        DBVersion != ("JurikSoftServerDB110")
                        )
                    {
                        fileStream_JurikSoftXMLDB.Close();

                        new JsRctServerV110XMLConfigImporter().InitMainServerSettingsXmlDB();
                        new JsRctServerV110XMLConfigImporter().InitCommonSecuritySettingsXmlDB();

                        new JsRctServerV110XMLConfigImporter().ApplyDBSettings();

                        MessageBox.Show(ServerStringFactory.GetString(124, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                        return;
                    }

                    byte_IsServerDataBaseEncrypted = (byte)fileStream_JurikSoftXMLDB.ReadByte();
                    byte_IsSettingsDataBaseCompressed = (byte)fileStream_JurikSoftXMLDB.ReadByte();

                    fileStream_JurikSoftXMLDB.Position = 86;

                    fileStream_JurikSoftXMLDB.Read(byteArray_UnprocessedXMLData, 0, byteArray_UnprocessedXMLData.Length);

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

                        fileStream_JurikSoftXMLDB.Position = 22;

                        fileStream_JurikSoftXMLDB.Read(byteArray_StoredXMLDataHash, 0, byteArray_StoredXMLDataHash.Length);
                        fileStream_JurikSoftXMLDB.Read(byteArray_StoredHashOfPasswordHash, 0, byteArray_StoredHashOfPasswordHash.Length);

                        byteArray_ComputedPasswordHash = sHA256Managed_obj.ComputeHash(System.Text.Encoding.Default.GetBytes(ServerSettingsEnvironment.LocalSecurityPassword));
                        byteArray_ComputedHashOfPasswordHash = sHA256Managed_obj.ComputeHash(byteArray_ComputedPasswordHash);

                        if (CommonMethods.IsBytesArraysEquals(byteArray_ComputedHashOfPasswordHash, byteArray_StoredHashOfPasswordHash) == false)
                        {
                            MessageBox.Show(ServerStringFactory.GetString(126, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            if (fileStream_JurikSoftXMLDB != null) fileStream_JurikSoftXMLDB.Close();

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
                        byteArray_DecompressedXMLData = new JurikSoft.Compression.CommonEnvironment().Decompress(memoryStream_XMLData.ToArray(), false);

                        memoryStream_XMLData = new MemoryStream(byteArray_DecompressedXMLData);

                        ServerSettingsEnvironment.CompressSettingsDataBase = true;
                    }
                    else
                    {
                        ServerSettingsEnvironment.CompressSettingsDataBase = false;
                    }

                    fileStream_JurikSoftXMLDB.Close();

                    if (DBVersion == "JurikSoftServerDB090")
                    {
                        new JsRctServer.Version090.JsRctServerV090XMLConfigImporter().RetriveServerSettingsData(memoryStream_XMLData);

                        SyncIdentTables();
                    }

                    if (DBVersion == "JurikSoftServerDB110")
                    {
                        new JsRctServerV110XMLConfigImporter().RetriveServerSettingsData(memoryStream_XMLData);
                    }

                    memoryStream_XMLData.Close();
                }

                catch
                {
                }
                finally
                {
                    if (fileStream_JurikSoftXMLDB != null) fileStream_JurikSoftXMLDB.Close();

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
                JSServerDBEnvironment.LoadXMLDataFile(string_XMLFilePath, bool_UseDBImportMode);
            }

            public static void SyncIdentTables()
            {
                if (DBVersion == "JurikSoftServerDB090")
                {
                    JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.Clear();

                    for (int int_CycleCount = 0; int_CycleCount != JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.Count; int_CycleCount++)
                    {
                        JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.Add(JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows[int_CycleCount].ItemArray);
                    }

                    JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.Clear();

                    for (int int_CycleCount = 0; int_CycleCount != JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.Count; int_CycleCount++)
                    {
                        JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.Add(JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows[int_CycleCount].ItemArray);
                    }

                    JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Clear();

                    for (int int_CycleCount = 0; int_CycleCount != JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Count; int_CycleCount++)
                    {
                        JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Add(JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows[int_CycleCount].ItemArray);
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
                if (JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.Count < 0) return null;

                DataRow dataRow_NewRecord = null;

                DataSet_Server_Ver110.DataSet_JurikSoftServerDB.EventsLogDataTable eventsLogDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog;

                ////////////////////////////////////////////////////////////////////////////////

                ListViewItem[] listViewItemArray_Logs = new ListViewItem[eventsLogDataTable_obj.Rows.Count];

                string string_LogType, string_LogDate, string_LogTime, string_LogSource, string_LogDescription;

                for (int int_CycleCount = 0; int_CycleCount != eventsLogDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows[int_CycleCount];

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
                if (JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.Count < 0) return new XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase[0];

                DataRow dataRow_NewRecord = null;

                DataSet_Server_Ver110.DataSet_JurikSoftServerDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase;

                /////////////////////////////////////////

                XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase[] securityDataBaseArray_obj = new XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase[securityDataBaseDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != securityDataBaseDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows[int_CycleCount];

                    securityDataBaseArray_obj[int_CycleCount] = new XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase();

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
                if (JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Count < 0) return new AccessRestrictionRule[0];

                DataRow dataRow_NewRecord = null;

                DataSet_Server_Ver110.DataSet_JurikSoftServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules;

                ////////////////////////////////////////////////////////////////////////////////

                AccessRestrictionRule[] accessRestrictionRuleArray_obj = new AccessRestrictionRule[accessRestrictionRulesDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != accessRestrictionRulesDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows[int_CycleCount];

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
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveAccessRestrictionRulesDataBaseRow(int int_RowIndex)
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveEventsLogDataBaseRow(int int_RowIndex)
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.RemoveAt(int_RowIndex);
            }


            public void ClearSecurityDataBase()
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.Clear();
            }

            public void ClearAccessRestrictionRulesDataBase()
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Clear();
            }

            public void ClearEventsLogDataBase()
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.Clear();
            }
        }

        public class JSClientDBEnvironment
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

            public static void WriteXMLDataToFile(string string_XMLFilePath, string string_VersionHeader, DataSet dataSet_JurikSoftClientDB)
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

                dataSet_JurikSoftClientDB.WriteXml(memoryStream_XMLData);


                if (ClientSettingsEnvironment.EncryptSettingsDataBase == true) byte_ToEncryptClientDataBase = 1;
                if (ClientSettingsEnvironment.CompressSettingsDataBase == true) byte_ToCompressClientDataBase = 1;


                if (ClientSettingsEnvironment.CompressSettingsDataBase == true)
                {
                    JurikSoft.Compression.LZSS lZSS_obj = new JurikSoft.Compression.LZSS(16, true, true, false, 65536);

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

                fileStream_ClientDB.Write(System.Text.Encoding.Default.GetBytes(string_VersionHeader), 0, 20); // string_VersionHeader must be 20 bytes!

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

                    DataSet_Client_Ver110.DataSet_JurikSoftClientDB.MainSettingsDataTable mainSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.MainSettings;

                    DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable proxyServersSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings;

                    /////////////////////////

                    dataRow_NewRecord = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.MainSettings.Rows[0];

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

                    dataRow_NewRecord = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows[0];

                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.ProxyHostColumn] = ClientSettingsEnvironment.ProxyServerHost;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.ProxyPortColumn] = ClientSettingsEnvironment.ProxyServerPort;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.ProxyTimeOutColumn] = ClientSettingsEnvironment.ProxyServerTimeOut;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.ProxyTypeColumn] = ClientSettingsEnvironment.ProxyServerType;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn] = ClientSettingsEnvironment.UseProxyToResolveHostNames;

                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.UseAuthenticationColumn] = ClientSettingsEnvironment.UseProxyAuthentication;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.LoginColumn] = ClientSettingsEnvironment.ProxyLogin;
                    dataRow_NewRecord[proxyServersSettingsDataTable_obj.PasswordColumn] = ClientSettingsEnvironment.ProxyPassword;

                    WriteXMLDataToFile(string_XMLFilePath, "JurikSoftClientDB110", JsRctClientV110XMLConfigImporter.JurikSoftClientDB);
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("JurikSoftClientDB")) File.Delete("JurikSoftClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(481, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return;
                }

            }

            public static void LoadXMLDataFile(string string_XMLFilePath, bool bool_UseDBImportMode)
            {
                FileStream fileStream_JurikSoftXMLDB = null;

                MemoryStream memoryStream_XMLData = new MemoryStream(),
                            memoryStream_UnprocessedXMLData = new MemoryStream(),
                            memoryStream_DecryptedXMLData = new MemoryStream(),
                            memoryStream_EncryptedXMLData = null;

                SHA256Managed sHA256Managed_obj = new SHA256Managed();

                RijndaelManaged rijndaelManaged_obj = new RijndaelManaged();

                CryptoStream cryptoStream_obj = null;

                try
                {
                    if (File.Exists(string_XMLFilePath) == false || new FileInfo(string_XMLFilePath).Length < 500)
                    {
                        new JsRctClientV110XMLConfigImporter().InitProxyServersSettingsXmlDB();
                        new JsRctClientV110XMLConfigImporter().InitMainClientSettingsXmlDB();

                        new JsRctClientV110XMLConfigImporter().ApplyDBSettings();

                        return;
                    }

                    fileStream_JurikSoftXMLDB = File.Open(string_XMLFilePath, FileMode.Open, FileAccess.Read);

                    byte[]
                        byteArray_UnprocessedXMLData = new byte[fileStream_JurikSoftXMLDB.Length - 86],
                        byteArray_ComputedXMLDataHash = new byte[32], byteArray_ComputedHashOfPasswordHash = new byte[32],
                        byteArray_StoredXMLDataHash = new byte[32], byteArray_StoredHashOfPasswordHash = new byte[32],
                        byteArray_DecompressedXMLData = null, byteArray_ComputedPasswordHash, byteArray_JurikSoftClientDBHeader = new byte[20],
                        byteArray_EncryptedXMLData = new byte[fileStream_JurikSoftXMLDB.Length - 86];

                    byte byte_IsClientDataBaseEncrypted = 0, byte_IsSettingsDataBaseCompressed = 0;

                    fileStream_JurikSoftXMLDB.Read(byteArray_JurikSoftClientDBHeader, 0, byteArray_JurikSoftClientDBHeader.Length);

                    DBVersion = System.Text.Encoding.Default.GetString(byteArray_JurikSoftClientDBHeader);

                    if (
                        DBVersion != ("JurikSoftClientDB090") &&
                        DBVersion != ("JurikSoftClientDB010") &&
                        DBVersion != ("JurikSoftClientDB110")
                        )
                    {
                        fileStream_JurikSoftXMLDB.Close();

                        new JsRctClientV110XMLConfigImporter().InitProxyServersSettingsXmlDB();
                        new JsRctClientV110XMLConfigImporter().InitMainClientSettingsXmlDB();

                        new JsRctClientV110XMLConfigImporter().ApplyDBSettings();

                        MessageBox.Show(ClientStringFactory.GetString(542, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                        return;
                    }

                    byte_IsClientDataBaseEncrypted = (byte)fileStream_JurikSoftXMLDB.ReadByte();
                    byte_IsSettingsDataBaseCompressed = (byte)fileStream_JurikSoftXMLDB.ReadByte();

                    fileStream_JurikSoftXMLDB.Position = 86;

                    fileStream_JurikSoftXMLDB.Read(byteArray_UnprocessedXMLData, 0, byteArray_UnprocessedXMLData.Length);

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

                        fileStream_JurikSoftXMLDB.Position = 22;

                        fileStream_JurikSoftXMLDB.Read(byteArray_StoredXMLDataHash, 0, byteArray_StoredXMLDataHash.Length);
                        fileStream_JurikSoftXMLDB.Read(byteArray_StoredHashOfPasswordHash, 0, byteArray_StoredHashOfPasswordHash.Length);

                        byteArray_ComputedPasswordHash = sHA256Managed_obj.ComputeHash(System.Text.Encoding.Default.GetBytes(ClientSettingsEnvironment.LocalSecurityPassword));
                        byteArray_ComputedHashOfPasswordHash = sHA256Managed_obj.ComputeHash(byteArray_ComputedPasswordHash);

                        if (CommonMethods.IsBytesArraysEquals(byteArray_ComputedHashOfPasswordHash, byteArray_StoredHashOfPasswordHash) == false)
                        {
                            MessageBox.Show(ClientStringFactory.GetString(541, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            if (fileStream_JurikSoftXMLDB != null) fileStream_JurikSoftXMLDB.Close();

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
                        byteArray_DecompressedXMLData = new JurikSoft.Compression.CommonEnvironment().Decompress(memoryStream_XMLData.ToArray(), false);

                        memoryStream_XMLData = new MemoryStream(byteArray_DecompressedXMLData);

                        ClientSettingsEnvironment.CompressSettingsDataBase = true;
                    }
                    else
                    {
                        ClientSettingsEnvironment.CompressSettingsDataBase = false;
                    }

                    fileStream_JurikSoftXMLDB.Close();

                    if (DBVersion == "JurikSoftClientDB090")
                    {
                        new JsRctClient.Version090.JsRctClientV090XMLConfigImporter().RetriveCleintSettingsData(memoryStream_XMLData);

                        SyncIdentTables();
                    }

                    if (DBVersion == "JurikSoftClientDB110")
                    {
                        new JsRctClientV110XMLConfigImporter().RetriveClientSettingsData(memoryStream_XMLData);
                    }

                    memoryStream_XMLData.Close();
                }

                catch (Exception exception_obj)
                {

                }
                finally
                {
                    if (fileStream_JurikSoftXMLDB != null) fileStream_JurikSoftXMLDB.Close();

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
                    if (DBVersion == "JurikSoftClientDB090")
                    {
                        JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Count; int_CycleCount++)
                        {
                            JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Add(JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows[int_CycleCount].ItemArray);
                        }

                        JsRctClientV110XMLConfigImporter.JurikSoftClientDB.MainSettings.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.MainSettings.Rows.Count; int_CycleCount++)
                        {
                            JsRctClientV110XMLConfigImporter.JurikSoftClientDB.MainSettings.Rows.Add(JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.MainSettings.Rows[int_CycleCount].ItemArray);
                        }

                        JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows.Count; int_CycleCount++)
                        {
                            JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows.Add(JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows[int_CycleCount].ItemArray);
                        }

                        JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows.Count; int_CycleCount++)
                        {
                            JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows.Add(JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows[int_CycleCount].ItemArray);
                        }

                        JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServerUsers.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.JurikSoftServerUsers.Rows.Count; int_CycleCount++)
                        {
                            JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServerUsers.Rows.Add(JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.JurikSoftServerUsers.Rows[int_CycleCount].ItemArray);
                        }

                        JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServerUserEMails.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.JurikSoftServerUserEMails.Rows.Count; int_CycleCount++)
                        {
                            JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServerUserEMails.Rows.Add(JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.JurikSoftServerUserEMails.Rows[int_CycleCount].ItemArray);
                        }

                        JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ICQList.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.ICQList.Rows.Count; int_CycleCount++)
                        {
                            JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ICQList.Rows.Add(JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.ICQList.Rows[int_CycleCount].ItemArray);
                        }

                        JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServerEMails.Rows.Clear();

                        for (int int_CycleCount = 0; int_CycleCount != JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.JurikSoftServerEMails.Rows.Count; int_CycleCount++)
                        {
                            JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServerEMails.Rows.Add(JsRctClient.Version090.JsRctClientV090XMLConfigImporter.JurikSoftClientDB.JurikSoftServerEMails.Rows[int_CycleCount].ItemArray);
                        }
                    }
                }
                catch (Exception exception_obj)
                {
                }
            }


            public ListViewItem[] GetJurikSoftServersGroups()
            {
                try
                {
                    if (JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows.Count < 0) return null;

                    DataRow dataRow_NewRecord = null;

                    DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ServerGroupTypesDataTable serverGroupTypesDataTableDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes;

                    ////////////////////////////////////////////////////////////////////////////////

                    ListViewItem[] listViewItemArray_JurikSoftServersGroups = new ListViewItem[serverGroupTypesDataTableDataTable_obj.Rows.Count];

                    string string_GroupName = string.Empty;

                    for (int int_CycleCount = 0; int_CycleCount != serverGroupTypesDataTableDataTable_obj.Rows.Count; int_CycleCount++)
                    {
                        dataRow_NewRecord = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows[int_CycleCount];

                        string_GroupName = (string)dataRow_NewRecord[serverGroupTypesDataTableDataTable_obj.GroupNameColumn];

                        listViewItemArray_JurikSoftServersGroups[int_CycleCount] = new ListViewItem(string_GroupName, 0);

                        listViewItemArray_JurikSoftServersGroups[int_CycleCount].Tag = int_CycleCount;
                    }

                    return listViewItemArray_JurikSoftServersGroups;
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("JurikSoftClientDB")) File.Delete("JurikSoftClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(490, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return null;
                }
            }

            public ListViewItem[] GetProxyServersList()
            {
                try
                {
                    if (JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Count < 2) return null;

                    DataRow dataRow_NewRecord = null;

                    DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable proxyServersSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings;

                    ////////////////////////////////////////////////////////////////////////////////

                    ListViewItem[] listViewItemArray_ProxyServersList = new ListViewItem[proxyServersSettingsDataTable_obj.Rows.Count - 1];

                    if (listViewItemArray_ProxyServersList.Length < 1) return null;

                    string string_ProxyServerTitle, string_ProxyHost, string_ProxyPort;

                    for (int int_CycleCount = 0; int_CycleCount != listViewItemArray_ProxyServersList.Length; int_CycleCount++)
                    {
                        dataRow_NewRecord = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows[int_CycleCount + 1];

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
                    if (File.Exists("JurikSoftClientDB")) File.Delete("JurikSoftClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(490, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return null;
                }
            }

            public ListViewItem[] GetJurikSoftServersList(int int_SelectedGroupID)
            {
                try
                {
                    if (JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows.Count < 0) return null;

                    DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow[] dataRowArray_JurikSoftServersRows = null;

                    DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow dataRow_CurrentJurikSoftServerRow = null;

                    DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ServerGroupTypesDataTable serverGroupTypesDataTableDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes;
                    DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersDataTable jurikSoftServersDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers;

                    ////////////////////////////////////////////////////////////////////////////////

                    dataRowArray_JurikSoftServersRows = (DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow[])JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows[int_SelectedGroupID].GetChildRows("ServerGroupTypes_JurikSoftServerInfo");

                    ListViewItem[] listViewItemArray_JurikSoftServersList = new ListViewItem[dataRowArray_JurikSoftServersRows.Length];

                    string string_ServerName = string.Empty, string_ServerHost = string.Empty, string_ServerPort = string.Empty,
                            string_ServerLocation = string.Empty, string_GroupName = string.Empty;

                    for (int int_CycleCount = 0; int_CycleCount != dataRowArray_JurikSoftServersRows.Length; int_CycleCount++)
                    {
                        dataRow_CurrentJurikSoftServerRow = (DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow)dataRowArray_JurikSoftServersRows[int_CycleCount];

                        string_ServerName = (string)dataRow_CurrentJurikSoftServerRow.ServerName;
                        string_ServerHost = (string)dataRow_CurrentJurikSoftServerRow.ServerHost;
                        string_ServerPort = (string)dataRow_CurrentJurikSoftServerRow.ServerPort.ToString();
                        string_ServerLocation = (string)dataRow_CurrentJurikSoftServerRow.ServerLocation;
                        string_GroupName = (string)serverGroupTypesDataTableDataTable_obj[int_SelectedGroupID][serverGroupTypesDataTableDataTable_obj.GroupNameColumn];

                        listViewItemArray_JurikSoftServersList[int_CycleCount] = new ListViewItem(string_ServerName, 0);

                        listViewItemArray_JurikSoftServersList[int_CycleCount].SubItems.Add(string_ServerHost);
                        listViewItemArray_JurikSoftServersList[int_CycleCount].SubItems.Add(string_ServerPort);
                        listViewItemArray_JurikSoftServersList[int_CycleCount].SubItems.Add(string_ServerLocation);
                        listViewItemArray_JurikSoftServersList[int_CycleCount].SubItems.Add(string_GroupName);
                    }

                    return listViewItemArray_JurikSoftServersList;
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("JurikSoftClientDB")) File.Delete("JurikSoftClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(490, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return null;
                }
            }

            public ListViewItem[] GetJurikSoftServersList()
            {
                try
                {
                    if (JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows.Count == 0) return null;

                    DataRow dataRow_NewRecord = null;

                    DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersDataTable jurikSoftServersDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers;

                    ////////////////////////////////////////////////////////////////////////////////

                    ListViewItem[] listViewItemArray_JurikSoftServersList = new ListViewItem[jurikSoftServersDataTable_obj.Rows.Count];

                    string string_ServerName = string.Empty, string_ServerHost = string.Empty, string_ServerPort = string.Empty,
                            string_ServerLocation = string.Empty, string_GroupName = string.Empty;

                    for (int int_CycleCount = 0; int_CycleCount != jurikSoftServersDataTable_obj.Rows.Count; int_CycleCount++)
                    {
                        dataRow_NewRecord = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows[int_CycleCount];

                        string_ServerName = (string)dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerNameColumn];
                        string_ServerHost = (string)dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerHostColumn];
                        string_ServerPort = (string)dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerPortColumn].ToString();
                        string_ServerLocation = (string)dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerLocationColumn];
                        string_GroupName = (string)((DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ServerGroupTypesRow)dataRow_NewRecord.GetParentRow("ServerGroupTypes_JurikSoftServerInfo")).GroupName;

                        listViewItemArray_JurikSoftServersList[int_CycleCount] = new ListViewItem(string_ServerName, 0);

                        listViewItemArray_JurikSoftServersList[int_CycleCount].SubItems.Add(string_ServerHost);
                        listViewItemArray_JurikSoftServersList[int_CycleCount].SubItems.Add(string_ServerPort);
                        listViewItemArray_JurikSoftServersList[int_CycleCount].SubItems.Add(string_ServerLocation);
                        listViewItemArray_JurikSoftServersList[int_CycleCount].SubItems.Add(string_GroupName);

                        listViewItemArray_JurikSoftServersList[int_CycleCount].Tag = int_CycleCount;
                    }

                    return listViewItemArray_JurikSoftServersList;
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("JurikSoftClientDB")) File.Delete("JurikSoftClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(490, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return null;
                }
            }


            public string[] GetServersGroupsItems()
            {
                try
                {
                    if (JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows.Count == 0) return null;

                    DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ServerGroupTypesDataTable serverGroupTypesDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes;

                    ////////////////////////////////////////////////////////////////////////////////

                    string[] stringArray_ServersGroupsNames = new string[JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows.Count];

                    for (int int_CycleCount = 0; int_CycleCount != serverGroupTypesDataTable_obj.Rows.Count; int_CycleCount++)
                    {
                        stringArray_ServersGroupsNames[int_CycleCount] = (string)JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows[int_CycleCount][serverGroupTypesDataTable_obj.GroupNameColumn];
                    }

                    return stringArray_ServersGroupsNames;
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("JurikSoftClientDB")) File.Delete("JurikSoftClientDB");

                    MessageBox.Show(ClientStringFactory.GetString(490, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                    return null;
                }
            }

            public void ClearJurikSoftServersDataBase()
            {
                JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows.Clear();
            }


            public void RemoveJurikSoftServersDataBaseRow(int int_RowIndex)
            {
                JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveProxyServerRecord(int int_RecordIndex)
            {
                DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow[] jurikSoftServersRowArray_ProxyChilds = null;

                jurikSoftServersRowArray_ProxyChilds = (DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow[])JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows[int_RecordIndex].GetChildRows("ProxyServersSettings_JurikSoftServersList");

                foreach (DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow jurikSoftServersRow_Current in jurikSoftServersRowArray_ProxyChilds)
                {
                    jurikSoftServersRow_Current.ProxyServerID = 0;
                    jurikSoftServersRow_Current.UseProxyServer = false;
                }

                JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.RemoveAt(int_RecordIndex);
            }


            public void DeleteAllLogins()
            {
                DataSet_Client_Ver110.DataSet_JurikSoftClientDB.MainSettingsDataTable mainSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.MainSettings;

                DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable proxyServersSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings;

                DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersDataTable jurikSoftServersDataTableDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers;


                mainSettingsDataTable_obj[0][mainSettingsDataTable_obj.ServerLoginColumn] = String.Empty;

                for (int int_CycleCount = 0; int_CycleCount != proxyServersSettingsDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    proxyServersSettingsDataTable_obj[int_CycleCount][proxyServersSettingsDataTable_obj.LoginColumn] = String.Empty;
                }

                for (int int_CycleCount = 0; int_CycleCount != jurikSoftServersDataTableDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    jurikSoftServersDataTableDataTable_obj[int_CycleCount][jurikSoftServersDataTableDataTable_obj.LoginColumn] = String.Empty;
                }
            }

            public void DeleteAllPasswords()
            {
                DataSet_Client_Ver110.DataSet_JurikSoftClientDB.MainSettingsDataTable mainSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.MainSettings;

                DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable proxyServersSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings;

                DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersDataTable jurikSoftServersDataTableDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers;

                mainSettingsDataTable_obj[0][mainSettingsDataTable_obj.ServerPasswordColumn] = String.Empty;

                for (int int_CycleCount = 0; int_CycleCount != proxyServersSettingsDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    proxyServersSettingsDataTable_obj[int_CycleCount][proxyServersSettingsDataTable_obj.PasswordColumn] = String.Empty;
                }

                for (int int_CycleCount = 0; int_CycleCount != jurikSoftServersDataTableDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    jurikSoftServersDataTableDataTable_obj[int_CycleCount][jurikSoftServersDataTableDataTable_obj.PasswordColumn] = String.Empty;
                }
            }
        }

        /*

        public class JSCconnectingServiceDBEnvironment : MarshalByRefObject
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

            public static void WriteXMLDataToFile(string string_XMLFilePath, string string_VersionHeader, DataSet dataSet_JurikSoftServerDB)
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

                dataSet_JurikSoftServerDB.WriteXml(memoryStream_XMLData);


                if (ServerSettingsEnvironment.EncryptSettingsDataBase == true) byte_ToEncryptServerDataBase = 1;
                if (ServerSettingsEnvironment.CompressSettingsDataBase == true) byte_ToCompressSettingsDataBase = 1;


                if (ServerSettingsEnvironment.CompressSettingsDataBase == true)
                {
                    JurikSoft.Compression.LZSS lZSS_obj = new JurikSoft.Compression.LZSS(16, true, true, false, 65536);

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

                fileStream_ServerDB.Write(System.Text.Encoding.Default.GetBytes(string_VersionHeader), 0, 20); // string_VersionHeader must be 20 bytes!

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

                    DataSet_JurikSoftServerDB.MainSettingsDataTable mainSettingsDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.MainSettings;

                    DataSet_JurikSoftServerDB.CommonSecuritySettingsDataTable commonSecuritySettingsDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.CommonSecuritySettings;

                    new JsRctServerV110XMLConfigImporter().InitMainServerSettingsXmlDB();
                    new JsRctServerV110XMLConfigImporter().InitCommonSecuritySettingsXmlDB();

                    /////////////////////////

                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.MainSettings.Rows[0];

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

                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.CommonSecuritySettings.Rows[0];

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxConnectionsColumn] = ServerSettingsEnvironment.MaxConnections;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxConnectionPerAccountColumn] = ServerSettingsEnvironment.MaxConnectionsPerAccount;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.EnableAccessRestrictionsColumn] = ServerSettingsEnvironment.EnableAccessRestrictionRules;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.AllowWindowsAccountsColumn] = ServerSettingsEnvironment.IsWindowsAuthenticationAllowed;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MinRSAKeySizeColumn] = ServerSettingsEnvironment.MinRSAPublicKeyLength;

                    dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxRSAKeySizeColumn] = ServerSettingsEnvironment.MaxRSAPublicKeyLength;


                    WriteXMLDataToFile(string_XMLFilePath, "JurikSoftServerDB110", JsRctServerV110XMLConfigImporter.JurikSoftServerDB);
                }

                catch (Exception exception_obj)
                {
                    if (File.Exists("JurikSoftServerDB")) File.Delete("JurikSoftServerDB");

                    MessageBox.Show(ServerStringFactory.GetString(125, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                    return;
                }

            }

            public static void LoadXMLDataFile(string string_XMLFilePath, bool bool_UseDBImportMode)
            {
                FileStream fileStream_JurikSoftXMLDB = null;

                MemoryStream memoryStream_XMLData = new MemoryStream(),
                            memoryStream_UnprocessedXMLData = new MemoryStream(),
                            memoryStream_DecryptedXMLData = new MemoryStream(),
                            memoryStream_EncryptedXMLData = null;

                SHA256Managed sHA256Managed_obj = new SHA256Managed();

                RijndaelManaged rijndaelManaged_obj = new RijndaelManaged();

                CryptoStream cryptoStream_obj = null;

                try
                {
                    if (File.Exists(string_XMLFilePath) == false || new FileInfo(string_XMLFilePath).Length < 500)
                    {
                        new JsRctServerV110XMLConfigImporter().InitMainServerSettingsXmlDB();
                        new JsRctServerV110XMLConfigImporter().InitCommonSecuritySettingsXmlDB();

                        new JsRctServerV110XMLConfigImporter().ApplyDBSettings();

                        return;
                    }

                    fileStream_JurikSoftXMLDB = File.Open(string_XMLFilePath, FileMode.Open, FileAccess.Read);

                    byte[]
                        byteArray_UnprocessedXMLData = new byte[fileStream_JurikSoftXMLDB.Length - 86],
                        byteArray_ComputedXMLDataHash = new byte[32], byteArray_ComputedHashOfPasswordHash = new byte[32],
                        byteArray_StoredXMLDataHash = new byte[32], byteArray_StoredHashOfPasswordHash = new byte[32],
                        byteArray_DecompressedXMLData = null, byteArray_ComputedPasswordHash, byteArray_JurikSoftServerDBHeader = new byte[20],
                        byteArray_EncryptedXMLData = new byte[fileStream_JurikSoftXMLDB.Length - 86];

                    byte byte_IsServerDataBaseEncrypted = 0, byte_IsSettingsDataBaseCompressed = 0;

                    fileStream_JurikSoftXMLDB.Read(byteArray_JurikSoftServerDBHeader, 0, byteArray_JurikSoftServerDBHeader.Length);

                    DBVersion = System.Text.Encoding.Default.GetString(byteArray_JurikSoftServerDBHeader);

                    if (                        
                        DBVersion != ("JurikSoftServerDB090") &&
                        DBVersion != ("JurikSoftServerDB010") &&
                        DBVersion != ("JurikSoftServerDB110")
                        )
                    {
                        fileStream_JurikSoftXMLDB.Close();

                        new JsRctServerV110XMLConfigImporter().InitMainServerSettingsXmlDB();
                        new JsRctServerV110XMLConfigImporter().InitCommonSecuritySettingsXmlDB();

                        new JsRctServerV110XMLConfigImporter().ApplyDBSettings();

                        MessageBox.Show(ServerStringFactory.GetString(124, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                        return;
                    }

                    byte_IsServerDataBaseEncrypted = (byte)fileStream_JurikSoftXMLDB.ReadByte();
                    byte_IsSettingsDataBaseCompressed = (byte)fileStream_JurikSoftXMLDB.ReadByte();

                    fileStream_JurikSoftXMLDB.Position = 86;

                    fileStream_JurikSoftXMLDB.Read(byteArray_UnprocessedXMLData, 0, byteArray_UnprocessedXMLData.Length);

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

                        fileStream_JurikSoftXMLDB.Position = 22;

                        fileStream_JurikSoftXMLDB.Read(byteArray_StoredXMLDataHash, 0, byteArray_StoredXMLDataHash.Length);
                        fileStream_JurikSoftXMLDB.Read(byteArray_StoredHashOfPasswordHash, 0, byteArray_StoredHashOfPasswordHash.Length);

                        byteArray_ComputedPasswordHash = sHA256Managed_obj.ComputeHash(System.Text.Encoding.Default.GetBytes(ServerSettingsEnvironment.LocalSecurityPassword));
                        byteArray_ComputedHashOfPasswordHash = sHA256Managed_obj.ComputeHash(byteArray_ComputedPasswordHash);

                        if (CommonMethods.IsBytesArraysEquals(byteArray_ComputedHashOfPasswordHash, byteArray_StoredHashOfPasswordHash) == false)
                        {
                            MessageBox.Show(ServerStringFactory.GetString(126, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            if (fileStream_JurikSoftXMLDB != null) fileStream_JurikSoftXMLDB.Close();

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
                        byteArray_DecompressedXMLData = new JurikSoft.Compression.CommonEnvironment().Decompress(memoryStream_XMLData.ToArray(), false);

                        memoryStream_XMLData = new MemoryStream(byteArray_DecompressedXMLData);

                        ServerSettingsEnvironment.CompressSettingsDataBase = true;
                    }
                    else
                    {
                        ServerSettingsEnvironment.CompressSettingsDataBase = false;
                    }

                    fileStream_JurikSoftXMLDB.Close();

                    if (DBVersion == "JurikSoftServerDB090")
                    {
                        new JsRctServer.Version090.JsRctServerV090XMLConfigImporter().RetriveServerSettingsData(memoryStream_XMLData);

                        SyncIdentTables();
                    }

                    if (DBVersion == "JurikSoftServerDB110")
                    {
                        new JsRctServerV110XMLConfigImporter().RetriveServerSettingsData(memoryStream_XMLData);
                    }

                    memoryStream_XMLData.Close();
                }

                catch
                {
                }
                finally
                {
                    if (fileStream_JurikSoftXMLDB != null) fileStream_JurikSoftXMLDB.Close();

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
                JSServerDBEnvironment.LoadXMLDataFile(string_XMLFilePath, bool_UseDBImportMode);
            }

            public static void SyncIdentTables()
            {
                if (DBVersion == "JurikSoftServerDB090")
                {
                    JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.Clear();

                    for (int int_CycleCount = 0; int_CycleCount != JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.Count; int_CycleCount++)
                    {
                        JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.Add(JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows[int_CycleCount].ItemArray);
                    }

                    JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.Clear();

                    for (int int_CycleCount = 0; int_CycleCount != JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.Count; int_CycleCount++)
                    {
                        JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.Add(JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows[int_CycleCount].ItemArray);
                    }
                    
                    JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Clear();

                    for (int int_CycleCount = 0; int_CycleCount != JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Count; int_CycleCount++)
                    {
                        JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Add(JsRctServer.Version090.JsRctServerV090XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows[int_CycleCount].ItemArray);
                    }
                }
            }

            public ListViewItem[] GetEventsLog()
            {
                if (JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.Count < 0) return null;

                DataRow dataRow_NewRecord = null;

                DataSet_JurikSoftServerDB.EventsLogDataTable eventsLogDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog;

                ////////////////////////////////////////////////////////////////////////////////

                ListViewItem[] listViewItemArray_Logs = new ListViewItem[eventsLogDataTable_obj.Rows.Count];

                string string_LogType, string_LogDate, string_LogTime, string_LogSource, string_LogDescription;

                for (int int_CycleCount = 0; int_CycleCount != eventsLogDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows[int_CycleCount];

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




            public class ClientsSecurityDataBase : MarshalByRefObject
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

            public class ClientsAccessRestrictionRule : MarshalByRefObject
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

            
            public ClientsSecurityDataBase[] GetClientsSecurityDataBase()
            {
                if (.SecurityDataBase.Rows.Count < 0) return new XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase[0]; ///!!! зачем то оставлял if (.SecurityDataBase.Rows.Count < 0) return new XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase[0];

                DataRow dataRow_NewRecord = null;

                ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable securityDataBaseDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase;

                /////////////////////////////////////////

                XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase[] securityDataBaseArray_obj = new XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase[securityDataBaseDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != securityDataBaseDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows[int_CycleCount];

                    securityDataBaseArray_obj[int_CycleCount] = new XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase();

                    securityDataBaseArray_obj[int_CycleCount].UserName = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserNameColumn];
                    securityDataBaseArray_obj[int_CycleCount].Login = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserLoginColumn];
                    securityDataBaseArray_obj[int_CycleCount].Password = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserPasswordColumn];

                    securityDataBaseArray_obj[int_CycleCount].CreationTime = (DateTime)dataRow_NewRecord[securityDataBaseDataTable_obj.CreationTimeColumn];

                    securityDataBaseArray_obj[int_CycleCount].IsAccountEnabled = (bool)dataRow_NewRecord[securityDataBaseDataTable_obj.EnabledAccountStateColumn];
                }

                return securityDataBaseArray_obj;
            }

            public ClientsAccessRestrictionRule[] GetClientsAccessRestrictionRules()
            {
                if (JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Count < 0) return new AccessRestrictionRule[0];

                DataRow dataRow_NewRecord = null;

                DataSet_JurikSoftServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules;

                ////////////////////////////////////////////////////////////////////////////////

                AccessRestrictionRule[] accessRestrictionRuleArray_obj = new AccessRestrictionRule[accessRestrictionRulesDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != accessRestrictionRulesDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows[int_CycleCount];

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
            

            public void RemoveClientsSecurityDataBaseRow(int int_RowIndex)
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveClientsAccessRestrictionRulesDataBaseRow(int int_RowIndex)
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveClientsEventsLogDataBaseRow(int int_RowIndex)
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.RemoveAt(int_RowIndex);
            }


            public void ClearClientsSecurityDataBase()
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.Clear();
            }

            public void ClearClientsAccessRestrictionRulesDataBase()
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Clear();
            }

            public void ClearClientsEventsLogDataBase()
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.Clear();
            }





            public class ServersSecurityDataBase : MarshalByRefObject
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

            public class ServersAccessRestrictionRule : MarshalByRefObject
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
            

            public ServersSecurityDataBase[] GetServersSecurityDataBase()
            {
                if (JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.Count < 0) return new XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase[0];

                DataRow dataRow_NewRecord = null;

                DataSet_JurikSoftServerDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase;

                /////////////////////////////////////////

                XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase[] securityDataBaseArray_obj = new XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase[securityDataBaseDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != securityDataBaseDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows[int_CycleCount];

                    securityDataBaseArray_obj[int_CycleCount] = new XMLConfigImporer.JSServerDBEnvironment.SecurityDataBase();

                    securityDataBaseArray_obj[int_CycleCount].UserName = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserNameColumn];
                    securityDataBaseArray_obj[int_CycleCount].Login = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserLoginColumn];
                    securityDataBaseArray_obj[int_CycleCount].Password = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserPasswordColumn];

                    securityDataBaseArray_obj[int_CycleCount].CreationTime = (DateTime)dataRow_NewRecord[securityDataBaseDataTable_obj.CreationTimeColumn];

                    securityDataBaseArray_obj[int_CycleCount].IsAccountEnabled = (bool)dataRow_NewRecord[securityDataBaseDataTable_obj.EnabledAccountStateColumn];
                }

                return securityDataBaseArray_obj;
            }

            public ServersAccessRestrictionRule[] GetServersAccessRestrictionRules()
            {
                if (JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Count < 0) return new AccessRestrictionRule[0];

                DataRow dataRow_NewRecord = null;

                DataSet_JurikSoftServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules;

                ////////////////////////////////////////////////////////////////////////////////

                AccessRestrictionRule[] accessRestrictionRuleArray_obj = new AccessRestrictionRule[accessRestrictionRulesDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != accessRestrictionRulesDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows[int_CycleCount];

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


            public void RemoveServersSecurityDataBaseRow(int int_RowIndex)
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveServersAccessRestrictionRulesDataBaseRow(int int_RowIndex)
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveServersEventsLogDataBaseRow(int int_RowIndex)
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.RemoveAt(int_RowIndex);
            }


            public void ClearServersSecurityDataBase()
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.SecurityDataBase.Rows.Clear();
            }

            public void ClearServersAccessRestrictionRulesDataBase()
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.AccessRestrictionRules.Rows.Clear();
            }

            public void ClearServersEventsLogDataBase()
            {
                JsRctServerV110XMLConfigImporter.JurikSoftServerDB.EventsLog.Rows.Clear();
            }



        }
        
        namespace JSCconnectingService
        {      
            namespace Version10
            {
                public class JsConnectingServiceV10XMLConfigImporter
                {
                    static DataSet_ConnectingServiceDB dataSet_ConnectingServiceDB = new ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB();

                    public static DataSet_ConnectingServiceDB ConnectingServiceDB
                    {
                        get
                        {
                            return dataSet_ConnectingServiceDB;
                        }

                        set
                        {
                            dataSet_ConnectingServiceDB = value;
                        }
                    }

                    public void ApplyDBSettings()
                    {
                        if (ConnectingServiceDB.Tables["MainSettings"].Rows.Count < 1) throw (new Exception());

                        if (ConnectingServiceDB.Tables["MainSettings"].Rows.Count < 1) return;

                        ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.MainSettingsDataTable mainSettingsDataTable_obj = JurikSoftClientDB.MainSettings;

                        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = JurikSoftClientDB.ProxyServersSettings;


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

                    public void InitProxyServersSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = JurikSoftClientDB.ProxyServersSettings;

                            JurikSoftClientDB.ProxyServersSettings.Rows.Clear();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftClientDB.ProxyServersSettings.NewRow();

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

                            JurikSoftClientDB.ProxyServersSettings.Rows.Add(dataRow_NewRecord);

                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("JurikSoftClientDB")) File.Delete("JurikSoftClientDB");

                            MessageBox.Show(ClientStringFactory.GetString(480, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                    public void InitMainClientSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.MainSettingsDataTable mainSettingsDataTable_obj = JurikSoftClientDB.MainSettings;

                            dataRow_NewRecord = JurikSoftClientDB.MainSettings.NewRow();

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

                            dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedFilesPathColumn] = "C:\\juriksoft\\downloads\\files\\";
                            dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedScreenShotsPathColumn] = "C:\\juriksoft\\downloads\\images\\";

                            dataRow_NewRecord[mainSettingsDataTable_obj.ProxyServerIDColumn] = 0;

                            dataRow_NewRecord[mainSettingsDataTable_obj.CurrentAppLanguageColumn] = ClientSettingsEnvironment.CurrentLanguage;

                            dataRow_NewRecord[mainSettingsDataTable_obj.ServerHostColumn] = "localhost";
                            dataRow_NewRecord[mainSettingsDataTable_obj.ServerPortColumn] = 5544;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ServerLoginColumn] = String.Empty;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ServerPasswordColumn] = String.Empty;

                            
                             //   0 - AES 128 bit
                             //   1 - AES 256 bit
                             //   2 - DES 64 bit
                             //   3 - RC2 40 bit
                             //   4 - RC2 128 bit
                             //   5 - TripleDES 128 bit
                             //   6 - TripleDES 192 bit
                            

                            dataRow_NewRecord[mainSettingsDataTable_obj.SentFilesEncryptAlgorithmIndexColumn] = 1;
                            dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedFilesEncryptAlgorithmIndexColumn] = 1;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedScreenshotsEncryptAlgorithmIndexColumn] = 0;
                            dataRow_NewRecord[mainSettingsDataTable_obj.SendingSystemDataEncryptAlgorithmIndexColumn] = 1;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedSystemDataEncryptAlgorithmIndexColumn] = 1;


                            
                              //  0 - Adaptive Prefix codes
                              //  1 - Non-Adaptive Prefix codes
                              //  2 - LZSS
                              //  3 - RLE
                           

                            dataRow_NewRecord[mainSettingsDataTable_obj.SentFilesCompressAlgorithmIndexColumn] = 3;
                            dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedFilesCompressAlgorithmIndexColumn] = 3;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedScreenshotsCompressAlgorithmIndexColumn] = 3;
                            dataRow_NewRecord[mainSettingsDataTable_obj.SendingSystemDataCompressAlgorithmIndexColumn] = 0;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ReceivedSystemDataCompressAlgorithmIndexColumn] = 3;

                            dataRow_NewRecord[mainSettingsDataTable_obj.RememberLoginsColumn] = ClientSettingsEnvironment.RememberLogins;
                            dataRow_NewRecord[mainSettingsDataTable_obj.RememberPasswordsColumn] = ClientSettingsEnvironment.RememberPasswords;

                            JurikSoftClientDB.MainSettings.Rows.Add(dataRow_NewRecord);

                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("JurikSoftClientDB")) File.Delete("JurikSoftClientDB");

                            MessageBox.Show(ClientStringFactory.GetString(480, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                    public void RetriveClientSettingsData(MemoryStream memoryStream_XMLData)
                    {
                        try
                        {
                            JurikSoftClientDB.Clear();

                            JurikSoftClientDB.ReadXml(memoryStream_XMLData);
                        }
                        catch (Exception exception_obj)
                        {
                            InitProxyServersSettingsXmlDB();

                            InitMainClientSettingsXmlDB();

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

        */

        namespace JsRctClient
        {
            namespace Version090
            {
                public class JsRctClientV090XMLConfigImporter
                {
                    static DataSet_Client_Ver090.DataSet_JurikSoftClientDB dataSet_JurikSoftClientDB = new DataSet_Client_Ver090.DataSet_JurikSoftClientDB();

                    public static DataSet_Client_Ver090.DataSet_JurikSoftClientDB JurikSoftClientDB
                    {
                        get
                        {
                            return dataSet_JurikSoftClientDB;
                        }

                        set
                        {
                            dataSet_JurikSoftClientDB = value;
                        }
                    }

                    public void ApplyDBSettings()
                    {
                        if (JurikSoftClientDB.Tables["MainSettings"].Rows.Count < 1) throw (new Exception());

                        if (JurikSoftClientDB.Tables["MainSettings"].Rows.Count < 1) return;

                        DataSet_Client_Ver090.DataSet_JurikSoftClientDB.MainSettingsDataTable mainSettingsDataTable_obj = JurikSoftClientDB.MainSettings;

                        DataSet_Client_Ver090.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = JurikSoftClientDB.ProxyServersSettings;


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
                            JsRctClientV090XMLConfigImporter.JurikSoftClientDB.Clear();

                            JsRctClientV090XMLConfigImporter.JurikSoftClientDB.ReadXml(memoryStream_XMLData);

                            ApplyDBSettings();
                        }

                        catch (Exception exception_obj)
                        {
                            new JsRctClientV110XMLConfigImporter().RetriveClientSettingsData(memoryStream_XMLData);
                        }
                    }
                }
            }

            namespace Version110
            {
                public class JsRctClientV110XMLConfigImporter
                {
                    static DataSet_Client_Ver110.DataSet_JurikSoftClientDB dataSet_JurikSoftClientDB = new DataSet_Client_Ver110.DataSet_JurikSoftClientDB();

                    public static DataSet_Client_Ver110.DataSet_JurikSoftClientDB JurikSoftClientDB
                    {
                        get
                        {
                            return dataSet_JurikSoftClientDB;
                        }

                        set
                        {
                            dataSet_JurikSoftClientDB = value;
                        }
                    }

                    public void ApplyDBSettings()
                    {
                        if (JurikSoftClientDB.Tables["MainSettings"].Rows.Count < 1) throw (new Exception());

                        if (JurikSoftClientDB.Tables["MainSettings"].Rows.Count < 1) return;

                        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.MainSettingsDataTable mainSettingsDataTable_obj = JurikSoftClientDB.MainSettings;

                        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = JurikSoftClientDB.ProxyServersSettings;
                        
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

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_ProxySettingsDataTable cSPForm_ProxySettingsDataTable_obj = JurikSoftClientDB.CSPForm_ProxySettings;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = JurikSoftClientDB.CSPForm_ServerAuthentication;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = JurikSoftClientDB.CSPForm_UINAccountStateSettings;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_CSPServersListDataTable cSPForm_CSPServersListDataTable_obj = JurikSoftClientDB.CSPForm_CSPServersList;
                            

                            ClientSettingsEnvironment.CSP_CSPServersList_Password = (string)cSPForm_CSPServersListDataTable_obj.Rows[0][cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_PasswordColumn];
                            ClientSettingsEnvironment.CSP_CSPServersList_UIN = (string)cSPForm_CSPServersListDataTable_obj.Rows[0][cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UINColumn];
                            ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServiceIPAddress = (string)cSPForm_CSPServersListDataTable_obj.Rows[0][cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServiceIPAddressColumn];
                            ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServicePort = (int)cSPForm_CSPServersListDataTable_obj.Rows[0][cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServicePortColumn];
                            ClientSettingsEnvironment.CSP_CSPServersList_UseJurikSoftCSPServer = (bool)cSPForm_CSPServersListDataTable_obj.Rows[0][cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UseJurikSoftCSPServerColumn];

                            ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort = (int)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_JSRCTLogin = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_JSRCTLoginColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_JSRCTPassword = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_JSRCTPasswordColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_CSPServerUIN = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPServerUINColumn];
                            ClientSettingsEnvironment.CSP_ServerAuth_UseJurikSoftCSPServer = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseJurikSoftCSPServerColumn];
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
                            ClientSettingsEnvironment.CSP_ChangeUINAccountState_UseJurikSoftCSPServer = (bool)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseJurikSoftCSPServerColumn];
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

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = JurikSoftClientDB.ProxyServersSettings;

                            JurikSoftClientDB.ProxyServersSettings.Rows.Clear();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftClientDB.ProxyServersSettings.NewRow();

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

                            JurikSoftClientDB.ProxyServersSettings.Rows.Add(dataRow_NewRecord);

                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("JurikSoftClientDB")) File.Delete("JurikSoftClientDB");

                            MessageBox.Show(ClientStringFactory.GetString(480, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                    public void InitMainClientSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.MainSettingsDataTable mainSettingsDataTable_obj = JurikSoftClientDB.MainSettings;

                            dataRow_NewRecord = JurikSoftClientDB.MainSettings.NewRow();

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

                            dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedFilesPathColumn] = "C:\\juriksoft\\downloads\\files\\";
                            dataRow_NewRecord[mainSettingsDataTable_obj.DownloadedScreenShotsPathColumn] = "C:\\juriksoft\\downloads\\images\\";

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

                            JurikSoftClientDB.MainSettings.Rows.Add(dataRow_NewRecord);

                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("JurikSoftClientDB")) File.Delete("JurikSoftClientDB");

                            MessageBox.Show(ClientStringFactory.GetString(480, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                    public void InitCSPSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_ProxySettingsDataTable cSPForm_ProxySettingsDataTable_obj = JurikSoftClientDB.CSPForm_ProxySettings;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = JurikSoftClientDB.CSPForm_ServerAuthentication;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = JurikSoftClientDB.CSPForm_UINAccountStateSettings;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_CSPServersListDataTable cSPForm_CSPServersListDataTable_obj = JurikSoftClientDB.CSPForm_CSPServersList;

                            JurikSoftClientDB.CSPForm_ProxySettings.Rows.Clear();
                            JurikSoftClientDB.CSPForm_ServerAuthentication.Rows.Clear();
                            JurikSoftClientDB.CSPForm_UINAccountStateSettings.Rows.Clear();
                            JurikSoftClientDB.CSPForm_CSPServersList.Rows.Clear();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftClientDB.CSPForm_ProxySettings.NewRow();

                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_UseAuthenticationColumn] = true;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ResolveHostNamesColumn] = true;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_UseProxyColumn] = true;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyHostColumn] = "";
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyPortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_Socks5UserNameColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_Socks5PasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyTimeOutIndexColumn] = 0;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyTypeIndexColumn] = 0;

                            JurikSoftClientDB.CSPForm_ProxySettings.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftClientDB.CSPForm_CSPServersList.NewRow();

                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_PasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServiceIPAddressColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServicePortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UseJurikSoftCSPServerColumn] = true;

                            JurikSoftClientDB.CSPForm_CSPServersList.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftClientDB.CSPForm_UINAccountStateSettings.NewRow();

                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_GetActivationCodeColumn] = true;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseJurikSoftCSPServerColumn] = true;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServiceIPAddressColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServicePortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_PasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINActivationCodeColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_NewAccountStateIndexColumn] = 0;

                            JurikSoftClientDB.CSPForm_UINAccountStateSettings.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftClientDB.CSPForm_ServerAuthentication.NewRow();

                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_JSRCTLoginColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_JSRCTPasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPServerUINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseJurikSoftCSPServerColumn] = true;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_WaitForServerColumn] = true;

                            JurikSoftClientDB.CSPForm_ServerAuthentication.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();
                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("JurikSoftClientDB")) File.Delete("JurikSoftClientDB");

                            MessageBox.Show(ClientStringFactory.GetString(480, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }
                    public void SaveCSPSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_ProxySettingsDataTable cSPForm_ProxySettingsDataTable_obj = JurikSoftClientDB.CSPForm_ProxySettings;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = JurikSoftClientDB.CSPForm_ServerAuthentication;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = JurikSoftClientDB.CSPForm_UINAccountStateSettings;

                            DataSet_Client_Ver110.DataSet_JurikSoftClientDB.CSPForm_CSPServersListDataTable cSPForm_CSPServersListDataTable_obj = JurikSoftClientDB.CSPForm_CSPServersList;

                            JurikSoftClientDB.CSPForm_ProxySettings.Rows.Clear();
                            JurikSoftClientDB.CSPForm_ServerAuthentication.Rows.Clear();
                            JurikSoftClientDB.CSPForm_UINAccountStateSettings.Rows.Clear();
                            JurikSoftClientDB.CSPForm_CSPServersList.Rows.Clear();

                  
                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftClientDB.CSPForm_ServerAuthentication.NewRow();

                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn] = ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn] = ClientSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn] = ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn] = ClientSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_JSRCTLoginColumn] = ClientSettingsEnvironment.CSP_ServerAuth_JSRCTLogin;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_JSRCTPasswordColumn] = ClientSettingsEnvironment.CSP_ServerAuth_JSRCTPassword;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPServerUINColumn] = ClientSettingsEnvironment.CSP_ServerAuth_CSPServerUIN;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseJurikSoftCSPServerColumn] = ClientSettingsEnvironment.CSP_ServerAuth_UseJurikSoftCSPServer;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_WaitForServerColumn] = ClientSettingsEnvironment.CSP_ServerAuth_WaitForServer;

                            JurikSoftClientDB.CSPForm_ServerAuthentication.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftClientDB.CSPForm_ProxySettings.NewRow();

                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_UseAuthenticationColumn] = ClientSettingsEnvironment.CSP_ProxySettings_Authentication;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ResolveHostNamesColumn] = ClientSettingsEnvironment.CSP_ProxySettings_ResolveHostNames;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_UseProxyColumn] = ClientSettingsEnvironment.CSP_ProxySettings_UseProxy;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyHostColumn] = ClientSettingsEnvironment.CSP_ProxySettings_ProxyHost;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyPortColumn] = ClientSettingsEnvironment.CSP_ProxySettings_ProxyPort;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_Socks5UserNameColumn] = ClientSettingsEnvironment.CSP_ProxySettings_Socks5UserName;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_Socks5PasswordColumn] = ClientSettingsEnvironment.CSP_ProxySettings_Socks5Password;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyTimeOutIndexColumn] = ClientSettingsEnvironment.CSP_ProxySettings_ProxyTimeOutIndex;
                            dataRow_NewRecord[cSPForm_ProxySettingsDataTable_obj.CSP_ProxySettings_ProxyTypeIndexColumn] = ClientSettingsEnvironment.CSP_ProxySettings_ProxyTypeIndex;

                            JurikSoftClientDB.CSPForm_ProxySettings.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftClientDB.CSPForm_CSPServersList.NewRow();

                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_PasswordColumn] = ClientSettingsEnvironment.CSP_CSPServersList_Password;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UINColumn] = ClientSettingsEnvironment.CSP_CSPServersList_UIN;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServiceIPAddressColumn] = ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServiceIPAddress;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_CustomCSPServicePortColumn] = ClientSettingsEnvironment.CSP_CSPServersList_CustomCSPServicePort;
                            dataRow_NewRecord[cSPForm_CSPServersListDataTable_obj.CSP_CSPServersList_UseJurikSoftCSPServerColumn] = ClientSettingsEnvironment.CSP_CSPServersList_UseJurikSoftCSPServer;

                            JurikSoftClientDB.CSPForm_CSPServersList.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftClientDB.CSPForm_UINAccountStateSettings.NewRow();

                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_GetActivationCodeColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_GetActivationCode;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseJurikSoftCSPServerColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_UseJurikSoftCSPServer;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServiceIPAddressColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServiceIPAddress;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServicePortColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServicePort;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_UIN;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_PasswordColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_Password;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINActivationCodeColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_UINActivationCode;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_NewAccountStateIndexColumn] = ClientSettingsEnvironment.CSP_ChangeUINAccountState_NewAccountStateIndex;

                            JurikSoftClientDB.CSPForm_UINAccountStateSettings.Rows.Add(dataRow_NewRecord);

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
                            JurikSoftClientDB.Clear();

                            JurikSoftClientDB.ReadXml(memoryStream_XMLData);
                        }
                        catch (Exception exception_obj)
                        {
                            JurikSoftClientDB.Clear();

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

        namespace JsRctServer
        {
            namespace Version090
            {
                public class JsRctServerV090XMLConfigImporter
                {
                    static DataSet_Server_Ver090.DataSet_JurikSoftServerDB dataSet_JurikSoftServerDB = new DataSet_Server_Ver090.DataSet_JurikSoftServerDB();

                    public static DataSet_Server_Ver090.DataSet_JurikSoftServerDB JurikSoftServerDB
                    {
                        get
                        {
                            return dataSet_JurikSoftServerDB;
                        }

                        set
                        {
                            dataSet_JurikSoftServerDB = value;
                        }
                    }

                    public void ApplyDBSettings()
                    {
                        if (dataSet_JurikSoftServerDB.Tables["MainSettings"].Rows.Count < 1) throw (new Exception());

                        if (dataSet_JurikSoftServerDB.Tables["MainSettings"].Rows.Count < 1) return;

                        DataSet_Server_Ver090.DataSet_JurikSoftServerDB.MainSettingsDataTable mainSettingsDataTable_obj = dataSet_JurikSoftServerDB.MainSettings;

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
                            JsRctServerV090XMLConfigImporter.JurikSoftServerDB.Clear();

                            JsRctServerV090XMLConfigImporter.JurikSoftServerDB.ReadXml(memoryStream_XMLData);

                            ApplyDBSettings();
                        }

                        catch (Exception exception_obj)
                        {
                            new JsRctServerV110XMLConfigImporter().RetriveServerSettingsData(memoryStream_XMLData);
                        }
                    }
                }
            }

            namespace Version110
            {
                public class JsRctServerV110XMLConfigImporter : MarshalByRefObject
                {
                    static DataSet_Server_Ver110.DataSet_JurikSoftServerDB dataSet_JurikSoftServerDB = new DataSet_Server_Ver110.DataSet_JurikSoftServerDB();

                    public static DataSet_Server_Ver110.DataSet_JurikSoftServerDB JurikSoftServerDB
                    {
                        get
                        {
                            return dataSet_JurikSoftServerDB;
                        }

                        set
                        {
                            dataSet_JurikSoftServerDB = value;
                        }
                    }

                    public DataSet_Server_Ver110.DataSet_JurikSoftServerDB RemotingWrapper_JurikSoftServerDB
                    {
                        get
                        {
                            return JsRctServerV110XMLConfigImporter.JurikSoftServerDB;
                        }

                        set
                        {
                            JsRctServerV110XMLConfigImporter.JurikSoftServerDB = value;
                        }
                    }

                    public void ApplyDBSettings()
                    {
                        if (dataSet_JurikSoftServerDB.Tables["MainSettings"].Rows.Count < 1) InitMainServerSettingsXmlDB();

                        if (dataSet_JurikSoftServerDB.Tables["MainSettings"].Rows.Count < 1) return;

                        DataSet_Server_Ver110.DataSet_JurikSoftServerDB.MainSettingsDataTable mainSettingsDataTable_obj = dataSet_JurikSoftServerDB.MainSettings;

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

                        if (dataSet_JurikSoftServerDB.Tables["CommonSecuritySettings"].Rows.Count < 1) InitCommonSecuritySettingsXmlDB();

                        if (dataSet_JurikSoftServerDB.Tables["CommonSecuritySettings"].Rows.Count < 1) return;

                        DataSet_Server_Ver110.DataSet_JurikSoftServerDB.CommonSecuritySettingsDataTable commonSecuritySettingsDataTable_obj = dataSet_JurikSoftServerDB.CommonSecuritySettings;


                        ServerSettingsEnvironment.MaxConnections = (int)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.MaxConnectionsColumn];

                        ServerSettingsEnvironment.MaxConnectionsPerAccount = (int)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.MaxConnectionPerAccountColumn];

                        ServerSettingsEnvironment.EnableAccessRestrictionRules = (bool)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.EnableAccessRestrictionsColumn];

                        ServerSettingsEnvironment.IsWindowsAuthenticationAllowed = (bool)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.AllowWindowsAccountsColumn];

                        ServerSettingsEnvironment.MinRSAPublicKeyLength = (int)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.MinRSAKeySizeColumn];
                        ServerSettingsEnvironment.MaxRSAPublicKeyLength = (int)commonSecuritySettingsDataTable_obj.Rows[0][commonSecuritySettingsDataTable_obj.MaxRSAKeySizeColumn];


                        try
                        {
                            DataSet_Server_Ver110.DataSet_JurikSoftServerDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = JurikSoftServerDB.CSPForm_ServerAuthentication;

                            DataSet_Server_Ver110.DataSet_JurikSoftServerDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = JurikSoftServerDB.CSPForm_UINAccountStateSettings;

                            ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort = (int)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN = (string)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_UseJurikSoftCSPServer = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseJurikSoftCSPServerColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_IsPublicServer = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_IsPublicServerColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_HideIP = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_HideIPColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_KeepConnectionAlive = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_KeepConnectionAliveColumn];
                            ServerSettingsEnvironment.CSP_ServerAuth_ConnectAtStartUp = (bool)cSPForm_ServerAuthenticationDataTable_obj.Rows[0][cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_ConnectAtStartUpColumn];
                            
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_GetActivationCode = (bool)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_GetActivationCodeColumn];
                            ServerSettingsEnvironment.CSP_ChangeUINAccountState_UseJurikSoftCSPServer = (bool)cSPForm_UINAccountStateSettingsDataTable_obj.Rows[0][cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseJurikSoftCSPServerColumn];
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

                            DataSet_Server_Ver110.DataSet_JurikSoftServerDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = JurikSoftServerDB.CSPForm_ServerAuthentication;

                            DataSet_Server_Ver110.DataSet_JurikSoftServerDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = JurikSoftServerDB.CSPForm_UINAccountStateSettings;

                            JurikSoftServerDB.CSPForm_ServerAuthentication.Rows.Clear();
                            JurikSoftServerDB.CSPForm_UINAccountStateSettings.Rows.Clear();
                                                                                 
                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftServerDB.CSPForm_UINAccountStateSettings.NewRow();

                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_GetActivationCodeColumn] = true;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseJurikSoftCSPServerColumn] = true;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServiceIPAddressColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServicePortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_PasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINActivationCodeColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_NewAccountStateIndexColumn] = 0;

                            JurikSoftServerDB.CSPForm_UINAccountStateSettings.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftServerDB.CSPForm_ServerAuthentication.NewRow();

                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn] = 5545;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn] = String.Empty;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseJurikSoftCSPServerColumn] = true;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_IsPublicServerColumn] = true;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_HideIPColumn] = true;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_KeepConnectionAliveColumn] = true;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_ConnectAtStartUpColumn] = true;                            

                            JurikSoftServerDB.CSPForm_ServerAuthentication.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();
                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("JurikSoftServerDB")) File.Delete("JurikSoftServerDB");

                            MessageBox.Show(ServerStringFactory.GetString(480, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }
                    public void SaveCSPSettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            DataSet_Server_Ver110.DataSet_JurikSoftServerDB.CSPForm_ServerAuthenticationDataTable cSPForm_ServerAuthenticationDataTable_obj = JurikSoftServerDB.CSPForm_ServerAuthentication;

                            DataSet_Server_Ver110.DataSet_JurikSoftServerDB.CSPForm_UINAccountStateSettingsDataTable cSPForm_UINAccountStateSettingsDataTable_obj = JurikSoftServerDB.CSPForm_UINAccountStateSettings;

                            JurikSoftServerDB.CSPForm_ServerAuthentication.Rows.Clear();
                            JurikSoftServerDB.CSPForm_UINAccountStateSettings.Rows.Clear();
                            
                            ////////////////////////////////////////////////////////////////////////////////

                            dataRow_NewRecord = JurikSoftServerDB.CSPForm_ServerAuthentication.NewRow();

                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServiceIPAddressColumn] = ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServiceIPAddress;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CustomCSPServicePortColumn] = ServerSettingsEnvironment.CSP_ServerAuth_CustomCSPServicePort;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginPasswordColumn] = ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginPassword;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_CSPLoginUINColumn] = ServerSettingsEnvironment.CSP_ServerAuth_CSPLoginUIN;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_UseJurikSoftCSPServerColumn] = ServerSettingsEnvironment.CSP_ServerAuth_UseJurikSoftCSPServer;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_IsPublicServerColumn] = ServerSettingsEnvironment.CSP_ServerAuth_IsPublicServer;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_HideIPColumn] = ServerSettingsEnvironment.CSP_ServerAuth_HideIP;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_KeepConnectionAliveColumn] = ServerSettingsEnvironment.CSP_ServerAuth_KeepConnectionAlive;
                            dataRow_NewRecord[cSPForm_ServerAuthenticationDataTable_obj.CSP_ServerAuth_ConnectAtStartUpColumn] = ServerSettingsEnvironment.CSP_ServerAuth_ConnectAtStartUp;   

                            JurikSoftServerDB.CSPForm_ServerAuthentication.Rows.Add(dataRow_NewRecord);

                            dataRow_NewRecord.AcceptChanges();

                            ////////////////////////////////////////////////////////////////////////////////
                       
                            dataRow_NewRecord = JurikSoftServerDB.CSPForm_UINAccountStateSettings.NewRow();

                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_GetActivationCodeColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_GetActivationCode;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UseJurikSoftCSPServerColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_UseJurikSoftCSPServer;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServiceIPAddressColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServiceIPAddress;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_CustomCSPServicePortColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_CustomCSPServicePort;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_UIN;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_PasswordColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_Password;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_UINActivationCodeColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_UINActivationCode;
                            dataRow_NewRecord[cSPForm_UINAccountStateSettingsDataTable_obj.CSP_ChangeUINAccountState_NewAccountStateIndexColumn] = ServerSettingsEnvironment.CSP_ChangeUINAccountState_NewAccountStateIndex;

                            JurikSoftServerDB.CSPForm_UINAccountStateSettings.Rows.Add(dataRow_NewRecord);

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

                            DataSet_Server_Ver110.DataSet_JurikSoftServerDB.MainSettingsDataTable mainSettingsDataTable_obj = JurikSoftServerDB.MainSettings;

                            JurikSoftServerDB.MainSettings.Clear();

                            dataRow_NewRecord = dataSet_JurikSoftServerDB.MainSettings.NewRow();

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

                            JurikSoftServerDB.MainSettings.Rows.Add(dataRow_NewRecord);
                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("JurikSoftServerDB")) File.Delete("JurikSoftServerDB");

                            MessageBox.Show(ServerStringFactory.GetString(127, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                    public void InitCommonSecuritySettingsXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            DataSet_Server_Ver110.DataSet_JurikSoftServerDB.CommonSecuritySettingsDataTable commonSecuritySettingsDataTable_obj = dataSet_JurikSoftServerDB.CommonSecuritySettings;

                            dataSet_JurikSoftServerDB.CommonSecuritySettings.Clear();

                            dataRow_NewRecord = dataSet_JurikSoftServerDB.CommonSecuritySettings.NewRow();

                            dataRow_NewRecord.ItemArray.Initialize();

                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.AllowWindowsAccountsColumn] = false;
                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.EnableAccessRestrictionsColumn] = false;

                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MinRSAKeySizeColumn] = 256;
                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxRSAKeySizeColumn] = 8192;

                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxConnectionsColumn] = 255;
                            dataRow_NewRecord[commonSecuritySettingsDataTable_obj.MaxConnectionPerAccountColumn] = 255;

                            dataSet_JurikSoftServerDB.CommonSecuritySettings.Rows.Add(dataRow_NewRecord);

                        }
                        catch (Exception exception_obj)
                        {
                            if (File.Exists("JurikSoftServerDB")) File.Delete("JurikSoftServerDB");

                            MessageBox.Show(ServerStringFactory.GetString(127, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                    public void RetriveServerSettingsData(MemoryStream memoryStream_XMLData)
                    {
                        try
                        {
                            JurikSoftServerDB.Clear();

                            JurikSoftServerDB.ReadXml(memoryStream_XMLData);
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