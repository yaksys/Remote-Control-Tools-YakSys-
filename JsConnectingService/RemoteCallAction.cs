using System;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;


public class RemoteCallAction
{
    #region Properties

    BaseChannelObject baseConnectedObject_NecessaryClient;
    public BaseChannelObject NecessaryBaseChannelObject
    {
        set
        {
            baseConnectedObject_NecessaryClient = value;
        }

        get
        {
            return baseConnectedObject_NecessaryClient;
        }
    }

    #endregion
    
    #region SendBindServerRequest method

    public void SendBindServerRequest(ulong ulong_ClientUIN, ulong ulong_DestinedServerUIN)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 1);//Local Action Code

        CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_ClientUIN);
        CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_DestinedServerUIN);

        NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }

    #endregion
    
    #region SendConnectionCheck method

    public void SendConnectionCheck()
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, -5);

        NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }

    #endregion

    public void SendClientDisconnectionEvent(ConnectedClient disconnectedClient_obj)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 9);

        CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, disconnectedClient_obj.UIN);

        NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }

    public void SendServerDisconnectionEvent(ConnectedServer disconnectedServer_obj)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 10);

        CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, disconnectedServer_obj.UIN);

        NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }

    public void SendGeneratedUID(ulong ulong_UID)
    {
        MemoryStream memoryStream_DataToSend = new MemoryStream();

        CommonMethods.WriteIntToStream(memoryStream_DataToSend, 9);
        CommonMethods.WriteUInt64ToStream(memoryStream_DataToSend, ulong_UID);

        NecessaryBaseChannelObject.SendData(memoryStream_DataToSend.ToArray(), SentDataType.ApplicationData);

        memoryStream_DataToSend.Close();
    }
    
}