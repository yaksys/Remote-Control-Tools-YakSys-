using System;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace CSP
{
    public class CSPRemoteCallAction
    {
        #region Properties

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




        #region SendKeepConnectionAliveParams method

        public void SendKeepConnectionAliveParams(bool bool_KeepConnectionAlive)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 8);//Local Action Code

            if (bool_KeepConnectionAlive == true)
            {
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1);
            }
            else
            {
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);
            }

            this.NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region SentRequestedServerInfo method

        public void SentRequestedServerInfo(ulong ulong_ServerUIN, bool bool_WaitForServer)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1);//Local Action Code

            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_ServerUIN);// Requested Server Code

            if (bool_WaitForServer == true)
            {
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1);
            }
            else
            {
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);
            }

            this.NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region SendConnectionCheck method

        public void SendConnectionCheck()
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, -5);

            bool bool_IssuccessfullyCall = NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            if (bool_IssuccessfullyCall == false)
            {
                NecessaryBaseChannelObject.IsConnected = false;

                throw new Exception();
            }

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region SendCommonAuthorizationRequest

        public enum ConnectingObjectType
        {
            Client, Server
        }

        public enum ConnectingChannelObjectType
        {
            SystemChannel, AppliedChannel
        }

        public void SendCommonAuthorizationRequest(ConnectingObjectType ConnectingObjectType_obj, ConnectingChannelObjectType connectingChannelObjectType_obj, ulong ulong_UIN, ulong ulong_InterConnectedUIN, ulong ulong_ChannelUID)
        {
            byte[] byteArray_AuthRequest = new byte[30];

            byteArray_AuthRequest[0] = BitConverter.GetBytes(-37)[0]; // -37 is a ID Code of Auth Request 
            byteArray_AuthRequest[1] = BitConverter.GetBytes(-37)[1];
            byteArray_AuthRequest[2] = BitConverter.GetBytes(-37)[2];
            byteArray_AuthRequest[3] = BitConverter.GetBytes(-37)[3];

            if (ConnectingObjectType_obj == ConnectingObjectType.Client)  //Is a JurikSoft Client Auth Request 
            {
                byteArray_AuthRequest[4] = 0;
            }
            else //Is a JurikSoft Server Auth Request
            {
                byteArray_AuthRequest[4] = 1;
            }


            if (connectingChannelObjectType_obj == ConnectingChannelObjectType.SystemChannel)  //Is a System Channel Auth Request 
            {
                byteArray_AuthRequest[5] = 0;
            }
            else //Is a Applied Channel Auth Request 
            {
                byteArray_AuthRequest[5] = 1;
            }

            BitConverter.GetBytes(ulong_UIN).CopyTo(byteArray_AuthRequest, 6);

            BitConverter.GetBytes(ulong_InterConnectedUIN).CopyTo(byteArray_AuthRequest, 14);

            BitConverter.GetBytes(ulong_ChannelUID).CopyTo(byteArray_AuthRequest, 22);

            this.NecessaryBaseChannelObject.SendData(byteArray_AuthRequest, SentDataType.ApplicationData);
        }

        #endregion

        #region SendAuthRequestForUINregistration

        public void SendAuthRequestForUINregistration(ConnectingObjectType ConnectingObjectType_obj)
        {
            byte[] byteArray_AuthRequest = new byte[30];

            byteArray_AuthRequest[0] = BitConverter.GetBytes(-37)[0]; // -37 is a ID Code of Auth Request 
            byteArray_AuthRequest[1] = BitConverter.GetBytes(-37)[1];
            byteArray_AuthRequest[2] = BitConverter.GetBytes(-37)[2];
            byteArray_AuthRequest[3] = BitConverter.GetBytes(-37)[3];

            if (ConnectingObjectType_obj == ConnectingObjectType.Client)  //Is a JurikSoft Client Auth Request 
            {
                byteArray_AuthRequest[4] = 0;
            }
            else //Is a JurikSoft Server Auth Request
            {
                byteArray_AuthRequest[4] = 1;
            }

            this.NecessaryBaseChannelObject.SendData(byteArray_AuthRequest, SentDataType.ApplicationData);
        }

        #endregion

        #region SentClientConnectionRequest

        public void SentClientConnectionRequest()
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region SentServerConnectionRequest

        public void SentServerConnectionRequest()
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region InitInterconnectionProcess

        public void InitInterconnectionProcess(ulong ulong_ClientUIN)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 2);

            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_ClientUIN);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region CloseClientConnection

        public void CloseClientConnection(ulong ulong_ClientUIN)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 3);

            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_ClientUIN);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region CloseServerConnection

        public void CloseServerConnection(ulong ulong_ServerUIN)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 4);

            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_ServerUIN);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region CloseServerAppliedChannelConnection

        public void CloseServerAppliedChannelConnection(ulong ulong_ServerUIN, ulong ulong_ChannelUID)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 5);

            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_ServerUIN);
            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_ChannelUID);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region UnHideServerIP

        public void UnHideServerIP()
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 5);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion


        #region UnHideClientIP

        public void UnHideClientIP()
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 7);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region GetPublicServersList

        public void GetPublicServersList()
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 6);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region RegisterNewServerUINRequest

        public void RegisterNewServerUINRequest(string string_Login, string string_UserName, string string_Password, string string_FirstName, string string_SecondName, string string_LastName, string string_ICQ, string string_EMail,
            string string_Work, string string_HomePhone, string string_WorkPhone, string string_MobilePhone)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 999);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_Login);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_UserName);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_Password);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_FirstName);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_SecondName);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_LastName);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_ICQ);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_EMail);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_Work);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_HomePhone);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_WorkPhone);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_MobilePhone);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);

            memoryStream_DataToSend.Close();
        }

        #endregion


        public void BeginRegisterNewUINProcess()
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 999);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);

            memoryStream_DataToSend.Close();
        }

        #region RegisterNewClientUINRequest

        public void RegisterNewClientUINRequest(string string_UserName, string string_Password, string string_FirstName, string string_SecondName, string string_LastName, string string_ICQ, string string_EMail,
            string string_Work, string string_HomePhone, string string_WorkPhone, string string_MobilePhone)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1000);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_UserName);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_Password);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_FirstName);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_SecondName);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_LastName);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_ICQ);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_EMail);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_Work);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_HomePhone);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_WorkPhone);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_MobilePhone);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region RegisterNewServerUINRequest

        public void RegisterNewServerUINRequest(string string_UserName, string string_Password, string string_FirstName, string string_SecondName, string string_LastName, string string_ICQ, string string_EMail,
            string string_Work, string string_HomePhone, string string_WorkPhone, string string_MobilePhone)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1001);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_UserName);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_Password);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_FirstName);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_SecondName);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_LastName);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_ICQ);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_EMail);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_Work);

            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_HomePhone);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_WorkPhone);
            CommonMethods.WriteStringToStream(memoryStream_DataToSend, string_MobilePhone);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion


        #region ActivateClientUINRequest

        public void ActivateClientUINRequest(ulong ulong_ActivationCode)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1002);

            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_ActivationCode);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region ActivateServerUINRequest

        public void ActivateServerUINRequest(ulong ulong_ActivationCode)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1003);

            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_ActivationCode);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion


        #region DeActivateClientUINRequest

        public void DeActivateClientUINRequest(bool bool_RequestActivationCode)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1004);

            if (bool_RequestActivationCode == true)
            {
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1);
            }
            else
            {
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);
            }

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion

        #region DeActivateServerUINRequest

        public void DeActivateServerUINRequest(bool bool_RequestActivationCode)
        {
            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1005);

            if (bool_RequestActivationCode == true)
            {
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1);
            }
            else
            {
                CommonMethods.WriteIntToStream(memoryStream_DataToSend, 0);
            }

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        #endregion
    }

}