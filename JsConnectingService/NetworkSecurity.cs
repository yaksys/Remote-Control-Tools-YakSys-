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
using YakSysConnectingService;
using YakSys;
using YakSys.ConnectingServiceXMLConfigImporter;
using YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingService;
using YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingService.Version10;

[Serializable]
public class CommonNetworkSecurity : MarshalByRefObject
{
    public static void RSADecryptAndSetPrimaryAESKeyInfo(MemoryStream memoryStream_EncryptedData, string string_XMLStringWithPrivateRSAKeys, BaseConnectedObject baseConnectedObject_obj)
    {
        int int_PrimaryAESKeySize = CommonMethods.ReadIntFromStream(memoryStream_EncryptedData);

        byte[] byteArray_EncryptedPrimaryAESKey = CommonMethods.ReadBytesFromStream(memoryStream_EncryptedData),
               byteArray_EncryptedPrimaryAESIV = CommonMethods.ReadBytesFromStream(memoryStream_EncryptedData);
        
        RSACryptoServiceProvider rSACryptoServiceProvider_obj = new RSACryptoServiceProvider(512);

        rSACryptoServiceProvider_obj.FromXmlString(string_XMLStringWithPrivateRSAKeys);

        byte[] byteArray_DecryptedPrimaryAESKey = rSACryptoServiceProvider_obj.Decrypt(byteArray_EncryptedPrimaryAESKey, false);
        byte[] byteArray_DecryptedPrimaryAESIV = rSACryptoServiceProvider_obj.Decrypt(byteArray_EncryptedPrimaryAESIV, false);
        
        baseConnectedObject_obj.AES256bit_PrimaryObj = new RijndaelManaged();

        baseConnectedObject_obj.AES256bit_PrimaryObj.KeySize = int_PrimaryAESKeySize;

        baseConnectedObject_obj.AES256bit_PrimaryObj.Key = byteArray_DecryptedPrimaryAESKey;
        baseConnectedObject_obj.AES256bit_PrimaryObj.IV = byteArray_DecryptedPrimaryAESIV;

        rSACryptoServiceProvider_obj.Clear();

        string_XMLStringWithPrivateRSAKeys = string.Empty;
    }

    public static void DecryptLoginPasswordPair(byte[] byteArray_AuthUserData, out string string_Login, out string string_Password)
    {
        MemoryStream memoryStream_AuthUserData = new MemoryStream(byteArray_AuthUserData);

        string_Login = CommonMethods.ReadStringFromStream(memoryStream_AuthUserData);
        string_Password = CommonMethods.ReadStringFromStream(memoryStream_AuthUserData);

        memoryStream_AuthUserData.Close();
    }
}
/// <summary>
///  
/// </summary>

[Serializable]
public class ClientsNetworkSecurity : MarshalByRefObject
{
    public static void LoadSecurityDB(YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ClientsSecurityDataBase[] securityDataBaseArray_UsersList)
    {
        ClientsNetworkSecurity.UserAccount userAccount_NewAccount = null;
        
        for (int int_CycleCount = 0; int_CycleCount != securityDataBaseArray_UsersList.Length; int_CycleCount++)
        {
            userAccount_NewAccount = new ClientsNetworkSecurity.UserAccount();

            userAccount_NewAccount.FirstName = securityDataBaseArray_UsersList[int_CycleCount].FirstName;
            userAccount_NewAccount.SecondName = securityDataBaseArray_UsersList[int_CycleCount].SecondName;
            userAccount_NewAccount.LastName = securityDataBaseArray_UsersList[int_CycleCount].LastName;

            userAccount_NewAccount.ICQ = securityDataBaseArray_UsersList[int_CycleCount].ICQ;
            userAccount_NewAccount.EMail = securityDataBaseArray_UsersList[int_CycleCount].EMail;

            userAccount_NewAccount.Work = securityDataBaseArray_UsersList[int_CycleCount].Work;

            userAccount_NewAccount.HomePhone = securityDataBaseArray_UsersList[int_CycleCount].HomePhone;
            userAccount_NewAccount.WorkPhone = securityDataBaseArray_UsersList[int_CycleCount].WorkPhone;
            userAccount_NewAccount.MobilePhone = securityDataBaseArray_UsersList[int_CycleCount].MobilePhone;

            userAccount_NewAccount.ActivationCode = securityDataBaseArray_UsersList[int_CycleCount].ActivationCode;
            userAccount_NewAccount.IsActivated = securityDataBaseArray_UsersList[int_CycleCount].IsActivated;
 
            userAccount_NewAccount.IsEnabled = securityDataBaseArray_UsersList[int_CycleCount].IsEnabled;
            userAccount_NewAccount.Password = securityDataBaseArray_UsersList[int_CycleCount].Password;
            userAccount_NewAccount.UIN = securityDataBaseArray_UsersList[int_CycleCount].UIN;
            userAccount_NewAccount.UserName = securityDataBaseArray_UsersList[int_CycleCount].User;
            userAccount_NewAccount.CreationTime = securityDataBaseArray_UsersList[int_CycleCount].CreationTime;

            AddNewUser(userAccount_NewAccount);
        }
    }
    public static void LoadAccessRestrictionRulesDB(YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ServersAccessRestrictionRule[] accessRestrictionRuleArray_RulesList)
    {
        for (int int_CycleCount = 0; int_CycleCount != accessRestrictionRuleArray_RulesList.Length; int_CycleCount++)
        {
            AddNewAccessRestrictionRule(accessRestrictionRuleArray_RulesList[int_CycleCount].IPAddressesRangeStartValue, accessRestrictionRuleArray_RulesList[int_CycleCount].IPAddressesRangeEndValue, accessRestrictionRuleArray_RulesList[int_CycleCount].IPAddress,
                        accessRestrictionRuleArray_RulesList[int_CycleCount].MACAddress, accessRestrictionRuleArray_RulesList[int_CycleCount].ComplementaryUseMACAddress, accessRestrictionRuleArray_RulesList[int_CycleCount].CreationTime, accessRestrictionRuleArray_RulesList[int_CycleCount].RuleTypeIndex, accessRestrictionRuleArray_RulesList[int_CycleCount].IsRuleEnabled);
        }
    }

    public static void RemoveAccessRestrictionRule(int int_AccessRestrinctionRuleIndex)
    {        
        new YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment().RemoveClientsAccessRestrictionRulesDataBaseRow(int_AccessRestrinctionRuleIndex);

        AccessRestrictionRuleObject.AccessRestrictionRules.RemoveAt(int_AccessRestrinctionRuleIndex);
    }
    public void RemotingWrapper_RemoveAccessRestrictionRule(int int_AccessRestrinctionRuleIndex)
    {
        ClientsNetworkSecurity.RemoveAccessRestrictionRule(int_AccessRestrinctionRuleIndex);
    }


    public static void StoreNewClientUserAccountToDB(ClientsNetworkSecurity.UserAccount userAccount_NewAccount)
    {
        DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable clientsSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase;

        DataRow dataRow_NewRecord = null;

        dataRow_NewRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase.NewRow();

        int int_SecurityDataBaseID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (clientsSecurityDataBaseDataTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= clientsSecurityDataBaseDataTable_obj.Rows.Count
            || (int)clientsSecurityDataBaseDataTable_obj.Rows[int_CycleCount][clientsSecurityDataBaseDataTable_obj.IDColumn] == int_SecurityDataBaseID)
            {
                int_SecurityDataBaseID++;
                int_CycleCount = -1;
                continue;
            }

            else if (int_CycleCount + 1 == clientsSecurityDataBaseDataTable_obj.Rows.Count) break;
        }

        DateTime dateTime_CreationTime = DateTime.Now;

        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.IDColumn] = int_SecurityDataBaseID;


        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.UINColumn] = userAccount_NewAccount.UIN;
        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.UserNameColumn] = userAccount_NewAccount.UserName;
        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.UserPasswordColumn] = userAccount_NewAccount.Password;
        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.EnabledAccountStateColumn] = userAccount_NewAccount.IsEnabled;

        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.UserFirstNameColumn] = userAccount_NewAccount.FirstName;
        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.UserLastNameColumn] = userAccount_NewAccount.LastName;
        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.UserMiddleNameColumn] = userAccount_NewAccount.SecondName;

        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.EMailColumn] = userAccount_NewAccount.EMail;
        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.ICQColumn] = userAccount_NewAccount.ICQ;

        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.CompanyColumn] = userAccount_NewAccount.Work;

        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.WorkPhoneColumn] = userAccount_NewAccount.WorkPhone;
        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.HomePhoneColumn] = userAccount_NewAccount.HomePhone;
        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.PrivateCellularColumn] = userAccount_NewAccount.MobilePhone;

        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;

        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.EnabledAccountStateColumn] = userAccount_NewAccount.IsEnabled;

        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.ActivationCodeColumn] = userAccount_NewAccount.ActivationCode;
        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.IsActivatedColumn] = userAccount_NewAccount.IsActivated;
        dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.ActivationTimeColumn] = DateTime.MinValue;   
   
        if (userAccount_NewAccount.IsActivated == true)
        {
            dataRow_NewRecord[clientsSecurityDataBaseDataTable_obj.ActivationTimeColumn] = userAccount_NewAccount.ActivationTime;
        }

        ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase.Rows.Add(dataRow_NewRecord);

    }

    public static bool AddNewUser(ClientsNetworkSecurity.UserAccount userAccount_NewAccount)
    {
        ClientsNetworkSecurity.UserAccount.UsersAccounts.Add(userAccount_NewAccount);

        ObjCopy.obj_MainForm.AddClientAccountToListView(userAccount_NewAccount);

        return true;
    }
  
    public bool RemotingWrapper_AddNewUser(string string_UIN, string string_UserName, string string_Password, string string_FirstName,
                    string string_SecondName, string string_LastName, string string_ICQ, string string_EMail,
                    string string_Work, string string_HomePhone, string string_WorkPhone, string string_MobilePhone, bool bool_IsAccountEnabled, bool bool_IsAccountActivated)
    {

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

        userAccount_NewAccount.ActivationCode = 0;
        userAccount_NewAccount.IsActivated = bool_IsAccountActivated;

        userAccount_NewAccount.IsEnabled = false;
        userAccount_NewAccount.Password = string_Password;
        userAccount_NewAccount.UIN = string_UIN;
        userAccount_NewAccount.UserName = string_UserName;
        userAccount_NewAccount.CreationTime = DateTime.Now;

        return ClientsNetworkSecurity.AddNewUser(userAccount_NewAccount);
    }

    public void RemotingWrapper_StoreUserAccountToDB(string string_UserName, string string_Login, string string_Password, string string_FirstName, string string_LastName,
           string string_MiddleName, string string_EMailAddress, string string_ICQ, string string_Company, string string_WorkPhone, string string_HomePhome, string string_PrivateCellular,
           DateTime dateTime_CreationTime, DateTime dateTime_ActivationTime, bool bool_IsAccountEnabled, bool bool_IsAccountActivated)
    {
        DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable ClientsSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase;

        ////////////////////////////////////////////////////////////////////////////////

        DataRow dataRow_NewRecord = null;

        dataRow_NewRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase.NewRow();

        int int_SecurityDataBaseID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (ClientsSecurityDataBaseDataTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= ClientsSecurityDataBaseDataTable_obj.Rows.Count
            || (int)ClientsSecurityDataBaseDataTable_obj.Rows[int_CycleCount][ClientsSecurityDataBaseDataTable_obj.IDColumn] == int_SecurityDataBaseID)
            {
                int_SecurityDataBaseID++;
                int_CycleCount = -1;
                continue;
            }

            else if (int_CycleCount + 1 == ClientsSecurityDataBaseDataTable_obj.Rows.Count) break;
        }

        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.IDColumn] = int_SecurityDataBaseID;

        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.UINColumn] = string_Login;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.UserNameColumn] = string_UserName;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.UserPasswordColumn] = string_Password;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.EnabledAccountStateColumn] = bool_IsAccountEnabled;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.UserNameColumn] = string_FirstName;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.UserLastNameColumn] = string_LastName;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.UserMiddleNameColumn] = string_MiddleName;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.EMailColumn] = string_EMailAddress;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.ICQColumn] = string_ICQ;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.CompanyColumn] = string_Company;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.WorkPhoneColumn] = string_WorkPhone;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.HomePhoneColumn] = string_HomePhome;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.PrivateCellularColumn] = string_PrivateCellular;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;

        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.IsEnabledColumn] = bool_IsAccountEnabled;
        dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.IsActivatedColumn] = bool_IsAccountActivated;

        if (bool_IsAccountActivated == true)
        {
            dataRow_NewRecord[ClientsSecurityDataBaseDataTable_obj.ActivationTimeColumn] = dateTime_ActivationTime;
        }

        ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase.Rows.Add(dataRow_NewRecord);

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
        }

        return int_RealDBRowAccountIndex;
    }
    public int RemotingWrapper_GetYakSysAccountRealRowIndex(int int_AccountIndex)
    {
        return ClientsNetworkSecurity.GetYakSysAccountRealRowIndex(int_AccountIndex);
    }

    public static void RemoveAccount(int int_AccountIndex)
    {
        BaseChannelObject baseChannelObject_CurrentObj = null;

        UserAccount.UsersAccounts[int_AccountIndex].IsEnabled = false;

        for (; 0 != UserAccount.UsersAccounts[int_AccountIndex].ClientsUsingAccount.Count; )
        {
            baseChannelObject_CurrentObj = UserAccount.UsersAccounts[int_AccountIndex].ClientsUsingAccount[0];

            if (baseChannelObject_CurrentObj.RequestToDisconnect == true) continue;

            baseChannelObject_CurrentObj.Disconnect(4);
        }

        UserAccount.UsersAccounts[int_AccountIndex].DisconnectAllClients();

        //!!!YakSys.XMLConfigImporter доделан для JS CS ?!        
        new YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment().RemoveClientsSecurityDataBaseRow(GetYakSysAccountRealRowIndex(int_AccountIndex));

        UserAccount.UsersAccounts.RemoveAt(int_AccountIndex);
    }
    public void RemotingWrapper_RemoveAccount(int int_AccountIndex)
    {
        ClientsNetworkSecurity.RemoveAccount(int_AccountIndex);
    }

    public static void ClearAccounts()
    {
        BaseChannelObject baseChannelObject_CurrentObj = null;

        foreach (UserAccount obj_UserAccount in UserAccount.UsersAccounts)
        {
            for (; 0 != obj_UserAccount.ClientsUsingAccount.Count; )
            {
                baseChannelObject_CurrentObj = obj_UserAccount.ClientsUsingAccount[0];

                if (baseChannelObject_CurrentObj.RequestToDisconnect == true) continue;

                baseChannelObject_CurrentObj.Disconnect(4);
            }

            obj_UserAccount.IsEnabled = false;
        }

        UserAccount.UsersAccounts.Clear();

        YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ClearClientsSecurityDataBase();
    }
    public void RemotingWrapper_ClearAccounts()
    {
        ClientsNetworkSecurity.ClearAccounts();
    }

    public static void ClearAccessRestrictionRules()
    {
        AccessRestrictionRuleObject.AccessRestrictionRules.Clear();

         YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ClearClientsAccessRestrictionRulesDataBase();
    }
    public void RemotingWrapper_ClearAccessRestrictionRules()
    {
        ClientsNetworkSecurity.ClearAccessRestrictionRules();
    }

    static void EditUserAccountInDB(string string_FirstName, string string_LastName, string string_MiddleName, string string_EMailAddress, string string_ICQ, string string_Company, string string_WorkPhone, string string_HomePhome, string string_PrivateCellular, int int_EditedRecordIndex)
    {
        DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable clientsSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase;

        int_EditedRecordIndex = GetYakSysAccountRealRowIndex(int_EditedRecordIndex);

        DataRow dataRow_EditedRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase[int_EditedRecordIndex];

        dataRow_EditedRecord[clientsSecurityDataBaseDataTable_obj.UserNameColumn] = string_FirstName;
        dataRow_EditedRecord[clientsSecurityDataBaseDataTable_obj.UserLastNameColumn] = string_LastName;
        dataRow_EditedRecord[clientsSecurityDataBaseDataTable_obj.UserMiddleNameColumn] = string_MiddleName;
        dataRow_EditedRecord[clientsSecurityDataBaseDataTable_obj.EMailColumn] = string_EMailAddress;
        dataRow_EditedRecord[clientsSecurityDataBaseDataTable_obj.ICQColumn] = string_ICQ;
        dataRow_EditedRecord[clientsSecurityDataBaseDataTable_obj.CompanyColumn] = string_Company;
        dataRow_EditedRecord[clientsSecurityDataBaseDataTable_obj.WorkPhoneColumn] = string_WorkPhone;
        dataRow_EditedRecord[clientsSecurityDataBaseDataTable_obj.HomePhoneColumn] = string_HomePhome;
        dataRow_EditedRecord[clientsSecurityDataBaseDataTable_obj.PrivateCellularColumn] = string_PrivateCellular;
    }
    public void RemotingWrapper_EditUserAccountInDB(string string_FirstName, string string_LastName, string string_MiddleName, string string_EMailAddress, string string_ICQ, string string_Company, string string_WorkPhone, string string_HomePhome, string string_PrivateCellular, int int_EditedRecordIndex)
    {
        ClientsNetworkSecurity.EditUserAccountInDB(string_FirstName, string_LastName, string_MiddleName, string_EMailAddress, string_ICQ, string_Company, string_WorkPhone, string_HomePhome, string_PrivateCellular, int_EditedRecordIndex);
    }

    public static void RemoveExistingRule(int int_RuleIndex)
    {
        AccessRestrictionRuleObject.AccessRestrictionRules.RemoveAt(int_RuleIndex);
    }
    public void RemotingWrapper_RemoveExistingRule(int int_RuleIndex)
    {
        ClientsNetworkSecurity.RemoveExistingRule(int_RuleIndex);
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

        ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Add(accessRestrictionRuleObject_NewRule);
    }
    public void RemotingWrapper_StoreAccessRestrictionRuleToDB(string string_IPRangeStartValue, string string_IPRangeEndValue, string string_IPAddressValue, string string_MACAddress, bool bool_ComplementaryUseMACAddress, DateTime dateTime_CreationTime, int int_RuleType, bool bool_IsRuleEnabled)
    {
        DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable clientsAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules;

        ////////////////////////////////////////////////////////////////////////////////

        DataRow dataRow_NewRecord = null;

        dataRow_NewRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.NewRow();

        int int_AccessRestrictionRulesID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (clientsAccessRestrictionRulesDataTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= clientsAccessRestrictionRulesDataTable_obj.Rows.Count
                || (int)clientsAccessRestrictionRulesDataTable_obj.Rows[int_CycleCount][clientsAccessRestrictionRulesDataTable_obj.IDColumn] == int_AccessRestrictionRulesID)
            {
                int_AccessRestrictionRulesID++;
                int_CycleCount = -1;
                continue;
            }

            else if (int_CycleCount + 1 == clientsAccessRestrictionRulesDataTable_obj.Rows.Count) break;
        }

        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.IDColumn] = int_AccessRestrictionRulesID;

        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn] = string_IPRangeStartValue;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn] = string_IPRangeEndValue;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.IPAddressColumn] = string_IPAddressValue;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn] = bool_ComplementaryUseMACAddress;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.MACAddressColumn] = string_MACAddress;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.RuleTypeColumn] = int_RuleType;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;
        dataRow_NewRecord[clientsAccessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn] = bool_IsRuleEnabled;

        ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.Add(dataRow_NewRecord);
    }
    public void RemotingWrapper_AddNewAccessRestrictionRule(IPAddress iPAddress_IPAddressesRangeStartValue, IPAddress iPAddress_IPAddressesRangeEndValue, IPAddress iPAddress_IPAddress, string string_MACAddress, bool bool_ComplementaryUseMACAddress, DateTime dateTime_CreationTime, int int_RuleType, bool bool_IsRuleEnabled)
    {
        ClientsNetworkSecurity.AddNewAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress, string_MACAddress, bool_ComplementaryUseMACAddress, dateTime_CreationTime, int_RuleType, bool_IsRuleEnabled);
    }

    public static void EditExistingAccessRestrictionRule(IPAddress iPAddress_IPAddressesRangeStartValue, IPAddress iPAddress_IPAddressesRangeEndValue, IPAddress iPAddress_IPAddress, string string_MACAddress, bool bool_ComplementaryUseMACAddress, DateTime dateTime_CreationTime, int int_RuleType, int int_RuleIndex)
    {
        AccessRestrictionRuleObject accessRestrictionRuleObject_NewRule = ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[int_RuleIndex];

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
        ClientsNetworkSecurity.EditExistingAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress, string_MACAddress, bool_ComplementaryUseMACAddress, dateTime_CreationTime, int_RuleType, int_RuleIndex);
    }
    public void RemotingWrapper_EditExistingAccessRestrictionRuleInDB(string string_IPAddressesRangeStartValue, string string_IPAddressesRangeEndValue, string string_IPAddress, string string_MACAddress, bool bool_ComplementaryUseMACAddress, int int_RuleType, int int_RuleIndex)
    {
        DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable clientsAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules;

        DataRow dataRow_EditedRecord = null;

        dataRow_EditedRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules[int_RuleIndex];

        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn] = string_IPAddressesRangeStartValue;
        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn] = string_IPAddressesRangeEndValue;
        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.IPAddressColumn] = string_IPAddress;
        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn] = bool_ComplementaryUseMACAddress;
        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.MACAddressColumn] = string_MACAddress;
        dataRow_EditedRecord[clientsAccessRestrictionRulesDataTable_obj.RuleTypeColumn] = int_RuleType;
    }


    public static bool AuthorizeConnectedUser(ref BaseChannelObject baseConnectedObject_obj, string string_Login, string string_Password)
    {
        bool bool_IsAuthUser = false;

        ClientsNetworkSecurity.UserAccount userAccount_CurrentUser = null;

        for (int int_CycleCount = 0; int_CycleCount != ClientsNetworkSecurity.UserAccount.UsersAccounts.Count; int_CycleCount++)
        {
            if (ClientsNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].UIN == string_Login)
            {
                userAccount_CurrentUser = ClientsNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount];

                if (string_Password == userAccount_CurrentUser.Password)
                {       
                    bool_IsAuthUser = true;

                    baseConnectedObject_obj.NetworkInformation_AccountType = StringFactory.GetString(756, MainForm.CurrentLanguage);
                    baseConnectedObject_obj.NetworkInformation_UserName = userAccount_CurrentUser.UserName;
                }

                baseConnectedObject_obj.IsActivated = userAccount_CurrentUser.IsActivated;
                baseConnectedObject_obj.IsAccountEnabled = userAccount_CurrentUser.IsEnabled;

                userAccount_CurrentUser.AddClient(baseConnectedObject_obj); //!!!!? надо ли добавлять клиента если он не прошел авторизацию ? походу да

                break;
            }
        }

        return bool_IsAuthUser;
    }
    public bool RemotingWrapper_AuthorizeConnectedUser(ref BaseChannelObject YakSysTcpClient_obj, string string_Login, string string_Password)
    {
        return ClientsNetworkSecurity.AuthorizeConnectedUser(ref YakSysTcpClient_obj, string_Login, string_Password);
    }

    public static bool CheckAccessPossible(IPAddress iPAddress_IPAddress, string string_MACAddress)
    {
        if (CommonEnvironment.IsClientAccessRestrictionRuleEnable == false) return true;

        if (AccessRestrictionRuleObject.AccessRestrictionRules.Count == 0) return false;

        bool bool_Result = false, bool_IsEnabledRulesInDB = false;

        int int_RuleType = 0;

        foreach (AccessRestrictionRuleObject accessRestrictionRuleObject_obj in AccessRestrictionRuleObject.AccessRestrictionRules)
        {
            int_RuleType = accessRestrictionRuleObject_obj.RuleType;

            if (accessRestrictionRuleObject_obj.IsEnabled == false) continue;
            else bool_IsEnabledRulesInDB = true;

            if (accessRestrictionRuleObject_obj.IPAddressesRangeStartValue != null &&
                UserAccountsAndAccessRestrictionRulesEnvironment.IsSecondIPAddressBiggerOrEquals(accessRestrictionRuleObject_obj.IPAddressesRangeStartValue, iPAddress_IPAddress) == true &&
                UserAccountsAndAccessRestrictionRulesEnvironment.IsSecondIPAddressBiggerOrEquals(accessRestrictionRuleObject_obj.IPAddressesRangeEndValue, iPAddress_IPAddress) == false)
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
        return ClientsNetworkSecurity.CheckAccessPossible(iPAddress_IPAddress, string_MACAddress);
    }

    [Serializable]
    public class UserAccount : MarshalByRefObject
    {
        static List<ClientsNetworkSecurity.UserAccount> list_UsersAccounts = new List<ClientsNetworkSecurity.UserAccount>();
        public static List<ClientsNetworkSecurity.UserAccount> UsersAccounts
        {
            get
            {
                return list_UsersAccounts;
            }
        }
        public List<ClientsNetworkSecurity.UserAccount> RemotingWrapper_UsersAccounts
        {
            get
            {
                return ClientsNetworkSecurity.UserAccount.UsersAccounts;
            }
        }
        
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

        string string_UserName = String.Empty;
        public string UserName
        {
            get
            {
                return string_UserName;
            }

            set
            {
                string_UserName = value;
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

        DateTime dateTime_CreationTime = DateTime.Now;
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

        List<BaseChannelObject> list_ClientsUsingAccount = new List<BaseChannelObject>();

        public List<BaseChannelObject> ClientsUsingAccount
        {
            get
            {
                return list_ClientsUsingAccount;
            }
        }

        public void AddClient(BaseChannelObject YakSysTcpClient_obj)
        {
            YakSysTcpClient_obj.IsAccountEnabled = IsEnabled;

            ClientsUsingAccount.Add(YakSysTcpClient_obj);
        }

        public void DisconnectAllClients()
        {
            BaseChannelObject baseChannelObject_CurrentObj = null;

            this.IsEnabled = false;

            for (; 0 != this.ClientsUsingAccount.Count; )
            {
                baseChannelObject_CurrentObj = this.ClientsUsingAccount[0];

                if (baseChannelObject_CurrentObj.RequestToDisconnect == true) continue;

                baseChannelObject_CurrentObj.Disconnect(5);
            }
        }

        public void ChangeAccountState()
        {
            BaseChannelObject baseChannelObject_CurrentObj = null;

            LocalAction localAction_obj = new LocalAction();

            for (int int_intCycleCount = 0; int_intCycleCount != ClientsUsingAccount.Count; int_intCycleCount++)
            {
                baseChannelObject_CurrentObj = ClientsUsingAccount[int_intCycleCount];

                localAction_obj.NecessaryBaseChannelObject = baseChannelObject_CurrentObj;

                if (baseChannelObject_CurrentObj.IsAccountEnabled == IsEnabled ||
                    baseChannelObject_CurrentObj.RequestToDisconnect)
                {
                    continue;
                }

                (ClientsUsingAccount[int_intCycleCount]).IsAccountEnabled = IsEnabled;

                int int_IsAccountEnabled;

                if ((ClientsUsingAccount[int_intCycleCount]).IsAccountEnabled == true)
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
            DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable clientsSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase;

            this.IsEnabled = false;

            this.ChangeAccountState();

            int int_RealDBRowAccountIndex = UsersAccounts.IndexOf(this);

            clientsSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][clientsSecurityDataBaseDataTable_obj.EnabledAccountStateColumn] = false;
        }

        public void EnableAccount()
        {
            DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable clientsSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase;

            this.IsEnabled = true;

            this.ChangeAccountState();
            int int_RealDBRowAccountIndex = UsersAccounts.IndexOf(this);

            clientsSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][clientsSecurityDataBaseDataTable_obj.EnabledAccountStateColumn] = true;
        }

        public void ActivateAccount()
        {
            DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable clientsSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase;

            this.IsActivated = true;
            this.ActivationTime = DateTime.Now;

            int int_RealDBRowAccountIndex = UsersAccounts.IndexOf(this);

            clientsSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][clientsSecurityDataBaseDataTable_obj.IsActivatedColumn] = true;
            clientsSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][clientsSecurityDataBaseDataTable_obj.ActivationTimeColumn] = this.ActivationTime;
        }

        public void DeActivateAccount()
        {
            DataSet_ConnectingServiceDB.ClientsSecurityDataBaseDataTable clientsSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase;

            this.IsActivated = false;
            this.ActivationTime = DateTime.Now;

            int int_RealDBRowAccountIndex = UsersAccounts.IndexOf(this);

            clientsSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][clientsSecurityDataBaseDataTable_obj.IsActivatedColumn] = false;
            clientsSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][clientsSecurityDataBaseDataTable_obj.ActivationTimeColumn] = this.ActivationTime;
        }

        public void RemoveAccount()
        {
            UsersAccounts.Remove(this);
        }
    }

    [Serializable]
    public class AccessRestrictionRuleObject : MarshalByRefObject
    {
        static List<ClientsNetworkSecurity.AccessRestrictionRuleObject> list_AccessRestrictionRuleInfo = new List<ClientsNetworkSecurity.AccessRestrictionRuleObject>();
        public static List<ClientsNetworkSecurity.AccessRestrictionRuleObject> AccessRestrictionRules
        {
            get
            {
                return list_AccessRestrictionRuleInfo;
            }
        }
        public List<ClientsNetworkSecurity.AccessRestrictionRuleObject> RemotingWrapper_AccessRestrictionRules
        {
            get
            {
                return ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules;
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
            DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable clientsAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules;

            this.IsEnabled = false;

            int int_RealDBRowAccountIndex = AccessRestrictionRules.IndexOf(this);

            clientsAccessRestrictionRulesDataTable_obj[int_RealDBRowAccountIndex][clientsAccessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn] = false;
        }

        public void EnableRule()
        {
            DataSet_ConnectingServiceDB.ClientsAccessRestrictionRulesDataTable clientsAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules;

            this.IsEnabled = true;

            int int_RealDBRowAccountIndex = AccessRestrictionRules.IndexOf(this);

            clientsAccessRestrictionRulesDataTable_obj[int_RealDBRowAccountIndex][clientsAccessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn] = true;
        }
    }
}

[Serializable]
public class ServersNetworkSecurity : MarshalByRefObject
{
    public static void LoadSecurityDB(YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ServersSecurityDataBase[] securityDataBaseArray_UsersList)
    {
        ServersNetworkSecurity.UserAccount userAccount_NewAccount = null;

        for (int int_CycleCount = 0; int_CycleCount != securityDataBaseArray_UsersList.Length; int_CycleCount++)
        {
            userAccount_NewAccount = new ServersNetworkSecurity.UserAccount();

            userAccount_NewAccount.FirstName = securityDataBaseArray_UsersList[int_CycleCount].FirstName;
            userAccount_NewAccount.SecondName = securityDataBaseArray_UsersList[int_CycleCount].SecondName;
            userAccount_NewAccount.LastName = securityDataBaseArray_UsersList[int_CycleCount].LastName;

            userAccount_NewAccount.ICQ = securityDataBaseArray_UsersList[int_CycleCount].ICQ;
            userAccount_NewAccount.EMail = securityDataBaseArray_UsersList[int_CycleCount].EMail;

            userAccount_NewAccount.Work = securityDataBaseArray_UsersList[int_CycleCount].Work;

            userAccount_NewAccount.HomePhone = securityDataBaseArray_UsersList[int_CycleCount].HomePhone;
            userAccount_NewAccount.WorkPhone = securityDataBaseArray_UsersList[int_CycleCount].WorkPhone;
            userAccount_NewAccount.MobilePhone = securityDataBaseArray_UsersList[int_CycleCount].MobilePhone;

            userAccount_NewAccount.ActivationCode = securityDataBaseArray_UsersList[int_CycleCount].ActivationCode;
            userAccount_NewAccount.IsActivated = securityDataBaseArray_UsersList[int_CycleCount].IsActivated;

            userAccount_NewAccount.IsEnabled = securityDataBaseArray_UsersList[int_CycleCount].IsEnabled;
            userAccount_NewAccount.Password = securityDataBaseArray_UsersList[int_CycleCount].Password;
            userAccount_NewAccount.UIN = securityDataBaseArray_UsersList[int_CycleCount].UIN;
            userAccount_NewAccount.UserName = securityDataBaseArray_UsersList[int_CycleCount].User;
            userAccount_NewAccount.CreationTime = securityDataBaseArray_UsersList[int_CycleCount].CreationTime;

            AddNewUser(userAccount_NewAccount);
        }
    }
    public static void LoadAccessRestrictionRulesDB(YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ServersAccessRestrictionRule[] accessRestrictionRuleArray_RulesList)
    {
        for (int int_CycleCount = 0; int_CycleCount != accessRestrictionRuleArray_RulesList.Length; int_CycleCount++)
        {
            AddNewAccessRestrictionRule(accessRestrictionRuleArray_RulesList[int_CycleCount].IPAddressesRangeStartValue, accessRestrictionRuleArray_RulesList[int_CycleCount].IPAddressesRangeEndValue, accessRestrictionRuleArray_RulesList[int_CycleCount].IPAddress,
                        accessRestrictionRuleArray_RulesList[int_CycleCount].MACAddress, accessRestrictionRuleArray_RulesList[int_CycleCount].ComplementaryUseMACAddress, accessRestrictionRuleArray_RulesList[int_CycleCount].CreationTime, accessRestrictionRuleArray_RulesList[int_CycleCount].RuleTypeIndex, accessRestrictionRuleArray_RulesList[int_CycleCount].IsRuleEnabled);
        }
    }

    public static void RemoveAccessRestrictionRule(int int_AccessRestrinctionRuleIndex)
    {
        new YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment().RemoveServersAccessRestrictionRulesDataBaseRow(int_AccessRestrinctionRuleIndex);

        AccessRestrictionRuleObject.AccessRestrictionRules.RemoveAt(int_AccessRestrinctionRuleIndex);
    }
    public void RemotingWrapper_RemoveAccessRestrictionRule(int int_AccessRestrinctionRuleIndex)
    {
        ServersNetworkSecurity.RemoveAccessRestrictionRule(int_AccessRestrinctionRuleIndex);
    }

    public static void StoreNewServerUserAccountToDB(ServersNetworkSecurity.UserAccount userAccount_NewAccount)
    {
        DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable serversSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase;

        DataRow dataRow_NewRecord = null;

        dataRow_NewRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase.NewRow();

        int int_SecurityDataBaseID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (serversSecurityDataBaseDataTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= serversSecurityDataBaseDataTable_obj.Rows.Count
            || (int)serversSecurityDataBaseDataTable_obj.Rows[int_CycleCount][serversSecurityDataBaseDataTable_obj.IDColumn] == int_SecurityDataBaseID)
            {
                int_SecurityDataBaseID++;
                int_CycleCount = -1;
                continue;
            }

            else if (int_CycleCount + 1 == serversSecurityDataBaseDataTable_obj.Rows.Count) break;
        }

        DateTime dateTime_CreationTime = DateTime.Now;

        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.IDColumn] = int_SecurityDataBaseID;


        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UINColumn] = userAccount_NewAccount.UIN;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UserNameColumn] = userAccount_NewAccount.UserName;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UserPasswordColumn] = userAccount_NewAccount.Password;

        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UserFirstNameColumn] = userAccount_NewAccount.FirstName;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UserLastNameColumn] = userAccount_NewAccount.LastName;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UserMiddleNameColumn] = userAccount_NewAccount.SecondName;

        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.EMailColumn] = userAccount_NewAccount.EMail;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.ICQColumn] = userAccount_NewAccount.ICQ;

        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.CompanyColumn] = userAccount_NewAccount.Work;

        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.WorkPhoneColumn] = userAccount_NewAccount.WorkPhone;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.HomePhoneColumn] = userAccount_NewAccount.HomePhone;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.PrivateCellularColumn] = userAccount_NewAccount.MobilePhone;

        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;

        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.EnabledAccountStateColumn] = userAccount_NewAccount.IsEnabled;

        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.ActivationCodeColumn] = userAccount_NewAccount.ActivationCode;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.IsActivatedColumn] = userAccount_NewAccount.IsActivated;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.ActivationTimeColumn] = DateTime.MinValue;        

        if (userAccount_NewAccount.IsActivated == true)
        {
            dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.ActivationTimeColumn] = userAccount_NewAccount.ActivationTime;
        }


        ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase.Rows.Add(dataRow_NewRecord);

    }

    public static bool AddNewUser(ServersNetworkSecurity.UserAccount userAccount_NewAccount)
    {
        ServersNetworkSecurity.UserAccount.UsersAccounts.Add(userAccount_NewAccount);

        ObjCopy.obj_MainForm.AddServerAccountToListView(userAccount_NewAccount);

        return true;
    }

    public bool RemotingWrapper_AddNewUser(string string_UIN, string string_UserName, string string_Password, string string_FirstName,
                string string_SecondName, string string_LastName, string string_ICQ, string string_EMail,
                string string_Work, string string_HomePhone, string string_WorkPhone, string string_MobilePhone, bool bool_IsAccountEnabled, bool bool_IsAccountActivated)
    {

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

        userAccount_NewAccount.ActivationCode = 0;
        userAccount_NewAccount.IsActivated = bool_IsAccountActivated;

        userAccount_NewAccount.IsEnabled = false;
        userAccount_NewAccount.Password = string_Password;
        userAccount_NewAccount.UIN = string_UIN;
        userAccount_NewAccount.UserName = string_UserName;
        userAccount_NewAccount.CreationTime = DateTime.Now;

        return ServersNetworkSecurity.AddNewUser(userAccount_NewAccount);
    }

    public void RemotingWrapper_StoreUserAccountToDB(string string_UserName, string string_Login, string string_Password, string string_FirstName, string string_LastName,
        string string_MiddleName, string string_EMailAddress, string string_ICQ, string string_Company, string string_WorkPhone, string string_HomePhome, string string_PrivateCellular,
        DateTime dateTime_CreationTime, DateTime dateTime_ActivationTime, bool bool_IsAccountEnabled, bool bool_IsAccountActivated)
    {
        DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable serversSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase;

        ////////////////////////////////////////////////////////////////////////////////

        DataRow dataRow_NewRecord = null;

        dataRow_NewRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase.NewRow();

        int int_SecurityDataBaseID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (serversSecurityDataBaseDataTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= serversSecurityDataBaseDataTable_obj.Rows.Count
            || (int)serversSecurityDataBaseDataTable_obj.Rows[int_CycleCount][serversSecurityDataBaseDataTable_obj.IDColumn] == int_SecurityDataBaseID)
            {
                int_SecurityDataBaseID++;
                int_CycleCount = -1;
                continue;
            }

            else if (int_CycleCount + 1 == serversSecurityDataBaseDataTable_obj.Rows.Count) break;
        }

        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.IDColumn] = int_SecurityDataBaseID;

        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UINColumn] = string_Login;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UserNameColumn] = string_UserName;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UserPasswordColumn] = string_Password;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.EnabledAccountStateColumn] = bool_IsAccountEnabled;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UserNameColumn] = string_FirstName;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UserLastNameColumn] = string_LastName;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.UserMiddleNameColumn] = string_MiddleName;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.EMailColumn] = string_EMailAddress;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.ICQColumn] = string_ICQ;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.CompanyColumn] = string_Company;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.WorkPhoneColumn] = string_WorkPhone;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.HomePhoneColumn] = string_HomePhome;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.PrivateCellularColumn] = string_PrivateCellular;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.ActivationTimeColumn] = dateTime_ActivationTime;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.IsActivatedColumn] = bool_IsAccountActivated;
        dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.IsEnabledColumn] = bool_IsAccountEnabled;


        if (bool_IsAccountActivated == true)
        {
            dataRow_NewRecord[serversSecurityDataBaseDataTable_obj.ActivationTimeColumn] = dateTime_ActivationTime;
        }

        ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase.Rows.Add(dataRow_NewRecord);

        ////////////////////////////////////////////////////////////////////////////////////////
    }

    public static int GetYakSysAccountRealRowIndex(int int_AccountIndex)
    {
        int int_RealDBRowAccountIndex = 0;

        //Calculate real DB Row account index (Windows Accounts not stored in JsDB)
        for (int int_CycleCount = 0; int_CycleCount != UserAccount.UsersAccounts.Count; int_CycleCount++)
        {
            if (UserAccount.UsersAccounts[int_AccountIndex] == UserAccount.UsersAccounts[int_CycleCount])
            {
                break;
            }
        }

        return int_RealDBRowAccountIndex;
    }
    public int RemotingWrapper_GetYakSysAccountRealRowIndex(int int_AccountIndex)
    {
        return ServersNetworkSecurity.GetYakSysAccountRealRowIndex(int_AccountIndex);
    }


    public static void RemoveAccount(int int_AccountIndex)
    {
        BaseChannelObject baseChannelObject_CurrentObj = null;

        UserAccount.UsersAccounts[int_AccountIndex].IsEnabled = false;

        for (; 0 != UserAccount.UsersAccounts[int_AccountIndex].ClientsUsingAccount.Count; )
        {
            baseChannelObject_CurrentObj = UserAccount.UsersAccounts[int_AccountIndex].ClientsUsingAccount[0];

            if (baseChannelObject_CurrentObj.RequestToDisconnect == true) continue;

            baseChannelObject_CurrentObj.Disconnect(4);
        }

        UserAccount.UsersAccounts[int_AccountIndex].DisconnectAllClients();

        new YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment().RemoveServersSecurityDataBaseRow(GetYakSysAccountRealRowIndex(int_AccountIndex));

        UserAccount.UsersAccounts.RemoveAt(int_AccountIndex);
    }
    public void RemotingWrapper_RemoveAccount(int int_AccountIndex)
    {
        ServersNetworkSecurity.RemoveAccount(int_AccountIndex);
    }

    public static void ClearAccounts()
    {
        BaseChannelObject baseChannelObject_CurrentObj = null;

        foreach (UserAccount obj_UserAccount in UserAccount.UsersAccounts)
        {

            for (; 0 != obj_UserAccount.ClientsUsingAccount.Count; )
            {
                baseChannelObject_CurrentObj = obj_UserAccount.ClientsUsingAccount[0];

                if (baseChannelObject_CurrentObj.RequestToDisconnect == true) continue;

                baseChannelObject_CurrentObj.Disconnect(4);
            }

            obj_UserAccount.IsEnabled = false;

        }

        UserAccount.UsersAccounts.Clear();

        YakSys.ConnectingServiceXMLConfigImporter.YakSysConnectingServiceDBEnvironment.ClearServersSecurityDataBase();
    }
    public void RemotingWrapper_ClearAccounts()
    {
        ServersNetworkSecurity.ClearAccounts();
    }

    public static void ClearAccessRestrictionRules()
    {
        AccessRestrictionRuleObject.AccessRestrictionRules.Clear();

        YakSysConnectingServiceDBEnvironment.ClearServersAccessRestrictionRulesDataBase();
    }
    public void RemotingWrapper_ClearAccessRestrictionRules()
    {
        ServersNetworkSecurity.ClearAccessRestrictionRules();
    }

    static void EditUserAccountInDB(string string_FirstName, string string_LastName, string string_MiddleName, string string_EMailAddress, string string_ICQ, string string_Company, string string_WorkPhone, string string_HomePhome, string string_PrivateCellular, int int_EditedRecordIndex)
    {
        DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable serversSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase;

        int_EditedRecordIndex = GetYakSysAccountRealRowIndex(int_EditedRecordIndex);

        DataRow dataRow_EditedRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase[int_EditedRecordIndex];

        dataRow_EditedRecord[serversSecurityDataBaseDataTable_obj.UserNameColumn] = string_FirstName;
        dataRow_EditedRecord[serversSecurityDataBaseDataTable_obj.UserLastNameColumn] = string_LastName;
        dataRow_EditedRecord[serversSecurityDataBaseDataTable_obj.UserMiddleNameColumn] = string_MiddleName;
        dataRow_EditedRecord[serversSecurityDataBaseDataTable_obj.EMailColumn] = string_EMailAddress;
        dataRow_EditedRecord[serversSecurityDataBaseDataTable_obj.ICQColumn] = string_ICQ;
        dataRow_EditedRecord[serversSecurityDataBaseDataTable_obj.CompanyColumn] = string_Company;
        dataRow_EditedRecord[serversSecurityDataBaseDataTable_obj.WorkPhoneColumn] = string_WorkPhone;
        dataRow_EditedRecord[serversSecurityDataBaseDataTable_obj.HomePhoneColumn] = string_HomePhome;
        dataRow_EditedRecord[serversSecurityDataBaseDataTable_obj.PrivateCellularColumn] = string_PrivateCellular;
    }
    public void RemotingWrapper_EditUserAccountInDB(string string_FirstName, string string_LastName, string string_MiddleName, string string_EMailAddress, string string_ICQ, string string_Company, string string_WorkPhone, string string_HomePhome, string string_PrivateCellular, int int_EditedRecordIndex)
    {
        ServersNetworkSecurity.EditUserAccountInDB(string_FirstName, string_LastName, string_MiddleName, string_EMailAddress, string_ICQ, string_Company, string_WorkPhone, string_HomePhome, string_PrivateCellular, int_EditedRecordIndex);
    }

    public static void RemoveExistingRule(int int_RuleIndex)
    {
        AccessRestrictionRuleObject.AccessRestrictionRules.RemoveAt(int_RuleIndex);
    }
    public void RemotingWrapper_RemoveExistingRule(int int_RuleIndex)
    {
        ClientsNetworkSecurity.RemoveExistingRule(int_RuleIndex);
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

        ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Add(accessRestrictionRuleObject_NewRule);
    }
    public void RemotingWrapper_StoreAccessRestrictionRuleToDB(string string_IPRangeStartValue, string string_IPRangeEndValue, string string_IPAddressValue, string string_MACAddress, bool bool_ComplementaryUseMACAddress, DateTime dateTime_CreationTime, int int_RuleType, bool bool_IsRuleEnabled)
    {
        DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable serversAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules;

        ////////////////////////////////////////////////////////////////////////////////

        DataRow dataRow_NewRecord = null;

        dataRow_NewRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.NewRow();

        int int_AccessRestrictionRulesID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (serversAccessRestrictionRulesDataTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= serversAccessRestrictionRulesDataTable_obj.Rows.Count
                || (int)serversAccessRestrictionRulesDataTable_obj.Rows[int_CycleCount][serversAccessRestrictionRulesDataTable_obj.IDColumn] == int_AccessRestrictionRulesID)
            {
                int_AccessRestrictionRulesID++;
                int_CycleCount = -1;
                continue;
            }

            else if (int_CycleCount + 1 == serversAccessRestrictionRulesDataTable_obj.Rows.Count) break;
        }

        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.IDColumn] = int_AccessRestrictionRulesID;

        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn] = string_IPRangeStartValue;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn] = string_IPRangeEndValue;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.IPAddressColumn] = string_IPAddressValue;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn] = bool_ComplementaryUseMACAddress;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.MACAddressColumn] = string_MACAddress;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.RuleTypeColumn] = int_RuleType;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;
        dataRow_NewRecord[serversAccessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn] = bool_IsRuleEnabled;

        ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.Add(dataRow_NewRecord);
    }
    public void RemotingWrapper_AddNewAccessRestrictionRule(IPAddress iPAddress_IPAddressesRangeStartValue, IPAddress iPAddress_IPAddressesRangeEndValue, IPAddress iPAddress_IPAddress, string string_MACAddress, bool bool_ComplementaryUseMACAddress, DateTime dateTime_CreationTime, int int_RuleType, bool bool_IsRuleEnabled)
    {
        ClientsNetworkSecurity.AddNewAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress, string_MACAddress, bool_ComplementaryUseMACAddress, dateTime_CreationTime, int_RuleType, bool_IsRuleEnabled);
    }

    public static void EditExistingAccessRestrictionRule(IPAddress iPAddress_IPAddressesRangeStartValue, IPAddress iPAddress_IPAddressesRangeEndValue, IPAddress iPAddress_IPAddress, string string_MACAddress, bool bool_ComplementaryUseMACAddress, DateTime dateTime_CreationTime, int int_RuleType, int int_RuleIndex)
    {
        AccessRestrictionRuleObject accessRestrictionRuleObject_NewRule = ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[int_RuleIndex];

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
        ServersNetworkSecurity.EditExistingAccessRestrictionRule(iPAddress_IPAddressesRangeStartValue, iPAddress_IPAddressesRangeEndValue, iPAddress_IPAddress, string_MACAddress, bool_ComplementaryUseMACAddress, dateTime_CreationTime, int_RuleType, int_RuleIndex);
    }
    public void RemotingWrapper_EditExistingAccessRestrictionRuleInDB(string string_IPAddressesRangeStartValue, string string_IPAddressesRangeEndValue, string string_IPAddress, string string_MACAddress, bool bool_ComplementaryUseMACAddress, int int_RuleType, int int_RuleIndex)
    {
        DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable ServersAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules;

        DataRow dataRow_EditedRecord = null;

        dataRow_EditedRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules[int_RuleIndex];

        dataRow_EditedRecord[ServersAccessRestrictionRulesDataTable_obj.IPRangeStartValueColumn] = string_IPAddressesRangeStartValue;
        dataRow_EditedRecord[ServersAccessRestrictionRulesDataTable_obj.IPRangeEndValueColumn] = string_IPAddressesRangeEndValue;
        dataRow_EditedRecord[ServersAccessRestrictionRulesDataTable_obj.IPAddressColumn] = string_IPAddress;
        dataRow_EditedRecord[ServersAccessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn] = bool_ComplementaryUseMACAddress;
        dataRow_EditedRecord[ServersAccessRestrictionRulesDataTable_obj.MACAddressColumn] = string_MACAddress;
        dataRow_EditedRecord[ServersAccessRestrictionRulesDataTable_obj.RuleTypeColumn] = int_RuleType;
    }


    public static bool AuthorizeConnectedUser(ref BaseChannelObject baseConnectedObject_obj, string string_Login, string string_Password)
    {
        bool bool_IsAuthUser = false;

        ServersNetworkSecurity.UserAccount userAccount_CurrentUser = null;

        for (int int_CycleCount = 0; int_CycleCount != ServersNetworkSecurity.UserAccount.UsersAccounts.Count; int_CycleCount++)
        {
            if (ServersNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].UIN == string_Login)
            {
                userAccount_CurrentUser = ServersNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount];

                if (string_Password == ServersNetworkSecurity.UserAccount.UsersAccounts[int_CycleCount].Password)
                {
                    bool_IsAuthUser = true;

                    baseConnectedObject_obj.NetworkInformation_AccountType = StringFactory.GetString(756, MainForm.CurrentLanguage);
                    baseConnectedObject_obj.NetworkInformation_UserName = userAccount_CurrentUser.UserName;
                }

                baseConnectedObject_obj.IsAccountEnabled = userAccount_CurrentUser.IsEnabled;
                baseConnectedObject_obj.IsActivated = userAccount_CurrentUser.IsActivated;

                userAccount_CurrentUser.AddClient(baseConnectedObject_obj); //!!!!? надо ли добавлять клиента если он не прошел авторизацию ? походу да

                break;
            }
        }

        return bool_IsAuthUser;
    }
    public bool RemotingWrapper_AuthorizeConnectedUser(ref BaseChannelObject baseConnectedObject_obj, string string_Login, string string_Password)
    {
        return ServersNetworkSecurity.AuthorizeConnectedUser(ref baseConnectedObject_obj, string_Login, string_Password);
    }

    public static bool CheckAccessPossible(IPAddress iPAddress_IPAddress, string string_MACAddress)
    {
        if (CommonEnvironment.IsServerAccessRestrictionRuleEnable == false) return true;

        if (AccessRestrictionRuleObject.AccessRestrictionRules.Count == 0) return false;

        bool bool_Result = false, bool_IsEnabledRulesInDB = false;

        int int_RuleType = 0;

        foreach (AccessRestrictionRuleObject accessRestrictionRuleObject_obj in AccessRestrictionRuleObject.AccessRestrictionRules)
        {
            int_RuleType = accessRestrictionRuleObject_obj.RuleType;

            if (accessRestrictionRuleObject_obj.IsEnabled == false) continue;
            else bool_IsEnabledRulesInDB = true;

            if (accessRestrictionRuleObject_obj.IPAddressesRangeStartValue != null &&
                UserAccountsAndAccessRestrictionRulesEnvironment.IsSecondIPAddressBiggerOrEquals(accessRestrictionRuleObject_obj.IPAddressesRangeStartValue, iPAddress_IPAddress) == true &&
                UserAccountsAndAccessRestrictionRulesEnvironment.IsSecondIPAddressBiggerOrEquals(accessRestrictionRuleObject_obj.IPAddressesRangeEndValue, iPAddress_IPAddress) == false)
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
        return ServersNetworkSecurity.CheckAccessPossible(iPAddress_IPAddress, string_MACAddress);
    }

    [Serializable]
    public class UserAccount : MarshalByRefObject
    {
        static List<ServersNetworkSecurity.UserAccount> list_UsersAccounts = new List<ServersNetworkSecurity.UserAccount>();
        public static List<ServersNetworkSecurity.UserAccount> UsersAccounts
        {
            get
            {
                return list_UsersAccounts;
            }
        }
        public List<ServersNetworkSecurity.UserAccount> RemotingWrapper_UsersAccounts
        {
            get
            {
                return ServersNetworkSecurity.UserAccount.UsersAccounts;
            }
        }
        
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

        string string_UserName = String.Empty;
        public string UserName
        {
            get
            {
                return string_UserName;
            }

            set
            {
                string_UserName = value;
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

        DateTime dateTime_CreationTime = DateTime.Now;
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

        List<BaseChannelObject> list_ClientsUsingAccount = new List<BaseChannelObject>();

        public List<BaseChannelObject> ClientsUsingAccount
        {
            get
            {
                return list_ClientsUsingAccount;
            }
        }

        public void AddClient(BaseChannelObject YakSysTcpClient_obj)
        {
            YakSysTcpClient_obj.IsAccountEnabled = IsEnabled;

            ClientsUsingAccount.Add(YakSysTcpClient_obj);
        }

        public void DisconnectAllClients()
        {
            BaseChannelObject baseChannelObject_CurrentObj = null;

            this.IsEnabled = false;

            for (; 0 != this.ClientsUsingAccount.Count; )
            {
                baseChannelObject_CurrentObj = this.ClientsUsingAccount[0];

                if (baseChannelObject_CurrentObj.RequestToDisconnect == true) continue;

                baseChannelObject_CurrentObj.Disconnect(5);
            }
        }

        public void ChangeAccountState()
        {
            BaseChannelObject baseChannelObject_CurrentObj = null;

            LocalAction localAction_obj = new LocalAction();

            for (int int_intCycleCount = 0; int_intCycleCount != ClientsUsingAccount.Count; int_intCycleCount++)
            {
                baseChannelObject_CurrentObj = ClientsUsingAccount[int_intCycleCount];

                localAction_obj.NecessaryBaseChannelObject = baseChannelObject_CurrentObj;

                if (baseChannelObject_CurrentObj.IsAccountEnabled == IsEnabled ||
                    baseChannelObject_CurrentObj.RequestToDisconnect)
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
            DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable serversSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase;

            this.IsEnabled = false;

            this.ChangeAccountState();

            int int_RealDBRowAccountIndex = UsersAccounts.IndexOf(this);

            serversSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][serversSecurityDataBaseDataTable_obj.EnabledAccountStateColumn] = false;
        }

        public void EnableAccount()
        {
            DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable serversSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase;

            this.IsEnabled = true;

            this.ChangeAccountState();
            int int_RealDBRowAccountIndex = UsersAccounts.IndexOf(this);

            serversSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][serversSecurityDataBaseDataTable_obj.EnabledAccountStateColumn] = true;
        }

        public void ActivateAccount()
        {
            DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable serversSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase;

            this.IsActivated = true;
            this.ActivationTime = DateTime.Now;

            int int_RealDBRowAccountIndex = UsersAccounts.IndexOf(this);

            serversSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][serversSecurityDataBaseDataTable_obj.IsActivatedColumn] = true;
            serversSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][serversSecurityDataBaseDataTable_obj.ActivationTimeColumn] = this.ActivationTime;
        }

        public void DeActivateAccount()
        {
            DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable serversSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase;

            this.IsActivated = false;
            this.ActivationTime = DateTime.Now;

            int int_RealDBRowAccountIndex = UsersAccounts.IndexOf(this);

            serversSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][serversSecurityDataBaseDataTable_obj.IsActivatedColumn] = false;
            serversSecurityDataBaseDataTable_obj[int_RealDBRowAccountIndex][serversSecurityDataBaseDataTable_obj.ActivationTimeColumn] = this.ActivationTime;
        }
        
        public void RemoveAccount()
        {
            UsersAccounts.Remove(this);
        }
    }

    [Serializable]
    public class AccessRestrictionRuleObject : MarshalByRefObject
    {
        static List<ServersNetworkSecurity.AccessRestrictionRuleObject> list_AccessRestrictionRuleInfo = new List<ServersNetworkSecurity.AccessRestrictionRuleObject>();
        public static List<ServersNetworkSecurity.AccessRestrictionRuleObject> AccessRestrictionRules
        {
            get
            {
                return list_AccessRestrictionRuleInfo;
            }
        }
        public List<ServersNetworkSecurity.AccessRestrictionRuleObject> RemotingWrapper_AccessRestrictionRules
        {
            get
            {
                return ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules;
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
            DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable serversAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules;

            this.IsEnabled = false;

            int int_RealDBRowAccountIndex = AccessRestrictionRules.IndexOf(this);

            serversAccessRestrictionRulesDataTable_obj[int_RealDBRowAccountIndex][serversAccessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn] = false;
        }

        public void EnableRule()
        {
            DataSet_ConnectingServiceDB.ServersAccessRestrictionRulesDataTable serversAccessRestrictionRulesDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules;

            this.IsEnabled = true;

            int int_RealDBRowAccountIndex = AccessRestrictionRules.IndexOf(this);

            serversAccessRestrictionRulesDataTable_obj[int_RealDBRowAccountIndex][serversAccessRestrictionRulesDataTable_obj.IsRestrictionEnabledColumn] = true;
        }
    }
}



