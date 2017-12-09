using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using YakSysConnectingService;


public class ConnectingServiceDBSupplier
{
    static DataSet_ConnectingServiceDB dataSet_ConnectingServiceDB = new DataSet_ConnectingServiceDB();
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


    public static MemoryStream DecompressXMLDataFile(string string_XMLFilePath)
    {
        FileStream fileStream_ConnectingServiceXMLDB = null;

        try
        {
            if (File.Exists(string_XMLFilePath) == false) return null;

            MemoryStream memoryStream_XMLData = new MemoryStream();

            fileStream_ConnectingServiceXMLDB = File.Open(string_XMLFilePath, FileMode.Open, FileAccess.Read);

            byte[] byteArray_DecompressedXMLData = null,
                byteArray_CompressedXMLData = new byte[fileStream_ConnectingServiceXMLDB.Length - 88];// 88 is a meta data length in bytes

            fileStream_ConnectingServiceXMLDB.Position = 88;

            fileStream_ConnectingServiceXMLDB.Read(byteArray_CompressedXMLData, 0, byteArray_CompressedXMLData.Length);

            byteArray_DecompressedXMLData = new YakSys.Compression.CommonEnvironment().Decompress(byteArray_CompressedXMLData, false);

            memoryStream_XMLData = new MemoryStream(byteArray_DecompressedXMLData);

            return memoryStream_XMLData;
        }

        catch (Exception exception)
        {
            return null;
        }

        finally
        {
            fileStream_ConnectingServiceXMLDB.Close();
        }
    }


    public void WriteXMLDataToFile(string string_XMLFilePath)
    {
        FileStream fileStream_ServerDB = File.Create(string_XMLFilePath);

        MemoryStream memoryStream_XMLData = new MemoryStream(),
            memoryStream_EncryptedXMLData = new MemoryStream();

        SHA256Managed sHA256Managed_obj = new SHA256Managed();

        RijndaelManaged rijndaelManaged_obj = new RijndaelManaged();

        CryptoStream cryptoStream_obj = null;

        byte[] byteArray_ComputedXMLDataHash = new byte[32], byteArray_PasswordHash = new byte[32],
                byteArray_EncryptedData = null, byteArray_CompressedXMLData,
                byteArray_HashOfPasswordHash = new byte[32];

        byte byte_ToEncryptServerDataBase = 0, byte_ToCompressSettingsDataBase = 0;

        ConnectingServiceDB.WriteXml(memoryStream_XMLData);


        if (CommonEnvironment.EncryptSettingsDataBase == true) byte_ToEncryptServerDataBase = 1;
        if (CommonEnvironment.CompressSettingsDataBase == true) byte_ToCompressSettingsDataBase = 1;


        if (CommonEnvironment.CompressSettingsDataBase == true)
        {
            YakSys.Compression.LZSS lZSS_obj = new YakSys.Compression.LZSS(16, true, true, false, 65536);

            byteArray_CompressedXMLData = lZSS_obj.Compress(memoryStream_XMLData.ToArray(), false);

            memoryStream_XMLData = new MemoryStream(byteArray_CompressedXMLData);
        }

        byteArray_ComputedXMLDataHash = sHA256Managed_obj.ComputeHash(memoryStream_XMLData);

        if (CommonEnvironment.LocalSecurityPassword.Length > 5 && CommonEnvironment.EncryptSettingsDataBase == true)
        {
            byteArray_PasswordHash = sHA256Managed_obj.ComputeHash(System.Text.Encoding.Default.GetBytes(CommonEnvironment.LocalSecurityPassword));
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

        fileStream_ServerDB.Write(System.Text.Encoding.Default.GetBytes("ConnectingServiceDB010"), 0, 22);

        fileStream_ServerDB.WriteByte(byte_ToEncryptServerDataBase);
        fileStream_ServerDB.WriteByte(byte_ToCompressSettingsDataBase);

        fileStream_ServerDB.Write(byteArray_ComputedXMLDataHash, 0, byteArray_ComputedXMLDataHash.Length);
        fileStream_ServerDB.Write(byteArray_HashOfPasswordHash, 0, byteArray_HashOfPasswordHash.Length);


        fileStream_ServerDB.Write(memoryStream_XMLData.ToArray(), 0, memoryStream_XMLData.ToArray().Length);

        fileStream_ServerDB.Close();
    }

    public void InitMainServerXmlDB()
    {
        try
        {
            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.MainSettingsDataTable mainSettingsDataTable_obj = ConnectingServiceDB.MainSettings;

            ConnectingServiceDB.MainSettings.Clear();

            dataRow_NewRecord = ConnectingServiceDB.MainSettings.NewRow();

            dataRow_NewRecord.ItemArray.Initialize();

            dataRow_NewRecord[mainSettingsDataTable_obj.IDColumn] = 0;

            dataRow_NewRecord[mainSettingsDataTable_obj.ServerPortColumn] = 5545;

            dataRow_NewRecord[mainSettingsDataTable_obj.AppVersionColumn] = "0.1.0";

            dataRow_NewRecord[mainSettingsDataTable_obj.ShowToolTipsColumn] = true;
            dataRow_NewRecord[mainSettingsDataTable_obj.ShowAdvancedSettingsColumn] = false;

            dataRow_NewRecord[mainSettingsDataTable_obj.AutoRunColumn] = false;
            dataRow_NewRecord[mainSettingsDataTable_obj.StartServerAtRunColumn] = false;
            dataRow_NewRecord[mainSettingsDataTable_obj.MinimizeToNotifyAreaAtRunColumn] = false;
            dataRow_NewRecord[mainSettingsDataTable_obj.ShowIconInNotifyAreaColumn] = true;

            dataRow_NewRecord[mainSettingsDataTable_obj.MaxConnectionsColumn] = 255;
            dataRow_NewRecord[mainSettingsDataTable_obj.MaxConnectionPerAccountColumn] = 255;

            dataRow_NewRecord[mainSettingsDataTable_obj.PromptPasswordAfterUnHideColumn] = false;

            dataRow_NewRecord[mainSettingsDataTable_obj.IsClientAccessRestrictionRuleEnableColumn] = false;
            dataRow_NewRecord[mainSettingsDataTable_obj.IsServerAccessRestrictionRuleEnableColumn] = false;

            dataRow_NewRecord[mainSettingsDataTable_obj.CurrentAppLanguageColumn] = MainForm.CurrentLanguage;

            dataRow_NewRecord[mainSettingsDataTable_obj.ActivateHiddenModeAtStartUpColumn] = false;

            ConnectingServiceDB.MainSettings.Rows.Add(dataRow_NewRecord);

        }
        catch (Exception e)
        {
            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

            MessageBox.Show(StringFactory.GetString(127, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return;
        }
    }

    public void InitSMTPSettingsXmlDB()
    {
        try
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.SMTPSettingsDataTable smtpSettingsDataTable_obj = ConnectingServiceDB.SMTPSettings;

            ConnectingServiceDB.SMTPSettings.Clear();

            dataRow_NewRecord = ConnectingServiceDB.SMTPSettings.NewRow();

            dataRow_NewRecord.ItemArray.Initialize();

            dataRow_NewRecord[smtpSettingsDataTable_obj.IDColumn] = 0;

            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_ServerColumn] = string.Empty;
            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_PortColumn] = 25;

            dataRow_NewRecord[smtpSettingsDataTable_obj.SenderMailAddressColumn] = string.Empty;

            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_LoginColumn] = string.Empty;
            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_PasswordColumn] = string.Empty;

            ConnectingServiceDB.SMTPSettings.Rows.Add(dataRow_NewRecord);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        catch (Exception e)
        {
            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

            MessageBox.Show(StringFactory.GetString(127, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return;
        }
    }


    public void ApplyDBSettings()
    {
        if (ConnectingServiceDB.Tables["MainSettings"].Rows.Count < 1 || ConnectingServiceDB.Tables["SMTPSettings"].Rows.Count < 1)
        {
            InitMainServerXmlDB();
            
            InitSMTPSettingsXmlDB();

            ApplyDBSettings();
        }


        if (ConnectingServiceDB.Tables["MainSettings"].Rows.Count < 1 || ConnectingServiceDB.Tables["SMTPSettings"].Rows.Count < 1) return;

              
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        DataSet_ConnectingServiceDB.MainSettingsDataTable mainSettingsDataTable_obj = ConnectingServiceDB.MainSettings;

        CommonEnvironment.ServerPort = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerPortColumn];

        CommonEnvironment.AppVersion = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.AppVersionColumn];

        CommonEnvironment.ShowToolTips = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowToolTipsColumn];
        CommonEnvironment.ShowAdvancedSettings = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowAdvancedSettingsColumn];

        CommonEnvironment.AutoRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.AutoRunColumn];
        CommonEnvironment.StartServerAtRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.StartServerAtRunColumn];
        CommonEnvironment.MinimizeToNotifyAreaAtRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.MinimizeToNotifyAreaAtRunColumn];
        CommonEnvironment.ShowIconInNotifyArea = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowIconInNotifyAreaColumn];

        CommonEnvironment.MaxConnections = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.MaxConnectionsColumn];

        CommonEnvironment.MaxConnectionsPerAccount = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.MaxConnectionPerAccountColumn];

        CommonEnvironment.IsServerAccessRestrictionRuleEnable = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.IsServerAccessRestrictionRuleEnableColumn];
        CommonEnvironment.IsClientAccessRestrictionRuleEnable = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.IsClientAccessRestrictionRuleEnableColumn];

        CommonEnvironment.ActivateHiddenModeAtStartUp = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ActivateHiddenModeAtStartUpColumn];

        MainForm.CurrentLanguage = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.CurrentAppLanguageColumn];
                           
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
           
        DataSet_ConnectingServiceDB.SMTPSettingsDataTable smtpSettingsDataTable_obj = ConnectingServiceDB.SMTPSettings;
            
        if (smtpSettingsDataTable_obj.Rows.Count < 1)
        {
            InitSMTPSettingsXmlDB();
        }

        CommonEnvironment.SMTPLogin = (string)smtpSettingsDataTable_obj.Rows[0][smtpSettingsDataTable_obj.SMTP_LoginColumn];
        CommonEnvironment.SMTPPassword = (string)smtpSettingsDataTable_obj.Rows[0][smtpSettingsDataTable_obj.SMTP_PasswordColumn];

        CommonEnvironment.SMTPServer = (string)smtpSettingsDataTable_obj.Rows[0][smtpSettingsDataTable_obj.SMTP_ServerColumn];
        CommonEnvironment.SenderMailAddress = (string)smtpSettingsDataTable_obj.Rows[0][smtpSettingsDataTable_obj.SenderMailAddressColumn];

        CommonEnvironment.SMTPPort = (int)smtpSettingsDataTable_obj.Rows[0][smtpSettingsDataTable_obj.SMTP_PortColumn];
    }

    public void RetriveServerSettingsData(MemoryStream memoryStream_XMLData)
    {
        try
        {
            ConnectingServiceDBSupplier.ConnectingServiceDB.Clear();

            ConnectingServiceDB.ReadXml(memoryStream_XMLData);
        }
        catch (Exception)
        {
            InitMainServerXmlDB();

            MessageBox.Show(StringFactory.GetString(127, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return;
        }

        try
        {
            ApplyDBSettings();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            MessageBox.Show(StringFactory.GetString(128, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));
        }
    }

    public void WriteServerSettingsData(string string_XMLFilePath)
    {
        try
        {
            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.MainSettingsDataTable mainSettingsDataTable_obj = ConnectingServiceDB.MainSettings;

            dataRow_NewRecord = ConnectingServiceDB.MainSettings.Rows[0];

            dataRow_NewRecord[mainSettingsDataTable_obj.ServerPortColumn] = CommonEnvironment.ServerPort;

            dataRow_NewRecord[mainSettingsDataTable_obj.AppVersionColumn] = CommonEnvironment.AppVersion;

            dataRow_NewRecord[mainSettingsDataTable_obj.ShowToolTipsColumn] = CommonEnvironment.ShowToolTips;

            dataRow_NewRecord[mainSettingsDataTable_obj.ShowAdvancedSettingsColumn] = CommonEnvironment.ShowAdvancedSettings;

            dataRow_NewRecord[mainSettingsDataTable_obj.AutoRunColumn] = CommonEnvironment.AutoRun;
            dataRow_NewRecord[mainSettingsDataTable_obj.StartServerAtRunColumn] = CommonEnvironment.StartServerAtRun;
            dataRow_NewRecord[mainSettingsDataTable_obj.MinimizeToNotifyAreaAtRunColumn] = CommonEnvironment.MinimizeToNotifyAreaAtRun;
            dataRow_NewRecord[mainSettingsDataTable_obj.ShowIconInNotifyAreaColumn] = CommonEnvironment.ShowIconInNotifyArea;

            dataRow_NewRecord[mainSettingsDataTable_obj.MaxConnectionsColumn] = CommonEnvironment.MaxConnections;

            dataRow_NewRecord[mainSettingsDataTable_obj.IsClientAccessRestrictionRuleEnableColumn] = CommonEnvironment.IsClientAccessRestrictionRuleEnable;
            dataRow_NewRecord[mainSettingsDataTable_obj.IsServerAccessRestrictionRuleEnableColumn] = CommonEnvironment.IsServerAccessRestrictionRuleEnable;

            dataRow_NewRecord[mainSettingsDataTable_obj.ActivateHiddenModeAtStartUpColumn] = CommonEnvironment.ActivateHiddenModeAtStartUp;

            dataRow_NewRecord[mainSettingsDataTable_obj.MaxConnectionPerAccountColumn] = CommonEnvironment.MaxConnectionsPerAccount;

            dataRow_NewRecord[mainSettingsDataTable_obj.CurrentAppLanguageColumn] = MainForm.CurrentLanguage;

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            DataSet_ConnectingServiceDB.SMTPSettingsDataTable smtpSettingsDataTable_obj = ConnectingServiceDB.SMTPSettings;

            if (smtpSettingsDataTable_obj.Rows.Count < 1)
            {
                InitSMTPSettingsXmlDB();
            }

            dataRow_NewRecord = ConnectingServiceDB.SMTPSettings.Rows[0];

            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_ServerColumn] = CommonEnvironment.SMTPServer;
            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_PortColumn] = CommonEnvironment.SMTPPort;

            dataRow_NewRecord[smtpSettingsDataTable_obj.SenderMailAddressColumn] = CommonEnvironment.SenderMailAddress;

            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_LoginColumn] = CommonEnvironment.SMTPLogin;
            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_PasswordColumn] = CommonEnvironment.SMTPPassword;

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            WriteXMLDataToFile(string_XMLFilePath);
        }

        catch (Exception)
        {
            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

            MessageBox.Show(StringFactory.GetString(481, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return;
        }
    }



    public void FillCommonEventsLog()
    {
        try
        {
            if (ConnectingServiceDB.CommonEventsLog.Rows.Count < 0) return;

            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.CommonEventsLogDataTable eventsLogDataTable_obj = ConnectingServiceDB.CommonEventsLog;

            ////////////////////////////////////////////////////////////////////////////////

            string string_LogType, string_LogDate, string_LogTime, string_LogSource, string_LogDescription;

            for (int int_CycleCount = 0; int_CycleCount != eventsLogDataTable_obj.Rows.Count; int_CycleCount++)
            {
                dataRow_NewRecord = ConnectingServiceDB.CommonEventsLog.Rows[int_CycleCount];

                string_LogSource = (string)dataRow_NewRecord[eventsLogDataTable_obj.SourceColumn];
                string_LogType = (string)dataRow_NewRecord[eventsLogDataTable_obj.TypeColumn];
                string_LogDescription = (string)dataRow_NewRecord[eventsLogDataTable_obj.DescriptionColumn];
                string_LogDate = (string)dataRow_NewRecord[eventsLogDataTable_obj.DateColumn];
                string_LogTime = (string)dataRow_NewRecord[eventsLogDataTable_obj.TimeColumn];

                ConnectingServiceLogsEvents.NewCommonLogRecordEvent(string_LogType, string_LogDate, string_LogTime, string_LogSource, string_LogDescription, true);
            }
        }

        catch (Exception)
        {
            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

            MessageBox.Show(StringFactory.GetString(128, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return;
        }
    }
    public void FillServersEventsLog()
    {
        try
        {
            if (ConnectingServiceDB.ServersEventsLog.Rows.Count < 0) return;

            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.ServersEventsLogDataTable eventsLogDataTable_obj = ConnectingServiceDB.ServersEventsLog;

            ////////////////////////////////////////////////////////////////////////////////

            string string_LogType, string_LogDate, string_LogTime, string_LogSource, string_LogDescription, string_UserName, string_UIN;

            for (int int_CycleCount = 0; int_CycleCount != eventsLogDataTable_obj.Rows.Count; int_CycleCount++)
            {
                dataRow_NewRecord = ConnectingServiceDB.ServersEventsLog.Rows[int_CycleCount];

                string_LogSource = (string)dataRow_NewRecord[eventsLogDataTable_obj.SourceColumn];
                string_LogType = (string)dataRow_NewRecord[eventsLogDataTable_obj.TypeColumn];
                string_LogDescription = (string)dataRow_NewRecord[eventsLogDataTable_obj.DescriptionColumn];
                string_LogDate = (string)dataRow_NewRecord[eventsLogDataTable_obj.DateColumn];
                string_LogTime = (string)dataRow_NewRecord[eventsLogDataTable_obj.TimeColumn];
                string_UserName = (string)dataRow_NewRecord[eventsLogDataTable_obj.UserNameColumn];
                string_UIN = (string)dataRow_NewRecord[eventsLogDataTable_obj.UINColumn];

                ConnectingServiceLogsEvents.NewServersLogRecordEvent(string_LogType, string_LogDate, string_LogTime, string_UserName, string_UIN, string_LogSource, string_LogDescription, true);
            }
        }

        catch (Exception)
        {
            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

            MessageBox.Show(StringFactory.GetString(128, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return;
        }
    }
    public void FillClientsEventsLog()
    {
        try
        {
            if (ConnectingServiceDB.ClientsEventsLog.Rows.Count < 0) return;

            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.ClientsEventsLogDataTable eventsLogDataTable_obj = ConnectingServiceDB.ClientsEventsLog;

            ////////////////////////////////////////////////////////////////////////////////

            string string_LogType, string_LogDate, string_LogTime, string_LogSource, string_LogDescription, string_UserName, string_UIN;

            for (int int_CycleCount = 0; int_CycleCount != eventsLogDataTable_obj.Rows.Count; int_CycleCount++)
            {
                dataRow_NewRecord = ConnectingServiceDB.ClientsEventsLog.Rows[int_CycleCount];

                string_LogSource = (string)dataRow_NewRecord[eventsLogDataTable_obj.SourceColumn];
                string_LogType = (string)dataRow_NewRecord[eventsLogDataTable_obj.TypeColumn];
                string_LogDescription = (string)dataRow_NewRecord[eventsLogDataTable_obj.DescriptionColumn];
                string_LogDate = (string)dataRow_NewRecord[eventsLogDataTable_obj.DateColumn];
                string_LogTime = (string)dataRow_NewRecord[eventsLogDataTable_obj.TimeColumn];
                string_UserName = (string)dataRow_NewRecord[eventsLogDataTable_obj.UserNameColumn];
                string_UIN = (string)dataRow_NewRecord[eventsLogDataTable_obj.UINColumn];

                ConnectingServiceLogsEvents.NewClientsLogRecordEvent(string_LogType, string_LogDate, string_LogTime, string_UserName, string_UIN, string_LogSource, string_LogDescription, true);
            }
        }

        catch (Exception)
        {
            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

            MessageBox.Show(StringFactory.GetString(128, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return;
        }
    }


    public void FillClientsSecurityDataBase()
    {
        try
        {
            if (ConnectingServiceDB.ClientsSecurityDataBase.Rows.Count < 0) return;

            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable securityDataBaseDataTable_obj = ConnectingServiceDB.ClientsSecurityDataBase;

            ClientsNetworkSecurity.UserAccount userAccount_NewAccount = null;

            for (int int_CycleCount = 0; int_CycleCount != securityDataBaseDataTable_obj.Rows.Count; int_CycleCount++)
            {
                dataRow_NewRecord = ConnectingServiceDB.ClientsSecurityDataBase.Rows[int_CycleCount];

                userAccount_NewAccount = new ClientsNetworkSecurity.UserAccount();

                userAccount_NewAccount.FirstName = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserFirstNameColumn]; ;
                userAccount_NewAccount.SecondName = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserMiddleNameColumn]; ;
                userAccount_NewAccount.LastName = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserLastNameColumn];

                userAccount_NewAccount.ICQ = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.ICQColumn];
                userAccount_NewAccount.EMail = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.EMailColumn];

                userAccount_NewAccount.Work = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.CompanyColumn];

                userAccount_NewAccount.HomePhone = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.HomePhoneColumn];
                userAccount_NewAccount.WorkPhone = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.WorkPhoneColumn];
                userAccount_NewAccount.MobilePhone = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.PrivateCellularColumn];

                userAccount_NewAccount.ActivationCode = (ulong)dataRow_NewRecord[securityDataBaseDataTable_obj.ActivationCodeColumn];
                userAccount_NewAccount.IsActivated = (bool)dataRow_NewRecord[securityDataBaseDataTable_obj.IsActivatedColumn];

                userAccount_NewAccount.IsEnabled = (bool)dataRow_NewRecord[securityDataBaseDataTable_obj.EnabledAccountStateColumn];
                userAccount_NewAccount.Password = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserPasswordColumn];
                userAccount_NewAccount.UIN = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UINColumn];
                userAccount_NewAccount.UserName = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserNameColumn];

                userAccount_NewAccount.CreationTime = (DateTime)dataRow_NewRecord[securityDataBaseDataTable_obj.CreationTimeColumn];
                userAccount_NewAccount.IsActivated = (bool)dataRow_NewRecord[securityDataBaseDataTable_obj.IsActivatedColumn];

                if (userAccount_NewAccount.IsActivated == true)
                {
                    userAccount_NewAccount.ActivationTime = (DateTime)dataRow_NewRecord[securityDataBaseDataTable_obj.ActivationTimeColumn];
                }

                dataRow_NewRecord = ConnectingServiceDB.ClientsSecurityDataBase.Rows[int_CycleCount];

                ClientsNetworkSecurity.AddNewUser(userAccount_NewAccount);
            }
        }

        catch (Exception)
        {
            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

            MessageBox.Show(StringFactory.GetString(128, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return;
        }
    }
    public void FillServersSecurityDataBase()
    {
        try
        {
            if (ConnectingServiceDB.ServersSecurityDataBase.Rows.Count < 0) return;

            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable securityDataBaseDataTable_obj = ConnectingServiceDB.ServersSecurityDataBase;

            ServersNetworkSecurity.UserAccount userAccount_NewAccount = null;

            for (int int_CycleCount = 0; int_CycleCount != securityDataBaseDataTable_obj.Rows.Count; int_CycleCount++)
            {
                dataRow_NewRecord = ConnectingServiceDB.ServersSecurityDataBase.Rows[int_CycleCount];

                userAccount_NewAccount = new ServersNetworkSecurity.UserAccount();

                userAccount_NewAccount.FirstName = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserFirstNameColumn];
                userAccount_NewAccount.SecondName = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserMiddleNameColumn];
                userAccount_NewAccount.LastName = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserLastNameColumn];

                userAccount_NewAccount.ICQ = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.ICQColumn];
                userAccount_NewAccount.EMail = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.EMailColumn];

                userAccount_NewAccount.Work = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.CompanyColumn];

                userAccount_NewAccount.HomePhone = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.HomePhoneColumn];
                userAccount_NewAccount.WorkPhone = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.WorkPhoneColumn];
                userAccount_NewAccount.MobilePhone = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.PrivateCellularColumn];

                userAccount_NewAccount.ActivationCode = (ulong)dataRow_NewRecord[securityDataBaseDataTable_obj.ActivationCodeColumn];

                userAccount_NewAccount.Password = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserPasswordColumn];
                userAccount_NewAccount.UIN = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UINColumn];
                userAccount_NewAccount.UserName = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserNameColumn];

                userAccount_NewAccount.CreationTime = (DateTime)dataRow_NewRecord[securityDataBaseDataTable_obj.CreationTimeColumn];

                userAccount_NewAccount.IsActivated = (bool)dataRow_NewRecord[securityDataBaseDataTable_obj.IsActivatedColumn];
                userAccount_NewAccount.IsEnabled = (bool)dataRow_NewRecord[securityDataBaseDataTable_obj.EnabledAccountStateColumn];

                if (userAccount_NewAccount.IsActivated == true)
                {
                    userAccount_NewAccount.ActivationTime = (DateTime)dataRow_NewRecord[securityDataBaseDataTable_obj.ActivationTimeColumn];
                }


                dataRow_NewRecord = ConnectingServiceDB.ServersSecurityDataBase.Rows[int_CycleCount];

                ServersNetworkSecurity.AddNewUser(userAccount_NewAccount);
            }
        }

        catch (Exception)
        {
            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

            MessageBox.Show(StringFactory.GetString(128, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return;
        }
    }

    public void LoadClientsAccessRestrictionRules()
    {
        try
        {
            if (ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.Count < 0) return;

            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = ConnectingServiceDB.ClientsAccessRestrictionRules;

            ////////////////////////////////////////////////////////////////////////////////

            IPAddress iPAddress_IPAddressesRangeStartValue = null;
            IPAddress iPAddress_IPAddressesRangeEndValue = null;
            IPAddress iPAddress_IPAddress = null;

            string string_IPAddressesRangeStartValue = "", string_IPAddressesRangeEndValue = "",
                   string_IPAddress = "", string_MACAddress = "", string_IPAddressesRangeValue = "",
                   string_RuleType = "";

            bool bool_ComplementaryUseMACAddress;

            int int_RuleType = 0;

            DateTime dateTime_CreationTime;

            for (int int_CycleCount = 0; int_CycleCount != accessRestrictionRulesDataTable_obj.Rows.Count; int_CycleCount++)
            {
                iPAddress_IPAddressesRangeStartValue = iPAddress_IPAddressesRangeEndValue = iPAddress_IPAddress = null;

                string_IPAddressesRangeStartValue = string_IPAddressesRangeEndValue = string_IPAddress =
                string_MACAddress = string_IPAddressesRangeValue = string_RuleType = string.Empty;

                dataRow_NewRecord = ConnectingServiceDB.ClientsAccessRestrictionRules.Rows[int_CycleCount];

                string_IPAddressesRangeStartValue = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
                string_IPAddressesRangeEndValue = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];

                string_IPAddress = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPAddressColumn];

                string_MACAddress = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.MACAddressColumn];

                dateTime_CreationTime = (DateTime)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.CreationTimeColumn];

                bool_ComplementaryUseMACAddress = (bool)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

                int_RuleType = (int)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.RuleTypeColumn];

                if (string_IPAddressesRangeStartValue != string.Empty && string_IPAddressesRangeEndValue != string.Empty)
                {
                    iPAddress_IPAddressesRangeStartValue = IPAddress.Parse(string_IPAddressesRangeStartValue);

                    iPAddress_IPAddressesRangeEndValue = IPAddress.Parse(string_IPAddressesRangeEndValue);

                    string_IPAddressesRangeValue = iPAddress_IPAddressesRangeStartValue + " - " + iPAddress_IPAddressesRangeEndValue;
                }
                if (string_IPAddress != string.Empty) iPAddress_IPAddress = IPAddress.Parse(string_IPAddress);

                if (int_RuleType == 0) string_RuleType = StringFactory.GetString(197, MainForm.CurrentLanguage);
                else string_RuleType = StringFactory.GetString(198, MainForm.CurrentLanguage);

                bool bool_IsRuleEnabled = (bool)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn];

                ClientsNetworkSecurity.AddNewAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress,
                                                                  string_MACAddress, bool_ComplementaryUseMACAddress, dateTime_CreationTime, int_RuleType, bool_IsRuleEnabled);

                ObjCopy.obj_MainForm.AddClientAccessRestrictionRuleToListView(string_IPAddressesRangeValue, string_IPAddress, string_MACAddress, dateTime_CreationTime, string_RuleType, bool_IsRuleEnabled);

            }
        }

        catch (Exception)
        {
            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

            MessageBox.Show(StringFactory.GetString(128, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return;
        }
    }
    public void LoadServersAccessRestrictionRules()
    {
        try
        {
            if (ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.Count < 0) return;

            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = ConnectingServiceDB.ServersAccessRestrictionRules;

            ////////////////////////////////////////////////////////////////////////////////

            IPAddress iPAddress_IPAddressesRangeStartValue = null;
            IPAddress iPAddress_IPAddressesRangeEndValue = null;
            IPAddress iPAddress_IPAddress = null;

            string string_IPAddressesRangeStartValue = "", string_IPAddressesRangeEndValue = "",
                   string_IPAddress = "", string_MACAddress = "", string_IPAddressesRangeValue = "",
                   string_RuleType = "";

            bool bool_ComplementaryUseMACAddress;

            int int_RuleType = 0;

            DateTime dateTime_CreationTime;

            for (int int_CycleCount = 0; int_CycleCount != accessRestrictionRulesDataTable_obj.Rows.Count; int_CycleCount++)
            {
                iPAddress_IPAddressesRangeStartValue = iPAddress_IPAddressesRangeEndValue = iPAddress_IPAddress = null;

                string_IPAddressesRangeStartValue = string_IPAddressesRangeEndValue = string_IPAddress =
                string_MACAddress = string_IPAddressesRangeValue = string_RuleType = string.Empty;

                dataRow_NewRecord = ConnectingServiceDB.ServersAccessRestrictionRules.Rows[int_CycleCount];

                string_IPAddressesRangeStartValue = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
                string_IPAddressesRangeEndValue = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];

                string_IPAddress = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPAddressColumn];

                string_MACAddress = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.MACAddressColumn];

                dateTime_CreationTime = (DateTime)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.CreationTimeColumn];

                bool_ComplementaryUseMACAddress = (bool)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

                int_RuleType = (int)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.RuleTypeColumn];

                if (string_IPAddressesRangeStartValue != string.Empty && string_IPAddressesRangeEndValue != string.Empty)
                {
                    iPAddress_IPAddressesRangeStartValue = IPAddress.Parse(string_IPAddressesRangeStartValue);

                    iPAddress_IPAddressesRangeEndValue = IPAddress.Parse(string_IPAddressesRangeEndValue);

                    string_IPAddressesRangeValue = iPAddress_IPAddressesRangeStartValue + " - " + iPAddress_IPAddressesRangeEndValue;
                }
                if (string_IPAddress != string.Empty) iPAddress_IPAddress = IPAddress.Parse(string_IPAddress);

                if (int_RuleType == 0) string_RuleType = StringFactory.GetString(197, MainForm.CurrentLanguage);
                else string_RuleType = StringFactory.GetString(198, MainForm.CurrentLanguage);

                bool bool_IsRuleEnabled = (bool)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn];

                ServersNetworkSecurity.AddNewAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress,
                                                                  string_MACAddress, bool_ComplementaryUseMACAddress, dateTime_CreationTime, int_RuleType, bool_IsRuleEnabled);

                ObjCopy.obj_MainForm.AddServerAccessRestrictionRuleToListView(string_IPAddressesRangeValue, string_IPAddress, string_MACAddress, dateTime_CreationTime, string_RuleType, bool_IsRuleEnabled);

            }
        }

        catch (Exception)
        {
            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

            MessageBox.Show(StringFactory.GetString(128, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));

            return;
        }
    }

    public static void ClearCommonEventsLog()
    {
        ConnectingServiceDB.CommonEventsLog.Rows.Clear();
    }
    public static void ClearServersEventsLog()
    {
        ConnectingServiceDB.ServersEventsLog.Rows.Clear();
    }
    public static void ClearClientsEventsLog()
    {
        ConnectingServiceDB.ClientsEventsLog.Rows.Clear();
    }
}