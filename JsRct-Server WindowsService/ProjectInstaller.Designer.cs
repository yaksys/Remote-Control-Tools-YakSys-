namespace RCT_Server_Windows_Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller_YakSysServer = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller_YakSysServer = new System.ServiceProcess.ServiceInstaller();
            this.serviceController_YakSysServer = new System.ServiceProcess.ServiceController();
            // 
            // serviceProcessInstaller_YakSysServer
            // 
            this.serviceProcessInstaller_YakSysServer.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller_YakSysServer.Password = null;
            this.serviceProcessInstaller_YakSysServer.Username = null;
            this.serviceProcessInstaller_YakSysServer.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller_YakSysServer_AfterInstall);
            this.serviceProcessInstaller_YakSysServer.AfterUninstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller_YakSysServer_AfterUninstall);
            // 
            // serviceInstaller_YakSysServer
            // 
            this.serviceInstaller_YakSysServer.DisplayName = "YakSys RCT Server";
            this.serviceInstaller_YakSysServer.ServiceName = "YakSys RCT Server";
            this.serviceInstaller_YakSysServer.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.serviceInstaller_YakSysServer.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller_YakSysServer_AfterInstall);
            // 
            // serviceController_YakSysServer
            // 
            this.serviceController_YakSysServer.ServiceName = "YakSys RCT Server";
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
        private System.ServiceProcess.ServiceController serviceController_YakSysServer;
    }
}