using System;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;
using JurikSoft.Compression;
using System.Net;
using JsConnectingService;
using System.Threading;



public class CommonNetworkEvents
{
    #region Disconnect Events

    public delegate void ServiceStoppedEventHandler();
    public static ServiceStoppedEventHandler ServiceStoppedEvent;

    public delegate void ClientDisconnectedEventHandler(ConnectedClient ñonnectedClient_obj);
    public static ClientDisconnectedEventHandler ClientDisconnectedEvent;

    public delegate void ServerDisconnectedEventHandler(ConnectedServer ñonnectedServer_obj);
    public static ServerDisconnectedEventHandler ServerDisconnectedEvent;

    #endregion

    #region Connected Events

    public delegate void ServiceStartedEventHandler();
    public static ServiceStartedEventHandler ServiceStartedEvent;

    public delegate void NewClientConnectedEventHandler(ConnectedClient ñonnectedClient_obj);
    public static NewClientConnectedEventHandler NewClientConnectedEvent;

    public delegate void NewServerConnectedEventHandler(ConnectedServer ñonnectedServer_obj);
    public static NewServerConnectedEventHandler NewServerConnectedEvent;

    #endregion

    #region InterConnected Events

    public delegate void NewInterConnectionEventHandler(ConnectedServer.AppliedServerChannel appliedServerChannel_obj, ConnectedClient.AppliedClientChannel appliedClientChannel_obj);
    public static NewInterConnectionEventHandler NewInterConnectionEvent;

    #endregion
}

public class ConnectingServiceLogsEvents
{
    #region  Events

    public delegate void NewCommonLogRecordEventHandler(string string_RecordType, string string_Date, string string_Time, string string_RecordSource, string string_EventDescription, bool bool_ListViewRecordOnly);
    public static NewCommonLogRecordEventHandler NewCommonLogRecordEvent;

    #endregion

    #region  Events

    public delegate void NewServersLogRecordEventHandler(string string_RecordType, string string_Date, string string_Time, string string_UserName, string string_UIN, string string_RecordSource, string string_EventDescription, bool bool_ListViewRecordOnly);
    public static NewServersLogRecordEventHandler NewServersLogRecordEvent;

    #endregion

    #region  Events

    public delegate void NewClientsLogRecordEventHandler(string string_RecordType, string string_Date, string string_Time, string string_UserName, string string_UIN, string string_RecordSource, string string_EventDescription, bool bool_ListViewRecordOnly);
    public static NewClientsLogRecordEventHandler NewClientsLogRecordEvent;

    #endregion
}

public class ConmpressionEnvironment
{
    public ConmpressionEnvironment()
    {
        if (iCompressionArray_obj[1] != null) return;

        iCompressionArray_obj[1] = new JurikSoft.Compression.PrefixCodes(true);
        iCompressionArray_obj[2] = new JurikSoft.Compression.PrefixCodes(false);
        iCompressionArray_obj[3] = new JurikSoft.Compression.LZSS(8, true, true, false, 131072);
        iCompressionArray_obj[4] = new DeflateCompressionWrapper();
        iCompressionArray_obj[5] = new JurikSoft.Compression.RLE(JurikSoft.Compression.PrefixCodesCompression.NonAdaptive);

    }

    public static ICompression[] iCompressionArray_obj = new ICompression[6];

    public class DeflateCompressionWrapper : JurikSoft.Compression.ICompression
    {
        MemoryStream memoryStream_DecompressedData = new MemoryStream();
        MemoryStream memoryStream_DataToCompress = new MemoryStream();

        public byte[] Compress(byte[] DataToCompress, bool AddCheckSum)
        {
            memoryStream_DataToCompress.SetLength(0);

            DeflateStream deflateStream_obj = new DeflateStream(memoryStream_DataToCompress, CompressionMode.Compress, true);

            deflateStream_obj.Write(DataToCompress, 0, DataToCompress.Length);

            deflateStream_obj.Close();

            memoryStream_DataToCompress.SetLength(memoryStream_DataToCompress.Position);

            return memoryStream_DataToCompress.ToArray();
        }

        public byte[] Decompress(byte[] byteArray_DeflateCompressedData)
        {
            MemoryStream memoryStream_CompressedData = new MemoryStream(byteArray_DeflateCompressedData, 0, byteArray_DeflateCompressedData.Length);

            memoryStream_DecompressedData.SetLength(0);

            memoryStream_CompressedData.Position = 0;

            DeflateStream deflateStream_obj = new DeflateStream(memoryStream_CompressedData, CompressionMode.Decompress, true);

            int int_DecompressedByte = 0;

            for (; ; )
            {
                int_DecompressedByte = deflateStream_obj.ReadByte();

                if (int_DecompressedByte == -1) break;

                memoryStream_DecompressedData.WriteByte((byte)int_DecompressedByte);
            }

            deflateStream_obj.Flush();
            deflateStream_obj.Close();

            memoryStream_CompressedData.Close();

            memoryStream_DecompressedData.SetLength(memoryStream_DecompressedData.Position);

            return memoryStream_DecompressedData.ToArray();
        }
    }
}

public class CommonMethods
{
    public static string ReadStringFromStream(MemoryStream obj_MemoryStream)
    {
        byte[] byteArray_StringLength = new byte[4];

        obj_MemoryStream.Read(byteArray_StringLength, 0, 4);

        byte[] byteArray_String = new byte[BitConverter.ToInt32(byteArray_StringLength, 0)];

        obj_MemoryStream.Read(byteArray_String, 0, BitConverter.ToInt32(byteArray_StringLength, 0));

        return Encoding.Unicode.GetString(byteArray_String);
    }

    public static int ReadIntFromStream(MemoryStream obj_MemoryStream)
    {
        byte[] byteArray_Int = new byte[4];

        obj_MemoryStream.Read(byteArray_Int, 0, 4);

        return BitConverter.ToInt32(byteArray_Int, 0);
    }

    public static long ReadInt64FromStream(MemoryStream obj_MemoryStream)
    {
        byte[] byteArray_Int = new byte[8];

        obj_MemoryStream.Read(byteArray_Int, 0, 8);

        return BitConverter.ToInt64(byteArray_Int, 0);
    }

    public static ulong ReadUInt64FromStream(MemoryStream obj_MemoryStream)
    {
        byte[] byteArray_UInt = new byte[8];

        obj_MemoryStream.Read(byteArray_UInt, 0, 8);

        return BitConverter.ToUInt64(byteArray_UInt, 0);
    }

    public static byte[] ReadBytesFromStream(MemoryStream obj_MemoryStream)
    {
        byte[] byteArray_BytesLength = new byte[4];

        obj_MemoryStream.Read(byteArray_BytesLength, 0, 4);

        byte[] byteArray_Bytes = new byte[BitConverter.ToInt32(byteArray_BytesLength, 0)];

        obj_MemoryStream.Read(byteArray_Bytes, 0, BitConverter.ToInt32(byteArray_BytesLength, 0));

        return byteArray_Bytes;
    }


    public static void WriteStringToStream(MemoryStream obj_MemoryStream, string string_StringForWrite)
    {
        byte[] byteArray_StringForWrite = Encoding.Unicode.GetBytes(string_StringForWrite),
                byteArray_StringForWriteLength = BitConverter.GetBytes(byteArray_StringForWrite.Length);

        obj_MemoryStream.Write(byteArray_StringForWriteLength, 0, byteArray_StringForWriteLength.Length);

        obj_MemoryStream.Write(byteArray_StringForWrite, 0, byteArray_StringForWrite.Length);
    }

    public static void WriteIntToStream(MemoryStream obj_MemoryStream, int int_IntForWrite)
    {
        obj_MemoryStream.Write(BitConverter.GetBytes(int_IntForWrite), 0, 4);
    }

    public static void WriteInt64ToStream(MemoryStream obj_MemoryStream, Int64 int_IntForWrite)
    {
        obj_MemoryStream.Write(BitConverter.GetBytes(int_IntForWrite), 0, 8);
    }

    public static void WriteUInt64ToStream(MemoryStream obj_MemoryStream, ulong ulong_UlongForWrite)
    {
        byte[] byteArray_UInt64 = BitConverter.GetBytes(ulong_UlongForWrite);

        obj_MemoryStream.Write(BitConverter.GetBytes(ulong_UlongForWrite), 0, 8);
    }

    public static void WriteBytesToStream(MemoryStream obj_MemoryStream, byte[] byteArray_BytesForWrite)
    {
        byte[] byteArray_BytesForWriteLength = BitConverter.GetBytes(byteArray_BytesForWrite.Length);

        obj_MemoryStream.Write(byteArray_BytesForWriteLength, 0, byteArray_BytesForWriteLength.Length);

        obj_MemoryStream.Write(byteArray_BytesForWrite, 0, byteArray_BytesForWrite.Length);
    }


    public static byte[] GetByteArrayPart(byte[] byteArray_FullBytesArray, int int_StartPosition, int int_Length)
    {
        byte[] byteArray_NewBuffer = new byte[int_Length];

        int int_PositionInNewBuffer = 0;

        for (int int_CycleCount = 0; int_CycleCount != int_Length; int_CycleCount++, int_PositionInNewBuffer++)
        {
            byteArray_NewBuffer[int_PositionInNewBuffer] = byteArray_FullBytesArray[int_StartPosition + int_CycleCount];
        }

        return byteArray_NewBuffer;
    }

    public static bool AreBytesArraysEquals(byte[] byteArray_InitialData, byte[] byteArray_ComparedData)
    {
        if (byteArray_InitialData.Length != byteArray_ComparedData.Length) return false;

        for (int int_CycleCount = 0; int_CycleCount != byteArray_InitialData.Length; int_CycleCount++)
        {
            if (byteArray_InitialData[int_CycleCount] != byteArray_ComparedData[int_CycleCount]) return false;
        }

        return true;
    }

    public static bool IsSecondIPAddressBiggerOrEquals(IPAddress iPAddress_FirstAddress, IPAddress iPAddress_SecondAddress)
    {
        byte[] byteArray_FirstAddress = iPAddress_FirstAddress.GetAddressBytes();
        byte[] byteArray_SecondAddress = iPAddress_SecondAddress.GetAddressBytes();

        if (byteArray_SecondAddress[0] > byteArray_FirstAddress[0]) return true;

        if (byteArray_SecondAddress[0] == byteArray_FirstAddress[0])
        {
            if (byteArray_SecondAddress[1] > byteArray_FirstAddress[1]) return true;

            if (byteArray_SecondAddress[1] == byteArray_FirstAddress[1])
            {
                if (byteArray_SecondAddress[2] > byteArray_FirstAddress[2]) return true;

                if (byteArray_SecondAddress[2] == byteArray_FirstAddress[2])
                {
                    if (byteArray_SecondAddress[3] >= byteArray_FirstAddress[3]) return true;
                    else return false;
                }

                else return false;
            }
            else return false;
        }
        else return false;
    }

    public static string SpreadToHundreds(string string_NecessaryString)
    {
        for (int int_LastDotPosition = string_NecessaryString.Length; int_LastDotPosition - 3 >= 1; int_LastDotPosition -= 3)
        {
            string_NecessaryString = string_NecessaryString.Insert(int_LastDotPosition - 3, ", ");
        }

        return string_NecessaryString;
    }


    public ulong WaitForOperationCompleting(ref ulong ulong_Value, ulong ulong_ExceptValue, int int_MaxSleepValue)
    {
        int int_SleepCounter = 0;

        while (true)
        {
            lock (this)
            {
                if (ulong_Value != ulong_ExceptValue) break;
            }

            Thread.Sleep(10);

            int_SleepCounter += 10;

            if (int_SleepCounter > int_MaxSleepValue)
            {
                return ulong_Value;
            }
        }

        return ulong_Value;
    }

    public bool WaitForOperationCompleting(ref bool bool_Value, int int_MaxSleepValue)
    {
        int int_SleepCounter = 0;

        while (true)
        {
            lock (this)
            {
                if (bool_Value == true) break;
            }

            Thread.Sleep(10);

            int_SleepCounter += 10;

            if (int_SleepCounter > int_MaxSleepValue)
            {
                return bool_Value;
            }
        }

        return bool_Value;
    }
}


public class ClientAccountsAndAccessRestrictionRulesEnvironment
{
    public static void ViewSelectedAccessRestrictionRule(int int_AccessRestrictionRuleRowIndex)
    {
        ClientsAccessRestrictionRulesManagerForm accessRestrictionRulesManagerForm_obj = new ClientsAccessRestrictionRulesManagerForm();

        accessRestrictionRulesManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.Count == 0) return;

        accessRestrictionRulesManagerForm_obj.AddButton.Visible = false;

        string string_MACAddress = String.Empty;

        DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable clientsAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules;

        accessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
        accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];
        accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPAddressColumn];

        string_MACAddress = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.MACAddressColumn];

        if (string_MACAddress.Length == 17)
        {
            accessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.Text = string_MACAddress.Substring(0, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.Text = string_MACAddress.Substring(3, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.Text = string_MACAddress.Substring(6, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.Text = string_MACAddress.Substring(9, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.Text = string_MACAddress.Substring(12, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.Text = string_MACAddress.Substring(15, 2);
        }

        accessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Checked = (bool)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

        accessRestrictionRulesManagerForm_obj.RuleTypeComboBox.SelectedIndex = (int)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.RuleTypeColumn];

        accessRestrictionRulesManagerForm_obj.EditedRecordIndex = int_AccessRestrictionRuleRowIndex;


        if (accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Checked = true;
        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Checked = true;

        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length == 0 && accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length == 0)
            accessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Checked = true;

        accessRestrictionRulesManagerForm_obj.AddButton.Visible =
        accessRestrictionRulesManagerForm_obj.ApplyButton.Visible =

        accessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Enabled =

        accessRestrictionRulesManagerForm_obj.RuleTypeComboBox.Enabled =
        accessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Enabled = false;

        accessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.IPAddressTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.ReadOnly = true;

        accessRestrictionRulesManagerForm_obj.RestrictByIPAddressGroupBox.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByIPRangeGroupBox.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByMACAddressGroupBox.Enabled = true;

        accessRestrictionRulesManagerForm_obj.ShowDialog();
    }

    public static void EditSelectedAccessRestrictionRule(int int_AccessRestrictionRuleRowIndex)
    {
        ClientsAccessRestrictionRulesManagerForm accessRestrictionRulesManagerForm_obj = new ClientsAccessRestrictionRulesManagerForm();

        accessRestrictionRulesManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.Count == 0) return;

        accessRestrictionRulesManagerForm_obj.AddButton.Visible = false;

        string string_MACAddress = String.Empty;

        DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable clientsAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules;

        accessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
        accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];
        accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPAddressColumn];

        string_MACAddress = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.MACAddressColumn];

        if (string_MACAddress.Length == 17)
        {
            accessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.Text = string_MACAddress.Substring(0, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.Text = string_MACAddress.Substring(3, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.Text = string_MACAddress.Substring(6, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.Text = string_MACAddress.Substring(9, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.Text = string_MACAddress.Substring(12, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.Text = string_MACAddress.Substring(15, 2);
        }

        accessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Checked = (bool)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

        accessRestrictionRulesManagerForm_obj.RuleTypeComboBox.SelectedIndex = (int)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.RuleTypeColumn];

        accessRestrictionRulesManagerForm_obj.EditedRecordIndex = int_AccessRestrictionRuleRowIndex;


        if (accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Checked = true;
        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Checked = true;

        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length == 0 && accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length == 0)
            accessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Checked = true;

        accessRestrictionRulesManagerForm_obj.ShowDialog();
    }

    /*
    
    public static void EditSelectedClientAccount(int int_SelectedClientAccountRowIndex)
    {
        UsersAccountsManagerForm usersAccountsManagerForm_obj = new UsersAccountsManagerForm();

        usersAccountsManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.SecurityDataBase.Rows.Count == 0) return;

        usersAccountsManagerForm_obj.EditedRecordIndex = int_SelectedClientAccountRowIndex;

        usersAccountsManagerForm_obj.AddButton.Visible = false;

        usersAccountsManagerForm_obj.LoginTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.UserNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.NewPasswordTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.ReadOnly = true;

        DataSet_ConnectingServiceDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.SecurityDataBase;

        usersAccountsManagerForm_obj.LoginTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserLoginColumn];
        usersAccountsManagerForm_obj.UserNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserNameColumn];
        usersAccountsManagerForm_obj.NewPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.FirstNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserFirstNameColumn];
        usersAccountsManagerForm_obj.LastNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserLastNameColumn];
        usersAccountsManagerForm_obj.MiddleNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserMiddleNameColumn];
        usersAccountsManagerForm_obj.EMailAddressTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.EMailColumn];
        usersAccountsManagerForm_obj.ICQTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.ICQColumn];
        usersAccountsManagerForm_obj.CompanyTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.CompanyColumn];
        usersAccountsManagerForm_obj.HomePhomeTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.WorkPhoneTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.PrivateCellularTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.PrivateCellularColumn];

        usersAccountsManagerForm_obj.EditedRecordIndex = int_SelectedClientAccountRowIndex;

        usersAccountsManagerForm_obj.ShowDialog();
    }

    public static void ViewSelectedClientAccount(int int_SelectedClientAccountRowIndex)
    {
        UsersAccountsManagerForm usersAccountsManagerForm_obj = new UsersAccountsManagerForm();

        usersAccountsManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.SecurityDataBase.Rows.Count == 0) return;

        usersAccountsManagerForm_obj.ApplyButton.Visible = false;
        usersAccountsManagerForm_obj.AddButton.Visible = false;



        usersAccountsManagerForm_obj.LoginTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.UserNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.NewPasswordTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.FirstNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.MiddleNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.LastNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.EMailAddressTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.ICQTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.CompanyTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.HomePhomeTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.WorkPhoneTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.PrivateCellularTextBox.ReadOnly = true;

        usersAccountsManagerForm_obj.LoginTextBox.Focus();

        DataSet_ConnectingServiceDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.SecurityDataBase;

        usersAccountsManagerForm_obj.LoginTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserLoginColumn];
        usersAccountsManagerForm_obj.UserNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserNameColumn];
        usersAccountsManagerForm_obj.NewPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.FirstNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserFirstNameColumn];
        usersAccountsManagerForm_obj.LastNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserLastNameColumn];
        usersAccountsManagerForm_obj.MiddleNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.UserMiddleNameColumn];
        usersAccountsManagerForm_obj.EMailAddressTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.EMailColumn];
        usersAccountsManagerForm_obj.ICQTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.ICQColumn];
        usersAccountsManagerForm_obj.CompanyTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.CompanyColumn];
        usersAccountsManagerForm_obj.HomePhomeTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.WorkPhoneTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.PrivateCellularTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedClientAccountRowIndex][securityDataBaseDataTable_obj.PrivateCellularColumn];

        usersAccountsManagerForm_obj.EditedRecordIndex = int_SelectedClientAccountRowIndex;

        usersAccountsManagerForm_obj.ShowDialog();
    }

    */

}

public class ServerAccountsAndAccessRestrictionRulesEnvironment
{
    public static void ViewSelectedAccessRestrictionRule(int int_AccessRestrictionRuleRowIndex)
    {
        ServersAccessRestrictionRulesManagerForm accessRestrictionRulesManagerForm_obj = new ServersAccessRestrictionRulesManagerForm();

        accessRestrictionRulesManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.Count == 0) return;

        accessRestrictionRulesManagerForm_obj.AddButton.Visible = false;

        string string_MACAddress = String.Empty;

        DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable serversAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules;

        accessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
        accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];
        accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPAddressColumn];

        string_MACAddress = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.MACAddressColumn];

        if (string_MACAddress.Length == 17)
        {
            accessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.Text = string_MACAddress.Substring(0, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.Text = string_MACAddress.Substring(3, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.Text = string_MACAddress.Substring(6, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.Text = string_MACAddress.Substring(9, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.Text = string_MACAddress.Substring(12, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.Text = string_MACAddress.Substring(15, 2);
        }

        accessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Checked = (bool)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

        accessRestrictionRulesManagerForm_obj.RuleTypeComboBox.SelectedIndex = (int)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.RuleTypeColumn];

        accessRestrictionRulesManagerForm_obj.EditedRecordIndex = int_AccessRestrictionRuleRowIndex;


        if (accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Checked = true;
        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Checked = true;

        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length == 0 && accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length == 0)
            accessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Checked = true;

        accessRestrictionRulesManagerForm_obj.AddButton.Visible =
        accessRestrictionRulesManagerForm_obj.ApplyButton.Visible =

        accessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Enabled =

        accessRestrictionRulesManagerForm_obj.RuleTypeComboBox.Enabled =
        accessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Enabled = false;

        accessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.IPAddressTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.ReadOnly = true;

        accessRestrictionRulesManagerForm_obj.RestrictByIPAddressGroupBox.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByIPRangeGroupBox.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByMACAddressGroupBox.Enabled = true;

        accessRestrictionRulesManagerForm_obj.ShowDialog();
    }

    public static void EditSelectedAccessRestrictionRule(int int_AccessRestrictionRuleRowIndex)
    {
        ServersAccessRestrictionRulesManagerForm accessRestrictionRulesManagerForm_obj = new ServersAccessRestrictionRulesManagerForm();

        accessRestrictionRulesManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.Count == 0) return;

        accessRestrictionRulesManagerForm_obj.AddButton.Visible = false;

        string string_MACAddress = String.Empty;

        DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable serversAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules;

        accessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
        accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];
        accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPAddressColumn];

        string_MACAddress = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.MACAddressColumn];

        if (string_MACAddress.Length == 17)
        {
            accessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.Text = string_MACAddress.Substring(0, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.Text = string_MACAddress.Substring(3, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.Text = string_MACAddress.Substring(6, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.Text = string_MACAddress.Substring(9, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.Text = string_MACAddress.Substring(12, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.Text = string_MACAddress.Substring(15, 2);
        }

        accessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Checked = (bool)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

        accessRestrictionRulesManagerForm_obj.RuleTypeComboBox.SelectedIndex = (int)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.RuleTypeColumn];

        accessRestrictionRulesManagerForm_obj.EditedRecordIndex = int_AccessRestrictionRuleRowIndex;


        if (accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Checked = true;
        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Checked = true;

        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length == 0 && accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length == 0)
            accessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Checked = true;

        accessRestrictionRulesManagerForm_obj.ShowDialog();
    }

    /*
    
    public static void EditSelectedServerAccount(int int_SelectedServerAccountRowIndex)
    {
        UsersAccountsManagerForm usersAccountsManagerForm_obj = new UsersAccountsManagerForm();

        usersAccountsManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.SecurityDataBase.Rows.Count == 0) return;

        usersAccountsManagerForm_obj.EditedRecordIndex = int_SelectedServerAccountRowIndex;

        usersAccountsManagerForm_obj.AddButton.Visible = false;

        usersAccountsManagerForm_obj.LoginTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.UserNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.NewPasswordTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.ReadOnly = true;

        DataSet_ConnectingServiceDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.SecurityDataBase;

        usersAccountsManagerForm_obj.LoginTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserLoginColumn];
        usersAccountsManagerForm_obj.UserNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserNameColumn];
        usersAccountsManagerForm_obj.NewPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.FirstNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserFirstNameColumn];
        usersAccountsManagerForm_obj.LastNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserLastNameColumn];
        usersAccountsManagerForm_obj.MiddleNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserMiddleNameColumn];
        usersAccountsManagerForm_obj.EMailAddressTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.EMailColumn];
        usersAccountsManagerForm_obj.ICQTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.ICQColumn];
        usersAccountsManagerForm_obj.CompanyTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.CompanyColumn];
        usersAccountsManagerForm_obj.HomePhomeTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.WorkPhoneTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.PrivateCellularTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.PrivateCellularColumn];

        usersAccountsManagerForm_obj.EditedRecordIndex = int_SelectedServerAccountRowIndex;

        usersAccountsManagerForm_obj.ShowDialog();
    }

    public static void ViewSelectedServerAccount(int int_SelectedServerAccountRowIndex)
    {
        UsersAccountsManagerForm usersAccountsManagerForm_obj = new UsersAccountsManagerForm();

        usersAccountsManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.SecurityDataBase.Rows.Count == 0) return;

        usersAccountsManagerForm_obj.ApplyButton.Visible = false;
        usersAccountsManagerForm_obj.AddButton.Visible = false;



        usersAccountsManagerForm_obj.LoginTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.UserNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.NewPasswordTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.FirstNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.MiddleNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.LastNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.EMailAddressTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.ICQTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.CompanyTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.HomePhomeTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.WorkPhoneTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.PrivateCellularTextBox.ReadOnly = true;

        usersAccountsManagerForm_obj.LoginTextBox.Focus();

        DataSet_ConnectingServiceDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.SecurityDataBase;

        usersAccountsManagerForm_obj.LoginTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserLoginColumn];
        usersAccountsManagerForm_obj.UserNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserNameColumn];
        usersAccountsManagerForm_obj.NewPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.FirstNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserFirstNameColumn];
        usersAccountsManagerForm_obj.LastNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserLastNameColumn];
        usersAccountsManagerForm_obj.MiddleNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.UserMiddleNameColumn];
        usersAccountsManagerForm_obj.EMailAddressTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.EMailColumn];
        usersAccountsManagerForm_obj.ICQTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.ICQColumn];
        usersAccountsManagerForm_obj.CompanyTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.CompanyColumn];
        usersAccountsManagerForm_obj.HomePhomeTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.WorkPhoneTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.PrivateCellularTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedServerAccountRowIndex][securityDataBaseDataTable_obj.PrivateCellularColumn];

        usersAccountsManagerForm_obj.EditedRecordIndex = int_SelectedServerAccountRowIndex;

        usersAccountsManagerForm_obj.ShowDialog();
    }

    */
}

public class UserAccountsAndAccessRestrictionRulesEnvironment
{
    public static bool IsSecondIPAddressBiggerOrEquals(IPAddress iPAddress_FirstAddress, IPAddress iPAddress_SecondAddress)
    {
        byte[] byteArray_FirstAddress = iPAddress_FirstAddress.GetAddressBytes();
        byte[] byteArray_SecondAddress = iPAddress_SecondAddress.GetAddressBytes();

        if (byteArray_SecondAddress[0] > byteArray_FirstAddress[0]) return true;

        if (byteArray_SecondAddress[0] == byteArray_FirstAddress[0])
        {
            if (byteArray_SecondAddress[1] > byteArray_FirstAddress[1]) return true;

            if (byteArray_SecondAddress[1] == byteArray_FirstAddress[1])
            {
                if (byteArray_SecondAddress[2] > byteArray_FirstAddress[2]) return true;

                if (byteArray_SecondAddress[2] == byteArray_FirstAddress[2])
                {
                    if (byteArray_SecondAddress[3] >= byteArray_FirstAddress[3]) return true;
                    else return false;
                }

                else return false;
            }
            else return false;
        }
        else return false;
    }
}



public class CommonEnvironment
{
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



    static string string_SMTPServer = string.Empty, string_SenderMailAddress = string.Empty, string_SMTPLogin = string.Empty, string_SMTPPassword = string.Empty ;
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

    


    public static void ViewClientAccessRestrictionRule(int int_AccessRestrictionRuleRowIndex)
    {
        ClientsAccessRestrictionRulesManagerForm clientsAccessRestrictionRulesManagerForm_obj = new ClientsAccessRestrictionRulesManagerForm();

        clientsAccessRestrictionRulesManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.Count == 0) return;

        clientsAccessRestrictionRulesManagerForm_obj.AddButton.Visible = false;

        string string_MACAddress = "";

        DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable clientsAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules;

        clientsAccessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
        clientsAccessRestrictionRulesManagerForm_obj.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];
        clientsAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPAddressColumn];

        string_MACAddress = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.MACAddressColumn];

        if (string_MACAddress.Length == 17)
        {
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.Text = string_MACAddress.Substring(0, 2);
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.Text = string_MACAddress.Substring(3, 2);
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.Text = string_MACAddress.Substring(6, 2);
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.Text = string_MACAddress.Substring(9, 2);
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.Text = string_MACAddress.Substring(12, 2);
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.Text = string_MACAddress.Substring(15, 2);
        }

        clientsAccessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Checked = (bool)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

        clientsAccessRestrictionRulesManagerForm_obj.RuleTypeComboBox.SelectedIndex = (int)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.RuleTypeColumn];

        clientsAccessRestrictionRulesManagerForm_obj.EditedRecordIndex = int_AccessRestrictionRuleRowIndex;


        if (clientsAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length >= 7) clientsAccessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Checked = true;
        if (clientsAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length >= 7) clientsAccessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Checked = true;

        if (clientsAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length == 0 && clientsAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length == 0)
            clientsAccessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Checked = true;

        clientsAccessRestrictionRulesManagerForm_obj.AddButton.Visible =
        clientsAccessRestrictionRulesManagerForm_obj.Visible =

        clientsAccessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Enabled =
        clientsAccessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Enabled =
        clientsAccessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Enabled =

        clientsAccessRestrictionRulesManagerForm_obj.RuleTypeComboBox.Enabled =
        clientsAccessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Enabled = false;

        clientsAccessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.ReadOnly =
        clientsAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.ReadOnly =
        clientsAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.ReadOnly =
        clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.ReadOnly =
        clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.ReadOnly =
        clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.ReadOnly =
        clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.ReadOnly =
        clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.ReadOnly =
        clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.ReadOnly = 

        clientsAccessRestrictionRulesManagerForm_obj.RestrictByIPAddressGroupBox.Enabled =
        clientsAccessRestrictionRulesManagerForm_obj.RestrictByIPRangeGroupBox.Enabled =
        clientsAccessRestrictionRulesManagerForm_obj.RestrictByMACAddressGroupBox.Enabled = true;

        clientsAccessRestrictionRulesManagerForm_obj.ShowDialog();
    }

    public static void EditClientAccessRestrictionRule(int int_AccessRestrictionRuleRowIndex)
    {
        ClientsAccessRestrictionRulesManagerForm clientsAccessRestrictionRulesManagerForm_obj = new ClientsAccessRestrictionRulesManagerForm();

        clientsAccessRestrictionRulesManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.Count == 0) return;

        clientsAccessRestrictionRulesManagerForm_obj.AddButton.Visible = false;

        string string_MACAddress = "";

        DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable clientsAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules;

        clientsAccessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
        clientsAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];
        clientsAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.IPAddressColumn];

        string_MACAddress = (string)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.MACAddressColumn];

        if (string_MACAddress.Length == 17)
        {
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.Text = string_MACAddress.Substring(0, 2);
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.Text = string_MACAddress.Substring(3, 2);
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.Text = string_MACAddress.Substring(6, 2);
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.Text = string_MACAddress.Substring(9, 2);
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.Text = string_MACAddress.Substring(12, 2);
            clientsAccessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.Text = string_MACAddress.Substring(15, 2);
        }

        clientsAccessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Checked = (bool)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

        clientsAccessRestrictionRulesManagerForm_obj.RuleTypeComboBox.SelectedIndex = (int)clientsAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][clientsAccessRestrictionRulesDataTable_obj.RuleTypeColumn];

        clientsAccessRestrictionRulesManagerForm_obj.EditedRecordIndex = int_AccessRestrictionRuleRowIndex;


        if (clientsAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length >= 7) clientsAccessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Checked = true;
        if (clientsAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length >= 7) clientsAccessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Checked = true;

        if (clientsAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length == 0 && clientsAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length == 0)
            clientsAccessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Checked = true;

        clientsAccessRestrictionRulesManagerForm_obj.ShowDialog();
    }

    public static void ViewClientUserAccount(int int_SelectedUserAccountRowIndex)
    {
        ClientsAccountsManagerForm clientsAccountsManagerForm_obj = new ClientsAccountsManagerForm();

        clientsAccountsManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase.Rows.Count == 0) return;

        clientsAccountsManagerForm_obj.ApplyButton.Visible = false;
        clientsAccountsManagerForm_obj.AddButton.Visible = false;



        clientsAccountsManagerForm_obj.LoginTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.UserNameTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.NewPasswordTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.ConfirmedPasswordTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.FirstNameTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.MiddleNameTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.LastNameTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.EMailAddressTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.ICQTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.CompanyTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.HomePhomeTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.WorkPhoneTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.PrivateCellularTextBox.ReadOnly = true;

        clientsAccountsManagerForm_obj.LoginTextBox.Focus();

        DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable clientsSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase;

        clientsAccountsManagerForm_obj.LoginTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UINColumn];
        clientsAccountsManagerForm_obj.UserNameTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserNameColumn];
        clientsAccountsManagerForm_obj.NewPasswordTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserPasswordColumn];
        clientsAccountsManagerForm_obj.ConfirmedPasswordTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserPasswordColumn];
        clientsAccountsManagerForm_obj.FirstNameTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserFirstNameColumn];
        clientsAccountsManagerForm_obj.LastNameTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserLastNameColumn];
        clientsAccountsManagerForm_obj.MiddleNameTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserMiddleNameColumn];
        clientsAccountsManagerForm_obj.EMailAddressTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.EMailColumn];
        clientsAccountsManagerForm_obj.ICQTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.ICQColumn];
        clientsAccountsManagerForm_obj.CompanyTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.CompanyColumn];
        clientsAccountsManagerForm_obj.HomePhomeTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.HomePhoneColumn];
        clientsAccountsManagerForm_obj.WorkPhoneTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.WorkPhoneColumn];
        clientsAccountsManagerForm_obj.PrivateCellularTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.PrivateCellularColumn];

        clientsAccountsManagerForm_obj.EditedRecordIndex = int_SelectedUserAccountRowIndex;

        clientsAccountsManagerForm_obj.ShowDialog();

    }

    public static void EditClientUserAccount(int int_SelectedUserAccountRowIndex)
    {
        ClientsAccountsManagerForm clientsAccountsManagerForm_obj = new ClientsAccountsManagerForm();

        clientsAccountsManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase.Rows.Count == 0) return;

        clientsAccountsManagerForm_obj.EditedRecordIndex = int_SelectedUserAccountRowIndex;

        clientsAccountsManagerForm_obj.AddButton.Visible = false;

        clientsAccountsManagerForm_obj.LoginTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.UserNameTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.NewPasswordTextBox.ReadOnly = true;
        clientsAccountsManagerForm_obj.ConfirmedPasswordTextBox.ReadOnly = true;

        DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable clientsSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase;

        clientsAccountsManagerForm_obj.LoginTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UINColumn];
        clientsAccountsManagerForm_obj.UserNameTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserNameColumn];
        clientsAccountsManagerForm_obj.NewPasswordTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserPasswordColumn];
        clientsAccountsManagerForm_obj.ConfirmedPasswordTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserPasswordColumn];
        clientsAccountsManagerForm_obj.FirstNameTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserNameColumn];
        clientsAccountsManagerForm_obj.LastNameTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserLastNameColumn];
        clientsAccountsManagerForm_obj.MiddleNameTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.UserMiddleNameColumn];
        clientsAccountsManagerForm_obj.EMailAddressTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.EMailColumn];
        clientsAccountsManagerForm_obj.ICQTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.ICQColumn];
        clientsAccountsManagerForm_obj.CompanyTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.CompanyColumn];
        clientsAccountsManagerForm_obj.HomePhomeTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.HomePhoneColumn];
        clientsAccountsManagerForm_obj.WorkPhoneTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.HomePhoneColumn];
        clientsAccountsManagerForm_obj.PrivateCellularTextBox.Text = (string)clientsSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][clientsSecurityDataBaseDataTable_obj.PrivateCellularColumn];

        clientsAccountsManagerForm_obj.EditedRecordIndex = int_SelectedUserAccountRowIndex;

        clientsAccountsManagerForm_obj.ShowDialog();
    }





    public static void ViewServerAccessRestrictionRule(int int_AccessRestrictionRuleRowIndex)
    {
        ServersAccessRestrictionRulesManagerForm serversAccessRestrictionRulesManagerForm_obj = new ServersAccessRestrictionRulesManagerForm();

        serversAccessRestrictionRulesManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.Count == 0) return;

        serversAccessRestrictionRulesManagerForm_obj.AddButton.Visible = false;

        string string_MACAddress = "";

        DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable serversAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules;

        serversAccessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
        serversAccessRestrictionRulesManagerForm_obj.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];
        serversAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPAddressColumn];

        string_MACAddress = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.MACAddressColumn];

        if (string_MACAddress.Length == 17)
        {
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.Text = string_MACAddress.Substring(0, 2);
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.Text = string_MACAddress.Substring(3, 2);
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.Text = string_MACAddress.Substring(6, 2);
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.Text = string_MACAddress.Substring(9, 2);
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.Text = string_MACAddress.Substring(12, 2);
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.Text = string_MACAddress.Substring(15, 2);
        }

        serversAccessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Checked = (bool)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

        serversAccessRestrictionRulesManagerForm_obj.RuleTypeComboBox.SelectedIndex = (int)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.RuleTypeColumn];

        serversAccessRestrictionRulesManagerForm_obj.EditedRecordIndex = int_AccessRestrictionRuleRowIndex;


        if (serversAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length >= 7) serversAccessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Checked = true;
        if (serversAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length >= 7) serversAccessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Checked = true;

        if (serversAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length == 0 && serversAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length == 0)
            serversAccessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Checked = true;

        serversAccessRestrictionRulesManagerForm_obj.AddButton.Visible =
        serversAccessRestrictionRulesManagerForm_obj.Visible =

        serversAccessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Enabled =
        serversAccessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Enabled =
        serversAccessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Enabled =

        serversAccessRestrictionRulesManagerForm_obj.RuleTypeComboBox.Enabled =
        serversAccessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Enabled = false;

        serversAccessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.ReadOnly =
        serversAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.ReadOnly =
        serversAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.ReadOnly =
        serversAccessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.ReadOnly =
        serversAccessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.ReadOnly =
        serversAccessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.ReadOnly =
        serversAccessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.ReadOnly =
        serversAccessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.ReadOnly =
        serversAccessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.ReadOnly = true;

        serversAccessRestrictionRulesManagerForm_obj.RestrictByIPAddressGroupBox.Enabled =
        serversAccessRestrictionRulesManagerForm_obj.RestrictByIPRangeGroupBox.Enabled =
        serversAccessRestrictionRulesManagerForm_obj.RestrictByMACAddressGroupBox.Enabled = true;

        serversAccessRestrictionRulesManagerForm_obj.ShowDialog();
    }

    public static void EditServerAccessRestrictionRule(int int_AccessRestrictionRuleRowIndex)
    {
        ServersAccessRestrictionRulesManagerForm serversAccessRestrictionRulesManagerForm_obj = new ServersAccessRestrictionRulesManagerForm();

        serversAccessRestrictionRulesManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.Count == 0) return;

        serversAccessRestrictionRulesManagerForm_obj.AddButton.Visible = false;

        string string_MACAddress = "";

        DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable serversAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules;

        serversAccessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
        serversAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];
        serversAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.IPAddressColumn];

        string_MACAddress = (string)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.MACAddressColumn];

        if (string_MACAddress.Length == 17)
        {
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.Text = string_MACAddress.Substring(0, 2);
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.Text = string_MACAddress.Substring(3, 2);
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.Text = string_MACAddress.Substring(6, 2);
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.Text = string_MACAddress.Substring(9, 2);
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.Text = string_MACAddress.Substring(12, 2);
            serversAccessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.Text = string_MACAddress.Substring(15, 2);
        }

        serversAccessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Checked = (bool)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

        serversAccessRestrictionRulesManagerForm_obj.RuleTypeComboBox.SelectedIndex = (int)serversAccessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][serversAccessRestrictionRulesDataTable_obj.RuleTypeColumn];

        serversAccessRestrictionRulesManagerForm_obj.EditedRecordIndex = int_AccessRestrictionRuleRowIndex;


        if (serversAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length >= 7) serversAccessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Checked = true;
        if (serversAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length >= 7) serversAccessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Checked = true;

        if (serversAccessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length == 0 && serversAccessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length == 0)
            serversAccessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Checked = true;

        serversAccessRestrictionRulesManagerForm_obj.ShowDialog();
    }

    public static void ViewServerUserAccount(int int_SelectedUserAccountRowIndex)
    {
        ServersAccountsManagerForm serversAccountsManagerForm_obj = new ServersAccountsManagerForm();

        serversAccountsManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase.Rows.Count == 0) return;

        serversAccountsManagerForm_obj.ApplyButton.Visible = false;
        serversAccountsManagerForm_obj.AddButton.Visible = false;



        serversAccountsManagerForm_obj.LoginTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.UserNameTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.NewPasswordTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.ConfirmedPasswordTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.FirstNameTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.MiddleNameTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.LastNameTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.EMailAddressTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.ICQTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.CompanyTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.HomePhomeTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.WorkPhoneTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.PrivateCellularTextBox.ReadOnly = true;

        serversAccountsManagerForm_obj.LoginTextBox.Focus();

        DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable serversSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase;

        serversAccountsManagerForm_obj.LoginTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UINColumn];
        serversAccountsManagerForm_obj.UserNameTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserNameColumn];
        serversAccountsManagerForm_obj.NewPasswordTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserPasswordColumn];
        serversAccountsManagerForm_obj.ConfirmedPasswordTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserPasswordColumn];
        serversAccountsManagerForm_obj.FirstNameTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserFirstNameColumn];
        serversAccountsManagerForm_obj.LastNameTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserLastNameColumn];
        serversAccountsManagerForm_obj.MiddleNameTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserMiddleNameColumn];
        serversAccountsManagerForm_obj.EMailAddressTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.EMailColumn];
        serversAccountsManagerForm_obj.ICQTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.ICQColumn];
        serversAccountsManagerForm_obj.CompanyTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.CompanyColumn];
        serversAccountsManagerForm_obj.HomePhomeTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.HomePhoneColumn];
        serversAccountsManagerForm_obj.WorkPhoneTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.WorkPhoneColumn];
        serversAccountsManagerForm_obj.PrivateCellularTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.PrivateCellularColumn];

        serversAccountsManagerForm_obj.EditedRecordIndex = int_SelectedUserAccountRowIndex;

        serversAccountsManagerForm_obj.ShowDialog();

    }

    public static void EditServerUserAccount(int int_SelectedUserAccountRowIndex)
    {
        ServersAccountsManagerForm serversAccountsManagerForm_obj = new ServersAccountsManagerForm();

        serversAccountsManagerForm_obj.OverrideCancelButton.Text = StringFactory.GetString(143, MainForm.CurrentLanguage);

        if (ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase.Rows.Count == 0) return;

        serversAccountsManagerForm_obj.EditedRecordIndex = int_SelectedUserAccountRowIndex;

        serversAccountsManagerForm_obj.AddButton.Visible = false;

        serversAccountsManagerForm_obj.LoginTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.UserNameTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.NewPasswordTextBox.ReadOnly = true;
        serversAccountsManagerForm_obj.ConfirmedPasswordTextBox.ReadOnly = true;

        DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable serversSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase;

        serversAccountsManagerForm_obj.LoginTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UINColumn];
        serversAccountsManagerForm_obj.UserNameTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserNameColumn];
        serversAccountsManagerForm_obj.NewPasswordTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserPasswordColumn];
        serversAccountsManagerForm_obj.ConfirmedPasswordTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserPasswordColumn];
        serversAccountsManagerForm_obj.FirstNameTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserNameColumn];
        serversAccountsManagerForm_obj.LastNameTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserLastNameColumn];
        serversAccountsManagerForm_obj.MiddleNameTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.UserMiddleNameColumn];
        serversAccountsManagerForm_obj.EMailAddressTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.EMailColumn];
        serversAccountsManagerForm_obj.ICQTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.ICQColumn];
        serversAccountsManagerForm_obj.CompanyTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.CompanyColumn];
        serversAccountsManagerForm_obj.HomePhomeTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.HomePhoneColumn];
        serversAccountsManagerForm_obj.WorkPhoneTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.HomePhoneColumn];
        serversAccountsManagerForm_obj.PrivateCellularTextBox.Text = (string)serversSecurityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][serversSecurityDataBaseDataTable_obj.PrivateCellularColumn];

        serversAccountsManagerForm_obj.EditedRecordIndex = int_SelectedUserAccountRowIndex;

        serversAccountsManagerForm_obj.ShowDialog();
    }
}