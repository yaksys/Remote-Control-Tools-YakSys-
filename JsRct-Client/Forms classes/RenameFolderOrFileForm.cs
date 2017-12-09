using System.Threading;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;

public class RenameFolderOrFileForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.Button button_RenameFolderOrFileForm_Rename;
	private System.Windows.Forms.Button button_RenameFolderOrFileForm_Cancel;
	private System.Windows.Forms.TextBox textBox_RenameFolderOrFileForm_OldItemName;
	private System.Windows.Forms.Label label_RenameFolderOrFileForm_OldItemName;
	private System.Windows.Forms.TextBox textBox_RenameFolderOrFileForm_NewItemName;
	private System.Windows.Forms.Label label_RenameFolderOrFileForm_NewItemName;

	private System.ComponentModel.Container components = null;

	public RenameFolderOrFileForm()
	{

		InitializeComponent();

		ChangeControlsLanguage();
		
	}

	public void ChangeControlsLanguage()
	{
		this.Text = ClientStringFactory.GetString(250 , ClientSettingsEnvironment.CurrentLanguage);
		this.button_RenameFolderOrFileForm_Rename.Text = ClientStringFactory.GetString(86 , ClientSettingsEnvironment.CurrentLanguage);
		this.button_RenameFolderOrFileForm_Cancel.Text = ClientStringFactory.GetString(5 , ClientSettingsEnvironment.CurrentLanguage);
		this.label_RenameFolderOrFileForm_OldItemName.Text = ClientStringFactory.GetString(249 , ClientSettingsEnvironment.CurrentLanguage);
		this.label_RenameFolderOrFileForm_NewItemName.Text = ClientStringFactory.GetString(228 , ClientSettingsEnvironment.CurrentLanguage);
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameFolderOrFileForm));
        this.textBox_RenameFolderOrFileForm_OldItemName = new System.Windows.Forms.TextBox();
        this.textBox_RenameFolderOrFileForm_NewItemName = new System.Windows.Forms.TextBox();
        this.button_RenameFolderOrFileForm_Rename = new System.Windows.Forms.Button();
        this.button_RenameFolderOrFileForm_Cancel = new System.Windows.Forms.Button();
        this.label_RenameFolderOrFileForm_OldItemName = new System.Windows.Forms.Label();
        this.label_RenameFolderOrFileForm_NewItemName = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // textBox_RenameFolderOrFileForm_OldItemName
        // 
        this.textBox_RenameFolderOrFileForm_OldItemName.Location = new System.Drawing.Point(16, 32);
        this.textBox_RenameFolderOrFileForm_OldItemName.Name = "textBox_RenameFolderOrFileForm_OldItemName";
        this.textBox_RenameFolderOrFileForm_OldItemName.ReadOnly = true;
        this.textBox_RenameFolderOrFileForm_OldItemName.Size = new System.Drawing.Size(216, 20);
        this.textBox_RenameFolderOrFileForm_OldItemName.TabIndex = 3;
        // 
        // textBox_RenameFolderOrFileForm_NewItemName
        // 
        this.textBox_RenameFolderOrFileForm_NewItemName.Location = new System.Drawing.Point(16, 80);
        this.textBox_RenameFolderOrFileForm_NewItemName.Name = "textBox_RenameFolderOrFileForm_NewItemName";
        this.textBox_RenameFolderOrFileForm_NewItemName.Size = new System.Drawing.Size(216, 20);
        this.textBox_RenameFolderOrFileForm_NewItemName.TabIndex = 1;
        // 
        // button_RenameFolderOrFileForm_Rename
        // 
        this.button_RenameFolderOrFileForm_Rename.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_RenameFolderOrFileForm_Rename.Location = new System.Drawing.Point(16, 112);
        this.button_RenameFolderOrFileForm_Rename.Name = "button_RenameFolderOrFileForm_Rename";
        this.button_RenameFolderOrFileForm_Rename.Size = new System.Drawing.Size(112, 23);
        this.button_RenameFolderOrFileForm_Rename.TabIndex = 0;
        this.button_RenameFolderOrFileForm_Rename.Click += new System.EventHandler(this.button_RenameFolderOrFileForm_Rename_Click);
        // 
        // button_RenameFolderOrFileForm_Cancel
        // 
        this.button_RenameFolderOrFileForm_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_RenameFolderOrFileForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_RenameFolderOrFileForm_Cancel.Location = new System.Drawing.Point(160, 112);
        this.button_RenameFolderOrFileForm_Cancel.Name = "button_RenameFolderOrFileForm_Cancel";
        this.button_RenameFolderOrFileForm_Cancel.Size = new System.Drawing.Size(75, 23);
        this.button_RenameFolderOrFileForm_Cancel.TabIndex = 1;
        this.button_RenameFolderOrFileForm_Cancel.Click += new System.EventHandler(this.button_RenameFolderOrFileForm_Cancel_Click);
        // 
        // label_RenameFolderOrFileForm_OldItemName
        // 
        this.label_RenameFolderOrFileForm_OldItemName.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_RenameFolderOrFileForm_OldItemName.Location = new System.Drawing.Point(16, 16);
        this.label_RenameFolderOrFileForm_OldItemName.Name = "label_RenameFolderOrFileForm_OldItemName";
        this.label_RenameFolderOrFileForm_OldItemName.Size = new System.Drawing.Size(216, 16);
        this.label_RenameFolderOrFileForm_OldItemName.TabIndex = 4;
        // 
        // label_RenameFolderOrFileForm_NewItemName
        // 
        this.label_RenameFolderOrFileForm_NewItemName.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_RenameFolderOrFileForm_NewItemName.Location = new System.Drawing.Point(16, 64);
        this.label_RenameFolderOrFileForm_NewItemName.Name = "label_RenameFolderOrFileForm_NewItemName";
        this.label_RenameFolderOrFileForm_NewItemName.Size = new System.Drawing.Size(216, 16);
        this.label_RenameFolderOrFileForm_NewItemName.TabIndex = 5;
        // 
        // RenameFolderOrFileForm
        // 
        this.AcceptButton = this.button_RenameFolderOrFileForm_Rename;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.CancelButton = this.button_RenameFolderOrFileForm_Cancel;
        this.ClientSize = new System.Drawing.Size(250, 152);
        this.Controls.Add(this.label_RenameFolderOrFileForm_NewItemName);
        this.Controls.Add(this.label_RenameFolderOrFileForm_OldItemName);
        this.Controls.Add(this.button_RenameFolderOrFileForm_Cancel);
        this.Controls.Add(this.button_RenameFolderOrFileForm_Rename);
        this.Controls.Add(this.textBox_RenameFolderOrFileForm_NewItemName);
        this.Controls.Add(this.textBox_RenameFolderOrFileForm_OldItemName);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(256, 184);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(256, 184);
        this.Name = "RenameFolderOrFileForm";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Shown += new System.EventHandler(this.RenameFolderOrFileForm_Shown);
        this.ResumeLayout(false);
        this.PerformLayout();

	}
		#endregion

	private void button_RenameFolderOrFileForm_Rename_Click(object sender, System.EventArgs e)
	{

		if( textBox_RenameFolderOrFileForm_NewItemName.Text == "") 
		{
			MessageBox.Show(ClientStringFactory.GetString(229, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage));	
			return;
		}
		if( 
			textBox_RenameFolderOrFileForm_NewItemName.Text.IndexOf("*")  != -1 ||
			textBox_RenameFolderOrFileForm_NewItemName.Text.IndexOf("<")  != -1 ||
			textBox_RenameFolderOrFileForm_NewItemName.Text.IndexOf(">")  != -1 ||
			textBox_RenameFolderOrFileForm_NewItemName.Text.IndexOf(":")  != -1 ||
			textBox_RenameFolderOrFileForm_NewItemName.Text.IndexOf("?")  != -1 ||
			textBox_RenameFolderOrFileForm_NewItemName.Text.IndexOf("\"") != -1 ||
			textBox_RenameFolderOrFileForm_NewItemName.Text.IndexOf("|")  != -1 ||
			textBox_RenameFolderOrFileForm_NewItemName.Text.IndexOf("/")  != -1 ||
			textBox_RenameFolderOrFileForm_NewItemName.Text.IndexOf("\\") != -1 
			) 
		{
			MessageBox.Show(ClientStringFactory.GetString(230, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(51, ClientSettingsEnvironment.CurrentLanguage));			
			return;
		}

		if( !MainTcpClient.IsConnected ) 
		{
			MessageBox.Show(ObjCopy.obj_MainClientForm, ClientStringFactory.GetString(213, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Information);
			
            return;
		}
		
		else
		{
			try
			{

				RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();
	
				obj_RemoteCallAction.LastSelectedNameOfFolderOrFileWithPath = LastSelectedNameOfFolderOrFileWithPath;

				string string_NewNameOfFolderOrFileWithPath = LastSelectedNameOfFolderOrFileWithPath;

				string_NewNameOfFolderOrFileWithPath = string_NewNameOfFolderOrFileWithPath.Remove(string_NewNameOfFolderOrFileWithPath.LastIndexOf("\\"),
				string_NewNameOfFolderOrFileWithPath.Length-string_NewNameOfFolderOrFileWithPath.LastIndexOf("\\"));
				
				obj_RemoteCallAction.CurrentFilePath = string_NewNameOfFolderOrFileWithPath+"\\";
				
				obj_RemoteCallAction.NewNameOfFolderOrFile = string_NewNameOfFolderOrFileWithPath+"\\"+textBox_RenameFolderOrFileForm_NewItemName.Text;

				new Thread(new ThreadStart(obj_RemoteCallAction.RenameFolderOrFile)).Start();
			}
			
			catch (Exception exception_obj) 
			{

			}     
		}

		Close();

	}

	private void button_RenameFolderOrFileForm_Cancel_Click(object sender, System.EventArgs e)
	{

	}

	public string RenameFolderOrFileName 
	{
		set
		{
			textBox_RenameFolderOrFileForm_OldItemName.Text = value;
		}
	}

	#region Properties 

	string string_LastSelectedNameOfFolderOrFile, string_LastSelectedNameOfFolderOrFileWithPath;
    
	public string LastSelectedNameOfFolderOrFile
	{
		get
		{
			return string_LastSelectedNameOfFolderOrFile;
		}

		set
		{
			string_LastSelectedNameOfFolderOrFile = value;
		}
	}

	public string LastSelectedNameOfFolderOrFileWithPath
	{
		get
		{
			return string_LastSelectedNameOfFolderOrFileWithPath;
		}

		set
		{
			string_LastSelectedNameOfFolderOrFileWithPath = value;
		}
	}

	#endregion

    private void RenameFolderOrFileForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }

}

