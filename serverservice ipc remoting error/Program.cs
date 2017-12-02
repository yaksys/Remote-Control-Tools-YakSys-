using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace JsRct_Server_WindowsService
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThreadAttribute]
        static void Main()
        {
            // More than one user Service may run within the same process. To add
            // another service to this process, change the following line to
            // create a second service object. For example,
            //
            //   ServicesToRun = new ServiceBase[] {new JurikSoftServerWindowsService(), new MySecondUserService()};
            //            

            ServiceBase ServicesToRun = new JurikSoftServerWindowsService();
            
            ServiceBase.Run(ServicesToRun);
        }
    }
}