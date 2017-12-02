using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JurikSoft_Universal_KeyGen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_JurikSoftUniversalKeyGen());
        }
    }
}