using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Remote_Control_Tools_ProcWindow
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThreadAttribute]
        static void Main()
        {
            //_hookID = SetHook(_proc);///!!!!!

            //UnhookWindowsHookEx(_hookID); ///!!!!!  

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Main());
        }
    }
}
