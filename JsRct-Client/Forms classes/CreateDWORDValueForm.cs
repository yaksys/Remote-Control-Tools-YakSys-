using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;

public class CreateDWORDValueForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.RadioButton radioButton_CreateDWORDValueForm_Base_Hex;
	private System.Windows.Forms.RadioButton radioButton_CreateDWORDValueForm_Base_Decimal;
	private System.Windows.Forms.GroupBox groupBox_CreateDWORDValueForm_Base;
	private System.Windows.Forms.Button button_CreateDWORDValueForm_Cancel;
	private System.Windows.Forms.Button button_CreateDWORDValueForm_OK;
	private System.Windows.Forms.Label label_CreateDWORDValueForm_ValueData;
	private System.Windows.Forms.Label label_CreateDWORDValueForm_ValueName;
	private System.Windows.Forms.TextBox textBox_CreateDWORDValueForm_ValueName;
	private System.Windows.Forms.NumericUpDown numericUpDown_CreateDWORDValueForm_ValueData;

	private System.ComponentModel.Container components = null;

    public CreateDWORDValueForm(Form form_Owner, string ValueName, int ValueData)
	{
		InitializeComponent();

		ChangeControlsLanguage();
	
		this.radioButton_CreateDWORDValueForm_Base_Hex.Checked = false;
		this.radioButton_CreateDWORDValueForm_Base_Decimal.Checked = true;

		this.numericUpDown_CreateDWORDValueForm_ValueData.Hexadecimal = false;

        this.ValueName = ValueName;
        this.ValueData = ValueData;

        this.Owner = form_Owner;
	}


	void ChangeControlsLanguage()
	{
		this.Text = ClientStringFactory.GetString(608, ClientSettingsEnvironment.CurrentLanguage);

		this.label_CreateDWORDValueForm_ValueData.Text = ClientStringFactory.GetString(602, ClientSettingsEnvironment.CurrentLanguage);
	
		this.label_CreateDWORDValueForm_ValueName.Text = ClientStringFactory.GetString(589, ClientSettingsEnvironment.CurrentLanguage);

		this.button_CreateDWORDValueForm_OK.Text = ClientStringFactory.GetString(175, ClientSettingsEnvironment.CurrentLanguage);	

		this.button_CreateDWORDValueForm_Cancel.Text = ClientStringFactory.GetString(5, ClientSettingsEnvironment.CurrentLanguage);
	
		this.groupBox_CreateDWORDValueForm_Base.Text = ClientStringFactory.GetString(603, ClientSettingsEnvironment.CurrentLanguage);
		
		this.radioButton_CreateDWORDValueForm_Base_Decimal.Text = ClientStringFactory.GetString(604, ClientSettingsEnvironment.CurrentLanguage);
	
		this.radioButton_CreateDWORDValueForm_Base_Hex.Text = ClientStringFactory.GetString(605, ClientSettingsEnvironment.CurrentLanguage);
	}


	void SuccessClose()
	{
		ValueName = this.textBox_CreateDWORDValueForm_ValueName.Text;
		ValueData = (int)this.numericUpDown_CreateDWORDValueForm_ValueData.Value;

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

	private void InitializeComponent()
	{
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDWORDValueForm));
        this.radioButton_CreateDWORDValueForm_Base_Hex = new System.Windows.Forms.RadioButton();
        this.radioButton_CreateDWORDValueForm_Base_Decimal = new System.Windows.Forms.RadioButton();
        this.groupBox_CreateDWORDValueForm_Base = new System.Windows.Forms.GroupBox();
        this.button_CreateDWORDValueForm_Cancel = new System.Windows.Forms.Button();
        this.button_CreateDWORDValueForm_OK = new System.Windows.Forms.Button();
        this.label_CreateDWORDValueForm_ValueData = new System.Windows.Forms.Label();
        this.label_CreateDWORDValueForm_ValueName = new System.Windows.Forms.Label();
        this.textBox_CreateDWORDValueForm_ValueName = new System.Windows.Forms.TextBox();
        this.numericUpDown_CreateDWORDValueForm_ValueData = new System.Windows.Forms.NumericUpDown();
        this.groupBox_CreateDWORDValueForm_Base.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CreateDWORDValueForm_ValueData)).BeginInit();
        this.SuspendLayout();
        // 
        // radioButton_CreateDWORDValueForm_Base_Hex
        // 
        this.radioButton_CreateDWORDValueForm_Base_Hex.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.radioButton_CreateDWORDValueForm_Base_Hex.Location = new System.Drawing.Point(8, 24);
        this.radioButton_CreateDWORDValueForm_Base_Hex.Name = "radioButton_CreateDWORDValueForm_Base_Hex";
        this.radioButton_CreateDWORDValueForm_Base_Hex.Size = new System.Drawing.Size(152, 16);
        this.radioButton_CreateDWORDValueForm_Base_Hex.TabIndex = 0;
        this.radioButton_CreateDWORDValueForm_Base_Hex.Text = "Hexidecimal";
        this.radioButton_CreateDWORDValueForm_Base_Hex.CheckedChanged += new System.EventHandler(this.radioButton_CreateDWORDValueForm_Base_Hex_CheckedChanged);
        // 
        // radioButton_CreateDWORDValueForm_Base_Decimal
        // 
        this.radioButton_CreateDWORDValueForm_Base_Decimal.Checked = true;
        this.radioButton_CreateDWORDValueForm_Base_Decimal.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.radioButton_CreateDWORDValueForm_Base_Decimal.Location = new System.Drawing.Point(8, 40);
        this.radioButton_CreateDWORDValueForm_Base_Decimal.Name = "radioButton_CreateDWORDValueForm_Base_Decimal";
        this.radioButton_CreateDWORDValueForm_Base_Decimal.Size = new System.Drawing.Size(152, 16);
        this.radioButton_CreateDWORDValueForm_Base_Decimal.TabIndex = 1;
        this.radioButton_CreateDWORDValueForm_Base_Decimal.TabStop = true;
        this.radioButton_CreateDWORDValueForm_Base_Decimal.Text = "Decimal";
        this.radioButton_CreateDWORDValueForm_Base_Decimal.CheckedChanged += new System.EventHandler(this.radioButton_CreateDWORDValueForm_Base_Decimal_CheckedChanged);
        // 
        // groupBox_CreateDWORDValueForm_Base
        // 
        this.groupBox_CreateDWORDValueForm_Base.Controls.Add(this.radioButton_CreateDWORDValueForm_Base_Decimal);
        this.groupBox_CreateDWORDValueForm_Base.Controls.Add(this.radioButton_CreateDWORDValueForm_Base_Hex);
        this.groupBox_CreateDWORDValueForm_Base.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_CreateDWORDValueForm_Base.Location = new System.Drawing.Point(136, 64);
        this.groupBox_CreateDWORDValueForm_Base.Name = "groupBox_CreateDWORDValueForm_Base";
        this.groupBox_CreateDWORDValueForm_Base.Size = new System.Drawing.Size(168, 64);
        this.groupBox_CreateDWORDValueForm_Base.TabIndex = 2;
        this.groupBox_CreateDWORDValueForm_Base.TabStop = false;
        this.groupBox_CreateDWORDValueForm_Base.Text = "Base";
        // 
        // button_CreateDWORDValueForm_Cancel
        // 
        this.button_CreateDWORDValueForm_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_CreateDWORDValueForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_CreateDWORDValueForm_Cancel.Location = new System.Drawing.Point(224, 136);
        this.button_CreateDWORDValueForm_Cancel.Name = "button_CreateDWORDValueForm_Cancel";
        this.button_CreateDWORDValueForm_Cancel.Size = new System.Drawing.Size(80, 23);
        this.button_CreateDWORDValueForm_Cancel.TabIndex = 22;
        this.button_CreateDWORDValueForm_Cancel.Text = "Cancel";
        this.button_CreateDWORDValueForm_Cancel.Click += new System.EventHandler(this.button_CreateDWORDValueForm_Cancel_Click);
        // 
        // button_CreateDWORDValueForm_OK
        // 
        this.button_CreateDWORDValueForm_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.button_CreateDWORDValueForm_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_CreateDWORDValueForm_OK.Location = new System.Drawing.Point(136, 136);
        this.button_CreateDWORDValueForm_OK.Name = "button_CreateDWORDValueForm_OK";
        this.button_CreateDWORDValueForm_OK.Size = new System.Drawing.Size(80, 23);
        this.button_CreateDWORDValueForm_OK.TabIndex = 21;
        this.button_CreateDWORDValueForm_OK.Text = "OK";
        this.button_CreateDWORDValueForm_OK.Click += new System.EventHandler(this.button_CreateDWORDValueForm_OK_Click);
        // 
        // label_CreateDWORDValueForm_ValueData
        // 
        this.label_CreateDWORDValueForm_ValueData.Location = new System.Drawing.Point(8, 64);
        this.label_CreateDWORDValueForm_ValueData.Name = "label_CreateDWORDValueForm_ValueData";
        this.label_CreateDWORDValueForm_ValueData.Size = new System.Drawing.Size(120, 16);
        this.label_CreateDWORDValueForm_ValueData.TabIndex = 20;
        this.label_CreateDWORDValueForm_ValueData.Text = "Value data:";
        // 
        // label_CreateDWORDValueForm_ValueName
        // 
        this.label_CreateDWORDValueForm_ValueName.Location = new System.Drawing.Point(8, 16);
        this.label_CreateDWORDValueForm_ValueName.Name = "label_CreateDWORDValueForm_ValueName";
        this.label_CreateDWORDValueForm_ValueName.Size = new System.Drawing.Size(288, 16);
        this.label_CreateDWORDValueForm_ValueName.TabIndex = 19;
        this.label_CreateDWORDValueForm_ValueName.Text = "Value name:";
        // 
        // textBox_CreateDWORDValueForm_ValueName
        // 
        this.textBox_CreateDWORDValueForm_ValueName.Location = new System.Drawing.Point(8, 32);
        this.textBox_CreateDWORDValueForm_ValueName.MaxLength = 128;
        this.textBox_CreateDWORDValueForm_ValueName.Name = "textBox_CreateDWORDValueForm_ValueName";
        this.textBox_CreateDWORDValueForm_ValueName.Size = new System.Drawing.Size(296, 20);
        this.textBox_CreateDWORDValueForm_ValueName.TabIndex = 17;
        // 
        // numericUpDown_CreateDWORDValueForm_ValueData
        // 
        this.numericUpDown_CreateDWORDValueForm_ValueData.InterceptArrowKeys = false;
        this.numericUpDown_CreateDWORDValueForm_ValueData.Location = new System.Drawing.Point(8, 80);
        this.numericUpDown_CreateDWORDValueForm_ValueData.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
        this.numericUpDown_CreateDWORDValueForm_ValueData.Name = "numericUpDown_CreateDWORDValueForm_ValueData";
        this.numericUpDown_CreateDWORDValueForm_ValueData.Size = new System.Drawing.Size(120, 20);
        this.numericUpDown_CreateDWORDValueForm_ValueData.TabIndex = 23;
        this.numericUpDown_CreateDWORDValueForm_ValueData.ValueChanged += new System.EventHandler(this.numericUpDown_CreateDWORDValueForm_ValueData_ValueChanged);
        // 
        // CreateDWORDValueForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(314, 168);
        this.Controls.Add(this.numericUpDown_CreateDWORDValueForm_ValueData);
        this.Controls.Add(this.button_CreateDWORDValueForm_Cancel);
        this.Controls.Add(this.button_CreateDWORDValueForm_OK);
        this.Controls.Add(this.label_CreateDWORDValueForm_ValueData);
        this.Controls.Add(this.label_CreateDWORDValueForm_ValueName);
        this.Controls.Add(this.textBox_CreateDWORDValueForm_ValueName);
        this.Controls.Add(this.groupBox_CreateDWORDValueForm_Base);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CreateDWORDValueForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Shown += new System.EventHandler(this.CreateDWORDValueForm_Shown);
        this.groupBox_CreateDWORDValueForm_Base.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CreateDWORDValueForm_ValueData)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

	}
	#endregion


	private void button_CreateDWORDValueForm_OK_Click(object sender, System.EventArgs e)
	{
		SuccessClose();
	}

	
	private void button_CreateDWORDValueForm_Cancel_Click(object sender, System.EventArgs e)
	{
		this.Close();
	}


	private void radioButton_CreateDWORDValueForm_Base_Hex_CheckedChanged(object sender, System.EventArgs e)
	{
		int int_Value = (int)this.numericUpDown_CreateDWORDValueForm_ValueData.Value;

		this.numericUpDown_CreateDWORDValueForm_ValueData.Hexadecimal = this.radioButton_CreateDWORDValueForm_Base_Hex.Checked;		

		this.numericUpDown_CreateDWORDValueForm_ValueData.Value = int_Value;
	}

	
	private void radioButton_CreateDWORDValueForm_Base_Decimal_CheckedChanged(object sender, System.EventArgs e)
	{
		int int_Value = (int)this.numericUpDown_CreateDWORDValueForm_ValueData.Value;

		this.numericUpDown_CreateDWORDValueForm_ValueData.Hexadecimal = this.radioButton_CreateDWORDValueForm_Base_Hex.Checked;		

		this.numericUpDown_CreateDWORDValueForm_ValueData.Value = int_Value;	
	}
	

	private void numericUpDown_CreateDWORDValueForm_ValueData_ValueChanged(object sender, System.EventArgs e)
	{
		int int_Value = (int)this.numericUpDown_CreateDWORDValueForm_ValueData.Value;

		this.numericUpDown_CreateDWORDValueForm_ValueData.Hexadecimal = this.radioButton_CreateDWORDValueForm_Base_Hex.Checked;		

		this.numericUpDown_CreateDWORDValueForm_ValueData.Value = int_Value;	
	}
	
	public bool ValueNameReadOnly
	{
		get
		{
			return this.textBox_CreateDWORDValueForm_ValueName.ReadOnly;
		}

		set
		{
			this.textBox_CreateDWORDValueForm_ValueName.ReadOnly = value;
			this.numericUpDown_CreateDWORDValueForm_ValueData.Select();
		}
	}
	
	string string_ValueName;	
	int int_ValueData;

	public int ValueData
	{
		get
		{                
            return int_ValueData;           
		}

		set
        {                
            int_ValueData = value;
                
            this.numericUpDown_CreateDWORDValueForm_ValueData.Value = value;            
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
            this.textBox_CreateDWORDValueForm_ValueName.Text = value;            
		}
	}

    private void CreateDWORDValueForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }


}
