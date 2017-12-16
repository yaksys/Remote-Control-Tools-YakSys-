using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;
using YakSys.Proxy.Exceptions;
using YakSys.Compression;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;

public enum SentDataType
{
    SystemData, ApplicationData, FileObject
}


public class MainTcpClient : TcpClient
{
    #region Constructor and Close Method

    public MainTcpClient()
    {       
        Statistic_BytesSent = Statistic_BytesReceived = Statistic_CompletedReceiveTasks = 0;
    }

    public new void Close()
    {
        MainTcpClient.IsConnected = false;

        base.Close();
    }

    #endregion

    #region SendData To Server method and his Environment

    ICompression iCompression_obj = null;

    MemoryStream memoryStream_DataToSend = new MemoryStream();

    byte byte_IsDataCompressed = 0, byte_IsDataEncrypted = 0;

    NetworkStream networkStream_ThisClient = null;

    public void SendData(byte[] byteArray_SentData, SentDataType SentDataType_Current)
    {
        try
        {
            lock (this)
            {
                if (networkStream_ThisClient == null) networkStream_ThisClient = this.GetStream();

                iCompression_obj = CompressionEnvironment.iCompressionArray_obj[ClientSettingsEnvironment.SendingSystemDataCompressAlgorithmIndex];

                memoryStream_DataToSend.SetLength(0);

                byte_IsDataCompressed = byte_IsDataEncrypted = 0;

                #region Запись в поток размера данных и информации о шифровании\сжатии

                if (
                    byteArray_SentData.Length > 256 &&
                    (
                    (ClientSettingsEnvironment.ToCompressSentSystemData && SentDataType_Current == SentDataType.ApplicationData)
                    ||
                    (ClientSettingsEnvironment.ToCompressSentFiles && SentDataType_Current == SentDataType.FileObject)
                    )
                  )
                {
                    if (SentDataType_Current == SentDataType.ApplicationData)
                    {
                        iCompression_obj = CompressionEnvironment.iCompressionArray_obj[ClientSettingsEnvironment.SendingSystemDataCompressAlgorithmIndex + 1];

                        byte_IsDataCompressed = (byte)(ClientSettingsEnvironment.SendingSystemDataCompressAlgorithmIndex + 1);
                    }
                    else
                    {
                        iCompression_obj = CompressionEnvironment.iCompressionArray_obj[ClientSettingsEnvironment.SentFilesCompressAlgorithmIndex + 1];

                        byte_IsDataCompressed = (byte)(ClientSettingsEnvironment.SentFilesCompressAlgorithmIndex + 1);
                    }

                    byteArray_SentData = iCompression_obj.Compress(byteArray_SentData, false);
                }

                if (
                    (ClientSettingsEnvironment.ToEncryptSentSystemData && SentDataType_Current == SentDataType.ApplicationData)
                    ||
                    (ClientSettingsEnvironment.ToEncryptSentFiles && SentDataType_Current == SentDataType.FileObject)
                  )
                {
                    if (SentDataType_Current == SentDataType.ApplicationData)
                    {
                        byteArray_SentData = this.EncryptData(byteArray_SentData, ClientSettingsEnvironment.SendingSystemDataEncryptAlgorithmIndex + 1);
                        byte_IsDataEncrypted = (byte)(ClientSettingsEnvironment.SendingSystemDataEncryptAlgorithmIndex + 1);
                    }
                    else
                    {
                        byteArray_SentData = this.EncryptData(byteArray_SentData, ClientSettingsEnvironment.SentFilesEncryptAlgorithmIndex + 1);
                        byte_IsDataEncrypted = (byte)(ClientSettingsEnvironment.SentFilesEncryptAlgorithmIndex + 1);
                    }
                }

                memoryStream_DataToSend.Write(BitConverter.GetBytes((int)byteArray_SentData.Length), 0, 4);

                memoryStream_DataToSend.WriteByte(byte_IsDataCompressed);
                memoryStream_DataToSend.WriteByte(byte_IsDataEncrypted);

                #endregion

                memoryStream_DataToSend.Write(byteArray_SentData, 0, byteArray_SentData.Length);

                Statistic_BytesSent += memoryStream_DataToSend.ToArray().Length;

                networkStream_ThisClient.Write(memoryStream_DataToSend.ToArray(), 0, (int)memoryStream_DataToSend.ToArray().Length);
            }
        }
        catch
        {

        }
    }

    #endregion

    #region Local Members and Connection status monitors

    protected static bool bool_IsConnected = false;
    public static bool IsConnected
    {
        set
        {
            bool_IsConnected = value;
        }

        get
        {
            return bool_IsConnected;
        }
    }

    public Socket Socket
    {
        get
        {
            return this.Client;
        }

        set
        {
            this.Client = value;
        }
    }

    #endregion

    #region Crypto SubSystem

    string string_XMLStringWithPrivateRSAKeys = string.Empty;
    public string XMLStringWithPrivateRSAKeys
    {
        get
        {
            return string_XMLStringWithPrivateRSAKeys;
        }

        set
        {
            string_XMLStringWithPrivateRSAKeys = value;
        }
    }

    string string_XMLStringWithServersPublicRSAKeys = string.Empty;
    public string XMLStringWithServersPublicRSAKeys
    {
        get
        {
            return string_XMLStringWithServersPublicRSAKeys;
        }

        set
        {
            string_XMLStringWithServersPublicRSAKeys = value;
        }
    }

    public TripleDESCryptoServiceProvider tripleDES128bit_Session = null,
                                          tripleDES192bit_Session = null;

    public DESCryptoServiceProvider DES64bit_Session = null;

    public RC2CryptoServiceProvider RCtwo40bit_Session = null,
                                    RCtwo128bit_Session = null;

    public RijndaelManaged AES256bit_PrimaryObj = null,
                           AES128bit_Session = null,
                           AES256bit_Session = null;

    public ICryptoTransform
            iCryptoTransform_DecryptorAES256bit_PrimaryObj = null,
            iCryptoTransform_DecryptorAES128bit = null,
            iCryptoTransform_DecryptorAES256bit = null,
            iCryptoTransform_DecryptorDES64bit = null,
            iCryptoTransform_DecryptorRCTwo40bit = null,
            iCryptoTransform_DecryptorRCTwo128bit = null,
            iCryptoTransform_DecryptorTripleDES128bit = null,
            iCryptoTransform_DecryptorTripleDES192bit = null,

            iCryptoTransform_EncryptorAES256bit_PrimaryObj = null,
            iCryptoTransform_EncryptorAES128bit = null,
            iCryptoTransform_EncryptorAES256bit = null,
            iCryptoTransform_EncryptorDES64bit = null,
            iCryptoTransform_EncryptorRCTwo40bit = null,
            iCryptoTransform_EncryptorRCTwo128bit = null,
            iCryptoTransform_EncryptorTripleDES128bit = null,
            iCryptoTransform_EncryptorTripleDES192bit = null;

    public CryptoStream cryptoStream_DecryptRecievedData = null;

    public ICryptoTransform
            iCryptoTransform_NecessaryEncryptor = null,
            iCryptoTransform_NecessaryDecryptor = null;

    MemoryStream memoryStream_EncryptedData = new MemoryStream(),
                 memoryStream_DecryptedData = new MemoryStream();

    public void InitEncryptors()
    {
        this.iCryptoTransform_EncryptorAES128bit = this.AES128bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorAES256bit = this.AES256bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorDES64bit = this.DES64bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorRCTwo40bit = this.RCtwo40bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorRCTwo128bit = this.RCtwo128bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorTripleDES128bit = this.tripleDES128bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorTripleDES192bit = this.tripleDES192bit_Session.CreateEncryptor();
    }

    public void InitDecryptors()
    {
        this.iCryptoTransform_DecryptorAES128bit = this.AES128bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorAES256bit = this.AES256bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorDES64bit = this.DES64bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorRCTwo40bit = this.RCtwo40bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorRCTwo128bit = this.RCtwo128bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorTripleDES128bit = this.tripleDES128bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorTripleDES192bit = this.tripleDES192bit_Session.CreateDecryptor();
    }


    ICryptoTransform GetNecessaryEncryptor(int int_AlgorithmIndex)
    {
        switch (int_AlgorithmIndex)
        {
            case 1:
                return iCryptoTransform_EncryptorAES128bit;

            case 2:
                return iCryptoTransform_EncryptorAES256bit;

            case 3:
                return iCryptoTransform_EncryptorDES64bit;

            case 4:
                return iCryptoTransform_EncryptorRCTwo40bit;

            case 5:
                return iCryptoTransform_EncryptorRCTwo128bit;

            case 6:
                return iCryptoTransform_EncryptorTripleDES128bit;

            case 7:
                return iCryptoTransform_EncryptorTripleDES192bit;

            case 8:
                return iCryptoTransform_EncryptorAES256bit_PrimaryObj;
        }

        return null;
    }

    ICryptoTransform GetNecessaryDecryptor(int int_AlgorithmIndex)
    {
        switch (int_AlgorithmIndex)
        {
            case 1:
                return iCryptoTransform_DecryptorAES128bit;

            case 2:
                return iCryptoTransform_DecryptorAES256bit;

            case 3:
                return iCryptoTransform_DecryptorDES64bit;

            case 4:
                return iCryptoTransform_DecryptorRCTwo40bit;

            case 5:
                return iCryptoTransform_DecryptorRCTwo128bit;

            case 6:
                return iCryptoTransform_DecryptorTripleDES128bit;

            case 7:
                return iCryptoTransform_DecryptorTripleDES192bit;

            case 8:
                return iCryptoTransform_DecryptorAES256bit_PrimaryObj;
        }

        return null;
    }


    public byte[] EncryptData(byte[] byteArray_DataToEncrypt, int int_AlgorithmIndex)
    {
        lock (this)
        {
            iCryptoTransform_NecessaryEncryptor = this.GetNecessaryEncryptor(int_AlgorithmIndex);

            memoryStream_EncryptedData.SetLength(0);

            CryptoStream cryptoStream = new CryptoStream(memoryStream_EncryptedData, iCryptoTransform_NecessaryEncryptor, CryptoStreamMode.Write);

            cryptoStream.Write(byteArray_DataToEncrypt, 0, byteArray_DataToEncrypt.Length);

            cryptoStream.FlushFinalBlock();

            memoryStream_EncryptedData.SetLength(memoryStream_EncryptedData.Position);

            return memoryStream_EncryptedData.ToArray();
        }
    }

    public byte[] DecryptData(MemoryStream memoryStream_EncryptedData, int int_AlgorithmIndex)
    {
        lock (this)
        {
            int int_ReadedByte = 0;

            memoryStream_DecryptedData.SetLength(0);

            iCryptoTransform_NecessaryDecryptor = this.GetNecessaryDecryptor(int_AlgorithmIndex);

            cryptoStream_DecryptRecievedData = new CryptoStream(memoryStream_EncryptedData,
            iCryptoTransform_NecessaryDecryptor, CryptoStreamMode.Read);

            while (true)
            {
                int_ReadedByte = cryptoStream_DecryptRecievedData.ReadByte();

                if (int_ReadedByte == -1) break;

                memoryStream_DecryptedData.WriteByte((byte)int_ReadedByte);
            }

            cryptoStream_DecryptRecievedData.Flush();

            return memoryStream_DecryptedData.ToArray();
        }
    }

    #endregion

    static long long_BytesSent = 0;
    public static long Statistic_BytesSent
    {
        get
        {
            return long_BytesSent;
        }

        set
        {
            long_BytesSent = value;
        }
    }

    static long long_BytesReceived = 0;
    public static long Statistic_BytesReceived
    {
        get
        {
            return long_BytesReceived;
        }

        set
        {
            long_BytesReceived = value;
        }
    }

    static long long_CompletedReceiveTasks = 0;
    public static long Statistic_CompletedReceiveTasks
    {
        get
        {
            return long_CompletedReceiveTasks;
        }

        set
        {
            long_CompletedReceiveTasks = value;
        }
    }

    static string string_ConnectionStatus = "";
    public static string ConnectionStatus
    {
        get
        {
            return string_ConnectionStatus;
        }

        set
        {
            string_ConnectionStatus = value;
        }
    }

}


public class NetworkAction
{
    public static MainTcpClient tcpClient_MainClient;
    MainTcpClient TcpClient
    {
        get
        {
            return tcpClient_MainClient;
        }
    }


    void ConnectionLostProcess()
    {
        if (MainTcpClient.IsConnected == false) return;

        MessageBox.Show(ClientStringFactory.GetString(226, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

        DisconnectFromServer();
    }


    //Main data receiving loop!
    public void DataReceivingCycle(object socket_Client)
    {
        try
        {
            YakSys.Compression.CommonEnvironment commonEnvironment_obj = new YakSys.Compression.CommonEnvironment();

            CompressionEnvironment.DeflateCompressionWrapper deflateCompressionWrapper_obj = new CompressionEnvironment.DeflateCompressionWrapper();

            byte[] byteArray_SystemData = new byte[6], byteArray_ReceivedData = null;

            int int_ReceivedDataLength = 0, int_TotalReceived = 0, int_TotalAvailable = 0, int_ActionNumber = 0,
                int_LastConnectionCheck = 0, int_DataEncryptAlgorithmIndex = 0, int_DataCompressionAlgorithmIndex = 0;

            MemoryStream memoryStream_ReceivedData = new MemoryStream(),
                         memoryStream_DecryptedData = new MemoryStream();

            LocalAction localAction_obj = null;

            TcpClient.Client = (Socket)socket_Client;

            ObjCopy.obj_RemoteCallAction.SendAuthorizationRequest();

            MainTcpClient.IsConnected = true;

            //GetData cycle while Client is connected!
            while (MainTcpClient.IsConnected)// || MainTcpClient.InstanceCount > 0) //!! проблема с MainTcpClient.InstanceCount! он неправильно считается и не пускает иногда на соединения из за этого!!!
            {
                if (TcpClient.Available > 0)
                {
                    int_LastConnectionCheck = 0;

                    #region receive data from socket

                    memoryStream_ReceivedData.SetLength(0);
                    memoryStream_DecryptedData.SetLength(0);

                    TcpClient.Socket.Receive(byteArray_SystemData);

                    int_ReceivedDataLength = BitConverter.ToInt32(byteArray_SystemData, 0);

                    int_DataCompressionAlgorithmIndex = byteArray_SystemData[4];
                    int_DataEncryptAlgorithmIndex = byteArray_SystemData[5];

                    int_TotalReceived = 0;
                    int_TotalAvailable = 0;

                    while (int_TotalReceived != int_ReceivedDataLength)
                    {
                        int_TotalAvailable = TcpClient.Available;

                        if (int_TotalAvailable > 0)
                        {
                            if (int_TotalAvailable > (int_ReceivedDataLength - int_TotalReceived))
                            {
                                if (int_ReceivedDataLength - int_TotalReceived < 0)
                                {
                                    DisconnectFromServer();
                                }

                                byteArray_ReceivedData = new byte[int_ReceivedDataLength - int_TotalReceived];
                            }

                            else
                            {
                                byteArray_ReceivedData = new byte[int_TotalAvailable];
                            }

                            int_TotalReceived += TcpClient.Socket.Receive(byteArray_ReceivedData);

                            memoryStream_ReceivedData.Write(byteArray_ReceivedData, 0, byteArray_ReceivedData.Length);
                        }
                    }

                    if (byteArray_ReceivedData == null)
                    {
                        Thread.Sleep(100);

                        continue;
                    }

                    #endregion

                    localAction_obj = new LocalAction();
                    localAction_obj.CurrentlyUsedTcpClient = TcpClient;

                    #region decrypt

                    if (int_DataEncryptAlgorithmIndex != 0)// Encrypted Data
                    {
                        memoryStream_ReceivedData.Position = 0;
                        memoryStream_DecryptedData.SetLength(0);

                        memoryStream_DecryptedData = new MemoryStream(TcpClient.DecryptData(memoryStream_ReceivedData, int_DataEncryptAlgorithmIndex));

                        localAction_obj.RecivedData = new byte[memoryStream_DecryptedData.ToArray().Length];

                        memoryStream_DecryptedData.Position = 0;
                        memoryStream_DecryptedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);
                    }
                    else
                    {

                        localAction_obj.RecivedData = new byte[memoryStream_ReceivedData.ToArray().Length];

                        memoryStream_ReceivedData.Position = 0;
                        memoryStream_ReceivedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);
                    }

                    #endregion

                    #region decompress

                    if (int_DataCompressionAlgorithmIndex > 0 && int_DataCompressionAlgorithmIndex < 4)
                    {
                        localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                    }
                    if (int_DataCompressionAlgorithmIndex == 4)
                    {
                        localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                    }

                    #endregion

                    int_ActionNumber = localAction_obj.ActionNumber = BitConverter.ToInt32(localAction_obj.RecivedData, 0);

                    if (int_ActionNumber == -5)
                    {
                        int_LastConnectionCheck = 0;

                        continue;
                    }

                    localAction_obj.ActionAllocator();

                    memoryStream_ReceivedData.SetLength(0);

                    MainTcpClient.Statistic_BytesReceived += int_TotalReceived;
                    MainTcpClient.Statistic_CompletedReceiveTasks++;
                }

                Thread.Sleep(5);

                int_LastConnectionCheck++;

                if (int_LastConnectionCheck > 10000)
                {
                    ConnectionLostProcess();
                }
            }
        }

        catch (Exception exception_obj)
        {


#if DEBUG
            MessageBox.Show(exception_obj.Message + " : " + exception_obj.StackTrace + "\n" + exception_obj.Source);
#endif

            DisconnectFromServer();
            
            return;
        }

    }


    TcpClient tcpClient_LinkToCloseByTimeOut = null;

    int int_GlobalTimeOutMS = 0;

    protected void ConnectionTimeOutWatcher()
    {
        if (int_GlobalTimeOutMS <= 0 || tcpClient_LinkToCloseByTimeOut == null) return;

        int int_InternalTimeOutCount = 0;
        while (int_InternalTimeOutCount <= int_GlobalTimeOutMS)
        {
            Thread.Sleep(10);
            int_InternalTimeOutCount += 10;
        }

        if (tcpClient_LinkToCloseByTimeOut != null) tcpClient_LinkToCloseByTimeOut.Close();
    }



    #region CSP Support---------------------------------------------------------------------------------------------------------------

    public enum CSPConnectionStatus
    {
        Disconnected, TryToConnect, WaitForServer, Connected
    }

    public static CSPConnectionStatus CSPCurrentConnectionStatus = CSPConnectionStatus.Disconnected;

    //!!!! надо что бы логин и пароль к серверу не брались из маинклент форм статически!
    // при коннекте через обычный и через сервис - из разных мест устанавливют переменные логина и пароля!
    public void OnClientDisconnected(CSP.ConnectedClient connectedClient_obj)
    {
        NetworkAction.connectedCSPClient_obj = connectedClient_obj;

        DisconnectFromCSP(ref connectedClient_obj);

        //!! this.DisconnectFromServer(); проверить все выховы DisconnectFromServer и убрать лишние!
    }

    public void OnClientInterConnectionClosed(CSP.ConnectedClient connectedClient_obj)
    {
        MainTcpClient.IsConnected = false;

        CSPCurrentConnectionStatus = CSPConnectionStatus.WaitForServer;

        MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(767, ClientSettingsEnvironment.CurrentLanguage);
    }

    public void OnCSPInterConnectionEstablished(CSP.ConnectedClient connectedClient_obj)
    {
        NetworkAction.connectedCSPClient_obj = connectedClient_obj;

        tcpClient_MainClient = new MainTcpClient();

        tcpClient_MainClient.Client = connectedClient_obj.AppliedChannel.Client;

        new Thread(new ParameterizedThreadStart(this.DataReceivingCycle)).Start((object)connectedClient_obj.AppliedChannel.Client);

        ObjCopy.obj_MainClientForm.SetStatistic_ConnectedAt = DateTime.Now.ToLongTimeString();
        
        ObjCopy.obj_MainClientForm.SetStatistic_BytesSent = 0;
        ObjCopy.obj_MainClientForm.SetStatistic_BytesReceived = 0;
        ObjCopy.obj_MainClientForm.SetStatistic_CompletedTasks = 0;

        CSPCurrentConnectionStatus = CSPConnectionStatus.Connected;
    }

    void OnClientSuccessfullyConnectedEvent(CSP.ConnectedClient connectedClient_obj)
    {
        NetworkAction.connectedCSPClient_obj = connectedClient_obj;

        CSPCurrentConnectionStatus = CSPConnectionStatus.WaitForServer;            
        MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(767, ClientSettingsEnvironment.CurrentLanguage);        
    }

    public static CSP.ConnectedClient connectedCSPClient_obj = null, connectedClient_ServersListRetriever = null;

    string string_LastClientConnectionParam_ServiceIPAddress = string.Empty, string_LastClientConnectionParam_CSPPassword = string.Empty,
          string_LastClientConnectionParam_YakSysServerLogin = string.Empty, string_LastClientConnectionParam_YakSysServerPassword = string.Empty;

    int int_LastClientConnectionParam_ServicePort = 5545;
    ulong ulong_LastClientConnectionParam_CSPLoginUIN = 0, ulong_LastClientConnectionParam_InterConnectedUIN = 0;

    bool bool_LastClientConnectionParam_WaitForServer = false;
    bool bool_LastClientConnectionParam_UseCommonCSPServer = false;
    bool bool_LastClientConnectionParam_KeepConnectionAlive = false;

    public void ConnectClientToYakSysServerUsingCSP(bool bool_UseCommonCSPServer, string string_ServiceIPAddress, int int_ServicePort, ulong ulong_CSPLoginUIN, string string_CSPPassword, 
                                                ulong ulong_InterConnectedUIN, string string_YakSysServerLogin, string string_YakSysServerPassword, bool bool_WaitForServer, bool bool_KeepConnectionAlive)
    {
        if (NetworkAction.CSPCurrentConnectionStatus != CSPConnectionStatus.Disconnected)
        {
            return;
        }

        if (Monitor.TryEnter(this, 500) == true)
        {
            try
            {
                bool_LastClientConnectionParam_UseCommonCSPServer = bool_UseCommonCSPServer;

                string_LastClientConnectionParam_ServiceIPAddress = string_ServiceIPAddress;
                string_LastClientConnectionParam_CSPPassword = string_CSPPassword;
                int_LastClientConnectionParam_ServicePort = int_ServicePort;

                ulong_LastClientConnectionParam_CSPLoginUIN = ulong_CSPLoginUIN;
                ulong_LastClientConnectionParam_InterConnectedUIN = ulong_InterConnectedUIN;

                string_LastClientConnectionParam_YakSysServerLogin = string_YakSysServerLogin;
                string_LastClientConnectionParam_YakSysServerPassword = string_YakSysServerPassword;

                bool_LastClientConnectionParam_WaitForServer = bool_WaitForServer;
                bool_LastClientConnectionParam_KeepConnectionAlive = bool_KeepConnectionAlive;

                new Thread(new ThreadStart(ConnectClientToYakSysServerUsingCSP)).Start();
            }

            catch
            {
                this.DisconnectFromCSP(ref connectedCSPClient_obj);
            }
        }
    }

    //!! щеё куча ошибок ..напр. главное окно говорит что no connected а cspform говорит что коннектед .. 
    //это после эсцепшена на СС вылетало (retuns NULL) ... а на СС межсоединение добавлялось дважды между клиентом и сервером!!!
    void ConnectClientToYakSysServerUsingCSP()
    {
        if (CSPCurrentConnectionStatus != CSPConnectionStatus.Disconnected)
        {
            return;
        }
        else
        {
            CSPCurrentConnectionStatus = CSPConnectionStatus.TryToConnect;
        }

        try
        {
            if (bool_LastClientConnectionParam_UseCommonCSPServer == true)
            {
                string_LastClientConnectionParam_ServiceIPAddress = CSP.ConnectingServiceProvider.GetCommonCSPIPString();

                System.Net.IPAddress iPAddress_ParsedCSIP;

                if (System.Net.IPAddress.TryParse(string_LastClientConnectionParam_ServiceIPAddress, out iPAddress_ParsedCSIP) == false)
                {
                    MessageBox.Show(ClientStringFactory.GetString(735, ClientSettingsEnvironment.CurrentLanguage));

                    return;
                }
            }

            CSP.CommonNetworkEvents.ClientDisconnectedEvent += new CSP.CommonNetworkEvents.ClientDisconnectedEventHandler(OnClientDisconnected);
            CSP.CommonNetworkEvents.ClientEnteringNewInterConnectionProcessEvent += new CSP.CommonNetworkEvents.ClientEnteringNewInterConnectionProcessEventHandler(OnCSPInterConnectionEstablished);
            CSP.CommonNetworkEvents.ClientInterConnectionClosedEvent += new CSP.CommonNetworkEvents.ClientInterConnectionClosedEventHandler(OnClientInterConnectionClosed);
            CSP.CommonNetworkEvents.ClientSuccessfullyConnectedEvent += new CSP.CommonNetworkEvents.ClientSuccessfullyConnectedEventHandler(OnClientSuccessfullyConnectedEvent);

            MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(354, ClientSettingsEnvironment.CurrentLanguage); //вниз ставить нельзя. при событии дисконнекта статус соединения главной формы последним обновит TryToConnect

            ObjCopy.obj_MainClientForm.LoginForConnection = string_LastClientConnectionParam_YakSysServerLogin;
            ObjCopy.obj_MainClientForm.PasswordForConnection = string_LastClientConnectionParam_YakSysServerPassword;

            CSP.ConnectingServiceProvider connectingServiceProvider_obj = new CSP.ConnectingServiceProvider();

            connectingServiceProvider_obj.ConnectClientToYakSysConnectingService(string_LastClientConnectionParam_ServiceIPAddress, int_LastClientConnectionParam_ServicePort, ulong_LastClientConnectionParam_CSPLoginUIN, ulong_LastClientConnectionParam_InterConnectedUIN, string_LastClientConnectionParam_CSPPassword, bool_LastClientConnectionParam_WaitForServer, bool_LastClientConnectionParam_KeepConnectionAlive);

            return;
        }
        catch
        {
            ObjCopy.obj_MainClientForm.EnableAllControls();

            CSP.CommonNetworkEvents.ClientDisconnectedEvent -= new CSP.CommonNetworkEvents.ClientDisconnectedEventHandler(OnClientDisconnected);
            CSP.CommonNetworkEvents.ClientEnteringNewInterConnectionProcessEvent -= new CSP.CommonNetworkEvents.ClientEnteringNewInterConnectionProcessEventHandler(OnCSPInterConnectionEstablished);
            CSP.CommonNetworkEvents.ClientInterConnectionClosedEvent -= new CSP.CommonNetworkEvents.ClientInterConnectionClosedEventHandler(OnClientInterConnectionClosed);
            CSP.CommonNetworkEvents.ClientSuccessfullyConnectedEvent -= new CSP.CommonNetworkEvents.ClientSuccessfullyConnectedEventHandler(OnClientSuccessfullyConnectedEvent);

            return;
        }
        finally
        {
        }
    }

    public CSP.ConnectedClient ConnectSystemClientChannelToCSP(string string_ServiceIPAddress, int int_ServicePort, ulong ulong_LoginUIN, string string_Password)
    {
        CSP.ConnectingServiceProvider connectingServiceProvider_obj = new CSP.ConnectingServiceProvider();

        CSP.ConnectedClient connectedClient_InternalObj = null;

        connectedClient_InternalObj = connectingServiceProvider_obj.ConnectSystemClientChannelToYakSysConnectingService(string_ServiceIPAddress, int_ServicePort, ulong_LoginUIN, string_Password);

        if (connectedClient_InternalObj == null)
        {
            if (MainTcpClient.IsConnected)
            {
                MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(235, ClientSettingsEnvironment.CurrentLanguage);
            }
            else
            {
                MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(78, ClientSettingsEnvironment.CurrentLanguage);
            }

            ObjCopy.obj_MainClientForm.EnableAllControls();

            return null;
        }

        return connectedClient_InternalObj;
    }

    public bool IsSystemChannelConnected(CSP.ConnectedClient connectedClient_obj)
    {
        if (connectedClient_obj == null || connectedClient_obj.SystemChannel == null || connectedClient_obj.SystemChannel.IsConnected == false || connectedClient_obj.SystemChannel.IsAuthorized == false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool IsAppliedChannelConnected(CSP.ConnectedClient connectedClient_obj)
    {
        if (connectedClient_obj == null || connectedClient_obj.AppliedChannel == null || connectedClient_obj.AppliedChannel.IsConnected == false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool IsCSPClientObjConnected()
    {
        if (connectedCSPClient_obj != null && connectedCSPClient_obj.SystemChannel != null && connectedCSPClient_obj.SystemChannel.IsConnected == true)
        {
            try
            {
                connectedCSPClient_obj.CheckConnection();
            }
            catch
            {
                try
                {
                    connectedCSPClient_obj.Disconnect();

                    return false;
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }
        
    public bool IsCSPObjConnected(CSP.ConnectedClient checkedCSPClient_obj)
    {
        if (checkedCSPClient_obj != null && checkedCSPClient_obj.SystemChannel != null && checkedCSPClient_obj.SystemChannel.IsConnected == true)
        {
            try
            {
                checkedCSPClient_obj.CheckConnection();
            }
            catch
            {
                try
                {
                    checkedCSPClient_obj.Disconnect();

                    return false;
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsObjectNull(ref Object objToWatch)
    {
        int int_SleepCount = 0;

        while (objToWatch == null)
        {
            Thread.Sleep(500);

            int_SleepCount++;

            if (int_SleepCount > 10) return true;
        }

        return false;
    }

    public void DisconnectFromCSP(ref CSP.ConnectedClient connectedClient_ObjToDisconnect)
    {
        try
        {
            int int_SleepCount = 0;

            while (connectedClient_ObjToDisconnect == null)
            {
                Thread.Sleep(300);

                int_SleepCount++;

                if (int_SleepCount > 10) break;
            }

            if (connectedClient_ObjToDisconnect != null) //!!если отключились до того как waitforserver перешел в connected то не будет дисконнекта так как connectedClient_ObjToDisconnect ЕЩЁ равно null 
            {
                connectedClient_ObjToDisconnect.Disconnect();
            }

            connectedClient_ObjToDisconnect = null;
        }
        catch
        {

        }
        finally
        {
            CSP.CommonNetworkEvents.ClientDisconnectedEvent -= new CSP.CommonNetworkEvents.ClientDisconnectedEventHandler(OnClientDisconnected);
            CSP.CommonNetworkEvents.ClientEnteringNewInterConnectionProcessEvent -= new CSP.CommonNetworkEvents.ClientEnteringNewInterConnectionProcessEventHandler(OnCSPInterConnectionEstablished);
            CSP.CommonNetworkEvents.ClientInterConnectionClosedEvent -= new CSP.CommonNetworkEvents.ClientInterConnectionClosedEventHandler(OnClientInterConnectionClosed);
            CSP.CommonNetworkEvents.ClientSuccessfullyConnectedEvent -= new CSP.CommonNetworkEvents.ClientSuccessfullyConnectedEventHandler(OnClientSuccessfullyConnectedEvent);

            MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(78, ClientSettingsEnvironment.CurrentLanguage);

            CSPCurrentConnectionStatus = CSPConnectionStatus.Disconnected;

            ObjCopy.obj_MainClientForm.EnableAllControls();

            MainTcpClient.IsConnected = false;
        }
    }

    #endregion------------------------------------------------------------------------------------------------------------------------



    public void ConnectToServer()
    {
        try
        {            
            if (MainTcpClient.IsConnected)
            {
                MessageBox.Show(ClientStringFactory.GetString(227, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);

                return;
            }

            if (!MainTcpClient.IsConnected)
            {
                try
                {
                    if (ObjCopy.obj_MainClientForm.ServerPort == -1 || ObjCopy.obj_MainClientForm.ProxyPort == -1)
                    {
                        return;
                    }

                    tcpClient_MainClient = new MainTcpClient();
                    
                    ObjCopy.obj_MainClientForm.SetStatistic_BytesSent = 0;
                    ObjCopy.obj_MainClientForm.SetStatistic_BytesReceived = 0;
                    ObjCopy.obj_MainClientForm.SetStatistic_CompletedTasks = 0;

                    if (!ObjCopy.obj_MainClientForm.UseProxyServer)
                    {
                        tcpClient_LinkToCloseByTimeOut = tcpClient_MainClient;

                        int_GlobalTimeOutMS = ObjCopy.obj_MainClientForm.ConnectionTimeOut;

                        Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));

                        thread_ConnectionTimeOutWatcher.Start();

                        tcpClient_MainClient.Connect(ObjCopy.obj_MainClientForm.ServerHost, ObjCopy.obj_MainClientForm.ServerPort);

                        thread_ConnectionTimeOutWatcher.Abort();
                    }
                    else
                    {
                        YakSys.Proxy.ProxyProvider proxyProvider_obj = new YakSys.Proxy.ProxyProvider();

                        proxyProvider_obj.SendingSocks4ConnectionRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_SendingSocks4ConnectionRequest);
                        proxyProvider_obj.SendingSocks5AuthenticationRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_SendingSocks5AuthenticationRequest);
                        proxyProvider_obj.SendingSocks5ConnectionRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_SendingSocks5ConnectionRequest);
                        proxyProvider_obj.SendingSocks5RequestDetails += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_SendingSocks5RequestDetails);

                        proxyProvider_obj.WaitingForReplyToSocks4ConnectionRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_WaitingForReplyToSocks4ConnectionRequest);
                        proxyProvider_obj.WaitingForReplyToSocks5AuthenticationRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_WaitingForReplyToSocks5AuthenticationRequest);
                        proxyProvider_obj.WaitingForReplyToSocks5ConnectionRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_WaitingForReplyToSocks5ConnectionRequest);
                        proxyProvider_obj.WaitingForReplyToSocks5RequestDetails += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(ProxyProvider_WaitingForReplyToSocks5RequestDetails);

                        if (ObjCopy.obj_MainClientForm.ProxyTypeIndex < 0)
                        {
                            MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(465, ClientSettingsEnvironment.CurrentLanguage));

                            return;
                        }

                        YakSys.Proxy.ProxyProvider.SerialNumber = "4688445487";
                        YakSys.Proxy.ProxyProvider.RegistrationName = "YakSys";

                        TcpClient tcpClient_TemporaryObj = tcpClient_MainClient;

                        if (ObjCopy.obj_MainClientForm.ProxyTypeIndex == 0)
                            proxyProvider_obj.ConnectThroughSocks4Proxy(ref tcpClient_TemporaryObj, ObjCopy.obj_MainClientForm.ServerHost, ObjCopy.obj_MainClientForm.ServerPort, ObjCopy.obj_MainClientForm.ProxyHost, ObjCopy.obj_MainClientForm.ProxyPort, ObjCopy.obj_MainClientForm.UseProxyResolveHostNames, ObjCopy.obj_MainClientForm.ProxyTimeOut);

                        if (ObjCopy.obj_MainClientForm.ProxyTypeIndex == 1)
                        {
                            if (ObjCopy.obj_MainClientForm.NeenProxyAuthentication == false)
                            {
                                proxyProvider_obj.ConnectThroughSocks5Proxy(ref tcpClient_TemporaryObj, ObjCopy.obj_MainClientForm.ServerHost, ObjCopy.obj_MainClientForm.ServerPort, ObjCopy.obj_MainClientForm.ProxyHost, ObjCopy.obj_MainClientForm.ProxyPort, ObjCopy.obj_MainClientForm.UseProxyResolveHostNames, ObjCopy.obj_MainClientForm.ProxyTimeOut);
                            }

                            if (ObjCopy.obj_MainClientForm.NeenProxyAuthentication)
                            {
                                proxyProvider_obj.ConnectThroughSocks5Proxy(ref tcpClient_TemporaryObj, ObjCopy.obj_MainClientForm.ServerHost, ObjCopy.obj_MainClientForm.ServerPort, ObjCopy.obj_MainClientForm.ProxyHost, ObjCopy.obj_MainClientForm.ProxyPort, ObjCopy.obj_MainClientForm.Socks5UserName, ObjCopy.obj_MainClientForm.Socks5Password, ObjCopy.obj_MainClientForm.UseProxyResolveHostNames, ObjCopy.obj_MainClientForm.ProxyTimeOut);
                            }
                        }

                        if (ObjCopy.obj_MainClientForm.ProxyTypeIndex == 2)
                        {
                            if (ObjCopy.obj_MainClientForm.NeenProxyAuthentication == false)
                            {
                                proxyProvider_obj.ConnectThroughHTTPSProxy(ref tcpClient_TemporaryObj, ObjCopy.obj_MainClientForm.ServerHost, ObjCopy.obj_MainClientForm.ServerPort, ObjCopy.obj_MainClientForm.ProxyHost, ObjCopy.obj_MainClientForm.ProxyPort, ObjCopy.obj_MainClientForm.UseProxyResolveHostNames, ObjCopy.obj_MainClientForm.ProxyTimeOut);
                            }

                            if (ObjCopy.obj_MainClientForm.NeenProxyAuthentication)
                            {
                                proxyProvider_obj.ConnectThroughHTTPSProxy(ref tcpClient_TemporaryObj, ObjCopy.obj_MainClientForm.ServerHost, ObjCopy.obj_MainClientForm.ServerPort, ObjCopy.obj_MainClientForm.ProxyHost, ObjCopy.obj_MainClientForm.ProxyPort, ObjCopy.obj_MainClientForm.Socks5UserName, ObjCopy.obj_MainClientForm.Socks5Password, ObjCopy.obj_MainClientForm.UseProxyResolveHostNames, ObjCopy.obj_MainClientForm.ProxyTimeOut);
                            }
                        }
                    }

                    new Thread(new ParameterizedThreadStart(this.DataReceivingCycle)).Start(TcpClient.Client);

                    Thread.Sleep(1000);

                    ObjCopy.obj_MainClientForm.SetStatistic_ConnectedAt = DateTime.Now.ToLongTimeString();
                }

                catch (Socks5ServiceNotFoundException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(416, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (TimeOutException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(417, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (AuthenticationRequiredException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(418, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (NoAcceptableMethodsException)
                {
                    MessageBox.Show(ClientStringFactory.GetString(419, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (GeneralSocksServerFailureException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(420, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (ConnectionNotAllowedException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(421, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (NetworkUnreachableException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(422, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (HostUnreachableException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(423, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (ConnectionRefusedException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(424, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (TTLExpiredException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(425, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (UnsupportedSocksCommandException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(426, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (UnsupportedAddressTypeException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(427, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (ProxyConnectionException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(428, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (Socks4ServiceNotFoundException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(429, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (RequestRejectedOrFailed)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(430, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (IdentdOnClientNotResponse)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(431, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (DifferentUserIDs)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(432, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (UnableToResolveHostName)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(433, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (AuthenticationNotAllowedException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(434, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch (AuthenticationFailureException)
                {
                    MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(435, ClientSettingsEnvironment.CurrentLanguage));

                    tcpClient_MainClient.Close();
                }

                catch
                {
                    tcpClient_MainClient.Close();
                }


                finally
                {
                    if (MainTcpClient.IsConnected)
                    {
                        MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(261, ClientSettingsEnvironment.CurrentLanguage);

                    }
                    else
                    {
                        MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(78, ClientSettingsEnvironment.CurrentLanguage);
                    }

                    ObjCopy.obj_MainClientForm.EnableAllControls();
                }
            }
        }

        catch
        {
            tcpClient_MainClient.Close();
        }
    }
           
    public void DisconnectFromServer()
    {
        ObjCopy.obj_MainClientForm.EnableAllControls();
        ObjCopy.obj_MainClientForm.CurrentFilePath = "C:\\";

        MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(78, ClientSettingsEnvironment.CurrentLanguage);

        if (MainTcpClient.IsConnected)
        {
            ObjCopy.obj_RemoteCallAction.InformAboutDisconnect();

            try
            {
                if (MainTcpClient.IsConnected)
                {
                    if (tcpClient_MainClient != null)
                    {
                        tcpClient_MainClient.Close();
                    }
                    tcpClient_MainClient = null;

                    MainTcpClient.IsConnected = false;

                    DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Clear();
                    DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Clear();

                    LocalAction.bitmapData_obj = null;

                    LocalAction.image_ReceivedImage = null;

                    LocalAction.byteMultiDimArray_PreviousRegions = new byte[64][];
                }
            }

            catch (Exception exception_obj)
            {

            }

            if (MainTcpClient.IsConnected)
            {
                MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(261, ClientSettingsEnvironment.CurrentLanguage);
            }
            else
            {
                MainTcpClient.ConnectionStatus = ClientStringFactory.GetString(78, ClientSettingsEnvironment.CurrentLanguage);
            }
        }
    }

    private void ProxyProvider_SendingSocks4ConnectionRequest()
    {

    }

    private void ProxyProvider_SendingSocks5AuthenticationRequest()
    {

    }

    private void ProxyProvider_SendingSocks5ConnectionRequest()
    {

    }

    private void ProxyProvider_SendingSocks5RequestDetails()
    {

    }

    private void ProxyProvider_WaitingForReplyToSocks4ConnectionRequest()
    {

    }

    private void ProxyProvider_WaitingForReplyToSocks5AuthenticationRequest()
    {

    }

    private void ProxyProvider_WaitingForReplyToSocks5ConnectionRequest()
    {

    }

    private void ProxyProvider_WaitingForReplyToSocks5RequestDetails()
    {

    }

}


