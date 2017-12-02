using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using JurikSoft.RCTServiceGUI;

public class UsersAccountsManagerForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_Login;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_Login;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_NewPassword;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_NewPassword;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_FirstName;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_FirstName;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_MiddleName;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_MiddleName;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_LastName;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_LastName;
	private System.Windows.Forms.Button button_UsersAccountsManagerForm_Add;
	private System.Windows.Forms.Button button_UsersAccountsManagerForm_Apply;
	private System.Windows.Forms.Button button_UsersAccountsManagerForm_Cancel;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_EMailAddress;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_EMailAddress;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_HomePhome;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_WorkPhone;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_WorkPhone;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_Company;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_Company;
	private System.Windows.Forms.GroupBox groupBox_UsersAccountsManagerForm_AccountInformation;
	private System.Windows.Forms.GroupBox groupBox_UsersAccountsManagerForm_AdditionalInformation;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_ICQ;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_ICQ;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_HomePhone;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_PrivateCellular;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_PrivateCellular;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_ConfirmedPassword;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_ConfirmedPassword;
	private System.Windows.Forms.TextBox textBox_UsersAccountsManagerForm_UserName;
	private System.Windows.Forms.Label label_UsersAccountsManagerForm_UserName;

	private System.ComponentModel.Container components = null;
		
	void ChangeControlsLanguage()
	{
		this.Text = ServerStringFactory.GetString(129, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Text = ServerStringFactory.GetString(140, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Text = ServerStringFactory.GetString(141, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

		this.label_UsersAccountsManagerForm_Login.Text = ServerStringFactory.GetString(17, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.label_UsersAccountsManagerForm_UserName.Text = ServerStringFactory.GetString(142, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.label_UsersAccountsManagerForm_NewPassword.Text = ServerStringFactory.GetString(16, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.label_UsersAccountsManagerForm_ConfirmedPassword.Text = ServerStringFactory.GetString(130, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
					
		this.label_UsersAccountsManagerForm_FirstName.Text = ServerStringFactory.GetString(131, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.label_UsersAccountsManagerForm_LastName.Text = ServerStringFactory.GetString(132, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.label_UsersAccountsManagerForm_MiddleName.Text = ServerStringFactory.GetString(133, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.label_UsersAccountsManagerForm_EMailAddress.Text = ServerStringFactory.GetString(134, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.label_UsersAccountsManagerForm_ICQ.Text = ServerStringFactory.GetString(135, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.label_UsersAccountsManagerForm_Company.Text = ServerStringFactory.GetString(136, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.label_UsersAccountsManagerForm_HomePhone.Text = ServerStringFactory.GetString(137, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.label_UsersAccountsManagerForm_WorkPhone.Text = ServerStringFactory.GetString(138, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.label_UsersAccountsManagerForm_PrivateCellular.Text = ServerStringFactory.GetString(139, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		
		this.button_UsersAccountsManagerForm_Add.Text = ServerStringFactory.GetString(23, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.button_UsersAccountsManagerForm_Apply.Text = ServerStringFactory.GetString(79, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
		this.button_UsersAccountsManagerForm_Cancel.Text = ServerStringFactory.GetString(86, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
	}


	public UsersAccountsManagerForm()
	{
		InitializeComponent();

		ChangeControlsLanguage();
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
	
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(UsersAccountsManagerForm));
		this.label_UsersAccountsManagerForm_FirstName = new System.Windows.Forms.Label();
		this.textBox_UsersAccountsManagerForm_FirstName = new System.Windows.Forms.TextBox();
		this.textBox_UsersAccountsManagerForm_EMailAddress = new System.Windows.Forms.TextBox();
		this.label_UsersAccountsManagerForm_EMailAddress = new System.Windows.Forms.Label();
		this.textBox_UsersAccountsManagerForm_HomePhome = new System.Windows.Forms.TextBox();
		this.label_UsersAccountsManagerForm_HomePhone = new System.Windows.Forms.Label();
		this.textBox_UsersAccountsManagerForm_MiddleName = new System.Windows.Forms.TextBox();
		this.label_UsersAccountsManagerForm_MiddleName = new System.Windows.Forms.Label();
		this.textBox_UsersAccountsManagerForm_Company = new System.Windows.Forms.TextBox();
		this.label_UsersAccountsManagerForm_Company = new System.Windows.Forms.Label();
		this.textBox_UsersAccountsManagerForm_WorkPhone = new System.Windows.Forms.TextBox();
		this.label_UsersAccountsManagerForm_WorkPhone = new System.Windows.Forms.Label();
		this.textBox_UsersAccountsManagerForm_Login = new System.Windows.Forms.TextBox();
		this.label_UsersAccountsManagerForm_Login = new System.Windows.Forms.Label();
		this.textBox_UsersAccountsManagerForm_LastName = new System.Windows.Forms.TextBox();
		this.label_UsersAccountsManagerForm_LastName = new System.Windows.Forms.Label();
		this.textBox_UsersAccountsManagerForm_ICQ = new System.Windows.Forms.TextBox();
		this.label_UsersAccountsManagerForm_ICQ = new System.Windows.Forms.Label();
		this.textBox_UsersAccountsManagerForm_PrivateCellular = new System.Windows.Forms.TextBox();
		this.label_UsersAccountsManagerForm_PrivateCellular = new System.Windows.Forms.Label();
		this.groupBox_UsersAccountsManagerForm_AccountInformation = new System.Windows.Forms.GroupBox();
		this.textBox_UsersAccountsManagerForm_UserName = new System.Windows.Forms.TextBox();
		this.label_UsersAccountsManagerForm_UserName = new System.Windows.Forms.Label();
		this.label_UsersAccountsManagerForm_ConfirmedPassword = new System.Windows.Forms.Label();
		this.textBox_UsersAccountsManagerForm_ConfirmedPassword = new System.Windows.Forms.TextBox();
		this.label_UsersAccountsManagerForm_NewPassword = new System.Windows.Forms.Label();
		this.textBox_UsersAccountsManagerForm_NewPassword = new System.Windows.Forms.TextBox();
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation = new System.Windows.Forms.GroupBox();
		this.button_UsersAccountsManagerForm_Add = new System.Windows.Forms.Button();
		this.button_UsersAccountsManagerForm_Apply = new System.Windows.Forms.Button();
		this.button_UsersAccountsManagerForm_Cancel = new System.Windows.Forms.Button();
		this.groupBox_UsersAccountsManagerForm_AccountInformation.SuspendLayout();
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.SuspendLayout();
		this.SuspendLayout();
		// 
		// label_UsersAccountsManagerForm_FirstName
		// 
		this.label_UsersAccountsManagerForm_FirstName.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_UsersAccountsManagerForm_FirstName.Location = new System.Drawing.Point(16, 32);
		this.label_UsersAccountsManagerForm_FirstName.Name = "label_UsersAccountsManagerForm_FirstName";
		this.label_UsersAccountsManagerForm_FirstName.Size = new System.Drawing.Size(136, 16);
		this.label_UsersAccountsManagerForm_FirstName.TabIndex = 0;
		this.label_UsersAccountsManagerForm_FirstName.Text = "First Name:";
		// 
		// textBox_UsersAccountsManagerForm_FirstName
		// 
		this.textBox_UsersAccountsManagerForm_FirstName.Location = new System.Drawing.Point(16, 48);
		this.textBox_UsersAccountsManagerForm_FirstName.Name = "textBox_UsersAccountsManagerForm_FirstName";
		this.textBox_UsersAccountsManagerForm_FirstName.Size = new System.Drawing.Size(136, 20);
		this.textBox_UsersAccountsManagerForm_FirstName.TabIndex = 4;
		this.textBox_UsersAccountsManagerForm_FirstName.Text = String.Empty;
		// 
		// textBox_UsersAccountsManagerForm_EMailAddress
		// 
		this.textBox_UsersAccountsManagerForm_EMailAddress.Location = new System.Drawing.Point(16, 96);
		this.textBox_UsersAccountsManagerForm_EMailAddress.Name = "textBox_UsersAccountsManagerForm_EMailAddress";
		this.textBox_UsersAccountsManagerForm_EMailAddress.Size = new System.Drawing.Size(136, 20);
		this.textBox_UsersAccountsManagerForm_EMailAddress.TabIndex = 7;
		this.textBox_UsersAccountsManagerForm_EMailAddress.Text = String.Empty;
		// 
		// label_UsersAccountsManagerForm_EMailAddress
		// 
		this.label_UsersAccountsManagerForm_EMailAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_UsersAccountsManagerForm_EMailAddress.Location = new System.Drawing.Point(16, 80);
		this.label_UsersAccountsManagerForm_EMailAddress.Name = "label_UsersAccountsManagerForm_EMailAddress";
		this.label_UsersAccountsManagerForm_EMailAddress.Size = new System.Drawing.Size(136, 16);
		this.label_UsersAccountsManagerForm_EMailAddress.TabIndex = 2;
		this.label_UsersAccountsManagerForm_EMailAddress.Text = "E-Mail:";
		// 
		// textBox_UsersAccountsManagerForm_HomePhome
		// 
		this.textBox_UsersAccountsManagerForm_HomePhome.Location = new System.Drawing.Point(16, 144);
		this.textBox_UsersAccountsManagerForm_HomePhome.Name = "textBox_UsersAccountsManagerForm_HomePhome";
		this.textBox_UsersAccountsManagerForm_HomePhome.Size = new System.Drawing.Size(136, 20);
		this.textBox_UsersAccountsManagerForm_HomePhome.TabIndex = 10;
		this.textBox_UsersAccountsManagerForm_HomePhome.Text = String.Empty;
		// 
		// label_UsersAccountsManagerForm_HomePhone
		// 
		this.label_UsersAccountsManagerForm_HomePhone.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_UsersAccountsManagerForm_HomePhone.Location = new System.Drawing.Point(16, 128);
		this.label_UsersAccountsManagerForm_HomePhone.Name = "label_UsersAccountsManagerForm_HomePhone";
		this.label_UsersAccountsManagerForm_HomePhone.Size = new System.Drawing.Size(136, 24);
		this.label_UsersAccountsManagerForm_HomePhone.TabIndex = 4;
		this.label_UsersAccountsManagerForm_HomePhone.Text = "Home phone:";
		// 
		// textBox_UsersAccountsManagerForm_MiddleName
		// 
		this.textBox_UsersAccountsManagerForm_MiddleName.Location = new System.Drawing.Point(304, 48);
		this.textBox_UsersAccountsManagerForm_MiddleName.Name = "textBox_UsersAccountsManagerForm_MiddleName";
		this.textBox_UsersAccountsManagerForm_MiddleName.Size = new System.Drawing.Size(144, 20);
		this.textBox_UsersAccountsManagerForm_MiddleName.TabIndex = 6;
		this.textBox_UsersAccountsManagerForm_MiddleName.Text = String.Empty;
		// 
		// label_UsersAccountsManagerForm_MiddleName
		// 
		this.label_UsersAccountsManagerForm_MiddleName.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_UsersAccountsManagerForm_MiddleName.Location = new System.Drawing.Point(304, 32);
		this.label_UsersAccountsManagerForm_MiddleName.Name = "label_UsersAccountsManagerForm_MiddleName";
		this.label_UsersAccountsManagerForm_MiddleName.Size = new System.Drawing.Size(144, 16);
		this.label_UsersAccountsManagerForm_MiddleName.TabIndex = 8;
		this.label_UsersAccountsManagerForm_MiddleName.Text = "Middle Name:";
		// 
		// textBox_UsersAccountsManagerForm_Company
		// 
		this.textBox_UsersAccountsManagerForm_Company.Location = new System.Drawing.Point(304, 96);
		this.textBox_UsersAccountsManagerForm_Company.Name = "textBox_UsersAccountsManagerForm_Company";
		this.textBox_UsersAccountsManagerForm_Company.Size = new System.Drawing.Size(144, 20);
		this.textBox_UsersAccountsManagerForm_Company.TabIndex = 9;
		this.textBox_UsersAccountsManagerForm_Company.Text = String.Empty;
		// 
		// label_UsersAccountsManagerForm_Company
		// 
		this.label_UsersAccountsManagerForm_Company.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_UsersAccountsManagerForm_Company.Location = new System.Drawing.Point(304, 80);
		this.label_UsersAccountsManagerForm_Company.Name = "label_UsersAccountsManagerForm_Company";
		this.label_UsersAccountsManagerForm_Company.Size = new System.Drawing.Size(144, 16);
		this.label_UsersAccountsManagerForm_Company.TabIndex = 10;
		this.label_UsersAccountsManagerForm_Company.Text = "Company:";
		// 
		// textBox_UsersAccountsManagerForm_WorkPhone
		// 
		this.textBox_UsersAccountsManagerForm_WorkPhone.Location = new System.Drawing.Point(160, 144);
		this.textBox_UsersAccountsManagerForm_WorkPhone.Name = "textBox_UsersAccountsManagerForm_WorkPhone";
		this.textBox_UsersAccountsManagerForm_WorkPhone.Size = new System.Drawing.Size(136, 20);
		this.textBox_UsersAccountsManagerForm_WorkPhone.TabIndex = 11;
		this.textBox_UsersAccountsManagerForm_WorkPhone.Text = String.Empty;
		// 
		// label_UsersAccountsManagerForm_WorkPhone
		// 
		this.label_UsersAccountsManagerForm_WorkPhone.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_UsersAccountsManagerForm_WorkPhone.Location = new System.Drawing.Point(160, 128);
		this.label_UsersAccountsManagerForm_WorkPhone.Name = "label_UsersAccountsManagerForm_WorkPhone";
		this.label_UsersAccountsManagerForm_WorkPhone.Size = new System.Drawing.Size(136, 16);
		this.label_UsersAccountsManagerForm_WorkPhone.TabIndex = 12;
		this.label_UsersAccountsManagerForm_WorkPhone.Text = "Work  phone:";
		// 
		// textBox_UsersAccountsManagerForm_Login
		// 
		this.textBox_UsersAccountsManagerForm_Login.Location = new System.Drawing.Point(16, 48);
		this.textBox_UsersAccountsManagerForm_Login.Name = "textBox_UsersAccountsManagerForm_Login";
		this.textBox_UsersAccountsManagerForm_Login.Size = new System.Drawing.Size(128, 20);
		this.textBox_UsersAccountsManagerForm_Login.TabIndex = 0;
		this.textBox_UsersAccountsManagerForm_Login.Text = String.Empty;
		// 
		// label_UsersAccountsManagerForm_Login
		// 
		this.label_UsersAccountsManagerForm_Login.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_UsersAccountsManagerForm_Login.Location = new System.Drawing.Point(16, 32);
		this.label_UsersAccountsManagerForm_Login.Name = "label_UsersAccountsManagerForm_Login";
		this.label_UsersAccountsManagerForm_Login.Size = new System.Drawing.Size(128, 16);
		this.label_UsersAccountsManagerForm_Login.TabIndex = 20;
		this.label_UsersAccountsManagerForm_Login.Text = "Login:";
		// 
		// textBox_UsersAccountsManagerForm_LastName
		// 
		this.textBox_UsersAccountsManagerForm_LastName.Location = new System.Drawing.Point(160, 48);
		this.textBox_UsersAccountsManagerForm_LastName.Name = "textBox_UsersAccountsManagerForm_LastName";
		this.textBox_UsersAccountsManagerForm_LastName.Size = new System.Drawing.Size(136, 20);
		this.textBox_UsersAccountsManagerForm_LastName.TabIndex = 5;
		this.textBox_UsersAccountsManagerForm_LastName.Text = String.Empty;
		// 
		// label_UsersAccountsManagerForm_LastName
		// 
		this.label_UsersAccountsManagerForm_LastName.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_UsersAccountsManagerForm_LastName.Location = new System.Drawing.Point(160, 32);
		this.label_UsersAccountsManagerForm_LastName.Name = "label_UsersAccountsManagerForm_LastName";
		this.label_UsersAccountsManagerForm_LastName.Size = new System.Drawing.Size(136, 16);
		this.label_UsersAccountsManagerForm_LastName.TabIndex = 22;
		this.label_UsersAccountsManagerForm_LastName.Text = "Last Name:";
		// 
		// textBox_UsersAccountsManagerForm_ICQ
		// 
		this.textBox_UsersAccountsManagerForm_ICQ.Location = new System.Drawing.Point(160, 96);
		this.textBox_UsersAccountsManagerForm_ICQ.Name = "textBox_UsersAccountsManagerForm_ICQ";
		this.textBox_UsersAccountsManagerForm_ICQ.Size = new System.Drawing.Size(136, 20);
		this.textBox_UsersAccountsManagerForm_ICQ.TabIndex = 8;
		this.textBox_UsersAccountsManagerForm_ICQ.Text = String.Empty;
		// 
		// label_UsersAccountsManagerForm_ICQ
		// 
		this.label_UsersAccountsManagerForm_ICQ.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_UsersAccountsManagerForm_ICQ.Location = new System.Drawing.Point(160, 80);
		this.label_UsersAccountsManagerForm_ICQ.Name = "label_UsersAccountsManagerForm_ICQ";
		this.label_UsersAccountsManagerForm_ICQ.Size = new System.Drawing.Size(136, 16);
		this.label_UsersAccountsManagerForm_ICQ.TabIndex = 24;
		this.label_UsersAccountsManagerForm_ICQ.Text = "ICQ:";
		// 
		// textBox_UsersAccountsManagerForm_PrivateCellular
		// 
		this.textBox_UsersAccountsManagerForm_PrivateCellular.Location = new System.Drawing.Point(304, 144);
		this.textBox_UsersAccountsManagerForm_PrivateCellular.Name = "textBox_UsersAccountsManagerForm_PrivateCellular";
		this.textBox_UsersAccountsManagerForm_PrivateCellular.Size = new System.Drawing.Size(144, 20);
		this.textBox_UsersAccountsManagerForm_PrivateCellular.TabIndex = 12;
		this.textBox_UsersAccountsManagerForm_PrivateCellular.Text = String.Empty;
		// 
		// label_UsersAccountsManagerForm_PrivateCellular
		// 
		this.label_UsersAccountsManagerForm_PrivateCellular.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_UsersAccountsManagerForm_PrivateCellular.Location = new System.Drawing.Point(304, 128);
		this.label_UsersAccountsManagerForm_PrivateCellular.Name = "label_UsersAccountsManagerForm_PrivateCellular";
		this.label_UsersAccountsManagerForm_PrivateCellular.Size = new System.Drawing.Size(144, 16);
		this.label_UsersAccountsManagerForm_PrivateCellular.TabIndex = 26;
		this.label_UsersAccountsManagerForm_PrivateCellular.Text = "Private cellular:";
		// 
		// groupBox_UsersAccountsManagerForm_AccountInformation
		// 
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_UserName);
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Controls.Add(this.label_UsersAccountsManagerForm_UserName);
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Controls.Add(this.label_UsersAccountsManagerForm_ConfirmedPassword);
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_ConfirmedPassword);
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Controls.Add(this.label_UsersAccountsManagerForm_NewPassword);
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_NewPassword);
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_Login);
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Controls.Add(this.label_UsersAccountsManagerForm_Login);
		this.groupBox_UsersAccountsManagerForm_AccountInformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Location = new System.Drawing.Point(16, 16);
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Name = "groupBox_UsersAccountsManagerForm_AccountInformation";
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Size = new System.Drawing.Size(296, 144);
		this.groupBox_UsersAccountsManagerForm_AccountInformation.TabIndex = 28;
		this.groupBox_UsersAccountsManagerForm_AccountInformation.TabStop = false;
		this.groupBox_UsersAccountsManagerForm_AccountInformation.Text = "Account info";
		// 
		// textBox_UsersAccountsManagerForm_UserName
		// 
		this.textBox_UsersAccountsManagerForm_UserName.Location = new System.Drawing.Point(152, 48);
		this.textBox_UsersAccountsManagerForm_UserName.Name = "textBox_UsersAccountsManagerForm_UserName";
		this.textBox_UsersAccountsManagerForm_UserName.Size = new System.Drawing.Size(128, 20);
		this.textBox_UsersAccountsManagerForm_UserName.TabIndex = 1;
		this.textBox_UsersAccountsManagerForm_UserName.Text = String.Empty;
		// 
		// label_UsersAccountsManagerForm_UserName
		// 
		this.label_UsersAccountsManagerForm_UserName.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_UsersAccountsManagerForm_UserName.Location = new System.Drawing.Point(152, 32);
		this.label_UsersAccountsManagerForm_UserName.Name = "label_UsersAccountsManagerForm_UserName";
		this.label_UsersAccountsManagerForm_UserName.Size = new System.Drawing.Size(128, 16);
		this.label_UsersAccountsManagerForm_UserName.TabIndex = 26;
		this.label_UsersAccountsManagerForm_UserName.Text = "User Name:";
		// 
		// label_UsersAccountsManagerForm_ConfirmedPassword
		// 
		this.label_UsersAccountsManagerForm_ConfirmedPassword.Location = new System.Drawing.Point(152, 80);
		this.label_UsersAccountsManagerForm_ConfirmedPassword.Name = "label_UsersAccountsManagerForm_ConfirmedPassword";
		this.label_UsersAccountsManagerForm_ConfirmedPassword.Size = new System.Drawing.Size(136, 16);
		this.label_UsersAccountsManagerForm_ConfirmedPassword.TabIndex = 25;
		this.label_UsersAccountsManagerForm_ConfirmedPassword.Text = "Confirmed Password:";
		// 
		// textBox_UsersAccountsManagerForm_ConfirmedPassword
		// 
		this.textBox_UsersAccountsManagerForm_ConfirmedPassword.Location = new System.Drawing.Point(152, 96);
		this.textBox_UsersAccountsManagerForm_ConfirmedPassword.MaxLength = 64;
		this.textBox_UsersAccountsManagerForm_ConfirmedPassword.Name = "textBox_UsersAccountsManagerForm_ConfirmedPassword";
		this.textBox_UsersAccountsManagerForm_ConfirmedPassword.PasswordChar = '*';
		this.textBox_UsersAccountsManagerForm_ConfirmedPassword.Size = new System.Drawing.Size(128, 20);
		this.textBox_UsersAccountsManagerForm_ConfirmedPassword.TabIndex = 3;
		this.textBox_UsersAccountsManagerForm_ConfirmedPassword.Text = String.Empty;
		// 
		// label_UsersAccountsManagerForm_NewPassword
		// 
		this.label_UsersAccountsManagerForm_NewPassword.Location = new System.Drawing.Point(16, 80);
		this.label_UsersAccountsManagerForm_NewPassword.Name = "label_UsersAccountsManagerForm_NewPassword";
		this.label_UsersAccountsManagerForm_NewPassword.Size = new System.Drawing.Size(128, 16);
		this.label_UsersAccountsManagerForm_NewPassword.TabIndex = 3;
		this.label_UsersAccountsManagerForm_NewPassword.Text = "Password:";
		// 
		// textBox_UsersAccountsManagerForm_NewPassword
		// 
		this.textBox_UsersAccountsManagerForm_NewPassword.Location = new System.Drawing.Point(16, 96);
		this.textBox_UsersAccountsManagerForm_NewPassword.MaxLength = 64;
		this.textBox_UsersAccountsManagerForm_NewPassword.Name = "textBox_UsersAccountsManagerForm_NewPassword";
		this.textBox_UsersAccountsManagerForm_NewPassword.PasswordChar = '*';
		this.textBox_UsersAccountsManagerForm_NewPassword.Size = new System.Drawing.Size(128, 20);
		this.textBox_UsersAccountsManagerForm_NewPassword.TabIndex = 2;
		this.textBox_UsersAccountsManagerForm_NewPassword.Text = String.Empty;
		// 
		// groupBox_UsersAccountsManagerForm_AdditionalInformation
		// 
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_HomePhome);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_ICQ);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.label_UsersAccountsManagerForm_ICQ);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.label_UsersAccountsManagerForm_PrivateCellular);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_PrivateCellular);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_LastName);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_Company);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.label_UsersAccountsManagerForm_Company);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_MiddleName);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.label_UsersAccountsManagerForm_FirstName);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.label_UsersAccountsManagerForm_HomePhone);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.label_UsersAccountsManagerForm_MiddleName);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_EMailAddress);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.label_UsersAccountsManagerForm_EMailAddress);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_FirstName);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.textBox_UsersAccountsManagerForm_WorkPhone);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.label_UsersAccountsManagerForm_WorkPhone);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Controls.Add(this.label_UsersAccountsManagerForm_LastName);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Location = new System.Drawing.Point(328, 16);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Name = "groupBox_UsersAccountsManagerForm_AdditionalInformation";
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Size = new System.Drawing.Size(464, 184);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.TabIndex = 31;
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.TabStop = false;
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Text = "Additional info";
		// 
		// button_UsersAccountsManagerForm_Add
		// 
		this.button_UsersAccountsManagerForm_Add.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button_UsersAccountsManagerForm_Add.Location = new System.Drawing.Point(16, 176);
		this.button_UsersAccountsManagerForm_Add.Name = "button_UsersAccountsManagerForm_Add";
		this.button_UsersAccountsManagerForm_Add.Size = new System.Drawing.Size(88, 23);
		this.button_UsersAccountsManagerForm_Add.TabIndex = 13;
		this.button_UsersAccountsManagerForm_Add.Text = "Add";
		this.button_UsersAccountsManagerForm_Add.Click += new System.EventHandler(this.button_UsersAccountsManagerForm_Add_Click);
		// 
		// button_UsersAccountsManagerForm_Apply
		// 
		this.button_UsersAccountsManagerForm_Apply.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button_UsersAccountsManagerForm_Apply.Location = new System.Drawing.Point(120, 176);
		this.button_UsersAccountsManagerForm_Apply.Name = "button_UsersAccountsManagerForm_Apply";
		this.button_UsersAccountsManagerForm_Apply.Size = new System.Drawing.Size(88, 23);
		this.button_UsersAccountsManagerForm_Apply.TabIndex = 14;
		this.button_UsersAccountsManagerForm_Apply.Text = "Apply";
		this.button_UsersAccountsManagerForm_Apply.Click += new System.EventHandler(this.button_UsersAccountsManagerForm_Apply_Click);
		// 
		// button_UsersAccountsManagerForm_Cancel
		// 
		this.button_UsersAccountsManagerForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button_UsersAccountsManagerForm_Cancel.Location = new System.Drawing.Point(224, 176);
		this.button_UsersAccountsManagerForm_Cancel.Name = "button_UsersAccountsManagerForm_Cancel";
		this.button_UsersAccountsManagerForm_Cancel.Size = new System.Drawing.Size(88, 23);
		this.button_UsersAccountsManagerForm_Cancel.TabIndex = 15;
		this.button_UsersAccountsManagerForm_Cancel.Text = "Cancel";
		this.button_UsersAccountsManagerForm_Cancel.Click += new System.EventHandler(this.button_UsersAccountsManagerForm_Cancel_Click);
		// 
		// UsersAccountsManagerForm
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(802, 216);
		this.Controls.Add(this.button_UsersAccountsManagerForm_Cancel);
		this.Controls.Add(this.button_UsersAccountsManagerForm_Apply);
		this.Controls.Add(this.button_UsersAccountsManagerForm_Add);
		this.Controls.Add(this.groupBox_UsersAccountsManagerForm_AdditionalInformation);
		this.Controls.Add(this.groupBox_UsersAccountsManagerForm_AccountInformation);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.MaximumSize = new System.Drawing.Size(808, 248);
		this.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size(808, 248);
		this.Name = "UsersAccountsManagerForm";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "User account manager";
		this.groupBox_UsersAccountsManagerForm_AccountInformation.ResumeLayout(false);
		this.groupBox_UsersAccountsManagerForm_AdditionalInformation.ResumeLayout(false);
		this.ResumeLayout(false);

	}
	#endregion

	private void button_UsersAccountsManagerForm_Add_Click(object sender, System.EventArgs e)
	{
		if (this.textBox_UsersAccountsManagerForm_Login.Text.Length == 0
		||	this.textBox_UsersAccountsManagerForm_NewPassword.Text.Length == 0 
		||	this.textBox_UsersAccountsManagerForm_ConfirmedPassword.Text.Length == 0
		||	this.textBox_UsersAccountsManagerForm_UserName.Text.Length == 0) 
			
		{
			MessageBox.Show(ServerStringFactory.GetString(60, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), 
			ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		
			return;
		}

        for (int int_intCycleCount = 0; int_intCycleCount != LocalObjCopy.obj_NetworkSecurity_UserAccount.RemotingWrapper_UsersAccounts.Count; int_intCycleCount++)
		{
            if (LocalObjCopy.obj_NetworkSecurity_UserAccount.RemotingWrapper_UsersAccounts[int_intCycleCount].Login == this.textBox_UsersAccountsManagerForm_Login.Text) 
			{
				MessageBox.Show(ServerStringFactory.GetString(61, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), 
				ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				
				return;
			}
		}

		if(this.textBox_UsersAccountsManagerForm_NewPassword.Text != this.textBox_UsersAccountsManagerForm_ConfirmedPassword.Text)
		{
			MessageBox.Show(ServerStringFactory.GetString(115, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
			return;
		}

        DateTime dateTime_CreationTime = DateTime.Now;

        if (LocalObjCopy.obj_NetworkSecurity.RemotingWrapper_AddNewUser(this.textBox_UsersAccountsManagerForm_UserName.Text, this.textBox_UsersAccountsManagerForm_Login.Text, this.textBox_UsersAccountsManagerForm_NewPassword.Text, dateTime_CreationTime, true))
		{
            LocalObjCopy.obj_NetworkSecurity.RemotingWrapper_StoreUserAccountToDB(this.textBox_UsersAccountsManagerForm_UserName.Text, this.textBox_UsersAccountsManagerForm_Login.Text, this.textBox_UsersAccountsManagerForm_NewPassword.Text, this.textBox_UsersAccountsManagerForm_FirstName.Text, this.textBox_UsersAccountsManagerForm_LastName.Text, this.textBox_UsersAccountsManagerForm_MiddleName.Text, this.textBox_UsersAccountsManagerForm_EMailAddress.Text, this.textBox_UsersAccountsManagerForm_ICQ.Text, this.textBox_UsersAccountsManagerForm_Company.Text, this.textBox_UsersAccountsManagerForm_WorkPhone.Text, this.textBox_UsersAccountsManagerForm_HomePhome.Text, this.textBox_UsersAccountsManagerForm_PrivateCellular.Text, dateTime_CreationTime, true);	
		
            LocalObjCopy.obj_JurikSoftServerLog.RemotingWrapper_InsertDataToLog(ServerStringFactory.GetString(44, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), dateTime_CreationTime.ToShortDateString(), dateTime_CreationTime.ToLongTimeString(), 
                                                                                ServerStringFactory.GetString(1, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage), ServerStringFactory.GetString(45, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage) + this.textBox_UsersAccountsManagerForm_UserName.Text);
        }

		this.Close();
	}

	private void button_UsersAccountsManagerForm_Apply_Click(object sender, System.EventArgs e)
	{
        LocalObjCopy.obj_NetworkSecurity.RemotingWrapper_EditUserAccountInDB(this.textBox_UsersAccountsManagerForm_FirstName.Text, this.textBox_UsersAccountsManagerForm_LastName.Text, this.textBox_UsersAccountsManagerForm_MiddleName.Text, this.textBox_UsersAccountsManagerForm_EMailAddress.Text, this.textBox_UsersAccountsManagerForm_ICQ.Text, this.textBox_UsersAccountsManagerForm_Company.Text, this.textBox_UsersAccountsManagerForm_WorkPhone.Text, this.textBox_UsersAccountsManagerForm_HomePhome.Text, this.textBox_UsersAccountsManagerForm_PrivateCellular.Text, EditedRecordIndex);	
		
		this.Close();
	}

	private void button_UsersAccountsManagerForm_Cancel_Click(object sender, System.EventArgs e)
	{
		this.Close();
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
			return this.button_UsersAccountsManagerForm_Apply;
		}

		set
		{
			this.button_UsersAccountsManagerForm_Apply = value;
		}
	}

	public Button OverrideCancelButton
	{
		get
		{
			return this.button_UsersAccountsManagerForm_Cancel;
		}

		set
		{
			this.button_UsersAccountsManagerForm_Cancel = value;
		}
	}
	
	public Button AddButton
	{
		get
		{
			return this.button_UsersAccountsManagerForm_Add;
		}

		set
		{
			this.button_UsersAccountsManagerForm_Add = value;
		}
	}


	public TextBox LoginTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_Login;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_Login = value;
		}	
	}

	public TextBox UserNameTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_UserName;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_UserName = value;
		}	
	}

	public TextBox NewPasswordTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_NewPassword;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_NewPassword = value;
		}	
	}

	public TextBox ConfirmedPasswordTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_ConfirmedPassword;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_ConfirmedPassword = value;
		}	
	}

	public TextBox FirstNameTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_FirstName;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_FirstName = value;
		}	
	}
	
	public TextBox MiddleNameTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_MiddleName;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_MiddleName = value;
		}	
	}
	
	public TextBox LastNameTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_LastName;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_LastName = value;
		}	
	}
	
	public TextBox EMailAddressTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_EMailAddress;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_EMailAddress = value;
		}	
	}

	public TextBox ICQTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_ICQ;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_ICQ = value;
		}	
	}

	public TextBox CompanyTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_Company;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_Company = value;
		}	
	}

	public TextBox HomePhomeTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_HomePhome;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_HomePhome = value;
		}	
	}

	public TextBox WorkPhoneTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_WorkPhone;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_WorkPhone = value;
		}	
	}

	public TextBox PrivateCellularTextBox
	{	
		get
		{
			return this.textBox_UsersAccountsManagerForm_PrivateCellular;
		}
		
		set	
		{
			this.textBox_UsersAccountsManagerForm_PrivateCellular = value;
		}	
	}	
}

