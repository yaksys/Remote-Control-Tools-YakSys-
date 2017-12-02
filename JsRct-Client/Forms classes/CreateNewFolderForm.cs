using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

public class CreateNewFolderForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.Button button_CreateNewFolderForm_Cancel;
	private System.Windows.Forms.Button button_CreateNewFolderForm_OK;
	private System.Windows.Forms.TextBox textBox_CreateNewFolderForm_NewFolderName;
	private System.Windows.Forms.Label label_CreateNewFolderForm_EditNewFolderName;

	private System.ComponentModel.Container components = null;

	public void ChangeControlsLanguage()
	{
		this.Text = ClientStringFactory.GetString(6 , ClientSettingsEnvironment.CurrentLanguage);
		
		this.label_CreateNewFolderForm_EditNewFolderName.Text = ClientStringFactory.GetString(4 , ClientSettingsEnvironment.CurrentLanguage);

		this.button_CreateNewFolderForm_OK.Text = ClientStringFactory.GetString(175 , ClientSettingsEnvironment.CurrentLanguage);
	
		this.button_CreateNewFolderForm_Cancel.Text = ClientStringFactory.GetString(5 , ClientSettingsEnvironment.CurrentLanguage);
	}

    public CreateNewFolderForm()
	{
		InitializeComponent();

		ChangeControlsLanguage();
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

	private void InitializeComponent()
	{
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewFolderForm));
        this.textBox_CreateNewFolderForm_NewFolderName = new System.Windows.Forms.TextBox();
        this.label_CreateNewFolderForm_EditNewFolderName = new System.Windows.Forms.Label();
        this.button_CreateNewFolderForm_Cancel = new System.Windows.Forms.Button();
        this.button_CreateNewFolderForm_OK = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // textBox_CreateNewFolderForm_NewFolderName
        // 
        this.textBox_CreateNewFolderForm_NewFolderName.Location = new System.Drawing.Point(8, 32);
        this.textBox_CreateNewFolderForm_NewFolderName.Name = "textBox_CreateNewFolderForm_NewFolderName";
        this.textBox_CreateNewFolderForm_NewFolderName.Size = new System.Drawing.Size(272, 20);
        this.textBox_CreateNewFolderForm_NewFolderName.TabIndex = 0;
        // 
        // label_CreateNewFolderForm_EditNewFolderName
        // 
        this.label_CreateNewFolderForm_EditNewFolderName.Location = new System.Drawing.Point(8, 16);
        this.label_CreateNewFolderForm_EditNewFolderName.Name = "label_CreateNewFolderForm_EditNewFolderName";
        this.label_CreateNewFolderForm_EditNewFolderName.Size = new System.Drawing.Size(272, 16);
        this.label_CreateNewFolderForm_EditNewFolderName.TabIndex = 1;
        // 
        // button_CreateNewFolderForm_Cancel
        // 
        this.button_CreateNewFolderForm_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_CreateNewFolderForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_CreateNewFolderForm_Cancel.Location = new System.Drawing.Point(152, 64);
        this.button_CreateNewFolderForm_Cancel.Name = "button_CreateNewFolderForm_Cancel";
        this.button_CreateNewFolderForm_Cancel.Size = new System.Drawing.Size(96, 23);
        this.button_CreateNewFolderForm_Cancel.TabIndex = 2;
        this.button_CreateNewFolderForm_Cancel.Click += new System.EventHandler(this.button_CreateNewFolderForm_Cancel_Click);
        // 
        // button_CreateNewFolderForm_OK
        // 
        this.button_CreateNewFolderForm_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_CreateNewFolderForm_OK.Location = new System.Drawing.Point(40, 64);
        this.button_CreateNewFolderForm_OK.Name = "button_CreateNewFolderForm_OK";
        this.button_CreateNewFolderForm_OK.Size = new System.Drawing.Size(96, 23);
        this.button_CreateNewFolderForm_OK.TabIndex = 3;
        this.button_CreateNewFolderForm_OK.Click += new System.EventHandler(this.button_CreateNewFolderForm_OK_Click);
        // 
        // CreateNewFolderForm
        // 
        this.AcceptButton = this.button_CreateNewFolderForm_OK;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.CancelButton = this.button_CreateNewFolderForm_Cancel;
        this.ClientSize = new System.Drawing.Size(306, 112);
        this.Controls.Add(this.button_CreateNewFolderForm_OK);
        this.Controls.Add(this.button_CreateNewFolderForm_Cancel);
        this.Controls.Add(this.label_CreateNewFolderForm_EditNewFolderName);
        this.Controls.Add(this.textBox_CreateNewFolderForm_NewFolderName);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(312, 144);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(312, 144);
        this.Name = "CreateNewFolderForm";
        this.ShowInTaskbar = false;
        this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Shown += new System.EventHandler(this.CreateNewFolderForm_Shown);
        this.ResumeLayout(false);
        this.PerformLayout();

	}
		#endregion
	
	private void button_CreateNewFolderForm_OK_Click(object sender, System.EventArgs e)
	{
		if( textBox_CreateNewFolderForm_NewFolderName.Text == "") return;

		if( 
			textBox_CreateNewFolderForm_NewFolderName.Text.IndexOf("*")  != -1 ||
			textBox_CreateNewFolderForm_NewFolderName.Text.IndexOf("<")  != -1 ||
			textBox_CreateNewFolderForm_NewFolderName.Text.IndexOf(">")  != -1 ||
			textBox_CreateNewFolderForm_NewFolderName.Text.IndexOf(":")  != -1 ||
			textBox_CreateNewFolderForm_NewFolderName.Text.IndexOf("?")  != -1 ||
			textBox_CreateNewFolderForm_NewFolderName.Text.IndexOf("\"") != -1 ||
			textBox_CreateNewFolderForm_NewFolderName.Text.IndexOf("|")  != -1 ||
			textBox_CreateNewFolderForm_NewFolderName.Text.IndexOf("/")  != -1 ||
			textBox_CreateNewFolderForm_NewFolderName.Text.IndexOf("\\") != -1 
			) 
		{
			MessageBox.Show(ClientStringFactory.GetString(230, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(51, ClientSettingsEnvironment.CurrentLanguage));			
			return;
		}

        try
        {
            RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

            obj_RemoteCallAction.CurrentFilePath = ObjCopy.obj_MainClientForm.CurrentFilePath;
            obj_RemoteCallAction.NameOfNewFolder = NameOfNewFolder;

            new Thread(new ThreadStart(obj_RemoteCallAction.CreateNewFolder)).Start();

        }
        catch(Exception exception_obj)
        {
        
        }
        finally
        {
            this.Close();
        }
	}
    	
	private void button_CreateNewFolderForm_Cancel_Click(object sender, System.EventArgs e)
	{
		this.Close();
	}
    
    private void CreateNewFolderForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }
	
    public string NameOfNewFolder
	{
		get
		{
			return textBox_CreateNewFolderForm_NewFolderName.Text;
		}
	}
}

