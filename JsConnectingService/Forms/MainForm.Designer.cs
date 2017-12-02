
partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        this.checkBox_MainWindowParameters_ShowInNotifyArea = new System.Windows.Forms.CheckBox();
        this.button_Main_WindowParameters = new System.Windows.Forms.Button();
        this.groupBox_Main_MainNetworkControl = new System.Windows.Forms.GroupBox();
        this.textBox_Main_ListeningPort = new System.Windows.Forms.TextBox();
        this.textBox_Main_ServerStatus = new System.Windows.Forms.TextBox();
        this.label_Main_ServerPort = new System.Windows.Forms.Label();
        this.label_Main_ServerStatus = new System.Windows.Forms.Label();
        this.button_Main_StopServer = new System.Windows.Forms.Button();
        this.button_MainForm_StartServer = new System.Windows.Forms.Button();
        this.pictureBox_Main_Control = new System.Windows.Forms.PictureBox();
        this.button_Main_AdditionalParameters = new System.Windows.Forms.Button();
        this.groupBoxMain_ActiveInterConnections = new System.Windows.Forms.GroupBox();
        this.button_ActiveInterConnections_SwitchToServer = new System.Windows.Forms.Button();
        this.button_ActiveInterConnections_SwitchToClient = new System.Windows.Forms.Button();
        this.button_ActiveInterConnections_DisconnectAll = new System.Windows.Forms.Button();
        this.button_ActiveInterConnections_DisconnectInterConnection = new System.Windows.Forms.Button();
        this.listView_ActiveInterConnections_ConnectionsList = new System.Windows.Forms.ListView();
        this.columnHeader_InterconnectionLists_ServerUIN = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_InterconnectionLists_ServerIP = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_InterconnectionLists_ClientUIN = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_InterconnectionLists_ClientIP = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_InterconnectionLists_ConnectedAt = new System.Windows.Forms.ColumnHeader();
        this.tabControl_Main = new System.Windows.Forms.TabControl();
        this.tabPage_NetworkControl = new System.Windows.Forms.TabPage();
        this.groupBox_ActiveConnectionDetails_Statistic = new System.Windows.Forms.GroupBox();
        this.textBox_ActiveConnectionDetails_ServerBytesReceived = new System.Windows.Forms.TextBox();
        this.textBox_ActiveConnectionDetails_ServerBytesSent = new System.Windows.Forms.TextBox();
        this.label_ActiveConnectionDetails_ServerBytesReceived = new System.Windows.Forms.Label();
        this.label_ActiveConnectionDetails_ServerBytesSent = new System.Windows.Forms.Label();
        this.textBox_ActiveConnectionDetails_ClientBytesReceived = new System.Windows.Forms.TextBox();
        this.textBox_ActiveConnectionDetails_ClientBytesSent = new System.Windows.Forms.TextBox();
        this.label_ActiveConnectionDetails_ClientBytesReceived = new System.Windows.Forms.Label();
        this.label_ActiveConnectionDetails_ClientBytesSent = new System.Windows.Forms.Label();
        this.groupBox_Main_CommonStatistic = new System.Windows.Forms.GroupBox();
        this.textBox_CommonStatistic_ActiveConnections = new System.Windows.Forms.TextBox();
        this.label_CommonStatistic_Connections = new System.Windows.Forms.Label();
        this.textBox_CommonStatistic_LastConnectionAt = new System.Windows.Forms.TextBox();
        this.textBox_CommonStatistic_BytesReceived = new System.Windows.Forms.TextBox();
        this.textBox_CommonStatistic_BytesSent = new System.Windows.Forms.TextBox();
        this.label_CommonStatistic_LastConnectionAt = new System.Windows.Forms.Label();
        this.label_CommonStatistic_BytesReceived = new System.Windows.Forms.Label();
        this.label_CommonStatistic_BytesSent = new System.Windows.Forms.Label();
        this.tabPage_ConnectedObjects = new System.Windows.Forms.TabPage();
        this.groupBox_ConnectedUsers_ConnectedClients = new System.Windows.Forms.GroupBox();
        this.groupBox_ConnectedClients_Details = new System.Windows.Forms.GroupBox();
        this.textBox_ClientDetails_MACAddress = new System.Windows.Forms.TextBox();
        this.textBox_ClientDetails_ConnectedAt = new System.Windows.Forms.TextBox();
        this.textBox_ClientDetails_IPAddress = new System.Windows.Forms.TextBox();
        this.textBox_ClientDetails_BytesReceived = new System.Windows.Forms.TextBox();
        this.label_ClientDetails_IPAddress = new System.Windows.Forms.Label();
        this.textBox_ClientDetails_BytesSent = new System.Windows.Forms.TextBox();
        this.label_ClientDetails_MACAddress = new System.Windows.Forms.Label();
        this.label_ClientDetails_CannectedAt = new System.Windows.Forms.Label();
        this.label_ClientDetails_BytesReceived = new System.Windows.Forms.Label();
        this.label_ClientDetails_BytesSent = new System.Windows.Forms.Label();
        this.button_ConnectedClients_DisconnectClient = new System.Windows.Forms.Button();
        this.listView_ConnectedUsers_ConnectedClients = new System.Windows.Forms.ListView();
        this.columnHeader_ConnectedClients_ClientUIN = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ConnectedClients_UserName = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ConnectedClients_ClientIP = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ConnectedClients_ConnectedAt = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ConnectedClients_Status = new System.Windows.Forms.ColumnHeader();
        this.button_ConnectedClients_DisconnectAll = new System.Windows.Forms.Button();
        this.groupBox_ConnectedUsers_ConnectedServers = new System.Windows.Forms.GroupBox();
        this.listView_ConnectedUsers_ConnectedServers = new System.Windows.Forms.ListView();
        this.columnHeader_ConnectedServers_ServerUIN = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ConnectedServers_UserName = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ConnectedServers_ServerIP = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ConnectedServers_ConnectedAt = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ConnectedServers_Status = new System.Windows.Forms.ColumnHeader();
        this.button_ConnectedServers_DisconnectAll = new System.Windows.Forms.Button();
        this.button_ConnectedServers_DisconnectServer = new System.Windows.Forms.Button();
        this.groupBox_ConnectedServers_Details = new System.Windows.Forms.GroupBox();
        this.textBox_ServerDetails_ConnectedAt = new System.Windows.Forms.TextBox();
        this.label_ServerDetails_MACAddress = new System.Windows.Forms.Label();
        this.textBox_ServerDetails_IPAddress = new System.Windows.Forms.TextBox();
        this.label_ServerDetails_CannectedAt = new System.Windows.Forms.Label();
        this.textBox_ServerDetails_MACAddress = new System.Windows.Forms.TextBox();
        this.textBox_ServerDetails_BytesReceived = new System.Windows.Forms.TextBox();
        this.label_ServerDetails_IPAddress = new System.Windows.Forms.Label();
        this.label_ServerDetails_BytesReceived = new System.Windows.Forms.Label();
        this.textBox_ServerDetails_BytesSent = new System.Windows.Forms.TextBox();
        this.label_ServerDetails_BytesSent = new System.Windows.Forms.Label();
        this.tabPage_ClientsAccounts = new System.Windows.Forms.TabPage();
        this.groupBox_ClientsAccounts_RestrictionRules = new System.Windows.Forms.GroupBox();
        this.listView_ClientsRestrictionRules_RulestList = new System.Windows.Forms.ListView();
        this.columnHeader_ClientsRestrictionRules_IPRange = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsRestrictionRules_IPAddress = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsRestrictionRules_MACAddress = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsRestrictionRules_RuleType = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsRestrictionRules_CreationTime = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsRestrictionRules_RuleStatus = new System.Windows.Forms.ColumnHeader();
        this.button_ClientsRestrictionRules_ViewRule = new System.Windows.Forms.Button();
        this.button_ClientsRestrictionRules_EnableRule = new System.Windows.Forms.Button();
        this.button51 = new System.Windows.Forms.Button();
        this.button_ClientsRestrictionRules_DisableRule = new System.Windows.Forms.Button();
        this.label_ClientsRestrictionRules_RestrictionRules = new System.Windows.Forms.Label();
        this.button_ClientsRestrictionRules_EditRule = new System.Windows.Forms.Button();
        this.button_ClientsRestrictionRules_ClearRulesList = new System.Windows.Forms.Button();
        this.button_ClientsRestrictionRules_AddRule = new System.Windows.Forms.Button();
        this.checkBox_ClientsRestrictionRules_UseRestrictionRules = new System.Windows.Forms.CheckBox();
        this.button_ClientsRestrictionRules_RemoveRule = new System.Windows.Forms.Button();
        this.groupBox_ClientsAccounts_Accounts = new System.Windows.Forms.GroupBox();
        this.button_ClientsAccounts_ActivateAccount = new System.Windows.Forms.Button();
        this.button_ClientsAccounts_ClearAccountsList = new System.Windows.Forms.Button();
        this.button_ClientsAccounts_RemoveAccount = new System.Windows.Forms.Button();
        this.button_ClientsAccounts_AddAccount = new System.Windows.Forms.Button();
        this.listView_ClientsAccounts_ClientsAccounts = new System.Windows.Forms.ListView();
        this.columnHeader_ClientsAccounts_User = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsAccounts_UIN = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsAccounts_ActivationCode = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsAccounts_CreationTime = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsAccounts_ActivationTime = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsAccounts_Status = new System.Windows.Forms.ColumnHeader();
        this.button_ClientsAccounts_DisableAccount = new System.Windows.Forms.Button();
        this.button_ClientsAccounts_EnableAccount = new System.Windows.Forms.Button();
        this.button_ClientsAccounts_EditAccount = new System.Windows.Forms.Button();
        this.button_ClientsAccounts_ViewAccount = new System.Windows.Forms.Button();
        this.label2 = new System.Windows.Forms.Label();
        this.tabPage_ServersAccounts = new System.Windows.Forms.TabPage();
        this.groupBox_ServersAccounts_RestrictionRules = new System.Windows.Forms.GroupBox();
        this.listView_ServersRestrictionRules_RulestList = new System.Windows.Forms.ListView();
        this.columnHeader_ServersRestrictionRules_IPRange = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersRestrictionRules_IPAddress = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersRestrictionRules_MACAddress = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersRestrictionRules_RuleType = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersRestrictionRules_CreationTime = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersRestrictionRules_RuleStatus = new System.Windows.Forms.ColumnHeader();
        this.button57 = new System.Windows.Forms.Button();
        this.button_ServersRestrictionRules_ViewRule = new System.Windows.Forms.Button();
        this.button59 = new System.Windows.Forms.Button();
        this.button_ServersRestrictionRules_EnableRule = new System.Windows.Forms.Button();
        this.button61 = new System.Windows.Forms.Button();
        this.button_ServersRestrictionRules_DisableRule = new System.Windows.Forms.Button();
        this.label_ServersRestrictionRules_RestrictionRules = new System.Windows.Forms.Label();
        this.button_ServersRestrictionRules_EditRule = new System.Windows.Forms.Button();
        this.button_ServersRestrictionRules_ClearRulesList = new System.Windows.Forms.Button();
        this.button_ServersRestrictionRules_AddRule = new System.Windows.Forms.Button();
        this.checkBox_ServersRestrictionRules_UseRestrictionRules = new System.Windows.Forms.CheckBox();
        this.button_ServersRestrictionRules_RemoveRule = new System.Windows.Forms.Button();
        this.groupBox_ServersAccounts_Accounts = new System.Windows.Forms.GroupBox();
        this.button_ServersAccounts_ActivateAccount = new System.Windows.Forms.Button();
        this.button67 = new System.Windows.Forms.Button();
        this.button68 = new System.Windows.Forms.Button();
        this.button69 = new System.Windows.Forms.Button();
        this.button_ServersAccounts_ClearAccountsList = new System.Windows.Forms.Button();
        this.button_ServersAccounts_RemoveAccount = new System.Windows.Forms.Button();
        this.button_ServersAccounts_AddAccount = new System.Windows.Forms.Button();
        this.listView_ServersAccounts_ServersAccounts = new System.Windows.Forms.ListView();
        this.columnHeader_ServersAccounts_User = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersAccounts_UIN = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersAccounts_ActivationCode = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersAccounts_CreationTime = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersAccounts_ActivationTime = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersAccounts_Status = new System.Windows.Forms.ColumnHeader();
        this.button_ServersAccounts_DisableAccount = new System.Windows.Forms.Button();
        this.button_ServersAccounts_EnableAccount = new System.Windows.Forms.Button();
        this.button_ServersAccounts_EditAccount = new System.Windows.Forms.Button();
        this.button_ServersAccounts_ViewAccount = new System.Windows.Forms.Button();
        this.label9 = new System.Windows.Forms.Label();
        this.tabPage_EventsLogs = new System.Windows.Forms.TabPage();
        this.groupBox_EventsLog_SeversEventsLog = new System.Windows.Forms.GroupBox();
        this.button_ServersEventsLog_SaveLog = new System.Windows.Forms.Button();
        this.listView_ServersEventsLog_LogList = new System.Windows.Forms.ListView();
        this.columnHeader_ServersEventsLog_EventType = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersEventsLog_RecordTime = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersEventsLog_UserName = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersEventsLog_UIN = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ServersEventsLog_EventInformation = new System.Windows.Forms.ColumnHeader();
        this.button_ServersEventsLog_ClearLog = new System.Windows.Forms.Button();
        this.button4 = new System.Windows.Forms.Button();
        this.button5 = new System.Windows.Forms.Button();
        this.button6 = new System.Windows.Forms.Button();
        this.label_ServersEventsLog_Events = new System.Windows.Forms.Label();
        this.groupBox_EventsLog_ClientsEventsLog = new System.Windows.Forms.GroupBox();
        this.button_ClientsEventsLog_SaveLog = new System.Windows.Forms.Button();
        this.listView_ClientsEventsLog_LogList = new System.Windows.Forms.ListView();
        this.columnHeader_ClientsEventsLog_EventType = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsEventsLog_RecordTime = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsEventsLog_UserName = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsEventsLog_UIN = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ClientsEventsLog_EventInformation = new System.Windows.Forms.ColumnHeader();
        this.button_ClientsEventsLog_ClearLog = new System.Windows.Forms.Button();
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button3 = new System.Windows.Forms.Button();
        this.label_ClientsEventsLog_Events = new System.Windows.Forms.Label();
        this.groupBox_EventsLog_CommonEventsLog = new System.Windows.Forms.GroupBox();
        this.button_CommonEventsLog_SaveLog = new System.Windows.Forms.Button();
        this.button_CommonEventsLog_ClearLog = new System.Windows.Forms.Button();
        this.listView_CommonEventsLog_LogList = new System.Windows.Forms.ListView();
        this.columnHeader_CommonEventsLogList_EventType = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_CommonEventsLogList_RecordTime = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_CommonEventsLogList_EventInformation = new System.Windows.Forms.ColumnHeader();
        this.button24 = new System.Windows.Forms.Button();
        this.button25 = new System.Windows.Forms.Button();
        this.button26 = new System.Windows.Forms.Button();
        this.label_CommonEventsLog_Events = new System.Windows.Forms.Label();
        this.button_Security_ViewClientAccount = new System.Windows.Forms.Button();
        this.button_Security_ClearClientAccounts = new System.Windows.Forms.Button();
        this.label_Security_ListOfUsersAccounts = new System.Windows.Forms.Label();
        this.button_Security_EditClientAccount = new System.Windows.Forms.Button();
        this.button_Security_EnableClientAccount = new System.Windows.Forms.Button();
        this.button_Security_DisableClientAccount = new System.Windows.Forms.Button();
        this.listView_Security_ListOfUsersAccounts = new System.Windows.Forms.ListView();
        this.columnHeader_UsersDatabase_User = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_UsersDatabase_Login = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_UsersDatabase_TimeOfCreation = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_UsersDatabase_AccountStatus = new System.Windows.Forms.ColumnHeader();
        this.button_Security_AddNewUser = new System.Windows.Forms.Button();
        this.button_Security_RemoveClientAccount = new System.Windows.Forms.Button();
        this.button7 = new System.Windows.Forms.Button();
        this.button8 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.button9 = new System.Windows.Forms.Button();
        this.button10 = new System.Windows.Forms.Button();
        this.button11 = new System.Windows.Forms.Button();
        this.listView3 = new System.Windows.Forms.ListView();
        this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
        this.button12 = new System.Windows.Forms.Button();
        this.button13 = new System.Windows.Forms.Button();
        this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
        this.menuItem_File = new System.Windows.Forms.MenuItem();
        this.menuItem_File_Import = new System.Windows.Forms.MenuItem();
        this.menuItem_File_Import_SettingsDatabase = new System.Windows.Forms.MenuItem();
        this.menuItem_File_Export = new System.Windows.Forms.MenuItem();
        this.menuItem_File_Export_SettingsDatabase = new System.Windows.Forms.MenuItem();
        this.menuItem_File_Exit = new System.Windows.Forms.MenuItem();
        this.menuItem_Options = new System.Windows.Forms.MenuItem();
        this.menuItem_Options_Settings = new System.Windows.Forms.MenuItem();
        this.menuItem_Help = new System.Windows.Forms.MenuItem();
        this.menuItem_Help_About = new System.Windows.Forms.MenuItem();
        this.button21 = new System.Windows.Forms.Button();
        this.button22 = new System.Windows.Forms.Button();
        this.button23 = new System.Windows.Forms.Button();
        this.button27 = new System.Windows.Forms.Button();
        this.button28 = new System.Windows.Forms.Button();
        this.button29 = new System.Windows.Forms.Button();
        this.label3 = new System.Windows.Forms.Label();
        this.button30 = new System.Windows.Forms.Button();
        this.listView5 = new System.Windows.Forms.ListView();
        this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
        this.button31 = new System.Windows.Forms.Button();
        this.button32 = new System.Windows.Forms.Button();
        this.checkBox1 = new System.Windows.Forms.CheckBox();
        this.button33 = new System.Windows.Forms.Button();
        this.button34 = new System.Windows.Forms.Button();
        this.button38 = new System.Windows.Forms.Button();
        this.button39 = new System.Windows.Forms.Button();
        this.button40 = new System.Windows.Forms.Button();
        this.button41 = new System.Windows.Forms.Button();
        this.button42 = new System.Windows.Forms.Button();
        this.listView6 = new System.Windows.Forms.ListView();
        this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
        this.button43 = new System.Windows.Forms.Button();
        this.button44 = new System.Windows.Forms.Button();
        this.button45 = new System.Windows.Forms.Button();
        this.button46 = new System.Windows.Forms.Button();
        this.label4 = new System.Windows.Forms.Label();
        this.notifyIcon_Main = new System.Windows.Forms.NotifyIcon(this.components);
        this.contextMenu_WindowParameters = new System.Windows.Forms.ContextMenu();
        this.menuItem_MainWindowState_ActivateHiddenMode = new System.Windows.Forms.MenuItem();
        this.menuItem_MainWindowState_MinimizeToNotifyArea = new System.Windows.Forms.MenuItem();
        this.menuItem_MainWindowState_MinimizeToTaskBar = new System.Windows.Forms.MenuItem();
        this.groupBox_Main_MainNetworkControl.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Main_Control)).BeginInit();
        this.groupBoxMain_ActiveInterConnections.SuspendLayout();
        this.tabControl_Main.SuspendLayout();
        this.tabPage_NetworkControl.SuspendLayout();
        this.groupBox_ActiveConnectionDetails_Statistic.SuspendLayout();
        this.groupBox_Main_CommonStatistic.SuspendLayout();
        this.tabPage_ConnectedObjects.SuspendLayout();
        this.groupBox_ConnectedUsers_ConnectedClients.SuspendLayout();
        this.groupBox_ConnectedClients_Details.SuspendLayout();
        this.groupBox_ConnectedUsers_ConnectedServers.SuspendLayout();
        this.groupBox_ConnectedServers_Details.SuspendLayout();
        this.tabPage_ClientsAccounts.SuspendLayout();
        this.groupBox_ClientsAccounts_RestrictionRules.SuspendLayout();
        this.groupBox_ClientsAccounts_Accounts.SuspendLayout();
        this.tabPage_ServersAccounts.SuspendLayout();
        this.groupBox_ServersAccounts_RestrictionRules.SuspendLayout();
        this.groupBox_ServersAccounts_Accounts.SuspendLayout();
        this.tabPage_EventsLogs.SuspendLayout();
        this.groupBox_EventsLog_SeversEventsLog.SuspendLayout();
        this.groupBox_EventsLog_ClientsEventsLog.SuspendLayout();
        this.groupBox_EventsLog_CommonEventsLog.SuspendLayout();
        this.SuspendLayout();
        // 
        // checkBox_MainWindowParameters_ShowInNotifyArea
        // 
        this.checkBox_MainWindowParameters_ShowInNotifyArea.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_MainWindowParameters_ShowInNotifyArea.Location = new System.Drawing.Point(14, 217);
        this.checkBox_MainWindowParameters_ShowInNotifyArea.Name = "checkBox_MainWindowParameters_ShowInNotifyArea";
        this.checkBox_MainWindowParameters_ShowInNotifyArea.Size = new System.Drawing.Size(158, 16);
        this.checkBox_MainWindowParameters_ShowInNotifyArea.TabIndex = 14;
        this.checkBox_MainWindowParameters_ShowInNotifyArea.Text = "Show in Notify Area";
        this.checkBox_MainWindowParameters_ShowInNotifyArea.UseVisualStyleBackColor = true;
        this.checkBox_MainWindowParameters_ShowInNotifyArea.CheckedChanged += new System.EventHandler(this.checkBox_MainWindowParameters_ShowInNotifyArea_CheckedChanged);
        // 
        // button_Main_WindowParameters
        // 
        this.button_Main_WindowParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_Main_WindowParameters.Location = new System.Drawing.Point(14, 178);
        this.button_Main_WindowParameters.Name = "button_Main_WindowParameters";
        this.button_Main_WindowParameters.Size = new System.Drawing.Size(158, 23);
        this.button_Main_WindowParameters.TabIndex = 13;
        this.button_Main_WindowParameters.Text = "Window Parameters";
        this.button_Main_WindowParameters.Click += new System.EventHandler(this.button_Main_WindowParameters_Click);
        // 
        // groupBox_Main_MainNetworkControl
        // 
        this.groupBox_Main_MainNetworkControl.Controls.Add(this.textBox_Main_ListeningPort);
        this.groupBox_Main_MainNetworkControl.Controls.Add(this.textBox_Main_ServerStatus);
        this.groupBox_Main_MainNetworkControl.Controls.Add(this.label_Main_ServerPort);
        this.groupBox_Main_MainNetworkControl.Controls.Add(this.label_Main_ServerStatus);
        this.groupBox_Main_MainNetworkControl.Controls.Add(this.button_Main_StopServer);
        this.groupBox_Main_MainNetworkControl.Controls.Add(this.button_MainForm_StartServer);
        this.groupBox_Main_MainNetworkControl.Controls.Add(this.pictureBox_Main_Control);
        this.groupBox_Main_MainNetworkControl.Controls.Add(this.button_Main_AdditionalParameters);
        this.groupBox_Main_MainNetworkControl.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_Main_MainNetworkControl.Location = new System.Drawing.Point(6, 6);
        this.groupBox_Main_MainNetworkControl.Name = "groupBox_Main_MainNetworkControl";
        this.groupBox_Main_MainNetworkControl.Size = new System.Drawing.Size(175, 162);
        this.groupBox_Main_MainNetworkControl.TabIndex = 11;
        this.groupBox_Main_MainNetworkControl.TabStop = false;
        this.groupBox_Main_MainNetworkControl.Text = "Main Network Control";
        // 
        // textBox_Main_ListeningPort
        // 
        this.textBox_Main_ListeningPort.Location = new System.Drawing.Point(91, 24);
        this.textBox_Main_ListeningPort.MaxLength = 5;
        this.textBox_Main_ListeningPort.Name = "textBox_Main_ListeningPort";
        this.textBox_Main_ListeningPort.Size = new System.Drawing.Size(75, 20);
        this.textBox_Main_ListeningPort.TabIndex = 0;
        this.textBox_Main_ListeningPort.Text = "5545";
        // 
        // textBox_Main_ServerStatus
        // 
        this.textBox_Main_ServerStatus.Location = new System.Drawing.Point(91, 64);
        this.textBox_Main_ServerStatus.Name = "textBox_Main_ServerStatus";
        this.textBox_Main_ServerStatus.ReadOnly = true;
        this.textBox_Main_ServerStatus.Size = new System.Drawing.Size(75, 20);
        this.textBox_Main_ServerStatus.TabIndex = 5;
        // 
        // label_Main_ServerPort
        // 
        this.label_Main_ServerPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_Main_ServerPort.Location = new System.Drawing.Point(43, 25);
        this.label_Main_ServerPort.Name = "label_Main_ServerPort";
        this.label_Main_ServerPort.Size = new System.Drawing.Size(40, 16);
        this.label_Main_ServerPort.TabIndex = 3;
        this.label_Main_ServerPort.Text = "Port:";
        this.label_Main_ServerPort.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // label_Main_ServerStatus
        // 
        this.label_Main_ServerStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_Main_ServerStatus.Location = new System.Drawing.Point(27, 68);
        this.label_Main_ServerStatus.Name = "label_Main_ServerStatus";
        this.label_Main_ServerStatus.Size = new System.Drawing.Size(56, 16);
        this.label_Main_ServerStatus.TabIndex = 2;
        this.label_Main_ServerStatus.Text = "Status:";
        this.label_Main_ServerStatus.TextAlign = System.Drawing.ContentAlignment.BottomRight;
        // 
        // button_Main_StopServer
        // 
        this.button_Main_StopServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_Main_StopServer.Location = new System.Drawing.Point(91, 96);
        this.button_Main_StopServer.Name = "button_Main_StopServer";
        this.button_Main_StopServer.Size = new System.Drawing.Size(75, 23);
        this.button_Main_StopServer.TabIndex = 2;
        this.button_Main_StopServer.Text = "Stop";
        this.button_Main_StopServer.Click += new System.EventHandler(this.button_Main_StopServer_Click);
        // 
        // button_MainForm_StartServer
        // 
        this.button_MainForm_StartServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_MainForm_StartServer.Location = new System.Drawing.Point(8, 96);
        this.button_MainForm_StartServer.Name = "button_MainForm_StartServer";
        this.button_MainForm_StartServer.Size = new System.Drawing.Size(75, 23);
        this.button_MainForm_StartServer.TabIndex = 1;
        this.button_MainForm_StartServer.Text = "Start";
        this.button_MainForm_StartServer.Click += new System.EventHandler(this.button_MainForm_StartServer_Click);
        // 
        // pictureBox_Main_Control
        // 
        this.pictureBox_Main_Control.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Main_Control.Image")));
        this.pictureBox_Main_Control.Location = new System.Drawing.Point(8, 16);
        this.pictureBox_Main_Control.Name = "pictureBox_Main_Control";
        this.pictureBox_Main_Control.Size = new System.Drawing.Size(32, 32);
        this.pictureBox_Main_Control.TabIndex = 7;
        this.pictureBox_Main_Control.TabStop = false;
        // 
        // button_Main_AdditionalParameters
        // 
        this.button_Main_AdditionalParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_Main_AdditionalParameters.Location = new System.Drawing.Point(8, 128);
        this.button_Main_AdditionalParameters.Name = "button_Main_AdditionalParameters";
        this.button_Main_AdditionalParameters.Size = new System.Drawing.Size(158, 23);
        this.button_Main_AdditionalParameters.TabIndex = 9;
        this.button_Main_AdditionalParameters.Text = "Additional Parameters";
        this.button_Main_AdditionalParameters.Click += new System.EventHandler(this.button_Main_AdditionalParameters_Click);
        // 
        // groupBoxMain_ActiveInterConnections
        // 
        this.groupBoxMain_ActiveInterConnections.Controls.Add(this.button_ActiveInterConnections_SwitchToServer);
        this.groupBoxMain_ActiveInterConnections.Controls.Add(this.button_ActiveInterConnections_SwitchToClient);
        this.groupBoxMain_ActiveInterConnections.Controls.Add(this.button_ActiveInterConnections_DisconnectAll);
        this.groupBoxMain_ActiveInterConnections.Controls.Add(this.button_ActiveInterConnections_DisconnectInterConnection);
        this.groupBoxMain_ActiveInterConnections.Controls.Add(this.listView_ActiveInterConnections_ConnectionsList);
        this.groupBoxMain_ActiveInterConnections.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBoxMain_ActiveInterConnections.Location = new System.Drawing.Point(187, 6);
        this.groupBoxMain_ActiveInterConnections.Name = "groupBoxMain_ActiveInterConnections";
        this.groupBoxMain_ActiveInterConnections.Size = new System.Drawing.Size(779, 640);
        this.groupBoxMain_ActiveInterConnections.TabIndex = 15;
        this.groupBoxMain_ActiveInterConnections.TabStop = false;
        this.groupBoxMain_ActiveInterConnections.Text = "Active InterConnections";
        // 
        // button_ActiveInterConnections_SwitchToServer
        // 
        this.button_ActiveInterConnections_SwitchToServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ActiveInterConnections_SwitchToServer.Location = new System.Drawing.Point(360, 606);
        this.button_ActiveInterConnections_SwitchToServer.Name = "button_ActiveInterConnections_SwitchToServer";
        this.button_ActiveInterConnections_SwitchToServer.Size = new System.Drawing.Size(107, 23);
        this.button_ActiveInterConnections_SwitchToServer.TabIndex = 4;
        this.button_ActiveInterConnections_SwitchToServer.Text = "Switch to Server";
        this.button_ActiveInterConnections_SwitchToServer.Click += new System.EventHandler(this.button_ActiveInterConnections_SwitchToServer_Click);
        // 
        // button_ActiveInterConnections_SwitchToClient
        // 
        this.button_ActiveInterConnections_SwitchToClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ActiveInterConnections_SwitchToClient.Location = new System.Drawing.Point(241, 606);
        this.button_ActiveInterConnections_SwitchToClient.Name = "button_ActiveInterConnections_SwitchToClient";
        this.button_ActiveInterConnections_SwitchToClient.Size = new System.Drawing.Size(113, 23);
        this.button_ActiveInterConnections_SwitchToClient.TabIndex = 3;
        this.button_ActiveInterConnections_SwitchToClient.Text = "Switch to Client";
        this.button_ActiveInterConnections_SwitchToClient.Click += new System.EventHandler(this.button_ActiveInterConnections_SwitchToClient_Click);
        // 
        // button_ActiveInterConnections_DisconnectAll
        // 
        this.button_ActiveInterConnections_DisconnectAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ActiveInterConnections_DisconnectAll.Location = new System.Drawing.Point(128, 606);
        this.button_ActiveInterConnections_DisconnectAll.Name = "button_ActiveInterConnections_DisconnectAll";
        this.button_ActiveInterConnections_DisconnectAll.Size = new System.Drawing.Size(107, 23);
        this.button_ActiveInterConnections_DisconnectAll.TabIndex = 2;
        this.button_ActiveInterConnections_DisconnectAll.Text = "Disconnect All";
        this.button_ActiveInterConnections_DisconnectAll.Click += new System.EventHandler(this.button_ActiveInterConnections_DisconnectAll_Click);
        // 
        // button_ActiveInterConnections_DisconnectInterConnection
        // 
        this.button_ActiveInterConnections_DisconnectInterConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ActiveInterConnections_DisconnectInterConnection.Location = new System.Drawing.Point(9, 606);
        this.button_ActiveInterConnections_DisconnectInterConnection.Name = "button_ActiveInterConnections_DisconnectInterConnection";
        this.button_ActiveInterConnections_DisconnectInterConnection.Size = new System.Drawing.Size(113, 23);
        this.button_ActiveInterConnections_DisconnectInterConnection.TabIndex = 1;
        this.button_ActiveInterConnections_DisconnectInterConnection.Text = "Disconnect";
        this.button_ActiveInterConnections_DisconnectInterConnection.Click += new System.EventHandler(this.button_ActiveInterConnections_DisconnectInterConnection_Click);
        // 
        // listView_ActiveInterConnections_ConnectionsList
        // 
        this.listView_ActiveInterConnections_ConnectionsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_InterconnectionLists_ServerUIN,
            this.columnHeader_InterconnectionLists_ServerIP,
            this.columnHeader_InterconnectionLists_ClientUIN,
            this.columnHeader_InterconnectionLists_ClientIP,
            this.columnHeader_InterconnectionLists_ConnectedAt});
        this.listView_ActiveInterConnections_ConnectionsList.FullRowSelect = true;
        this.listView_ActiveInterConnections_ConnectionsList.GridLines = true;
        this.listView_ActiveInterConnections_ConnectionsList.HideSelection = false;
        this.listView_ActiveInterConnections_ConnectionsList.Location = new System.Drawing.Point(9, 24);
        this.listView_ActiveInterConnections_ConnectionsList.Name = "listView_ActiveInterConnections_ConnectionsList";
        this.listView_ActiveInterConnections_ConnectionsList.Size = new System.Drawing.Size(760, 566);
        this.listView_ActiveInterConnections_ConnectionsList.TabIndex = 0;
        this.listView_ActiveInterConnections_ConnectionsList.UseCompatibleStateImageBehavior = false;
        this.listView_ActiveInterConnections_ConnectionsList.View = System.Windows.Forms.View.Details;
        this.listView_ActiveInterConnections_ConnectionsList.SelectedIndexChanged += new System.EventHandler(this.listView_ActiveInterConnections_ConnectionsList_SelectedIndexChanged);
        // 
        // columnHeader_InterconnectionLists_ServerUIN
        // 
        this.columnHeader_InterconnectionLists_ServerUIN.Text = "Server UIN";
        this.columnHeader_InterconnectionLists_ServerUIN.Width = 110;
        // 
        // columnHeader_InterconnectionLists_ServerIP
        // 
        this.columnHeader_InterconnectionLists_ServerIP.Text = "Server IP";
        this.columnHeader_InterconnectionLists_ServerIP.Width = 120;
        // 
        // columnHeader_InterconnectionLists_ClientUIN
        // 
        this.columnHeader_InterconnectionLists_ClientUIN.Text = "Client UIN";
        this.columnHeader_InterconnectionLists_ClientUIN.Width = 110;
        // 
        // columnHeader_InterconnectionLists_ClientIP
        // 
        this.columnHeader_InterconnectionLists_ClientIP.Text = "Client IP";
        this.columnHeader_InterconnectionLists_ClientIP.Width = 120;
        // 
        // columnHeader_InterconnectionLists_ConnectedAt
        // 
        this.columnHeader_InterconnectionLists_ConnectedAt.Text = "Connected At";
        this.columnHeader_InterconnectionLists_ConnectedAt.Width = 120;
        // 
        // tabControl_Main
        // 
        this.tabControl_Main.Controls.Add(this.tabPage_NetworkControl);
        this.tabControl_Main.Controls.Add(this.tabPage_ConnectedObjects);
        this.tabControl_Main.Controls.Add(this.tabPage_ClientsAccounts);
        this.tabControl_Main.Controls.Add(this.tabPage_ServersAccounts);
        this.tabControl_Main.Controls.Add(this.tabPage_EventsLogs);
        this.tabControl_Main.Location = new System.Drawing.Point(7, 7);
        this.tabControl_Main.Name = "tabControl_Main";
        this.tabControl_Main.SelectedIndex = 0;
        this.tabControl_Main.ShowToolTips = true;
        this.tabControl_Main.Size = new System.Drawing.Size(980, 680);
        this.tabControl_Main.TabIndex = 16;
        // 
        // tabPage_NetworkControl
        // 
        this.tabPage_NetworkControl.Controls.Add(this.groupBox_ActiveConnectionDetails_Statistic);
        this.tabPage_NetworkControl.Controls.Add(this.groupBox_Main_CommonStatistic);
        this.tabPage_NetworkControl.Controls.Add(this.groupBox_Main_MainNetworkControl);
        this.tabPage_NetworkControl.Controls.Add(this.groupBoxMain_ActiveInterConnections);
        this.tabPage_NetworkControl.Controls.Add(this.button_Main_WindowParameters);
        this.tabPage_NetworkControl.Controls.Add(this.checkBox_MainWindowParameters_ShowInNotifyArea);
        this.tabPage_NetworkControl.Location = new System.Drawing.Point(4, 22);
        this.tabPage_NetworkControl.Name = "tabPage_NetworkControl";
        this.tabPage_NetworkControl.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage_NetworkControl.Size = new System.Drawing.Size(972, 654);
        this.tabPage_NetworkControl.TabIndex = 0;
        this.tabPage_NetworkControl.Text = "Main";
        // 
        // groupBox_ActiveConnectionDetails_Statistic
        // 
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.textBox_ActiveConnectionDetails_ServerBytesReceived);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.textBox_ActiveConnectionDetails_ServerBytesSent);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.label_ActiveConnectionDetails_ServerBytesReceived);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.label_ActiveConnectionDetails_ServerBytesSent);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.textBox_ActiveConnectionDetails_ClientBytesReceived);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.textBox_ActiveConnectionDetails_ClientBytesSent);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.label_ActiveConnectionDetails_ClientBytesReceived);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.label_ActiveConnectionDetails_ClientBytesSent);
        this.groupBox_ActiveConnectionDetails_Statistic.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ActiveConnectionDetails_Statistic.Location = new System.Drawing.Point(6, 246);
        this.groupBox_ActiveConnectionDetails_Statistic.Name = "groupBox_ActiveConnectionDetails_Statistic";
        this.groupBox_ActiveConnectionDetails_Statistic.Size = new System.Drawing.Size(175, 195);
        this.groupBox_ActiveConnectionDetails_Statistic.TabIndex = 17;
        this.groupBox_ActiveConnectionDetails_Statistic.TabStop = false;
        this.groupBox_ActiveConnectionDetails_Statistic.Text = "Active Connection Details";
        // 
        // textBox_ActiveConnectionDetails_ServerBytesReceived
        // 
        this.textBox_ActiveConnectionDetails_ServerBytesReceived.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_ActiveConnectionDetails_ServerBytesReceived.Location = new System.Drawing.Point(8, 165);
        this.textBox_ActiveConnectionDetails_ServerBytesReceived.Name = "textBox_ActiveConnectionDetails_ServerBytesReceived";
        this.textBox_ActiveConnectionDetails_ServerBytesReceived.ReadOnly = true;
        this.textBox_ActiveConnectionDetails_ServerBytesReceived.Size = new System.Drawing.Size(158, 20);
        this.textBox_ActiveConnectionDetails_ServerBytesReceived.TabIndex = 23;
        // 
        // textBox_ActiveConnectionDetails_ServerBytesSent
        // 
        this.textBox_ActiveConnectionDetails_ServerBytesSent.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_ActiveConnectionDetails_ServerBytesSent.ForeColor = System.Drawing.SystemColors.WindowText;
        this.textBox_ActiveConnectionDetails_ServerBytesSent.Location = new System.Drawing.Point(8, 121);
        this.textBox_ActiveConnectionDetails_ServerBytesSent.Name = "textBox_ActiveConnectionDetails_ServerBytesSent";
        this.textBox_ActiveConnectionDetails_ServerBytesSent.ReadOnly = true;
        this.textBox_ActiveConnectionDetails_ServerBytesSent.Size = new System.Drawing.Size(158, 20);
        this.textBox_ActiveConnectionDetails_ServerBytesSent.TabIndex = 22;
        // 
        // label_ActiveConnectionDetails_ServerBytesReceived
        // 
        this.label_ActiveConnectionDetails_ServerBytesReceived.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ActiveConnectionDetails_ServerBytesReceived.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ActiveConnectionDetails_ServerBytesReceived.Location = new System.Drawing.Point(8, 150);
        this.label_ActiveConnectionDetails_ServerBytesReceived.Name = "label_ActiveConnectionDetails_ServerBytesReceived";
        this.label_ActiveConnectionDetails_ServerBytesReceived.Size = new System.Drawing.Size(158, 16);
        this.label_ActiveConnectionDetails_ServerBytesReceived.TabIndex = 21;
        this.label_ActiveConnectionDetails_ServerBytesReceived.Text = "Server Bytes Received:";
        // 
        // label_ActiveConnectionDetails_ServerBytesSent
        // 
        this.label_ActiveConnectionDetails_ServerBytesSent.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ActiveConnectionDetails_ServerBytesSent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ActiveConnectionDetails_ServerBytesSent.Location = new System.Drawing.Point(8, 106);
        this.label_ActiveConnectionDetails_ServerBytesSent.Name = "label_ActiveConnectionDetails_ServerBytesSent";
        this.label_ActiveConnectionDetails_ServerBytesSent.Size = new System.Drawing.Size(158, 16);
        this.label_ActiveConnectionDetails_ServerBytesSent.TabIndex = 20;
        this.label_ActiveConnectionDetails_ServerBytesSent.Text = "Server Bytes Sent:";
        // 
        // textBox_ActiveConnectionDetails_ClientBytesReceived
        // 
        this.textBox_ActiveConnectionDetails_ClientBytesReceived.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_ActiveConnectionDetails_ClientBytesReceived.Location = new System.Drawing.Point(8, 77);
        this.textBox_ActiveConnectionDetails_ClientBytesReceived.Name = "textBox_ActiveConnectionDetails_ClientBytesReceived";
        this.textBox_ActiveConnectionDetails_ClientBytesReceived.ReadOnly = true;
        this.textBox_ActiveConnectionDetails_ClientBytesReceived.Size = new System.Drawing.Size(158, 20);
        this.textBox_ActiveConnectionDetails_ClientBytesReceived.TabIndex = 19;
        // 
        // textBox_ActiveConnectionDetails_ClientBytesSent
        // 
        this.textBox_ActiveConnectionDetails_ClientBytesSent.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_ActiveConnectionDetails_ClientBytesSent.ForeColor = System.Drawing.SystemColors.WindowText;
        this.textBox_ActiveConnectionDetails_ClientBytesSent.Location = new System.Drawing.Point(8, 37);
        this.textBox_ActiveConnectionDetails_ClientBytesSent.Name = "textBox_ActiveConnectionDetails_ClientBytesSent";
        this.textBox_ActiveConnectionDetails_ClientBytesSent.ReadOnly = true;
        this.textBox_ActiveConnectionDetails_ClientBytesSent.Size = new System.Drawing.Size(158, 20);
        this.textBox_ActiveConnectionDetails_ClientBytesSent.TabIndex = 18;
        // 
        // label_ActiveConnectionDetails_ClientBytesReceived
        // 
        this.label_ActiveConnectionDetails_ClientBytesReceived.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ActiveConnectionDetails_ClientBytesReceived.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ActiveConnectionDetails_ClientBytesReceived.Location = new System.Drawing.Point(8, 62);
        this.label_ActiveConnectionDetails_ClientBytesReceived.Name = "label_ActiveConnectionDetails_ClientBytesReceived";
        this.label_ActiveConnectionDetails_ClientBytesReceived.Size = new System.Drawing.Size(158, 16);
        this.label_ActiveConnectionDetails_ClientBytesReceived.TabIndex = 15;
        this.label_ActiveConnectionDetails_ClientBytesReceived.Text = "Client Bytes Received:";
        // 
        // label_ActiveConnectionDetails_ClientBytesSent
        // 
        this.label_ActiveConnectionDetails_ClientBytesSent.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ActiveConnectionDetails_ClientBytesSent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ActiveConnectionDetails_ClientBytesSent.Location = new System.Drawing.Point(8, 20);
        this.label_ActiveConnectionDetails_ClientBytesSent.Name = "label_ActiveConnectionDetails_ClientBytesSent";
        this.label_ActiveConnectionDetails_ClientBytesSent.Size = new System.Drawing.Size(158, 18);
        this.label_ActiveConnectionDetails_ClientBytesSent.TabIndex = 14;
        this.label_ActiveConnectionDetails_ClientBytesSent.Text = "Client Bytes Sent:";
        // 
        // groupBox_Main_CommonStatistic
        // 
        this.groupBox_Main_CommonStatistic.Controls.Add(this.textBox_CommonStatistic_ActiveConnections);
        this.groupBox_Main_CommonStatistic.Controls.Add(this.label_CommonStatistic_Connections);
        this.groupBox_Main_CommonStatistic.Controls.Add(this.textBox_CommonStatistic_LastConnectionAt);
        this.groupBox_Main_CommonStatistic.Controls.Add(this.textBox_CommonStatistic_BytesReceived);
        this.groupBox_Main_CommonStatistic.Controls.Add(this.textBox_CommonStatistic_BytesSent);
        this.groupBox_Main_CommonStatistic.Controls.Add(this.label_CommonStatistic_LastConnectionAt);
        this.groupBox_Main_CommonStatistic.Controls.Add(this.label_CommonStatistic_BytesReceived);
        this.groupBox_Main_CommonStatistic.Controls.Add(this.label_CommonStatistic_BytesSent);
        this.groupBox_Main_CommonStatistic.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_Main_CommonStatistic.Location = new System.Drawing.Point(6, 451);
        this.groupBox_Main_CommonStatistic.Name = "groupBox_Main_CommonStatistic";
        this.groupBox_Main_CommonStatistic.Size = new System.Drawing.Size(175, 195);
        this.groupBox_Main_CommonStatistic.TabIndex = 16;
        this.groupBox_Main_CommonStatistic.TabStop = false;
        this.groupBox_Main_CommonStatistic.Text = "Common Statistic";
        // 
        // textBox_CommonStatistic_ActiveConnections
        // 
        this.textBox_CommonStatistic_ActiveConnections.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_CommonStatistic_ActiveConnections.Location = new System.Drawing.Point(8, 165);
        this.textBox_CommonStatistic_ActiveConnections.Name = "textBox_CommonStatistic_ActiveConnections";
        this.textBox_CommonStatistic_ActiveConnections.ReadOnly = true;
        this.textBox_CommonStatistic_ActiveConnections.Size = new System.Drawing.Size(158, 20);
        this.textBox_CommonStatistic_ActiveConnections.TabIndex = 23;
        // 
        // label_CommonStatistic_Connections
        // 
        this.label_CommonStatistic_Connections.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_CommonStatistic_Connections.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_CommonStatistic_Connections.Location = new System.Drawing.Point(8, 150);
        this.label_CommonStatistic_Connections.Name = "label_CommonStatistic_Connections";
        this.label_CommonStatistic_Connections.Size = new System.Drawing.Size(158, 18);
        this.label_CommonStatistic_Connections.TabIndex = 22;
        this.label_CommonStatistic_Connections.Text = "Connections:";
        // 
        // textBox_CommonStatistic_LastConnectionAt
        // 
        this.textBox_CommonStatistic_LastConnectionAt.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_CommonStatistic_LastConnectionAt.Location = new System.Drawing.Point(8, 121);
        this.textBox_CommonStatistic_LastConnectionAt.Name = "textBox_CommonStatistic_LastConnectionAt";
        this.textBox_CommonStatistic_LastConnectionAt.ReadOnly = true;
        this.textBox_CommonStatistic_LastConnectionAt.Size = new System.Drawing.Size(158, 20);
        this.textBox_CommonStatistic_LastConnectionAt.TabIndex = 21;
        // 
        // textBox_CommonStatistic_BytesReceived
        // 
        this.textBox_CommonStatistic_BytesReceived.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_CommonStatistic_BytesReceived.Location = new System.Drawing.Point(8, 77);
        this.textBox_CommonStatistic_BytesReceived.Name = "textBox_CommonStatistic_BytesReceived";
        this.textBox_CommonStatistic_BytesReceived.ReadOnly = true;
        this.textBox_CommonStatistic_BytesReceived.Size = new System.Drawing.Size(158, 20);
        this.textBox_CommonStatistic_BytesReceived.TabIndex = 19;
        // 
        // textBox_CommonStatistic_BytesSent
        // 
        this.textBox_CommonStatistic_BytesSent.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_CommonStatistic_BytesSent.ForeColor = System.Drawing.SystemColors.WindowText;
        this.textBox_CommonStatistic_BytesSent.Location = new System.Drawing.Point(8, 35);
        this.textBox_CommonStatistic_BytesSent.Name = "textBox_CommonStatistic_BytesSent";
        this.textBox_CommonStatistic_BytesSent.ReadOnly = true;
        this.textBox_CommonStatistic_BytesSent.Size = new System.Drawing.Size(158, 20);
        this.textBox_CommonStatistic_BytesSent.TabIndex = 18;
        // 
        // label_CommonStatistic_LastConnectionAt
        // 
        this.label_CommonStatistic_LastConnectionAt.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_CommonStatistic_LastConnectionAt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_CommonStatistic_LastConnectionAt.Location = new System.Drawing.Point(8, 106);
        this.label_CommonStatistic_LastConnectionAt.Name = "label_CommonStatistic_LastConnectionAt";
        this.label_CommonStatistic_LastConnectionAt.Size = new System.Drawing.Size(158, 18);
        this.label_CommonStatistic_LastConnectionAt.TabIndex = 17;
        this.label_CommonStatistic_LastConnectionAt.Text = "Last connection at:";
        // 
        // label_CommonStatistic_BytesReceived
        // 
        this.label_CommonStatistic_BytesReceived.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_CommonStatistic_BytesReceived.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_CommonStatistic_BytesReceived.Location = new System.Drawing.Point(8, 62);
        this.label_CommonStatistic_BytesReceived.Name = "label_CommonStatistic_BytesReceived";
        this.label_CommonStatistic_BytesReceived.Size = new System.Drawing.Size(158, 18);
        this.label_CommonStatistic_BytesReceived.TabIndex = 15;
        this.label_CommonStatistic_BytesReceived.Text = "Bytes Received:";
        // 
        // label_CommonStatistic_BytesSent
        // 
        this.label_CommonStatistic_BytesSent.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_CommonStatistic_BytesSent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_CommonStatistic_BytesSent.Location = new System.Drawing.Point(8, 20);
        this.label_CommonStatistic_BytesSent.Name = "label_CommonStatistic_BytesSent";
        this.label_CommonStatistic_BytesSent.Size = new System.Drawing.Size(158, 18);
        this.label_CommonStatistic_BytesSent.TabIndex = 14;
        this.label_CommonStatistic_BytesSent.Text = "Bytes Sent:";
        // 
        // tabPage_ConnectedObjects
        // 
        this.tabPage_ConnectedObjects.Controls.Add(this.groupBox_ConnectedUsers_ConnectedClients);
        this.tabPage_ConnectedObjects.Controls.Add(this.groupBox_ConnectedUsers_ConnectedServers);
        this.tabPage_ConnectedObjects.Location = new System.Drawing.Point(4, 22);
        this.tabPage_ConnectedObjects.Name = "tabPage_ConnectedObjects";
        this.tabPage_ConnectedObjects.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage_ConnectedObjects.Size = new System.Drawing.Size(972, 654);
        this.tabPage_ConnectedObjects.TabIndex = 1;
        this.tabPage_ConnectedObjects.Text = "Connected Users";
        // 
        // groupBox_ConnectedUsers_ConnectedClients
        // 
        this.groupBox_ConnectedUsers_ConnectedClients.Controls.Add(this.groupBox_ConnectedClients_Details);
        this.groupBox_ConnectedUsers_ConnectedClients.Controls.Add(this.button_ConnectedClients_DisconnectClient);
        this.groupBox_ConnectedUsers_ConnectedClients.Controls.Add(this.listView_ConnectedUsers_ConnectedClients);
        this.groupBox_ConnectedUsers_ConnectedClients.Controls.Add(this.button_ConnectedClients_DisconnectAll);
        this.groupBox_ConnectedUsers_ConnectedClients.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ConnectedUsers_ConnectedClients.Location = new System.Drawing.Point(6, 6);
        this.groupBox_ConnectedUsers_ConnectedClients.Name = "groupBox_ConnectedUsers_ConnectedClients";
        this.groupBox_ConnectedUsers_ConnectedClients.Size = new System.Drawing.Size(958, 315);
        this.groupBox_ConnectedUsers_ConnectedClients.TabIndex = 14;
        this.groupBox_ConnectedUsers_ConnectedClients.TabStop = false;
        this.groupBox_ConnectedUsers_ConnectedClients.Text = "Connected Clients";
        // 
        // groupBox_ConnectedClients_Details
        // 
        this.groupBox_ConnectedClients_Details.Controls.Add(this.textBox_ClientDetails_MACAddress);
        this.groupBox_ConnectedClients_Details.Controls.Add(this.textBox_ClientDetails_ConnectedAt);
        this.groupBox_ConnectedClients_Details.Controls.Add(this.textBox_ClientDetails_IPAddress);
        this.groupBox_ConnectedClients_Details.Controls.Add(this.textBox_ClientDetails_BytesReceived);
        this.groupBox_ConnectedClients_Details.Controls.Add(this.label_ClientDetails_IPAddress);
        this.groupBox_ConnectedClients_Details.Controls.Add(this.textBox_ClientDetails_BytesSent);
        this.groupBox_ConnectedClients_Details.Controls.Add(this.label_ClientDetails_MACAddress);
        this.groupBox_ConnectedClients_Details.Controls.Add(this.label_ClientDetails_CannectedAt);
        this.groupBox_ConnectedClients_Details.Controls.Add(this.label_ClientDetails_BytesReceived);
        this.groupBox_ConnectedClients_Details.Controls.Add(this.label_ClientDetails_BytesSent);
        this.groupBox_ConnectedClients_Details.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ConnectedClients_Details.Location = new System.Drawing.Point(799, 13);
        this.groupBox_ConnectedClients_Details.Name = "groupBox_ConnectedClients_Details";
        this.groupBox_ConnectedClients_Details.Size = new System.Drawing.Size(148, 220);
        this.groupBox_ConnectedClients_Details.TabIndex = 18;
        this.groupBox_ConnectedClients_Details.TabStop = false;
        this.groupBox_ConnectedClients_Details.Text = "Active Connection Details";
        // 
        // textBox_ClientDetails_MACAddress
        // 
        this.textBox_ClientDetails_MACAddress.Location = new System.Drawing.Point(7, 187);
        this.textBox_ClientDetails_MACAddress.Name = "textBox_ClientDetails_MACAddress";
        this.textBox_ClientDetails_MACAddress.ReadOnly = true;
        this.textBox_ClientDetails_MACAddress.Size = new System.Drawing.Size(132, 20);
        this.textBox_ClientDetails_MACAddress.TabIndex = 13;
        // 
        // textBox_ClientDetails_ConnectedAt
        // 
        this.textBox_ClientDetails_ConnectedAt.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_ClientDetails_ConnectedAt.Location = new System.Drawing.Point(7, 111);
        this.textBox_ClientDetails_ConnectedAt.Name = "textBox_ClientDetails_ConnectedAt";
        this.textBox_ClientDetails_ConnectedAt.ReadOnly = true;
        this.textBox_ClientDetails_ConnectedAt.Size = new System.Drawing.Size(132, 20);
        this.textBox_ClientDetails_ConnectedAt.TabIndex = 21;
        // 
        // textBox_ClientDetails_IPAddress
        // 
        this.textBox_ClientDetails_IPAddress.Location = new System.Drawing.Point(7, 149);
        this.textBox_ClientDetails_IPAddress.Name = "textBox_ClientDetails_IPAddress";
        this.textBox_ClientDetails_IPAddress.ReadOnly = true;
        this.textBox_ClientDetails_IPAddress.Size = new System.Drawing.Size(132, 20);
        this.textBox_ClientDetails_IPAddress.TabIndex = 12;
        // 
        // textBox_ClientDetails_BytesReceived
        // 
        this.textBox_ClientDetails_BytesReceived.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_ClientDetails_BytesReceived.Location = new System.Drawing.Point(7, 73);
        this.textBox_ClientDetails_BytesReceived.Name = "textBox_ClientDetails_BytesReceived";
        this.textBox_ClientDetails_BytesReceived.ReadOnly = true;
        this.textBox_ClientDetails_BytesReceived.Size = new System.Drawing.Size(132, 20);
        this.textBox_ClientDetails_BytesReceived.TabIndex = 19;
        // 
        // label_ClientDetails_IPAddress
        // 
        this.label_ClientDetails_IPAddress.AutoSize = true;
        this.label_ClientDetails_IPAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ClientDetails_IPAddress.Location = new System.Drawing.Point(7, 135);
        this.label_ClientDetails_IPAddress.Name = "label_ClientDetails_IPAddress";
        this.label_ClientDetails_IPAddress.Size = new System.Drawing.Size(61, 13);
        this.label_ClientDetails_IPAddress.TabIndex = 10;
        this.label_ClientDetails_IPAddress.Text = "IP Address:";
        // 
        // textBox_ClientDetails_BytesSent
        // 
        this.textBox_ClientDetails_BytesSent.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_ClientDetails_BytesSent.ForeColor = System.Drawing.SystemColors.WindowText;
        this.textBox_ClientDetails_BytesSent.Location = new System.Drawing.Point(7, 35);
        this.textBox_ClientDetails_BytesSent.Name = "textBox_ClientDetails_BytesSent";
        this.textBox_ClientDetails_BytesSent.ReadOnly = true;
        this.textBox_ClientDetails_BytesSent.Size = new System.Drawing.Size(132, 20);
        this.textBox_ClientDetails_BytesSent.TabIndex = 18;
        // 
        // label_ClientDetails_MACAddress
        // 
        this.label_ClientDetails_MACAddress.AutoSize = true;
        this.label_ClientDetails_MACAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ClientDetails_MACAddress.Location = new System.Drawing.Point(7, 173);
        this.label_ClientDetails_MACAddress.Name = "label_ClientDetails_MACAddress";
        this.label_ClientDetails_MACAddress.Size = new System.Drawing.Size(74, 13);
        this.label_ClientDetails_MACAddress.TabIndex = 11;
        this.label_ClientDetails_MACAddress.Text = "MAC Address:";
        // 
        // label_ClientDetails_CannectedAt
        // 
        this.label_ClientDetails_CannectedAt.AutoSize = true;
        this.label_ClientDetails_CannectedAt.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ClientDetails_CannectedAt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ClientDetails_CannectedAt.Location = new System.Drawing.Point(7, 97);
        this.label_ClientDetails_CannectedAt.Name = "label_ClientDetails_CannectedAt";
        this.label_ClientDetails_CannectedAt.Size = new System.Drawing.Size(74, 13);
        this.label_ClientDetails_CannectedAt.TabIndex = 17;
        this.label_ClientDetails_CannectedAt.Text = "Connected at:";
        // 
        // label_ClientDetails_BytesReceived
        // 
        this.label_ClientDetails_BytesReceived.AutoSize = true;
        this.label_ClientDetails_BytesReceived.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ClientDetails_BytesReceived.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ClientDetails_BytesReceived.Location = new System.Drawing.Point(7, 59);
        this.label_ClientDetails_BytesReceived.Name = "label_ClientDetails_BytesReceived";
        this.label_ClientDetails_BytesReceived.Size = new System.Drawing.Size(85, 13);
        this.label_ClientDetails_BytesReceived.TabIndex = 15;
        this.label_ClientDetails_BytesReceived.Text = "Bytes Received:";
        // 
        // label_ClientDetails_BytesSent
        // 
        this.label_ClientDetails_BytesSent.AutoSize = true;
        this.label_ClientDetails_BytesSent.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ClientDetails_BytesSent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ClientDetails_BytesSent.Location = new System.Drawing.Point(7, 21);
        this.label_ClientDetails_BytesSent.Name = "label_ClientDetails_BytesSent";
        this.label_ClientDetails_BytesSent.Size = new System.Drawing.Size(61, 13);
        this.label_ClientDetails_BytesSent.TabIndex = 14;
        this.label_ClientDetails_BytesSent.Text = "Bytes Sent:";
        // 
        // button_ConnectedClients_DisconnectClient
        // 
        this.button_ConnectedClients_DisconnectClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ConnectedClients_DisconnectClient.Location = new System.Drawing.Point(799, 245);
        this.button_ConnectedClients_DisconnectClient.Name = "button_ConnectedClients_DisconnectClient";
        this.button_ConnectedClients_DisconnectClient.Size = new System.Drawing.Size(148, 23);
        this.button_ConnectedClients_DisconnectClient.TabIndex = 1;
        this.button_ConnectedClients_DisconnectClient.Text = "Disconnect";
        this.button_ConnectedClients_DisconnectClient.Click += new System.EventHandler(this.button_ConnectedClients_DisconnectClient_Click);
        // 
        // listView_ConnectedUsers_ConnectedClients
        // 
        this.listView_ConnectedUsers_ConnectedClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ConnectedClients_ClientUIN,
            this.columnHeader_ConnectedClients_UserName,
            this.columnHeader_ConnectedClients_ClientIP,
            this.columnHeader_ConnectedClients_ConnectedAt,
            this.columnHeader_ConnectedClients_Status});
        this.listView_ConnectedUsers_ConnectedClients.FullRowSelect = true;
        this.listView_ConnectedUsers_ConnectedClients.GridLines = true;
        this.listView_ConnectedUsers_ConnectedClients.HideSelection = false;
        this.listView_ConnectedUsers_ConnectedClients.Location = new System.Drawing.Point(6, 19);
        this.listView_ConnectedUsers_ConnectedClients.Name = "listView_ConnectedUsers_ConnectedClients";
        this.listView_ConnectedUsers_ConnectedClients.Size = new System.Drawing.Size(787, 286);
        this.listView_ConnectedUsers_ConnectedClients.TabIndex = 0;
        this.listView_ConnectedUsers_ConnectedClients.UseCompatibleStateImageBehavior = false;
        this.listView_ConnectedUsers_ConnectedClients.View = System.Windows.Forms.View.Details;
        this.listView_ConnectedUsers_ConnectedClients.SelectedIndexChanged += new System.EventHandler(this.listView_ConnectedUsers_ConnectedClients_SelectedIndexChanged);
        // 
        // columnHeader_ConnectedClients_ClientUIN
        // 
        this.columnHeader_ConnectedClients_ClientUIN.Text = "Client UIN";
        this.columnHeader_ConnectedClients_ClientUIN.Width = 100;
        // 
        // columnHeader_ConnectedClients_UserName
        // 
        this.columnHeader_ConnectedClients_UserName.Text = "User Name";
        this.columnHeader_ConnectedClients_UserName.Width = 100;
        // 
        // columnHeader_ConnectedClients_ClientIP
        // 
        this.columnHeader_ConnectedClients_ClientIP.Text = "Client IP";
        this.columnHeader_ConnectedClients_ClientIP.Width = 100;
        // 
        // columnHeader_ConnectedClients_ConnectedAt
        // 
        this.columnHeader_ConnectedClients_ConnectedAt.Text = "Connected At";
        this.columnHeader_ConnectedClients_ConnectedAt.Width = 140;
        // 
        // columnHeader_ConnectedClients_Status
        // 
        this.columnHeader_ConnectedClients_Status.Text = "Status";
        this.columnHeader_ConnectedClients_Status.Width = 325;
        // 
        // button_ConnectedClients_DisconnectAll
        // 
        this.button_ConnectedClients_DisconnectAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ConnectedClients_DisconnectAll.Location = new System.Drawing.Point(799, 280);
        this.button_ConnectedClients_DisconnectAll.Name = "button_ConnectedClients_DisconnectAll";
        this.button_ConnectedClients_DisconnectAll.Size = new System.Drawing.Size(148, 23);
        this.button_ConnectedClients_DisconnectAll.TabIndex = 2;
        this.button_ConnectedClients_DisconnectAll.Text = "Disconnect All";
        this.button_ConnectedClients_DisconnectAll.Click += new System.EventHandler(this.button_ConnectedClients_DisconnectAll_Click);
        // 
        // groupBox_ConnectedUsers_ConnectedServers
        // 
        this.groupBox_ConnectedUsers_ConnectedServers.Controls.Add(this.listView_ConnectedUsers_ConnectedServers);
        this.groupBox_ConnectedUsers_ConnectedServers.Controls.Add(this.button_ConnectedServers_DisconnectAll);
        this.groupBox_ConnectedUsers_ConnectedServers.Controls.Add(this.button_ConnectedServers_DisconnectServer);
        this.groupBox_ConnectedUsers_ConnectedServers.Controls.Add(this.groupBox_ConnectedServers_Details);
        this.groupBox_ConnectedUsers_ConnectedServers.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ConnectedUsers_ConnectedServers.Location = new System.Drawing.Point(6, 327);
        this.groupBox_ConnectedUsers_ConnectedServers.Name = "groupBox_ConnectedUsers_ConnectedServers";
        this.groupBox_ConnectedUsers_ConnectedServers.Size = new System.Drawing.Size(958, 315);
        this.groupBox_ConnectedUsers_ConnectedServers.TabIndex = 13;
        this.groupBox_ConnectedUsers_ConnectedServers.TabStop = false;
        this.groupBox_ConnectedUsers_ConnectedServers.Text = "Connected Servers";
        // 
        // listView_ConnectedUsers_ConnectedServers
        // 
        this.listView_ConnectedUsers_ConnectedServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ConnectedServers_ServerUIN,
            this.columnHeader_ConnectedServers_UserName,
            this.columnHeader_ConnectedServers_ServerIP,
            this.columnHeader_ConnectedServers_ConnectedAt,
            this.columnHeader_ConnectedServers_Status});
        this.listView_ConnectedUsers_ConnectedServers.FullRowSelect = true;
        this.listView_ConnectedUsers_ConnectedServers.GridLines = true;
        this.listView_ConnectedUsers_ConnectedServers.HideSelection = false;
        this.listView_ConnectedUsers_ConnectedServers.Location = new System.Drawing.Point(6, 25);
        this.listView_ConnectedUsers_ConnectedServers.Name = "listView_ConnectedUsers_ConnectedServers";
        this.listView_ConnectedUsers_ConnectedServers.Size = new System.Drawing.Size(787, 284);
        this.listView_ConnectedUsers_ConnectedServers.TabIndex = 4;
        this.listView_ConnectedUsers_ConnectedServers.UseCompatibleStateImageBehavior = false;
        this.listView_ConnectedUsers_ConnectedServers.View = System.Windows.Forms.View.Details;
        this.listView_ConnectedUsers_ConnectedServers.SelectedIndexChanged += new System.EventHandler(this.listView_ConnectedUsers_ConnectedServers_SelectedIndexChanged);
        // 
        // columnHeader_ConnectedServers_ServerUIN
        // 
        this.columnHeader_ConnectedServers_ServerUIN.Text = "Server UIN";
        this.columnHeader_ConnectedServers_ServerUIN.Width = 100;
        // 
        // columnHeader_ConnectedServers_UserName
        // 
        this.columnHeader_ConnectedServers_UserName.Text = "User Name";
        this.columnHeader_ConnectedServers_UserName.Width = 100;
        // 
        // columnHeader_ConnectedServers_ServerIP
        // 
        this.columnHeader_ConnectedServers_ServerIP.Text = "Server IP";
        this.columnHeader_ConnectedServers_ServerIP.Width = 100;
        // 
        // columnHeader_ConnectedServers_ConnectedAt
        // 
        this.columnHeader_ConnectedServers_ConnectedAt.Text = "Connected At";
        this.columnHeader_ConnectedServers_ConnectedAt.Width = 140;
        // 
        // columnHeader_ConnectedServers_Status
        // 
        this.columnHeader_ConnectedServers_Status.Text = "Status";
        this.columnHeader_ConnectedServers_Status.Width = 325;
        // 
        // button_ConnectedServers_DisconnectAll
        // 
        this.button_ConnectedServers_DisconnectAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ConnectedServers_DisconnectAll.Location = new System.Drawing.Point(799, 280);
        this.button_ConnectedServers_DisconnectAll.Name = "button_ConnectedServers_DisconnectAll";
        this.button_ConnectedServers_DisconnectAll.Size = new System.Drawing.Size(148, 23);
        this.button_ConnectedServers_DisconnectAll.TabIndex = 2;
        this.button_ConnectedServers_DisconnectAll.Text = "Disconnect All";
        this.button_ConnectedServers_DisconnectAll.Click += new System.EventHandler(this.button_ConnectedServers_DisconnectAll_Click);
        // 
        // button_ConnectedServers_DisconnectServer
        // 
        this.button_ConnectedServers_DisconnectServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ConnectedServers_DisconnectServer.Location = new System.Drawing.Point(799, 246);
        this.button_ConnectedServers_DisconnectServer.Name = "button_ConnectedServers_DisconnectServer";
        this.button_ConnectedServers_DisconnectServer.Size = new System.Drawing.Size(148, 23);
        this.button_ConnectedServers_DisconnectServer.TabIndex = 1;
        this.button_ConnectedServers_DisconnectServer.Text = "Disconnect";
        this.button_ConnectedServers_DisconnectServer.Click += new System.EventHandler(this.button_ConnectedServers_DisconnectServer_Click);
        // 
        // groupBox_ConnectedServers_Details
        // 
        this.groupBox_ConnectedServers_Details.Controls.Add(this.textBox_ServerDetails_ConnectedAt);
        this.groupBox_ConnectedServers_Details.Controls.Add(this.label_ServerDetails_MACAddress);
        this.groupBox_ConnectedServers_Details.Controls.Add(this.textBox_ServerDetails_IPAddress);
        this.groupBox_ConnectedServers_Details.Controls.Add(this.label_ServerDetails_CannectedAt);
        this.groupBox_ConnectedServers_Details.Controls.Add(this.textBox_ServerDetails_MACAddress);
        this.groupBox_ConnectedServers_Details.Controls.Add(this.textBox_ServerDetails_BytesReceived);
        this.groupBox_ConnectedServers_Details.Controls.Add(this.label_ServerDetails_IPAddress);
        this.groupBox_ConnectedServers_Details.Controls.Add(this.label_ServerDetails_BytesReceived);
        this.groupBox_ConnectedServers_Details.Controls.Add(this.textBox_ServerDetails_BytesSent);
        this.groupBox_ConnectedServers_Details.Controls.Add(this.label_ServerDetails_BytesSent);
        this.groupBox_ConnectedServers_Details.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ConnectedServers_Details.Location = new System.Drawing.Point(799, 13);
        this.groupBox_ConnectedServers_Details.Name = "groupBox_ConnectedServers_Details";
        this.groupBox_ConnectedServers_Details.Size = new System.Drawing.Size(148, 220);
        this.groupBox_ConnectedServers_Details.TabIndex = 19;
        this.groupBox_ConnectedServers_Details.TabStop = false;
        this.groupBox_ConnectedServers_Details.Text = "Active Connection Details";
        // 
        // textBox_ServerDetails_ConnectedAt
        // 
        this.textBox_ServerDetails_ConnectedAt.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_ServerDetails_ConnectedAt.Location = new System.Drawing.Point(7, 111);
        this.textBox_ServerDetails_ConnectedAt.Name = "textBox_ServerDetails_ConnectedAt";
        this.textBox_ServerDetails_ConnectedAt.ReadOnly = true;
        this.textBox_ServerDetails_ConnectedAt.Size = new System.Drawing.Size(132, 20);
        this.textBox_ServerDetails_ConnectedAt.TabIndex = 21;
        // 
        // label_ServerDetails_MACAddress
        // 
        this.label_ServerDetails_MACAddress.AutoSize = true;
        this.label_ServerDetails_MACAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServerDetails_MACAddress.Location = new System.Drawing.Point(7, 173);
        this.label_ServerDetails_MACAddress.Name = "label_ServerDetails_MACAddress";
        this.label_ServerDetails_MACAddress.Size = new System.Drawing.Size(74, 13);
        this.label_ServerDetails_MACAddress.TabIndex = 11;
        this.label_ServerDetails_MACAddress.Text = "MAC Address:";
        // 
        // textBox_ServerDetails_IPAddress
        // 
        this.textBox_ServerDetails_IPAddress.Location = new System.Drawing.Point(7, 149);
        this.textBox_ServerDetails_IPAddress.Name = "textBox_ServerDetails_IPAddress";
        this.textBox_ServerDetails_IPAddress.ReadOnly = true;
        this.textBox_ServerDetails_IPAddress.Size = new System.Drawing.Size(133, 20);
        this.textBox_ServerDetails_IPAddress.TabIndex = 12;
        // 
        // label_ServerDetails_CannectedAt
        // 
        this.label_ServerDetails_CannectedAt.AutoSize = true;
        this.label_ServerDetails_CannectedAt.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServerDetails_CannectedAt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ServerDetails_CannectedAt.Location = new System.Drawing.Point(7, 97);
        this.label_ServerDetails_CannectedAt.Name = "label_ServerDetails_CannectedAt";
        this.label_ServerDetails_CannectedAt.Size = new System.Drawing.Size(74, 13);
        this.label_ServerDetails_CannectedAt.TabIndex = 17;
        this.label_ServerDetails_CannectedAt.Text = "Connected at:";
        // 
        // textBox_ServerDetails_MACAddress
        // 
        this.textBox_ServerDetails_MACAddress.Location = new System.Drawing.Point(7, 187);
        this.textBox_ServerDetails_MACAddress.Name = "textBox_ServerDetails_MACAddress";
        this.textBox_ServerDetails_MACAddress.ReadOnly = true;
        this.textBox_ServerDetails_MACAddress.Size = new System.Drawing.Size(133, 20);
        this.textBox_ServerDetails_MACAddress.TabIndex = 13;
        // 
        // textBox_ServerDetails_BytesReceived
        // 
        this.textBox_ServerDetails_BytesReceived.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_ServerDetails_BytesReceived.Location = new System.Drawing.Point(7, 70);
        this.textBox_ServerDetails_BytesReceived.Name = "textBox_ServerDetails_BytesReceived";
        this.textBox_ServerDetails_BytesReceived.ReadOnly = true;
        this.textBox_ServerDetails_BytesReceived.Size = new System.Drawing.Size(132, 20);
        this.textBox_ServerDetails_BytesReceived.TabIndex = 19;
        // 
        // label_ServerDetails_IPAddress
        // 
        this.label_ServerDetails_IPAddress.AutoSize = true;
        this.label_ServerDetails_IPAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServerDetails_IPAddress.Location = new System.Drawing.Point(7, 135);
        this.label_ServerDetails_IPAddress.Name = "label_ServerDetails_IPAddress";
        this.label_ServerDetails_IPAddress.Size = new System.Drawing.Size(61, 13);
        this.label_ServerDetails_IPAddress.TabIndex = 10;
        this.label_ServerDetails_IPAddress.Text = "IP Address:";
        // 
        // label_ServerDetails_BytesReceived
        // 
        this.label_ServerDetails_BytesReceived.AutoSize = true;
        this.label_ServerDetails_BytesReceived.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServerDetails_BytesReceived.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ServerDetails_BytesReceived.Location = new System.Drawing.Point(7, 56);
        this.label_ServerDetails_BytesReceived.Name = "label_ServerDetails_BytesReceived";
        this.label_ServerDetails_BytesReceived.Size = new System.Drawing.Size(85, 13);
        this.label_ServerDetails_BytesReceived.TabIndex = 15;
        this.label_ServerDetails_BytesReceived.Text = "Bytes Received:";
        // 
        // textBox_ServerDetails_BytesSent
        // 
        this.textBox_ServerDetails_BytesSent.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_ServerDetails_BytesSent.ForeColor = System.Drawing.SystemColors.WindowText;
        this.textBox_ServerDetails_BytesSent.Location = new System.Drawing.Point(7, 32);
        this.textBox_ServerDetails_BytesSent.Name = "textBox_ServerDetails_BytesSent";
        this.textBox_ServerDetails_BytesSent.ReadOnly = true;
        this.textBox_ServerDetails_BytesSent.Size = new System.Drawing.Size(132, 20);
        this.textBox_ServerDetails_BytesSent.TabIndex = 18;
        // 
        // label_ServerDetails_BytesSent
        // 
        this.label_ServerDetails_BytesSent.AutoSize = true;
        this.label_ServerDetails_BytesSent.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServerDetails_BytesSent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ServerDetails_BytesSent.Location = new System.Drawing.Point(7, 18);
        this.label_ServerDetails_BytesSent.Name = "label_ServerDetails_BytesSent";
        this.label_ServerDetails_BytesSent.Size = new System.Drawing.Size(61, 13);
        this.label_ServerDetails_BytesSent.TabIndex = 14;
        this.label_ServerDetails_BytesSent.Text = "Bytes Sent:";
        // 
        // tabPage_ClientsAccounts
        // 
        this.tabPage_ClientsAccounts.Controls.Add(this.groupBox_ClientsAccounts_RestrictionRules);
        this.tabPage_ClientsAccounts.Controls.Add(this.groupBox_ClientsAccounts_Accounts);
        this.tabPage_ClientsAccounts.Location = new System.Drawing.Point(4, 22);
        this.tabPage_ClientsAccounts.Name = "tabPage_ClientsAccounts";
        this.tabPage_ClientsAccounts.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage_ClientsAccounts.Size = new System.Drawing.Size(972, 654);
        this.tabPage_ClientsAccounts.TabIndex = 2;
        this.tabPage_ClientsAccounts.Text = "Clients Accounts";
        // 
        // groupBox_ClientsAccounts_RestrictionRules
        // 
        this.groupBox_ClientsAccounts_RestrictionRules.Controls.Add(this.listView_ClientsRestrictionRules_RulestList);
        this.groupBox_ClientsAccounts_RestrictionRules.Controls.Add(this.button_ClientsRestrictionRules_ViewRule);
        this.groupBox_ClientsAccounts_RestrictionRules.Controls.Add(this.button_ClientsRestrictionRules_EnableRule);
        this.groupBox_ClientsAccounts_RestrictionRules.Controls.Add(this.button51);
        this.groupBox_ClientsAccounts_RestrictionRules.Controls.Add(this.button_ClientsRestrictionRules_DisableRule);
        this.groupBox_ClientsAccounts_RestrictionRules.Controls.Add(this.label_ClientsRestrictionRules_RestrictionRules);
        this.groupBox_ClientsAccounts_RestrictionRules.Controls.Add(this.button_ClientsRestrictionRules_EditRule);
        this.groupBox_ClientsAccounts_RestrictionRules.Controls.Add(this.button_ClientsRestrictionRules_ClearRulesList);
        this.groupBox_ClientsAccounts_RestrictionRules.Controls.Add(this.button_ClientsRestrictionRules_AddRule);
        this.groupBox_ClientsAccounts_RestrictionRules.Controls.Add(this.checkBox_ClientsRestrictionRules_UseRestrictionRules);
        this.groupBox_ClientsAccounts_RestrictionRules.Controls.Add(this.button_ClientsRestrictionRules_RemoveRule);
        this.groupBox_ClientsAccounts_RestrictionRules.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ClientsAccounts_RestrictionRules.Location = new System.Drawing.Point(6, 362);
        this.groupBox_ClientsAccounts_RestrictionRules.Name = "groupBox_ClientsAccounts_RestrictionRules";
        this.groupBox_ClientsAccounts_RestrictionRules.Size = new System.Drawing.Size(958, 286);
        this.groupBox_ClientsAccounts_RestrictionRules.TabIndex = 42;
        this.groupBox_ClientsAccounts_RestrictionRules.TabStop = false;
        this.groupBox_ClientsAccounts_RestrictionRules.Text = "Restriction Rules";
        // 
        // listView_ClientsRestrictionRules_RulestList
        // 
        this.listView_ClientsRestrictionRules_RulestList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ClientsRestrictionRules_IPRange,
            this.columnHeader_ClientsRestrictionRules_IPAddress,
            this.columnHeader_ClientsRestrictionRules_MACAddress,
            this.columnHeader_ClientsRestrictionRules_RuleType,
            this.columnHeader_ClientsRestrictionRules_CreationTime,
            this.columnHeader_ClientsRestrictionRules_RuleStatus});
        this.listView_ClientsRestrictionRules_RulestList.FullRowSelect = true;
        this.listView_ClientsRestrictionRules_RulestList.GridLines = true;
        this.listView_ClientsRestrictionRules_RulestList.HideSelection = false;
        this.listView_ClientsRestrictionRules_RulestList.Location = new System.Drawing.Point(6, 38);
        this.listView_ClientsRestrictionRules_RulestList.Name = "listView_ClientsRestrictionRules_RulestList";
        this.listView_ClientsRestrictionRules_RulestList.Size = new System.Drawing.Size(944, 200);
        this.listView_ClientsRestrictionRules_RulestList.TabIndex = 30;
        this.listView_ClientsRestrictionRules_RulestList.UseCompatibleStateImageBehavior = false;
        this.listView_ClientsRestrictionRules_RulestList.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader_ClientsRestrictionRules_IPRange
        // 
        this.columnHeader_ClientsRestrictionRules_IPRange.Text = "IP Range";
        this.columnHeader_ClientsRestrictionRules_IPRange.Width = 200;
        // 
        // columnHeader_ClientsRestrictionRules_IPAddress
        // 
        this.columnHeader_ClientsRestrictionRules_IPAddress.Text = "IP Address";
        this.columnHeader_ClientsRestrictionRules_IPAddress.Width = 150;
        // 
        // columnHeader_ClientsRestrictionRules_MACAddress
        // 
        this.columnHeader_ClientsRestrictionRules_MACAddress.Text = "MAC Address";
        this.columnHeader_ClientsRestrictionRules_MACAddress.Width = 150;
        // 
        // columnHeader_ClientsRestrictionRules_RuleType
        // 
        this.columnHeader_ClientsRestrictionRules_RuleType.Text = "Rule Type";
        this.columnHeader_ClientsRestrictionRules_RuleType.Width = 150;
        // 
        // columnHeader_ClientsRestrictionRules_CreationTime
        // 
        this.columnHeader_ClientsRestrictionRules_CreationTime.Text = "Creation Time";
        this.columnHeader_ClientsRestrictionRules_CreationTime.Width = 120;
        // 
        // columnHeader_ClientsRestrictionRules_RuleStatus
        // 
        this.columnHeader_ClientsRestrictionRules_RuleStatus.Text = "Status";
        this.columnHeader_ClientsRestrictionRules_RuleStatus.Width = 150;
        // 
        // button_ClientsRestrictionRules_ViewRule
        // 
        this.button_ClientsRestrictionRules_ViewRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsRestrictionRules_ViewRule.Location = new System.Drawing.Point(244, 251);
        this.button_ClientsRestrictionRules_ViewRule.Name = "button_ClientsRestrictionRules_ViewRule";
        this.button_ClientsRestrictionRules_ViewRule.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsRestrictionRules_ViewRule.TabIndex = 37;
        this.button_ClientsRestrictionRules_ViewRule.Text = "Vew";
        this.button_ClientsRestrictionRules_ViewRule.Click += new System.EventHandler(this.button_ClientsRestrictionRules_ViewRule_Click);
        // 
        // button_ClientsRestrictionRules_EnableRule
        // 
        this.button_ClientsRestrictionRules_EnableRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsRestrictionRules_EnableRule.Location = new System.Drawing.Point(482, 251);
        this.button_ClientsRestrictionRules_EnableRule.Name = "button_ClientsRestrictionRules_EnableRule";
        this.button_ClientsRestrictionRules_EnableRule.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsRestrictionRules_EnableRule.TabIndex = 39;
        this.button_ClientsRestrictionRules_EnableRule.Text = "Enable";
        this.button_ClientsRestrictionRules_EnableRule.Click += new System.EventHandler(this.button_ClientsRestrictionRules_EnableRule_Click);
        // 
        // button51
        // 
        this.button51.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button51.Location = new System.Drawing.Point(16, 699);
        this.button51.Name = "button51";
        this.button51.Size = new System.Drawing.Size(104, 23);
        this.button51.TabIndex = 1;
        this.button51.Text = "Disconnect";
        // 
        // button_ClientsRestrictionRules_DisableRule
        // 
        this.button_ClientsRestrictionRules_DisableRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsRestrictionRules_DisableRule.Location = new System.Drawing.Point(363, 251);
        this.button_ClientsRestrictionRules_DisableRule.Name = "button_ClientsRestrictionRules_DisableRule";
        this.button_ClientsRestrictionRules_DisableRule.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsRestrictionRules_DisableRule.TabIndex = 38;
        this.button_ClientsRestrictionRules_DisableRule.Text = "Disable";
        this.button_ClientsRestrictionRules_DisableRule.Click += new System.EventHandler(this.button_ClientsRestrictionRules_DisableRule_Click);
        // 
        // label_ClientsRestrictionRules_RestrictionRules
        // 
        this.label_ClientsRestrictionRules_RestrictionRules.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ClientsRestrictionRules_RestrictionRules.Location = new System.Drawing.Point(6, 23);
        this.label_ClientsRestrictionRules_RestrictionRules.Name = "label_ClientsRestrictionRules_RestrictionRules";
        this.label_ClientsRestrictionRules_RestrictionRules.Size = new System.Drawing.Size(352, 16);
        this.label_ClientsRestrictionRules_RestrictionRules.TabIndex = 31;
        this.label_ClientsRestrictionRules_RestrictionRules.Text = "List of access restrictions rules:";
        // 
        // button_ClientsRestrictionRules_EditRule
        // 
        this.button_ClientsRestrictionRules_EditRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsRestrictionRules_EditRule.Location = new System.Drawing.Point(125, 251);
        this.button_ClientsRestrictionRules_EditRule.Name = "button_ClientsRestrictionRules_EditRule";
        this.button_ClientsRestrictionRules_EditRule.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsRestrictionRules_EditRule.TabIndex = 36;
        this.button_ClientsRestrictionRules_EditRule.Text = "Edit";
        this.button_ClientsRestrictionRules_EditRule.Click += new System.EventHandler(this.button_ClientsRestrictionRules_EditRule_Click);
        // 
        // button_ClientsRestrictionRules_ClearRulesList
        // 
        this.button_ClientsRestrictionRules_ClearRulesList.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsRestrictionRules_ClearRulesList.Location = new System.Drawing.Point(720, 251);
        this.button_ClientsRestrictionRules_ClearRulesList.Name = "button_ClientsRestrictionRules_ClearRulesList";
        this.button_ClientsRestrictionRules_ClearRulesList.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsRestrictionRules_ClearRulesList.TabIndex = 35;
        this.button_ClientsRestrictionRules_ClearRulesList.Text = "Clear";
        this.button_ClientsRestrictionRules_ClearRulesList.Click += new System.EventHandler(this.button_ClientsRestrictionRules_ClearRulesList_Click);
        // 
        // button_ClientsRestrictionRules_AddRule
        // 
        this.button_ClientsRestrictionRules_AddRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsRestrictionRules_AddRule.Location = new System.Drawing.Point(6, 251);
        this.button_ClientsRestrictionRules_AddRule.Name = "button_ClientsRestrictionRules_AddRule";
        this.button_ClientsRestrictionRules_AddRule.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsRestrictionRules_AddRule.TabIndex = 32;
        this.button_ClientsRestrictionRules_AddRule.Text = "Add";
        this.button_ClientsRestrictionRules_AddRule.Click += new System.EventHandler(this.button_ClientsRestrictionRules_AddRule_Click);
        // 
        // checkBox_ClientsRestrictionRules_UseRestrictionRules
        // 
        this.checkBox_ClientsRestrictionRules_UseRestrictionRules.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_ClientsRestrictionRules_UseRestrictionRules.Location = new System.Drawing.Point(782, 16);
        this.checkBox_ClientsRestrictionRules_UseRestrictionRules.Name = "checkBox_ClientsRestrictionRules_UseRestrictionRules";
        this.checkBox_ClientsRestrictionRules_UseRestrictionRules.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.checkBox_ClientsRestrictionRules_UseRestrictionRules.Size = new System.Drawing.Size(168, 16);
        this.checkBox_ClientsRestrictionRules_UseRestrictionRules.TabIndex = 34;
        this.checkBox_ClientsRestrictionRules_UseRestrictionRules.Text = "Use Restrictions";
        this.checkBox_ClientsRestrictionRules_UseRestrictionRules.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        this.checkBox_ClientsRestrictionRules_UseRestrictionRules.CheckedChanged += new System.EventHandler(this.checkBox_ClientsRestrictionRules_UseRestrictionRules_CheckedChanged);
        // 
        // button_ClientsRestrictionRules_RemoveRule
        // 
        this.button_ClientsRestrictionRules_RemoveRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsRestrictionRules_RemoveRule.Location = new System.Drawing.Point(601, 251);
        this.button_ClientsRestrictionRules_RemoveRule.Name = "button_ClientsRestrictionRules_RemoveRule";
        this.button_ClientsRestrictionRules_RemoveRule.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsRestrictionRules_RemoveRule.TabIndex = 33;
        this.button_ClientsRestrictionRules_RemoveRule.Text = "Remove";
        this.button_ClientsRestrictionRules_RemoveRule.Click += new System.EventHandler(this.button_ClientsRestrictionRules_RemoveRule_Click);
        // 
        // groupBox_ClientsAccounts_Accounts
        // 
        this.groupBox_ClientsAccounts_Accounts.Controls.Add(this.button_ClientsAccounts_ActivateAccount);
        this.groupBox_ClientsAccounts_Accounts.Controls.Add(this.button_ClientsAccounts_ClearAccountsList);
        this.groupBox_ClientsAccounts_Accounts.Controls.Add(this.button_ClientsAccounts_RemoveAccount);
        this.groupBox_ClientsAccounts_Accounts.Controls.Add(this.button_ClientsAccounts_AddAccount);
        this.groupBox_ClientsAccounts_Accounts.Controls.Add(this.listView_ClientsAccounts_ClientsAccounts);
        this.groupBox_ClientsAccounts_Accounts.Controls.Add(this.button_ClientsAccounts_DisableAccount);
        this.groupBox_ClientsAccounts_Accounts.Controls.Add(this.button_ClientsAccounts_EnableAccount);
        this.groupBox_ClientsAccounts_Accounts.Controls.Add(this.button_ClientsAccounts_EditAccount);
        this.groupBox_ClientsAccounts_Accounts.Controls.Add(this.button_ClientsAccounts_ViewAccount);
        this.groupBox_ClientsAccounts_Accounts.Controls.Add(this.label2);
        this.groupBox_ClientsAccounts_Accounts.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ClientsAccounts_Accounts.Location = new System.Drawing.Point(6, 6);
        this.groupBox_ClientsAccounts_Accounts.Name = "groupBox_ClientsAccounts_Accounts";
        this.groupBox_ClientsAccounts_Accounts.Size = new System.Drawing.Size(958, 350);
        this.groupBox_ClientsAccounts_Accounts.TabIndex = 32;
        this.groupBox_ClientsAccounts_Accounts.TabStop = false;
        this.groupBox_ClientsAccounts_Accounts.Text = "Clients Accounts";
        // 
        // button_ClientsAccounts_ActivateAccount
        // 
        this.button_ClientsAccounts_ActivateAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsAccounts_ActivateAccount.Location = new System.Drawing.Point(840, 315);
        this.button_ClientsAccounts_ActivateAccount.Name = "button_ClientsAccounts_ActivateAccount";
        this.button_ClientsAccounts_ActivateAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsAccounts_ActivateAccount.TabIndex = 23;
        this.button_ClientsAccounts_ActivateAccount.Text = "Activate";
        this.button_ClientsAccounts_ActivateAccount.Click += new System.EventHandler(this.button_ClientsAccounts_ActivateAccount_Click);
        // 
        // button_ClientsAccounts_ClearAccountsList
        // 
        this.button_ClientsAccounts_ClearAccountsList.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsAccounts_ClearAccountsList.Location = new System.Drawing.Point(720, 315);
        this.button_ClientsAccounts_ClearAccountsList.Name = "button_ClientsAccounts_ClearAccountsList";
        this.button_ClientsAccounts_ClearAccountsList.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsAccounts_ClearAccountsList.TabIndex = 21;
        this.button_ClientsAccounts_ClearAccountsList.Text = "Clear";
        this.button_ClientsAccounts_ClearAccountsList.Click += new System.EventHandler(this.button_ClientsAccounts_ClearAccountsList_Click);
        // 
        // button_ClientsAccounts_RemoveAccount
        // 
        this.button_ClientsAccounts_RemoveAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsAccounts_RemoveAccount.Location = new System.Drawing.Point(601, 315);
        this.button_ClientsAccounts_RemoveAccount.Name = "button_ClientsAccounts_RemoveAccount";
        this.button_ClientsAccounts_RemoveAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsAccounts_RemoveAccount.TabIndex = 20;
        this.button_ClientsAccounts_RemoveAccount.Text = "Remove";
        this.button_ClientsAccounts_RemoveAccount.Click += new System.EventHandler(this.button_ClientsAccounts_RemoveAccount_Click);
        // 
        // button_ClientsAccounts_AddAccount
        // 
        this.button_ClientsAccounts_AddAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsAccounts_AddAccount.Location = new System.Drawing.Point(6, 315);
        this.button_ClientsAccounts_AddAccount.Name = "button_ClientsAccounts_AddAccount";
        this.button_ClientsAccounts_AddAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsAccounts_AddAccount.TabIndex = 15;
        this.button_ClientsAccounts_AddAccount.Text = "Add";
        this.button_ClientsAccounts_AddAccount.Click += new System.EventHandler(this.button_ClientsAccounts_AddAccount_Click);
        // 
        // listView_ClientsAccounts_ClientsAccounts
        // 
        this.listView_ClientsAccounts_ClientsAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ClientsAccounts_User,
            this.columnHeader_ClientsAccounts_UIN,
            this.columnHeader_ClientsAccounts_ActivationCode,
            this.columnHeader_ClientsAccounts_CreationTime,
            this.columnHeader_ClientsAccounts_ActivationTime,
            this.columnHeader_ClientsAccounts_Status});
        this.listView_ClientsAccounts_ClientsAccounts.FullRowSelect = true;
        this.listView_ClientsAccounts_ClientsAccounts.GridLines = true;
        this.listView_ClientsAccounts_ClientsAccounts.HideSelection = false;
        this.listView_ClientsAccounts_ClientsAccounts.Location = new System.Drawing.Point(6, 35);
        this.listView_ClientsAccounts_ClientsAccounts.Name = "listView_ClientsAccounts_ClientsAccounts";
        this.listView_ClientsAccounts_ClientsAccounts.Size = new System.Drawing.Size(944, 270);
        this.listView_ClientsAccounts_ClientsAccounts.TabIndex = 14;
        this.listView_ClientsAccounts_ClientsAccounts.UseCompatibleStateImageBehavior = false;
        this.listView_ClientsAccounts_ClientsAccounts.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader_ClientsAccounts_User
        // 
        this.columnHeader_ClientsAccounts_User.Text = "User Name";
        this.columnHeader_ClientsAccounts_User.Width = 150;
        // 
        // columnHeader_ClientsAccounts_UIN
        // 
        this.columnHeader_ClientsAccounts_UIN.Text = "UIN";
        this.columnHeader_ClientsAccounts_UIN.Width = 150;
        // 
        // columnHeader_ClientsAccounts_ActivationCode
        // 
        this.columnHeader_ClientsAccounts_ActivationCode.Text = "Activation Code";
        this.columnHeader_ClientsAccounts_ActivationCode.Width = 150;
        // 
        // columnHeader_ClientsAccounts_CreationTime
        // 
        this.columnHeader_ClientsAccounts_CreationTime.Text = "Creation Time";
        this.columnHeader_ClientsAccounts_CreationTime.Width = 150;
        // 
        // columnHeader_ClientsAccounts_ActivationTime
        // 
        this.columnHeader_ClientsAccounts_ActivationTime.Text = "Activation Time";
        this.columnHeader_ClientsAccounts_ActivationTime.Width = 115;
        // 
        // columnHeader_ClientsAccounts_Status
        // 
        this.columnHeader_ClientsAccounts_Status.Text = "Status";
        this.columnHeader_ClientsAccounts_Status.Width = 204;
        // 
        // button_ClientsAccounts_DisableAccount
        // 
        this.button_ClientsAccounts_DisableAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsAccounts_DisableAccount.Location = new System.Drawing.Point(363, 315);
        this.button_ClientsAccounts_DisableAccount.Name = "button_ClientsAccounts_DisableAccount";
        this.button_ClientsAccounts_DisableAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsAccounts_DisableAccount.TabIndex = 18;
        this.button_ClientsAccounts_DisableAccount.Text = "Disable";
        this.button_ClientsAccounts_DisableAccount.Click += new System.EventHandler(this.button_ClientsAccounts_DisableAccount_Click);
        // 
        // button_ClientsAccounts_EnableAccount
        // 
        this.button_ClientsAccounts_EnableAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsAccounts_EnableAccount.Location = new System.Drawing.Point(482, 315);
        this.button_ClientsAccounts_EnableAccount.Name = "button_ClientsAccounts_EnableAccount";
        this.button_ClientsAccounts_EnableAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsAccounts_EnableAccount.TabIndex = 19;
        this.button_ClientsAccounts_EnableAccount.Text = "Enable";
        this.button_ClientsAccounts_EnableAccount.Click += new System.EventHandler(this.button_ClientsAccounts_EnableAccount_Click);
        // 
        // button_ClientsAccounts_EditAccount
        // 
        this.button_ClientsAccounts_EditAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsAccounts_EditAccount.Location = new System.Drawing.Point(125, 315);
        this.button_ClientsAccounts_EditAccount.Name = "button_ClientsAccounts_EditAccount";
        this.button_ClientsAccounts_EditAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsAccounts_EditAccount.TabIndex = 16;
        this.button_ClientsAccounts_EditAccount.Text = "Edit";
        this.button_ClientsAccounts_EditAccount.Click += new System.EventHandler(this.button_ClientsAccounts_EditAccount_Click);
        // 
        // button_ClientsAccounts_ViewAccount
        // 
        this.button_ClientsAccounts_ViewAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsAccounts_ViewAccount.Location = new System.Drawing.Point(244, 315);
        this.button_ClientsAccounts_ViewAccount.Name = "button_ClientsAccounts_ViewAccount";
        this.button_ClientsAccounts_ViewAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsAccounts_ViewAccount.TabIndex = 17;
        this.button_ClientsAccounts_ViewAccount.Text = "Vew";
        this.button_ClientsAccounts_ViewAccount.Click += new System.EventHandler(this.button_ClientsAccounts_ViewAccount_Click);
        // 
        // label2
        // 
        this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label2.Location = new System.Drawing.Point(6, 20);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(144, 16);
        this.label2.TabIndex = 22;
        this.label2.Text = "List of users accounts:";
        // 
        // tabPage_ServersAccounts
        // 
        this.tabPage_ServersAccounts.Controls.Add(this.groupBox_ServersAccounts_RestrictionRules);
        this.tabPage_ServersAccounts.Controls.Add(this.groupBox_ServersAccounts_Accounts);
        this.tabPage_ServersAccounts.Location = new System.Drawing.Point(4, 22);
        this.tabPage_ServersAccounts.Name = "tabPage_ServersAccounts";
        this.tabPage_ServersAccounts.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage_ServersAccounts.Size = new System.Drawing.Size(972, 654);
        this.tabPage_ServersAccounts.TabIndex = 3;
        this.tabPage_ServersAccounts.Text = "Servers Accounts";
        // 
        // groupBox_ServersAccounts_RestrictionRules
        // 
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.listView_ServersRestrictionRules_RulestList);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.button57);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.button_ServersRestrictionRules_ViewRule);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.button59);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.button_ServersRestrictionRules_EnableRule);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.button61);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.button_ServersRestrictionRules_DisableRule);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.label_ServersRestrictionRules_RestrictionRules);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.button_ServersRestrictionRules_EditRule);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.button_ServersRestrictionRules_ClearRulesList);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.button_ServersRestrictionRules_AddRule);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.checkBox_ServersRestrictionRules_UseRestrictionRules);
        this.groupBox_ServersAccounts_RestrictionRules.Controls.Add(this.button_ServersRestrictionRules_RemoveRule);
        this.groupBox_ServersAccounts_RestrictionRules.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ServersAccounts_RestrictionRules.Location = new System.Drawing.Point(6, 362);
        this.groupBox_ServersAccounts_RestrictionRules.Name = "groupBox_ServersAccounts_RestrictionRules";
        this.groupBox_ServersAccounts_RestrictionRules.Size = new System.Drawing.Size(958, 286);
        this.groupBox_ServersAccounts_RestrictionRules.TabIndex = 44;
        this.groupBox_ServersAccounts_RestrictionRules.TabStop = false;
        this.groupBox_ServersAccounts_RestrictionRules.Text = "Restriction Rules";
        // 
        // listView_ServersRestrictionRules_RulestList
        // 
        this.listView_ServersRestrictionRules_RulestList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ServersRestrictionRules_IPRange,
            this.columnHeader_ServersRestrictionRules_IPAddress,
            this.columnHeader_ServersRestrictionRules_MACAddress,
            this.columnHeader_ServersRestrictionRules_RuleType,
            this.columnHeader_ServersRestrictionRules_CreationTime,
            this.columnHeader_ServersRestrictionRules_RuleStatus});
        this.listView_ServersRestrictionRules_RulestList.FullRowSelect = true;
        this.listView_ServersRestrictionRules_RulestList.GridLines = true;
        this.listView_ServersRestrictionRules_RulestList.HideSelection = false;
        this.listView_ServersRestrictionRules_RulestList.Location = new System.Drawing.Point(6, 38);
        this.listView_ServersRestrictionRules_RulestList.Name = "listView_ServersRestrictionRules_RulestList";
        this.listView_ServersRestrictionRules_RulestList.Size = new System.Drawing.Size(944, 200);
        this.listView_ServersRestrictionRules_RulestList.TabIndex = 40;
        this.listView_ServersRestrictionRules_RulestList.UseCompatibleStateImageBehavior = false;
        this.listView_ServersRestrictionRules_RulestList.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader_ServersRestrictionRules_IPRange
        // 
        this.columnHeader_ServersRestrictionRules_IPRange.Text = "IP Range";
        this.columnHeader_ServersRestrictionRules_IPRange.Width = 200;
        // 
        // columnHeader_ServersRestrictionRules_IPAddress
        // 
        this.columnHeader_ServersRestrictionRules_IPAddress.Text = "IP Address";
        this.columnHeader_ServersRestrictionRules_IPAddress.Width = 150;
        // 
        // columnHeader_ServersRestrictionRules_MACAddress
        // 
        this.columnHeader_ServersRestrictionRules_MACAddress.Text = "MAC Address";
        this.columnHeader_ServersRestrictionRules_MACAddress.Width = 150;
        // 
        // columnHeader_ServersRestrictionRules_RuleType
        // 
        this.columnHeader_ServersRestrictionRules_RuleType.Text = "Rule Type";
        this.columnHeader_ServersRestrictionRules_RuleType.Width = 150;
        // 
        // columnHeader_ServersRestrictionRules_CreationTime
        // 
        this.columnHeader_ServersRestrictionRules_CreationTime.Text = "Creation Time";
        this.columnHeader_ServersRestrictionRules_CreationTime.Width = 120;
        // 
        // columnHeader_ServersRestrictionRules_RuleStatus
        // 
        this.columnHeader_ServersRestrictionRules_RuleStatus.Text = "Status";
        this.columnHeader_ServersRestrictionRules_RuleStatus.Width = 150;
        // 
        // button57
        // 
        this.button57.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button57.Location = new System.Drawing.Point(238, 699);
        this.button57.Name = "button57";
        this.button57.Size = new System.Drawing.Size(104, 23);
        this.button57.TabIndex = 3;
        this.button57.Text = "Details";
        // 
        // button_ServersRestrictionRules_ViewRule
        // 
        this.button_ServersRestrictionRules_ViewRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersRestrictionRules_ViewRule.Location = new System.Drawing.Point(244, 251);
        this.button_ServersRestrictionRules_ViewRule.Name = "button_ServersRestrictionRules_ViewRule";
        this.button_ServersRestrictionRules_ViewRule.Size = new System.Drawing.Size(110, 23);
        this.button_ServersRestrictionRules_ViewRule.TabIndex = 37;
        this.button_ServersRestrictionRules_ViewRule.Text = "Vew";
        this.button_ServersRestrictionRules_ViewRule.Click += new System.EventHandler(this.button_ServersRestrictionRules_ViewRule_Click);
        // 
        // button59
        // 
        this.button59.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button59.Location = new System.Drawing.Point(128, 699);
        this.button59.Name = "button59";
        this.button59.Size = new System.Drawing.Size(104, 23);
        this.button59.TabIndex = 2;
        this.button59.Text = "Disconnect All";
        // 
        // button_ServersRestrictionRules_EnableRule
        // 
        this.button_ServersRestrictionRules_EnableRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersRestrictionRules_EnableRule.Location = new System.Drawing.Point(482, 251);
        this.button_ServersRestrictionRules_EnableRule.Name = "button_ServersRestrictionRules_EnableRule";
        this.button_ServersRestrictionRules_EnableRule.Size = new System.Drawing.Size(110, 23);
        this.button_ServersRestrictionRules_EnableRule.TabIndex = 39;
        this.button_ServersRestrictionRules_EnableRule.Text = "Enable";
        this.button_ServersRestrictionRules_EnableRule.Click += new System.EventHandler(this.button_ServersRestrictionRules_EnableRule_Click);
        // 
        // button61
        // 
        this.button61.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button61.Location = new System.Drawing.Point(16, 699);
        this.button61.Name = "button61";
        this.button61.Size = new System.Drawing.Size(104, 23);
        this.button61.TabIndex = 1;
        this.button61.Text = "Disconnect";
        // 
        // button_ServersRestrictionRules_DisableRule
        // 
        this.button_ServersRestrictionRules_DisableRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersRestrictionRules_DisableRule.Location = new System.Drawing.Point(363, 251);
        this.button_ServersRestrictionRules_DisableRule.Name = "button_ServersRestrictionRules_DisableRule";
        this.button_ServersRestrictionRules_DisableRule.Size = new System.Drawing.Size(110, 23);
        this.button_ServersRestrictionRules_DisableRule.TabIndex = 38;
        this.button_ServersRestrictionRules_DisableRule.Text = "Disable";
        this.button_ServersRestrictionRules_DisableRule.Click += new System.EventHandler(this.button_ServersRestrictionRules_DisableRule_Click);
        // 
        // label_ServersRestrictionRules_RestrictionRules
        // 
        this.label_ServersRestrictionRules_RestrictionRules.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServersRestrictionRules_RestrictionRules.Location = new System.Drawing.Point(6, 23);
        this.label_ServersRestrictionRules_RestrictionRules.Name = "label_ServersRestrictionRules_RestrictionRules";
        this.label_ServersRestrictionRules_RestrictionRules.Size = new System.Drawing.Size(352, 16);
        this.label_ServersRestrictionRules_RestrictionRules.TabIndex = 31;
        this.label_ServersRestrictionRules_RestrictionRules.Text = "List of access restrictions rules:";
        // 
        // button_ServersRestrictionRules_EditRule
        // 
        this.button_ServersRestrictionRules_EditRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersRestrictionRules_EditRule.Location = new System.Drawing.Point(125, 251);
        this.button_ServersRestrictionRules_EditRule.Name = "button_ServersRestrictionRules_EditRule";
        this.button_ServersRestrictionRules_EditRule.Size = new System.Drawing.Size(110, 23);
        this.button_ServersRestrictionRules_EditRule.TabIndex = 36;
        this.button_ServersRestrictionRules_EditRule.Text = "Edit";
        this.button_ServersRestrictionRules_EditRule.Click += new System.EventHandler(this.button_ServersRestrictionRules_EditRule_Click);
        // 
        // button_ServersRestrictionRules_ClearRulesList
        // 
        this.button_ServersRestrictionRules_ClearRulesList.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersRestrictionRules_ClearRulesList.Location = new System.Drawing.Point(720, 251);
        this.button_ServersRestrictionRules_ClearRulesList.Name = "button_ServersRestrictionRules_ClearRulesList";
        this.button_ServersRestrictionRules_ClearRulesList.Size = new System.Drawing.Size(110, 23);
        this.button_ServersRestrictionRules_ClearRulesList.TabIndex = 35;
        this.button_ServersRestrictionRules_ClearRulesList.Text = "Clear";
        this.button_ServersRestrictionRules_ClearRulesList.Click += new System.EventHandler(this.button_ServersRestrictionRules_ClearRulesList_Click);
        // 
        // button_ServersRestrictionRules_AddRule
        // 
        this.button_ServersRestrictionRules_AddRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersRestrictionRules_AddRule.Location = new System.Drawing.Point(6, 251);
        this.button_ServersRestrictionRules_AddRule.Name = "button_ServersRestrictionRules_AddRule";
        this.button_ServersRestrictionRules_AddRule.Size = new System.Drawing.Size(110, 23);
        this.button_ServersRestrictionRules_AddRule.TabIndex = 32;
        this.button_ServersRestrictionRules_AddRule.Text = "Add";
        this.button_ServersRestrictionRules_AddRule.Click += new System.EventHandler(this.button_ServersRestrictionRules_AddRule_Click);
        // 
        // checkBox_ServersRestrictionRules_UseRestrictionRules
        // 
        this.checkBox_ServersRestrictionRules_UseRestrictionRules.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_ServersRestrictionRules_UseRestrictionRules.Location = new System.Drawing.Point(782, 16);
        this.checkBox_ServersRestrictionRules_UseRestrictionRules.Name = "checkBox_ServersRestrictionRules_UseRestrictionRules";
        this.checkBox_ServersRestrictionRules_UseRestrictionRules.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.checkBox_ServersRestrictionRules_UseRestrictionRules.Size = new System.Drawing.Size(168, 16);
        this.checkBox_ServersRestrictionRules_UseRestrictionRules.TabIndex = 34;
        this.checkBox_ServersRestrictionRules_UseRestrictionRules.Text = "Use Restrictions";
        this.checkBox_ServersRestrictionRules_UseRestrictionRules.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        this.checkBox_ServersRestrictionRules_UseRestrictionRules.CheckedChanged += new System.EventHandler(this.checkBox_ServersRestrictionRules_UseRestrictionRules_CheckedChanged);
        // 
        // button_ServersRestrictionRules_RemoveRule
        // 
        this.button_ServersRestrictionRules_RemoveRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersRestrictionRules_RemoveRule.Location = new System.Drawing.Point(601, 251);
        this.button_ServersRestrictionRules_RemoveRule.Name = "button_ServersRestrictionRules_RemoveRule";
        this.button_ServersRestrictionRules_RemoveRule.Size = new System.Drawing.Size(110, 23);
        this.button_ServersRestrictionRules_RemoveRule.TabIndex = 33;
        this.button_ServersRestrictionRules_RemoveRule.Text = "Remove";
        this.button_ServersRestrictionRules_RemoveRule.Click += new System.EventHandler(this.button_ServersRestrictionRules_RemoveRule_Click);
        // 
        // groupBox_ServersAccounts_Accounts
        // 
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.button_ServersAccounts_ActivateAccount);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.button67);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.button68);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.button69);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.button_ServersAccounts_ClearAccountsList);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.button_ServersAccounts_RemoveAccount);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.button_ServersAccounts_AddAccount);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.listView_ServersAccounts_ServersAccounts);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.button_ServersAccounts_DisableAccount);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.button_ServersAccounts_EnableAccount);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.button_ServersAccounts_EditAccount);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.button_ServersAccounts_ViewAccount);
        this.groupBox_ServersAccounts_Accounts.Controls.Add(this.label9);
        this.groupBox_ServersAccounts_Accounts.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ServersAccounts_Accounts.Location = new System.Drawing.Point(6, 6);
        this.groupBox_ServersAccounts_Accounts.Name = "groupBox_ServersAccounts_Accounts";
        this.groupBox_ServersAccounts_Accounts.Size = new System.Drawing.Size(958, 350);
        this.groupBox_ServersAccounts_Accounts.TabIndex = 43;
        this.groupBox_ServersAccounts_Accounts.TabStop = false;
        this.groupBox_ServersAccounts_Accounts.Text = "Servers Accounts";
        // 
        // button_ServersAccounts_ActivateAccount
        // 
        this.button_ServersAccounts_ActivateAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersAccounts_ActivateAccount.Location = new System.Drawing.Point(840, 315);
        this.button_ServersAccounts_ActivateAccount.Name = "button_ServersAccounts_ActivateAccount";
        this.button_ServersAccounts_ActivateAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ServersAccounts_ActivateAccount.TabIndex = 24;
        this.button_ServersAccounts_ActivateAccount.Text = "Activate";
        this.button_ServersAccounts_ActivateAccount.Click += new System.EventHandler(this.button_ServersAccounts_ActivateAccount_Click);
        // 
        // button67
        // 
        this.button67.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button67.Location = new System.Drawing.Point(238, 699);
        this.button67.Name = "button67";
        this.button67.Size = new System.Drawing.Size(104, 23);
        this.button67.TabIndex = 3;
        this.button67.Text = "Details";
        // 
        // button68
        // 
        this.button68.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button68.Location = new System.Drawing.Point(128, 699);
        this.button68.Name = "button68";
        this.button68.Size = new System.Drawing.Size(104, 23);
        this.button68.TabIndex = 2;
        this.button68.Text = "Disconnect All";
        // 
        // button69
        // 
        this.button69.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button69.Location = new System.Drawing.Point(16, 699);
        this.button69.Name = "button69";
        this.button69.Size = new System.Drawing.Size(104, 23);
        this.button69.TabIndex = 1;
        this.button69.Text = "Disconnect";
        // 
        // button_ServersAccounts_ClearAccountsList
        // 
        this.button_ServersAccounts_ClearAccountsList.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersAccounts_ClearAccountsList.Location = new System.Drawing.Point(720, 315);
        this.button_ServersAccounts_ClearAccountsList.Name = "button_ServersAccounts_ClearAccountsList";
        this.button_ServersAccounts_ClearAccountsList.Size = new System.Drawing.Size(110, 23);
        this.button_ServersAccounts_ClearAccountsList.TabIndex = 21;
        this.button_ServersAccounts_ClearAccountsList.Text = "Clear";
        this.button_ServersAccounts_ClearAccountsList.Click += new System.EventHandler(this.button_ServersAccounts_ClearAccountsList_Click);
        // 
        // button_ServersAccounts_RemoveAccount
        // 
        this.button_ServersAccounts_RemoveAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersAccounts_RemoveAccount.Location = new System.Drawing.Point(601, 315);
        this.button_ServersAccounts_RemoveAccount.Name = "button_ServersAccounts_RemoveAccount";
        this.button_ServersAccounts_RemoveAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ServersAccounts_RemoveAccount.TabIndex = 20;
        this.button_ServersAccounts_RemoveAccount.Text = "Remove";
        this.button_ServersAccounts_RemoveAccount.Click += new System.EventHandler(this.button_ServersAccounts_RemoveAccount_Click);
        // 
        // button_ServersAccounts_AddAccount
        // 
        this.button_ServersAccounts_AddAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersAccounts_AddAccount.Location = new System.Drawing.Point(6, 315);
        this.button_ServersAccounts_AddAccount.Name = "button_ServersAccounts_AddAccount";
        this.button_ServersAccounts_AddAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ServersAccounts_AddAccount.TabIndex = 15;
        this.button_ServersAccounts_AddAccount.Text = "Add";
        this.button_ServersAccounts_AddAccount.Click += new System.EventHandler(this.button_ServersAccounts_AddAccount_Click);
        // 
        // listView_ServersAccounts_ServersAccounts
        // 
        this.listView_ServersAccounts_ServersAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ServersAccounts_User,
            this.columnHeader_ServersAccounts_UIN,
            this.columnHeader_ServersAccounts_ActivationCode,
            this.columnHeader_ServersAccounts_CreationTime,
            this.columnHeader_ServersAccounts_ActivationTime,
            this.columnHeader_ServersAccounts_Status});
        this.listView_ServersAccounts_ServersAccounts.FullRowSelect = true;
        this.listView_ServersAccounts_ServersAccounts.GridLines = true;
        this.listView_ServersAccounts_ServersAccounts.HideSelection = false;
        this.listView_ServersAccounts_ServersAccounts.Location = new System.Drawing.Point(6, 35);
        this.listView_ServersAccounts_ServersAccounts.Name = "listView_ServersAccounts_ServersAccounts";
        this.listView_ServersAccounts_ServersAccounts.Size = new System.Drawing.Size(944, 270);
        this.listView_ServersAccounts_ServersAccounts.TabIndex = 14;
        this.listView_ServersAccounts_ServersAccounts.UseCompatibleStateImageBehavior = false;
        this.listView_ServersAccounts_ServersAccounts.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader_ServersAccounts_User
        // 
        this.columnHeader_ServersAccounts_User.Text = "User Name";
        this.columnHeader_ServersAccounts_User.Width = 150;
        // 
        // columnHeader_ServersAccounts_UIN
        // 
        this.columnHeader_ServersAccounts_UIN.Text = "UIN";
        this.columnHeader_ServersAccounts_UIN.Width = 150;
        // 
        // columnHeader_ServersAccounts_ActivationCode
        // 
        this.columnHeader_ServersAccounts_ActivationCode.Text = "Activation Code";
        this.columnHeader_ServersAccounts_ActivationCode.Width = 150;
        // 
        // columnHeader_ServersAccounts_CreationTime
        // 
        this.columnHeader_ServersAccounts_CreationTime.Text = "Creation Time";
        this.columnHeader_ServersAccounts_CreationTime.Width = 150;
        // 
        // columnHeader_ServersAccounts_ActivationTime
        // 
        this.columnHeader_ServersAccounts_ActivationTime.Text = "Activation Time";
        this.columnHeader_ServersAccounts_ActivationTime.Width = 115;
        // 
        // columnHeader_ServersAccounts_Status
        // 
        this.columnHeader_ServersAccounts_Status.Text = "Status";
        this.columnHeader_ServersAccounts_Status.Width = 204;
        // 
        // button_ServersAccounts_DisableAccount
        // 
        this.button_ServersAccounts_DisableAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersAccounts_DisableAccount.Location = new System.Drawing.Point(363, 315);
        this.button_ServersAccounts_DisableAccount.Name = "button_ServersAccounts_DisableAccount";
        this.button_ServersAccounts_DisableAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ServersAccounts_DisableAccount.TabIndex = 18;
        this.button_ServersAccounts_DisableAccount.Text = "Disable";
        this.button_ServersAccounts_DisableAccount.Click += new System.EventHandler(this.button_ServersAccounts_DisableAccount_Click);
        // 
        // button_ServersAccounts_EnableAccount
        // 
        this.button_ServersAccounts_EnableAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersAccounts_EnableAccount.Location = new System.Drawing.Point(482, 315);
        this.button_ServersAccounts_EnableAccount.Name = "button_ServersAccounts_EnableAccount";
        this.button_ServersAccounts_EnableAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ServersAccounts_EnableAccount.TabIndex = 19;
        this.button_ServersAccounts_EnableAccount.Text = "Enable";
        this.button_ServersAccounts_EnableAccount.Click += new System.EventHandler(this.button_ServersAccounts_EnableAccount_Click);
        // 
        // button_ServersAccounts_EditAccount
        // 
        this.button_ServersAccounts_EditAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersAccounts_EditAccount.Location = new System.Drawing.Point(125, 315);
        this.button_ServersAccounts_EditAccount.Name = "button_ServersAccounts_EditAccount";
        this.button_ServersAccounts_EditAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ServersAccounts_EditAccount.TabIndex = 16;
        this.button_ServersAccounts_EditAccount.Text = "Edit";
        this.button_ServersAccounts_EditAccount.Click += new System.EventHandler(this.button_ServersAccounts_EditAccount_Click);
        // 
        // button_ServersAccounts_ViewAccount
        // 
        this.button_ServersAccounts_ViewAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersAccounts_ViewAccount.Location = new System.Drawing.Point(244, 315);
        this.button_ServersAccounts_ViewAccount.Name = "button_ServersAccounts_ViewAccount";
        this.button_ServersAccounts_ViewAccount.Size = new System.Drawing.Size(110, 23);
        this.button_ServersAccounts_ViewAccount.TabIndex = 17;
        this.button_ServersAccounts_ViewAccount.Text = "Vew";
        this.button_ServersAccounts_ViewAccount.Click += new System.EventHandler(this.button_ServersAccounts_ViewAccount_Click);
        // 
        // label9
        // 
        this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label9.Location = new System.Drawing.Point(6, 20);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(144, 16);
        this.label9.TabIndex = 22;
        this.label9.Text = "List of users accounts:";
        // 
        // tabPage_EventsLogs
        // 
        this.tabPage_EventsLogs.Controls.Add(this.groupBox_EventsLog_SeversEventsLog);
        this.tabPage_EventsLogs.Controls.Add(this.groupBox_EventsLog_ClientsEventsLog);
        this.tabPage_EventsLogs.Controls.Add(this.groupBox_EventsLog_CommonEventsLog);
        this.tabPage_EventsLogs.Location = new System.Drawing.Point(4, 22);
        this.tabPage_EventsLogs.Name = "tabPage_EventsLogs";
        this.tabPage_EventsLogs.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage_EventsLogs.Size = new System.Drawing.Size(972, 654);
        this.tabPage_EventsLogs.TabIndex = 4;
        this.tabPage_EventsLogs.Text = "Events Logs";
        // 
        // groupBox_EventsLog_SeversEventsLog
        // 
        this.groupBox_EventsLog_SeversEventsLog.Controls.Add(this.button_ServersEventsLog_SaveLog);
        this.groupBox_EventsLog_SeversEventsLog.Controls.Add(this.listView_ServersEventsLog_LogList);
        this.groupBox_EventsLog_SeversEventsLog.Controls.Add(this.button_ServersEventsLog_ClearLog);
        this.groupBox_EventsLog_SeversEventsLog.Controls.Add(this.button4);
        this.groupBox_EventsLog_SeversEventsLog.Controls.Add(this.button5);
        this.groupBox_EventsLog_SeversEventsLog.Controls.Add(this.button6);
        this.groupBox_EventsLog_SeversEventsLog.Controls.Add(this.label_ServersEventsLog_Events);
        this.groupBox_EventsLog_SeversEventsLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_EventsLog_SeversEventsLog.Location = new System.Drawing.Point(6, 223);
        this.groupBox_EventsLog_SeversEventsLog.Name = "groupBox_EventsLog_SeversEventsLog";
        this.groupBox_EventsLog_SeversEventsLog.Size = new System.Drawing.Size(960, 210);
        this.groupBox_EventsLog_SeversEventsLog.TabIndex = 18;
        this.groupBox_EventsLog_SeversEventsLog.TabStop = false;
        this.groupBox_EventsLog_SeversEventsLog.Text = "Servers Events Log";
        // 
        // button_ServersEventsLog_SaveLog
        // 
        this.button_ServersEventsLog_SaveLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersEventsLog_SaveLog.Location = new System.Drawing.Point(727, 15);
        this.button_ServersEventsLog_SaveLog.Name = "button_ServersEventsLog_SaveLog";
        this.button_ServersEventsLog_SaveLog.Size = new System.Drawing.Size(110, 23);
        this.button_ServersEventsLog_SaveLog.TabIndex = 24;
        this.button_ServersEventsLog_SaveLog.Text = "Save";
        this.button_ServersEventsLog_SaveLog.Click += new System.EventHandler(this.button_ServersEventsLog_SaveLog_Click);
        // 
        // listView_ServersEventsLog_LogList
        // 
        this.listView_ServersEventsLog_LogList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ServersEventsLog_EventType,
            this.columnHeader_ServersEventsLog_RecordTime,
            this.columnHeader_ServersEventsLog_UserName,
            this.columnHeader_ServersEventsLog_UIN,
            this.columnHeader_ServersEventsLog_EventInformation});
        this.listView_ServersEventsLog_LogList.FullRowSelect = true;
        this.listView_ServersEventsLog_LogList.GridLines = true;
        this.listView_ServersEventsLog_LogList.HideSelection = false;
        this.listView_ServersEventsLog_LogList.Location = new System.Drawing.Point(10, 45);
        this.listView_ServersEventsLog_LogList.Name = "listView_ServersEventsLog_LogList";
        this.listView_ServersEventsLog_LogList.Size = new System.Drawing.Size(944, 150);
        this.listView_ServersEventsLog_LogList.TabIndex = 24;
        this.listView_ServersEventsLog_LogList.UseCompatibleStateImageBehavior = false;
        this.listView_ServersEventsLog_LogList.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader_ServersEventsLog_EventType
        // 
        this.columnHeader_ServersEventsLog_EventType.Text = "Event Type";
        this.columnHeader_ServersEventsLog_EventType.Width = 120;
        // 
        // columnHeader_ServersEventsLog_RecordTime
        // 
        this.columnHeader_ServersEventsLog_RecordTime.Text = "Record time";
        this.columnHeader_ServersEventsLog_RecordTime.Width = 120;
        // 
        // columnHeader_ServersEventsLog_UserName
        // 
        this.columnHeader_ServersEventsLog_UserName.Text = "User";
        this.columnHeader_ServersEventsLog_UserName.Width = 100;
        // 
        // columnHeader_ServersEventsLog_UIN
        // 
        this.columnHeader_ServersEventsLog_UIN.Text = "UIN";
        this.columnHeader_ServersEventsLog_UIN.Width = 100;
        // 
        // columnHeader_ServersEventsLog_EventInformation
        // 
        this.columnHeader_ServersEventsLog_EventInformation.Text = "Event Information";
        this.columnHeader_ServersEventsLog_EventInformation.Width = 480;
        // 
        // button_ServersEventsLog_ClearLog
        // 
        this.button_ServersEventsLog_ClearLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ServersEventsLog_ClearLog.Location = new System.Drawing.Point(843, 15);
        this.button_ServersEventsLog_ClearLog.Name = "button_ServersEventsLog_ClearLog";
        this.button_ServersEventsLog_ClearLog.Size = new System.Drawing.Size(110, 23);
        this.button_ServersEventsLog_ClearLog.TabIndex = 23;
        this.button_ServersEventsLog_ClearLog.Text = "Clear";
        this.button_ServersEventsLog_ClearLog.Click += new System.EventHandler(this.button_ServersEventsLog_ClearLog_Click);
        // 
        // button4
        // 
        this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button4.Location = new System.Drawing.Point(238, 699);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(104, 23);
        this.button4.TabIndex = 3;
        this.button4.Text = "Details";
        // 
        // button5
        // 
        this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button5.Location = new System.Drawing.Point(128, 699);
        this.button5.Name = "button5";
        this.button5.Size = new System.Drawing.Size(104, 23);
        this.button5.TabIndex = 2;
        this.button5.Text = "Disconnect All";
        // 
        // button6
        // 
        this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button6.Location = new System.Drawing.Point(16, 699);
        this.button6.Name = "button6";
        this.button6.Size = new System.Drawing.Size(104, 23);
        this.button6.TabIndex = 1;
        this.button6.Text = "Disconnect";
        // 
        // label_ServersEventsLog_Events
        // 
        this.label_ServersEventsLog_Events.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ServersEventsLog_Events.Location = new System.Drawing.Point(10, 29);
        this.label_ServersEventsLog_Events.Name = "label_ServersEventsLog_Events";
        this.label_ServersEventsLog_Events.Size = new System.Drawing.Size(88, 16);
        this.label_ServersEventsLog_Events.TabIndex = 3;
        this.label_ServersEventsLog_Events.Text = "Events:";
        // 
        // groupBox_EventsLog_ClientsEventsLog
        // 
        this.groupBox_EventsLog_ClientsEventsLog.Controls.Add(this.button_ClientsEventsLog_SaveLog);
        this.groupBox_EventsLog_ClientsEventsLog.Controls.Add(this.listView_ClientsEventsLog_LogList);
        this.groupBox_EventsLog_ClientsEventsLog.Controls.Add(this.button_ClientsEventsLog_ClearLog);
        this.groupBox_EventsLog_ClientsEventsLog.Controls.Add(this.button1);
        this.groupBox_EventsLog_ClientsEventsLog.Controls.Add(this.button2);
        this.groupBox_EventsLog_ClientsEventsLog.Controls.Add(this.button3);
        this.groupBox_EventsLog_ClientsEventsLog.Controls.Add(this.label_ClientsEventsLog_Events);
        this.groupBox_EventsLog_ClientsEventsLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_EventsLog_ClientsEventsLog.Location = new System.Drawing.Point(6, 438);
        this.groupBox_EventsLog_ClientsEventsLog.Name = "groupBox_EventsLog_ClientsEventsLog";
        this.groupBox_EventsLog_ClientsEventsLog.Size = new System.Drawing.Size(960, 210);
        this.groupBox_EventsLog_ClientsEventsLog.TabIndex = 18;
        this.groupBox_EventsLog_ClientsEventsLog.TabStop = false;
        this.groupBox_EventsLog_ClientsEventsLog.Text = "Clients Events Log";
        // 
        // button_ClientsEventsLog_SaveLog
        // 
        this.button_ClientsEventsLog_SaveLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsEventsLog_SaveLog.Location = new System.Drawing.Point(727, 15);
        this.button_ClientsEventsLog_SaveLog.Name = "button_ClientsEventsLog_SaveLog";
        this.button_ClientsEventsLog_SaveLog.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsEventsLog_SaveLog.TabIndex = 25;
        this.button_ClientsEventsLog_SaveLog.Text = "Save";
        this.button_ClientsEventsLog_SaveLog.Click += new System.EventHandler(this.button_ClientsEventsLog_SaveLog_Click);
        // 
        // listView_ClientsEventsLog_LogList
        // 
        this.listView_ClientsEventsLog_LogList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ClientsEventsLog_EventType,
            this.columnHeader_ClientsEventsLog_RecordTime,
            this.columnHeader_ClientsEventsLog_UserName,
            this.columnHeader_ClientsEventsLog_UIN,
            this.columnHeader_ClientsEventsLog_EventInformation});
        this.listView_ClientsEventsLog_LogList.FullRowSelect = true;
        this.listView_ClientsEventsLog_LogList.GridLines = true;
        this.listView_ClientsEventsLog_LogList.HideSelection = false;
        this.listView_ClientsEventsLog_LogList.Location = new System.Drawing.Point(10, 45);
        this.listView_ClientsEventsLog_LogList.Name = "listView_ClientsEventsLog_LogList";
        this.listView_ClientsEventsLog_LogList.Size = new System.Drawing.Size(944, 150);
        this.listView_ClientsEventsLog_LogList.TabIndex = 23;
        this.listView_ClientsEventsLog_LogList.UseCompatibleStateImageBehavior = false;
        this.listView_ClientsEventsLog_LogList.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader_ClientsEventsLog_EventType
        // 
        this.columnHeader_ClientsEventsLog_EventType.Text = "Event Type";
        this.columnHeader_ClientsEventsLog_EventType.Width = 120;
        // 
        // columnHeader_ClientsEventsLog_RecordTime
        // 
        this.columnHeader_ClientsEventsLog_RecordTime.Text = "Record time";
        this.columnHeader_ClientsEventsLog_RecordTime.Width = 120;
        // 
        // columnHeader_ClientsEventsLog_UserName
        // 
        this.columnHeader_ClientsEventsLog_UserName.Text = "User";
        this.columnHeader_ClientsEventsLog_UserName.Width = 100;
        // 
        // columnHeader_ClientsEventsLog_UIN
        // 
        this.columnHeader_ClientsEventsLog_UIN.Text = "UIN";
        this.columnHeader_ClientsEventsLog_UIN.Width = 100;
        // 
        // columnHeader_ClientsEventsLog_EventInformation
        // 
        this.columnHeader_ClientsEventsLog_EventInformation.Text = "Event Information";
        this.columnHeader_ClientsEventsLog_EventInformation.Width = 480;
        // 
        // button_ClientsEventsLog_ClearLog
        // 
        this.button_ClientsEventsLog_ClearLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ClientsEventsLog_ClearLog.Location = new System.Drawing.Point(843, 15);
        this.button_ClientsEventsLog_ClearLog.Name = "button_ClientsEventsLog_ClearLog";
        this.button_ClientsEventsLog_ClearLog.Size = new System.Drawing.Size(110, 23);
        this.button_ClientsEventsLog_ClearLog.TabIndex = 22;
        this.button_ClientsEventsLog_ClearLog.Text = "Clear";
        this.button_ClientsEventsLog_ClearLog.Click += new System.EventHandler(this.button_ClientsEventsLog_ClearLog_Click);
        // 
        // button1
        // 
        this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button1.Location = new System.Drawing.Point(238, 699);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(104, 23);
        this.button1.TabIndex = 3;
        this.button1.Text = "Details";
        // 
        // button2
        // 
        this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button2.Location = new System.Drawing.Point(128, 699);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(104, 23);
        this.button2.TabIndex = 2;
        this.button2.Text = "Disconnect All";
        // 
        // button3
        // 
        this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button3.Location = new System.Drawing.Point(16, 699);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(104, 23);
        this.button3.TabIndex = 1;
        this.button3.Text = "Disconnect";
        // 
        // label_ClientsEventsLog_Events
        // 
        this.label_ClientsEventsLog_Events.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ClientsEventsLog_Events.Location = new System.Drawing.Point(10, 30);
        this.label_ClientsEventsLog_Events.Name = "label_ClientsEventsLog_Events";
        this.label_ClientsEventsLog_Events.Size = new System.Drawing.Size(88, 16);
        this.label_ClientsEventsLog_Events.TabIndex = 3;
        this.label_ClientsEventsLog_Events.Text = "Events:";
        // 
        // groupBox_EventsLog_CommonEventsLog
        // 
        this.groupBox_EventsLog_CommonEventsLog.Controls.Add(this.button_CommonEventsLog_SaveLog);
        this.groupBox_EventsLog_CommonEventsLog.Controls.Add(this.button_CommonEventsLog_ClearLog);
        this.groupBox_EventsLog_CommonEventsLog.Controls.Add(this.listView_CommonEventsLog_LogList);
        this.groupBox_EventsLog_CommonEventsLog.Controls.Add(this.button24);
        this.groupBox_EventsLog_CommonEventsLog.Controls.Add(this.button25);
        this.groupBox_EventsLog_CommonEventsLog.Controls.Add(this.button26);
        this.groupBox_EventsLog_CommonEventsLog.Controls.Add(this.label_CommonEventsLog_Events);
        this.groupBox_EventsLog_CommonEventsLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_EventsLog_CommonEventsLog.Location = new System.Drawing.Point(6, 6);
        this.groupBox_EventsLog_CommonEventsLog.Name = "groupBox_EventsLog_CommonEventsLog";
        this.groupBox_EventsLog_CommonEventsLog.Size = new System.Drawing.Size(960, 210);
        this.groupBox_EventsLog_CommonEventsLog.TabIndex = 17;
        this.groupBox_EventsLog_CommonEventsLog.TabStop = false;
        this.groupBox_EventsLog_CommonEventsLog.Text = "Common Events Log";
        // 
        // button_CommonEventsLog_SaveLog
        // 
        this.button_CommonEventsLog_SaveLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_CommonEventsLog_SaveLog.Location = new System.Drawing.Point(727, 15);
        this.button_CommonEventsLog_SaveLog.Name = "button_CommonEventsLog_SaveLog";
        this.button_CommonEventsLog_SaveLog.Size = new System.Drawing.Size(110, 23);
        this.button_CommonEventsLog_SaveLog.TabIndex = 23;
        this.button_CommonEventsLog_SaveLog.Text = "Save";
        this.button_CommonEventsLog_SaveLog.Click += new System.EventHandler(this.button_CommonEventsLog_SaveLog_Click);
        // 
        // button_CommonEventsLog_ClearLog
        // 
        this.button_CommonEventsLog_ClearLog.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_CommonEventsLog_ClearLog.Location = new System.Drawing.Point(843, 15);
        this.button_CommonEventsLog_ClearLog.Name = "button_CommonEventsLog_ClearLog";
        this.button_CommonEventsLog_ClearLog.Size = new System.Drawing.Size(110, 23);
        this.button_CommonEventsLog_ClearLog.TabIndex = 22;
        this.button_CommonEventsLog_ClearLog.Text = "Clear";
        this.button_CommonEventsLog_ClearLog.Click += new System.EventHandler(this.button_CommonEventsLog_ClearLog_Click);
        // 
        // listView_CommonEventsLog_LogList
        // 
        this.listView_CommonEventsLog_LogList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_CommonEventsLogList_EventType,
            this.columnHeader_CommonEventsLogList_RecordTime,
            this.columnHeader_CommonEventsLogList_EventInformation});
        this.listView_CommonEventsLog_LogList.FullRowSelect = true;
        this.listView_CommonEventsLog_LogList.GridLines = true;
        this.listView_CommonEventsLog_LogList.HideSelection = false;
        this.listView_CommonEventsLog_LogList.Location = new System.Drawing.Point(10, 45);
        this.listView_CommonEventsLog_LogList.Name = "listView_CommonEventsLog_LogList";
        this.listView_CommonEventsLog_LogList.Size = new System.Drawing.Size(944, 150);
        this.listView_CommonEventsLog_LogList.TabIndex = 17;
        this.listView_CommonEventsLog_LogList.UseCompatibleStateImageBehavior = false;
        this.listView_CommonEventsLog_LogList.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader_CommonEventsLogList_EventType
        // 
        this.columnHeader_CommonEventsLogList_EventType.Text = "Event Type";
        this.columnHeader_CommonEventsLogList_EventType.Width = 120;
        // 
        // columnHeader_CommonEventsLogList_RecordTime
        // 
        this.columnHeader_CommonEventsLogList_RecordTime.Text = "Record time";
        this.columnHeader_CommonEventsLogList_RecordTime.Width = 120;
        // 
        // columnHeader_CommonEventsLogList_EventInformation
        // 
        this.columnHeader_CommonEventsLogList_EventInformation.Text = "Event Information";
        this.columnHeader_CommonEventsLogList_EventInformation.Width = 680;
        // 
        // button24
        // 
        this.button24.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button24.Location = new System.Drawing.Point(238, 699);
        this.button24.Name = "button24";
        this.button24.Size = new System.Drawing.Size(104, 23);
        this.button24.TabIndex = 3;
        this.button24.Text = "Details";
        // 
        // button25
        // 
        this.button25.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button25.Location = new System.Drawing.Point(128, 699);
        this.button25.Name = "button25";
        this.button25.Size = new System.Drawing.Size(104, 23);
        this.button25.TabIndex = 2;
        this.button25.Text = "Disconnect All";
        // 
        // button26
        // 
        this.button26.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button26.Location = new System.Drawing.Point(16, 699);
        this.button26.Name = "button26";
        this.button26.Size = new System.Drawing.Size(104, 23);
        this.button26.TabIndex = 1;
        this.button26.Text = "Disconnect";
        // 
        // label_CommonEventsLog_Events
        // 
        this.label_CommonEventsLog_Events.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_CommonEventsLog_Events.Location = new System.Drawing.Point(10, 28);
        this.label_CommonEventsLog_Events.Name = "label_CommonEventsLog_Events";
        this.label_CommonEventsLog_Events.Size = new System.Drawing.Size(88, 16);
        this.label_CommonEventsLog_Events.TabIndex = 3;
        this.label_CommonEventsLog_Events.Text = "Events:";
        // 
        // button_Security_ViewClientAccount
        // 
        this.button_Security_ViewClientAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_Security_ViewClientAccount.Location = new System.Drawing.Point(232, 208);
        this.button_Security_ViewClientAccount.Name = "button_Security_ViewClientAccount";
        this.button_Security_ViewClientAccount.Size = new System.Drawing.Size(96, 23);
        this.button_Security_ViewClientAccount.TabIndex = 3;
        this.button_Security_ViewClientAccount.Text = "Vew";
        // 
        // button_Security_ClearClientAccounts
        // 
        this.button_Security_ClearClientAccounts.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_Security_ClearClientAccounts.Location = new System.Drawing.Point(648, 208);
        this.button_Security_ClearClientAccounts.Name = "button_Security_ClearClientAccounts";
        this.button_Security_ClearClientAccounts.Size = new System.Drawing.Size(96, 23);
        this.button_Security_ClearClientAccounts.TabIndex = 7;
        this.button_Security_ClearClientAccounts.Text = "Clear";
        // 
        // label_Security_ListOfUsersAccounts
        // 
        this.label_Security_ListOfUsersAccounts.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_Security_ListOfUsersAccounts.Location = new System.Drawing.Point(16, 8);
        this.label_Security_ListOfUsersAccounts.Name = "label_Security_ListOfUsersAccounts";
        this.label_Security_ListOfUsersAccounts.Size = new System.Drawing.Size(144, 16);
        this.label_Security_ListOfUsersAccounts.TabIndex = 13;
        this.label_Security_ListOfUsersAccounts.Text = "List of users accounts:";
        // 
        // button_Security_EditClientAccount
        // 
        this.button_Security_EditClientAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_Security_EditClientAccount.Location = new System.Drawing.Point(128, 208);
        this.button_Security_EditClientAccount.Name = "button_Security_EditClientAccount";
        this.button_Security_EditClientAccount.Size = new System.Drawing.Size(96, 23);
        this.button_Security_EditClientAccount.TabIndex = 2;
        this.button_Security_EditClientAccount.Text = "Edit";
        // 
        // button_Security_EnableClientAccount
        // 
        this.button_Security_EnableClientAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_Security_EnableClientAccount.Location = new System.Drawing.Point(440, 208);
        this.button_Security_EnableClientAccount.Name = "button_Security_EnableClientAccount";
        this.button_Security_EnableClientAccount.Size = new System.Drawing.Size(97, 23);
        this.button_Security_EnableClientAccount.TabIndex = 5;
        this.button_Security_EnableClientAccount.Text = "Enable";
        // 
        // button_Security_DisableClientAccount
        // 
        this.button_Security_DisableClientAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_Security_DisableClientAccount.Location = new System.Drawing.Point(336, 208);
        this.button_Security_DisableClientAccount.Name = "button_Security_DisableClientAccount";
        this.button_Security_DisableClientAccount.Size = new System.Drawing.Size(96, 23);
        this.button_Security_DisableClientAccount.TabIndex = 4;
        this.button_Security_DisableClientAccount.Text = "Disable";
        // 
        // listView_Security_ListOfUsersAccounts
        // 
        this.listView_Security_ListOfUsersAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_UsersDatabase_User,
            this.columnHeader_UsersDatabase_Login,
            this.columnHeader_UsersDatabase_TimeOfCreation,
            this.columnHeader_UsersDatabase_AccountStatus});
        this.listView_Security_ListOfUsersAccounts.FullRowSelect = true;
        this.listView_Security_ListOfUsersAccounts.GridLines = true;
        this.listView_Security_ListOfUsersAccounts.HideSelection = false;
        this.listView_Security_ListOfUsersAccounts.Location = new System.Drawing.Point(16, 24);
        this.listView_Security_ListOfUsersAccounts.Name = "listView_Security_ListOfUsersAccounts";
        this.listView_Security_ListOfUsersAccounts.Size = new System.Drawing.Size(728, 176);
        this.listView_Security_ListOfUsersAccounts.TabIndex = 0;
        this.listView_Security_ListOfUsersAccounts.UseCompatibleStateImageBehavior = false;
        this.listView_Security_ListOfUsersAccounts.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader_UsersDatabase_User
        // 
        this.columnHeader_UsersDatabase_User.Text = "    User";
        this.columnHeader_UsersDatabase_User.Width = 120;
        // 
        // columnHeader_UsersDatabase_Login
        // 
        this.columnHeader_UsersDatabase_Login.Text = "Login";
        this.columnHeader_UsersDatabase_Login.Width = 100;
        // 
        // columnHeader_UsersDatabase_TimeOfCreation
        // 
        this.columnHeader_UsersDatabase_TimeOfCreation.Text = "Time of creation";
        this.columnHeader_UsersDatabase_TimeOfCreation.Width = 120;
        // 
        // columnHeader_UsersDatabase_AccountStatus
        // 
        this.columnHeader_UsersDatabase_AccountStatus.Text = "Status";
        this.columnHeader_UsersDatabase_AccountStatus.Width = 100;
        // 
        // button_Security_AddNewUser
        // 
        this.button_Security_AddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_Security_AddNewUser.Location = new System.Drawing.Point(16, 208);
        this.button_Security_AddNewUser.Name = "button_Security_AddNewUser";
        this.button_Security_AddNewUser.Size = new System.Drawing.Size(104, 24);
        this.button_Security_AddNewUser.TabIndex = 1;
        this.button_Security_AddNewUser.Text = "Add";
        // 
        // button_Security_RemoveClientAccount
        // 
        this.button_Security_RemoveClientAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_Security_RemoveClientAccount.Location = new System.Drawing.Point(544, 208);
        this.button_Security_RemoveClientAccount.Name = "button_Security_RemoveClientAccount";
        this.button_Security_RemoveClientAccount.Size = new System.Drawing.Size(96, 23);
        this.button_Security_RemoveClientAccount.TabIndex = 6;
        this.button_Security_RemoveClientAccount.Text = "Remove";
        // 
        // button7
        // 
        this.button7.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button7.Location = new System.Drawing.Point(232, 208);
        this.button7.Name = "button7";
        this.button7.Size = new System.Drawing.Size(96, 23);
        this.button7.TabIndex = 3;
        this.button7.Text = "Vew";
        // 
        // button8
        // 
        this.button8.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button8.Location = new System.Drawing.Point(648, 208);
        this.button8.Name = "button8";
        this.button8.Size = new System.Drawing.Size(96, 23);
        this.button8.TabIndex = 7;
        this.button8.Text = "Clear";
        // 
        // label1
        // 
        this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label1.Location = new System.Drawing.Point(16, 8);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(144, 16);
        this.label1.TabIndex = 13;
        this.label1.Text = "List of users accounts:";
        // 
        // button9
        // 
        this.button9.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button9.Location = new System.Drawing.Point(128, 208);
        this.button9.Name = "button9";
        this.button9.Size = new System.Drawing.Size(96, 23);
        this.button9.TabIndex = 2;
        this.button9.Text = "Edit";
        // 
        // button10
        // 
        this.button10.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button10.Location = new System.Drawing.Point(440, 208);
        this.button10.Name = "button10";
        this.button10.Size = new System.Drawing.Size(97, 23);
        this.button10.TabIndex = 5;
        this.button10.Text = "Enable";
        // 
        // button11
        // 
        this.button11.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button11.Location = new System.Drawing.Point(336, 208);
        this.button11.Name = "button11";
        this.button11.Size = new System.Drawing.Size(96, 23);
        this.button11.TabIndex = 4;
        this.button11.Text = "Disable";
        // 
        // listView3
        // 
        this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
        this.listView3.FullRowSelect = true;
        this.listView3.GridLines = true;
        this.listView3.HideSelection = false;
        this.listView3.Location = new System.Drawing.Point(16, 24);
        this.listView3.Name = "listView3";
        this.listView3.Size = new System.Drawing.Size(728, 176);
        this.listView3.TabIndex = 0;
        this.listView3.UseCompatibleStateImageBehavior = false;
        this.listView3.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader7
        // 
        this.columnHeader7.Text = "    User";
        this.columnHeader7.Width = 120;
        // 
        // columnHeader8
        // 
        this.columnHeader8.Text = "Login";
        this.columnHeader8.Width = 100;
        // 
        // columnHeader9
        // 
        this.columnHeader9.Text = "Time of creation";
        this.columnHeader9.Width = 120;
        // 
        // columnHeader10
        // 
        this.columnHeader10.Text = "Status";
        this.columnHeader10.Width = 100;
        // 
        // button12
        // 
        this.button12.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button12.Location = new System.Drawing.Point(16, 208);
        this.button12.Name = "button12";
        this.button12.Size = new System.Drawing.Size(104, 24);
        this.button12.TabIndex = 1;
        this.button12.Text = "Add";
        // 
        // button13
        // 
        this.button13.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button13.Location = new System.Drawing.Point(544, 208);
        this.button13.Name = "button13";
        this.button13.Size = new System.Drawing.Size(96, 23);
        this.button13.TabIndex = 6;
        this.button13.Text = "Remove";
        // 
        // mainMenu
        // 
        this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_File,
            this.menuItem_Options,
            this.menuItem_Help});
        // 
        // menuItem_File
        // 
        this.menuItem_File.Index = 0;
        this.menuItem_File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_File_Import,
            this.menuItem_File_Export,
            this.menuItem_File_Exit});
        this.menuItem_File.Text = "File";
        // 
        // menuItem_File_Import
        // 
        this.menuItem_File_Import.Index = 0;
        this.menuItem_File_Import.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_File_Import_SettingsDatabase});
        this.menuItem_File_Import.Text = "Import";
        // 
        // menuItem_File_Import_SettingsDatabase
        // 
        this.menuItem_File_Import_SettingsDatabase.Index = 0;
        this.menuItem_File_Import_SettingsDatabase.Text = "Settings DataBase";
        this.menuItem_File_Import_SettingsDatabase.Click += new System.EventHandler(this.menuItem_File_Import_SettingsDatabase_Click);
        // 
        // menuItem_File_Export
        // 
        this.menuItem_File_Export.Index = 1;
        this.menuItem_File_Export.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_File_Export_SettingsDatabase});
        this.menuItem_File_Export.Text = "Export";
        // 
        // menuItem_File_Export_SettingsDatabase
        // 
        this.menuItem_File_Export_SettingsDatabase.Index = 0;
        this.menuItem_File_Export_SettingsDatabase.Text = "Settings DataBase";
        this.menuItem_File_Export_SettingsDatabase.Click += new System.EventHandler(this.menuItem_File_Export_SettingsDatabase_Click);
        // 
        // menuItem_File_Exit
        // 
        this.menuItem_File_Exit.Index = 2;
        this.menuItem_File_Exit.Text = "Exit";
        this.menuItem_File_Exit.Click += new System.EventHandler(this.menuItem_File_Exit_Click);
        // 
        // menuItem_Options
        // 
        this.menuItem_Options.Index = 1;
        this.menuItem_Options.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Options_Settings});
        this.menuItem_Options.Text = "Options";
        // 
        // menuItem_Options_Settings
        // 
        this.menuItem_Options_Settings.Index = 0;
        this.menuItem_Options_Settings.Text = "Settings";
        this.menuItem_Options_Settings.Click += new System.EventHandler(this.menuItem_Options_Settings_Click);
        // 
        // menuItem_Help
        // 
        this.menuItem_Help.Index = 2;
        this.menuItem_Help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Help_About});
        this.menuItem_Help.Text = "Help";
        // 
        // menuItem_Help_About
        // 
        this.menuItem_Help_About.Index = 0;
        this.menuItem_Help_About.Text = "About";
        this.menuItem_Help_About.Click += new System.EventHandler(this.menuItem_Help_About_Click);
        // 
        // button21
        // 
        this.button21.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button21.Location = new System.Drawing.Point(238, 699);
        this.button21.Name = "button21";
        this.button21.Size = new System.Drawing.Size(104, 23);
        this.button21.TabIndex = 3;
        this.button21.Text = "Details";
        // 
        // button22
        // 
        this.button22.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button22.Location = new System.Drawing.Point(232, 311);
        this.button22.Name = "button22";
        this.button22.Size = new System.Drawing.Size(96, 23);
        this.button22.TabIndex = 37;
        this.button22.Text = "Vew";
        // 
        // button23
        // 
        this.button23.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button23.Location = new System.Drawing.Point(128, 699);
        this.button23.Name = "button23";
        this.button23.Size = new System.Drawing.Size(104, 23);
        this.button23.TabIndex = 2;
        this.button23.Text = "Disconnect All";
        // 
        // button27
        // 
        this.button27.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button27.Location = new System.Drawing.Point(440, 311);
        this.button27.Name = "button27";
        this.button27.Size = new System.Drawing.Size(97, 23);
        this.button27.TabIndex = 39;
        this.button27.Text = "Enable";
        // 
        // button28
        // 
        this.button28.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button28.Location = new System.Drawing.Point(16, 699);
        this.button28.Name = "button28";
        this.button28.Size = new System.Drawing.Size(104, 23);
        this.button28.TabIndex = 1;
        this.button28.Text = "Disconnect";
        // 
        // button29
        // 
        this.button29.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button29.Location = new System.Drawing.Point(336, 311);
        this.button29.Name = "button29";
        this.button29.Size = new System.Drawing.Size(96, 23);
        this.button29.TabIndex = 38;
        this.button29.Text = "Disable";
        // 
        // label3
        // 
        this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label3.Location = new System.Drawing.Point(16, 26);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(352, 16);
        this.label3.TabIndex = 31;
        this.label3.Text = "List of access restrictions rules:";
        // 
        // button30
        // 
        this.button30.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button30.Location = new System.Drawing.Point(128, 311);
        this.button30.Name = "button30";
        this.button30.Size = new System.Drawing.Size(96, 23);
        this.button30.TabIndex = 36;
        this.button30.Text = "Edit";
        // 
        // listView5
        // 
        this.listView5.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19});
        this.listView5.FullRowSelect = true;
        this.listView5.GridLines = true;
        this.listView5.HideSelection = false;
        this.listView5.Location = new System.Drawing.Point(16, 42);
        this.listView5.Name = "listView5";
        this.listView5.Size = new System.Drawing.Size(1237, 253);
        this.listView5.TabIndex = 30;
        this.listView5.UseCompatibleStateImageBehavior = false;
        this.listView5.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader15
        // 
        this.columnHeader15.Text = "IP Range";
        this.columnHeader15.Width = 200;
        // 
        // columnHeader16
        // 
        this.columnHeader16.Text = "IP Address";
        this.columnHeader16.Width = 100;
        // 
        // columnHeader17
        // 
        this.columnHeader17.Text = "Mac Address";
        this.columnHeader17.Width = 100;
        // 
        // columnHeader18
        // 
        this.columnHeader18.Text = "Rule Type";
        this.columnHeader18.Width = 180;
        // 
        // columnHeader19
        // 
        this.columnHeader19.Text = "Creation Time";
        this.columnHeader19.Width = 125;
        // 
        // button31
        // 
        this.button31.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button31.Location = new System.Drawing.Point(648, 311);
        this.button31.Name = "button31";
        this.button31.Size = new System.Drawing.Size(96, 23);
        this.button31.TabIndex = 35;
        this.button31.Text = "Clear";
        // 
        // button32
        // 
        this.button32.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button32.Location = new System.Drawing.Point(16, 311);
        this.button32.Name = "button32";
        this.button32.Size = new System.Drawing.Size(104, 24);
        this.button32.TabIndex = 32;
        this.button32.Text = "Add";
        // 
        // checkBox1
        // 
        this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox1.Location = new System.Drawing.Point(1085, 20);
        this.checkBox1.Name = "checkBox1";
        this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.checkBox1.Size = new System.Drawing.Size(168, 16);
        this.checkBox1.TabIndex = 34;
        this.checkBox1.Text = "Use Restrictions";
        this.checkBox1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        // 
        // button33
        // 
        this.button33.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button33.Location = new System.Drawing.Point(544, 311);
        this.button33.Name = "button33";
        this.button33.Size = new System.Drawing.Size(96, 23);
        this.button33.TabIndex = 33;
        this.button33.Text = "Remove";
        // 
        // button34
        // 
        this.button34.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button34.Location = new System.Drawing.Point(238, 699);
        this.button34.Name = "button34";
        this.button34.Size = new System.Drawing.Size(104, 23);
        this.button34.TabIndex = 3;
        this.button34.Text = "Details";
        // 
        // button38
        // 
        this.button38.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button38.Location = new System.Drawing.Point(128, 699);
        this.button38.Name = "button38";
        this.button38.Size = new System.Drawing.Size(104, 23);
        this.button38.TabIndex = 2;
        this.button38.Text = "Disconnect All";
        // 
        // button39
        // 
        this.button39.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button39.Location = new System.Drawing.Point(16, 699);
        this.button39.Name = "button39";
        this.button39.Size = new System.Drawing.Size(104, 23);
        this.button39.TabIndex = 1;
        this.button39.Text = "Disconnect";
        // 
        // button40
        // 
        this.button40.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button40.Location = new System.Drawing.Point(648, 312);
        this.button40.Name = "button40";
        this.button40.Size = new System.Drawing.Size(96, 23);
        this.button40.TabIndex = 21;
        this.button40.Text = "Clear";
        // 
        // button41
        // 
        this.button41.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button41.Location = new System.Drawing.Point(544, 312);
        this.button41.Name = "button41";
        this.button41.Size = new System.Drawing.Size(96, 23);
        this.button41.TabIndex = 20;
        this.button41.Text = "Remove";
        // 
        // button42
        // 
        this.button42.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button42.Location = new System.Drawing.Point(16, 312);
        this.button42.Name = "button42";
        this.button42.Size = new System.Drawing.Size(104, 24);
        this.button42.TabIndex = 15;
        this.button42.Text = "Add";
        // 
        // listView6
        // 
        this.listView6.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23});
        this.listView6.FullRowSelect = true;
        this.listView6.GridLines = true;
        this.listView6.HideSelection = false;
        this.listView6.Location = new System.Drawing.Point(16, 19);
        this.listView6.Name = "listView6";
        this.listView6.Size = new System.Drawing.Size(1237, 277);
        this.listView6.TabIndex = 14;
        this.listView6.UseCompatibleStateImageBehavior = false;
        this.listView6.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader20
        // 
        this.columnHeader20.Text = "    User";
        this.columnHeader20.Width = 120;
        // 
        // columnHeader21
        // 
        this.columnHeader21.Text = "Login";
        this.columnHeader21.Width = 100;
        // 
        // columnHeader22
        // 
        this.columnHeader22.Text = "Time of creation";
        this.columnHeader22.Width = 120;
        // 
        // columnHeader23
        // 
        this.columnHeader23.Text = "Status";
        this.columnHeader23.Width = 100;
        // 
        // button43
        // 
        this.button43.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button43.Location = new System.Drawing.Point(336, 312);
        this.button43.Name = "button43";
        this.button43.Size = new System.Drawing.Size(96, 23);
        this.button43.TabIndex = 18;
        this.button43.Text = "Disable";
        // 
        // button44
        // 
        this.button44.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button44.Location = new System.Drawing.Point(440, 312);
        this.button44.Name = "button44";
        this.button44.Size = new System.Drawing.Size(97, 23);
        this.button44.TabIndex = 19;
        this.button44.Text = "Enable";
        // 
        // button45
        // 
        this.button45.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button45.Location = new System.Drawing.Point(128, 312);
        this.button45.Name = "button45";
        this.button45.Size = new System.Drawing.Size(96, 23);
        this.button45.TabIndex = 16;
        this.button45.Text = "Edit";
        // 
        // button46
        // 
        this.button46.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button46.Location = new System.Drawing.Point(232, 312);
        this.button46.Name = "button46";
        this.button46.Size = new System.Drawing.Size(96, 23);
        this.button46.TabIndex = 17;
        this.button46.Text = "Vew";
        // 
        // label4
        // 
        this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label4.Location = new System.Drawing.Point(32, 29);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(144, 16);
        this.label4.TabIndex = 22;
        this.label4.Text = "List of users accounts:";
        // 
        // notifyIcon_Main
        // 
        this.notifyIcon_Main.Visible = true;
        // 
        // contextMenu_WindowParameters
        // 
        this.contextMenu_WindowParameters.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_MainWindowState_ActivateHiddenMode,
            this.menuItem_MainWindowState_MinimizeToNotifyArea,
            this.menuItem_MainWindowState_MinimizeToTaskBar});
        // 
        // menuItem_MainWindowState_ActivateHiddenMode
        // 
        this.menuItem_MainWindowState_ActivateHiddenMode.Index = 0;
        this.menuItem_MainWindowState_ActivateHiddenMode.Text = "Acivate Hidden Mode";
        this.menuItem_MainWindowState_ActivateHiddenMode.Click += new System.EventHandler(this.menuItem_MainWindowState_ActivateHiddenMode_Click);
        // 
        // menuItem_MainWindowState_MinimizeToNotifyArea
        // 
        this.menuItem_MainWindowState_MinimizeToNotifyArea.Index = 1;
        this.menuItem_MainWindowState_MinimizeToNotifyArea.Text = "Minimize to Notify Area";
        this.menuItem_MainWindowState_MinimizeToNotifyArea.Click += new System.EventHandler(this.menuItem_MainWindowState_MinimizeToNotifyArea_Click);
        // 
        // menuItem_MainWindowState_MinimizeToTaskBar
        // 
        this.menuItem_MainWindowState_MinimizeToTaskBar.Index = 2;
        this.menuItem_MainWindowState_MinimizeToTaskBar.Text = "Minimize to Task Bar";
        this.menuItem_MainWindowState_MinimizeToTaskBar.Click += new System.EventHandler(this.menuItem_MainWindowState_MinimizeToTaskBar_Click);
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(994, 695);
        this.Controls.Add(this.tabControl_Main);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Menu = this.mainMenu;
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "JurikSoft Connecting Service";
        this.Load += new System.EventHandler(this.MainForm_Load);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
        this.groupBox_Main_MainNetworkControl.ResumeLayout(false);
        this.groupBox_Main_MainNetworkControl.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Main_Control)).EndInit();
        this.groupBoxMain_ActiveInterConnections.ResumeLayout(false);
        this.tabControl_Main.ResumeLayout(false);
        this.tabPage_NetworkControl.ResumeLayout(false);
        this.groupBox_ActiveConnectionDetails_Statistic.ResumeLayout(false);
        this.groupBox_ActiveConnectionDetails_Statistic.PerformLayout();
        this.groupBox_Main_CommonStatistic.ResumeLayout(false);
        this.groupBox_Main_CommonStatistic.PerformLayout();
        this.tabPage_ConnectedObjects.ResumeLayout(false);
        this.groupBox_ConnectedUsers_ConnectedClients.ResumeLayout(false);
        this.groupBox_ConnectedClients_Details.ResumeLayout(false);
        this.groupBox_ConnectedClients_Details.PerformLayout();
        this.groupBox_ConnectedUsers_ConnectedServers.ResumeLayout(false);
        this.groupBox_ConnectedServers_Details.ResumeLayout(false);
        this.groupBox_ConnectedServers_Details.PerformLayout();
        this.tabPage_ClientsAccounts.ResumeLayout(false);
        this.groupBox_ClientsAccounts_RestrictionRules.ResumeLayout(false);
        this.groupBox_ClientsAccounts_Accounts.ResumeLayout(false);
        this.tabPage_ServersAccounts.ResumeLayout(false);
        this.groupBox_ServersAccounts_RestrictionRules.ResumeLayout(false);
        this.groupBox_ServersAccounts_Accounts.ResumeLayout(false);
        this.tabPage_EventsLogs.ResumeLayout(false);
        this.groupBox_EventsLog_SeversEventsLog.ResumeLayout(false);
        this.groupBox_EventsLog_ClientsEventsLog.ResumeLayout(false);
        this.groupBox_EventsLog_CommonEventsLog.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckBox checkBox_MainWindowParameters_ShowInNotifyArea;
    private System.Windows.Forms.Button button_Main_WindowParameters;
    private System.Windows.Forms.GroupBox groupBox_Main_MainNetworkControl;
    private System.Windows.Forms.TextBox textBox_Main_ListeningPort;
    private System.Windows.Forms.TextBox textBox_Main_ServerStatus;
    private System.Windows.Forms.Label label_Main_ServerPort;
    private System.Windows.Forms.Label label_Main_ServerStatus;
    private System.Windows.Forms.Button button_Main_StopServer;
    private System.Windows.Forms.Button button_MainForm_StartServer;
    private System.Windows.Forms.PictureBox pictureBox_Main_Control;
    private System.Windows.Forms.Button button_Main_AdditionalParameters;
    private System.Windows.Forms.GroupBox groupBoxMain_ActiveInterConnections;
    private System.Windows.Forms.Button button_ActiveInterConnections_DisconnectAll;
    private System.Windows.Forms.Button button_ActiveInterConnections_DisconnectInterConnection;
    private System.Windows.Forms.ListView listView_ActiveInterConnections_ConnectionsList;
    private System.Windows.Forms.ColumnHeader columnHeader_InterconnectionLists_ServerUIN;
    private System.Windows.Forms.ColumnHeader columnHeader_InterconnectionLists_ClientUIN;
    private System.Windows.Forms.TabControl tabControl_Main;
    private System.Windows.Forms.TabPage tabPage_NetworkControl;
    private System.Windows.Forms.TabPage tabPage_ConnectedObjects;
    private System.Windows.Forms.GroupBox groupBox_Main_CommonStatistic;
    private System.Windows.Forms.TextBox textBox_CommonStatistic_ActiveConnections;
    private System.Windows.Forms.Label label_CommonStatistic_Connections;
    private System.Windows.Forms.TextBox textBox_CommonStatistic_LastConnectionAt;
    private System.Windows.Forms.TextBox textBox_CommonStatistic_BytesReceived;
    private System.Windows.Forms.TextBox textBox_CommonStatistic_BytesSent;
    private System.Windows.Forms.Label label_CommonStatistic_LastConnectionAt;
    private System.Windows.Forms.Label label_CommonStatistic_BytesReceived;
    private System.Windows.Forms.Label label_CommonStatistic_BytesSent;
    private System.Windows.Forms.GroupBox groupBox_ConnectedUsers_ConnectedServers;
    private System.Windows.Forms.Button button_ConnectedServers_DisconnectAll;
    private System.Windows.Forms.Button button_ConnectedServers_DisconnectServer;
    private System.Windows.Forms.TabPage tabPage_ClientsAccounts;
    private System.Windows.Forms.Button button_ClientsAccounts_ViewAccount;
    private System.Windows.Forms.Button button_ClientsAccounts_ClearAccountsList;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button_ClientsAccounts_EditAccount;
    private System.Windows.Forms.Button button_ClientsAccounts_EnableAccount;
    private System.Windows.Forms.Button button_ClientsAccounts_DisableAccount;
    private System.Windows.Forms.ListView listView_ClientsAccounts_ClientsAccounts;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsAccounts_User;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsAccounts_UIN;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsAccounts_CreationTime;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsAccounts_Status;
    private System.Windows.Forms.Button button_ClientsAccounts_AddAccount;
    private System.Windows.Forms.Button button_ClientsAccounts_RemoveAccount;
    private System.Windows.Forms.TabPage tabPage_ServersAccounts;
    private System.Windows.Forms.Button button_Security_ViewClientAccount;
    private System.Windows.Forms.Button button_Security_ClearClientAccounts;
    private System.Windows.Forms.Label label_Security_ListOfUsersAccounts;
    private System.Windows.Forms.Button button_Security_EditClientAccount;
    private System.Windows.Forms.Button button_Security_EnableClientAccount;
    private System.Windows.Forms.Button button_Security_DisableClientAccount;
    private System.Windows.Forms.ListView listView_Security_ListOfUsersAccounts;
    private System.Windows.Forms.ColumnHeader columnHeader_UsersDatabase_User;
    private System.Windows.Forms.ColumnHeader columnHeader_UsersDatabase_Login;
    private System.Windows.Forms.ColumnHeader columnHeader_UsersDatabase_TimeOfCreation;
    private System.Windows.Forms.ColumnHeader columnHeader_UsersDatabase_AccountStatus;
    private System.Windows.Forms.Button button_Security_AddNewUser;
    private System.Windows.Forms.Button button_Security_RemoveClientAccount;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button9;
    private System.Windows.Forms.Button button10;
    private System.Windows.Forms.Button button11;
    private System.Windows.Forms.ListView listView3;
    private System.Windows.Forms.ColumnHeader columnHeader7;
    private System.Windows.Forms.ColumnHeader columnHeader8;
    private System.Windows.Forms.ColumnHeader columnHeader9;
    private System.Windows.Forms.ColumnHeader columnHeader10;
    private System.Windows.Forms.Button button12;
    private System.Windows.Forms.Button button13;
    private System.Windows.Forms.TabPage tabPage_EventsLogs;
    private System.Windows.Forms.MainMenu mainMenu;
    private System.Windows.Forms.MenuItem menuItem_File;
    private System.Windows.Forms.MenuItem menuItem_File_Import;
    private System.Windows.Forms.MenuItem menuItem_File_Import_SettingsDatabase;
    private System.Windows.Forms.MenuItem menuItem_File_Export;
    private System.Windows.Forms.MenuItem menuItem_File_Export_SettingsDatabase;
    private System.Windows.Forms.MenuItem menuItem_File_Exit;
    private System.Windows.Forms.MenuItem menuItem_Options;
    private System.Windows.Forms.MenuItem menuItem_Options_Settings;
    private System.Windows.Forms.MenuItem menuItem_Help;
    private System.Windows.Forms.MenuItem menuItem_Help_About;
    private System.Windows.Forms.ColumnHeader columnHeader_InterconnectionLists_ServerIP;
    private System.Windows.Forms.ColumnHeader columnHeader_InterconnectionLists_ClientIP;
    private System.Windows.Forms.GroupBox groupBox_ClientsAccounts_Accounts;
    private System.Windows.Forms.GroupBox groupBox_EventsLog_CommonEventsLog;
    private System.Windows.Forms.Button button24;
    private System.Windows.Forms.Button button25;
    private System.Windows.Forms.Button button26;
    private System.Windows.Forms.Label label_CommonEventsLog_Events;
    private System.Windows.Forms.GroupBox groupBox_ClientsAccounts_RestrictionRules;
    private System.Windows.Forms.Button button_ClientsRestrictionRules_ViewRule;
    private System.Windows.Forms.Button button_ClientsRestrictionRules_EnableRule;
    private System.Windows.Forms.Button button51;
    private System.Windows.Forms.Button button_ClientsRestrictionRules_DisableRule;
    private System.Windows.Forms.Label label_ClientsRestrictionRules_RestrictionRules;
    private System.Windows.Forms.Button button_ClientsRestrictionRules_EditRule;
    private System.Windows.Forms.ListView listView_ClientsRestrictionRules_RulestList;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsRestrictionRules_IPRange;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsRestrictionRules_IPAddress;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsRestrictionRules_MACAddress;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsRestrictionRules_RuleType;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsRestrictionRules_CreationTime;
    private System.Windows.Forms.Button button_ClientsRestrictionRules_ClearRulesList;
    private System.Windows.Forms.Button button_ClientsRestrictionRules_AddRule;
    private System.Windows.Forms.CheckBox checkBox_ClientsRestrictionRules_UseRestrictionRules;
    private System.Windows.Forms.Button button_ClientsRestrictionRules_RemoveRule;
    private System.Windows.Forms.GroupBox groupBox_ConnectedUsers_ConnectedClients;
    private System.Windows.Forms.Button button_ConnectedClients_DisconnectAll;
    private System.Windows.Forms.Button button_ConnectedClients_DisconnectClient;
    private System.Windows.Forms.ListView listView_ConnectedUsers_ConnectedClients;
    private System.Windows.Forms.ColumnHeader columnHeader_ConnectedClients_ClientUIN;
    private System.Windows.Forms.ColumnHeader columnHeader_ConnectedClients_UserName;
    private System.Windows.Forms.ColumnHeader columnHeader_ConnectedClients_ClientIP;
    private System.Windows.Forms.ColumnHeader columnHeader_InterconnectionLists_ConnectedAt;
    private System.Windows.Forms.ColumnHeader columnHeader_ConnectedClients_ConnectedAt;
    private System.Windows.Forms.Button button21;
    private System.Windows.Forms.Button button22;
    private System.Windows.Forms.Button button23;
    private System.Windows.Forms.Button button27;
    private System.Windows.Forms.Button button28;
    private System.Windows.Forms.Button button29;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button30;
    private System.Windows.Forms.ListView listView5;
    private System.Windows.Forms.ColumnHeader columnHeader15;
    private System.Windows.Forms.ColumnHeader columnHeader16;
    private System.Windows.Forms.ColumnHeader columnHeader17;
    private System.Windows.Forms.ColumnHeader columnHeader18;
    private System.Windows.Forms.ColumnHeader columnHeader19;
    private System.Windows.Forms.Button button31;
    private System.Windows.Forms.Button button32;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.Button button33;
    private System.Windows.Forms.Button button34;
    private System.Windows.Forms.Button button38;
    private System.Windows.Forms.Button button39;
    private System.Windows.Forms.Button button40;
    private System.Windows.Forms.Button button41;
    private System.Windows.Forms.Button button42;
    private System.Windows.Forms.ListView listView6;
    private System.Windows.Forms.ColumnHeader columnHeader20;
    private System.Windows.Forms.ColumnHeader columnHeader21;
    private System.Windows.Forms.ColumnHeader columnHeader22;
    private System.Windows.Forms.ColumnHeader columnHeader23;
    private System.Windows.Forms.Button button43;
    private System.Windows.Forms.Button button44;
    private System.Windows.Forms.Button button45;
    private System.Windows.Forms.Button button46;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.GroupBox groupBox_ActiveConnectionDetails_Statistic;
    private System.Windows.Forms.TextBox textBox_ActiveConnectionDetails_ClientBytesReceived;
    private System.Windows.Forms.TextBox textBox_ActiveConnectionDetails_ClientBytesSent;
    private System.Windows.Forms.Label label_ActiveConnectionDetails_ClientBytesReceived;
    private System.Windows.Forms.Label label_ActiveConnectionDetails_ClientBytesSent;
    private System.Windows.Forms.ListView listView_ConnectedUsers_ConnectedServers;
    private System.Windows.Forms.ColumnHeader columnHeader_ConnectedServers_ServerUIN;
    private System.Windows.Forms.ColumnHeader columnHeader_ConnectedServers_UserName;
    private System.Windows.Forms.ColumnHeader columnHeader_ConnectedServers_ServerIP;
    private System.Windows.Forms.ColumnHeader columnHeader_ConnectedServers_ConnectedAt;
    private System.Windows.Forms.ColumnHeader columnHeader_ConnectedClients_Status;
    private System.Windows.Forms.ColumnHeader columnHeader_ConnectedServers_Status;
    private System.Windows.Forms.GroupBox groupBox_ConnectedClients_Details;
    private System.Windows.Forms.TextBox textBox_ClientDetails_MACAddress;
    private System.Windows.Forms.TextBox textBox_ClientDetails_ConnectedAt;
    private System.Windows.Forms.TextBox textBox_ClientDetails_IPAddress;
    private System.Windows.Forms.TextBox textBox_ClientDetails_BytesReceived;
    private System.Windows.Forms.Label label_ClientDetails_IPAddress;
    private System.Windows.Forms.TextBox textBox_ClientDetails_BytesSent;
    private System.Windows.Forms.Label label_ClientDetails_MACAddress;
    private System.Windows.Forms.Label label_ClientDetails_CannectedAt;
    private System.Windows.Forms.Label label_ClientDetails_BytesReceived;
    private System.Windows.Forms.Label label_ClientDetails_BytesSent;
    private System.Windows.Forms.GroupBox groupBox_ConnectedServers_Details;
    private System.Windows.Forms.TextBox textBox_ServerDetails_MACAddress;
    private System.Windows.Forms.TextBox textBox_ServerDetails_ConnectedAt;
    private System.Windows.Forms.TextBox textBox_ServerDetails_IPAddress;
    private System.Windows.Forms.TextBox textBox_ServerDetails_BytesReceived;
    private System.Windows.Forms.Label label_ServerDetails_IPAddress;
    private System.Windows.Forms.TextBox textBox_ServerDetails_BytesSent;
    private System.Windows.Forms.Label label_ServerDetails_MACAddress;
    private System.Windows.Forms.Label label_ServerDetails_CannectedAt;
    private System.Windows.Forms.Label label_ServerDetails_BytesReceived;
    private System.Windows.Forms.Label label_ServerDetails_BytesSent;
    private System.Windows.Forms.GroupBox groupBox_EventsLog_SeversEventsLog;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.Label label_ServersEventsLog_Events;
    private System.Windows.Forms.GroupBox groupBox_EventsLog_ClientsEventsLog;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Label label_ClientsEventsLog_Events;
    private System.Windows.Forms.GroupBox groupBox_ServersAccounts_RestrictionRules;
    private System.Windows.Forms.Button button57;
    private System.Windows.Forms.Button button_ServersRestrictionRules_ViewRule;
    private System.Windows.Forms.Button button59;
    private System.Windows.Forms.Button button_ServersRestrictionRules_EnableRule;
    private System.Windows.Forms.Button button61;
    private System.Windows.Forms.Button button_ServersRestrictionRules_DisableRule;
    private System.Windows.Forms.Label label_ServersRestrictionRules_RestrictionRules;
    private System.Windows.Forms.Button button_ServersRestrictionRules_EditRule;
    private System.Windows.Forms.Button button_ServersRestrictionRules_ClearRulesList;
    private System.Windows.Forms.Button button_ServersRestrictionRules_AddRule;
    private System.Windows.Forms.CheckBox checkBox_ServersRestrictionRules_UseRestrictionRules;
    private System.Windows.Forms.Button button_ServersRestrictionRules_RemoveRule;
    private System.Windows.Forms.GroupBox groupBox_ServersAccounts_Accounts;
    private System.Windows.Forms.Button button67;
    private System.Windows.Forms.Button button68;
    private System.Windows.Forms.Button button69;
    private System.Windows.Forms.Button button_ServersAccounts_ClearAccountsList;
    private System.Windows.Forms.Button button_ServersAccounts_RemoveAccount;
    private System.Windows.Forms.Button button_ServersAccounts_AddAccount;
    private System.Windows.Forms.ListView listView_ServersAccounts_ServersAccounts;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersAccounts_User;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersAccounts_UIN;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersAccounts_CreationTime;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersAccounts_Status;
    private System.Windows.Forms.Button button_ServersAccounts_DisableAccount;
    private System.Windows.Forms.Button button_ServersAccounts_EnableAccount;
    private System.Windows.Forms.Button button_ServersAccounts_EditAccount;
    private System.Windows.Forms.Button button_ServersAccounts_ViewAccount;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsRestrictionRules_RuleStatus;
    private System.Windows.Forms.ListView listView_ServersRestrictionRules_RulestList;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersRestrictionRules_IPRange;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersRestrictionRules_IPAddress;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersRestrictionRules_MACAddress;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersRestrictionRules_RuleType;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersRestrictionRules_CreationTime;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersRestrictionRules_RuleStatus;
    private System.Windows.Forms.ListView listView_CommonEventsLog_LogList;
    private System.Windows.Forms.ColumnHeader columnHeader_CommonEventsLogList_RecordTime;
    private System.Windows.Forms.ColumnHeader columnHeader_CommonEventsLogList_EventType;
    public System.Windows.Forms.NotifyIcon notifyIcon_Main;
    private System.Windows.Forms.ContextMenu contextMenu_WindowParameters;
    private System.Windows.Forms.MenuItem menuItem_MainWindowState_ActivateHiddenMode;
    private System.Windows.Forms.MenuItem menuItem_MainWindowState_MinimizeToNotifyArea;
    private System.Windows.Forms.MenuItem menuItem_MainWindowState_MinimizeToTaskBar;
    private System.Windows.Forms.Button button_ActiveInterConnections_SwitchToServer;
    private System.Windows.Forms.Button button_ActiveInterConnections_SwitchToClient;
    private System.Windows.Forms.TextBox textBox_ActiveConnectionDetails_ServerBytesReceived;
    private System.Windows.Forms.TextBox textBox_ActiveConnectionDetails_ServerBytesSent;
    private System.Windows.Forms.Label label_ActiveConnectionDetails_ServerBytesReceived;
    private System.Windows.Forms.Label label_ActiveConnectionDetails_ServerBytesSent;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsAccounts_ActivationCode;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersAccounts_ActivationCode;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsAccounts_ActivationTime;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersAccounts_ActivationTime;
    private System.Windows.Forms.Button button_ClientsAccounts_ActivateAccount;
    private System.Windows.Forms.Button button_ServersAccounts_ActivateAccount;
    private System.Windows.Forms.Button button_ServersEventsLog_ClearLog;
    private System.Windows.Forms.Button button_ClientsEventsLog_ClearLog;
    private System.Windows.Forms.Button button_CommonEventsLog_ClearLog;
    private System.Windows.Forms.ListView listView_ServersEventsLog_LogList;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersEventsLog_UserName;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersEventsLog_UIN;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersEventsLog_RecordTime;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersEventsLog_EventType;
    private System.Windows.Forms.ColumnHeader columnHeader_ServersEventsLog_EventInformation;
    private System.Windows.Forms.ListView listView_ClientsEventsLog_LogList;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsEventsLog_UserName;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsEventsLog_UIN;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsEventsLog_RecordTime;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsEventsLog_EventType;
    private System.Windows.Forms.ColumnHeader columnHeader_ClientsEventsLog_EventInformation;
    private System.Windows.Forms.ColumnHeader columnHeader_CommonEventsLogList_EventInformation;
    private System.Windows.Forms.Button button_ServersEventsLog_SaveLog;
    private System.Windows.Forms.Button button_ClientsEventsLog_SaveLog;
    private System.Windows.Forms.Button button_CommonEventsLog_SaveLog;
}

