using Microsoft.Win32;

namespace JsRct_Server_WindowsService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller_JurikSoftServer = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller_JurikSoftServer = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller_JurikSoftServer
            // 
            this.serviceProcessInstaller_JurikSoftServer.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller_JurikSoftServer.Password = null;
            this.serviceProcessInstaller_JurikSoftServer.Username = null;
            // 
            // serviceInstaller_JurikSoftServer
            // 
            this.serviceInstaller_JurikSoftServer.ServiceName = "JurikSoft Server";
            this.serviceInstaller_JurikSoftServer.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller_JurikSoftServer_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller_JurikSoftServer,
            this.serviceInstaller_JurikSoftServer});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller_JurikSoftServer;
        private System.ServiceProcess.ServiceInstaller serviceInstaller_JurikSoftServer;
    }
}