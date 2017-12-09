using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ServiceProcess;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO.Compression;
using YakSys.Compression;
using YakSys.WMIClassesInfoRetriever.Win32_InstalledApplications;
using YakSys.WMIClassesInfoRetriever.Win32_Hardware;
using YakSys.WMIClassesInfoRetriever.Win32_OS;
using YakSys.WMIClassesInfoRetriever.CIM_Common;
using YakSys.WMIClassesInfoRetriever;
using System.Security.Permissions;
using System.Net.Mail;

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

    BaseChannelObject baseChannelObject_NecessaryChannel;
    public BaseChannelObject NecessaryBaseChannelObject
    {
        set
        {
            baseChannelObject_NecessaryChannel = value;
        }

        get
        {
            return baseChannelObject_NecessaryChannel;
        }
    }

    #endregion

    public void ActionAllocator()
    {
        try
        {
            if (this.baseChannelObject_NecessaryChannel.IsActivated == false)
            {
                switch (BitConverter.ToInt32(byteArray_ReceivedData, 0))
                {
                    case 1000:
                        RegisterNewClientUINRequest();
                        break;

                    case 1001:
                        RegisterNewServerUINRequest();
                        break;

                    case 1002:
                        new Thread(new ThreadStart(ActivateClientUINRequest)).Start();
                        break;

                    case 1003:
                        new Thread(new ThreadStart(ActivateServerUINRequest)).Start();
                        break;

                }

                Thread.Sleep(5000);

                NecessaryBaseChannelObject.Disconnect(6);

                return;
            }
            else
            {
                switch (BitConverter.ToInt32(byteArray_ReceivedData, 0))
                {
                    case 1:
                        InterconnectionProcessRequest();
                        break;

                    case 2:
                        InitInterconnectionProcess();
                        break;

                    case 3:
                        CloseClientConnection();
                        break;

                    case 4:
                        CloseServerConnection();
                        break;
                        
                    case 5:
                        UnHideServerIP();
                        break;

                    case 6:
                        SendPublicServersList();
                        break;

                    case 1004:
                        new Thread(new ThreadStart(DeActivateClientUINRequest)).Start();
                        break;

                    case 1005:
                        new Thread(new ThreadStart(DeActivateServerUINRequest)).Start();
                        break;
                }
            }
        }

        catch (Exception exception)
        {
        }
    }

    #region InterconnectionProcessRequest method

    public void InterconnectionProcessRequest() //call by client
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_RequestServerUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            int int_WaitForServer = CommonMethods.ReadIntFromStream(memoryStream_ReceivedData);
            bool bool_WaitForServer = true;

            if (int_WaitForServer == 1)
            {
                bool_WaitForServer = true;
            }
            else
            {
                bool_WaitForServer = false;
            }

            if (ConnectedClient.IsNecesseryUINConnected(this.NecessaryBaseChannelObject.UIN) == true)
            {
                ConnectedClient connectedClient_obj = ConnectedClient.GetClientByUIN(this.NecessaryBaseChannelObject.UIN); //!! было (ulong_ClientUIN)
                
                connectedClient_obj.WaitForServer = bool_WaitForServer;

                ConnectedClient.AppliedClientChannel appliedClientChannel_obj = connectedClient_obj.GetNecesseryAppliedClientChannelByServerUIN(ulong_RequestServerUIN);

                connectedClient_obj.InterconnectionProcessRequest(appliedClientChannel_obj, ulong_RequestServerUIN);
            }
        }

        catch (Exception exception)
        {
            MessageBox.Show(exception.Message + " -- " + exception.StackTrace);
        }

        finally
        {

        }
    }

    #endregion

    #region SendNewInterConnectionEventNotify method

    void SendNewInterConnectionEventNotify(BaseChannelObject BaseChannelObject_NotifyClient, ulong ulong_InterConnectedUIN)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 14);

        CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_InterConnectedUIN);

        BaseChannelObject_NotifyClient.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);

        memoryStream_DataToSend.Close();
    }

    #endregion

    #region InitInterconnectionProcess method

    public void InitInterconnectionProcess() //called by server
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_ClientUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            if (ConnectedClient.IsNecesseryUINConnected((ulong)ulong_ClientUIN) == true)
            {
                NetworkAction.InterConnectedObjects interConnectedObject_obj = new NetworkAction.InterConnectedObjects();

                interConnectedObject_obj.AppliedServerChannel = ConnectedServer.GetServerByUIN(this.NecessaryBaseChannelObject.UIN).GetNecesseryAppliedServerChannelByClientUIN(ulong_ClientUIN);
                interConnectedObject_obj.AppliedClientChannel = ConnectedClient.GetClientByUIN(ulong_ClientUIN).GetNecesseryAppliedClientChannelByServerUIN(this.NecessaryBaseChannelObject.UIN);

                interConnectedObject_obj.AppliedClientChannel.InterconnectedObject = interConnectedObject_obj.AppliedServerChannel.ChannelOwner; // если клиент ждал сервера то этот объект  InterconnectedObject назначается только здесь!

                new Thread(new ParameterizedThreadStart(new NetworkAction().ClientInterConnectionProcessReceiveCycle)).Start(interConnectedObject_obj);
                new Thread(new ParameterizedThreadStart(new NetworkAction().ServerInterConnectionProcessReceiveCycle)).Start(interConnectedObject_obj);

                CommonNetworkEvents.NewInterConnectionEvent(interConnectedObject_obj.AppliedServerChannel, interConnectedObject_obj.AppliedClientChannel);

                SendNewInterConnectionEventNotify(interConnectedObject_obj.AppliedServerChannel.ChannelOwner.SystemChannel.BaseChannel, interConnectedObject_obj.AppliedServerChannel.ChannelOwner.UIN);
                SendNewInterConnectionEventNotify(interConnectedObject_obj.AppliedClientChannel.ChannelOwner.SystemChannel.BaseChannel, interConnectedObject_obj.AppliedClientChannel.ChannelOwner.UIN);
            }

            memoryStream_ReceivedData.Close();
        }

        catch
        {

        }

        finally
        {

        }
    }

    #endregion

    #region CloseClientConnection method

    public void CloseClientConnection()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_ClientUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            if (ConnectedClient.IsNecesseryUINConnected((ulong)ulong_ClientUIN) == true)
            {
                ConnectedClient.GetClientByUIN(ulong_ClientUIN).Disconnect(7);
            }
        }

        catch
        {

        }
    }

    #endregion

    #region CloseServerConnection method

    public void CloseServerConnection()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_ServerUIN = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            if (ConnectedServer.IsNecesseryUINConnected((ulong)ulong_ServerUIN) == true)
            {
                ConnectedServer.GetServerByUIN(ulong_ServerUIN).Disconnect(7);
            }
        }

        catch
        {

        }
    }

    #endregion

    #region SendConnectionCheck method

    public void SendConnectionCheck()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, -5);

        NecessaryBaseChannelObject.Client.SendBufferSize = 64;
        NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);
        NecessaryBaseChannelObject.Client.SendBufferSize = 8192;

        memoryStream_DataToSend.Close();
    }

    #endregion


    #region SendAuthorizationStatus method

    public void SendAuthorizationStatus(int int_AuthorizationStatus)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 19);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_AuthorizationStatus);

        NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);

        memoryStream_DataToSend.Close();
    }

    #endregion

    #region SendDisconnectionStatus method

    public void SendDisconnectionStatus(int int_DisconnectionStatus)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 15);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_DisconnectionStatus);

        NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.SystemData);

        memoryStream_DataToSend.Close();
    }

    #endregion

    #region ToSendChangesOfAccountState method

    public void ToSendChangesOfAccountState(int int_ErrorCode)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 18);
        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_ErrorCode);

        NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }

    #endregion

    #region SendPublicServersList method

    public void SendPublicServersList()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 8);

        //------------------------------------------------------------------------------------------------------------------------

        MemoryStream memoryStream_TmpServersData = new MemoryStream();

        int int_PublicServersCount = 0;

        for (int int_Count = 0; int_Count != ConnectedServer.AllConnectedServers.Count; int_Count++)
        {
            if (ConnectedServer.AllConnectedServers[int_Count].PublicServer == true)
            {
                int_PublicServersCount++;
            }
            else
            {
                continue;
            }

            CommonMethods.WriteUInt64ToStream(memoryStream_TmpServersData, ConnectedServer.AllConnectedServers[int_Count].UIN);

            if (ConnectedServer.AllConnectedServers[int_Count].HideIP == false)
            {
                CommonMethods.WriteStringToStream(memoryStream_TmpServersData, ConnectedServer.AllConnectedServers[int_Count].IPAddress);
            }
            else
            {
                CommonMethods.WriteStringToStream(memoryStream_TmpServersData, String.Empty);
            }

            CommonMethods.WriteStringToStream(memoryStream_TmpServersData, ConnectedServer.AllConnectedServers[int_Count].SystemChannel.BaseChannel.Statistic_ConnectedTime.ToString());
        }

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, int_PublicServersCount);

        memoryStream_DataToSend.Write(memoryStream_TmpServersData.ToArray(), 0, memoryStream_TmpServersData.ToArray().Length);

        //------------------------------------------------------------------------------------------------------------------------

        NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }

    #endregion

    #region Simple SendMail method

    public void SendMail(string mailAddress_Recipient, string mailAddress_Sender, string string_Subject, string string_Text)
    {
        try
        {
            SmtpClient smtpClient_Client = new SmtpClient(CommonEnvironment.SMTPServer, CommonEnvironment.SMTPPort);

            MailMessage mailMessage_obj = new MailMessage(mailAddress_Sender, mailAddress_Recipient);

            smtpClient_Client.Credentials = new System.Net.NetworkCredential(CommonEnvironment.SMTPLogin, CommonEnvironment.SMTPPassword);

            mailMessage_obj.Body = string_Text;
            mailMessage_obj.Subject = string_Subject;

            smtpClient_Client.Send(mailMessage_obj);
        }
        catch (Exception exception)
        {
            return;
        }
    }

    #endregion

    #region UnHideServerIP

    public void UnHideServerIP()
    {
        if (ConnectedServer.GetServerByUIN(NecessaryBaseChannelObject.UIN) != null)
        {
            ConnectedServer.GetServerByUIN(NecessaryBaseChannelObject.UIN).HideIP = false;
        }
    }

    #endregion



    #region RegisterNewClientUINRequest method

    public void RegisterNewClientUINRequest()
    {
        try
        {
            string string_UserName, string_Password, string_FirstName,
                    string_SecondName, string_LastName, string_ICQ, string_EMail,
                    string_Work, string_HomePhone, string_WorkPhone, string_MobilePhone;

            //---------------------------------------------------------------------------------------------------------------

            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            string_UserName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_Password = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            string_FirstName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_SecondName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_LastName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            string_ICQ = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_EMail = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            string_Work = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            string_HomePhone = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_WorkPhone = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_MobilePhone = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            //---------------------------------------------------------------------------------------------------------------

            Random random_obj = new Random();

            ulong ulong_GeneratedUIN = (ulong)(random_obj.Next());

            foreach (ClientsNetworkSecurity.UserAccount userAccount_obj in ClientsNetworkSecurity.UserAccount.UsersAccounts)
            {
                try
                {
                    if (ulong.Parse(userAccount_obj.UIN) == ulong_GeneratedUIN)
                    {
                        RegisterNewClientUINRequest();

                        return;
                    }
                }
                catch
                {
                    return;
                }
            }

            //---------------------------------------------------------------------------------------------------------------

            ClientsNetworkSecurity.UserAccount userAccount_NewAccount = new ClientsNetworkSecurity.UserAccount();

            userAccount_NewAccount.FirstName = string_FirstName;
            userAccount_NewAccount.SecondName = string_SecondName;
            userAccount_NewAccount.LastName = string_LastName;

            userAccount_NewAccount.ICQ = string_ICQ;
            userAccount_NewAccount.EMail = string_EMail;

            userAccount_NewAccount.Work = string_Work;

            userAccount_NewAccount.HomePhone = string_HomePhone;
            userAccount_NewAccount.WorkPhone = string_WorkPhone;
            userAccount_NewAccount.MobilePhone = string_MobilePhone;

            userAccount_NewAccount.ActivationCode = (ulong)(random_obj.Next());

            userAccount_NewAccount.IsEnabled = true;
            userAccount_NewAccount.IsActivated = false;

            userAccount_NewAccount.Password = string_Password;
            userAccount_NewAccount.UIN = ulong_GeneratedUIN.ToString();
            userAccount_NewAccount.UserName = string_UserName;
            userAccount_NewAccount.CreationTime = DateTime.Now;

            ClientsNetworkSecurity.AddNewUser(userAccount_NewAccount);
            ClientsNetworkSecurity.StoreNewClientUserAccountToDB(userAccount_NewAccount);

            //---------------------------------------------------------------------------------------------------------------

            string string_Message = "Your YakSys Connecting Service Activation Code for UIN " + ulong_GeneratedUIN.ToString() + " is: " + userAccount_NewAccount.ActivationCode.ToString();

            SendMail(userAccount_NewAccount.EMail, "jurik_ja@mail.ru", "YakSys Connecting Service Activation Code", string_Message);

            //---------------------------------------------------------------------------------------------------------------

            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 12);
            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_GeneratedUIN);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message + " -- " + exception.StackTrace);

            return;
        }
    }

    #endregion

    #region RegisterNewServerUINRequest method

    public void RegisterNewServerUINRequest()
    {
        try
        {
            string string_UserName, string_Password, string_FirstName,
                    string_SecondName, string_LastName, string_ICQ, string_EMail,
                    string_Work, string_HomePhone, string_WorkPhone, string_MobilePhone;

            //---------------------------------------------------------------------------------------------------------------

            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            string_UserName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_Password = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            string_FirstName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_SecondName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_LastName = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            string_ICQ = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_EMail = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            string_Work = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            string_HomePhone = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_WorkPhone = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);
            string_MobilePhone = CommonMethods.ReadStringFromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            //---------------------------------------------------------------------------------------------------------------

            Random random_obj = new Random();

            ulong ulong_GeneratedUIN = (ulong)(random_obj.Next());

            foreach (ServersNetworkSecurity.UserAccount userAccount_obj in ServersNetworkSecurity.UserAccount.UsersAccounts)
            {
                try
                {
                    if (ulong.Parse(userAccount_obj.UIN) == ulong_GeneratedUIN)
                    {
                        RegisterNewServerUINRequest();

                        return;
                    }
                }
                catch
                {
                    return;
                }
            }

            //---------------------------------------------------------------------------------------------------------------

            ServersNetworkSecurity.UserAccount userAccount_NewAccount = new ServersNetworkSecurity.UserAccount();

            userAccount_NewAccount.FirstName = string_FirstName;
            userAccount_NewAccount.SecondName = string_SecondName;
            userAccount_NewAccount.LastName = string_LastName;

            userAccount_NewAccount.ICQ = string_ICQ;
            userAccount_NewAccount.EMail = string_EMail;

            userAccount_NewAccount.Work = string_Work;

            userAccount_NewAccount.HomePhone = string_HomePhone;
            userAccount_NewAccount.WorkPhone = string_WorkPhone;
            userAccount_NewAccount.MobilePhone = string_MobilePhone;

            userAccount_NewAccount.ActivationCode = (ulong)(random_obj.Next());

            userAccount_NewAccount.IsEnabled = true;
            userAccount_NewAccount.IsActivated = false;

            userAccount_NewAccount.Password = string_Password;
            userAccount_NewAccount.UIN = ulong_GeneratedUIN.ToString();

            userAccount_NewAccount.UserName = string_UserName;

            userAccount_NewAccount.CreationTime = DateTime.Now;

            ServersNetworkSecurity.AddNewUser(userAccount_NewAccount);
            ServersNetworkSecurity.StoreNewServerUserAccountToDB(userAccount_NewAccount);

            //---------------------------------------------------------------------------------------------------------------

            string string_Message = "Your YakSys Connecting Service Activation Code for UIN " + ulong_GeneratedUIN.ToString() + " is: " + userAccount_NewAccount.ActivationCode.ToString();

            SendMail(userAccount_NewAccount.EMail, "jurik_ja@mail.ru", "YakSys Connecting Service Activation Code", string_Message);

            //---------------------------------------------------------------------------------------------------------------

            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 13);
            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_GeneratedUIN);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message + " -- " + exception.StackTrace);

            return;
        }
    }

    #endregion

    #region ActivateClientUINRequest method

    public void ActivateClientUINRequest()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_ActivationCode = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            for (int int_CycleCount = 0; int_CycleCount != ClientsNetworkSecurity.UserAccount.UsersAccounts.Count; int_CycleCount++)
            {
                if (ClientsNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].UIN == NecessaryBaseChannelObject.UIN.ToString() &&
                    ClientsNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].ActivationCode == ulong_ActivationCode)
                {
                    ClientsNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].ActivateAccount();

                    ObjCopy.obj_MainForm.RefresfClientsActivatedStatus();
                }
            }

            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 20);
            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, NecessaryBaseChannelObject.UIN);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }

        catch
        {

        }
        finally
        {
        }
    }

    #endregion

    #region ActivateServerUINRequest method

    public void ActivateServerUINRequest()
    {
        try
        {
            MemoryStream memoryStream_ReceivedData = new MemoryStream(byteArray_ReceivedData, 4, byteArray_ReceivedData.Length - 4);

            ulong ulong_ActivationCode = CommonMethods.ReadUInt64FromStream(memoryStream_ReceivedData);

            memoryStream_ReceivedData.Close();

            for (int int_CycleCount = 0; int_CycleCount != ServersNetworkSecurity.UserAccount.UsersAccounts.Count; int_CycleCount++)
            {
                if (ServersNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].UIN == NecessaryBaseChannelObject.UIN.ToString() &&
                    ServersNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].ActivationCode == ulong_ActivationCode)
                {
                    ServersNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].ActivateAccount();

                    ObjCopy.obj_MainForm.RefresfServersActivatedStatus();
                }
            }

            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 21);
            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, NecessaryBaseChannelObject.UIN);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }
        catch
        {

        }
        finally
        {
        }
    }

    #endregion



    #region DeActivateClientUINRequest method

    public void DeActivateClientUINRequest()
    {
        try
        {
            for (int int_CycleCount = 0; int_CycleCount != ClientsNetworkSecurity.UserAccount.UsersAccounts.Count; int_CycleCount++)
            {
                if (ClientsNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].UIN == NecessaryBaseChannelObject.UIN.ToString())
                {
                    ClientsNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].DeActivateAccount();

                    ObjCopy.obj_MainForm.RefresfClientsActivatedStatus();
                }
            }

            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 22);
            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, NecessaryBaseChannelObject.UIN);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }
        catch
        {

        }
        finally
        {
        }
    }

    #endregion

    #region DeActivateServerUINRequest method

    public void DeActivateServerUINRequest()
    {
        try
        {
            for (int int_CycleCount = 0; int_CycleCount != ServersNetworkSecurity.UserAccount.UsersAccounts.Count; int_CycleCount++)
            {
                if (ServersNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].UIN == NecessaryBaseChannelObject.UIN.ToString())
                {
                    ServersNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].DeActivateAccount();

                    ObjCopy.obj_MainForm.RefresfServersActivatedStatus();
                }
            }

            MemoryStream memoryStream_DataToSend = new MemoryStream();

            CommonMethods.WriteIntToStream(memoryStream_DataToSend, 23);
            CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, NecessaryBaseChannelObject.UIN);

            NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

            memoryStream_DataToSend.Close();
        }
        catch
        {

        }
        finally
        {

        }
    }

    #endregion
}

