using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using YakSys;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;

public class AddNewItemForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.Label label_AddNewItemForm_NewItemName;
	private System.Windows.Forms.Button button_AddNewItemForm_Cancel;
	private System.Windows.Forms.Button button_AddNewItemForm_Add;
	private System.Windows.Forms.TextBox textBox_AddNewItemForm_NewItemName;

	private System.ComponentModel.Container components = null;

	public AddNewItemForm()
	{
		InitializeComponent();

		ChangeControlsLanguage();
	}

		
	void ChangeControlsLanguage()
	{
		this.Text = ClientStringFactory.GetString(504 , ClientSettingsEnvironment.CurrentLanguage);

		this.label_AddNewItemForm_NewItemName.Text = ClientStringFactory.GetString(505 , ClientSettingsEnvironment.CurrentLanguage);
			
		this.button_AddNewItemForm_Cancel.Text = ClientStringFactory.GetString(5 , ClientSettingsEnvironment.CurrentLanguage);
			
		this.button_AddNewItemForm_Add.Text = ClientStringFactory.GetString(311 , ClientSettingsEnvironment.CurrentLanguage);	
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewItemForm));
        this.label_AddNewItemForm_NewItemName = new System.Windows.Forms.Label();
        this.button_AddNewItemForm_Cancel = new System.Windows.Forms.Button();
        this.button_AddNewItemForm_Add = new System.Windows.Forms.Button();
        this.textBox_AddNewItemForm_NewItemName = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // label_AddNewItemForm_NewItemName
        // 
        this.label_AddNewItemForm_NewItemName.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_AddNewItemForm_NewItemName.Location = new System.Drawing.Point(8, 16);
        this.label_AddNewItemForm_NewItemName.Name = "label_AddNewItemForm_NewItemName";
        this.label_AddNewItemForm_NewItemName.Size = new System.Drawing.Size(216, 16);
        this.label_AddNewItemForm_NewItemName.TabIndex = 15;
        // 
        // button_AddNewItemForm_Cancel
        // 
        this.button_AddNewItemForm_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_AddNewItemForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_AddNewItemForm_Cancel.Location = new System.Drawing.Point(136, 64);
        this.button_AddNewItemForm_Cancel.Name = "button_AddNewItemForm_Cancel";
        this.button_AddNewItemForm_Cancel.Size = new System.Drawing.Size(88, 23);
        this.button_AddNewItemForm_Cancel.TabIndex = 14;
        // 
        // button_AddNewItemForm_Add
        // 
        this.button_AddNewItemForm_Add.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.button_AddNewItemForm_Add.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_AddNewItemForm_Add.Location = new System.Drawing.Point(8, 64);
        this.button_AddNewItemForm_Add.Name = "button_AddNewItemForm_Add";
        this.button_AddNewItemForm_Add.Size = new System.Drawing.Size(88, 23);
        this.button_AddNewItemForm_Add.TabIndex = 12;
        this.button_AddNewItemForm_Add.Click += new System.EventHandler(this.button_AddNewItemForm_Add_Click);
        // 
        // textBox_AddNewItemForm_NewItemName
        // 
        this.textBox_AddNewItemForm_NewItemName.Location = new System.Drawing.Point(8, 32);
        this.textBox_AddNewItemForm_NewItemName.Name = "textBox_AddNewItemForm_NewItemName";
        this.textBox_AddNewItemForm_NewItemName.Size = new System.Drawing.Size(216, 20);
        this.textBox_AddNewItemForm_NewItemName.TabIndex = 13;
        this.textBox_AddNewItemForm_NewItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_AddNewItemForm_NewItemName_KeyDown);
        // 
        // AddNewItemForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(234, 96);
        this.Controls.Add(this.label_AddNewItemForm_NewItemName);
        this.Controls.Add(this.button_AddNewItemForm_Cancel);
        this.Controls.Add(this.button_AddNewItemForm_Add);
        this.Controls.Add(this.textBox_AddNewItemForm_NewItemName);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "AddNewItemForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Shown += new System.EventHandler(this.AddNewItemForm_Shown);
        this.Load += new System.EventHandler(this.AddNewItemForm_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

	}
	#endregion

	void SuccessClose()
	{
		NewItemName = this.textBox_AddNewItemForm_NewItemName.Text;

		this.DialogResult = DialogResult.OK;

		this.Close();
	}

	
	private void button_AddNewItemForm_Add_Click(object sender, System.EventArgs e)
	{
		SuccessClose();
	}

	
	private void textBox_AddNewItemForm_NewItemName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		if(e.KeyData == Keys.Enter) SuccessClose();
	}

	
	private void AddNewItemForm_Load(object sender, System.EventArgs e)
	{
		this.textBox_AddNewItemForm_NewItemName.Select();
	}

	
	public string InfoLabelText
	{
		set
		{
			this.label_AddNewItemForm_NewItemName.Text = value;
		}
	}
		
	string string_NewItemName = String.Empty;

	public string NewItemName
	{
		set
		{
			string_NewItemName = value;
		}

		get
		{
			return string_NewItemName;
		}
	}

    private void AddNewItemForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }

}

