using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Data;
using System.Threading;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using YakSys.RCTServiceGUI;
using YakSys.Server_Core;
using System.ServiceProcess.Design;

public class MainServerForm : System.Windows.Forms.Form
{
    public static NotifyIcon notifyIcon_Main = new NotifyIcon();

    private System.Windows.Forms.TabControl tabControl_Main;
    private System.Windows.Forms.TabPage tabPage_Security;
    private System.Windows.Forms.TabPage tabPage_Log;
    private System.Windows.Forms.Button button_Main_StartServer;
    private System.Windows.Forms.Button button_Main_StopServer;
    private System.Windows.Forms.Label label_Main_ServerStatus;
    private System.Windows.Forms.Label label_Main_ServerPort;
    private System.Windows.Forms.TextBox textBox_Main_ListeningPort;
    private System.Windows.Forms.TextBox textBox_Main_ServerStatus;
    private System.Windows.Forms.GroupBox groupBox_Main_MainNetworkControl;
    private System.Windows.Forms.ColumnHeader columnHeader_Type;
    private System.Windows.Forms.ColumnHeader columnHeader_Date;
    private System.Windows.Forms.ColumnHeader columnHeader_Time;
    private System.Windows.Forms.ColumnHeader columnHeader_Source;
    private System.Windows.Forms.ColumnHeader columnHeader_Description;
    private System.Windows.Forms.MainMenu mainMenu;
    private System.Windows.Forms.MenuItem menuItem_Help;
    private System.Windows.Forms.MenuItem menuItem_Help_About;
    private System.Windows.Forms.MenuItem menuItem_SaveLog;
    private System.Windows.Forms.MenuItem menuItem_ClearLog;
    private System.Windows.Forms.MenuItem menuItem_Log;
    private System.Windows.Forms.TabPage tabPage_NetworkControl;
    private System.Windows.Forms.Button button_Security_EditUserAccount;
    private System.Windows.Forms.Button button_Security_EnableUserAccount;
    private System.Windows.Forms.Button button_Security_DisableUserAccount;
    private System.Windows.Forms.ListView listView_Security_ListOfUsersAccounts;
    private System.Windows.Forms.Button button_Security_RemoveUserAccount;
    private System.Windows.Forms.ImageList imageList_IconsOfSecurilyList;
    private System.Windows.Forms.MenuItem menuItem_Options;
    private System.Windows.Forms.MenuItem menuItem_Options_Settings;
    private System.Windows.Forms.MenuItem menuItem_Help_Register;
    private System.Windows.Forms.Label label_Log_Events;
    private System.Windows.Forms.Button button_Security_AddNewUser;
    private System.Windows.Forms.ColumnHeader columnHeader_UsersDatabase_User;
    private System.Windows.Forms.ColumnHeader columnHeader_UsersDatabase_Login;
    private System.Windows.Forms.ColumnHeader columnHeader_UsersDatabase_TimeOfCreation;
    private System.Windows.Forms.ColumnHeader columnHeader_UsersDatabase_AccountStatus;
    private System.Windows.Forms.Button button_Security_ViewUserAccount;
    private System.Windows.Forms.Button button_Security_ClearUserAccounts;
    private System.Windows.Forms.Label label_Security_ListOfUsersAccounts;
    private System.Windows.Forms.ListView listView_MainServerForm_EventsLog;
    private System.Windows.Forms.ImageList imageList_CommonIcons;
    private System.Windows.Forms.MenuItem menuItem_File;
    private System.Windows.Forms.MenuItem menuItem_File_Exit;
    private System.Windows.Forms.MenuItem menuItem_File_Import;
    private System.Windows.Forms.MenuItem menuItem_File_Import_SettingsDatabase;
    private System.Windows.Forms.MenuItem menuItem_File_Export;
    private System.Windows.Forms.MenuItem menuItem_File_Export_SettingsDatabase;
    private System.Windows.Forms.TabPage tabPage_AccessRestrictions;
    private System.Windows.Forms.ColumnHeader columnHeader_AccessRestrictions_IPRange;
    private System.Windows.Forms.ColumnHeader columnHeader_AccessRestrictions_RuleType;
    private System.Windows.Forms.ColumnHeader columnHeader_AccessRestrictions_IPAddress;
    private System.Windows.Forms.ColumnHeader columnHeader_AccessRestrictions_MACAddress;
    private System.Windows.Forms.Button button_AccessRestrictions_EditRestriction;
    private System.Windows.Forms.Button button_AccessRestrictions_ClearRestrictions;
    private System.Windows.Forms.Button button_AccessRestrictions_RemoveRestriction;
    private System.Windows.Forms.Button button_AccessRestrictions_AddRestriction;
    private System.Windows.Forms.ListView listView_AccessRestrictions_AccessRestrictionRulesList;
    private System.Windows.Forms.Label label_AccessRestrictions_ListOfAccessRestrictionsRules;
    private System.Windows.Forms.CheckBox checkBox_AccessRestrictions_EnableAccessRestrictions;
    private System.Windows.Forms.Button button_CurrentConnections_DisconnectAll;
    private System.Windows.Forms.Button button_CurrentConnections_Disconnect;
    private System.Windows.Forms.ColumnHeader columnHeader_CurrentConnections_User;
    private System.Windows.Forms.ColumnHeader columnHeader_CurrentConnections_IPAddress;
    private System.Windows.Forms.ColumnHeader columnHeader_CurrentConnections_Status;
    private System.Windows.Forms.Button button_CurrentConnections_Details;
    private System.Windows.Forms.GroupBox groupBox_Main_ActiveConnections;
    private System.Windows.Forms.ImageList imageList_IconsOfActiveConnections;
    private System.Windows.Forms.ListView listView_ActiveConnections_CurrentConnections;
    private System.Windows.Forms.ColumnHeader columnHeader_AccessRestrictions_CreationTime;
    private System.Windows.Forms.ImageList imageList_IconsOfRestrictionRulesList;
    private System.Windows.Forms.Button button_AccessRestrictions_ViewRestriction;
    private System.Windows.Forms.Button button_AccessRestrictions_EnableRestriction;
    private System.Windows.Forms.Button button_AccessRestrictions_DisableRestriction;
    private System.Windows.Forms.Button button_Main_AdditionalParameters;
    private System.Windows.Forms.CheckBox checkBox_MainWindowParameters_ShowInNotifyArea;
    private CheckBox checkBox_Security_AllowWindowsAuthentication;
    private StatusBar statusBar_Main;
    private StatusBarPanel statusBarPanel_BytesSent;
    private StatusBarPanel statusBarPanel_BytesReceived;
    private StatusBarPanel statusBarPanel_LastConnectionTime;
    private StatusBarPanel statusBarPanel_Connections;
    private ColumnHeader columnHeader_AccountType;
    private Button button_MainWindowParameters_MinimizeToNotifyArea;
    private Button button_Main_ConnectingService;
    private System.ComponentModel.IContainer components;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }


    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainServerForm));
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_NetworkControl = new System.Windows.Forms.TabPage();
            this.button_MainWindowParameters_MinimizeToNotifyArea = new System.Windows.Forms.Button();
            this.checkBox_MainWindowParameters_ShowInNotifyArea = new System.Windows.Forms.CheckBox();
            this.groupBox_Main_ActiveConnections = new System.Windows.Forms.GroupBox();
            this.button_CurrentConnections_Details = new System.Windows.Forms.Button();
            this.button_CurrentConnections_DisconnectAll = new System.Windows.Forms.Button();
            this.button_CurrentConnections_Disconnect = new System.Windows.Forms.Button();
            this.listView_ActiveConnections_CurrentConnections = new System.Windows.Forms.ListView();
            this.columnHeader_CurrentConnections_User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_CurrentConnections_IPAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_CurrentConnections_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_AccountType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_IconsOfActiveConnections = new System.Windows.Forms.ImageList(this.components);
            this.groupBox_Main_MainNetworkControl = new System.Windows.Forms.GroupBox();
            this.button_Main_ConnectingService = new System.Windows.Forms.Button();
            this.textBox_Main_ListeningPort = new System.Windows.Forms.TextBox();
            this.textBox_Main_ServerStatus = new System.Windows.Forms.TextBox();
            this.label_Main_ServerPort = new System.Windows.Forms.Label();
            this.label_Main_ServerStatus = new System.Windows.Forms.Label();
            this.button_Main_StopServer = new System.Windows.Forms.Button();
            this.button_Main_StartServer = new System.Windows.Forms.Button();
            this.button_Main_AdditionalParameters = new System.Windows.Forms.Button();
            this.tabPage_Security = new System.Windows.Forms.TabPage();
            this.checkBox_Security_AllowWindowsAuthentication = new System.Windows.Forms.CheckBox();
            this.button_Security_ViewUserAccount = new System.Windows.Forms.Button();
            this.button_Security_ClearUserAccounts = new System.Windows.Forms.Button();
            this.label_Security_ListOfUsersAccounts = new System.Windows.Forms.Label();
            this.button_Security_EditUserAccount = new System.Windows.Forms.Button();
            this.button_Security_EnableUserAccount = new System.Windows.Forms.Button();
            this.button_Security_DisableUserAccount = new System.Windows.Forms.Button();
            this.listView_Security_ListOfUsersAccounts = new System.Windows.Forms.ListView();
            this.columnHeader_UsersDatabase_User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_UsersDatabase_Login = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_UsersDatabase_TimeOfCreation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_UsersDatabase_AccountStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_IconsOfSecurilyList = new System.Windows.Forms.ImageList(this.components);
            this.button_Security_AddNewUser = new System.Windows.Forms.Button();
            this.button_Security_RemoveUserAccount = new System.Windows.Forms.Button();
            this.tabPage_AccessRestrictions = new System.Windows.Forms.TabPage();
            this.button_AccessRestrictions_ViewRestriction = new System.Windows.Forms.Button();
            this.button_AccessRestrictions_EnableRestriction = new System.Windows.Forms.Button();
            this.button_AccessRestrictions_DisableRestriction = new System.Windows.Forms.Button();
            this.button_AccessRestrictions_EditRestriction = new System.Windows.Forms.Button();
            this.button_AccessRestrictions_ClearRestrictions = new System.Windows.Forms.Button();
            this.checkBox_AccessRestrictions_EnableAccessRestrictions = new System.Windows.Forms.CheckBox();
            this.button_AccessRestrictions_RemoveRestriction = new System.Windows.Forms.Button();
            this.button_AccessRestrictions_AddRestriction = new System.Windows.Forms.Button();
            this.label_AccessRestrictions_ListOfAccessRestrictionsRules = new System.Windows.Forms.Label();
            this.listView_AccessRestrictions_AccessRestrictionRulesList = new System.Windows.Forms.ListView();
            this.columnHeader_AccessRestrictions_IPRange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_AccessRestrictions_IPAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_AccessRestrictions_MACAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_AccessRestrictions_RuleType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_AccessRestrictions_CreationTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_IconsOfRestrictionRulesList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage_Log = new System.Windows.Forms.TabPage();
            this.label_Log_Events = new System.Windows.Forms.Label();
            this.listView_MainServerForm_EventsLog = new System.Windows.Forms.ListView();
            this.columnHeader_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_CommonIcons = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem_File = new System.Windows.Forms.MenuItem();
            this.menuItem_File_Import = new System.Windows.Forms.MenuItem();
            this.menuItem_File_Import_SettingsDatabase = new System.Windows.Forms.MenuItem();
            this.menuItem_File_Export = new System.Windows.Forms.MenuItem();
            this.menuItem_File_Export_SettingsDatabase = new System.Windows.Forms.MenuItem();
            this.menuItem_File_Exit = new System.Windows.Forms.MenuItem();
            this.menuItem_Log = new System.Windows.Forms.MenuItem();
            this.menuItem_SaveLog = new System.Windows.Forms.MenuItem();
            this.menuItem_ClearLog = new System.Windows.Forms.MenuItem();
            this.menuItem_Options = new System.Windows.Forms.MenuItem();
            this.menuItem_Options_Settings = new System.Windows.Forms.MenuItem();
            this.menuItem_Help = new System.Windows.Forms.MenuItem();
            this.menuItem_Help_About = new System.Windows.Forms.MenuItem();
            this.menuItem_Help_Register = new System.Windows.Forms.MenuItem();
            this.statusBar_Main = new System.Windows.Forms.StatusBar();
            this.statusBarPanel_BytesSent = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_BytesReceived = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_Connections = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel_LastConnectionTime = new System.Windows.Forms.StatusBarPanel();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_NetworkControl.SuspendLayout();
            this.groupBox_Main_ActiveConnections.SuspendLayout();
            this.groupBox_Main_MainNetworkControl.SuspendLayout();
            this.tabPage_Security.SuspendLayout();
            this.tabPage_AccessRestrictions.SuspendLayout();
            this.tabPage_Log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_BytesSent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_BytesReceived)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_Connections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_LastConnectionTime)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_NetworkControl);
            this.tabControl_Main.Controls.Add(this.tabPage_Security);
            this.tabControl_Main.Controls.Add(this.tabPage_AccessRestrictions);
            this.tabControl_Main.Controls.Add(this.tabPage_Log);
            this.tabControl_Main.Location = new System.Drawing.Point(8, 4);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(768, 271);
            this.tabControl_Main.TabIndex = 7;
            this.tabControl_Main.SelectedIndexChanged += new System.EventHandler(this.tabControl_Main_SelectedIndexChanged);
            // 
            // tabPage_NetworkControl
            // 
            this.tabPage_NetworkControl.Controls.Add(this.button_MainWindowParameters_MinimizeToNotifyArea);
            this.tabPage_NetworkControl.Controls.Add(this.checkBox_MainWindowParameters_ShowInNotifyArea);
            this.tabPage_NetworkControl.Controls.Add(this.groupBox_Main_ActiveConnections);
            this.tabPage_NetworkControl.Controls.Add(this.groupBox_Main_MainNetworkControl);
            this.tabPage_NetworkControl.Location = new System.Drawing.Point(4, 22);
            this.tabPage_NetworkControl.Name = "tabPage_NetworkControl";
            this.tabPage_NetworkControl.Size = new System.Drawing.Size(760, 245);
            this.tabPage_NetworkControl.TabIndex = 0;
            this.tabPage_NetworkControl.Text = "Network Control";
            // 
            // button_MainWindowParameters_MinimizeToNotifyArea
            // 
            this.button_MainWindowParameters_MinimizeToNotifyArea.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_MainWindowParameters_MinimizeToNotifyArea.Location = new System.Drawing.Point(8, 189);
            this.button_MainWindowParameters_MinimizeToNotifyArea.Name = "button_MainWindowParameters_MinimizeToNotifyArea";
            this.button_MainWindowParameters_MinimizeToNotifyArea.Size = new System.Drawing.Size(208, 23);
            this.button_MainWindowParameters_MinimizeToNotifyArea.TabIndex = 11;
            this.button_MainWindowParameters_MinimizeToNotifyArea.Text = "Minimize to Notify Area";
            this.button_MainWindowParameters_MinimizeToNotifyArea.Click += new System.EventHandler(this.button_MainWindowParameters_MinimizeToNotifyArea_Click);
            // 
            // checkBox_MainWindowParameters_ShowInNotifyArea
            // 
            this.checkBox_MainWindowParameters_ShowInNotifyArea.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_MainWindowParameters_ShowInNotifyArea.Location = new System.Drawing.Point(24, 221);
            this.checkBox_MainWindowParameters_ShowInNotifyArea.Name = "checkBox_MainWindowParameters_ShowInNotifyArea";
            this.checkBox_MainWindowParameters_ShowInNotifyArea.Size = new System.Drawing.Size(184, 16);
            this.checkBox_MainWindowParameters_ShowInNotifyArea.TabIndex = 10;
            this.checkBox_MainWindowParameters_ShowInNotifyArea.Text = "Show in Notify Area";
            this.checkBox_MainWindowParameters_ShowInNotifyArea.CheckedChanged += new System.EventHandler(this.checkBox_MainWindowParameters_ShowInNotifyArea_CheckedChanged);
            // 
            // groupBox_Main_ActiveConnections
            // 
            this.groupBox_Main_ActiveConnections.Controls.Add(this.button_CurrentConnections_Details);
            this.groupBox_Main_ActiveConnections.Controls.Add(this.button_CurrentConnections_DisconnectAll);
            this.groupBox_Main_ActiveConnections.Controls.Add(this.button_CurrentConnections_Disconnect);
            this.groupBox_Main_ActiveConnections.Controls.Add(this.listView_ActiveConnections_CurrentConnections);
            this.groupBox_Main_ActiveConnections.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_Main_ActiveConnections.Location = new System.Drawing.Point(224, 16);
            this.groupBox_Main_ActiveConnections.Name = "groupBox_Main_ActiveConnections";
            this.groupBox_Main_ActiveConnections.Size = new System.Drawing.Size(523, 216);
            this.groupBox_Main_ActiveConnections.TabIndex = 7;
            this.groupBox_Main_ActiveConnections.TabStop = false;
            this.groupBox_Main_ActiveConnections.Text = "Active Connections";
            // 
            // button_CurrentConnections_Details
            // 
            this.button_CurrentConnections_Details.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_CurrentConnections_Details.Location = new System.Drawing.Point(238, 184);
            this.button_CurrentConnections_Details.Name = "button_CurrentConnections_Details";
            this.button_CurrentConnections_Details.Size = new System.Drawing.Size(104, 23);
            this.button_CurrentConnections_Details.TabIndex = 3;
            this.button_CurrentConnections_Details.Text = "Details";
            this.button_CurrentConnections_Details.Click += new System.EventHandler(this.button_CurrentConnections_Details_Click);
            // 
            // button_CurrentConnections_DisconnectAll
            // 
            this.button_CurrentConnections_DisconnectAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_CurrentConnections_DisconnectAll.Location = new System.Drawing.Point(128, 184);
            this.button_CurrentConnections_DisconnectAll.Name = "button_CurrentConnections_DisconnectAll";
            this.button_CurrentConnections_DisconnectAll.Size = new System.Drawing.Size(104, 23);
            this.button_CurrentConnections_DisconnectAll.TabIndex = 2;
            this.button_CurrentConnections_DisconnectAll.Text = "Disconnect All";
            this.button_CurrentConnections_DisconnectAll.Click += new System.EventHandler(this.button_CurrentConnections_DisconnectAll_Click);
            // 
            // button_CurrentConnections_Disconnect
            // 
            this.button_CurrentConnections_Disconnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_CurrentConnections_Disconnect.Location = new System.Drawing.Point(16, 184);
            this.button_CurrentConnections_Disconnect.Name = "button_CurrentConnections_Disconnect";
            this.button_CurrentConnections_Disconnect.Size = new System.Drawing.Size(104, 23);
            this.button_CurrentConnections_Disconnect.TabIndex = 1;
            this.button_CurrentConnections_Disconnect.Text = "Disconnect";
            this.button_CurrentConnections_Disconnect.Click += new System.EventHandler(this.button_CurrentConnections_Disconnect_Click);
            // 
            // listView_ActiveConnections_CurrentConnections
            // 
            this.listView_ActiveConnections_CurrentConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_CurrentConnections_User,
            this.columnHeader_CurrentConnections_IPAddress,
            this.columnHeader_CurrentConnections_Status,
            this.columnHeader_AccountType});
            this.listView_ActiveConnections_CurrentConnections.FullRowSelect = true;
            this.listView_ActiveConnections_CurrentConnections.GridLines = true;
            this.listView_ActiveConnections_CurrentConnections.HideSelection = false;
            this.listView_ActiveConnections_CurrentConnections.HoverSelection = true;
            this.listView_ActiveConnections_CurrentConnections.Location = new System.Drawing.Point(16, 24);
            this.listView_ActiveConnections_CurrentConnections.Name = "listView_ActiveConnections_CurrentConnections";
            this.listView_ActiveConnections_CurrentConnections.Size = new System.Drawing.Size(490, 152);
            this.listView_ActiveConnections_CurrentConnections.SmallImageList = this.imageList_IconsOfActiveConnections;
            this.listView_ActiveConnections_CurrentConnections.TabIndex = 0;
            this.listView_ActiveConnections_CurrentConnections.UseCompatibleStateImageBehavior = false;
            this.listView_ActiveConnections_CurrentConnections.View = System.Windows.Forms.View.Details;
            this.listView_ActiveConnections_CurrentConnections.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ActiveConnections_CurrentConnections_ColumnClick);
            // 
            // columnHeader_CurrentConnections_User
            // 
            this.columnHeader_CurrentConnections_User.Text = "User";
            this.columnHeader_CurrentConnections_User.Width = 100;
            // 
            // columnHeader_CurrentConnections_IPAddress
            // 
            this.columnHeader_CurrentConnections_IPAddress.Text = "IP Address";
            this.columnHeader_CurrentConnections_IPAddress.Width = 100;
            // 
            // columnHeader_CurrentConnections_Status
            // 
            this.columnHeader_CurrentConnections_Status.Text = "Status";
            this.columnHeader_CurrentConnections_Status.Width = 100;
            // 
            // columnHeader_AccountType
            // 
            this.columnHeader_AccountType.Text = "Account Type";
            this.columnHeader_AccountType.Width = 164;
            // 
            // imageList_IconsOfActiveConnections
            // 
            this.imageList_IconsOfActiveConnections.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_IconsOfActiveConnections.ImageStream")));
            this.imageList_IconsOfActiveConnections.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_IconsOfActiveConnections.Images.SetKeyName(0, "");
            // 
            // groupBox_Main_MainNetworkControl
            // 
            this.groupBox_Main_MainNetworkControl.Controls.Add(this.button_Main_ConnectingService);
            this.groupBox_Main_MainNetworkControl.Controls.Add(this.textBox_Main_ListeningPort);
            this.groupBox_Main_MainNetworkControl.Controls.Add(this.textBox_Main_ServerStatus);
            this.groupBox_Main_MainNetworkControl.Controls.Add(this.label_Main_ServerPort);
            this.groupBox_Main_MainNetworkControl.Controls.Add(this.label_Main_ServerStatus);
            this.groupBox_Main_MainNetworkControl.Controls.Add(this.button_Main_StopServer);
            this.groupBox_Main_MainNetworkControl.Controls.Add(this.button_Main_StartServer);
            this.groupBox_Main_MainNetworkControl.Controls.Add(this.button_Main_AdditionalParameters);
            this.groupBox_Main_MainNetworkControl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_Main_MainNetworkControl.Location = new System.Drawing.Point(8, 16);
            this.groupBox_Main_MainNetworkControl.Name = "groupBox_Main_MainNetworkControl";
            this.groupBox_Main_MainNetworkControl.Size = new System.Drawing.Size(208, 165);
            this.groupBox_Main_MainNetworkControl.TabIndex = 6;
            this.groupBox_Main_MainNetworkControl.TabStop = false;
            this.groupBox_Main_MainNetworkControl.Text = "Main Network Control";
            // 
            // button_Main_ConnectingService
            // 
            this.button_Main_ConnectingService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Main_ConnectingService.Location = new System.Drawing.Point(16, 96);
            this.button_Main_ConnectingService.Name = "button_Main_ConnectingService";
            this.button_Main_ConnectingService.Size = new System.Drawing.Size(176, 23);
            this.button_Main_ConnectingService.TabIndex = 10;
            this.button_Main_ConnectingService.Text = "Connecting Service";
            this.button_Main_ConnectingService.Click += new System.EventHandler(this.button_Main_ConnectingService_Click);
            // 
            // textBox_Main_ListeningPort
            // 
            this.textBox_Main_ListeningPort.Location = new System.Drawing.Point(142, 35);
            this.textBox_Main_ListeningPort.MaxLength = 5;
            this.textBox_Main_ListeningPort.Name = "textBox_Main_ListeningPort";
            this.textBox_Main_ListeningPort.Size = new System.Drawing.Size(50, 20);
            this.textBox_Main_ListeningPort.TabIndex = 0;
            this.textBox_Main_ListeningPort.Text = "5544";
            this.textBox_Main_ListeningPort.TextChanged += new System.EventHandler(this.textBox_Main_ListeningPort_TextChanged);
            // 
            // textBox_Main_ServerStatus
            // 
            this.textBox_Main_ServerStatus.Location = new System.Drawing.Point(16, 35);
            this.textBox_Main_ServerStatus.Name = "textBox_Main_ServerStatus";
            this.textBox_Main_ServerStatus.ReadOnly = true;
            this.textBox_Main_ServerStatus.Size = new System.Drawing.Size(114, 20);
            this.textBox_Main_ServerStatus.TabIndex = 5;
            // 
            // label_Main_ServerPort
            // 
            this.label_Main_ServerPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_Main_ServerPort.Location = new System.Drawing.Point(143, 19);
            this.label_Main_ServerPort.Name = "label_Main_ServerPort";
            this.label_Main_ServerPort.Size = new System.Drawing.Size(40, 14);
            this.label_Main_ServerPort.TabIndex = 3;
            this.label_Main_ServerPort.Text = "Port:";
            this.label_Main_ServerPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Main_ServerStatus
            // 
            this.label_Main_ServerStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_Main_ServerStatus.Location = new System.Drawing.Point(17, 20);
            this.label_Main_ServerStatus.Name = "label_Main_ServerStatus";
            this.label_Main_ServerStatus.Size = new System.Drawing.Size(56, 16);
            this.label_Main_ServerStatus.TabIndex = 2;
            this.label_Main_ServerStatus.Text = "Status:";
            this.label_Main_ServerStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // button_Main_StopServer
            // 
            this.button_Main_StopServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Main_StopServer.Location = new System.Drawing.Point(110, 64);
            this.button_Main_StopServer.Name = "button_Main_StopServer";
            this.button_Main_StopServer.Size = new System.Drawing.Size(82, 23);
            this.button_Main_StopServer.TabIndex = 2;
            this.button_Main_StopServer.Text = "Stop";
            this.button_Main_StopServer.Click += new System.EventHandler(this.button_Main_StopServer_Click);
            // 
            // button_Main_StartServer
            // 
            this.button_Main_StartServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Main_StartServer.Location = new System.Drawing.Point(16, 64);
            this.button_Main_StartServer.Name = "button_Main_StartServer";
            this.button_Main_StartServer.Size = new System.Drawing.Size(82, 23);
            this.button_Main_StartServer.TabIndex = 1;
            this.button_Main_StartServer.Text = "Start";
            this.button_Main_StartServer.Click += new System.EventHandler(this.button_Main_StartServer_Click);
            // 
            // button_Main_AdditionalParameters
            // 
            this.button_Main_AdditionalParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Main_AdditionalParameters.Location = new System.Drawing.Point(16, 128);
            this.button_Main_AdditionalParameters.Name = "button_Main_AdditionalParameters";
            this.button_Main_AdditionalParameters.Size = new System.Drawing.Size(176, 23);
            this.button_Main_AdditionalParameters.TabIndex = 9;
            this.button_Main_AdditionalParameters.Text = "Additional Parameters";
            this.button_Main_AdditionalParameters.Click += new System.EventHandler(this.button_Main_AdditionalParameters_Click);
            // 
            // tabPage_Security
            // 
            this.tabPage_Security.Controls.Add(this.checkBox_Security_AllowWindowsAuthentication);
            this.tabPage_Security.Controls.Add(this.button_Security_ViewUserAccount);
            this.tabPage_Security.Controls.Add(this.button_Security_ClearUserAccounts);
            this.tabPage_Security.Controls.Add(this.label_Security_ListOfUsersAccounts);
            this.tabPage_Security.Controls.Add(this.button_Security_EditUserAccount);
            this.tabPage_Security.Controls.Add(this.button_Security_EnableUserAccount);
            this.tabPage_Security.Controls.Add(this.button_Security_DisableUserAccount);
            this.tabPage_Security.Controls.Add(this.listView_Security_ListOfUsersAccounts);
            this.tabPage_Security.Controls.Add(this.button_Security_AddNewUser);
            this.tabPage_Security.Controls.Add(this.button_Security_RemoveUserAccount);
            this.tabPage_Security.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Security.Name = "tabPage_Security";
            this.tabPage_Security.Size = new System.Drawing.Size(760, 245);
            this.tabPage_Security.TabIndex = 1;
            this.tabPage_Security.Text = "Security";
            // 
            // checkBox_Security_AllowWindowsAuthentication
            // 
            this.checkBox_Security_AllowWindowsAuthentication.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_Security_AllowWindowsAuthentication.Location = new System.Drawing.Point(355, 8);
            this.checkBox_Security_AllowWindowsAuthentication.Name = "checkBox_Security_AllowWindowsAuthentication";
            this.checkBox_Security_AllowWindowsAuthentication.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_Security_AllowWindowsAuthentication.Size = new System.Drawing.Size(389, 16);
            this.checkBox_Security_AllowWindowsAuthentication.TabIndex = 15;
            this.checkBox_Security_AllowWindowsAuthentication.Text = "Allow Use Windows Accounts";
            this.checkBox_Security_AllowWindowsAuthentication.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox_Security_AllowWindowsAuthentication.CheckedChanged += new System.EventHandler(this.checkBox_Security_AllowWindowsAuthentication_CheckedChanged);
            // 
            // button_Security_ViewUserAccount
            // 
            this.button_Security_ViewUserAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Security_ViewUserAccount.Location = new System.Drawing.Point(232, 208);
            this.button_Security_ViewUserAccount.Name = "button_Security_ViewUserAccount";
            this.button_Security_ViewUserAccount.Size = new System.Drawing.Size(96, 23);
            this.button_Security_ViewUserAccount.TabIndex = 3;
            this.button_Security_ViewUserAccount.Text = "Vew";
            this.button_Security_ViewUserAccount.Click += new System.EventHandler(this.button_Security_ViewUserAccount_Click);
            // 
            // button_Security_ClearUserAccounts
            // 
            this.button_Security_ClearUserAccounts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Security_ClearUserAccounts.Location = new System.Drawing.Point(648, 208);
            this.button_Security_ClearUserAccounts.Name = "button_Security_ClearUserAccounts";
            this.button_Security_ClearUserAccounts.Size = new System.Drawing.Size(96, 23);
            this.button_Security_ClearUserAccounts.TabIndex = 7;
            this.button_Security_ClearUserAccounts.Text = "Clear";
            this.button_Security_ClearUserAccounts.Click += new System.EventHandler(this.button_Security_ClearUserAccounts_Click);
            // 
            // label_Security_ListOfUsersAccounts
            // 
            this.label_Security_ListOfUsersAccounts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_Security_ListOfUsersAccounts.Location = new System.Drawing.Point(16, 8);
            this.label_Security_ListOfUsersAccounts.Name = "label_Security_ListOfUsersAccounts";
            this.label_Security_ListOfUsersAccounts.Size = new System.Drawing.Size(268, 16);
            this.label_Security_ListOfUsersAccounts.TabIndex = 13;
            this.label_Security_ListOfUsersAccounts.Text = "List of users accounts:";
            // 
            // button_Security_EditUserAccount
            // 
            this.button_Security_EditUserAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Security_EditUserAccount.Location = new System.Drawing.Point(128, 208);
            this.button_Security_EditUserAccount.Name = "button_Security_EditUserAccount";
            this.button_Security_EditUserAccount.Size = new System.Drawing.Size(96, 23);
            this.button_Security_EditUserAccount.TabIndex = 2;
            this.button_Security_EditUserAccount.Text = "Edit";
            this.button_Security_EditUserAccount.Click += new System.EventHandler(this.button_Security_EditUserAccount_Click);
            // 
            // button_Security_EnableUserAccount
            // 
            this.button_Security_EnableUserAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Security_EnableUserAccount.Location = new System.Drawing.Point(440, 208);
            this.button_Security_EnableUserAccount.Name = "button_Security_EnableUserAccount";
            this.button_Security_EnableUserAccount.Size = new System.Drawing.Size(97, 23);
            this.button_Security_EnableUserAccount.TabIndex = 5;
            this.button_Security_EnableUserAccount.Text = "Enable";
            this.button_Security_EnableUserAccount.Click += new System.EventHandler(this.button_Security_EnableUserAccount_Click);
            // 
            // button_Security_DisableUserAccount
            // 
            this.button_Security_DisableUserAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Security_DisableUserAccount.Location = new System.Drawing.Point(336, 208);
            this.button_Security_DisableUserAccount.Name = "button_Security_DisableUserAccount";
            this.button_Security_DisableUserAccount.Size = new System.Drawing.Size(96, 23);
            this.button_Security_DisableUserAccount.TabIndex = 4;
            this.button_Security_DisableUserAccount.Text = "Disable";
            this.button_Security_DisableUserAccount.Click += new System.EventHandler(this.button_Security_DisableUserAccount_Click);
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
            this.listView_Security_ListOfUsersAccounts.SmallImageList = this.imageList_IconsOfSecurilyList;
            this.listView_Security_ListOfUsersAccounts.TabIndex = 0;
            this.listView_Security_ListOfUsersAccounts.UseCompatibleStateImageBehavior = false;
            this.listView_Security_ListOfUsersAccounts.View = System.Windows.Forms.View.Details;
            this.listView_Security_ListOfUsersAccounts.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_Security_ListOfUsersAccounts_ColumnClick);
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
            this.columnHeader_UsersDatabase_TimeOfCreation.Width = 142;
            // 
            // columnHeader_UsersDatabase_AccountStatus
            // 
            this.columnHeader_UsersDatabase_AccountStatus.Text = "Status";
            this.columnHeader_UsersDatabase_AccountStatus.Width = 100;
            // 
            // imageList_IconsOfSecurilyList
            // 
            this.imageList_IconsOfSecurilyList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_IconsOfSecurilyList.ImageStream")));
            this.imageList_IconsOfSecurilyList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_IconsOfSecurilyList.Images.SetKeyName(0, "");
            this.imageList_IconsOfSecurilyList.Images.SetKeyName(1, "");
            // 
            // button_Security_AddNewUser
            // 
            this.button_Security_AddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Security_AddNewUser.Location = new System.Drawing.Point(16, 208);
            this.button_Security_AddNewUser.Name = "button_Security_AddNewUser";
            this.button_Security_AddNewUser.Size = new System.Drawing.Size(104, 24);
            this.button_Security_AddNewUser.TabIndex = 1;
            this.button_Security_AddNewUser.Text = "Add";
            this.button_Security_AddNewUser.Click += new System.EventHandler(this.button_Security_AddNewUser_Click);
            // 
            // button_Security_RemoveUserAccount
            // 
            this.button_Security_RemoveUserAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Security_RemoveUserAccount.Location = new System.Drawing.Point(544, 208);
            this.button_Security_RemoveUserAccount.Name = "button_Security_RemoveUserAccount";
            this.button_Security_RemoveUserAccount.Size = new System.Drawing.Size(96, 23);
            this.button_Security_RemoveUserAccount.TabIndex = 6;
            this.button_Security_RemoveUserAccount.Text = "Remove";
            this.button_Security_RemoveUserAccount.Click += new System.EventHandler(this.button_Security_RemoveUserAccount_Click);
            // 
            // tabPage_AccessRestrictions
            // 
            this.tabPage_AccessRestrictions.Controls.Add(this.button_AccessRestrictions_ViewRestriction);
            this.tabPage_AccessRestrictions.Controls.Add(this.button_AccessRestrictions_EnableRestriction);
            this.tabPage_AccessRestrictions.Controls.Add(this.button_AccessRestrictions_DisableRestriction);
            this.tabPage_AccessRestrictions.Controls.Add(this.button_AccessRestrictions_EditRestriction);
            this.tabPage_AccessRestrictions.Controls.Add(this.button_AccessRestrictions_ClearRestrictions);
            this.tabPage_AccessRestrictions.Controls.Add(this.checkBox_AccessRestrictions_EnableAccessRestrictions);
            this.tabPage_AccessRestrictions.Controls.Add(this.button_AccessRestrictions_RemoveRestriction);
            this.tabPage_AccessRestrictions.Controls.Add(this.button_AccessRestrictions_AddRestriction);
            this.tabPage_AccessRestrictions.Controls.Add(this.label_AccessRestrictions_ListOfAccessRestrictionsRules);
            this.tabPage_AccessRestrictions.Controls.Add(this.listView_AccessRestrictions_AccessRestrictionRulesList);
            this.tabPage_AccessRestrictions.Location = new System.Drawing.Point(4, 22);
            this.tabPage_AccessRestrictions.Name = "tabPage_AccessRestrictions";
            this.tabPage_AccessRestrictions.Size = new System.Drawing.Size(760, 245);
            this.tabPage_AccessRestrictions.TabIndex = 4;
            this.tabPage_AccessRestrictions.Text = "Access Restrictions";
            // 
            // button_AccessRestrictions_ViewRestriction
            // 
            this.button_AccessRestrictions_ViewRestriction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_AccessRestrictions_ViewRestriction.Location = new System.Drawing.Point(232, 208);
            this.button_AccessRestrictions_ViewRestriction.Name = "button_AccessRestrictions_ViewRestriction";
            this.button_AccessRestrictions_ViewRestriction.Size = new System.Drawing.Size(96, 23);
            this.button_AccessRestrictions_ViewRestriction.TabIndex = 17;
            this.button_AccessRestrictions_ViewRestriction.Text = "Vew";
            this.button_AccessRestrictions_ViewRestriction.Click += new System.EventHandler(this.button_AccessRestrictions_ViewRestriction_Click);
            // 
            // button_AccessRestrictions_EnableRestriction
            // 
            this.button_AccessRestrictions_EnableRestriction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_AccessRestrictions_EnableRestriction.Location = new System.Drawing.Point(440, 208);
            this.button_AccessRestrictions_EnableRestriction.Name = "button_AccessRestrictions_EnableRestriction";
            this.button_AccessRestrictions_EnableRestriction.Size = new System.Drawing.Size(97, 23);
            this.button_AccessRestrictions_EnableRestriction.TabIndex = 19;
            this.button_AccessRestrictions_EnableRestriction.Text = "Enable";
            this.button_AccessRestrictions_EnableRestriction.Click += new System.EventHandler(this.button_AccessRestrictions_EnableRestriction_Click);
            // 
            // button_AccessRestrictions_DisableRestriction
            // 
            this.button_AccessRestrictions_DisableRestriction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_AccessRestrictions_DisableRestriction.Location = new System.Drawing.Point(336, 208);
            this.button_AccessRestrictions_DisableRestriction.Name = "button_AccessRestrictions_DisableRestriction";
            this.button_AccessRestrictions_DisableRestriction.Size = new System.Drawing.Size(96, 23);
            this.button_AccessRestrictions_DisableRestriction.TabIndex = 18;
            this.button_AccessRestrictions_DisableRestriction.Text = "Disable";
            this.button_AccessRestrictions_DisableRestriction.Click += new System.EventHandler(this.button_AccessRestrictions_DisableRestriction_Click);
            // 
            // button_AccessRestrictions_EditRestriction
            // 
            this.button_AccessRestrictions_EditRestriction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_AccessRestrictions_EditRestriction.Location = new System.Drawing.Point(128, 208);
            this.button_AccessRestrictions_EditRestriction.Name = "button_AccessRestrictions_EditRestriction";
            this.button_AccessRestrictions_EditRestriction.Size = new System.Drawing.Size(96, 23);
            this.button_AccessRestrictions_EditRestriction.TabIndex = 16;
            this.button_AccessRestrictions_EditRestriction.Text = "Edit";
            this.button_AccessRestrictions_EditRestriction.Click += new System.EventHandler(this.button_AccessRestrictions_EditRestriction_Click);
            // 
            // button_AccessRestrictions_ClearRestrictions
            // 
            this.button_AccessRestrictions_ClearRestrictions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_AccessRestrictions_ClearRestrictions.Location = new System.Drawing.Point(648, 208);
            this.button_AccessRestrictions_ClearRestrictions.Name = "button_AccessRestrictions_ClearRestrictions";
            this.button_AccessRestrictions_ClearRestrictions.Size = new System.Drawing.Size(96, 23);
            this.button_AccessRestrictions_ClearRestrictions.TabIndex = 15;
            this.button_AccessRestrictions_ClearRestrictions.Text = "Clear";
            this.button_AccessRestrictions_ClearRestrictions.Click += new System.EventHandler(this.button_AccessRestrictions_ClearRestrictions_Click);
            // 
            // checkBox_AccessRestrictions_EnableAccessRestrictions
            // 
            this.checkBox_AccessRestrictions_EnableAccessRestrictions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_AccessRestrictions_EnableAccessRestrictions.Location = new System.Drawing.Point(576, 8);
            this.checkBox_AccessRestrictions_EnableAccessRestrictions.Name = "checkBox_AccessRestrictions_EnableAccessRestrictions";
            this.checkBox_AccessRestrictions_EnableAccessRestrictions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_AccessRestrictions_EnableAccessRestrictions.Size = new System.Drawing.Size(168, 16);
            this.checkBox_AccessRestrictions_EnableAccessRestrictions.TabIndex = 14;
            this.checkBox_AccessRestrictions_EnableAccessRestrictions.Text = "Use Restrictions";
            this.checkBox_AccessRestrictions_EnableAccessRestrictions.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox_AccessRestrictions_EnableAccessRestrictions.CheckedChanged += new System.EventHandler(this.checkBox_AccessRestrictions_EnableAccessRestrictions_CheckedChanged);
            // 
            // button_AccessRestrictions_RemoveRestriction
            // 
            this.button_AccessRestrictions_RemoveRestriction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_AccessRestrictions_RemoveRestriction.Location = new System.Drawing.Point(544, 208);
            this.button_AccessRestrictions_RemoveRestriction.Name = "button_AccessRestrictions_RemoveRestriction";
            this.button_AccessRestrictions_RemoveRestriction.Size = new System.Drawing.Size(96, 23);
            this.button_AccessRestrictions_RemoveRestriction.TabIndex = 11;
            this.button_AccessRestrictions_RemoveRestriction.Text = "Remove";
            this.button_AccessRestrictions_RemoveRestriction.Click += new System.EventHandler(this.button_AccessRestrictions_RemoveRestriction_Click);
            // 
            // button_AccessRestrictions_AddRestriction
            // 
            this.button_AccessRestrictions_AddRestriction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_AccessRestrictions_AddRestriction.Location = new System.Drawing.Point(16, 208);
            this.button_AccessRestrictions_AddRestriction.Name = "button_AccessRestrictions_AddRestriction";
            this.button_AccessRestrictions_AddRestriction.Size = new System.Drawing.Size(104, 24);
            this.button_AccessRestrictions_AddRestriction.TabIndex = 10;
            this.button_AccessRestrictions_AddRestriction.Text = "Add";
            this.button_AccessRestrictions_AddRestriction.Click += new System.EventHandler(this.button_AccessRestrictions_AddRestriction_Click);
            // 
            // label_AccessRestrictions_ListOfAccessRestrictionsRules
            // 
            this.label_AccessRestrictions_ListOfAccessRestrictionsRules.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_AccessRestrictions_ListOfAccessRestrictionsRules.Location = new System.Drawing.Point(16, 8);
            this.label_AccessRestrictions_ListOfAccessRestrictionsRules.Name = "label_AccessRestrictions_ListOfAccessRestrictionsRules";
            this.label_AccessRestrictions_ListOfAccessRestrictionsRules.Size = new System.Drawing.Size(352, 16);
            this.label_AccessRestrictions_ListOfAccessRestrictionsRules.TabIndex = 9;
            this.label_AccessRestrictions_ListOfAccessRestrictionsRules.Text = "List of access restrictions rules:";
            // 
            // listView_AccessRestrictions_AccessRestrictionRulesList
            // 
            this.listView_AccessRestrictions_AccessRestrictionRulesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_AccessRestrictions_IPRange,
            this.columnHeader_AccessRestrictions_IPAddress,
            this.columnHeader_AccessRestrictions_MACAddress,
            this.columnHeader_AccessRestrictions_RuleType,
            this.columnHeader_AccessRestrictions_CreationTime});
            this.listView_AccessRestrictions_AccessRestrictionRulesList.FullRowSelect = true;
            this.listView_AccessRestrictions_AccessRestrictionRulesList.GridLines = true;
            this.listView_AccessRestrictions_AccessRestrictionRulesList.HideSelection = false;
            this.listView_AccessRestrictions_AccessRestrictionRulesList.Location = new System.Drawing.Point(16, 24);
            this.listView_AccessRestrictions_AccessRestrictionRulesList.Name = "listView_AccessRestrictions_AccessRestrictionRulesList";
            this.listView_AccessRestrictions_AccessRestrictionRulesList.Size = new System.Drawing.Size(728, 176);
            this.listView_AccessRestrictions_AccessRestrictionRulesList.SmallImageList = this.imageList_IconsOfRestrictionRulesList;
            this.listView_AccessRestrictions_AccessRestrictionRulesList.TabIndex = 8;
            this.listView_AccessRestrictions_AccessRestrictionRulesList.UseCompatibleStateImageBehavior = false;
            this.listView_AccessRestrictions_AccessRestrictionRulesList.View = System.Windows.Forms.View.Details;
            this.listView_AccessRestrictions_AccessRestrictionRulesList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_AccessRestrictions_AccessRestrictionRulesList_ColumnClick);
            // 
            // columnHeader_AccessRestrictions_IPRange
            // 
            this.columnHeader_AccessRestrictions_IPRange.Text = "IP Range";
            this.columnHeader_AccessRestrictions_IPRange.Width = 200;
            // 
            // columnHeader_AccessRestrictions_IPAddress
            // 
            this.columnHeader_AccessRestrictions_IPAddress.Text = "IP Address";
            this.columnHeader_AccessRestrictions_IPAddress.Width = 100;
            // 
            // columnHeader_AccessRestrictions_MACAddress
            // 
            this.columnHeader_AccessRestrictions_MACAddress.Text = "Mac Address";
            this.columnHeader_AccessRestrictions_MACAddress.Width = 100;
            // 
            // columnHeader_AccessRestrictions_RuleType
            // 
            this.columnHeader_AccessRestrictions_RuleType.Text = "Rule Type";
            this.columnHeader_AccessRestrictions_RuleType.Width = 180;
            // 
            // columnHeader_AccessRestrictions_CreationTime
            // 
            this.columnHeader_AccessRestrictions_CreationTime.Text = "Creation Time";
            this.columnHeader_AccessRestrictions_CreationTime.Width = 125;
            // 
            // imageList_IconsOfRestrictionRulesList
            // 
            this.imageList_IconsOfRestrictionRulesList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_IconsOfRestrictionRulesList.ImageStream")));
            this.imageList_IconsOfRestrictionRulesList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_IconsOfRestrictionRulesList.Images.SetKeyName(0, "");
            this.imageList_IconsOfRestrictionRulesList.Images.SetKeyName(1, "");
            // 
            // tabPage_Log
            // 
            this.tabPage_Log.Controls.Add(this.label_Log_Events);
            this.tabPage_Log.Controls.Add(this.listView_MainServerForm_EventsLog);
            this.tabPage_Log.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Log.Name = "tabPage_Log";
            this.tabPage_Log.Size = new System.Drawing.Size(760, 245);
            this.tabPage_Log.TabIndex = 2;
            this.tabPage_Log.Text = "Log";
            // 
            // label_Log_Events
            // 
            this.label_Log_Events.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_Log_Events.Location = new System.Drawing.Point(16, 8);
            this.label_Log_Events.Name = "label_Log_Events";
            this.label_Log_Events.Size = new System.Drawing.Size(88, 16);
            this.label_Log_Events.TabIndex = 1;
            this.label_Log_Events.Text = "Events:";
            // 
            // listView_MainServerForm_EventsLog
            // 
            this.listView_MainServerForm_EventsLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Type,
            this.columnHeader_Date,
            this.columnHeader_Time,
            this.columnHeader_Source,
            this.columnHeader_Description});
            this.listView_MainServerForm_EventsLog.FullRowSelect = true;
            this.listView_MainServerForm_EventsLog.GridLines = true;
            this.listView_MainServerForm_EventsLog.Location = new System.Drawing.Point(16, 24);
            this.listView_MainServerForm_EventsLog.Name = "listView_MainServerForm_EventsLog";
            this.listView_MainServerForm_EventsLog.Size = new System.Drawing.Size(728, 200);
            this.listView_MainServerForm_EventsLog.SmallImageList = this.imageList_CommonIcons;
            this.listView_MainServerForm_EventsLog.TabIndex = 0;
            this.listView_MainServerForm_EventsLog.UseCompatibleStateImageBehavior = false;
            this.listView_MainServerForm_EventsLog.View = System.Windows.Forms.View.Details;
            this.listView_MainServerForm_EventsLog.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_MainServerForm_EventsLog_ColumnClick);
            // 
            // columnHeader_Type
            // 
            this.columnHeader_Type.Text = "Type";
            this.columnHeader_Type.Width = 95;
            // 
            // columnHeader_Date
            // 
            this.columnHeader_Date.Text = "Date";
            this.columnHeader_Date.Width = 71;
            // 
            // columnHeader_Time
            // 
            this.columnHeader_Time.Text = "Time";
            this.columnHeader_Time.Width = 55;
            // 
            // columnHeader_Source
            // 
            this.columnHeader_Source.Text = "Source";
            this.columnHeader_Source.Width = 105;
            // 
            // columnHeader_Description
            // 
            this.columnHeader_Description.Text = "Description";
            this.columnHeader_Description.Width = 380;
            // 
            // imageList_CommonIcons
            // 
            this.imageList_CommonIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_CommonIcons.ImageStream")));
            this.imageList_CommonIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_CommonIcons.Images.SetKeyName(0, "");
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_File,
            this.menuItem_Log,
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
            // menuItem_Log
            // 
            this.menuItem_Log.Index = 1;
            this.menuItem_Log.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_SaveLog,
            this.menuItem_ClearLog});
            this.menuItem_Log.Text = "Log";
            // 
            // menuItem_SaveLog
            // 
            this.menuItem_SaveLog.Index = 0;
            this.menuItem_SaveLog.Text = "Save Log";
            this.menuItem_SaveLog.Click += new System.EventHandler(this.menuItem_SaveLog_Click);
            // 
            // menuItem_ClearLog
            // 
            this.menuItem_ClearLog.Index = 1;
            this.menuItem_ClearLog.Text = "Clear Log";
            this.menuItem_ClearLog.Click += new System.EventHandler(this.menuItem_ClearLog_Click);
            // 
            // menuItem_Options
            // 
            this.menuItem_Options.Index = 2;
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
            this.menuItem_Help.Index = 3;
            this.menuItem_Help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Help_About,
            this.menuItem_Help_Register});
            this.menuItem_Help.Text = "Help";
            // 
            // menuItem_Help_About
            // 
            this.menuItem_Help_About.Index = 0;
            this.menuItem_Help_About.Text = "About";
            this.menuItem_Help_About.Click += new System.EventHandler(this.menuItem_Help_About_Click);
            // 
            // menuItem_Help_Register
            // 
            this.menuItem_Help_Register.Enabled = false;
            this.menuItem_Help_Register.Index = 1;
            this.menuItem_Help_Register.Text = "Register...";
            this.menuItem_Help_Register.Visible = false;
            this.menuItem_Help_Register.Click += new System.EventHandler(this.menuItem_Help_Register_Click);
            // 
            // statusBar_Main
            // 
            this.statusBar_Main.Location = new System.Drawing.Point(0, 279);
            this.statusBar_Main.Name = "statusBar_Main";
            this.statusBar_Main.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel_BytesSent,
            this.statusBarPanel_BytesReceived,
            this.statusBarPanel_Connections,
            this.statusBarPanel_LastConnectionTime});
            this.statusBar_Main.ShowPanels = true;
            this.statusBar_Main.Size = new System.Drawing.Size(776, 22);
            this.statusBar_Main.SizingGrip = false;
            this.statusBar_Main.TabIndex = 8;
            // 
            // statusBarPanel_BytesSent
            // 
            this.statusBarPanel_BytesSent.Name = "statusBarPanel_BytesSent";
            this.statusBarPanel_BytesSent.Width = 170;
            // 
            // statusBarPanel_BytesReceived
            // 
            this.statusBarPanel_BytesReceived.Name = "statusBarPanel_BytesReceived";
            this.statusBarPanel_BytesReceived.Width = 170;
            // 
            // statusBarPanel_Connections
            // 
            this.statusBarPanel_Connections.Name = "statusBarPanel_Connections";
            this.statusBarPanel_Connections.Width = 160;
            // 
            // statusBarPanel_LastConnectionTime
            // 
            this.statusBarPanel_LastConnectionTime.Name = "statusBarPanel_LastConnectionTime";
            this.statusBarPanel_LastConnectionTime.Width = 280;
            // 
            // MainServerForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(776, 301);
            this.Controls.Add(this.statusBar_Main);
            this.Controls.Add(this.tabControl_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(792, 360);
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(792, 360);
            this.Name = "MainServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.MainServerForm_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainServerForm_Closing);
            this.Load += new System.EventHandler(this.MainServerForm_Load);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_NetworkControl.ResumeLayout(false);
            this.groupBox_Main_ActiveConnections.ResumeLayout(false);
            this.groupBox_Main_MainNetworkControl.ResumeLayout(false);
            this.groupBox_Main_MainNetworkControl.PerformLayout();
            this.tabPage_Security.ResumeLayout(false);
            this.tabPage_AccessRestrictions.ResumeLayout(false);
            this.tabPage_Log.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_BytesSent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_BytesReceived)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_Connections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel_LastConnectionTime)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion
    /*
    public int CheckSN(string string_FullName, string string_Key)
    {
        MD5CryptoServiceProvider MD5Object_Key = new MD5CryptoServiceProvider();

        byte[] byteArray_KeyHash = MD5Object_Key.ComputeHash(Encoding.Unicode.GetBytes(string_FullName));

        string string_CurrentNubmer = null;

        for (int int_CycleCount = 0; byteArray_KeyHash.Length != int_CycleCount; int_CycleCount++)
        {
            string_CurrentNubmer += (byteArray_KeyHash[int_CycleCount] * 8).ToString();
        }

        if (string_Key == string_CurrentNubmer.Substring(0, 10))
        {
            if (Registry.CurrentUser.OpenSubKey("Software\\YakSys", true) == null)
                Registry.CurrentUser.CreateSubKey("Software\\YakSys");

            Registry.CurrentUser.OpenSubKey("Software\\YakSys", true).SetValue("SN", string_Key);
            Registry.CurrentUser.OpenSubKey("Software\\YakSys", true).SetValue("Name", string_FullName);

            menuItem_Help_Register.Enabled = false;

            LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_ProductSerialNumber = string_Key;
            LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_ProductLicenceName = string_FullName;

            LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_IsProductRegistered = true;

            return 1;
        }

        return 0;
    }
    */
    Thread thread_NGSCRThread;
    /*
    private void NGSCRThread()
    {
        try
        {
            RegistrationForm registrationForm_obj = new RegistrationForm();

            thread_NGSCRThread = Thread.CurrentThread;

            if (Registry.CurrentUser.OpenSubKey("Software\\YakSys", true) != null
                && Registry.CurrentUser.OpenSubKey("Software\\YakSys", true).GetValue("SN") != null
                && Registry.CurrentUser.OpenSubKey("Software\\YakSys", true).GetValue("Name") != null)
            {
                string string_Key = Registry.CurrentUser.OpenSubKey("Software\\YakSys", true).GetValue("SN").ToString(),
                    string_FullName = Registry.CurrentUser.OpenSubKey("Software\\YakSys", true).GetValue("Name").ToString();

                if (CheckSN(string_FullName, string_Key) == 1) return;
            }

            Thread.Sleep(10000);

            for (; LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_IsProductRegistered != true; Thread.Sleep((2 * 60) * 1000))
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Enabled = false;

                    if (LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_IsProductRegistered == true)
                    {
                        this.Enabled = true;

                        return;
                    }
                    registrationForm_obj.ShowDialog(this);

                    System.Threading.Thread.Sleep(2000);

                    this.Enabled = true;
                });
            }

            return;
        }

        catch (Exception)
        {

        }
    }
    */

    [STAThreadAttribute]
    static void Main()
    {
        if (IsInstanceExists() == true)
        {
            MessageBox.Show("YakSys Remote Control Tools GUI already running");

            if (LocalObjCopy.obj_MainServerForm != null)
            {
                LocalObjCopy.obj_MainServerForm.BringToFront();

                LocalObjCopy.obj_MainServerForm.Show();
            }

            return;
        }

        Application.EnableVisualStyles();
       // Application.SetCompatibleTextRenderingDefault(false);

        LocalObjCopy.obj_MainServerForm = new MainServerForm();

        Application.Run(LocalObjCopy.obj_MainServerForm);
    }

    static Mutex mutex_InstanceCheckMutex;
    static bool IsInstanceExists()
    {
        bool bool_IsInstanceExists;

        mutex_InstanceCheckMutex = new Mutex(false, "YakSys RCT Windows Service GUI v1.1", out bool_IsInstanceExists);
        
        return !bool_IsInstanceExists;
    } 



    public MainServerForm()
    {
        InitializeComponent();
    }

    private void MainServerForm_Load(object sender, System.EventArgs e)
    {
        try
        {
            if (LocalObjCopy.obj_NetworkAction.RemotingWrapper_InstanceCount == 0)
            {
            }
        }
        catch (RemotingException)
        {
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(ServerStringFactory.GetString(760, 0), ServerStringFactory.GetString(1, 0));

                Process.GetCurrentProcess().Kill();
            });
        }


        new Thread(new ThreadStart(CheckRemotingConnectionThread)).Start();

        Thread.Sleep(2000);

        YakSys.RCTServiceGUI.NETRemotingInteractionLayer.ConnectToNETRemotingLocalHost();

        LocalObjCopy.obj_MainServerForm.ChangeControlsLanguage();

        this.SetUpServerSettingsFromDB();

        this.RefreshAccessRestrictionRulesList();
        this.RefreshUserAccountsList();
        this.RefreshActiveConnectionsList();

        new Thread(new ThreadStart(RefreshListsContentThread)).Start();

        LocalObjCopy.obj_MainServerForm.Select();
        LocalObjCopy.obj_MainServerForm.ShowInTaskbar = true;
        LocalObjCopy.obj_MainServerForm.Activate();
    }

    public void YakSysRctExitServer()
    {
        if (DialogResult.Yes == MessageBox.Show(this, ServerStringFactory.GetString(39, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            notifyIcon_Main.Visible = false;

            if (thread_NGSCRThread != null) thread_NGSCRThread.Abort();

            Process.GetCurrentProcess().Kill();
        }
    }

    private void MainServerForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        e.Cancel = true;

        YakSysRctExitServer();
    }

    private void MainServerForm_Activated(object sender, System.EventArgs e)
    {
        this.ShowInTaskbar = true;

        if (this.ShowInTaskbar == true)
        {
            try
            {
                notifyIcon_Main.Visible = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_ShowIconInNotifyArea = this.checkBox_MainWindowParameters_ShowInNotifyArea.Checked;

                if (connectingServiceProviderForm_obj != null)
                {
                    connectingServiceProviderForm_obj.BringToFront();
                    connectingServiceProviderForm_obj.Select();
                }
            }
            catch (RemotingException)
            {

            }
            catch
            {

            }
        }
    }


    public string SpreadToHundreds(string string_NecessaryString)
    {
        for (int int_LastDotPosition = string_NecessaryString.Length; int_LastDotPosition - 3 >= 1; int_LastDotPosition -= 3)
        {
            string_NecessaryString = string_NecessaryString.Insert(int_LastDotPosition - 3, ", ");
        }

        return string_NecessaryString;
    }


    public void ChangeControlsLanguage()
    {
        this.Text = ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.tabPage_NetworkControl.Text = ServerStringFactory.GetString(4, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.groupBox_Main_MainNetworkControl.Text = ServerStringFactory.GetString(6, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.textBox_Main_ServerStatus.Text = ServerStringFactory.GetString(58, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_Main_ServerPort.Text = ServerStringFactory.GetString(8, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_Main_ServerStatus.Text = ServerStringFactory.GetString(9, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.button_MainWindowParameters_MinimizeToNotifyArea.Text = ServerStringFactory.GetString(153, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        if (LocalObjCopy.obj_NetworkAction.RemotingWrapper_InstanceCount > 0)
        {
            LocalObjCopy.obj_NetworkStatusAndStatistics.RemotingWrapper_ServerStatus = ServerStringFactory.GetString(56, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

            LocalObjCopy.obj_MainServerForm.ServerStatus = ServerStringFactory.GetString(56, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        }
        else
        {
            LocalObjCopy.obj_NetworkStatusAndStatistics.RemotingWrapper_ServerStatus = ServerStringFactory.GetString(7, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

            LocalObjCopy.obj_MainServerForm.ServerStatus = ServerStringFactory.GetString(7, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        }

        this.button_Main_StopServer.Text = ServerStringFactory.GetString(10, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_Main_StartServer.Text = ServerStringFactory.GetString(11, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.button_Main_ConnectingService.Text = ServerStringFactory.GetString(797, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);


        this.tabPage_Security.Text = ServerStringFactory.GetString(43, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_Security_ListOfUsersAccounts.Text = ServerStringFactory.GetString(12, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_Security_EditUserAccount.Text = ServerStringFactory.GetString(13, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_Security_EnableUserAccount.Text = ServerStringFactory.GetString(14, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_Security_DisableUserAccount.Text = ServerStringFactory.GetString(15, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_Security_AddNewUser.Text = ServerStringFactory.GetString(23, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_Security_RemoveUserAccount.Text = ServerStringFactory.GetString(24, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_Security_ClearUserAccounts.Text = ServerStringFactory.GetString(113, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_Security_ViewUserAccount.Text = ServerStringFactory.GetString(112, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.columnHeader_UsersDatabase_User.Text = ServerStringFactory.GetString(19, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_UsersDatabase_Login.Text = ServerStringFactory.GetString(20, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_UsersDatabase_TimeOfCreation.Text = ServerStringFactory.GetString(21, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_UsersDatabase_AccountStatus.Text = ServerStringFactory.GetString(22, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.tabPage_Log.Text = ServerStringFactory.GetString(62, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_Type.Text = ServerStringFactory.GetString(25, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_Date.Text = ServerStringFactory.GetString(26, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_Time.Text = ServerStringFactory.GetString(27, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_Source.Text = ServerStringFactory.GetString(28, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_Description.Text = ServerStringFactory.GetString(29, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.menuItem_File.Text = ServerStringFactory.GetString(30, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.menuItem_File_Exit.Text = ServerStringFactory.GetString(31, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.menuItem_Log.Text = ServerStringFactory.GetString(62, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.menuItem_SaveLog.Text = ServerStringFactory.GetString(32, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.menuItem_ClearLog.Text = ServerStringFactory.GetString(33, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.menuItem_Help.Text = ServerStringFactory.GetString(34, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.menuItem_Help_About.Text = ServerStringFactory.GetString(35, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.menuItem_Options.Text = ServerStringFactory.GetString(64, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.menuItem_Options_Settings.Text = ServerStringFactory.GetString(65, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.menuItem_Help_Register.Text = ServerStringFactory.GetString(85, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_Log_Events.Text = ServerStringFactory.GetString(88, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.menuItem_File_Import.Text = ServerStringFactory.GetString(146, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.menuItem_File_Import_SettingsDatabase.Text = ServerStringFactory.GetString(148, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.menuItem_File_Export.Text = ServerStringFactory.GetString(147, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.menuItem_File_Export_SettingsDatabase.Text = ServerStringFactory.GetString(148, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.tabPage_AccessRestrictions.Text = ServerStringFactory.GetString(154, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_AccessRestrictions_ListOfAccessRestrictionsRules.Text = ServerStringFactory.GetString(155, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.checkBox_AccessRestrictions_EnableAccessRestrictions.Text = ServerStringFactory.GetString(161, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.button_AccessRestrictions_AddRestriction.Text = ServerStringFactory.GetString(23, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_AccessRestrictions_EditRestriction.Text = ServerStringFactory.GetString(13, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_AccessRestrictions_RemoveRestriction.Text = ServerStringFactory.GetString(24, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_AccessRestrictions_ClearRestrictions.Text = ServerStringFactory.GetString(113, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_AccessRestrictions_ViewRestriction.Text = ServerStringFactory.GetString(112, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_AccessRestrictions_EnableRestriction.Text = ServerStringFactory.GetString(14, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_AccessRestrictions_DisableRestriction.Text = ServerStringFactory.GetString(15, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.columnHeader_AccessRestrictions_IPRange.Text = ServerStringFactory.GetString(156, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_AccessRestrictions_IPAddress.Text = ServerStringFactory.GetString(157, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_AccessRestrictions_MACAddress.Text = ServerStringFactory.GetString(159, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_AccessRestrictions_RuleType.Text = ServerStringFactory.GetString(160, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_AccessRestrictions_CreationTime.Text = ServerStringFactory.GetString(21, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.columnHeader_AccountType.Text = ServerStringFactory.GetString(758, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.groupBox_Main_ActiveConnections.Text = ServerStringFactory.GetString(174, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.columnHeader_CurrentConnections_IPAddress.Text = ServerStringFactory.GetString(157, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_CurrentConnections_Status.Text = ServerStringFactory.GetString(172, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.columnHeader_CurrentConnections_User.Text = ServerStringFactory.GetString(173, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.button_CurrentConnections_Details.Text = ServerStringFactory.GetString(170, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_CurrentConnections_Disconnect.Text = ServerStringFactory.GetString(168, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.button_CurrentConnections_DisconnectAll.Text = ServerStringFactory.GetString(169, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.button_Main_AdditionalParameters.Text = ServerStringFactory.GetString(223, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.checkBox_MainWindowParameters_ShowInNotifyArea.Text = ServerStringFactory.GetString(97, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.checkBox_Security_AllowWindowsAuthentication.Text = ServerStringFactory.GetString(759, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
    }

    public void SetUpServerSettingsFromDB()
    {
        this.ServerPort = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_ServerPort;

        notifyIcon_Main.DoubleClick += new System.EventHandler(LocalObjCopy.obj_MainServerForm.RestoreWindowFromSystemTray);
        notifyIcon_Main.Text = "YakSys RCT Server";
        notifyIcon_Main.Icon = LocalObjCopy.obj_MainServerForm.Icon;

        MainServerForm.notifyIcon_Main.Visible = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_ShowIconInNotifyArea;

     //   new Thread(new ThreadStart(LocalObjCopy.obj_MainServerForm.NGSCRThread)).Start();!! FREE

        this.checkBox_AccessRestrictions_EnableAccessRestrictions.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_EnableAccessRestrictionRules;

        this.checkBox_Security_AllowWindowsAuthentication.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_IsWindowsAuthenticationAllowed;


        this.checkBox_AccessRestrictions_EnableAccessRestrictions_CheckedChanged(null, null);

        this.checkBox_MainWindowParameters_ShowInNotifyArea.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_ShowIconInNotifyArea;


        if (LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_MinimizeToNotifyAreaAtRun == true)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = this.Visible = false;
        }

    }

    ////////////////////////// Menu items

    private void menuItem_Help_About_Click(object sender, System.EventArgs e)
    {
        new AboutForm().ShowDialog();
    }

    private void menuItem_Help_Register_Click(object sender, System.EventArgs e)
    {
        new RegistrationForm().ShowDialog();
    }


    private void menuItem_Options_Settings_Click(object sender, System.EventArgs e)
    {
        SettingsForm obj_SettingsForm = new SettingsForm();
      
        obj_SettingsForm.ShowDialog();
    }


    private void menuItem_File_Import_SettingsDatabase_Click(object sender, System.EventArgs e)
    {
        OpenFileDialog openFileDialog_obj = new OpenFileDialog();

        openFileDialog_obj.Multiselect = false;

        openFileDialog_obj.Title = ServerStringFactory.GetString(149, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        openFileDialog_obj.ShowDialog();

        LocalObjCopy.obj_YakSysServerDBEnvironment.RemotingWrapper_LoadXMLDataFile(openFileDialog_obj.FileName, true);

        SetUpServerSettingsFromDB();
    }

    private void menuItem_File_Export_SettingsDatabase_Click(object sender, System.EventArgs e)
    {
        SaveFileDialog saveFileDialog_obj = new SaveFileDialog();

        saveFileDialog_obj.Title = ServerStringFactory.GetString(150, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        saveFileDialog_obj.FileName = "YakSysServerDB";

        saveFileDialog_obj.ShowDialog();

        LocalObjCopy.obj_YakSysServerDBEnvironment.WriteServerSettingsData(saveFileDialog_obj.FileName);
    }
    
    private void menuItem_File_Exit_Click(object sender, System.EventArgs e)
    {
        YakSysRctExitServer();
    }


    private void menuItem_SaveLog_Click(object sender, System.EventArgs e)
    {
        if (listView_MainServerForm_EventsLog.Items.Count > 0)
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

                string string_Added;

                byteArray_LogItem = System.Text.Encoding.Default.GetBytes(ServerStringFactory.GetString(40, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));

                int_LogItemLength = byteArray_LogItem.Length;

                file_Log.Write(byteArray_LogItem, 0, int_LogItemLength);

                for (int int_CycleCount = 0; listView_MainServerForm_EventsLog.Items.Count != int_CycleCount; int_CycleCount++)
                {
                    for (int int_SubCycleCount = 0; 5 != int_SubCycleCount; int_SubCycleCount++)
                    {
                        if (int_SubCycleCount == 4) string_Added = "    \n";
                        else string_Added = "    ";

                        byteArray_LogItem = System.Text.Encoding.Default.GetBytes(listView_MainServerForm_EventsLog.Items[int_CycleCount].SubItems[int_SubCycleCount].Text + string_Added);

                        int_LogItemLength = byteArray_LogItem.Length;

                        file_Log.Write(byteArray_LogItem, 0, int_LogItemLength);
                    }
                }

                file_Log.Close();
            }
        }

        else MessageBox.Show(ServerStringFactory.GetString(41, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Stop);
    }

    private void menuItem_ClearLog_Click(object sender, System.EventArgs e)
    {
        if (listView_MainServerForm_EventsLog.Items.Count > 0)
        {
            if (DialogResult.Yes == MessageBox.Show(ServerStringFactory.GetString(42, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                listView_MainServerForm_EventsLog.Items.Clear();

                LocalObjCopy.obj_YakSysServerDBEnvironment.ClearEventsLogDataBase();
            }
        }
    }
    
    //////////////////////////////////////////////////////////


    private void checkBox_MainWindowParameters_ShowInNotifyArea_CheckedChanged(object sender, System.EventArgs e)
    {
        notifyIcon_Main.Visible = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_ShowIconInNotifyArea = this.checkBox_MainWindowParameters_ShowInNotifyArea.Checked;
    }

    public void MinimizeToNotifyArea()
    {
        this.Visible = this.ShowInTaskbar = false;

        notifyIcon_Main.Visible = true;
    }

    private void button_MainWindowParameters_MinimizeToNotifyArea_Click(object sender, EventArgs e)
    {
        this.MinimizeToNotifyArea();
    }

    private void RestoreWindowFromSystemTray(object sender, System.EventArgs e)
    {
        this.ShowInTaskbar = true;

        notifyIcon_Main.Visible = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_ShowIconInNotifyArea;

        this.WindowState = FormWindowState.Normal;

        this.tabControl_Main.SelectedIndex = 1;
        this.tabControl_Main.SelectedIndex = 0;

        this.Visible = true;
    }



    private void checkBox_Security_AllowWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
    {
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_IsWindowsAuthenticationAllowed = this.checkBox_Security_AllowWindowsAuthentication.Checked;

        if (this.checkBox_Security_AllowWindowsAuthentication.Checked == false)
        {
            LocalObjCopy.obj_NetworkSecurity.RemotingWrapper_ClearAllWindowsAccountsFromDB();
        }
        else
        {
            LocalObjCopy.obj_NetworkSecurity.RemotingWrapper_RefreshWindowsAccountsDB();
        }

        this.RefreshUserAccountsList();
    }

    private void button_Main_AdditionalParameters_Click(object sender, System.EventArgs e)
    {
        AdditionalParametersForm additionalParametersForm_obj = new AdditionalParametersForm();

        additionalParametersForm_obj.ShowDialog();
    }



    private void button_Main_StartServer_Click(object sender, System.EventArgs e)
    {
        if (LocalObjCopy.obj_NetworkAction.RemotingWrapper_InstanceCount > 0) return;

        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_ServerPort = this.ServerPort;

        LocalObjCopy.obj_NetworkAction.StartServer(this.ServerPort);

        if (LocalObjCopy.obj_NetworkAction.RemotingWrapper_InstanceCount > 0)
        {
            LocalObjCopy.obj_MainServerForm.ServerStatus = ServerStringFactory.GetString(56, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        }
        else
        {
            LocalObjCopy.obj_MainServerForm.ServerStatus = ServerStringFactory.GetString(7, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        }
    }

    static ConnectingServiceProviderForm connectingServiceProviderForm_obj = null;
    private void button_Main_ConnectingService_Click(object sender, EventArgs e)
    {
        try
        {
            connectingServiceProviderForm_obj = new ConnectingServiceProviderForm();

            connectingServiceProviderForm_obj.ShowDialog();
        }
        catch
        {            
            connectingServiceProviderForm_obj = null;
        }
        finally
        {
            connectingServiceProviderForm_obj = null;
        }
    }

    private void button_Main_StopServer_Click(object sender, System.EventArgs e)
    {
        LocalObjCopy.obj_NetworkAction.StopServer();

        if (LocalObjCopy.obj_NetworkAction.RemotingWrapper_InstanceCount > 0)
        {
            LocalObjCopy.obj_MainServerForm.ServerStatus = ServerStringFactory.GetString(56, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        }
        else
        {
            LocalObjCopy.obj_MainServerForm.ServerStatus = ServerStringFactory.GetString(7, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        }
    }

    private void textBox_Main_ListeningPort_TextChanged(object sender, System.EventArgs e)
    {
        ServerPort = int.Parse(this.textBox_Main_ListeningPort.Text);
    }


    ///////////////////////////////// User Accounts

    public void AddUserAcountToListView(string string_Internal_User, string string_Internal_Login, string string_CreationTime, bool bool_IsAccountEnabled, int int_RealIndexInDB)
    {
        ListViewItem listViewItem_SecurityInfo = new ListViewItem(string_Internal_User, 0);

        listViewItem_SecurityInfo.SubItems.Add(string_Internal_Login);
        listViewItem_SecurityInfo.SubItems.Add(string_CreationTime);

        if (bool_IsAccountEnabled == true)
        {
            listViewItem_SecurityInfo.SubItems.Add(ServerStringFactory.GetString(50, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
        }
        else
        {
            listViewItem_SecurityInfo.SubItems.Add(ServerStringFactory.GetString(47, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
            listViewItem_SecurityInfo.ImageIndex = 1;
        }

        listViewItem_SecurityInfo.Tag = int_RealIndexInDB;

        this.listView_Security_ListOfUsersAccounts.Items.Add(listViewItem_SecurityInfo);
    }

    public void RemoveUserAccountFromListView(int int_UserAccountIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_Security_ListOfUsersAccounts.Items[int_UserAccountIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_Security_ListOfUsersAccounts.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_Security_ListOfUsersAccounts.Items.RemoveAt(int_UserAccountIndex);
    }

    public static void EditSelectedUserAccount(int int_SelectedUserAccountRowIndex)
    {
        UsersAccountsManagerForm usersAccountsManagerForm_obj = new UsersAccountsManagerForm();

        usersAccountsManagerForm_obj.OverrideCancelButton.Text = ServerStringFactory.GetString(143, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        if (LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.SecurityDataBase.Rows.Count == 0) return;

        usersAccountsManagerForm_obj.EditedRecordIndex = int_SelectedUserAccountRowIndex;

        usersAccountsManagerForm_obj.AddButton.Visible = false;

        usersAccountsManagerForm_obj.LoginTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.UserNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.NewPasswordTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.ReadOnly = true;

        YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.SecurityDataBase;

        usersAccountsManagerForm_obj.LoginTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserLoginColumn];
        usersAccountsManagerForm_obj.UserNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserNameColumn];
        usersAccountsManagerForm_obj.NewPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.FirstNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserFirstNameColumn];
        usersAccountsManagerForm_obj.LastNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserLastNameColumn];
        usersAccountsManagerForm_obj.MiddleNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserMiddleNameColumn];
        usersAccountsManagerForm_obj.EMailAddressTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.EMailColumn];
        usersAccountsManagerForm_obj.ICQTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.ICQColumn];
        usersAccountsManagerForm_obj.CompanyTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.CompanyColumn];
        usersAccountsManagerForm_obj.HomePhomeTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.WorkPhoneTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.PrivateCellularTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.PrivateCellularColumn];

        usersAccountsManagerForm_obj.EditedRecordIndex = int_SelectedUserAccountRowIndex;

        usersAccountsManagerForm_obj.ShowDialog();
    }

    public static void ViewSelectedUserAccount(int int_SelectedUserAccountRowIndex)
    {
        int_SelectedUserAccountRowIndex = LocalObjCopy.obj_NetworkSecurity.RemotingWrapper_GetYakSysAccountRealRowIndex(int_SelectedUserAccountRowIndex);

        UsersAccountsManagerForm usersAccountsManagerForm_obj = new UsersAccountsManagerForm();

        usersAccountsManagerForm_obj.OverrideCancelButton.Text = ServerStringFactory.GetString(143, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        if (LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.SecurityDataBase.Rows.Count == 0) return;

        usersAccountsManagerForm_obj.ApplyButton.Visible = false;
        usersAccountsManagerForm_obj.AddButton.Visible = false;



        usersAccountsManagerForm_obj.LoginTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.UserNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.NewPasswordTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.FirstNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.MiddleNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.LastNameTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.EMailAddressTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.ICQTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.CompanyTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.HomePhomeTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.WorkPhoneTextBox.ReadOnly = true;
        usersAccountsManagerForm_obj.PrivateCellularTextBox.ReadOnly = true;

        usersAccountsManagerForm_obj.LoginTextBox.Focus();

        YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.SecurityDataBase;

        usersAccountsManagerForm_obj.LoginTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserLoginColumn];
        usersAccountsManagerForm_obj.UserNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserNameColumn];
        usersAccountsManagerForm_obj.NewPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.ConfirmedPasswordTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserPasswordColumn];
        usersAccountsManagerForm_obj.FirstNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserFirstNameColumn];
        usersAccountsManagerForm_obj.LastNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserLastNameColumn];
        usersAccountsManagerForm_obj.MiddleNameTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.UserMiddleNameColumn];
        usersAccountsManagerForm_obj.EMailAddressTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.EMailColumn];
        usersAccountsManagerForm_obj.ICQTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.ICQColumn];
        usersAccountsManagerForm_obj.CompanyTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.CompanyColumn];
        usersAccountsManagerForm_obj.HomePhomeTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.WorkPhoneTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.HomePhoneColumn];
        usersAccountsManagerForm_obj.PrivateCellularTextBox.Text = (string)securityDataBaseDataTable_obj[int_SelectedUserAccountRowIndex][securityDataBaseDataTable_obj.PrivateCellularColumn];

        usersAccountsManagerForm_obj.EditedRecordIndex = int_SelectedUserAccountRowIndex;

        usersAccountsManagerForm_obj.ShowDialog();
    }

    private void button_Security_AddNewUser_Click(object sender, System.EventArgs e)
    {
        UsersAccountsManagerForm usersAccountsManagerForm_obj = new UsersAccountsManagerForm();

        usersAccountsManagerForm_obj.ApplyButton.Visible = false;

        usersAccountsManagerForm_obj.ShowDialog();

        this.RefreshUserAccountsList();
    }

    private void button_Security_DisableUserAccount_Click(object sender, System.EventArgs e)
    {
        if (listView_Security_ListOfUsersAccounts.Items.Count == 0) return;

        if (listView_Security_ListOfUsersAccounts.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(70, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(46, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.SecurityDataBase;

        for (int int_CycleCount = 0; int_CycleCount != this.listView_Security_ListOfUsersAccounts.SelectedItems.Count; int_CycleCount++)
        {
            this.listView_Security_ListOfUsersAccounts.SelectedItems[int_CycleCount].ImageIndex = 1;
            this.listView_Security_ListOfUsersAccounts.SelectedItems[int_CycleCount].SubItems[3].Text = ServerStringFactory.GetString(47, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

            LocalObjCopy.obj_NetworkSecurity_UserAccount.RemotingWrapper_UsersAccounts[(int)this.listView_Security_ListOfUsersAccounts.SelectedItems[int_CycleCount].Tag].DisableAccount();

            LocalObjCopy.obj_YakSysServerLog.RemotingWrapper_InsertDataToLog(ServerStringFactory.GetString(44, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(48, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage) +
                                                       LocalObjCopy.obj_NetworkSecurity_UserAccount.RemotingWrapper_UsersAccounts[(int)this.listView_Security_ListOfUsersAccounts.SelectedItems[int_CycleCount].Tag].User);
        }
    }

    private void button_Security_EnableUserAccount_Click(object sender, System.EventArgs e)
    {
        if (listView_Security_ListOfUsersAccounts.Items.Count == 0) return;

        if (listView_Security_ListOfUsersAccounts.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(70, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(49, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.SecurityDataBaseDataTable securityDataBaseDataTable_obj = LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.SecurityDataBase;

        for (int int_CycleCount = 0; int_CycleCount != this.listView_Security_ListOfUsersAccounts.SelectedItems.Count; int_CycleCount++)
        {
            listView_Security_ListOfUsersAccounts.SelectedItems[int_CycleCount].ImageIndex = 0;
            listView_Security_ListOfUsersAccounts.SelectedItems[int_CycleCount].SubItems[3].Text = ServerStringFactory.GetString(50, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

            LocalObjCopy.obj_NetworkSecurity_UserAccount.RemotingWrapper_UsersAccounts[(int)this.listView_Security_ListOfUsersAccounts.SelectedItems[int_CycleCount].Tag].EnableAccount();

            LocalObjCopy.obj_YakSysServerLog.RemotingWrapper_InsertDataToLog(ServerStringFactory.GetString(44, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(),
                ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(51, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage) + LocalObjCopy.obj_NetworkSecurity_UserAccount.RemotingWrapper_UsersAccounts[(int)this.listView_Security_ListOfUsersAccounts.SelectedItems[int_CycleCount].Tag].User);
        }
    }

    void RemoveUserAccountItems()
    {
        if (this.listView_Security_ListOfUsersAccounts.SelectedItems.Count > 0)
        {
            LocalObjCopy.obj_NetworkSecurity.RemotingWrapper_RemoveAccount((int)this.listView_Security_ListOfUsersAccounts.SelectedItems[0].Tag);

            RemoveUserAccountFromListView(listView_Security_ListOfUsersAccounts.SelectedItems[0].Index);

            RemoveUserAccountItems();
        }
    }

    private void button_Security_RemoveUserAccount_Click(object sender, System.EventArgs e)
    {
        if (this.listView_Security_ListOfUsersAccounts.Items.Count == 0) return;

        if (this.listView_Security_ListOfUsersAccounts.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(70, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(52, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        this.RemoveUserAccountItems();
    }

    private void button_Security_ClearUserAccounts_Click(object sender, System.EventArgs e)
    {
        if (this.listView_Security_ListOfUsersAccounts.Items.Count < 1) return;

        if (DialogResult.Yes == MessageBox.Show(ServerStringFactory.GetString(145, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            LocalObjCopy.obj_NetworkSecurity.RemotingWrapper_ClearAccounts();

            return;
        }

    }

    private void button_Security_ViewUserAccount_Click(object sender, System.EventArgs e)
    {
        if (this.listView_Security_ListOfUsersAccounts.SelectedItems.Count == 0) return;

        ViewSelectedUserAccount((int)this.listView_Security_ListOfUsersAccounts.SelectedItems[0].Tag);
    }

    private void button_Security_EditUserAccount_Click(object sender, System.EventArgs e)
    {
        if (this.listView_Security_ListOfUsersAccounts.SelectedItems.Count == 0) return;

        EditSelectedUserAccount((int)this.listView_Security_ListOfUsersAccounts.SelectedItems[0].Tag);
    }

    ///////////////////////////////// Access Rtestrictions

    public void AddAccessRestrictionRuleToListView(string string_IPRangeValue, string string_IPAddress, string string_MACAddress, DateTime dateTime_CreationTime, string string_RuleType, bool bool_IsRuleEnabled, int int_RealIndexInDB)
    {
        ListViewItem listViewItem_AccessRestrictionRule = new ListViewItem(string_IPRangeValue, 0);

        listViewItem_AccessRestrictionRule.SubItems.Add(string_IPAddress);
        listViewItem_AccessRestrictionRule.SubItems.Add(string_MACAddress);
        listViewItem_AccessRestrictionRule.SubItems.Add(string_RuleType);
        listViewItem_AccessRestrictionRule.SubItems.Add(dateTime_CreationTime.ToShortDateString() + "  " + dateTime_CreationTime.ToLongTimeString());

        if (bool_IsRuleEnabled == true)
        {
            listViewItem_AccessRestrictionRule.ImageIndex = 0;
        }
        else
        {
            listViewItem_AccessRestrictionRule.ImageIndex = 1;
        }

        listViewItem_AccessRestrictionRule.Tag = int_RealIndexInDB;

        this.listView_AccessRestrictions_AccessRestrictionRulesList.Items.Add(listViewItem_AccessRestrictionRule);
    }

    public void EditAccessRestrictionRuleInListView(int int_RecordIndex, string string_IPRangeValue, string string_IPAddress, string string_MACAddress, string string_RuleType)
    {
        ListViewItem listViewItem_AccessRestrictionRule = this.listView_AccessRestrictions_AccessRestrictionRulesList.Items[int_RecordIndex];

        listViewItem_AccessRestrictionRule.SubItems[0].Text = string_IPRangeValue;

        listViewItem_AccessRestrictionRule.SubItems[1].Text = string_IPAddress;
        listViewItem_AccessRestrictionRule.SubItems[2].Text = string_MACAddress;
        listViewItem_AccessRestrictionRule.SubItems[3].Text = string_RuleType;
    }

    public void RemoveAccessRestrictionRuleFromListView(int int_AccessRestrictionRuleIndex)
    {
        int int_DeletedTagIndex = (int)this.listView_AccessRestrictions_AccessRestrictionRulesList.Items[int_AccessRestrictionRuleIndex].Tag;

        foreach (ListViewItem listViewItem_obj in this.listView_AccessRestrictions_AccessRestrictionRulesList.Items)
        {
            if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
            {
                listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
            }
        }

        this.listView_AccessRestrictions_AccessRestrictionRulesList.Items.RemoveAt(int_AccessRestrictionRuleIndex);

        LocalObjCopy.obj_YakSysServerLog.RemotingWrapper_InsertDataToLog(ServerStringFactory.GetString(44, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), DateTime.Now.ToShortDateString(),
                        DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(215, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
    }

    public static void ViewSelectedAccessRestrictionRule(int int_AccessRestrictionRuleRowIndex)
    {
        AccessRestrictionRulesManagerForm accessRestrictionRulesManagerForm_obj = new AccessRestrictionRulesManagerForm();

        accessRestrictionRulesManagerForm_obj.OverrideCancelButton.Text = ServerStringFactory.GetString(143, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        if (LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.AccessRestrictionRules.Rows.Count == 0) return;

        accessRestrictionRulesManagerForm_obj.AddButton.Visible = false;

        string string_MACAddress = String.Empty;

        YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.AccessRestrictionRules;

        accessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.Text = (string)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
        accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text = (string)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];
        accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text = (string)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.IPAddressColumn];

        string_MACAddress = (string)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.MACAddressColumn];

        if (string_MACAddress.Length == 17)
        {
            accessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.Text = string_MACAddress.Substring(0, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.Text = string_MACAddress.Substring(3, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.Text = string_MACAddress.Substring(6, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.Text = string_MACAddress.Substring(9, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.Text = string_MACAddress.Substring(12, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.Text = string_MACAddress.Substring(15, 2);
        }

        accessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Checked = (bool)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

        accessRestrictionRulesManagerForm_obj.RuleTypeComboBox.SelectedIndex = (int)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.RuleTypeColumn];

        accessRestrictionRulesManagerForm_obj.EditedRecordIndex = int_AccessRestrictionRuleRowIndex;


        if (accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Checked = true;
        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Checked = true;

        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length == 0 && accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length == 0)
            accessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Checked = true;

        accessRestrictionRulesManagerForm_obj.AddButton.Visible =
        accessRestrictionRulesManagerForm_obj.ApplyButton.Visible =

        accessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Enabled =

        accessRestrictionRulesManagerForm_obj.RuleTypeComboBox.Enabled =
        accessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Enabled = false;

        accessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.IPAddressTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.ReadOnly =
        accessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.ReadOnly = true;

        accessRestrictionRulesManagerForm_obj.RestrictByIPAddressGroupBox.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByIPRangeGroupBox.Enabled =
        accessRestrictionRulesManagerForm_obj.RestrictByMACAddressGroupBox.Enabled = true;

        accessRestrictionRulesManagerForm_obj.ShowDialog();
    }

    public static void EditSelectedAccessRestrictionRule(int int_AccessRestrictionRuleRowIndex)
    {
        AccessRestrictionRulesManagerForm accessRestrictionRulesManagerForm_obj = new AccessRestrictionRulesManagerForm();

        accessRestrictionRulesManagerForm_obj.OverrideCancelButton.Text = ServerStringFactory.GetString(143, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        if (LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.AccessRestrictionRules.Rows.Count == 0) return;

        accessRestrictionRulesManagerForm_obj.AddButton.Visible = false;

        string string_MACAddress = String.Empty;

        YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.AccessRestrictionRules;

        accessRestrictionRulesManagerForm_obj.IPRangeStartValueTextBox.Text = (string)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.IPRangeStartValueColumn];
        accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text = (string)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.IPRangeEndValueColumn];
        accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text = (string)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.IPAddressColumn];

        string_MACAddress = (string)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.MACAddressColumn];

        if (string_MACAddress.Length == 17)
        {
            accessRestrictionRulesManagerForm_obj.MACAddressValueOneTextBox.Text = string_MACAddress.Substring(0, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueTwoTextBox.Text = string_MACAddress.Substring(3, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueThreeTextBox.Text = string_MACAddress.Substring(6, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFourTextBox.Text = string_MACAddress.Substring(9, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueFiveTextBox.Text = string_MACAddress.Substring(12, 2);
            accessRestrictionRulesManagerForm_obj.MACAddressValueSixTextBox.Text = string_MACAddress.Substring(15, 2);
        }

        accessRestrictionRulesManagerForm_obj.AddMACAdressToRuleCheckBox.Checked = (bool)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.ComplementaryUseMACAddressColumn];

        accessRestrictionRulesManagerForm_obj.RuleTypeComboBox.SelectedIndex = (int)accessRestrictionRulesDataTable_obj[int_AccessRestrictionRuleRowIndex][accessRestrictionRulesDataTable_obj.RuleTypeColumn];

        accessRestrictionRulesManagerForm_obj.EditedRecordIndex = int_AccessRestrictionRuleRowIndex;


        if (accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPRangeRadioButton.Checked = true;
        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length >= 7) accessRestrictionRulesManagerForm_obj.RestrictByIPAddressRadioButton.Checked = true;

        if (accessRestrictionRulesManagerForm_obj.IPAddressTextBox.Text.Length == 0 && accessRestrictionRulesManagerForm_obj.IPRangeEndValueTextBox.Text.Length == 0)
            accessRestrictionRulesManagerForm_obj.RestrictByMACAddressRadioButton.Checked = true;

        accessRestrictionRulesManagerForm_obj.ShowDialog();
    }

    private void button_AccessRestrictions_AddRestriction_Click(object sender, System.EventArgs e)
    {
        AccessRestrictionRulesManagerForm accessRestrictionRulesManagerForm_obj = new AccessRestrictionRulesManagerForm();

        accessRestrictionRulesManagerForm_obj.ApplyButton.Visible = false;

        accessRestrictionRulesManagerForm_obj.ShowDialog();

        this.RefreshAccessRestrictionRulesList();
    }

    private void button_AccessRestrictions_EditRestriction_Click(object sender, System.EventArgs e)
    {
        if (this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems.Count == 0) return;

        EditSelectedAccessRestrictionRule((int)this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems[0].Tag);
    }

    private void button_AccessRestrictions_ViewRestriction_Click(object sender, System.EventArgs e)
    {
        if (this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems.Count == 0) return;

        ViewSelectedAccessRestrictionRule((int)this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems[0].Tag);
    }

    void RemoveAccessRestrictionsItems()
    {
        if (this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems.Count > 0)
        {
            LocalObjCopy.obj_NetworkSecurity.RemotingWrapper_RemoveAccessRestrictionRule((int)this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems[0].Tag);

            this.RemoveAccessRestrictionRuleFromListView(this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems[0].Index);

            this.RemoveAccessRestrictionsItems();
        }
    }

    private void button_AccessRestrictions_RemoveRestriction_Click(object sender, System.EventArgs e)
    {
        if (this.listView_AccessRestrictions_AccessRestrictionRulesList.Items.Count < 1)
        {
            return;
        }

        if (this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(210, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(211, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        this.RemoveAccessRestrictionsItems();
    }

    private void button_AccessRestrictions_ClearRestrictions_Click(object sender, System.EventArgs e)
    {
        if (this.listView_AccessRestrictions_AccessRestrictionRulesList.Items.Count < 1)
        {
            return;
        }

        if (DialogResult.Yes == MessageBox.Show(ServerStringFactory.GetString(209, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            LocalObjCopy.obj_NetworkSecurity.RemotingWrapper_ClearAccessRestrictionRules();

            return;
        }
    }

    private void button_AccessRestrictions_DisableRestriction_Click(object sender, System.EventArgs e)
    {
        if (this.listView_AccessRestrictions_AccessRestrictionRulesList.Items.Count == 0)
        {
            return;
        }

        if (this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(210, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(213, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.AccessRestrictionRules;

        for (int int_CycleCount = 0; int_CycleCount != this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems.Count; int_CycleCount++)
        {
            this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems[int_CycleCount].ImageIndex = 1;

            LocalObjCopy.obj_NetworkSecurity_AccessRestrictionRuleObject.RemotingWrapper_AccessRestrictionRules[(int)this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems[int_CycleCount].Tag].DisableRule();

            LocalObjCopy.obj_YakSysServerLog.RemotingWrapper_InsertDataToLog(ServerStringFactory.GetString(44, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), DateTime.Now.ToShortDateString(),
                                                                                 DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(217, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
        }
    }

    private void button_AccessRestrictions_EnableRestriction_Click(object sender, System.EventArgs e)
    {
        if (this.listView_AccessRestrictions_AccessRestrictionRulesList.Items.Count == 0)
        {
            return;
        }

        if (this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(210, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(212, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        YakSysRct_Xml_Config_Importer.Server_DataSet_ver_110.DataSet_YakSysServerDB.AccessRestrictionRulesDataTable accessRestrictionRulesDataTable_obj = LocalObjCopy.obj_YakSysRctServerV110XMLConfigImporter.RemotingWrapper_YakSysServerDB.AccessRestrictionRules;

        for (int int_CycleCount = 0; int_CycleCount != this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems.Count; int_CycleCount++)
        {
            this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems[int_CycleCount].ImageIndex = 0;

            LocalObjCopy.obj_NetworkSecurity_AccessRestrictionRuleObject.RemotingWrapper_AccessRestrictionRules[(int)this.listView_AccessRestrictions_AccessRestrictionRulesList.SelectedItems[int_CycleCount].Tag].EnableRule();

            LocalObjCopy.obj_YakSysServerLog.RemotingWrapper_InsertDataToLog(ServerStringFactory.GetString(44, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), DateTime.Now.ToShortDateString(),
                                                                                DateTime.Now.ToLongTimeString(), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(216, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
        }
    }

    private void checkBox_AccessRestrictions_EnableAccessRestrictions_CheckedChanged(object sender, System.EventArgs e)
    {
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_EnableAccessRestrictionRules = this.checkBox_AccessRestrictions_EnableAccessRestrictions.Checked;

        this.listView_AccessRestrictions_AccessRestrictionRulesList.Enabled =
        this.button_AccessRestrictions_AddRestriction.Enabled =
        this.button_AccessRestrictions_ClearRestrictions.Enabled =
        this.button_AccessRestrictions_EditRestriction.Enabled =
        this.button_AccessRestrictions_RemoveRestriction.Enabled =
        this.button_AccessRestrictions_ViewRestriction.Enabled =
        this.button_AccessRestrictions_EnableRestriction.Enabled =
        this.button_AccessRestrictions_DisableRestriction.Enabled =
        this.label_AccessRestrictions_ListOfAccessRestrictionsRules.Enabled = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_EnableAccessRestrictionRules;
    }

    /////////////////////////////////   Active connections

    private void button_CurrentConnections_DisconnectAll_Click(object sender, System.EventArgs e)
    {
        if (MessageBox.Show(ServerStringFactory.GetString(178, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        LocalObjCopy.obj_NetworkAction.DisconnectAllClients();

        this.RefreshActiveConnectionsList();
    }

    void RemoveActiveConnectionsItems()
    {
        if (this.listView_ActiveConnections_CurrentConnections.SelectedItems.Count > 0 && LocalObjCopy.obj_SessionStatisticAndInfo.RemotingWrapper_AllSessionStatisticAndInfoOjects.Count > 0)
        {
            LocalObjCopy.obj_NetworkAction.DisconnectNecessaryClient((int)this.listView_ActiveConnections_CurrentConnections.SelectedItems[0].Tag, 2);

            this.RemoveActiveConnectionsItems();
        }
    }

    private void button_CurrentConnections_Disconnect_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ActiveConnections_CurrentConnections.Items.Count == 0 ||
            LocalObjCopy.obj_SessionStatisticAndInfo.RemotingWrapper_AllSessionStatisticAndInfoOjects.Count == 0)
        {
            this.RefreshActiveConnectionsList();

            return;
        }

        if (this.listView_ActiveConnections_CurrentConnections.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(179, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        if (MessageBox.Show(ServerStringFactory.GetString(177, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            != DialogResult.Yes)
        {
            return;
        }

        this.RemoveActiveConnectionsItems();
    }

    private void button_CurrentConnections_Details_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ActiveConnections_CurrentConnections.Items.Count == 0 ||
            LocalObjCopy.obj_SessionStatisticAndInfo.RemotingWrapper_AllSessionStatisticAndInfoOjects.Count == 0)
        {
            this.RefreshActiveConnectionsList();

            return;
        }

        if (this.listView_ActiveConnections_CurrentConnections.SelectedItems.Count == 0)
        {
            MessageBox.Show(ServerStringFactory.GetString(181, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return;
        }

        YakSysTcpClient.SessionStatisticAndInfo sessionStatisticAndInfo_CurrentObj = LocalObjCopy.obj_SessionStatisticAndInfo.RemotingWrapper_AllSessionStatisticAndInfoOjects[(int)this.listView_ActiveConnections_CurrentConnections.SelectedItems[0].Tag];

        ActiveConnectionDetailsForm activeConnectionDetailsForm_obj = new ActiveConnectionDetailsForm();

        activeConnectionDetailsForm_obj.NetworkInformation_IPAddress = sessionStatisticAndInfo_CurrentObj.ClientIPAddress;

        activeConnectionDetailsForm_obj.NetworkInformation_MACAddress = LocalObjCopy.obj_NetworkAction.RemotingWrapper_ResolveMACAddressFromIP(sessionStatisticAndInfo_CurrentObj.ClientIPAddress);

        activeConnectionDetailsForm_obj.Statistic_BytesSent = sessionStatisticAndInfo_CurrentObj.Statistic_BytesSent;
        activeConnectionDetailsForm_obj.Statistic_BytesReceived = sessionStatisticAndInfo_CurrentObj.Statistic_BytesReceived;

        activeConnectionDetailsForm_obj.Statistic_ConnectedAt = sessionStatisticAndInfo_CurrentObj.Statistic_ConnectedTime.ToShortDateString() + "   " + sessionStatisticAndInfo_CurrentObj.Statistic_ConnectedTime.ToLongTimeString();

        activeConnectionDetailsForm_obj.ShowDialog();

        activeConnectionDetailsForm_obj.Close();
    }

    public void InsertNewActiveConnectionToList(string string_UserName, string string_IPAddress, string string_AccountType, bool bol_IsAccountEnabled)
    {
        if (this.IsHandleCreated == false) return;

        this.Invoke((MethodInvoker)delegate
        {
            ListViewItem listViewItem_NewActiveConnection = new ListViewItem(string_UserName, this.listView_ActiveConnections_CurrentConnections.Items.Count);

            listViewItem_NewActiveConnection.ImageIndex = 0;

            listViewItem_NewActiveConnection.SubItems.Add(string_IPAddress);
            listViewItem_NewActiveConnection.SubItems.Add(ServerStringFactory.GetString(175, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage));
            listViewItem_NewActiveConnection.SubItems.Add(string_AccountType);

            listViewItem_NewActiveConnection.Tag = this.listView_ActiveConnections_CurrentConnections.Items.Count;

            this.listView_ActiveConnections_CurrentConnections.Items.Add(listViewItem_NewActiveConnection);
        });
    }

    public void RemoveActiveConnectionFromListView(int int_ConnectionIndex)
    {
        try
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                int int_DeletedTagIndex = (int)this.listView_ActiveConnections_CurrentConnections.Items[int_ConnectionIndex].Tag;

                this.listView_ActiveConnections_CurrentConnections.Items.RemoveAt(int_ConnectionIndex);	//? перенесено сюда в связи с неправельным удалением из списка !

                foreach (ListViewItem listViewItem_obj in this.listView_ActiveConnections_CurrentConnections.Items)
                {
                    if ((int)listViewItem_obj.Tag > int_DeletedTagIndex)
                    {
                        listViewItem_obj.Tag = (int)listViewItem_obj.Tag - 1;
                    }
                }

                //  this.listView_ActiveConnections_CurrentConnections.Items.RemoveAt(int_ConnectionIndex);// в версии 0.9 было здесь!
            });
        }
        catch { }
    }

    public void ChangeActiveConnectionStatusInListView(int int_ConnectionIndex, int int_StatusTypeIndex)
    {
        this.Invoke((MethodInvoker)delegate
        {
            switch (int_StatusTypeIndex)
            {
                case 0:
                    this.listView_ActiveConnections_CurrentConnections.Items[int_ConnectionIndex].SubItems[2].Text = ServerStringFactory.GetString(176, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
                    break;

                case 1:
                    this.listView_ActiveConnections_CurrentConnections.Items[int_ConnectionIndex].SubItems[2].Text = ServerStringFactory.GetString(175, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
                    break;
            }
        });
    }

    ///////////////////////////////// Column Sort

    ListViewColumnSorter listViewColumnSorter_UsersAccounts = new ListViewColumnSorter(),
                         listViewColumnSorter_EventsLog = new ListViewColumnSorter(),
                         listViewColumnSorter_ActiveConnections = new ListViewColumnSorter(),
                         listViewColumnSorter_AccessRestrictionRules = new ListViewColumnSorter();

    private void listView_Security_ListOfUsersAccounts_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_Security_ListOfUsersAccounts.ListViewItemSorter = this.listViewColumnSorter_UsersAccounts;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == this.listViewColumnSorter_UsersAccounts.SortColumn)
        {
            if (this.listViewColumnSorter_UsersAccounts.Order == SortOrder.Ascending)
                this.listViewColumnSorter_UsersAccounts.Order = SortOrder.Descending;

            else this.listViewColumnSorter_UsersAccounts.Order = SortOrder.Ascending;
        }
        else
        {
            this.listViewColumnSorter_UsersAccounts.SortColumn = e.Column;
            this.listViewColumnSorter_UsersAccounts.Order = SortOrder.Ascending;
        }

        this.listView_Security_ListOfUsersAccounts.Sort();
    }

    private void listView_MainServerForm_EventsLog_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_MainServerForm_EventsLog.ListViewItemSorter = listViewColumnSorter_EventsLog;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_EventsLog.SortColumn)
        {
            if (listViewColumnSorter_EventsLog.Order == SortOrder.Ascending)
                listViewColumnSorter_EventsLog.Order = SortOrder.Descending;

            else listViewColumnSorter_EventsLog.Order = SortOrder.Ascending;
        }
        else
        {
            listViewColumnSorter_EventsLog.SortColumn = e.Column;
            listViewColumnSorter_EventsLog.Order = SortOrder.Ascending;
        }

        this.listView_MainServerForm_EventsLog.Sort();
    }

    private void listView_ActiveConnections_CurrentConnections_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_ActiveConnections_CurrentConnections.ListViewItemSorter = this.listViewColumnSorter_ActiveConnections;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == this.listViewColumnSorter_ActiveConnections.SortColumn)
        {
            if (this.listViewColumnSorter_ActiveConnections.Order == SortOrder.Ascending)
                this.listViewColumnSorter_ActiveConnections.Order = SortOrder.Descending;

            else this.listViewColumnSorter_ActiveConnections.Order = SortOrder.Ascending;
        }
        else
        {
            this.listViewColumnSorter_ActiveConnections.SortColumn = e.Column;
            this.listViewColumnSorter_ActiveConnections.Order = SortOrder.Ascending;
        }

        this.listView_ActiveConnections_CurrentConnections.Sort();
    }

    private void listView_AccessRestrictions_AccessRestrictionRulesList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_AccessRestrictions_AccessRestrictionRulesList.ListViewItemSorter = this.listViewColumnSorter_AccessRestrictionRules;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == this.listViewColumnSorter_AccessRestrictionRules.SortColumn)
        {
            if (this.listViewColumnSorter_AccessRestrictionRules.Order == SortOrder.Ascending)
                this.listViewColumnSorter_AccessRestrictionRules.Order = SortOrder.Descending;

            else this.listViewColumnSorter_AccessRestrictionRules.Order = SortOrder.Ascending;
        }
        else
        {
            this.listViewColumnSorter_AccessRestrictionRules.SortColumn = e.Column;
            this.listViewColumnSorter_AccessRestrictionRules.Order = SortOrder.Ascending;
        }

        this.listView_AccessRestrictions_AccessRestrictionRulesList.Sort();
    }

    ///////////////////////////////// Refresh lists data

    private void tabControl_Main_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.tabControl_Main.SelectedTab == this.tabPage_NetworkControl)
        {
            this.RefreshActiveConnectionsList();
        }

        if (this.tabControl_Main.SelectedTab == this.tabPage_Log)
        {
            this.RefreshDataLogList();
        }

        if (this.tabControl_Main.SelectedTab == this.tabPage_Security)
        {
            this.RefreshUserAccountsList();
        }

        if (this.tabControl_Main.SelectedTab == this.tabPage_AccessRestrictions)
        {
            this.RefreshAccessRestrictionRulesList();
        }
    }

    void RefreshDataLogList()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_MainServerForm_EventsLog.Items.Clear();

            this.listView_MainServerForm_EventsLog.Items.AddRange(LocalObjCopy.obj_YakSysServerDBEnvironment.GetEventsLog());
        });
    }

    void RefreshActiveConnectionsList()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.listView_ActiveConnections_CurrentConnections.Items.Clear();

            foreach (YakSysTcpClient.SessionStatisticAndInfo sessionStatisticAndInfo_obj in LocalObjCopy.obj_SessionStatisticAndInfo.RemotingWrapper_AllSessionStatisticAndInfoOjects)
            {
                try
                {
                    sessionStatisticAndInfo_obj.IsNewObject = false;

                    LocalObjCopy.obj_MainServerForm.InsertNewActiveConnectionToList(sessionStatisticAndInfo_obj.NetworkInformation_UserName, sessionStatisticAndInfo_obj.ClientIPAddress, sessionStatisticAndInfo_obj.NetworkInformation_AccountType, sessionStatisticAndInfo_obj.IsAccountEnabled);
                }
                catch { }
            }
        });
    }

    void RefreshUserAccountsList()
    {
        this.Invoke((MethodInvoker)delegate
        {
            LocalObjCopy.obj_MainServerForm.listView_Security_ListOfUsersAccounts.Items.Clear();

            foreach (NetworkSecurity.UserAccount userAccount_obj in LocalObjCopy.obj_NetworkSecurity_UserAccount.RemotingWrapper_UsersAccounts)
            {
                userAccount_obj.IsNewObject = false;

                if (userAccount_obj.AccountType == NetworkSecurity.UserAccount.AccountTypesEnum.YakSysAccount)
                {
                    LocalObjCopy.obj_MainServerForm.AddUserAcountToListView(userAccount_obj.User, userAccount_obj.Login, userAccount_obj.TimeOfCreation, userAccount_obj.IsEnabled, LocalObjCopy.obj_NetworkSecurity_UserAccount.RemotingWrapper_UsersAccounts.IndexOf(userAccount_obj));
                }
            }
        });
    }

    void RefreshAccessRestrictionRulesList()
    {
        this.Invoke((MethodInvoker)delegate
        {
            LocalObjCopy.obj_MainServerForm.listView_AccessRestrictions_AccessRestrictionRulesList.Items.Clear();

            IPAddress ipAddress_RangeValue = IPAddress.None,
                       ipAddress_SingleValue = IPAddress.None;

            string string_MACAddress = string.Empty,
                    string_RuleType = string.Empty,
                    string_IPAddress = string.Empty,
                    string_IPAddressRange = string.Empty;

            DateTime dateTime_CreationTime = DateTime.MinValue;

            foreach (NetworkSecurity.AccessRestrictionRuleObject accessRestrictionRule_obj in LocalObjCopy.obj_NetworkSecurity_AccessRestrictionRuleObject.RemotingWrapper_AccessRestrictionRules)
            {
                accessRestrictionRule_obj.IsNewObject = false;

                ipAddress_RangeValue = IPAddress.None;
                ipAddress_SingleValue = IPAddress.None;

                string_MACAddress = string.Empty;
                string_RuleType = string.Empty;
                string_IPAddressRange = string.Empty;
                string_IPAddress = string.Empty;

                dateTime_CreationTime = DateTime.MinValue;

                if (accessRestrictionRule_obj.IPAddressesRangeStartValue != null &&
                    accessRestrictionRule_obj.IPAddressesRangeEndValue != null)
                {
                    string_IPAddressRange = accessRestrictionRule_obj.IPAddressesRangeStartValue.ToString() + " - " + accessRestrictionRule_obj.IPAddressesRangeEndValue.ToString();
                }

                if (accessRestrictionRule_obj.IPAddress != null)
                {
                    string_IPAddress = accessRestrictionRule_obj.IPAddress.ToString();
                }

                if (accessRestrictionRule_obj.MACAddress != null)
                {
                    string_MACAddress = accessRestrictionRule_obj.MACAddress;
                }

                if (accessRestrictionRule_obj.CreationTime != null)
                {
                    dateTime_CreationTime = accessRestrictionRule_obj.CreationTime;
                }

                if (accessRestrictionRule_obj.RuleType == 0)
                {
                    string_RuleType = ServerStringFactory.GetString(197, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
                }
                else
                {
                    string_RuleType = ServerStringFactory.GetString(198, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
                }

                LocalObjCopy.obj_MainServerForm.AddAccessRestrictionRuleToListView(string_IPAddressRange, string_IPAddress, string_MACAddress, dateTime_CreationTime, string_RuleType, accessRestrictionRule_obj.IsEnabled, LocalObjCopy.obj_NetworkSecurity_AccessRestrictionRuleObject.RemotingWrapper_AccessRestrictionRules.IndexOf(accessRestrictionRule_obj));
            }
        });
    }

    public void RefreshListsContentThread()
    {
        int int_YakSysAccountCount = 0;

        for (; ; Thread.Sleep(1000))
        {
            try
            {
                this.Statistic_BytesSent = LocalObjCopy.obj_NetworkStatusAndStatistics.RemotingWrapper_Statistic_BytesSent;
                this.Statistic_BytesReceived = LocalObjCopy.obj_NetworkStatusAndStatistics.RemotingWrapper_Statistic_BytesReceived;
                this.Statistic_ActiveConnections = LocalObjCopy.obj_NetworkStatusAndStatistics.RemotingWrapper_Statistic_ActiveConnections;
                this.Statistic_LastConnectionAt = LocalObjCopy.obj_NetworkStatusAndStatistics.RemotingWrapper_Statistic_LastConnectionAt; //!! не на русском

                this.ServerStatus = LocalObjCopy.obj_NetworkStatusAndStatistics.RemotingWrapper_ServerStatus;

                foreach (NetworkSecurity.AccessRestrictionRuleObject accessRestrictionRule_obj in LocalObjCopy.obj_NetworkSecurity_AccessRestrictionRuleObject.RemotingWrapper_AccessRestrictionRules)
                {
                    if (accessRestrictionRule_obj.IsNewObject == true ||
                        LocalObjCopy.obj_NetworkSecurity_AccessRestrictionRuleObject.RemotingWrapper_AccessRestrictionRules.Count != this.listView_AccessRestrictions_AccessRestrictionRulesList.Items.Count)
                    {
                        this.RefreshAccessRestrictionRulesList();
                    }
                }

                foreach (YakSysTcpClient.SessionStatisticAndInfo sessionStatisticAndInfo_obj in LocalObjCopy.obj_SessionStatisticAndInfo.RemotingWrapper_AllSessionStatisticAndInfoOjects)
                {
                    if (sessionStatisticAndInfo_obj.IsNewObject == true)
                    {
                        Thread.Sleep(1000);

                        this.RefreshActiveConnectionsList();
                    }
                }

                foreach (NetworkSecurity.UserAccount userAccount_obj in LocalObjCopy.obj_NetworkSecurity_UserAccount.RemotingWrapper_UsersAccounts)
                {
                    if (userAccount_obj.AccountType == NetworkSecurity.UserAccount.AccountTypesEnum.YakSysAccount)
                    {
                        int_YakSysAccountCount++;
                    }

                    if (userAccount_obj.IsNewObject == true)
                    {
                        this.RefreshUserAccountsList();
                    }
                }

                if (int_YakSysAccountCount != this.listView_Security_ListOfUsersAccounts.Items.Count)
                {
                    this.RefreshUserAccountsList();
                }

                if (LocalObjCopy.obj_SessionStatisticAndInfo.RemotingWrapper_AllSessionStatisticAndInfoOjects.Count != this.listView_ActiveConnections_CurrentConnections.Items.Count)
                {
                    this.RefreshActiveConnectionsList();
                }

                if (LocalObjCopy.obj_NetworkSecurity_AccessRestrictionRuleObject.RemotingWrapper_AccessRestrictionRules.Count != this.listView_AccessRestrictions_AccessRestrictionRulesList.Items.Count)
                {
                    this.RefreshAccessRestrictionRulesList();
                }

                int_YakSysAccountCount = 0;
            }
            catch (RemotingException)
            {
            }
        }
    }

    public void CheckRemotingConnectionThread()
    {//!!!!! баг! сервис есть а экцепшн вылетает!
        for (; ; Thread.Sleep(200))
        {
            try
            {
                if (LocalObjCopy.obj_NetworkAction.RemotingWrapper_InstanceCount == 0)
                {
                }
            }
            catch (RemotingException)
            {
                this.Invoke((MethodInvoker)delegate
                {
                   MessageBox.Show(ServerStringFactory.GetString(760, 0), ServerStringFactory.GetString(1, 0));

                   Process.GetCurrentProcess().Kill();
                });
            }
        }

    }

    ///////////////////////////////// Invoke Delegates and Properties

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
                        MessageBox.Show(ServerStringFactory.GetString(87, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK);
                        return -1;
                    }

                    return Convert.ToInt32(textBox_Main_ListeningPort.Text);
                }

                catch (FormatException)
                {
                    MessageBox.Show(ServerStringFactory.GetString(87, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK);
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

    long long_BytesReceived = 0;

    long long_BytesSent = 0;

    public long Statistic_BytesSent
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.long_BytesSent = value;

                this.statusBarPanel_BytesSent.Text = ServerStringFactory.GetString(163, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage) + " " + this.SpreadToHundreds(this.long_BytesSent.ToString());
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (long)this.Invoke((delegate_ReturningLongMethod)delegate
            {
                return this.long_BytesSent;
            });
        }
    }

    public long Statistic_BytesReceived
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.long_BytesReceived = value;

                this.statusBarPanel_BytesReceived.Text = ServerStringFactory.GetString(164, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage) + " " + this.SpreadToHundreds(this.long_BytesReceived.ToString());
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (long)this.Invoke((delegate_ReturningLongMethod)delegate
            {
                return this.long_BytesReceived;
            });
        }
    }

    long long_ActiveConnections = 0;
    public long Statistic_ActiveConnections
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                long_ActiveConnections = value;

                this.statusBarPanel_Connections.Text = ServerStringFactory.GetString(166, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage) + " " + value.ToString();
            });
        }

        get
        {
            return long_ActiveConnections;
        }
    }

    public string Statistic_LastConnectionAt
    {
        set
        {
            if (this.IsHandleCreated == false) return;

            this.Invoke((MethodInvoker)delegate
            {
                this.statusBarPanel_LastConnectionTime.Text = value;
            });
        }
    }

    #endregion


}