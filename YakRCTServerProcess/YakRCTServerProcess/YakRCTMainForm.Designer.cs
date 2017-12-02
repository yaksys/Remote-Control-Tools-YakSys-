namespace YakRCTServerProcess
{
    partial class Form_yakServer_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_yakServer_Main));
            this.button_StartYakRCT = new System.Windows.Forms.Button();
            this.button_StopRCT = new System.Windows.Forms.Button();
            this.button_ServerGUI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_StartYakRCT
            // 
            this.button_StartYakRCT.Location = new System.Drawing.Point(13, 49);
            this.button_StartYakRCT.Name = "button_StartYakRCT";
            this.button_StartYakRCT.Size = new System.Drawing.Size(75, 23);
            this.button_StartYakRCT.TabIndex = 0;
            this.button_StartYakRCT.Text = "Start RCT";
            this.button_StartYakRCT.UseVisualStyleBackColor = true;
            this.button_StartYakRCT.Click += new System.EventHandler(this.button_StartYakRCT_Click);
            // 
            // button_StopRCT
            // 
            this.button_StopRCT.Location = new System.Drawing.Point(13, 78);
            this.button_StopRCT.Name = "button_StopRCT";
            this.button_StopRCT.Size = new System.Drawing.Size(75, 23);
            this.button_StopRCT.TabIndex = 1;
            this.button_StopRCT.Text = "Stop RCT";
            this.button_StopRCT.UseVisualStyleBackColor = true;
            this.button_StopRCT.Click += new System.EventHandler(this.button_StopRCT_Click);
            // 
            // button_ServerGUI
            // 
            this.button_ServerGUI.Location = new System.Drawing.Point(13, 108);
            this.button_ServerGUI.Name = "button_ServerGUI";
            this.button_ServerGUI.Size = new System.Drawing.Size(75, 23);
            this.button_ServerGUI.TabIndex = 2;
            this.button_ServerGUI.Text = "Server GUI";
            this.button_ServerGUI.UseVisualStyleBackColor = true;
            this.button_ServerGUI.Click += new System.EventHandler(this.button_ServerGUI_Click);
            // 
            // Form_yakServer_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button_ServerGUI);
            this.Controls.Add(this.button_StopRCT);
            this.Controls.Add(this.button_StartYakRCT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_yakServer_Main";
            this.Text = "RCT Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_yakServer_Main_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_StartYakRCT;
        private System.Windows.Forms.Button button_StopRCT;
        private System.Windows.Forms.Button button_ServerGUI;
    }
}

