using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

using YakSys;

	public class PasswordVerificationForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button_PasswordVerivicationForm_Login;
		private System.Windows.Forms.Button button_PasswordVerivicationForm_Quit;
		private System.Windows.Forms.TextBox textBox_PasswordVerivicationForm_Password;
		private System.Windows.Forms.Label label_PasswordVerivicationForm_Password;
		private System.Windows.Forms.GroupBox groupBox_PasswordVerivicationForm_WhenPasswordLost;
		private System.Windows.Forms.Button button_PasswordVerivicationForm_LoginWithOutPassword;
		private System.Windows.Forms.Label label_PasswordVerivicationForm_LostPasswordDecription;
		private System.Windows.Forms.PictureBox pictureBox_PasswordVerivicationForm_Logo;
		private System.Windows.Forms.GroupBox groupBox_PasswordVerivicationForm_Language;
		private System.Windows.Forms.Label label_PasswordVerivicationForm_CurrentLanguage;
		private System.Windows.Forms.ComboBox comboBox_PasswordVerivicationForm_Language;
		private System.Windows.Forms.GroupBox groupBox_Contacts;
		private System.Windows.Forms.RichTextBox richTextBox_About;
		private System.Windows.Forms.Label label_Title;
		private System.Windows.Forms.GroupBox groupBox_PasswordVerivicationForm_Login;

		private System.ComponentModel.Container components = null;

		public PasswordVerificationForm()
		{		
			InitializeComponent();

			this.comboBox_PasswordVerivicationForm_Language.SelectedIndex = MainForm.CurrentLanguage;
		}


		public void ChangeControlsLanguage()
		{
			this.Text = ServerStringFactory.GetString(117, CurrentLanguage);

			this.label_Title.Text = ServerStringFactory.GetString(90, CurrentLanguage);
			
			this.groupBox_Contacts.Text = ServerStringFactory.GetString(89, CurrentLanguage);

			this.richTextBox_About.Text = ServerStringFactory.GetString(2, CurrentLanguage);

			this.label_PasswordVerivicationForm_Password.Text = ServerStringFactory.GetString(16, CurrentLanguage);

			this.groupBox_PasswordVerivicationForm_Language.Text = ServerStringFactory.GetString(118, CurrentLanguage);
			
			this.label_PasswordVerivicationForm_CurrentLanguage.Text = ServerStringFactory.GetString(66, CurrentLanguage);
		
			this.button_PasswordVerivicationForm_Quit.Text = ServerStringFactory.GetString(31, CurrentLanguage);
			
			this.button_PasswordVerivicationForm_Login.Text = ServerStringFactory.GetString(119, CurrentLanguage);
			
			this.button_PasswordVerivicationForm_LoginWithOutPassword.Text = ServerStringFactory.GetString(122, CurrentLanguage);
		
			this.groupBox_PasswordVerivicationForm_WhenPasswordLost.Text = ServerStringFactory.GetString(121, CurrentLanguage);
		
			this.label_PasswordVerivicationForm_LostPasswordDecription.Text = ServerStringFactory.GetString(120, CurrentLanguage);
		}


		protected override void Dispose( bool disposing )
		{
			if(disposing )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordVerificationForm));
            this.button_PasswordVerivicationForm_Login = new System.Windows.Forms.Button();
            this.button_PasswordVerivicationForm_Quit = new System.Windows.Forms.Button();
            this.textBox_PasswordVerivicationForm_Password = new System.Windows.Forms.TextBox();
            this.label_PasswordVerivicationForm_Password = new System.Windows.Forms.Label();
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost = new System.Windows.Forms.GroupBox();
            this.button_PasswordVerivicationForm_LoginWithOutPassword = new System.Windows.Forms.Button();
            this.label_PasswordVerivicationForm_LostPasswordDecription = new System.Windows.Forms.Label();
            this.pictureBox_PasswordVerivicationForm_Logo = new System.Windows.Forms.PictureBox();
            this.groupBox_PasswordVerivicationForm_Language = new System.Windows.Forms.GroupBox();
            this.label_PasswordVerivicationForm_CurrentLanguage = new System.Windows.Forms.Label();
            this.comboBox_PasswordVerivicationForm_Language = new System.Windows.Forms.ComboBox();
            this.groupBox_Contacts = new System.Windows.Forms.GroupBox();
            this.richTextBox_About = new System.Windows.Forms.RichTextBox();
            this.groupBox_PasswordVerivicationForm_Login = new System.Windows.Forms.GroupBox();
            this.label_Title = new System.Windows.Forms.Label();
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PasswordVerivicationForm_Logo)).BeginInit();
            this.groupBox_PasswordVerivicationForm_Language.SuspendLayout();
            this.groupBox_Contacts.SuspendLayout();
            this.groupBox_PasswordVerivicationForm_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_PasswordVerivicationForm_Login
            // 
            this.button_PasswordVerivicationForm_Login.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_PasswordVerivicationForm_Login.Location = new System.Drawing.Point(16, 72);
            this.button_PasswordVerivicationForm_Login.Name = "button_PasswordVerivicationForm_Login";
            this.button_PasswordVerivicationForm_Login.Size = new System.Drawing.Size(80, 23);
            this.button_PasswordVerivicationForm_Login.TabIndex = 1;
            this.button_PasswordVerivicationForm_Login.Text = "Login";
            this.button_PasswordVerivicationForm_Login.Click += new System.EventHandler(this.button_PasswordVerivicationForm_Login_Click);
            // 
            // button_PasswordVerivicationForm_Quit
            // 
            this.button_PasswordVerivicationForm_Quit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_PasswordVerivicationForm_Quit.Location = new System.Drawing.Point(112, 72);
            this.button_PasswordVerivicationForm_Quit.Name = "button_PasswordVerivicationForm_Quit";
            this.button_PasswordVerivicationForm_Quit.Size = new System.Drawing.Size(80, 23);
            this.button_PasswordVerivicationForm_Quit.TabIndex = 2;
            this.button_PasswordVerivicationForm_Quit.Text = "Quit";
            this.button_PasswordVerivicationForm_Quit.Click += new System.EventHandler(this.button_PasswordVerivicationForm_Quit_Click);
            // 
            // textBox_PasswordVerivicationForm_Password
            // 
            this.textBox_PasswordVerivicationForm_Password.Location = new System.Drawing.Point(16, 40);
            this.textBox_PasswordVerivicationForm_Password.Name = "textBox_PasswordVerivicationForm_Password";
            this.textBox_PasswordVerivicationForm_Password.PasswordChar = '*';
            this.textBox_PasswordVerivicationForm_Password.Size = new System.Drawing.Size(176, 20);
            this.textBox_PasswordVerivicationForm_Password.TabIndex = 0;
            // 
            // label_PasswordVerivicationForm_Password
            // 
            this.label_PasswordVerivicationForm_Password.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_PasswordVerivicationForm_Password.Location = new System.Drawing.Point(16, 24);
            this.label_PasswordVerivicationForm_Password.Name = "label_PasswordVerivicationForm_Password";
            this.label_PasswordVerivicationForm_Password.Size = new System.Drawing.Size(176, 16);
            this.label_PasswordVerivicationForm_Password.TabIndex = 3;
            this.label_PasswordVerivicationForm_Password.Text = "Password:";
            // 
            // groupBox_PasswordVerivicationForm_WhenPasswordLost
            // 
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.Controls.Add(this.button_PasswordVerivicationForm_LoginWithOutPassword);
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.Controls.Add(this.label_PasswordVerivicationForm_LostPasswordDecription);
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.Controls.Add(this.pictureBox_PasswordVerivicationForm_Logo);
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.Location = new System.Drawing.Point(16, 232);
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.Name = "groupBox_PasswordVerivicationForm_WhenPasswordLost";
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.Size = new System.Drawing.Size(480, 120);
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.TabIndex = 4;
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.TabStop = false;
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.Text = "When you lost/forgot your password";
            // 
            // button_PasswordVerivicationForm_LoginWithOutPassword
            // 
            this.button_PasswordVerivicationForm_LoginWithOutPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_PasswordVerivicationForm_LoginWithOutPassword.Location = new System.Drawing.Point(24, 80);
            this.button_PasswordVerivicationForm_LoginWithOutPassword.Name = "button_PasswordVerivicationForm_LoginWithOutPassword";
            this.button_PasswordVerivicationForm_LoginWithOutPassword.Size = new System.Drawing.Size(160, 24);
            this.button_PasswordVerivicationForm_LoginWithOutPassword.TabIndex = 4;
            this.button_PasswordVerivicationForm_LoginWithOutPassword.Text = "Login without password";
            this.button_PasswordVerivicationForm_LoginWithOutPassword.Click += new System.EventHandler(this.button_PasswordVerivicationForm_LoginWithOutPassword_Click);
            // 
            // label_PasswordVerivicationForm_LostPasswordDecription
            // 
            this.label_PasswordVerivicationForm_LostPasswordDecription.Location = new System.Drawing.Point(8, 24);
            this.label_PasswordVerivicationForm_LostPasswordDecription.Name = "label_PasswordVerivicationForm_LostPasswordDecription";
            this.label_PasswordVerivicationForm_LostPasswordDecription.Size = new System.Drawing.Size(464, 40);
            this.label_PasswordVerivicationForm_LostPasswordDecription.TabIndex = 0;
            this.label_PasswordVerivicationForm_LostPasswordDecription.Text = "Note: You can login without password but YakSys Server DataBase will be erased" +
                ". All data will be deleted, including Servers list, Proxy list, Auth data and Se" +
                "ttings.";
            // 
            // pictureBox_PasswordVerivicationForm_Logo
            // 
            this.pictureBox_PasswordVerivicationForm_Logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_PasswordVerivicationForm_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_PasswordVerivicationForm_Logo.Image")));
            this.pictureBox_PasswordVerivicationForm_Logo.Location = new System.Drawing.Point(312, 64);
            this.pictureBox_PasswordVerivicationForm_Logo.Name = "pictureBox_PasswordVerivicationForm_Logo";
            this.pictureBox_PasswordVerivicationForm_Logo.Size = new System.Drawing.Size(160, 48);
            this.pictureBox_PasswordVerivicationForm_Logo.TabIndex = 5;
            this.pictureBox_PasswordVerivicationForm_Logo.TabStop = false;
            this.pictureBox_PasswordVerivicationForm_Logo.Click += new System.EventHandler(this.pictureBox_PasswordVerivicationForm_Logo_Click);
            // 
            // groupBox_PasswordVerivicationForm_Language
            // 
            this.groupBox_PasswordVerivicationForm_Language.Controls.Add(this.label_PasswordVerivicationForm_CurrentLanguage);
            this.groupBox_PasswordVerivicationForm_Language.Controls.Add(this.comboBox_PasswordVerivicationForm_Language);
            this.groupBox_PasswordVerivicationForm_Language.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_PasswordVerivicationForm_Language.Location = new System.Drawing.Point(16, 160);
            this.groupBox_PasswordVerivicationForm_Language.Name = "groupBox_PasswordVerivicationForm_Language";
            this.groupBox_PasswordVerivicationForm_Language.Size = new System.Drawing.Size(208, 64);
            this.groupBox_PasswordVerivicationForm_Language.TabIndex = 7;
            this.groupBox_PasswordVerivicationForm_Language.TabStop = false;
            // 
            // label_PasswordVerivicationForm_CurrentLanguage
            // 
            this.label_PasswordVerivicationForm_CurrentLanguage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_PasswordVerivicationForm_CurrentLanguage.Location = new System.Drawing.Point(8, 30);
            this.label_PasswordVerivicationForm_CurrentLanguage.Name = "label_PasswordVerivicationForm_CurrentLanguage";
            this.label_PasswordVerivicationForm_CurrentLanguage.Size = new System.Drawing.Size(88, 16);
            this.label_PasswordVerivicationForm_CurrentLanguage.TabIndex = 1;
            this.label_PasswordVerivicationForm_CurrentLanguage.Text = "Current language:";
            this.label_PasswordVerivicationForm_CurrentLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBox_PasswordVerivicationForm_Language
            // 
            this.comboBox_PasswordVerivicationForm_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PasswordVerivicationForm_Language.Items.AddRange(new object[] {
            "English",
            "Russian"});
            this.comboBox_PasswordVerivicationForm_Language.Location = new System.Drawing.Point(100, 26);
            this.comboBox_PasswordVerivicationForm_Language.Name = "comboBox_PasswordVerivicationForm_Language";
            this.comboBox_PasswordVerivicationForm_Language.Size = new System.Drawing.Size(92, 21);
            this.comboBox_PasswordVerivicationForm_Language.Sorted = true;
            this.comboBox_PasswordVerivicationForm_Language.TabIndex = 3;
            this.comboBox_PasswordVerivicationForm_Language.SelectedIndexChanged += new System.EventHandler(this.comboBox_PasswordVerivicationForm_Language_SelectedIndexChanged);
            // 
            // groupBox_Contacts
            // 
            this.groupBox_Contacts.Controls.Add(this.richTextBox_About);
            this.groupBox_Contacts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_Contacts.Location = new System.Drawing.Point(240, 40);
            this.groupBox_Contacts.Name = "groupBox_Contacts";
            this.groupBox_Contacts.Size = new System.Drawing.Size(256, 184);
            this.groupBox_Contacts.TabIndex = 8;
            this.groupBox_Contacts.TabStop = false;
            this.groupBox_Contacts.Text = "Контактная информация";
            // 
            // richTextBox_About
            // 
            this.richTextBox_About.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox_About.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_About.ForeColor = System.Drawing.SystemColors.ControlText;
            this.richTextBox_About.Location = new System.Drawing.Point(8, 32);
            this.richTextBox_About.Name = "richTextBox_About";
            this.richTextBox_About.ReadOnly = true;
            this.richTextBox_About.Size = new System.Drawing.Size(240, 144);
            this.richTextBox_About.TabIndex = 1;
            this.richTextBox_About.Text = resources.GetString("richTextBox_About.Text");
            // 
            // groupBox_PasswordVerivicationForm_Login
            // 
            this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.button_PasswordVerivicationForm_Quit);
            this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.textBox_PasswordVerivicationForm_Password);
            this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.label_PasswordVerivicationForm_Password);
            this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.button_PasswordVerivicationForm_Login);
            this.groupBox_PasswordVerivicationForm_Login.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_PasswordVerivicationForm_Login.Location = new System.Drawing.Point(16, 40);
            this.groupBox_PasswordVerivicationForm_Login.Name = "groupBox_PasswordVerivicationForm_Login";
            this.groupBox_PasswordVerivicationForm_Login.Size = new System.Drawing.Size(208, 112);
            this.groupBox_PasswordVerivicationForm_Login.TabIndex = 9;
            this.groupBox_PasswordVerivicationForm_Login.TabStop = false;
            // 
            // label_Title
            // 
            this.label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Title.Location = new System.Drawing.Point(112, 16);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(264, 16);
            this.label_Title.TabIndex = 10;
            this.label_Title.Text = "YakSys Connecting Service 0.9.0 для Windows 2000/XP/2003";
            // 
            // PasswordVerificationForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(512, 373);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.groupBox_PasswordVerivicationForm_Login);
            this.Controls.Add(this.groupBox_Contacts);
            this.Controls.Add(this.groupBox_PasswordVerivicationForm_Language);
            this.Controls.Add(this.groupBox_PasswordVerivicationForm_WhenPasswordLost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(518, 398);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(518, 398);
            this.Name = "PasswordVerificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password verification";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PasswordVerificationForm_Closing);
            this.groupBox_PasswordVerivicationForm_WhenPasswordLost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PasswordVerivicationForm_Logo)).EndInit();
            this.groupBox_PasswordVerivicationForm_Language.ResumeLayout(false);
            this.groupBox_Contacts.ResumeLayout(false);
            this.groupBox_PasswordVerivicationForm_Login.ResumeLayout(false);
            this.groupBox_PasswordVerivicationForm_Login.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void button_PasswordVerivicationForm_Login_Click(object sender, System.EventArgs e)
		{	
			if(File.Exists("ConnectingServiceDB") == false || new FileInfo("ConnectingServiceDB").Length < 500)
			{
				this.bool_NeedToClose = true;

				this.Close();

				return;
			}

			FileStream fileStream_ConnectingServiceXMLDB = null;
			
			try
			{		
				
				MemoryStream memoryStream_XMLData = new MemoryStream(),
							 memoryStream_DecryptedXMLData = new MemoryStream(),
							 memoryStream_EncryptedXMLData = null;

				SHA256Managed sHA256Managed_obj = new SHA256Managed();
			
				RijndaelManaged rijndaelManaged_obj = new RijndaelManaged();

				CryptoStream cryptoStream_obj = null;

				fileStream_ConnectingServiceXMLDB = File.Open("ConnectingServiceDB", FileMode.Open, FileAccess.Read);
		
				byte [] byteArray_ComputedXMLDataHash = new byte[32], byteArray_ComputedHashOfPasswordHash = new byte[32],
						byteArray_StoredXMLDataHash = new byte[32], byteArray_StoredHashOfPasswordHash = new byte[32],
						byteArray_DecompressedXMLData = null, byteArray_ComputedPasswordHash, byteArray_ConnectingServiceDBHeader = new byte[22],
						byteArray_EncryptedXMLData = new byte[fileStream_ConnectingServiceXMLDB.Length - 88];
				
				byte byte_ToEncryptServerDataBase = 0, byte_ToCompressSettingsDataBase = 0;

				fileStream_ConnectingServiceXMLDB.Read(byteArray_ConnectingServiceDBHeader, 0, byteArray_ConnectingServiceDBHeader.Length);

                if (CommonMethods.AreBytesArraysEquals(System.Text.Encoding.Default.GetBytes("ConnectingServiceDB010"), byteArray_ConnectingServiceDBHeader) == false)
				{
					fileStream_ConnectingServiceXMLDB.Close();

					MessageBox.Show(ServerStringFactory.GetString(124, CurrentLanguage), ServerStringFactory.GetString(1, CurrentLanguage));
			
					this.bool_NeedToClose = true;

					this.Close();

					return;
				}

				byte_ToEncryptServerDataBase = (byte)fileStream_ConnectingServiceXMLDB.ReadByte();
				byte_ToCompressSettingsDataBase = (byte)fileStream_ConnectingServiceXMLDB.ReadByte();

				fileStream_ConnectingServiceXMLDB.Read(byteArray_StoredXMLDataHash, 0, byteArray_StoredXMLDataHash.Length);
				fileStream_ConnectingServiceXMLDB.Read(byteArray_StoredHashOfPasswordHash, 0, byteArray_StoredHashOfPasswordHash.Length);
				
				if(byte_ToEncryptServerDataBase == 1)  
				{
					byteArray_ComputedPasswordHash = sHA256Managed_obj.ComputeHash(System.Text.Encoding.Default.GetBytes(this.textBox_PasswordVerivicationForm_Password.Text));
					byteArray_ComputedHashOfPasswordHash = sHA256Managed_obj.ComputeHash(byteArray_ComputedPasswordHash);

                    if (CommonMethods.AreBytesArraysEquals(byteArray_ComputedHashOfPasswordHash, byteArray_StoredHashOfPasswordHash) == false)
					{
						MessageBox.Show(ServerStringFactory.GetString(126, CurrentLanguage), ServerStringFactory.GetString(1, CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			
						return;
					}           
					
					rijndaelManaged_obj.KeySize = 256;

					rijndaelManaged_obj.Key = byteArray_ComputedPasswordHash;
					rijndaelManaged_obj.IV = new byte[rijndaelManaged_obj.BlockSize/8];

				
					fileStream_ConnectingServiceXMLDB.Read(byteArray_EncryptedXMLData, 0, byteArray_EncryptedXMLData.Length);
			
					memoryStream_EncryptedXMLData = new MemoryStream(byteArray_EncryptedXMLData);


					cryptoStream_obj = new CryptoStream(memoryStream_EncryptedXMLData, rijndaelManaged_obj.CreateDecryptor(), CryptoStreamMode.Read);

					while(true)
					{
						int int_Byte = cryptoStream_obj.ReadByte();

						if(int_Byte == -1) break;

						memoryStream_DecryptedXMLData.WriteByte((byte)int_Byte);
					}

					memoryStream_EncryptedXMLData.Close();

					cryptoStream_obj.Flush();						
					cryptoStream_obj.Clear();
					cryptoStream_obj.Close();

					
					CommonEnvironment.EncryptSettingsDataBase = true;
					CommonEnvironment.LocalSecurityPassword = this.textBox_PasswordVerivicationForm_Password.Text;

					memoryStream_XMLData = new MemoryStream(memoryStream_DecryptedXMLData.ToArray());

					memoryStream_DecryptedXMLData.Close();
				}

				if(byte_ToCompressSettingsDataBase == 1)
				{					
					byteArray_DecompressedXMLData = new YakSys.Compression.CommonEnvironment().Decompress(memoryStream_XMLData.ToArray(), false);

					memoryStream_XMLData = new MemoryStream(byteArray_DecompressedXMLData);

					CommonEnvironment.CompressSettingsDataBase = true;
				}
				else CommonEnvironment.CompressSettingsDataBase = false;

				fileStream_ConnectingServiceXMLDB.Close();

				ConnectingServiceDBSupplier ConnectingServiceDBSupplier_obj = new ConnectingServiceDBSupplier();

				ConnectingServiceDBSupplier_obj.RetriveServerSettingsData(memoryStream_XMLData);	

				memoryStream_XMLData.Close();

				this.bool_NeedToClose = true;

				this.Close();
			}

			catch(Exception)
			{
				MessageBox.Show(ServerStringFactory.GetString(125, CurrentLanguage), ServerStringFactory.GetString(1, CurrentLanguage));
			}

			finally
			{
				fileStream_ConnectingServiceXMLDB.Close();
			}
		}

	
		private void button_PasswordVerivicationForm_Quit_Click(object sender, System.EventArgs e)
		{			
			System.Diagnostics.Process.GetCurrentProcess().Kill();			
		}

		
		private void button_PasswordVerivicationForm_LoginWithOutPassword_Click(object sender, System.EventArgs e)
		{					
			if(DialogResult.No == MessageBox.Show( ServerStringFactory.GetString(123, CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage),MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			return;
		
			try
			{
				File.Delete("ConnectingServiceDB");

				new ConnectingServiceDBSupplier().InitMainServerXmlDB();

				bool_NeedToClose = true;

				this.Close();
			}

			catch(Exception)
			{

			}
		}

		bool bool_NeedToClose = false;

		
		private void pictureBox_PasswordVerivicationForm_Logo_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.YakSys.net");
		}

		
		private void comboBox_PasswordVerivicationForm_Language_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CurrentLanguage = comboBox_PasswordVerivicationForm_Language.SelectedIndex;

			this.ChangeControlsLanguage();
		}

	
		int int_CurrentLanguage = 0;

		private void PasswordVerificationForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(bool_NeedToClose == false)
			System.Diagnostics.Process.GetCurrentProcess().Kill();			
		}

	
		int CurrentLanguage
		{
			get
			{
				return int_CurrentLanguage;
			}

			set
			{
				int_CurrentLanguage = value;
			}
		}


	}
