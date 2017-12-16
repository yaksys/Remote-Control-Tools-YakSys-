using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


public class AboutForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.PictureBox pictureBox_YakSysTitle;
	private System.Windows.Forms.RichTextBox richTextBox_About;
    private System.Windows.Forms.Label label_Title;
	private System.Windows.Forms.Button button_OK;
    private System.Windows.Forms.GroupBox groupBox_Contacts;
    private Button button_BuyNow;
    private Label label_ProductCopyOwner;
    private Label label_ProductSerialNumber;
    private Button button_ActivateSerialNumber;
    private TextBox textBox_ProductCopyOwner;
    private TextBox textBox_ProductSerialNumber;
    private Label label_ProductNotRegistered;
    private GroupBox groupBox_RegistrationInformation;

	private System.ComponentModel.Container components = null;

	public AboutForm()
	{
		InitializeComponent();

		this.richTextBox_About.Text = ServerStringFactory.GetString(2, MainForm.CurrentLanguage);

		this.Text = ServerStringFactory.GetString(3, MainForm.CurrentLanguage);
		
		this.button_BuyNow.Text = ServerStringFactory.GetString(80, MainForm.CurrentLanguage);
		
		this.groupBox_Contacts.Text = ServerStringFactory.GetString(89, MainForm.CurrentLanguage);

		this.label_Title.Text = ServerStringFactory.GetString(90, MainForm.CurrentLanguage);
			
		this.groupBox_RegistrationInformation.Text = ServerStringFactory.GetString(91, MainForm.CurrentLanguage);
	
		this.label_ProductCopyOwner.Text = ServerStringFactory.GetString(92, MainForm.CurrentLanguage);
		
		this.label_ProductSerialNumber.Text = ServerStringFactory.GetString(93, MainForm.CurrentLanguage);
	
		this.button_ActivateSerialNumber.Text = ServerStringFactory.GetString(94, MainForm.CurrentLanguage);
		
		this.label_ProductNotRegistered.Text = ServerStringFactory.GetString(95, MainForm.CurrentLanguage);

		
		if(CommonEnvironment.IsProductRegistered == true)
		{
			this.button_BuyNow.Visible = this.button_ActivateSerialNumber.Visible = false;
		
			this.textBox_ProductCopyOwner.Text = CommonEnvironment.ProductLicenceName;			
			this.textBox_ProductSerialNumber.Text = CommonEnvironment.ProductSerialNumber;
		}

		else
		{
			this.textBox_ProductCopyOwner.Visible = this.textBox_ProductSerialNumber.Visible = false;
				
			this.label_ProductCopyOwner.Visible = this.label_ProductSerialNumber.Visible = false;

			this.label_ProductNotRegistered.Visible = true;
		}

		this.label_ProductNotRegistered.Select();					
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
        this.pictureBox_YakSysTitle = new System.Windows.Forms.PictureBox();
        this.richTextBox_About = new System.Windows.Forms.RichTextBox();
        this.label_Title = new System.Windows.Forms.Label();
        this.button_OK = new System.Windows.Forms.Button();
        this.groupBox_Contacts = new System.Windows.Forms.GroupBox();
        this.button_BuyNow = new System.Windows.Forms.Button();
        this.label_ProductCopyOwner = new System.Windows.Forms.Label();
        this.label_ProductSerialNumber = new System.Windows.Forms.Label();
        this.button_ActivateSerialNumber = new System.Windows.Forms.Button();
        this.textBox_ProductCopyOwner = new System.Windows.Forms.TextBox();
        this.textBox_ProductSerialNumber = new System.Windows.Forms.TextBox();
        this.label_ProductNotRegistered = new System.Windows.Forms.Label();
        this.groupBox_RegistrationInformation = new System.Windows.Forms.GroupBox();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_YakSysTitle)).BeginInit();
        this.groupBox_Contacts.SuspendLayout();
        this.groupBox_RegistrationInformation.SuspendLayout();
        this.SuspendLayout();
        // 
        // pictureBox_YakSysTitle
        // 
        this.pictureBox_YakSysTitle.Cursor = System.Windows.Forms.Cursors.Hand;
        this.pictureBox_YakSysTitle.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_YakSysTitle.Image")));
        this.pictureBox_YakSysTitle.Location = new System.Drawing.Point(8, 8);
        this.pictureBox_YakSysTitle.Name = "pictureBox_YakSysTitle";
        this.pictureBox_YakSysTitle.Size = new System.Drawing.Size(155, 46);
        this.pictureBox_YakSysTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        this.pictureBox_YakSysTitle.TabIndex = 0;
        this.pictureBox_YakSysTitle.TabStop = false;
        this.pictureBox_YakSysTitle.Click += new System.EventHandler(this.pictureBox_YakSysTitle_Click);
        // 
        // richTextBox_About
        // 
        this.richTextBox_About.BackColor = System.Drawing.SystemColors.Control;
        this.richTextBox_About.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.richTextBox_About.ForeColor = System.Drawing.SystemColors.ControlText;
        this.richTextBox_About.Location = new System.Drawing.Point(8, 32);
        this.richTextBox_About.Name = "richTextBox_About";
        this.richTextBox_About.ReadOnly = true;
        this.richTextBox_About.Size = new System.Drawing.Size(240, 144);
        this.richTextBox_About.TabIndex = 1;
        this.richTextBox_About.Text = resources.GetString("richTextBox_About.Text");
        this.richTextBox_About.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_About_LinkClicked);
        // 
        // label_Title
        // 
        this.label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label_Title.Location = new System.Drawing.Point(8, 64);
        this.label_Title.Name = "label_Title";
        this.label_Title.Size = new System.Drawing.Size(251, 29);
        this.label_Title.TabIndex = 2;
        this.label_Title.Text = "YakSys Connecting Service 0.1.0 для Windows 2000/XP/2003";
        // 
        // button_OK
        // 
        this.button_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_OK.Location = new System.Drawing.Point(8, 292);
        this.button_OK.Name = "button_OK";
        this.button_OK.Size = new System.Drawing.Size(96, 23);
        this.button_OK.TabIndex = 4;
        this.button_OK.Text = "OK";
        this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
        // 
        // groupBox_Contacts
        // 
        this.groupBox_Contacts.Controls.Add(this.richTextBox_About);
        this.groupBox_Contacts.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_Contacts.Location = new System.Drawing.Point(8, 96);
        this.groupBox_Contacts.Name = "groupBox_Contacts";
        this.groupBox_Contacts.Size = new System.Drawing.Size(256, 184);
        this.groupBox_Contacts.TabIndex = 5;
        this.groupBox_Contacts.TabStop = false;
        this.groupBox_Contacts.Text = "Контактная информация";
        // 
        // button_BuyNow
        // 
        this.button_BuyNow.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_BuyNow.Location = new System.Drawing.Point(120, 144);
        this.button_BuyNow.Name = "button_BuyNow";
        this.button_BuyNow.Size = new System.Drawing.Size(96, 23);
        this.button_BuyNow.TabIndex = 3;
        this.button_BuyNow.Text = "Купить";
        this.button_BuyNow.Click += new System.EventHandler(this.button_BuyNow_Click);
        // 
        // label_ProductCopyOwner
        // 
        this.label_ProductCopyOwner.Location = new System.Drawing.Point(8, 40);
        this.label_ProductCopyOwner.Name = "label_ProductCopyOwner";
        this.label_ProductCopyOwner.Size = new System.Drawing.Size(208, 16);
        this.label_ProductCopyOwner.TabIndex = 1;
        this.label_ProductCopyOwner.Text = "Владельцем копии продукта явяется:";
        // 
        // label_ProductSerialNumber
        // 
        this.label_ProductSerialNumber.AutoSize = true;
        this.label_ProductSerialNumber.Location = new System.Drawing.Point(8, 88);
        this.label_ProductSerialNumber.Name = "label_ProductSerialNumber";
        this.label_ProductSerialNumber.Size = new System.Drawing.Size(212, 13);
        this.label_ProductSerialNumber.TabIndex = 2;
        this.label_ProductSerialNumber.Text = "Регистрационый номер копии продукта:";
        // 
        // button_ActivateSerialNumber
        // 
        this.button_ActivateSerialNumber.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ActivateSerialNumber.Location = new System.Drawing.Point(8, 144);
        this.button_ActivateSerialNumber.Name = "button_ActivateSerialNumber";
        this.button_ActivateSerialNumber.Size = new System.Drawing.Size(96, 23);
        this.button_ActivateSerialNumber.TabIndex = 2;
        this.button_ActivateSerialNumber.Text = "Активировать";
        this.button_ActivateSerialNumber.Click += new System.EventHandler(this.button_ActivateSerialNumber_Click);
        // 
        // textBox_ProductCopyOwner
        // 
        this.textBox_ProductCopyOwner.Location = new System.Drawing.Point(8, 56);
        this.textBox_ProductCopyOwner.Name = "textBox_ProductCopyOwner";
        this.textBox_ProductCopyOwner.ReadOnly = true;
        this.textBox_ProductCopyOwner.Size = new System.Drawing.Size(208, 20);
        this.textBox_ProductCopyOwner.TabIndex = 0;
        // 
        // textBox_ProductSerialNumber
        // 
        this.textBox_ProductSerialNumber.Location = new System.Drawing.Point(8, 104);
        this.textBox_ProductSerialNumber.Name = "textBox_ProductSerialNumber";
        this.textBox_ProductSerialNumber.ReadOnly = true;
        this.textBox_ProductSerialNumber.Size = new System.Drawing.Size(208, 20);
        this.textBox_ProductSerialNumber.TabIndex = 1;
        // 
        // label_ProductNotRegistered
        // 
        this.label_ProductNotRegistered.Location = new System.Drawing.Point(8, 24);
        this.label_ProductNotRegistered.Name = "label_ProductNotRegistered";
        this.label_ProductNotRegistered.Size = new System.Drawing.Size(208, 16);
        this.label_ProductNotRegistered.TabIndex = 6;
        this.label_ProductNotRegistered.Text = "Продукт не зарегистрирован.";
        this.label_ProductNotRegistered.Visible = false;
        // 
        // groupBox_RegistrationInformation
        // 
        this.groupBox_RegistrationInformation.Controls.Add(this.label_ProductNotRegistered);
        this.groupBox_RegistrationInformation.Controls.Add(this.textBox_ProductSerialNumber);
        this.groupBox_RegistrationInformation.Controls.Add(this.textBox_ProductCopyOwner);
        this.groupBox_RegistrationInformation.Controls.Add(this.button_ActivateSerialNumber);
        this.groupBox_RegistrationInformation.Controls.Add(this.label_ProductSerialNumber);
        this.groupBox_RegistrationInformation.Controls.Add(this.label_ProductCopyOwner);
        this.groupBox_RegistrationInformation.Controls.Add(this.button_BuyNow);
        this.groupBox_RegistrationInformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_RegistrationInformation.Location = new System.Drawing.Point(272, 96);
        this.groupBox_RegistrationInformation.Name = "groupBox_RegistrationInformation";
        this.groupBox_RegistrationInformation.Size = new System.Drawing.Size(232, 184);
        this.groupBox_RegistrationInformation.TabIndex = 3;
        this.groupBox_RegistrationInformation.TabStop = false;
        this.groupBox_RegistrationInformation.Text = "Регистрационная информация";
        // 
        // AboutForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(271, 327);
        this.Controls.Add(this.groupBox_Contacts);
        this.Controls.Add(this.button_OK);
        this.Controls.Add(this.groupBox_RegistrationInformation);
        this.Controls.Add(this.label_Title);
        this.Controls.Add(this.pictureBox_YakSysTitle);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(520, 352);
        this.MinimizeBox = false;
        this.Name = "AboutForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_YakSysTitle)).EndInit();
        this.groupBox_Contacts.ResumeLayout(false);
        this.groupBox_RegistrationInformation.ResumeLayout(false);
        this.groupBox_RegistrationInformation.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

	}
	#endregion

	private void richTextBox_About_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
	{
		System.Diagnostics.Process.Start(e.LinkText);
	}

	
	private void pictureBox_YakSysTitle_Click(object sender, System.EventArgs e)
	{
		System.Diagnostics.Process.Start("http://www.YakSys.net");
	}

	
	private void button_OK_Click(object sender, System.EventArgs e)
	{
		this.Close();
	}

	
	private void button_BuyNow_Click(object sender, System.EventArgs e)
	{
		System.Diagnostics.Process.Start("https://secure.shareit.com/shareit/checkout.html?productid=207450&language=English");
	}

	
	private void button_ActivateSerialNumber_Click(object sender, System.EventArgs e)
	{
		new RegistrationForm().ShowDialog();
	}	
}

