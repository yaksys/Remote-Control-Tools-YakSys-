using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using JurikSoft.RCTServiceGUI;

public class ActiveConnectionDetailsForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.GroupBox groupBox_ActiveConnectionDetails_Statistic;
    private System.Windows.Forms.TextBox textBox_Statistic_ConnectedAt;
    private System.Windows.Forms.TextBox textBox_Statistic_BytesReceived;
    private System.Windows.Forms.TextBox textBox_Statistic_BytesSent;
    private System.Windows.Forms.Label label_Statistic_ConnectedAt;
    private System.Windows.Forms.Label label_Statistic_BytesReceived;
    private System.Windows.Forms.Label label_Statistic_BytesSent;
    private System.Windows.Forms.Label label_NetworkInformation_IPAddress;
    private System.Windows.Forms.Label label_NetworkInformation_MACAddress;
    private System.Windows.Forms.TextBox textBox_NetworkInformation_IPAddress;
    private System.Windows.Forms.TextBox textBox_NetworkInformation_MACAddress;
    private System.Windows.Forms.GroupBox groupBox_ActiveConnectionDetails_NetworkInformation;
    private System.Windows.Forms.Button button_ActiveConnectionDetails_OK;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    void ChangeControlsLanguage()
    {
        this.Text = ServerStringFactory.GetString(180, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_NetworkInformation_IPAddress.Text = ServerStringFactory.GetString(185, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_NetworkInformation_MACAddress.Text = ServerStringFactory.GetString(186, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_Statistic_BytesReceived.Text = ServerStringFactory.GetString(188, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_Statistic_BytesSent.Text = ServerStringFactory.GetString(187, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.label_Statistic_ConnectedAt.Text = ServerStringFactory.GetString(183, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.groupBox_ActiveConnectionDetails_NetworkInformation.Text = ServerStringFactory.GetString(184, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
        this.groupBox_ActiveConnectionDetails_Statistic.Text = ServerStringFactory.GetString(171, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
    }

    public ActiveConnectionDetailsForm()
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
        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ActiveConnectionDetailsForm));
        this.groupBox_ActiveConnectionDetails_Statistic = new System.Windows.Forms.GroupBox();
        this.textBox_Statistic_ConnectedAt = new System.Windows.Forms.TextBox();
        this.textBox_Statistic_BytesReceived = new System.Windows.Forms.TextBox();
        this.textBox_Statistic_BytesSent = new System.Windows.Forms.TextBox();
        this.label_Statistic_ConnectedAt = new System.Windows.Forms.Label();
        this.label_Statistic_BytesReceived = new System.Windows.Forms.Label();
        this.label_Statistic_BytesSent = new System.Windows.Forms.Label();
        this.label_NetworkInformation_IPAddress = new System.Windows.Forms.Label();
        this.label_NetworkInformation_MACAddress = new System.Windows.Forms.Label();
        this.textBox_NetworkInformation_IPAddress = new System.Windows.Forms.TextBox();
        this.textBox_NetworkInformation_MACAddress = new System.Windows.Forms.TextBox();
        this.groupBox_ActiveConnectionDetails_NetworkInformation = new System.Windows.Forms.GroupBox();
        this.button_ActiveConnectionDetails_OK = new System.Windows.Forms.Button();
        this.groupBox_ActiveConnectionDetails_Statistic.SuspendLayout();
        this.groupBox_ActiveConnectionDetails_NetworkInformation.SuspendLayout();
        this.SuspendLayout();
        // 
        // groupBox_ActiveConnectionDetails_Statistic
        // 
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.textBox_Statistic_ConnectedAt);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.textBox_Statistic_BytesReceived);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.textBox_Statistic_BytesSent);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.label_Statistic_ConnectedAt);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.label_Statistic_BytesReceived);
        this.groupBox_ActiveConnectionDetails_Statistic.Controls.Add(this.label_Statistic_BytesSent);
        this.groupBox_ActiveConnectionDetails_Statistic.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ActiveConnectionDetails_Statistic.Location = new System.Drawing.Point(200, 16);
        this.groupBox_ActiveConnectionDetails_Statistic.Name = "groupBox_ActiveConnectionDetails_Statistic";
        this.groupBox_ActiveConnectionDetails_Statistic.Size = new System.Drawing.Size(168, 176);
        this.groupBox_ActiveConnectionDetails_Statistic.TabIndex = 9;
        this.groupBox_ActiveConnectionDetails_Statistic.TabStop = false;
        this.groupBox_ActiveConnectionDetails_Statistic.Text = "Statistic";
        // 
        // textBox_Statistic_ConnectedAt
        // 
        this.textBox_Statistic_ConnectedAt.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_Statistic_ConnectedAt.Location = new System.Drawing.Point(16, 136);
        this.textBox_Statistic_ConnectedAt.Name = "textBox_Statistic_ConnectedAt";
        this.textBox_Statistic_ConnectedAt.ReadOnly = true;
        this.textBox_Statistic_ConnectedAt.Size = new System.Drawing.Size(136, 20);
        this.textBox_Statistic_ConnectedAt.TabIndex = 21;
        this.textBox_Statistic_ConnectedAt.Text = String.Empty;
        // 
        // textBox_Statistic_BytesReceived
        // 
        this.textBox_Statistic_BytesReceived.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_Statistic_BytesReceived.Location = new System.Drawing.Point(16, 88);
        this.textBox_Statistic_BytesReceived.Name = "textBox_Statistic_BytesReceived";
        this.textBox_Statistic_BytesReceived.ReadOnly = true;
        this.textBox_Statistic_BytesReceived.Size = new System.Drawing.Size(136, 20);
        this.textBox_Statistic_BytesReceived.TabIndex = 19;
        this.textBox_Statistic_BytesReceived.Text = String.Empty;
        // 
        // textBox_Statistic_BytesSent
        // 
        this.textBox_Statistic_BytesSent.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.textBox_Statistic_BytesSent.ForeColor = System.Drawing.SystemColors.WindowText;
        this.textBox_Statistic_BytesSent.Location = new System.Drawing.Point(16, 40);
        this.textBox_Statistic_BytesSent.Name = "textBox_Statistic_BytesSent";
        this.textBox_Statistic_BytesSent.ReadOnly = true;
        this.textBox_Statistic_BytesSent.Size = new System.Drawing.Size(136, 20);
        this.textBox_Statistic_BytesSent.TabIndex = 18;
        this.textBox_Statistic_BytesSent.Text = String.Empty;
        // 
        // label_Statistic_ConnectedAt
        // 
        this.label_Statistic_ConnectedAt.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_Statistic_ConnectedAt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_Statistic_ConnectedAt.Location = new System.Drawing.Point(16, 120);
        this.label_Statistic_ConnectedAt.Name = "label_Statistic_ConnectedAt";
        this.label_Statistic_ConnectedAt.Size = new System.Drawing.Size(136, 16);
        this.label_Statistic_ConnectedAt.TabIndex = 17;
        this.label_Statistic_ConnectedAt.Text = "Connected at:";
        // 
        // label_Statistic_BytesReceived
        // 
        this.label_Statistic_BytesReceived.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_Statistic_BytesReceived.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_Statistic_BytesReceived.Location = new System.Drawing.Point(16, 72);
        this.label_Statistic_BytesReceived.Name = "label_Statistic_BytesReceived";
        this.label_Statistic_BytesReceived.Size = new System.Drawing.Size(136, 16);
        this.label_Statistic_BytesReceived.TabIndex = 15;
        this.label_Statistic_BytesReceived.Text = "Bytes Received:";
        // 
        // label_Statistic_BytesSent
        // 
        this.label_Statistic_BytesSent.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_Statistic_BytesSent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.label_Statistic_BytesSent.Location = new System.Drawing.Point(16, 24);
        this.label_Statistic_BytesSent.Name = "label_Statistic_BytesSent";
        this.label_Statistic_BytesSent.Size = new System.Drawing.Size(136, 16);
        this.label_Statistic_BytesSent.TabIndex = 14;
        this.label_Statistic_BytesSent.Text = "Bytes Sent:";
        // 
        // label_NetworkInformation_IPAddress
        // 
        this.label_NetworkInformation_IPAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_NetworkInformation_IPAddress.Location = new System.Drawing.Point(16, 24);
        this.label_NetworkInformation_IPAddress.Name = "label_NetworkInformation_IPAddress";
        this.label_NetworkInformation_IPAddress.Size = new System.Drawing.Size(136, 16);
        this.label_NetworkInformation_IPAddress.TabIndex = 10;
        this.label_NetworkInformation_IPAddress.Text = "IP Address:";
        // 
        // label_NetworkInformation_MACAddress
        // 
        this.label_NetworkInformation_MACAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_NetworkInformation_MACAddress.Location = new System.Drawing.Point(16, 72);
        this.label_NetworkInformation_MACAddress.Name = "label_NetworkInformation_MACAddress";
        this.label_NetworkInformation_MACAddress.Size = new System.Drawing.Size(136, 16);
        this.label_NetworkInformation_MACAddress.TabIndex = 11;
        this.label_NetworkInformation_MACAddress.Text = "MAC Address:";
        // 
        // textBox_NetworkInformation_IPAddress
        // 
        this.textBox_NetworkInformation_IPAddress.Location = new System.Drawing.Point(16, 40);
        this.textBox_NetworkInformation_IPAddress.Name = "textBox_NetworkInformation_IPAddress";
        this.textBox_NetworkInformation_IPAddress.ReadOnly = true;
        this.textBox_NetworkInformation_IPAddress.Size = new System.Drawing.Size(136, 20);
        this.textBox_NetworkInformation_IPAddress.TabIndex = 12;
        this.textBox_NetworkInformation_IPAddress.Text = String.Empty;
        // 
        // textBox_NetworkInformation_MACAddress
        // 
        this.textBox_NetworkInformation_MACAddress.Location = new System.Drawing.Point(16, 88);
        this.textBox_NetworkInformation_MACAddress.Name = "textBox_NetworkInformation_MACAddress";
        this.textBox_NetworkInformation_MACAddress.ReadOnly = true;
        this.textBox_NetworkInformation_MACAddress.Size = new System.Drawing.Size(136, 20);
        this.textBox_NetworkInformation_MACAddress.TabIndex = 13;
        this.textBox_NetworkInformation_MACAddress.Text = String.Empty;
        // 
        // groupBox_ActiveConnectionDetails_NetworkInformation
        // 
        this.groupBox_ActiveConnectionDetails_NetworkInformation.Controls.Add(this.textBox_NetworkInformation_MACAddress);
        this.groupBox_ActiveConnectionDetails_NetworkInformation.Controls.Add(this.textBox_NetworkInformation_IPAddress);
        this.groupBox_ActiveConnectionDetails_NetworkInformation.Controls.Add(this.label_NetworkInformation_IPAddress);
        this.groupBox_ActiveConnectionDetails_NetworkInformation.Controls.Add(this.label_NetworkInformation_MACAddress);
        this.groupBox_ActiveConnectionDetails_NetworkInformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_ActiveConnectionDetails_NetworkInformation.Location = new System.Drawing.Point(16, 16);
        this.groupBox_ActiveConnectionDetails_NetworkInformation.Name = "groupBox_ActiveConnectionDetails_NetworkInformation";
        this.groupBox_ActiveConnectionDetails_NetworkInformation.Size = new System.Drawing.Size(168, 128);
        this.groupBox_ActiveConnectionDetails_NetworkInformation.TabIndex = 14;
        this.groupBox_ActiveConnectionDetails_NetworkInformation.TabStop = false;
        this.groupBox_ActiveConnectionDetails_NetworkInformation.Text = "Network Information";
        // 
        // button_ActiveConnectionDetails_OK
        // 
        this.button_ActiveConnectionDetails_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_ActiveConnectionDetails_OK.Location = new System.Drawing.Point(56, 160);
        this.button_ActiveConnectionDetails_OK.Name = "button_ActiveConnectionDetails_OK";
        this.button_ActiveConnectionDetails_OK.Size = new System.Drawing.Size(88, 23);
        this.button_ActiveConnectionDetails_OK.TabIndex = 15;
        this.button_ActiveConnectionDetails_OK.Text = "OK";
        this.button_ActiveConnectionDetails_OK.Click += new System.EventHandler(this.button_ActiveConnectionDetails_OK_Click);
        // 
        // ActiveConnectionDetailsForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(386, 208);
        this.Controls.Add(this.button_ActiveConnectionDetails_OK);
        this.Controls.Add(this.groupBox_ActiveConnectionDetails_NetworkInformation);
        this.Controls.Add(this.groupBox_ActiveConnectionDetails_Statistic);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(392, 240);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(392, 240);
        this.Name = "ActiveConnectionDetailsForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Active Connection Details";
        this.TopMost = true;
        this.groupBox_ActiveConnectionDetails_Statistic.ResumeLayout(false);
        this.groupBox_ActiveConnectionDetails_NetworkInformation.ResumeLayout(false);
        this.ResumeLayout(false);

    }
    #endregion

    private void button_ActiveConnectionDetails_OK_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }

    #region Common Properties

    public long Statistic_BytesSent
    {
        set
        {
            this.textBox_Statistic_BytesSent.Text = LocalObjCopy.obj_MainServerForm.SpreadToHundreds(value.ToString());
        }

        get
        {
            return long.Parse(this.textBox_Statistic_BytesSent.Text.Replace(", ", ""));
        }
    }


    public long Statistic_BytesReceived
    {
        set
        {
            this.textBox_Statistic_BytesReceived.Text = LocalObjCopy.obj_MainServerForm.SpreadToHundreds(value.ToString());
        }

        get
        {
            return long.Parse(this.textBox_Statistic_BytesReceived.Text.Replace(", ", ""));
        }
    }


    public string Statistic_ConnectedAt
    {
        set
        {
            this.textBox_Statistic_ConnectedAt.Text = value;
        }

        get
        {
            return this.textBox_Statistic_ConnectedAt.Text;
        }
    }


    public string NetworkInformation_IPAddress
    {
        set
        {
            this.textBox_NetworkInformation_IPAddress.Text = value;
        }

        get
        {
            return this.textBox_NetworkInformation_IPAddress.Text;
        }
    }


    public string NetworkInformation_MACAddress
    {
        set
        {
            this.textBox_NetworkInformation_MACAddress.Text = value;
        }

        get
        {
            return this.textBox_NetworkInformation_MACAddress.Text;
        }
    }


    #endregion
}

