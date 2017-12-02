namespace JurikSoft_Universal_KeyGen
{
    partial class Form_JurikSoftUniversalKeyGen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_JurikSoftUniversalKeyGen));
            this.label_SoftwareList = new System.Windows.Forms.Label();
            this.label_RegistrationName = new System.Windows.Forms.Label();
            this.textBox_RegistrationName = new System.Windows.Forms.TextBox();
            this.comboBox_SoftwareList = new System.Windows.Forms.ComboBox();
            this.textBox_GeneratedSerialNumber = new System.Windows.Forms.TextBox();
            this.label_GeneratedSerialNumber = new System.Windows.Forms.Label();
            this.pictureBox_Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // label_SoftwareList
            // 
            this.label_SoftwareList.AutoSize = true;
            this.label_SoftwareList.Location = new System.Drawing.Point(12, 9);
            this.label_SoftwareList.Name = "label_SoftwareList";
            this.label_SoftwareList.Size = new System.Drawing.Size(71, 13);
            this.label_SoftwareList.TabIndex = 0;
            this.label_SoftwareList.Text = "Software List:";
            // 
            // label_RegistrationName
            // 
            this.label_RegistrationName.AutoSize = true;
            this.label_RegistrationName.Location = new System.Drawing.Point(12, 65);
            this.label_RegistrationName.Name = "label_RegistrationName";
            this.label_RegistrationName.Size = new System.Drawing.Size(97, 13);
            this.label_RegistrationName.TabIndex = 1;
            this.label_RegistrationName.Text = "Registration Name:";
            // 
            // textBox_RegistrationName
            // 
            this.textBox_RegistrationName.Location = new System.Drawing.Point(15, 81);
            this.textBox_RegistrationName.Name = "textBox_RegistrationName";
            this.textBox_RegistrationName.Size = new System.Drawing.Size(217, 20);
            this.textBox_RegistrationName.TabIndex = 2;
            this.textBox_RegistrationName.TextChanged += new System.EventHandler(this.textBox_RegistrationName_TextChanged);
            // 
            // comboBox_SoftwareList
            // 
            this.comboBox_SoftwareList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SoftwareList.FormattingEnabled = true;
            this.comboBox_SoftwareList.Items.AddRange(new object[] {
            "Remote Control Tools 0.6.0",
            "Remote Control Tools 0.7.0",
            "Remote Control Tools 0.8.0",
            "Remote Control Tools 0.9.0",
            "Remote Control Tools 1.0.0",
            "Proxy Provider 1.1.0",
            "Compression Library 1.1.0"});
            this.comboBox_SoftwareList.Location = new System.Drawing.Point(15, 25);
            this.comboBox_SoftwareList.Name = "comboBox_SoftwareList";
            this.comboBox_SoftwareList.Size = new System.Drawing.Size(217, 21);
            this.comboBox_SoftwareList.TabIndex = 3;
            this.comboBox_SoftwareList.SelectedIndexChanged += new System.EventHandler(this.comboBox_SoftwareList_SelectedIndexChanged);
            // 
            // textBox_GeneratedSerialNumber
            // 
            this.textBox_GeneratedSerialNumber.Location = new System.Drawing.Point(15, 124);
            this.textBox_GeneratedSerialNumber.Name = "textBox_GeneratedSerialNumber";
            this.textBox_GeneratedSerialNumber.ReadOnly = true;
            this.textBox_GeneratedSerialNumber.Size = new System.Drawing.Size(217, 20);
            this.textBox_GeneratedSerialNumber.TabIndex = 4;
            // 
            // label_GeneratedSerialNumber
            // 
            this.label_GeneratedSerialNumber.AutoSize = true;
            this.label_GeneratedSerialNumber.Location = new System.Drawing.Point(12, 108);
            this.label_GeneratedSerialNumber.Name = "label_GeneratedSerialNumber";
            this.label_GeneratedSerialNumber.Size = new System.Drawing.Size(129, 13);
            this.label_GeneratedSerialNumber.TabIndex = 5;
            this.label_GeneratedSerialNumber.Text = "Generated Serial Number:";
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Logo.Image")));
            this.pictureBox_Logo.Location = new System.Drawing.Point(261, 25);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.pictureBox_Logo.Size = new System.Drawing.Size(155, 46);
            this.pictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Logo.TabIndex = 6;
            this.pictureBox_Logo.TabStop = false;
            // 
            // Form_JurikSoftUniversalKeyGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 163);
            this.Controls.Add(this.pictureBox_Logo);
            this.Controls.Add(this.label_GeneratedSerialNumber);
            this.Controls.Add(this.textBox_GeneratedSerialNumber);
            this.Controls.Add(this.comboBox_SoftwareList);
            this.Controls.Add(this.textBox_RegistrationName);
            this.Controls.Add(this.label_RegistrationName);
            this.Controls.Add(this.label_SoftwareList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(451, 197);
            this.MinimumSize = new System.Drawing.Size(451, 197);
            this.Name = "Form_JurikSoftUniversalKeyGen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JurikSoft Universal KeyGen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_SoftwareList;
        private System.Windows.Forms.Label label_RegistrationName;
        private System.Windows.Forms.TextBox textBox_RegistrationName;
        private System.Windows.Forms.ComboBox comboBox_SoftwareList;
        private System.Windows.Forms.TextBox textBox_GeneratedSerialNumber;
        private System.Windows.Forms.Label label_GeneratedSerialNumber;
        private System.Windows.Forms.PictureBox pictureBox_Logo;
    }
}

