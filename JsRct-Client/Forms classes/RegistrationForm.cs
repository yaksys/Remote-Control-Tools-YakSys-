using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

public class RegistrationForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.LinkLabel linkLabel_JurikSoft;
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

        this.Text = ClientStringFactory.GetString(330, ClientSettingsEnvironment.CurrentLanguage);
        this.label_RegistrationNumber.Text = ClientStringFactory.GetString(335, ClientSettingsEnvironment.CurrentLanguage);
        this.label_Name.Text = ClientStringFactory.GetString(249, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_KeyApply.Text = ClientStringFactory.GetString(330, ClientSettingsEnvironment.CurrentLanguage);

        this.button_Apply.Text = ClientStringFactory.GetString(332, ClientSettingsEnvironment.CurrentLanguage);
        this.button_BuyOnline.Text = ClientStringFactory.GetString(333, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ContinueUnregistered.Text = ClientStringFactory.GetString(334, ClientSettingsEnvironment.CurrentLanguage);

        this.richTextBox_RegInfo.Text = ClientStringFactory.GetString(331, ClientSettingsEnvironment.CurrentLanguage);
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
        this.groupBox_KeyApply = new System.Windows.Forms.GroupBox();
        this.richTextBox_RegInfo = new System.Windows.Forms.RichTextBox();
        this.button_Apply = new System.Windows.Forms.Button();
        this.label_RegistrationNumber = new System.Windows.Forms.Label();
        this.label_Name = new System.Windows.Forms.Label();
        this.textBox_RegistrationNumber = new System.Windows.Forms.TextBox();
        this.textBox_Name = new System.Windows.Forms.TextBox();
        this.button_BuyOnline = new System.Windows.Forms.Button();
        this.button_ContinueUnregistered = new System.Windows.Forms.Button();
        this.linkLabel_JurikSoft = new System.Windows.Forms.LinkLabel();
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
        this.button_Apply.Size = new System.Drawing.Size(75, 23);
        this.button_Apply.TabIndex = 4;
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
        // 
        // textBox_Name
        // 
        this.textBox_Name.Location = new System.Drawing.Point(24, 120);
        this.textBox_Name.Name = "textBox_Name";
        this.textBox_Name.Size = new System.Drawing.Size(256, 20);
        this.textBox_Name.TabIndex = 0;
        // 
        // button_BuyOnline
        // 
        this.button_BuyOnline.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_BuyOnline.Location = new System.Drawing.Point(40, 248);
        this.button_BuyOnline.Name = "button_BuyOnline";
        this.button_BuyOnline.Size = new System.Drawing.Size(88, 23);
        this.button_BuyOnline.TabIndex = 1;
        this.button_BuyOnline.Text = "Buy online";
        this.button_BuyOnline.Click += new System.EventHandler(this.button_BuyOnline_Click);
        // 
        // button_ContinueUnregistered
        // 
        this.button_ContinueUnregistered.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ContinueUnregistered.Location = new System.Drawing.Point(136, 248);
        this.button_ContinueUnregistered.Name = "button_ContinueUnregistered";
        this.button_ContinueUnregistered.Size = new System.Drawing.Size(160, 23);
        this.button_ContinueUnregistered.TabIndex = 2;
        this.button_ContinueUnregistered.Text = "Continue Unregistered";
        this.button_ContinueUnregistered.Click += new System.EventHandler(this.button_ContinueUnregistered_Click);
        // 
        // linkLabel_JurikSoft
        // 
        this.linkLabel_JurikSoft.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.linkLabel_JurikSoft.Location = new System.Drawing.Point(304, 256);
        this.linkLabel_JurikSoft.Name = "linkLabel_JurikSoft";
        this.linkLabel_JurikSoft.Size = new System.Drawing.Size(120, 16);
        this.linkLabel_JurikSoft.TabIndex = 3;
        this.linkLabel_JurikSoft.TabStop = true;
        this.linkLabel_JurikSoft.Text = "http://www.yaksys.net";
        this.linkLabel_JurikSoft.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_JurikSoft_LinkClicked);
        // 
        // RegistrationForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(442, 282);
        this.ControlBox = false;
        this.Controls.Add(this.linkLabel_JurikSoft);
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
        this.Shown += new System.EventHandler(this.RegistrationForm_Shown);
        this.Closing += new System.ComponentModel.CancelEventHandler(this.RegistrationForm_Closing);
        this.groupBox_KeyApply.ResumeLayout(false);
        this.groupBox_KeyApply.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    private void button_BuyOnline_Click(object sender, System.EventArgs e)
    {
        System.Diagnostics.Process.Start("https://secure.shareit.com/shareit/checkout.html?productid=207450&language=English");
    }

    private void button_Apply_Click(object sender, System.EventArgs e)
    {
        if (this.textBox_Name.Text.Length < 1 || textBox_RegistrationNumber.Text.Length < 1)
        {
            MessageBox.Show(ClientStringFactory.GetString(336, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));
           
            return;
        }
        /*
        if (ObjCopy.obj_MainClientForm.CheckSN(textBox_Name.Text, textBox_RegistrationNumber.Text) == 1)
        {
            MessageBox.Show(ClientStringFactory.GetString(337, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));

            Close();

            return;
        }*/

        else
        {
            MessageBox.Show(ClientStringFactory.GetString(338, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));
        }
    }

    private void button_ContinueUnregistered_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }


    private void linkLabel_JurikSoft_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        System.Diagnostics.Process.Start("http://www.yaksys.net");
    }
    

    private void RegistrationForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        this.Close();
    }

    private void RegistrationForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }

}

