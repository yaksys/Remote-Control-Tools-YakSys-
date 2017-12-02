using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JurikSoft.Compression;


namespace Multiple_Desktop_Management
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void button_NetworkControl_Disconnect_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("far.exe", FileMode.Open);
            
            byte[] uncomp = new byte[fs.Length];
           
            fs.Read(uncomp, 0, uncomp.Length);
                        
            ICompression iCompressionArray_obj = new LZSS(8, true, true, false, 131072);

            DateTime dt1 = DateTime.Now;
           
            byte [] compress = iCompressionArray_obj.Compress(uncomp, false);

            DateTime dt2 = DateTime.Now;

            TimeSpan ts1 = dt2 - dt1;

            MessageBox.Show(ts1.Minutes.ToString() + ":" + ts1.Seconds.ToString() + ":" + ts1.Milliseconds.ToString());
        }
    }
}