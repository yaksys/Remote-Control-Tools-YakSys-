using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;

public class SettingsForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.Button button_SettingsForm_OK;
	private System.Windows.Forms.CheckBox checkBox_SettingsForm_AutoRun;
	private System.Windows.Forms.Button button_SettingsForm_Cancel;
	private System.Windows.Forms.Button button_RestoreToDefaults;
	private System.Windows.Forms.GroupBox groupBox_SettingsForm_Language;
	private System.Windows.Forms.Label label_SettingsForm_SelectLanguage;
	private System.Windows.Forms.ComboBox comboBox_SettingsForm_Language;
	private System.Windows.Forms.GroupBox groupBox_LocalSecurity_SecurityParameters;
	private System.Windows.Forms.CheckBox checkBox_LocalSecurity_CompressSettingsDatabase;
	private System.Windows.Forms.CheckBox checkBox_LocalSecurity_EncryptSettingsDatabase;
	private System.Windows.Forms.GroupBox groupBox_LocalSecurity_UsedPassword;
	private System.Windows.Forms.Button button_LocalSecurity_SetPassword;
	private System.Windows.Forms.Button button_LocalSecurity_NewPassword;
	private System.Windows.Forms.Label label_LocalSecurity_NewPassword;
	private System.Windows.Forms.TextBox textBox_LocalSecurity_ConfirmedPassword;
	private System.Windows.Forms.TextBox textBox_LocalSecurity_NewPassword;
	private System.Windows.Forms.Label label_LocalSecurity_ConfirmedPassword;
	private System.Windows.Forms.CheckBox checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart;
	private System.Windows.Forms.CheckBox checkBox_SettingsForm_StartServerAtRun;
	private System.Windows.Forms.GroupBox groupBox_SettingsForm_StartUpParameters;
	private System.Windows.Forms.CheckBox checkBox_SettingsForm_ActivateHiddenMode;
    private GroupBox groupBoxSettingsForm_SendingMailSettings;
    private TextBox textBox_SendingMailSettings_SMTPPassword;
    private TextBox textBox_SendingMailSettings_SMTPLogin;
    private TextBox textBox_SendingMailSettings_MailAddress;
    private TextBox textBox_SendingMailSettings_SMTPServer;
    private TextBox textBox_SendingMailSettings_SMTPPort;
    private Label label_SendingMailSettings_SMTPPort;
    private Label label_SendingMailSettings_SMTPServer;
    private Label label_SendingMailSettings_MailAddress;
    private Label label_SendingMailSettings_SMTPLogin;
    private Label label_SendingMailSettings_SMTPPassword;
	
	private System.ComponentModel.Container components = null;
	
	void ChangeControlsLanguage()
	{	
		this.Text = ServerStringFactory.GetString(65, MainForm.CurrentLanguage);
		
		this.groupBox_SettingsForm_Language.Text = ServerStringFactory.GetString(66, MainForm.CurrentLanguage);
	
		this.label_SettingsForm_SelectLanguage.Text = ServerStringFactory.GetString(118, MainForm.CurrentLanguage);
	
		this.comboBox_SettingsForm_Language.SelectedIndex = MainForm.CurrentLanguage;

		this.checkBox_SettingsForm_AutoRun.Text = ServerStringFactory.GetString(73, MainForm.CurrentLanguage);
		
		this.checkBox_SettingsForm_StartServerAtRun.Text = ServerStringFactory.GetString(71, MainForm.CurrentLanguage);
		
		this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Text = ServerStringFactory.GetString(72, MainForm.CurrentLanguage);
	

		this.groupBox_SettingsForm_StartUpParameters.Text = ServerStringFactory.GetString(218, MainForm.CurrentLanguage);
	 
	
		this.groupBox_LocalSecurity_SecurityParameters.Text = ServerStringFactory.GetString(107, MainForm.CurrentLanguage);
		this.groupBox_LocalSecurity_UsedPassword.Text = ServerStringFactory.GetString(106, MainForm.CurrentLanguage);	
			
		this.label_LocalSecurity_NewPassword.Text = ServerStringFactory.GetString(104, MainForm.CurrentLanguage);		
		this.label_LocalSecurity_ConfirmedPassword.Text = ServerStringFactory.GetString(105, MainForm.CurrentLanguage);

		this.button_LocalSecurity_NewPassword.Text = ServerStringFactory.GetString(102, MainForm.CurrentLanguage);
		this.button_LocalSecurity_SetPassword.Text = ServerStringFactory.GetString(103, MainForm.CurrentLanguage);

		this.checkBox_LocalSecurity_CompressSettingsDatabase.Text = ServerStringFactory.GetString(101, MainForm.CurrentLanguage);		
		this.checkBox_LocalSecurity_EncryptSettingsDatabase.Text = ServerStringFactory.GetString(100, MainForm.CurrentLanguage);

		this.button_RestoreToDefaults.Text = ServerStringFactory.GetString(108, MainForm.CurrentLanguage);

		this.button_SettingsForm_Cancel.Text = ServerStringFactory.GetString(86, MainForm.CurrentLanguage);

		this.checkBox_SettingsForm_ActivateHiddenMode.Text = ServerStringFactory.GetString(114, MainForm.CurrentLanguage);
	}

		
	public SettingsForm()
	{
		InitializeComponent();

		ChangeControlsLanguage();	

		this.checkBox_SettingsForm_AutoRun.Checked = CommonEnvironment.AutoRun;
		
		this.checkBox_SettingsForm_StartServerAtRun.Checked = CommonEnvironment.StartServerAtRun;
		
		this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Checked = CommonEnvironment.MinimizeToNotifyAreaAtRun;
	
		this.checkBox_SettingsForm_ActivateHiddenMode.Checked = CommonEnvironment.ActivateHiddenModeAtStartUp;

		this.checkBox_LocalSecurity_CompressSettingsDatabase.Checked = CommonEnvironment.CompressSettingsDataBase;		
		this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked = CommonEnvironment.EncryptSettingsDataBase;
		
		this.textBox_LocalSecurity_NewPassword.Text = this.textBox_LocalSecurity_ConfirmedPassword.Text = CommonEnvironment.LocalSecurityPassword;

		if(this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked == false)
		{
			this.groupBox_LocalSecurity_UsedPassword.Enabled = false;

			this.textBox_LocalSecurity_NewPassword.Text = this.textBox_LocalSecurity_ConfirmedPassword.Text = "";
		}

		this.checkBox_LocalSecurity_EncryptSettingsDatabase_CheckedChanged(null, null);

        this.textBox_SendingMailSettings_SMTPPort.Text = CommonEnvironment.SMTPPort.ToString();
       
        this.textBox_SendingMailSettings_SMTPLogin.Text = CommonEnvironment.SMTPLogin;        
        this.textBox_SendingMailSettings_SMTPPassword.Text = CommonEnvironment.SMTPPassword;
        
        this.textBox_SendingMailSettings_SMTPServer.Text = CommonEnvironment.SMTPServer;        
        this.textBox_SendingMailSettings_MailAddress.Text = CommonEnvironment.SenderMailAddress;
	}

		
	protected override void Dispose( bool disposing )
	{
		if(disposing )
		{
			if(components != null)
			{
				components.Dispose();
			}
		}
		base.Dispose( disposing );
	}

		
	#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.button_SettingsForm_OK = new System.Windows.Forms.Button();
            this.checkBox_SettingsForm_AutoRun = new System.Windows.Forms.CheckBox();
            this.checkBox_SettingsForm_StartServerAtRun = new System.Windows.Forms.CheckBox();
            this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart = new System.Windows.Forms.CheckBox();
            this.button_SettingsForm_Cancel = new System.Windows.Forms.Button();
            this.groupBox_SettingsForm_Language = new System.Windows.Forms.GroupBox();
            this.label_SettingsForm_SelectLanguage = new System.Windows.Forms.Label();
            this.comboBox_SettingsForm_Language = new System.Windows.Forms.ComboBox();
            this.groupBox_LocalSecurity_SecurityParameters = new System.Windows.Forms.GroupBox();
            this.checkBox_LocalSecurity_CompressSettingsDatabase = new System.Windows.Forms.CheckBox();
            this.checkBox_LocalSecurity_EncryptSettingsDatabase = new System.Windows.Forms.CheckBox();
            this.groupBox_LocalSecurity_UsedPassword = new System.Windows.Forms.GroupBox();
            this.button_LocalSecurity_SetPassword = new System.Windows.Forms.Button();
            this.button_LocalSecurity_NewPassword = new System.Windows.Forms.Button();
            this.label_LocalSecurity_NewPassword = new System.Windows.Forms.Label();
            this.textBox_LocalSecurity_ConfirmedPassword = new System.Windows.Forms.TextBox();
            this.textBox_LocalSecurity_NewPassword = new System.Windows.Forms.TextBox();
            this.label_LocalSecurity_ConfirmedPassword = new System.Windows.Forms.Label();
            this.button_RestoreToDefaults = new System.Windows.Forms.Button();
            this.groupBox_SettingsForm_StartUpParameters = new System.Windows.Forms.GroupBox();
            this.checkBox_SettingsForm_ActivateHiddenMode = new System.Windows.Forms.CheckBox();
            this.groupBoxSettingsForm_SendingMailSettings = new System.Windows.Forms.GroupBox();
            this.label_SendingMailSettings_SMTPPort = new System.Windows.Forms.Label();
            this.label_SendingMailSettings_SMTPServer = new System.Windows.Forms.Label();
            this.label_SendingMailSettings_MailAddress = new System.Windows.Forms.Label();
            this.label_SendingMailSettings_SMTPLogin = new System.Windows.Forms.Label();
            this.label_SendingMailSettings_SMTPPassword = new System.Windows.Forms.Label();
            this.textBox_SendingMailSettings_SMTPPort = new System.Windows.Forms.TextBox();
            this.textBox_SendingMailSettings_SMTPPassword = new System.Windows.Forms.TextBox();
            this.textBox_SendingMailSettings_SMTPLogin = new System.Windows.Forms.TextBox();
            this.textBox_SendingMailSettings_MailAddress = new System.Windows.Forms.TextBox();
            this.textBox_SendingMailSettings_SMTPServer = new System.Windows.Forms.TextBox();
            this.groupBox_SettingsForm_Language.SuspendLayout();
            this.groupBox_LocalSecurity_SecurityParameters.SuspendLayout();
            this.groupBox_LocalSecurity_UsedPassword.SuspendLayout();
            this.groupBox_SettingsForm_StartUpParameters.SuspendLayout();
            this.groupBoxSettingsForm_SendingMailSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_SettingsForm_OK
            // 
            this.button_SettingsForm_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_SettingsForm_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SettingsForm_OK.Location = new System.Drawing.Point(264, 248);
            this.button_SettingsForm_OK.Name = "button_SettingsForm_OK";
            this.button_SettingsForm_OK.Size = new System.Drawing.Size(88, 23);
            this.button_SettingsForm_OK.TabIndex = 6;
            this.button_SettingsForm_OK.Text = "OK";
            this.button_SettingsForm_OK.Click += new System.EventHandler(this.button_SettingsForm_OK_Click);
            // 
            // checkBox_SettingsForm_AutoRun
            // 
            this.checkBox_SettingsForm_AutoRun.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_SettingsForm_AutoRun.Location = new System.Drawing.Point(16, 24);
            this.checkBox_SettingsForm_AutoRun.Name = "checkBox_SettingsForm_AutoRun";
            this.checkBox_SettingsForm_AutoRun.Size = new System.Drawing.Size(208, 16);
            this.checkBox_SettingsForm_AutoRun.TabIndex = 0;
            this.checkBox_SettingsForm_AutoRun.Text = "Auto run with Windows";
            // 
            // checkBox_SettingsForm_StartServerAtRun
            // 
            this.checkBox_SettingsForm_StartServerAtRun.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_SettingsForm_StartServerAtRun.Location = new System.Drawing.Point(16, 48);
            this.checkBox_SettingsForm_StartServerAtRun.Name = "checkBox_SettingsForm_StartServerAtRun";
            this.checkBox_SettingsForm_StartServerAtRun.Size = new System.Drawing.Size(208, 16);
            this.checkBox_SettingsForm_StartServerAtRun.TabIndex = 1;
            this.checkBox_SettingsForm_StartServerAtRun.Text = "Auto start Server";
            // 
            // checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart
            // 
            this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Location = new System.Drawing.Point(16, 72);
            this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Name = "checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart";
            this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Size = new System.Drawing.Size(208, 16);
            this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.TabIndex = 2;
            this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Text = "Minimize to Notify Area";
            // 
            // button_SettingsForm_Cancel
            // 
            this.button_SettingsForm_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_SettingsForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SettingsForm_Cancel.Location = new System.Drawing.Point(368, 248);
            this.button_SettingsForm_Cancel.Name = "button_SettingsForm_Cancel";
            this.button_SettingsForm_Cancel.Size = new System.Drawing.Size(88, 23);
            this.button_SettingsForm_Cancel.TabIndex = 7;
            this.button_SettingsForm_Cancel.Text = "Cancel";
            // 
            // groupBox_SettingsForm_Language
            // 
            this.groupBox_SettingsForm_Language.Controls.Add(this.label_SettingsForm_SelectLanguage);
            this.groupBox_SettingsForm_Language.Controls.Add(this.comboBox_SettingsForm_Language);
            this.groupBox_SettingsForm_Language.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_SettingsForm_Language.Location = new System.Drawing.Point(248, 176);
            this.groupBox_SettingsForm_Language.Name = "groupBox_SettingsForm_Language";
            this.groupBox_SettingsForm_Language.Size = new System.Drawing.Size(224, 56);
            this.groupBox_SettingsForm_Language.TabIndex = 9;
            this.groupBox_SettingsForm_Language.TabStop = false;
            // 
            // label_SettingsForm_SelectLanguage
            // 
            this.label_SettingsForm_SelectLanguage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_SettingsForm_SelectLanguage.Location = new System.Drawing.Point(2, 32);
            this.label_SettingsForm_SelectLanguage.Name = "label_SettingsForm_SelectLanguage";
            this.label_SettingsForm_SelectLanguage.Size = new System.Drawing.Size(95, 16);
            this.label_SettingsForm_SelectLanguage.TabIndex = 1;
            this.label_SettingsForm_SelectLanguage.Text = "Current language:";
            this.label_SettingsForm_SelectLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBox_SettingsForm_Language
            // 
            this.comboBox_SettingsForm_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SettingsForm_Language.Items.AddRange(new object[] {
            "English",
            "Russian"});
            this.comboBox_SettingsForm_Language.Location = new System.Drawing.Point(100, 24);
            this.comboBox_SettingsForm_Language.Name = "comboBox_SettingsForm_Language";
            this.comboBox_SettingsForm_Language.Size = new System.Drawing.Size(108, 21);
            this.comboBox_SettingsForm_Language.Sorted = true;
            this.comboBox_SettingsForm_Language.TabIndex = 4;
            this.comboBox_SettingsForm_Language.SelectedIndexChanged += new System.EventHandler(this.comboBox_SettingsForm_Language_SelectedIndexChanged);
            // 
            // groupBox_LocalSecurity_SecurityParameters
            // 
            this.groupBox_LocalSecurity_SecurityParameters.Controls.Add(this.checkBox_LocalSecurity_CompressSettingsDatabase);
            this.groupBox_LocalSecurity_SecurityParameters.Controls.Add(this.checkBox_LocalSecurity_EncryptSettingsDatabase);
            this.groupBox_LocalSecurity_SecurityParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_LocalSecurity_SecurityParameters.Location = new System.Drawing.Point(8, 8);
            this.groupBox_LocalSecurity_SecurityParameters.Name = "groupBox_LocalSecurity_SecurityParameters";
            this.groupBox_LocalSecurity_SecurityParameters.Size = new System.Drawing.Size(232, 96);
            this.groupBox_LocalSecurity_SecurityParameters.TabIndex = 8;
            this.groupBox_LocalSecurity_SecurityParameters.TabStop = false;
            this.groupBox_LocalSecurity_SecurityParameters.Text = "Security Parameters";
            // 
            // checkBox_LocalSecurity_CompressSettingsDatabase
            // 
            this.checkBox_LocalSecurity_CompressSettingsDatabase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_LocalSecurity_CompressSettingsDatabase.Location = new System.Drawing.Point(16, 56);
            this.checkBox_LocalSecurity_CompressSettingsDatabase.Name = "checkBox_LocalSecurity_CompressSettingsDatabase";
            this.checkBox_LocalSecurity_CompressSettingsDatabase.Size = new System.Drawing.Size(208, 24);
            this.checkBox_LocalSecurity_CompressSettingsDatabase.TabIndex = 1;
            this.checkBox_LocalSecurity_CompressSettingsDatabase.Text = "Compress Settings Database";
            // 
            // checkBox_LocalSecurity_EncryptSettingsDatabase
            // 
            this.checkBox_LocalSecurity_EncryptSettingsDatabase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_LocalSecurity_EncryptSettingsDatabase.Location = new System.Drawing.Point(16, 24);
            this.checkBox_LocalSecurity_EncryptSettingsDatabase.Name = "checkBox_LocalSecurity_EncryptSettingsDatabase";
            this.checkBox_LocalSecurity_EncryptSettingsDatabase.Size = new System.Drawing.Size(208, 24);
            this.checkBox_LocalSecurity_EncryptSettingsDatabase.TabIndex = 0;
            this.checkBox_LocalSecurity_EncryptSettingsDatabase.Text = "Encrypt Settings Database";
            this.checkBox_LocalSecurity_EncryptSettingsDatabase.CheckedChanged += new System.EventHandler(this.checkBox_LocalSecurity_EncryptSettingsDatabase_CheckedChanged);
            // 
            // groupBox_LocalSecurity_UsedPassword
            // 
            this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.button_LocalSecurity_SetPassword);
            this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.button_LocalSecurity_NewPassword);
            this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.label_LocalSecurity_NewPassword);
            this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.textBox_LocalSecurity_ConfirmedPassword);
            this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.textBox_LocalSecurity_NewPassword);
            this.groupBox_LocalSecurity_UsedPassword.Controls.Add(this.label_LocalSecurity_ConfirmedPassword);
            this.groupBox_LocalSecurity_UsedPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_LocalSecurity_UsedPassword.Location = new System.Drawing.Point(248, 8);
            this.groupBox_LocalSecurity_UsedPassword.Name = "groupBox_LocalSecurity_UsedPassword";
            this.groupBox_LocalSecurity_UsedPassword.Size = new System.Drawing.Size(224, 160);
            this.groupBox_LocalSecurity_UsedPassword.TabIndex = 7;
            this.groupBox_LocalSecurity_UsedPassword.TabStop = false;
            this.groupBox_LocalSecurity_UsedPassword.Text = "Password";
            // 
            // button_LocalSecurity_SetPassword
            // 
            this.button_LocalSecurity_SetPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_LocalSecurity_SetPassword.Location = new System.Drawing.Point(120, 120);
            this.button_LocalSecurity_SetPassword.Name = "button_LocalSecurity_SetPassword";
            this.button_LocalSecurity_SetPassword.Size = new System.Drawing.Size(88, 23);
            this.button_LocalSecurity_SetPassword.TabIndex = 5;
            this.button_LocalSecurity_SetPassword.Text = "Set";
            this.button_LocalSecurity_SetPassword.Click += new System.EventHandler(this.button_LocalSecurity_SetPassword_Click);
            // 
            // button_LocalSecurity_NewPassword
            // 
            this.button_LocalSecurity_NewPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_LocalSecurity_NewPassword.Location = new System.Drawing.Point(16, 120);
            this.button_LocalSecurity_NewPassword.Name = "button_LocalSecurity_NewPassword";
            this.button_LocalSecurity_NewPassword.Size = new System.Drawing.Size(88, 23);
            this.button_LocalSecurity_NewPassword.TabIndex = 4;
            this.button_LocalSecurity_NewPassword.Text = "New";
            this.button_LocalSecurity_NewPassword.Click += new System.EventHandler(this.button_LocalSecurity_NewPassword_Click);
            // 
            // label_LocalSecurity_NewPassword
            // 
            this.label_LocalSecurity_NewPassword.Location = new System.Drawing.Point(16, 24);
            this.label_LocalSecurity_NewPassword.Name = "label_LocalSecurity_NewPassword";
            this.label_LocalSecurity_NewPassword.Size = new System.Drawing.Size(192, 16);
            this.label_LocalSecurity_NewPassword.TabIndex = 3;
            this.label_LocalSecurity_NewPassword.Text = "New Password:";
            // 
            // textBox_LocalSecurity_ConfirmedPassword
            // 
            this.textBox_LocalSecurity_ConfirmedPassword.Location = new System.Drawing.Point(16, 88);
            this.textBox_LocalSecurity_ConfirmedPassword.MaxLength = 64;
            this.textBox_LocalSecurity_ConfirmedPassword.Name = "textBox_LocalSecurity_ConfirmedPassword";
            this.textBox_LocalSecurity_ConfirmedPassword.PasswordChar = '*';
            this.textBox_LocalSecurity_ConfirmedPassword.Size = new System.Drawing.Size(192, 20);
            this.textBox_LocalSecurity_ConfirmedPassword.TabIndex = 3;
            // 
            // textBox_LocalSecurity_NewPassword
            // 
            this.textBox_LocalSecurity_NewPassword.Location = new System.Drawing.Point(16, 40);
            this.textBox_LocalSecurity_NewPassword.MaxLength = 64;
            this.textBox_LocalSecurity_NewPassword.Name = "textBox_LocalSecurity_NewPassword";
            this.textBox_LocalSecurity_NewPassword.PasswordChar = '*';
            this.textBox_LocalSecurity_NewPassword.Size = new System.Drawing.Size(192, 20);
            this.textBox_LocalSecurity_NewPassword.TabIndex = 2;
            // 
            // label_LocalSecurity_ConfirmedPassword
            // 
            this.label_LocalSecurity_ConfirmedPassword.Location = new System.Drawing.Point(16, 72);
            this.label_LocalSecurity_ConfirmedPassword.Name = "label_LocalSecurity_ConfirmedPassword";
            this.label_LocalSecurity_ConfirmedPassword.Size = new System.Drawing.Size(192, 16);
            this.label_LocalSecurity_ConfirmedPassword.TabIndex = 4;
            this.label_LocalSecurity_ConfirmedPassword.Text = "Retyped Password:";
            // 
            // button_RestoreToDefaults
            // 
            this.button_RestoreToDefaults.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RestoreToDefaults.Location = new System.Drawing.Point(24, 248);
            this.button_RestoreToDefaults.Name = "button_RestoreToDefaults";
            this.button_RestoreToDefaults.Size = new System.Drawing.Size(112, 23);
            this.button_RestoreToDefaults.TabIndex = 5;
            this.button_RestoreToDefaults.Text = "Restore to defaults";
            this.button_RestoreToDefaults.Click += new System.EventHandler(this.button_RestoreToDefaults_Click);
            // 
            // groupBox_SettingsForm_StartUpParameters
            // 
            this.groupBox_SettingsForm_StartUpParameters.Controls.Add(this.checkBox_SettingsForm_ActivateHiddenMode);
            this.groupBox_SettingsForm_StartUpParameters.Controls.Add(this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart);
            this.groupBox_SettingsForm_StartUpParameters.Controls.Add(this.checkBox_SettingsForm_StartServerAtRun);
            this.groupBox_SettingsForm_StartUpParameters.Controls.Add(this.checkBox_SettingsForm_AutoRun);
            this.groupBox_SettingsForm_StartUpParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_SettingsForm_StartUpParameters.Location = new System.Drawing.Point(8, 112);
            this.groupBox_SettingsForm_StartUpParameters.Name = "groupBox_SettingsForm_StartUpParameters";
            this.groupBox_SettingsForm_StartUpParameters.Size = new System.Drawing.Size(232, 120);
            this.groupBox_SettingsForm_StartUpParameters.TabIndex = 10;
            this.groupBox_SettingsForm_StartUpParameters.TabStop = false;
            this.groupBox_SettingsForm_StartUpParameters.Text = "StartUp Parameters";
            // 
            // checkBox_SettingsForm_ActivateHiddenMode
            // 
            this.checkBox_SettingsForm_ActivateHiddenMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_SettingsForm_ActivateHiddenMode.Location = new System.Drawing.Point(16, 96);
            this.checkBox_SettingsForm_ActivateHiddenMode.Name = "checkBox_SettingsForm_ActivateHiddenMode";
            this.checkBox_SettingsForm_ActivateHiddenMode.Size = new System.Drawing.Size(208, 16);
            this.checkBox_SettingsForm_ActivateHiddenMode.TabIndex = 3;
            this.checkBox_SettingsForm_ActivateHiddenMode.Text = "Activate Hidden Mode";
            // 
            // groupBoxSettingsForm_SendingMailSettings
            // 
            this.groupBoxSettingsForm_SendingMailSettings.Controls.Add(this.label_SendingMailSettings_SMTPPort);
            this.groupBoxSettingsForm_SendingMailSettings.Controls.Add(this.label_SendingMailSettings_SMTPServer);
            this.groupBoxSettingsForm_SendingMailSettings.Controls.Add(this.label_SendingMailSettings_MailAddress);
            this.groupBoxSettingsForm_SendingMailSettings.Controls.Add(this.label_SendingMailSettings_SMTPLogin);
            this.groupBoxSettingsForm_SendingMailSettings.Controls.Add(this.label_SendingMailSettings_SMTPPassword);
            this.groupBoxSettingsForm_SendingMailSettings.Controls.Add(this.textBox_SendingMailSettings_SMTPPort);
            this.groupBoxSettingsForm_SendingMailSettings.Controls.Add(this.textBox_SendingMailSettings_SMTPPassword);
            this.groupBoxSettingsForm_SendingMailSettings.Controls.Add(this.textBox_SendingMailSettings_SMTPLogin);
            this.groupBoxSettingsForm_SendingMailSettings.Controls.Add(this.textBox_SendingMailSettings_MailAddress);
            this.groupBoxSettingsForm_SendingMailSettings.Controls.Add(this.textBox_SendingMailSettings_SMTPServer);
            this.groupBoxSettingsForm_SendingMailSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxSettingsForm_SendingMailSettings.Location = new System.Drawing.Point(478, 8);
            this.groupBoxSettingsForm_SendingMailSettings.Name = "groupBoxSettingsForm_SendingMailSettings";
            this.groupBoxSettingsForm_SendingMailSettings.Size = new System.Drawing.Size(183, 263);
            this.groupBoxSettingsForm_SendingMailSettings.TabIndex = 11;
            this.groupBoxSettingsForm_SendingMailSettings.TabStop = false;
            this.groupBoxSettingsForm_SendingMailSettings.Text = "Sending Mail Settings";
            // 
            // label_SendingMailSettings_SMTPPort
            // 
            this.label_SendingMailSettings_SMTPPort.Location = new System.Drawing.Point(14, 74);
            this.label_SendingMailSettings_SMTPPort.Name = "label_SendingMailSettings_SMTPPort";
            this.label_SendingMailSettings_SMTPPort.Size = new System.Drawing.Size(67, 13);
            this.label_SendingMailSettings_SMTPPort.TabIndex = 12;
            this.label_SendingMailSettings_SMTPPort.Text = "SMTP Port:";
            // 
            // label_SendingMailSettings_SMTPServer
            // 
            this.label_SendingMailSettings_SMTPServer.Location = new System.Drawing.Point(14, 25);
            this.label_SendingMailSettings_SMTPServer.Name = "label_SendingMailSettings_SMTPServer";
            this.label_SendingMailSettings_SMTPServer.Size = new System.Drawing.Size(150, 14);
            this.label_SendingMailSettings_SMTPServer.TabIndex = 11;
            this.label_SendingMailSettings_SMTPServer.Text = "SMTP Server:";
            // 
            // label_SendingMailSettings_MailAddress
            // 
            this.label_SendingMailSettings_MailAddress.Location = new System.Drawing.Point(14, 118);
            this.label_SendingMailSettings_MailAddress.Name = "label_SendingMailSettings_MailAddress";
            this.label_SendingMailSettings_MailAddress.Size = new System.Drawing.Size(150, 11);
            this.label_SendingMailSettings_MailAddress.TabIndex = 10;
            this.label_SendingMailSettings_MailAddress.Text = "Sender E-Mail Address:";
            // 
            // label_SendingMailSettings_SMTPLogin
            // 
            this.label_SendingMailSettings_SMTPLogin.Location = new System.Drawing.Point(14, 164);
            this.label_SendingMailSettings_SMTPLogin.Name = "label_SendingMailSettings_SMTPLogin";
            this.label_SendingMailSettings_SMTPLogin.Size = new System.Drawing.Size(150, 13);
            this.label_SendingMailSettings_SMTPLogin.TabIndex = 9;
            this.label_SendingMailSettings_SMTPLogin.Text = "login:";
            // 
            // label_SendingMailSettings_SMTPPassword
            // 
            this.label_SendingMailSettings_SMTPPassword.Location = new System.Drawing.Point(14, 209);
            this.label_SendingMailSettings_SMTPPassword.Name = "label_SendingMailSettings_SMTPPassword";
            this.label_SendingMailSettings_SMTPPassword.Size = new System.Drawing.Size(150, 12);
            this.label_SendingMailSettings_SMTPPassword.TabIndex = 8;
            this.label_SendingMailSettings_SMTPPassword.Text = "Password:";
            // 
            // textBox_SendingMailSettings_SMTPPort
            // 
            this.textBox_SendingMailSettings_SMTPPort.Location = new System.Drawing.Point(17, 88);
            this.textBox_SendingMailSettings_SMTPPort.MaxLength = 64;
            this.textBox_SendingMailSettings_SMTPPort.Name = "textBox_SendingMailSettings_SMTPPort";
            this.textBox_SendingMailSettings_SMTPPort.Size = new System.Drawing.Size(61, 20);
            this.textBox_SendingMailSettings_SMTPPort.TabIndex = 7;
            this.textBox_SendingMailSettings_SMTPPort.Text = "25";
            // 
            // textBox_SendingMailSettings_SMTPPassword
            // 
            this.textBox_SendingMailSettings_SMTPPassword.Location = new System.Drawing.Point(17, 226);
            this.textBox_SendingMailSettings_SMTPPassword.MaxLength = 64;
            this.textBox_SendingMailSettings_SMTPPassword.Name = "textBox_SendingMailSettings_SMTPPassword";
            this.textBox_SendingMailSettings_SMTPPassword.PasswordChar = '*';
            this.textBox_SendingMailSettings_SMTPPassword.Size = new System.Drawing.Size(147, 20);
            this.textBox_SendingMailSettings_SMTPPassword.TabIndex = 6;
            // 
            // textBox_SendingMailSettings_SMTPLogin
            // 
            this.textBox_SendingMailSettings_SMTPLogin.Location = new System.Drawing.Point(17, 180);
            this.textBox_SendingMailSettings_SMTPLogin.MaxLength = 64;
            this.textBox_SendingMailSettings_SMTPLogin.Name = "textBox_SendingMailSettings_SMTPLogin";
            this.textBox_SendingMailSettings_SMTPLogin.Size = new System.Drawing.Size(147, 20);
            this.textBox_SendingMailSettings_SMTPLogin.TabIndex = 5;
            // 
            // textBox_SendingMailSettings_MailAddress
            // 
            this.textBox_SendingMailSettings_MailAddress.Location = new System.Drawing.Point(17, 134);
            this.textBox_SendingMailSettings_MailAddress.MaxLength = 64;
            this.textBox_SendingMailSettings_MailAddress.Name = "textBox_SendingMailSettings_MailAddress";
            this.textBox_SendingMailSettings_MailAddress.Size = new System.Drawing.Size(147, 20);
            this.textBox_SendingMailSettings_MailAddress.TabIndex = 3;
            // 
            // textBox_SendingMailSettings_SMTPServer
            // 
            this.textBox_SendingMailSettings_SMTPServer.Location = new System.Drawing.Point(17, 40);
            this.textBox_SendingMailSettings_SMTPServer.MaxLength = 64;
            this.textBox_SendingMailSettings_SMTPServer.Name = "textBox_SendingMailSettings_SMTPServer";
            this.textBox_SendingMailSettings_SMTPServer.Size = new System.Drawing.Size(147, 20);
            this.textBox_SendingMailSettings_SMTPServer.TabIndex = 2;
            // 
            // SettingsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.button_SettingsForm_Cancel;
            this.ClientSize = new System.Drawing.Size(673, 295);
            this.Controls.Add(this.groupBoxSettingsForm_SendingMailSettings);
            this.Controls.Add(this.groupBox_SettingsForm_StartUpParameters);
            this.Controls.Add(this.button_RestoreToDefaults);
            this.Controls.Add(this.button_SettingsForm_Cancel);
            this.Controls.Add(this.button_SettingsForm_OK);
            this.Controls.Add(this.groupBox_SettingsForm_Language);
            this.Controls.Add(this.groupBox_LocalSecurity_SecurityParameters);
            this.Controls.Add(this.groupBox_LocalSecurity_UsedPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.groupBox_SettingsForm_Language.ResumeLayout(false);
            this.groupBox_LocalSecurity_SecurityParameters.ResumeLayout(false);
            this.groupBox_LocalSecurity_UsedPassword.ResumeLayout(false);
            this.groupBox_LocalSecurity_UsedPassword.PerformLayout();
            this.groupBox_SettingsForm_StartUpParameters.ResumeLayout(false);
            this.groupBoxSettingsForm_SendingMailSettings.ResumeLayout(false);
            this.groupBoxSettingsForm_SendingMailSettings.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		
	private void button_SettingsForm_OK_Click(object sender, System.EventArgs e)
	{			
		try
		{
			IWshRuntimeLibrary.IWshShortcut iWshShortcut_obj =
                ((IWshRuntimeLibrary.IWshShortcut)new IWshRuntimeLibrary.WshShell().CreateShortcut(Application.ExecutablePath + ".lnk")); 
		
			iWshShortcut_obj.TargetPath = Application.ExecutablePath;

			iWshShortcut_obj.WorkingDirectory = Application.StartupPath;

			iWshShortcut_obj.Save();		

	
			if(this.checkBox_SettingsForm_AutoRun.Checked) 
			{
				Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("YakSys Server", Application.ExecutablePath + ".lnk");
			}
			else 
			{	
				string [] stringArray_ValueKeys = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValueNames();

				for(int int_CycleCount = 0; stringArray_ValueKeys.Length != int_CycleCount; int_CycleCount++)
				{					
					if(stringArray_ValueKeys[int_CycleCount].Equals("YakSys Server"))
					{
						Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).DeleteValue("YakSys Server");
						
						break;
					}
				}
			}


            CommonEnvironment.SMTPLogin = this.textBox_SendingMailSettings_SMTPLogin.Text;
            CommonEnvironment.SMTPPassword = this.textBox_SendingMailSettings_SMTPPassword.Text;

            CommonEnvironment.SMTPServer = this.textBox_SendingMailSettings_SMTPServer.Text;
            CommonEnvironment.SenderMailAddress = this.textBox_SendingMailSettings_MailAddress.Text;
            

            int int_Port = 25;

            if (int.TryParse(this.textBox_SendingMailSettings_SMTPPort.Text, out int_Port) == true)
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
            CommonEnvironment.SMTPPort = int_Port;




			CommonEnvironment.AutoRun = this.checkBox_SettingsForm_AutoRun.Checked;
			
			CommonEnvironment.StartServerAtRun = this.checkBox_SettingsForm_StartServerAtRun.Checked;
			
			CommonEnvironment.MinimizeToNotifyAreaAtRun = this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Checked;

			CommonEnvironment.CompressSettingsDataBase = this.checkBox_LocalSecurity_CompressSettingsDatabase.Checked;		
			CommonEnvironment.EncryptSettingsDataBase = this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked;
			
			CommonEnvironment.ActivateHiddenModeAtStartUp = this.checkBox_SettingsForm_ActivateHiddenMode.Checked;

			if(this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked == false)
			CommonEnvironment.LocalSecurityPassword = "";

			if(CommonEnvironment.LocalSecurityPassword.Length < 6) CommonEnvironment.EncryptSettingsDataBase = false;

			this.Close();
	
		}
		catch
		{
		}
	}

		
	private void comboBox_SettingsForm_Language_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		MainForm.CurrentLanguage = comboBox_SettingsForm_Language.SelectedIndex;
		
		ChangeControlsLanguage();
	}

	
	private void button_RestoreToDefaults_Click(object sender, System.EventArgs e)
	{
		if(MessageBox.Show(ServerStringFactory.GetString(110, MainForm.CurrentLanguage), 
			ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.YesNo) != DialogResult.Yes)
			return;

		CommonEnvironment.AutoRun = this.checkBox_SettingsForm_AutoRun.Checked = false;
		
		CommonEnvironment.StartServerAtRun = this.checkBox_SettingsForm_StartServerAtRun.Checked = false;
		
		CommonEnvironment.MinimizeToNotifyAreaAtRun = this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Checked = false;
	
		CommonEnvironment.ActivateHiddenModeAtStartUp = this.checkBox_SettingsForm_ActivateHiddenMode.Checked = false;

		CommonEnvironment.CompressSettingsDataBase = this.checkBox_LocalSecurity_CompressSettingsDatabase.Checked = true;		
		CommonEnvironment.EncryptSettingsDataBase = this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked = false;
		
	}

	
	public void SetPasswordInputEnableState(bool bool_EnableState)
	{
		this.label_LocalSecurity_NewPassword.Enabled = bool_EnableState;
		this.label_LocalSecurity_ConfirmedPassword.Enabled = bool_EnableState;

		this.textBox_LocalSecurity_NewPassword.Enabled = bool_EnableState;
		this.textBox_LocalSecurity_ConfirmedPassword.Enabled = bool_EnableState;
	}

	
	private void checkBox_LocalSecurity_EncryptSettingsDatabase_CheckedChanged(object sender, System.EventArgs e)
	{
		this.groupBox_LocalSecurity_UsedPassword.Enabled = this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked;
	
			
		if(this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked == true && CommonEnvironment.LocalSecurityPassword.Length < 6)
		{
			this.button_LocalSecurity_NewPassword_Click(null, null);
	
			return;
		}
		else
		{
			SetPasswordInputEnableState(false);
				
			this.button_LocalSecurity_SetPassword.Enabled = false;			
			this.button_LocalSecurity_NewPassword.Enabled = true;
		}
	}

	
	private void button_LocalSecurity_NewPassword_Click(object sender, System.EventArgs e)
	{
		SetPasswordInputEnableState(true);

		this.button_LocalSecurity_SetPassword.Enabled = true;
		this.button_LocalSecurity_NewPassword.Enabled = false;
		
		this.textBox_LocalSecurity_NewPassword.Text = this.textBox_LocalSecurity_ConfirmedPassword.Text = 
		CommonEnvironment.LocalSecurityPassword = "";
	}


	private void button_LocalSecurity_SetPassword_Click(object sender, System.EventArgs e)
	{

		if(this.textBox_LocalSecurity_NewPassword.Text.Length < 6)
		{
			MessageBox.Show(ServerStringFactory.GetString(116, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
			return;
		}

		if(this.textBox_LocalSecurity_NewPassword.Text != this.textBox_LocalSecurity_ConfirmedPassword.Text)
		{
			MessageBox.Show(ServerStringFactory.GetString(115, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
			return;
		}			

		CommonEnvironment.LocalSecurityPassword = this.textBox_LocalSecurity_NewPassword.Text;
			
		this.button_LocalSecurity_SetPassword.Enabled = false;
		this.button_LocalSecurity_NewPassword.Enabled = true;
			
		SetPasswordInputEnableState(false);
	}

	
}

