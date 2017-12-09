using Microsoft.Win32;

namespace YakSysRct_Server_WindowsService
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
            this.serviceProcessInstaller_YakSysServer = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller_YakSysServer = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller_YakSysServer
            // 
            this.serviceProcessInstaller_YakSysServer.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller_YakSysServer.Password = null;
            this.serviceProcessInstaller_YakSysServer.Username = null;
            // 
            // serviceInstaller_YakSysServer
            // 
            this.serviceInstaller_YakSysServer.ServiceName = "YakSys RCT Server";
            this.serviceInstaller_YakSysServer.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller_YakSysServer_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller_YakSysServer,
            this.serviceInstaller_YakSysServer});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller_YakSysServer;
        private System.ServiceProcess.ServiceInstaller serviceInstaller_YakSysServer;
    }
}