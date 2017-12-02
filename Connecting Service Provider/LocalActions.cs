using System;
using System.Globalization;
using System.Threading;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ServiceProcess;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO.Compression;
using ZNIISRCT.Compression;
using System.Security.Permissions;
namespace CSP
{
    public class LocalAction
    {
        #region Class Members

        byte[] byteArray_ReceivedData;

        public byte[] RecivedData
        {
            set
            {
                byteArray_ReceivedData = value;
            }

            get
            {
                return this.byteArray_ReceivedData;
            }
        }

        int int_Action = 0;
        public int ActionNumber
        {
            get
            {
                return int_Action;
            }

            set
            {
                int_Action = value;
            }
        }

        BaseChannelObject baseChannelObject_Obj;
        public BaseChannelObject NecessaryBaseChannelObject
        {
            set
            {
                baseChannelObject_Obj = value;
            }

            get
            {
                return baseChannelObject_Obj;
            }
        }

        #endregion

        public void ActionAllocator()
        {
            try
            {
                switch (ActionNumber)
                {
                    case -34:
                        {
                            SynchronizeCryptoKeys();
                            SendCryptoLoginPasswordPair();
                        }
                        break;

                    case -35:
                        {
                            SynchronizeCryptoKeys();
                        }
                        break;

                    case 1:
                        ProcessServerAppliedChannelRequest();
                        break;

                    case 8:
                        ReceivePublicServersList();
                        break;

                    case 9:
                        ReceiveGeneratedClientAppliedChannelID();
                        break;

                    case 10:
                        InformInterConnectionClosed();
                        break;

                    case 12:
                        ProcessRegisteredClientUIN();
                        break;

                    case 13:
                        ProcessRegisteredServerUIN();
                        break;

                    case 14:
                        ProcessNewInterConnectionEvent();
                        break;

                    case 15:
                        ProcessDisconnectionStatus();
                        break;

                    case 18:
                        new Thread(new ThreadStart(ShowChangesOfAccountState)).Start();
                        break;

                    case 19:
                        ShowAuthorizationStatus();
                        break;

                    case 20:
                        ProcessClientUINActivation();
                        break;

                    case 21:
                        ProcessServerUINActivation();
                        break;

                    case 22:
                        ProcessClientUINDeActivation();
                        break;

                    case 23:
                        ProcessServerUINDeActivation();
                        break;

                    case 24:
                        SendRSAEncryptedAuthorizationData();
                        break;

                }
            }

            catch (Exception ex)
            {
            }
        }

        #region ProcessServerAppliedChannelRequest method

        public void ProcessServerAppliedChannelRequest()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_ClientUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData),
            ulong_DestinedServerUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            //-------------------------------------------------------------------------------------------------------------------

            ConnectedServer.AppliedServerChannel appliedServerChannel_obj = new ConnectedServer.AppliedServerChannel();

            appliedServerChannel_obj.ServerOwner = NecessaryBaseChannelObject.ServerOwner;

            appliedServerChannel_obj.ConnectingObjectTypeInfo = ConnectingObjectType.Server;

            appliedServerChannel_obj.ServerOwner = NecessaryBaseChannelObject.ServerOwner;

            //-------------------------------------------------------------------------------------------------------------------

            new ConnectingServiceProvider().ConnectObjectToJSConnectingService(NecessaryBaseChannelObject.ServerOwner.SystemChannel.IPAddress, NecessaryBaseChannelObject.ServerOwner.SystemChannel.CSPort, this.NecessaryBaseChannelObject.UIN, ulong_ClientUIN, this.NecessaryBaseChannelObject.Password,
                CSPRemoteCallAction.ConnectingObjectType.Server, CSPRemoteCallAction.ConnectingChannelObjectType.AppliedChannel, appliedServerChannel_obj);

            if (appliedServerChannel_obj.IsAuthorized == true)
            {
                CSPRemoteCallAction cSPRemoteCallAction_obj = new CSPRemoteCallAction();

                cSPRemoteCallAction_obj.NecessaryBaseChannelObject = NecessaryBaseChannelObject;

                cSPRemoteCallAction_obj.InitInterconnectionProcess(ulong_ClientUIN);

                cSPRemoteCallAction_obj.SendCommonAuthorizationRequest(CSPRemoteCallAction.ConnectingObjectType.Server, CSPRemoteCallAction.ConnectingChannelObjectType.AppliedChannel, ulong_ClientUIN, ulong_ClientUIN, 0);

                //----------------------------------------------------------------------------------------------

                this.NecessaryBaseChannelObject.ServerOwner.AppliedServerChannels.Add(appliedServerChannel_obj);

                CommonNetworkEvents.CallNewAppliedServerChannelConnectedEvent(appliedServerChannel_obj);
            }
            else
            {
                this.NecessaryBaseChannelObject.ServerOwner.Disconnect();

                return;
            }
        }

        #endregion

        void SynchronizeCryptoKeys()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            this.NecessaryBaseChannelObject.tripleDES128bit_Session = new TripleDESCryptoServiceProvider();
            this.NecessaryBaseChannelObject.tripleDES128bit_Session.KeySize = 128;
            this.NecessaryBaseChannelObject.tripleDES128bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
            this.NecessaryBaseChannelObject.tripleDES128bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

            this.NecessaryBaseChannelObject.tripleDES192bit_Session = new TripleDESCryptoServiceProvider();
            this.NecessaryBaseChannelObject.tripleDES192bit_Session.KeySize = 192;
            this.NecessaryBaseChannelObject.tripleDES192bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
            this.NecessaryBaseChannelObject.tripleDES192bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

            this.NecessaryBaseChannelObject.DES64bit_Session = new DESCryptoServiceProvider();
            this.NecessaryBaseChannelObject.DES64bit_Session.KeySize = 64;
            this.NecessaryBaseChannelObject.DES64bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
            this.NecessaryBaseChannelObject.DES64bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

            this.NecessaryBaseChannelObject.RCtwo40bit_Session = new RC2CryptoServiceProvider();
            this.NecessaryBaseChannelObject.RCtwo40bit_Session.KeySize = 40;
            this.NecessaryBaseChannelObject.RCtwo40bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
            this.NecessaryBaseChannelObject.RCtwo40bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

            this.NecessaryBaseChannelObject.RCtwo128bit_Session = new RC2CryptoServiceProvider();
            this.NecessaryBaseChannelObject.RCtwo128bit_Session.KeySize = 128;
            this.NecessaryBaseChannelObject.RCtwo128bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
            this.NecessaryBaseChannelObject.RCtwo128bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

            this.NecessaryBaseChannelObject.AES128bit_Session = new RijndaelManaged();
            this.NecessaryBaseChannelObject.AES128bit_Session.KeySize = 128;
            this.NecessaryBaseChannelObject.AES128bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
            this.NecessaryBaseChannelObject.AES128bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

            this.NecessaryBaseChannelObject.AES256bit_Session = new RijndaelManaged();
            this.NecessaryBaseChannelObject.AES256bit_Session.KeySize = 256;
            this.NecessaryBaseChannelObject.AES256bit_Session.Key = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);
            this.NecessaryBaseChannelObject.AES256bit_Session.IV = CommonMethods.ReadBytesFromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            //---------------------------------------------------------------------------------------------------------------------------

            this.NecessaryBaseChannelObject.InitEncryptors();
            this.NecessaryBaseChannelObject.InitDecryptors();

            this.NecessaryBaseChannelObject.EncryptSendingSystemDataAlgorithm = 2;

            //---------------------------------------------------------------------------------------------------------------------------     

            this.NecessaryBaseChannelObject.CryptoSubSystemInitComplete = true;

            if (CommonNetworkEvents.CryptoKeysSyncCompletingEvent != null)
            {
                CommonNetworkEvents.CryptoKeysSyncCompletingEvent();
            }
        }

        void SendCryptoLoginPasswordPair()
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, -35);

            MemoryStream memoryStream_AuthData = new MemoryStream();

            CommonMethods.WriteStringToStream(memoryStream_AuthData, this.NecessaryBaseChannelObject.UIN.ToString());
            CommonMethods.WriteStringToStream(memoryStream_AuthData, this.NecessaryBaseChannelObject.Password);

            CommonMethods.WriteBytesToStream(memoryStream_DataToSend, this.NecessaryBaseChannelObject.EncryptData(memoryStream_AuthData.ToArray(), 8));

            this.NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);

            memoryStream_AuthData.Close();
            memoryStream_DataToSend.Close();
        }

        void SendRSAEncryptedAuthorizationData()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_RSAKeySize = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            this.NecessaryBaseChannelObject.XMLStringWithServersPublicRSAKeys = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            RSACryptoServiceProvider rSACryptoServiceProvider_Session = new RSACryptoServiceProvider(int_RSAKeySize);

            this.NecessaryBaseChannelObject.XMLStringWithPrivateRSAKeys = rSACryptoServiceProvider_Session.ToXmlString(true);

            rSACryptoServiceProvider_Session.FromXmlString(this.NecessaryBaseChannelObject.XMLStringWithServersPublicRSAKeys);


            this.NecessaryBaseChannelObject.AES256bit_PrimaryObj = new RijndaelManaged();
            this.NecessaryBaseChannelObject.AES256bit_PrimaryObj.KeySize = 256;
            this.NecessaryBaseChannelObject.AES256bit_PrimaryObj.GenerateIV();
            this.NecessaryBaseChannelObject.AES256bit_PrimaryObj.GenerateKey();

            this.NecessaryBaseChannelObject.iCryptoTransform_DecryptorAES256bit_PrimaryObj = this.NecessaryBaseChannelObject.AES256bit_PrimaryObj.CreateDecryptor();
            this.NecessaryBaseChannelObject.iCryptoTransform_EncryptorAES256bit_PrimaryObj = this.NecessaryBaseChannelObject.AES256bit_PrimaryObj.CreateEncryptor();


            byte[] byteArray_EncryptedPrimaryAESKey = rSACryptoServiceProvider_Session.Encrypt(this.NecessaryBaseChannelObject.AES256bit_PrimaryObj.Key, false),
                   byteArray_EncryptedPrimaryAESIV = rSACryptoServiceProvider_Session.Encrypt(this.NecessaryBaseChannelObject.AES256bit_PrimaryObj.IV, false);


            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, -33);

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, this.NecessaryBaseChannelObject.AES256bit_PrimaryObj.KeySize);

            CommonMethods.WriteBytesToStream(memoryStream_DataToSend, byteArray_EncryptedPrimaryAESKey);
            CommonMethods.WriteBytesToStream(memoryStream_DataToSend, byteArray_EncryptedPrimaryAESIV);

            this.NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);

            rSACryptoServiceProvider_Session.Clear();

            memoryStream_DataToSend.Close();
        }

        void ShowChangesOfAccountState()
        {
            try
            {
                MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

                int int_IsAccountEnabled = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

                memoryStream_ReceivedData.Close();

                CommonNetworkEvents.AuthReasults authResult_obj = new CommonNetworkEvents.AuthReasults();

                switch (int_IsAccountEnabled)
                {
                    case 0:
                        authResult_obj = CommonNetworkEvents.AuthReasults.AccountEnabled;
                        break;

                    case 1:
                        authResult_obj = CommonNetworkEvents.AuthReasults.AccountTemporaryDisabled;
                        break;
                }

                if (NecessaryBaseChannelObject.ConnectingObjectTypeInfo == ConnectingObjectType.Client)
                {
                    CommonNetworkEvents.CallClientAccountStateChangedEventEvent(this.NecessaryBaseChannelObject.ClientOwner, authResult_obj);
                }
                else
                {
                    CommonNetworkEvents.CallServerAccountStateChangedEventEvent(this.NecessaryBaseChannelObject.ServerOwner, authResult_obj);
                }
            }
            catch
            {
            }
        }

        void ShowAuthorizationStatus()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_AuthorizationStatus = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            this.NecessaryBaseChannelObject.AuthorizationComplete = true;

            CommonNetworkEvents.AuthReasults authResults_Result = CommonNetworkEvents.AuthReasults.AuthSuccess;

            if (int_AuthorizationStatus == 1)
            {
                authResults_Result = CommonNetworkEvents.AuthReasults.AuthSuccess;

                this.NecessaryBaseChannelObject.IsAuthorized = true;
            }
            if (int_AuthorizationStatus == 4)
            {
                authResults_Result = CommonNetworkEvents.AuthReasults.AccountTemporaryDisabled;

                this.NecessaryBaseChannelObject.IsAuthorized = true;
                this.NecessaryBaseChannelObject.IsAccountEnabled = false;
            }

            if (this.NecessaryBaseChannelObject.OwnerType == ChannelOwnerType.Client)
            {
                CommonNetworkEvents.CallClientSuccessfullyAuthorizedEvent(this.NecessaryBaseChannelObject.ClientOwner, authResults_Result);
            }
            if (this.NecessaryBaseChannelObject.OwnerType == ChannelOwnerType.Server)
            {
                CommonNetworkEvents.CallServerSuccessfullyAuthorizedEvent(this.NecessaryBaseChannelObject.ServerOwner, authResults_Result);
            }
        }

        void ProcessDisconnectionStatus()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_DisconnectionStatus = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();


            CommonNetworkEvents.DisconnectionReason disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.AuthFailure;

            /*
             * 0 is a Auth failed or Access impossible
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
             * 
             events DisconnectionStatus: AuthFailure, DisconnectByAdmin, MaxConnectionLimit, MaxConnectionsPerAccountLimit, AccountRemoved, DisconnectAllClientsByAdmin, 
                                         ConnectionClosedByOperaionCompleted, ConnectionClosedByUserRequest, ConnectionLost, ExceptionThrownInReceivedCycle, RequestedServerNotConnected
             * 
             */

            switch (int_DisconnectionStatus)
            {
                case 0:
                    {
                        disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.AuthFailure;
                    }
                    break;

                case 1:
                    {
                        disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.DisconnectByAdmin;
                    }
                    break;

                case 2:
                    {
                        disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.MaxConnectionLimit;
                    }
                    break;

                case 3:
                    {
                        disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.MaxConnectionsPerAccountLimit;
                    }
                    break;

                case 4:
                    {
                        disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.AccountRemoved;
                    }
                    break;

                case 5:
                    {
                        disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.DisconnectAllClientsByAdmin;
                    }
                    break;

                case 6:
                    {
                        disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.ConnectionClosedByOperaionCompleted;
                    }
                    break;

                case 7:
                    {
                        disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.ConnectionClosedByUserRequest;
                    }
                    break;

                case 8:
                    {
                        disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.ConnectionLost;
                    }
                    break;

                case 9:
                    {
                        disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.ExceptionThrownInReceivedCycle;
                    }
                    break;

                case 10:
                    {
                        disconnectionReason_Result = CommonNetworkEvents.DisconnectionReason.RequestedServerNotConnected;
                    }
                    break;
            }


            if (NecessaryBaseChannelObject.ConnectingObjectTypeInfo == ConnectingObjectType.Client)
            {
                try
                {
                    this.NecessaryBaseChannelObject.ClientOwner.DisconnectionReason = int_DisconnectionStatus;

                    CommonNetworkEvents.CallClientDisconnectedEvent(this.NecessaryBaseChannelObject.ClientOwner);
                    CommonNetworkEvents.CallClientDiconnectionInfoEvent(this.NecessaryBaseChannelObject.ClientOwner, disconnectionReason_Result);
                }
                catch { }
                finally
                {
                    //this.NecessaryBaseChannelObject.ClientOwner.Disconnect();
                }
            }
            if (NecessaryBaseChannelObject.ConnectingObjectTypeInfo == ConnectingObjectType.Server)
            {
                try
                {
                    this.NecessaryBaseChannelObject.ServerOwner.DisconnectionReason = int_DisconnectionStatus;

                    CommonNetworkEvents.CallServerDisconnectedEvent(this.NecessaryBaseChannelObject.ServerOwner);
                    CommonNetworkEvents.CallServerDiconnectionInfoEvent(this.NecessaryBaseChannelObject.ServerOwner, disconnectionReason_Result);
                }
                catch { }
                finally
                {
                    //this.NecessaryBaseChannelObject.ServerOwner.Disconnect();//куча дисконнектов.. надо чистить
                }
            }

            try
            {
                //this.NecessaryBaseChannelObject.Disconnect(100); //100 for temp // куча дисконнектов.. надо чистить
            }
            catch { }
        }

        void ReceiveGeneratedClientAppliedChannelID()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_UID = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            this.NecessaryBaseChannelObject.ClientOwner.AppliedChannel.ChannelUID = ulong_UID;
        }

        void ReceivePublicServersList()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            int int_PublicServersCount = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);

            try
            {
                PublicServerInfo[] publicServerInfo_obj = new PublicServerInfo[int_PublicServersCount];

                for (int int_Count = 0; int_Count != int_PublicServersCount; int_Count++)
                {
                    publicServerInfo_obj[int_Count] = new PublicServerInfo();

                    publicServerInfo_obj[int_Count].UIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);
                    publicServerInfo_obj[int_Count].IPAddress = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                    publicServerInfo_obj[int_Count].ConnectedTime = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
                }

                CommonNetworkEvents.CallOnPublicServersListReceivedEvent(publicServerInfo_obj);
            }
            catch (Exception)
            {

            }

            memoryStream_ReceivedData.Close();
        }

        void ProcessRegisteredClientUIN()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_GeneratedUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            if (CommonNetworkEvents.ClientUINRegisteredEvent != null)
            {
                CommonNetworkEvents.ClientUINRegisteredEvent(ulong_GeneratedUIN);
            }

            this.NecessaryBaseChannelObject.Disconnect(100); //100 for temp //!!
        }

        void ProcessRegisteredServerUIN()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_GeneratedUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            if (CommonNetworkEvents.ServerUINRegisteredEvent != null)
            {
                CommonNetworkEvents.ServerUINRegisteredEvent(ulong_GeneratedUIN);
            }

            this.NecessaryBaseChannelObject.Disconnect(100); //100 for temp//!!
        }

        void InformInterConnectionClosed()
        {
            if (this.NecessaryBaseChannelObject.OwnerType == ChannelOwnerType.Client)
            {
                CommonNetworkEvents.CallClientInterConnectionClosedEvent(this.NecessaryBaseChannelObject.ClientOwner);
            }
            if (this.NecessaryBaseChannelObject.OwnerType == ChannelOwnerType.Server)
            {
                CommonNetworkEvents.CallServerInterConnectionClosedEvent(this.NecessaryBaseChannelObject.ServerOwner);
            }
        }

        void ProcessNewInterConnectionEvent()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_InterConnectedUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            if (this.NecessaryBaseChannelObject.ConnectingObjectTypeInfo == ConnectingObjectType.Server)
            {
                CommonNetworkEvents.CallServerEnteringNewInterConnectionProcessEvent(this.NecessaryBaseChannelObject.ServerOwner);
            }

            if (this.NecessaryBaseChannelObject.ConnectingObjectTypeInfo == ConnectingObjectType.Client)
            {
                CommonNetworkEvents.CallClientEnteringNewInterConnectiondProcessEvent(this.NecessaryBaseChannelObject.ClientOwner);
            }
        }

        void ProcessClientUINActivation()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_ActivatedUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            if (CommonNetworkEvents.ClientUINActivatedEvent != null)
            {
                CommonNetworkEvents.ClientUINActivatedEvent(ulong_ActivatedUIN);
            }

            this.NecessaryBaseChannelObject.Disconnect(100); //100 for temp
        }

        void ProcessServerUINActivation()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_ActivatedUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            if (CommonNetworkEvents.ServerUINActivatedEvent != null)
            {
                CommonNetworkEvents.ServerUINActivatedEvent(ulong_ActivatedUIN);
            }

            this.NecessaryBaseChannelObject.Disconnect(100); //100 for temp
        }

        void ProcessClientUINDeActivation()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_DeActivatedUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            if (CommonNetworkEvents.ClientUINDeActivatedEvent != null)
            {
                CommonNetworkEvents.ClientUINDeActivatedEvent(ulong_DeActivatedUIN);
            }

            this.NecessaryBaseChannelObject.Disconnect(100); //100 for temp
        }

        void ProcessServerUINDeActivation()
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_DeActivatedUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            if (CommonNetworkEvents.ServerUINDeActivatedEvent != null)
            {
                CommonNetworkEvents.ServerUINDeActivatedEvent(ulong_DeActivatedUIN);
            }

            this.NecessaryBaseChannelObject.Disconnect(100); //100 for temp
        }
    }

}