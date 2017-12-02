namespace JurikSoft_Server_Service_Controller
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.serviceController_Main = new System.ServiceProcess.ServiceController();
            this.button_MainForm_ServiceStart = new System.Windows.Forms.Button();
            this.button_MainForm_ServiceStop = new System.Windows.Forms.Button();
            this.label_MainForm_ServiceStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serviceController_Main
            // 
            this.serviceController_Main.MachineName = "localhost";
            this.serviceController_Main.ServiceName = "JurikSoft Server";
            // 
            // button_MainForm_ServiceStart
            // 
            this.button_MainForm_ServiceStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_MainForm_ServiceStart.Image = ((System.Drawing.Image)(resources.GetObject("button_MainForm_ServiceStart.Image")));
            this.button_MainForm_ServiceStart.Location = new System.Drawing.Point(232, 24);
            this.button_MainForm_ServiceStart.Name = "button_MainForm_ServiceStart";
            this.button_MainForm_ServiceStart.Size = new System.Drawing.Size(24, 24);
            this.button_MainForm_ServiceStart.TabIndex = 0;
            this.button_MainForm_ServiceStart.UseVisualStyleBackColor = true;
            this.button_MainForm_ServiceStart.Click += new System.EventHandler(this.button_MainForm_ServiceStart_Click);
            this.button_MainForm_ServiceStart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MainForm_ServiceStart_MouseMove);
            // 
            // button_MainForm_ServiceStop
            // 
            this.button_MainForm_ServiceStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_MainForm_ServiceStop.Image = ((System.Drawing.Image)(resources.GetObject("button_MainForm_ServiceStop.Image")));
            this.button_MainForm_ServiceStop.Location = new System.Drawing.Point(262, 24);
            this.button_MainForm_ServiceStop.Name = "button_MainForm_ServiceStop";
            this.button_MainForm_ServiceStop.Size = new System.Drawing.Size(24, 24);
            this.button_MainForm_ServiceStop.TabIndex = 2;
            this.button_MainForm_ServiceStop.UseVisualStyleBackColor = true;
            this.button_MainForm_ServiceStop.Click += new System.EventHandler(this.button_MainForm_ServiceStop_Click);
            this.button_MainForm_ServiceStop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MainForm_ServiceStop_MouseMove);
            // 
            // label_MainForm_ServiceStatus
            // 
            this.label_MainForm_ServiceStatus.AutoSize = true;
            this.label_MainForm_ServiceStatus.Location = new System.Drawing.Point(9, 30);
            this.label_MainForm_ServiceStatus.Name = "label_MainForm_ServiceStatus";
            this.label_MainForm_ServiceStatus.Size = new System.Drawing.Size(79, 13);
            this.label_MainForm_ServiceStatus.TabIndex = 3;
            this.label_MainForm_ServiceStatus.Text = "Service Status:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 65);
            this.Controls.Add(this.label_MainForm_ServiceStatus);
            this.Controls.Add(this.button_MainForm_ServiceStop);
            this.Controls.Add(this.button_MainForm_ServiceStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JurikSoft Server Service Controller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ServiceProcess.ServiceController serviceController_Main;
        private System.Windows.Forms.Button button_MainForm_ServiceStart;
        private System.Windows.Forms.Button button_MainForm_ServiceStop;
        private System.Windows.Forms.Label label_MainForm_ServiceStatus;
    }
}

