using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;

public class CreateTextValueForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.TextBox textBox_CreateTextValueForm_ValueName;
	private System.Windows.Forms.TextBox textBox_CreateTextValueForm_ValueData;
	private System.Windows.Forms.Label label_CreateTextValueForm_ValueName;
	private System.Windows.Forms.Label label_CreateTextValueForm_ValueData;
	private System.Windows.Forms.Button button_CreateTextValueForm_Cancel;
	private System.Windows.Forms.Button button_CreateTextValueForm_OK;

	private System.ComponentModel.Container components = null;



    public CreateTextValueForm(Form form_Owner, string string_ValueName, string string_StringValue)
	{
		InitializeComponent();

		ChangeControlsLanguage();

        this.ValueName = string_ValueName;
        this.ValueData = string_StringValue;

        this.Owner = form_Owner;
	}

	void ChangeControlsLanguage()
	{
		this.Text = ClientStringFactory.GetString(606, ClientSettingsEnvironment.CurrentLanguage);

		this.label_CreateTextValueForm_ValueData.Text = ClientStringFactory.GetString(602, ClientSettingsEnvironment.CurrentLanguage);
		
		this.label_CreateTextValueForm_ValueName.Text = ClientStringFactory.GetString(589, ClientSettingsEnvironment.CurrentLanguage);

		this.button_CreateTextValueForm_OK.Text = ClientStringFactory.GetString(175, ClientSettingsEnvironment.CurrentLanguage);	

		this.button_CreateTextValueForm_Cancel.Text = ClientStringFactory.GetString(5, ClientSettingsEnvironment.CurrentLanguage);
	}
    
	void SuccessClose()
	{
		ValueData = this.textBox_CreateTextValueForm_ValueData.Text;
		ValueName = this.textBox_CreateTextValueForm_ValueName.Text;

		this.DialogResult = DialogResult.OK;

		this.Close();
	}
    

	protected override void Dispose( bool disposing )
	{
		if( disposing )
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTextValueForm));
        this.textBox_CreateTextValueForm_ValueName = new System.Windows.Forms.TextBox();
        this.textBox_CreateTextValueForm_ValueData = new System.Windows.Forms.TextBox();
        this.label_CreateTextValueForm_ValueName = new System.Windows.Forms.Label();
        this.label_CreateTextValueForm_ValueData = new System.Windows.Forms.Label();
        this.button_CreateTextValueForm_Cancel = new System.Windows.Forms.Button();
        this.button_CreateTextValueForm_OK = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // textBox_CreateTextValueForm_ValueName
        // 
        this.textBox_CreateTextValueForm_ValueName.Location = new System.Drawing.Point(8, 32);
        this.textBox_CreateTextValueForm_ValueName.MaxLength = 128;
        this.textBox_CreateTextValueForm_ValueName.Name = "textBox_CreateTextValueForm_ValueName";
        this.textBox_CreateTextValueForm_ValueName.Size = new System.Drawing.Size(320, 20);
        this.textBox_CreateTextValueForm_ValueName.TabIndex = 0;
        this.textBox_CreateTextValueForm_ValueName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_CreateTextValueForm_ValueName_KeyDown);
        // 
        // textBox_CreateTextValueForm_ValueData
        // 
        this.textBox_CreateTextValueForm_ValueData.Location = new System.Drawing.Point(8, 72);
        this.textBox_CreateTextValueForm_ValueData.Name = "textBox_CreateTextValueForm_ValueData";
        this.textBox_CreateTextValueForm_ValueData.Size = new System.Drawing.Size(320, 20);
        this.textBox_CreateTextValueForm_ValueData.TabIndex = 1;
        this.textBox_CreateTextValueForm_ValueData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_CreateTextValueForm_ValueData_KeyDown);
        // 
        // label_CreateTextValueForm_ValueName
        // 
        this.label_CreateTextValueForm_ValueName.Location = new System.Drawing.Point(8, 16);
        this.label_CreateTextValueForm_ValueName.Name = "label_CreateTextValueForm_ValueName";
        this.label_CreateTextValueForm_ValueName.Size = new System.Drawing.Size(320, 16);
        this.label_CreateTextValueForm_ValueName.TabIndex = 2;
        this.label_CreateTextValueForm_ValueName.Text = "Value name:";
        // 
        // label_CreateTextValueForm_ValueData
        // 
        this.label_CreateTextValueForm_ValueData.Location = new System.Drawing.Point(8, 56);
        this.label_CreateTextValueForm_ValueData.Name = "label_CreateTextValueForm_ValueData";
        this.label_CreateTextValueForm_ValueData.Size = new System.Drawing.Size(320, 16);
        this.label_CreateTextValueForm_ValueData.TabIndex = 3;
        this.label_CreateTextValueForm_ValueData.Text = "Value data:";
        // 
        // button_CreateTextValueForm_Cancel
        // 
        this.button_CreateTextValueForm_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_CreateTextValueForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_CreateTextValueForm_Cancel.Location = new System.Drawing.Point(240, 104);
        this.button_CreateTextValueForm_Cancel.Name = "button_CreateTextValueForm_Cancel";
        this.button_CreateTextValueForm_Cancel.Size = new System.Drawing.Size(88, 23);
        this.button_CreateTextValueForm_Cancel.TabIndex = 16;
        this.button_CreateTextValueForm_Cancel.Text = "Cancel";
        this.button_CreateTextValueForm_Cancel.Click += new System.EventHandler(this.button_CreateTextValueForm_Cancel_Click);
        // 
        // button_CreateTextValueForm_OK
        // 
        this.button_CreateTextValueForm_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.button_CreateTextValueForm_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_CreateTextValueForm_OK.Location = new System.Drawing.Point(136, 104);
        this.button_CreateTextValueForm_OK.Name = "button_CreateTextValueForm_OK";
        this.button_CreateTextValueForm_OK.Size = new System.Drawing.Size(88, 23);
        this.button_CreateTextValueForm_OK.TabIndex = 15;
        this.button_CreateTextValueForm_OK.Text = "OK";
        this.button_CreateTextValueForm_OK.Click += new System.EventHandler(this.button_CreateTextValueForm_OK_Click);
        // 
        // CreateTextValueForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(338, 136);
        this.Controls.Add(this.button_CreateTextValueForm_Cancel);
        this.Controls.Add(this.button_CreateTextValueForm_OK);
        this.Controls.Add(this.label_CreateTextValueForm_ValueData);
        this.Controls.Add(this.label_CreateTextValueForm_ValueName);
        this.Controls.Add(this.textBox_CreateTextValueForm_ValueData);
        this.Controls.Add(this.textBox_CreateTextValueForm_ValueName);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CreateTextValueForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Shown += new System.EventHandler(this.CreateTextValueForm_Shown);
        this.ResumeLayout(false);
        this.PerformLayout();

	}
	#endregion

	private void button_CreateTextValueForm_OK_Click(object sender, System.EventArgs e)
	{
		SuccessClose();
	}

	private void button_CreateTextValueForm_Cancel_Click(object sender, System.EventArgs e)
	{
		this.Close();
	}
    	

	private void textBox_CreateTextValueForm_ValueData_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		if(e.KeyData == Keys.Enter) SuccessClose();
	}
	
	private void textBox_CreateTextValueForm_ValueName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		if(e.KeyData == Keys.Enter) SuccessClose();
	}

    private void CreateTextValueForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }


	public bool ValueNameReadOnly
	{
		get
		{
			return this.textBox_CreateTextValueForm_ValueName.ReadOnly;
		}

		set
		{
			this.textBox_CreateTextValueForm_ValueName.ReadOnly = value;
			this.textBox_CreateTextValueForm_ValueData.Select();
		}
	}
	
	string string_ValueName, string_ValueData;

	public string ValueData
	{
		get
		{
			return string_ValueData;
		}
		set
		{
			string_ValueData = value;
			this.textBox_CreateTextValueForm_ValueData.Text = value;
		}
	}

	public string ValueName
	{
		get
		{
			return string_ValueName;
		}
		set
		{
			string_ValueName = value;
			this.textBox_CreateTextValueForm_ValueName.Text = value;
		}
	}

}

