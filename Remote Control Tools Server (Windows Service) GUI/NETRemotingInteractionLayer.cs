using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DataSet_Server_Ver110;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctServer;
using JurikSoft.XMLConfigImporer.JsRctServer.Version110;
using JurikSoft.RCTServiceGUI;
using JurikSoft.Server_Core;

namespace JurikSoft.RCTServiceGUI
{
    class NETRemotingInteractionLayer
    {
        public static void ConnectToNETRemotingLocalHost()
        {
            RemotingConfiguration.RegisterWellKnownClientType(typeof(JurikSoft.XMLConfigImporer.JsRctServer.Version110.ServerSettingsEnvironment), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_ServerSettingsEnvironment_URI");
                                                                                                                                                    
            RemotingConfiguration.RegisterWellKnownClientType(typeof(NetworkAction), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_NetworkAction_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(NetworkSecurity), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_NetworkSecurity_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(NetworkSecurity.UserAccount), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/Classobj_NetworkSecurity.UserAccount_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(NetworkSecurity.AccessRestrictionRuleObject), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_NetworkSecurity.AccessRestrictionRuleObject_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(JSServerDBEnvironment), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_JSServerDBEnvironment_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(JSServerDBEnvironment.SecurityDataBase), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_JSServerDBEnvironment.SecurityDataBase_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(JSServerDBEnvironment.AccessRestrictionRule), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_JSServerDBEnvironment.AccessRestrictionRule_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(JsRctServerV110XMLConfigImporter), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_JsRctServerV110XMLConfigImporter_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(JurikSoftServerLog), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_JurikSoftServerLog_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(JurikSoftTcpClient), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_JurikSoftTcpClient_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(NetworkStatusAndStatistics), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_NetworkStatusAndStatistics_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(JurikSoftTcpClient.SessionStatisticAndInfo), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_JurikSoftTcpClient.SessionStatisticAndInfo_URI");
        }
    }

    class LocalObjCopy
    {
        public static MainServerForm obj_MainServerForm = new MainServerForm();
        
        public static NetworkAction obj_NetworkAction = (NetworkAction)Activator.GetObject(typeof(NetworkAction), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_NetworkAction_URI");

        public static NetworkSecurity obj_NetworkSecurity = (NetworkSecurity)Activator.GetObject(typeof(NetworkSecurity), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_NetworkSecurity_URI");

        public static ServerSettingsEnvironment obj_ServerSettingsEnvironment = (ServerSettingsEnvironment)Activator.GetObject(typeof(ServerSettingsEnvironment), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_ServerSettingsEnvironment_URI");

        public static JSServerDBEnvironment obj_JSServerDBEnvironment = (JSServerDBEnvironment)Activator.GetObject(typeof(JSServerDBEnvironment), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_JSServerDBEnvironment_URI");

        public static JsRctServerV110XMLConfigImporter obj_JsRctServerV110XMLConfigImporter = (JsRctServerV110XMLConfigImporter)Activator.GetObject(typeof(JsRctServerV110XMLConfigImporter), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_JsRctServerV110XMLConfigImporter_URI");

        public static NetworkSecurity.AccessRestrictionRuleObject obj_NetworkSecurity_AccessRestrictionRuleObject = (NetworkSecurity.AccessRestrictionRuleObject)RemotingServices.Connect(typeof(NetworkSecurity.AccessRestrictionRuleObject), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_NetworkSecurity.AccessRestrictionRuleObject_URI");

        public static NetworkSecurity.UserAccount obj_NetworkSecurity_UserAccount = (NetworkSecurity.UserAccount)RemotingServices.Connect(typeof(NetworkSecurity.UserAccount), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_NetworkSecurity.UserAccount_URI");

        public static NetworkStatusAndStatistics obj_NetworkStatusAndStatistics = (NetworkStatusAndStatistics)RemotingServices.Connect(typeof(NetworkStatusAndStatistics), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_NetworkStatusAndStatistics_URI");
                    
        public static JurikSoftServerLog obj_JurikSoftServerLog = (JurikSoftServerLog)Activator.GetObject(typeof(JurikSoftServerLog), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_JurikSoftServerLog_URI");

        public static JurikSoftTcpClient.SessionStatisticAndInfo obj_SessionStatisticAndInfo = (JurikSoftTcpClient.SessionStatisticAndInfo)Activator.GetObject(typeof(JurikSoftTcpClient.SessionStatisticAndInfo), "ipc://ZNIIS RCT Server Service IPC Port/ZNIIS RCT Server/ClassObj_JurikSoftTcpClient.SessionStatisticAndInfo_URI");
    }
}
