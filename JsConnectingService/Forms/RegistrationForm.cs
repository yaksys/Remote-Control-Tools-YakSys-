using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;


public class RegistrationForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.LinkLabel linkLabel_YakSys;
	private System.Windows.Forms.GroupBox groupBox_KeyApply;
	private System.Windows.Forms.RichTextBox richTextBox_RegInfo;
	private System.Windows.Forms.Button button_Apply;
	private System.Windows.Forms.Label label_Name;
	private System.Windows.Forms.TextBox textBox_Name;
	private System.Windows.Forms.Button button_BuyOnline;
	private System.Windows.Forms.Label label_RegistrationNumber;
	private System.Windows.Forms.TextBox textBox_RegistrationNumber;
	private System.Windows.Forms.Button button_ContinueUnregistered;

	private System.ComponentModel.Container components = null;

	public RegistrationForm()
	{
		InitializeComponent();
	
		this.label_Name.Text = StringFactory.GetString(75, MainForm.CurrentLanguage);
		
		this.Text = this.groupBox_KeyApply.Text = StringFactory.GetString(76, MainForm.CurrentLanguage);
		
		this.label_RegistrationNumber.Text = StringFactory.GetString(77, MainForm.CurrentLanguage);
			
		this.richTextBox_RegInfo.Text = StringFactory.GetString(78, MainForm.CurrentLanguage);
		
		this.button_Apply.Text = StringFactory.GetString(79, MainForm.CurrentLanguage);
		
		this.button_BuyOnline.Text = StringFactory.GetString(80, MainForm.CurrentLanguage);
		
		this.button_ContinueUnregistered.Text = StringFactory.GetString(81, MainForm.CurrentLanguage);		
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
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RegistrationForm));
		this.groupBox_KeyApply = new System.Windows.Forms.GroupBox();
		this.richTextBox_RegInfo = new System.Windows.Forms.RichTextBox();
		this.button_Apply = new System.Windows.Forms.Button();
		this.label_RegistrationNumber = new System.Windows.Forms.Label();
		this.label_Name = new System.Windows.Forms.Label();
		this.textBox_RegistrationNumber = new System.Windows.Forms.TextBox();
		this.textBox_Name = new System.Windows.Forms.TextBox();
		this.button_BuyOnline = new System.Windows.Forms.Button();
		this.button_ContinueUnregistered = new System.Windows.Forms.Button();
		this.linkLabel_YakSys = new System.Windows.Forms.LinkLabel();
		this.groupBox_KeyApply.SuspendLayout();
		this.SuspendLayout();
		// 
		// groupBox_KeyApply
		// 
		this.groupBox_KeyApply.Controls.Add(this.richTextBox_RegInfo);
		this.groupBox_KeyApply.Controls.Add(this.button_Apply);
		this.groupBox_KeyApply.Controls.Add(this.label_RegistrationNumber);
		this.groupBox_KeyApply.Controls.Add(this.label_Name);
		this.groupBox_KeyApply.Controls.Add(this.textBox_RegistrationNumber);
		this.groupBox_KeyApply.Controls.Add(this.textBox_Name);
		this.groupBox_KeyApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.groupBox_KeyApply.Location = new System.Drawing.Point(16, 16);
		this.groupBox_KeyApply.Name = "groupBox_KeyApply";
		this.groupBox_KeyApply.Size = new System.Drawing.Size(408, 216);
		this.groupBox_KeyApply.TabIndex = 0;
		this.groupBox_KeyApply.TabStop = false;
		// 
		// richTextBox_RegInfo
		// 
		this.richTextBox_RegInfo.BackColor = System.Drawing.SystemColors.Control;
		this.richTextBox_RegInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.richTextBox_RegInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
		this.richTextBox_RegInfo.Location = new System.Drawing.Point(24, 32);
		this.richTextBox_RegInfo.Name = "richTextBox_RegInfo";
		this.richTextBox_RegInfo.ReadOnly = true;
		this.richTextBox_RegInfo.Size = new System.Drawing.Size(376, 64);
		this.richTextBox_RegInfo.TabIndex = 5;
		this.richTextBox_RegInfo.Text = String.Empty;
		// 
		// button_Apply
		// 
		this.button_Apply.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button_Apply.Location = new System.Drawing.Point(304, 176);
		this.button_Apply.Name = "button_Apply";
		this.button_Apply.TabIndex = 2;
		this.button_Apply.Text = "Apply";
		this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
		// 
		// label_RegistrationNumber
		// 
		this.label_RegistrationNumber.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_RegistrationNumber.Location = new System.Drawing.Point(24, 160);
		this.label_RegistrationNumber.Name = "label_RegistrationNumber";
		this.label_RegistrationNumber.Size = new System.Drawing.Size(232, 16);
		this.label_RegistrationNumber.TabIndex = 3;
		this.label_RegistrationNumber.Text = "Registration number:";
		// 
		// label_Name
		// 
		this.label_Name.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.label_Name.Location = new System.Drawing.Point(24, 104);
		this.label_Name.Name = "label_Name";
		this.label_Name.Size = new System.Drawing.Size(120, 16);
		this.label_Name.TabIndex = 2;
		this.label_Name.Text = "Name:";
		// 
		// textBox_RegistrationNumber
		// 
		this.textBox_RegistrationNumber.Location = new System.Drawing.Point(24, 176);
		this.textBox_RegistrationNumber.MaxLength = 20;
		this.textBox_RegistrationNumber.Name = "textBox_RegistrationNumber";
		this.textBox_RegistrationNumber.Size = new System.Drawing.Size(256, 20);
		this.textBox_RegistrationNumber.TabIndex = 1;
		this.textBox_RegistrationNumber.Text = String.Empty;
		// 
		// textBox_Name
		// 
		this.textBox_Name.Location = new System.Drawing.Point(24, 120);
		this.textBox_Name.Name = "textBox_Name";
		this.textBox_Name.Size = new System.Drawing.Size(256, 20);
		this.textBox_Name.TabIndex = 0;
		this.textBox_Name.Text = String.Empty;
		// 
		// button_BuyOnline
		// 
		this.button_BuyOnline.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button_BuyOnline.Location = new System.Drawing.Point(40, 248);
		this.button_BuyOnline.Name = "button_BuyOnline";
		this.button_BuyOnline.Size = new System.Drawing.Size(88, 23);
		this.button_BuyOnline.TabIndex = 3;
		this.button_BuyOnline.Text = "Buy online";
		this.button_BuyOnline.Click += new System.EventHandler(this.button_BuyOnline_Click);
		// 
		// button_ContinueUnregistered
		// 
		this.button_ContinueUnregistered.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button_ContinueUnregistered.Location = new System.Drawing.Point(136, 248);
		this.button_ContinueUnregistered.Name = "button_ContinueUnregistered";
		this.button_ContinueUnregistered.Size = new System.Drawing.Size(160, 23);
		this.button_ContinueUnregistered.TabIndex = 4;
		this.button_ContinueUnregistered.Text = "Continue Unregistered";
		this.button_ContinueUnregistered.Click += new System.EventHandler(this.button_ContinueUnregistered_Click);
		// 
		// linkLabel_YakSys
		// 
		this.linkLabel_YakSys.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.linkLabel_YakSys.Location = new System.Drawing.Point(304, 256);
		this.linkLabel_YakSys.Name = "linkLabel_YakSys";
		this.linkLabel_YakSys.Size = new System.Drawing.Size(120, 16);
		this.linkLabel_YakSys.TabIndex = 3;
		this.linkLabel_YakSys.TabStop = true;
		this.linkLabel_YakSys.Text = "http://www.YakSys.net";
		this.linkLabel_YakSys.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_YakSys_LinkClicked);
		// 
		// RegistrationForm
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(442, 282);
		this.ControlBox = false;
		this.Controls.Add(this.linkLabel_YakSys);
		this.Controls.Add(this.button_ContinueUnregistered);
		this.Controls.Add(this.button_BuyOnline);
		this.Controls.Add(this.groupBox_KeyApply);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "RegistrationForm";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.groupBox_KeyApply.ResumeLayout(false);
		this.ResumeLayout(false);

	}
		#endregion

	private void button_BuyOnline_Click(object sender, System.EventArgs e)
	{
		System.Diagnostics.Process.Start("https://secure.shareit.com/shareit/checkout.html?productid=207450&language=English");
	}

	private void button_Apply_Click(object sender, System.EventArgs e)
	{
		if(textBox_Name.Text.Length < 1 || textBox_RegistrationNumber.Text.Length < 1) 
		{
			MessageBox.Show(StringFactory.GetString(82, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));
			
			return;
		}
        //--
        /*
        if (ObjCopy.obj_MainForm.CheckSN(textBox_Name.Text, textBox_RegistrationNumber.Text) == 1) 
		{
			MessageBox.Show(StringFactory.GetString(83, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));
			
			Close();

			return;
		}	
			
		else MessageBox.Show(StringFactory.GetString(84, MainForm.CurrentLanguage), StringFactory.GetString(1, MainForm.CurrentLanguage));*/
	}

	private void button_ContinueUnregistered_Click(object sender, System.EventArgs e)
	{						
		Close();
	}

	private void linkLabel_YakSys_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
	{
		System.Diagnostics.Process.Start("http://www.YakSys.net");
	}	
}


