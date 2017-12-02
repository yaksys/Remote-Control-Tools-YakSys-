using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

public class RenameItemForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.Label label_RenameItemForm_NewItemName;
	private System.Windows.Forms.Label label_RenameItemForm_OldItemName;
	private System.Windows.Forms.Button button_RenameItemForm_Cancel;
	private System.Windows.Forms.Button button_RenameItemForm_Rename;
	private System.Windows.Forms.TextBox textBox_RenameItemForm_NewItemName;
	private System.Windows.Forms.TextBox textBox_RenameItemForm_OldItemName;

	private System.ComponentModel.Container components = null;

	public RenameItemForm()
	{	
		InitializeComponent();

		ChangeControlsLanguage();
	}

	public void ChangeControlsLanguage()
	{
		this.Text = ClientStringFactory.GetString(250 , ClientSettingsEnvironment.CurrentLanguage);
	
		this.button_RenameItemForm_Rename.Text = ClientStringFactory.GetString(86 , ClientSettingsEnvironment.CurrentLanguage);
		this.button_RenameItemForm_Cancel.Text = ClientStringFactory.GetString(5 , ClientSettingsEnvironment.CurrentLanguage);
		
		this.label_RenameItemForm_OldItemName.Text = ClientStringFactory.GetString(249 , ClientSettingsEnvironment.CurrentLanguage);
		this.label_RenameItemForm_NewItemName.Text = ClientStringFactory.GetString(228 , ClientSettingsEnvironment.CurrentLanguage);
	}
    
	protected override void Dispose( bool disposing )
	{
		if( disposing )
		{
			if( components != null)
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameItemForm));
        this.label_RenameItemForm_NewItemName = new System.Windows.Forms.Label();
        this.label_RenameItemForm_OldItemName = new System.Windows.Forms.Label();
        this.button_RenameItemForm_Cancel = new System.Windows.Forms.Button();
        this.button_RenameItemForm_Rename = new System.Windows.Forms.Button();
        this.textBox_RenameItemForm_NewItemName = new System.Windows.Forms.TextBox();
        this.textBox_RenameItemForm_OldItemName = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // label_RenameItemForm_NewItemName
        // 
        this.label_RenameItemForm_NewItemName.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_RenameItemForm_NewItemName.Location = new System.Drawing.Point(16, 64);
        this.label_RenameItemForm_NewItemName.Name = "label_RenameItemForm_NewItemName";
        this.label_RenameItemForm_NewItemName.Size = new System.Drawing.Size(216, 16);
        this.label_RenameItemForm_NewItemName.TabIndex = 11;
        // 
        // label_RenameItemForm_OldItemName
        // 
        this.label_RenameItemForm_OldItemName.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_RenameItemForm_OldItemName.Location = new System.Drawing.Point(16, 16);
        this.label_RenameItemForm_OldItemName.Name = "label_RenameItemForm_OldItemName";
        this.label_RenameItemForm_OldItemName.Size = new System.Drawing.Size(216, 16);
        this.label_RenameItemForm_OldItemName.TabIndex = 10;
        // 
        // button_RenameItemForm_Cancel
        // 
        this.button_RenameItemForm_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_RenameItemForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_RenameItemForm_Cancel.Location = new System.Drawing.Point(160, 112);
        this.button_RenameItemForm_Cancel.Name = "button_RenameItemForm_Cancel";
        this.button_RenameItemForm_Cancel.Size = new System.Drawing.Size(75, 23);
        this.button_RenameItemForm_Cancel.TabIndex = 8;
        // 
        // button_RenameItemForm_Rename
        // 
        this.button_RenameItemForm_Rename.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.button_RenameItemForm_Rename.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_RenameItemForm_Rename.Location = new System.Drawing.Point(16, 112);
        this.button_RenameItemForm_Rename.Name = "button_RenameItemForm_Rename";
        this.button_RenameItemForm_Rename.Size = new System.Drawing.Size(112, 23);
        this.button_RenameItemForm_Rename.TabIndex = 6;
        this.button_RenameItemForm_Rename.Click += new System.EventHandler(this.button_RenameItemForm_Rename_Click);
        // 
        // textBox_RenameItemForm_NewItemName
        // 
        this.textBox_RenameItemForm_NewItemName.Location = new System.Drawing.Point(16, 80);
        this.textBox_RenameItemForm_NewItemName.Name = "textBox_RenameItemForm_NewItemName";
        this.textBox_RenameItemForm_NewItemName.Size = new System.Drawing.Size(216, 20);
        this.textBox_RenameItemForm_NewItemName.TabIndex = 7;
        // 
        // textBox_RenameItemForm_OldItemName
        // 
        this.textBox_RenameItemForm_OldItemName.Location = new System.Drawing.Point(16, 32);
        this.textBox_RenameItemForm_OldItemName.Name = "textBox_RenameItemForm_OldItemName";
        this.textBox_RenameItemForm_OldItemName.ReadOnly = true;
        this.textBox_RenameItemForm_OldItemName.Size = new System.Drawing.Size(216, 20);
        this.textBox_RenameItemForm_OldItemName.TabIndex = 9;
        // 
        // RenameItemForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(250, 152);
        this.Controls.Add(this.label_RenameItemForm_NewItemName);
        this.Controls.Add(this.label_RenameItemForm_OldItemName);
        this.Controls.Add(this.button_RenameItemForm_Cancel);
        this.Controls.Add(this.button_RenameItemForm_Rename);
        this.Controls.Add(this.textBox_RenameItemForm_NewItemName);
        this.Controls.Add(this.textBox_RenameItemForm_OldItemName);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(256, 184);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(256, 184);
        this.Name = "RenameItemForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Shown += new System.EventHandler(this.RenameItemForm_Shown);
        this.Load += new System.EventHandler(this.RenameItemForm_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

	}
	#endregion

	private void button_RenameItemForm_Rename_Click(object sender, System.EventArgs e)
	{
		string_NewItemName = this.textBox_RenameItemForm_NewItemName.Text;

		Close();
	}
    		
	string string_NewItemName = String.Empty;

	private void RenameItemForm_Load(object sender, System.EventArgs e)
	{
		this.textBox_RenameItemForm_NewItemName.Select();
	}

	public string NewItemName
	{
		get
		{
			return string_NewItemName;
		}

		set
		{
			string_NewItemName = value;
		}
	}

	public string OldItemName
	{
		get
		{
			return this.textBox_RenameItemForm_OldItemName.Text;
		}

		set
		{
			this.textBox_RenameItemForm_OldItemName.Text = value;
		}
	}

    private void RenameItemForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }
}
