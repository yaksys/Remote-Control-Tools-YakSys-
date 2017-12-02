using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using JsConnectingService;

public class ServersAccountsManagerForm : System.Windows.Forms.Form
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
        this.Text = StringFactory.GetString(129, MainForm.CurrentLanguage);

        this.groupBox_UsersAccountsManagerForm_AccountInformation.Text = StringFactory.GetString(140, MainForm.CurrentLanguage);
        this.groupBox_UsersAccountsManagerForm_AdditionalInformation.Text = StringFactory.GetString(141, MainForm.CurrentLanguage);

        this.label_UsersAccountsManagerForm_Login.Text = StringFactory.GetString(17, MainForm.CurrentLanguage);
        this.label_UsersAccountsManagerForm_UserName.Text = StringFactory.GetString(142, MainForm.CurrentLanguage);
        this.label_UsersAccountsManagerForm_NewPassword.Text = StringFactory.GetString(16, MainForm.CurrentLanguage);
        this.label_UsersAccountsManagerForm_ConfirmedPassword.Text = StringFactory.GetString(130, MainForm.CurrentLanguage);

        this.label_UsersAccountsManagerForm_FirstName.Text = StringFactory.GetString(131, MainForm.CurrentLanguage);
        this.label_UsersAccountsManagerForm_LastName.Text = StringFactory.GetString(132, MainForm.CurrentLanguage);
        this.label_UsersAccountsManagerForm_MiddleName.Text = StringFactory.GetString(133, MainForm.CurrentLanguage);
        this.label_UsersAccountsManagerForm_EMailAddress.Text = StringFactory.GetString(134, MainForm.CurrentLanguage);
        this.label_UsersAccountsManagerForm_ICQ.Text = StringFactory.GetString(135, MainForm.CurrentLanguage);
        this.label_UsersAccountsManagerForm_Company.Text = StringFactory.GetString(136, MainForm.CurrentLanguage);
        this.label_UsersAccountsManagerForm_HomePhone.Text = StringFactory.GetString(137, MainForm.CurrentLanguage);
        this.label_UsersAccountsManagerForm_WorkPhone.Text = StringFactory.GetString(138, MainForm.CurrentLanguage);
        this.label_UsersAccountsManagerForm_PrivateCellular.Text = StringFactory.GetString(139, MainForm.CurrentLanguage);

        this.button_UsersAccountsManagerForm_Add.Text = StringFactory.GetString(23, MainForm.CurrentLanguage);
        this.button_UsersAccountsManagerForm_Apply.Text = StringFactory.GetString(79, MainForm.CurrentLanguage);
        this.button_UsersAccountsManagerForm_Cancel.Text = StringFactory.GetString(86, MainForm.CurrentLanguage);
    }


    public ServersAccountsManagerForm()
    {
        InitializeComponent();

        ChangeControlsLanguage();
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

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServersAccountsManagerForm));
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
        // 
        // textBox_UsersAccountsManagerForm_EMailAddress
        // 
        this.textBox_UsersAccountsManagerForm_EMailAddress.Location = new System.Drawing.Point(16, 96);
        this.textBox_UsersAccountsManagerForm_EMailAddress.Name = "textBox_UsersAccountsManagerForm_EMailAddress";
        this.textBox_UsersAccountsManagerForm_EMailAddress.Size = new System.Drawing.Size(136, 20);
        this.textBox_UsersAccountsManagerForm_EMailAddress.TabIndex = 7;
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
        this.textBox_UsersAccountsManagerForm_Login.MaxLength = 10;
        this.textBox_UsersAccountsManagerForm_Login.Name = "textBox_UsersAccountsManagerForm_Login";
        this.textBox_UsersAccountsManagerForm_Login.Size = new System.Drawing.Size(128, 20);
        this.textBox_UsersAccountsManagerForm_Login.TabIndex = 0;
        this.textBox_UsersAccountsManagerForm_Login.TextChanged += new System.EventHandler(this.textBox_UsersAccountsManagerForm_Login_TextChanged);
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
        // ServersAccountsManagerForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(802, 223);
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
        this.Name = "ServersAccountsManagerForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "User account manager";
        this.groupBox_UsersAccountsManagerForm_AccountInformation.ResumeLayout(false);
        this.groupBox_UsersAccountsManagerForm_AccountInformation.PerformLayout();
        this.groupBox_UsersAccountsManagerForm_AdditionalInformation.ResumeLayout(false);
        this.groupBox_UsersAccountsManagerForm_AdditionalInformation.PerformLayout();
        this.ResumeLayout(false);

    }
    #endregion

    private void button_UsersAccountsManagerForm_Add_Click(object sender, System.EventArgs e)
    {
        if (this.textBox_UsersAccountsManagerForm_Login.Text.Length == 0
        || this.textBox_UsersAccountsManagerForm_NewPassword.Text.Length == 0
        || this.textBox_UsersAccountsManagerForm_ConfirmedPassword.Text.Length == 0
        || this.textBox_UsersAccountsManagerForm_UserName.Text.Length == 0)
        {
            MessageBox.Show(StringFactory.GetString(60, MainForm.CurrentLanguage),
            StringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return;
        }

        if (this.textBox_UsersAccountsManagerForm_ConfirmedPassword.Text.Length < 6)
        {
            MessageBox.Show("password length can't be less than 6 characters");

            return;
        }

        for (int int_intCycleCount = 0; int_intCycleCount != ServersNetworkSecurity.UserAccount.UsersAccounts.Count; int_intCycleCount++)
        {
            if (ServersNetworkSecurity.UserAccount.UsersAccounts[int_intCycleCount].UIN == this.textBox_UsersAccountsManagerForm_Login.Text)
            {
                MessageBox.Show(StringFactory.GetString(61, MainForm.CurrentLanguage),
                StringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
        }

        if (this.textBox_UsersAccountsManagerForm_NewPassword.Text != this.textBox_UsersAccountsManagerForm_ConfirmedPassword.Text)
        {
            MessageBox.Show(StringFactory.GetString(115, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return;
        }

            
        ServersNetworkSecurity.UserAccount userAccount_NewAccount = new ServersNetworkSecurity.UserAccount();

        userAccount_NewAccount.FirstName = this.textBox_UsersAccountsManagerForm_FirstName.Text;
        userAccount_NewAccount.SecondName = this.textBox_UsersAccountsManagerForm_MiddleName.Text;
        userAccount_NewAccount.LastName = this.textBox_UsersAccountsManagerForm_LastName.Text;

        userAccount_NewAccount.ICQ = this.textBox_UsersAccountsManagerForm_ICQ.Text;
        userAccount_NewAccount.EMail = this.textBox_UsersAccountsManagerForm_EMailAddress.Text;

        userAccount_NewAccount.Work = this.textBox_UsersAccountsManagerForm_Company.Text;

        userAccount_NewAccount.HomePhone = this.textBox_UsersAccountsManagerForm_HomePhome.Text;
        userAccount_NewAccount.WorkPhone = this.textBox_UsersAccountsManagerForm_WorkPhone.Text;
        userAccount_NewAccount.MobilePhone = this.textBox_UsersAccountsManagerForm_PrivateCellular.Text;;

        userAccount_NewAccount.ActivationCode = 0;

        userAccount_NewAccount.IsEnabled = true;
        userAccount_NewAccount.IsActivated = true;

        userAccount_NewAccount.Password = this.textBox_UsersAccountsManagerForm_NewPassword.Text;
        userAccount_NewAccount.UIN =  this.textBox_UsersAccountsManagerForm_Login.Text;
        userAccount_NewAccount.UserName = this.textBox_UsersAccountsManagerForm_UserName.Text;

        userAccount_NewAccount.CreationTime = DateTime.Now;
        userAccount_NewAccount.ActivationTime = DateTime.Now;

        if (ServersNetworkSecurity.AddNewUser(userAccount_NewAccount) == true)
        {
            ConnectingServiceLogsEvents.NewServersLogRecordEvent(StringFactory.GetString(44, MainForm.CurrentLanguage), DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), userAccount_NewAccount.UserName, userAccount_NewAccount.UIN,
                                                                 StringFactory.GetString(1, MainForm.CurrentLanguage), StringFactory.GetString(45, MainForm.CurrentLanguage), false);
            
            ServersNetworkSecurity.StoreNewServerUserAccountToDB(userAccount_NewAccount);
        }

        this.Close();
    }

    private void button_UsersAccountsManagerForm_Apply_Click(object sender, System.EventArgs e)
    {
        DataSet_ConnectingServiceDB.ServersSecurityDataBaseDataTable ServersSecurityDataBaseDataTable_obj = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersSecurityDataBase;

        DataRow dataRow_EditedRecord = null;

        DateTime dateTime_CreationTime = DateTime.Now;

        dataRow_EditedRecord = ConnectingServiceDBSupplier.ConnectingServiceDB.ServersAccessRestrictionRules[EditedRecordIndex];

        dataRow_EditedRecord[ServersSecurityDataBaseDataTable_obj.UserNameColumn] = this.textBox_UsersAccountsManagerForm_FirstName.Text;
        dataRow_EditedRecord[ServersSecurityDataBaseDataTable_obj.UserLastNameColumn] = this.textBox_UsersAccountsManagerForm_LastName.Text;
        dataRow_EditedRecord[ServersSecurityDataBaseDataTable_obj.UserMiddleNameColumn] = this.textBox_UsersAccountsManagerForm_MiddleName.Text;
        dataRow_EditedRecord[ServersSecurityDataBaseDataTable_obj.EMailColumn] = this.textBox_UsersAccountsManagerForm_EMailAddress.Text;
        dataRow_EditedRecord[ServersSecurityDataBaseDataTable_obj.ICQColumn] = this.textBox_UsersAccountsManagerForm_ICQ.Text;
        dataRow_EditedRecord[ServersSecurityDataBaseDataTable_obj.CompanyColumn] = this.textBox_UsersAccountsManagerForm_Company.Text;
        dataRow_EditedRecord[ServersSecurityDataBaseDataTable_obj.WorkPhoneColumn] = this.textBox_UsersAccountsManagerForm_WorkPhone.Text;
        dataRow_EditedRecord[ServersSecurityDataBaseDataTable_obj.HomePhoneColumn] = this.textBox_UsersAccountsManagerForm_HomePhome.Text;
        dataRow_EditedRecord[ServersSecurityDataBaseDataTable_obj.PrivateCellularColumn] = this.textBox_UsersAccountsManagerForm_PrivateCellular.Text;
        dataRow_EditedRecord[ServersSecurityDataBaseDataTable_obj.CreationTimeColumn] = dateTime_CreationTime;

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

    private void textBox_UsersAccountsManagerForm_Login_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int int_TextLength = 0;

            for (int int_CycleCount = 0; int_CycleCount != textBox_UsersAccountsManagerForm_Login.Text.Length; int_CycleCount++)
            {
                if (char.IsDigit(this.textBox_UsersAccountsManagerForm_Login.Text[int_CycleCount]) == false)
                {
                    int_TextLength = this.textBox_UsersAccountsManagerForm_Login.SelectionStart - 1;

                    this.textBox_UsersAccountsManagerForm_Login.Text = this.textBox_UsersAccountsManagerForm_Login.Text.Remove(int_CycleCount, 1);

                    if (int_TextLength < 0) int_TextLength = 0;

                    this.textBox_UsersAccountsManagerForm_Login.SelectionStart = int_TextLength;

                    int_CycleCount = 0;
                }
            }
        }
        catch
        {
        }
    }

}

