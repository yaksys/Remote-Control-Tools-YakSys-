using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;

public class CreateMultilineTextValueForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.Button button_CreateMultilineTextValueForm_Cancel;
	private System.Windows.Forms.Button button_CreateMultilineTextValueForm_OK;
	private System.Windows.Forms.Label label_CreateMultilineTextValueForm_ValueData;
	private System.Windows.Forms.Label label_CreateMultilineTextValueForm_ValueName;
	private System.Windows.Forms.TextBox textBox_CreateMultilineTextValueForm_ValueData;
	private System.Windows.Forms.TextBox textBox_CreateMultilineTextValueForm_ValueName;

	private System.ComponentModel.Container components = null;

    public CreateMultilineTextValueForm(Form form_Owner, string ValueName, string[] StringData)
	{
		InitializeComponent();

		ChangeControlsLanguage();

        this.ValueName = ValueName;
        this.ValueData = StringData;

        this.Owner = form_Owner;
	}

	
	void ChangeControlsLanguage()
	{
		this.Text = ClientStringFactory.GetString(607, ClientSettingsEnvironment.CurrentLanguage);

		this.label_CreateMultilineTextValueForm_ValueData.Text = ClientStringFactory.GetString(602, ClientSettingsEnvironment.CurrentLanguage);
		
		this.label_CreateMultilineTextValueForm_ValueName.Text = ClientStringFactory.GetString(589, ClientSettingsEnvironment.CurrentLanguage);

		this.button_CreateMultilineTextValueForm_OK.Text = ClientStringFactory.GetString(175, ClientSettingsEnvironment.CurrentLanguage);	

		this.button_CreateMultilineTextValueForm_Cancel.Text = ClientStringFactory.GetString(5, ClientSettingsEnvironment.CurrentLanguage);
	}


	void SuccessClose()
	{
		ValueData = this.textBox_CreateMultilineTextValueForm_ValueData.Lines;
		ValueName = this.textBox_CreateMultilineTextValueForm_ValueName.Text;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateMultilineTextValueForm));
        this.button_CreateMultilineTextValueForm_Cancel = new System.Windows.Forms.Button();
        this.button_CreateMultilineTextValueForm_OK = new System.Windows.Forms.Button();
        this.label_CreateMultilineTextValueForm_ValueData = new System.Windows.Forms.Label();
        this.label_CreateMultilineTextValueForm_ValueName = new System.Windows.Forms.Label();
        this.textBox_CreateMultilineTextValueForm_ValueData = new System.Windows.Forms.TextBox();
        this.textBox_CreateMultilineTextValueForm_ValueName = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // button_CreateMultilineTextValueForm_Cancel
        // 
        this.button_CreateMultilineTextValueForm_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_CreateMultilineTextValueForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_CreateMultilineTextValueForm_Cancel.Location = new System.Drawing.Point(248, 272);
        this.button_CreateMultilineTextValueForm_Cancel.Name = "button_CreateMultilineTextValueForm_Cancel";
        this.button_CreateMultilineTextValueForm_Cancel.Size = new System.Drawing.Size(88, 23);
        this.button_CreateMultilineTextValueForm_Cancel.TabIndex = 22;
        this.button_CreateMultilineTextValueForm_Cancel.Text = "Cancel";
        this.button_CreateMultilineTextValueForm_Cancel.Click += new System.EventHandler(this.button_CreateMultilineTextValueForm_Cancel_Click);
        // 
        // button_CreateMultilineTextValueForm_OK
        // 
        this.button_CreateMultilineTextValueForm_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.button_CreateMultilineTextValueForm_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_CreateMultilineTextValueForm_OK.Location = new System.Drawing.Point(144, 272);
        this.button_CreateMultilineTextValueForm_OK.Name = "button_CreateMultilineTextValueForm_OK";
        this.button_CreateMultilineTextValueForm_OK.Size = new System.Drawing.Size(88, 23);
        this.button_CreateMultilineTextValueForm_OK.TabIndex = 21;
        this.button_CreateMultilineTextValueForm_OK.Text = "OK";
        this.button_CreateMultilineTextValueForm_OK.Click += new System.EventHandler(this.button_CreateMultilineTextValueForm_OK_Click);
        // 
        // label_CreateMultilineTextValueForm_ValueData
        // 
        this.label_CreateMultilineTextValueForm_ValueData.Location = new System.Drawing.Point(16, 64);
        this.label_CreateMultilineTextValueForm_ValueData.Name = "label_CreateMultilineTextValueForm_ValueData";
        this.label_CreateMultilineTextValueForm_ValueData.Size = new System.Drawing.Size(320, 16);
        this.label_CreateMultilineTextValueForm_ValueData.TabIndex = 20;
        this.label_CreateMultilineTextValueForm_ValueData.Text = "Value data:";
        // 
        // label_CreateMultilineTextValueForm_ValueName
        // 
        this.label_CreateMultilineTextValueForm_ValueName.Location = new System.Drawing.Point(16, 24);
        this.label_CreateMultilineTextValueForm_ValueName.Name = "label_CreateMultilineTextValueForm_ValueName";
        this.label_CreateMultilineTextValueForm_ValueName.Size = new System.Drawing.Size(320, 16);
        this.label_CreateMultilineTextValueForm_ValueName.TabIndex = 19;
        this.label_CreateMultilineTextValueForm_ValueName.Text = "Value name:";
        // 
        // textBox_CreateMultilineTextValueForm_ValueData
        // 
        this.textBox_CreateMultilineTextValueForm_ValueData.Location = new System.Drawing.Point(16, 80);
        this.textBox_CreateMultilineTextValueForm_ValueData.Multiline = true;
        this.textBox_CreateMultilineTextValueForm_ValueData.Name = "textBox_CreateMultilineTextValueForm_ValueData";
        this.textBox_CreateMultilineTextValueForm_ValueData.Size = new System.Drawing.Size(320, 176);
        this.textBox_CreateMultilineTextValueForm_ValueData.TabIndex = 18;
        // 
        // textBox_CreateMultilineTextValueForm_ValueName
        // 
        this.textBox_CreateMultilineTextValueForm_ValueName.Location = new System.Drawing.Point(16, 40);
        this.textBox_CreateMultilineTextValueForm_ValueName.MaxLength = 128;
        this.textBox_CreateMultilineTextValueForm_ValueName.Name = "textBox_CreateMultilineTextValueForm_ValueName";
        this.textBox_CreateMultilineTextValueForm_ValueName.Size = new System.Drawing.Size(320, 20);
        this.textBox_CreateMultilineTextValueForm_ValueName.TabIndex = 17;
        this.textBox_CreateMultilineTextValueForm_ValueName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_CreateMultilineTextValueForm_ValueName_KeyDown);
        // 
        // CreateMultilineTextValueForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(354, 312);
        this.Controls.Add(this.button_CreateMultilineTextValueForm_Cancel);
        this.Controls.Add(this.button_CreateMultilineTextValueForm_OK);
        this.Controls.Add(this.label_CreateMultilineTextValueForm_ValueData);
        this.Controls.Add(this.label_CreateMultilineTextValueForm_ValueName);
        this.Controls.Add(this.textBox_CreateMultilineTextValueForm_ValueData);
        this.Controls.Add(this.textBox_CreateMultilineTextValueForm_ValueName);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CreateMultilineTextValueForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Shown += new System.EventHandler(this.CreateMultilineTextValueForm_Shown);
        this.ResumeLayout(false);
        this.PerformLayout();

	}
	#endregion

	private void button_CreateMultilineTextValueForm_OK_Click(object sender, System.EventArgs e)
	{
		SuccessClose();
	}

	private void button_CreateMultilineTextValueForm_Cancel_Click(object sender, System.EventArgs e)
	{
		this.Close();
	}

	
	private void textBox_CreateMultilineTextValueForm_ValueName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		if(e.KeyData == Keys.Enter) SuccessClose();
	}

	
	public bool ValueNameReadOnly
	{
		get
		{
			return this.textBox_CreateMultilineTextValueForm_ValueName.ReadOnly;
		}

		set
		{
			this.textBox_CreateMultilineTextValueForm_ValueName.ReadOnly = value;
			this.textBox_CreateMultilineTextValueForm_ValueData.Select();
		}
	}

    #region Invoke Delegates

    delegate string delegate_ReturningStringMethod();
    delegate bool delegate_ReturningBoolMethod();

    delegate int delegate_ReturningIntMethod();
    delegate long delegate_ReturningLongMethod();
    delegate decimal delegate_ReturningDecimalMethod();

    delegate ListView.ListViewItemCollection delegate_ReturningListViewItemCollectionMethod();
    delegate ImageList delegate_ReturningImageListMethod();
    delegate TrackBar delegate_ReturningTrackBarMethod();
    delegate TreeView delegate_ReturningTreeViewMethod();

    delegate string [] delegate_ReturningStringArrayMethod();

    #endregion

	string string_ValueName;
	string [] stringArray_ValueData;

	public string [] ValueData
	{
		get
		{      
            return stringArray_ValueData;
		}

		set
		{                    
            this.stringArray_ValueData = value;
            this.textBox_CreateMultilineTextValueForm_ValueData.Lines = value;           
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
            this.string_ValueName = value;
            this.textBox_CreateMultilineTextValueForm_ValueName.Text = value;
		}
	}

    private void CreateMultilineTextValueForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }
}

