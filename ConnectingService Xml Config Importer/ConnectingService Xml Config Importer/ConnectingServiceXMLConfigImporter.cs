using System;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;
using YakSys;
using YakSys.ConnectingServiceXMLConfigImporter;
using YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingService;
using YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingService.Version10;


//DataSet_ConnectingServiceDB.xsd

namespace YakSys
{
    namespace ConnectingServiceXMLConfigImporter
    {
        public class YakSysConnectingServiceDBEnvironment : MarshalByRefObject
        {
            public class ClientsSecurityDataBase : MarshalByRefObject
            {
                string string_FirstName = String.Empty;
                public string FirstName
                {
                    set
                    {
                        string_FirstName = value;
                    }
                    get
                    {
                        return string_FirstName;
                    }

                }

                string string_SecondName = String.Empty;
                public string SecondName
                {
                    set
                    {
                        string_SecondName = value;
                    }
                    get
                    {
                        return string_SecondName;
                    }

                }

                string string_LastName = String.Empty;
                public string LastName
                {
                    set
                    {
                        string_LastName = value;
                    }
                    get
                    {
                        return string_LastName;
                    }

                }

                string string_ICQ = String.Empty;
                public string ICQ
                {
                    set
                    {
                        string_ICQ = value;
                    }
                    get
                    {
                        return string_ICQ;
                    }

                }

                string string_EMail = String.Empty;
                public string EMail
                {
                    set
                    {
                        string_EMail = value;
                    }
                    get
                    {
                        return string_EMail;
                    }

                }

                string string_Work = String.Empty;
                public string Work
                {
                    set
                    {
                        string_Work = value;
                    }
                    get
                    {
                        return string_Work;
                    }

                }

                string string_HomePhone = String.Empty;
                public string HomePhone
                {
                    set
                    {
                        string_HomePhone = value;
                    }
                    get
                    {
                        return string_HomePhone;
                    }
                }

                string string_WorkPhone = String.Empty;
                public string WorkPhone
                {
                    set
                    {
                        string_WorkPhone = value;
                    }
                    get
                    {
                        return string_WorkPhone;
                    }
                }

                string string_MobilePhone = String.Empty;
                public string MobilePhone
                {
                    set
                    {
                        string_MobilePhone = value;
                    }
                    get
                    {
                        return string_MobilePhone;
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

                string string_User = String.Empty;
                public string User
                {
                    get
                    {
                        return string_User;
                    }

                    set
                    {
                        string_User = value;
                    }
                }

                string string_Password = String.Empty;
                public string Password
                {
                    set
                    {
                        string_Password = value;
                    }
                    get
                    {
                        return string_Password;
                    }

                }

                string string_UIN = String.Empty;
                public string UIN
                {
                    get
                    {
                        return string_UIN;
                    }

                    set
                    {
                        string_UIN = value;
                    }
                }

                int int_PermissionLevel = 0;
                public int PermissionLevel
                {
                    get
                    {
                        return int_PermissionLevel;
                    }

                    set
                    {
                        int_PermissionLevel = value;
                    }
                }

                ulong ulong_ActivationCode = 0;
                public ulong ActivationCode
                {
                    get
                    {
                        return ulong_ActivationCode;
                    }

                    set
                    {
                        ulong_ActivationCode = value;
                    }
                }

                bool bool_IsEnabled = false;
                public bool IsEnabled
                {
                    set
                    {
                        bool_IsEnabled = value;
                    }

                    get
                    {
                        return bool_IsEnabled;
                    }
                }

                bool bool_IsActivated = false;
                public bool IsActivated
                {
                    set
                    {
                        bool_IsActivated = value;
                    }

                    get
                    {
                        return bool_IsActivated;
                    }
                }

                DateTime dateTime_CreationTime = new DateTime();
                public DateTime CreationTime
                {
                    get
                    {
                        return dateTime_CreationTime;
                    }

                    set
                    {
                        dateTime_CreationTime = value;
                    }
                }

                DateTime dateTime_ActivationTime = new DateTime();
                public DateTime ActivationTime
                {
                    get
                    {
                        return dateTime_ActivationTime;
                    }

                    set
                    {
                        dateTime_ActivationTime = value;
                    }
                }
            }

            public class ClientsAccessRestrictionRule : MarshalByRefObject
            {
                IPAddress iPAddress_IPAddressesRangeStartValue = null;
                IPAddress iPAddress_IPAddressesRangeEndValue = null;
                IPAddress iPAddress_IPAddress = null;

                string string_IPAddressesRangeStartValueText = string.Empty, string_IPAddressesRangeEndValueText = string.Empty,
                       string_IPAddressText = string.Empty, string_MACAddress = string.Empty, string_IPAddressesRangeValueText = string.Empty,
                       string_RuleTypeStringRepresentation = string.Empty;

                bool bool_ComplementaryUseMACAddress, bool_IsRuleEnabled;

                int int_RuleTypeIndex = 0;

                DateTime dateTime_CreationTime;



                public IPAddress IPAddressesRangeStartValue
                {
                    get
                    {
                        return iPAddress_IPAddressesRangeStartValue;
                    }

                    set
                    {
                        iPAddress_IPAddressesRangeStartValue = value;
                    }
                }

                public IPAddress IPAddressesRangeEndValue
                {
                    get
                    {
                        return iPAddress_IPAddressesRangeEndValue;
                    }

                    set
                    {
                        iPAddress_IPAddressesRangeEndValue = value;
                    }
                }

                public IPAddress IPAddress
                {
                    get
                    {
                        return iPAddress_IPAddress;
                    }

                    set
                    {
                        iPAddress_IPAddress = value;
                    }
                }


                public string IPAddressesRangeStartValueText
                {
                    get
                    {
                        return string_IPAddressesRangeStartValueText;
                    }

                    set
                    {
                        string_IPAddressesRangeStartValueText = value;
                    }
                }

                public string IPAddressesRangeEndValueText
                {
                    get
                    {
                        return string_IPAddressesRangeEndValueText;
                    }

                    set
                    {
                        string_IPAddressesRangeEndValueText = value;
                    }
                }

                public string IPAddressText
                {
                    get
                    {
                        return string_IPAddressText;
                    }

                    set
                    {
                        string_IPAddressText = value;
                    }
                }

                public string MACAddress
                {
                    get
                    {
                        return string_MACAddress;
                    }

                    set
                    {
                        string_MACAddress = value;
                    }
                }

                public string IPAddressesRangeValueText
                {
                    get
                    {
                        return string_IPAddressesRangeValueText;
                    }

                    set
                    {
                        string_IPAddressesRangeValueText = value;
                    }
                }

                public string RuleTypeStringRepresentation
                {
                    get
                    {
                        return string_RuleTypeStringRepresentation;
                    }

                    set
                    {
                        string_RuleTypeStringRepresentation = value;
                    }
                }

                public bool ComplementaryUseMACAddress
                {
                    get
                    {
                        return bool_ComplementaryUseMACAddress;
                    }

                    set
                    {
                        bool_ComplementaryUseMACAddress = value;
                    }
                }

                public bool IsRuleEnabled
                {
                    get
                    {
                        return bool_IsRuleEnabled;
                    }

                    set
                    {
                        bool_IsRuleEnabled = value;
                    }
                }

                public int RuleTypeIndex
                {
                    get
                    {
                        return int_RuleTypeIndex;
                    }

                    set
                    {
                        int_RuleTypeIndex = value;
                    }
                }

                public DateTime CreationTime
                {
                    get
                    {
                        return dateTime_CreationTime;
                    }

                    set
                    {
                        dateTime_CreationTime = value;
                    }
                }
            }

            public ClientsSecurityDataBase[] GetClientsSecurityDataBase()
            {
                if (YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsSecurityDataBase.Rows.Count < 0) return new ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ClientsSecurityDataBase[0];

                DataRow dataRow_NewRecord = null;

                YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable ClientsSecurityDataBaseDataTable_obj = YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsSecurityDataBase;

                /////////////////////////////////////////

                ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ClientsSecurityDataBase[] ClientsSecurityDataBaseArray_obj = new ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ClientsSecurityDataBase[ClientsSecurityDataBaseDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != ClientsSecurityDataBaseDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsSecurityDataBase.Rows[int_CycleCount];

                    ClientsSecurityDataBaseArray_obj[int_CycleCount] = new ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ClientsSecurityDataBase();

                    ClientsSecurityDataBaseArray_obj[int_CycleCount].User = (string)dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.UserNameColumn];
                    ClientsSecurityDataBaseArray_obj[int_CycleCount].UIN = (string)dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.UINColumn];
                    ClientsSecurityDataBaseArray_obj[int_CycleCount].Password = (string)dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.UserPasswordColumn];

                    ClientsSecurityDataBaseArray_obj[int_CycleCount].CreationTime = (DateTime)dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.CreationTimeColumn];

                    ClientsSecurityDataBaseArray_obj[int_CycleCount].IsEnabled = (bool)dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.EnabledAccountStateColumn];
                    ClientsSecurityDataBaseArray_obj[int_CycleCount].IsActivated = (bool)dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.IsActivatedColumn];
                }

                return ClientsSecurityDataBaseArray_obj;
            }

            public ClientsAccessRestrictionRule[] GetClientsAccessRestrictionRules()
            {
                if (YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.Count < 0) return new ClientsAccessRestrictionRule[0];

                DataRow dataRow_NewRecord = null;

                YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable ClientsAccessRestrictionRulesDataTable_obj = YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsAccessRestrictionRules;

                ////////////////////////////////////////////////////////////////////////////////

                ClientsAccessRestrictionRule[] accessRestrictionRuleArray_obj = new ClientsAccessRestrictionRule[ClientsAccessRestrictionRulesDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != ClientsAccessRestrictionRulesDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsAccessRestrictionRules.Rows[int_CycleCount];

                    accessRestrictionRuleArray_obj[int_CycleCount] = new ClientsAccessRestrictionRule();

                    accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValueText = (string)dataRow_NewRecord[ClientsAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
                    accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValueText = (string)dataRow_NewRecord[ClientsAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].IPAddressText = (string)dataRow_NewRecord[ClientsAccessRestrictionRulesDataTable_obj.IPAddressColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].MACAddress = (string)dataRow_NewRecord[ClientsAccessRestrictionRulesDataTable_obj.MACAddressColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].CreationTime = (DateTime)dataRow_NewRecord[ClientsAccessRestrictionRulesDataTable_obj.CreationTimeColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].ComplementaryUseMACAddress = (bool)dataRow_NewRecord[ClientsAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeIndex = (int)dataRow_NewRecord[ClientsAccessRestrictionRulesDataTable_obj.RuleTypeColumn];

                    if (accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValueText != string.Empty && accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValueText != string.Empty)
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValue = IPAddress.Parse(accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValueText);

                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValue = IPAddress.Parse(accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValueText);

                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeValueText = accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValue + " - " + accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValue;
                    }

                    if (accessRestrictionRuleArray_obj[int_CycleCount].IPAddressText != string.Empty)
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddress = IPAddress.Parse(accessRestrictionRuleArray_obj[int_CycleCount].IPAddressText);
                    }

                    if (accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeIndex == 0)
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeStringRepresentation = CSStringFactory.GetString(197, CSSettingsEnvironment.CurrentLanguage);
                    }

                    else
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeStringRepresentation = CSStringFactory.GetString(198, CSSettingsEnvironment.CurrentLanguage);
                    }

                    accessRestrictionRuleArray_obj[int_CycleCount].IsRuleEnabled = (bool)dataRow_NewRecord[ClientsAccessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn];
                }

                return accessRestrictionRuleArray_obj;

            }


            public void RemoveClientsSecurityDataBaseRow(int int_RowIndex)
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsSecurityDataBase.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveClientsAccessRestrictionRulesDataBaseRow(int int_RowIndex)
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveClientsEventsLogDataBaseRow(int int_RowIndex)
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsEventsLog.Rows.RemoveAt(int_RowIndex);
            }


            public static void ClearClientsSecurityDataBase()
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsSecurityDataBase.Rows.Clear();
            }

            public static void ClearClientsAccessRestrictionRulesDataBase()
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.Clear();
            }

            public static void ClearClientsEventsLogDataBase()
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ClientsEventsLog.Rows.Clear();
            }


            public class ServersSecurityDataBase : MarshalByRefObject
            {
                string string_FirstName = String.Empty;
                public string FirstName
                {
                    set
                    {
                        string_FirstName = value;
                    }
                    get
                    {
                        return string_FirstName;
                    }

                }

                string string_SecondName = String.Empty;
                public string SecondName
                {
                    set
                    {
                        string_SecondName = value;
                    }
                    get
                    {
                        return string_SecondName;
                    }

                }

                string string_LastName = String.Empty;
                public string LastName
                {
                    set
                    {
                        string_LastName = value;
                    }
                    get
                    {
                        return string_LastName;
                    }

                }

                string string_ICQ = String.Empty;
                public string ICQ
                {
                    set
                    {
                        string_ICQ = value;
                    }
                    get
                    {
                        return string_ICQ;
                    }

                }

                string string_EMail = String.Empty;
                public string EMail
                {
                    set
                    {
                        string_EMail = value;
                    }
                    get
                    {
                        return string_EMail;
                    }

                }

                string string_Work = String.Empty;
                public string Work
                {
                    set
                    {
                        string_Work = value;
                    }
                    get
                    {
                        return string_Work;
                    }

                }

                string string_HomePhone = String.Empty;
                public string HomePhone
                {
                    set
                    {
                        string_HomePhone = value;
                    }
                    get
                    {
                        return string_HomePhone;
                    }
                }

                string string_WorkPhone = String.Empty;
                public string WorkPhone
                {
                    set
                    {
                        string_WorkPhone = value;
                    }
                    get
                    {
                        return string_WorkPhone;
                    }
                }

                string string_MobilePhone = String.Empty;
                public string MobilePhone
                {
                    set
                    {
                        string_MobilePhone = value;
                    }
                    get
                    {
                        return string_MobilePhone;
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

                string string_User = String.Empty;
                public string User
                {
                    get
                    {
                        return string_User;
                    }

                    set
                    {
                        string_User = value;
                    }
                }

                string string_Password = String.Empty;
                public string Password
                {
                    set
                    {
                        string_Password = value;
                    }
                    get
                    {
                        return string_Password;
                    }

                }

                string string_UIN = String.Empty;
                public string UIN
                {
                    get
                    {
                        return string_UIN;
                    }

                    set
                    {
                        string_UIN = value;
                    }
                }

                int int_PermissionLevel = 0;
                public int PermissionLevel
                {
                    get
                    {
                        return int_PermissionLevel;
                    }

                    set
                    {
                        int_PermissionLevel = value;
                    }
                }

                ulong ulong_ActivationCode = 0;
                public ulong ActivationCode
                {
                    get
                    {
                        return ulong_ActivationCode;
                    }

                    set
                    {
                        ulong_ActivationCode = value;
                    }
                }

                bool bool_IsEnabled = false;
                public bool IsEnabled
                {
                    set
                    {
                        bool_IsEnabled = value;
                    }

                    get
                    {
                        return bool_IsEnabled;
                    }
                }

                bool bool_IsActivated = false;
                public bool IsActivated
                {
                    set
                    {
                        bool_IsActivated = value;
                    }

                    get
                    {
                        return bool_IsActivated;
                    }
                }

                DateTime dateTime_CreationTime = new DateTime();
                public DateTime CreationTime
                {
                    get
                    {
                        return dateTime_CreationTime;
                    }

                    set
                    {
                        dateTime_CreationTime = value;
                    }
                }

                DateTime dateTime_ActivationTime = new DateTime();
                public DateTime ActivationTime
                {
                    get
                    {
                        return dateTime_ActivationTime;
                    }

                    set
                    {
                        dateTime_ActivationTime = value;
                    }
                }
            }

            public class ServersAccessRestrictionRule : MarshalByRefObject
            {
                IPAddress iPAddress_IPAddressesRangeStartValue = null;
                IPAddress iPAddress_IPAddressesRangeEndValue = null;
                IPAddress iPAddress_IPAddress = null;

                string string_IPAddressesRangeStartValueText = string.Empty, string_IPAddressesRangeEndValueText = string.Empty,
                       string_IPAddressText = string.Empty, string_MACAddress = string.Empty, string_IPAddressesRangeValueText = string.Empty,
                       string_RuleTypeStringRepresentation = string.Empty;

                bool bool_ComplementaryUseMACAddress, bool_IsRuleEnabled;

                int int_RuleTypeIndex = 0;

                DateTime dateTime_CreationTime;



                public IPAddress IPAddressesRangeStartValue
                {
                    get
                    {
                        return iPAddress_IPAddressesRangeStartValue;
                    }

                    set
                    {
                        iPAddress_IPAddressesRangeStartValue = value;
                    }
                }

                public IPAddress IPAddressesRangeEndValue
                {
                    get
                    {
                        return iPAddress_IPAddressesRangeEndValue;
                    }

                    set
                    {
                        iPAddress_IPAddressesRangeEndValue = value;
                    }
                }

                public IPAddress IPAddress
                {
                    get
                    {
                        return iPAddress_IPAddress;
                    }

                    set
                    {
                        iPAddress_IPAddress = value;
                    }
                }


                public string IPAddressesRangeStartValueText
                {
                    get
                    {
                        return string_IPAddressesRangeStartValueText;
                    }

                    set
                    {
                        string_IPAddressesRangeStartValueText = value;
                    }
                }

                public string IPAddressesRangeEndValueText
                {
                    get
                    {
                        return string_IPAddressesRangeEndValueText;
                    }

                    set
                    {
                        string_IPAddressesRangeEndValueText = value;
                    }
                }

                public string IPAddressText
                {
                    get
                    {
                        return string_IPAddressText;
                    }

                    set
                    {
                        string_IPAddressText = value;
                    }
                }

                public string MACAddress
                {
                    get
                    {
                        return string_MACAddress;
                    }

                    set
                    {
                        string_MACAddress = value;
                    }
                }

                public string IPAddressesRangeValueText
                {
                    get
                    {
                        return string_IPAddressesRangeValueText;
                    }

                    set
                    {
                        string_IPAddressesRangeValueText = value;
                    }
                }

                public string RuleTypeStringRepresentation
                {
                    get
                    {
                        return string_RuleTypeStringRepresentation;
                    }

                    set
                    {
                        string_RuleTypeStringRepresentation = value;
                    }
                }

                public bool ComplementaryUseMACAddress
                {
                    get
                    {
                        return bool_ComplementaryUseMACAddress;
                    }

                    set
                    {
                        bool_ComplementaryUseMACAddress = value;
                    }
                }

                public bool IsRuleEnabled
                {
                    get
                    {
                        return bool_IsRuleEnabled;
                    }

                    set
                    {
                        bool_IsRuleEnabled = value;
                    }
                }

                public int RuleTypeIndex
                {
                    get
                    {
                        return int_RuleTypeIndex;
                    }

                    set
                    {
                        int_RuleTypeIndex = value;
                    }
                }

                public DateTime CreationTime
                {
                    get
                    {
                        return dateTime_CreationTime;
                    }

                    set
                    {
                        dateTime_CreationTime = value;
                    }
                }
            }

            public ServersSecurityDataBase[] GetServersSecurityDataBase()
            {
                if (YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersSecurityDataBase.Rows.Count < 0) return new ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ServersSecurityDataBase[0];

                DataRow dataRow_NewRecord = null;

                YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable securityDataBaseDataTable_obj = YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersSecurityDataBase;

                /////////////////////////////////////////

                ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ServersSecurityDataBase[] securityDataBaseArray_obj = new ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ServersSecurityDataBase[securityDataBaseDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != securityDataBaseDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersSecurityDataBase.Rows[int_CycleCount];

                    securityDataBaseArray_obj[int_CycleCount] = new ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ServersSecurityDataBase();

                    securityDataBaseArray_obj[int_CycleCount].User = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserNameColumn];
                    securityDataBaseArray_obj[int_CycleCount].UIN = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UINColumn];
                    securityDataBaseArray_obj[int_CycleCount].Password = (string)dataRow_NewRecord[securityDataBaseDataTable_obj.UserPasswordColumn];

                    securityDataBaseArray_obj[int_CycleCount].CreationTime = (DateTime)dataRow_NewRecord[securityDataBaseDataTable_obj.CreationTimeColumn];

                    securityDataBaseArray_obj[int_CycleCount].IsEnabled = (bool)dataRow_NewRecord[securityDataBaseDataTable_obj.EnabledAccountStateColumn];
                    securityDataBaseArray_obj[int_CycleCount].IsActivated = (bool)dataRow_NewRecord[securityDataBaseDataTable_obj.IsActivatedColumn];
                }

                return securityDataBaseArray_obj;
            }

            public ServersAccessRestrictionRule[] GetServersAccessRestrictionRules()
            {
                if (YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.Count < 0) return new ServersAccessRestrictionRule[0];

                DataRow dataRow_NewRecord = null;

                YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersAccessRestrictionRules;

                ////////////////////////////////////////////////////////////////////////////////

                ServersAccessRestrictionRule[] accessRestrictionRuleArray_obj = new ServersAccessRestrictionRule[accessRestrictionRulesDataTable_obj.Rows.Count];

                for (int int_CycleCount = 0; int_CycleCount != accessRestrictionRulesDataTable_obj.Rows.Count; int_CycleCount++)
                {
                    dataRow_NewRecord = YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersAccessRestrictionRules.Rows[int_CycleCount];

                    accessRestrictionRuleArray_obj[int_CycleCount] = new ServersAccessRestrictionRule();

                    accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValueText = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
                    accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValueText = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].IPAddressText = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPAddressColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].MACAddress = (string)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.MACAddressColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].CreationTime = (DateTime)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.CreationTimeColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].ComplementaryUseMACAddress = (bool)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

                    accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeIndex = (int)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.RuleTypeColumn];

                    if (accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValueText != string.Empty && accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValueText != string.Empty)
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValue = IPAddress.Parse(accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValueText);

                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValue = IPAddress.Parse(accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValueText);

                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeValueText = accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeStartValue + " - " + accessRestrictionRuleArray_obj[int_CycleCount].IPAddressesRangeEndValue;
                    }

                    if (accessRestrictionRuleArray_obj[int_CycleCount].IPAddressText != string.Empty)
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].IPAddress = IPAddress.Parse(accessRestrictionRuleArray_obj[int_CycleCount].IPAddressText);
                    }

                    if (accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeIndex == 0)
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeStringRepresentation = CSStringFactory.GetString(197, CSSettingsEnvironment.CurrentLanguage);
                    }

                    else
                    {
                        accessRestrictionRuleArray_obj[int_CycleCount].RuleTypeStringRepresentation = CSStringFactory.GetString(198, CSSettingsEnvironment.CurrentLanguage);
                    }

                    accessRestrictionRuleArray_obj[int_CycleCount].IsRuleEnabled = (bool)dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn];
                }

                return accessRestrictionRuleArray_obj;

            }


            public void RemoveServersSecurityDataBaseRow(int int_RowIndex)
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersSecurityDataBase.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveServersAccessRestrictionRulesDataBaseRow(int int_RowIndex)
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.RemoveAt(int_RowIndex);
            }

            public void RemoveServersEventsLogDataBaseRow(int int_RowIndex)
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersEventsLog.Rows.RemoveAt(int_RowIndex);
            }


            public static void ClearServersSecurityDataBase()
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersSecurityDataBase.Rows.Clear();
            }

            public static void ClearServersAccessRestrictionRulesDataBase()
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.Clear();
            }

            static public void ClearServersEventsLogDataBase()
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.ServersEventsLog.Rows.Clear();
            }

            public static void ClearCommonEventsLog()
            {
                YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.CommonEventsLog.Rows.Clear();
            }

        }

        namespace YakSysConnectingService
        {
            namespace Version10
            {
                public class YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter
                {
                    static YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB dataSet_ConnectingServiceDB = new YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB();
                    public static YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB ConnectingServiceDB
                    {
                        get
                        {
                            return dataSet_ConnectingServiceDB;
                        }

                        set
                        {
                            dataSet_ConnectingServiceDB = value;
                        }
                    }

                    static string string_DBVersion = string.Empty;
                    public static string DBVersion
                    {
                        get
                        {
                            return string_DBVersion;
                        }

                        set
                        {
                            string_DBVersion = value;
                        }
                    }


                    public static MemoryStream DecompressXMLDataFile(string string_XMLFilePath)
                    {
                        FileStream fileStream_ConnectingServiceXMLDB = null;

                        try
                        {
                            if (File.Exists(string_XMLFilePath) == false) return null;

                            MemoryStream memoryStream_XMLData = new MemoryStream();

                            fileStream_ConnectingServiceXMLDB = File.Open(string_XMLFilePath, FileMode.Open, FileAccess.Read);

                            byte[] byteArray_DecompressedXMLData = null,
                                byteArray_CompressedXMLData = new byte[fileStream_ConnectingServiceXMLDB.Length - 88];// 88 is a meta data length in bytes

                            fileStream_ConnectingServiceXMLDB.Position = 88;

                            fileStream_ConnectingServiceXMLDB.Read(byteArray_CompressedXMLData, 0, byteArray_CompressedXMLData.Length);

                            byteArray_DecompressedXMLData = new YakSys.Compression.CommonEnvironment().Decompress(byteArray_CompressedXMLData, false);

                            memoryStream_XMLData = new MemoryStream(byteArray_DecompressedXMLData);

                            return memoryStream_XMLData;
                        }

                        catch (Exception exception)
                        {
                            return null;
                        }

                        finally
                        {
                            fileStream_ConnectingServiceXMLDB.Close();
                        }
                    }



                    public void WriteXMLDataToFile(string string_XMLFilePath)
                    {
                        FileStream fileStream_ServerDB = File.Create(string_XMLFilePath);

                        MemoryStream memoryStream_XMLData = new MemoryStream(),
                            memoryStream_EncryptedXMLData = new MemoryStream();

                        SHA256Managed sHA256Managed_obj = new SHA256Managed();

                        RijndaelManaged rijndaelManaged_obj = new RijndaelManaged();

                        CryptoStream cryptoStream_obj = null;

                        byte[] byteArray_ComputedXMLDataHash = new byte[32], byteArray_PasswordHash = new byte[32],
                                byteArray_EncryptedData = null, byteArray_CompressedXMLData,
                                byteArray_HashOfPasswordHash = new byte[32];

                        byte byte_ToEncryptServerDataBase = 0, byte_ToCompressSettingsDataBase = 0;

                        ConnectingServiceDB.WriteXml(memoryStream_XMLData);


                        if (CSSettingsEnvironment.EncryptSettingsDataBase == true) byte_ToEncryptServerDataBase = 1;
                        if (CSSettingsEnvironment.CompressSettingsDataBase == true) byte_ToCompressSettingsDataBase = 1;


                        if (CSSettingsEnvironment.CompressSettingsDataBase == true)
                        {
                            YakSys.Compression.LZSS LZSS_obj = new YakSys.Compression.LZSS(16, true, true, false, 65536);

                            byteArray_CompressedXMLData = LZSS_obj.Compress(memoryStream_XMLData.ToArray(), false);

                            memoryStream_XMLData = new MemoryStream(byteArray_CompressedXMLData);
                        }

                        byteArray_ComputedXMLDataHash = sHA256Managed_obj.ComputeHash(memoryStream_XMLData);

                        if (CSSettingsEnvironment.LocalSecurityPassword.Length > 5 && CSSettingsEnvironment.EncryptSettingsDataBase == true)
                        {
                            byteArray_PasswordHash = sHA256Managed_obj.ComputeHash(System.Text.Encoding.Default.GetBytes(CSSettingsEnvironment.LocalSecurityPassword));
                            byteArray_HashOfPasswordHash = sHA256Managed_obj.ComputeHash(byteArray_PasswordHash);

                            rijndaelManaged_obj.KeySize = 256;

                            rijndaelManaged_obj.Key = byteArray_PasswordHash;
                            rijndaelManaged_obj.IV = new byte[rijndaelManaged_obj.BlockSize / 8];

                            cryptoStream_obj = new CryptoStream(memoryStream_EncryptedXMLData, rijndaelManaged_obj.CreateEncryptor(), CryptoStreamMode.Write);

                            cryptoStream_obj.Write(memoryStream_XMLData.ToArray(), 0, memoryStream_XMLData.ToArray().Length);

                            memoryStream_XMLData.SetLength(0);

                            cryptoStream_obj.FlushFinalBlock();

                            byteArray_EncryptedData = memoryStream_EncryptedXMLData.ToArray();

                            cryptoStream_obj.Close();

                            memoryStream_XMLData = new MemoryStream(byteArray_EncryptedData);
                        }

                        fileStream_ServerDB.Write(System.Text.Encoding.Default.GetBytes("ConnectingServiceDB010"), 0, System.Text.Encoding.Default.GetBytes("ConnectingServiceDB010").Length);

                        fileStream_ServerDB.WriteByte(byte_ToEncryptServerDataBase);
                        fileStream_ServerDB.WriteByte(byte_ToCompressSettingsDataBase);

                        fileStream_ServerDB.Write(byteArray_ComputedXMLDataHash, 0, byteArray_ComputedXMLDataHash.Length);
                        fileStream_ServerDB.Write(byteArray_HashOfPasswordHash, 0, byteArray_HashOfPasswordHash.Length);


                        fileStream_ServerDB.Write(memoryStream_XMLData.ToArray(), 0, memoryStream_XMLData.ToArray().Length);

                        fileStream_ServerDB.Close();
                    }

                    public void InitMainServerXmlDB()
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.MainSettingsDataTable mainSettingsDataTable_obj = ConnectingServiceDB.MainSettings;

                            ConnectingServiceDB.MainSettings.Clear();

                            dataRow_NewRecord = ConnectingServiceDB.MainSettings.NewRow();

                            dataRow_NewRecord.ItemArray.Initialize();

                            dataRow_NewRecord[mainSettingsDataTable_obj.IDColumn] = 0;

                            dataRow_NewRecord[mainSettingsDataTable_obj.ServerPortColumn] = 5545;

                            dataRow_NewRecord[mainSettingsDataTable_obj.AppVersionColumn] = "0.1.0";

                            dataRow_NewRecord[mainSettingsDataTable_obj.ShowToolTipsColumn] = true;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ShowAdvancedSettingsColumn] = false;

                            dataRow_NewRecord[mainSettingsDataTable_obj.AutoRunColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.StartServerAtRunColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.MinimizeToNotifyAreaAtRunColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ShowIconInNotifyAreaColumn] = true;

                            dataRow_NewRecord[mainSettingsDataTable_obj.MaxConnectionsColumn] = 255;
                            dataRow_NewRecord[mainSettingsDataTable_obj.MaxConnectionPerAccountColumn] = 255;

                            dataRow_NewRecord[mainSettingsDataTable_obj.PromptPasswordAfterUnHideColumn] = false;

                            dataRow_NewRecord[mainSettingsDataTable_obj.IsClientAccessRestrictionRuleEnableColumn] = false;
                            dataRow_NewRecord[mainSettingsDataTable_obj.IsServerAccessRestrictionRuleEnableColumn] = false;

                            dataRow_NewRecord[mainSettingsDataTable_obj.CurrentAppLanguageColumn] = CSSettingsEnvironment.CurrentLanguage;

                            dataRow_NewRecord[mainSettingsDataTable_obj.ActivateHiddenModeAtStartUpColumn] = false;

                            ConnectingServiceDB.MainSettings.Rows.Add(dataRow_NewRecord);

                        }
                        catch (Exception e)
                        {
                            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

                            MessageBox.Show(CSStringFactory.GetString(127, CSSettingsEnvironment.CurrentLanguage), CSStringFactory.GetString(1, CSSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                    public void InitSMTPSettingsXmlDB()
                    {
                        try
                        {
                            ///////////////////////////////////////////////////////////////////////////////////////////////////////

                            DataRow dataRow_NewRecord = null;

                            YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.SMTPSettingsDataTable smtpSettingsDataTable_obj = ConnectingServiceDB.SMTPSettings;

                            ConnectingServiceDB.SMTPSettings.Clear();

                            dataRow_NewRecord = ConnectingServiceDB.SMTPSettings.NewRow();

                            dataRow_NewRecord.ItemArray.Initialize();

                            dataRow_NewRecord[smtpSettingsDataTable_obj.IDColumn] = 0;

                            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_ServerColumn] = string.Empty;
                            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_PortColumn] = 25;

                            dataRow_NewRecord[smtpSettingsDataTable_obj.SenderMailAddressColumn] = string.Empty;

                            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_LoginColumn] = string.Empty;
                            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_PasswordColumn] = string.Empty;

                            ConnectingServiceDB.SMTPSettings.Rows.Add(dataRow_NewRecord);

                            ///////////////////////////////////////////////////////////////////////////////////////////////////////
                        }
                        catch (Exception e)
                        {
                            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

                            MessageBox.Show(CSStringFactory.GetString(127, CSSettingsEnvironment.CurrentLanguage), CSStringFactory.GetString(1, CSSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }


                    public void ApplyDBSettings()
                    {
                        if (ConnectingServiceDB.Tables["MainSettings"].Rows.Count < 1 || ConnectingServiceDB.Tables["SMTPSettings"].Rows.Count < 1)
                        {
                            InitMainServerXmlDB();

                            InitSMTPSettingsXmlDB();

                            ApplyDBSettings();
                        }


                        if (ConnectingServiceDB.Tables["MainSettings"].Rows.Count < 1 || ConnectingServiceDB.Tables["SMTPSettings"].Rows.Count < 1) return;


                        ///////////////////////////////////////////////////////////////////////////////////////////////////////

                        YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.MainSettingsDataTable mainSettingsDataTable_obj = ConnectingServiceDB.MainSettings;

                        CSSettingsEnvironment.ServerPort = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ServerPortColumn];

                        CSSettingsEnvironment.AppVersion = (string)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.AppVersionColumn];

                        CSSettingsEnvironment.ShowToolTips = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowToolTipsColumn];
                        CSSettingsEnvironment.ShowAdvancedSettings = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowAdvancedSettingsColumn];

                        CSSettingsEnvironment.AutoRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.AutoRunColumn];
                        CSSettingsEnvironment.StartServerAtRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.StartServerAtRunColumn];
                        CSSettingsEnvironment.MinimizeToNotifyAreaAtRun = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.MinimizeToNotifyAreaAtRunColumn];
                        CSSettingsEnvironment.ShowIconInNotifyArea = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ShowIconInNotifyAreaColumn];

                        CSSettingsEnvironment.MaxConnections = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.MaxConnectionsColumn];

                        CSSettingsEnvironment.MaxConnectionsPerAccount = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.MaxConnectionPerAccountColumn];

                        CSSettingsEnvironment.IsServerAccessRestrictionRuleEnable = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.IsServerAccessRestrictionRuleEnableColumn];
                        CSSettingsEnvironment.IsClientAccessRestrictionRuleEnable = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.IsClientAccessRestrictionRuleEnableColumn];

                        CSSettingsEnvironment.ActivateHiddenModeAtStartUp = (bool)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.ActivateHiddenModeAtStartUpColumn];

                        CSSettingsEnvironment.CurrentLanguage = (int)mainSettingsDataTable_obj.Rows[0][mainSettingsDataTable_obj.CurrentAppLanguageColumn];

                        ///////////////////////////////////////////////////////////////////////////////////////////////////////

                        YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.SMTPSettingsDataTable smtpSettingsDataTable_obj = ConnectingServiceDB.SMTPSettings;

                        if (smtpSettingsDataTable_obj.Rows.Count < 1)
                        {
                            InitSMTPSettingsXmlDB();
                        }

                        CSSettingsEnvironment.SMTPLogin = (string)smtpSettingsDataTable_obj.Rows[0][smtpSettingsDataTable_obj.SMTP_LoginColumn];
                        CSSettingsEnvironment.SMTPPassword = (string)smtpSettingsDataTable_obj.Rows[0][smtpSettingsDataTable_obj.SMTP_PasswordColumn];

                        CSSettingsEnvironment.SMTPServer = (string)smtpSettingsDataTable_obj.Rows[0][smtpSettingsDataTable_obj.SMTP_ServerColumn];
                        CSSettingsEnvironment.SenderMailAddress = (string)smtpSettingsDataTable_obj.Rows[0][smtpSettingsDataTable_obj.SenderMailAddressColumn];

                        CSSettingsEnvironment.SMTPPort = (int)smtpSettingsDataTable_obj.Rows[0][smtpSettingsDataTable_obj.SMTP_PortColumn];
                    }

                    public void RetriveServerSettingsData(MemoryStream memoryStream_XMLData)
                    {
                        try
                        {
                            YakSysConnectingServiceV10ConnectingServiceXMLConfigImporter.ConnectingServiceDB.Clear();

                            ConnectingServiceDB.ReadXml(memoryStream_XMLData);
                        }
                        catch (Exception)
                        {
                            InitMainServerXmlDB();

                            MessageBox.Show(CSStringFactory.GetString(127, CSSettingsEnvironment.CurrentLanguage), CSStringFactory.GetString(1, CSSettingsEnvironment.CurrentLanguage));

                            return;
                        }

                        try
                        {
                            ApplyDBSettings();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);//!!!
                            MessageBox.Show(CSStringFactory.GetString(128, CSSettingsEnvironment.CurrentLanguage), CSStringFactory.GetString(1, CSSettingsEnvironment.CurrentLanguage));
                        }
                    }

                    public void WriteServerSettingsData(string string_XMLFilePath)
                    {
                        try
                        {
                            DataRow dataRow_NewRecord = null;

                            YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.MainSettingsDataTable mainSettingsDataTable_obj = ConnectingServiceDB.MainSettings;

                            dataRow_NewRecord = ConnectingServiceDB.MainSettings.Rows[0];

                            dataRow_NewRecord[mainSettingsDataTable_obj.ServerPortColumn] = CSSettingsEnvironment.ServerPort;

                            dataRow_NewRecord[mainSettingsDataTable_obj.AppVersionColumn] = CSSettingsEnvironment.AppVersion;

                            dataRow_NewRecord[mainSettingsDataTable_obj.ShowToolTipsColumn] = CSSettingsEnvironment.ShowToolTips;

                            dataRow_NewRecord[mainSettingsDataTable_obj.ShowAdvancedSettingsColumn] = CSSettingsEnvironment.ShowAdvancedSettings;

                            dataRow_NewRecord[mainSettingsDataTable_obj.AutoRunColumn] = CSSettingsEnvironment.AutoRun;
                            dataRow_NewRecord[mainSettingsDataTable_obj.StartServerAtRunColumn] = CSSettingsEnvironment.StartServerAtRun;
                            dataRow_NewRecord[mainSettingsDataTable_obj.MinimizeToNotifyAreaAtRunColumn] = CSSettingsEnvironment.MinimizeToNotifyAreaAtRun;
                            dataRow_NewRecord[mainSettingsDataTable_obj.ShowIconInNotifyAreaColumn] = CSSettingsEnvironment.ShowIconInNotifyArea;

                            dataRow_NewRecord[mainSettingsDataTable_obj.MaxConnectionsColumn] = CSSettingsEnvironment.MaxConnections;

                            dataRow_NewRecord[mainSettingsDataTable_obj.IsClientAccessRestrictionRuleEnableColumn] = CSSettingsEnvironment.IsClientAccessRestrictionRuleEnable;
                            dataRow_NewRecord[mainSettingsDataTable_obj.IsServerAccessRestrictionRuleEnableColumn] = CSSettingsEnvironment.IsServerAccessRestrictionRuleEnable;

                            dataRow_NewRecord[mainSettingsDataTable_obj.ActivateHiddenModeAtStartUpColumn] = CSSettingsEnvironment.ActivateHiddenModeAtStartUp;

                            dataRow_NewRecord[mainSettingsDataTable_obj.MaxConnectionPerAccountColumn] = CSSettingsEnvironment.MaxConnectionsPerAccount;

                            dataRow_NewRecord[mainSettingsDataTable_obj.CurrentAppLanguageColumn] = CSSettingsEnvironment.CurrentLanguage;

                            ///////////////////////////////////////////////////////////////////////////////////////////////////////

                            YakSys_Xml_Config_Importer.ConnectingService_DataSet_ver_10.DataSet_ConnectingServiceDB.SMTPSettingsDataTable smtpSettingsDataTable_obj = ConnectingServiceDB.SMTPSettings;

                            if (smtpSettingsDataTable_obj.Rows.Count < 1)
                            {
                                InitSMTPSettingsXmlDB();
                            }

                            dataRow_NewRecord = ConnectingServiceDB.SMTPSettings.Rows[0];

                            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_ServerColumn] = CSSettingsEnvironment.SMTPServer;
                            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_PortColumn] = CSSettingsEnvironment.SMTPPort;

                            dataRow_NewRecord[smtpSettingsDataTable_obj.SenderMailAddressColumn] = CSSettingsEnvironment.SenderMailAddress;

                            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_LoginColumn] = CSSettingsEnvironment.SMTPLogin;
                            dataRow_NewRecord[smtpSettingsDataTable_obj.SMTP_PasswordColumn] = CSSettingsEnvironment.SMTPPassword;

                            ///////////////////////////////////////////////////////////////////////////////////////////////////////

                            WriteXMLDataToFile(string_XMLFilePath);
                        }

                        catch (Exception)
                        {
                            if (File.Exists("ConnectingServiceDB")) File.Delete("ConnectingServiceDB");

                            MessageBox.Show(CSStringFactory.GetString(481, CSSettingsEnvironment.CurrentLanguage), CSStringFactory.GetString(1, CSSettingsEnvironment.CurrentLanguage));

                            return;
                        }
                    }

                }
            }
        }
    }
}