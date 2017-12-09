using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using YakSys;
using YakSys.Compression;
using System.Runtime.InteropServices;

public enum SentDataType
{
    SystemData, ApplicationData, FileObject, ScreenShot, RTDVFrame
}

public enum ChannelType
{
    System, Applied
}

public enum ConnectingObjectType
{
    Client, Server
}


public class BaseConnectedObject : TcpClient
{
    public BaseConnectedObject()
    {
        rNGCryptoServiceProvider_RandomGenerator.GetBytes(byteArray_RandomAuthorizationCodeForClient);
    }

    #region SendData To Client method and his Environvment

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

                iCompression_obj = CompressionEnvironment.iCompressionArray_obj[this.CompressSendingSystemDataAlgorithm];

                memoryStream_DataToSend.SetLength(0);

                byte_IsDataCompressed = 0;
                byte_IsDataEncrypted = 0;

                #region Запись в поток размера данных и информации о шифровании\сжатии

                if (
                    byteArray_SentData.Length > 256
                    &&
                    (
                        (this.CompressSendingSystemDataAlgorithm > 0 && SentDataType_Current == SentDataType.ApplicationData)
                        ||
                        (this.CompressSendingFileObjectsDataAlgorithm > 0 && SentDataType_Current == SentDataType.FileObject)
                    )
                )
                {
                    if (SentDataType_Current == SentDataType.ApplicationData)
                    {
                        iCompression_obj = CompressionEnvironment.iCompressionArray_obj[this.CompressSendingSystemDataAlgorithm];

                        byte_IsDataCompressed = (byte)this.CompressSendingSystemDataAlgorithm;
                    }
                    else
                    {
                        iCompression_obj = CompressionEnvironment.iCompressionArray_obj[this.CompressSendingFileObjectsDataAlgorithm];

                        byte_IsDataCompressed = (byte)this.CompressSendingFileObjectsDataAlgorithm;
                    }

                    byteArray_SentData = iCompression_obj.Compress(byteArray_SentData, false);
                }

                if (
                    (this.EncryptSendingSystemDataAlgorithm > 0 && SentDataType_Current == SentDataType.ApplicationData)
                    ||
                    (this.EncryptSendingFileObjectsDataAlgorithm > 0 && SentDataType_Current == SentDataType.FileObject)
                    ||
                    (this.EncryptSendingScreenshotDataAlgorithm > 0 && SentDataType_Current == SentDataType.ScreenShot)
                )
                {
                    if (SentDataType_Current == SentDataType.ApplicationData)
                    {
                        byteArray_SentData = this.EncryptData(byteArray_SentData, this.EncryptSendingSystemDataAlgorithm);
                        byte_IsDataEncrypted = (byte)this.EncryptSendingSystemDataAlgorithm;
                    }

                    if (SentDataType_Current == SentDataType.FileObject)
                    {
                        byteArray_SentData = this.EncryptData(byteArray_SentData, this.EncryptSendingFileObjectsDataAlgorithm);
                        byte_IsDataEncrypted = (byte)this.EncryptSendingFileObjectsDataAlgorithm;
                    }

                    if (SentDataType_Current == SentDataType.ScreenShot)
                    {
                        byteArray_SentData = this.EncryptData(byteArray_SentData, this.EncryptSendingScreenshotDataAlgorithm);
                        byte_IsDataEncrypted = (byte)this.EncryptSendingScreenshotDataAlgorithm;
                    }
                }

                memoryStream_DataToSend.Write(BitConverter.GetBytes(byteArray_SentData.Length), 0, 4);

                memoryStream_DataToSend.WriteByte(byte_IsDataCompressed);
                memoryStream_DataToSend.WriteByte(byte_IsDataEncrypted);

                #endregion

                memoryStream_DataToSend.Write(byteArray_SentData, 0, byteArray_SentData.Length);

                // log and stat
                this.Statistic_BytesSent += memoryStream_DataToSend.ToArray().Length;
                ObjCopy.obj_MainForm.Statistic_BytesSent += this.Statistic_BytesSent;

                // send
                networkStream_ThisClient.Write(memoryStream_DataToSend.ToArray(), 0, (int)memoryStream_DataToSend.ToArray().Length);
            }
        }
        catch
        {
            this.Close();
        }
    }

    #endregion

    #region Crypto SubSystem

    bool bool_EncryptSendingSystemData = true;
    public bool EncryptSendingSystemData
    {
        get
        {
            return bool_EncryptSendingSystemData;
        }

        set
        {
            bool_EncryptSendingSystemData = value;
        }
    }

    byte[] byteArray_RandomAuthorizationCodeForClient = new Byte[256];
    public byte[] RandomAuthorizationCodeForClient
    {
        get
        {
            return byteArray_RandomAuthorizationCodeForClient;
        }
    }

    int int_EncryptSendingSystemDataAlgorithm = 0;
    public int EncryptSendingSystemDataAlgorithm
    {
        set
        {
            int_EncryptSendingSystemDataAlgorithm = value;
        }

        get
        {
            return this.int_EncryptSendingSystemDataAlgorithm;
        }
    }

    int int_CompressSendingSystemDataAlgorithm = 0;
    public int CompressSendingSystemDataAlgorithm
    {
        set
        {
            int_CompressSendingSystemDataAlgorithm = value;
        }

        get
        {
            return this.int_CompressSendingSystemDataAlgorithm;
        }
    }

    int int_EncryptSendingFileObjectsDataAlgorithm = 0;
    public int EncryptSendingFileObjectsDataAlgorithm
    {
        set
        {
            this.int_EncryptSendingFileObjectsDataAlgorithm = value;
        }

        get
        {
            return this.int_EncryptSendingFileObjectsDataAlgorithm;
        }
    }

    int int_CompressSendingFileObjectsDataAlgorithm = 0;
    public int CompressSendingFileObjectsDataAlgorithm
    {
        set
        {
            this.int_CompressSendingFileObjectsDataAlgorithm = value;
        }

        get
        {
            return this.int_CompressSendingFileObjectsDataAlgorithm;
        }
    }

    int int_EncryptSendingScreenshotDataAlgorithm = 0;
    public int EncryptSendingScreenshotDataAlgorithm
    {
        set
        {
            this.int_EncryptSendingScreenshotDataAlgorithm = value;
        }

        get
        {
            return this.int_EncryptSendingScreenshotDataAlgorithm;
        }
    }


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

    string string_XMLStringWithClientsPublicRSAKeys = string.Empty;
    public string XMLStringWithClientsPublicRSAKeys
    {
        get
        {
            return string_XMLStringWithClientsPublicRSAKeys;
        }

        set
        {
            string_XMLStringWithClientsPublicRSAKeys = value;
        }
    }

    RNGCryptoServiceProvider rNGCryptoServiceProvider_RandomGenerator = new RNGCryptoServiceProvider();

    public TripleDESCryptoServiceProvider tripleDES_Session = new TripleDESCryptoServiceProvider();

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


    void InitEncryptors()
    {
        this.iCryptoTransform_EncryptorAES256bit_PrimaryObj = this.AES256bit_PrimaryObj.CreateEncryptor();
        this.iCryptoTransform_EncryptorAES128bit = this.AES128bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorAES256bit = this.AES256bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorDES64bit = this.DES64bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorRCTwo40bit = this.RCtwo40bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorRCTwo128bit = this.RCtwo128bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorTripleDES128bit = this.tripleDES128bit_Session.CreateEncryptor();
        this.iCryptoTransform_EncryptorTripleDES192bit = this.tripleDES192bit_Session.CreateEncryptor();
    }

    void InitDecryptors()
    {
        this.iCryptoTransform_DecryptorAES256bit_PrimaryObj = this.AES256bit_PrimaryObj.CreateDecryptor();
        this.iCryptoTransform_DecryptorAES128bit = this.AES128bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorAES256bit = this.AES256bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorDES64bit = this.DES64bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorRCTwo40bit = this.RCtwo40bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorRCTwo128bit = this.RCtwo128bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorTripleDES128bit = this.tripleDES128bit_Session.CreateDecryptor();
        this.iCryptoTransform_DecryptorTripleDES192bit = this.tripleDES192bit_Session.CreateDecryptor();
    }

    public ICryptoTransform GetNecessaryEncryptor(int int_AlgorithmIndex)
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

    MemoryStream memoryStream_EncryptedDataToSend = new MemoryStream();

    MemoryStream memoryStream_DecryptedData = new MemoryStream();

    public byte[] EncryptData(byte[] byteArray_DataToEncrypt, int int_AlgorithmIndex)
    {
        lock (this)
        {
            iCryptoTransform_NecessaryEncryptor = this.GetNecessaryEncryptor(int_AlgorithmIndex);

            memoryStream_EncryptedDataToSend.SetLength(0);

            CryptoStream cryptoStream = new CryptoStream(memoryStream_EncryptedDataToSend,
                                        iCryptoTransform_NecessaryEncryptor, CryptoStreamMode.Write);

            cryptoStream.Write(byteArray_DataToEncrypt, 0, byteArray_DataToEncrypt.Length);

            cryptoStream.FlushFinalBlock();

            //cryptoStream.Clear();

            memoryStream_EncryptedDataToSend.SetLength(memoryStream_EncryptedDataToSend.Position);

            return memoryStream_EncryptedDataToSend.ToArray();
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



    public void SetAndSendRSAPublicKey()
    {
        MemoryStream memoryStream_SentData = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_SentData, 24);

        RSACryptoServiceProvider rSACryptoServiceProvider_obj = new RSACryptoServiceProvider(512);

        CommonMethods.WriteIntToStream(memoryStream_SentData, 512); // Key Size

        this.XMLStringWithPrivateRSAKeys = rSACryptoServiceProvider_obj.ToXmlString(true);

        CommonMethods.WriteStringToStream(memoryStream_SentData, rSACryptoServiceProvider_obj.ToXmlString(false));

        this.SendData(memoryStream_SentData.ToArray(), SentDataType.SystemData);

        rSACryptoServiceProvider_obj.Clear();

        memoryStream_SentData.Close();
    }

    public void ReInitCryptoKeys()
    {
        this.tripleDES128bit_Session = new TripleDESCryptoServiceProvider();
        this.tripleDES128bit_Session.KeySize = 128;

        this.tripleDES192bit_Session = new TripleDESCryptoServiceProvider();
        this.tripleDES192bit_Session.KeySize = 192;

        this.DES64bit_Session = new DESCryptoServiceProvider();
        this.DES64bit_Session.KeySize = 64;

        this.RCtwo40bit_Session = new RC2CryptoServiceProvider();
        this.RCtwo40bit_Session.KeySize = 40;

        this.RCtwo128bit_Session = new RC2CryptoServiceProvider();
        this.RCtwo128bit_Session.KeySize = 128;

        this.AES128bit_Session = new RijndaelManaged();
        this.AES128bit_Session.KeySize = 128;

        this.AES256bit_Session = new RijndaelManaged();
        this.AES256bit_Session.KeySize = 256;

        InitEncryptors();
        InitDecryptors();

    }

    public void SendCryptoKeys()
    {
        ReInitCryptoKeys();

        ///////////////////////////////////////////////////////////////// .Key and .IV is RANDOM values

        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, -34);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.tripleDES128bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.tripleDES128bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.tripleDES192bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.tripleDES192bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.DES64bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.DES64bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.RCtwo40bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.RCtwo40bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.RCtwo128bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.RCtwo128bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.AES128bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.AES128bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.AES256bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.AES256bit_Session.IV);

        this.EncryptSendingSystemDataAlgorithm = 8;
        this.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }

    public void SendCryptoKeysForNewUINRegistration()
    {
        ReInitCryptoKeys();

        ///////////////////////////////////////////////////////////////// .Key and .IV is RANDOM values

        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, -35);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.tripleDES128bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.tripleDES128bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.tripleDES192bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.tripleDES192bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.DES64bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.DES64bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.RCtwo40bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.RCtwo40bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.RCtwo128bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.RCtwo128bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.AES128bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.AES128bit_Session.IV);

        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.AES256bit_Session.Key);
        CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.AES256bit_Session.IV);

        this.EncryptSendingSystemDataAlgorithm = 8;
        this.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }

    public void ClearCryptoSubsystem()
    {
        if (this.tripleDES_Session != null)
        {
            this.tripleDES_Session.Clear();
        }

        if (this.tripleDES128bit_Session != null)
        {
            this.tripleDES128bit_Session.Clear();
        }

        if (this.tripleDES192bit_Session != null)
        {
            this.tripleDES192bit_Session.Clear();
        }

        if (this.DES64bit_Session != null)
        {
            this.DES64bit_Session.Clear();
        }

        if (this.RCtwo40bit_Session != null)
        {
            this.RCtwo40bit_Session.Clear();
        }

        if (this.RCtwo128bit_Session != null)
        {
            this.RCtwo128bit_Session.Clear();
        }

        if (this.AES256bit_PrimaryObj != null)
        {
            this.AES256bit_PrimaryObj.Clear();
        }

        if (this.AES128bit_Session != null)
        {
            this.AES128bit_Session.Clear();
        }

        if (this.AES256bit_Session != null)
        {
            this.AES256bit_Session.Clear();
        }

        this.tripleDES_Session = null;
        this.tripleDES128bit_Session = null;
        this.tripleDES192bit_Session = null;
        this.DES64bit_Session = null;
        this.RCtwo40bit_Session = null;
        this.RCtwo128bit_Session = null;
        this.AES256bit_PrimaryObj = null;
        this.AES128bit_Session = null;
        this.AES256bit_Session = null;

        iCryptoTransform_DecryptorAES256bit_PrimaryObj = null;
        iCryptoTransform_DecryptorAES128bit = null;
        iCryptoTransform_DecryptorAES256bit = null;
        iCryptoTransform_DecryptorDES64bit = null;
        iCryptoTransform_DecryptorRCTwo40bit = null;
        iCryptoTransform_DecryptorRCTwo128bit = null;
        iCryptoTransform_DecryptorTripleDES128bit = null;
        iCryptoTransform_DecryptorTripleDES192bit = null;

        iCryptoTransform_EncryptorAES256bit_PrimaryObj = null;
        iCryptoTransform_EncryptorAES128bit = null;
        iCryptoTransform_EncryptorAES256bit = null;
        iCryptoTransform_EncryptorDES64bit = null;
        iCryptoTransform_EncryptorRCTwo40bit = null;
        iCryptoTransform_EncryptorRCTwo128bit = null;
        iCryptoTransform_EncryptorTripleDES128bit = null;
        iCryptoTransform_EncryptorTripleDES192bit = null;
    }

    #endregion

    #region Statistic

    long long_BytesSent = 0, long_BytesReceived = 0;

    public long Statistic_BytesSent
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
    public long Statistic_BytesReceived
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

    DateTime dateTime_ConnectedTime;
    public DateTime Statistic_ConnectedTime
    {
        get
        {
            return dateTime_ConnectedTime;
        }

        set
        {
            dateTime_ConnectedTime = value;
        }
    }

    #endregion
}

public class BaseChannelObject : BaseConnectedObject
{
    public BaseChannelObject()
    {
        BaseChannelObject.AllBaseChannelObjects.Add(this);

        InitNewUID();

        clientsUserAccount_AssignedValue = new ClientsNetworkSecurity.UserAccount();
        serversUserAccount_AssignedValue = new ServersNetworkSecurity.UserAccount();
    }
    
    public void Disconnect()
    {
        if (DisconnectionProcessed == true)
        {
            return;
        }

        DisconnectionProcessed = true;

        this.CheckClientsConnetions();

        this.RequestToDisconnect = true;

        this.Close();

        this.ClearCryptoSubsystem();

        BaseChannelObject.AllBaseChannelObjects.Remove(this);

        if (this.ChannelTypeInfo == ChannelType.System && this.IsAuthorized == true)
        {
            ObjCopy.obj_MainForm.Statistic_ActiveConnections--;
        }
    }
    public void Disconnect(int int_DisconnectReason)
    {
        LocalAction localAction_obj = new LocalAction();

        localAction_obj.NecessaryBaseChannelObject = this;

        localAction_obj.SendDisconnectionStatus(int_DisconnectReason);

        Disconnect();
    }

    #region Connections Check

    bool bool_DisconnectionProcessed = false;
    bool DisconnectionProcessed
    {
        get
        {
            return bool_DisconnectionProcessed;
        }
        set
        {
            bool_DisconnectionProcessed = value;
        }
    }

    static int int_CountOfCheckClientsConnetions = 0;

    public void SendCheckInfoToClients()
    {
        LocalAction localAction_obj = new LocalAction();

        BaseChannelObject baseChannelObject_obj = null;

        for (int int_CycleCount = 0; AllBaseChannelObjects.Count != int_CycleCount; int_CycleCount++)
        {
            try
            {
                baseChannelObject_obj = AllBaseChannelObjects[int_CycleCount];

                if (baseChannelObject_obj.ChannelTypeInfo == ChannelType.Applied) continue; // send connection check data ONLY to System channels!!! applied channels transmit ONLY CLEAR data!!! 

                localAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;

                localAction_obj.SendConnectionCheck();
            }

            catch
            {
                baseChannelObject_obj.Disconnect(8);

                if (AllBaseChannelObjects.Count == 0) break;

                int_CycleCount = -1;
            }
        }
    }

    public void CheckClientsConnetions()
    {
        if (int_CountOfCheckClientsConnetions > 0)
        {
            return;
        }

        int_CountOfCheckClientsConnetions++;

        try
        {
            while (AllBaseChannelObjects.Count > 0 && NetworkAction.InstanceCount > 0)
            {
                SendCheckInfoToClients();

                Thread.Sleep(10000); //!!! сколько нужно спать ?
            }

            SendCheckInfoToClients();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            int_CountOfCheckClientsConnetions--;
        }
    }

    #endregion

    public static bool IsNecesseryUIDRegistered(ulong ulong_UID)
    {
        foreach (BaseChannelObject baseChannelObject_obj in BaseChannelObject.AllBaseChannelObjects)
        {
            if (baseChannelObject_obj.ChannelUID == ulong_UID)
            {
                return true;
            }
        }

        return false;
    }

    public void InitNewUID()
    {
        ulong ulong_GeneratedUID = 0;

        while (true)
        {
            ulong_GeneratedUID = (ulong)(new Random().Next());

            if (IsNecesseryUIDRegistered(ulong_GeneratedUID) == false)
            {
                this.ChannelUID = ulong_GeneratedUID;

                return;
            }
        }
    }

    static List<BaseChannelObject> list_AllBaseChannelObjects = new List<BaseChannelObject>();
    internal static List<BaseChannelObject> AllBaseChannelObjects
    {
        get
        {
            return list_AllBaseChannelObjects;
        }
    }

    public ClientsNetworkSecurity.UserAccount clientsUserAccount_AssignedValue = new ClientsNetworkSecurity.UserAccount();
    public ServersNetworkSecurity.UserAccount serversUserAccount_AssignedValue = new ServersNetworkSecurity.UserAccount();

    #region Statistic and Information

    ConnectingObjectType connectingObjectTypeInfo_obj;
    public ConnectingObjectType ConnectingObjectTypeInfo
    {
        get
        {
            return this.connectingObjectTypeInfo_obj;
        }

        set
        {
            connectingObjectTypeInfo_obj = value;
        }
    }

    ChannelType channelTypeInfo_obj;
    public ChannelType ChannelTypeInfo
    {
        get
        {
            return channelTypeInfo_obj;
        }

        set
        {
            channelTypeInfo_obj = value;
        }
    }

    ulong ulong_UIN = 0;
    public ulong UIN
    {
        get
        {
            return ulong_UIN;
        }

        set
        {
            ulong_UIN = value;
        }
    }

    ulong ulong_InterConnectedUIN = 0;
    public ulong InterConnectedUIN
    {
        get
        {
            return ulong_InterConnectedUIN;
        }

        set
        {
            ulong_InterConnectedUIN = value;
        }
    }

    ulong ulong_ChannelUID = 0;
    public ulong ChannelUID
    {
        get
        {
            return ulong_ChannelUID;
        }
        set
        {
            ulong_ChannelUID = value;
        }
    }

    string string_AccountType;
    public string NetworkInformation_AccountType
    {
        set
        {
            this.string_AccountType = value;
        }

        get
        {
            return this.string_AccountType;
        }
    }

    string string_UserName;
    public string NetworkInformation_UserName
    {
        set
        {
            this.string_UserName = value;
        }

        get
        {
            return this.string_UserName;
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

    public string IPAddress
    {
        get
        {
            return ((IPEndPoint)this.Client.RemoteEndPoint).Address.ToString();
        }
    }

    string string_MACAddress;
    public string MACAddress
    {
        set
        {
            string_MACAddress = value;
        }
        get
        {
            return string_MACAddress;
        }
    }

    bool bool_RequestToDisconnect = false;
    public bool RequestToDisconnect
    {
        get
        {
            return bool_RequestToDisconnect;
        }

        set
        {
            bool_RequestToDisconnect = value;
        }
    }

    bool bool_IsAuthorized = false;
    public bool IsAuthorized
    {
        get
        {
            return bool_IsAuthorized;
        }

        set
        {
            bool_IsAuthorized = value;
        }

    }

    bool bool_IsAccountEnabled = false;
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

    bool bool_IsActivated = false;
    public bool IsActivated
    {
        get
        {
            return bool_IsActivated;
        }

        set
        {
            bool_IsActivated = value;
        }
    }

    #endregion
}





public class ConnectedClient
{
    public ConnectedClient(ulong ulong_UIN)
    {
        if (ConnectedClient.AllConnectedClients.Contains(this) == false)
        {
            this.UIN = ulong_UIN;

            ConnectedClient.AllConnectedClients.Add(this);
        }

        CommonNetworkEvents.ServiceStoppedEvent += Disconnect;

        CommonNetworkEvents.ServerDisconnectedEvent += OnInterConnectedServerDisconnected;
    }

    public void Disconnect()
    {
        CommonNetworkEvents.ClientDisconnectedEvent(this);

        RemoteCallAction remoteCallAction_obj = new RemoteCallAction();

        remoteCallAction_obj.NecessaryBaseChannelObject = SystemChannel.BaseChannel;

        SystemChannel.BaseChannel.Disconnect();

        ConnectedClient.AllConnectedClients.Remove(this);

        ConnectedClient.AllSystemClientChannels.Remove(SystemChannel);

        foreach (AppliedClientChannel appliedClientChannel_obj in this.AppliedClientChannels)
        {
            appliedClientChannel_obj.BaseChannel.Disconnect();

            ConnectedClient.AllAppliedClientChannels.Remove(appliedClientChannel_obj);
        }

        this.AppliedClientChannels.Clear();
    }
    public void Disconnect(int int_DisconnectReason)
    {
        /*
         * 0 is a Auth failed or Access impossible
         * 1 is a Disconnect by Admin
         * 2 is a reason of max connection limit exhausted
         * 3 is a MaxConnectionsPerAccount limit exhausted
         * 4 is a RemoveAccount or ClearAccounts events
         * 5 is a DisconnectAllClients event
         * 6 is a Disconnect when process succesfully completed (as an UIN Registration or Activation)
         * 7 is a Connection closed by Client\Server user request
         * 8 is a Connection was lost by SendCheckInfoToClients()
         * 9 is a Exception thrown in ReceiveCycle method
         * 10 is a requested Server not connected now
         */

        LocalAction localAction_obj = new LocalAction();

        localAction_obj.NecessaryBaseChannelObject = this.SystemChannel.BaseChannel;

        localAction_obj.SendDisconnectionStatus(int_DisconnectReason);

        Disconnect();
    }
    public static void DisconnectAll()
    {
        foreach (ConnectedClient connectedClient_obj in ConnectedClient.AllConnectedClients)
        {
            connectedClient_obj.Disconnect(5);

            DisconnectAll();

            return;
        }
    }

    public void OnInterConnectedServerDisconnected(ConnectedServer connectedServer_obj)
    {
        foreach (AppliedClientChannel appliedClientChannel_CycleObj in AllAppliedClientChannels)
        {
            if (appliedClientChannel_CycleObj.InterconnectedObject == connectedServer_obj)
            {
                Disconnect();

                OnInterConnectedServerDisconnected(connectedServer_obj);

                return;
            }
        }       
    }

    #region properties

    ulong ulong_UIN = 0;
    public ulong UIN
    {
        get
        {
            return ulong_UIN;
        }

        set
        {
            ulong_UIN = value;
        }
    }

    #endregion

    #region channels

    public class AppliedClientChannel
    {
        public AppliedClientChannel(BaseChannelObject baseChannelObject_Parent, ConnectedClient connectedClient_owner)
        {
            BaseChannel = baseChannelObject_Parent;
            ChannelOwner = connectedClient_owner;
        }

        ConnectedServer connectedServer_InterConnectedObj;
        public ConnectedServer InterconnectedObject
        {
            get
            {
                return connectedServer_InterConnectedObj;
            }
            set
            {
                connectedServer_InterConnectedObj = value;
            }
        }

        ConnectedClient connectedClient_obj;
        public ConnectedClient ChannelOwner
        {
            get
            {
                return connectedClient_obj;
            }

            set
            {
                connectedClient_obj = value;
            }
        }

        BaseChannelObject baseChannelObject_obj = null;
        public BaseChannelObject BaseChannel
        {
            get
            {
                return baseChannelObject_obj;
            }
            set
            {
                baseChannelObject_obj = value;
            }
        }
    }

    //---------------------------------------------------------------------------------------------------

    //используется только для удобного поиска при удалении каналов из статического листа ConnectedClient.AllAppliedClientChannels
    List<AppliedClientChannel> list_AppliedClientChannels = new List<AppliedClientChannel>();
    public List<AppliedClientChannel> AppliedClientChannels
    {
        get
        {
            return list_AppliedClientChannels;
        }
    }

    //---------------------------------------------------------------------------------------------------


    public class SystemClientChannel
    {
        public SystemClientChannel(BaseChannelObject baseChannelObject_Parent, ConnectedClient connectedClient_owner)
        {
            BaseChannel = baseChannelObject_Parent;
            ChannelOwner = connectedClient_owner;
        }

        ConnectedClient connectedClient_obj;
        public ConnectedClient ChannelOwner
        {
            get
            {
                return connectedClient_obj;
            }

            set
            {
                connectedClient_obj = value;
            }
        }

        BaseChannelObject baseChannelObject_obj = null;
        public BaseChannelObject BaseChannel
        {
            get
            {
                return baseChannelObject_obj;
            }
            set
            {
                baseChannelObject_obj = value;
            }
        }

        public void ReceiveCycle()
        {
            try
            {
                bool_IsReceiveThreadWorking = true;

                YakSys.Compression.CommonEnvironment commonEnvironment_obj = new YakSys.Compression.CommonEnvironment();

                CompressionEnvironment.DeflateCompressionWrapper deflateCompressionWrapper_obj = new CompressionEnvironment.DeflateCompressionWrapper();

                byte[] byteArray_SystemData = new byte[6], byteArray_ReceivedData = null;

                int int_ReceivedDataLength = 0, int_TotalReceived = 0,
                    int_TotalAvailable = 0, int_DataEncryptionAlgorithm = 0,
                    int_DataCompressionAlgorithm = 0;

                MemoryStream memoryStream_ReceivedData = new MemoryStream(),
                             memoryStream_DecryptedData = new MemoryStream();

                LocalAction localAction_obj = null;

                while (BaseChannel.Client.Connected && BaseChannel.RequestToDisconnect == false)
                {
                    if (BaseChannel.Available > 6)
                    {
                        #region Receive System Data [first 6 bytes]

                        BaseChannel.Client.Receive(byteArray_SystemData);

                        int_ReceivedDataLength = BitConverter.ToInt32(byteArray_SystemData, 0);

                        int_DataCompressionAlgorithm = byteArray_SystemData[4];
                        int_DataEncryptionAlgorithm = byteArray_SystemData[5];

                        #endregion

                        #region Re-Init MemoryStream and int_TotalReceived an int_TotalAvailable objects

                        memoryStream_ReceivedData.SetLength(0);
                        memoryStream_DecryptedData.SetLength(0);

                        int_TotalReceived = 0;
                        int_TotalAvailable = 0;

                        #endregion

                        #region Receive all data from Socket

                        while (int_TotalReceived != int_ReceivedDataLength)
                        {
                            if (BaseChannel.RequestToDisconnect) return;

                            int_TotalAvailable = BaseChannel.Client.Available;

                            if (int_TotalAvailable > 0)
                            {
                                if (int_TotalAvailable > (int_ReceivedDataLength - int_TotalReceived))
                                {
                                    byteArray_ReceivedData = new byte[int_ReceivedDataLength - int_TotalReceived];
                                }

                                else
                                {
                                    byteArray_ReceivedData = new byte[int_TotalAvailable];
                                }

                                int_TotalReceived += BaseChannel.Client.Receive(byteArray_ReceivedData);

                                memoryStream_ReceivedData.Write(byteArray_ReceivedData, 0, byteArray_ReceivedData.Length);
                            }
                        }

                        #endregion

                        if (byteArray_ReceivedData == null)
                        {
                            Thread.Sleep(100);

                            continue;
                        }

                        ObjCopy.obj_MainForm.Statistic_BytesReceived += int_TotalReceived;
                        BaseChannel.Statistic_BytesReceived += int_TotalReceived;

                        localAction_obj = new LocalAction();

                        localAction_obj.NecessaryBaseChannelObject = BaseChannel;

                        #region Decrypt Data and call localAction_obj.ActionAllocator when client Is Authorized

                        if (BaseChannel.IsAuthorized && int_DataEncryptionAlgorithm > 0)
                        {

                            if (BaseChannel.IsAccountEnabled == false)
                            {
                                if (BaseChannel.RequestToDisconnect == true) return;

                                Thread.Sleep(500);

                                continue;
                            }

                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_DecryptedData.SetLength(0);

                            memoryStream_DecryptedData = new MemoryStream(BaseChannel.DecryptData(memoryStream_ReceivedData, int_DataEncryptionAlgorithm));

                            localAction_obj.RecivedData = new byte[memoryStream_DecryptedData.ToArray().Length];

                            memoryStream_DecryptedData.Position = 0;
                            memoryStream_DecryptedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithm != 0)
                            {
                                if (int_DataCompressionAlgorithm < 4)
                                {
                                    localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                                }
                                else
                                {
                                    localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                                }
                            }

                            localAction_obj.ActionAllocator();

                            continue;
                        }

                        #endregion

                        #region call localAction_obj.ActionAllocator when client Is Authorized

                        if (BaseChannel.IsAuthorized && int_DataEncryptionAlgorithm == 0)
                        {
                            if (!BaseChannel.IsAccountEnabled)
                            {
                                if (BaseChannel.RequestToDisconnect) return;

                                Thread.Sleep(500);

                                continue;
                            }

                            localAction_obj.RecivedData = new byte[memoryStream_ReceivedData.ToArray().Length];

                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_ReceivedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithm != 0)
                            {
                                if (int_DataCompressionAlgorithm < 4)
                                {
                                    localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                                }
                                else
                                {
                                    localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                                }
                            }

                            localAction_obj.ActionAllocator();

                            continue;
                        }

                        #endregion
                    }

                    Thread.Sleep(5);
                }

                Thread.Sleep(1000);

                this.ChannelOwner.Disconnect();
            }

            catch
            {
                this.ChannelOwner.Disconnect(9);

                return;
            }
            finally
            {
                bool_IsReceiveThreadWorking = false;
            }
        }

        public bool bool_IsReceiveThreadWorking = false;
    }

    SystemClientChannel SystemClientChannel_obj = null;
    public SystemClientChannel SystemChannel
    {
        get
        {
            return SystemClientChannel_obj;
        }

        set
        {
            SystemClientChannel_obj = value;
        }
    }

    #endregion

    #region all static channel objects

    static List<AppliedClientChannel> list_AllAppliedClientChannels = new List<AppliedClientChannel>();
    public static List<AppliedClientChannel> AllAppliedClientChannels
    {
        get
        {
            return list_AllAppliedClientChannels;
        }
    }

    static List<SystemClientChannel> list_AllSystemClientChannels = new List<SystemClientChannel>();
    public static List<SystemClientChannel> AllSystemClientChannels
    {
        get
        {
            return list_AllSystemClientChannels;
        }
    }

    #endregion

    #region Statistic

    public ulong Statistic_BytesSent
    {
        get
        {
            ulong ulong_BytesSent = 0;

            foreach (AppliedClientChannel appliedClientChannel_obj in ConnectedClient.AllAppliedClientChannels)
            {
                ulong_BytesSent += (ulong)appliedClientChannel_obj.BaseChannel.Statistic_BytesSent;
            }

            ulong_BytesSent += (ulong)this.SystemChannel.BaseChannel.Statistic_BytesSent;

            return ulong_BytesSent;
        }
    }
    public ulong Statistic_BytesReceived
    {
        get
        {
            ulong ulong_BytesReceived = 0;

            foreach (AppliedClientChannel appliedClientChannel_obj in ConnectedClient.AllAppliedClientChannels)
            {
                ulong_BytesReceived += (ulong)appliedClientChannel_obj.BaseChannel.Statistic_BytesReceived;
            }

            ulong_BytesReceived += (ulong)this.SystemChannel.BaseChannel.Statistic_BytesReceived;

            return ulong_BytesReceived;
        }
    }

    #endregion

    public void RegisterNewSystemChannel()
    {
        SystemChannel.ChannelOwner = this;

        ulong ulong_GeneratedSystemChannelUID = (ulong)new Random().Next(int.MaxValue);

        lock (this)
        {
            foreach (SystemClientChannel systemClientChannel_CycleObj in AllSystemClientChannels)
            {
                if (systemClientChannel_CycleObj.BaseChannel.ChannelUID == ulong_GeneratedSystemChannelUID)
                {
                    ulong_GeneratedSystemChannelUID = (ulong)new Random().Next(int.MaxValue);

                    continue;
                }
            }
        }

        SystemChannel.BaseChannel.ChannelUID = ulong_GeneratedSystemChannelUID;

        AllSystemClientChannels.Add(SystemChannel);

        new Thread(new ThreadStart(SystemChannel.ReceiveCycle)).Start();

        bool bool_ThreadStartedComplete = new CommonMethods().WaitForOperationCompleting(ref SystemChannel.bool_IsReceiveThreadWorking, 10000);

        if (bool_ThreadStartedComplete == false)
        {
            return;
        }


        RemoteCallAction remoteCallAction_obj = new RemoteCallAction();

        remoteCallAction_obj.NecessaryBaseChannelObject = SystemChannel.BaseChannel;

        remoteCallAction_obj.SendGeneratedUID(SystemChannel.BaseChannel.ChannelUID);
    }
    public void RegisterNewAppliedChannel(ulong ulong_DestinedServerUIN, BaseChannelObject baseChannelObject_obj)
    {
        AppliedClientChannel appliedClientChannel_obj = new AppliedClientChannel(baseChannelObject_obj, this);

        appliedClientChannel_obj.BaseChannel.InterConnectedUIN = ulong_DestinedServerUIN;

        appliedClientChannel_obj.ChannelOwner = this;

        ulong ulong_GeneratedAppliedChannelUID = 0;

        lock (this)
        {
            foreach (AppliedClientChannel appliedClientChannel_CycleObj in AllAppliedClientChannels)
            {
                if (appliedClientChannel_CycleObj.BaseChannel.ChannelUID == ulong_GeneratedAppliedChannelUID)
                {
                    ulong_GeneratedAppliedChannelUID = (ulong)new Random().Next(int.MaxValue);

                    continue;
                }
            }
        }

        appliedClientChannel_obj.BaseChannel.ChannelUID = ulong_GeneratedAppliedChannelUID;

        AppliedClientChannels.Add(appliedClientChannel_obj);

        ConnectedClient.AllAppliedClientChannels.Add(appliedClientChannel_obj);
    }

    public void InterconnectionProcessRequest(ConnectedClient.AppliedClientChannel appliedClientChannel_obj, ulong ulong_DestinedServerUIN)
    {
        //--------------------------------------------------------------------------------------------

        if (ConnectedServer.IsNecesseryUINConnected(ulong_DestinedServerUIN) == false)
        {
            if (this.WaitForServer == true)
            {
                new Thread(new ParameterizedThreadStart(WaitForServerThread)).Start(ulong_DestinedServerUIN);

                return;
            }
            else
            {
                this.Disconnect(10);

                return;
            }
        }
        //!!exception appliedClientChannel_obj.InterconnectedObject = ConnectedServer.GetServerByUIN(ulong_DestinedServerUIN); - object reference == null
        appliedClientChannel_obj.InterconnectedObject = ConnectedServer.GetServerByUIN(ulong_DestinedServerUIN);

        //--------------------------------------------------------------------------------------------

        RemoteCallAction remoteCallAction_obj = new RemoteCallAction();

        remoteCallAction_obj.NecessaryBaseChannelObject = appliedClientChannel_obj.InterconnectedObject.SystemChannel.BaseChannel;

        remoteCallAction_obj.SendBindServerRequest(this.UIN, (ulong)ulong_DestinedServerUIN);


        //--------------------------------------------------------------------------------------------
    }

    bool bool_WaitForServer = false;
    public bool WaitForServer
    {
        get
        {
            return bool_WaitForServer;
        }
        set
        {
            bool_WaitForServer = value;
        }
    }
    void WaitForServerThread(object ulong_DestinedServerUIN)
    {
        ConnectedServer InterConnectedServerObj = null;

        while (this.SystemChannel.BaseChannel.Connected == true)
        {
            if (ConnectedServer.IsNecesseryUINConnected((ulong)ulong_DestinedServerUIN) == true)
            {
                InterConnectedServerObj = ConnectedServer.GetServerByUIN((ulong)ulong_DestinedServerUIN);

                if (InterConnectedServerObj == null || InterConnectedServerObj.SystemChannel == null || InterConnectedServerObj.SystemChannel.BaseChannel == null)
                {
                    Thread.Sleep(500);

                    continue;
                }

                RemoteCallAction remoteCallAction_obj = new RemoteCallAction();

                remoteCallAction_obj.NecessaryBaseChannelObject = InterConnectedServerObj.SystemChannel.BaseChannel;

                remoteCallAction_obj.SendBindServerRequest(this.UIN, (ulong)ulong_DestinedServerUIN);

                return;
            }

            Thread.Sleep(500);
        }
    }

    public static bool IsNecesseryUINConnected(ulong ulong_UIN)
    {
        foreach (ConnectedClient connectedClient_obj in ConnectedClient.AllConnectedClients)
        {
            if (connectedClient_obj.UIN == ulong_UIN)
            {
                return true;
            }
        }

        return false;
    }
    public static ConnectedClient GetClientByUIN(ulong ulong_UIN)
    {
        foreach (ConnectedClient connectedClient_obj in ConnectedClient.AllConnectedClients)
        {
            if (ulong_UIN == connectedClient_obj.UIN)
            {
                return connectedClient_obj;
            }
        }

        return null;
    }
    public AppliedClientChannel GetNecesseryAppliedClientChannelByServerUIN(ulong ulong_UIN)
    {
        foreach (AppliedClientChannel appliedClientChannel_obj in AllAppliedClientChannels)
        {
            if (appliedClientChannel_obj.BaseChannel.InterConnectedUIN == ulong_UIN)
            {
                return appliedClientChannel_obj;
            }
        }

        return null;
    }

    static List<ConnectedClient> list_AllConnectedClients = new List<ConnectedClient>();
    public static List<ConnectedClient> AllConnectedClients
    {
        get
        {
            return list_AllConnectedClients;
        }
    }

    public void OnSystemChannelConnectionEstablished()
    {

    }
    public void OnAppliedChannelConnectionEstablished()
    {

    }
}

public class ConnectedServer
{
    public ConnectedServer(ulong ulong_UIN)
    {
        if (ConnectedServer.AllConnectedServers.Contains(this) == false)
        {
            this.UIN = ulong_UIN;
        }

        CommonNetworkEvents.ClientDisconnectedEvent += OnAppliedChannelDisconnect;

        CommonNetworkEvents.ServiceStoppedEvent += Disconnect;

        ConnectedServer.AllConnectedServers.Add(this);
    }

    public void OnAppliedChannelDisconnect(ConnectedClient connectedClient_obj)
    {
        foreach (AppliedServerChannel appliedServerChannel_obj in ConnectedServer.AllAppliedServerChannels)
        {
            //if (appliedServerChannel_obj.InterconnectedObject == connectedClient_obj.AppliedChannel)

            if (ConnectedClient.GetClientByUIN(connectedClient_obj.UIN) != null && ConnectedClient.GetClientByUIN(connectedClient_obj.UIN).GetNecesseryAppliedClientChannelByServerUIN(this.UIN) != null &&
                appliedServerChannel_obj.InterconnectedObject == ConnectedClient.GetClientByUIN(connectedClient_obj.UIN).GetNecesseryAppliedClientChannelByServerUIN(this.UIN))
            {
                appliedServerChannel_obj.BaseChannel.Disconnect();

                this.AppliedServerChannels.Remove(appliedServerChannel_obj);

                ConnectedServer.AllAppliedServerChannels.Remove(appliedServerChannel_obj);

                this.OnAppliedChannelDisconnect(connectedClient_obj);

                return;
            }
        }
    }
    public void Disconnect()
    {
        CommonNetworkEvents.ServerDisconnectedEvent(this);

        //----------------------------------------------------------------------------------

        RemoteCallAction remoteCallAction_obj = new RemoteCallAction();

        remoteCallAction_obj.NecessaryBaseChannelObject = SystemChannel.BaseChannel;

        //----------------------------------------------------------------------------------

        foreach (AppliedServerChannel appliedServerChannel_obj in this.AppliedServerChannels)
        {
            AllAppliedServerChannels.Remove(appliedServerChannel_obj);
        }

        SystemChannel.BaseChannel.Disconnect();

        ConnectedServer.AllConnectedServers.Remove(this);

        AllSystemServerChannels.Remove(this.SystemChannel);

        this.AppliedServerChannels.Clear();      
    }
    public void Disconnect(int int_DisconnectReason)
    {
        /*
         * 0 is a Auth failed or Access impossible
         * 1 is a Disconnect by Admin
         * 2 is a reason of max connection limit exhausted
         * 3 is a MaxConnectionsPerAccount limit exhausted
         * 4 is a RemoveAccount or ClearAccounts events
         * 5 is a DisconnectAllClients event
         * 6 is a Disconnect when process succesfully completed (as an UIN Registration or Activation)
         * 7 is a Connection closed by Client\Server user request
         * 8 is a Connection was lost by SendCheckInfoToClients()
         * 9 is a Exception thrown in ReceiveCycle method
         * 10 is a requested Server not connected now
         */

        LocalAction localAction_obj = new LocalAction();

        localAction_obj.NecessaryBaseChannelObject = this.SystemChannel.BaseChannel;

        localAction_obj.SendDisconnectionStatus(int_DisconnectReason);

        Disconnect();
    }
    public static void DisconnectAll()
    {
        foreach (ConnectedServer connectedServer_obj in ConnectedServer.AllConnectedServers)
        {
            connectedServer_obj.Disconnect(5);

            DisconnectAll();

            return;
        }
    }

    #region channels

    public class AppliedServerChannel
    {
        public AppliedServerChannel(BaseChannelObject baseChannelObject_Parent, ConnectedServer connectedServer_Owner)
        {
            BaseChannel = baseChannelObject_Parent;
            ChannelOwner = connectedServer_Owner;
        }

        ConnectedClient.AppliedClientChannel appliedClientChannel_InterconnectedObject;
        public ConnectedClient.AppliedClientChannel InterconnectedObject
        {
            get
            {
                return appliedClientChannel_InterconnectedObject;
            }
            set
            {
                appliedClientChannel_InterconnectedObject = value;
            }
        }

        ConnectedServer connectedServer_obj;
        public ConnectedServer ChannelOwner
        {
            get
            {
                return connectedServer_obj;
            }

            set
            {
                connectedServer_obj = value;
            }
        }

        BaseChannelObject baseChannelObject_obj = null;
        public BaseChannelObject BaseChannel
        {
            get
            {
                return baseChannelObject_obj;
            }
            set
            {
                baseChannelObject_obj = value;
            }
        }
    }

    public class SystemServerChannel
    {
        public SystemServerChannel(BaseChannelObject baseChannelObject_Parent, ConnectedServer connectedServer_Owner)
        {
            BaseChannel = baseChannelObject_Parent;
            ChannelOwner = connectedServer_Owner;
        }

        ConnectedServer connectedServer_obj;
        public ConnectedServer ChannelOwner
        {
            get
            {
                return connectedServer_obj;
            }

            set
            {
                connectedServer_obj = value;
            }
        }

        BaseChannelObject baseChannelObject_obj = null;
        public BaseChannelObject BaseChannel
        {
            get
            {
                return baseChannelObject_obj;
            }
            set
            {
                baseChannelObject_obj = value;
            }
        }

        public bool bool_IsReceiveThreadWorking = false;

        public void ReceiveCycle()
        {
            try
            {
                bool_IsReceiveThreadWorking = true;

                YakSys.Compression.CommonEnvironment commonEnvironment_obj = new YakSys.Compression.CommonEnvironment();

                CompressionEnvironment.DeflateCompressionWrapper deflateCompressionWrapper_obj = new CompressionEnvironment.DeflateCompressionWrapper();

                byte[] byteArray_SystemData = new byte[6], byteArray_ReceivedData = null;

                int int_ReceivedDataLength = 0, int_TotalReceived = 0,
                    int_TotalAvailable = 0, int_DataEncryptionAlgorithm = 0,
                    int_DataCompressionAlgorithm = 0;

                MemoryStream memoryStream_ReceivedData = new MemoryStream(),
                             memoryStream_DecryptedData = new MemoryStream();

                LocalAction localAction_obj = null;

                while (BaseChannel.Client.Connected && BaseChannel.RequestToDisconnect == false)
                {
                    if (BaseChannel.Available > 6)
                    {
                        #region Receive System Data [first 6 bytes]

                        BaseChannel.Client.Receive(byteArray_SystemData);

                        int_ReceivedDataLength = BitConverter.ToInt32(byteArray_SystemData, 0);

                        int_DataCompressionAlgorithm = byteArray_SystemData[4];
                        int_DataEncryptionAlgorithm = byteArray_SystemData[5];

                        #endregion

                        #region Re-Init MemoryStream and int_TotalReceived an int_TotalAvailable objects

                        memoryStream_ReceivedData.SetLength(0);
                        memoryStream_DecryptedData.SetLength(0);

                        int_TotalReceived = 0;
                        int_TotalAvailable = 0;

                        #endregion

                        #region Receive all data from Socket

                        while (int_TotalReceived != int_ReceivedDataLength)
                        {
                            if (BaseChannel.RequestToDisconnect) return;

                            int_TotalAvailable = BaseChannel.Client.Available;

                            if (int_TotalAvailable > 0)
                            {
                                if (int_TotalAvailable > (int_ReceivedDataLength - int_TotalReceived))
                                {
                                    byteArray_ReceivedData = new byte[int_ReceivedDataLength - int_TotalReceived];
                                }

                                else
                                {
                                    byteArray_ReceivedData = new byte[int_TotalAvailable];
                                }

                                int_TotalReceived += BaseChannel.Client.Receive(byteArray_ReceivedData);

                                memoryStream_ReceivedData.Write(byteArray_ReceivedData, 0, byteArray_ReceivedData.Length);
                            }
                        }

                        if (byteArray_ReceivedData == null)
                        {
                            Thread.Sleep(100);

                            continue;
                        }

                        #endregion

                        ObjCopy.obj_MainForm.Statistic_BytesReceived += int_TotalReceived;
                        BaseChannel.Statistic_BytesReceived += int_TotalReceived;

                        localAction_obj = new LocalAction();

                        localAction_obj.NecessaryBaseChannelObject = BaseChannel;

                        #region Decrypt Data and call localAction_obj.ActionAllocator when client Is Authorized

                        if (BaseChannel.IsAuthorized && int_DataEncryptionAlgorithm > 0)
                        {

                            if (BaseChannel.IsAccountEnabled == false)
                            {
                                if (BaseChannel.RequestToDisconnect) return;

                                Thread.Sleep(500);

                                continue;
                            }


                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_DecryptedData.SetLength(0);

                            memoryStream_DecryptedData = new MemoryStream(BaseChannel.DecryptData(memoryStream_ReceivedData, int_DataEncryptionAlgorithm));

                            localAction_obj.RecivedData = new byte[memoryStream_DecryptedData.ToArray().Length];

                            memoryStream_DecryptedData.Position = 0;
                            memoryStream_DecryptedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithm != 0)
                            {
                                if (int_DataCompressionAlgorithm < 4)
                                {
                                    localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                                }
                                else
                                {
                                    localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                                }
                            }

                            localAction_obj.ActionAllocator();

                            continue;
                        }

                        #endregion

                        #region call localAction_obj.ActionAllocator when client Is Authorized

                        if (BaseChannel.IsAuthorized && int_DataEncryptionAlgorithm == 0)
                        {

                            if (BaseChannel.IsAccountEnabled == false)
                            {
                                if (BaseChannel.RequestToDisconnect) return;

                                Thread.Sleep(500);

                                continue;
                            }

                            localAction_obj.RecivedData = new byte[memoryStream_ReceivedData.ToArray().Length];

                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_ReceivedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithm != 0)
                            {
                                if (int_DataCompressionAlgorithm < 4)
                                {
                                    localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                                }
                                else
                                {
                                    localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                                }
                            }

                            localAction_obj.ActionAllocator();

                            continue;
                        }

                        #endregion
                    }

                    Thread.Sleep(5);
                }

                Thread.Sleep(1000);

                this.ChannelOwner.Disconnect();
            }

            catch (Exception exception)
            {
                this.ChannelOwner.Disconnect();

                return;
            }
            finally
            {
                bool_IsReceiveThreadWorking = false;
            }
        }
    }

    SystemServerChannel SystemServerChannel_obj = null;
    public SystemServerChannel SystemChannel
    {
        get
        {
            return SystemServerChannel_obj;
        }

        set
        {
            SystemServerChannel_obj = value;
        }
    }

    //---------------------------------------------------------------------------------------------------

    List<AppliedServerChannel> list_AppliedServerChannels = new List<AppliedServerChannel>();
    public List<AppliedServerChannel> AppliedServerChannels
    {
        get
        {
            return list_AppliedServerChannels;
        }
    }

    //---------------------------------------------------------------------------------------------------


    static List<AppliedServerChannel> list_AllAppliedServerChannels = new List<AppliedServerChannel>();
    public static List<AppliedServerChannel> AllAppliedServerChannels
    {
        get
        {
            return list_AllAppliedServerChannels;
        }
    }

    static List<SystemServerChannel> list_AllSystemServerChannels = new List<SystemServerChannel>();
    public static List<SystemServerChannel> AllSystemServerChannels
    {
        get
        {
            return list_AllSystemServerChannels;
        }
    }

    //---------------------------------------------------------------------------------------------------

    #endregion

    #region Statistic

    public ulong Statistic_BytesSent
    {
        get
        {
            ulong ulong_BytesSent = 0;

            foreach (AppliedServerChannel appliedServerChannel_obj in ConnectedServer.AllAppliedServerChannels)
            {
                ulong_BytesSent += (ulong)appliedServerChannel_obj.BaseChannel.Statistic_BytesSent;
            }

            ulong_BytesSent += (ulong)this.SystemChannel.BaseChannel.Statistic_BytesSent;

            return ulong_BytesSent;
        }
    }
    public ulong Statistic_BytesReceived
    {
        get
        {
            ulong ulong_BytesReceived = 0;

            foreach (AppliedServerChannel appliedServerChannel_obj in ConnectedServer.AllAppliedServerChannels)
            {
                ulong_BytesReceived += (ulong)appliedServerChannel_obj.BaseChannel.Statistic_BytesReceived;
            }

            ulong_BytesReceived += (ulong)this.SystemChannel.BaseChannel.Statistic_BytesReceived;

            return ulong_BytesReceived;
        }
    }

    public string IPAddress
    {
        get
        {
            return this.SystemChannel.BaseChannel.IPAddress;
        }
    }

    public string MACAddress
    {
        get
        {
            return this.SystemChannel.BaseChannel.MACAddress;
        }
    }

    #endregion

    #region properties

    ulong ulong_UIN = 0;
    public ulong UIN
    {
        get
        {
            return ulong_UIN;
        }

        set
        {
            ulong_UIN = value;
        }
    }

    bool bool_HideIP = true;
    public bool HideIP
    {
        get
        {
            return bool_HideIP;
        }

        set
        {
            bool_HideIP = value;
        }

    }

    bool bool_PublicServer = true;
    public bool PublicServer
    {
        get
        {
            return bool_PublicServer;
        }

        set
        {
            bool_PublicServer = value;
        }

    }

    #endregion

    public void RegisterNewSystemChannel()
    {
        SystemChannel.ChannelOwner = this;

        ulong ulong_GeneratedSystemChannelUID = 0;

        lock (this)
        {
            foreach (SystemServerChannel systemServerChannel_CycleObj in AllSystemServerChannels)
            {
                if (systemServerChannel_CycleObj.BaseChannel.ChannelUID == ulong_GeneratedSystemChannelUID)
                {
                    ulong_GeneratedSystemChannelUID = (ulong)new Random().Next(int.MaxValue);

                    continue;
                }
            }
        }

        SystemChannel.BaseChannel.ChannelUID = ulong_GeneratedSystemChannelUID;

        ConnectedServer.AllSystemServerChannels.Add(SystemChannel);

        new Thread(new ThreadStart(SystemChannel.ReceiveCycle)).Start();

        bool bool_ThreadStartedComplete = new CommonMethods().WaitForOperationCompleting(ref SystemChannel.bool_IsReceiveThreadWorking, 10000);

        if (bool_ThreadStartedComplete == false)
        {
            return;
        }

        RemoteCallAction remoteCallAction_obj = new RemoteCallAction();

        remoteCallAction_obj.NecessaryBaseChannelObject = SystemChannel.BaseChannel;

        remoteCallAction_obj.SendGeneratedUID(SystemChannel.BaseChannel.ChannelUID);
    }
    public void RegisterNewAppliedChannel(ulong ulong_DestinedClientUIN, BaseChannelObject baseChannelObject_obj)
    {
        AppliedServerChannel appliedServerChannel_obj = new AppliedServerChannel(baseChannelObject_obj, this);

        appliedServerChannel_obj.BaseChannel.InterConnectedUIN = ulong_DestinedClientUIN;

        appliedServerChannel_obj.ChannelOwner = this;

        ulong ulong_GeneratedAppliedChannelUID = 0;

        lock (this)
        {
            foreach (AppliedServerChannel appliedServerChannel_CycleObj in AllAppliedServerChannels)
            {
                if (appliedServerChannel_CycleObj.BaseChannel.ChannelUID == ulong_GeneratedAppliedChannelUID)
                {
                    ulong_GeneratedAppliedChannelUID = (ulong)new Random().Next(int.MaxValue);

                    continue;
                }
            }
        }

        appliedServerChannel_obj.BaseChannel.ChannelUID = ulong_GeneratedAppliedChannelUID;

        if (ConnectedClient.GetClientByUIN(ulong_DestinedClientUIN) == null)
        {
            return;
        }
        appliedServerChannel_obj.InterconnectedObject = ConnectedClient.GetClientByUIN(ulong_DestinedClientUIN).GetNecesseryAppliedClientChannelByServerUIN(this.UIN);

        AppliedServerChannels.Add(appliedServerChannel_obj);
        ConnectedServer.AllAppliedServerChannels.Add(appliedServerChannel_obj);
    }

    public static bool IsNecesseryUINConnected(ulong ulong_UIN)
    {
        foreach (ConnectedServer connectedServer_obj in ConnectedServer.AllConnectedServers)
        {
            if (connectedServer_obj.UIN == ulong_UIN)
            {
                return true;
            }
        }

        return false;
    }
    public static ConnectedServer GetServerByUIN(ulong ulong_UIN)
    {
        foreach (ConnectedServer connectedServer_obj in ConnectedServer.AllConnectedServers)
        {
            if (ulong_UIN == connectedServer_obj.UIN)
            {
                return connectedServer_obj;
            }
        }

        return null;
    }
    public AppliedServerChannel GetNecesseryAppliedServerChannelByClientUIN(ulong ulong_UIN)
    {
        foreach (AppliedServerChannel appliedServerChannel_obj in AllAppliedServerChannels)
        {
            if (appliedServerChannel_obj.BaseChannel.InterConnectedUIN == ulong_UIN)
            {
                return appliedServerChannel_obj;
            }
        }

        return null;
    }

    static List<ConnectedServer> list_AllConnectedServers = new List<ConnectedServer>();
    public static List<ConnectedServer> AllConnectedServers
    {
        get
        {
            return list_AllConnectedServers;
        }
    }

    public void OnSystemChannelConnectionEstablished()
    {

    }
    public void OnAppliedChannelConnectionEstablished()
    {

    }
}


/*
 * 
 * cначала регистрируются системные каналы
 * потом регистрируюся прикладные 
 * это всё в InitCommonReceiveCycle
 * потом по системному каналу плиент запрашивает соединение с сервером
 * если сервер найден то происходит процесс межсоединения
 * если нет но клиент хочет ждать - клиент висит в ожидаании
 * елси сервера нет и клиент не хочет ждать то склиент отрубается
 * 
 */

public class NetworkAction
{
    [DllImport("YakSysRctServerLib.dll")]
    private static extern string ResolveMACAddressFromIP(string string_IPAddress);

    private static TcpListener tcpListener_MainListener;

    protected static int int_InstanceCount = 0;
    public static int InstanceCount
    {
        get
        {
            return int_InstanceCount;
        }

        set
        {
            int_InstanceCount = value;
        }
    }

    #region InterConnectedObjects Processing

    public class InterConnectedObjects
    {
        ConnectedServer.AppliedServerChannel appliedServerChannel_obj = null;
        public ConnectedServer.AppliedServerChannel AppliedServerChannel
        {
            get
            {
                return appliedServerChannel_obj;
            }
            set
            {
                appliedServerChannel_obj = value;
            }
        }

        ConnectedClient.AppliedClientChannel appliedClientChannel_obj = null;
        public ConnectedClient.AppliedClientChannel AppliedClientChannel
        {
            get
            {
                return appliedClientChannel_obj;
            }
            set
            {
                appliedClientChannel_obj = value;
            }
        }
    }

    bool bool_InterConnectionThreadMonitor = false;

    public void ServerInterConnectionProcessReceiveCycle(Object interConnectedObject_obj)
    {
        /*
        byte[] byteArray_ReceivedData = null;

        int int_BytesRead = 0;

        try
        {
            while (((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Client.Connected == true && ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Client.Connected == true)
            {
                if (((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Client.Available > 0)
                {
                    int_BytesRead = 0;

                    byteArray_ReceivedData = new byte[((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Client.Available];

                    //                                                      | SERVER |
                    int_BytesRead = ((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Client.Receive(byteArray_ReceivedData);
                    Thread.Sleep(1);
                    if (int_BytesRead != byteArray_ReceivedData.Length)
                    {
                        MessageBox.Show("FUCK1");
                    }
                    //                                                      | CLIENT |
                    int_BytesRead = ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Client.Send(byteArray_ReceivedData);
                    Thread.Sleep(1);

                    if (int_BytesRead != byteArray_ReceivedData.Length)
                    {
                        MessageBox.Show("FUCK2");
                    }

                    /*
                    ObjCopy.obj_MainForm.Statistic_BytesSent += byteArray_ReceivedData.Length;
                    ((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Statistic_BytesReceived += byteArray_ReceivedData.Length;

                    ObjCopy.obj_MainForm.Statistic_BytesReceived += byteArray_ReceivedData.Length;
                    ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Statistic_BytesSent += byteArray_ReceivedData.Length;
                    */
        //}
        //-----------------------------------------------------------------------------------------------------------------------------
        /*
                    if (((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Client.Available > 0)
                    {
                        int_BytesRead = 0;

                        byteArray_ReceivedData = new byte[((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Client.Available];

                        //                                                      | CLIENT |
                        int_BytesRead = ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Client.Receive(byteArray_ReceivedData);
                        Thread.Sleep(1);
                        if (int_BytesRead != byteArray_ReceivedData.Length)
                        {
                            MessageBox.Show("FUCK3");
                        }
                        //                                                      | SERVER |
                        int_BytesRead = ((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Client.Send(byteArray_ReceivedData);
                        Thread.Sleep(1);
                        if (int_BytesRead != byteArray_ReceivedData.Length)
                        {
                            MessageBox.Show("FUCK4");
                        }
                        /*
                        ObjCopy.obj_MainForm.Statistic_BytesReceived += byteArray_ReceivedData.Length;
                        ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Statistic_BytesReceived += byteArray_ReceivedData.Length;

                        ObjCopy.obj_MainForm.Statistic_BytesSent += byteArray_ReceivedData.Length;
                        ((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Statistic_BytesSent += byteArray_ReceivedData.Length;
                        */
        /*
  }

  Thread.Sleep(2);
}
}

catch (Exception exception)
{
MessageBox.Show(exception.Message + " -- " + exception.StackTrace);
}

*/

        byte[] byteArray_ReceivedData = new byte[4096];

        int int_BytesAvailable = 0;

        try
        {
            while (((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Client.Connected == true && ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Client.Connected == true)
            {
                if (Monitor.TryEnter(bool_InterConnectionThreadMonitor, 10) == false)
                {
                    ServerInterConnectionProcessReceiveCycle(interConnectedObject_obj);

                    return;
                }

                if (((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Available > 0)
                {
                    int_BytesAvailable = ((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Available;

                    if (byteArray_ReceivedData != null && int_BytesAvailable < byteArray_ReceivedData.Length && byteArray_ReceivedData.Length > 10485760)
                    {
                        byteArray_ReceivedData = null;
                    }

                    if (byteArray_ReceivedData == null || byteArray_ReceivedData.Length < int_BytesAvailable)
                    {
                        byteArray_ReceivedData = new byte[int_BytesAvailable];
                    }

                    //                                                      | SERVER |
                    ((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Client.Receive(byteArray_ReceivedData, int_BytesAvailable, SocketFlags.None);
                    //                                                      | CLIENT |
                    ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Client.Send(byteArray_ReceivedData, int_BytesAvailable, SocketFlags.None);

                    ObjCopy.obj_MainForm.Statistic_BytesSent += int_BytesAvailable;
                    ((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Statistic_BytesReceived += int_BytesAvailable;

                    ObjCopy.obj_MainForm.Statistic_BytesReceived += int_BytesAvailable;
                    ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Statistic_BytesSent += int_BytesAvailable;
                }

                Thread.Sleep(1);
            }
        }

        catch (Exception exception)
        {
            MessageBox.Show(exception.Message + " -- " + exception.StackTrace);
        }
    }

    public void ClientInterConnectionProcessReceiveCycle(Object interConnectedObject_obj)
    {
        byte[] byteArray_ReceivedData = new byte[4096];

        int int_BytesAvailable = 0;

        try
        {
            while (((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Client.Connected == true && ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Client.Connected == true)
            {
                if (Monitor.TryEnter(bool_InterConnectionThreadMonitor, 10) == false)
                {
                    ServerInterConnectionProcessReceiveCycle(interConnectedObject_obj);

                    return;
                }

                if (((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Available > 0)
                {
                    int_BytesAvailable = ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Available;

                    if (byteArray_ReceivedData != null && int_BytesAvailable < byteArray_ReceivedData.Length && byteArray_ReceivedData.Length > 10485760)
                    {
                        byteArray_ReceivedData = null;
                    }

                    if (byteArray_ReceivedData == null || byteArray_ReceivedData.Length < int_BytesAvailable)
                    {
                        byteArray_ReceivedData = new byte[int_BytesAvailable];
                    }

                    //                                                      | CLIENT |
                    ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Client.Receive(byteArray_ReceivedData, int_BytesAvailable, SocketFlags.None);
                    //                                                      | SERVER |
                    ((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Client.Send(byteArray_ReceivedData, int_BytesAvailable, SocketFlags.None);

                    ObjCopy.obj_MainForm.Statistic_BytesReceived += int_BytesAvailable;
                    ((InterConnectedObjects)interConnectedObject_obj).AppliedClientChannel.BaseChannel.Statistic_BytesReceived += int_BytesAvailable;

                    ObjCopy.obj_MainForm.Statistic_BytesSent += int_BytesAvailable;
                    ((InterConnectedObjects)interConnectedObject_obj).AppliedServerChannel.BaseChannel.Statistic_BytesSent += int_BytesAvailable;
                }

                Thread.Sleep(1);
            }
        }

        catch (Exception exception)
        {
            MessageBox.Show(exception.Message + " -- " + exception.StackTrace);
        }

    }

    #endregion

    void RegisterNewUIN(BaseChannelObject baseChannelObject_obj, byte[] byteArray_ReceivedData)
    {
        YakSys.Compression.CommonEnvironment commonEnvironment_obj = new YakSys.Compression.CommonEnvironment();

        CompressionEnvironment.DeflateCompressionWrapper deflateCompressionWrapper_obj = new CompressionEnvironment.DeflateCompressionWrapper();

        int int_ReceivedDataLength = 0, int_TotalReceived = 0,
            int_TotalAvailable = 0, int_DataEncryptionAlgorithm = 0,
            int_DataCompressionAlgorithm = 0;

        MemoryStream memoryStream_ReceivedData = new MemoryStream(),
                     memoryStream_DecryptedData = new MemoryStream();

        LocalAction localAction_obj = null;

        byte[] byteArray_SystemData = new byte[6];

        if (byteArray_ReceivedData == null)
        {
            byteArray_ReceivedData = new byte[6];
        }

        //////////////////////////////////

        while (baseChannelObject_obj.Client.Connected && baseChannelObject_obj.RequestToDisconnect == false)
        {
            if (baseChannelObject_obj.Available > 6)
            {
                #region Receive System MetaData [first 6 bytes]

                baseChannelObject_obj.Client.Receive(byteArray_SystemData);

                int_ReceivedDataLength = BitConverter.ToInt32(byteArray_SystemData, 0);

                int_DataCompressionAlgorithm = byteArray_SystemData[4];
                int_DataEncryptionAlgorithm = byteArray_SystemData[5];

                #endregion

                #region Re-Init MemoryStream and int_TotalReceived an int_TotalAvailable objects

                memoryStream_ReceivedData.SetLength(0);

                int_TotalReceived = 0;
                int_TotalAvailable = 0;

                #endregion

                #region Receive all Data from Socket

                while (int_TotalReceived != int_ReceivedDataLength)
                {
                    if (baseChannelObject_obj.RequestToDisconnect) return;

                    int_TotalAvailable = baseChannelObject_obj.Client.Available;

                    if (int_TotalAvailable > 0)
                    {
                        if (int_TotalAvailable > (int_ReceivedDataLength - int_TotalReceived))
                        {
                            byteArray_ReceivedData = new byte[int_ReceivedDataLength - int_TotalReceived];
                        }

                        else
                        {
                            byteArray_ReceivedData = new byte[int_TotalAvailable];
                        }

                        int_TotalReceived += baseChannelObject_obj.Client.Receive(byteArray_ReceivedData);

                        memoryStream_ReceivedData.Write(byteArray_ReceivedData, 0, byteArray_ReceivedData.Length);
                    }
                }

                #endregion

                #region Decrypt, Decompress and Process Data if connected object successfully authorized

                localAction_obj = new LocalAction();

                localAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;

                if (int_DataEncryptionAlgorithm > 0)
                {
                    memoryStream_ReceivedData.Position = 0;
                    memoryStream_DecryptedData.SetLength(0);

                    memoryStream_DecryptedData = new MemoryStream(baseChannelObject_obj.DecryptData(memoryStream_ReceivedData, int_DataEncryptionAlgorithm)); //Decrypt Data!

                    localAction_obj.RecivedData = new byte[memoryStream_DecryptedData.ToArray().Length];

                    memoryStream_DecryptedData.Position = 0;
                    memoryStream_DecryptedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                    if (int_DataCompressionAlgorithm != 0)
                    {
                        if (int_DataCompressionAlgorithm < 4)
                        {
                            localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                        }
                        else
                        {
                            localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                        }
                    }

                    if (BitConverter.ToInt32(localAction_obj.RecivedData, 0) == 1000 || BitConverter.ToInt32(localAction_obj.RecivedData, 0) == 1001)
                    {
                        localAction_obj.ActionAllocator();

                        return;
                    }

                    continue;
                }

                #endregion
            }

            if (byteArray_ReceivedData == null)
            {
                Thread.Sleep(1);

                continue;
            }

            #region Check Authorization New RSA Method

            if (BitConverter.ToInt32(byteArray_ReceivedData, 0) == -37) //at first get the request from client or server
            {
                if (byteArray_ReceivedData[4] == 0)
                {
                    baseChannelObject_obj.ConnectingObjectTypeInfo = ConnectingObjectType.Client;
                }
                else //Server Request
                {
                    baseChannelObject_obj.ConnectingObjectTypeInfo = ConnectingObjectType.Server;
                }

                baseChannelObject_obj.SetAndSendRSAPublicKey();
            }

            if (BitConverter.ToInt32(byteArray_ReceivedData, 0) == -33) //at second init the crypto subsystem
            {
                memoryStream_ReceivedData.Position = 4;

                CommonNetworkSecurity.RSADecryptAndSetPrimaryAESKeyInfo(memoryStream_ReceivedData, baseChannelObject_obj.XMLStringWithPrivateRSAKeys, baseChannelObject_obj);

                baseChannelObject_obj.SendCryptoKeysForNewUINRegistration();
            }

            byteArray_ReceivedData = null;

            Thread.Sleep(1);

            #endregion
        }

        return;
    }

    void InitCommonReceiveCycle() // <--- Init Loop!
    {
        MemoryStream memoryStream_ReceivedData = new MemoryStream(),
                     memoryStream_DecryptedData = new MemoryStream(),
                     memoryStream_EncryptedLoginPasswordPair = new MemoryStream();

        try
        {
            Socket socket_TempAcceptedSocket = tcpListener_MainListener.AcceptSocket();

            BaseChannelObject baseChannelObject_obj = new BaseChannelObject();

            baseChannelObject_obj.Client = socket_TempAcceptedSocket;

            baseChannelObject_obj.SendCheckInfoToClients();

            YakSys.Compression.CommonEnvironment commonEnvironment_obj = new YakSys.Compression.CommonEnvironment();

            CompressionEnvironment.DeflateCompressionWrapper deflateCompressionWrapper_obj = new CompressionEnvironment.DeflateCompressionWrapper();

            byte[] byteArray_SystemData = new byte[6], byteArray_ReceivedData = null;

            int int_ReceivedDataLength = 0, int_TotalReceived = 0,
                int_TotalAvailable = 0, int_DataEncryptionAlgorithm = 0,
                int_DataCompressionAlgorithm = 0;

            LocalAction localAction_obj = null;

            ulong ulong_UIN = 0, ulong_InterConnectedUIN = 0, ulong_UID = 0;

            ChannelType channelType_obj = new ChannelType();

            ConnectedServer connectedServer_obj;
            ConnectedClient connectedClient_obj;

            bool bool_IsAccessPissible = false;

            while (baseChannelObject_obj.Client.Connected && baseChannelObject_obj.RequestToDisconnect == false)
            {
                if (baseChannelObject_obj.Available > 6)
                {
                    #region Receive System MetaData [first 6 bytes]

                    baseChannelObject_obj.Client.Receive(byteArray_SystemData);

                    int_ReceivedDataLength = BitConverter.ToInt32(byteArray_SystemData, 0);

                    int_DataCompressionAlgorithm = byteArray_SystemData[4];
                    int_DataEncryptionAlgorithm = byteArray_SystemData[5];

                    #endregion

                    #region Re-Init MemoryStream and int_TotalReceived an int_TotalAvailable objects

                    memoryStream_ReceivedData.SetLength(0);

                    int_TotalReceived = 0;
                    int_TotalAvailable = 0;

                    #endregion

                    #region Receive all Data from Socket

                    while (int_TotalReceived != int_ReceivedDataLength)
                    {
                        if (baseChannelObject_obj.RequestToDisconnect) return;

                        int_TotalAvailable = baseChannelObject_obj.Client.Available;

                        if (int_TotalAvailable > 0)
                        {
                            if (int_TotalAvailable > (int_ReceivedDataLength - int_TotalReceived))
                            {
                                byteArray_ReceivedData = new byte[int_ReceivedDataLength - int_TotalReceived];
                            }

                            else
                            {
                                byteArray_ReceivedData = new byte[int_TotalAvailable];
                            }

                            int_TotalReceived += baseChannelObject_obj.Client.Receive(byteArray_ReceivedData);

                            memoryStream_ReceivedData.Write(byteArray_ReceivedData, 0, byteArray_ReceivedData.Length);
                        }
                    }

                    if (byteArray_ReceivedData == null)
                    {
                        Thread.Sleep(100);

                        continue;
                    }

                    #endregion

                    #region Decrypt, Decompress and Process Data if connected object successfully authorized

                    localAction_obj = new LocalAction();

                    localAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;

                    if (baseChannelObject_obj.IsAuthorized && int_DataEncryptionAlgorithm > 0)
                    {
                        if (!baseChannelObject_obj.IsAccountEnabled)
                        {
                            if (baseChannelObject_obj.RequestToDisconnect) return;

                            Thread.Sleep(500);

                            continue;
                        }

                        memoryStream_ReceivedData.Position = 0;
                        memoryStream_DecryptedData.SetLength(0);

                        memoryStream_DecryptedData = new MemoryStream(baseChannelObject_obj.DecryptData(memoryStream_ReceivedData, int_DataEncryptionAlgorithm));

                        localAction_obj.RecivedData = new byte[memoryStream_DecryptedData.ToArray().Length];

                        memoryStream_DecryptedData.Position = 0;
                        memoryStream_DecryptedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                        if (int_DataCompressionAlgorithm != 0)
                        {
                            if (int_DataCompressionAlgorithm < 4)
                            {
                                localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                            }
                            else
                            {
                                localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                            }
                        }

                        localAction_obj.ActionAllocator();

                        continue;
                    }

                    #endregion

                    #region Authorization

                    if (baseChannelObject_obj.IsAuthorized == false && baseChannelObject_obj.IsAccountEnabled == false)
                    {
                        if (byteArray_ReceivedData.Length == 4 && BitConverter.ToInt32(byteArray_ReceivedData, 0) == 999)
                        {
                            RegisterNewUIN(baseChannelObject_obj, byteArray_ReceivedData);

                            return;
                        }

                        #region baseChannelObject init and IPAddress resolving

                        localAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;

                        IPAddress iPAddress_ClientIP = IPAddress.Parse(baseChannelObject_obj.IPAddress);

                        string string_MACAddress = ResolveMACAddressFromIP(baseChannelObject_obj.IPAddress);
                        baseChannelObject_obj.MACAddress = string_MACAddress;

                        #endregion

                        #region Close connection if connection is impossible by MaxConnections value or Access Restriction Rules

                        if (CommonEnvironment.MaxConnections > 0 && CommonEnvironment.MaxConnections == BaseChannelObject.AllBaseChannelObjects.Count)
                        {
                            baseChannelObject_obj.Disconnect(2); // 2 is a reason of max connection limit exhausted

                            return;
                        }

                        #endregion

                        #region  Process Initial Request Data and Send RSA Public Key as answer

                        if (BitConverter.ToInt32(byteArray_ReceivedData, 0) == -37) //Initial Request
                        {
                            if (byteArray_ReceivedData[4] == 0)
                            {
                                baseChannelObject_obj.ConnectingObjectTypeInfo = ConnectingObjectType.Client;

                                bool_IsAccessPissible = ClientsNetworkSecurity.CheckAccessPossible(iPAddress_ClientIP, string_MACAddress);

                                if (ClientsNetworkSecurity.UserAccount.UsersAccounts.Count == 0)
                                {
                                    bool_IsAccessPissible = false;
                                }
                            }
                            else //Server Request
                            {
                                baseChannelObject_obj.ConnectingObjectTypeInfo = ConnectingObjectType.Server;

                                bool_IsAccessPissible = ServersNetworkSecurity.CheckAccessPossible(iPAddress_ClientIP, string_MACAddress);

                                if (ServersNetworkSecurity.UserAccount.UsersAccounts.Count == 0)
                                {
                                    bool_IsAccessPissible = false;
                                }
                            }


                            if (byteArray_ReceivedData[5] == 0) //Is a System Channel Object
                            {
                                channelType_obj = ChannelType.System;
                            }
                            else //Is a Applied Channel Object 
                            {
                                channelType_obj = ChannelType.Applied;
                            }

                            baseChannelObject_obj.ChannelTypeInfo = channelType_obj;

                            ulong_UIN = BitConverter.ToUInt64(byteArray_ReceivedData, 6);
                            baseChannelObject_obj.UIN = ulong_UIN;

                            ulong_InterConnectedUIN = BitConverter.ToUInt64(byteArray_ReceivedData, 14);
                            baseChannelObject_obj.InterConnectedUIN = ulong_InterConnectedUIN;

                            ulong_UID = BitConverter.ToUInt64(byteArray_ReceivedData, 22);

                            if (bool_IsAccessPissible == false) //Check is connection possible
                            {
                                baseChannelObject_obj.Disconnect(0); // Auth failed

                                return;
                            }

                            #region Disconnect if object with same UIN already connected
                            //--------------------------------------------------------------------------------------------------------------------------------
                            if (baseChannelObject_obj.ConnectingObjectTypeInfo == ConnectingObjectType.Client)
                            {
                                if ((ConnectedClient.IsNecesseryUINConnected(ulong_UIN) == true && channelType_obj == ChannelType.System) ||
                                    (BaseChannelObject.IsNecesseryUIDRegistered(ulong_UID) != true && channelType_obj == ChannelType.Applied))
                                {
                                    baseChannelObject_obj.Disconnect(0);  // Auth failed

                                    return;
                                }
                            }

                            if (baseChannelObject_obj.ConnectingObjectTypeInfo == ConnectingObjectType.Server)
                            {
                                if ((ConnectedServer.IsNecesseryUINConnected(ulong_UIN) == true && channelType_obj == ChannelType.System) ||
                                    (ulong_UID != 0 && BaseChannelObject.IsNecesseryUIDRegistered(ulong_UID) == true && channelType_obj == ChannelType.Applied))
                                {
                                    baseChannelObject_obj.Disconnect(0);  // Auth failed

                                    return;
                                }
                            }
                            //--------------------------------------------------------------------------------------------------------------------------------
                            #endregion

                            baseChannelObject_obj.SetAndSendRSAPublicKey();
                        }

                        #endregion

                        #region Check Authorization New RSA Method

                        if (BitConverter.ToInt32(byteArray_ReceivedData, 0) == -33)
                        {
                            memoryStream_ReceivedData.Position = 4;

                            CommonNetworkSecurity.RSADecryptAndSetPrimaryAESKeyInfo(memoryStream_ReceivedData, baseChannelObject_obj.XMLStringWithPrivateRSAKeys, baseChannelObject_obj);

                            baseChannelObject_obj.SendCryptoKeys();
                        }

                        if (BitConverter.ToInt32(byteArray_ReceivedData, 0) == -35)
                        {
                            memoryStream_ReceivedData.Position = 4;

                            string string_Login = String.Empty, string_Password = String.Empty;

                            memoryStream_EncryptedLoginPasswordPair = new MemoryStream(CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData));

                            CommonNetworkSecurity.DecryptLoginPasswordPair(baseChannelObject_obj.DecryptData(memoryStream_EncryptedLoginPasswordPair, 8), out string_Login, out string_Password);

                            bool bool_IsAuthUser = false;

                            if (baseChannelObject_obj.ConnectingObjectTypeInfo == ConnectingObjectType.Client)
                            {
                                bool_IsAuthUser = ClientsNetworkSecurity.AuthorizeConnectedUser(ref baseChannelObject_obj, string_Login, string_Password);
                            }
                            else
                            {
                                bool_IsAuthUser = ServersNetworkSecurity.AuthorizeConnectedUser(ref baseChannelObject_obj, string_Login, string_Password);
                            }

                            #region /////////////////////////////////////////// Close session if connection impossible

                            if (bool_IsAuthUser == false)
                            {
                                baseChannelObject_obj.Disconnect(0); // Auth failed
                            }

                            if (
                                CommonEnvironment.MaxConnectionsPerAccount > 0 &&
                                (baseChannelObject_obj.ConnectingObjectTypeInfo == ConnectingObjectType.Client &&
                                CommonEnvironment.MaxConnectionsPerAccount == baseChannelObject_obj.clientsUserAccount_AssignedValue.ClientsUsingAccount.Count - 1)
                                ||
                                CommonEnvironment.MaxConnectionsPerAccount > 0 &&
                                (baseChannelObject_obj.ConnectingObjectTypeInfo == ConnectingObjectType.Server &&
                                CommonEnvironment.MaxConnectionsPerAccount == baseChannelObject_obj.serversUserAccount_AssignedValue.ClientsUsingAccount.Count - 1)
                                )
                            {

                                //--------------------------------------------------------------------------------------------------------------------------------
                                if (baseChannelObject_obj.ConnectingObjectTypeInfo == ConnectingObjectType.Server)
                                {
                                    if (baseChannelObject_obj.serversUserAccount_AssignedValue.ClientsUsingAccount.Contains(baseChannelObject_obj) == true)
                                    {
                                        baseChannelObject_obj.serversUserAccount_AssignedValue.ClientsUsingAccount.Remove(baseChannelObject_obj);
                                    }
                                }
                                else
                                {
                                    if (baseChannelObject_obj.clientsUserAccount_AssignedValue.ClientsUsingAccount.Contains(baseChannelObject_obj) == true)
                                    {
                                        baseChannelObject_obj.clientsUserAccount_AssignedValue.ClientsUsingAccount.Remove(baseChannelObject_obj);
                                    }
                                }
                                //--------------------------------------------------------------------------------------------------------------------------------

                                baseChannelObject_obj.Disconnect(3);

                                return;
                            }
                            #endregion

                            /////////////////////////////////////////// Login Successs

                            localAction_obj.SendAuthorizationStatus(1); // AUTH OK!!!

                            #region Log And Statistic Calls

                            if (channelType_obj == ChannelType.System)
                            {
                                baseChannelObject_obj.Statistic_ConnectedTime = DateTime.Now;

                                ObjCopy.obj_MainForm.Statistic_LastConnectionAt = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

                                ObjCopy.obj_MainForm.Statistic_ActiveConnections++;

                                if (baseChannelObject_obj.ConnectingObjectTypeInfo == ConnectingObjectType.Server)
                                {
                                    #region Call Log Event

                                    ConnectingServiceLogsEvents.NewServersLogRecordEvent(StringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), baseChannelObject_obj.NetworkInformation_UserName, string_Login, StringFactory.GetString(1, MainForm.CurrentLanguage), StringFactory.GetString(54, MainForm.CurrentLanguage), false);

                                    #endregion
                                }
                                if (baseChannelObject_obj.ConnectingObjectTypeInfo == ConnectingObjectType.Client)
                                {
                                    #region Call Log Event

                                    ConnectingServiceLogsEvents.NewClientsLogRecordEvent(StringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), baseChannelObject_obj.NetworkInformation_UserName, string_Login, StringFactory.GetString(1, MainForm.CurrentLanguage), StringFactory.GetString(54, MainForm.CurrentLanguage), false);

                                    #endregion
                                }
                            }


                            #endregion

                            baseChannelObject_obj.IsAuthorized = true;    //  дошли и авторизовались!

                            new Thread(new ThreadStart(baseChannelObject_obj.CheckClientsConnetions)).Start();

                            if (baseChannelObject_obj.IsAccountEnabled == false) //  аккаунт временно заблокирован... будет ждать пока не разблокируется!
                            {
                                localAction_obj.SendAuthorizationStatus(4); // 4 reason is account temporary disabled

                                while (baseChannelObject_obj.IsAccountEnabled == false)
                                {
                                    if (baseChannelObject_obj.Client.Connected == false && baseChannelObject_obj.RequestToDisconnect == true)
                                    {
                                        baseChannelObject_obj.Disconnect();

                                        return;
                                    }

                                    Thread.Sleep(1000);
                                }
                            }

                            #region Init Necessary System Transport Channel

                            //If Connected object is Client
                            if (baseChannelObject_obj.ConnectingObjectTypeInfo == ConnectingObjectType.Client)
                            {
                                if (ConnectedClient.IsNecesseryUINConnected(baseChannelObject_obj.UIN) == false)
                                {
                                    connectedClient_obj = new ConnectedClient(baseChannelObject_obj.UIN);
                                }
                                else
                                {
                                    connectedClient_obj = ConnectedClient.GetClientByUIN(baseChannelObject_obj.UIN);
                                }

                                /////////////////////////////////////////

                                if (channelType_obj == ChannelType.System)
                                {
                                    connectedClient_obj.SystemChannel = new ConnectedClient.SystemClientChannel(baseChannelObject_obj, connectedClient_obj);

                                    connectedClient_obj.RegisterNewSystemChannel();

                                    CommonNetworkEvents.NewClientConnectedEvent(connectedClient_obj);
                                }

                                if (channelType_obj == ChannelType.Applied)
                                {
                                    connectedClient_obj.RegisterNewAppliedChannel(baseChannelObject_obj.InterConnectedUIN, baseChannelObject_obj);
                                }
                            }
                            //If Connected object is Server
                            if (baseChannelObject_obj.ConnectingObjectTypeInfo == ConnectingObjectType.Server)
                            {
                                if (ConnectedServer.IsNecesseryUINConnected(baseChannelObject_obj.UIN) == false)
                                {
                                    connectedServer_obj = new ConnectedServer(baseChannelObject_obj.UIN);
                                }
                                else
                                {
                                    connectedServer_obj = ConnectedServer.GetServerByUIN(baseChannelObject_obj.UIN);
                                }

                                /////////////////////////////////////////

                                if (channelType_obj == ChannelType.System)
                                {
                                    connectedServer_obj.SystemChannel = new ConnectedServer.SystemServerChannel(baseChannelObject_obj, connectedServer_obj);

                                    connectedServer_obj.RegisterNewSystemChannel();

                                    CommonNetworkEvents.NewServerConnectedEvent(connectedServer_obj);
                                }

                                if (channelType_obj == ChannelType.Applied)
                                {
                                    connectedServer_obj.RegisterNewAppliedChannel(baseChannelObject_obj.InterConnectedUIN, baseChannelObject_obj);
                                }
                            }

                            return;

                            #endregion
                        }

                        #endregion
                    }

                    #endregion

                    Thread.Sleep(100);

                    continue;
                }

                Thread.Sleep(100);
            }
        }

        catch (Exception exception)
        {
            MessageBox.Show(exception.Message + " -- " + exception.StackTrace);

            return;
        }

        finally
        {
            if (memoryStream_ReceivedData != null)
            {
                memoryStream_ReceivedData.Close();
            }
            if (memoryStream_DecryptedData != null)
            {
                memoryStream_DecryptedData.Close();
            }
            if (memoryStream_EncryptedLoginPasswordPair != null)
            {
                memoryStream_EncryptedLoginPasswordPair.Close();
            }
        }
    }

    public void StartServer()
    {
        try
        {
            if (InstanceCount == 0)
            {
                tcpListener_MainListener = new TcpListener(IPAddress.Any, CommonEnvironment.ServerPort);
            }
            else
            {
                MessageBox.Show(StringFactory.GetString(55, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (ClientsNetworkSecurity.UserAccount.UsersAccounts.Count == 0 && ServersNetworkSecurity.UserAccount.UsersAccounts.Count == 0)
            {
                MessageBox.Show(StringFactory.GetString(69, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            tcpListener_MainListener.Start();

            InstanceCount++;


            ObjCopy.obj_MainForm.Invoke((MethodInvoker)delegate
            {
                ObjCopy.obj_MainForm.ServerStatus = StringFactory.GetString(56, MainForm.CurrentLanguage);

                #region Call Log Event

                ConnectingServiceLogsEvents.NewCommonLogRecordEvent(StringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), StringFactory.GetString(1, MainForm.CurrentLanguage), StringFactory.GetString(57, MainForm.CurrentLanguage), false);

                #endregion

                ObjCopy.obj_MainForm.Statistic_BytesSent = 0;
                ObjCopy.obj_MainForm.Statistic_BytesReceived = 0;
                ObjCopy.obj_MainForm.Statistic_ActiveConnections = 0;
            });


            while (InstanceCount == 1)
            {
                if (tcpListener_MainListener.Pending() == true)
                {
                    new Thread(new ThreadStart(InitCommonReceiveCycle)).Start();
                }

                Thread.Sleep(500);
            }
        }

        catch (Exception exception)
        {

        }
    }

    public void StopServer()
    {
        if (InstanceCount > 0)
        {
            InstanceCount--;

            if (CommonNetworkEvents.ServiceStoppedEvent != null)
            {
                CommonNetworkEvents.ServiceStoppedEvent();
            }

            tcpListener_MainListener.Stop();

            foreach (ConnectedClient connectedClient_obj in ConnectedClient.AllConnectedClients)
            {
                connectedClient_obj.Disconnect();
            }

            foreach (ConnectedServer connectedServer_obj in ConnectedServer.AllConnectedServers)
            {
                connectedServer_obj.Disconnect();
            }

            ConnectedClient.AllSystemClientChannels.Clear();
            ConnectedClient.AllAppliedClientChannels.Clear();

            ConnectedServer.AllSystemServerChannels.Clear();
            ConnectedServer.AllAppliedServerChannels.Clear();

            ConnectedClient.AllConnectedClients.Clear();
            ConnectedServer.AllConnectedServers.Clear();

            BaseChannelObject.AllBaseChannelObjects.Clear();


            ObjCopy.obj_MainForm.ServerStatus = StringFactory.GetString(7, MainForm.CurrentLanguage);

            #region Call Log Event

            ConnectingServiceLogsEvents.NewCommonLogRecordEvent(StringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), StringFactory.GetString(1, MainForm.CurrentLanguage), StringFactory.GetString(59, MainForm.CurrentLanguage), false);

            #endregion

            ObjCopy.obj_MainForm.Statistic_ActiveConnections = 0;
        }
    }
}
