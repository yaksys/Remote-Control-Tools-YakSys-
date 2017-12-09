using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using Microsoft.Win32;
using System.ServiceProcess;
using System.Management;


namespace YakSysRct_Server_WindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();   
        }

        private void serviceInstaller_YakSysServer_AfterInstall(object sender, InstallEventArgs e)
        {

            ServiceController serviceController_obj = new ServiceController("YakSys RCT Server");

            #region Allow Desktop Interact Mode

            ConnectionOptions connectionOptions_obj = new ConnectionOptions();

            connectionOptions_obj.Impersonation = ImpersonationLevel.Impersonate;

            ManagementScope managementScope_obj = new System.Management.ManagementScope(@"root\CIMV2", connectionOptions_obj);

            managementScope_obj.Connect();

            ManagementObject managementObject_obj = new ManagementObject("Win32_Service.Name='" + serviceController_obj.ServiceName + "'");

            ManagementBaseObject managementBaseObject_DesktopInteract = managementObject_obj.GetMethodParameters("Change");

            managementBaseObject_DesktopInteract["DesktopInteract"] = true;

            managementObject_obj.InvokeMethod("Change", managementBaseObject_DesktopInteract, null);
            
            #endregion

            managementObject_obj.InvokeMethod("ChangeStartMode", new object[1] { "Automatic" });
                        
            serviceController_obj.Start();

        }
    }
}