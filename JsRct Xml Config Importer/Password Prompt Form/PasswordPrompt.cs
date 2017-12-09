using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctServer.Version110;

public class PasswordPromptForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.GroupBox groupBox_PasswordVerivicationForm_Login;
    private System.Windows.Forms.Button button_PasswordPromptForm_Cancel;
    private System.Windows.Forms.TextBox textBox_PasswordPromptForm_Password;
    private System.Windows.Forms.Label label_PasswordPromptForm_Password;
    private System.Windows.Forms.Button button_PasswordPromptForm_Accept;
    private System.Windows.Forms.Label label_PasswordPromptForm_Descpription;

    private System.ComponentModel.Container components = null;

    public PasswordPromptForm()
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
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordPromptForm));
        this.groupBox_PasswordVerivicationForm_Login = new System.Windows.Forms.GroupBox();
        this.button_PasswordPromptForm_Cancel = new System.Windows.Forms.Button();
        this.textBox_PasswordPromptForm_Password = new System.Windows.Forms.TextBox();
        this.label_PasswordPromptForm_Password = new System.Windows.Forms.Label();
        this.button_PasswordPromptForm_Accept = new System.Windows.Forms.Button();
        this.label_PasswordPromptForm_Descpription = new System.Windows.Forms.Label();
        this.groupBox_PasswordVerivicationForm_Login.SuspendLayout();
        this.SuspendLayout();
        // 
        // groupBox_PasswordVerivicationForm_Login
        // 
        this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.button_PasswordPromptForm_Cancel);
        this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.textBox_PasswordPromptForm_Password);
        this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.label_PasswordPromptForm_Password);
        this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.button_PasswordPromptForm_Accept);
        this.groupBox_PasswordVerivicationForm_Login.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_PasswordVerivicationForm_Login.Location = new System.Drawing.Point(16, 64);
        this.groupBox_PasswordVerivicationForm_Login.Name = "groupBox_PasswordVerivicationForm_Login";
        this.groupBox_PasswordVerivicationForm_Login.Size = new System.Drawing.Size(208, 112);
        this.groupBox_PasswordVerivicationForm_Login.TabIndex = 10;
        this.groupBox_PasswordVerivicationForm_Login.TabStop = false;
        // 
        // button_PasswordPromptForm_Cancel
        // 
        this.button_PasswordPromptForm_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_PasswordPromptForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_PasswordPromptForm_Cancel.Location = new System.Drawing.Point(112, 72);
        this.button_PasswordPromptForm_Cancel.Name = "button_PasswordPromptForm_Cancel";
        this.button_PasswordPromptForm_Cancel.Size = new System.Drawing.Size(80, 23);
        this.button_PasswordPromptForm_Cancel.TabIndex = 2;
        this.button_PasswordPromptForm_Cancel.Text = "Cancel";
        this.button_PasswordPromptForm_Cancel.Click += new System.EventHandler(this.button_PasswordPromptForm_Cancel_Click);
        // 
        // textBox_PasswordPromptForm_Password
        // 
        this.textBox_PasswordPromptForm_Password.Location = new System.Drawing.Point(16, 40);
        this.textBox_PasswordPromptForm_Password.Name = "textBox_PasswordPromptForm_Password";
        this.textBox_PasswordPromptForm_Password.PasswordChar = '*';
        this.textBox_PasswordPromptForm_Password.Size = new System.Drawing.Size(176, 20);
        this.textBox_PasswordPromptForm_Password.TabIndex = 0;
        // 
        // label_PasswordPromptForm_Password
        // 
        this.label_PasswordPromptForm_Password.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_PasswordPromptForm_Password.Location = new System.Drawing.Point(16, 24);
        this.label_PasswordPromptForm_Password.Name = "label_PasswordPromptForm_Password";
        this.label_PasswordPromptForm_Password.Size = new System.Drawing.Size(176, 16);
        this.label_PasswordPromptForm_Password.TabIndex = 3;
        this.label_PasswordPromptForm_Password.Text = "Password:";
        // 
        // button_PasswordPromptForm_Accept
        // 
        this.button_PasswordPromptForm_Accept.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.button_PasswordPromptForm_Accept.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_PasswordPromptForm_Accept.Location = new System.Drawing.Point(16, 72);
        this.button_PasswordPromptForm_Accept.Name = "button_PasswordPromptForm_Accept";
        this.button_PasswordPromptForm_Accept.Size = new System.Drawing.Size(80, 23);
        this.button_PasswordPromptForm_Accept.TabIndex = 1;
        this.button_PasswordPromptForm_Accept.Text = "Accept";
        this.button_PasswordPromptForm_Accept.Click += new System.EventHandler(this.button_PasswordPromptForm_Accept_Click);
        // 
        // label_PasswordPromptForm_Descpription
        // 
        this.label_PasswordPromptForm_Descpription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label_PasswordPromptForm_Descpription.Location = new System.Drawing.Point(16, 8);
        this.label_PasswordPromptForm_Descpription.Name = "label_PasswordPromptForm_Descpription";
        this.label_PasswordPromptForm_Descpription.Size = new System.Drawing.Size(216, 48);
        this.label_PasswordPromptForm_Descpription.TabIndex = 11;
        this.label_PasswordPromptForm_Descpription.Text = "Selected DataBase file was encrypted. Please enter password to decrypt data.";
        this.label_PasswordPromptForm_Descpription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // PasswordPromptForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(242, 192);
        this.Controls.Add(this.label_PasswordPromptForm_Descpription);
        this.Controls.Add(this.groupBox_PasswordVerivicationForm_Login);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "PasswordPromptForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.groupBox_PasswordVerivicationForm_Login.ResumeLayout(false);
        this.groupBox_PasswordVerivicationForm_Login.PerformLayout();
        this.ResumeLayout(false);

    }
    #endregion

    private void button_PasswordPromptForm_Cancel_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }



    public void ChangeControlsLanguage()
    {
        this.Text = ServerStringFactory.GetString(117, ServerSettingsEnvironment.CurrentLanguage);

        this.label_PasswordPromptForm_Password.Text = ServerStringFactory.GetString(16, ServerSettingsEnvironment.CurrentLanguage);

        this.label_PasswordPromptForm_Descpription.Text = ServerStringFactory.GetString(151, ServerSettingsEnvironment.CurrentLanguage);

        this.button_PasswordPromptForm_Cancel.Text = ServerStringFactory.GetString(86, ServerSettingsEnvironment.CurrentLanguage);

        this.button_PasswordPromptForm_Accept.Text = ServerStringFactory.GetString(119, ServerSettingsEnvironment.CurrentLanguage);
    }
    
    string string_DBPassword = String.Empty;

    public string DBPassword
    {
        set
        {
            string_DBPassword = value;
        }
        get
        {
            return string_DBPassword;
        }
    }

    private void button_PasswordPromptForm_Accept_Click(object sender, System.EventArgs e)
    {
        DBPassword = this.textBox_PasswordPromptForm_Password.Text;
    }  

}

