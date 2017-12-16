using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ServiceProcess;
using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.Win32;
using YakSysConnectingService;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        ObjCopy.obj_MainForm = this;
    }




    private void MainForm_Load(object sender, System.EventArgs e)
    {
        if (File.Exists("ConnectingServiceDB") && new FileInfo("ConnectingServiceDB").Length > 500)
        {
            FileStream fileStream_ConnectingServiceXMLDB = null;

            try
            {
                fileStream_ConnectingServiceXMLDB = File.Open("ConnectingServiceDB", FileMode.Open, FileAccess.Read, FileShare.Read);
            }

            catch (Exception)
            {
                MessageBox.Show(ServerStringFactory.GetString(128, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

                new ConnectingServiceDBSupplier().InitMainServerXmlDB();

                ObjCopy.obj_MainForm.SetUpServerSettingsFromDB();

                return;
            }

            ConnectingServiceDBSupplier ConnectingServiceDBSupplier_obj = new ConnectingServiceDBSupplier();

            byte[] byteArray_ConnectingServiceDBHeader = new byte[22];

            fileStream_ConnectingServiceXMLDB.Read(byteArray_ConnectingServiceDBHeader, 0, byteArray_ConnectingServiceDBHeader.Length);

            if (CommonMethods.AreBytesArraysEquals(System.Text.Encoding.Default.GetBytes("ConnectingServiceDB010"), byteArray_ConnectingServiceDBHeader) == false)
            {
                fileStream_ConnectingServiceXMLDB.Close();

                new ConnectingServiceDBSupplier().InitMainServerXmlDB();

                ObjCopy.obj_MainForm.SetUpServerSettingsFromDB();

                MessageBox.Show(ServerStringFactory.GetString(96, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

                return;
            }

            int int_IsDataEncrypted = fileStream_ConnectingServiceXMLDB.ReadByte();
            int int_IsDataCompressed = fileStream_ConnectingServiceXMLDB.ReadByte();

            byte[] byteArray_XMLData = new byte[fileStream_ConnectingServiceXMLDB.Length - 88];

            MemoryStream memoryStream_XMLData = null;

            fileStream_ConnectingServiceXMLDB.Position = 88;

            fileStream_ConnectingServiceXMLDB.Read(byteArray_XMLData, 0, byteArray_XMLData.Length);

            fileStream_ConnectingServiceXMLDB.Close();

            if (int_IsDataEncrypted == 1)
            {
                PasswordVerificationForm passwordVerificationForm_obj = new PasswordVerificationForm();

                passwordVerificationForm_obj.ShowDialog();

                ObjCopy.obj_MainForm.SetUpServerSettingsFromDB();

                return;
            }

            if (int_IsDataEncrypted == 0 && int_IsDataCompressed == 1)
            {
                memoryStream_XMLData = ConnectingServiceDBSupplier.DecompressXMLDataFile("ConnectingServiceDB");

                ConnectingServiceDBSupplier_obj.RetriveServerSettingsData(memoryStream_XMLData);

                CommonEnvironment.CompressSettingsDataBase = true;
            }
            else CommonEnvironment.CompressSettingsDataBase = false;

            if (int_IsDataEncrypted == 0 && int_IsDataCompressed == 0)
            {
                ConnectingServiceDBSupplier_obj.RetriveServerSettingsData(new MemoryStream(byteArray_XMLData));
            }
        }

        else
        {
            new ConnectingServiceDBSupplier().InitMainServerXmlDB();
        }

        SubscribeToNetworkEvents();

        SubscribeToLogEvents();

        ObjCopy.obj_MainForm.SetUpServerSettingsFromDB();
    }


    private void ImportServerDB(string string_DBFileName)
    {
        if (File.Exists(string_DBFileName) && new FileInfo(string_DBFileName).Length > 500)
        {
            FileStream fileStream_ConnectingServiceXMLDB = File.Open(string_DBFileName, FileMode.Open, FileAccess.Read);

            byte[] byteArray_ConnectingServiceDBHeader = new byte[22];

            fileStream_ConnectingServiceXMLDB.Read(byteArray_ConnectingServiceDBHeader, 0, byteArray_ConnectingServiceDBHeader.Length);

            if (CommonMethods.AreBytesArraysEquals(System.Text.Encoding.Default.GetBytes("ConnectingServiceDB010"), byteArray_ConnectingServiceDBHeader) == false)
            {
                fileStream_ConnectingServiceXMLDB.Close();

                MessageBox.Show(ServerStringFactory.GetString(124, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));

                return;
            }


            int int_IsDataEncrypted = fileStream_ConnectingServiceXMLDB.ReadByte();
            int int_IsDataCompressed = fileStream_ConnectingServiceXMLDB.ReadByte();

            byte[] byteArray_XMLData = new byte[fileStream_ConnectingServiceXMLDB.Length - 88];

            MemoryStream memoryStream_XMLData = null;

            fileStream_ConnectingServiceXMLDB.Position = 88;

            fileStream_ConnectingServiceXMLDB.Read(byteArray_XMLData, 0, byteArray_XMLData.Length);

            fileStream_ConnectingServiceXMLDB.Close();

            if (int_IsDataEncrypted == 1)
            {
                PasswordPromptForm passwordPromptForm_obj = new PasswordPromptForm();

                passwordPromptForm_obj.DBFileName = string_DBFileName;

                if (passwordPromptForm_obj.ShowDialog() == DialogResult.Cancel) return;

                ObjCopy.obj_MainForm.SetUpServerSettingsFromDB();

                return;
            }

            if (int_IsDataEncrypted == 0 && int_IsDataCompressed == 1)
            {
                memoryStream_XMLData = ConnectingServiceDBSupplier.DecompressXMLDataFile(string_DBFileName);

                if (memoryStream_XMLData == null) return;

                ConnectingServiceDBSupplier ConnectingServiceDBSupplier_obj = new ConnectingServiceDBSupplier();

                ConnectingServiceDBSupplier_obj.RetriveServerSettingsData(memoryStream_XMLData);

                CommonEnvironment.CompressSettingsDataBase = true;

                ObjCopy.obj_MainForm.SetUpServerSettingsFromDB();
            }

            if (int_IsDataEncrypted == 0 && int_IsDataCompressed == 0)
            {
                memoryStream_XMLData = new MemoryStream(byteArray_XMLData);

                ConnectingServiceDBSupplier ConnectingServiceDBSupplier_obj = new ConnectingServiceDBSupplier();

                ConnectingServiceDBSupplier_obj.RetriveServerSettingsData(memoryStream_XMLData);

                CommonEnvironment.CompressSettingsDataBase = false;

                ObjCopy.obj_MainForm.SetUpServerSettingsFromDB();
            }
        }

        else return;
    }


    public void SetUpServerSettingsFromDB()
    {
        ConnectingServiceDBSupplier ConnectingServiceDBSupplier_obj = new ConnectingServiceDBSupplier();

        this.ServerPort = CommonEnvironment.ServerPort;

        this.listView_ClientsAccounts_ClientsAccounts.Items.Clear();
        this.listView_ClientsRestrictionRules_RulestList.Items.Clear();

        this.listView_ServersAccounts_ServersAccounts.Items.Clear();
        this.listView_ServersRestrictionRules_RulestList.Items.Clear();

        ConnectingServiceDBSupplier_obj.FillCommonEventsLog();
        ConnectingServiceDBSupplier_obj.FillClientsEventsLog();
        ConnectingServiceDBSupplier_obj.FillServersEventsLog();

        ConnectingServiceDBSupplier_obj.FillClientsSecurityDataBase();
        ConnectingServiceDBSupplier_obj.FillServersSecurityDataBase();

        ConnectingServiceDBSupplier_obj.LoadClientsAccessRestrictionRules();
        ConnectingServiceDBSupplier_obj.LoadServersAccessRestrictionRules();

        notifyIcon_Main.DoubleClick += new System.EventHandler(ObjCopy.obj_MainForm.RestoreWindowFromSystemTray);
        notifyIcon_Main.Text = "YakSys Connecting Service";
        notifyIcon_Main.Icon = ObjCopy.obj_MainForm.Icon;
        

        if (CommonEnvironment.StartServerAtRun == true)
        {
            new Thread(new ThreadStart(ObjCopy.obj_NetworkAction.StartServer)).Start();
        }

        this.notifyIcon_Main.Visible = CommonEnvironment.ShowIconInNotifyArea;

        this.checkBox_ClientsRestrictionRules_UseRestrictionRules.Checked = CommonEnvironment.IsClientAccessRestrictionRuleEnable;
        this.checkBox_ServersRestrictionRules_UseRestrictionRules.Checked = CommonEnvironment.IsServerAccessRestrictionRuleEnable;

        this.checkBox_ClientsRestrictionRules_UseRestrictionRules_CheckedChanged(null, null);
        this.checkBox_ServersRestrictionRules_UseRestrictionRules_CheckedChanged(null, null);

        this.checkBox_MainWindowParameters_ShowInNotifyArea.Checked = CommonEnvironment.ShowIconInNotifyArea;

        if (CommonEnvironment.ActivateHiddenModeAtStartUp == true)
        {
            this.ActivateHiddenMode();
        }
        else
        {
            if (CommonEnvironment.MinimizeToNotifyAreaAtRun == true)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = this.Visible = false;
            }
        }

    }


    private void WriteServerSettingsToDB()
    {
        int int_ParsedPort = 5545;

        if (int.TryParse(this.textBox_Main_ListeningPort.Text, out int_ParsedPort) == false)
        {
            CommonEnvironment.ServerPort = 5545;
        }

        ConnectingServiceDBSupplier ConnectingServiceDBSupplier_obj = new ConnectingServiceDBSupplier();

        ConnectingServiceDBSupplier_obj.WriteServerSettingsData(Application.StartupPath + "\\ConnectingServiceDB");
    }


    private void RestoreWindowFromSystemTray(object sender, System.EventArgs e)
    {
        this.ShowInTaskbar = true;

        notifyIcon_Main.Visible = CommonEnvironment.ShowIconInNotifyArea;

        this.WindowState = FormWindowState.Normal;

        this.tabControl_Main.SelectedIndex = 1;
        this.tabControl_Main.SelectedIndex = 0;

        this.Visible = true;
    }




    private void MainForm_Activated(object sender, System.EventArgs e)
    {
        this.ShowInTaskbar = true;

        if (this.ShowInTaskbar == true)
        {
            notifyIcon_Main.Visible = CommonEnvironment.ShowIconInNotifyArea = this.checkBox_MainWindowParameters_ShowInNotifyArea.Checked;
        }
    }


    private void menuItem_Help_Register_Click(object sender, System.EventArgs e)
    {
        new RegistrationForm().ShowDialog();
    }





    public void MinimizeToNotifyArea()
    {
        this.Visible = this.ShowInTaskbar = false;

        notifyIcon_Main.Visible = true;
    }


    public void ActivateHiddenMode()
    {
        notifyIcon_Main.Visible = this.Visible = this.ShowInTaskbar = false;
    }


    public void MinimizeToTaskBar()
    {
        this.WindowState = FormWindowState.Minimized;
    }




    public void YakSysConnectingServiceServer()
    {
        if (DialogResult.Yes == MessageBox.Show(this, ServerStringFactory.GetString(39, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            notifyIcon_Main.Visible = false;

            ObjCopy.obj_NetworkAction.StopServer();

            WriteServerSettingsToDB();

            Process.GetCurrentProcess().Kill();
        }
    }

    private void menuItem_File_Exit_Click(object sender, EventArgs e)
    {
        YakSysConnectingServiceExit();
    }



    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {

        e.Cancel = true;

        notifyIcon_Main.Visible = false;

        YakSysConnectingServiceExit();

    }

    public void YakSysConnectingServiceExit()
    {
        if (DialogResult.Yes == MessageBox.Show(this, ServerStringFactory.GetString(39, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            notifyIcon_Main.Visible = false;

            ObjCopy.obj_NetworkAction.StopServer();

            WriteServerSettingsToDB();

            Process.GetCurrentProcess().Kill();
        }
    }





    #region Network Events Processing

    public void OnNewInterConnectionEvent(ConnectedServer.AppliedServerChannel appliedServerChannel_obj, ConnectedClient.AppliedClientChannel appliedClientChannel_obj)
    {
        if (this.IsHandleCreated == false) return;
        try
        {
            this.Invoke((MethodInvoker)delegate
            {
                ListViewItem listViewItem_ActiveInterConnection = new ListViewItem(appliedServerChannel_obj.BaseChannel.UIN.ToString(), 0);
                listViewItem_ActiveInterConnection.SubItems.Add(appliedServerChannel_obj.BaseChannel.IPAddress);

                listViewItem_ActiveInterConnection.SubItems.Add(appliedClientChannel_obj.BaseChannel.UIN.ToString());
                listViewItem_ActiveInterConnection.SubItems.Add(appliedClientChannel_obj.BaseChannel.IPAddress);

                listViewItem_ActiveInterConnection.SubItems.Add(DateTime.Now.ToString());

                listViewItem_ActiveInterConnection.Tag = appliedClientChannel_obj;

                this.listView_ActiveInterConnections_ConnectionsList.Items.Add(listViewItem_ActiveInterConnection);

            });
        }

        catch (Exception ex)
        {
        }
    }

    public void OnNewClientConnectedEvent(ConnectedClient ñonnectedClient_obj)
    {
        if (this.IsHandleCreated == false) return;
        try
        {
            this.Invoke((MethodInvoker)delegate
            {
                ListViewItem listViewItem_NewConnectedClient = new ListViewItem(ñonnectedClient_obj.UIN.ToString(), 0);

                listViewItem_NewConnectedClient.SubItems.Add(ñonnectedClient_obj.SystemChannel.BaseChannel.NetworkInformation_UserName);
                listViewItem_NewConnectedClient.SubItems.Add(ñonnectedClient_obj.SystemChannel.BaseChannel.IPAddress);
                listViewItem_NewConnectedClient.SubItems.Add(DateTime.Now.ToString());
                listViewItem_NewConnectedClient.SubItems.Add("Active");

                listViewItem_NewConnectedClient.Tag = ñonnectedClient_obj;

                this.listView_ConnectedUsers_ConnectedClients.Items.Add(listViewItem_NewConnectedClient);


            });
        }
        catch
        {
        }
    }

    public void OnNewServerConnectedEvent(ConnectedServer ñonnectedServer_obj)
    {
        if (this.IsHandleCreated == false) return;
        try
        {
            this.Invoke((MethodInvoker)delegate
            {

                ListViewItem listViewItem_NewConnectedServer = new ListViewItem(ñonnectedServer_obj.UIN.ToString(), 0);

                listViewItem_NewConnectedServer.SubItems.Add(ñonnectedServer_obj.SystemChannel.BaseChannel.NetworkInformation_UserName);
                listViewItem_NewConnectedServer.SubItems.Add(ñonnectedServer_obj.SystemChannel.BaseChannel.IPAddress);
                listViewItem_NewConnectedServer.SubItems.Add(DateTime.Now.ToString());
                listViewItem_NewConnectedServer.SubItems.Add("Active");

                listViewItem_NewConnectedServer.Tag = ñonnectedServer_obj;

                this.listView_ConnectedUsers_ConnectedServers.Items.Add(listViewItem_NewConnectedServer);


            });
        }
        catch
        {
        }
    }


    public void OnClientDisconnectedEvent(ConnectedClient ñonnectedClient_obj)
    {
        bool bool_NeedRecursiveCall = false;

        if (this.IsHandleCreated == false) return;
        try
        {
            this.Invoke((MethodInvoker)delegate //!!! ïîäâèñàåò UI èíîãäà çäåñü!!! ìîæåò èç çà ðåêóðñèè invoke ?!
            {
                foreach (ListViewItem listViewItem_Client in this.listView_ConnectedUsers_ConnectedClients.Items)
                {
                    if (listViewItem_Client.Tag == ñonnectedClient_obj)
                    {
                        this.listView_ConnectedUsers_ConnectedClients.Items.Remove(listViewItem_Client);

                        bool_NeedRecursiveCall = true;

                        break;
                    }
                }

            });

            if (bool_NeedRecursiveCall == true)
            {
                OnClientDisconnectedEvent(ñonnectedClient_obj);
            }
            bool_NeedRecursiveCall = false;

            //---------------------------------------------------------------------------------------------------------------------------

            this.Invoke((MethodInvoker)delegate //!!! ïîäâèñàåò UI èíîãäà çäåñü!!! ìîæåò èç çà ðåêóðñèè invoke ?!
            {

                foreach (ListViewItem listViewItem_InterConnectedObject in this.listView_ActiveInterConnections_ConnectionsList.Items)
                {
                    if (((ConnectedClient.AppliedClientChannel)listViewItem_InterConnectedObject.Tag).ChannelOwner == ñonnectedClient_obj)
                    {
                        this.listView_ActiveInterConnections_ConnectionsList.Items.Remove(listViewItem_InterConnectedObject);

                        bool_NeedRecursiveCall = true;

                        break;
                    }
                }
            });

            if (bool_NeedRecursiveCall == true)
            {
                OnClientDisconnectedEvent(ñonnectedClient_obj);
            }
            bool_NeedRecursiveCall = false;

        }
        catch
        {
        }
    }

    public void OnServerDisconnectedEvent(ConnectedServer ñonnectedServer_obj)
    {
        if (this.IsHandleCreated == false) return;
        try
        {
            this.Invoke((MethodInvoker)delegate
            {
                foreach (ListViewItem listViewItem_Server in this.listView_ConnectedUsers_ConnectedServers.Items)
                {
                    if (listViewItem_Server.Tag == ñonnectedServer_obj)
                    {
                        this.listView_ConnectedUsers_ConnectedServers.Items.Remove(listViewItem_Server);

                        return;
                    }
                }
            });
        }
        catch
        {
        }
    }


    public void SubscribeToNetworkEvents()
    {
        CommonNetworkEvents.NewInterConnectionEvent += OnNewInterConnectionEvent;

        CommonNetworkEvents.NewServerConnectedEvent += OnNewServerConnectedEvent;
        CommonNetworkEvents.NewClientConnectedEvent += OnNewClientConnectedEvent;

        CommonNetworkEvents.ServerDisconnectedEvent += OnServerDisconnectedEvent;
        CommonNetworkEvents.ClientDisconnectedEvent += OnClientDisconnectedEvent;
    }

    #endregion



    private void button_MainForm_StartServer_Click(object sender, EventArgs e)
    {
        int int_Port = 5545;

        if (int.TryParse(this.textBox_Main_ListeningPort.Text, out int_Port) == true)
        {
            if (int_Port < 10 || int_Port > 65535)
            {
                MessageBox.Show("port value must be between 10 and 65535");

                return;
            }
        }
        else
        {
            MessageBox.Show("port value must be decimal number");

            return;
        }

        CommonEnvironment.ServerPort = int_Port;

        new Thread(new ThreadStart(ObjCopy.obj_NetworkAction.StartServer)).Start();
    }

    private void button_Main_StopServer_Click(object sender, EventArgs e)
    {
        ObjCopy.obj_NetworkAction.StopServer();
    }



    private void button_Main_AdditionalParameters_Click(object sender, EventArgs e)
    {
        AdditionalParametersForm additionalParametersForm_obj = new AdditionalParametersForm();

        additionalParametersForm_obj.ShowDialog();
    }

    private void button_ClientsAccounts_AddAccount_Click(object sender, EventArgs e)
    {
        ClientsAccountsManagerForm clientsAccountsManagerForm_obj = new ClientsAccountsManagerForm();

        clientsAccountsManagerForm_obj.ApplyButton.Visible = false;

        clientsAccountsManagerForm_obj.ShowDialog();
    }

    private void button_ClientsAccounts_EditAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsAccounts_ClientsAccounts.SelectedItems.Count == 0) return;

        CommonEnvironment.EditClientUserAccount((int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[0].Tag);
    }

    private void button_ClientsAccounts_ViewAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsAccounts_ClientsAccounts.SelectedItems.Count == 0) return;

        CommonEnvironment.ViewClientUserAccount((int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[0].Tag);
    }

    private void button_ClientsAccounts_DisableAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsAccounts_ClientsAccounts.Items.Count == 0) return;

        if (this.listView_ClientsAccounts_ClientsAccounts.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(70, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(46, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        for (int int_CycleCount = 0; int_CycleCount != listView_ClientsAccounts_ClientsAccounts.SelectedItems.Count; int_CycleCount++)
        {
            this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].ImageIndex = 0;
            this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(47, MainForm.CurrentLanguage);

            if (ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].IsActivated == true)
            {
                this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].SubItems[5].Text += ", Activated";
            }

            ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].IsEnabled = false;
            ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].ChangeAccountState();
            ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].DisableAccount();

            #region Call Log Event

            string string_UserName = ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].UserName,
                    string_UIN = ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].UIN;

            ConnectingServiceLogsEvents.NewClientsLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), string_UserName, string_UIN, ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(48, MainForm.CurrentLanguage), false);

            #endregion
        }
    }

    private void button_ClientsAccounts_EnableAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsAccounts_ClientsAccounts.Items.Count == 0) return;

        if (this.listView_ClientsAccounts_ClientsAccounts.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(70, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(49, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        for (int int_CycleCount = 0; int_CycleCount != listView_ClientsAccounts_ClientsAccounts.SelectedItems.Count; int_CycleCount++)
        {
            this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].ImageIndex = 1;
            this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(50, MainForm.CurrentLanguage);

            if (ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].IsActivated == true)
            {
                this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].SubItems[5].Text += ", Activated";
            }

            ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].IsEnabled = true;
            ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].ChangeAccountState();
            ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].EnableAccount();


            #region Call Log Event

            string string_UserName = ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].UserName,
                    string_UIN = ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].UIN;

            ConnectingServiceLogsEvents.NewClientsLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), string_UserName, string_UIN, ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(48, MainForm.CurrentLanguage), false);

            #endregion
        }
    }

    public void RemoveClientsAccountFromListView(int int_AccountIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_ClientsAccounts_ClientsAccounts.Items[int_AccountIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_ClientsAccounts_ClientsAccounts.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_ClientsAccounts_ClientsAccounts.Items.RemoveAt(int_AccountIndex);

        #region Call Log Event

        string string_UserName = ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_AccountIndex].Tag].UserName,
                string_UIN = ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_AccountIndex].Tag].UIN;

        ConnectingServiceLogsEvents.NewClientsLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), string_UserName, string_UIN, ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(215, MainForm.CurrentLanguage), false);

        #endregion

    }



    private void button_ClientsAccounts_RemoveAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsAccounts_ClientsAccounts.Items.Count == 0) return;

        if (this.listView_ClientsAccounts_ClientsAccounts.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(70, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(52, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        for (int int_CycleCount = 0; this.listView_ClientsAccounts_ClientsAccounts.SelectedItems.Count != 0; int_CycleCount++)
        {
            if (this.listView_ClientsAccounts_ClientsAccounts.Items.Count == 0) return;

            ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[0].Tag].DisconnectAllClients();

            #region Call Log Event

            string string_UserName = ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[0].Tag].UserName,
                    string_UIN = ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[0].Tag].UIN;

            ConnectingServiceLogsEvents.NewClientsLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), string_UserName, string_UIN, ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(53, MainForm.CurrentLanguage), false);

            #endregion

            ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[0].Tag].RemoveAccount();

            ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase.Rows.RemoveAt((int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[0].Tag);

            RemoveClientsAccountFromListView((int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[0].Index);
        }
    }

    private void button_ClientsAccounts_ClearAccountsList_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsAccounts_ClientsAccounts.Items.Count < 1) return;

        if (DialogResult.Yes == MessageBox.Show(ServerStringFactory.GetString(145, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            /*
            for (int int_CycleCount = 0; int_CycleCount != this.listView_ClientsAccounts_ClientsAccounts.Items.Count; int_CycleCount++)
            {
                ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].Tag].IsEnabled = false;

                for (; 0 != ClientsNetworkSecurity.UserAccount.UsersAccounts.Count; )
                {
                    ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].Tag].DisconnectAllClients();

                    ObjCopy.obj_MainForm.InsertDataToLog(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(53, MainForm.CurrentLanguage) +
                        ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].Tag].User);

                    ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].Tag].RemoveAccount();
                }
            }
            */

            this.listView_ClientsAccounts_ClientsAccounts.Items.Clear();

            ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsSecurityDataBase.Rows.Clear();

            ClientsNetworkSecurity.UserAccount.UsersAccounts.Clear();

            #region Call Log Event

            ConnectingServiceLogsEvents.NewCommonLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), "Users assounts cleared", false);

            #endregion

            return;
        }
    }

    private void checkBox_ClientsRestrictionRules_UseRestrictionRules_CheckedChanged(object sender, EventArgs e)
    {
        CommonEnvironment.IsClientAccessRestrictionRuleEnable = this.checkBox_ClientsRestrictionRules_UseRestrictionRules.Checked;

        this.listView_ClientsRestrictionRules_RulestList.Enabled =
        this.button_ClientsRestrictionRules_AddRule.Enabled =
        this.button_ClientsRestrictionRules_ClearRulesList.Enabled =
        this.button_ClientsRestrictionRules_EditRule.Enabled =
        this.button_ClientsRestrictionRules_RemoveRule.Enabled =
        this.button_ClientsRestrictionRules_ViewRule.Enabled =
        this.button_ClientsRestrictionRules_EnableRule.Enabled =
        this.button_ClientsRestrictionRules_DisableRule.Enabled =
        this.label_ClientsRestrictionRules_RestrictionRules.Enabled = CommonEnvironment.IsClientAccessRestrictionRuleEnable;
    }

    private void button_ClientsRestrictionRules_AddRule_Click(object sender, EventArgs e)
    {
        ClientsAccessRestrictionRulesManagerForm clientsAccessRestrictionRulesManagerForm_obj = new ClientsAccessRestrictionRulesManagerForm();

        clientsAccessRestrictionRulesManagerForm_obj.ApplyButton.Visible = false;

        clientsAccessRestrictionRulesManagerForm_obj.ShowDialog();

        #region Call Log Event

        ConnectingServiceLogsEvents.NewClientsLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "", "", ServerStringFactory.GetString(1, MainForm.CurrentLanguage), "Access restriction rule sucessfully added", false);

        #endregion
    }

    private void button_ClientsRestrictionRules_EditRule_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsRestrictionRules_RulestList.SelectedItems.Count == 0) return;

        CommonEnvironment.EditClientAccessRestrictionRule((int)this.listView_ClientsRestrictionRules_RulestList.SelectedItems[0].Tag);
    }

    private void button_ClientsRestrictionRules_ViewRule_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsRestrictionRules_RulestList.SelectedItems.Count == 0) return;

        CommonEnvironment.ViewClientAccessRestrictionRule((int)this.listView_ClientsRestrictionRules_RulestList.SelectedItems[0].Tag);
    }

    private void button_ClientsRestrictionRules_DisableRule_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsRestrictionRules_RulestList.Items.Count == 0) return;

        if (this.listView_ClientsRestrictionRules_RulestList.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(210, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(213, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        for (int int_CycleCount = 0; int_CycleCount != this.listView_ClientsRestrictionRules_RulestList.SelectedItems.Count; int_CycleCount++)
        {
            ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules[(int)this.listView_ClientsRestrictionRules_RulestList.SelectedItems[0].Tag].IsRestrictionEnabled = false;

            ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[(int)this.listView_ClientsRestrictionRules_RulestList.SelectedItems[0].Tag].IsEnabled = false;

            this.listView_ClientsRestrictionRules_RulestList.SelectedItems[int_CycleCount].ImageIndex = 1;
            this.listView_ClientsRestrictionRules_RulestList.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(47, MainForm.CurrentLanguage);
        }

        #region Call Log Event

        ConnectingServiceLogsEvents.NewClientsLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "", "", ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(217, MainForm.CurrentLanguage), false);

        #endregion
    }

    private void button_ClientsRestrictionRules_EnableRule_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsRestrictionRules_RulestList.Items.Count == 0) return;

        if (this.listView_ClientsRestrictionRules_RulestList.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(210, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(212, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        for (int int_CycleCount = 0; int_CycleCount != this.listView_ClientsRestrictionRules_RulestList.SelectedItems.Count; int_CycleCount++)
        {
            ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules[(int)this.listView_ClientsRestrictionRules_RulestList.SelectedItems[0].Tag].IsRestrictionEnabled = true;

            ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[(int)this.listView_ClientsRestrictionRules_RulestList.SelectedItems[0].Tag].IsEnabled = true;

            this.listView_ClientsRestrictionRules_RulestList.SelectedItems[int_CycleCount].ImageIndex = 1;
            this.listView_ClientsRestrictionRules_RulestList.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(50, MainForm.CurrentLanguage);
        }

        #region Call Log Event

        ConnectingServiceLogsEvents.NewClientsLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "", "", ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(217, MainForm.CurrentLanguage), false);

        #endregion
    }

    public void RemoveClientsAccessRestrictionRuleFromListView(int int_AccessRestrictionRuleIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_ClientsRestrictionRules_RulestList.Items[int_AccessRestrictionRuleIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_ClientsRestrictionRules_RulestList.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_ClientsRestrictionRules_RulestList.Items.RemoveAt(int_AccessRestrictionRuleIndex);

        #region Call Log Event

        ConnectingServiceLogsEvents.NewClientsLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "", "", ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(215, MainForm.CurrentLanguage), false);

        #endregion
    }

    private void button_ClientsRestrictionRules_RemoveRule_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsRestrictionRules_RulestList.Items.Count < 1) return;

        if (this.listView_ClientsRestrictionRules_RulestList.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(210, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(211, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        for (; 0 != this.listView_ClientsRestrictionRules_RulestList.SelectedItems.Count; )
        {
            ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.RemoveAt((int)this.listView_ClientsRestrictionRules_RulestList.SelectedItems[0].Tag);

            ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.RemoveAt((int)this.listView_ClientsRestrictionRules_RulestList.SelectedItems[0].Tag);

            this.RemoveClientsAccessRestrictionRuleFromListView(this.listView_ClientsRestrictionRules_RulestList.SelectedItems[0].Index);

        }

        #region Call Log Event

        ConnectingServiceLogsEvents.NewClientsLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "", "", ServerStringFactory.GetString(1, MainForm.CurrentLanguage), "Clients Access restrinction rule removed.", false);

        #endregion
    }

    private void button_ClientsRestrictionRules_ClearRulesList_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsRestrictionRules_RulestList.Items.Count < 1) return;

        if (DialogResult.Yes == MessageBox.Show(ServerStringFactory.GetString(209, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            this.listView_ClientsRestrictionRules_RulestList.Items.Clear();

            ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsAccessRestrictionRules.Rows.Clear();

            ClientsNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Clear();
        }

        #region Call Log Event

        ConnectingServiceLogsEvents.NewCommonLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), "Clients Access restrinction rule list clears.", false);

        #endregion
    }




    private void button_ServersAccounts_AddAccount_Click(object sender, EventArgs e)
    {
        ServersAccountsManagerForm serversAccountsManagerForm_obj = new ServersAccountsManagerForm();

        serversAccountsManagerForm_obj.ApplyButton.Visible = false;

        serversAccountsManagerForm_obj.ShowDialog();
    }

    private void button_ServersAccounts_EditAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersAccounts_ServersAccounts.SelectedItems.Count == 0) return;

        CommonEnvironment.EditServerUserAccount((int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[0].Tag);
    }

    private void button_ServersAccounts_ViewAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersAccounts_ServersAccounts.SelectedItems.Count == 0) return;

        CommonEnvironment.ViewServerUserAccount((int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[0].Tag);
    }

    private void button_ServersAccounts_DisableAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersAccounts_ServersAccounts.Items.Count == 0) return;

        if (this.listView_ServersAccounts_ServersAccounts.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(70, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(46, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        for (int int_CycleCount = 0; int_CycleCount != listView_ServersAccounts_ServersAccounts.SelectedItems.Count; int_CycleCount++)
        {
            this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].ImageIndex = 0;
            this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(47, MainForm.CurrentLanguage);

            if (ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].IsActivated == true)
            {
                this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].SubItems[5].Text += ", Activated";
            }

            ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].IsEnabled = false;
            ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].ChangeAccountState();
            ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].DisableAccount();

            #region Call Log Event

            string string_UserName = ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].UserName,
                    string_UIN = ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].UIN;

            ConnectingServiceLogsEvents.NewServersLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), string_UserName, string_UIN, ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(48, MainForm.CurrentLanguage), false);

            #endregion
        }
    }

    private void button_ServersAccounts_EnableAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersAccounts_ServersAccounts.Items.Count == 0) return;

        if (this.listView_ServersAccounts_ServersAccounts.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(70, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(49, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        for (int int_CycleCount = 0; int_CycleCount != listView_ServersAccounts_ServersAccounts.SelectedItems.Count; int_CycleCount++)
        {
            this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].ImageIndex = 1;
            this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(50, MainForm.CurrentLanguage);

            if (ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].IsActivated == true)
            {
                this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].SubItems[5].Text += ", Activated";
            }

            ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].IsEnabled = false;
            ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].ChangeAccountState();
            ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].EnableAccount();

            #region Call Log Event

            string string_UserName = ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].UserName,
                    string_UIN = ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].UIN;

            ConnectingServiceLogsEvents.NewServersLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), string_UserName, string_UIN, ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(48, MainForm.CurrentLanguage), false);

            #endregion
        }
    }

    public void RemoveServersAccountFromListView(int int_AccountIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_ServersAccounts_ServersAccounts.Items[int_AccountIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_ServersAccounts_ServersAccounts.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_ServersAccounts_ServersAccounts.Items.RemoveAt(int_AccountIndex);

        #region Call Log Event

        string string_UserName = ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_AccountIndex].Tag].UserName,
                string_UIN = ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_AccountIndex].Tag].UIN;

        ConnectingServiceLogsEvents.NewServersLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), string_UserName, string_UIN, ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(215, MainForm.CurrentLanguage), false);

        #endregion

    }

    private void button_ServersAccounts_RemoveAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersAccounts_ServersAccounts.Items.Count == 0) return;

        if (this.listView_ServersAccounts_ServersAccounts.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(70, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(52, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        for (int int_CycleCount = 0; this.listView_ServersAccounts_ServersAccounts.SelectedItems.Count != 0; int_CycleCount++)
        {
            if (this.listView_ServersAccounts_ServersAccounts.Items.Count == 0) return;

            ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[0].Tag].DisconnectAllClients();

            #region Call Log Event

            string string_UserName = ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[0].Tag].UserName,
                    string_UIN = ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[0].Tag].UIN;

            ConnectingServiceLogsEvents.NewServersLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), string_UserName, string_UIN, ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(215, MainForm.CurrentLanguage), false);

            #endregion

            ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[0].Tag].RemoveAccount();

            ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase.Rows.RemoveAt((int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[0].Tag);

            RemoveServersAccountFromListView((int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[0].Index);
        }
    }

    private void button_ServersAccounts_ClearAccountsList_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersAccounts_ServersAccounts.Items.Count < 1) return;

        if (DialogResult.Yes == MessageBox.Show(ServerStringFactory.GetString(145, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            /*
            for (int int_CycleCount = 0; int_CycleCount != this.listView_ServersAccounts_ServersAccounts.Items.Count; int_CycleCount++)
            {
                ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].Tag].IsEnabled = false;

                for (; 0 != ServersNetworkSecurity.UserAccount.UsersAccounts.Count; )
                {
                    ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].Tag].DisconnectAllClients();

                    ObjCopy.obj_MainForm.InsertDataToLog(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(53, MainForm.CurrentLanguage) +
                        ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].Tag].User);

                    ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].Tag].RemoveAccount();
                }

            }
            */
            this.listView_ServersAccounts_ServersAccounts.Items.Clear();

            ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase.Rows.Clear();

            ServersNetworkSecurity.UserAccount.UsersAccounts.Clear();

            return;
        }
    }

    private void button_ServersRestrictionRules_AddRule_Click(object sender, EventArgs e)
    {
        ServersAccessRestrictionRulesManagerForm serversAccessRestrictionRulesManagerForm_obj = new ServersAccessRestrictionRulesManagerForm();

        serversAccessRestrictionRulesManagerForm_obj.ApplyButton.Visible = false;

        serversAccessRestrictionRulesManagerForm_obj.ShowDialog();
    }

    private void button_ServersRestrictionRules_EditRule_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersRestrictionRules_RulestList.SelectedItems.Count == 0) return;

        CommonEnvironment.EditServerAccessRestrictionRule((int)this.listView_ServersRestrictionRules_RulestList.SelectedItems[0].Tag);
    }

    private void button_ServersRestrictionRules_ViewRule_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersRestrictionRules_RulestList.SelectedItems.Count == 0) return;

        CommonEnvironment.ViewServerAccessRestrictionRule((int)this.listView_ServersRestrictionRules_RulestList.SelectedItems[0].Tag);
    }

    private void button_ServersRestrictionRules_DisableRule_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersRestrictionRules_RulestList.Items.Count == 0) return;

        if (this.listView_ServersRestrictionRules_RulestList.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(210, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(213, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        for (int int_CycleCount = 0; int_CycleCount != this.listView_ServersRestrictionRules_RulestList.SelectedItems.Count; int_CycleCount++)
        {
            ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules[(int)this.listView_ServersRestrictionRules_RulestList.SelectedItems[0].Tag].IsRestrictionEnabled = false;

            ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[(int)this.listView_ServersRestrictionRules_RulestList.SelectedItems[0].Tag].IsEnabled = false;

            #region Call Log Event

            ConnectingServiceLogsEvents.NewServersLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "", "", ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(217, MainForm.CurrentLanguage), false);

            #endregion

            this.listView_ServersRestrictionRules_RulestList.SelectedItems[int_CycleCount].ImageIndex = 1;
            this.listView_ServersRestrictionRules_RulestList.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(47, MainForm.CurrentLanguage);
        }
    }

    private void button_ServersRestrictionRules_EnableRule_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersRestrictionRules_RulestList.Items.Count == 0) return;

        if (this.listView_ServersRestrictionRules_RulestList.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(210, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(212, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        for (int int_CycleCount = 0; int_CycleCount != this.listView_ServersRestrictionRules_RulestList.SelectedItems.Count; int_CycleCount++)
        {
            ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules[(int)this.listView_ServersRestrictionRules_RulestList.SelectedItems[0].Tag].IsRestrictionEnabled = true;

            ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules[(int)this.listView_ServersRestrictionRules_RulestList.SelectedItems[0].Tag].IsEnabled = true;

            #region Call Log Event

            ConnectingServiceLogsEvents.NewServersLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "", "", ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(215, MainForm.CurrentLanguage), false);

            #endregion

            this.listView_ServersRestrictionRules_RulestList.SelectedItems[int_CycleCount].ImageIndex = 1;
            this.listView_ServersRestrictionRules_RulestList.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(50, MainForm.CurrentLanguage);
        }
    }

    public void RemoveServersAccessRestrictionRuleFromListView(int int_AccessRestrictionRuleIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_ServersRestrictionRules_RulestList.Items[int_AccessRestrictionRuleIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_ServersRestrictionRules_RulestList.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_ServersRestrictionRules_RulestList.Items.RemoveAt(int_AccessRestrictionRuleIndex);

        #region Call Log Event

        ConnectingServiceLogsEvents.NewServersLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), "", "", ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(215, MainForm.CurrentLanguage), false);

        #endregion

    }

    private void button_ServersRestrictionRules_RemoveRule_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersRestrictionRules_RulestList.Items.Count < 1) return;

        if (this.listView_ServersRestrictionRules_RulestList.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(210, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(211, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        for (; 0 != this.listView_ServersRestrictionRules_RulestList.SelectedItems.Count; )
        {
            ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.RemoveAt((int)this.listView_ServersRestrictionRules_RulestList.SelectedItems[0].Tag);

            ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.RemoveAt((int)this.listView_ServersRestrictionRules_RulestList.SelectedItems[0].Tag);

            this.RemoveServersAccessRestrictionRuleFromListView(this.listView_ServersRestrictionRules_RulestList.SelectedItems[0].Index);
        }
    }

    private void button_ServersRestrictionRules_ClearRulesList_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersRestrictionRules_RulestList.Items.Count < 1) return;

        if (DialogResult.Yes == MessageBox.Show(ServerStringFactory.GetString(209, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            this.listView_ServersRestrictionRules_RulestList.Items.Clear();

            ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules.Rows.Clear();

            ServersNetworkSecurity.AccessRestrictionRuleObject.AccessRestrictionRules.Clear();
        }
    }

    private void checkBox_ServersRestrictionRules_UseRestrictionRules_CheckedChanged(object sender, EventArgs e)
    {
        CommonEnvironment.IsServerAccessRestrictionRuleEnable = this.checkBox_ServersRestrictionRules_UseRestrictionRules.Checked;

        this.listView_ServersRestrictionRules_RulestList.Enabled =
        this.button_ServersRestrictionRules_AddRule.Enabled =
        this.button_ServersRestrictionRules_ClearRulesList.Enabled =
        this.button_ServersRestrictionRules_EditRule.Enabled =
        this.button_ServersRestrictionRules_RemoveRule.Enabled =
        this.button_ServersRestrictionRules_ViewRule.Enabled =
        this.button_ServersRestrictionRules_EnableRule.Enabled =
        this.button_ServersRestrictionRules_DisableRule.Enabled =
        this.label_ServersRestrictionRules_RestrictionRules.Enabled = CommonEnvironment.IsServerAccessRestrictionRuleEnable;
    }




    public void FillCommoneventLogListView(ListViewItem[] listViewItemArray_Logs)
    {
        this.listView_CommonEventsLog_LogList.Items.AddRange(listViewItemArray_Logs);
    }


    public void AddClientAccountToListView(ClientsNetworkSecurity.UserAccount userAccount_obj)
    {
        ListViewItem listViewItem_SecurityInfo = new ListViewItem(userAccount_obj.UserName, 0);

        listViewItem_SecurityInfo.SubItems.Add(userAccount_obj.UIN);
        listViewItem_SecurityInfo.SubItems.Add(userAccount_obj.ActivationCode.ToString());
        listViewItem_SecurityInfo.SubItems.Add(userAccount_obj.CreationTime.ToString());
        listViewItem_SecurityInfo.SubItems.Add(userAccount_obj.ActivationTime.ToString());

        if (userAccount_obj.IsEnabled == true)
        {
            listViewItem_SecurityInfo.SubItems.Add(ServerStringFactory.GetString(50, MainForm.CurrentLanguage));
        }
        else
        {
            listViewItem_SecurityInfo.SubItems.Add(ServerStringFactory.GetString(47, MainForm.CurrentLanguage));
            listViewItem_SecurityInfo.ImageIndex = 1;
        }

        if (userAccount_obj.IsActivated == true)
        {
            listViewItem_SecurityInfo.SubItems[5].Text += ", Activated";
        }

        listViewItem_SecurityInfo.Tag = this.listView_ClientsAccounts_ClientsAccounts.Items.Count;

        this.listView_ClientsAccounts_ClientsAccounts.Items.Add(listViewItem_SecurityInfo);
    }

    public void RemoveClientAccountFromListView(int int_UserAccountIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_ClientsAccounts_ClientsAccounts.Items[int_UserAccountIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_ClientsAccounts_ClientsAccounts.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_ClientsAccounts_ClientsAccounts.Items.RemoveAt(int_UserAccountIndex);
    }
    //-----------------
    public void AddClientAccessRestrictionRuleToListView(string string_IPRangeValue, string string_IPAddress, string string_MACAddress, DateTime dateTime_CreationTime, string string_RuleType, bool bool_IsRuleEnabled)
    {
        ListViewItem listViewItem_ClientAccessRestrictionRule = new ListViewItem(string_IPRangeValue, 0);

        listViewItem_ClientAccessRestrictionRule.SubItems.Add(string_IPAddress);
        listViewItem_ClientAccessRestrictionRule.SubItems.Add(string_MACAddress);
        listViewItem_ClientAccessRestrictionRule.SubItems.Add(string_RuleType);
        listViewItem_ClientAccessRestrictionRule.SubItems.Add(dateTime_CreationTime.ToString());

        if (bool_IsRuleEnabled == true)
        {
            listViewItem_ClientAccessRestrictionRule.SubItems.Add(ServerStringFactory.GetString(47, MainForm.CurrentLanguage));
            listViewItem_ClientAccessRestrictionRule.ImageIndex = 0;
        }
        else
        {
            listViewItem_ClientAccessRestrictionRule.SubItems.Add(ServerStringFactory.GetString(50, MainForm.CurrentLanguage));
            listViewItem_ClientAccessRestrictionRule.ImageIndex = 1;
        }

        listViewItem_ClientAccessRestrictionRule.Tag = this.listView_ClientsRestrictionRules_RulestList.Items.Count;

        this.listView_ClientsRestrictionRules_RulestList.Items.Add(listViewItem_ClientAccessRestrictionRule);
    }

    public void EditClientAccessRestrictionRuleInListView(int int_RecordIndex, string string_IPRangeValue, string string_IPAddress, string string_MACAddress, string string_RuleType)
    {
        ListViewItem listViewItem_ClientsAccessRestrictionRule = this.listView_ClientsRestrictionRules_RulestList.Items[int_RecordIndex];

        listViewItem_ClientsAccessRestrictionRule.SubItems[0].Text = string_IPRangeValue;

        listViewItem_ClientsAccessRestrictionRule.SubItems[1].Text = string_IPAddress;
        listViewItem_ClientsAccessRestrictionRule.SubItems[2].Text = string_MACAddress;
        listViewItem_ClientsAccessRestrictionRule.SubItems[3].Text = string_RuleType;
    }

    public void RemoveClientAccessRestrictionRuleFromListView(int int_RuleIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_ClientsRestrictionRules_RulestList.Items[int_RuleIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_ClientsRestrictionRules_RulestList.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_ClientsRestrictionRules_RulestList.Items.RemoveAt(int_RuleIndex);
    }





    public void AddServerAccountToListView(ServersNetworkSecurity.UserAccount userAccount_obj)
    {
        if (this.IsHandleCreated == false) return;
        try
        {
            this.Invoke((MethodInvoker)delegate //!!! ïîäâèñàåò UI èíîãäà çäåñü!!! ìîæåò èç çà ðåêóðñèè invoke ?!
            {
                ListViewItem listViewItem_SecurityInfo = new ListViewItem(userAccount_obj.UserName, 0);

                listViewItem_SecurityInfo.SubItems.Add(userAccount_obj.UIN);
                listViewItem_SecurityInfo.SubItems.Add(userAccount_obj.ActivationCode.ToString());
                listViewItem_SecurityInfo.SubItems.Add(userAccount_obj.CreationTime.ToString());
                listViewItem_SecurityInfo.SubItems.Add(userAccount_obj.ActivationTime.ToString());

                if (userAccount_obj.IsEnabled == true)
                {
                    listViewItem_SecurityInfo.SubItems.Add(ServerStringFactory.GetString(50, MainForm.CurrentLanguage));
                }
                else
                {
                    listViewItem_SecurityInfo.SubItems.Add(ServerStringFactory.GetString(47, MainForm.CurrentLanguage));
                    listViewItem_SecurityInfo.ImageIndex = 1;
                }

                if (userAccount_obj.IsActivated == true)
                {
                    listViewItem_SecurityInfo.SubItems[5].Text += ", Activated";
                }

                listViewItem_SecurityInfo.Tag = this.listView_ServersAccounts_ServersAccounts.Items.Count;

                this.listView_ServersAccounts_ServersAccounts.Items.Add(listViewItem_SecurityInfo);

            });
        }
        catch
        {
        }

    }

    public void RemoveServerAccountFromListView(int int_UserAccountIndex)
    {
        if (this.IsHandleCreated == false) return;
        try
        {
            this.Invoke((MethodInvoker)delegate //!!! ïîäâèñàåò UI èíîãäà çäåñü!!! ìîæåò èç çà ðåêóðñèè invoke ?!
            {
                int int_DeletedTagIndex = (int)this.listView_ServersAccounts_ServersAccounts.Items[int_UserAccountIndex].Tag;

                foreach (ListViewItem listViewItem_obj in this.listView_ServersAccounts_ServersAccounts.Items)
                {
                    if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
                    {
                        listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
                    }
                }

                this.listView_ServersAccounts_ServersAccounts.Items.RemoveAt(int_UserAccountIndex);
            });
        }
        catch
        {
        }
    }
    //-----------------    
    public void AddServerAccessRestrictionRuleToListView(string string_IPRangeValue, string string_IPAddress, string string_MACAddress, DateTime dateTime_CreationTime, string string_RuleType, bool bool_IsRuleEnabled)
    {
        ListViewItem listViewItem_ServerAccessRestrictionRule = new ListViewItem(string_IPRangeValue, 0);

        listViewItem_ServerAccessRestrictionRule.SubItems.Add(string_IPAddress);
        listViewItem_ServerAccessRestrictionRule.SubItems.Add(string_MACAddress);
        listViewItem_ServerAccessRestrictionRule.SubItems.Add(string_RuleType);
        listViewItem_ServerAccessRestrictionRule.SubItems.Add(dateTime_CreationTime.ToString());

        if (bool_IsRuleEnabled == true)
        {
            listViewItem_ServerAccessRestrictionRule.SubItems.Add(ServerStringFactory.GetString(47, MainForm.CurrentLanguage));
            listViewItem_ServerAccessRestrictionRule.ImageIndex = 0;
        }
        else
        {
            listViewItem_ServerAccessRestrictionRule.SubItems.Add(ServerStringFactory.GetString(50, MainForm.CurrentLanguage));
            listViewItem_ServerAccessRestrictionRule.ImageIndex = 1;
        }

        listViewItem_ServerAccessRestrictionRule.Tag = this.listView_ServersRestrictionRules_RulestList.Items.Count;

        this.listView_ServersRestrictionRules_RulestList.Items.Add(listViewItem_ServerAccessRestrictionRule);
    }

    public void EditServerAccessRestrictionRuleInListView(int int_RecordIndex, string string_IPRangeValue, string string_IPAddress, string string_MACAddress, string string_RuleType)
    {
        ListViewItem listViewItem_ServersAccessRestrictionRule = this.listView_ServersRestrictionRules_RulestList.Items[int_RecordIndex];

        listViewItem_ServersAccessRestrictionRule.SubItems[0].Text = string_IPRangeValue;

        listViewItem_ServersAccessRestrictionRule.SubItems[1].Text = string_IPAddress;
        listViewItem_ServersAccessRestrictionRule.SubItems[2].Text = string_MACAddress;
        listViewItem_ServersAccessRestrictionRule.SubItems[3].Text = string_RuleType;
    }

    public void RemoveServerAccessRestrictionRuleFromListView(int int_RuleIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_ServersRestrictionRules_RulestList.Items[int_RuleIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_ServersRestrictionRules_RulestList.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_ServersRestrictionRules_RulestList.Items.RemoveAt(int_RuleIndex);
    }





    //ïåðåâåñòè âûçîâ çàïèñè æóðíàëà íà ìîäåëü Ñîáûòèé! 

    void SubscribeToLogEvents()
    {
        ConnectingServiceLogsEvents.NewCommonLogRecordEvent += OnNewCommonLogRecord;
        ConnectingServiceLogsEvents.NewClientsLogRecordEvent += OnNewClientsLogRecord;
        ConnectingServiceLogsEvents.NewServersLogRecordEvent += OnNewServersLogRecord;
    }


    public void OnNewCommonLogRecord(string string_RecordType, string string_LogDate, string string_LogTime, string string_RecordSource, string string_EventDescription, bool bool_ListViewRecordOnly)
    {
        if (this.IsHandleCreated == false) return;

        this.Invoke((MethodInvoker)delegate
        {
            ListViewItem listViewItem_Log = new ListViewItem(string_RecordType, 1);

            listViewItem_Log.ImageIndex = 0;

            listViewItem_Log.SubItems.Add(string_LogDate + " " + string_LogTime);
            listViewItem_Log.SubItems.Add(string_EventDescription);

            this.listView_CommonEventsLog_LogList.Items.Add(listViewItem_Log);

            if (bool_ListViewRecordOnly == true) return;

            ////////////////////////////////////////////////////////////////////////////////

            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.CommonEventsLogDataTable eventsLogDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.CommonEventsLog;

            dataRow_NewRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.CommonEventsLog.NewRow();

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

                else
                {
                    if (int_CycleCount + 1 == eventsLogDataTable_obj.Rows.Count)
                    {
                        break;
                    }
                }
            }

            dataRow_NewRecord[eventsLogDataTable_obj.IDColumn] = int_EventLogID;

            dataRow_NewRecord[eventsLogDataTable_obj.SourceColumn] = string_RecordSource;
            dataRow_NewRecord[eventsLogDataTable_obj.TypeColumn] = string_RecordType;
            dataRow_NewRecord[eventsLogDataTable_obj.DescriptionColumn] = string_EventDescription;
            dataRow_NewRecord[eventsLogDataTable_obj.EventIDColumn] = 0;
            dataRow_NewRecord[eventsLogDataTable_obj.DateColumn] = string_LogDate;
            dataRow_NewRecord[eventsLogDataTable_obj.TimeColumn] = string_LogTime;

            ConnectingServiceDBSupplier.ConnectingServiceDB.CommonEventsLog.Rows.Add(dataRow_NewRecord);
        });
    }

    public void OnNewClientsLogRecord(string string_RecordType, string string_LogDate, string string_LogTime, string string_UserName, string string_UIN, string string_RecordSource, string string_EventDescription, bool bool_ListViewRecordOnly)
    {
        if (this.IsHandleCreated == false) return;

        this.Invoke((MethodInvoker)delegate
        {
            ListViewItem listViewItem_Log = new ListViewItem(string_RecordType, 1);

            listViewItem_Log.ImageIndex = 0;

            listViewItem_Log.SubItems.Add(string_LogDate + " " + string_LogTime);
            listViewItem_Log.SubItems.Add(string_UserName);
            listViewItem_Log.SubItems.Add(string_UIN);
            listViewItem_Log.SubItems.Add(string_EventDescription);

            this.listView_ClientsEventsLog_LogList.Items.Add(listViewItem_Log);

            if (bool_ListViewRecordOnly == true) return;

            ////////////////////////////////////////////////////////////////////////////////

            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.ClientsEventsLogDataTable clientsEventsLogDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsEventsLog;

            dataRow_NewRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsEventsLog.NewRow();

            int int_EventLogID = 0;

            for (int int_CycleCount = 0; ; int_CycleCount++)
            {
                if (clientsEventsLogDataTable_obj.Rows.Count == 0) break;

                if (int_CycleCount >= clientsEventsLogDataTable_obj.Rows.Count
                    || (int)clientsEventsLogDataTable_obj.Rows[int_CycleCount][clientsEventsLogDataTable_obj.IDColumn] == int_EventLogID)
                {
                    int_EventLogID++;
                    int_CycleCount = -1;
                }

                else
                {
                    if (int_CycleCount + 1 == clientsEventsLogDataTable_obj.Rows.Count)
                    {
                        break;
                    }
                }
            }

            dataRow_NewRecord[clientsEventsLogDataTable_obj.IDColumn] = int_EventLogID;

            dataRow_NewRecord[clientsEventsLogDataTable_obj.SourceColumn] = string_RecordSource;
            dataRow_NewRecord[clientsEventsLogDataTable_obj.TypeColumn] = string_RecordType;
            dataRow_NewRecord[clientsEventsLogDataTable_obj.DescriptionColumn] = string_EventDescription;
            dataRow_NewRecord[clientsEventsLogDataTable_obj.EventIDColumn] = 0;
            dataRow_NewRecord[clientsEventsLogDataTable_obj.DateColumn] = string_LogDate;
            dataRow_NewRecord[clientsEventsLogDataTable_obj.TimeColumn] = string_LogTime;
            dataRow_NewRecord[clientsEventsLogDataTable_obj.UserNameColumn] = string_UserName;
            dataRow_NewRecord[clientsEventsLogDataTable_obj.UINColumn] = string_UIN;

            ConnectingServiceDBSupplier.ConnectingServiceDB.ClientsEventsLog.Rows.Add(dataRow_NewRecord);
        });
    }

    public void OnNewServersLogRecord(string string_RecordType, string string_LogDate, string string_LogTime, string string_UserName, string string_UIN, string string_RecordSource, string string_EventDescription, bool bool_ListViewRecordOnly)
    {
        if (this.IsHandleCreated == false) return;

        this.Invoke((MethodInvoker)delegate
        {
            ListViewItem listViewItem_Log = new ListViewItem(string_RecordType, 1);

            listViewItem_Log.ImageIndex = 0;

            listViewItem_Log.SubItems.Add(string_LogDate + " " + string_LogTime);
            listViewItem_Log.SubItems.Add(string_UserName);
            listViewItem_Log.SubItems.Add(string_UIN);
            listViewItem_Log.SubItems.Add(string_EventDescription);

            this.listView_ServersEventsLog_LogList.Items.Add(listViewItem_Log);

            if (bool_ListViewRecordOnly == true) return;

            ////////////////////////////////////////////////////////////////////////////////

            DataRow dataRow_NewRecord = null;

            DataSet_ConnectingServiceDB.ServersEventsLogDataTable serversEventsLogDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersEventsLog;

            dataRow_NewRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersEventsLog.NewRow();

            int int_EventLogID = 0;

            for (int int_CycleCount = 0; ; int_CycleCount++)
            {
                if (serversEventsLogDataTable_obj.Rows.Count == 0) break;

                if (int_CycleCount >= serversEventsLogDataTable_obj.Rows.Count
                    || (int)serversEventsLogDataTable_obj.Rows[int_CycleCount][serversEventsLogDataTable_obj.IDColumn] == int_EventLogID)
                {
                    int_EventLogID++;
                    int_CycleCount = -1;
                }

                else
                {
                    if (int_CycleCount + 1 == serversEventsLogDataTable_obj.Rows.Count)
                    {
                        break;
                    }
                }
            }

            dataRow_NewRecord[serversEventsLogDataTable_obj.IDColumn] = int_EventLogID;

            dataRow_NewRecord[serversEventsLogDataTable_obj.SourceColumn] = string_RecordSource;
            dataRow_NewRecord[serversEventsLogDataTable_obj.TypeColumn] = string_RecordType;
            dataRow_NewRecord[serversEventsLogDataTable_obj.DescriptionColumn] = string_EventDescription;
            dataRow_NewRecord[serversEventsLogDataTable_obj.EventIDColumn] = 0;
            dataRow_NewRecord[serversEventsLogDataTable_obj.DateColumn] = string_LogDate;
            dataRow_NewRecord[serversEventsLogDataTable_obj.TimeColumn] = string_LogTime;
            dataRow_NewRecord[serversEventsLogDataTable_obj.UserNameColumn] = string_UserName;
            dataRow_NewRecord[serversEventsLogDataTable_obj.UINColumn] = string_UIN;

            ConnectingServiceDBSupplier.ConnectingServiceDB.ServersEventsLog.Rows.Add(dataRow_NewRecord);
        });
    }




    #region Common Properties

    #region Invoke Delegates

    delegate string delegate_ReturningStringMethod();
    delegate bool delegate_ReturningBoolMethod();

    delegate int delegate_ReturningIntMethod();
    delegate long delegate_ReturningLongMethod();
    delegate decimal delegate_ReturningDecimalMethod();

    delegate ImageList delegate_ReturningImageListMethod();
    delegate TrackBar delegate_ReturningTrackBarMethod();

    #endregion

    public int ServerPort
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                try
                {
                    if (Convert.ToInt32(this.textBox_Main_ListeningPort.Text) > 65535 || Convert.ToInt32(this.textBox_Main_ListeningPort.Text) < 1)
                    {
                        MessageBox.Show(ServerStringFactory.GetString(87, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK);
                        return -1;
                    }

                    return Convert.ToInt32(textBox_Main_ListeningPort.Text);
                }

                catch (FormatException)
                {
                    MessageBox.Show(ServerStringFactory.GetString(87, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK);
                    return -1;
                }
            });
        }
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_Main_ListeningPort.Text = value.ToString();
            });
        }
    }

    public string ServerStatus
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_Main_ServerStatus.Text = value;
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_Main_ServerStatus.Text;
            });
        }
    }

    void ChangeControlsLanguage()
    {

    }

    static int int_CurrentLanguage = 1;

    public static int CurrentLanguage
    {
        get
        {
            return int_CurrentLanguage;
        }

        set
        {
            int_CurrentLanguage = value;
            ObjCopy.obj_MainForm.ChangeControlsLanguage();
        }
    }


    long long_BytesSent = 0;
    public long Statistic_BytesSent
    {
        set
        {
            lock (this)
            {
                if (this.IsHandleCreated == false) return;

                this.Invoke((MethodInvoker)delegate
                {
                    long_BytesSent = value;

                    this.textBox_CommonStatistic_BytesSent.Text = CommonMethods.SpreadToHundreds(long_BytesSent.ToString());
                });
            }
        }

        get
        {
            lock (this)
            {
                if (this.IsHandleCreated == false) return 0;

                return (long)this.Invoke((delegate_ReturningLongMethod)delegate
                {
                    return long_BytesSent;
                });
            }
        }
    }


    long long_BytesReceived = 0;
    public long Statistic_BytesReceived
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                long_BytesReceived = value;

                this.textBox_CommonStatistic_BytesReceived.Text = CommonMethods.SpreadToHundreds(value.ToString());
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (long)this.Invoke((delegate_ReturningLongMethod)delegate
            {
                return long_BytesReceived;
            });
        }
    }


    public string Statistic_LastConnectionAt
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_CommonStatistic_LastConnectionAt.Text = value;
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return string.Empty;

            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_CommonStatistic_LastConnectionAt.Text;
            });
        }
    }

    public long Statistic_ActiveConnections
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_CommonStatistic_ActiveConnections.Text = CommonMethods.SpreadToHundreds(value.ToString());
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (long)this.Invoke((delegate_ReturningLongMethod)delegate
            {
                try
                {
                    long long_ResultValue = 0;
                                     
                    if(long.TryParse(this.textBox_CommonStatistic_ActiveConnections.Text.Replace(", ", ""), out long_ResultValue)  == true)
                    {
                        return long_ResultValue;
                    }

                    return long_ResultValue;
                }
                catch
                {
                    return 0;
                }
            });
        }
    }

    #endregion




    private void button_Main_WindowParameters_Click(object sender, EventArgs e)
    {
        this.contextMenu_WindowParameters.Show(this.tabControl_Main, new Point(this.button_Main_WindowParameters.Location.X + this.button_Main_WindowParameters.Size.Width + 4, this.button_Main_WindowParameters.Location.Y + 23));
    }

    private void button_ConnectedClients_DisconnectClient_Click(object sender, EventArgs e)
    {
        if (this.listView_ConnectedUsers_ConnectedClients.SelectedItems.Count == 0) return;

        try
        {
            ((ConnectedClient)listView_ConnectedUsers_ConnectedClients.SelectedItems[0].Tag).Disconnect(1);
        }
        catch
        {
        }
    }

    private void button_ConnectedServers_DisconnectServer_Click(object sender, EventArgs e)
    {
        if (this.listView_ConnectedUsers_ConnectedServers.SelectedItems.Count == 0) return;

        try
        {
            ((ConnectedServer)listView_ConnectedUsers_ConnectedServers.SelectedItems[0].Tag).Disconnect(1);
        }
        catch
        {
        }
    }

    private void button_ConnectedClients_DisconnectAll_Click(object sender, EventArgs e)
    {
        ConnectedClient.DisconnectAll();
    }

    private void button_ConnectedServers_DisconnectAll_Click(object sender, EventArgs e)
    {
        ConnectedServer.DisconnectAll();
    }

    private void button_ActiveInterConnections_DisconnectAll_Click(object sender, EventArgs e)
    {
        try
        {
            ConnectedClient.AppliedClientChannel appliedClientChannel_obj = null;

            ArrayList arrayList_ConnectedServers = new ArrayList();

            foreach (ListViewItem listViewItem_Client in this.listView_ActiveInterConnections_ConnectionsList.Items)
            {
                appliedClientChannel_obj = (ConnectedClient.AppliedClientChannel)listViewItem_Client.Tag;

                if (appliedClientChannel_obj != null)
                {
                    arrayList_ConnectedServers.Add(appliedClientChannel_obj.InterconnectedObject);
                }
            }

            foreach (ConnectedServer connectedServer_obj in arrayList_ConnectedServers)
            {
                if (connectedServer_obj != null)
                {
                    connectedServer_obj.Disconnect(1);
                }
            }

        }
        catch
        {
        }
    }

    private void button_ActiveInterConnections_DisconnectInterConnection_Click(object sender, EventArgs e)
    {
        if (this.listView_ActiveInterConnections_ConnectionsList.SelectedItems.Count == 0) return;

        try
        {
            ConnectedClient.AppliedClientChannel appliedClientChannel_obj = (ConnectedClient.AppliedClientChannel)this.listView_ActiveInterConnections_ConnectionsList.SelectedItems[0].Tag;

            if (appliedClientChannel_obj.ChannelOwner != null && appliedClientChannel_obj.InterconnectedObject != null)
            {
                appliedClientChannel_obj.InterconnectedObject.Disconnect(1);
            }
        }
        catch
        {
        }
    }

    private void button_ActiveInterConnections_SwitchToClient_Click(object sender, EventArgs e)
    {
        if (this.listView_ActiveInterConnections_ConnectionsList.SelectedItems.Count == 0) return;

        try
        {
            ConnectedClient.AppliedClientChannel appliedClientChannel_obj = (ConnectedClient.AppliedClientChannel)this.listView_ActiveInterConnections_ConnectionsList.SelectedItems[0].Tag;

            foreach (ListViewItem listViewItem_Client in this.listView_ConnectedUsers_ConnectedClients.Items)
            {
                if ((ConnectedClient)listViewItem_Client.Tag == appliedClientChannel_obj.ChannelOwner)
                {
                    this.tabControl_Main.SelectedIndex = 1;

                    listViewItem_Client.Selected = true;
                    listViewItem_Client.Focused = true;

                    this.listView_ConnectedUsers_ConnectedClients.Focus();

                    return;
                }
            }
        }
        catch
        {
        }
    }

    private void button_ActiveInterConnections_SwitchToServer_Click(object sender, EventArgs e)
    {
        if (this.listView_ActiveInterConnections_ConnectionsList.SelectedItems.Count == 0) return;

        try
        {
            ConnectedClient.AppliedClientChannel appliedClientChannel_obj = (ConnectedClient.AppliedClientChannel)this.listView_ActiveInterConnections_ConnectionsList.SelectedItems[0].Tag;

            ConnectedServer connectedServer_obj = appliedClientChannel_obj.InterconnectedObject;

            foreach (ListViewItem listViewItem_Server in this.listView_ConnectedUsers_ConnectedServers.Items)
            {
                if ((ConnectedServer)listViewItem_Server.Tag == connectedServer_obj)
                {
                    this.tabControl_Main.SelectedIndex = 1;

                    listViewItem_Server.Selected = true;
                    listViewItem_Server.Focused = true;

                    this.listView_ConnectedUsers_ConnectedServers.Focus();

                    return;
                }
            }
        }
        catch
        {
        }
    }



    private void listView_ActiveInterConnections_ConnectionsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.listView_ActiveInterConnections_ConnectionsList.SelectedItems.Count == 0) return;

        try
        {
            ConnectedClient.AppliedClientChannel appliedClientChannel_obj = (ConnectedClient.AppliedClientChannel)this.listView_ActiveInterConnections_ConnectionsList.SelectedItems[0].Tag;

            ConnectedServer connectedServer_obj = appliedClientChannel_obj.InterconnectedObject;

            this.textBox_ActiveConnectionDetails_ClientBytesSent.Text = CommonMethods.SpreadToHundreds(appliedClientChannel_obj.ChannelOwner.Statistic_BytesSent.ToString());

            this.textBox_ActiveConnectionDetails_ClientBytesReceived.Text = CommonMethods.SpreadToHundreds(appliedClientChannel_obj.ChannelOwner.Statistic_BytesReceived.ToString());

            this.textBox_ActiveConnectionDetails_ServerBytesSent.Text = CommonMethods.SpreadToHundreds(connectedServer_obj.Statistic_BytesSent.ToString());

            this.textBox_ActiveConnectionDetails_ServerBytesReceived.Text = CommonMethods.SpreadToHundreds(connectedServer_obj.Statistic_BytesReceived.ToString());
        }
        catch
        {
        }
    }

    private void listView_ConnectedUsers_ConnectedClients_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ConnectedClient connectedClient_obj = (ConnectedClient)this.listView_ConnectedUsers_ConnectedClients.SelectedItems[0].Tag;

            this.textBox_ClientDetails_BytesSent.Text = CommonMethods.SpreadToHundreds(connectedClient_obj.Statistic_BytesSent.ToString());

            this.textBox_ClientDetails_BytesReceived.Text = CommonMethods.SpreadToHundreds(connectedClient_obj.Statistic_BytesReceived.ToString());

            this.textBox_ClientDetails_ConnectedAt.Text = connectedClient_obj.SystemChannel.BaseChannel.Statistic_ConnectedTime.ToShortDateString() + " " + connectedClient_obj.SystemChannel.BaseChannel.Statistic_ConnectedTime.ToLongTimeString();

            this.textBox_ClientDetails_IPAddress.Text = connectedClient_obj.SystemChannel.BaseChannel.IPAddress;

            this.textBox_ClientDetails_MACAddress.Text = connectedClient_obj.SystemChannel.BaseChannel.MACAddress;
        }
        catch
        {
        }
    }

    private void listView_ConnectedUsers_ConnectedServers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ConnectedServer connectedServer_obj = (ConnectedServer)this.listView_ConnectedUsers_ConnectedServers.SelectedItems[0].Tag;

            this.textBox_ServerDetails_BytesSent.Text = connectedServer_obj.Statistic_BytesSent.ToString();

            this.textBox_ServerDetails_BytesReceived.Text = connectedServer_obj.Statistic_BytesReceived.ToString();

            this.textBox_ServerDetails_ConnectedAt.Text = connectedServer_obj.SystemChannel.BaseChannel.Statistic_ConnectedTime.ToShortDateString() + " " + connectedServer_obj.SystemChannel.BaseChannel.Statistic_ConnectedTime.ToLongTimeString();

            this.textBox_ServerDetails_IPAddress.Text = connectedServer_obj.IPAddress;

            this.textBox_ServerDetails_MACAddress.Text = connectedServer_obj.MACAddress;
        }
        catch
        {
        }
    }


    private void checkBox_MainWindowParameters_ShowInNotifyArea_CheckedChanged(object sender, EventArgs e)
    {
        this.notifyIcon_Main.Visible = CommonEnvironment.ShowIconInNotifyArea = this.checkBox_MainWindowParameters_ShowInNotifyArea.Checked;
    }

    private void menuItem_MainWindowState_MinimizeToNotifyArea_Click(object sender, EventArgs e)
    {
        this.MinimizeToNotifyArea();
    }

    private void menuItem_MainWindowState_MinimizeToTaskBar_Click(object sender, EventArgs e)
    {
        this.MinimizeToTaskBar();
    }

    private void menuItem_MainWindowState_ActivateHiddenMode_Click(object sender, EventArgs e)
    {
        this.ActivateHiddenMode();
    }

    private void menuItem_Options_Settings_Click(object sender, EventArgs e)
    {
        SettingsForm obj_SettingsForm = new SettingsForm();

        obj_SettingsForm.ShowDialog();
    }

    private void menuItem_Help_About_Click(object sender, EventArgs e)
    {
        new AboutForm().ShowDialog();
    }

    private void menuItem_File_Import_SettingsDatabase_Click(object sender, System.EventArgs e)
    {
        OpenFileDialog openFileDialog_obj = new OpenFileDialog();

        openFileDialog_obj.Multiselect = false;

        openFileDialog_obj.Title = ServerStringFactory.GetString(149, MainForm.CurrentLanguage);

        openFileDialog_obj.ShowDialog();

        ImportServerDB(openFileDialog_obj.FileName);
    }

    private void menuItem_File_Export_SettingsDatabase_Click(object sender, System.EventArgs e)
    {
        SaveFileDialog saveFileDialog_obj = new SaveFileDialog();

        saveFileDialog_obj.Title = ServerStringFactory.GetString(150, MainForm.CurrentLanguage);

        saveFileDialog_obj.FileName = "ConnectingServiceDB";

        saveFileDialog_obj.ShowDialog();

        new ConnectingServiceDBSupplier().WriteServerSettingsData(saveFileDialog_obj.FileName);
    }

    private void button_ClientsAccounts_ActivateAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsAccounts_ClientsAccounts.Items.Count == 0) return;

        if (this.listView_ClientsAccounts_ClientsAccounts.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(70, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(49, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        for (int int_CycleCount = 0; int_CycleCount != listView_ClientsAccounts_ClientsAccounts.SelectedItems.Count; int_CycleCount++)
        {
            if (ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].IsActivated == true)
            {
                continue;
            }

            if (ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].IsEnabled == true)
            {
                this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].ImageIndex = 1;
                this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(50, MainForm.CurrentLanguage);
            }
            else
            {
                this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].ImageIndex = 0;
                this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(47, MainForm.CurrentLanguage);
            }

            this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].SubItems[4].Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].SubItems[5].Text += ", Activated";

            ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].ActivateAccount();

            #region Call Log Event

            string string_UserName = ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].UserName,
                    string_UIN = ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.SelectedItems[int_CycleCount].Tag].UIN;

            ConnectingServiceLogsEvents.NewClientsLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), string_UserName, string_UIN, ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(48, MainForm.CurrentLanguage), false);

            #endregion
        }
    }

    private void button_ServersAccounts_ActivateAccount_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersAccounts_ServersAccounts.Items.Count == 0) return;

        if (this.listView_ServersAccounts_ServersAccounts.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(70, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(49, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) return;

        for (int int_CycleCount = 0; int_CycleCount != listView_ServersAccounts_ServersAccounts.SelectedItems.Count; int_CycleCount++)
        {
            if (ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].IsActivated == true)
            {
                continue;
            }

            if (ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].IsEnabled == true)
            {
                this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].ImageIndex = 1;
                this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(50, MainForm.CurrentLanguage);
            }
            else
            {
                this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].ImageIndex = 0;
                this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(47, MainForm.CurrentLanguage);
            }

            this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].SubItems[4].Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].SubItems[5].Text += ", Activated";

            ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].ActivateAccount();

            #region Call Log Event

            string string_UserName = ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].UserName,
                    string_UIN = ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.SelectedItems[int_CycleCount].Tag].UIN;

            ConnectingServiceLogsEvents.NewServersLogRecordEvent(ServerStringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), string_UserName, string_UIN, ServerStringFactory.GetString(1, MainForm.CurrentLanguage), ServerStringFactory.GetString(48, MainForm.CurrentLanguage), false);

            #endregion
        }
    }

    public void RefresfServersActivatedStatus()
    {
        if (this.IsHandleCreated == false)
        {
            MessageBox.Show("fuck server activated");

            return;
        }
        try
        {
            this.Invoke((MethodInvoker)delegate //!!! ïîäâèñàåò UI èíîãäà çäåñü!!! ìîæåò èç çà ðåêóðñèè invoke ?!
            {
                for (int int_CycleCount = 0; int_CycleCount != this.listView_ServersAccounts_ServersAccounts.Items.Count; int_CycleCount++)
                {
                    if (ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].Tag].IsEnabled == true)
                    {
                        this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].ImageIndex = 1;
                        this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(50, MainForm.CurrentLanguage);
                    }
                    else
                    {
                        this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].ImageIndex = 0;
                        this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(47, MainForm.CurrentLanguage);
                    }

                    if (ServersNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].Tag].IsActivated == true)
                    {
                        this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].SubItems[4].Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                        this.listView_ServersAccounts_ServersAccounts.Items[int_CycleCount].SubItems[5].Text += ", Activated";
                    }
                }
            });
        }

        catch (Exception e)
        {
            MessageBox.Show(e.Message + "   fuck server activated   " + e.Source);

            return;
        }
    }

    public void RefresfClientsActivatedStatus()
    {
        if (this.IsHandleCreated == false)
        {
            MessageBox.Show("fuck client activated");

            return;
        }
        try
        {
            this.Invoke((MethodInvoker)delegate
            {
                for (int int_CycleCount = 0; int_CycleCount != this.listView_ClientsAccounts_ClientsAccounts.Items.Count; int_CycleCount++)
                {
                    if (ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].Tag].IsEnabled == true)
                    {
                        this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].ImageIndex = 1;
                        this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(50, MainForm.CurrentLanguage);
                    }
                    else
                    {
                        this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].ImageIndex = 0;
                        this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].SubItems[5].Text = ServerStringFactory.GetString(47, MainForm.CurrentLanguage);
                    }

                    if (ClientsNetworkSecurity.UserAccount.UsersAccounts[(int)this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].Tag].IsActivated == true)
                    {
                        this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].SubItems[4].Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                        this.listView_ClientsAccounts_ClientsAccounts.Items[int_CycleCount].SubItems[5].Text += ", Activated";
                    }
                }
            });
        }

        catch (Exception e)
        {
            MessageBox.Show(e.Message + "   fuck client activated   " + e.StackTrace);

            return;
        }
    }

    private void button_CommonEventsLog_ClearLog_Click(object sender, EventArgs e)
    {
        if (this.listView_CommonEventsLog_LogList.Items.Count == 0) return;

        if (MessageBox.Show(ServerStringFactory.GetString(213, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) //!! èñïðàâèòü ID GetString! 213 äëÿ òåñòà
        {
            return;
        }

        ConnectingServiceDBSupplier.ClearCommonEventsLog();

        this.listView_CommonEventsLog_LogList.Items.Clear();
    }

    private void button_ClientsEventsLog_ClearLog_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsEventsLog_LogList.Items.Count == 0) return;

        if (MessageBox.Show(ServerStringFactory.GetString(213, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) //!! èñïðàâèòü ID GetString! 213 äëÿ òåñòà
        {
            return;
        }

        ConnectingServiceDBSupplier.ClearClientsEventsLog();

        this.listView_ClientsEventsLog_LogList.Items.Clear();
    }

    private void button_ServersEventsLog_ClearLog_Click(object sender, EventArgs e)
    {
        if (this.listView_CommonEventsLog_LogList.Items.Count == 0) return;

        if (MessageBox.Show(ServerStringFactory.GetString(213, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes) //!! èñïðàâèòü ID GetString! 213 äëÿ òåñòà
        {
            return;
        }

        ConnectingServiceDBSupplier.ClearServersEventsLog();

        this.listView_ServersEventsLog_LogList.Items.Clear();
    }

    private void button_CommonEventsLog_SaveLog_Click(object sender, EventArgs e)
    {
        if (this.listView_CommonEventsLog_LogList.Items.Count > 0)
        {
            SaveFileDialog saveFileDialog_SaveLog = new SaveFileDialog();

            saveFileDialog_SaveLog.AddExtension = true;

            saveFileDialog_SaveLog.DefaultExt = ".txt";

            saveFileDialog_SaveLog.Filter = "Text files(*.txt)|*.txt";

            if (DialogResult.OK == saveFileDialog_SaveLog.ShowDialog(this))
            {
                FileStream file_Log = new FileStream(saveFileDialog_SaveLog.FileName, FileMode.Create, FileAccess.ReadWrite);

                byte[] byteArray_LogItem;

                int int_LogItemLength;

                string string_LogItemText = string.Empty; ;

                string[] stringArray_ItemsNames = new string[3];

                stringArray_ItemsNames[0] = "Òèï: ";
                stringArray_ItemsNames[1] = "Äàòà è Âðåìÿ: ";
                stringArray_ItemsNames[2] = "Îïèñàíèå: ";

                byteArray_LogItem = System.Text.Encoding.Default.GetBytes("Common events log. Generated by YakSys Connecting Service ver 1.0.\n\n\n");
                int_LogItemLength = byteArray_LogItem.Length;
                file_Log.Write(byteArray_LogItem, 0, int_LogItemLength);

                for (int int_CycleCount = 0; this.listView_CommonEventsLog_LogList.Items.Count != int_CycleCount; int_CycleCount++)
                {
                    string_LogItemText = "\n\n\n";
                    string_LogItemText += "Eevent #" + (int_CycleCount + 1).ToString() + "\n-----------------------------------------------\n\n";

                    for (int int_SubCycleCount = 0; 3 != int_SubCycleCount; int_SubCycleCount++)
                    {
                        string_LogItemText += stringArray_ItemsNames[int_SubCycleCount];

                        string_LogItemText += this.listView_CommonEventsLog_LogList.Items[int_CycleCount].SubItems[int_SubCycleCount].Text;
                        string_LogItemText += "\n";

                        byteArray_LogItem = System.Text.Encoding.Default.GetBytes(string_LogItemText);
                        int_LogItemLength = byteArray_LogItem.Length;
                        file_Log.Write(byteArray_LogItem, 0, int_LogItemLength);

                        string_LogItemText = string.Empty;
                    }
                }

                file_Log.Close();
            }
        }

        else
        {
            MessageBox.Show(ServerStringFactory.GetString(41, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }

    private void button_ServersEventsLog_SaveLog_Click(object sender, EventArgs e)
    {
        if (this.listView_ServersEventsLog_LogList.Items.Count > 0)
        {
            SaveFileDialog saveFileDialog_SaveLog = new SaveFileDialog();

            saveFileDialog_SaveLog.AddExtension = true;

            saveFileDialog_SaveLog.DefaultExt = ".txt";

            saveFileDialog_SaveLog.Filter = "Text files(*.txt)|*.txt";

            if (DialogResult.OK == saveFileDialog_SaveLog.ShowDialog(this))
            {
                FileStream file_Log = new FileStream(saveFileDialog_SaveLog.FileName, FileMode.Create, FileAccess.ReadWrite);

                byte[] byteArray_LogItem;

                int int_LogItemLength;

                string string_LogItemText = string.Empty;;

                string [] stringArray_ItemsNames = new string[5];

                stringArray_ItemsNames[0] = "Òèï: ";
                stringArray_ItemsNames[1] = "Äàòà è Âðåìÿ: ";
                stringArray_ItemsNames[2] = "Ïîëüçîâàòåëü: ";
                stringArray_ItemsNames[3] = "UIN: ";
                stringArray_ItemsNames[4] = "Îïèñàíèå: ";

                byteArray_LogItem = System.Text.Encoding.Default.GetBytes("Servers events log. Generated by YakSys Connecting Service ver 1.0.\n\n\n");
                int_LogItemLength = byteArray_LogItem.Length;
                file_Log.Write(byteArray_LogItem, 0, int_LogItemLength);

                for (int int_CycleCount = 0; this.listView_ServersEventsLog_LogList.Items.Count != int_CycleCount; int_CycleCount++)
                {
                    string_LogItemText = "\n\n\n"; 
                    string_LogItemText += "Eevent #" + (int_CycleCount+1).ToString()+"\n-----------------------------------------------\n\n";

                    for (int int_SubCycleCount = 0; 5 != int_SubCycleCount; int_SubCycleCount++)
                    {                        
                        string_LogItemText += stringArray_ItemsNames[int_SubCycleCount];

                        string_LogItemText += this.listView_ServersEventsLog_LogList.Items[int_CycleCount].SubItems[int_SubCycleCount].Text;
                        string_LogItemText += "\n"; 

                        byteArray_LogItem = System.Text.Encoding.Default.GetBytes(string_LogItemText);
                        int_LogItemLength = byteArray_LogItem.Length;
                        file_Log.Write(byteArray_LogItem, 0, int_LogItemLength);

                        string_LogItemText = string.Empty;
                    }
                }

                file_Log.Close();
            }
        }

        else
        {
            MessageBox.Show(ServerStringFactory.GetString(41, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }

    private void button_ClientsEventsLog_SaveLog_Click(object sender, EventArgs e)
    {
        if (this.listView_ClientsEventsLog_LogList.Items.Count > 0)
        {
            SaveFileDialog saveFileDialog_SaveLog = new SaveFileDialog();

            saveFileDialog_SaveLog.AddExtension = true;

            saveFileDialog_SaveLog.DefaultExt = ".txt";

            saveFileDialog_SaveLog.Filter = "Text files(*.txt)|*.txt";

            if (DialogResult.OK == saveFileDialog_SaveLog.ShowDialog(this))
            {
                FileStream file_Log = new FileStream(saveFileDialog_SaveLog.FileName, FileMode.Create, FileAccess.ReadWrite);

                byte[] byteArray_LogItem;

                int int_LogItemLength;

                string string_LogItemText = string.Empty; ;

                string[] stringArray_ItemsNames = new string[5];

                stringArray_ItemsNames[0] = "Òèï: ";
                stringArray_ItemsNames[1] = "Äàòà è Âðåìÿ: ";
                stringArray_ItemsNames[2] = "Ïîëüçîâàòåëü: ";
                stringArray_ItemsNames[3] = "UIN: ";
                stringArray_ItemsNames[4] = "Îïèñàíèå: ";

                byteArray_LogItem = System.Text.Encoding.Default.GetBytes("Client events log. Generated by YakSys Connecting Service ver 1.0.\n\n\n");
                int_LogItemLength = byteArray_LogItem.Length;
                file_Log.Write(byteArray_LogItem, 0, int_LogItemLength);

                for (int int_CycleCount = 0; this.listView_ClientsEventsLog_LogList.Items.Count != int_CycleCount; int_CycleCount++)
                {
                    string_LogItemText = "\n\n\n";
                    string_LogItemText += "Eevent #" + (int_CycleCount + 1).ToString() + "\n-----------------------------------------------\n\n";

                    for (int int_SubCycleCount = 0; 5 != int_SubCycleCount; int_SubCycleCount++)
                    {
                        string_LogItemText += stringArray_ItemsNames[int_SubCycleCount];

                        string_LogItemText += this.listView_ClientsEventsLog_LogList.Items[int_CycleCount].SubItems[int_SubCycleCount].Text;
                        string_LogItemText += "\n";

                        byteArray_LogItem = System.Text.Encoding.Default.GetBytes(string_LogItemText);
                        int_LogItemLength = byteArray_LogItem.Length;
                        file_Log.Write(byteArray_LogItem, 0, int_LogItemLength);

                        string_LogItemText = string.Empty;
                    }
                }

                file_Log.Close();
            }
        }

        else
        {
            MessageBox.Show(ServerStringFactory.GetString(41, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }

}
