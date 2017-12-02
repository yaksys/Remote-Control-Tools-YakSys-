using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

    public partial class AdditionalParametersForm : Form
    {
        public AdditionalParametersForm()
        {
            InitializeComponent();

            this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Value = CommonEnvironment.MaxConnections;
            this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Value = CommonEnvironment.MaxConnectionsPerAccount;
        }

        private void button_AdditionalParameters_OK_Click(object sender, EventArgs e)
        {
            CommonEnvironment.MaxConnections = (int)this.numericUpDown_AdditionalNetworkParameters_MaxConnections.Value;
            CommonEnvironment.MaxConnectionsPerAccount = (int)this.numericUpDown_AdditionalNetworkParameters_MaxConnectionsPerAccount.Value;

            this.Close();
        }

        private void button_AdditionalParameters_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

