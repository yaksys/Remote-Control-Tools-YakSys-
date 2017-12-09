using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using YakSys.RCTServiceGUI;

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
	
	private System.ComponentModel.Container components = null;
	
	void ChangeControlsLanguage()
	{	
		this.Text = ServerStringFactory.GetString(65, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		
		this.groupBox_SettingsForm_Language.Text = ServerStringFactory.GetString(66, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
	
		this.label_SettingsForm_SelectLanguage.Text = ServerStringFactory.GetString(118, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
	
		this.comboBox_SettingsForm_Language.SelectedIndex = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage;

		this.checkBox_SettingsForm_AutoRun.Text = ServerStringFactory.GetString(73, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		
		this.checkBox_SettingsForm_StartServerAtRun.Text = ServerStringFactory.GetString(71, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		
		this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Text = ServerStringFactory.GetString(72, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
	

		this.groupBox_SettingsForm_StartUpParameters.Text = ServerStringFactory.GetString(218, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
	 
	
		this.groupBox_LocalSecurity_SecurityParameters.Text = ServerStringFactory.GetString(107, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.groupBox_LocalSecurity_UsedPassword.Text = ServerStringFactory.GetString(106, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);	
			
		this.label_LocalSecurity_NewPassword.Text = ServerStringFactory.GetString(104, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);		
		this.label_LocalSecurity_ConfirmedPassword.Text = ServerStringFactory.GetString(105, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

		this.button_LocalSecurity_NewPassword.Text = ServerStringFactory.GetString(102, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.button_LocalSecurity_SetPassword.Text = ServerStringFactory.GetString(103, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

		this.checkBox_LocalSecurity_CompressSettingsDatabase.Text = ServerStringFactory.GetString(101, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);		
		this.checkBox_LocalSecurity_EncryptSettingsDatabase.Text = ServerStringFactory.GetString(100, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

		this.button_RestoreToDefaults.Text = ServerStringFactory.GetString(108, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

		this.button_SettingsForm_Cancel.Text = ServerStringFactory.GetString(86, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);        
	}

		
	public SettingsForm()
	{
		InitializeComponent();

		ChangeControlsLanguage();	

		this.checkBox_SettingsForm_AutoRun.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_AutoRun;
		
		this.checkBox_SettingsForm_StartServerAtRun.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_StartServerAtRun;
		
		this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_MinimizeToNotifyAreaAtRun;
	
		this.checkBox_LocalSecurity_CompressSettingsDatabase.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CompressSettingsDataBase;		
		this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_EncryptSettingsDataBase;
		
		this.textBox_LocalSecurity_NewPassword.Text = this.textBox_LocalSecurity_ConfirmedPassword.Text = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_LocalSecurityPassword;

		if(this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked == false)
		{
			this.groupBox_LocalSecurity_UsedPassword.Enabled = false;

			this.textBox_LocalSecurity_NewPassword.Text = this.textBox_LocalSecurity_ConfirmedPassword.Text = String.Empty;
		}

		this.checkBox_LocalSecurity_EncryptSettingsDatabase_CheckedChanged(null, null);	
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
            this.groupBox_SettingsForm_Language.SuspendLayout();
            this.groupBox_LocalSecurity_SecurityParameters.SuspendLayout();
            this.groupBox_LocalSecurity_UsedPassword.SuspendLayout();
            this.groupBox_SettingsForm_StartUpParameters.SuspendLayout();
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
            this.checkBox_SettingsForm_AutoRun.Location = new System.Drawing.Point(16, 98);
            this.checkBox_SettingsForm_AutoRun.Name = "checkBox_SettingsForm_AutoRun";
            this.checkBox_SettingsForm_AutoRun.Size = new System.Drawing.Size(208, 16);
            this.checkBox_SettingsForm_AutoRun.TabIndex = 0;
            this.checkBox_SettingsForm_AutoRun.Text = "Auto run with Windows";
            this.checkBox_SettingsForm_AutoRun.Visible = false;
            // 
            // checkBox_SettingsForm_StartServerAtRun
            // 
            this.checkBox_SettingsForm_StartServerAtRun.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_SettingsForm_StartServerAtRun.Location = new System.Drawing.Point(18, 40);
            this.checkBox_SettingsForm_StartServerAtRun.Name = "checkBox_SettingsForm_StartServerAtRun";
            this.checkBox_SettingsForm_StartServerAtRun.Size = new System.Drawing.Size(208, 16);
            this.checkBox_SettingsForm_StartServerAtRun.TabIndex = 1;
            this.checkBox_SettingsForm_StartServerAtRun.Text = "Auto start Server";
            // 
            // checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart
            // 
            this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Location = new System.Drawing.Point(18, 64);
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
            // SettingsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.button_SettingsForm_Cancel;
            this.ClientSize = new System.Drawing.Size(482, 288);
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
            this.MaximumSize = new System.Drawing.Size(488, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(488, 320);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.groupBox_SettingsForm_Language.ResumeLayout(false);
            this.groupBox_LocalSecurity_SecurityParameters.ResumeLayout(false);
            this.groupBox_LocalSecurity_UsedPassword.ResumeLayout(false);
            this.groupBox_LocalSecurity_UsedPassword.PerformLayout();
            this.groupBox_SettingsForm_StartUpParameters.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		
	private void button_SettingsForm_OK_Click(object sender, System.EventArgs e)
	{			
		try
		{
	
			if(this.checkBox_SettingsForm_AutoRun.Checked) 
			{
				Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("YakSys RCT Server", Application.ExecutablePath + ".lnk");
			}
			else 
			{	
				string [] stringArray_ValueKeys = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValueNames();

				for(int int_CycleCount = 0; stringArray_ValueKeys.Length != int_CycleCount; int_CycleCount++)
				{					
					if(stringArray_ValueKeys[int_CycleCount].Equals("YakSys RCT Server"))
					{
						Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).DeleteValue("YakSys RCT Server");
						
						break;
					}
				}
			}

		
			LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_AutoRun = this.checkBox_SettingsForm_AutoRun.Checked;
			
			LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_StartServerAtRun = this.checkBox_SettingsForm_StartServerAtRun.Checked;
			
			LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_MinimizeToNotifyAreaAtRun = this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Checked;

			LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CompressSettingsDataBase = this.checkBox_LocalSecurity_CompressSettingsDatabase.Checked;		
			LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_EncryptSettingsDataBase = this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked;

            if (this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked == false)
            {
                LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_LocalSecurityPassword = String.Empty;
            }

            if (LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_LocalSecurityPassword.Length < 6)
            {
                LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_EncryptSettingsDataBase = false;
            }

			this.Close();
	
		}
		catch
		{
		}
	}
    		
	private void comboBox_SettingsForm_Language_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage = comboBox_SettingsForm_Language.SelectedIndex;
		
		ChangeControlsLanguage();

        LocalObjCopy.obj_MainServerForm.ChangeControlsLanguage();
	}

	private void button_RestoreToDefaults_Click(object sender, System.EventArgs e)
	{
		if(MessageBox.Show(ServerStringFactory.GetString(110, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), 
			ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.YesNo) != DialogResult.Yes)
			return;

		LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_AutoRun = this.checkBox_SettingsForm_AutoRun.Checked = false;
		
		LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_StartServerAtRun = this.checkBox_SettingsForm_StartServerAtRun.Checked = false;
		
		LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_MinimizeToNotifyAreaAtRun = this.checkBox_SettingsForm_MinimizeToNotifyAreaAfterStart.Checked = false;

		LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CompressSettingsDataBase = this.checkBox_LocalSecurity_CompressSettingsDatabase.Checked = true;		
		LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_EncryptSettingsDataBase = this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked = false;		
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
	
			
		if(this.checkBox_LocalSecurity_EncryptSettingsDatabase.Checked == true && LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_LocalSecurityPassword.Length < 6)
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
		LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_LocalSecurityPassword = String.Empty;
	}
    
	private void button_LocalSecurity_SetPassword_Click(object sender, System.EventArgs e)
	{

		if(this.textBox_LocalSecurity_NewPassword.Text.Length < 6)
		{
			MessageBox.Show(ServerStringFactory.GetString(116, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
			return;
		}

		if(this.textBox_LocalSecurity_NewPassword.Text != this.textBox_LocalSecurity_ConfirmedPassword.Text)
		{
			MessageBox.Show(ServerStringFactory.GetString(115, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
			return;
		}			

		LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_LocalSecurityPassword = this.textBox_LocalSecurity_NewPassword.Text;
			
		this.button_LocalSecurity_SetPassword.Enabled = false;
		this.button_LocalSecurity_NewPassword.Enabled = true;
			
		SetPasswordInputEnableState(false);
	}
	
}

