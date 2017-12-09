using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;

public class ProxyDBManagerForm : System.Windows.Forms.Form
{/*
    private System.Windows.Forms.Label label_ProxyDBManagerForm_ProxyType;
    private System.Windows.Forms.CheckBox checkBox_ProxyDBManagerForm_ResolveHostNames;
    private System.Windows.Forms.CheckBox checkBox_ProxyDBManagerForm_Authentication;
    private System.Windows.Forms.Label label_ProxyDBManagerForm_ProxyTimeOut;
    private System.Windows.Forms.ComboBox comboBox_ProxyDBManagerForm_ProxyTimeOut;
    private System.Windows.Forms.Label label_ProxyDBManagerForm_ProxyPort;
    private System.Windows.Forms.Label label_ProxyDBManagerForm_ProxyHost;
    private System.Windows.Forms.TextBox textBox_ProxyDBManagerForm_ProxyPort;
    private System.Windows.Forms.TextBox textBox_ProxyDBManagerForm_ProxyHost;
    private System.Windows.Forms.Label label_ProxyDBManagerForm_Socks5Password;
    private System.Windows.Forms.Label label_ProxyDBManagerForm_Socks5UserName;
    private System.Windows.Forms.TextBox textBox_ProxyDBManagerForm_Socks5Password;
    private System.Windows.Forms.TextBox textBox_ProxyDBManagerForm_Socks5UserName;
    private System.Windows.Forms.ListBox listBox_ProxyDBManagerForm_ProxyType;
    private System.Windows.Forms.Label label_ProxyDBManagerForm_Location;
    private System.Windows.Forms.Label label_ProxyDBManagerForm_Title;
    private System.Windows.Forms.TextBox textBox_ProxyDBManagerForm_Location;
    private System.Windows.Forms.TextBox textBox_ProxyDBManagerForm_Title;
    private System.Windows.Forms.Label label_ProxyDBManagerForm_Description;
    private System.Windows.Forms.Button button_ProxyDBManagerForm_AddToDB;
    private System.Windows.Forms.Button button_ProxyDBManagerForm_Cancel;
    private System.Windows.Forms.TextBox textBox_ProxyDBManagerForm_Description;
    private System.Windows.Forms.Button button_ProxyDBManagerForm_Apply;

    private System.ComponentModel.Container components = null;

    public ProxyDBManagerForm()
    {
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();


        ChangeControlsLanguage();

        //
        // TODO: Add any constructor code after InitializeComponent call
        //

        this.comboBox_ProxyDBManagerForm_ProxyTimeOut.SelectedIndex = 0;
        this.comboBox_ProxyDBManagerForm_ProxyTimeOut.Select();

        this.listBox_ProxyDBManagerForm_ProxyType.SelectedIndex = 1;
        this.listBox_ProxyDBManagerForm_ProxyType.Select();

        this.checkBox_ProxyDBManagerForm_Authentication_CheckedChanged(null, null);
        this.listBox_ProxyDBManagerForm_ProxyType_SelectedIndexChanged(null, null);
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

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProxyDBManagerForm));
        this.label_ProxyDBManagerForm_ProxyType = new System.Windows.Forms.Label();
        this.checkBox_ProxyDBManagerForm_ResolveHostNames = new System.Windows.Forms.CheckBox();
        this.checkBox_ProxyDBManagerForm_Authentication = new System.Windows.Forms.CheckBox();
        this.label_ProxyDBManagerForm_ProxyTimeOut = new System.Windows.Forms.Label();
        this.comboBox_ProxyDBManagerForm_ProxyTimeOut = new System.Windows.Forms.ComboBox();
        this.label_ProxyDBManagerForm_ProxyPort = new System.Windows.Forms.Label();
        this.label_ProxyDBManagerForm_ProxyHost = new System.Windows.Forms.Label();
        this.textBox_ProxyDBManagerForm_ProxyPort = new System.Windows.Forms.TextBox();
        this.textBox_ProxyDBManagerForm_ProxyHost = new System.Windows.Forms.TextBox();
        this.label_ProxyDBManagerForm_Socks5Password = new System.Windows.Forms.Label();
        this.label_ProxyDBManagerForm_Socks5UserName = new System.Windows.Forms.Label();
        this.textBox_ProxyDBManagerForm_Socks5Password = new System.Windows.Forms.TextBox();
        this.textBox_ProxyDBManagerForm_Socks5UserName = new System.Windows.Forms.TextBox();
        this.listBox_ProxyDBManagerForm_ProxyType = new System.Windows.Forms.ListBox();
        this.label_ProxyDBManagerForm_Location = new System.Windows.Forms.Label();
        this.label_ProxyDBManagerForm_Title = new System.Windows.Forms.Label();
        this.textBox_ProxyDBManagerForm_Location = new System.Windows.Forms.TextBox();
        this.textBox_ProxyDBManagerForm_Title = new System.Windows.Forms.TextBox();
        this.label_ProxyDBManagerForm_Description = new System.Windows.Forms.Label();
        this.button_ProxyDBManagerForm_AddToDB = new System.Windows.Forms.Button();
        this.button_ProxyDBManagerForm_Cancel = new System.Windows.Forms.Button();
        this.textBox_ProxyDBManagerForm_Description = new System.Windows.Forms.TextBox();
        this.button_ProxyDBManagerForm_Apply = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // label_ProxyDBManagerForm_ProxyType
        // 
        this.label_ProxyDBManagerForm_ProxyType.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ProxyDBManagerForm_ProxyType.Location = new System.Drawing.Point(16, 16);
        this.label_ProxyDBManagerForm_ProxyType.Name = "label_ProxyDBManagerForm_ProxyType";
        this.label_ProxyDBManagerForm_ProxyType.Size = new System.Drawing.Size(128, 16);
        this.label_ProxyDBManagerForm_ProxyType.TabIndex = 59;
        this.label_ProxyDBManagerForm_ProxyType.Text = "Proxy Type:";
        // 
        // checkBox_ProxyDBManagerForm_ResolveHostNames
        // 
        this.checkBox_ProxyDBManagerForm_ResolveHostNames.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_ProxyDBManagerForm_ResolveHostNames.Location = new System.Drawing.Point(16, 176);
        this.checkBox_ProxyDBManagerForm_ResolveHostNames.Name = "checkBox_ProxyDBManagerForm_ResolveHostNames";
        this.checkBox_ProxyDBManagerForm_ResolveHostNames.Size = new System.Drawing.Size(216, 16);
        this.checkBox_ProxyDBManagerForm_ResolveHostNames.TabIndex = 58;
        this.checkBox_ProxyDBManagerForm_ResolveHostNames.Text = "Use Proxy to resolve hostnames";
        // 
        // checkBox_ProxyDBManagerForm_Authentication
        // 
        this.checkBox_ProxyDBManagerForm_Authentication.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_ProxyDBManagerForm_Authentication.Location = new System.Drawing.Point(16, 104);
        this.checkBox_ProxyDBManagerForm_Authentication.Name = "checkBox_ProxyDBManagerForm_Authentication";
        this.checkBox_ProxyDBManagerForm_Authentication.Size = new System.Drawing.Size(136, 16);
        this.checkBox_ProxyDBManagerForm_Authentication.TabIndex = 57;
        this.checkBox_ProxyDBManagerForm_Authentication.Text = "Authentication";
        this.checkBox_ProxyDBManagerForm_Authentication.CheckedChanged += new System.EventHandler(this.checkBox_ProxyDBManagerForm_Authentication_CheckedChanged);
        // 
        // label_ProxyDBManagerForm_ProxyTimeOut
        // 
        this.label_ProxyDBManagerForm_ProxyTimeOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ProxyDBManagerForm_ProxyTimeOut.Location = new System.Drawing.Point(208, 56);
        this.label_ProxyDBManagerForm_ProxyTimeOut.Name = "label_ProxyDBManagerForm_ProxyTimeOut";
        this.label_ProxyDBManagerForm_ProxyTimeOut.Size = new System.Drawing.Size(64, 16);
        this.label_ProxyDBManagerForm_ProxyTimeOut.TabIndex = 56;
        this.label_ProxyDBManagerForm_ProxyTimeOut.Text = "Time Out:";
        // 
        // comboBox_ProxyDBManagerForm_ProxyTimeOut
        // 
        this.comboBox_ProxyDBManagerForm_ProxyTimeOut.Items.AddRange(new object[] {
            "5 seconds",
            "10 seconds",
            "15 seconds"});
        this.comboBox_ProxyDBManagerForm_ProxyTimeOut.Location = new System.Drawing.Point(208, 72);
        this.comboBox_ProxyDBManagerForm_ProxyTimeOut.Name = "comboBox_ProxyDBManagerForm_ProxyTimeOut";
        this.comboBox_ProxyDBManagerForm_ProxyTimeOut.Size = new System.Drawing.Size(80, 21);
        this.comboBox_ProxyDBManagerForm_ProxyTimeOut.TabIndex = 55;
        // 
        // label_ProxyDBManagerForm_ProxyPort
        // 
        this.label_ProxyDBManagerForm_ProxyPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ProxyDBManagerForm_ProxyPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ProxyDBManagerForm_ProxyPort.Location = new System.Drawing.Point(152, 56);
        this.label_ProxyDBManagerForm_ProxyPort.Name = "label_ProxyDBManagerForm_ProxyPort";
        this.label_ProxyDBManagerForm_ProxyPort.Size = new System.Drawing.Size(48, 16);
        this.label_ProxyDBManagerForm_ProxyPort.TabIndex = 52;
        this.label_ProxyDBManagerForm_ProxyPort.Text = "Port:";
        // 
        // label_ProxyDBManagerForm_ProxyHost
        // 
        this.label_ProxyDBManagerForm_ProxyHost.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ProxyDBManagerForm_ProxyHost.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ProxyDBManagerForm_ProxyHost.Location = new System.Drawing.Point(152, 16);
        this.label_ProxyDBManagerForm_ProxyHost.Name = "label_ProxyDBManagerForm_ProxyHost";
        this.label_ProxyDBManagerForm_ProxyHost.Size = new System.Drawing.Size(136, 16);
        this.label_ProxyDBManagerForm_ProxyHost.TabIndex = 51;
        this.label_ProxyDBManagerForm_ProxyHost.Text = "Host:";
        // 
        // textBox_ProxyDBManagerForm_ProxyPort
        // 
        this.textBox_ProxyDBManagerForm_ProxyPort.Location = new System.Drawing.Point(152, 72);
        this.textBox_ProxyDBManagerForm_ProxyPort.MaxLength = 5;
        this.textBox_ProxyDBManagerForm_ProxyPort.Name = "textBox_ProxyDBManagerForm_ProxyPort";
        this.textBox_ProxyDBManagerForm_ProxyPort.Size = new System.Drawing.Size(48, 20);
        this.textBox_ProxyDBManagerForm_ProxyPort.TabIndex = 50;
        this.textBox_ProxyDBManagerForm_ProxyPort.Text = "1080";
        // 
        // textBox_ProxyDBManagerForm_ProxyHost
        // 
        this.textBox_ProxyDBManagerForm_ProxyHost.Location = new System.Drawing.Point(152, 32);
        this.textBox_ProxyDBManagerForm_ProxyHost.Name = "textBox_ProxyDBManagerForm_ProxyHost";
        this.textBox_ProxyDBManagerForm_ProxyHost.Size = new System.Drawing.Size(136, 20);
        this.textBox_ProxyDBManagerForm_ProxyHost.TabIndex = 49;
        // 
        // label_ProxyDBManagerForm_Socks5Password
        // 
        this.label_ProxyDBManagerForm_Socks5Password.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ProxyDBManagerForm_Socks5Password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ProxyDBManagerForm_Socks5Password.Location = new System.Drawing.Point(152, 128);
        this.label_ProxyDBManagerForm_Socks5Password.Name = "label_ProxyDBManagerForm_Socks5Password";
        this.label_ProxyDBManagerForm_Socks5Password.Size = new System.Drawing.Size(136, 16);
        this.label_ProxyDBManagerForm_Socks5Password.TabIndex = 48;
        this.label_ProxyDBManagerForm_Socks5Password.Text = "Password:";
        // 
        // label_ProxyDBManagerForm_Socks5UserName
        // 
        this.label_ProxyDBManagerForm_Socks5UserName.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ProxyDBManagerForm_Socks5UserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ProxyDBManagerForm_Socks5UserName.Location = new System.Drawing.Point(16, 128);
        this.label_ProxyDBManagerForm_Socks5UserName.Name = "label_ProxyDBManagerForm_Socks5UserName";
        this.label_ProxyDBManagerForm_Socks5UserName.Size = new System.Drawing.Size(128, 16);
        this.label_ProxyDBManagerForm_Socks5UserName.TabIndex = 47;
        this.label_ProxyDBManagerForm_Socks5UserName.Text = "User Name:";
        // 
        // textBox_ProxyDBManagerForm_Socks5Password
        // 
        this.textBox_ProxyDBManagerForm_Socks5Password.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.textBox_ProxyDBManagerForm_Socks5Password.Location = new System.Drawing.Point(152, 144);
        this.textBox_ProxyDBManagerForm_Socks5Password.Name = "textBox_ProxyDBManagerForm_Socks5Password";
        this.textBox_ProxyDBManagerForm_Socks5Password.PasswordChar = '*';
        this.textBox_ProxyDBManagerForm_Socks5Password.Size = new System.Drawing.Size(136, 20);
        this.textBox_ProxyDBManagerForm_Socks5Password.TabIndex = 46;
        // 
        // textBox_ProxyDBManagerForm_Socks5UserName
        // 
        this.textBox_ProxyDBManagerForm_Socks5UserName.Location = new System.Drawing.Point(16, 144);
        this.textBox_ProxyDBManagerForm_Socks5UserName.Name = "textBox_ProxyDBManagerForm_Socks5UserName";
        this.textBox_ProxyDBManagerForm_Socks5UserName.Size = new System.Drawing.Size(128, 20);
        this.textBox_ProxyDBManagerForm_Socks5UserName.TabIndex = 45;
        // 
        // listBox_ProxyDBManagerForm_ProxyType
        // 
        this.listBox_ProxyDBManagerForm_ProxyType.IntegralHeight = false;
        this.listBox_ProxyDBManagerForm_ProxyType.Items.AddRange(new object[] {
            "Socks server version 4",
            "Socks server version 5",
            "HTTPS Proxy server"});
        this.listBox_ProxyDBManagerForm_ProxyType.Location = new System.Drawing.Point(16, 32);
        this.listBox_ProxyDBManagerForm_ProxyType.Name = "listBox_ProxyDBManagerForm_ProxyType";
        this.listBox_ProxyDBManagerForm_ProxyType.Size = new System.Drawing.Size(128, 60);
        this.listBox_ProxyDBManagerForm_ProxyType.TabIndex = 53;
        this.listBox_ProxyDBManagerForm_ProxyType.SelectedIndexChanged += new System.EventHandler(this.listBox_ProxyDBManagerForm_ProxyType_SelectedIndexChanged);
        // 
        // label_ProxyDBManagerForm_Location
        // 
        this.label_ProxyDBManagerForm_Location.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ProxyDBManagerForm_Location.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ProxyDBManagerForm_Location.Location = new System.Drawing.Point(152, 224);
        this.label_ProxyDBManagerForm_Location.Name = "label_ProxyDBManagerForm_Location";
        this.label_ProxyDBManagerForm_Location.Size = new System.Drawing.Size(136, 16);
        this.label_ProxyDBManagerForm_Location.TabIndex = 63;
        this.label_ProxyDBManagerForm_Location.Text = "Location:";
        // 
        // label_ProxyDBManagerForm_Title
        // 
        this.label_ProxyDBManagerForm_Title.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ProxyDBManagerForm_Title.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ProxyDBManagerForm_Title.Location = new System.Drawing.Point(16, 224);
        this.label_ProxyDBManagerForm_Title.Name = "label_ProxyDBManagerForm_Title";
        this.label_ProxyDBManagerForm_Title.Size = new System.Drawing.Size(128, 16);
        this.label_ProxyDBManagerForm_Title.TabIndex = 62;
        this.label_ProxyDBManagerForm_Title.Text = "Title:";
        // 
        // textBox_ProxyDBManagerForm_Location
        // 
        this.textBox_ProxyDBManagerForm_Location.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.textBox_ProxyDBManagerForm_Location.Location = new System.Drawing.Point(152, 240);
        this.textBox_ProxyDBManagerForm_Location.Name = "textBox_ProxyDBManagerForm_Location";
        this.textBox_ProxyDBManagerForm_Location.Size = new System.Drawing.Size(136, 20);
        this.textBox_ProxyDBManagerForm_Location.TabIndex = 61;
        // 
        // textBox_ProxyDBManagerForm_Title
        // 
        this.textBox_ProxyDBManagerForm_Title.Location = new System.Drawing.Point(16, 240);
        this.textBox_ProxyDBManagerForm_Title.Name = "textBox_ProxyDBManagerForm_Title";
        this.textBox_ProxyDBManagerForm_Title.Size = new System.Drawing.Size(128, 20);
        this.textBox_ProxyDBManagerForm_Title.TabIndex = 60;
        // 
        // label_ProxyDBManagerForm_Description
        // 
        this.label_ProxyDBManagerForm_Description.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ProxyDBManagerForm_Description.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_ProxyDBManagerForm_Description.Location = new System.Drawing.Point(16, 272);
        this.label_ProxyDBManagerForm_Description.Name = "label_ProxyDBManagerForm_Description";
        this.label_ProxyDBManagerForm_Description.Size = new System.Drawing.Size(128, 16);
        this.label_ProxyDBManagerForm_Description.TabIndex = 65;
        this.label_ProxyDBManagerForm_Description.Text = "Description:";
        // 
        // button_ProxyDBManagerForm_AddToDB
        // 
        this.button_ProxyDBManagerForm_AddToDB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ProxyDBManagerForm_AddToDB.Location = new System.Drawing.Point(16, 392);
        this.button_ProxyDBManagerForm_AddToDB.Name = "button_ProxyDBManagerForm_AddToDB";
        this.button_ProxyDBManagerForm_AddToDB.Size = new System.Drawing.Size(80, 23);
        this.button_ProxyDBManagerForm_AddToDB.TabIndex = 67;
        this.button_ProxyDBManagerForm_AddToDB.Text = "Add";
        this.button_ProxyDBManagerForm_AddToDB.Click += new System.EventHandler(this.button_ProxyDBManagerForm_AddToDB_Click);
        // 
        // button_ProxyDBManagerForm_Cancel
        // 
        this.button_ProxyDBManagerForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ProxyDBManagerForm_Cancel.Location = new System.Drawing.Point(208, 392);
        this.button_ProxyDBManagerForm_Cancel.Name = "button_ProxyDBManagerForm_Cancel";
        this.button_ProxyDBManagerForm_Cancel.Size = new System.Drawing.Size(80, 23);
        this.button_ProxyDBManagerForm_Cancel.TabIndex = 68;
        this.button_ProxyDBManagerForm_Cancel.Text = "Cancel";
        this.button_ProxyDBManagerForm_Cancel.Click += new System.EventHandler(this.button_ProxyDBManagerForm_Cancel_Click);
        // 
        // textBox_ProxyDBManagerForm_Description
        // 
        this.textBox_ProxyDBManagerForm_Description.Location = new System.Drawing.Point(16, 288);
        this.textBox_ProxyDBManagerForm_Description.Multiline = true;
        this.textBox_ProxyDBManagerForm_Description.Name = "textBox_ProxyDBManagerForm_Description";
        this.textBox_ProxyDBManagerForm_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.textBox_ProxyDBManagerForm_Description.Size = new System.Drawing.Size(272, 88);
        this.textBox_ProxyDBManagerForm_Description.TabIndex = 70;
        // 
        // button_ProxyDBManagerForm_Apply
        // 
        this.button_ProxyDBManagerForm_Apply.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ProxyDBManagerForm_Apply.Location = new System.Drawing.Point(112, 392);
        this.button_ProxyDBManagerForm_Apply.Name = "button_ProxyDBManagerForm_Apply";
        this.button_ProxyDBManagerForm_Apply.Size = new System.Drawing.Size(80, 23);
        this.button_ProxyDBManagerForm_Apply.TabIndex = 71;
        this.button_ProxyDBManagerForm_Apply.Text = "Apply";
        this.button_ProxyDBManagerForm_Apply.Click += new System.EventHandler(this.button_ProxyDBManagerForm_Apply_Click);
        // 
        // ProxyDBManagerForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(304, 430);
        this.Controls.Add(this.button_ProxyDBManagerForm_Apply);
        this.Controls.Add(this.textBox_ProxyDBManagerForm_Description);
        this.Controls.Add(this.textBox_ProxyDBManagerForm_Location);
        this.Controls.Add(this.textBox_ProxyDBManagerForm_Title);
        this.Controls.Add(this.textBox_ProxyDBManagerForm_ProxyPort);
        this.Controls.Add(this.textBox_ProxyDBManagerForm_ProxyHost);
        this.Controls.Add(this.textBox_ProxyDBManagerForm_Socks5Password);
        this.Controls.Add(this.textBox_ProxyDBManagerForm_Socks5UserName);
        this.Controls.Add(this.button_ProxyDBManagerForm_Cancel);
        this.Controls.Add(this.button_ProxyDBManagerForm_AddToDB);
        this.Controls.Add(this.label_ProxyDBManagerForm_Description);
        this.Controls.Add(this.label_ProxyDBManagerForm_Location);
        this.Controls.Add(this.label_ProxyDBManagerForm_Title);
        this.Controls.Add(this.label_ProxyDBManagerForm_ProxyType);
        this.Controls.Add(this.checkBox_ProxyDBManagerForm_ResolveHostNames);
        this.Controls.Add(this.checkBox_ProxyDBManagerForm_Authentication);
        this.Controls.Add(this.label_ProxyDBManagerForm_ProxyTimeOut);
        this.Controls.Add(this.comboBox_ProxyDBManagerForm_ProxyTimeOut);
        this.Controls.Add(this.label_ProxyDBManagerForm_ProxyPort);
        this.Controls.Add(this.label_ProxyDBManagerForm_ProxyHost);
        this.Controls.Add(this.label_ProxyDBManagerForm_Socks5Password);
        this.Controls.Add(this.label_ProxyDBManagerForm_Socks5UserName);
        this.Controls.Add(this.listBox_ProxyDBManagerForm_ProxyType);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(310, 462);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(310, 462);
        this.Name = "ProxyDBManagerForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "New Proxy Server settings";
        this.Shown += new System.EventHandler(this.ProxyDBManagerForm_Shown);
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    #endregion

    void ChangeControlsLanguage()
    {
        this.Text = ClientStringFactory.GetString(381, ClientSettingsEnvironment.CurrentLanguage);

        this.label_ProxyDBManagerForm_ProxyType.Text = ClientStringFactory.GetString(384, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_ProxyDBManagerForm_ResolveHostNames.Text = ClientStringFactory.GetString(404, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_ProxyDBManagerForm_Authentication.Text = ClientStringFactory.GetString(383, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxyDBManagerForm_ProxyTimeOut.Text = ClientStringFactory.GetString(385, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxyDBManagerForm_ProxyPort.Text = ClientStringFactory.GetString(72, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxyDBManagerForm_ProxyHost.Text = ClientStringFactory.GetString(386, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxyDBManagerForm_Socks5Password.Text = ClientStringFactory.GetString(73, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxyDBManagerForm_Socks5UserName.Text = ClientStringFactory.GetString(405, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxyDBManagerForm_ProxyTimeOut.Text = ClientStringFactory.GetString(385, ClientSettingsEnvironment.CurrentLanguage);

        this.label_ProxyDBManagerForm_Location.Text = ClientStringFactory.GetString(487, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxyDBManagerForm_Title.Text = ClientStringFactory.GetString(547, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ProxyDBManagerForm_Description.Text = ClientStringFactory.GetString(314, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyDBManagerForm_AddToDB.Text = ClientStringFactory.GetString(311, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyDBManagerForm_Cancel.Text = ClientStringFactory.GetString(265, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ProxyDBManagerForm_Apply.Text = ClientStringFactory.GetString(307, ClientSettingsEnvironment.CurrentLanguage);

        this.listBox_ProxyDBManagerForm_ProxyType.Items.Clear();

        this.listBox_ProxyDBManagerForm_ProxyType.Items.AddRange(new object[] {
																				 ClientStringFactory.GetString(401, ClientSettingsEnvironment.CurrentLanguage),
																				 ClientStringFactory.GetString(402, ClientSettingsEnvironment.CurrentLanguage),
																				 ClientStringFactory.GetString(548, ClientSettingsEnvironment.CurrentLanguage),
			});


    }


    private void button_ProxyDBManagerForm_AddToDB_Click(object sender, System.EventArgs e)
    {
        if (ProxyPort == -1) return;

        DataRow dataRow_NewRecord = null;

        DataSet_Client_Ver110.DataSet_YakSysClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings;

        ////////////////////////////////////////////////////////////////////////////////

        dataRow_NewRecord = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings.NewRow();

        int int_ProxyServersSettingsID = 0;

        for (int int_CycleCount = 0; ; int_CycleCount++)
        {
            if (ProxyServersSettingsDataTable_obj.Rows.Count == 0) break;

            if (int_CycleCount >= ProxyServersSettingsDataTable_obj.Rows.Count
            || (int)ProxyServersSettingsDataTable_obj.Rows[int_CycleCount][ProxyServersSettingsDataTable_obj.IDColumn] == int_ProxyServersSettingsID)
            {
                int_ProxyServersSettingsID++;
                int_CycleCount = -1;
            }

            else if (int_CycleCount + 1 == ProxyServersSettingsDataTable_obj.Rows.Count) break;
        }

        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.IDColumn] = int_ProxyServersSettingsID;

        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyHostColumn] = this.textBox_ProxyDBManagerForm_ProxyHost.Text;
        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyPortColumn] = ProxyPort;
        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn] = (this.comboBox_ProxyDBManagerForm_ProxyTimeOut.SelectedIndex + 1) * 5000;
        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyTypeColumn] = this.listBox_ProxyDBManagerForm_ProxyType.SelectedIndex;
        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn] = this.checkBox_ProxyDBManagerForm_ResolveHostNames.Checked;
        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.UseAuthenticationColumn] = this.checkBox_ProxyDBManagerForm_Authentication.Checked;
        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.LoginColumn] = this.textBox_ProxyDBManagerForm_Socks5UserName.Text;
        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.PasswordColumn] = this.textBox_ProxyDBManagerForm_Socks5Password.Text;
        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyServerTitleColumn] = this.textBox_ProxyDBManagerForm_Title.Text;
        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyServerLocationColumn] = this.textBox_ProxyDBManagerForm_Location.Text;
        dataRow_NewRecord[ProxyServersSettingsDataTable_obj.ProxyServerDescriptionColumn] = this.textBox_ProxyDBManagerForm_Description.Text;

        YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings.Rows.Add(dataRow_NewRecord);

      //!!  ObjCopy.obj_MainClientForm.FillProxyServersList();

        this.Close();
    }

    private void button_ProxyDBManagerForm_Apply_Click(object sender, System.EventArgs e)
    {
        if (ProxyPort == -1) return;

        DataRow dataRow_EditedRecord = null;

        DataSet_Client_Ver110.DataSet_YakSysClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings;

        ////////////////////////////////////////////////////////////////////////////////

        dataRow_EditedRecord = YakSysRctClientV110XMLConfigImporter.YakSysClientDB.ProxyServersSettings[int_EditedRecordIndex + 1];

        dataRow_EditedRecord[ProxyServersSettingsDataTable_obj.ProxyHostColumn] = this.textBox_ProxyDBManagerForm_ProxyHost.Text;
        dataRow_EditedRecord[ProxyServersSettingsDataTable_obj.ProxyPortColumn] = ProxyPort;
        dataRow_EditedRecord[ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn] = (this.comboBox_ProxyDBManagerForm_ProxyTimeOut.SelectedIndex + 1) * 5000;
        dataRow_EditedRecord[ProxyServersSettingsDataTable_obj.ProxyTypeColumn] = this.listBox_ProxyDBManagerForm_ProxyType.SelectedIndex;
        dataRow_EditedRecord[ProxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn] = this.checkBox_ProxyDBManagerForm_ResolveHostNames.Checked;
        dataRow_EditedRecord[ProxyServersSettingsDataTable_obj.UseAuthenticationColumn] = this.checkBox_ProxyDBManagerForm_Authentication.Checked;
        dataRow_EditedRecord[ProxyServersSettingsDataTable_obj.LoginColumn] = this.textBox_ProxyDBManagerForm_Socks5UserName.Text;
        dataRow_EditedRecord[ProxyServersSettingsDataTable_obj.PasswordColumn] = this.textBox_ProxyDBManagerForm_Socks5Password.Text;
        dataRow_EditedRecord[ProxyServersSettingsDataTable_obj.ProxyServerTitleColumn] = this.textBox_ProxyDBManagerForm_Title.Text;
        dataRow_EditedRecord[ProxyServersSettingsDataTable_obj.ProxyServerLocationColumn] = this.textBox_ProxyDBManagerForm_Location.Text;
        dataRow_EditedRecord[ProxyServersSettingsDataTable_obj.ProxyServerDescriptionColumn] = this.textBox_ProxyDBManagerForm_Description.Text;

        ObjCopy.obj_MainClientForm.EditProxyServersListItem(int_EditedRecordIndex, this.textBox_ProxyDBManagerForm_Title.Text, this.textBox_ProxyDBManagerForm_ProxyHost.Text, this.textBox_ProxyDBManagerForm_ProxyPort.Text);

        this.Close();
    }

    private void button_ProxyDBManagerForm_Cancel_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }

    

    private void checkBox_ProxyDBManagerForm_Authentication_CheckedChanged(object sender, System.EventArgs e)
    {
        label_ProxyDBManagerForm_Socks5UserName.Enabled =
        label_ProxyDBManagerForm_Socks5Password.Enabled =
        textBox_ProxyDBManagerForm_Socks5UserName.Enabled =
        textBox_ProxyDBManagerForm_Socks5Password.Enabled =
        (checkBox_ProxyDBManagerForm_Authentication.Checked && checkBox_ProxyDBManagerForm_Authentication.Enabled);
    }

    private void listBox_ProxyDBManagerForm_ProxyType_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        bool bool_AuthEnabled = false;

        if (listBox_ProxyDBManagerForm_ProxyType.SelectedIndex == 0) bool_AuthEnabled = false;
        else bool_AuthEnabled = true;

        label_ProxyDBManagerForm_Socks5UserName.Enabled =
        label_ProxyDBManagerForm_Socks5Password.Enabled =
        textBox_ProxyDBManagerForm_Socks5UserName.Enabled =
        textBox_ProxyDBManagerForm_Socks5Password.Enabled =
        checkBox_ProxyDBManagerForm_Authentication.Enabled = bool_AuthEnabled;

        checkBox_ProxyDBManagerForm_Authentication_CheckedChanged(null, null);
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


    public Button ApplyButton
    {
        get
        {
            return this.button_ProxyDBManagerForm_Apply;
        }

        set
        {
            this.button_ProxyDBManagerForm_Apply = value;
        }
    }

    public Button CancelButton
    {
        get
        {
            return this.button_ProxyDBManagerForm_Cancel;
        }

        set
        {
            this.button_ProxyDBManagerForm_Cancel = value;
        }
    }

    public Button AddButton
    {
        get
        {
            return this.button_ProxyDBManagerForm_AddToDB;
        }

        set
        {
            this.button_ProxyDBManagerForm_AddToDB = value;
        }
    }


    public ListBox ProxyTypeList
    {
        get
        {
            return this.listBox_ProxyDBManagerForm_ProxyType;
        }

        set
        {
            this.listBox_ProxyDBManagerForm_ProxyType = value;
        }
    }

    public TextBox HostTextBox
    {
        get
        {
            return this.textBox_ProxyDBManagerForm_ProxyHost;
        }

        set
        {
            this.textBox_ProxyDBManagerForm_ProxyHost = value;
        }
    }

    public TextBox PortTextBox
    {
        get
        {
            return this.textBox_ProxyDBManagerForm_ProxyPort;
        }

        set
        {
            this.textBox_ProxyDBManagerForm_ProxyPort = value;
        }
    }

    public ComboBox TimeOutComboBox
    {
        get
        {
            return this.comboBox_ProxyDBManagerForm_ProxyTimeOut;
        }

        set
        {
            this.comboBox_ProxyDBManagerForm_ProxyTimeOut = value;
        }
    }


    public CheckBox AuthenticationCheckBox
    {
        get
        {
            return this.checkBox_ProxyDBManagerForm_Authentication;
        }

        set
        {
            this.checkBox_ProxyDBManagerForm_Authentication = value;
        }
    }

    public CheckBox ResolveHostnamesCheckBox
    {
        get
        {
            return this.checkBox_ProxyDBManagerForm_ResolveHostNames;
        }

        set
        {
            this.checkBox_ProxyDBManagerForm_ResolveHostNames = value;
        }
    }

    public TextBox LoginTextBox
    {
        get
        {
            return this.textBox_ProxyDBManagerForm_Socks5UserName;
        }

        set
        {
            this.textBox_ProxyDBManagerForm_Socks5UserName = value;
        }
    }

    public TextBox PasswordTextBox
    {
        get
        {
            return this.textBox_ProxyDBManagerForm_Socks5Password;
        }

        set
        {
            this.textBox_ProxyDBManagerForm_Socks5Password = value;
        }
    }

    public TextBox TitleTextBox
    {
        get
        {
            return this.textBox_ProxyDBManagerForm_Title;
        }

        set
        {
            this.textBox_ProxyDBManagerForm_Title = value;
        }
    }
   
    public TextBox LocationTextBox
    {
        get
        {
            return this.textBox_ProxyDBManagerForm_Location;
        }

        set
        {
            this.textBox_ProxyDBManagerForm_Location = value;
        }
    }

    public TextBox DescriptionTextBox
    {
        get
        {
            return this.textBox_ProxyDBManagerForm_Description;
        }

        set
        {
            this.textBox_ProxyDBManagerForm_Description = value;
        }
    }
    
    public int ProxyPort
    {
        get
        {
            try
            {
                if (Convert.ToInt32(this.textBox_ProxyDBManagerForm_ProxyPort.Text) > 65535 || Convert.ToInt32(this.textBox_ProxyDBManagerForm_ProxyPort.Text) < 1)
                {
                    MessageBox.Show(ClientStringFactory.GetString(444, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);
                    return -1;
                }

                return int.Parse(this.textBox_ProxyDBManagerForm_ProxyPort.Text);
            }

            catch (FormatException)
            {
                MessageBox.Show(ClientStringFactory.GetString(444, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK);
                return -1;
            }
        }

        set
        {
            this.textBox_ProxyDBManagerForm_ProxyPort.Text = value.ToString();
        }
    }

    private void ProxyDBManagerForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }
    */
}

