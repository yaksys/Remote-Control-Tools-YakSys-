using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;
using YakSysRct_Xml_Config_Importer;

public class YakSysServersDBManagerForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.TextBox textBox_YakSysServersDBManagerForm_ServerDescription;
    private System.Windows.Forms.Button button_YakSysServersDBManagerForm_Apply;
    private System.Windows.Forms.Button button_YakSysServersDBManagerForm_Cancel;
    private System.Windows.Forms.Button button_YakSysServersDBManagerForm_AddToDB;
    private System.Windows.Forms.TextBox textBox_YakSysServersDBManagerForm_ServerHost;
    private System.Windows.Forms.TextBox textBox_YakSysServersDBManagerForm_ServerLocation;
    private System.Windows.Forms.TextBox textBox_YakSysServersDBManagerForm_ServerName;
    private System.Windows.Forms.TextBox textBox_YakSysServersDBManagerForm_ServerPort;
    private System.Windows.Forms.TextBox textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup;
    private System.Windows.Forms.TextBox textBox_YakSysServersDBManagerForm_ServerNetworkDomain;
    private System.Windows.Forms.TextBox textBox_YakSysServersDBManagerForm_LoginForConnection;
    private System.Windows.Forms.TextBox textBox_YakSysServersDBManagerForm_PasswordForConnection;
    private System.Windows.Forms.Label label_YakSysServersDBManagerForm_ServerHost;
    private System.Windows.Forms.Label label_YakSysServersDBManagerForm_LoginForConnection;
    private System.Windows.Forms.Label label_YakSysServersDBManagerForm_ServerName;
    private System.Windows.Forms.Label label_YakSysServersDBManagerForm_ServerNetworkWorkgroup;
    private System.Windows.Forms.Label label_YakSysServersDBManagerForm_ServerDescription;
    private System.Windows.Forms.Label label_YakSysServersDBManagerForm_ServerNetworkDomain;
    private System.Windows.Forms.Label label_YakSysServersDBManagerForm_ServerLocation;
    private System.Windows.Forms.Label label_YakSysServersDBManagerForm_PasswordForConnection;
    private System.Windows.Forms.Label label_YakSysServersDBManagerForm_ServerPort;
    private System.Windows.Forms.ListView listView_ProxyServersList_ProxyServersList;
    private System.Windows.Forms.ColumnHeader columnHeader_ProxyServersList_Title;
    private System.Windows.Forms.ColumnHeader columnHeader_ProxyServersList_Host;
    private System.Windows.Forms.ColumnHeader columnHeader_ProxyServersList_Port;
    private System.Windows.Forms.Button button_ProxyServersList_ViewRecord;
    private System.Windows.Forms.Button button_ProxyServersList_AddRecord;
    private System.Windows.Forms.Button button_ProxyServersList_EditRecord;
    private System.Windows.Forms.GroupBox groupBox_YakSysServersDBManagerForm_ProxyServersList;
    private System.Windows.Forms.CheckBox checkBox_YakSysServersDBManagerForm_UseProxy;
    private System.Windows.Forms.GroupBox groupBox_YakSysServersDBManagerForm_GroupsList;
    private System.Windows.Forms.Button button_GroupsList_RenameGroup;
    private System.Windows.Forms.Label label_GroupsList_GroupsList;
    private System.Windows.Forms.Button button_GroupsList_RemoveGroup;
    private System.Windows.Forms.ListBox listBox_GroupsList_GroupsList;
    private System.Windows.Forms.Button button_GroupsList_AddNewGroup;
    private System.Windows.Forms.Label label_ProxyServersList_ProxyServersList;

    private System.ComponentModel.Container components = null;

    public YakSysServersDBManagerForm()
    {
        InitializeComponent();

        ChangeControlsLanguage();

        this.checkBox_YakSysServersDBManagerForm_UseProxy.Checked = false;

        UpdateProxyServersList();

        this.listBox_GroupsList_GroupsList.Items.Clear();

        string[] stringArray_ServersGroupsItems = new YakSys.XMLConfigImporter.YakSysClientDBEnvironment().GetServersGroupsItems();

        if (stringArray_ServersGroupsItems != null)
            this.listBox_GroupsList_GroupsList.Items.AddRange(stringArray_ServersGroupsItems);

        if (this.listBox_GroupsList_GroupsList.Items.Count > 0)
        {
            this.listBox_GroupsList_GroupsList.SelectedIndex = 0;
            this.listBox_GroupsList_GroupsList.Select();
        }

        if (this.listView_ProxyServersList_ProxyServersList.Items.Count > 0)
        {
            this.listView_ProxyServersList_ProxyServersList.Items[0].Selected = true;
            this.listView_ProxyServersList_ProxyServersList.Select();
        }
    }
    
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
    
    void ChangeControlsLanguage()
    {
        this.Text = ClientStringFactory.GetString(492, ClientSettingsEnvironment.CurrentLanguage);

        this.button_YakSysServersDBManagerForm_Apply.Text = ClientStringFactory.GetString(307, ClientSettingsEnvironment.CurrentLanguage);
        this.button_YakSysServersDBManagerForm_Cancel.Text = ClientStringFactory.GetString(265, ClientSettingsEnvironment.CurrentLanguage);
        this.button_YakSysServersDBManagerForm_AddToDB.Text = ClientStringFactory.GetString(311, ClientSettingsEnvironment.CurrentLanguage);

        this.label_YakSysServersDBManagerForm_ServerHost.Text = ClientStringFactory.GetString(77, ClientSettingsEnvironment.CurrentLanguage);
        this.label_YakSysServersDBManagerForm_LoginForConnection.Text = ClientStringFactory.GetString(74, ClientSettingsEnvironment.CurrentLanguage);
        this.label_YakSysServersDBManagerForm_ServerName.Text = ClientStringFactory.GetString(493, ClientSettingsEnvironment.CurrentLanguage);
        this.label_YakSysServersDBManagerForm_ServerNetworkWorkgroup.Text = ClientStringFactory.GetString(494, ClientSettingsEnvironment.CurrentLanguage);
        this.label_YakSysServersDBManagerForm_ServerNetworkDomain.Text = ClientStringFactory.GetString(495, ClientSettingsEnvironment.CurrentLanguage);
        this.label_YakSysServersDBManagerForm_ServerDescription.Text = ClientStringFactory.GetString(314, ClientSettingsEnvironment.CurrentLanguage);
        this.label_YakSysServersDBManagerForm_ServerLocation.Text = ClientStringFactory.GetString(487, ClientSettingsEnvironment.CurrentLanguage);
        this.label_YakSysServersDBManagerForm_PasswordForConnection.Text = ClientStringFactory.GetString(73, ClientSettingsEnvironment.CurrentLanguage);
        this.label_YakSysServersDBManagerForm_ServerPort.Text = ClientStringFactory.GetString(72, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.Text = ClientStringFactory.GetString(502, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Title.Text = ClientStringFactory.GetString(485, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Host.Text = ClientStringFactory.GetString(317, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Port.Text = ClientStringFactory.GetString(316, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_ViewRecord.Text = ClientStringFactory.GetString(306, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_AddRecord.Text = ClientStringFactory.GetString(311, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_EditRecord.Text = ClientStringFactory.GetString(483, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_YakSysServersDBManagerForm_UseProxy.Text = ClientStringFactory.GetString(382, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxyServersList_ProxyServersList.Text = ClientStringFactory.GetString(503, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_YakSysServersDBManagerForm_GroupsList.Text = ClientStringFactory.GetString(496, ClientSettingsEnvironment.CurrentLanguage);
        this.button_GroupsList_RenameGroup.Text = ClientStringFactory.GetString(86, ClientSettingsEnvironment.CurrentLanguage);
        this.label_GroupsList_GroupsList.Text = ClientStringFactory.GetString(497, ClientSettingsEnvironment.CurrentLanguage);
        this.button_GroupsList_RemoveGroup.Text = ClientStringFactory.GetString(312, ClientSettingsEnvironment.CurrentLanguage);
        this.button_GroupsList_AddNewGroup.Text = ClientStringFactory.GetString(311, ClientSettingsEnvironment.CurrentLanguage);

    }


    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YakSysServersDBManagerForm));
        this.textBox_YakSysServersDBManagerForm_ServerHost = new System.Windows.Forms.TextBox();
        this.textBox_YakSysServersDBManagerForm_ServerLocation = new System.Windows.Forms.TextBox();
        this.textBox_YakSysServersDBManagerForm_ServerName = new System.Windows.Forms.TextBox();
        this.textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup = new System.Windows.Forms.TextBox();
        this.textBox_YakSysServersDBManagerForm_LoginForConnection = new System.Windows.Forms.TextBox();
        this.textBox_YakSysServersDBManagerForm_PasswordForConnection = new System.Windows.Forms.TextBox();
        this.textBox_YakSysServersDBManagerForm_ServerNetworkDomain = new System.Windows.Forms.TextBox();
        this.textBox_YakSysServersDBManagerForm_ServerPort = new System.Windows.Forms.TextBox();
        this.textBox_YakSysServersDBManagerForm_ServerDescription = new System.Windows.Forms.TextBox();
        this.button_YakSysServersDBManagerForm_Apply = new System.Windows.Forms.Button();
        this.button_YakSysServersDBManagerForm_Cancel = new System.Windows.Forms.Button();
        this.button_YakSysServersDBManagerForm_AddToDB = new System.Windows.Forms.Button();
        this.label_YakSysServersDBManagerForm_ServerHost = new System.Windows.Forms.Label();
        this.label_YakSysServersDBManagerForm_LoginForConnection = new System.Windows.Forms.Label();
        this.label_YakSysServersDBManagerForm_ServerName = new System.Windows.Forms.Label();
        this.label_YakSysServersDBManagerForm_ServerNetworkWorkgroup = new System.Windows.Forms.Label();
        this.label_YakSysServersDBManagerForm_ServerDescription = new System.Windows.Forms.Label();
        this.label_YakSysServersDBManagerForm_ServerNetworkDomain = new System.Windows.Forms.Label();
        this.label_YakSysServersDBManagerForm_ServerLocation = new System.Windows.Forms.Label();
        this.label_YakSysServersDBManagerForm_PasswordForConnection = new System.Windows.Forms.Label();
        this.label_YakSysServersDBManagerForm_ServerPort = new System.Windows.Forms.Label();
        this.listView_ProxyServersList_ProxyServersList = new System.Windows.Forms.ListView();
        this.columnHeader_ProxyServersList_Title = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ProxyServersList_Host = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ProxyServersList_Port = new System.Windows.Forms.ColumnHeader();
        this.button_ProxyServersList_ViewRecord = new System.Windows.Forms.Button();
        this.button_ProxyServersList_AddRecord = new System.Windows.Forms.Button();
        this.checkBox_YakSysServersDBManagerForm_UseProxy = new System.Windows.Forms.CheckBox();
        this.button_ProxyServersList_EditRecord = new System.Windows.Forms.Button();
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList = new System.Windows.Forms.GroupBox();
        this.label_ProxyServersList_ProxyServersList = new System.Windows.Forms.Label();
        this.groupBox_YakSysServersDBManagerForm_GroupsList = new System.Windows.Forms.GroupBox();
        this.button_GroupsList_RenameGroup = new System.Windows.Forms.Button();
        this.label_GroupsList_GroupsList = new System.Windows.Forms.Label();
        this.button_GroupsList_RemoveGroup = new System.Windows.Forms.Button();
        this.listBox_GroupsList_GroupsList = new System.Windows.Forms.ListBox();
        this.button_GroupsList_AddNewGroup = new System.Windows.Forms.Button();
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.SuspendLayout();
        this.groupBox_YakSysServersDBManagerForm_GroupsList.SuspendLayout();
        this.SuspendLayout();
        // 
        // textBox_YakSysServersDBManagerForm_ServerHost
        // 
        this.textBox_YakSysServersDBManagerForm_ServerHost.Location = new System.Drawing.Point(16, 32);
        this.textBox_YakSysServersDBManagerForm_ServerHost.Name = "textBox_YakSysServersDBManagerForm_ServerHost";
        this.textBox_YakSysServersDBManagerForm_ServerHost.Size = new System.Drawing.Size(120, 20);
        this.textBox_YakSysServersDBManagerForm_ServerHost.TabIndex = 0;
        // 
        // textBox_YakSysServersDBManagerForm_ServerLocation
        // 
        this.textBox_YakSysServersDBManagerForm_ServerLocation.Location = new System.Drawing.Point(184, 128);
        this.textBox_YakSysServersDBManagerForm_ServerLocation.Name = "textBox_YakSysServersDBManagerForm_ServerLocation";
        this.textBox_YakSysServersDBManagerForm_ServerLocation.Size = new System.Drawing.Size(152, 20);
        this.textBox_YakSysServersDBManagerForm_ServerLocation.TabIndex = 6;
        // 
        // textBox_YakSysServersDBManagerForm_ServerName
        // 
        this.textBox_YakSysServersDBManagerForm_ServerName.Location = new System.Drawing.Point(16, 128);
        this.textBox_YakSysServersDBManagerForm_ServerName.Name = "textBox_YakSysServersDBManagerForm_ServerName";
        this.textBox_YakSysServersDBManagerForm_ServerName.Size = new System.Drawing.Size(152, 20);
        this.textBox_YakSysServersDBManagerForm_ServerName.TabIndex = 5;
        // 
        // textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup
        // 
        this.textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup.Location = new System.Drawing.Point(16, 176);
        this.textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup.Name = "textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup";
        this.textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup.Size = new System.Drawing.Size(152, 20);
        this.textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup.TabIndex = 7;
        // 
        // textBox_YakSysServersDBManagerForm_LoginForConnection
        // 
        this.textBox_YakSysServersDBManagerForm_LoginForConnection.Location = new System.Drawing.Point(16, 80);
        this.textBox_YakSysServersDBManagerForm_LoginForConnection.Name = "textBox_YakSysServersDBManagerForm_LoginForConnection";
        this.textBox_YakSysServersDBManagerForm_LoginForConnection.Size = new System.Drawing.Size(152, 20);
        this.textBox_YakSysServersDBManagerForm_LoginForConnection.TabIndex = 3;
        // 
        // textBox_YakSysServersDBManagerForm_PasswordForConnection
        // 
        this.textBox_YakSysServersDBManagerForm_PasswordForConnection.Location = new System.Drawing.Point(184, 80);
        this.textBox_YakSysServersDBManagerForm_PasswordForConnection.Name = "textBox_YakSysServersDBManagerForm_PasswordForConnection";
        this.textBox_YakSysServersDBManagerForm_PasswordForConnection.PasswordChar = '*';
        this.textBox_YakSysServersDBManagerForm_PasswordForConnection.Size = new System.Drawing.Size(152, 20);
        this.textBox_YakSysServersDBManagerForm_PasswordForConnection.TabIndex = 4;
        // 
        // textBox_YakSysServersDBManagerForm_ServerNetworkDomain
        // 
        this.textBox_YakSysServersDBManagerForm_ServerNetworkDomain.Location = new System.Drawing.Point(184, 176);
        this.textBox_YakSysServersDBManagerForm_ServerNetworkDomain.Name = "textBox_YakSysServersDBManagerForm_ServerNetworkDomain";
        this.textBox_YakSysServersDBManagerForm_ServerNetworkDomain.Size = new System.Drawing.Size(152, 20);
        this.textBox_YakSysServersDBManagerForm_ServerNetworkDomain.TabIndex = 8;
        // 
        // textBox_YakSysServersDBManagerForm_ServerPort
        // 
        this.textBox_YakSysServersDBManagerForm_ServerPort.Location = new System.Drawing.Point(152, 32);
        this.textBox_YakSysServersDBManagerForm_ServerPort.Name = "textBox_YakSysServersDBManagerForm_ServerPort";
        this.textBox_YakSysServersDBManagerForm_ServerPort.Size = new System.Drawing.Size(48, 20);
        this.textBox_YakSysServersDBManagerForm_ServerPort.TabIndex = 1;
        // 
        // textBox_YakSysServersDBManagerForm_ServerDescription
        // 
        this.textBox_YakSysServersDBManagerForm_ServerDescription.Location = new System.Drawing.Point(16, 224);
        this.textBox_YakSysServersDBManagerForm_ServerDescription.Multiline = true;
        this.textBox_YakSysServersDBManagerForm_ServerDescription.Name = "textBox_YakSysServersDBManagerForm_ServerDescription";
        this.textBox_YakSysServersDBManagerForm_ServerDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.textBox_YakSysServersDBManagerForm_ServerDescription.Size = new System.Drawing.Size(320, 256);
        this.textBox_YakSysServersDBManagerForm_ServerDescription.TabIndex = 9;
        // 
        // button_YakSysServersDBManagerForm_Apply
        // 
        this.button_YakSysServersDBManagerForm_Apply.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_YakSysServersDBManagerForm_Apply.Location = new System.Drawing.Point(456, 456);
        this.button_YakSysServersDBManagerForm_Apply.Name = "button_YakSysServersDBManagerForm_Apply";
        this.button_YakSysServersDBManagerForm_Apply.Size = new System.Drawing.Size(104, 23);
        this.button_YakSysServersDBManagerForm_Apply.TabIndex = 19;
        this.button_YakSysServersDBManagerForm_Apply.Text = "Apply";
        this.button_YakSysServersDBManagerForm_Apply.Click += new System.EventHandler(this.button_YakSysServersDBManagerForm_Apply_Click);
        // 
        // button_YakSysServersDBManagerForm_Cancel
        // 
        this.button_YakSysServersDBManagerForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_YakSysServersDBManagerForm_Cancel.Location = new System.Drawing.Point(568, 456);
        this.button_YakSysServersDBManagerForm_Cancel.Name = "button_YakSysServersDBManagerForm_Cancel";
        this.button_YakSysServersDBManagerForm_Cancel.Size = new System.Drawing.Size(96, 23);
        this.button_YakSysServersDBManagerForm_Cancel.TabIndex = 20;
        this.button_YakSysServersDBManagerForm_Cancel.Text = "Cancel";
        this.button_YakSysServersDBManagerForm_Cancel.Click += new System.EventHandler(this.button_YakSysServersDBManagerForm_Cancel_Click);
        // 
        // button_YakSysServersDBManagerForm_AddToDB
        // 
        this.button_YakSysServersDBManagerForm_AddToDB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_YakSysServersDBManagerForm_AddToDB.Location = new System.Drawing.Point(352, 456);
        this.button_YakSysServersDBManagerForm_AddToDB.Name = "button_YakSysServersDBManagerForm_AddToDB";
        this.button_YakSysServersDBManagerForm_AddToDB.Size = new System.Drawing.Size(96, 23);
        this.button_YakSysServersDBManagerForm_AddToDB.TabIndex = 18;
        this.button_YakSysServersDBManagerForm_AddToDB.Text = "Add";
        this.button_YakSysServersDBManagerForm_AddToDB.Click += new System.EventHandler(this.button_YakSysServersDBManagerForm_AddToDB_Click);
        // 
        // label_YakSysServersDBManagerForm_ServerHost
        // 
        this.label_YakSysServersDBManagerForm_ServerHost.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_YakSysServersDBManagerForm_ServerHost.Location = new System.Drawing.Point(16, 16);
        this.label_YakSysServersDBManagerForm_ServerHost.Name = "label_YakSysServersDBManagerForm_ServerHost";
        this.label_YakSysServersDBManagerForm_ServerHost.Size = new System.Drawing.Size(120, 16);
        this.label_YakSysServersDBManagerForm_ServerHost.TabIndex = 75;
        this.label_YakSysServersDBManagerForm_ServerHost.Text = "Host:";
        // 
        // label_YakSysServersDBManagerForm_LoginForConnection
        // 
        this.label_YakSysServersDBManagerForm_LoginForConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_YakSysServersDBManagerForm_LoginForConnection.Location = new System.Drawing.Point(16, 64);
        this.label_YakSysServersDBManagerForm_LoginForConnection.Name = "label_YakSysServersDBManagerForm_LoginForConnection";
        this.label_YakSysServersDBManagerForm_LoginForConnection.Size = new System.Drawing.Size(152, 16);
        this.label_YakSysServersDBManagerForm_LoginForConnection.TabIndex = 76;
        this.label_YakSysServersDBManagerForm_LoginForConnection.Text = "Login:";
        // 
        // label_YakSysServersDBManagerForm_ServerName
        // 
        this.label_YakSysServersDBManagerForm_ServerName.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_YakSysServersDBManagerForm_ServerName.Location = new System.Drawing.Point(16, 112);
        this.label_YakSysServersDBManagerForm_ServerName.Name = "label_YakSysServersDBManagerForm_ServerName";
        this.label_YakSysServersDBManagerForm_ServerName.Size = new System.Drawing.Size(152, 16);
        this.label_YakSysServersDBManagerForm_ServerName.TabIndex = 77;
        this.label_YakSysServersDBManagerForm_ServerName.Text = "Server name:";
        // 
        // label_YakSysServersDBManagerForm_ServerNetworkWorkgroup
        // 
        this.label_YakSysServersDBManagerForm_ServerNetworkWorkgroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_YakSysServersDBManagerForm_ServerNetworkWorkgroup.Location = new System.Drawing.Point(16, 160);
        this.label_YakSysServersDBManagerForm_ServerNetworkWorkgroup.Name = "label_YakSysServersDBManagerForm_ServerNetworkWorkgroup";
        this.label_YakSysServersDBManagerForm_ServerNetworkWorkgroup.Size = new System.Drawing.Size(152, 16);
        this.label_YakSysServersDBManagerForm_ServerNetworkWorkgroup.TabIndex = 78;
        this.label_YakSysServersDBManagerForm_ServerNetworkWorkgroup.Text = "Network workgroup:";
        // 
        // label_YakSysServersDBManagerForm_ServerDescription
        // 
        this.label_YakSysServersDBManagerForm_ServerDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_YakSysServersDBManagerForm_ServerDescription.Location = new System.Drawing.Point(16, 208);
        this.label_YakSysServersDBManagerForm_ServerDescription.Name = "label_YakSysServersDBManagerForm_ServerDescription";
        this.label_YakSysServersDBManagerForm_ServerDescription.Size = new System.Drawing.Size(152, 16);
        this.label_YakSysServersDBManagerForm_ServerDescription.TabIndex = 79;
        this.label_YakSysServersDBManagerForm_ServerDescription.Text = "Description:";
        // 
        // label_YakSysServersDBManagerForm_ServerNetworkDomain
        // 
        this.label_YakSysServersDBManagerForm_ServerNetworkDomain.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_YakSysServersDBManagerForm_ServerNetworkDomain.Location = new System.Drawing.Point(184, 160);
        this.label_YakSysServersDBManagerForm_ServerNetworkDomain.Name = "label_YakSysServersDBManagerForm_ServerNetworkDomain";
        this.label_YakSysServersDBManagerForm_ServerNetworkDomain.Size = new System.Drawing.Size(152, 16);
        this.label_YakSysServersDBManagerForm_ServerNetworkDomain.TabIndex = 80;
        this.label_YakSysServersDBManagerForm_ServerNetworkDomain.Text = "Network domain:";
        // 
        // label_YakSysServersDBManagerForm_ServerLocation
        // 
        this.label_YakSysServersDBManagerForm_ServerLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_YakSysServersDBManagerForm_ServerLocation.Location = new System.Drawing.Point(184, 112);
        this.label_YakSysServersDBManagerForm_ServerLocation.Name = "label_YakSysServersDBManagerForm_ServerLocation";
        this.label_YakSysServersDBManagerForm_ServerLocation.Size = new System.Drawing.Size(152, 16);
        this.label_YakSysServersDBManagerForm_ServerLocation.TabIndex = 81;
        this.label_YakSysServersDBManagerForm_ServerLocation.Text = "Server location:";
        // 
        // label_YakSysServersDBManagerForm_PasswordForConnection
        // 
        this.label_YakSysServersDBManagerForm_PasswordForConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_YakSysServersDBManagerForm_PasswordForConnection.Location = new System.Drawing.Point(184, 64);
        this.label_YakSysServersDBManagerForm_PasswordForConnection.Name = "label_YakSysServersDBManagerForm_PasswordForConnection";
        this.label_YakSysServersDBManagerForm_PasswordForConnection.Size = new System.Drawing.Size(152, 16);
        this.label_YakSysServersDBManagerForm_PasswordForConnection.TabIndex = 82;
        this.label_YakSysServersDBManagerForm_PasswordForConnection.Text = "Password:";
        // 
        // label_YakSysServersDBManagerForm_ServerPort
        // 
        this.label_YakSysServersDBManagerForm_ServerPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_YakSysServersDBManagerForm_ServerPort.Location = new System.Drawing.Point(152, 16);
        this.label_YakSysServersDBManagerForm_ServerPort.Name = "label_YakSysServersDBManagerForm_ServerPort";
        this.label_YakSysServersDBManagerForm_ServerPort.Size = new System.Drawing.Size(56, 16);
        this.label_YakSysServersDBManagerForm_ServerPort.TabIndex = 83;
        this.label_YakSysServersDBManagerForm_ServerPort.Text = "Port:";
        // 
        // listView_ProxyServersList_ProxyServersList
        // 
        this.listView_ProxyServersList_ProxyServersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ProxyServersList_Title,
            this.columnHeader_ProxyServersList_Host,
            this.columnHeader_ProxyServersList_Port});
        this.listView_ProxyServersList_ProxyServersList.FullRowSelect = true;
        this.listView_ProxyServersList_ProxyServersList.GridLines = true;
        this.listView_ProxyServersList_ProxyServersList.HideSelection = false;
        this.listView_ProxyServersList_ProxyServersList.HoverSelection = true;
        this.listView_ProxyServersList_ProxyServersList.Location = new System.Drawing.Point(16, 40);
        this.listView_ProxyServersList_ProxyServersList.MultiSelect = false;
        this.listView_ProxyServersList_ProxyServersList.Name = "listView_ProxyServersList_ProxyServersList";
        this.listView_ProxyServersList_ProxyServersList.Size = new System.Drawing.Size(280, 144);
        this.listView_ProxyServersList_ProxyServersList.TabIndex = 14;
        this.listView_ProxyServersList_ProxyServersList.UseCompatibleStateImageBehavior = false;
        this.listView_ProxyServersList_ProxyServersList.View = System.Windows.Forms.View.Details;
        this.listView_ProxyServersList_ProxyServersList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ProxyServersList_ProxyServersList_ColumnClick);
        // 
        // columnHeader_ProxyServersList_Title
        // 
        this.columnHeader_ProxyServersList_Title.Text = "Title";
        this.columnHeader_ProxyServersList_Title.Width = 114;
        // 
        // columnHeader_ProxyServersList_Host
        // 
        this.columnHeader_ProxyServersList_Host.Text = "Host";
        this.columnHeader_ProxyServersList_Host.Width = 97;
        // 
        // columnHeader_ProxyServersList_Port
        // 
        this.columnHeader_ProxyServersList_Port.Text = "Port";
        this.columnHeader_ProxyServersList_Port.Width = 45;
        // 
        // button_ProxyServersList_ViewRecord
        // 
        this.button_ProxyServersList_ViewRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ProxyServersList_ViewRecord.Location = new System.Drawing.Point(112, 192);
        this.button_ProxyServersList_ViewRecord.Name = "button_ProxyServersList_ViewRecord";
        this.button_ProxyServersList_ViewRecord.Size = new System.Drawing.Size(88, 24);
        this.button_ProxyServersList_ViewRecord.TabIndex = 16;
        this.button_ProxyServersList_ViewRecord.Text = "View";
        this.button_ProxyServersList_ViewRecord.Click += new System.EventHandler(this.button_ProxyServersList_ViewRecord_Click);
        // 
        // button_ProxyServersList_AddRecord
        // 
        this.button_ProxyServersList_AddRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ProxyServersList_AddRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.button_ProxyServersList_AddRecord.Location = new System.Drawing.Point(16, 192);
        this.button_ProxyServersList_AddRecord.Name = "button_ProxyServersList_AddRecord";
        this.button_ProxyServersList_AddRecord.Size = new System.Drawing.Size(88, 24);
        this.button_ProxyServersList_AddRecord.TabIndex = 15;
        this.button_ProxyServersList_AddRecord.Text = "Add";
        this.button_ProxyServersList_AddRecord.Click += new System.EventHandler(this.button_ProxyServersList_AddRecord_Click);
        // 
        // checkBox_YakSysServersDBManagerForm_UseProxy
        // 
        this.checkBox_YakSysServersDBManagerForm_UseProxy.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_YakSysServersDBManagerForm_UseProxy.Location = new System.Drawing.Point(216, 36);
        this.checkBox_YakSysServersDBManagerForm_UseProxy.Name = "checkBox_YakSysServersDBManagerForm_UseProxy";
        this.checkBox_YakSysServersDBManagerForm_UseProxy.Size = new System.Drawing.Size(136, 16);
        this.checkBox_YakSysServersDBManagerForm_UseProxy.TabIndex = 2;
        this.checkBox_YakSysServersDBManagerForm_UseProxy.Text = "Use Proxy";
        // 
        // button_ProxyServersList_EditRecord
        // 
        this.button_ProxyServersList_EditRecord.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ProxyServersList_EditRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.button_ProxyServersList_EditRecord.Location = new System.Drawing.Point(208, 192);
        this.button_ProxyServersList_EditRecord.Name = "button_ProxyServersList_EditRecord";
        this.button_ProxyServersList_EditRecord.Size = new System.Drawing.Size(88, 23);
        this.button_ProxyServersList_EditRecord.TabIndex = 17;
        this.button_ProxyServersList_EditRecord.Text = "Edit";
        this.button_ProxyServersList_EditRecord.Click += new System.EventHandler(this.button_ProxyServersList_EditRecord_Click);
        // 
        // groupBox_YakSysServersDBManagerForm_ProxyServersList
        // 
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.Controls.Add(this.label_ProxyServersList_ProxyServersList);
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.Controls.Add(this.button_ProxyServersList_ViewRecord);
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.Controls.Add(this.listView_ProxyServersList_ProxyServersList);
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.Controls.Add(this.button_ProxyServersList_AddRecord);
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.Controls.Add(this.button_ProxyServersList_EditRecord);
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.Location = new System.Drawing.Point(352, 216);
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.Name = "groupBox_YakSysServersDBManagerForm_ProxyServersList";
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.Size = new System.Drawing.Size(312, 224);
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.TabIndex = 89;
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.TabStop = false;
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.Text = "Used Proxy Server";
        // 
        // label_ProxyServersList_ProxyServersList
        // 
        this.label_ProxyServersList_ProxyServersList.Location = new System.Drawing.Point(16, 24);
        this.label_ProxyServersList_ProxyServersList.Name = "label_ProxyServersList_ProxyServersList";
        this.label_ProxyServersList_ProxyServersList.Size = new System.Drawing.Size(280, 16);
        this.label_ProxyServersList_ProxyServersList.TabIndex = 92;
        this.label_ProxyServersList_ProxyServersList.Text = "Available Proxy\\Firewalls Servers (select one):";
        // 
        // groupBox_YakSysServersDBManagerForm_GroupsList
        // 
        this.groupBox_YakSysServersDBManagerForm_GroupsList.Controls.Add(this.button_GroupsList_RenameGroup);
        this.groupBox_YakSysServersDBManagerForm_GroupsList.Controls.Add(this.label_GroupsList_GroupsList);
        this.groupBox_YakSysServersDBManagerForm_GroupsList.Controls.Add(this.button_GroupsList_RemoveGroup);
        this.groupBox_YakSysServersDBManagerForm_GroupsList.Controls.Add(this.listBox_GroupsList_GroupsList);
        this.groupBox_YakSysServersDBManagerForm_GroupsList.Controls.Add(this.button_GroupsList_AddNewGroup);
        this.groupBox_YakSysServersDBManagerForm_GroupsList.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_YakSysServersDBManagerForm_GroupsList.Location = new System.Drawing.Point(352, 24);
        this.groupBox_YakSysServersDBManagerForm_GroupsList.Name = "groupBox_YakSysServersDBManagerForm_GroupsList";
        this.groupBox_YakSysServersDBManagerForm_GroupsList.Size = new System.Drawing.Size(312, 176);
        this.groupBox_YakSysServersDBManagerForm_GroupsList.TabIndex = 90;
        this.groupBox_YakSysServersDBManagerForm_GroupsList.TabStop = false;
        this.groupBox_YakSysServersDBManagerForm_GroupsList.Text = "Group Member";
        // 
        // button_GroupsList_RenameGroup
        // 
        this.button_GroupsList_RenameGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_GroupsList_RenameGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.button_GroupsList_RenameGroup.Location = new System.Drawing.Point(104, 144);
        this.button_GroupsList_RenameGroup.Name = "button_GroupsList_RenameGroup";
        this.button_GroupsList_RenameGroup.Size = new System.Drawing.Size(104, 23);
        this.button_GroupsList_RenameGroup.TabIndex = 12;
        this.button_GroupsList_RenameGroup.Text = "Rename";
        this.button_GroupsList_RenameGroup.Click += new System.EventHandler(this.button_GroupsList_RenameGroup_Click);
        // 
        // label_GroupsList_GroupsList
        // 
        this.label_GroupsList_GroupsList.Location = new System.Drawing.Point(16, 24);
        this.label_GroupsList_GroupsList.Name = "label_GroupsList_GroupsList";
        this.label_GroupsList_GroupsList.Size = new System.Drawing.Size(280, 16);
        this.label_GroupsList_GroupsList.TabIndex = 91;
        this.label_GroupsList_GroupsList.Text = "Available Groups (select one):";
        // 
        // button_GroupsList_RemoveGroup
        // 
        this.button_GroupsList_RemoveGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_GroupsList_RemoveGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.button_GroupsList_RemoveGroup.Location = new System.Drawing.Point(216, 144);
        this.button_GroupsList_RemoveGroup.Name = "button_GroupsList_RemoveGroup";
        this.button_GroupsList_RemoveGroup.Size = new System.Drawing.Size(80, 23);
        this.button_GroupsList_RemoveGroup.TabIndex = 13;
        this.button_GroupsList_RemoveGroup.Text = "Remove";
        this.button_GroupsList_RemoveGroup.Click += new System.EventHandler(this.button_YakSysServersDBManagerForm_RemoveGroupRecord_Click);
        // 
        // listBox_GroupsList_GroupsList
        // 
        this.listBox_GroupsList_GroupsList.Items.AddRange(new object[] {
            ""});
        this.listBox_GroupsList_GroupsList.Location = new System.Drawing.Point(16, 40);
        this.listBox_GroupsList_GroupsList.Name = "listBox_GroupsList_GroupsList";
        this.listBox_GroupsList_GroupsList.Size = new System.Drawing.Size(280, 95);
        this.listBox_GroupsList_GroupsList.TabIndex = 10;
        // 
        // button_GroupsList_AddNewGroup
        // 
        this.button_GroupsList_AddNewGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_GroupsList_AddNewGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.button_GroupsList_AddNewGroup.Location = new System.Drawing.Point(16, 144);
        this.button_GroupsList_AddNewGroup.Name = "button_GroupsList_AddNewGroup";
        this.button_GroupsList_AddNewGroup.Size = new System.Drawing.Size(80, 24);
        this.button_GroupsList_AddNewGroup.TabIndex = 11;
        this.button_GroupsList_AddNewGroup.Text = "Add";
        this.button_GroupsList_AddNewGroup.Click += new System.EventHandler(this.button_GroupsList_AddNewGroup_Click);
        // 
        // YakSysServersDBManagerForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(682, 496);
        this.Controls.Add(this.groupBox_YakSysServersDBManagerForm_GroupsList);
        this.Controls.Add(this.groupBox_YakSysServersDBManagerForm_ProxyServersList);
        this.Controls.Add(this.label_YakSysServersDBManagerForm_ServerPort);
        this.Controls.Add(this.label_YakSysServersDBManagerForm_PasswordForConnection);
        this.Controls.Add(this.label_YakSysServersDBManagerForm_ServerLocation);
        this.Controls.Add(this.label_YakSysServersDBManagerForm_ServerNetworkDomain);
        this.Controls.Add(this.label_YakSysServersDBManagerForm_ServerDescription);
        this.Controls.Add(this.label_YakSysServersDBManagerForm_ServerNetworkWorkgroup);
        this.Controls.Add(this.label_YakSysServersDBManagerForm_ServerName);
        this.Controls.Add(this.label_YakSysServersDBManagerForm_LoginForConnection);
        this.Controls.Add(this.label_YakSysServersDBManagerForm_ServerHost);
        this.Controls.Add(this.button_YakSysServersDBManagerForm_Apply);
        this.Controls.Add(this.button_YakSysServersDBManagerForm_Cancel);
        this.Controls.Add(this.button_YakSysServersDBManagerForm_AddToDB);
        this.Controls.Add(this.textBox_YakSysServersDBManagerForm_ServerDescription);
        this.Controls.Add(this.textBox_YakSysServersDBManagerForm_ServerPort);
        this.Controls.Add(this.textBox_YakSysServersDBManagerForm_ServerNetworkDomain);
        this.Controls.Add(this.textBox_YakSysServersDBManagerForm_PasswordForConnection);
        this.Controls.Add(this.textBox_YakSysServersDBManagerForm_LoginForConnection);
        this.Controls.Add(this.textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup);
        this.Controls.Add(this.textBox_YakSysServersDBManagerForm_ServerName);
        this.Controls.Add(this.textBox_YakSysServersDBManagerForm_ServerLocation);
        this.Controls.Add(this.textBox_YakSysServersDBManagerForm_ServerHost);
        this.Controls.Add(this.checkBox_YakSysServersDBManagerForm_UseProxy);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(688, 528);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(688, 528);
        this.Name = "YakSysServersDBManagerForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "YakSysServersDBManagerForm";
        this.Shown += new System.EventHandler(this.YakSysServersDBManagerForm_Shown);
        this.groupBox_YakSysServersDBManagerForm_ProxyServersList.ResumeLayout(false);
        this.groupBox_YakSysServersDBManagerForm_GroupsList.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    #endregion

    private void button_YakSysServersDBManagerForm_AddToDB_Click(object sender, System.EventArgs e)
    {
        if (this.listBox_GroupsList_GroupsList.Items.Count == 0)
        {
            MessageBox.Show(ClientStringFactory.GetString(508, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

            return;
        }

        int int_SelectedProxyIndex = 0;

        if (this.listView_ProxyServersList_ProxyServersList.Items.Count == 0
        || this.listView_ProxyServersList_ProxyServersList.SelectedItems.Count == 0)
        {
            this.checkBox_YakSysServersDBManagerForm_UseProxy.Checked = false;
        }
        else
        {
            int_SelectedProxyIndex = this.listView_ProxyServersList_ProxyServersList.SelectedItems[0].Index;
        }


        if (ServerPort == -1) return;

        DataRow dataRow_NewRecord = null;

        YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersDataTable YakSysServersDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers;

        ////////////////////////////////////////////////////////////////////////////////


        dataRow_NewRecord = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers.NewRow();

        int int_YakSysServerID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (YakSysServersDataTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= YakSysServersDataTable_obj.Rows.Count
            || (int)YakSysServersDataTable_obj.Rows[int_CycleCount][YakSysServersDataTable_obj.IDColumn] == int_YakSysServerID)
            {
                int_YakSysServerID++;
                int_CycleCount = -1;
            }

            else if (int_CycleCount + 1 == YakSysServersDataTable_obj.Rows.Count) break;
        }


        dataRow_NewRecord[YakSysServersDataTable_obj.IDColumn] = int_YakSysServerID;

        dataRow_NewRecord[YakSysServersDataTable_obj.ServerHostColumn] = this.textBox_YakSysServersDBManagerForm_ServerHost.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.ServerPortColumn] = ServerPort;
        dataRow_NewRecord[YakSysServersDataTable_obj.LoginColumn] = this.textBox_YakSysServersDBManagerForm_LoginForConnection.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.PasswordColumn] = this.textBox_YakSysServersDBManagerForm_PasswordForConnection.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.ServerLocationColumn] = this.textBox_YakSysServersDBManagerForm_ServerLocation.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.ServerNameColumn] = this.textBox_YakSysServersDBManagerForm_ServerName.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.ServerDescriptionColumn] = this.textBox_YakSysServersDBManagerForm_ServerDescription.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.DomainColumn] = this.textBox_YakSysServersDBManagerForm_ServerNetworkDomain.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.WorkGroupColumn] = this.textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.UseProxyServerColumn] = this.checkBox_YakSysServersDBManagerForm_UseProxy.Checked;

        dataRow_NewRecord[YakSysServersDataTable_obj.ServerGroupTypeIDColumn] = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes[this.listBox_GroupsList_GroupsList.SelectedIndex].ID;

        if (this.listView_ProxyServersList_ProxyServersList.Items.Count > 0)
            dataRow_NewRecord[YakSysServersDataTable_obj.ProxyServerIDColumn] = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings[int_SelectedProxyIndex + 1].ID;

        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers.Rows.Add(dataRow_NewRecord);

        ObjCopy.obj_MainClientForm.AddNewYakSysServersListItem(this.textBox_YakSysServersDBManagerForm_ServerName.Text,

        this.textBox_YakSysServersDBManagerForm_ServerHost.Text, this.textBox_YakSysServersDBManagerForm_ServerPort.Text,
        this.textBox_YakSysServersDBManagerForm_ServerLocation.Text, this.listBox_GroupsList_GroupsList.Text);

        ObjCopy.obj_MainClientForm.RefreshYakSysServersGroups();

        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers.AcceptChanges();

        this.Close();
    }

    private void button_YakSysServersDBManagerForm_Apply_Click(object sender, System.EventArgs e)
    {
        if (this.listBox_GroupsList_GroupsList.Items.Count == 0)
        {
            MessageBox.Show(ClientStringFactory.GetString(508, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

            return;
        }

        int int_SelectedProxyIndex = 0;

        if (this.listView_ProxyServersList_ProxyServersList.Items.Count == 0
            || this.listView_ProxyServersList_ProxyServersList.SelectedItems.Count == 0)
        {
            this.checkBox_YakSysServersDBManagerForm_UseProxy.Checked = false;
        }
        else
        {
            int_SelectedProxyIndex = this.listView_ProxyServersList_ProxyServersList.SelectedItems[0].Index;
        }


        if (ServerPort == -1) return;

        DataRow dataRow_NewRecord = null;

        YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersDataTable YakSysServersDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers;

        ////////////////////////////////////////////////////////////////////////////////


        dataRow_NewRecord = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers.Rows[EditedRecordIndex];


        dataRow_NewRecord[YakSysServersDataTable_obj.ServerHostColumn] = this.textBox_YakSysServersDBManagerForm_ServerHost.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.ServerPortColumn] = ServerPort;
        dataRow_NewRecord[YakSysServersDataTable_obj.LoginColumn] = this.textBox_YakSysServersDBManagerForm_LoginForConnection.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.PasswordColumn] = this.textBox_YakSysServersDBManagerForm_PasswordForConnection.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.ServerLocationColumn] = this.textBox_YakSysServersDBManagerForm_ServerLocation.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.ServerNameColumn] = this.textBox_YakSysServersDBManagerForm_ServerName.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.ServerDescriptionColumn] = this.textBox_YakSysServersDBManagerForm_ServerDescription.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.DomainColumn] = this.textBox_YakSysServersDBManagerForm_ServerNetworkDomain.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.WorkGroupColumn] = this.textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup.Text;
        dataRow_NewRecord[YakSysServersDataTable_obj.UseProxyServerColumn] = this.checkBox_YakSysServersDBManagerForm_UseProxy.Checked;

        dataRow_NewRecord[YakSysServersDataTable_obj.ServerGroupTypeIDColumn] = this.listBox_GroupsList_GroupsList.SelectedIndex;

        if (this.listView_ProxyServersList_ProxyServersList.Items.Count > 0)
            dataRow_NewRecord[YakSysServersDataTable_obj.ProxyServerIDColumn] = int_SelectedProxyIndex + 1;

        ObjCopy.obj_MainClientForm.EditSelectedYakSysServersListItem(this.textBox_YakSysServersDBManagerForm_ServerName.Text,
                                                                        this.textBox_YakSysServersDBManagerForm_ServerHost.Text,
                                                                        this.textBox_YakSysServersDBManagerForm_ServerPort.Text,
                                                                        this.textBox_YakSysServersDBManagerForm_ServerLocation.Text,
                                                                        this.listBox_GroupsList_GroupsList.Text);

        ObjCopy.obj_MainClientForm.RefreshYakSysServersGroups();

        this.Close();
    }

    private void button_YakSysServersDBManagerForm_Cancel_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void button_ProxyServersList_AddRecord_Click(object sender, System.EventArgs e)
    {
        ProxyDBManagerForm proxyDBManagerForm_obj = new ProxyDBManagerForm();

        proxyDBManagerForm_obj.ApplyButton.Visible = false;

        proxyDBManagerForm_obj.ShowDialog();

        UpdateProxyServersList();
    }

    private void button_ProxyServersList_ViewRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ProxyServersList_ProxyServersList.SelectedItems.Count == 0) return;

        int int_SelectedProxyServerRowIndex = (int)this.listView_ProxyServersList_ProxyServersList.SelectedItems[0].Tag;

        UserAccountsAndAccessRestrictionRulesEnvironment.ViewSelectedProxyServerInfo(int_SelectedProxyServerRowIndex);

        UpdateProxyServersList();
    }

    private void button_ProxyServersList_EditRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listView_ProxyServersList_ProxyServersList.SelectedItems.Count == 0) return;

        int int_SelectedProxyServerRowIndex = (int)this.listView_ProxyServersList_ProxyServersList.SelectedItems[0].Tag;

        UserAccountsAndAccessRestrictionRulesEnvironment.EditSelectedProxyServerInfo(int_SelectedProxyServerRowIndex);

        UpdateProxyServersList();
    }
    
    private void button_GroupsList_AddNewGroup_Click(object sender, System.EventArgs e)
    {
        AddNewItemForm addNewItemForm_obj = new AddNewItemForm();

        addNewItemForm_obj.ShowDialog();

        if (addNewItemForm_obj.NewItemName.Length == 0) return;


        foreach (string string_CurrentItemName in listBox_GroupsList_GroupsList.Items)
        {
            if (string_CurrentItemName == addNewItemForm_obj.NewItemName)
            {
                MessageBox.Show(ClientStringFactory.GetString(506, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

                return;
            }
        }

        this.listBox_GroupsList_GroupsList.Items.Add(addNewItemForm_obj.NewItemName);


        DataRow dataRow_NewRecord = null;

        YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ServerGroupTypesDataTable serverGroupTypesTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes;

        ////////////////////////////////////////////////////////////////////////////////


        dataRow_NewRecord = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes.NewRow();


        int int_ServerGroupTypesID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (serverGroupTypesTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= serverGroupTypesTable_obj.Rows.Count
            || (int)serverGroupTypesTable_obj.Rows[int_CycleCount][serverGroupTypesTable_obj.IDColumn] == int_ServerGroupTypesID)
            {
                int_ServerGroupTypesID++;
                int_CycleCount = -1;
            }

            else if (int_CycleCount + 1 == serverGroupTypesTable_obj.Rows.Count) break;
        }


        dataRow_NewRecord[serverGroupTypesTable_obj.IDColumn] = int_ServerGroupTypesID;
        dataRow_NewRecord[serverGroupTypesTable_obj.GroupNameColumn] = addNewItemForm_obj.NewItemName;


        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes.Rows.Add(dataRow_NewRecord);

        ObjCopy.obj_MainClientForm.RefreshYakSysServersGroups();

        this.listBox_GroupsList_GroupsList.SelectedIndex = this.listBox_GroupsList_GroupsList.Items.Count - 1;

    }

    private void button_GroupsList_RenameGroup_Click(object sender, System.EventArgs e)
    {
        if (this.listBox_GroupsList_GroupsList.SelectedIndex < 0) return;

        RenameItemForm renameItemForm_obj = new RenameItemForm();

        renameItemForm_obj.OldItemName = (string)this.listBox_GroupsList_GroupsList.SelectedItem.ToString();

        renameItemForm_obj.ShowDialog();

        int int_SelectedItemIndex = this.listBox_GroupsList_GroupsList.SelectedIndex;

        YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ServerGroupTypesDataTable serverGroupTypesTableDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes;

        serverGroupTypesTableDataTable_obj.Rows[int_SelectedItemIndex][serverGroupTypesTableDataTable_obj.GroupNameColumn] = renameItemForm_obj.NewItemName;



        this.listBox_GroupsList_GroupsList.Items.RemoveAt(int_SelectedItemIndex);

        this.listBox_GroupsList_GroupsList.Items.Insert(int_SelectedItemIndex, renameItemForm_obj.NewItemName);

        this.listBox_GroupsList_GroupsList.SelectedIndex = int_SelectedItemIndex;

    }

    private void button_YakSysServersDBManagerForm_RemoveGroupRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listBox_GroupsList_GroupsList.Items.Count == 0) return;

        YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ServerGroupTypesDataTable serverGroupTypesTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ServerGroupTypes;

        DataRow[] dataRowArray_RowsToDelete = serverGroupTypesTable_obj.Rows[this.listBox_GroupsList_GroupsList.SelectedIndex].GetChildRows("ServerGroupTypes_YakSysServerInfo");

        if (dataRowArray_RowsToDelete.Length == 0)
        {
            serverGroupTypesTable_obj.RemoveServerGroupTypesRow((YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ServerGroupTypesRow)serverGroupTypesTable_obj.Rows[this.listBox_GroupsList_GroupsList.SelectedIndex]);

            this.listBox_GroupsList_GroupsList.Items.RemoveAt(this.listBox_GroupsList_GroupsList.SelectedIndex);

            if (this.listBox_GroupsList_GroupsList.Items.Count > 0)
            {
                this.listBox_GroupsList_GroupsList.SelectedIndex = 0;
            }

            return;
        }

        if (DialogResult.Yes == MessageBox.Show(ClientStringFactory.GetString(507, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            foreach (YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.YakSysServersRow row_Current in dataRowArray_RowsToDelete)
            {
                YakSysRctClientV110XMLConfigImporter.YakSysClientDB.YakSysServers.RemoveYakSysServersRow(row_Current);
            }

            serverGroupTypesTable_obj.RemoveServerGroupTypesRow((YakSysRct_Xml_Config_Importer.Client_DataSet_ver_110.DataSet_YakSysClientDB.ServerGroupTypesRow)serverGroupTypesTable_obj.Rows[this.listBox_GroupsList_GroupsList.SelectedIndex]);

            this.listBox_GroupsList_GroupsList.Items.RemoveAt(this.listBox_GroupsList_GroupsList.SelectedIndex);

            if (this.listBox_GroupsList_GroupsList.Items.Count > 0)
            {
                this.listBox_GroupsList_GroupsList.SelectedIndex = 0;
            }
                      
            ObjCopy.obj_MainClientForm.FillYakSysServersList();

            return;
        }
    }



    public int ServerPort
    {
        get
        {
            try
            {
                if (Convert.ToInt32(this.textBox_YakSysServersDBManagerForm_ServerPort.Text) > 65535 || Convert.ToInt32(this.textBox_YakSysServersDBManagerForm_ServerPort.Text) < 1)
                {
                    MessageBox.Show(ClientStringFactory.GetString(444, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);
                    return -1;
                }

                return int.Parse(this.textBox_YakSysServersDBManagerForm_ServerPort.Text);
            }

            catch (FormatException)
            {
                MessageBox.Show(ClientStringFactory.GetString(444, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);
                return -1;
            }
        }

        set
        {
            this.textBox_YakSysServersDBManagerForm_ServerPort.Text = value.ToString();
        }
    }


    public void UpdateProxyServersList()
    {
        this.listView_ProxyServersList_ProxyServersList.Items.Clear();

        foreach (ListViewItem listViewItem_Current in ObjCopy.obj_MainClientForm.ProxyServersListItems)
        {
            this.listView_ProxyServersList_ProxyServersList.Items.Add((ListViewItem)listViewItem_Current.Clone());
        }

        if (this.listView_ProxyServersList_ProxyServersList.Items.Count > 0)
            this.listView_ProxyServersList_ProxyServersList.Items[this.listView_ProxyServersList_ProxyServersList.Items.Count - 1].Selected = true;

    }

    ListViewColumnSorter listViewColumnSorter_ProxyServersList = new ListViewColumnSorter();

    private void listView_ProxyServersList_ProxyServersList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
    {
        this.listView_ProxyServersList_ProxyServersList.ListViewItemSorter = listViewColumnSorter_ProxyServersList;

        // Determine if clicked column is already the column that is being sorted.
        if (e.Column == listViewColumnSorter_ProxyServersList.SortColumn)
        {
            if (listViewColumnSorter_ProxyServersList.Order == SortOrder.Ascending)
                listViewColumnSorter_ProxyServersList.Order = SortOrder.Descending;

            else listViewColumnSorter_ProxyServersList.Order = SortOrder.Ascending;
        }
        else
        {
            listViewColumnSorter_ProxyServersList.SortColumn = e.Column;
            listViewColumnSorter_ProxyServersList.Order = SortOrder.Ascending;
        }

        this.listView_ProxyServersList_ProxyServersList.Sort();
    }

    int int_EditedRecordIndex = 0;

    public int EditedRecordIndex
    {
        get
        {
            return int_EditedRecordIndex;
        }

        set
        {
            int_EditedRecordIndex = value;
        }
    }


    public Button ViewProxyRecordButton
    {
        get
        {
            return this.button_ProxyServersList_ViewRecord;
        }
    }

    public Button AddProxyRecordButton
    {
        get
        {
            return this.button_ProxyServersList_AddRecord;
        }
    }

    public Button EditProxyRecordButton
    {
        get
        {
            return this.button_ProxyServersList_EditRecord;
        }
    }

    public Button ApplyButton
    {
        get
        {
            return this.button_YakSysServersDBManagerForm_Apply;
        }
    }


    public Button CancelButton
    {
        get
        {
            return this.button_YakSysServersDBManagerForm_Cancel;
        }
    }

    public Button AddButton
    {
        get
        {
            return this.button_YakSysServersDBManagerForm_AddToDB;
        }
    }


    public Button RenameGroupButton
    {
        get
        {
            return this.button_GroupsList_RenameGroup;
        }
    }

    public Button RemoveGroupButton
    {
        get
        {
            return this.button_GroupsList_RemoveGroup;
        }
    }

    public Button AddNewGroupButton
    {
        get
        {
            return this.button_GroupsList_AddNewGroup;
        }
    }


    public CheckBox UseProxyCheckBox
    {
        get
        {
            return this.checkBox_YakSysServersDBManagerForm_UseProxy;
        }
    }


    public TextBox ServerDescriptionTextBox
    {
        get
        {
            return this.textBox_YakSysServersDBManagerForm_ServerDescription;
        }
    }

    public TextBox ServerHostTextBox
    {
        get
        {
            return this.textBox_YakSysServersDBManagerForm_ServerHost;
        }
    }

    public TextBox ServerLocationTextBox
    {
        get
        {
            return this.textBox_YakSysServersDBManagerForm_ServerLocation;
        }
    }

    public TextBox ServerNameTextBox
    {
        get
        {
            return this.textBox_YakSysServersDBManagerForm_ServerName;
        }
    }

    public TextBox ServerPortTextBox
    {
        get
        {
            return this.textBox_YakSysServersDBManagerForm_ServerPort;
        }
    }

    public TextBox ServerNetworkWorkgroupTextBox
    {
        get
        {
            return this.textBox_YakSysServersDBManagerForm_ServerNetworkWorkgroup;
        }
    }

    public TextBox ServerNetworkDomainTextBox
    {
        get
        {
            return this.textBox_YakSysServersDBManagerForm_ServerNetworkDomain;
        }
    }

    public TextBox LoginForConnectionTextBox
    {
        get
        {
            return this.textBox_YakSysServersDBManagerForm_LoginForConnection;
        }
    }

    public TextBox PasswordForConnectionTextBox
    {
        get
        {
            return this.textBox_YakSysServersDBManagerForm_PasswordForConnection;
        }
    }


    public ListBox ServerGroupsListBox
    {
        get
        {
            return this.listBox_GroupsList_GroupsList;
        }
    }

    public ListView ProxyServersListView
    {
        get
        {
            return this.listView_ProxyServersList_ProxyServersList;
        }
    }


    public Label GroupMember
    {
        get
        {
            return this.label_GroupsList_GroupsList;
        }

        set
        {
            this.label_GroupsList_GroupsList = value;
        }
    }

    public Label UsedsProxy
    {
        get
        {
            return this.label_ProxyServersList_ProxyServersList;
        }

        set
        {
            this.label_ProxyServersList_ProxyServersList = value;
        }
    }

    private void YakSysServersDBManagerForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }
}

