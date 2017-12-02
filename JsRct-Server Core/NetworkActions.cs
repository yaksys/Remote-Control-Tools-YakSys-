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
using JurikSoft.Compression;
using System.Runtime.InteropServices;
using JurikSoft.XMLConfigImporer.JsRctServer.Version110;
using System.Drawing;
using System.Drawing.Imaging;
using JurikSoft.Server_Core;

namespace JurikSoft
{
    namespace Server_Core
    {
        [Serializable]
        public enum SentDataType
        {
            SystemData, ApplicationData, FileObject, ScreenShot, RTDVFrame, AudioPacket
        }



        [Serializable]
        public class JurikSoftTcpClient : TcpClient
        {



            public JurikSoftTcpClient()
            {
                rNGCryptoServiceProvider_RandomGenerator.GetBytes(byteArray_RandomAuthorizationCodeForClient);

                /*  
                  SessionStatisticAndInfo_Obj = new SessionStatisticAndInfo();

                  SessionStatisticAndInfo_Obj.JurikSoftTcpClient_Owner = this;

                  SessionStatisticAndInfo.AllSessionStatisticAndInfoOjects.Add(SessionStatisticAndInfo_Obj);                
              */
                bool_SendAbortSignal = false;

                new Thread(SendNormalPriorityDataThread).Start();
                new Thread(SendLowPriorityDataThread).Start();
                new Thread(SendHighPriorityDataThread).Start();

            }
            ~JurikSoftTcpClient()
            {
                RTDVQueries = 0;

                bool_SendAbortSignal = true;
            }

            public void InitCompressionEnvironment()
            {
                new ConmpressionEnvironment(); //Init objects in static Array of compression interface
            }

            #region Session Statistic and Informtion SubSystem

            SessionStatisticAndInfo sessionStatisticAndInfo_obj = null;
            public SessionStatisticAndInfo SessionStatisticAndInfo_Obj
            {
                get
                {
                    return sessionStatisticAndInfo_obj;
                }
                set
                {
                    sessionStatisticAndInfo_obj = value;
                }
            }

            [Serializable]
            public class SessionStatisticAndInfo : MarshalByRefObject
            {
                string string_AccountType, string_UserName;
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
                public string ClientIPAddress
                {
                    get
                    {
                        return ((IPEndPoint)this.JurikSoftTcpClient_Owner.Client.RemoteEndPoint).Address.ToString();
                    }
                }

                long long_BytesReceived = 0;
                long long_BytesSent = 0;
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

                public bool IsAccountEnabled
                {
                    get
                    {
                        return JurikSoftTcpClient_Owner.IsAccountEnabled;
                    }
                }

                internal bool bool_IsNewObject = true;
                public bool IsNewObject
                {
                    get
                    {
                        return bool_IsNewObject;
                    }
                    set
                    {
                        bool_IsNewObject = value;
                    }
                }

                internal JurikSoftTcpClient jurikSoftTcpClient_Owner = null;
                internal JurikSoftTcpClient JurikSoftTcpClient_Owner
                {
                    get
                    {
                        return jurikSoftTcpClient_Owner;
                    }

                    set
                    {
                        jurikSoftTcpClient_Owner = value;
                    }
                }

                static List<JurikSoftTcpClient> list_AllJurikSoftClients = new List<JurikSoftTcpClient>();
                internal static List<JurikSoftTcpClient> AllJurikSoftClients
                {
                    get
                    {
                        return list_AllJurikSoftClients;
                    }
                }

                static List<SessionStatisticAndInfo> list_AllSessionStatisticAndInfoOjects = new List<SessionStatisticAndInfo>();
                internal static List<SessionStatisticAndInfo> AllSessionStatisticAndInfoOjects
                {
                    get
                    {
                        return list_AllSessionStatisticAndInfoOjects;
                    }
                }
                public List<SessionStatisticAndInfo> RemotingWrapper_AllSessionStatisticAndInfoOjects
                {
                    get
                    {
                        return SessionStatisticAndInfo.AllSessionStatisticAndInfoOjects;
                    }
                }
            }

            #endregion

            #region SendData To Client method and his Environvment

            ICompression iCompression_obj = null;

            MemoryStream memoryStream_DataToSend = new MemoryStream();

            byte byte_IsDataCompressed = 0, byte_IsDataEncrypted = 0;

            NetworkStream networkStream_ThisClient = null;

            ///////////////////////////////////////////////////////////////////////////////////////



            enum PriorityClass { High, Normal, Low }

            struct SendingPacket
            {
                public byte[] byteArray_SentData;
                public SentDataType SentDataType_Current;
                public PriorityClass priorityClass_Priority;
                public bool NoDelay;
            }

            List<SendingPacket> list_HighPriority = new List<SendingPacket>();
            List<SendingPacket> list_NormalPriority = new List<SendingPacket>();
            List<SendingPacket> list_LowPriority = new List<SendingPacket>();

            bool bool_SendAbortSignal = false;

            void AddDataPacketToQueue(SendingPacket sendingPacket_Current)
            {
                switch (sendingPacket_Current.priorityClass_Priority)
                {
                    case PriorityClass.High:
                        list_HighPriority.Add(sendingPacket_Current);
                        break;

                    case PriorityClass.Normal:
                        list_NormalPriority.Add(sendingPacket_Current);
                        break;

                    case PriorityClass.Low:
                        list_LowPriority.Add(sendingPacket_Current);
                        break;
                }
            }

            void SendHighPriorityDataThread()
            {
                try
                {
                    Thread.CurrentThread.Priority = ThreadPriority.Highest;

                    for (; bool_SendAbortSignal != true; )
                    {
                        if (list_LowPriority == null)
                        {
                            bool_SendAbortSignal = true;

                            return;
                        }

                        if (list_HighPriority.Count == 0)
                        {
                            Thread.Sleep(100);

                            continue;
                        }

                        RealSendData(list_HighPriority[0]);

                        list_HighPriority.RemoveAt(0);

                        Thread.Sleep(1);
                    }

                }
                catch
                {
                    bool_SendAbortSignal = true;
                }
            }
            void SendNormalPriorityDataThread()
            {
                Thread.CurrentThread.Priority = ThreadPriority.Normal;

                try
                {
                    for (; bool_SendAbortSignal != true; )
                    {
                        if (list_LowPriority == null)
                        {
                            bool_SendAbortSignal = true;

                            return;
                        }

                        if (list_NormalPriority.Count == 0)
                        {
                            Thread.Sleep(100);

                            continue;
                        }

                        RealSendData(list_NormalPriority[0]);

                        list_NormalPriority.RemoveAt(0);

                        Thread.Sleep(10);
                    }
                }
                catch
                {
                    bool_SendAbortSignal = true;
                }
            }
            void SendLowPriorityDataThread()
            {
                Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                try
                {
                    for (; bool_SendAbortSignal != true; )
                    {
                        if (list_LowPriority == null)
                        {
                            bool_SendAbortSignal = true;

                            return;
                        }

                        if (list_LowPriority.Count == 0)
                        {
                            Thread.Sleep(100);

                            continue;
                        }

                        RealSendData(list_LowPriority[0]);

                        list_LowPriority.RemoveAt(0);

                        Thread.Sleep(10);
                    }
                }
                catch
                {
                    bool_SendAbortSignal = true;
                }
            }

            void RealSendData(SendingPacket sendingPacket_Current)
            {
                try
                {
                    lock (this)
                    {
                        byte[] byteArray_SentData = sendingPacket_Current.byteArray_SentData;

                        SentDataType SentDataType_Current = sendingPacket_Current.SentDataType_Current;

                        if (networkStream_ThisClient == null)
                        {
                            networkStream_ThisClient = this.GetStream(); //!! выбрасывает в эксцепшн ..говорит не может неподконнекченный сокет использовать
                        }

                        this.NoDelay = sendingPacket_Current.NoDelay;

                        iCompression_obj = ConmpressionEnvironment.iCompressionArray_obj[this.CompressSendingSystemDataAlgorithm];

                        memoryStream_DataToSend.SetLength(0);

                        byte_IsDataCompressed = 0;
                        byte_IsDataEncrypted = 0;

                        # region Write to the stream  metadata that contains information about used encryption\compression

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
                                iCompression_obj = ConmpressionEnvironment.iCompressionArray_obj[this.CompressSendingSystemDataAlgorithm];

                                byte_IsDataCompressed = (byte)this.CompressSendingSystemDataAlgorithm;
                            }
                            else
                            {
                                iCompression_obj = ConmpressionEnvironment.iCompressionArray_obj[this.CompressSendingFileObjectsDataAlgorithm];

                                byte_IsDataCompressed = (byte)this.CompressSendingFileObjectsDataAlgorithm;
                            }

                            byteArray_SentData = iCompression_obj.Compress(byteArray_SentData, false);
                        }

                        if (
                            (this.EncrypSendingSystemDataAlgorithm > 0 && SentDataType_Current == SentDataType.ApplicationData)
                            ||
                            (this.EncryptSendingFileObjectsDataAlgorithm > 0 && SentDataType_Current == SentDataType.FileObject)
                            ||
                            (this.EncryptSendingScreenshotDataAlgorithm > 0 && SentDataType_Current == SentDataType.ScreenShot)
                        )
                        {
                            if (SentDataType_Current == SentDataType.ApplicationData)
                            {
                                byteArray_SentData = this.EncryptData(byteArray_SentData, this.EncrypSendingSystemDataAlgorithm);
                                byte_IsDataEncrypted = (byte)this.EncrypSendingSystemDataAlgorithm;
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

                        NetworkStatusAndStatistics.Statistic_BytesSent += memoryStream_DataToSend.ToArray().Length; // ошибка?
                        this.sessionStatisticAndInfo_obj.Statistic_BytesSent += memoryStream_DataToSend.ToArray().Length;

                        networkStream_ThisClient.Write(memoryStream_DataToSend.ToArray(), 0, (int)memoryStream_DataToSend.ToArray().Length);
                    }
                }
                catch (Exception e) //!!!!!!!! вызывается при неправильном пароле\логине и не дает отправлять
                {
                    list_HighPriority.Clear();
                    list_NormalPriority.Clear();
                    list_NormalPriority.Clear();

                    MarkForDisconnect = true;

                    bool_SendAbortSignal = true;

                    throw new Exception("realsenddata exception");
                    //    MessageBox.Show("send data exception: " + e.Message);

                    //    ProcWindowService.MessageBoxPendingPool.AddMessageTaskToQueue("send data exception: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            public void SendData(byte[] byteArray_SentData, SentDataType SentDataType_Current)
            {
                try
                {
                    SendingPacket sendingPacket_Current = new SendingPacket();

                    sendingPacket_Current.byteArray_SentData = byteArray_SentData;

                    sendingPacket_Current.priorityClass_Priority = PriorityClass.Normal;

                    sendingPacket_Current.NoDelay = false;
                    
                    switch (SentDataType_Current)
                    {
                        case SentDataType.FileObject:
                            sendingPacket_Current.priorityClass_Priority = PriorityClass.Low;                            
                            break;

                        case SentDataType.RTDVFrame:
                            sendingPacket_Current.priorityClass_Priority = PriorityClass.Normal;
                            break;

                        case SentDataType.AudioPacket:
                            {
                                sendingPacket_Current.NoDelay = true;
                                sendingPacket_Current.priorityClass_Priority = PriorityClass.High;                        
                            }
                            break;
                    }

                    sendingPacket_Current.SentDataType_Current = SentDataType_Current;

                    AddDataPacketToQueue(sendingPacket_Current);

                }
                catch (Exception e)
                {

                }
            }


            #endregion

            public NetworkSecurity.UserAccount userAccount_AssignedValue = new NetworkSecurity.UserAccount();

            #region KeepAlive functional ( SendCheckInfoToClients, CheckClientsConnetions)

            static int int_CountOfCheckClientsConnetions = 0;

            static void SendCheckInfoToClients()
            {
                LocalAction localAction_obj = new LocalAction();

                for (int int_CycleCount = 0; SessionStatisticAndInfo.AllJurikSoftClients.Count != int_CycleCount; int_CycleCount++)
                {
                    try
                    {
                        localAction_obj.CurrentlyUsedTcpClient = SessionStatisticAndInfo.AllJurikSoftClients[int_CycleCount];

                        localAction_obj.SendConnectionCheck();

                        if (SessionStatisticAndInfo.AllJurikSoftClients[int_CycleCount].MarkForDisconnect == true)
                        {
                            ObjCopy.obj_NetworkAction.DisconnectNecessaryClient(SessionStatisticAndInfo.AllJurikSoftClients[int_CycleCount], 4);
                        }

                    }

                    catch (Exception exception_obj)
                    {
                        ObjCopy.obj_NetworkAction.DisconnectNecessaryClient(SessionStatisticAndInfo.AllJurikSoftClients[int_CycleCount], 4);

                        if (SessionStatisticAndInfo.AllJurikSoftClients.Count == 0) break;

                        int_CycleCount = -1;
                    }
                }
            }
            public static void CheckClientsConnetions()
            {
                if (int_CountOfCheckClientsConnetions > 0) return;
                int_CountOfCheckClientsConnetions++;

                try
                {
                    if (SessionStatisticAndInfo.AllJurikSoftClients.Count == 0) return;

                    SendCheckInfoToClients();

                    ObjCopy.obj_NetworkAction.IsCSPServerObjConnected();

                    Thread.Sleep(10000);

                    int_CountOfCheckClientsConnetions--;
                    CheckClientsConnetions();
                }
                catch
                {
                }
                finally
                {
                    int_CountOfCheckClientsConnetions--;
                }
            }

            #endregion

            #region Client's Properties

            bool bool_IsRTDVThreadEnabled = false;
            public bool IsRTDVThreadEnabled
            {
                get
                {
                    return bool_IsRTDVThreadEnabled;
                }

                set
                {
                    bool_IsRTDVThreadEnabled = value;
                }
            }

            bool bool_NeedToStopRTDV = false;
            public bool NeedToStopRTDV
            {
                get
                {
                    return bool_NeedToStopRTDV;
                }

                set
                {
                    bool_NeedToStopRTDV = value;
                }
            }

            int int_RTDVQueries = 0;
            public int RTDVQueries
            {
                get
                {
                    return int_RTDVQueries;
                }

                set
                {
                    int_RTDVQueries = value;
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

            bool bool_MarkForDisconnect = false;
            public bool MarkForDisconnect
            {
                get
                {
                    return bool_MarkForDisconnect;
                }

                set
                {
                    bool_MarkForDisconnect = value;
                }
            }

            int int_EncrypSendingSystemDataAlgorithm = 0;
            public int EncrypSendingSystemDataAlgorithm
            {
                set
                {
                    int_EncrypSendingSystemDataAlgorithm = value;
                }

                get
                {
                    return this.int_EncrypSendingSystemDataAlgorithm;
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

            #endregion

            #region Crypto SubSystem

            #region Members

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

            MemoryStream memoryStream_EncryptedDataToSend = new MemoryStream();

            MemoryStream memoryStream_DecryptedData = new MemoryStream();

            #endregion

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

            public void ReInitAndSendCryptoKeys()
            {
                this.tripleDES128bit_Session = new TripleDESCryptoServiceProvider();
                this.tripleDES128bit_Session.KeySize = 128;
                this.tripleDES128bit_Session.GenerateIV();
                this.tripleDES128bit_Session.GenerateKey();

                this.tripleDES192bit_Session = new TripleDESCryptoServiceProvider();
                this.tripleDES192bit_Session.KeySize = 192;
                this.tripleDES192bit_Session.GenerateIV();
                this.tripleDES192bit_Session.GenerateKey();

                this.DES64bit_Session = new DESCryptoServiceProvider();
                this.DES64bit_Session.KeySize = 64;
                this.DES64bit_Session.GenerateIV();
                this.DES64bit_Session.GenerateKey();

                this.RCtwo40bit_Session = new RC2CryptoServiceProvider();
                this.RCtwo40bit_Session.KeySize = 40;
                this.RCtwo40bit_Session.GenerateIV();
                this.RCtwo40bit_Session.GenerateKey();

                this.RCtwo128bit_Session = new RC2CryptoServiceProvider();
                this.RCtwo128bit_Session.KeySize = 128;
                this.RCtwo128bit_Session.GenerateIV();
                this.RCtwo128bit_Session.GenerateKey();

                this.AES128bit_Session = new RijndaelManaged();
                this.AES128bit_Session.KeySize = 128;
                this.AES128bit_Session.GenerateIV();
                this.AES128bit_Session.GenerateKey();

                this.AES256bit_Session = new RijndaelManaged();
                this.AES256bit_Session.KeySize = 256;
                this.AES256bit_Session.GenerateIV();
                this.AES256bit_Session.GenerateKey();

                InitEncryptors();
                InitDecryptors();

                /////////////////////////////////////////////////////////////////

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

                this.EncrypSendingSystemDataAlgorithm = 8;
                this.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

                memoryStream_DataToSend.Close();
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

            #endregion
        }


        public class NetworkAction : MarshalByRefObject
        {

            public NetworkAction()
            {
            }


            [DllImport("JsRctServerLib.dll")]
            private static extern string ResolveMACAddressFromIP(string string_IPAddress);
            public string RemotingWrapper_ResolveMACAddressFromIP(string string_IPAddress)
            {
                try
                {
                    return NetworkAction.ResolveMACAddressFromIP(string_IPAddress);
                }
                catch
                {
                    return "";
                }
            }

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
            public int RemotingWrapper_InstanceCount
            {
                get
                {
                    return NetworkAction.InstanceCount;
                }

                set
                {
                    NetworkAction.InstanceCount = value;
                }
            }


            public void DisconnectNecessaryClient(JurikSoftTcpClient tcpClient_InternalClient, int int_AccountChangeIndex)
            {
                if (JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.IndexOf(tcpClient_InternalClient) == -1 || tcpClient_InternalClient.RequestToDisconnect == true)
                {
                    return;
                }



                JurikSoftServerLog.InsertDataToLog(ServerStringFactory.GetString(44, ServerSettingsEnvironment.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage),
                                                           ServerStringFactory.GetString(68, ServerSettingsEnvironment.CurrentLanguage) + tcpClient_InternalClient.SessionStatisticAndInfo_Obj.NetworkInformation_UserName);


                if (tcpClient_InternalClient.RequestToDisconnect == true) return;

                tcpClient_InternalClient.RequestToDisconnect = true;

                LocalAction localAction_obj = new LocalAction();

                localAction_obj.CurrentlyUsedTcpClient = tcpClient_InternalClient;

                localAction_obj.DeleteAllDownloadingTasksOfClient();
                localAction_obj.DeleteAllUploadingTasksOfClient();

                localAction_obj.ToSendChangesOfAccountState(int_AccountChangeIndex);

                tcpClient_InternalClient.NeedToStopRTDV = true;

                for (int int_CycleCount = 0; int_CycleCount != NetworkSecurity.UserAccount.UsersAccounts.Count; int_CycleCount++)
                {
                    if (NetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].ClientsUsingAccount.Contains(tcpClient_InternalClient) == true)
                    {
                        NetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].ClientsUsingAccount.Remove(tcpClient_InternalClient);
                    }
                }

                int int_ClientIndex = JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.IndexOf(tcpClient_InternalClient);

                if (int_ClientIndex > -1)
                {
                    //ObjCopy.obj_MainServerForm.RemoveActiveConnectionFromListView(int_ClientIndex);
                    //GUIEvents.ActiveConnectionsCountChanged(this, new EventArgs());

                    NetworkStatusAndStatistics.Statistic_ActiveConnections--;
                }

                JurikSoftTcpClient.SessionStatisticAndInfo.AllSessionStatisticAndInfoOjects.Remove(tcpClient_InternalClient.SessionStatisticAndInfo_Obj);

                JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Remove(tcpClient_InternalClient);

                tcpClient_InternalClient.Close();
            }

            public void DisconnectNecessaryClient(int int_ClientNumber, int int_AccountChangeIndex)
            {
                JurikSoftTcpClient tcpClient_InternalClient = JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients[int_ClientNumber];

                if (JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Count == 0 || JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.IndexOf(tcpClient_InternalClient) == -1)
                {
                    return;
                }

                if (tcpClient_InternalClient.RequestToDisconnect == true) return;

                DisconnectNecessaryClient(tcpClient_InternalClient, int_AccountChangeIndex);
            }
   
            public void DisconnectAllClients()
            {
                if (JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Count == 0) return;

                for (; JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Count != 0; )
                {
                    try
                    {
                        ObjCopy.obj_NetworkAction.DisconnectNecessaryClient(JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients[0], 2);
                    }

                    catch (Exception)
                    {
                        JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Clear();

                        return;
                    }
                }

                JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Clear();
            }

            
            public void DataReceivingCycle(object socket_AcceptedSocket)
            {
                JurikSoftTcpClient tcpClient_InternalClient = new JurikSoftTcpClient();

                try
                {
                    JurikSoft.Compression.CommonEnvironment commonEnvironment_obj = new JurikSoft.Compression.CommonEnvironment();

                    ConmpressionEnvironment.DeflateCompressionWrapper deflateCompressionWrapper_obj = new ConmpressionEnvironment.DeflateCompressionWrapper();

                    tcpClient_InternalClient.Socket = (Socket)socket_AcceptedSocket;

                    byte[] byteArray_SystemData = new byte[6], byteArray_ReceivedData = null;

                    int int_ReceivedDataLength = 0, int_TotalReceived = 0,
                        int_TotalAvailable = 0, int_DataEncryptionAlgorithm = 0,
                        int_DataCompressionAlgorithm = 0;

                    MemoryStream memoryStream_ReceivedData = new MemoryStream(),
                                 memoryStream_DecryptedData = new MemoryStream();

                    LocalAction localAction_obj = null;

                    tcpClient_InternalClient.SessionStatisticAndInfo_Obj = new JurikSoftTcpClient.SessionStatisticAndInfo();
                    tcpClient_InternalClient.SessionStatisticAndInfo_Obj.JurikSoftTcpClient_Owner = tcpClient_InternalClient;

                    JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Add(tcpClient_InternalClient);

                    new Thread(new ThreadStart(JurikSoftTcpClient.CheckClientsConnetions)).Start();

                    while (tcpClient_InternalClient.Socket.Connected && tcpClient_InternalClient.MarkForDisconnect == false)
                    {
                        if (tcpClient_InternalClient.Available > 6)
                        {
                            #region Data Receive Process

                            memoryStream_ReceivedData.SetLength(0);

                            tcpClient_InternalClient.Socket.Receive(byteArray_SystemData);

                            int_ReceivedDataLength = BitConverter.ToInt32(byteArray_SystemData, 0);

                            int_DataCompressionAlgorithm = byteArray_SystemData[4];
                            int_DataEncryptionAlgorithm = byteArray_SystemData[5];

                            int_TotalReceived = 0;
                            int_TotalAvailable = 0;

                            while (int_TotalReceived != int_ReceivedDataLength)
                            {
                                if (tcpClient_InternalClient.RequestToDisconnect) return;

                                int_TotalAvailable = tcpClient_InternalClient.Socket.Available;

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

                                    int_TotalReceived += tcpClient_InternalClient.Socket.Receive(byteArray_ReceivedData);

                                    memoryStream_ReceivedData.Write(byteArray_ReceivedData, 0, byteArray_ReceivedData.Length);
                                }
                            }

                            if (byteArray_ReceivedData == null)
                            {
                                Thread.Sleep(100);

                                continue;
                            }

                            #endregion

                            NetworkStatusAndStatistics.Statistic_BytesReceived += int_TotalReceived;
                            tcpClient_InternalClient.SessionStatisticAndInfo_Obj.Statistic_BytesReceived += int_TotalReceived;

                            localAction_obj = new LocalAction();
                            localAction_obj.CurrentlyUsedTcpClient = tcpClient_InternalClient;

                            #region If Authorized
                          
                            if (tcpClient_InternalClient.IsAuthorized)
                            {
                                if (!tcpClient_InternalClient.IsAccountEnabled)
                                {
                                    if (tcpClient_InternalClient.RequestToDisconnect || tcpClient_InternalClient.MarkForDisconnect) return;

                                    Thread.Sleep(500);

                                    continue;
                                }

                                if (int_DataEncryptionAlgorithm > 0) //Is Data Encrypted
                                {
                                    memoryStream_ReceivedData.Position = 0;

                                    memoryStream_DecryptedData.SetLength(0);
                                    memoryStream_DecryptedData = new MemoryStream(tcpClient_InternalClient.DecryptData(memoryStream_ReceivedData, int_DataEncryptionAlgorithm));

                                    localAction_obj.RecivedData = new byte[memoryStream_DecryptedData.ToArray().Length];

                                    memoryStream_DecryptedData.Position = 0;
                                    memoryStream_DecryptedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);
                                }
                                else  //Is Clear Data
                                {
                                    localAction_obj.RecivedData = new byte[memoryStream_ReceivedData.ToArray().Length];

                                    memoryStream_ReceivedData.Position = 0;
                                    memoryStream_ReceivedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);
                                }

                                if (int_DataCompressionAlgorithm != 0) //Is Data Compresses
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

                            if (!tcpClient_InternalClient.IsAuthorized && !tcpClient_InternalClient.IsAccountEnabled)
                            {
                                NetworkSecurity.RefreshWindowsAccountsDB();

                                localAction_obj.CurrentlyUsedTcpClient = tcpClient_InternalClient;

                                #region If Access Impossible

                                IPAddress iPAddress_ClientIP = IPAddress.Parse(tcpClient_InternalClient.SessionStatisticAndInfo_Obj.ClientIPAddress);

                                string string_MACAddress = ""; //! ResolveMACAddressFromIP(tcpClient_InternalClient.SessionStatisticAndInfo_Obj.ClientIPAddress);

                                if (NetworkSecurity.CheckAccessPossible(iPAddress_ClientIP, string_MACAddress) == false || NetworkSecurity.UserAccount.UsersAccounts.Count == 0)
                                {
                                    localAction_obj.SendAuthorizationStatus(0);

                                    tcpClient_InternalClient.MarkForDisconnect = true;

                                    memoryStream_ReceivedData.Close();

                                    return;
                                }

                                if (ServerSettingsEnvironment.MaxConnections > 0 && ServerSettingsEnvironment.MaxConnections == JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Count)
                                {
                                    localAction_obj.SendAuthorizationStatus(2);

                                    tcpClient_InternalClient.MarkForDisconnect = true;

                                    memoryStream_ReceivedData.Close();

                                    return;
                                }

                                #endregion

                                #region  Send RSA public key

                                if (BitConverter.ToInt32(memoryStream_ReceivedData.ToArray(), 0) == -37)
                                {
                                    tcpClient_InternalClient.SetAndSendRSAPublicKey();
                                }

                                #endregion

                                #region Check Authorization New RSA Method

                                if (BitConverter.ToInt32(memoryStream_ReceivedData.ToArray(), 0) == -33)
                                {
                                    memoryStream_ReceivedData.Position = 4;

                                    NetworkSecurity.RSADecryptAndSetPrimaryAESKeyInfo(memoryStream_ReceivedData, tcpClient_InternalClient.XMLStringWithPrivateRSAKeys, tcpClient_InternalClient);

                                    tcpClient_InternalClient.ReInitAndSendCryptoKeys();
                                }

                                if (BitConverter.ToInt32(memoryStream_ReceivedData.ToArray(), 0) == -35)
                                {
                                    memoryStream_ReceivedData.Position = 4;

                                    string string_Login = String.Empty, string_Password = String.Empty;

                                    MemoryStream memoryStream_EncryptedLoginPasswordPair = new MemoryStream(CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData));

                                    NetworkSecurity.DecryptLoginPasswordPair(tcpClient_InternalClient.DecryptData(memoryStream_EncryptedLoginPasswordPair, 8), out string_Login, out string_Password);

                                    /////////////////////////////////////////// 

                                    bool bool_IsAuthUser = NetworkSecurity.AuthorizeConnectedUser(ref tcpClient_InternalClient, out tcpClient_InternalClient.userAccount_AssignedValue, string_Login, string_Password);
                                    {
                                        if (bool_IsAuthUser == false)
                                        {
                                            localAction_obj.SendAuthorizationStatus(0);
                                        }

                                        if (tcpClient_InternalClient.userAccount_AssignedValue == null)
                                        {
                                            DisconnectNecessaryClient(tcpClient_InternalClient, 4); //!!! 4 for temp

                                            memoryStream_ReceivedData.Close();

                                            return;
                                        }

                                        if (ServerSettingsEnvironment.MaxConnectionsPerAccount > 0 && ServerSettingsEnvironment.MaxConnectionsPerAccount == tcpClient_InternalClient.userAccount_AssignedValue.ClientsUsingAccount.Count - 1)
                                        {
                                            localAction_obj.SendAuthorizationStatus(3);
                                        }
                                    }

                                    if (bool_IsAuthUser == false || ServerSettingsEnvironment.MaxConnectionsPerAccount > 0 && ServerSettingsEnvironment.MaxConnectionsPerAccount == tcpClient_InternalClient.userAccount_AssignedValue.ClientsUsingAccount.Count - 1)
                                    {
                                        tcpClient_InternalClient.userAccount_AssignedValue.ClientsUsingAccount.Remove(tcpClient_InternalClient);

                                        DisconnectNecessaryClient(tcpClient_InternalClient, 4);//!!! 4 for temp

                                        memoryStream_ReceivedData.Close();

                                        return;
                                    }

                                    /////////////////////////////////////////// Login Successs

                                    tcpClient_InternalClient.InitCompressionEnvironment();

                                    tcpClient_InternalClient.SessionStatisticAndInfo_Obj.NetworkInformation_UserName = string_Login;

                                    localAction_obj.SendAuthorizationStatus(1);

                                    #region Log And Statistic Calls

                                    JurikSoftServerLog.InsertDataToLog(ServerStringFactory.GetString(44, ServerSettingsEnvironment.CurrentLanguage), DateTime.Now.ToShortDateString(),
                                                                       DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage),
                                                                       ServerStringFactory.GetString(54, ServerSettingsEnvironment.CurrentLanguage) + string_Login);

                                    tcpClient_InternalClient.SessionStatisticAndInfo_Obj.Statistic_ConnectedTime = DateTime.Now;

                                    NetworkStatusAndStatistics.Statistic_LastConnectionAt = DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToLongTimeString();

                                    NetworkStatusAndStatistics.Statistic_ActiveConnections++;

                                    #endregion

                                    JurikSoftTcpClient.SessionStatisticAndInfo.AllSessionStatisticAndInfoOjects.Add(tcpClient_InternalClient.SessionStatisticAndInfo_Obj);
                                    /////
                                    tcpClient_InternalClient.IsAuthorized = true;

                                    if (tcpClient_InternalClient.IsAccountEnabled == false)
                                    {
                                        localAction_obj.ToSendChangesOfAccountState(0);
                                    }
                                }


                                #endregion
                            }

                            #endregion                            
                        }

                        Thread.Sleep(5);
                    }

                    Thread.Sleep(1000);

                    ObjCopy.obj_NetworkAction.DisconnectNecessaryClient(tcpClient_InternalClient, 5);
                }

                catch (Exception exception_obj)
                {
                    ObjCopy.obj_NetworkAction.DisconnectNecessaryClient(tcpClient_InternalClient, 5);

                    //    ProcWindowService.MessageBoxPendingPool.AddMessageTaskToQueue("Server DataReceiveCycle exception: " + exception_obj.Message + " : " + exception_obj.StackTrace + "\n" + exception_obj.Source, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }


            #region CSP Support

            #region events

            public CSP.CommonNetworkEvents.DisconnectionReason disconnectionReason_LastResult;

            void ServerDisconnectionEventProcessing(CSP.ConnectedServer connectedServer_obj, CSP.CommonNetworkEvents.DisconnectionReason disconnectionReason_Result)//!! нет процессинга дисконнекта
            {
                CSP.CommonNetworkEvents.ServerDiconnectionInfoEvent -= ServerDisconnectionEventProcessing;
                                
                this.disconnectionReason_LastResult = disconnectionReason_Result;
            }

            #endregion

            static CSP.ConnectedServer connectedCSPServer_obj = null;
            static bool bool_IsPublishServerCallWorking = false;

            string string_LastPublishServerParam_ServiceIPAddress = string.Empty, string_LastPublishServerParam_Password = string.Empty;

            int int_LastPublishServerParam_ServicePort = 5545;

            ulong ulong_LastPublishServerParam_LoginUIN = 0;

            bool bool_LastPublishServerParam_HideIP = true, bool_LastPublishServerParam_PublicServer = false,
                 bool_LastPublishServerParam_KeepConnectionAlive = true, bool_LastPublishServerParam_UseCommonCSPServer = false;

            void OnNewClientConnected(CSP.ConnectedServer.AppliedServerChannel appliedServerChannel_obj)
            {
                new Thread(new ParameterizedThreadStart(DataReceivingCycle)).Start(appliedServerChannel_obj.Client);
            }

            public bool IsCSPServerObjConnected()
            {
                if (connectedCSPServer_obj != null && connectedCSPServer_obj.SystemChannel != null && connectedCSPServer_obj.SystemChannel.IsConnected == true)
                {
                    try
                    {
                        connectedCSPServer_obj.CheckConnection();
                    }
                    catch
                    {
                        try
                        {
                            foreach (CSP.ConnectedServer.AppliedServerChannel appliedServerChannel_obj in connectedCSPServer_obj.AppliedServerChannels)
                            {
                                appliedServerChannel_obj.Disconnect();

                                appliedServerChannel_obj.IsConnected = false;

                                appliedServerChannel_obj.Socket.Close();
                            }

                            connectedCSPServer_obj.SystemChannel.Socket.Close();

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

            public bool IsPublishServerCallWorking()
            {
                return bool_IsPublishServerCallWorking;
            }

            static Thread thread_KeepConnectionAlive = null, thread_PublishServer = null;

            public void CSP_PublishServerWrapper(bool bool_UseCommonCSPServer, string string_ServiceIPAddress, int int_ServicePort, ulong ulong_LoginUIN, string string_Password, bool bool_HideIP, bool bool_PublicServer, bool bool_KeepConnectionAlive)
            {
                if (IsPublishServerCallWorking() == true)
                {
                    return;
                }

                if (Monitor.TryEnter(this, 500) == true)
                {
                    try
                    {
                        bool_LastPublishServerParam_UseCommonCSPServer = bool_UseCommonCSPServer;
                        string_LastPublishServerParam_ServiceIPAddress = string_ServiceIPAddress;
                        string_LastPublishServerParam_Password = string_Password;
                        int_LastPublishServerParam_ServicePort = int_ServicePort;
                        ulong_LastPublishServerParam_LoginUIN = ulong_LoginUIN;
                        bool_LastPublishServerParam_HideIP = bool_HideIP;
                        bool_LastPublishServerParam_PublicServer = bool_PublicServer;
                        bool_LastPublishServerParam_KeepConnectionAlive = bool_KeepConnectionAlive;

                        if (thread_KeepConnectionAlive != null)
                        {
                            thread_KeepConnectionAlive.Abort();
                        }

                        if (thread_PublishServer != null)
                        {
                            thread_PublishServer.Abort();
                        }

                        thread_PublishServer = new Thread(new ThreadStart(CSP_PublishServer));
                        thread_PublishServer.Start();
                    }

                    catch
                    {
                        this.DisconnectFromCSP();
                    }
                }
            }

            void CSP_PublishServer()
            {
                if (IsPublishServerCallWorking() == true)
                {
                    return;
                }
                else
                {
                    bool_IsPublishServerCallWorking = true;
                }

                //if (Monitor.TryEnter(this, 500) == true)
                try
                {
                    CSP.CommonNetworkEvents.NewAppliedServerChannelConnectedEvent -= OnNewClientConnected;

                    string string_ServiceIPAddress = string_LastPublishServerParam_ServiceIPAddress;
                    string string_Password = string_LastPublishServerParam_Password;

                    int int_ServicePort = int_LastPublishServerParam_ServicePort;

                    ulong ulong_LoginUIN = ulong_LastPublishServerParam_LoginUIN;

                    bool bool_HideIP = bool_LastPublishServerParam_HideIP;
                    bool bool_PublicServer = bool_LastPublishServerParam_PublicServer;
                    bool bool_KeepConnectionAlive = bool_LastPublishServerParam_KeepConnectionAlive;

                    if (bool_LastPublishServerParam_UseCommonCSPServer == true)
                    {
                        string_ServiceIPAddress = CSP.ConnectingServiceProvider.GetCommonCSPIPString();

                        System.Net.IPAddress iPAddress_ParsedCSIP;

                        if (System.Net.IPAddress.TryParse(string_ServiceIPAddress, out iPAddress_ParsedCSIP) == false)
                        {
                            return;
                        }
                    }

                    if (IsCSPServerObjConnected() == true)
                    {
                        this.DisconnectFromCSP();
                    }


                    CSP.CommonNetworkEvents.ServerDiconnectionInfoEvent += ServerDisconnectionEventProcessing;

                    CSP.ConnectingServiceProvider connectingServiceProvider_obj = new CSP.ConnectingServiceProvider();

                    connectedCSPServer_obj = connectingServiceProvider_obj.ConnectServerToJSConnectingService(string_ServiceIPAddress, 5545, ulong_LoginUIN, string_Password);

                    bool_IsPublishServerCallWorking = false;

                    if (this.IsCSPServerObjConnected() == true && bool_HideIP == false)
                    {
                        connectedCSPServer_obj.UnHideServerIP();
                    }

                    CSP.CommonNetworkEvents.NewAppliedServerChannelConnectedEvent += OnNewClientConnected;

                    if (bool_LastPublishServerParam_KeepConnectionAlive == true)
                    {
                        Thread.Sleep(15000);

                        thread_KeepConnectionAlive = new Thread(new ThreadStart(KeepCSPConnectionAlive));
                        thread_KeepConnectionAlive.Start();
                    }
                }
                catch
                {
                    return;
                }
                finally
                {
                    bool_IsPublishServerCallWorking = false;
                }
            }

            void KeepCSPConnectionAlive()
            {
                try
                {
                    if (bool_LastPublishServerParam_KeepConnectionAlive == false)
                    {
                        return;
                    }

                    if (IsCSPServerObjConnected() == false && bool_LastPublishServerParam_KeepConnectionAlive == true)
                    {
                        Thread.Sleep(5000);

                        if (thread_PublishServer != null)
                        {
                            thread_PublishServer.Abort();
                        }

                        thread_PublishServer = new Thread(new ThreadStart(CSP_PublishServer));
                        thread_PublishServer.Start();

                        return;
                    }

                    Thread.Sleep(2000);

                    KeepCSPConnectionAlive();

                    return;
                }
                catch
                {
                    Thread.Sleep(2000);

                    KeepCSPConnectionAlive();

                    return;

                    bool_LastPublishServerParam_KeepConnectionAlive = false;
                }
            }

            public void StopKeepingCSPConnectionAlive()
            {
                try
                {
                    bool_LastPublishServerParam_KeepConnectionAlive = false;

                    if (thread_KeepConnectionAlive != null)
                    {
                        thread_KeepConnectionAlive.Abort();
                    }

                    if (thread_PublishServer != null)
                    {
                        thread_PublishServer.Abort();
                    }
                }
                catch
                {

                }
            }

            public void DisconnectFromCSP()
            {
                StopKeepingCSPConnectionAlive();

                if (connectedCSPServer_obj != null)
                {
                    connectedCSPServer_obj.Disconnect();
                }

                connectedCSPServer_obj = null;

                bool_IsPublishServerCallWorking = false;
            }

            #endregion

            void StartServer()
            {
                try
                {
                    if (InstanceCount == 0)
                    {
                        tcpListener_MainListener = new TcpListener(IPAddress.Any, ServerSettingsEnvironment.ServerPort);
                    }
                    else
                    {
                        ProcWindowService.MessageBoxPendingPool.AddMessageTaskToQueue(ServerStringFactory.GetString(55, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }

                    if (NetworkSecurity.UserAccount.UsersAccounts.Count == 0)
                    {
                        ProcWindowService.MessageBoxPendingPool.AddMessageTaskToQueue(ServerStringFactory.GetString(69, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    tcpListener_MainListener.Start();

                    InstanceCount++;


                    NetworkStatusAndStatistics.ServerStatus = ServerStringFactory.GetString(56, ServerSettingsEnvironment.CurrentLanguage);

                    JurikSoftServerLog.InsertDataToLog(ServerStringFactory.GetString(44, ServerSettingsEnvironment.CurrentLanguage), DateTime.Now.ToShortDateString(),
                    DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(57, ServerSettingsEnvironment.CurrentLanguage));

                    NetworkStatusAndStatistics.Statistic_BytesSent = 0;
                    NetworkStatusAndStatistics.Statistic_BytesReceived = 0;
                    NetworkStatusAndStatistics.Statistic_ActiveConnections = 0;


                    while (InstanceCount == 1)
                    {
                        if (tcpListener_MainListener.Pending() == true)
                        {
                            NetworkSecurity.RefreshWindowsAccountsDB();

                            new Thread(new ParameterizedThreadStart(DataReceivingCycle)).Start(tcpListener_MainListener.AcceptSocket());

                            Thread.Sleep(1000);
                        }

                        Thread.Sleep(500);
                    }
                }

                catch (Exception exception)
                {
                    ProcWindowService.MessageBoxPendingPool.AddMessageTaskToQueue(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            public void StartServer(int int_ListeningPort)
            {
                try
                {
                    ServerSettingsEnvironment.ServerPort = int_ListeningPort;

                    new Thread(new ThreadStart(ObjCopy.obj_NetworkAction.StartServer)).Start();
                }

                catch (Exception exception_obj)
                {

                }
            }

            public void StopServer()
            {
                DisconnectFromCSP();

                if (InstanceCount > 0)
                {
                    InstanceCount--;

                    tcpListener_MainListener.Stop();

                    NetworkStatusAndStatistics.ServerStatus = ServerStringFactory.GetString(7, ServerSettingsEnvironment.CurrentLanguage);

                    JurikSoftServerLog.InsertDataToLog(ServerStringFactory.GetString(44, ServerSettingsEnvironment.CurrentLanguage), DateTime.Now.ToShortDateString(),
                    DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, ServerSettingsEnvironment.CurrentLanguage), ServerStringFactory.GetString(59, ServerSettingsEnvironment.CurrentLanguage));

                    JurikSoftTcpClient jurikSoftTcpClient_CurrentObj = null;

                    for (int int_CycleCount = 0; JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Count != 0; )
                    {
                        try
                        {
                            int_CycleCount = JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Count - 1;

                            jurikSoftTcpClient_CurrentObj = JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients[int_CycleCount];

                            ObjCopy.obj_NetworkAction.DisconnectNecessaryClient(jurikSoftTcpClient_CurrentObj, 4);
                        }

                        catch
                        {
                            JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Clear();

                            return;
                        }
                    }

                    JurikSoftTcpClient.SessionStatisticAndInfo.AllJurikSoftClients.Clear();

                    NetworkStatusAndStatistics.Statistic_ActiveConnections = 0;
                }
            }
        }
    }
}