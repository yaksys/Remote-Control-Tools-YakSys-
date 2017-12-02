using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using JurikSoft.RCTServiceGUI;

public class AdditionalParametersForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.Button button_AdditionalParameters_OK;
    private System.Windows.Forms.Button button_AdditionalParameters_Cancel;
    private System.Windows.Forms.Label label_AdditionalNetworkParameters_MaxConnections;
    private System.Windows.Forms.Label label_AdditionalNetworkParameters_MaxConnectionsPerAccount;
    private System.Windows.Forms.NumericUpDown numericUpDown_AdditionalNetworkParameters_MaxConnections;
    private System.Windows.Forms.NumericUpDown numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount;
    private System.Windows.Forms.GroupBox groupBox_AdditionalParameters_AdditionalNetworkParameters;

    private System.ComponentModel.Container components = null;

    void ChangeControlsLanguage()
    {
        this.Text = ServerStringFactory.GetString(223, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Text = ServerStringFactory.GetString(220, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_AdditionalNetworkParameters_MaxConnections.Text = ServerStringFactory.GetString(224, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);

        this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.Text = ServerStringFactory.GetString(225, LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_CurrentLanguage);
    }



    public AdditionalParametersForm()
    {
        InitializeComponent();

        ChangeControlsLanguage();

        this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Value = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_MaxConnections;
        this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Value = LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_MaxConnectionsPerAccount;
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdditionalParametersForm));
        this.label_AdditionalNetworkParameters_MaxConnections = new System.Windows.Forms.Label();
        this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount = new System.Windows.Forms.Label();
        this.numericUpDown_AdditionalNetworkParameters_MaxConnections = new System.Windows.Forms.NumericUpDown();
        this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount = new System.Windows.Forms.NumericUpDown();
        this.button_AdditionalParameters_OK = new System.Windows.Forms.Button();
        this.button_AdditionalParameters_Cancel = new System.Windows.Forms.Button();
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters = new System.Windows.Forms.GroupBox();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AdditionalNetworkParameters_MaxConnections)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount)).BeginInit();
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.SuspendLayout();
        this.SuspendLayout();
        // 
        // label_AdditionalNetworkParameters_MaxConnections
        // 
        this.label_AdditionalNetworkParameters_MaxConnections.Location = new System.Drawing.Point(12, 24);
        this.label_AdditionalNetworkParameters_MaxConnections.Name = "label_AdditionalNetworkParameters_MaxConnections";
        this.label_AdditionalNetworkParameters_MaxConnections.Size = new System.Drawing.Size(280, 24);
        this.label_AdditionalNetworkParameters_MaxConnections.TabIndex = 0;
        this.label_AdditionalNetworkParameters_MaxConnections.Text = "Max. simultaneous connections amount:";
        this.label_AdditionalNetworkParameters_MaxConnections.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // label_AdditionalNetworkParameters_MaxConnectionsPerAccount
        // 
        this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.Location = new System.Drawing.Point(12, 56);
        this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.Name = "label_AdditionalNetworkParameters_MaxConnectionsPerAccount";
        this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.Size = new System.Drawing.Size(280, 24);
        this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.TabIndex = 1;
        this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.Text = "Max. simultaneous connections per each account:";
        this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // numericUpDown_AdditionalNetworkParameters_MaxConnections
        // 
        this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Location = new System.Drawing.Point(300, 24);
        this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
        this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Name = "numericUpDown_AdditionalNetworkParameters_MaxConnections";
        this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Size = new System.Drawing.Size(56, 20);
        this.numericUpDown_AdditionalNetworkParameters_MaxConnections.TabIndex = 2;
        this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount
        // 
        this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Location = new System.Drawing.Point(300, 56);
        this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
        this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Name = "numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount";
        this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Size = new System.Drawing.Size(56, 20);
        this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.TabIndex = 3;
        this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // button_AdditionalParameters_OK
        // 
        this.button_AdditionalParameters_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_AdditionalParameters_OK.Location = new System.Drawing.Point(97, 129);
        this.button_AdditionalParameters_OK.Name = "button_AdditionalParameters_OK";
        this.button_AdditionalParameters_OK.Size = new System.Drawing.Size(88, 23);
        this.button_AdditionalParameters_OK.TabIndex = 4;
        this.button_AdditionalParameters_OK.Text = "OK";
        this.button_AdditionalParameters_OK.Click += new System.EventHandler(this.button_AdditionalParameters_OK_Click);
        // 
        // button_AdditionalParameters_Cancel
        // 
        this.button_AdditionalParameters_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_AdditionalParameters_Cancel.Location = new System.Drawing.Point(201, 129);
        this.button_AdditionalParameters_Cancel.Name = "button_AdditionalParameters_Cancel";
        this.button_AdditionalParameters_Cancel.Size = new System.Drawing.Size(88, 23);
        this.button_AdditionalParameters_Cancel.TabIndex = 5;
        this.button_AdditionalParameters_Cancel.Text = "Cancel";
        this.button_AdditionalParameters_Cancel.Click += new System.EventHandler(this.button_AdditionalParameters_Cancel_Click);
        // 
        // groupBox_AdditionalParameters_AdditionalNetworkParameters
        // 
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Controls.Add(this.label_AdditionalNetworkParameters_MaxConnections);
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Controls.Add(this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount);
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Controls.Add(this.numericUpDown_AdditionalNetworkParameters_MaxConnections);
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Controls.Add(this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount);
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Location = new System.Drawing.Point(8, 16);
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Name = "groupBox_AdditionalParameters_AdditionalNetworkParameters";
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Size = new System.Drawing.Size(368, 94);
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.TabIndex = 6;
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.TabStop = false;
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Text = "Additional Network Parameters";
        // 
        // AdditionalParametersForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(386, 175);
        this.Controls.Add(this.groupBox_AdditionalParameters_AdditionalNetworkParameters);
        this.Controls.Add(this.button_AdditionalParameters_Cancel);
        this.Controls.Add(this.button_AdditionalParameters_OK);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(392, 200);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(392, 200);
        this.Name = "AdditionalParametersForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Additional Parameters";
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AdditionalNetworkParameters_MaxConnections)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount)).EndInit();
        this.groupBox_AdditionalParameters_AdditionalNetworkParameters.ResumeLayout(false);
        this.ResumeLayout(false);

    }
    #endregion

    private void button_AdditionalParameters_OK_Click(object sender, System.EventArgs e)
    {
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_MaxConnections = (int)this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Value;
        LocalObjCopy.obj_ServerSettingsEnvironment.RemotingWrapper_MaxConnectionsPerAccount = (int)this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Value;

        this.Close();
    }


    private void button_AdditionalParameters_Cancel_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }
}

