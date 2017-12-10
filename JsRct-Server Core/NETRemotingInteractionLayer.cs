using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctServer.Version110;
using System.Collections;
using System.Security.Principal;

namespace YakSys
{
    namespace Server_Core
    {
        public class NETRemotingInteractionLayer
        {
            public static void StartNETRemotingHost(int int_NETRemotingChannelPort)
            {
                try
                {
                    BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
                    serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

                    System.Collections.IDictionary hashTable_IpcServerChannelProperties = new System.Collections.Hashtable();

                    SecurityIdentifier securityIdentifier_obj = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                    
                    NTAccount nTAccount_obj = securityIdentifier_obj.Translate(typeof(NTAccount)) as NTAccount;

                    hashTable_IpcServerChannelProperties["portName"] = "YakSys RCT Server Service IPC Port";
                    hashTable_IpcServerChannelProperties["authorizedGroup"] = nTAccount_obj.Value;                                     
                    hashTable_IpcServerChannelProperties["exclusiveAddressUse"] = false;
                    

                    IpcChannel ipcServerChannel_ServerChannel = new IpcChannel(hashTable_IpcServerChannelProperties, null, serverProv);

                    ChannelServices.RegisterChannel(ipcServerChannel_ServerChannel, false);

                    RemotingConfiguration.ApplicationName = "YakSys RCT Server";


                    // Windows Vista/Windows 7 Service Desktop interact Layer-------------------------------------------------------------

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(ProcWindowService), "ClassObj_ProcWindowService_URI", WellKnownObjectMode.SingleCall);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(ProcWindowService.ApplicationStartPendingPool), "ClassObj_ProcWindowService_ApplicationStartPendingPool_URI", WellKnownObjectMode.SingleCall);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(ProcWindowService.RTDVContainer), "ClassObj_ProcWindowService_RTDVContainer_URI", WellKnownObjectMode.SingleCall);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(ProcWindowService.MessageBoxPendingPool), "ClassObj_ProcWindowService_MessageBoxPendingPool_URI", WellKnownObjectMode.SingleCall);
                 
                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(ProcWindowService.ClipboardWrapper), "ClassObj_ProcWindowService_ClipboardWrapper_URI", WellKnownObjectMode.SingleCall);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(ProcWindowService.MicrophoneRecordWrapper), "ClassObj_ProcWindowService_MicrophoneRecordWrapper_URI", WellKnownObjectMode.SingleCall);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(ProcWindowService.WebCamContainer), "ClassObj_ProcWindowService_WebCamContainer_URI", WellKnownObjectMode.SingleCall);


                    // -------------------------------------------------------------------------------------------------------------------

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(ServerSettingsEnvironment), "ClassObj_ServerSettingsEnvironment_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(NetworkAction), "ClassObj_NetworkAction_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(NetworkSecurity), "ClassObj_NetworkSecurity_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(NetworkSecurity.UserAccount), "ClassObj_NetworkSecurity.UserAccount_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(NetworkSecurity.AccessRestrictionRuleObject), "ClassObj_NetworkSecurity.AccessRestrictionRuleObject_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(YakSysServerDBEnvironment), "ClassObj_YakSysServerDBEnvironment_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(YakSysServerDBEnvironment.SecurityDataBase), "ClassObj_YakSysServerDBEnvironment.SecurityDataBase_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(YakSysServerDBEnvironment.AccessRestrictionRule), "ClassObj_YakSysServerDBEnvironment.AccessRestrictionRule_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(YakSysRctServerV110XMLConfigImporter), "ClassObj_YakSysRctServerV110XMLConfigImporter_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(YakSysServerLog), "ClassObj_YakSysServerLog_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(YakSysTcpClient), "ClassObj_YakSysTcpClient_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(NetworkStatusAndStatistics), "ClassObj_NetworkStatusAndStatistics_URI", WellKnownObjectMode.Singleton);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(YakSysTcpClient.SessionStatisticAndInfo), "ClassObj_YakSysTcpClient.SessionStatisticAndInfo_URI", WellKnownObjectMode.Singleton);
                }
                catch
                {
                    MessageBox.Show("Starting .NET Remoting Host using IPC channels failed!");
                }
            }
        }

        [Serializable]
        public class NetworkStatusAndStatistics : MarshalByRefObject
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
                    string_LastConnectionAt = ServerStringFactory.GetString(165, ServerSettingsEnvironment.CurrentLanguage) + " " + value;
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
                    return NetworkStatusAndStatistics.Statistic_BytesSent;
                }
            }
            public long RemotingWrapper_Statistic_BytesReceived
            {
                get
                {
                    return NetworkStatusAndStatistics.Statistic_BytesReceived;
                }
            }
            public long RemotingWrapper_Statistic_ActiveConnections
            {
                get
                {
                    return NetworkStatusAndStatistics.Statistic_ActiveConnections;
                }
            }

            public string RemotingWrapper_Statistic_LastConnectionAt
            {
                get
                {
                    return NetworkStatusAndStatistics.Statistic_LastConnectionAt;
                }
            }
            public string RemotingWrapper_ServerStatus
            {
                set
                {
                    NetworkStatusAndStatistics.ServerStatus = value;
                }
         
                get
                {
                    return NetworkStatusAndStatistics.ServerStatus;
                }
            }
        }

        public class YakSysServerLog : MarshalByRefObject
        {
            public static void InsertDataToLog(string string_LogType, string string_LogDate, string string_LogTime,
                                                 string string_LogSource, string string_LogDescription)
            {
                DataRow dataRow_NewRecord = null;

                YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.EventsLogDataTable eventsLogDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.EventsLog;

                ////////////////////////////////////////////////////////////////////////////////

                dataRow_NewRecord = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.EventsLog.NewRow();

                int int_EventLogID = 0;

                for (int int_CycleCount = 0; ; int_CycleCount++)
                {
                    if (eventsLogDataTable_obj.Rows.Count == 0) break;

                    if (int_CycleCount >= eventsLogDataTable_obj.Rows.Count
                        || (int)eventsLogDataTable_obj.Rows[int_CycleCount][eventsLogDataTable_obj.IDColumn] == int_EventLogID)
                    {
                        int_EventLogID++;
                        int_CycleCount = -1;
                    }

                    else if (int_CycleCount + 1 == eventsLogDataTable_obj.Rows.Count) break;
                }

                dataRow_NewRecord[eventsLogDataTable_obj.IDColumn] = int_EventLogID;

                dataRow_NewRecord[eventsLogDataTable_obj.SourceColumn] = string_LogSource;
                dataRow_NewRecord[eventsLogDataTable_obj.TypeColumn] = string_LogType;
                dataRow_NewRecord[eventsLogDataTable_obj.DescriptionColumn] = string_LogDescription;
                dataRow_NewRecord[eventsLogDataTable_obj.EventIDColumn] = 0;
                dataRow_NewRecord[eventsLogDataTable_obj.DateColumn] = string_LogDate;
                dataRow_NewRecord[eventsLogDataTable_obj.TimeColumn] = string_LogTime;

                YakSysRctServerV110XMLConfigImporter.YakSysServerDB.EventsLog.Rows.Add(dataRow_NewRecord);

            }

            public void RemotingWrapper_InsertDataToLog(string string_LogType, string string_LogDate, string string_LogTime,
                                                        string string_LogSource, string string_LogDescription)
            {
                YakSysServerLog.InsertDataToLog(string_LogType, string_LogDate, string_LogTime, string_LogSource, string_LogDescription);
            }
        }
    }
}