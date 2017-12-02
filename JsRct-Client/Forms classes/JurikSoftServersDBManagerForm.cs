using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

public class JurikSoftServersDBManagerForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.TextBox textBox_JurikSoftServersDBManagerForm_ServerDescription;
    private System.Windows.Forms.Button button_JurikSoftServersDBManagerForm_Apply;
    private System.Windows.Forms.Button button_JurikSoftServersDBManagerForm_Cancel;
    private System.Windows.Forms.Button button_JurikSoftServersDBManagerForm_AddToDB;
    private System.Windows.Forms.TextBox textBox_JurikSoftServersDBManagerForm_ServerHost;
    private System.Windows.Forms.TextBox textBox_JurikSoftServersDBManagerForm_ServerLocation;
    private System.Windows.Forms.TextBox textBox_JurikSoftServersDBManagerForm_ServerName;
    private System.Windows.Forms.TextBox textBox_JurikSoftServersDBManagerForm_ServerPort;
    private System.Windows.Forms.TextBox textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup;
    private System.Windows.Forms.TextBox textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain;
    private System.Windows.Forms.TextBox textBox_JurikSoftServersDBManagerForm_LoginForConnection;
    private System.Windows.Forms.TextBox textBox_JurikSoftServersDBManagerForm_PasswordForConnection;
    private System.Windows.Forms.Label label_JurikSoftServersDBManagerForm_ServerHost;
    private System.Windows.Forms.Label label_JurikSoftServersDBManagerForm_LoginForConnection;
    private System.Windows.Forms.Label label_JurikSoftServersDBManagerForm_ServerName;
    private System.Windows.Forms.Label label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup;
    private System.Windows.Forms.Label label_JurikSoftServersDBManagerForm_ServerDescription;
    private System.Windows.Forms.Label label_JurikSoftServersDBManagerForm_ServerNetworkDomain;
    private System.Windows.Forms.Label label_JurikSoftServersDBManagerForm_ServerLocation;
    private System.Windows.Forms.Label label_JurikSoftServersDBManagerForm_PasswordForConnection;
    private System.Windows.Forms.Label label_JurikSoftServersDBManagerForm_ServerPort;
    private System.Windows.Forms.ListView listView_ProxyServersList_ProxyServersList;
    private System.Windows.Forms.ColumnHeader columnHeader_ProxyServersList_Title;
    private System.Windows.Forms.ColumnHeader columnHeader_ProxyServersList_Host;
    private System.Windows.Forms.ColumnHeader columnHeader_ProxyServersList_Port;
    private System.Windows.Forms.Button button_ProxyServersList_ViewRecord;
    private System.Windows.Forms.Button button_ProxyServersList_AddRecord;
    private System.Windows.Forms.Button button_ProxyServersList_EditRecord;
    private System.Windows.Forms.GroupBox groupBox_JurikSoftServersDBManagerForm_ProxyServersList;
    private System.Windows.Forms.CheckBox checkBox_JurikSoftServersDBManagerForm_UseProxy;
    private System.Windows.Forms.GroupBox groupBox_JurikSoftServersDBManagerForm_GroupsList;
    private System.Windows.Forms.Button button_GroupsList_RenameGroup;
    private System.Windows.Forms.Label label_GroupsList_GroupsList;
    private System.Windows.Forms.Button button_GroupsList_RemoveGroup;
    private System.Windows.Forms.ListBox listBox_GroupsList_GroupsList;
    private System.Windows.Forms.Button button_GroupsList_AddNewGroup;
    private System.Windows.Forms.Label label_ProxyServersList_ProxyServersList;

    private System.ComponentModel.Container components = null;

    public JurikSoftServersDBManagerForm()
    {
        InitializeComponent();

        ChangeControlsLanguage();

        this.checkBox_JurikSoftServersDBManagerForm_UseProxy.Checked = false;

        UpdateProxyServersList();

        this.listBox_GroupsList_GroupsList.Items.Clear();

        string[] stringArray_ServersGroupsItems = new JurikSoft.XMLConfigImporer.JSClientDBEnvironment().GetServersGroupsItems();

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

        this.button_JurikSoftServersDBManagerForm_Apply.Text = ClientStringFactory.GetString(307, ClientSettingsEnvironment.CurrentLanguage);
        this.button_JurikSoftServersDBManagerForm_Cancel.Text = ClientStringFactory.GetString(265, ClientSettingsEnvironment.CurrentLanguage);
        this.button_JurikSoftServersDBManagerForm_AddToDB.Text = ClientStringFactory.GetString(311, ClientSettingsEnvironment.CurrentLanguage);

        this.label_JurikSoftServersDBManagerForm_ServerHost.Text = ClientStringFactory.GetString(77, ClientSettingsEnvironment.CurrentLanguage);
        this.label_JurikSoftServersDBManagerForm_LoginForConnection.Text = ClientStringFactory.GetString(74, ClientSettingsEnvironment.CurrentLanguage);
        this.label_JurikSoftServersDBManagerForm_ServerName.Text = ClientStringFactory.GetString(493, ClientSettingsEnvironment.CurrentLanguage);
        this.label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.Text = ClientStringFactory.GetString(494, ClientSettingsEnvironment.CurrentLanguage);
        this.label_JurikSoftServersDBManagerForm_ServerNetworkDomain.Text = ClientStringFactory.GetString(495, ClientSettingsEnvironment.CurrentLanguage);
        this.label_JurikSoftServersDBManagerForm_ServerDescription.Text = ClientStringFactory.GetString(314, ClientSettingsEnvironment.CurrentLanguage);
        this.label_JurikSoftServersDBManagerForm_ServerLocation.Text = ClientStringFactory.GetString(487, ClientSettingsEnvironment.CurrentLanguage);
        this.label_JurikSoftServersDBManagerForm_PasswordForConnection.Text = ClientStringFactory.GetString(73, ClientSettingsEnvironment.CurrentLanguage);
        this.label_JurikSoftServersDBManagerForm_ServerPort.Text = ClientStringFactory.GetString(72, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.Text = ClientStringFactory.GetString(502, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Title.Text = ClientStringFactory.GetString(485, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Host.Text = ClientStringFactory.GetString(317, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ProxyServersList_Port.Text = ClientStringFactory.GetString(316, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_ViewRecord.Text = ClientStringFactory.GetString(306, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_AddRecord.Text = ClientStringFactory.GetString(311, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyServersList_EditRecord.Text = ClientStringFactory.GetString(483, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_JurikSoftServersDBManagerForm_UseProxy.Text = ClientStringFactory.GetString(382, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxyServersList_ProxyServersList.Text = ClientStringFactory.GetString(503, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.Text = ClientStringFactory.GetString(496, ClientSettingsEnvironment.CurrentLanguage);
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JurikSoftServersDBManagerForm));
        this.textBox_JurikSoftServersDBManagerForm_ServerHost = new System.Windows.Forms.TextBox();
        this.textBox_JurikSoftServersDBManagerForm_ServerLocation = new System.Windows.Forms.TextBox();
        this.textBox_JurikSoftServersDBManagerForm_ServerName = new System.Windows.Forms.TextBox();
        this.textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup = new System.Windows.Forms.TextBox();
        this.textBox_JurikSoftServersDBManagerForm_LoginForConnection = new System.Windows.Forms.TextBox();
        this.textBox_JurikSoftServersDBManagerForm_PasswordForConnection = new System.Windows.Forms.TextBox();
        this.textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain = new System.Windows.Forms.TextBox();
        this.textBox_JurikSoftServersDBManagerForm_ServerPort = new System.Windows.Forms.TextBox();
        this.textBox_JurikSoftServersDBManagerForm_ServerDescription = new System.Windows.Forms.TextBox();
        this.button_JurikSoftServersDBManagerForm_Apply = new System.Windows.Forms.Button();
        this.button_JurikSoftServersDBManagerForm_Cancel = new System.Windows.Forms.Button();
        this.button_JurikSoftServersDBManagerForm_AddToDB = new System.Windows.Forms.Button();
        this.label_JurikSoftServersDBManagerForm_ServerHost = new System.Windows.Forms.Label();
        this.label_JurikSoftServersDBManagerForm_LoginForConnection = new System.Windows.Forms.Label();
        this.label_JurikSoftServersDBManagerForm_ServerName = new System.Windows.Forms.Label();
        this.label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup = new System.Windows.Forms.Label();
        this.label_JurikSoftServersDBManagerForm_ServerDescription = new System.Windows.Forms.Label();
        this.label_JurikSoftServersDBManagerForm_ServerNetworkDomain = new System.Windows.Forms.Label();
        this.label_JurikSoftServersDBManagerForm_ServerLocation = new System.Windows.Forms.Label();
        this.label_JurikSoftServersDBManagerForm_PasswordForConnection = new System.Windows.Forms.Label();
        this.label_JurikSoftServersDBManagerForm_ServerPort = new System.Windows.Forms.Label();
        this.listView_ProxyServersList_ProxyServersList = new System.Windows.Forms.ListView();
        this.columnHeader_ProxyServersList_Title = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ProxyServersList_Host = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ProxyServersList_Port = new System.Windows.Forms.ColumnHeader();
        this.button_ProxyServersList_ViewRecord = new System.Windows.Forms.Button();
        this.button_ProxyServersList_AddRecord = new System.Windows.Forms.Button();
        this.checkBox_JurikSoftServersDBManagerForm_UseProxy = new System.Windows.Forms.CheckBox();
        this.button_ProxyServersList_EditRecord = new System.Windows.Forms.Button();
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList = new System.Windows.Forms.GroupBox();
        this.label_ProxyServersList_ProxyServersList = new System.Windows.Forms.Label();
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList = new System.Windows.Forms.GroupBox();
        this.button_GroupsList_RenameGroup = new System.Windows.Forms.Button();
        this.label_GroupsList_GroupsList = new System.Windows.Forms.Label();
        this.button_GroupsList_RemoveGroup = new System.Windows.Forms.Button();
        this.listBox_GroupsList_GroupsList = new System.Windows.Forms.ListBox();
        this.button_GroupsList_AddNewGroup = new System.Windows.Forms.Button();
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.SuspendLayout();
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.SuspendLayout();
        this.SuspendLayout();
        // 
        // textBox_JurikSoftServersDBManagerForm_ServerHost
        // 
        this.textBox_JurikSoftServersDBManagerForm_ServerHost.Location = new System.Drawing.Point(16, 32);
        this.textBox_JurikSoftServersDBManagerForm_ServerHost.Name = "textBox_JurikSoftServersDBManagerForm_ServerHost";
        this.textBox_JurikSoftServersDBManagerForm_ServerHost.Size = new System.Drawing.Size(120, 20);
        this.textBox_JurikSoftServersDBManagerForm_ServerHost.TabIndex = 0;
        // 
        // textBox_JurikSoftServersDBManagerForm_ServerLocation
        // 
        this.textBox_JurikSoftServersDBManagerForm_ServerLocation.Location = new System.Drawing.Point(184, 128);
        this.textBox_JurikSoftServersDBManagerForm_ServerLocation.Name = "textBox_JurikSoftServersDBManagerForm_ServerLocation";
        this.textBox_JurikSoftServersDBManagerForm_ServerLocation.Size = new System.Drawing.Size(152, 20);
        this.textBox_JurikSoftServersDBManagerForm_ServerLocation.TabIndex = 6;
        // 
        // textBox_JurikSoftServersDBManagerForm_ServerName
        // 
        this.textBox_JurikSoftServersDBManagerForm_ServerName.Location = new System.Drawing.Point(16, 128);
        this.textBox_JurikSoftServersDBManagerForm_ServerName.Name = "textBox_JurikSoftServersDBManagerForm_ServerName";
        this.textBox_JurikSoftServersDBManagerForm_ServerName.Size = new System.Drawing.Size(152, 20);
        this.textBox_JurikSoftServersDBManagerForm_ServerName.TabIndex = 5;
        // 
        // textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup
        // 
        this.textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.Location = new System.Drawing.Point(16, 176);
        this.textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.Name = "textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup";
        this.textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.Size = new System.Drawing.Size(152, 20);
        this.textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.TabIndex = 7;
        // 
        // textBox_JurikSoftServersDBManagerForm_LoginForConnection
        // 
        this.textBox_JurikSoftServersDBManagerForm_LoginForConnection.Location = new System.Drawing.Point(16, 80);
        this.textBox_JurikSoftServersDBManagerForm_LoginForConnection.Name = "textBox_JurikSoftServersDBManagerForm_LoginForConnection";
        this.textBox_JurikSoftServersDBManagerForm_LoginForConnection.Size = new System.Drawing.Size(152, 20);
        this.textBox_JurikSoftServersDBManagerForm_LoginForConnection.TabIndex = 3;
        // 
        // textBox_JurikSoftServersDBManagerForm_PasswordForConnection
        // 
        this.textBox_JurikSoftServersDBManagerForm_PasswordForConnection.Location = new System.Drawing.Point(184, 80);
        this.textBox_JurikSoftServersDBManagerForm_PasswordForConnection.Name = "textBox_JurikSoftServersDBManagerForm_PasswordForConnection";
        this.textBox_JurikSoftServersDBManagerForm_PasswordForConnection.PasswordChar = '*';
        this.textBox_JurikSoftServersDBManagerForm_PasswordForConnection.Size = new System.Drawing.Size(152, 20);
        this.textBox_JurikSoftServersDBManagerForm_PasswordForConnection.TabIndex = 4;
        // 
        // textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain
        // 
        this.textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain.Location = new System.Drawing.Point(184, 176);
        this.textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain.Name = "textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain";
        this.textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain.Size = new System.Drawing.Size(152, 20);
        this.textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain.TabIndex = 8;
        // 
        // textBox_JurikSoftServersDBManagerForm_ServerPort
        // 
        this.textBox_JurikSoftServersDBManagerForm_ServerPort.Location = new System.Drawing.Point(152, 32);
        this.textBox_JurikSoftServersDBManagerForm_ServerPort.Name = "textBox_JurikSoftServersDBManagerForm_ServerPort";
        this.textBox_JurikSoftServersDBManagerForm_ServerPort.Size = new System.Drawing.Size(48, 20);
        this.textBox_JurikSoftServersDBManagerForm_ServerPort.TabIndex = 1;
        // 
        // textBox_JurikSoftServersDBManagerForm_ServerDescription
        // 
        this.textBox_JurikSoftServersDBManagerForm_ServerDescription.Location = new System.Drawing.Point(16, 224);
        this.textBox_JurikSoftServersDBManagerForm_ServerDescription.Multiline = true;
        this.textBox_JurikSoftServersDBManagerForm_ServerDescription.Name = "textBox_JurikSoftServersDBManagerForm_ServerDescription";
        this.textBox_JurikSoftServersDBManagerForm_ServerDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.textBox_JurikSoftServersDBManagerForm_ServerDescription.Size = new System.Drawing.Size(320, 256);
        this.textBox_JurikSoftServersDBManagerForm_ServerDescription.TabIndex = 9;
        // 
        // button_JurikSoftServersDBManagerForm_Apply
        // 
        this.button_JurikSoftServersDBManagerForm_Apply.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_JurikSoftServersDBManagerForm_Apply.Location = new System.Drawing.Point(456, 456);
        this.button_JurikSoftServersDBManagerForm_Apply.Name = "button_JurikSoftServersDBManagerForm_Apply";
        this.button_JurikSoftServersDBManagerForm_Apply.Size = new System.Drawing.Size(104, 23);
        this.button_JurikSoftServersDBManagerForm_Apply.TabIndex = 19;
        this.button_JurikSoftServersDBManagerForm_Apply.Text = "Apply";
        this.button_JurikSoftServersDBManagerForm_Apply.Click += new System.EventHandler(this.button_JurikSoftServersDBManagerForm_Apply_Click);
        // 
        // button_JurikSoftServersDBManagerForm_Cancel
        // 
        this.button_JurikSoftServersDBManagerForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_JurikSoftServersDBManagerForm_Cancel.Location = new System.Drawing.Point(568, 456);
        this.button_JurikSoftServersDBManagerForm_Cancel.Name = "button_JurikSoftServersDBManagerForm_Cancel";
        this.button_JurikSoftServersDBManagerForm_Cancel.Size = new System.Drawing.Size(96, 23);
        this.button_JurikSoftServersDBManagerForm_Cancel.TabIndex = 20;
        this.button_JurikSoftServersDBManagerForm_Cancel.Text = "Cancel";
        this.button_JurikSoftServersDBManagerForm_Cancel.Click += new System.EventHandler(this.button_JurikSoftServersDBManagerForm_Cancel_Click);
        // 
        // button_JurikSoftServersDBManagerForm_AddToDB
        // 
        this.button_JurikSoftServersDBManagerForm_AddToDB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_JurikSoftServersDBManagerForm_AddToDB.Location = new System.Drawing.Point(352, 456);
        this.button_JurikSoftServersDBManagerForm_AddToDB.Name = "button_JurikSoftServersDBManagerForm_AddToDB";
        this.button_JurikSoftServersDBManagerForm_AddToDB.Size = new System.Drawing.Size(96, 23);
        this.button_JurikSoftServersDBManagerForm_AddToDB.TabIndex = 18;
        this.button_JurikSoftServersDBManagerForm_AddToDB.Text = "Add";
        this.button_JurikSoftServersDBManagerForm_AddToDB.Click += new System.EventHandler(this.button_JurikSoftServersDBManagerForm_AddToDB_Click);
        // 
        // label_JurikSoftServersDBManagerForm_ServerHost
        // 
        this.label_JurikSoftServersDBManagerForm_ServerHost.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_JurikSoftServersDBManagerForm_ServerHost.Location = new System.Drawing.Point(16, 16);
        this.label_JurikSoftServersDBManagerForm_ServerHost.Name = "label_JurikSoftServersDBManagerForm_ServerHost";
        this.label_JurikSoftServersDBManagerForm_ServerHost.Size = new System.Drawing.Size(120, 16);
        this.label_JurikSoftServersDBManagerForm_ServerHost.TabIndex = 75;
        this.label_JurikSoftServersDBManagerForm_ServerHost.Text = "Host:";
        // 
        // label_JurikSoftServersDBManagerForm_LoginForConnection
        // 
        this.label_JurikSoftServersDBManagerForm_LoginForConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_JurikSoftServersDBManagerForm_LoginForConnection.Location = new System.Drawing.Point(16, 64);
        this.label_JurikSoftServersDBManagerForm_LoginForConnection.Name = "label_JurikSoftServersDBManagerForm_LoginForConnection";
        this.label_JurikSoftServersDBManagerForm_LoginForConnection.Size = new System.Drawing.Size(152, 16);
        this.label_JurikSoftServersDBManagerForm_LoginForConnection.TabIndex = 76;
        this.label_JurikSoftServersDBManagerForm_LoginForConnection.Text = "Login:";
        // 
        // label_JurikSoftServersDBManagerForm_ServerName
        // 
        this.label_JurikSoftServersDBManagerForm_ServerName.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_JurikSoftServersDBManagerForm_ServerName.Location = new System.Drawing.Point(16, 112);
        this.label_JurikSoftServersDBManagerForm_ServerName.Name = "label_JurikSoftServersDBManagerForm_ServerName";
        this.label_JurikSoftServersDBManagerForm_ServerName.Size = new System.Drawing.Size(152, 16);
        this.label_JurikSoftServersDBManagerForm_ServerName.TabIndex = 77;
        this.label_JurikSoftServersDBManagerForm_ServerName.Text = "Server name:";
        // 
        // label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup
        // 
        this.label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.Location = new System.Drawing.Point(16, 160);
        this.label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.Name = "label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup";
        this.label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.Size = new System.Drawing.Size(152, 16);
        this.label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.TabIndex = 78;
        this.label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.Text = "Network workgroup:";
        // 
        // label_JurikSoftServersDBManagerForm_ServerDescription
        // 
        this.label_JurikSoftServersDBManagerForm_ServerDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_JurikSoftServersDBManagerForm_ServerDescription.Location = new System.Drawing.Point(16, 208);
        this.label_JurikSoftServersDBManagerForm_ServerDescription.Name = "label_JurikSoftServersDBManagerForm_ServerDescription";
        this.label_JurikSoftServersDBManagerForm_ServerDescription.Size = new System.Drawing.Size(152, 16);
        this.label_JurikSoftServersDBManagerForm_ServerDescription.TabIndex = 79;
        this.label_JurikSoftServersDBManagerForm_ServerDescription.Text = "Description:";
        // 
        // label_JurikSoftServersDBManagerForm_ServerNetworkDomain
        // 
        this.label_JurikSoftServersDBManagerForm_ServerNetworkDomain.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_JurikSoftServersDBManagerForm_ServerNetworkDomain.Location = new System.Drawing.Point(184, 160);
        this.label_JurikSoftServersDBManagerForm_ServerNetworkDomain.Name = "label_JurikSoftServersDBManagerForm_ServerNetworkDomain";
        this.label_JurikSoftServersDBManagerForm_ServerNetworkDomain.Size = new System.Drawing.Size(152, 16);
        this.label_JurikSoftServersDBManagerForm_ServerNetworkDomain.TabIndex = 80;
        this.label_JurikSoftServersDBManagerForm_ServerNetworkDomain.Text = "Network domain:";
        // 
        // label_JurikSoftServersDBManagerForm_ServerLocation
        // 
        this.label_JurikSoftServersDBManagerForm_ServerLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_JurikSoftServersDBManagerForm_ServerLocation.Location = new System.Drawing.Point(184, 112);
        this.label_JurikSoftServersDBManagerForm_ServerLocation.Name = "label_JurikSoftServersDBManagerForm_ServerLocation";
        this.label_JurikSoftServersDBManagerForm_ServerLocation.Size = new System.Drawing.Size(152, 16);
        this.label_JurikSoftServersDBManagerForm_ServerLocation.TabIndex = 81;
        this.label_JurikSoftServersDBManagerForm_ServerLocation.Text = "Server location:";
        // 
        // label_JurikSoftServersDBManagerForm_PasswordForConnection
        // 
        this.label_JurikSoftServersDBManagerForm_PasswordForConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_JurikSoftServersDBManagerForm_PasswordForConnection.Location = new System.Drawing.Point(184, 64);
        this.label_JurikSoftServersDBManagerForm_PasswordForConnection.Name = "label_JurikSoftServersDBManagerForm_PasswordForConnection";
        this.label_JurikSoftServersDBManagerForm_PasswordForConnection.Size = new System.Drawing.Size(152, 16);
        this.label_JurikSoftServersDBManagerForm_PasswordForConnection.TabIndex = 82;
        this.label_JurikSoftServersDBManagerForm_PasswordForConnection.Text = "Password:";
        // 
        // label_JurikSoftServersDBManagerForm_ServerPort
        // 
        this.label_JurikSoftServersDBManagerForm_ServerPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_JurikSoftServersDBManagerForm_ServerPort.Location = new System.Drawing.Point(152, 16);
        this.label_JurikSoftServersDBManagerForm_ServerPort.Name = "label_JurikSoftServersDBManagerForm_ServerPort";
        this.label_JurikSoftServersDBManagerForm_ServerPort.Size = new System.Drawing.Size(56, 16);
        this.label_JurikSoftServersDBManagerForm_ServerPort.TabIndex = 83;
        this.label_JurikSoftServersDBManagerForm_ServerPort.Text = "Port:";
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
        // checkBox_JurikSoftServersDBManagerForm_UseProxy
        // 
        this.checkBox_JurikSoftServersDBManagerForm_UseProxy.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_JurikSoftServersDBManagerForm_UseProxy.Location = new System.Drawing.Point(216, 36);
        this.checkBox_JurikSoftServersDBManagerForm_UseProxy.Name = "checkBox_JurikSoftServersDBManagerForm_UseProxy";
        this.checkBox_JurikSoftServersDBManagerForm_UseProxy.Size = new System.Drawing.Size(136, 16);
        this.checkBox_JurikSoftServersDBManagerForm_UseProxy.TabIndex = 2;
        this.checkBox_JurikSoftServersDBManagerForm_UseProxy.Text = "Use Proxy";
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
        // groupBox_JurikSoftServersDBManagerForm_ProxyServersList
        // 
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.Controls.Add(this.label_ProxyServersList_ProxyServersList);
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.Controls.Add(this.button_ProxyServersList_ViewRecord);
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.Controls.Add(this.listView_ProxyServersList_ProxyServersList);
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.Controls.Add(this.button_ProxyServersList_AddRecord);
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.Controls.Add(this.button_ProxyServersList_EditRecord);
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.Location = new System.Drawing.Point(352, 216);
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.Name = "groupBox_JurikSoftServersDBManagerForm_ProxyServersList";
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.Size = new System.Drawing.Size(312, 224);
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.TabIndex = 89;
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.TabStop = false;
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.Text = "Used Proxy Server";
        // 
        // label_ProxyServersList_ProxyServersList
        // 
        this.label_ProxyServersList_ProxyServersList.Location = new System.Drawing.Point(16, 24);
        this.label_ProxyServersList_ProxyServersList.Name = "label_ProxyServersList_ProxyServersList";
        this.label_ProxyServersList_ProxyServersList.Size = new System.Drawing.Size(280, 16);
        this.label_ProxyServersList_ProxyServersList.TabIndex = 92;
        this.label_ProxyServersList_ProxyServersList.Text = "Available Proxy\\Firewalls Servers (select one):";
        // 
        // groupBox_JurikSoftServersDBManagerForm_GroupsList
        // 
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.Controls.Add(this.button_GroupsList_RenameGroup);
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.Controls.Add(this.label_GroupsList_GroupsList);
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.Controls.Add(this.button_GroupsList_RemoveGroup);
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.Controls.Add(this.listBox_GroupsList_GroupsList);
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.Controls.Add(this.button_GroupsList_AddNewGroup);
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.Location = new System.Drawing.Point(352, 24);
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.Name = "groupBox_JurikSoftServersDBManagerForm_GroupsList";
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.Size = new System.Drawing.Size(312, 176);
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.TabIndex = 90;
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.TabStop = false;
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.Text = "Group Member";
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
        this.button_GroupsList_RemoveGroup.Click += new System.EventHandler(this.button_JurikSoftServersDBManagerForm_RemoveGroupRecord_Click);
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
        // JurikSoftServersDBManagerForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(682, 496);
        this.Controls.Add(this.groupBox_JurikSoftServersDBManagerForm_GroupsList);
        this.Controls.Add(this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList);
        this.Controls.Add(this.label_JurikSoftServersDBManagerForm_ServerPort);
        this.Controls.Add(this.label_JurikSoftServersDBManagerForm_PasswordForConnection);
        this.Controls.Add(this.label_JurikSoftServersDBManagerForm_ServerLocation);
        this.Controls.Add(this.label_JurikSoftServersDBManagerForm_ServerNetworkDomain);
        this.Controls.Add(this.label_JurikSoftServersDBManagerForm_ServerDescription);
        this.Controls.Add(this.label_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup);
        this.Controls.Add(this.label_JurikSoftServersDBManagerForm_ServerName);
        this.Controls.Add(this.label_JurikSoftServersDBManagerForm_LoginForConnection);
        this.Controls.Add(this.label_JurikSoftServersDBManagerForm_ServerHost);
        this.Controls.Add(this.button_JurikSoftServersDBManagerForm_Apply);
        this.Controls.Add(this.button_JurikSoftServersDBManagerForm_Cancel);
        this.Controls.Add(this.button_JurikSoftServersDBManagerForm_AddToDB);
        this.Controls.Add(this.textBox_JurikSoftServersDBManagerForm_ServerDescription);
        this.Controls.Add(this.textBox_JurikSoftServersDBManagerForm_ServerPort);
        this.Controls.Add(this.textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain);
        this.Controls.Add(this.textBox_JurikSoftServersDBManagerForm_PasswordForConnection);
        this.Controls.Add(this.textBox_JurikSoftServersDBManagerForm_LoginForConnection);
        this.Controls.Add(this.textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup);
        this.Controls.Add(this.textBox_JurikSoftServersDBManagerForm_ServerName);
        this.Controls.Add(this.textBox_JurikSoftServersDBManagerForm_ServerLocation);
        this.Controls.Add(this.textBox_JurikSoftServersDBManagerForm_ServerHost);
        this.Controls.Add(this.checkBox_JurikSoftServersDBManagerForm_UseProxy);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(688, 528);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(688, 528);
        this.Name = "JurikSoftServersDBManagerForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "JurikSoftServersDBManagerForm";
        this.Shown += new System.EventHandler(this.JurikSoftServersDBManagerForm_Shown);
        this.groupBox_JurikSoftServersDBManagerForm_ProxyServersList.ResumeLayout(false);
        this.groupBox_JurikSoftServersDBManagerForm_GroupsList.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    #endregion

    private void button_JurikSoftServersDBManagerForm_AddToDB_Click(object sender, System.EventArgs e)
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
            this.checkBox_JurikSoftServersDBManagerForm_UseProxy.Checked = false;
        }
        else
        {
            int_SelectedProxyIndex = this.listView_ProxyServersList_ProxyServersList.SelectedItems[0].Index;
        }


        if (ServerPort == -1) return;

        DataRow dataRow_NewRecord = null;

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersDataTable jurikSoftServersDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers;

        ////////////////////////////////////////////////////////////////////////////////


        dataRow_NewRecord = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.NewRow();

        int int_JurikSoftServerID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (jurikSoftServersDataTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= jurikSoftServersDataTable_obj.Rows.Count
            || (int)jurikSoftServersDataTable_obj.Rows[int_CycleCount][jurikSoftServersDataTable_obj.IDColumn] == int_JurikSoftServerID)
            {
                int_JurikSoftServerID++;
                int_CycleCount = -1;
            }

            else if (int_CycleCount + 1 == jurikSoftServersDataTable_obj.Rows.Count) break;
        }


        dataRow_NewRecord[jurikSoftServersDataTable_obj.IDColumn] = int_JurikSoftServerID;

        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerHostColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerHost.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerPortColumn] = ServerPort;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.LoginColumn] = this.textBox_JurikSoftServersDBManagerForm_LoginForConnection.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.PasswordColumn] = this.textBox_JurikSoftServersDBManagerForm_PasswordForConnection.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerLocationColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerLocation.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerNameColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerName.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerDescriptionColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerDescription.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.DomainColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.WorkGroupColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.UseProxyServerColumn] = this.checkBox_JurikSoftServersDBManagerForm_UseProxy.Checked;

        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerGroupTypeIDColumn] = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes[this.listBox_GroupsList_GroupsList.SelectedIndex].ID;

        if (this.listView_ProxyServersList_ProxyServersList.Items.Count > 0)
            dataRow_NewRecord[jurikSoftServersDataTable_obj.ProxyServerIDColumn] = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings[int_SelectedProxyIndex + 1].ID;

        JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows.Add(dataRow_NewRecord);

        ObjCopy.obj_MainClientForm.AddNewJurikSoftServersListItem(this.textBox_JurikSoftServersDBManagerForm_ServerName.Text,

        this.textBox_JurikSoftServersDBManagerForm_ServerHost.Text, this.textBox_JurikSoftServersDBManagerForm_ServerPort.Text,
        this.textBox_JurikSoftServersDBManagerForm_ServerLocation.Text, this.listBox_GroupsList_GroupsList.Text);

        ObjCopy.obj_MainClientForm.RefreshJurikSoftServersGroups();

        JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.AcceptChanges();

        this.Close();
    }

    private void button_JurikSoftServersDBManagerForm_Apply_Click(object sender, System.EventArgs e)
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
            this.checkBox_JurikSoftServersDBManagerForm_UseProxy.Checked = false;
        }
        else
        {
            int_SelectedProxyIndex = this.listView_ProxyServersList_ProxyServersList.SelectedItems[0].Index;
        }


        if (ServerPort == -1) return;

        DataRow dataRow_NewRecord = null;

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersDataTable jurikSoftServersDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers;

        ////////////////////////////////////////////////////////////////////////////////


        dataRow_NewRecord = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows[EditedRecordIndex];


        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerHostColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerHost.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerPortColumn] = ServerPort;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.LoginColumn] = this.textBox_JurikSoftServersDBManagerForm_LoginForConnection.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.PasswordColumn] = this.textBox_JurikSoftServersDBManagerForm_PasswordForConnection.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerLocationColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerLocation.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerNameColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerName.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerDescriptionColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerDescription.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.DomainColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.WorkGroupColumn] = this.textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup.Text;
        dataRow_NewRecord[jurikSoftServersDataTable_obj.UseProxyServerColumn] = this.checkBox_JurikSoftServersDBManagerForm_UseProxy.Checked;

        dataRow_NewRecord[jurikSoftServersDataTable_obj.ServerGroupTypeIDColumn] = this.listBox_GroupsList_GroupsList.SelectedIndex;

        if (this.listView_ProxyServersList_ProxyServersList.Items.Count > 0)
            dataRow_NewRecord[jurikSoftServersDataTable_obj.ProxyServerIDColumn] = int_SelectedProxyIndex + 1;

        ObjCopy.obj_MainClientForm.EditSelectedJurikSoftServersListItem(this.textBox_JurikSoftServersDBManagerForm_ServerName.Text,
                                                                        this.textBox_JurikSoftServersDBManagerForm_ServerHost.Text,
                                                                        this.textBox_JurikSoftServersDBManagerForm_ServerPort.Text,
                                                                        this.textBox_JurikSoftServersDBManagerForm_ServerLocation.Text,
                                                                        this.listBox_GroupsList_GroupsList.Text);

        ObjCopy.obj_MainClientForm.RefreshJurikSoftServersGroups();

        this.Close();
    }

    private void button_JurikSoftServersDBManagerForm_Cancel_Click(object sender, System.EventArgs e)
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

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ServerGroupTypesDataTable serverGroupTypesTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes;

        ////////////////////////////////////////////////////////////////////////////////


        dataRow_NewRecord = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.NewRow();


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


        JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes.Rows.Add(dataRow_NewRecord);

        ObjCopy.obj_MainClientForm.RefreshJurikSoftServersGroups();

        this.listBox_GroupsList_GroupsList.SelectedIndex = this.listBox_GroupsList_GroupsList.Items.Count - 1;

    }

    private void button_GroupsList_RenameGroup_Click(object sender, System.EventArgs e)
    {
        if (this.listBox_GroupsList_GroupsList.SelectedIndex < 0) return;

        RenameItemForm renameItemForm_obj = new RenameItemForm();

        renameItemForm_obj.OldItemName = (string)this.listBox_GroupsList_GroupsList.SelectedItem.ToString();

        renameItemForm_obj.ShowDialog();

        int int_SelectedItemIndex = this.listBox_GroupsList_GroupsList.SelectedIndex;

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ServerGroupTypesDataTable serverGroupTypesTableDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes;

        serverGroupTypesTableDataTable_obj.Rows[int_SelectedItemIndex][serverGroupTypesTableDataTable_obj.GroupNameColumn] = renameItemForm_obj.NewItemName;



        this.listBox_GroupsList_GroupsList.Items.RemoveAt(int_SelectedItemIndex);

        this.listBox_GroupsList_GroupsList.Items.Insert(int_SelectedItemIndex, renameItemForm_obj.NewItemName);

        this.listBox_GroupsList_GroupsList.SelectedIndex = int_SelectedItemIndex;

    }

    private void button_JurikSoftServersDBManagerForm_RemoveGroupRecord_Click(object sender, System.EventArgs e)
    {
        if (this.listBox_GroupsList_GroupsList.Items.Count == 0) return;

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ServerGroupTypesDataTable serverGroupTypesTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ServerGroupTypes;

        DataRow[] dataRowArray_RowsToDelete = serverGroupTypesTable_obj.Rows[this.listBox_GroupsList_GroupsList.SelectedIndex].GetChildRows("ServerGroupTypes_JurikSoftServerInfo");

        if (dataRowArray_RowsToDelete.Length == 0)
        {
            serverGroupTypesTable_obj.RemoveServerGroupTypesRow((DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ServerGroupTypesRow)serverGroupTypesTable_obj.Rows[this.listBox_GroupsList_GroupsList.SelectedIndex]);

            this.listBox_GroupsList_GroupsList.Items.RemoveAt(this.listBox_GroupsList_GroupsList.SelectedIndex);

            if (this.listBox_GroupsList_GroupsList.Items.Count > 0)
            {
                this.listBox_GroupsList_GroupsList.SelectedIndex = 0;
            }

            return;
        }

        if (DialogResult.Yes == MessageBox.Show(ClientStringFactory.GetString(507, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            foreach (DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersRow row_Current in dataRowArray_RowsToDelete)
            {
                JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.RemoveJurikSoftServersRow(row_Current);
            }

            serverGroupTypesTable_obj.RemoveServerGroupTypesRow((DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ServerGroupTypesRow)serverGroupTypesTable_obj.Rows[this.listBox_GroupsList_GroupsList.SelectedIndex]);

            this.listBox_GroupsList_GroupsList.Items.RemoveAt(this.listBox_GroupsList_GroupsList.SelectedIndex);

            if (this.listBox_GroupsList_GroupsList.Items.Count > 0)
            {
                this.listBox_GroupsList_GroupsList.SelectedIndex = 0;
            }
                      
            ObjCopy.obj_MainClientForm.FillJurikSoftServersList();

            return;
        }
    }



    public int ServerPort
    {
        get
        {
            try
            {
                if (Convert.ToInt32(this.textBox_JurikSoftServersDBManagerForm_ServerPort.Text) > 65535 || Convert.ToInt32(this.textBox_JurikSoftServersDBManagerForm_ServerPort.Text) < 1)
                {
                    MessageBox.Show(ClientStringFactory.GetString(444, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);
                    return -1;
                }

                return int.Parse(this.textBox_JurikSoftServersDBManagerForm_ServerPort.Text);
            }

            catch (FormatException)
            {
                MessageBox.Show(ClientStringFactory.GetString(444, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);
                return -1;
            }
        }

        set
        {
            this.textBox_JurikSoftServersDBManagerForm_ServerPort.Text = value.ToString();
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
            return this.button_JurikSoftServersDBManagerForm_Apply;
        }
    }


    public Button CancelButton
    {
        get
        {
            return this.button_JurikSoftServersDBManagerForm_Cancel;
        }
    }

    public Button AddButton
    {
        get
        {
            return this.button_JurikSoftServersDBManagerForm_AddToDB;
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
            return this.checkBox_JurikSoftServersDBManagerForm_UseProxy;
        }
    }


    public TextBox ServerDescriptionTextBox
    {
        get
        {
            return this.textBox_JurikSoftServersDBManagerForm_ServerDescription;
        }
    }

    public TextBox ServerHostTextBox
    {
        get
        {
            return this.textBox_JurikSoftServersDBManagerForm_ServerHost;
        }
    }

    public TextBox ServerLocationTextBox
    {
        get
        {
            return this.textBox_JurikSoftServersDBManagerForm_ServerLocation;
        }
    }

    public TextBox ServerNameTextBox
    {
        get
        {
            return this.textBox_JurikSoftServersDBManagerForm_ServerName;
        }
    }

    public TextBox ServerPortTextBox
    {
        get
        {
            return this.textBox_JurikSoftServersDBManagerForm_ServerPort;
        }
    }

    public TextBox ServerNetworkWorkgroupTextBox
    {
        get
        {
            return this.textBox_JurikSoftServersDBManagerForm_ServerNetworkWorkgroup;
        }
    }

    public TextBox ServerNetworkDomainTextBox
    {
        get
        {
            return this.textBox_JurikSoftServersDBManagerForm_ServerNetworkDomain;
        }
    }

    public TextBox LoginForConnectionTextBox
    {
        get
        {
            return this.textBox_JurikSoftServersDBManagerForm_LoginForConnection;
        }
    }

    public TextBox PasswordForConnectionTextBox
    {
        get
        {
            return this.textBox_JurikSoftServersDBManagerForm_PasswordForConnection;
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

    private void JurikSoftServersDBManagerForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }
}

