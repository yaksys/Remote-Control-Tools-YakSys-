using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace JurikSoft_Universal_KeyGen
{
    public partial class Form_JurikSoftUniversalKeyGen : Form
    {
        public Form_JurikSoftUniversalKeyGen()
        {
            InitializeComponent();

            this.comboBox_SoftwareList.SelectedIndex = 4;
        }

        public void GenerateSerialNumber()
        {
            if (textBox_RegistrationName.Text.Length < 1)
            {
                textBox_GeneratedSerialNumber.Text = string.Empty;

                return;
            }

            string string_FullRegistrationName = textBox_RegistrationName.Text;

            MD5CryptoServiceProvider MD5Object_Key = new MD5CryptoServiceProvider();
            
            SHA256Managed SHA256Managed_Key = new SHA256Managed();

            SHA512Managed SHA512Managed_Key = new SHA512Managed();

            byte[] byteArray_KeyHash = null;

            string string_CurrentNubmer = null;

            int int_GenerationFactor = 0;

            #region Init Generation Factor and Crypto Algorithm

            switch (this.comboBox_SoftwareList.SelectedIndex)
            {
                case 0:
                    {
                        byteArray_KeyHash = MD5Object_Key.ComputeHash(Encoding.Unicode.GetBytes(string_FullRegistrationName));
                                                
                        int_GenerationFactor = 1;
                    }
                    break;

                case 1:
                    {
                        byteArray_KeyHash = MD5Object_Key.ComputeHash(Encoding.Unicode.GetBytes(string_FullRegistrationName));
                       
                        int_GenerationFactor = 1;
                    }
                    break;

                case 2:
                    {
                        byteArray_KeyHash = MD5Object_Key.ComputeHash(Encoding.Unicode.GetBytes(string_FullRegistrationName));
                       
                        int_GenerationFactor = 3;
                    }
                    break;

                case 3:
                    {
                        byteArray_KeyHash = MD5Object_Key.ComputeHash(Encoding.Unicode.GetBytes(string_FullRegistrationName));
                       
                        int_GenerationFactor = 7;
                    }
                    break;

                case 4:
                    {
                        byteArray_KeyHash = MD5Object_Key.ComputeHash(Encoding.Unicode.GetBytes(string_FullRegistrationName));
                       
                        int_GenerationFactor = 8;
                    }
                    break;

                case 5:
                    {
                        byteArray_KeyHash = SHA512Managed_Key.ComputeHash(Encoding.Unicode.GetBytes(string_FullRegistrationName));
                       
                        int_GenerationFactor = 4;
                    }
                    break;

                case 6:
                    {
                        byteArray_KeyHash = SHA256Managed_Key.ComputeHash(Encoding.Unicode.GetBytes(string_FullRegistrationName));
                        
                        int_GenerationFactor = 1;
                    }
                    break;
            }

            #endregion

            for (int int_CycleCount = 0; byteArray_KeyHash.Length != int_CycleCount; int_CycleCount++)
            {
                string_CurrentNubmer += (byteArray_KeyHash[int_CycleCount] * int_GenerationFactor).ToString();
            }

            this.textBox_GeneratedSerialNumber.Text = string_CurrentNubmer.Substring(0, 10);

            return;
        }

        private void textBox_RegistrationName_TextChanged(object sender, EventArgs e)
        {
            GenerateSerialNumber();
        }

        private void comboBox_SoftwareList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateSerialNumber();
        }
    }
}