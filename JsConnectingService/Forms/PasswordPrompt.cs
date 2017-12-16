using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

	public class PasswordPromptForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox_PasswordVerivicationForm_Login;
		private System.Windows.Forms.Button button_PasswordPromptForm_Cancel;
		private System.Windows.Forms.TextBox textBox_PasswordPromptForm_Password;
		private System.Windows.Forms.Label label_PasswordPromptForm_Password;
		private System.Windows.Forms.Button button_PasswordPromptForm_Accept;
		private System.Windows.Forms.Label label_PasswordPromptForm_Descpription;

		private System.ComponentModel.Container components = null;

		public PasswordPromptForm()
		{		
			InitializeComponent();		

			ChangeControlsLanguage();
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
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PasswordPromptForm));
			this.groupBox_PasswordVerivicationForm_Login = new System.Windows.Forms.GroupBox();
			this.button_PasswordPromptForm_Cancel = new System.Windows.Forms.Button();
			this.textBox_PasswordPromptForm_Password = new System.Windows.Forms.TextBox();
			this.label_PasswordPromptForm_Password = new System.Windows.Forms.Label();
			this.button_PasswordPromptForm_Accept = new System.Windows.Forms.Button();
			this.label_PasswordPromptForm_Descpription = new System.Windows.Forms.Label();
			this.groupBox_PasswordVerivicationForm_Login.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_PasswordVerivicationForm_Login
			// 
			this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.button_PasswordPromptForm_Cancel);
			this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.textBox_PasswordPromptForm_Password);
			this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.label_PasswordPromptForm_Password);
			this.groupBox_PasswordVerivicationForm_Login.Controls.Add(this.button_PasswordPromptForm_Accept);
			this.groupBox_PasswordVerivicationForm_Login.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox_PasswordVerivicationForm_Login.Location = new System.Drawing.Point(16, 64);
			this.groupBox_PasswordVerivicationForm_Login.Name = "groupBox_PasswordVerivicationForm_Login";
			this.groupBox_PasswordVerivicationForm_Login.Size = new System.Drawing.Size(208, 112);
			this.groupBox_PasswordVerivicationForm_Login.TabIndex = 10;
			this.groupBox_PasswordVerivicationForm_Login.TabStop = false;
			// 
			// button_PasswordPromptForm_Cancel
			// 
			this.button_PasswordPromptForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button_PasswordPromptForm_Cancel.Location = new System.Drawing.Point(112, 72);
			this.button_PasswordPromptForm_Cancel.Name = "button_PasswordPromptForm_Cancel";
			this.button_PasswordPromptForm_Cancel.Size = new System.Drawing.Size(80, 23);
			this.button_PasswordPromptForm_Cancel.TabIndex = 2;
			this.button_PasswordPromptForm_Cancel.Text = "Cancel";
			this.button_PasswordPromptForm_Cancel.Click += new System.EventHandler(this.button_PasswordPromptForm_Cancel_Click);
			// 
			// textBox_PasswordPromptForm_Password
			// 
			this.textBox_PasswordPromptForm_Password.Location = new System.Drawing.Point(16, 40);
			this.textBox_PasswordPromptForm_Password.Name = "textBox_PasswordPromptForm_Password";
			this.textBox_PasswordPromptForm_Password.PasswordChar = '*';
			this.textBox_PasswordPromptForm_Password.Size = new System.Drawing.Size(176, 20);
			this.textBox_PasswordPromptForm_Password.TabIndex = 0;
			this.textBox_PasswordPromptForm_Password.Text = "";
			// 
			// label_PasswordPromptForm_Password
			// 
			this.label_PasswordPromptForm_Password.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label_PasswordPromptForm_Password.Location = new System.Drawing.Point(16, 24);
			this.label_PasswordPromptForm_Password.Name = "label_PasswordPromptForm_Password";
			this.label_PasswordPromptForm_Password.Size = new System.Drawing.Size(176, 16);
			this.label_PasswordPromptForm_Password.TabIndex = 3;
			this.label_PasswordPromptForm_Password.Text = "Password:";
			// 
			// button_PasswordPromptForm_Accept
			// 
			this.button_PasswordPromptForm_Accept.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button_PasswordPromptForm_Accept.Location = new System.Drawing.Point(16, 72);
			this.button_PasswordPromptForm_Accept.Name = "button_PasswordPromptForm_Accept";
			this.button_PasswordPromptForm_Accept.Size = new System.Drawing.Size(80, 23);
			this.button_PasswordPromptForm_Accept.TabIndex = 1;
			this.button_PasswordPromptForm_Accept.Text = "Accept";
			this.button_PasswordPromptForm_Accept.Click += new System.EventHandler(this.button_PasswordPromptForm_Accept_Click);
			// 
			// label_PasswordPromptForm_Descpription
			// 
			this.label_PasswordPromptForm_Descpription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label_PasswordPromptForm_Descpription.Location = new System.Drawing.Point(16, 8);
			this.label_PasswordPromptForm_Descpription.Name = "label_PasswordPromptForm_Descpription";
			this.label_PasswordPromptForm_Descpription.Size = new System.Drawing.Size(216, 48);
			this.label_PasswordPromptForm_Descpription.TabIndex = 11;
			this.label_PasswordPromptForm_Descpription.Text = "Selected DataBase file was encrypted.Please enter password to decrypt data.";
			this.label_PasswordPromptForm_Descpription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PasswordPromptForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(242, 192);
			this.Controls.Add(this.label_PasswordPromptForm_Descpription);
			this.Controls.Add(this.groupBox_PasswordVerivicationForm_Login);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PasswordPromptForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.groupBox_PasswordVerivicationForm_Login.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void button_PasswordPromptForm_Cancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		
		public void ChangeControlsLanguage()
		{
			this.Text = ServerStringFactory.GetString(117, MainForm.CurrentLanguage);

			this.label_PasswordPromptForm_Password.Text = ServerStringFactory.GetString(16, MainForm.CurrentLanguage);
			
			this.label_PasswordPromptForm_Descpription.Text = ServerStringFactory.GetString(151, MainForm.CurrentLanguage);
			
			this.button_PasswordPromptForm_Cancel.Text = ServerStringFactory.GetString(86, MainForm.CurrentLanguage);
		
			this.button_PasswordPromptForm_Accept.Text = ServerStringFactory.GetString(119, MainForm.CurrentLanguage);
		}

	
		string string_DBFileName = "";

		public string DBFileName
		{
			set
			{
				string_DBFileName = value;
			}
			get
			{
				return string_DBFileName;
			}
		}


		public void DecryptDB()
		{
			if(File.Exists(DBFileName) == false || new FileInfo(DBFileName).Length < 500)
			{			
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

				fileStream_ConnectingServiceXMLDB = File.Open(DBFileName, FileMode.Open, FileAccess.Read);
		
				byte [] byteArray_ComputedXMLDataHash = new byte[32], byteArray_ComputedHashOfPasswordHash = new byte[32],
					byteArray_StoredXMLDataHash = new byte[32], byteArray_StoredHashOfPasswordHash = new byte[32],
					byteArray_DecompressedXMLData = null, byteArray_ComputedPasswordHash, byteArray_ConnectingServiceDBHeader = new byte[22],
					byteArray_EncryptedXMLData = new byte[fileStream_ConnectingServiceXMLDB.Length - 88];
				
				byte byte_ToEncryptServerDataBase = 0, byte_ToCompressSettingsDataBase = 0;

				fileStream_ConnectingServiceXMLDB.Read(byteArray_ConnectingServiceDBHeader, 0, byteArray_ConnectingServiceDBHeader.Length);

                if (CommonMethods.AreBytesArraysEquals(System.Text.Encoding.Default.GetBytes("ConnectingServiceDB010"), byteArray_ConnectingServiceDBHeader) == false)
				{
					fileStream_ConnectingServiceXMLDB.Close();

					MessageBox.Show(ServerStringFactory.GetString(124, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));
			
					this.Close();

					return;
				}

				byte_ToEncryptServerDataBase = (byte)fileStream_ConnectingServiceXMLDB.ReadByte();
				byte_ToCompressSettingsDataBase = (byte)fileStream_ConnectingServiceXMLDB.ReadByte();

				fileStream_ConnectingServiceXMLDB.Read(byteArray_StoredXMLDataHash, 0, byteArray_StoredXMLDataHash.Length);
				fileStream_ConnectingServiceXMLDB.Read(byteArray_StoredHashOfPasswordHash, 0, byteArray_StoredHashOfPasswordHash.Length);
				
				if(byte_ToEncryptServerDataBase == 1)  
				{
					byteArray_ComputedPasswordHash = sHA256Managed_obj.ComputeHash(System.Text.Encoding.Default.GetBytes(this.textBox_PasswordPromptForm_Password.Text));
					byteArray_ComputedHashOfPasswordHash = sHA256Managed_obj.ComputeHash(byteArray_ComputedPasswordHash);

                    if (CommonMethods.AreBytesArraysEquals(byteArray_ComputedHashOfPasswordHash, byteArray_StoredHashOfPasswordHash) == false)
					{
						MessageBox.Show(ServerStringFactory.GetString(126, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			
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
					CommonEnvironment.LocalSecurityPassword = this.textBox_PasswordPromptForm_Password.Text;

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
	
				ObjCopy.obj_MainForm.SetUpServerSettingsFromDB();	
				
				memoryStream_XMLData.Close();
				this.Close();
			}

			catch(Exception)
			{
				MessageBox.Show(ServerStringFactory.GetString(125, MainForm.CurrentLanguage), ServerStringFactory.GetString(1, MainForm.CurrentLanguage));
			}
			finally
			{
				fileStream_ConnectingServiceXMLDB.Close();
			}
		}



		private void button_PasswordPromptForm_Accept_Click(object sender, System.EventArgs e)
		{
			DecryptDB();		
		}






	}

