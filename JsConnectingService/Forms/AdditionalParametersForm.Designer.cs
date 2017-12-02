
    partial class AdditionalParametersForm
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
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters = new System.Windows.Forms.GroupBox();
            this.label_AdditionalNetworkParameters_MaxConnections = new System.Windows.Forms.Label();
            this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount = new System.Windows.Forms.Label();
            this.numericUpDown_AdditionalNetworkParameters_MaxConnections = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount = new System.Windows.Forms.NumericUpDown();
            this.button_AdditionalParameters_Cancel = new System.Windows.Forms.Button();
            this.button_AdditionalParameters_OK = new System.Windows.Forms.Button();
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AdditionalNetworkParameters_MaxConnections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_AdditionalParameters_AdditionalNetworkParameters
            // 
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Controls.Add(this.label_AdditionalNetworkParameters_MaxConnections);
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Controls.Add(this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount);
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Controls.Add(this.numericUpDown_AdditionalNetworkParameters_MaxConnections);
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Controls.Add(this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount);
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Location = new System.Drawing.Point(14, 13);
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Name = "groupBox_AdditionalParameters_AdditionalNetworkParameters";
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Size = new System.Drawing.Size(368, 94);
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.TabIndex = 9;
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.TabStop = false;
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.Text = "Additional Network Parameters";
            // 
            // label_AdditionalNetworkParameters_MaxConnections
            // 
            this.label_AdditionalNetworkParameters_MaxConnections.Location = new System.Drawing.Point(12, 24);
            this.label_AdditionalNetworkParameters_MaxConnections.Name = "label_AdditionalNetworkParameters_MaxConnections";
            this.label_AdditionalNetworkParameters_MaxConnections.Size = new System.Drawing.Size(280, 24);
            this.label_AdditionalNetworkParameters_MaxConnections.TabIndex = 0;
            this.label_AdditionalNetworkParameters_MaxConnections.Text = "Max. simultaneous connections amount:";
            this.label_AdditionalNetworkParameters_MaxConnections.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_AdditionalNetworkParameters_MaxConnectionsPerAccount
            // 
            this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.Location = new System.Drawing.Point(12, 56);
            this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.Name = "label_AdditionalNetworkParameters_MaxConnectionsPerAccount";
            this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.Size = new System.Drawing.Size(280, 24);
            this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.TabIndex = 1;
            this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.Text = "Max. simultaneous connections per each account:";
            this.label_AdditionalNetworkParameters_MaxConnectionsPerAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_AdditionalNetworkParameters_MaxConnections
            // 
            this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Location = new System.Drawing.Point(300, 24);
            this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Name = "numericUpDown_AdditionalNetworkParameters_MaxConnections";
            this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_AdditionalNetworkParameters_MaxConnections.TabIndex = 2;
            this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount
            // 
            this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Location = new System.Drawing.Point(300, 56);
            this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Name = "numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount";
            this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.TabIndex = 3;
            this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_AdditionalParameters_Cancel
            // 
            this.button_AdditionalParameters_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_AdditionalParameters_Cancel.Location = new System.Drawing.Point(207, 126);
            this.button_AdditionalParameters_Cancel.Name = "button_AdditionalParameters_Cancel";
            this.button_AdditionalParameters_Cancel.Size = new System.Drawing.Size(88, 23);
            this.button_AdditionalParameters_Cancel.TabIndex = 8;
            this.button_AdditionalParameters_Cancel.Text = "Cancel";
            this.button_AdditionalParameters_Cancel.Click += new System.EventHandler(this.button_AdditionalParameters_Cancel_Click);
            // 
            // button_AdditionalParameters_OK
            // 
            this.button_AdditionalParameters_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_AdditionalParameters_OK.Location = new System.Drawing.Point(103, 126);
            this.button_AdditionalParameters_OK.Name = "button_AdditionalParameters_OK";
            this.button_AdditionalParameters_OK.Size = new System.Drawing.Size(88, 23);
            this.button_AdditionalParameters_OK.TabIndex = 7;
            this.button_AdditionalParameters_OK.Text = "OK";
            this.button_AdditionalParameters_OK.Click += new System.EventHandler(this.button_AdditionalParameters_OK_Click);
            // 
            // AdditionalParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 162);
            this.Controls.Add(this.groupBox_AdditionalParameters_AdditionalNetworkParameters);
            this.Controls.Add(this.button_AdditionalParameters_Cancel);
            this.Controls.Add(this.button_AdditionalParameters_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdditionalParametersForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AdditionalParametersForm";
            this.groupBox_AdditionalParameters_AdditionalNetworkParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AdditionalNetworkParameters_MaxConnections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_AdditionalParameters_AdditionalNetworkParameters;
        private System.Windows.Forms.Label label_AdditionalNetworkParameters_MaxConnections;
        private System.Windows.Forms.Label label_AdditionalNetworkParameters_MaxConnectionsPerAccount;
        private System.Windows.Forms.NumericUpDown numericUpDown_AdditionalNetworkParameters_MaxConnections;
        private System.Windows.Forms.NumericUpDown numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount;
        private System.Windows.Forms.Button button_AdditionalParameters_Cancel;
        private System.Windows.Forms.Button button_AdditionalParameters_OK;
    }
