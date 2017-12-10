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
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctServer;
using YakSys.XMLConfigImporter.YakSysRctServer.Version110;
using YakSys.RCTServiceGUI;
using YakSys.Server_Core;

namespace YakSys.RCTServiceGUI
{
    class NETRemotingInteractionLayer
    {
        public static void ConnectToNETRemotingLocalHost()
        {
            RemotingConfiguration.RegisterWellKnownClientType(typeof(YakSys.XMLConfigImporter.YakSysRctServer.Version110.ServerSettingsEnvironment), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ServerSettingsEnvironment_URI");
                                                                                                                                                    
            RemotingConfiguration.RegisterWellKnownClientType(typeof(NetworkAction), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_NetworkAction_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(NetworkSecurity), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_NetworkSecurity_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(NetworkSecurity.UserAccount), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_NetworkSecurity.UserAccount_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(NetworkSecurity.AccessRestrictionRuleObject), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_NetworkSecurity.AccessRestrictionRuleObject_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(YakSysServerDBEnvironment), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_YakSysServerDBEnvironment_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(YakSysServerDBEnvironment.SecurityDataBase), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_YakSysServerDBEnvironment.SecurityDataBase_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(YakSysServerDBEnvironment.AccessRestrictionRule), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_YakSysServerDBEnvironment.AccessRestrictionRule_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(YakSysRctServerV110XMLConfigImporter), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_YakSysRctServerV110XMLConfigImporter_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(YakSysServerLog), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_YakSysServerLog_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(YakSysTcpClient), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_YakSysTcpClient_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(NetworkStatusAndStatistics), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_NetworkStatusAndStatistics_URI");

            RemotingConfiguration.RegisterWellKnownClientType(typeof(YakSysTcpClient.SessionStatisticAndInfo), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_YakSysTcpClient.SessionStatisticAndInfo_URI");
        }
    }

    class LocalObjCopy
    {
        public static MainServerForm obj_MainServerForm = new MainServerForm();
        
        public static NetworkAction obj_NetworkAction = (NetworkAction)Activator.GetObject(typeof(NetworkAction), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_NetworkAction_URI");

        public static NetworkSecurity obj_NetworkSecurity = (NetworkSecurity)Activator.GetObject(typeof(NetworkSecurity), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_NetworkSecurity_URI");

        public static ServerSettingsEnvironment obj_ServerSettingsEnvironment = (ServerSettingsEnvironment)Activator.GetObject(typeof(ServerSettingsEnvironment), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_ServerSettingsEnvironment_URI");

        public static YakSysServerDBEnvironment obj_YakSysServerDBEnvironment = (YakSysServerDBEnvironment)Activator.GetObject(typeof(YakSysServerDBEnvironment), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_YakSysServerDBEnvironment_URI");

        public static YakSysRctServerV110XMLConfigImporter obj_YakSysRctServerV110XMLConfigImporter = (YakSysRctServerV110XMLConfigImporter)Activator.GetObject(typeof(YakSysRctServerV110XMLConfigImporter), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_YakSysRctServerV110XMLConfigImporter_URI");

        public static NetworkSecurity.AccessRestrictionRuleObject obj_NetworkSecurity_AccessRestrictionRuleObject = (NetworkSecurity.AccessRestrictionRuleObject)RemotingServices.Connect(typeof(NetworkSecurity.AccessRestrictionRuleObject), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_NetworkSecurity.AccessRestrictionRuleObject_URI");

        public static NetworkSecurity.UserAccount obj_NetworkSecurity_UserAccount = (NetworkSecurity.UserAccount)RemotingServices.Connect(typeof(NetworkSecurity.UserAccount), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_NetworkSecurity.UserAccount_URI");

        public static NetworkStatusAndStatistics obj_NetworkStatusAndStatistics = (NetworkStatusAndStatistics)RemotingServices.Connect(typeof(NetworkStatusAndStatistics), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_NetworkStatusAndStatistics_URI");
                    
        public static YakSysServerLog obj_YakSysServerLog = (YakSysServerLog)Activator.GetObject(typeof(YakSysServerLog), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_YakSysServerLog_URI");

        public static YakSysTcpClient.SessionStatisticAndInfo obj_SessionStatisticAndInfo = (YakSysTcpClient.SessionStatisticAndInfo)Activator.GetObject(typeof(YakSysTcpClient.SessionStatisticAndInfo), "ipc://YakSys RCT Server Service IPC Port/YakSys RCT Server/ClassObj_YakSysTcpClient.SessionStatisticAndInfo_URI");
    }
}
