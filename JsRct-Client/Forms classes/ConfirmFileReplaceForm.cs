using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

public class ConfirmFileReplaceForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.Label label_ConfirmFileReplaceForm_Information;
    private System.Windows.Forms.Button button_ConfirmFileReplaceForm_NoToAll;
    private System.Windows.Forms.Button button_ConfirmFileReplaceForm_YesToAll;
    private System.Windows.Forms.Button button_ConfirmFileReplaceForm_No;
    private System.Windows.Forms.Button button_ConfirmFileReplaceForm_Yes;
    private System.Windows.Forms.Label label_ConfirmFileReplaceForm_LocalFileName;
    private System.Windows.Forms.TextBox textBox_ConfirmFileReplaceForm_LocalFileName;
    private System.Windows.Forms.GroupBox groupBox_ConfirmFileReplaceForm_LocalSide;
    private System.Windows.Forms.Label label_ConfirmFileReplaceForm_LocalFileSize;
    private System.Windows.Forms.TextBox textBox_ConfirmFileReplaceForm_LocalFileSize;
    private System.Windows.Forms.TextBox textBox_ConfirmFileReplaceForm_LocalFileLastWriteTime;
    private System.Windows.Forms.Label label_ConfirmFileReplaceForm_LocalFileLastWriteTime;
    private System.Windows.Forms.GroupBox groupBox_ConfirmFileReplaceForm_RemoteSide;
    private System.Windows.Forms.Label label_ConfirmFileReplaceForm_RemoteFileLastWriteTime;
    private System.Windows.Forms.TextBox textBox_ConfirmFileReplaceForm_RemoteFileLastWriteTime;
    private System.Windows.Forms.TextBox textBox_ConfirmFileReplaceForm_RemoteFileSize;
    private System.Windows.Forms.Label label_ConfirmFileReplaceForm_RemoteFileSize;
    private System.Windows.Forms.TextBox textBox_ConfirmFileReplaceForm_RemoteFileName;
    private System.Windows.Forms.Label label_ConfirmFileReplaceForm_RemoteFileName;

    private System.ComponentModel.Container components = null;


    public void ChangeControlsLanguage()
    {
        this.label_ConfirmFileReplaceForm_LocalFileName.Text = ClientStringFactory.GetString(274, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ConfirmFileReplaceForm_RemoteFileName.Text = ClientStringFactory.GetString(274, ClientSettingsEnvironment.CurrentLanguage);

        this.label_ConfirmFileReplaceForm_LocalFileSize.Text = ClientStringFactory.GetString(91, ClientSettingsEnvironment.CurrentLanguage) + ":";
        this.label_ConfirmFileReplaceForm_RemoteFileSize.Text = ClientStringFactory.GetString(91, ClientSettingsEnvironment.CurrentLanguage) + ":";

        this.label_ConfirmFileReplaceForm_LocalFileLastWriteTime.Text = ClientStringFactory.GetString(92, ClientSettingsEnvironment.CurrentLanguage) + ":";
        this.label_ConfirmFileReplaceForm_RemoteFileLastWriteTime.Text = ClientStringFactory.GetString(92, ClientSettingsEnvironment.CurrentLanguage) + ":";

        this.button_ConfirmFileReplaceForm_NoToAll.Text = ClientStringFactory.GetString(272, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ConfirmFileReplaceForm_YesToAll.Text = ClientStringFactory.GetString(273, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ConfirmFileReplaceForm_No.Text = ClientStringFactory.GetString(267, ClientSettingsEnvironment.CurrentLanguage);
        this.button_ConfirmFileReplaceForm_Yes.Text = ClientStringFactory.GetString(270, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_ConfirmFileReplaceForm_LocalSide.Text = ClientStringFactory.GetString(276, ClientSettingsEnvironment.CurrentLanguage);
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.Text = ClientStringFactory.GetString(277, ClientSettingsEnvironment.CurrentLanguage);

        this.Text = ClientStringFactory.GetString(275, ClientSettingsEnvironment.CurrentLanguage);

        if (int_SelectedDialogType == 1) this.label_ConfirmFileReplaceForm_Information.Text = ClientStringFactory.GetString(258, ClientSettingsEnvironment.CurrentLanguage);
        if (int_SelectedDialogType == 0) this.label_ConfirmFileReplaceForm_Information.Text = ClientStringFactory.GetString(278, ClientSettingsEnvironment.CurrentLanguage);
    }


    int int_SelectedDialogType = 0;

    public ConfirmFileReplaceForm(int int_DialogType,
           string string_LocalFileName, string string_LocalFileSize, string string_LocalFileLastWriteTime,
           string string_RemoteFileName, string string_RemoteFileSize, string string_RemoteFileLastWriteTime)
    {
        InitializeComponent();

        int_SelectedDialogType = int_DialogType;

        ChangeControlsLanguage();

        for (int int_LastDotPosition = string_LocalFileSize.Length; int_LastDotPosition - 3 >= 1; int_LastDotPosition -= 3)
        {
            string_LocalFileSize = string_LocalFileSize.Insert(int_LastDotPosition - 3, ", ");
        }

        for (int int_LastDotPosition = string_RemoteFileSize.Length; int_LastDotPosition - 3 >= 1; int_LastDotPosition -= 3)
        {
            string_RemoteFileSize = string_RemoteFileSize.Insert(int_LastDotPosition - 3, ", ");
        }

        this.textBox_ConfirmFileReplaceForm_LocalFileName.Text = string_LocalFileName;
        this.textBox_ConfirmFileReplaceForm_LocalFileSize.Text = string_LocalFileSize;
        this.textBox_ConfirmFileReplaceForm_LocalFileLastWriteTime.Text = string_LocalFileLastWriteTime;

        this.textBox_ConfirmFileReplaceForm_RemoteFileName.Text = string_RemoteFileName;
        this.textBox_ConfirmFileReplaceForm_RemoteFileSize.Text = string_RemoteFileSize;
        this.textBox_ConfirmFileReplaceForm_RemoteFileLastWriteTime.Text = string_RemoteFileLastWriteTime;
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmFileReplaceForm));
        this.label_ConfirmFileReplaceForm_LocalFileName = new System.Windows.Forms.Label();
        this.textBox_ConfirmFileReplaceForm_LocalFileName = new System.Windows.Forms.TextBox();
        this.label_ConfirmFileReplaceForm_Information = new System.Windows.Forms.Label();
        this.button_ConfirmFileReplaceForm_NoToAll = new System.Windows.Forms.Button();
        this.button_ConfirmFileReplaceForm_YesToAll = new System.Windows.Forms.Button();
        this.button_ConfirmFileReplaceForm_No = new System.Windows.Forms.Button();
        this.button_ConfirmFileReplaceForm_Yes = new System.Windows.Forms.Button();
        this.groupBox_ConfirmFileReplaceForm_LocalSide = new System.Windows.Forms.GroupBox();
        this.label_ConfirmFileReplaceForm_LocalFileLastWriteTime = new System.Windows.Forms.Label();
        this.textBox_ConfirmFileReplaceForm_LocalFileLastWriteTime = new System.Windows.Forms.TextBox();
        this.textBox_ConfirmFileReplaceForm_LocalFileSize = new System.Windows.Forms.TextBox();
        this.label_ConfirmFileReplaceForm_LocalFileSize = new System.Windows.Forms.Label();
        this.groupBox_ConfirmFileReplaceForm_RemoteSide = new System.Windows.Forms.GroupBox();
        this.label_ConfirmFileReplaceForm_RemoteFileLastWriteTime = new System.Windows.Forms.Label();
        this.textBox_ConfirmFileReplaceForm_RemoteFileLastWriteTime = new System.Windows.Forms.TextBox();
        this.textBox_ConfirmFileReplaceForm_RemoteFileSize = new System.Windows.Forms.TextBox();
        this.label_ConfirmFileReplaceForm_RemoteFileSize = new System.Windows.Forms.Label();
        this.textBox_ConfirmFileReplaceForm_RemoteFileName = new System.Windows.Forms.TextBox();
        this.label_ConfirmFileReplaceForm_RemoteFileName = new System.Windows.Forms.Label();
        this.groupBox_ConfirmFileReplaceForm_LocalSide.SuspendLayout();
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.SuspendLayout();
        this.SuspendLayout();
        // 
        // label_ConfirmFileReplaceForm_LocalFileName
        // 
        this.label_ConfirmFileReplaceForm_LocalFileName.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ConfirmFileReplaceForm_LocalFileName.Location = new System.Drawing.Point(8, 24);
        this.label_ConfirmFileReplaceForm_LocalFileName.Name = "label_ConfirmFileReplaceForm_LocalFileName";
        this.label_ConfirmFileReplaceForm_LocalFileName.Size = new System.Drawing.Size(120, 16);
        this.label_ConfirmFileReplaceForm_LocalFileName.TabIndex = 27;
        this.label_ConfirmFileReplaceForm_LocalFileName.Text = "File name:";
        // 
        // textBox_ConfirmFileReplaceForm_LocalFileName
        // 
        this.textBox_ConfirmFileReplaceForm_LocalFileName.Location = new System.Drawing.Point(128, 24);
        this.textBox_ConfirmFileReplaceForm_LocalFileName.Name = "textBox_ConfirmFileReplaceForm_LocalFileName";
        this.textBox_ConfirmFileReplaceForm_LocalFileName.ReadOnly = true;
        this.textBox_ConfirmFileReplaceForm_LocalFileName.Size = new System.Drawing.Size(128, 20);
        this.textBox_ConfirmFileReplaceForm_LocalFileName.TabIndex = 26;
        // 
        // label_ConfirmFileReplaceForm_Information
        // 
        this.label_ConfirmFileReplaceForm_Information.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ConfirmFileReplaceForm_Information.Location = new System.Drawing.Point(8, 8);
        this.label_ConfirmFileReplaceForm_Information.Name = "label_ConfirmFileReplaceForm_Information";
        this.label_ConfirmFileReplaceForm_Information.Size = new System.Drawing.Size(560, 32);
        this.label_ConfirmFileReplaceForm_Information.TabIndex = 25;
        this.label_ConfirmFileReplaceForm_Information.Text = "Information...";
        // 
        // button_ConfirmFileReplaceForm_NoToAll
        // 
        this.button_ConfirmFileReplaceForm_NoToAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ConfirmFileReplaceForm_NoToAll.Location = new System.Drawing.Point(480, 176);
        this.button_ConfirmFileReplaceForm_NoToAll.Name = "button_ConfirmFileReplaceForm_NoToAll";
        this.button_ConfirmFileReplaceForm_NoToAll.Size = new System.Drawing.Size(80, 23);
        this.button_ConfirmFileReplaceForm_NoToAll.TabIndex = 24;
        this.button_ConfirmFileReplaceForm_NoToAll.Text = "No to All";
        this.button_ConfirmFileReplaceForm_NoToAll.Click += new System.EventHandler(this.button_ConfirmFileReplaceForm_NoToAll_Click);
        // 
        // button_ConfirmFileReplaceForm_YesToAll
        // 
        this.button_ConfirmFileReplaceForm_YesToAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ConfirmFileReplaceForm_YesToAll.Location = new System.Drawing.Point(112, 176);
        this.button_ConfirmFileReplaceForm_YesToAll.Name = "button_ConfirmFileReplaceForm_YesToAll";
        this.button_ConfirmFileReplaceForm_YesToAll.Size = new System.Drawing.Size(80, 23);
        this.button_ConfirmFileReplaceForm_YesToAll.TabIndex = 23;
        this.button_ConfirmFileReplaceForm_YesToAll.Text = "Yes to All";
        this.button_ConfirmFileReplaceForm_YesToAll.Click += new System.EventHandler(this.button_ConfirmFileReplaceForm_YesToAll_Click);
        // 
        // button_ConfirmFileReplaceForm_No
        // 
        this.button_ConfirmFileReplaceForm_No.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ConfirmFileReplaceForm_No.Location = new System.Drawing.Point(384, 176);
        this.button_ConfirmFileReplaceForm_No.Name = "button_ConfirmFileReplaceForm_No";
        this.button_ConfirmFileReplaceForm_No.Size = new System.Drawing.Size(75, 23);
        this.button_ConfirmFileReplaceForm_No.TabIndex = 22;
        this.button_ConfirmFileReplaceForm_No.Text = "No";
        this.button_ConfirmFileReplaceForm_No.Click += new System.EventHandler(this.button_ConfirmFileReplaceForm_No_Click);
        // 
        // button_ConfirmFileReplaceForm_Yes
        // 
        this.button_ConfirmFileReplaceForm_Yes.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ConfirmFileReplaceForm_Yes.Location = new System.Drawing.Point(16, 176);
        this.button_ConfirmFileReplaceForm_Yes.Name = "button_ConfirmFileReplaceForm_Yes";
        this.button_ConfirmFileReplaceForm_Yes.Size = new System.Drawing.Size(75, 23);
        this.button_ConfirmFileReplaceForm_Yes.TabIndex = 21;
        this.button_ConfirmFileReplaceForm_Yes.Text = "Yes";
        this.button_ConfirmFileReplaceForm_Yes.Click += new System.EventHandler(this.button_ConfirmFileReplaceForm_Yes_Click);
        // 
        // groupBox_ConfirmFileReplaceForm_LocalSide
        // 
        this.groupBox_ConfirmFileReplaceForm_LocalSide.Controls.Add(this.label_ConfirmFileReplaceForm_LocalFileLastWriteTime);
        this.groupBox_ConfirmFileReplaceForm_LocalSide.Controls.Add(this.textBox_ConfirmFileReplaceForm_LocalFileLastWriteTime);
        this.groupBox_ConfirmFileReplaceForm_LocalSide.Controls.Add(this.textBox_ConfirmFileReplaceForm_LocalFileSize);
        this.groupBox_ConfirmFileReplaceForm_LocalSide.Controls.Add(this.label_ConfirmFileReplaceForm_LocalFileSize);
        this.groupBox_ConfirmFileReplaceForm_LocalSide.Controls.Add(this.textBox_ConfirmFileReplaceForm_LocalFileName);
        this.groupBox_ConfirmFileReplaceForm_LocalSide.Controls.Add(this.label_ConfirmFileReplaceForm_LocalFileName);
        this.groupBox_ConfirmFileReplaceForm_LocalSide.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ConfirmFileReplaceForm_LocalSide.Location = new System.Drawing.Point(8, 48);
        this.groupBox_ConfirmFileReplaceForm_LocalSide.Name = "groupBox_ConfirmFileReplaceForm_LocalSide";
        this.groupBox_ConfirmFileReplaceForm_LocalSide.Size = new System.Drawing.Size(272, 120);
        this.groupBox_ConfirmFileReplaceForm_LocalSide.TabIndex = 28;
        this.groupBox_ConfirmFileReplaceForm_LocalSide.TabStop = false;
        this.groupBox_ConfirmFileReplaceForm_LocalSide.Text = "Local Side";
        // 
        // label_ConfirmFileReplaceForm_LocalFileLastWriteTime
        // 
        this.label_ConfirmFileReplaceForm_LocalFileLastWriteTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ConfirmFileReplaceForm_LocalFileLastWriteTime.Location = new System.Drawing.Point(8, 88);
        this.label_ConfirmFileReplaceForm_LocalFileLastWriteTime.Name = "label_ConfirmFileReplaceForm_LocalFileLastWriteTime";
        this.label_ConfirmFileReplaceForm_LocalFileLastWriteTime.Size = new System.Drawing.Size(120, 16);
        this.label_ConfirmFileReplaceForm_LocalFileLastWriteTime.TabIndex = 31;
        this.label_ConfirmFileReplaceForm_LocalFileLastWriteTime.Text = "Last Write Time:";
        // 
        // textBox_ConfirmFileReplaceForm_LocalFileLastWriteTime
        // 
        this.textBox_ConfirmFileReplaceForm_LocalFileLastWriteTime.Location = new System.Drawing.Point(128, 88);
        this.textBox_ConfirmFileReplaceForm_LocalFileLastWriteTime.Name = "textBox_ConfirmFileReplaceForm_LocalFileLastWriteTime";
        this.textBox_ConfirmFileReplaceForm_LocalFileLastWriteTime.ReadOnly = true;
        this.textBox_ConfirmFileReplaceForm_LocalFileLastWriteTime.Size = new System.Drawing.Size(128, 20);
        this.textBox_ConfirmFileReplaceForm_LocalFileLastWriteTime.TabIndex = 30;
        // 
        // textBox_ConfirmFileReplaceForm_LocalFileSize
        // 
        this.textBox_ConfirmFileReplaceForm_LocalFileSize.Location = new System.Drawing.Point(128, 56);
        this.textBox_ConfirmFileReplaceForm_LocalFileSize.Name = "textBox_ConfirmFileReplaceForm_LocalFileSize";
        this.textBox_ConfirmFileReplaceForm_LocalFileSize.ReadOnly = true;
        this.textBox_ConfirmFileReplaceForm_LocalFileSize.Size = new System.Drawing.Size(128, 20);
        this.textBox_ConfirmFileReplaceForm_LocalFileSize.TabIndex = 29;
        // 
        // label_ConfirmFileReplaceForm_LocalFileSize
        // 
        this.label_ConfirmFileReplaceForm_LocalFileSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ConfirmFileReplaceForm_LocalFileSize.Location = new System.Drawing.Point(8, 56);
        this.label_ConfirmFileReplaceForm_LocalFileSize.Name = "label_ConfirmFileReplaceForm_LocalFileSize";
        this.label_ConfirmFileReplaceForm_LocalFileSize.Size = new System.Drawing.Size(120, 16);
        this.label_ConfirmFileReplaceForm_LocalFileSize.TabIndex = 28;
        this.label_ConfirmFileReplaceForm_LocalFileSize.Text = "File Size (Bytes):";
        // 
        // groupBox_ConfirmFileReplaceForm_RemoteSide
        // 
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.Controls.Add(this.label_ConfirmFileReplaceForm_RemoteFileLastWriteTime);
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.Controls.Add(this.textBox_ConfirmFileReplaceForm_RemoteFileLastWriteTime);
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.Controls.Add(this.textBox_ConfirmFileReplaceForm_RemoteFileSize);
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.Controls.Add(this.label_ConfirmFileReplaceForm_RemoteFileSize);
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.Controls.Add(this.textBox_ConfirmFileReplaceForm_RemoteFileName);
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.Controls.Add(this.label_ConfirmFileReplaceForm_RemoteFileName);
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.Location = new System.Drawing.Point(296, 48);
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.Name = "groupBox_ConfirmFileReplaceForm_RemoteSide";
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.Size = new System.Drawing.Size(272, 120);
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.TabIndex = 29;
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.TabStop = false;
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.Text = "Remote Side";
        // 
        // label_ConfirmFileReplaceForm_RemoteFileLastWriteTime
        // 
        this.label_ConfirmFileReplaceForm_RemoteFileLastWriteTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ConfirmFileReplaceForm_RemoteFileLastWriteTime.Location = new System.Drawing.Point(8, 88);
        this.label_ConfirmFileReplaceForm_RemoteFileLastWriteTime.Name = "label_ConfirmFileReplaceForm_RemoteFileLastWriteTime";
        this.label_ConfirmFileReplaceForm_RemoteFileLastWriteTime.Size = new System.Drawing.Size(116, 16);
        this.label_ConfirmFileReplaceForm_RemoteFileLastWriteTime.TabIndex = 37;
        this.label_ConfirmFileReplaceForm_RemoteFileLastWriteTime.Text = "Last Write Time:";
        // 
        // textBox_ConfirmFileReplaceForm_RemoteFileLastWriteTime
        // 
        this.textBox_ConfirmFileReplaceForm_RemoteFileLastWriteTime.Location = new System.Drawing.Point(128, 88);
        this.textBox_ConfirmFileReplaceForm_RemoteFileLastWriteTime.Name = "textBox_ConfirmFileReplaceForm_RemoteFileLastWriteTime";
        this.textBox_ConfirmFileReplaceForm_RemoteFileLastWriteTime.ReadOnly = true;
        this.textBox_ConfirmFileReplaceForm_RemoteFileLastWriteTime.Size = new System.Drawing.Size(128, 20);
        this.textBox_ConfirmFileReplaceForm_RemoteFileLastWriteTime.TabIndex = 36;
        // 
        // textBox_ConfirmFileReplaceForm_RemoteFileSize
        // 
        this.textBox_ConfirmFileReplaceForm_RemoteFileSize.Location = new System.Drawing.Point(128, 56);
        this.textBox_ConfirmFileReplaceForm_RemoteFileSize.Name = "textBox_ConfirmFileReplaceForm_RemoteFileSize";
        this.textBox_ConfirmFileReplaceForm_RemoteFileSize.ReadOnly = true;
        this.textBox_ConfirmFileReplaceForm_RemoteFileSize.Size = new System.Drawing.Size(128, 20);
        this.textBox_ConfirmFileReplaceForm_RemoteFileSize.TabIndex = 35;
        // 
        // label_ConfirmFileReplaceForm_RemoteFileSize
        // 
        this.label_ConfirmFileReplaceForm_RemoteFileSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ConfirmFileReplaceForm_RemoteFileSize.Location = new System.Drawing.Point(8, 56);
        this.label_ConfirmFileReplaceForm_RemoteFileSize.Name = "label_ConfirmFileReplaceForm_RemoteFileSize";
        this.label_ConfirmFileReplaceForm_RemoteFileSize.Size = new System.Drawing.Size(120, 16);
        this.label_ConfirmFileReplaceForm_RemoteFileSize.TabIndex = 34;
        this.label_ConfirmFileReplaceForm_RemoteFileSize.Text = "File Size (Bytes):";
        // 
        // textBox_ConfirmFileReplaceForm_RemoteFileName
        // 
        this.textBox_ConfirmFileReplaceForm_RemoteFileName.Location = new System.Drawing.Point(128, 24);
        this.textBox_ConfirmFileReplaceForm_RemoteFileName.Name = "textBox_ConfirmFileReplaceForm_RemoteFileName";
        this.textBox_ConfirmFileReplaceForm_RemoteFileName.ReadOnly = true;
        this.textBox_ConfirmFileReplaceForm_RemoteFileName.Size = new System.Drawing.Size(128, 20);
        this.textBox_ConfirmFileReplaceForm_RemoteFileName.TabIndex = 32;
        // 
        // label_ConfirmFileReplaceForm_RemoteFileName
        // 
        this.label_ConfirmFileReplaceForm_RemoteFileName.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_ConfirmFileReplaceForm_RemoteFileName.Location = new System.Drawing.Point(8, 24);
        this.label_ConfirmFileReplaceForm_RemoteFileName.Name = "label_ConfirmFileReplaceForm_RemoteFileName";
        this.label_ConfirmFileReplaceForm_RemoteFileName.Size = new System.Drawing.Size(116, 16);
        this.label_ConfirmFileReplaceForm_RemoteFileName.TabIndex = 33;
        this.label_ConfirmFileReplaceForm_RemoteFileName.Text = "File name:";
        // 
        // ConfirmFileReplaceForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(578, 208);
        this.ControlBox = false;
        this.Controls.Add(this.groupBox_ConfirmFileReplaceForm_RemoteSide);
        this.Controls.Add(this.groupBox_ConfirmFileReplaceForm_LocalSide);
        this.Controls.Add(this.label_ConfirmFileReplaceForm_Information);
        this.Controls.Add(this.button_ConfirmFileReplaceForm_NoToAll);
        this.Controls.Add(this.button_ConfirmFileReplaceForm_YesToAll);
        this.Controls.Add(this.button_ConfirmFileReplaceForm_No);
        this.Controls.Add(this.button_ConfirmFileReplaceForm_Yes);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.Name = "ConfirmFileReplaceForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Confirm File Replace";
        this.Shown += new System.EventHandler(this.ConfirmFileReplaceForm_Shown);
        this.groupBox_ConfirmFileReplaceForm_LocalSide.ResumeLayout(false);
        this.groupBox_ConfirmFileReplaceForm_LocalSide.PerformLayout();
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.ResumeLayout(false);
        this.groupBox_ConfirmFileReplaceForm_RemoteSide.PerformLayout();
        this.ResumeLayout(false);

    }
    #endregion


    private void button_ConfirmFileReplaceForm_Yes_Click(object sender, System.EventArgs e)
    {
        if (int_SelectedDialogType == 1) LocalAction.LastResultOfLocalFileReplace = 1;
        if (int_SelectedDialogType == 0) LocalAction.LastResultOfRemoteFileReplace = 1;
        
        Close();
    }

    private void button_ConfirmFileReplaceForm_YesToAll_Click(object sender, System.EventArgs e)
    {
        if (int_SelectedDialogType == 1) LocalAction.LastResultOfLocalFileReplace = 2;
        if (int_SelectedDialogType == 0) LocalAction.LastResultOfRemoteFileReplace = 2;
       
        Close();
    }

    private void button_ConfirmFileReplaceForm_No_Click(object sender, System.EventArgs e)
    {
        if (int_SelectedDialogType == 1) LocalAction.LastResultOfLocalFileReplace = 3;
        if (int_SelectedDialogType == 0) LocalAction.LastResultOfRemoteFileReplace = 3;
        
        Close();
    }

    private void button_ConfirmFileReplaceForm_NoToAll_Click(object sender, System.EventArgs e)
    {
        if (int_SelectedDialogType == 1) LocalAction.LastResultOfLocalFileReplace = 4;
        if (int_SelectedDialogType == 0) LocalAction.LastResultOfRemoteFileReplace = 4;
        
        Close();
    }

    private void ConfirmFileReplaceForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }
}

