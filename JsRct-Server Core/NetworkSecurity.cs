using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Data;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using YakSys.WMIClassesInfoRetriever.Win32_InstalledApplications;
using YakSys.WMIClassesInfoRetriever.Win32_Hardware;
using YakSys.WMIClassesInfoRetriever.Win32_OS;
using YakSys.WMIClassesInfoRetriever.CIM_Common;
using YakSys.WMIClassesInfoRetriever;
using YakSys.XMLConfigImporter.YakSysRctServer.Version110;
using YakSys.XMLConfigImporter;

namespace YakSys
{
    namespace Server_Core
    {
        [Serializable]
        public class NetworkSecurity : MarshalByRefObject
        {
            public static void LoadSecurityDB(YakSys.XMLConfigImporter.YakSysServerDBEnvironment.SecurityDataBase[] securityDataBaseArray_UsersList)
            {
                for (int int_CycleCount = 0; int_CycleCount != securityDataBaseArray_UsersList.Length; int_CycleCount++)
                {
                    AddNewUser(securityDataBaseArray_UsersList[int_CycleCount].UserName, securityDataBaseArray_UsersList[int_CycleCount].Login, securityDataBaseArray_UsersList[int_CycleCount].Password, securityDataBaseArray_UsersList[int_CycleCount].CreationTime, securityDataBaseArray_UsersList[int_CycleCount].IsAccountEnabled);
                }
            }
            public static void LoadAccessRestrictionRulesDB(YakSys.XMLConfigImporter.YakSysServerDBEnvironment.AccessRestrictionRule[] accessRestrictionRuleArray_RulesList)
            {
                for (int int_CycleCount = 0; int_CycleCount != accessRestrictionRuleArray_RulesList.Length; int_CycleCount++)
                {
                    AddNewAccessRestrictionRule(accessRestrictionRuleArray_RulesList[int_CycleCount].IPAddressesRangeStartValue, accessRestrictionRuleArray_RulesList[int_CycleCount].IPAddressesRangeEndValue, accessRestrictionRuleArray_RulesList[int_CycleCount].IPAddress,
                                accessRestrictionRuleArray_RulesList[int_CycleCount].MACAddress, accessRestrictionRuleArray_RulesList[int_CycleCount].ComplementaryUseMACAddress, accessRestrictionRuleArray_RulesList[int_CycleCount].CreationTime, accessRestrictionRuleArray_RulesList[int_CycleCount].RuleTypeIndex, accessRestrictionRuleArray_RulesList[int_CycleCount].IsRuleEnabled);
                }
            }

            public static void RemoveAccessRestrictionRule(int int_AccessRestrinctionRuleIndex)
            {
                new YakSys.XMLConfigImporter.YakSysServerDBEnvironment().RemoveAccessRestrictionRulesDataBaseRow(int_AccessRestrinctionRuleIndex);

                AccessRestrictionRuleObject.AccessRestrictionRules.RemoveAt(int_AccessRestrinctionRuleIndex);
            }
            public void RemotingWrapper_RemoveAccessRestrictionRule(int int_AccessRestrinctionRuleIndex)
            {
                NetworkSecurity.RemoveAccessRestrictionRule(int_AccessRestrinctionRuleIndex);
            }

            public static bool AddNewUser(string string_UserName, string string_Login, string string_Password, DateTime dateTime_CreationTime, bool bool_IsAccountEnabled)
            {
                UserAccount userAccount_NewUser = new UserAccount();

                userAccount_NewUser.User = string_UserName;

                userAccount_NewUser.Login = string_Login;

                userAccount_NewUser.Password = string_Password;

                userAccount_NewUser.TimeOfCreation = dateTime_CreationTime.ToShortDateString() + "  " + dateTime_CreationTime.ToLongTimeString();

                userAccount_NewUser.IsEnabled = bool_IsAccountEnabled;

                userAccount_NewUser.AccountType = UserAccount.AccountTypesEnum.YakSysAccount;

                NetworkSecurity.UserAccount.UsersAccounts.Add(userAccount_NewUser);

                return true;
            }
            public bool RemotingWrapper_AddNewUser(string string_UserName, string string_Login, string string_Password, DateTime dateTime_CreationTime, bool bool_IsAccountEnabled)
            {
                return NetworkSecurity.AddNewUser(string_UserName, string_Login, string_Password, dateTime_CreationTime, bool_IsAccountEnabled);
            }
            
            public void RemotingWrapper_StoreUserAccountToDB(string string_UserName, string string_Login, string string_Password, string string_FirstName, string string_LastName, string string_MiddleName, string string_EMailAddress, string string_ICQ, string string_Company, string string_WorkPhone, string string_HomePhome, string string_PrivateCellular, DateTime dateTime_CreationTime, bool bool_IsAccountEnabled)
            {
                YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase;

                ////////////////////////////////////////////////////////////////////////////////

                DataRow dataRow_NewRecord = null;

                dataRow_NewRecord = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase.NewRow();

                int int_SecurityDataBaseID = 0;

                for (int int_CycleCount = 0; ; int_CycleCount++)
                {
                    if (securityDataBaseDataTable_obj.Rows.Count == 0) break;

                    if (int_CycleCount >= securityDataBaseDataTable_obj.Rows.Count
                    || (int)securityDataBaseDataTable_obj.Rows[int_CycleCount][securityDataBaseDataTable_obj.IDColumn] == int_SecurityDataBaseID)
                    {
                        int_SecurityDataBaseID++;
                        int_CycleCount = -1;
                        continue;
                    }

                    else if (int_CycleCount + 1 == securityDataBaseDataTable_obj.Rows.Count) break;
                }

                dataRow_NewRecord[securityDataBaseDataTable_obj.IDColumn] = int_SecurityDataBaseID;

                dataRow_NewRecord[securityDataBaseDataTable_obj.UserLoginColumn] = string_Login;
                dataRow_NewRecord[securityDataBaseDataTable_obj.UserNameColumn] = string_UserName;
                dataRow_NewRecord[securityDataBaseDataTable_obj.UserPasswordColumn] = string_Password;
                dataRow_NewRecord[securityDataBaseDataTable_obj.EnabledAccountStateColumn] = bool_IsAccountEnabled;
                dataRow_NewRecord[securityDataBaseDataTable_obj.UserFirstNameColumn] = string_FirstName;
                dataRow_NewRecord[securityDataBaseDataTable_obj.UserLastNameColumn] = string_LastName;
                dataRow_NewRecord[securityDataBaseDataTable_obj.UserMiddleNameColumn] = string_MiddleName;
                dataRow_NewRecord[securityDataBaseDataTable_obj.EMailColumn] = string_EMailAddress;
                dataRow_NewRecord[securityDataBaseDataTable_obj.ICQColumn] = string_ICQ;
                dataRow_NewRecord[securityDataBaseDataTable_obj.CompanyColumn] = string_Company;
                dataRow_NewRecord[securityDataBaseDataTable_obj.WorkPhoneColumn] = string_WorkPhone;
                dataRow_NewRecord[securityDataBaseDataTable_obj.HomePhoneColumn] = string_HomePhome;
                dataRow_NewRecord[securityDataBaseDataTable_obj.PrivateCellularColumn] = string_PrivateCellular;
                dataRow_NewRecord[securityDataBaseDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;

                YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase.Rows.Add(dataRow_NewRecord);

                ////////////////////////////////////////////////////////////////////////////////////////
            }
            
            public static int GetYakSysAccountRealRowIndex(int int_AccountIndex)
            {
                int int_RealDBRowAccountIndex = 0;

                //Calculate real DB Row account index (Windows Accounts not stored in YakSysDB)
                for (int int_CycleCount = 0; int_CycleCount != UserAccount.UsersAccounts.Count; int_CycleCount++)
                {
                    if (UserAccount.UsersAccounts[int_AccountIndex] == UserAccount.UsersAccounts[int_CycleCount])
                    {
                        break;
                    }          
 
                    if (UserAccount.UsersAccounts[int_CycleCount].AccountType != UserAccount.AccountTypesEnum.WindowsAccount)
                    {
                        int_RealDBRowAccountIndex++;
                    }         
                }

                return int_RealDBRowAccountIndex;
            }
            public int RemotingWrapper_GetYakSysAccountRealRowIndex(int int_AccountIndex)
            {
                return NetworkSecurity.GetYakSysAccountRealRowIndex(int_AccountIndex);
            }

            public static void RemoveAccount(int int_AccountIndex)
            {
                YakSysTcpClient YakSysTcpClient_CurrentObj = null;
            
                UserAccount.UsersAccounts[int_AccountIndex].IsEnabled = false;

                for (; 0 != UserAccount.UsersAccounts[int_AccountIndex].ClientsUsingAccount.Count; )
                {
                    YakSysTcpClient_CurrentObj = UserAccount.UsersAccounts[int_AccountIndex].ClientsUsingAccount[0];

                    if (YakSysTcpClient_CurrentObj.RequestToDisconnect == true) continue;

                    ObjCopy.obj_NetworkAction.DisconnectNecessaryClient(YakSysTcpClient_CurrentObj, 3);
                }

                UserAccount.UsersAccounts[int_AccountIndex].DisconnectAllClients();

                new YakSys.XMLConfigImporter.YakSysServerDBEnvironment().RemoveSecurityDataBaseRow(GetYakSysAccountRealRowIndex(int_AccountIndex));

                UserAccount.UsersAccounts.RemoveAt(int_AccountIndex);
            }
            public void RemotingWrapper_RemoveAccount(int int_AccountIndex)
            {
                NetworkSecurity.RemoveAccount(int_AccountIndex);
            }

            public static void ClearAccounts()
            {
                YakSysTcpClient YakSysTcpClient_CurrentObj = null;

                foreach (UserAccount obj_UserAccount in UserAccount.UsersAccounts)
                {
                    if (obj_UserAccount.AccountType != UserAccount.AccountTypesEnum.WindowsAccount)
                    {
                        for (; 0 != obj_UserAccount.ClientsUsingAccount.Count; )
                        {
                            YakSysTcpClient_CurrentObj = obj_UserAccount.ClientsUsingAccount[0];

                            if (YakSysTcpClient_CurrentObj.RequestToDisconnect == true) continue;

                            ObjCopy.obj_NetworkAction.DisconnectNecessaryClient(YakSysTcpClient_CurrentObj, 3);
                        }

                        obj_UserAccount.IsEnabled = false;
                    }
                }

                UserAccount.UsersAccounts.Clear();

                new YakSys.XMLConfigImporter.YakSysServerDBEnvironment().ClearSecurityDataBase();
            }
            public void RemotingWrapper_ClearAccounts()
            {
                NetworkSecurity.ClearAccounts();
            }

            public static void ClearAccessRestrictionRules()
            {
                AccessRestrictionRuleObject.AccessRestrictionRules.Clear();

                new YakSys.XMLConfigImporter.YakSysServerDBEnvironment().ClearAccessRestrictionRulesDataBase();
            }
            public void RemotingWrapper_ClearAccessRestrictionRules()
            {
                NetworkSecurity.ClearAccessRestrictionRules();
            }

            static void EditUserAccountInDB(string string_FirstName, string string_LastName, string string_MiddleName, string string_EMailAddress, string string_ICQ, string string_Company, string string_WorkPhone, string string_HomePhome, string string_PrivateCellular, int int_EditedRecordIndex)
            {
                YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase;

                int_EditedRecordIndex = GetYakSysAccountRealRowIndex(int_EditedRecordIndex);

                DataRow dataRow_EditedRecord = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase[int_EditedRecordIndex];
                
                dataRow_EditedRecord[securityDataBaseDataTable_obj.UserFirstNameColumn] = string_FirstName;
                dataRow_EditedRecord[securityDataBaseDataTable_obj.UserLastNameColumn] = string_LastName;
                dataRow_EditedRecord[securityDataBaseDataTable_obj.UserMiddleNameColumn] = string_MiddleName;
                dataRow_EditedRecord[securityDataBaseDataTable_obj.EMailColumn] = string_EMailAddress;
                dataRow_EditedRecord[securityDataBaseDataTable_obj.ICQColumn] = string_ICQ;
                dataRow_EditedRecord[securityDataBaseDataTable_obj.CompanyColumn] = string_Company;
                dataRow_EditedRecord[securityDataBaseDataTable_obj.WorkPhoneColumn] = string_WorkPhone;
                dataRow_EditedRecord[securityDataBaseDataTable_obj.HomePhoneColumn] = string_HomePhome;
                dataRow_EditedRecord[securityDataBaseDataTable_obj.PrivateCellularColumn] = string_PrivateCellular;                           
            }
            public void RemotingWrapper_EditUserAccountInDB(string string_FirstName, string string_LastName, string string_MiddleName, string string_EMailAddress, string string_ICQ, string string_Company, string string_WorkPhone, string string_HomePhome, string string_PrivateCellular, int int_EditedRecordIndex)
            {
                NetworkSecurity.EditUserAccountInDB(string_FirstName, string_LastName, string_MiddleName, string_EMailAddress, string_ICQ, string_Company, string_WorkPhone, string_HomePhome, string_PrivateCellular, int_EditedRecordIndex);
            }
                       
            public static void RefreshWindowsAccountsDB()
            {
                YakSys.WMIClassesInfoRetriever.WMIClassesInfoRetriever obj_WMIClassesInfoRetriever = new YakSys.WMIClassesInfoRetriever.WMIClassesInfoRetriever(YakSys.WMIClassesInfoRetriever.WMIClassesInfoRetriever.NullReferencesHandlerMechanism.SetToDefaults);

                Win32_UserAccount[] arrayWin32_UserAccount_obj = obj_WMIClassesInfoRetriever.GetWin32_UserAccountInfo();

                if(arrayWin32_UserAccount_obj == null)
                {
                    return;
                }

                NetworkSecurity.UserAccount userAccount_NewWindowsUserAccount;

                bool bool_WindowsUserAccountCanBeAdded = false;

                for (int int_CycleCount = 0; int_CycleCount != arrayWin32_UserAccount_obj.Length; int_CycleCount++)
                {
                    bool_WindowsUserAccountCanBeAdded = true;

                    if (arrayWin32_UserAccount_obj[int_CycleCount].PasswordRequired == false ||
                        arrayWin32_UserAccount_obj[int_CycleCount].Status != "OK")
                    {
                        continue;
                    }

                    foreach (UserAccount userAccount_obj in NetworkSecurity.UserAccount.UsersAccounts)
                    {
                        if (userAccount_obj.AccountType == UserAccount.AccountTypesEnum.WindowsAccount)
                        {
                            if (userAccount_obj.Login == arrayWin32_UserAccount_obj[int_CycleCount].Name)
                            {
                                bool_WindowsUserAccountCanBeAdded = false;

                                break;
                            }
                        }
                    }

                    if (bool_WindowsUserAccountCanBeAdded == false) continue;
                    else
                    {
                        userAccount_NewWindowsUserAccount = new NetworkSecurity.UserAccount();

                        userAccount_NewWindowsUserAccount.AccountType = NetworkSecurity.UserAccount.AccountTypesEnum.WindowsAccount;

                        userAccount_NewWindowsUserAccount.User = arrayWin32_UserAccount_obj[int_CycleCount].FullName;

                        userAccount_NewWindowsUserAccount.Login = arrayWin32_UserAccount_obj[int_CycleCount].Name;

                        userAccount_NewWindowsUserAccount.IsEnabled = true;

                        NetworkSecurity.UserAccount.UsersAccounts.Add(userAccount_NewWindowsUserAccount);
                    }
                }
            }
            public void RemotingWrapper_RefreshWindowsAccountsDB()
            {
                NetworkSecurity.RefreshWindowsAccountsDB();
            }


            public static void RSADecryptAndSetPrimaryAESKeyInfo(MemoryStream memoryStream_EncryptedData, string string_XMLStringWithPrivateRSAKeys, YakSysTcpClient YakSysTcpClient_obj)
            {
                int int_PrimaryAESKeySize = CommonMethods.ReadIntFromStream(memoryStream_EncryptedData);

                byte[] byteArray_EncryptedPrimaryAESKey = CommonMethods.ReadBytesFromStream(memoryStream_EncryptedData),
                       byteArray_EncryptedPrimaryAESIV = CommonMethods.ReadBytesFromStream(memoryStream_EncryptedData);
                

                RSACryptoServiceProvider rSACryptoServiceProvider_obj = new RSACryptoServiceProvider(512);

                rSACryptoServiceProvider_obj.FromXmlString(string_XMLStringWithPrivateRSAKeys); 
                //!!!!exception возникало из за множественных вызовов цикла приема, соотв. из за ошибки в обработке событий коннекта (не отписывался подписчик)
                //!!!!а так же из за множестыенного вызова ObjCopy.obj_RemoteCallAction.SendAuthorizationRequest(); на клиенте!!! вызов должен быть однократный !!!

                byte[] byteArray_DecryptedPrimaryAESKey = rSACryptoServiceProvider_obj.Decrypt(byteArray_EncryptedPrimaryAESKey, false),
                       byteArray_DecryptedPrimaryAESIV = rSACryptoServiceProvider_obj.Decrypt(byteArray_EncryptedPrimaryAESIV, false);
                

                YakSysTcpClient_obj.AES256bit_PrimaryObj = new RijndaelManaged();

                YakSysTcpClient_obj.AES256bit_PrimaryObj.KeySize = int_PrimaryAESKeySize;

                YakSysTcpClient_obj.AES256bit_PrimaryObj.Key = byteArray_DecryptedPrimaryAESKey;
                YakSysTcpClient_obj.AES256bit_PrimaryObj.IV = byteArray_DecryptedPrimaryAESIV;

                rSACryptoServiceProvider_obj.Clear();

                string_XMLStringWithPrivateRSAKeys = string.Empty;
            }

            public static void DecryptLoginPasswordPair(byte [] byteArray_AuthUserData, out string string_Login, out string string_Password)
            {
                MemoryStream memoryStream_AuthUserData = new MemoryStream(byteArray_AuthUserData);

                string_Login = CommonMethods.ReadStringFromStream(memoryStream_AuthUserData);
                string_Password = CommonMethods.ReadStringFromStream(memoryStream_AuthUserData);

                memoryStream_AuthUserData.Close();
            }
            
            public static void ClearAllWindowsAccountsFromDB()
            {
                foreach (NetworkSecurity.UserAccount userAccount_obj in NetworkSecurity.UserAccount.UsersAccounts)
                {
                    if (userAccount_obj.AccountType == NetworkSecurity.UserAccount.AccountTypesEnum.WindowsAccount)
                    {
                        userAccount_obj.IsEnabled = false;

                        userAccount_obj.DisconnectAllClients();

                        NetworkSecurity.UserAccount.UsersAccounts.Remove(userAccount_obj);

                        ClearAllWindowsAccountsFromDB();

                        return;
                    }
                }
            }
            public void RemotingWrapper_ClearAllWindowsAccountsFromDB()
            {
                NetworkSecurity.ClearAllWindowsAccountsFromDB();
            }

            public static void RemoveExistingRule(int int_RuleIndex)
            {
                AccessRestrictionRuleObject.AccessRestrictionRules.RemoveAt(int_RuleIndex);
            }
            public void RemotingWrapper_RemoveExistingRule(int int_RuleIndex)
            {
                NetworkSecurity.RemoveExistingRule(int_RuleIndex);
            }

            public static void AddNewAccessRestrictionRule(IPAddress iPAddress_IPAddressesRangeStartValue, IPAddress iPAddress_IPAddressesRangeEndValue, IPAddress iPAddress_IPAddress, string string_MACAddress, bool bool_ComplementaryUseMACAddress, DateTime dateTime_CreationTime, int int_RuleType, bool bool_IsRuleEnabled)
            {
                AccessRestrictionRuleObject accessRestrictionRuleObject_NewRule = new AccessRestrictionRuleObject();

                accessRestrictionRuleObject_NewRule.IPAddressesRangeStartValue = iPAddress_IPAddressesRangeStartValue;
                accessRestrictionRuleObject_NewRule.IPAddressesRangeEndValue = iPAddress_IPAddressesRangeEndValue;
                accessRestrictionRuleObject_NewRule.IPAddress = iPAddress_IPAddress;

                accessRestrictionRuleObject_NewRule.MACAddress = string_MACAddress;

                accessRestrictionRuleObject_NewRule.ComplementaryUseMACAddress = bool_ComplementaryUseMACAddress;

                accessRestrictionRuleObject_NewRule.CreationTime = dateTime_CreationTime;

                accessRestrictionRuleObject_NewRule.RuleType = int_RuleType;

                accessRestrictionRuleObject_NewRule.IsEnabled = bool_IsRuleEnabled;

                NetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Add(accessRestrictionRuleObject_NewRule);
            }
            public void RemotingWrapper_StoreAccessRestrictionRuleToDB(string string_IPRangeStartValue, string string_IPRangeEndValue, string string_IPAddressValue, string string_MACAddress, bool bool_ComplementaryUseMACAddress, DateTime dateTime_CreationTime, int int_RuleType, bool bool_IsRuleEnabled)
            {
                YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules;

                ////////////////////////////////////////////////////////////////////////////////

                DataRow dataRow_NewRecord = null;

                dataRow_NewRecord = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules.NewRow();

                int int_AccessRestrictionRulesID = 0;

                for (int int_CycleCount = 0; ; int_CycleCount++)
                {
                    if (accessRestrictionRulesDataTable_obj.Rows.Count == 0) break;

                    if (int_CycleCount >= accessRestrictionRulesDataTable_obj.Rows.Count
                        || (int)accessRestrictionRulesDataTable_obj.Rows[int_CycleCount][accessRestrictionRulesDataTable_obj.IDColumn] == int_AccessRestrictionRulesID)
                    {
                        int_AccessRestrictionRulesID++;
                        int_CycleCount = -1;
                        continue;
                    }

                    else if (int_CycleCount + 1 == accessRestrictionRulesDataTable_obj.Rows.Count) break;
                }

                dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IDColumn] = int_AccessRestrictionRulesID;

                dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPRangeStartValueColumn] = string_IPRangeStartValue;
                dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPRangeEndValueColumn] = string_IPRangeEndValue;
                dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IPAddressColumn] = string_IPAddressValue;
                dataRow_NewRecord[accessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn] = bool_ComplementaryUseMACAddress;
                dataRow_NewRecord[accessRestrictionRulesDataTable_obj.MACAddressColumn] = string_MACAddress;
                dataRow_NewRecord[accessRestrictionRulesDataTable_obj.RuleTypeColumn] = int_RuleType;
                dataRow_NewRecord[accessRestrictionRulesDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;
                dataRow_NewRecord[accessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn] = bool_IsRuleEnabled;

                YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules.Rows.Add(dataRow_NewRecord);
            }
            public void RemotingWrapper_AddNewAccessRestrictionRule(IPAddress iPAddress_IPAddressesRangeStartValue, IPAddress iPAddress_IPAddressesRangeEndValue, IPAddress iPAddress_IPAddress, string string_MACAddress, bool bool_ComplementaryUseMACAddress, DateTime dateTime_CreationTime, int int_RuleType, bool bool_IsRuleEnabled)
            {
                NetworkSecurity.AddNewAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress, string_MACAddress, bool_ComplementaryUseMACAddress, dateTime_CreationTime, int_RuleType, bool_IsRuleEnabled);
            }
                        
            public static void EditExistingAccessRestrictionRule(IPAddress iPAddress_IPAddressesRangeStartValue, IPAddress iPAddress_IPAddressesRangeEndValue, IPAddress iPAddress_IPAddress, string string_MACAddress, bool bool_ComplementaryUseMACAddress, DateTime dateTime_CreationTime, int int_RuleType, int int_RuleIndex)
            {
                AccessRestrictionRuleObject accessRestrictionRuleObject_NewRule = NetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[int_RuleIndex];

                accessRestrictionRuleObject_NewRule.IPAddressesRangeStartValue = iPAddress_IPAddressesRangeStartValue;
                accessRestrictionRuleObject_NewRule.IPAddressesRangeEndValue = iPAddress_IPAddressesRangeEndValue;
                accessRestrictionRuleObject_NewRule.IPAddress = iPAddress_IPAddress;

                accessRestrictionRuleObject_NewRule.MACAddress = string_MACAddress;

                accessRestrictionRuleObject_NewRule.ComplementaryUseMACAddress = bool_ComplementaryUseMACAddress;

                accessRestrictionRuleObject_NewRule.CreationTime = dateTime_CreationTime;

                accessRestrictionRuleObject_NewRule.RuleType = int_RuleType;
            }
            public void RemotingWrapper_EditExistingAccessRestrictionRule(IPAddress iPAddress_IPAddressesRangeStartValue, IPAddress iPAddress_IPAddressesRangeEndValue, IPAddress iPAddress_IPAddress, string string_MACAddress, bool bool_ComplementaryUseMACAddress, DateTime dateTime_CreationTime, int int_RuleType, int int_RuleIndex)
            {
                NetworkSecurity.EditExistingAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress, string_MACAddress, bool_ComplementaryUseMACAddress, dateTime_CreationTime, int_RuleType, int_RuleIndex);
            }
            public void RemotingWrapper_EditExistingAccessRestrictionRuleInDB(string string_IPAddressesRangeStartValue, string string_IPAddressesRangeEndValue, string string_IPAddress, string string_MACAddress, bool bool_ComplementaryUseMACAddress, int int_RuleType, int int_RuleIndex)
            {
                YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules;

                DataRow dataRow_EditedRecord = null;

                dataRow_EditedRecord = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules[int_RuleIndex];

                dataRow_EditedRecord[accessRestrictionRulesDataTable_obj.IPRangeStartValueColumn] = string_IPAddressesRangeStartValue;
                dataRow_EditedRecord[accessRestrictionRulesDataTable_obj.IPRangeEndValueColumn] = string_IPAddressesRangeEndValue;
                dataRow_EditedRecord[accessRestrictionRulesDataTable_obj.IPAddressColumn] = string_IPAddress;
                dataRow_EditedRecord[accessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn] = bool_ComplementaryUseMACAddress;
                dataRow_EditedRecord[accessRestrictionRulesDataTable_obj.MACAddressColumn] = string_MACAddress;
                dataRow_EditedRecord[accessRestrictionRulesDataTable_obj.RuleTypeColumn] = int_RuleType;	
            }
            

            public static bool AuthorizeConnectedUser(ref YakSysTcpClient YakSysTcpClient_obj, out NetworkSecurity.UserAccount userAccount_CurrentUser, string string_Login, string string_Password)
            {
                bool bool_IsAuthUser = false;

                userAccount_CurrentUser = null;

                for (int int_CycleCount = 0; int_CycleCount != NetworkSecurity.UserAccount.UsersAccounts.Count; int_CycleCount++)
                {
                    if (NetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].Login == string_Login)
                    {
                        userAccount_CurrentUser = NetworkSecurity.UserAccount.UsersAccounts[int_CycleCount];

                        if (userAccount_CurrentUser.AccountType == NetworkSecurity.UserAccount.AccountTypesEnum.YakSysAccount)
                        {
                            if (string_Password == NetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].Password)
                            {
                                bool_IsAuthUser = true;

                                YakSysTcpClient_obj.SessionStatisticAndInfo_Obj.NetworkInformation_AccountType = ServerStringFactory.GetString(756, ServerSettingsEnvironment.CurrentLanguage);
                            }
                        }

                        if (userAccount_CurrentUser.AccountType == NetworkSecurity.UserAccount.AccountTypesEnum.WindowsAccount &&
                            ServerSettingsEnvironment.IsWindowsAuthenticationAllowed == true)
                        {
                            bool_IsAuthUser = NetworkSecurity.IsWindowsAuthUser(null, new StringBuilder(string_Login), new StringBuilder(string_Password), new HandleRef());

                            YakSysTcpClient_obj.SessionStatisticAndInfo_Obj.NetworkInformation_AccountType = ServerStringFactory.GetString(757, ServerSettingsEnvironment.CurrentLanguage);
                        }

                        YakSysTcpClient_obj.IsAccountEnabled = ((NetworkSecurity.UserAccount)NetworkSecurity.UserAccount.UsersAccounts[int_CycleCount]).IsEnabled;

                        NetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].AddClient(YakSysTcpClient_obj);

                        break;
                    }
                }

                return bool_IsAuthUser;
            }
            public bool RemotingWrapper_AuthorizeConnectedUser(ref YakSysTcpClient YakSysTcpClient_obj, out NetworkSecurity.UserAccount userAccount_CurrentUser, string string_Login, string string_Password)
            {
                return NetworkSecurity.AuthorizeConnectedUser(ref YakSysTcpClient_obj, out userAccount_CurrentUser, string_Login, string_Password);
            }

            public static bool CheckAccessPossible(IPAddress iPAddress_IPAddress, string string_MACAddress)
            {
                if (ServerSettingsEnvironment.EnableAccessRestrictionRules == false || AccessRestrictionRuleObject.AccessRestrictionRules.Count < 1) return true;

                if (AccessRestrictionRuleObject.AccessRestrictionRules.Count == 0) return false;

                bool bool_Result = false, bool_IsEnabledRulesInDB = false;

                int int_RuleType = 0;

                foreach (AccessRestrictionRuleObject accessRestrictionRuleObject_obj in AccessRestrictionRuleObject.AccessRestrictionRules)
                {
                    int_RuleType = accessRestrictionRuleObject_obj.RuleType;

                    if (accessRestrictionRuleObject_obj.IsEnabled == false) continue;
                    else bool_IsEnabledRulesInDB = true;

                    if (accessRestrictionRuleObject_obj.IPAddressesRangeStartValue != null &&
                        CommonMethods.IsSecondIPAddressBiggerOrEquals(accessRestrictionRuleObject_obj.IPAddressesRangeStartValue, iPAddress_IPAddress) == true &&
                        CommonMethods.IsSecondIPAddressBiggerOrEquals(accessRestrictionRuleObject_obj.IPAddressesRangeEndValue, iPAddress_IPAddress) == false)
                    {
                        bool_Result = true;
                    }

                    if (accessRestrictionRuleObject_obj.IPAddressesRangeStartValue != null &&
                        accessRestrictionRuleObject_obj.IPAddressesRangeEndValue.Address == iPAddress_IPAddress.Address)
                    {
                        bool_Result = true;
                    }

                    if (accessRestrictionRuleObject_obj.IPAddress != null &&
                        iPAddress_IPAddress.Address == accessRestrictionRuleObject_obj.IPAddress.Address)
                    {
                        bool_Result = true;
                    }

                    if (accessRestrictionRuleObject_obj.MACAddress.Length == 17)
                    {
                        if (accessRestrictionRuleObject_obj.MACAddress == string_MACAddress) bool_Result = true;
                        else bool_Result = false;
                    }

                    if (accessRestrictionRuleObject_obj.ComplementaryUseMACAddress)
                    {
                        if (accessRestrictionRuleObject_obj.MACAddress == string_MACAddress) bool_Result = true;
                        else bool_Result = false;
                    }
                }

                if (bool_IsEnabledRulesInDB == false) return false;

                if (bool_Result == true && int_RuleType == 0) return true;
                if (bool_Result == true && int_RuleType == 1) return false;
                if (bool_Result == false && int_RuleType == 1) return true;
                if (bool_Result == false && int_RuleType == 0) return false;

                return false;
            }
            public bool RemotingWrapper_CheckAccessPossible(IPAddress iPAddress_IPAddress, string string_MACAddress)
            {
                return NetworkSecurity.CheckAccessPossible(iPAddress_IPAddress, string_MACAddress);
            }

            [DllImport("YakSysRctServerLib.dll", CharSet = CharSet.Ansi)]
            private static extern unsafe bool CheckPassword_LogonUser(StringBuilder stringBuilder_DomainName, StringBuilder stringBuilder_UserName, StringBuilder stringBuilder_Password, HandleRef phToken);
            private bool RemotingWrapper_CheckPassword_LogonUser(StringBuilder stringBuilder_DomainName, StringBuilder stringBuilder_UserName, StringBuilder stringBuilder_Password, HandleRef phToken)
            {
                return NetworkSecurity.CheckPassword_LogonUser(stringBuilder_DomainName, stringBuilder_UserName, stringBuilder_Password, phToken);
            }

            public static bool IsWindowsAuthUser(StringBuilder stringBuilder_Domain, StringBuilder stringBuilder_UserName, StringBuilder stringBuilder_Password, HandleRef handleRef_Token)
            {
                return CheckPassword_LogonUser(stringBuilder_Domain, stringBuilder_UserName, stringBuilder_Password, handleRef_Token);
            }
            public bool RemotingWrapper_IsWindowsAuthUser(StringBuilder stringBuilder_Domain, StringBuilder stringBuilder_UserName, StringBuilder stringBuilder_Password, HandleRef handleRef_Token)
            {
                return NetworkSecurity.IsWindowsAuthUser(stringBuilder_Domain, stringBuilder_UserName, stringBuilder_Password, handleRef_Token);
            }
            
            [Serializable]
            public class UserAccount : MarshalByRefObject
            {
                static List<NetworkSecurity.UserAccount> list_UsersAccounts = new List<NetworkSecurity.UserAccount>();
                public static List<NetworkSecurity.UserAccount> UsersAccounts
                {
                    get
                    {
                        return list_UsersAccounts;
                    }
                }
                public List<NetworkSecurity.UserAccount> RemotingWrapper_UsersAccounts
                {
                    get
                    {
                        return NetworkSecurity.UserAccount.UsersAccounts;
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

                string string_Login = String.Empty;
                public string Login
                {
                    get
                    {
                        return string_Login;
                    }

                    set
                    {
                        string_Login = value;
                    }
                }

                string string_TimeOfCreation = String.Empty;
                public string TimeOfCreation
                {
                    get
                    {
                        return string_TimeOfCreation;
                    }

                    set
                    {
                        string_TimeOfCreation = value;
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

                public enum AccountTypesEnum { YakSysAccount, WindowsAccount };

                public AccountTypesEnum AccountType = AccountTypesEnum.YakSysAccount;

                List<YakSysTcpClient> list_ClientsUsingAccount = new List<YakSysTcpClient>();

                public List<YakSysTcpClient> ClientsUsingAccount
                {
                    get
                    {
                        return list_ClientsUsingAccount;
                    }
                }

                public void AddClient(YakSysTcpClient YakSysTcpClient_obj)
                {
                    YakSysTcpClient_obj.IsAccountEnabled = IsEnabled;

                    ClientsUsingAccount.Add(YakSysTcpClient_obj);
                }

                public void DisconnectAllClients()
                {
                    YakSysTcpClient YakSysTcpClient_CurrentObj = null;

                    this.IsEnabled = false;

                    for (; 0 != this.ClientsUsingAccount.Count; )
                    {
                        YakSysTcpClient_CurrentObj = this.ClientsUsingAccount[0];

                        if (YakSysTcpClient_CurrentObj.RequestToDisconnect == true) continue;

                        ObjCopy.obj_NetworkAction.DisconnectNecessaryClient(YakSysTcpClient_CurrentObj, 3);
                    }
                }

                public void ChangeAccountState()
                {
                    YakSysTcpClient YakSysTcpClient_CurrentObj = null;

                    LocalAction localAction_obj = new LocalAction();

                    for (int int_intCycleCount = 0; int_intCycleCount != ClientsUsingAccount.Count; int_intCycleCount++)
                    {
                        YakSysTcpClient_CurrentObj = ClientsUsingAccount[int_intCycleCount];

                        localAction_obj.CurrentlyUsedTcpClient = YakSysTcpClient_CurrentObj;

                        if (YakSysTcpClient_CurrentObj.IsAccountEnabled == IsEnabled ||
                            YakSysTcpClient_CurrentObj.RequestToDisconnect)
                        {
                            continue;
                        }

                        (ClientsUsingAccount[int_intCycleCount]).IsAccountEnabled = IsEnabled;

                        int int_IsAccountEnabled;

                        if ((ClientsUsingAccount[int_intCycleCount]).IsAccountEnabled)
                        {
                            int_IsAccountEnabled = 1;
                        }
                        else
                        {
                            int_IsAccountEnabled = 0;
                        }

                        localAction_obj.ToSendChangesOfAccountState(int_IsAccountEnabled);
                    }
                }

                public void DisableAccount()
                {
                    YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase;

                    this.IsEnabled = false;

                    this.ChangeAccountState();

                    int int_RealDBRowAccountIndex = UsersAccounts.IndexOf(this);

                    //Calculate real DB Row account index (Windows Accounts not stored in JsDB)
                    foreach (UserAccount obj_UserAccount in UserAccount.UsersAccounts)
                    {
                        if (obj_UserAccount == UserAccount.UsersAccounts[UsersAccounts.IndexOf(this)])
                        {
                            break;
                        }

                        if (obj_UserAccount.AccountType == UserAccount.AccountTypesEnum.WindowsAccount)
                        {
                            int_RealDBRowAccountIndex--;
                        }
                    }

                    securityDataBaseDataTable_obj[int_RealDBRowAccountIndex][securityDataBaseDataTable_obj.EnabledAccountStateColumn] = false;
                }

                public void EnableAccount()
                {
                    YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.SecurityDataBase;

                    this.IsEnabled = true;

                    this.ChangeAccountState();
                    int int_RealDBRowAccountIndex = UsersAccounts.IndexOf(this);

                    //Calculate real DB Row account index (Windows Accounts not stored in JsDB)
                    foreach (UserAccount obj_UserAccount in UserAccount.UsersAccounts)
                    {
                        if (obj_UserAccount == UserAccount.UsersAccounts[UsersAccounts.IndexOf(this)])
                        {
                            break;
                        }

                        if (obj_UserAccount.AccountType == UserAccount.AccountTypesEnum.WindowsAccount)
                        {
                            int_RealDBRowAccountIndex--;
                        }
                    }

                    securityDataBaseDataTable_obj[int_RealDBRowAccountIndex][securityDataBaseDataTable_obj.EnabledAccountStateColumn] = true;
                }
            }

            [Serializable]
            public class AccessRestrictionRuleObject : MarshalByRefObject
            {
                static List<NetworkSecurity.AccessRestrictionRuleObject> list_AccessRestrictionRuleInfo = new List<NetworkSecurity.AccessRestrictionRuleObject>();
                public static List<NetworkSecurity.AccessRestrictionRuleObject> AccessRestrictionRules
                {
                    get
                    {
                        return list_AccessRestrictionRuleInfo;
                    }
                }
                public List<NetworkSecurity.AccessRestrictionRuleObject> RemotingWrapper_AccessRestrictionRules
                {
                    get
                    {
                        return NetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules;
                    }
                }

                IPAddress iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress;

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

                bool bool_ComplementaryUseMACAddress;
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

                string string_MACAddress = String.Empty;
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

                DateTime dateTime_CreationTime;
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
                
                int int_RuleType;
                public int RuleType
                {
                    get
                    {
                        return int_RuleType;
                    }

                    set
                    {
                        int_RuleType = value;
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

                public void DisableRule()
                {
                    YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules;

                    this.IsEnabled = false;

                    int int_RealDBRowAccountIndex = AccessRestrictionRules.IndexOf(this);

                    accessRestrictionRulesDataTable_obj[int_RealDBRowAccountIndex][accessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn] = false;
                }

                public void EnableRule()
                {
                    YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = YakSysRctServerV110XMLConfigImporter.YakSysServerDB.AccessRestrictionRules;

                    this.IsEnabled = true;

                    int int_RealDBRowAccountIndex = AccessRestrictionRules.IndexOf(this);

                    accessRestrictionRulesDataTable_obj[int_RealDBRowAccountIndex][accessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn] = true;
                }
            }
        }
    }
}