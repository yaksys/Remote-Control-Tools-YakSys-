
    partial class Form_Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Microsoft Windows Network");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Active Directory Network");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.button_ServerServiceControl_InstallServer = new System.Windows.Forms.Button();
            this.treeView_Computers = new System.Windows.Forms.TreeView();
            this.label_ServerServiceControl_Login = new System.Windows.Forms.Label();
            this.textBox_ServerServiceControl_Login = new System.Windows.Forms.TextBox();
            this.textBox_ServerServiceControl_Password = new System.Windows.Forms.TextBox();
            this.label_ServerServiceControl_Password = new System.Windows.Forms.Label();
            this.textBox_ServerServiceControl_Address = new System.Windows.Forms.TextBox();
            this.label_ServerServiceControl_Address = new System.Windows.Forms.Label();
            this.button_ServerServiceControl_UninstallServer = new System.Windows.Forms.Button();
            this.groupBox_NetworkComputers = new System.Windows.Forms.GroupBox();
            this.button_ServerServiceControl_GetInformation = new System.Windows.Forms.Button();
            this.textBox_ServerServiceControl_ServiceStatus = new System.Windows.Forms.TextBox();
            this.textBox_ServerServiceControl_Domain = new System.Windows.Forms.TextBox();
            this.label_ServerServiceControl_Domain = new System.Windows.Forms.Label();
            this.button_ServerServiceControl_ServiceStop = new System.Windows.Forms.Button();
            this.button_ServerServiceControl_ServiceStart = new System.Windows.Forms.Button();
            this.textBox_ServerServiceControl_InstallDate = new System.Windows.Forms.TextBox();
            this.textBox_ServerServiceControl_ServiceState = new System.Windows.Forms.TextBox();
            this.comboBox_ServerServiceControl_StartMode = new System.Windows.Forms.ComboBox();
            this.label_ServerServiceControl_StartMode = new System.Windows.Forms.Label();
            this.label_ServerServiceControl_ServiceState = new System.Windows.Forms.Label();
            this.label_ServerServiceControl_InstallDate = new System.Windows.Forms.Label();
            this.label_ServerServiceControl_ServiceStatus = new System.Windows.Forms.Label();
            this.groupBox_ServerServiceControl = new System.Windows.Forms.GroupBox();
            this.label_ServerServiceControl_ProcessID = new System.Windows.Forms.Label();
            this.textBox_ServerServiceControl_ProcessID = new System.Windows.Forms.TextBox();
            this.label_ServerServiceControl_HostAddress = new System.Windows.Forms.Label();
            this.textBox_ServerServiceControl_HostAddress = new System.Windows.Forms.TextBox();
            this.label_ServerServiceControl_HostType = new System.Windows.Forms.Label();
            this.textBox_ServerServiceControl_HostType = new System.Windows.Forms.TextBox();
            this.label_ServerServiceControl_DesktopInteract = new System.Windows.Forms.Label();
            this.textBox_ServerServiceControl_DesktopInteract = new System.Windows.Forms.TextBox();
            this.label_ServerServiceControl_ServiceType = new System.Windows.Forms.Label();
            this.textBox_ServerServiceControl_ServiceType = new System.Windows.Forms.TextBox();
            this.label_ServerServiceControl_ServiceName = new System.Windows.Forms.Label();
            this.textBox_ServerServiceControl_ServiceName = new System.Windows.Forms.TextBox();
            this.menuStrip_MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_NetworkComputers.SuspendLayout();
            this.groupBox_ServerServiceControl.SuspendLayout();
            this.menuStrip_MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ServerServiceControl_InstallServer
            // 
            this.button_ServerServiceControl_InstallServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ServerServiceControl_InstallServer.Location = new System.Drawing.Point(7, 419);
            this.button_ServerServiceControl_InstallServer.Name = "button_ServerServiceControl_InstallServer";
            this.button_ServerServiceControl_InstallServer.Size = new System.Drawing.Size(110, 23);
            this.button_ServerServiceControl_InstallServer.TabIndex = 0;
            this.button_ServerServiceControl_InstallServer.Text = "Install Server";
            this.button_ServerServiceControl_InstallServer.UseVisualStyleBackColor = true;
            this.button_ServerServiceControl_InstallServer.Click += new System.EventHandler(this.button_ServerServiceControl_Install_Click);
            // 
            // treeView_Computers
            // 
            this.treeView_Computers.Location = new System.Drawing.Point(14, 17);
            this.treeView_Computers.Name = "treeView_Computers";
            treeNode13.Name = "treeNode_MicrosoftNetwork";
            treeNode13.Text = "Microsoft Windows Network";
            treeNode14.Name = "treeNode_ADNetwork";
            treeNode14.Text = "Active Directory Network";
            this.treeView_Computers.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            this.treeView_Computers.Size = new System.Drawing.Size(269, 425);
            this.treeView_Computers.TabIndex = 3;
            this.treeView_Computers.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_Computers_BeforeExpand);
            this.treeView_Computers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Computers_AfterSelect);
            // 
            // label_ServerServiceControl_Login
            // 
            this.label_ServerServiceControl_Login.AutoSize = true;
            this.label_ServerServiceControl_Login.Location = new System.Drawing.Point(13, 369);
            this.label_ServerServiceControl_Login.Name = "label_ServerServiceControl_Login";
            this.label_ServerServiceControl_Login.Size = new System.Drawing.Size(36, 13);
            this.label_ServerServiceControl_Login.TabIndex = 4;
            this.label_ServerServiceControl_Login.Text = "Login:";
            // 
            // textBox_ServerServiceControl_Login
            // 
            this.textBox_ServerServiceControl_Login.Location = new System.Drawing.Point(16, 385);
            this.textBox_ServerServiceControl_Login.Name = "textBox_ServerServiceControl_Login";
            this.textBox_ServerServiceControl_Login.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_Login.TabIndex = 5;
            // 
            // textBox_ServerServiceControl_Password
            // 
            this.textBox_ServerServiceControl_Password.Location = new System.Drawing.Point(154, 386);
            this.textBox_ServerServiceControl_Password.Name = "textBox_ServerServiceControl_Password";
            this.textBox_ServerServiceControl_Password.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_Password.TabIndex = 7;
            // 
            // label_ServerServiceControl_Password
            // 
            this.label_ServerServiceControl_Password.AutoSize = true;
            this.label_ServerServiceControl_Password.Location = new System.Drawing.Point(151, 370);
            this.label_ServerServiceControl_Password.Name = "label_ServerServiceControl_Password";
            this.label_ServerServiceControl_Password.Size = new System.Drawing.Size(56, 13);
            this.label_ServerServiceControl_Password.TabIndex = 6;
            this.label_ServerServiceControl_Password.Text = "Password:";
            // 
            // textBox_ServerServiceControl_Address
            // 
            this.textBox_ServerServiceControl_Address.Location = new System.Drawing.Point(16, 333);
            this.textBox_ServerServiceControl_Address.Name = "textBox_ServerServiceControl_Address";
            this.textBox_ServerServiceControl_Address.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_Address.TabIndex = 9;
            // 
            // label_ServerServiceControl_Address
            // 
            this.label_ServerServiceControl_Address.AutoSize = true;
            this.label_ServerServiceControl_Address.Location = new System.Drawing.Point(13, 317);
            this.label_ServerServiceControl_Address.Name = "label_ServerServiceControl_Address";
            this.label_ServerServiceControl_Address.Size = new System.Drawing.Size(91, 13);
            this.label_ServerServiceControl_Address.TabIndex = 8;
            this.label_ServerServiceControl_Address.Text = "Network Address:";
            // 
            // button_ServerServiceControl_UninstallServer
            // 
            this.button_ServerServiceControl_UninstallServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ServerServiceControl_UninstallServer.Location = new System.Drawing.Point(181, 419);
            this.button_ServerServiceControl_UninstallServer.Name = "button_ServerServiceControl_UninstallServer";
            this.button_ServerServiceControl_UninstallServer.Size = new System.Drawing.Size(110, 23);
            this.button_ServerServiceControl_UninstallServer.TabIndex = 10;
            this.button_ServerServiceControl_UninstallServer.Text = "Uninstall Server";
            this.button_ServerServiceControl_UninstallServer.UseVisualStyleBackColor = true;
            this.button_ServerServiceControl_UninstallServer.Click += new System.EventHandler(this.button_ServerServiceControl_UninstallServer_Click);
            // 
            // groupBox_NetworkComputers
            // 
            this.groupBox_NetworkComputers.Controls.Add(this.treeView_Computers);
            this.groupBox_NetworkComputers.Location = new System.Drawing.Point(11, 34);
            this.groupBox_NetworkComputers.Name = "groupBox_NetworkComputers";
            this.groupBox_NetworkComputers.Size = new System.Drawing.Size(296, 458);
            this.groupBox_NetworkComputers.TabIndex = 11;
            this.groupBox_NetworkComputers.TabStop = false;
            this.groupBox_NetworkComputers.Text = "Network Computers";
            // 
            // button_ServerServiceControl_GetInformation
            // 
            this.button_ServerServiceControl_GetInformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ServerServiceControl_GetInformation.Location = new System.Drawing.Point(86, 279);
            this.button_ServerServiceControl_GetInformation.Name = "button_ServerServiceControl_GetInformation";
            this.button_ServerServiceControl_GetInformation.Size = new System.Drawing.Size(131, 23);
            this.button_ServerServiceControl_GetInformation.TabIndex = 17;
            this.button_ServerServiceControl_GetInformation.Text = "Get Information";
            this.button_ServerServiceControl_GetInformation.UseVisualStyleBackColor = true;
            this.button_ServerServiceControl_GetInformation.Click += new System.EventHandler(this.button_ServerServiceControl_RefreshStatus_Click);
            // 
            // textBox_ServerServiceControl_ServiceStatus
            // 
            this.textBox_ServerServiceControl_ServiceStatus.Location = new System.Drawing.Point(15, 139);
            this.textBox_ServerServiceControl_ServiceStatus.Name = "textBox_ServerServiceControl_ServiceStatus";
            this.textBox_ServerServiceControl_ServiceStatus.ReadOnly = true;
            this.textBox_ServerServiceControl_ServiceStatus.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_ServiceStatus.TabIndex = 16;
            // 
            // textBox_ServerServiceControl_Domain
            // 
            this.textBox_ServerServiceControl_Domain.Location = new System.Drawing.Point(154, 333);
            this.textBox_ServerServiceControl_Domain.Name = "textBox_ServerServiceControl_Domain";
            this.textBox_ServerServiceControl_Domain.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_Domain.TabIndex = 15;
            // 
            // label_ServerServiceControl_Domain
            // 
            this.label_ServerServiceControl_Domain.AutoSize = true;
            this.label_ServerServiceControl_Domain.Location = new System.Drawing.Point(151, 317);
            this.label_ServerServiceControl_Domain.Name = "label_ServerServiceControl_Domain";
            this.label_ServerServiceControl_Domain.Size = new System.Drawing.Size(46, 13);
            this.label_ServerServiceControl_Domain.TabIndex = 14;
            this.label_ServerServiceControl_Domain.Text = "Domain:";
            // 
            // button_ServerServiceControl_ServiceStop
            // 
            this.button_ServerServiceControl_ServiceStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ServerServiceControl_ServiceStop.Image = ((System.Drawing.Image)(resources.GetObject("button_ServerServiceControl_ServiceStop.Image")));
            this.button_ServerServiceControl_ServiceStop.Location = new System.Drawing.Point(153, 418);
            this.button_ServerServiceControl_ServiceStop.Name = "button_ServerServiceControl_ServiceStop";
            this.button_ServerServiceControl_ServiceStop.Size = new System.Drawing.Size(24, 24);
            this.button_ServerServiceControl_ServiceStop.TabIndex = 13;
            this.button_ServerServiceControl_ServiceStop.UseVisualStyleBackColor = true;
            this.button_ServerServiceControl_ServiceStop.Click += new System.EventHandler(this.button_ServerServiceControl_ServiceStop_Click);
            // 
            // button_ServerServiceControl_ServiceStart
            // 
            this.button_ServerServiceControl_ServiceStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ServerServiceControl_ServiceStart.Image = ((System.Drawing.Image)(resources.GetObject("button_ServerServiceControl_ServiceStart.Image")));
            this.button_ServerServiceControl_ServiceStart.Location = new System.Drawing.Point(123, 418);
            this.button_ServerServiceControl_ServiceStart.Name = "button_ServerServiceControl_ServiceStart";
            this.button_ServerServiceControl_ServiceStart.Size = new System.Drawing.Size(24, 24);
            this.button_ServerServiceControl_ServiceStart.TabIndex = 12;
            this.button_ServerServiceControl_ServiceStart.UseVisualStyleBackColor = true;
            this.button_ServerServiceControl_ServiceStart.Click += new System.EventHandler(this.button_ServerServiceControl_ServiceStart_Click);
            // 
            // textBox_ServerServiceControl_InstallDate
            // 
            this.textBox_ServerServiceControl_InstallDate.Location = new System.Drawing.Point(15, 192);
            this.textBox_ServerServiceControl_InstallDate.Name = "textBox_ServerServiceControl_InstallDate";
            this.textBox_ServerServiceControl_InstallDate.ReadOnly = true;
            this.textBox_ServerServiceControl_InstallDate.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_InstallDate.TabIndex = 18;
            // 
            // textBox_ServerServiceControl_ServiceState
            // 
            this.textBox_ServerServiceControl_ServiceState.Location = new System.Drawing.Point(153, 192);
            this.textBox_ServerServiceControl_ServiceState.Name = "textBox_ServerServiceControl_ServiceState";
            this.textBox_ServerServiceControl_ServiceState.ReadOnly = true;
            this.textBox_ServerServiceControl_ServiceState.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_ServiceState.TabIndex = 20;
            // 
            // comboBox_ServerServiceControl_StartMode
            // 
            this.comboBox_ServerServiceControl_StartMode.FormattingEnabled = true;
            this.comboBox_ServerServiceControl_StartMode.Items.AddRange(new object[] {
            "Automatic",
            "Manual",
            "Disabled"});
            this.comboBox_ServerServiceControl_StartMode.Location = new System.Drawing.Point(153, 245);
            this.comboBox_ServerServiceControl_StartMode.Name = "comboBox_ServerServiceControl_StartMode";
            this.comboBox_ServerServiceControl_StartMode.Size = new System.Drawing.Size(131, 21);
            this.comboBox_ServerServiceControl_StartMode.TabIndex = 21;
            this.comboBox_ServerServiceControl_StartMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_ServerServiceControl_StartMode_SelectedIndexChanged);
            // 
            // label_ServerServiceControl_StartMode
            // 
            this.label_ServerServiceControl_StartMode.AutoSize = true;
            this.label_ServerServiceControl_StartMode.Location = new System.Drawing.Point(149, 229);
            this.label_ServerServiceControl_StartMode.Name = "label_ServerServiceControl_StartMode";
            this.label_ServerServiceControl_StartMode.Size = new System.Drawing.Size(101, 13);
            this.label_ServerServiceControl_StartMode.TabIndex = 22;
            this.label_ServerServiceControl_StartMode.Text = "Service Start Mode:";
            // 
            // label_ServerServiceControl_ServiceState
            // 
            this.label_ServerServiceControl_ServiceState.AutoSize = true;
            this.label_ServerServiceControl_ServiceState.Location = new System.Drawing.Point(150, 176);
            this.label_ServerServiceControl_ServiceState.Name = "label_ServerServiceControl_ServiceState";
            this.label_ServerServiceControl_ServiceState.Size = new System.Drawing.Size(74, 13);
            this.label_ServerServiceControl_ServiceState.TabIndex = 23;
            this.label_ServerServiceControl_ServiceState.Text = "Service State:";
            // 
            // label_ServerServiceControl_InstallDate
            // 
            this.label_ServerServiceControl_InstallDate.AutoSize = true;
            this.label_ServerServiceControl_InstallDate.Location = new System.Drawing.Point(13, 176);
            this.label_ServerServiceControl_InstallDate.Name = "label_ServerServiceControl_InstallDate";
            this.label_ServerServiceControl_InstallDate.Size = new System.Drawing.Size(63, 13);
            this.label_ServerServiceControl_InstallDate.TabIndex = 24;
            this.label_ServerServiceControl_InstallDate.Text = "Install Date:";
            // 
            // label_ServerServiceControl_ServiceStatus
            // 
            this.label_ServerServiceControl_ServiceStatus.AutoSize = true;
            this.label_ServerServiceControl_ServiceStatus.Location = new System.Drawing.Point(13, 123);
            this.label_ServerServiceControl_ServiceStatus.Name = "label_ServerServiceControl_ServiceStatus";
            this.label_ServerServiceControl_ServiceStatus.Size = new System.Drawing.Size(79, 13);
            this.label_ServerServiceControl_ServiceStatus.TabIndex = 25;
            this.label_ServerServiceControl_ServiceStatus.Text = "Service Status:";
            // 
            // groupBox_ServerServiceControl
            // 
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_ProcessID);
            this.groupBox_ServerServiceControl.Controls.Add(this.button_ServerServiceControl_GetInformation);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_ProcessID);
            this.groupBox_ServerServiceControl.Controls.Add(this.button_ServerServiceControl_UninstallServer);
            this.groupBox_ServerServiceControl.Controls.Add(this.button_ServerServiceControl_ServiceStart);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_HostAddress);
            this.groupBox_ServerServiceControl.Controls.Add(this.button_ServerServiceControl_ServiceStop);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_HostAddress);
            this.groupBox_ServerServiceControl.Controls.Add(this.button_ServerServiceControl_InstallServer);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_HostType);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_HostType);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_Domain);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_Domain);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_DesktopInteract);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_Address);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_DesktopInteract);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_Address);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_ServiceType);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_Password);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_ServiceType);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_Password);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_ServiceName);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_ServiceName);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_Login);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_ServiceStatus);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_Login);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_ServiceStatus);
            this.groupBox_ServerServiceControl.Controls.Add(this.comboBox_ServerServiceControl_StartMode);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_ServiceState);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_StartMode);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_ServiceState);
            this.groupBox_ServerServiceControl.Controls.Add(this.label_ServerServiceControl_InstallDate);
            this.groupBox_ServerServiceControl.Controls.Add(this.textBox_ServerServiceControl_InstallDate);
            this.groupBox_ServerServiceControl.Location = new System.Drawing.Point(312, 34);
            this.groupBox_ServerServiceControl.Name = "groupBox_ServerServiceControl";
            this.groupBox_ServerServiceControl.Size = new System.Drawing.Size(298, 458);
            this.groupBox_ServerServiceControl.TabIndex = 26;
            this.groupBox_ServerServiceControl.TabStop = false;
            this.groupBox_ServerServiceControl.Text = "JurikSoft Server Service Control and Information";
            // 
            // label_ServerServiceControl_ProcessID
            // 
            this.label_ServerServiceControl_ProcessID.AutoSize = true;
            this.label_ServerServiceControl_ProcessID.Location = new System.Drawing.Point(13, 229);
            this.label_ServerServiceControl_ProcessID.Name = "label_ServerServiceControl_ProcessID";
            this.label_ServerServiceControl_ProcessID.Size = new System.Drawing.Size(62, 13);
            this.label_ServerServiceControl_ProcessID.TabIndex = 43;
            this.label_ServerServiceControl_ProcessID.Text = "Process ID:";
            // 
            // textBox_ServerServiceControl_ProcessID
            // 
            this.textBox_ServerServiceControl_ProcessID.Location = new System.Drawing.Point(15, 245);
            this.textBox_ServerServiceControl_ProcessID.Name = "textBox_ServerServiceControl_ProcessID";
            this.textBox_ServerServiceControl_ProcessID.ReadOnly = true;
            this.textBox_ServerServiceControl_ProcessID.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_ProcessID.TabIndex = 42;
            // 
            // label_ServerServiceControl_HostAddress
            // 
            this.label_ServerServiceControl_HostAddress.AutoSize = true;
            this.label_ServerServiceControl_HostAddress.Location = new System.Drawing.Point(13, 17);
            this.label_ServerServiceControl_HostAddress.Name = "label_ServerServiceControl_HostAddress";
            this.label_ServerServiceControl_HostAddress.Size = new System.Drawing.Size(73, 13);
            this.label_ServerServiceControl_HostAddress.TabIndex = 39;
            this.label_ServerServiceControl_HostAddress.Text = "Host Address:";
            // 
            // textBox_ServerServiceControl_HostAddress
            // 
            this.textBox_ServerServiceControl_HostAddress.Location = new System.Drawing.Point(15, 33);
            this.textBox_ServerServiceControl_HostAddress.Name = "textBox_ServerServiceControl_HostAddress";
            this.textBox_ServerServiceControl_HostAddress.ReadOnly = true;
            this.textBox_ServerServiceControl_HostAddress.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_HostAddress.TabIndex = 38;
            // 
            // label_ServerServiceControl_HostType
            // 
            this.label_ServerServiceControl_HostType.AutoSize = true;
            this.label_ServerServiceControl_HostType.Location = new System.Drawing.Point(150, 16);
            this.label_ServerServiceControl_HostType.Name = "label_ServerServiceControl_HostType";
            this.label_ServerServiceControl_HostType.Size = new System.Drawing.Size(59, 13);
            this.label_ServerServiceControl_HostType.TabIndex = 37;
            this.label_ServerServiceControl_HostType.Text = "Host Type:";
            // 
            // textBox_ServerServiceControl_HostType
            // 
            this.textBox_ServerServiceControl_HostType.Location = new System.Drawing.Point(153, 33);
            this.textBox_ServerServiceControl_HostType.Name = "textBox_ServerServiceControl_HostType";
            this.textBox_ServerServiceControl_HostType.ReadOnly = true;
            this.textBox_ServerServiceControl_HostType.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_HostType.TabIndex = 34;
            // 
            // label_ServerServiceControl_DesktopInteract
            // 
            this.label_ServerServiceControl_DesktopInteract.AutoSize = true;
            this.label_ServerServiceControl_DesktopInteract.Location = new System.Drawing.Point(150, 70);
            this.label_ServerServiceControl_DesktopInteract.Name = "label_ServerServiceControl_DesktopInteract";
            this.label_ServerServiceControl_DesktopInteract.Size = new System.Drawing.Size(89, 13);
            this.label_ServerServiceControl_DesktopInteract.TabIndex = 32;
            this.label_ServerServiceControl_DesktopInteract.Text = "Desktop Interact:";
            // 
            // textBox_ServerServiceControl_DesktopInteract
            // 
            this.textBox_ServerServiceControl_DesktopInteract.Location = new System.Drawing.Point(153, 86);
            this.textBox_ServerServiceControl_DesktopInteract.Name = "textBox_ServerServiceControl_DesktopInteract";
            this.textBox_ServerServiceControl_DesktopInteract.ReadOnly = true;
            this.textBox_ServerServiceControl_DesktopInteract.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_DesktopInteract.TabIndex = 31;
            // 
            // label_ServerServiceControl_ServiceType
            // 
            this.label_ServerServiceControl_ServiceType.AutoSize = true;
            this.label_ServerServiceControl_ServiceType.Location = new System.Drawing.Point(13, 70);
            this.label_ServerServiceControl_ServiceType.Name = "label_ServerServiceControl_ServiceType";
            this.label_ServerServiceControl_ServiceType.Size = new System.Drawing.Size(73, 13);
            this.label_ServerServiceControl_ServiceType.TabIndex = 29;
            this.label_ServerServiceControl_ServiceType.Text = "Service Type:";
            // 
            // textBox_ServerServiceControl_ServiceType
            // 
            this.textBox_ServerServiceControl_ServiceType.Location = new System.Drawing.Point(15, 86);
            this.textBox_ServerServiceControl_ServiceType.Name = "textBox_ServerServiceControl_ServiceType";
            this.textBox_ServerServiceControl_ServiceType.ReadOnly = true;
            this.textBox_ServerServiceControl_ServiceType.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_ServiceType.TabIndex = 26;
            // 
            // label_ServerServiceControl_ServiceName
            // 
            this.label_ServerServiceControl_ServiceName.AutoSize = true;
            this.label_ServerServiceControl_ServiceName.Location = new System.Drawing.Point(149, 123);
            this.label_ServerServiceControl_ServiceName.Name = "label_ServerServiceControl_ServiceName";
            this.label_ServerServiceControl_ServiceName.Size = new System.Drawing.Size(77, 13);
            this.label_ServerServiceControl_ServiceName.TabIndex = 28;
            this.label_ServerServiceControl_ServiceName.Text = "Service Name:";
            // 
            // textBox_ServerServiceControl_ServiceName
            // 
            this.textBox_ServerServiceControl_ServiceName.Location = new System.Drawing.Point(153, 139);
            this.textBox_ServerServiceControl_ServiceName.Name = "textBox_ServerServiceControl_ServiceName";
            this.textBox_ServerServiceControl_ServiceName.ReadOnly = true;
            this.textBox_ServerServiceControl_ServiceName.Size = new System.Drawing.Size(131, 20);
            this.textBox_ServerServiceControl_ServiceName.TabIndex = 27;
            // 
            // menuStrip_MainMenu
            // 
            this.menuStrip_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_MainMenu.Name = "menuStrip_MainMenu";
            this.menuStrip_MainMenu.Size = new System.Drawing.Size(620, 24);
            this.menuStrip_MainMenu.TabIndex = 27;
            this.menuStrip_MainMenu.Text = "menuStrip_MainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.russianToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // russianToolStripMenuItem
            // 
            this.russianToolStripMenuItem.Checked = true;
            this.russianToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            this.russianToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.russianToolStripMenuItem.Text = "Russian";
            this.russianToolStripMenuItem.Click += new System.EventHandler(this.russianToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 506);
            this.Controls.Add(this.groupBox_ServerServiceControl);
            this.Controls.Add(this.groupBox_NetworkComputers);
            this.Controls.Add(this.menuStrip_MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip_MainMenu;
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JurikSoft Server Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.groupBox_NetworkComputers.ResumeLayout(false);
            this.groupBox_ServerServiceControl.ResumeLayout(false);
            this.groupBox_ServerServiceControl.PerformLayout();
            this.menuStrip_MainMenu.ResumeLayout(false);
            this.menuStrip_MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ServerServiceControl_InstallServer;
        private System.Windows.Forms.TreeView treeView_Computers;
        private System.Windows.Forms.Label label_ServerServiceControl_Login;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_Login;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_Password;
        private System.Windows.Forms.Label label_ServerServiceControl_Password;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_Address;
        private System.Windows.Forms.Label label_ServerServiceControl_Address;
        private System.Windows.Forms.Button button_ServerServiceControl_UninstallServer;
        private System.Windows.Forms.GroupBox groupBox_NetworkComputers;
        private System.Windows.Forms.Button button_ServerServiceControl_ServiceStop;
        private System.Windows.Forms.Button button_ServerServiceControl_ServiceStart;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_Domain;
        private System.Windows.Forms.Label label_ServerServiceControl_Domain;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_ServiceStatus;
        private System.Windows.Forms.Button button_ServerServiceControl_GetInformation;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_InstallDate;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_ServiceState;
        private System.Windows.Forms.ComboBox comboBox_ServerServiceControl_StartMode;
        private System.Windows.Forms.Label label_ServerServiceControl_StartMode;
        private System.Windows.Forms.Label label_ServerServiceControl_ServiceStatus;
        private System.Windows.Forms.Label label_ServerServiceControl_InstallDate;
        private System.Windows.Forms.Label label_ServerServiceControl_ServiceState;
        private System.Windows.Forms.GroupBox groupBox_ServerServiceControl;
        private System.Windows.Forms.Label label_ServerServiceControl_DesktopInteract;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_DesktopInteract;
        private System.Windows.Forms.Label label_ServerServiceControl_ServiceType;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_ServiceType;
        private System.Windows.Forms.Label label_ServerServiceControl_ServiceName;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_ServiceName;
        private System.Windows.Forms.Label label_ServerServiceControl_HostType;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_HostType;
        private System.Windows.Forms.Label label_ServerServiceControl_HostAddress;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_HostAddress;
        private System.Windows.Forms.Label label_ServerServiceControl_ProcessID;
        private System.Windows.Forms.TextBox textBox_ServerServiceControl_ProcessID;
        private System.Windows.Forms.MenuStrip menuStrip_MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem russianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
    }


