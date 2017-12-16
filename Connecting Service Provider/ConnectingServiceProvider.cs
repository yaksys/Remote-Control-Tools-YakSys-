using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using YakSys.Compression;
using System.Runtime.InteropServices;
using YakSys.XMLConfigImporter.YakSysRctServer.Version110;

#region common methods and enumerations

namespace CSP
{
    class CommonMethods
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

        public static void WriteUInt64ToStream(MemoryStream obj_MemoryStream, UInt64 uint_IntForWrite)
        {
            obj_MemoryStream.Write(BitConverter.GetBytes(uint_IntForWrite), 0, 8);
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

        public bool WaitForOperationCompletingEx(ref BaseChannelObject baseChanelObject_obj, ref bool bool_Value, int int_MaxSleepValue)
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

                if (int_SleepCounter > int_MaxSleepValue || baseChanelObject_obj.IsConnected == false)
                {
                    return bool_Value;
                }
            }

            return bool_Value;
        }
    }


    public enum SentDataType
    {
        SystemData, ApplicationData, FileObject, ScreenShot, RTDVFrame
    }

    public enum CryptoAlgorithm
    {
        TripleDES_128bit, TripleDES_192bit, DES_64bit, RCtwo_40bit, RCtwo_128bit, AES_256bit, AES_128bit, None
    }

    public enum ChannelOwnerType
    {
        Client, Server
    }

    public enum ConnectingObjectType
    {
        Client, Server
    }

    public enum ConnectingChannelObjectType
    {
        SystemChannel, AppliedChannel
    }


    #endregion

    public class CSNetworkStatusAndStatistics : MarshalByRefObject
    {
        static long long_BytesReceived = 0,
                    long_BytesSent = 0,
                    long_ActiveConnections = 0;

        internal static long Statistic_BytesSent
        {
            set
            {
                long_BytesSent = value;
            }

            get
            {

                return long_BytesSent;

            }
        }
        internal static long Statistic_BytesReceived
        {
            set
            {
                long_BytesReceived = value;
            }

            get
            {
                return long_BytesReceived;
            }
        }
        internal static long Statistic_ActiveConnections
        {
            set
            {
                long_ActiveConnections = value;
            }

            get
            {
                return long_ActiveConnections;
            }
        }

        static string string_LastConnectionAt = string.Empty;
        internal static string Statistic_LastConnectionAt
        {
            get
            {
                return string_LastConnectionAt;
            }

            set
            {
                string_LastConnectionAt = value;
            }
        }

        static string string_ServerStatus = string.Empty;
        public static string ServerStatus
        {
            set
            {
                string_ServerStatus = value;
            }
            get
            {
                return string_ServerStatus;
            }
        }

        public long RemotingWrapper_Statistic_BytesSent
        {
            get
            {
                return CSNetworkStatusAndStatistics.Statistic_BytesSent;
            }
        }
        public long RemotingWrapper_Statistic_BytesReceived
        {
            get
            {
                return CSNetworkStatusAndStatistics.Statistic_BytesReceived;
            }
        }
        public long RemotingWrapper_Statistic_ActiveConnections
        {
            get
            {
                return CSNetworkStatusAndStatistics.Statistic_ActiveConnections;
            }
        }

        public string RemotingWrapper_Statistic_LastConnectionAt
        {
            get
            {
                return CSNetworkStatusAndStatistics.Statistic_LastConnectionAt;
            }
        }
        public string RemotingWrapper_ServerStatus
        {
            set
            {
                CSNetworkStatusAndStatistics.ServerStatus = value;
            }

            get
            {
                return CSNetworkStatusAndStatistics.ServerStatus;
            }
        }
    }

    public class CommonNetworkEvents
    {
        public enum DisconnectionReason
        {
            /*
             * 0 is a Auth failure or Access impossible
             * 1 is a Disconnect by Admin
             * 2 is a Reason of max connection limit exhausted
             * 3 is a MaxConnectionsPerAccount limit exhausted
             * 4 is a RemoveAccount or ClearAccounts events
             * 5 is a DisconnectAllClients event
             * 6 is a Disconnect when process succesfully completed (as an UIN Registration or Activation)
             * 7 is a Connection closed by Client\Server user request
             * 8 is a Connection was lost by SendCheckInfoToClients()
             * 9 is a Exception thrown in ReceiveCycle method
             * 10 is a requested Server not connected now
             */

            AuthFailure, DisconnectByAdmin, MaxConnectionLimit, MaxConnectionsPerAccountLimit, AccountRemoved, DisconnectAllClientsByAdmin,
            ConnectionClosedByOperaionCompleted, ConnectionClosedByUserRequest, ConnectionLost, ExceptionThrownInReceivedCycle, RequestedServerNotConnected
        }

        public enum AuthReasults
        {
            AuthSuccess, AccountTemporaryDisabled, AccountEnabled
        }

        #region Disconnect Events

        public delegate void ClientDisconnectedEventHandler(ConnectedClient ÒonnectedClient_obj);
        public static ClientDisconnectedEventHandler ClientDisconnectedEvent;

        public delegate void ServerDisconnectedEventHandler(ConnectedServer ÒonnectedServer_obj);
        public static ServerDisconnectedEventHandler ServerDisconnectedEvent;

        public static void CallServerDisconnectedEvent(ConnectedServer connectedServer_obj)
        {
            if (ServerDisconnectedEvent != null)
            {
                ServerDisconnectedEvent(connectedServer_obj);
            }
        }

        public static void CallClientDisconnectedEvent(ConnectedClient ÒonnectedClient_obj)
        {
            if (ClientDisconnectedEvent != null)
            {
                ClientDisconnectedEvent(ÒonnectedClient_obj);
            }
        }

        #endregion

        #region Auth Failure Events

        public delegate void ClientDiconnectionInfoEventHandler(ConnectedClient ÒonnectedClient_obj, DisconnectionReason disconnectionReason_Result);
        public static ClientDiconnectionInfoEventHandler ClientDiconnectionInfoEvent;

        public delegate void ServerDiconnectionInfoEventHandler(ConnectedServer ÒonnectedServer_obj, DisconnectionReason disconnectionReason_Result);
        public static ServerDiconnectionInfoEventHandler ServerDiconnectionInfoEvent;

        public static void CallServerDiconnectionInfoEvent(ConnectedServer connectedServer_obj, DisconnectionReason disconnectionReason_obj)
        {
            if (ClientDiconnectionInfoEvent != null)
            {
                ServerDiconnectionInfoEvent(connectedServer_obj, disconnectionReason_obj);
            }
        }

        public static void CallClientDiconnectionInfoEvent(ConnectedClient ÒonnectedClient_obj, DisconnectionReason disconnectionReason_obj)
        {
            if (ClientDiconnectionInfoEvent != null)
            {
                ClientDiconnectionInfoEvent(ÒonnectedClient_obj, disconnectionReason_obj);
            }
        }

        #endregion

        #region Connected Events

        public delegate void ClientSuccessfullyConnectedEventHandler(ConnectedClient ÒonnectedClient_obj);
        public static ClientSuccessfullyConnectedEventHandler ClientSuccessfullyConnectedEvent;

        public delegate void ServerSuccessfullyConnectedEventHandler(ConnectedServer ÒonnectedServer_obj);
        public static ServerSuccessfullyConnectedEventHandler ServerSuccessfullyConnectedEvent;

        public static void CallServerSuccessfullyConnectedEvent(ConnectedServer connectedServer_obj)
        {
            if (ServerSuccessfullyConnectedEvent != null)
            {
                ServerSuccessfullyConnectedEvent(connectedServer_obj);
            }
        }

        public static void CallClientSuccessfullyConnectedEvent(ConnectedClient ÒonnectedClient_obj)
        {
            if (ClientSuccessfullyConnectedEvent != null)
            {
                ClientSuccessfullyConnectedEvent(ÒonnectedClient_obj);
            }
        }

        #endregion

        #region Account Disabled or Enabled state chaned Events

        public delegate void ClientAccountStateChangedEventHandler(ConnectedClient ÒonnectedClient_obj, AuthReasults authReasults_Result);
        public static ClientAccountStateChangedEventHandler ClientAccountStateChangedEventEvent;

        public delegate void ServerAccountStateChangedEventHandler(ConnectedServer ÒonnectedServer_obj, AuthReasults authReasults_Result);
        public static ServerAccountStateChangedEventHandler ServerAccountStateChangedEvent;


        public static void CallClientAccountStateChangedEventEvent(ConnectedClient ÒonnectedClient_obj, AuthReasults authResult_obj)
        {
            if (ClientAccountStateChangedEventEvent != null)
            {
                ClientAccountStateChangedEventEvent(ÒonnectedClient_obj, authResult_obj);
            }
        }

        public static void CallServerAccountStateChangedEventEvent(ConnectedServer ÒonnectedServer_obj, AuthReasults authResult_obj)
        {
            if (ServerAccountStateChangedEvent != null)
            {
                ServerAccountStateChangedEvent(ÒonnectedServer_obj, authResult_obj);
            }
        }


        #endregion

        #region Authorized Events

        public delegate void ClientSuccessfullyAuthorizedEventHandler(ConnectedClient ÒonnectedClient_obj, AuthReasults authReasults_Result);
        public static ClientSuccessfullyAuthorizedEventHandler ClientSuccessfullyAuthorizedEvent;

        public delegate void ServerSuccessfullyAuthorizedEventHandler(ConnectedServer ÒonnectedServer_obj, AuthReasults authReasults_Result);
        public static ServerSuccessfullyAuthorizedEventHandler ServerSuccessfullyAuthorizedEvent;

        public static void CallServerSuccessfullyAuthorizedEvent(ConnectedServer connectedServer_obj, AuthReasults authResult_obj)
        {
            if (ServerSuccessfullyAuthorizedEvent != null)
            {
                ServerSuccessfullyAuthorizedEvent(connectedServer_obj, authResult_obj);
            }
        }

        public static void CallClientSuccessfullyAuthorizedEvent(ConnectedClient ÒonnectedClient_obj, AuthReasults authResult_obj)
        {
            if (ClientSuccessfullyAuthorizedEvent != null)
            {
                ClientSuccessfullyAuthorizedEvent(ÒonnectedClient_obj, authResult_obj);
            }
        }

        #endregion

        #region Network events

        public delegate void NewAppliedServerChannelConnectedEventHandler(ConnectedServer.AppliedServerChannel appliedServerChannel_obj);
        public static event NewAppliedServerChannelConnectedEventHandler NewAppliedServerChannelConnectedEvent;

        public static void CallNewAppliedServerChannelConnectedEvent(ConnectedServer.AppliedServerChannel appliedServerChannel_obj)
        {
            if (NewAppliedServerChannelConnectedEvent != null)
            {
                NewAppliedServerChannelConnectedEvent(appliedServerChannel_obj);
            }
        }

        #endregion

        #region New InterConnection events

        public delegate void ServerEnteringNewInterConnectionProcessEventHandler(ConnectedServer connectedServer_obj);
        public static event ServerEnteringNewInterConnectionProcessEventHandler ServerEnteringNewInterConnectionProcessEvent;

        public static void CallServerEnteringNewInterConnectionProcessEvent(ConnectedServer connectedServer_obj)
        {
            if (ServerEnteringNewInterConnectionProcessEvent != null)
            {
                ServerEnteringNewInterConnectionProcessEvent(connectedServer_obj);
            }
        }

        //-----------------------------------------------------------------------------------------------

        public delegate void ClientEnteringNewInterConnectionProcessEventHandler(ConnectedClient ÒonnectedClient_obj);
        public static event ClientEnteringNewInterConnectionProcessEventHandler ClientEnteringNewInterConnectionProcessEvent;

        public static void CallClientEnteringNewInterConnectiondProcessEvent(ConnectedClient ÒonnectedClient_obj)
        {
            if (ClientEnteringNewInterConnectionProcessEvent != null)
            {
                ClientEnteringNewInterConnectionProcessEvent(ÒonnectedClient_obj);
            }
        }

        #endregion

        #region InterConnection Closed Events

        public delegate void ClientInterConnectionClosedEventHandler(ConnectedClient ÒonnectedClient_obj);
        public static ClientInterConnectionClosedEventHandler ClientInterConnectionClosedEvent;

        public delegate void ServerInterConnectionClosedEventHandler(ConnectedServer ÒonnectedServer_obj);
        public static ServerInterConnectionClosedEventHandler ServerInterConnectionClosedEvent;

        public static void CallClientInterConnectionClosedEvent(ConnectedClient ÒonnectedClient_obj)
        {
            if (ClientInterConnectionClosedEvent != null)
            {
                ClientInterConnectionClosedEvent(ÒonnectedClient_obj);
            }
        }

        public static void CallServerInterConnectionClosedEvent(ConnectedServer connectedServer_obj)
        {
            if (ServerInterConnectionClosedEvent != null)
            {
                ServerInterConnectionClosedEvent(connectedServer_obj);
            }
        }

        #endregion

        #region UIN events

        public delegate void ClientUINRegisteredEventHandler(ulong ulong_RegisteredUIN);
        public static ClientUINRegisteredEventHandler ClientUINRegisteredEvent;

        public delegate void ServerUINRegisteredEventHandler(ulong ulong_RegisteredUIN);
        public static ServerUINRegisteredEventHandler ServerUINRegisteredEvent;

        public delegate void ClientUINActivatedEventHandler(ulong ulong_ActivatedUIN);
        public static ClientUINActivatedEventHandler ClientUINActivatedEvent;

        public delegate void ServerUINActivatedEventHandler(ulong ulong_ActivatedUIN);
        public static ServerUINActivatedEventHandler ServerUINActivatedEvent;

        public delegate void ClientUINDeActivatedEventHandler(ulong ulong_DeActivatedUIN);
        public static ClientUINDeActivatedEventHandler ClientUINDeActivatedEvent;

        public delegate void ServerUINDeActivatedEventHandler(ulong ulong_DeActivatedUIN);
        public static ServerUINDeActivatedEventHandler ServerUINDeActivatedEvent;

        #endregion

        #region Statistic Events

        public delegate void PublicServersListReceivedEventHandler(PublicServerInfo[] PublicServerInfo_Info);
        public static PublicServersListReceivedEventHandler OnPublicServersListReceivedEvent;

        public static void CallOnPublicServersListReceivedEvent(PublicServerInfo[] PublicServerInfo_Info)
        {
            if (OnPublicServersListReceivedEvent != null)
            {
                OnPublicServersListReceivedEvent(PublicServerInfo_Info);
            }
        }

        #endregion

        #region Crypto events

        public delegate void CryptoKeysSyncCompletingEventHandler();
        public static CryptoKeysSyncCompletingEventHandler CryptoKeysSyncCompletingEvent;

        #endregion
    }


    //!!!! ÔÓıÓ‰Û ÌÂ ‰ÓÎÊÌÓ ·˚Ú¸ static ÔÓÎÂÈ ‚ ÔÓÓ‰ÂÊÍÂ ÔÓÍÒË??
    public static class CSPProxySupport
    {
        static bool bool_UseProxy = false;
        public static bool UseProxy
        {
            get
            {
                return bool_UseProxy;
            }
            set
            {
                bool_UseProxy = value;
            }
        }

        static bool bool_UseProxyResolveHostNames = false;
        public static bool UseProxyResolveHostNames
        {
            get
            {
                return bool_UseProxyResolveHostNames;
            }
            set
            {
                bool_UseProxyResolveHostNames = value;
            }
        }

        static bool bool_NeedProxyAuthentication = false;
        public static bool NeedProxyAuthentication
        {
            get
            {
                return bool_NeedProxyAuthentication;
            }
            set
            {
                bool_NeedProxyAuthentication = value;
            }
        }

        static int int_ProxyTypeIndex = 0;
        public static int ProxyTypeIndex
        {
            get
            {
                return int_ProxyTypeIndex;
            }
            set
            {
                int_ProxyTypeIndex = value;
            }
        }

        static int int_ProxyPort = 1080;
        public static int ProxyPort
        {
            get
            {
                return int_ProxyPort;
            }
            set
            {
                int_ProxyPort = value;
            }
        }

        static int int_ProxyTimeOut = 15000;
        public static int ProxyTimeOut
        {
            get
            {
                return int_ProxyTimeOut;
            }
            set
            {
                int_ProxyTimeOut = value;
            }
        }

        static string string_ProxyHost = string.Empty;
        public static string ProxyHost
        {
            get
            {
                return string_ProxyHost;
            }
            set
            {
                string_ProxyHost = value;
            }
        }

        static string string_Socks5UserName = string.Empty;
        public static string Socks5UserName
        {
            get
            {
                return string_Socks5UserName;
            }
            set
            {
                string_Socks5UserName = value;
            }
        }

        static string string_Socks5Password = string.Empty;
        public static string Socks5Password
        {
            get
            {
                return string_Socks5Password;
            }
            set
            {
                string_Socks5Password = value;
            }
        }


        public static void ProxyProvider_SendingSocks4ConnectionRequest()
        {

        }

        public static void ProxyProvider_SendingSocks5AuthenticationRequest()
        {

        }

        public static void ProxyProvider_SendingSocks5ConnectionRequest()
        {

        }

        public static void ProxyProvider_SendingSocks5RequestDetails()
        {

        }

        public static void ProxyProvider_WaitingForReplyToSocks4ConnectionRequest()
        {

        }

        public static void ProxyProvider_WaitingForReplyToSocks5AuthenticationRequest()
        {

        }

        public static void ProxyProvider_WaitingForReplyToSocks5ConnectionRequest()
        {

        }

        public static void ProxyProvider_WaitingForReplyToSocks5RequestDetails()
        {

        }
    }


    public class BaseConnectedObject : TcpClient
    {
        public BaseConnectedObject()
        {
            rNGCryptoServiceProvider_RandomGenerator.GetBytes(byteArray_RandomAuthorizationCodeForClient);

            AllConnectedObjects.Add(this);
        }

        protected void InternalDisconnect()
        {
            try
            {
                this.ClearCryptoSubsystem();

                this.Close();

                BaseChannelObject.AllConnectedObjects.Remove(this);

                this.Dispose(true);
            }
            catch (Exception ex)
            {
            }
        }

        #region SendData To Client method and his Environvment

        ICompression iCompression_obj = null;

        MemoryStream memoryStream_DataToSend = new MemoryStream();

        byte byte_IsDataCompressed = 0, byte_IsDataEncrypted = 0;

        NetworkStream networkStream_ThisClient = null;

        public bool SendData(byte[] byteArray_SentData, SentDataType SentDataType_Current)
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

                    #region «‡ÔËÒ¸ ‚ ÔÓÚÓÍ ‡ÁÏÂ‡ ‰‡ÌÌ˚ı Ë ËÌÙÓÏ‡ˆËË Ó ¯ËÙÓ‚‡ÌËË\ÒÊ‡ÚËË

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

                    this.Statistic_BytesSent += memoryStream_DataToSend.ToArray().Length;

                    networkStream_ThisClient.Write(memoryStream_DataToSend.ToArray(), 0, (int)memoryStream_DataToSend.ToArray().Length);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region BaseConnectedObject Properties

        static List<BaseConnectedObject> list_AllConnectedObjects = new List<BaseConnectedObject>();
        internal static List<BaseConnectedObject> AllConnectedObjects
        {
            get
            {
                return list_AllConnectedObjects;
            }
        }

        public string IPAddress
        {
            get
            {
                return ((IPEndPoint)this.Client.RemoteEndPoint).Address.ToString();
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


        public void InitEncryptors()
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

        public void InitDecryptors()
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

        #endregion
    }


    public class BaseChannelObject : BaseConnectedObject
    {
        #region Disconnect functions

        public void Disconnect(int int_DisconnectReason)
        {
            try
            {
                if (RequestToDisconnect == true)
                {
                    return;
                }

                RequestToDisconnect = true;

                if (this.ChannelTypeInfo == ConnectingChannelObjectType.SystemChannel)
                {
                    if (this.IsAuthorized == true)
                    {
                        CSNetworkStatusAndStatistics.Statistic_ActiveConnections--;
                    }

                    CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();
                    cSPRemoteCallAction_obj.NecessaryBaseChannelObject = this;

                    if (ConnectingObjectTypeInfo == ConnectingObjectType.Client)
                    {
                        cSPRemoteCallAction_obj.CloseClientConnection(this.UIN); //!! ÓÚÔ‡‚ÎˇÚ¸ ‰ËÒÍÓÌÌÂÍÚ Ì‡‰Ó ÚÓÎ¸ÍÓ ÍÓ„‰‡ ‰ËÒÍÓÌÌÂÍÚ ËÌËˆËËÓ‚‡Ì CSProvider!             
                    }
                    else
                    {
                        cSPRemoteCallAction_obj.CloseServerConnection(this.UIN); //!! ÓÚÔ‡‚ÎˇÚ¸ ‰ËÒÍÓÌÌÂÍÚ Ì‡‰Ó ÚÓÎ¸ÍÓ ÍÓ„‰‡ ‰ËÒÍÓÌÌÂÍÚ ËÌËˆËËÓ‚‡Ì CSProvider
                    }
                }

                InternalDisconnect();

                if (BaseChannelObjectDisconnectedEvent != null)
                {
                    BaseChannelObjectDisconnectedEvent(this, int_DisconnectReason);
                }
            }
            catch (Exception ex)
            {
                if (RequestToDisconnect == false)
                {
                    Disconnect(100); //!100 for temp

                    return;
                }
            }
            finally
            {

            }
        }

        public delegate void BaseChannelObjectDisconnectedEventHandler(BaseChannelObject baseChannelObject_obj, int int_DisconnectReason);
        public static event BaseChannelObjectDisconnectedEventHandler BaseChannelObjectDisconnectedEvent;

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

        #endregion

        public new void Connect(string string_Host, int int_Port)
        {
            IsConnected = true;

            if (CSPProxySupport.UseProxy == false)
            {
                try
                {
                    this.CSPort = int_Port;
                    this.CSHost = string_Host;

                    base.Connect(string_Host, int_Port);

                    IsConnected = true;
                }
                catch
                {
                    Disconnect(100); //!! 10 for temp

                    IsConnected = false;
                }

                return;
            }

            #region Proxy Support

            if (CSPProxySupport.UseProxy == true)
            {
                try
                {
                    YakSys.Proxy.ProxyProvider proxyProvider_obj = new YakSys.Proxy.ProxyProvider();

                    proxyProvider_obj.SendingSocks4ConnectionRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(CSPProxySupport.ProxyProvider_SendingSocks4ConnectionRequest);
                    proxyProvider_obj.SendingSocks5AuthenticationRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(CSPProxySupport.ProxyProvider_SendingSocks5AuthenticationRequest);
                    proxyProvider_obj.SendingSocks5ConnectionRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(CSPProxySupport.ProxyProvider_SendingSocks5ConnectionRequest);
                    proxyProvider_obj.SendingSocks5RequestDetails += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(CSPProxySupport.ProxyProvider_SendingSocks5RequestDetails);

                    proxyProvider_obj.WaitingForReplyToSocks4ConnectionRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(CSPProxySupport.ProxyProvider_WaitingForReplyToSocks4ConnectionRequest);
                    proxyProvider_obj.WaitingForReplyToSocks5AuthenticationRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(CSPProxySupport.ProxyProvider_WaitingForReplyToSocks5AuthenticationRequest);
                    proxyProvider_obj.WaitingForReplyToSocks5ConnectionRequest += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(CSPProxySupport.ProxyProvider_WaitingForReplyToSocks5ConnectionRequest);
                    proxyProvider_obj.WaitingForReplyToSocks5RequestDetails += new YakSys.Proxy.ProxyProvider.BaseProxyEventHandler(CSPProxySupport.ProxyProvider_WaitingForReplyToSocks5RequestDetails);

                    if (CSPProxySupport.ProxyTypeIndex <= 0)
                    {
                        IsConnected = false;

                        return;
                    }

                    YakSys.Proxy.ProxyProvider.SerialNumber = "4688445487";
                    YakSys.Proxy.ProxyProvider.RegistrationName = "YakSys";

                    Socket socket_ConnectedObj = base.Socket;

                    if (CSPProxySupport.ProxyTypeIndex == 0)
                    {
                        proxyProvider_obj.ConnectThroughSocks4Proxy(ref socket_ConnectedObj, string_Host, int_Port, CSPProxySupport.ProxyHost, CSPProxySupport.ProxyPort, CSPProxySupport.UseProxyResolveHostNames, CSPProxySupport.ProxyTimeOut);
                    }
                    if (CSPProxySupport.ProxyTypeIndex == 1)
                    {
                        if (CSPProxySupport.NeedProxyAuthentication == false)
                        {
                            proxyProvider_obj.ConnectThroughSocks5Proxy(ref socket_ConnectedObj, string_Host, int_Port, CSPProxySupport.ProxyHost, CSPProxySupport.ProxyPort, CSPProxySupport.UseProxyResolveHostNames, CSPProxySupport.ProxyTimeOut);
                        }

                        if (CSPProxySupport.NeedProxyAuthentication)
                        {
                            proxyProvider_obj.ConnectThroughSocks5Proxy(ref socket_ConnectedObj, string_Host, int_Port, CSPProxySupport.ProxyHost, CSPProxySupport.ProxyPort, CSPProxySupport.Socks5UserName, CSPProxySupport.Socks5Password, CSPProxySupport.UseProxyResolveHostNames, CSPProxySupport.ProxyTimeOut);
                        }
                    }

                    if (CSPProxySupport.ProxyTypeIndex == 2)
                    {
                        if (CSPProxySupport.NeedProxyAuthentication == false)
                        {
                            proxyProvider_obj.ConnectThroughHTTPSProxy(ref socket_ConnectedObj, string_Host, int_Port, CSPProxySupport.ProxyHost, CSPProxySupport.ProxyPort, CSPProxySupport.UseProxyResolveHostNames, CSPProxySupport.ProxyTimeOut);
                        }

                        if (CSPProxySupport.NeedProxyAuthentication)
                        {
                            proxyProvider_obj.ConnectThroughHTTPSProxy(ref socket_ConnectedObj, string_Host, int_Port, CSPProxySupport.ProxyHost, CSPProxySupport.ProxyPort, CSPProxySupport.Socks5UserName, CSPProxySupport.Socks5Password, CSPProxySupport.UseProxyResolveHostNames, CSPProxySupport.ProxyTimeOut);
                        }
                    }
                }

                catch
                {
                    Disconnect(10); //!! 10 for temp

                    IsConnected = false;
                }
            }

            #endregion
        }

        public void DataReceivingCycle_ClientSystemChannel(object baseChannelObject_Client)
        {
            try
            {
                BaseChannelObject baseChannelObject_obj = (BaseChannelObject)baseChannelObject_Client;

                YakSys.Compression.CommonEnvironment commonEnvironment_obj = new YakSys.Compression.CommonEnvironment();

                CompressionEnvironment.DeflateCompressionWrapper deflateCompressionWrapper_obj = new CompressionEnvironment.DeflateCompressionWrapper();

                byte[] byteArray_SystemData = new byte[6], byteArray_ReceivedData = null;

                int int_ReceivedDataLength = 0, int_TotalReceived = 0, int_TotalAvailable = 0, int_ActionNumber = 0,
                    int_LastConnectionCheck = 0, int_DataEncryptAlgorithmIndex = 0, int_DataCompressionAlgorithmIndex = 0;

                MemoryStream memoryStream_ReceivedData = new MemoryStream(),
                             memoryStream_DecryptedData = new MemoryStream();

                LocalAction localAction_obj = null;

                baseChannelObject_obj.IsReceiveThreadStarted = true;

                //GetData cycle while Client is connected!
                while (baseChannelObject_obj.Socket.Connected && baseChannelObject_obj.RequestToDisconnect == false)
                {
                    if (baseChannelObject_obj.Available > 0)
                    {
                        int_LastConnectionCheck = 0;

                        memoryStream_ReceivedData.SetLength(0);
                        memoryStream_DecryptedData.SetLength(0);

                        baseChannelObject_obj.Socket.Receive(byteArray_SystemData);

                        int_ReceivedDataLength = BitConverter.ToInt32(byteArray_SystemData, 0);

                        int_DataCompressionAlgorithmIndex = byteArray_SystemData[4];
                        int_DataEncryptAlgorithmIndex = byteArray_SystemData[5];

                        int_TotalReceived = 0;
                        int_TotalAvailable = 0;

                        while (int_TotalReceived != int_ReceivedDataLength)
                        {
                            int_TotalAvailable = baseChannelObject_obj.Socket.Available;

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

                                int_TotalReceived += baseChannelObject_obj.Socket.Receive(byteArray_ReceivedData);

                                memoryStream_ReceivedData.Write(byteArray_ReceivedData, 0, byteArray_ReceivedData.Length);
                            }
                        }

                        localAction_obj = new LocalAction();
                        localAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;


                        if (int_DataEncryptAlgorithmIndex != 0)// Encrypted Data
                        {
                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_DecryptedData.SetLength(0);

                            memoryStream_DecryptedData = new MemoryStream(baseChannelObject_obj.DecryptData(memoryStream_ReceivedData, int_DataEncryptAlgorithmIndex));

                            localAction_obj.RecivedData = new byte[memoryStream_DecryptedData.ToArray().Length];

                            memoryStream_DecryptedData.Position = 0;
                            memoryStream_DecryptedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithmIndex > 0 && int_DataCompressionAlgorithmIndex < 4)
                            {
                                localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                            }
                            if (int_DataCompressionAlgorithmIndex == 4)
                            {
                                localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                            }

                            int_ActionNumber = localAction_obj.ActionNumber = BitConverter.ToInt32(localAction_obj.RecivedData, 0);
                        }

                        if (int_DataEncryptAlgorithmIndex == 0)// Clear Data
                        {
                            localAction_obj.RecivedData = new byte[memoryStream_ReceivedData.ToArray().Length];

                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_ReceivedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithmIndex > 0 && int_DataCompressionAlgorithmIndex < 4)
                            {
                                localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                            }
                            if (int_DataCompressionAlgorithmIndex == 4)
                            {
                                localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                            }

                            int_ActionNumber = localAction_obj.ActionNumber = BitConverter.ToInt32(localAction_obj.RecivedData, 0);
                        }

                        if (int_ActionNumber == -5)
                        {
                            int_LastConnectionCheck = 0;

                            continue;
                        }

                        localAction_obj.ActionAllocator();

                        memoryStream_ReceivedData.SetLength(0);

                        baseChannelObject_obj.Statistic_BytesReceived += int_ReceivedDataLength + 4;
                    }

                    Thread.Sleep(1);

                    int_LastConnectionCheck++;

                    if (int_LastConnectionCheck > 10000)
                    {
                        baseChannelObject_obj.Close();
                    }
                }
            }

            catch (Exception exception_obj)
            {         

                return;
            }

        }
        public void DataReceivingCycle_ClientAppliedChannel(object baseChannelObject_Client)
        {
            try
            {
                BaseChannelObject baseChannelObject_obj = (BaseChannelObject)baseChannelObject_Client;

                YakSys.Compression.CommonEnvironment commonEnvironment_obj = new YakSys.Compression.CommonEnvironment();

                CompressionEnvironment.DeflateCompressionWrapper deflateCompressionWrapper_obj = new CompressionEnvironment.DeflateCompressionWrapper();

                byte[] byteArray_SystemData = new byte[6], byteArray_ReceivedData = null;

                int int_ReceivedDataLength = 0, int_TotalReceived = 0, int_TotalAvailable = 0, int_ActionNumber = 0,
                    int_LastConnectionCheck = 0, int_DataEncryptAlgorithmIndex = 0, int_DataCompressionAlgorithmIndex = 0;

                MemoryStream memoryStream_ReceivedData = new MemoryStream(),
                             memoryStream_DecryptedData = new MemoryStream();

                LocalAction localAction_obj = null;

                baseChannelObject_obj.IsReceiveThreadStarted = true;

                //GetData cycle while Client is connected!
                while (baseChannelObject_obj.Socket.Connected && baseChannelObject_obj.RequestToDisconnect == false)
                {
                    if (baseChannelObject_obj.IsAuthorized == true) //Exit after applied channel has been created
                    {
                        CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

                        cSPRemoteCallAction_obj.NecessaryBaseChannelObject = connectedClient_obj.SystemChannel;

                        cSPRemoteCallAction_obj.SendKeepConnectionAliveParams(baseChannelObject_obj.ClientOwner.KeepConnectionAlive);

                        cSPRemoteCallAction_obj.SentRequestedServerInfo(ulong_InterConnectedUIN, baseChannelObject_obj.ClientOwner.WaitForServer);

                        return; // Must exit for using this connected applied chennel by master application!!! return after applied channel auth process completed!!!
                    }

                    if (baseChannelObject_obj.Available > 0)
                    {
                        int_LastConnectionCheck = 0;

                        memoryStream_ReceivedData.SetLength(0);
                        memoryStream_DecryptedData.SetLength(0);

                        baseChannelObject_obj.Socket.Receive(byteArray_SystemData);

                        int_ReceivedDataLength = BitConverter.ToInt32(byteArray_SystemData, 0);

                        int_DataCompressionAlgorithmIndex = byteArray_SystemData[4];
                        int_DataEncryptAlgorithmIndex = byteArray_SystemData[5];

                        int_TotalReceived = 0;
                        int_TotalAvailable = 0;

                        while (int_TotalReceived != int_ReceivedDataLength)
                        {
                            int_TotalAvailable = baseChannelObject_obj.Socket.Available;

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

                                int_TotalReceived += baseChannelObject_obj.Socket.Receive(byteArray_ReceivedData);

                                memoryStream_ReceivedData.Write(byteArray_ReceivedData, 0, byteArray_ReceivedData.Length);
                            }
                        }

                        localAction_obj = new LocalAction();
                        localAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;

                        if (int_DataEncryptAlgorithmIndex != 0)// Encrypted Data
                        {
                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_DecryptedData.SetLength(0);

                            memoryStream_DecryptedData = new MemoryStream(baseChannelObject_obj.DecryptData(memoryStream_ReceivedData, int_DataEncryptAlgorithmIndex));

                            localAction_obj.RecivedData = new byte[memoryStream_DecryptedData.ToArray().Length];

                            memoryStream_DecryptedData.Position = 0;
                            memoryStream_DecryptedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithmIndex > 0 && int_DataCompressionAlgorithmIndex < 4)
                            {
                                localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                            }
                            if (int_DataCompressionAlgorithmIndex == 4)
                            {
                                localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                            }

                            int_ActionNumber = localAction_obj.ActionNumber = BitConverter.ToInt32(localAction_obj.RecivedData, 0);
                        }

                        if (int_DataEncryptAlgorithmIndex == 0)// Clear Data
                        {
                            localAction_obj.RecivedData = new byte[memoryStream_ReceivedData.ToArray().Length];

                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_ReceivedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithmIndex > 0 && int_DataCompressionAlgorithmIndex < 4)
                            {
                                localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                            }
                            if (int_DataCompressionAlgorithmIndex == 4)
                            {
                                localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                            }

                            int_ActionNumber = localAction_obj.ActionNumber = BitConverter.ToInt32(localAction_obj.RecivedData, 0);
                        }

                        if (int_ActionNumber == -5)
                        {
                            int_LastConnectionCheck = 0;

                            continue;
                        }

                        localAction_obj.ActionAllocator();

                        memoryStream_ReceivedData.SetLength(0);

                        baseChannelObject_obj.Statistic_BytesReceived += int_ReceivedDataLength + 4;
                    }

                    Thread.Sleep(5);

                    int_LastConnectionCheck++;

                    if (int_LastConnectionCheck > 10000)
                    {
                        //    ConnectionLostProcess();
                    }
                }
            }

            catch (Exception exception_obj)
            {
                //  DisconnectFromServer();

                return;
            }

        }

        public void DataReceivingCycle_ServerSystemChannel(object baseChannelObject_Server)
        {
            try
            {
                BaseChannelObject baseChannelObject_obj = (BaseChannelObject)baseChannelObject_Server;

                YakSys.Compression.CommonEnvironment commonEnvironment_obj = new YakSys.Compression.CommonEnvironment();

                CompressionEnvironment.DeflateCompressionWrapper deflateCompressionWrapper_obj = new CompressionEnvironment.DeflateCompressionWrapper();

                byte[] byteArray_SystemData = new byte[6], byteArray_ReceivedData = null;

                int int_ReceivedDataLength = 0, int_TotalReceived = 0, int_TotalAvailable = 0, int_ActionNumber = 0,
                    int_LastConnectionCheck = 0, int_DataEncryptAlgorithmIndex = 0, int_DataCompressionAlgorithmIndex = 0;

                MemoryStream memoryStream_ReceivedData = new MemoryStream(),
                             memoryStream_DecryptedData = new MemoryStream();

                LocalAction localAction_obj = null;

                baseChannelObject_obj.IsReceiveThreadStarted = true;

                //GetData cycle while Client is connected!
                while (baseChannelObject_obj.Socket.Connected && baseChannelObject_obj.RequestToDisconnect == false)
                {
                    if (baseChannelObject_obj.Available > 0)
                    {
                        int_LastConnectionCheck = 0;

                        memoryStream_ReceivedData.SetLength(0);
                        memoryStream_DecryptedData.SetLength(0);

                        baseChannelObject_obj.Socket.Receive(byteArray_SystemData);

                        int_ReceivedDataLength = BitConverter.ToInt32(byteArray_SystemData, 0);

                        int_DataCompressionAlgorithmIndex = byteArray_SystemData[4];
                        int_DataEncryptAlgorithmIndex = byteArray_SystemData[5];

                        int_TotalReceived = 0;
                        int_TotalAvailable = 0;

                        while (int_TotalReceived != int_ReceivedDataLength)
                        {
                            int_TotalAvailable = baseChannelObject_obj.Socket.Available;

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

                                int_TotalReceived += baseChannelObject_obj.Socket.Receive(byteArray_ReceivedData);

                                memoryStream_ReceivedData.Write(byteArray_ReceivedData, 0, byteArray_ReceivedData.Length);
                            }
                        }

                        localAction_obj = new LocalAction();
                        localAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;

                        if (int_DataEncryptAlgorithmIndex != 0)// Encrypted Data
                        {
                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_DecryptedData.SetLength(0);

                            memoryStream_DecryptedData = new MemoryStream(baseChannelObject_obj.DecryptData(memoryStream_ReceivedData, int_DataEncryptAlgorithmIndex));

                            localAction_obj.RecivedData = new byte[memoryStream_DecryptedData.ToArray().Length];

                            memoryStream_DecryptedData.Position = 0;
                            memoryStream_DecryptedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithmIndex > 0 && int_DataCompressionAlgorithmIndex < 4)
                            {
                                localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                            }
                            if (int_DataCompressionAlgorithmIndex == 4)
                            {
                                localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                            }

                            int_ActionNumber = localAction_obj.ActionNumber = BitConverter.ToInt32(localAction_obj.RecivedData, 0);
                        }

                        if (int_DataEncryptAlgorithmIndex == 0)// Clear Data
                        {
                            localAction_obj.RecivedData = new byte[memoryStream_ReceivedData.ToArray().Length];

                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_ReceivedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithmIndex > 0 && int_DataCompressionAlgorithmIndex < 4)
                            {
                                localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                            }
                            if (int_DataCompressionAlgorithmIndex == 4)
                            {
                                localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                            }

                            int_ActionNumber = localAction_obj.ActionNumber = BitConverter.ToInt32(localAction_obj.RecivedData, 0);
                        }

                        if (int_ActionNumber == -5)
                        {
                            int_LastConnectionCheck = 0;

                            continue;
                        }

                        localAction_obj.ActionAllocator();

                        memoryStream_ReceivedData.SetLength(0);

                        baseChannelObject_obj.Statistic_BytesReceived += int_ReceivedDataLength + 4;
                    }

                    Thread.Sleep(5);

                    int_LastConnectionCheck++;

                    if (int_LastConnectionCheck > 10000)
                    {
                        //    ConnectionLostProcess();
                    }
                }
            }

            catch (Exception exception_obj)
            {
                //  DisconnectFromServer();

                return;
            }

        }
        public void DataReceivingCycle_ServerAppliedChannel(object baseChannelObject_Server)
        {
            try
            {
                BaseChannelObject baseChannelObject_obj = (BaseChannelObject)baseChannelObject_Server;

                YakSys.Compression.CommonEnvironment commonEnvironment_obj = new YakSys.Compression.CommonEnvironment();

                CompressionEnvironment.DeflateCompressionWrapper deflateCompressionWrapper_obj = new CompressionEnvironment.DeflateCompressionWrapper();

                byte[] byteArray_SystemData = new byte[6], byteArray_ReceivedData = null;

                int int_ReceivedDataLength = 0, int_TotalReceived = 0, int_TotalAvailable = 0, int_ActionNumber = 0,
                    int_LastConnectionCheck = 0, int_DataEncryptAlgorithmIndex = 0, int_DataCompressionAlgorithmIndex = 0;

                MemoryStream memoryStream_ReceivedData = new MemoryStream(),
                             memoryStream_DecryptedData = new MemoryStream();

                LocalAction localAction_obj = null;

                baseChannelObject_obj.IsReceiveThreadStarted = true;

                //GetData cycle while Client is connected!
                while (baseChannelObject_obj.Socket.Connected == true && baseChannelObject_obj.RequestToDisconnect == false)
                {
                    if (baseChannelObject_obj.IsAuthorized == true)
                    {
                        return; // Must exit for using this connected applied chennel by master application!!! return after applied channel auth process completed!!!
                    }

                    if (baseChannelObject_obj.Available > 0)
                    {
                        int_LastConnectionCheck = 0;

                        memoryStream_ReceivedData.SetLength(0);
                        memoryStream_DecryptedData.SetLength(0);

                        baseChannelObject_obj.Socket.Receive(byteArray_SystemData);

                        int_ReceivedDataLength = BitConverter.ToInt32(byteArray_SystemData, 0);

                        int_DataCompressionAlgorithmIndex = byteArray_SystemData[4];
                        int_DataEncryptAlgorithmIndex = byteArray_SystemData[5];

                        int_TotalReceived = 0;
                        int_TotalAvailable = 0;

                        while (int_TotalReceived != int_ReceivedDataLength)
                        {
                            int_TotalAvailable = baseChannelObject_obj.Socket.Available;

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

                                int_TotalReceived += baseChannelObject_obj.Socket.Receive(byteArray_ReceivedData);

                                memoryStream_ReceivedData.Write(byteArray_ReceivedData, 0, byteArray_ReceivedData.Length);
                            }
                        }

                        localAction_obj = new LocalAction();
                        localAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;

                        if (int_DataEncryptAlgorithmIndex != 0)// Encrypted Data
                        {
                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_DecryptedData.SetLength(0);

                            memoryStream_DecryptedData = new MemoryStream(baseChannelObject_obj.DecryptData(memoryStream_ReceivedData, int_DataEncryptAlgorithmIndex));

                            localAction_obj.RecivedData = new byte[memoryStream_DecryptedData.ToArray().Length];

                            memoryStream_DecryptedData.Position = 0;
                            memoryStream_DecryptedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithmIndex > 0 && int_DataCompressionAlgorithmIndex < 4)
                            {
                                localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                            }
                            if (int_DataCompressionAlgorithmIndex == 4)
                            {
                                localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                            }

                            int_ActionNumber = localAction_obj.ActionNumber = BitConverter.ToInt32(localAction_obj.RecivedData, 0);
                        }

                        if (int_DataEncryptAlgorithmIndex == 0)// Clear Data
                        {
                            localAction_obj.RecivedData = new byte[memoryStream_ReceivedData.ToArray().Length];

                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_ReceivedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithmIndex > 0 && int_DataCompressionAlgorithmIndex < 4)
                            {
                                localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                            }
                            if (int_DataCompressionAlgorithmIndex == 4)
                            {
                                localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                            }

                            int_ActionNumber = localAction_obj.ActionNumber = BitConverter.ToInt32(localAction_obj.RecivedData, 0);
                        }

                        if (int_ActionNumber == -5)
                        {
                            int_LastConnectionCheck = 0;

                            continue;
                        }

                        localAction_obj.ActionAllocator();

                        memoryStream_ReceivedData.SetLength(0);

                        baseChannelObject_obj.Statistic_BytesReceived += int_ReceivedDataLength + 4;
                    }

                    Thread.Sleep(5);

                    int_LastConnectionCheck++;

                    if (int_LastConnectionCheck > 10000)
                    {
                        //    ConnectionLostProcess();
                    }
                }
            }

            catch (Exception exception_obj)
            {
                //  DisconnectFromServer();

                return;
            }
        }


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

        ConnectingChannelObjectType channelTypeInfo_obj;
        public ConnectingChannelObjectType ChannelTypeInfo
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


        #region Local Members and Connection status monitors

        protected static int int_InstanceCount = 0;
        public static int InstanceCount
        {
            get
            {
                return int_InstanceCount;
            }
        }

        protected static bool bool_IsConnected = false;
        public bool IsConnected
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

        public bool bool_IsReceiveThreadStarted = false;
        public bool IsReceiveThreadStarted
        {
            set
            {
                lock (this)
                {
                    bool_IsReceiveThreadStarted = value;
                }
            }

            get
            {
                lock (this)
                {
                    return bool_IsReceiveThreadStarted;
                }
            }
        }

        #endregion

        #region ConnectedObjects Owners

        ConnectedClient connectedClient_obj;
        public ConnectedClient ClientOwner
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

        ConnectedServer connectedServer_obj;
        public ConnectedServer ServerOwner
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

        public ChannelOwnerType OwnerType
        {
            get
            {
                if (ServerOwner != null)
                {
                    return ChannelOwnerType.Server;
                }
                else
                {
                    return ChannelOwnerType.Client;
                }
            }
        }

        #endregion

        public ulong ulong_ChannelUID = 0;
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

        int int_CSPort = 5545;
        public int CSPort
        {
            get
            {
                return int_CSPort;
            }

            set
            {
                int_CSPort = value;
            }
        }

        string string_CSHost = string.Empty;
        public string CSHost
        {
            get
            {
                return string_CSHost;
            }

            set
            {
                string_CSHost = value;
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

        string string_AccountType = string.Empty;
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

        string string_UserName = string.Empty;
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

        public bool bool_IsAuthorized = false;
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

        public bool bool_AuthorizationComplete = false;
        public bool AuthorizationComplete
        {
            get
            {
                return bool_AuthorizationComplete;
            }

            set
            {
                bool_AuthorizationComplete = value;
            }

        }

        public bool bool_CryptoSubSystemInitComplete = false;
        public bool CryptoSubSystemInitComplete
        {
            get
            {
                return bool_CryptoSubSystemInitComplete;
            }

            set
            {
                bool_CryptoSubSystemInitComplete = value;
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
    }

    public class ConnectedClient
    {
        public void ChangeCryptoAlgorithm(CryptoAlgorithm cryptoAlgorithm_enum)//!!!!
        {
            switch (cryptoAlgorithm_enum)
            {
                case CryptoAlgorithm.AES_128bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 1;
                    }
                    break;

                case CryptoAlgorithm.AES_256bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 2;
                    }
                    break;

                case CryptoAlgorithm.DES_64bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 3;
                    }
                    break;

                case CryptoAlgorithm.RCtwo_128bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 4;
                    }
                    break;

                case CryptoAlgorithm.RCtwo_40bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 5;
                    }
                    break;

                case CryptoAlgorithm.TripleDES_128bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 6;
                    }
                    break;

                case CryptoAlgorithm.TripleDES_192bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 7;
                    }
                    break;

                case CryptoAlgorithm.None:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 0;
                    }
                    break;
            }
        }

        public void GetPublicServersList()
        {
            if (this.SystemChannel.AuthorizationComplete == true && this.SystemChannel.Connected == true)
            {
                CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

                cSPRemoteCallAction_obj.NecessaryBaseChannelObject = this.SystemChannel;

                cSPRemoteCallAction_obj.GetPublicServersList();
            }
        }

        public ConnectedClient(ulong ulong_UIN)
        {
            CommonNetworkEvents.ClientDisconnectedEvent += OnDisconnect;

            this.UIN = ulong_UIN;

            ConnectedClient.AllConnectedClients.Add(this);
        }

        public void UnHideClientIP()
        {
            if (this.SystemChannel.AuthorizationComplete == true && this.SystemChannel.Connected == true)
            {
                CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

                cSPRemoteCallAction_obj.NecessaryBaseChannelObject = this.SystemChannel;

                cSPRemoteCallAction_obj.UnHideClientIP();
            }
        }

        public void OnDisconnect(ConnectedClient ÒonnectedClient_obj)
        {
            if (ÒonnectedClient_obj == this)
            {
                Disconnect();
            }
        }

        public void Disconnect()
        {
            try
            {
                if (this.SystemChannel != null)
                {
                    this.SystemChannel.IsConnected = false;

                    this.SystemChannel.Disconnect(100); //100 for temp
                }

                if (this.AppliedChannel != null)
                {
                    this.AppliedChannel.Disconnect(100); //100 for temp
                }
            }
            catch
            {

            }
            finally
            {
                ConnectedClient.AllConnectedClients.Remove(this);
                AllSystemClientChannels.Remove(this.SystemChannel);
                AllAppliedClientChannels.Remove(this.AppliedChannel);
            }
        }

        public void CheckConnection()
        {
            CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

            cSPRemoteCallAction_obj.NecessaryBaseChannelObject = this.SystemChannel;

            cSPRemoteCallAction_obj.SendConnectionCheck();
        }

        #region Properties

        static List<ConnectedClient> list_AllConnectedClients = new List<ConnectedClient>();
        public static List<ConnectedClient> AllConnectedClients
        {
            get
            {
                return list_AllConnectedClients;
            }
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

        bool bool_KeepConnectionAlive = false;
        public bool KeepConnectionAlive
        {
            get
            {
                return bool_KeepConnectionAlive;
            }
            set
            {
                bool_KeepConnectionAlive = value;
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

        int int_DisconnectionReason = 0;
        public int DisconnectionReason
        {
            get
            {
                return int_DisconnectionReason;
            }
            set
            {
                int_DisconnectionReason = value;
            }
        }

        #endregion

        #region channels

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

        AppliedClientChannel appliedClientChannel_obj = null;
        public AppliedClientChannel AppliedChannel
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

        public class AppliedClientChannel : BaseChannelObject
        {
            public AppliedClientChannel()
            {
                AllAppliedClientChannels.Add(this);
            }
        }

        public class SystemClientChannel : BaseChannelObject
        {
            public SystemClientChannel()
            {
                this.IsConnected = false;

                AllSystemClientChannels.Add(this);
            }
        }

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
    }

    public class PublicServerInfo
    {
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

        string string_IPAddress = string.Empty;
        public string IPAddress
        {
            get
            {
                return string_IPAddress;
            }

            set
            {
                string_IPAddress = value;
            }
        }

        string string_ConnectedTime = string.Empty;
        public string ConnectedTime
        {
            get
            {
                return string_ConnectedTime;
            }

            set
            {
                string_ConnectedTime = value;
            }
        }
    }

    public class ConnectedServer
    {
        public void ChangeCryptoAlgorithm(CryptoAlgorithm cryptoAlgorithm_enum)//!!!!
        {
            switch (cryptoAlgorithm_enum)
            {
                case CryptoAlgorithm.AES_128bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 1;
                    }
                    break;

                case CryptoAlgorithm.AES_256bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 2;
                    }
                    break;

                case CryptoAlgorithm.DES_64bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 3;
                    }
                    break;

                case CryptoAlgorithm.RCtwo_128bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 4;
                    }
                    break;

                case CryptoAlgorithm.RCtwo_40bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 5;
                    }
                    break;

                case CryptoAlgorithm.TripleDES_128bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 6;
                    }
                    break;

                case CryptoAlgorithm.TripleDES_192bit:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 7;
                    }
                    break;

                case CryptoAlgorithm.None:
                    {
                        this.SystemChannel.EncryptSendingSystemDataAlgorithm = 0;
                    }
                    break;
            }
        }

        public void GetPublicServersList()
        {
            if (this.SystemChannel.AuthorizationComplete == true && this.SystemChannel.Connected == true)
            {
                CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

                cSPRemoteCallAction_obj.NecessaryBaseChannelObject = this.SystemChannel;

                cSPRemoteCallAction_obj.GetPublicServersList();
            }
        }

        public void UnHideServerIP()
        {
            if (this.SystemChannel.AuthorizationComplete == true && this.SystemChannel.Connected == true)
            {
                CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

                cSPRemoteCallAction_obj.NecessaryBaseChannelObject = this.SystemChannel;

                cSPRemoteCallAction_obj.UnHideServerIP();
            }
        }

        public ConnectedServer(ulong ulong_UIN)
        {
            CommonNetworkEvents.ServerDisconnectedEvent += OnDisconnect;

            this.UIN = ulong_UIN;

            ConnectedServer.AllConnectedServers.Add(this);
        }

        public void OnDisconnect(ConnectedServer ÒonnectedServer_obj)
        {
            if (ÒonnectedServer_obj == this)
            {
                Disconnect();
            }
        }

        public void Disconnect()
        {
            try
            {

                if (this.SystemChannel != null)
                {
                    this.SystemChannel.Disconnect(100); //100 for temp

                    this.SystemChannel.IsConnected = false;
                }

                foreach (AppliedServerChannel appliedServerChannel_obj in AllAppliedServerChannels)
                {
                    if (appliedServerChannel_obj != null)
                    {
                        appliedServerChannel_obj.Disconnect();
                    }
                }
            }
            catch
            {

            }
            finally
            {
                AllSystemServerChannels.Remove(this.SystemChannel); //‚ÓÁÏÓÊÌÓ ·Û‰ÂÚ Û‰‡ÎˇÚÒˇ ÍÓ„‰‡ ÛÊÂ ÌÛÎÎ!!!!!!

                ConnectedServer.AllConnectedServers.Remove(this);

                AllAppliedServerChannels.Clear();
            }
        }

        public void CheckConnection()
        {
            CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

            cSPRemoteCallAction_obj.NecessaryBaseChannelObject = this.SystemChannel;

            cSPRemoteCallAction_obj.SendConnectionCheck();
        }

        #region Properties

        int int_DisconnectionReason = 0;
        public int DisconnectionReason
        {
            get
            {
                return int_DisconnectionReason;
            }
            set
            {
                int_DisconnectionReason = value;
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

        static List<ConnectedServer> list_AllConnectedServers = new List<ConnectedServer>();
        public static List<ConnectedServer> AllConnectedServers
        {
            get
            {
                return list_AllConnectedServers;
            }
        }

        #endregion

        #region channels

        List<AppliedServerChannel> list_AppliedServerChannels = new List<ConnectedServer.AppliedServerChannel>();
        public List<AppliedServerChannel> AppliedServerChannels
        {
            get
            {
                return list_AppliedServerChannels;
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

        public class AppliedServerChannel : BaseChannelObject
        {
            public AppliedServerChannel()
            {
                AllAppliedServerChannels.Add(this);
            }

            public new void Disconnect()
            {
                CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

                cSPRemoteCallAction_obj.NecessaryBaseChannelObject = this;

                cSPRemoteCallAction_obj.CloseServerAppliedChannelConnection(this.UIN, this.ChannelUID);

                base.Disconnect(100); //100 for temp
            }
        }

        public class SystemServerChannel : BaseChannelObject
        {
            public SystemServerChannel()
            {
                AllSystemServerChannels.Add(this);
            }
        }

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

        #endregion
    }

    /*//!!!
     * 
     * ‰ËÒÍÓÌÌÂÍÚ
     *
     * ÒÓ·˚ÚËˇ
     * ÔËÒÚ‚‡Ë‚‡Ú¸ uid ‚ÒÂÏ Í‡Ì‡Î‡Ï, Í‡Í ÒËÒÚÂÏÌ˚Ï Ú‡Í Ë ÔËÍÎ‡‰Ì˚Ï , ÍÎËÂÌÚ‡ Ë ÒÂ‚Â
     * 
     * ÔÓÍÒË
     * ÏÓ‰ËÙËÍ‡ÚÓ˚ ‰ÓÒÚÛÔ‡
     */


    public class ConnectingServiceProvider : object
    {
        int int_GlobalTimeOutMS = 0;
        protected void ConnectionTimeOutWatcher(object tcpClient_LinkToCloseByTimeOut)
        {
            if (int_GlobalTimeOutMS <= 0 || (TcpClient)tcpClient_LinkToCloseByTimeOut == null) return;

            int int_InternalTimeOutCount = 0;

            while (int_InternalTimeOutCount <= int_GlobalTimeOutMS)
            {
                Thread.Sleep(10);

                int_InternalTimeOutCount += 10;
            }

            if ((TcpClient)tcpClient_LinkToCloseByTimeOut != null)
            {
                ((TcpClient)tcpClient_LinkToCloseByTimeOut).Close();
            }
        }

        //---------------------------------------------------------------------------------------------------- Common Auth and Local Action process Thread

        public void DataReceivingCycle_CommonAuthThread(object baseChannelObject_Client)
        {
            try
            {
                BaseChannelObject baseChannelObject_obj = (BaseChannelObject)baseChannelObject_Client;

                YakSys.Compression.CommonEnvironment commonEnvironment_obj = new YakSys.Compression.CommonEnvironment();

                CompressionEnvironment.DeflateCompressionWrapper deflateCompressionWrapper_obj = new CompressionEnvironment.DeflateCompressionWrapper();

                byte[] byteArray_SystemData = new byte[6], byteArray_ReceivedData = null;

                int int_ReceivedDataLength = 0, int_TotalReceived = 0, int_TotalAvailable = 0, int_ActionNumber = 0,
                    int_LastConnectionCheck = 0, int_DataEncryptAlgorithmIndex = 0, int_DataCompressionAlgorithmIndex = 0;

                MemoryStream memoryStream_ReceivedData = new MemoryStream(),
                             memoryStream_DecryptedData = new MemoryStream();

                LocalAction localAction_obj = null;

                baseChannelObject_obj.IsReceiveThreadStarted = true;

                //GetData cycle while Client is connected!
                while (baseChannelObject_obj.Socket.Connected && baseChannelObject_obj.RequestToDisconnect == false)
                {
                    if (baseChannelObject_obj.IsAuthorized == true)
                    {
                        return; // Must exit for using this connected applied chennel by master application!!! return after applied channel auth process completed!!!
                    }

                    if (baseChannelObject_obj.Available > 0)
                    {
                        int_LastConnectionCheck = 0;

                        memoryStream_ReceivedData.SetLength(0);
                        memoryStream_DecryptedData.SetLength(0);

                        baseChannelObject_obj.Socket.Receive(byteArray_SystemData);

                        int_ReceivedDataLength = BitConverter.ToInt32(byteArray_SystemData, 0);

                        int_DataCompressionAlgorithmIndex = byteArray_SystemData[4];
                        int_DataEncryptAlgorithmIndex = byteArray_SystemData[5];

                        int_TotalReceived = 0;
                        int_TotalAvailable = 0;

                        while (int_TotalReceived != int_ReceivedDataLength)
                        {
                            int_TotalAvailable = baseChannelObject_obj.Socket.Available;

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

                                int_TotalReceived += baseChannelObject_obj.Socket.Receive(byteArray_ReceivedData);

                                memoryStream_ReceivedData.Write(byteArray_ReceivedData, 0, byteArray_ReceivedData.Length);
                            }
                        }

                        localAction_obj = new LocalAction();
                        localAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;

                        if (int_DataEncryptAlgorithmIndex != 0)// Encrypted Data
                        {
                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_DecryptedData.SetLength(0);

                            memoryStream_DecryptedData = new MemoryStream(baseChannelObject_obj.DecryptData(memoryStream_ReceivedData, int_DataEncryptAlgorithmIndex));

                            localAction_obj.RecivedData = new byte[memoryStream_DecryptedData.ToArray().Length];

                            memoryStream_DecryptedData.Position = 0;
                            memoryStream_DecryptedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithmIndex > 0 && int_DataCompressionAlgorithmIndex < 4)
                            {
                                localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                            }
                            if (int_DataCompressionAlgorithmIndex == 4)
                            {
                                localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                            }

                            int_ActionNumber = localAction_obj.ActionNumber = BitConverter.ToInt32(localAction_obj.RecivedData, 0);
                        }

                        if (int_DataEncryptAlgorithmIndex == 0)// Clear Data
                        {
                            localAction_obj.RecivedData = new byte[memoryStream_ReceivedData.ToArray().Length];

                            memoryStream_ReceivedData.Position = 0;
                            memoryStream_ReceivedData.Read(localAction_obj.RecivedData, 0, localAction_obj.RecivedData.Length);

                            if (int_DataCompressionAlgorithmIndex > 0 && int_DataCompressionAlgorithmIndex < 4)
                            {
                                localAction_obj.RecivedData = commonEnvironment_obj.Decompress(localAction_obj.RecivedData, false);
                            }
                            if (int_DataCompressionAlgorithmIndex == 4)
                            {
                                localAction_obj.RecivedData = deflateCompressionWrapper_obj.Decompress(localAction_obj.RecivedData);
                            }

                            int_ActionNumber = localAction_obj.ActionNumber = BitConverter.ToInt32(localAction_obj.RecivedData, 0);
                        }

                        if (int_ActionNumber == -5)
                        {
                            int_LastConnectionCheck = 0;

                            continue;
                        }

                        localAction_obj.ActionAllocator();

                        memoryStream_ReceivedData.SetLength(0);

                        baseChannelObject_obj.Statistic_BytesReceived += int_ReceivedDataLength + 4;
                    }

                    Thread.Sleep(5);

                    int_LastConnectionCheck++;

                    if (int_LastConnectionCheck > 10000)
                    {
                        baseChannelObject_obj.Disconnect(100); //100 for temp//!!

                        return;
                    }
                }
            }

            catch (Exception exception_obj)
            {
                return;
            }

        }

        //---------------------------------------------------------------------------------------------------- Register New UIN

        public bool RegisterNewClientUINRequest(string string_Host, int int_Port, string string_UserName, string string_Password, string string_FirstName, string string_SecondName, string string_LastName, string string_ICQ, string string_EMail,
           string string_Work, string string_HomePhone, string string_WorkPhone, string string_MobilePhone)
        {
            BaseChannelObject baseChannelObject_obj = new BaseChannelObject();

            baseChannelObject_obj.Connect(string_Host, int_Port);

            if (baseChannelObject_obj.IsConnected == false)
            {
                return false;
            }

            new Thread(new ParameterizedThreadStart(DataReceivingCycle_CommonAuthThread)).Start(baseChannelObject_obj);

            new CommonMethods().WaitForOperationCompleting(ref baseChannelObject_obj.bool_IsReceiveThreadStarted, 10000);

            //-----------------------------------------------------------------------------------------------------------

            CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

            cSPRemoteCallAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;

            cSPRemoteCallAction_obj.BeginRegisterNewUINProcess();

            cSPRemoteCallAction_obj.SendAuthRequestForUINregistration(CSPRemoteCallAction.ConnectingObjectType.Client);

            new CommonMethods().WaitForOperationCompleting(ref baseChannelObject_obj.bool_CryptoSubSystemInitComplete, 10000);

            if (baseChannelObject_obj.bool_CryptoSubSystemInitComplete == false)
            {
                return false;
            }

            cSPRemoteCallAction_obj.RegisterNewClientUINRequest(string_UserName, string_Password, string_FirstName, string_SecondName, string_LastName, string_ICQ,
                                                                string_EMail, string_Work, string_HomePhone, string_WorkPhone, string_MobilePhone);

            return true;
        }

        public bool RegisterNewServerUINRequest(string string_Host, int int_Port, string string_UserName, string string_Password, string string_FirstName, string string_SecondName, string string_LastName, string string_ICQ, string string_EMail,
           string string_Work, string string_HomePhone, string string_WorkPhone, string string_MobilePhone)
        {
            BaseChannelObject baseChannelObject_obj = new BaseChannelObject();

            baseChannelObject_obj.Connect(string_Host, int_Port);

            if (baseChannelObject_obj.IsConnected == false)
            {
                return false;
            }

            new Thread(new ParameterizedThreadStart(DataReceivingCycle_CommonAuthThread)).Start(baseChannelObject_obj);

            new CommonMethods().WaitForOperationCompleting(ref baseChannelObject_obj.bool_IsReceiveThreadStarted, 10000);

            //-----------------------------------------------------------------------------------------------------------

            CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

            cSPRemoteCallAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;

            cSPRemoteCallAction_obj.BeginRegisterNewUINProcess();

            cSPRemoteCallAction_obj.SendAuthRequestForUINregistration(CSPRemoteCallAction.ConnectingObjectType.Server);

            new CommonMethods().WaitForOperationCompleting(ref baseChannelObject_obj.bool_CryptoSubSystemInitComplete, 10000);

            if (baseChannelObject_obj.bool_CryptoSubSystemInitComplete == false)
            {
                return false;
            }

            cSPRemoteCallAction_obj.RegisterNewServerUINRequest(string_UserName, string_Password, string_FirstName, string_SecondName, string_LastName, string_ICQ, string_EMail,
                                                                  string_Work, string_HomePhone, string_WorkPhone, string_MobilePhone);

            return true;
        }

        //---------------------------------------------------------------------------------------------------- Activate UIN

        public ConnectedClient ActivateClientUINRequest(string string_Host, int int_Port, ulong ulong_UIN, string string_Password, ulong ulong_ActivationCode)
        {
            ConnectedClient connectedClient_obj = ConnectSystemClientChannelToYakSysConnectingService(string_Host, int_Port, ulong_UIN, string_Password);

            if (connectedClient_obj == null || connectedClient_obj.SystemChannel == null || connectedClient_obj.SystemChannel.IsConnected == false)
            {
                return null;
            }

            CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

            cSPRemoteCallAction_obj.NecessaryBaseChannelObject = connectedClient_obj.SystemChannel;

            cSPRemoteCallAction_obj.ActivateClientUINRequest(ulong_ActivationCode);

            return connectedClient_obj;
        }

        public ConnectedServer ActivateServerUINRequest(string string_Host, int int_Port, ulong ulong_UIN, string string_Password, ulong ulong_ActivationCode)
        {
            ConnectedServer connectedServer_obj = ConnectServerToYakSysConnectingService(string_Host, int_Port, ulong_UIN, string_Password);

            if (connectedServer_obj == null || connectedServer_obj.SystemChannel == null || connectedServer_obj.SystemChannel.IsConnected == false)
            {
                return null;
            }

            CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

            cSPRemoteCallAction_obj.NecessaryBaseChannelObject = connectedServer_obj.SystemChannel;

            cSPRemoteCallAction_obj.ActivateServerUINRequest(ulong_ActivationCode);

            return connectedServer_obj;
        }

        //---------------------------------------------------------------------------------------------------- Disable UIN

        public ConnectedClient DeActivateClientUINRequest(string string_Host, int int_Port, ulong ulong_UIN, string string_Password, bool bool_RequestActivationCode)
        {
            ConnectedClient connectedClient_obj = ConnectSystemClientChannelToYakSysConnectingService(string_Host, int_Port, ulong_UIN, string_Password);

            if (connectedClient_obj.SystemChannel == null || connectedClient_obj.SystemChannel.IsConnected == false)
            {
                return null;
            }

            CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

            cSPRemoteCallAction_obj.NecessaryBaseChannelObject = connectedClient_obj.SystemChannel;

            cSPRemoteCallAction_obj.DeActivateClientUINRequest(bool_RequestActivationCode);

            return connectedClient_obj;
        }

        public ConnectedServer DeActivateServerUINRequest(string string_Host, int int_Port, ulong ulong_UIN, string string_Password, bool bool_RequestActivationCode)
        {
            ConnectedServer connectedServer_obj = ConnectServerToYakSysConnectingService(string_Host, int_Port, ulong_UIN, string_Password);

            if (connectedServer_obj.SystemChannel == null || connectedServer_obj.SystemChannel.IsConnected == false)
            {
                return null;
            }

            CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

            cSPRemoteCallAction_obj.NecessaryBaseChannelObject = connectedServer_obj.SystemChannel;

            cSPRemoteCallAction_obj.DeActivateServerUINRequest(bool_RequestActivationCode);

            return connectedServer_obj;
        }

        //---------------------------------------------------------------------------------------------------- Connect Client to CSP methods

        public void ConnectClientToYakSysConnectingService(string string_Host, int int_Port, ulong ulong_UIN, ulong ulong_InterConnectedUIN, string string_Password, bool bool_WaitForServer, bool bool_KeepConnectionAlive)
        {
            try
            {
                ConnectedClient connectedClient_obj = new ConnectedClient(ulong_UIN);

                connectedClient_obj.KeepConnectionAlive = bool_KeepConnectionAlive;
                connectedClient_obj.WaitForServer = bool_WaitForServer;

                //--------------------------------------------------------------------------------------------------------------------------------------------

                connectedClient_obj.SystemChannel = new ConnectedClient.SystemClientChannel();

                connectedClient_obj.SystemChannel.InterConnectedUIN = ulong_InterConnectedUIN;

                connectedClient_obj.SystemChannel.ClientOwner = connectedClient_obj;

                connectedClient_obj.SystemChannel.ConnectingObjectTypeInfo = ConnectingObjectType.Client;

                //--------------------------------------------------------------------------------------------------------------------------------------------
                   

                connectedClient_obj.AppliedChannel = new ConnectedClient.AppliedClientChannel();

                connectedClient_obj.AppliedChannel.InterConnectedUIN = ulong_InterConnectedUIN;

                connectedClient_obj.AppliedChannel.ClientOwner = connectedClient_obj;

                connectedClient_obj.AppliedChannel.ConnectingObjectTypeInfo = ConnectingObjectType.Client;

                //--------------------------------------------------------------------------------------------------------------------------------------------


                new ConnectingServiceProvider().ConnectObjectToYakSysConnectingService(string_Host, int_Port, ulong_UIN, ulong_InterConnectedUIN, string_Password, CSPRemoteCallAction.ConnectingObjectType.Client, CSPRemoteCallAction.ConnectingChannelObjectType.SystemChannel, connectedClient_obj.SystemChannel);



                new CommonMethods().WaitForOperationCompleting(ref connectedClient_obj.AppliedChannel.ulong_ChannelUID, 0, 10000);//Û‚ÂÎË˜ÂÌÓ ‰Ó 10 ÒÂÍ

                if (connectedClient_obj.AppliedChannel.ChannelUID < 1)
                {
                    connectedClient_obj.Disconnect();

                    CommonNetworkEvents.CallClientDisconnectedEvent(connectedClient_obj);

                    return;
                }

                //--------------------------------------------------------------------------------------------------------------------------------------------

                new ConnectingServiceProvider().ConnectObjectToYakSysConnectingService(string_Host, int_Port, ulong_UIN, ulong_InterConnectedUIN, string_Password, CSPRemoteCallAction.ConnectingObjectType.Client, CSPRemoteCallAction.ConnectingChannelObjectType.AppliedChannel, connectedClient_obj.AppliedChannel);

                CommonNetworkEvents.CallClientSuccessfullyConnectedEvent(connectedClient_obj);

                return;
            }
            catch(Exception ex)
            {
               
            }
        }

        public ConnectedClient ConnectSystemClientChannelToYakSysConnectingService(string string_Host, int int_Port, ulong ulong_UIN, string string_Password)
        {
            ConnectedClient connectedClient_obj = new ConnectedClient(ulong_UIN);

            //--------------------------------------------------------------------------------------------------------------------------------------------

            connectedClient_obj.SystemChannel = new ConnectedClient.SystemClientChannel();

            connectedClient_obj.SystemChannel.ClientOwner = connectedClient_obj;

            connectedClient_obj.SystemChannel.ConnectingObjectTypeInfo = ConnectingObjectType.Client;

            //--------------------------------------------------------------------------------------------------------------------------------------------

            new ConnectingServiceProvider().ConnectObjectToYakSysConnectingService(string_Host, int_Port, ulong_UIN, 0, string_Password, CSPRemoteCallAction.ConnectingObjectType.Client, CSPRemoteCallAction.ConnectingChannelObjectType.SystemChannel, connectedClient_obj.SystemChannel);

            return connectedClient_obj;
        }

        //---------------------------------------------------------------------------------------------------- Connect Server to CSP

        public ConnectedServer ConnectServerToYakSysConnectingService(string string_Host, int int_Port, ulong ulong_UIN, string string_Password)
        {
            ConnectedServer connectedServer_obj = new ConnectedServer(ulong_UIN);

            connectedServer_obj.SystemChannel = new ConnectedServer.SystemServerChannel();

            connectedServer_obj.SystemChannel.ServerOwner = connectedServer_obj;

            connectedServer_obj.SystemChannel.ConnectingObjectTypeInfo = ConnectingObjectType.Server;

            new ConnectingServiceProvider().ConnectObjectToYakSysConnectingService(string_Host, int_Port, ulong_UIN, 0, string_Password, CSPRemoteCallAction.ConnectingObjectType.Server, CSPRemoteCallAction.ConnectingChannelObjectType.SystemChannel, connectedServer_obj.SystemChannel);

            CommonNetworkEvents.CallServerSuccessfullyConnectedEvent(connectedServer_obj);

            return connectedServer_obj;
        }

        //---------------------------------------------------------------------------------------------------- Connect common object to CSP

        public static IPAddress GetCommonCSPIP()
        {
            try
            {
                System.Net.WebClient webClient_CommonCSPIP = new WebClient();

                string string_CommonCSPIP = webClient_CommonCSPIP.DownloadString("http://yaksys.net/commoncspip.txt");

                IPAddress iPAddress_CommonCSPIP = null;

                if (IPAddress.TryParse(string_CommonCSPIP, out iPAddress_CommonCSPIP) == true)
                {
                    return iPAddress_CommonCSPIP;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static string GetCommonCSPIPString()
        {
            try
            {
                System.Net.WebClient webClient_CommonCSPIP = new WebClient();

                string string_CommonCSPIP = webClient_CommonCSPIP.DownloadString("http://yaksys.net/commoncspip.txt");

                return string_CommonCSPIP;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void ConnectObjectToYakSysConnectingService(string string_Host, int int_Port, ulong ulong_UIN, ulong ulong_InterConnectedUIN, string string_Password,
        CSPRemoteCallAction.ConnectingObjectType ConnectingObjectType_obj, CSPRemoteCallAction.ConnectingChannelObjectType connectingChannelObjectType_obj, BaseChannelObject baseChannelObject_obj)
        {
            baseChannelObject_obj.Connect(string_Host, int_Port);

            if (baseChannelObject_obj.IsConnected == false)
            {
                return;
            }

            baseChannelObject_obj.UIN = ulong_UIN;
            baseChannelObject_obj.Password = string_Password;

            ulong ulong_UID = 0;

            if (ConnectingObjectType_obj == CSPRemoteCallAction.ConnectingObjectType.Client && connectingChannelObjectType_obj == CSPRemoteCallAction.ConnectingChannelObjectType.SystemChannel)
            {
                new Thread(new ParameterizedThreadStart(baseChannelObject_obj.DataReceivingCycle_ClientSystemChannel)).Start(baseChannelObject_obj);
            }

            if (ConnectingObjectType_obj == CSPRemoteCallAction.ConnectingObjectType.Server && connectingChannelObjectType_obj == CSPRemoteCallAction.ConnectingChannelObjectType.SystemChannel)
            {
                new Thread(new ParameterizedThreadStart(baseChannelObject_obj.DataReceivingCycle_ServerSystemChannel)).Start(baseChannelObject_obj); //run  with server. create (but no closing for now) one system channel with CS 
            }

            if (ConnectingObjectType_obj == CSPRemoteCallAction.ConnectingObjectType.Client && connectingChannelObjectType_obj == CSPRemoteCallAction.ConnectingChannelObjectType.AppliedChannel)
            {
                new Thread(new ParameterizedThreadStart(baseChannelObject_obj.DataReceivingCycle_ClientAppliedChannel)).Start(baseChannelObject_obj);

                ulong_UID = baseChannelObject_obj.ChannelUID;
            }

            if (ConnectingObjectType_obj == CSPRemoteCallAction.ConnectingObjectType.Server && connectingChannelObjectType_obj == CSPRemoteCallAction.ConnectingChannelObjectType.AppliedChannel)
            {
                new Thread(new ParameterizedThreadStart(baseChannelObject_obj.DataReceivingCycle_ServerAppliedChannel)).Start(baseChannelObject_obj);
            }

            new CommonMethods().WaitForOperationCompleting(ref baseChannelObject_obj.bool_IsReceiveThreadStarted, 10000);


            CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

            cSPRemoteCallAction_obj.NecessaryBaseChannelObject = baseChannelObject_obj;

            cSPRemoteCallAction_obj.SendCommonAuthorizationRequest(ConnectingObjectType_obj, connectingChannelObjectType_obj, ulong_UIN, ulong_InterConnectedUIN, ulong_UID);


            new CommonMethods().WaitForOperationCompletingEx(ref baseChannelObject_obj, ref baseChannelObject_obj.bool_AuthorizationComplete, 10000);

        }

    }

}