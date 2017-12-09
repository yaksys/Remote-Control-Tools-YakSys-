using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;

public class FilesUploadForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.Label label_TotalBytesSent;
    private System.Windows.Forms.Label label_BytesSent;
    private System.Windows.Forms.TextBox textBox_TotalSentFrom;
    private System.Windows.Forms.Label label_TotalSentFrom;
    private System.Windows.Forms.TextBox textBox_TotalBytesSent;
    private System.Windows.Forms.TextBox textBox_SentFrom;
    private System.Windows.Forms.Label label_SentFrom;
    private System.Windows.Forms.TextBox textBox_BytesSent;
    private System.Windows.Forms.Label label_FilesUploadForm_NumberFrom;
    private System.Windows.Forms.Label label_FilesUploadForm_UploadedFiles;
    private System.Windows.Forms.TextBox textBox_FilesUploadForm_TotalFilesNum;
    private System.Windows.Forms.TextBox textBox_FilesUploadForm_CurrentFileNum;
    private System.Windows.Forms.Label label_FilesUploadForm_TotalUploadingProgress;
    private System.Windows.Forms.Label label_FilesUploadForm_CurrentUploadedFileProgress;
    private System.Windows.Forms.TextBox textBox_FilesUploadForm_RemoteFolder;
    private System.Windows.Forms.Label label_FilesUploadForm_RemoteFolder;
    private System.Windows.Forms.Label label_FilesUploadForm_CurrentFileName;
    private System.Windows.Forms.TextBox textBox_FilesUploadForm_CurrentFileName;
    private System.Windows.Forms.ProgressBar progressBar_FilesUploadForm_TotalUploaded;
    private System.Windows.Forms.Button button_FilesUploadForm_StopUpload;
    private System.Windows.Forms.ProgressBar progressBar_FileUploadForm_CurrentFileUploaded;
    private System.Windows.Forms.ComboBox comboBox_FilesUploadForm_SegmentSize;
    private System.Windows.Forms.Label label_FilesUploadForm_SegmentSize;
    private System.Windows.Forms.Button button_FilesUploadForm_PauseUpload;
    private System.Windows.Forms.TabPage tabPage_Errors;
    private System.Windows.Forms.PictureBox pictureBox_FilesUploadForm_HorLine2;
    private System.Windows.Forms.Button button_FilesUploadForm_Details;
    private System.Windows.Forms.ListView listView_FilesUploadForm_Errors;
    private System.Windows.Forms.PictureBox pictureBox_FilesUploadForm_HorLine1;
    private System.Windows.Forms.TabPage tabPage_Tasks;
    private System.Windows.Forms.ListView listView_FilesUploadForm_Tasks;
    private System.Windows.Forms.ColumnHeader columnHeader_ErrorsTabPage_ErrorDescription;
    private System.Windows.Forms.ColumnHeader columnHeader_ErrorsTabPage_Time;
    private System.Windows.Forms.ColumnHeader columnHeader_TasksTabPage_Time;
    private System.Windows.Forms.ColumnHeader columnHeader_TasksTabPage_TasksDescription;
    private System.Windows.Forms.TabControl tabControl_FilesUploadForm_Tasks;
    private System.Windows.Forms.ImageList imageList_Tasks;
    private System.ComponentModel.IContainer components;

    public FilesUploadForm()
    {

        InitializeComponent();
        comboBox_FilesUploadForm_SegmentSize.SelectedIndex = 5;
        Show();
    }



    public void ChangeControlsLanguage()
    {
        this.button_FilesUploadForm_Details.Text = ClientStringFactory.GetString(340, ClientSettingsEnvironment.CurrentLanguage);
        this.label_TotalSentFrom.Text = ClientStringFactory.GetString(40, ClientSettingsEnvironment.CurrentLanguage);
        this.label_TotalBytesSent.Text = ClientStringFactory.GetString(43, ClientSettingsEnvironment.CurrentLanguage);
        this.label_SentFrom.Text = ClientStringFactory.GetString(40, ClientSettingsEnvironment.CurrentLanguage);
        this.label_BytesSent.Text = ClientStringFactory.GetString(43, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesUploadForm_NumberFrom.Text = ClientStringFactory.GetString(40, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesUploadForm_UploadedFiles.Text = ClientStringFactory.GetString(44, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesUploadForm_TotalUploadingProgress.Text = ClientStringFactory.GetString(244, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesUploadForm_CurrentUploadedFileProgress.Text = ClientStringFactory.GetString(45, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesUploadForm_RemoteFolder.Text = ClientStringFactory.GetString(46, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesUploadForm_CurrentFileName.Text = ClientStringFactory.GetString(47, ClientSettingsEnvironment.CurrentLanguage);
        this.button_FilesUploadForm_StopUpload.Text = ClientStringFactory.GetString(35, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesUploadForm_SegmentSize.Text = ClientStringFactory.GetString(256, ClientSettingsEnvironment.CurrentLanguage);
        this.Text = ClientStringFactory.GetString(245, ClientSettingsEnvironment.CurrentLanguage);

        this.tabPage_Errors.Text = ClientStringFactory.GetString(343, ClientSettingsEnvironment.CurrentLanguage);
        this.tabPage_Tasks.Text = ClientStringFactory.GetString(346, ClientSettingsEnvironment.CurrentLanguage);

        this.columnHeader_ErrorsTabPage_ErrorDescription.Text = ClientStringFactory.GetString(315, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ErrorsTabPage_Time.Text = ClientStringFactory.GetString(20, ClientSettingsEnvironment.CurrentLanguage);

        this.columnHeader_TasksTabPage_TasksDescription.Text = ClientStringFactory.GetString(315, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_TasksTabPage_Time.Text = ClientStringFactory.GetString(20, ClientSettingsEnvironment.CurrentLanguage);

        if (!UploadPaused)
        {
            this.button_FilesUploadForm_PauseUpload.Text = ClientStringFactory.GetString(259, ClientSettingsEnvironment.CurrentLanguage);
        }

        else
            this.button_FilesUploadForm_PauseUpload.Text = ClientStringFactory.GetString(260, ClientSettingsEnvironment.CurrentLanguage);

        tabControl_FilesUploadForm_Tasks.SelectedIndex = tabControl_FilesUploadForm_Tasks.Controls.IndexOf(tabPage_Errors);

    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
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
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesUploadForm));
        this.textBox_TotalSentFrom = new System.Windows.Forms.TextBox();
        this.label_TotalSentFrom = new System.Windows.Forms.Label();
        this.textBox_TotalBytesSent = new System.Windows.Forms.TextBox();
        this.label_TotalBytesSent = new System.Windows.Forms.Label();
        this.textBox_SentFrom = new System.Windows.Forms.TextBox();
        this.label_SentFrom = new System.Windows.Forms.Label();
        this.textBox_BytesSent = new System.Windows.Forms.TextBox();
        this.label_BytesSent = new System.Windows.Forms.Label();
        this.label_FilesUploadForm_NumberFrom = new System.Windows.Forms.Label();
        this.label_FilesUploadForm_UploadedFiles = new System.Windows.Forms.Label();
        this.textBox_FilesUploadForm_TotalFilesNum = new System.Windows.Forms.TextBox();
        this.textBox_FilesUploadForm_CurrentFileNum = new System.Windows.Forms.TextBox();
        this.label_FilesUploadForm_TotalUploadingProgress = new System.Windows.Forms.Label();
        this.label_FilesUploadForm_CurrentUploadedFileProgress = new System.Windows.Forms.Label();
        this.textBox_FilesUploadForm_RemoteFolder = new System.Windows.Forms.TextBox();
        this.label_FilesUploadForm_RemoteFolder = new System.Windows.Forms.Label();
        this.label_FilesUploadForm_CurrentFileName = new System.Windows.Forms.Label();
        this.textBox_FilesUploadForm_CurrentFileName = new System.Windows.Forms.TextBox();
        this.progressBar_FilesUploadForm_TotalUploaded = new System.Windows.Forms.ProgressBar();
        this.button_FilesUploadForm_StopUpload = new System.Windows.Forms.Button();
        this.progressBar_FileUploadForm_CurrentFileUploaded = new System.Windows.Forms.ProgressBar();
        this.comboBox_FilesUploadForm_SegmentSize = new System.Windows.Forms.ComboBox();
        this.label_FilesUploadForm_SegmentSize = new System.Windows.Forms.Label();
        this.button_FilesUploadForm_PauseUpload = new System.Windows.Forms.Button();
        this.pictureBox_FilesUploadForm_HorLine2 = new System.Windows.Forms.PictureBox();
        this.button_FilesUploadForm_Details = new System.Windows.Forms.Button();
        this.tabControl_FilesUploadForm_Tasks = new System.Windows.Forms.TabControl();
        this.tabPage_Tasks = new System.Windows.Forms.TabPage();
        this.listView_FilesUploadForm_Tasks = new System.Windows.Forms.ListView();
        this.columnHeader_TasksTabPage_TasksDescription = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_TasksTabPage_Time = new System.Windows.Forms.ColumnHeader();
        this.imageList_Tasks = new System.Windows.Forms.ImageList(this.components);
        this.tabPage_Errors = new System.Windows.Forms.TabPage();
        this.listView_FilesUploadForm_Errors = new System.Windows.Forms.ListView();
        this.columnHeader_ErrorsTabPage_ErrorDescription = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ErrorsTabPage_Time = new System.Windows.Forms.ColumnHeader();
        this.pictureBox_FilesUploadForm_HorLine1 = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FilesUploadForm_HorLine2)).BeginInit();
        this.tabControl_FilesUploadForm_Tasks.SuspendLayout();
        this.tabPage_Tasks.SuspendLayout();
        this.tabPage_Errors.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FilesUploadForm_HorLine1)).BeginInit();
        this.SuspendLayout();
        // 
        // textBox_TotalSentFrom
        // 
        this.textBox_TotalSentFrom.Location = new System.Drawing.Point(384, 72);
        this.textBox_TotalSentFrom.Name = "textBox_TotalSentFrom";
        this.textBox_TotalSentFrom.ReadOnly = true;
        this.textBox_TotalSentFrom.Size = new System.Drawing.Size(104, 20);
        this.textBox_TotalSentFrom.TabIndex = 41;
        // 
        // label_TotalSentFrom
        // 
        this.label_TotalSentFrom.Location = new System.Drawing.Point(350, 80);
        this.label_TotalSentFrom.Name = "label_TotalSentFrom";
        this.label_TotalSentFrom.Size = new System.Drawing.Size(32, 16);
        this.label_TotalSentFrom.TabIndex = 40;
        // 
        // textBox_TotalBytesSent
        // 
        this.textBox_TotalBytesSent.Location = new System.Drawing.Point(240, 72);
        this.textBox_TotalBytesSent.Name = "textBox_TotalBytesSent";
        this.textBox_TotalBytesSent.ReadOnly = true;
        this.textBox_TotalBytesSent.Size = new System.Drawing.Size(104, 20);
        this.textBox_TotalBytesSent.TabIndex = 39;
        // 
        // label_TotalBytesSent
        // 
        this.label_TotalBytesSent.Location = new System.Drawing.Point(128, 80);
        this.label_TotalBytesSent.Name = "label_TotalBytesSent";
        this.label_TotalBytesSent.Size = new System.Drawing.Size(104, 16);
        this.label_TotalBytesSent.TabIndex = 38;
        // 
        // textBox_SentFrom
        // 
        this.textBox_SentFrom.Location = new System.Drawing.Point(384, 16);
        this.textBox_SentFrom.Name = "textBox_SentFrom";
        this.textBox_SentFrom.ReadOnly = true;
        this.textBox_SentFrom.Size = new System.Drawing.Size(104, 20);
        this.textBox_SentFrom.TabIndex = 37;
        // 
        // label_SentFrom
        // 
        this.label_SentFrom.Location = new System.Drawing.Point(352, 24);
        this.label_SentFrom.Name = "label_SentFrom";
        this.label_SentFrom.Size = new System.Drawing.Size(34, 16);
        this.label_SentFrom.TabIndex = 36;
        // 
        // textBox_BytesSent
        // 
        this.textBox_BytesSent.Location = new System.Drawing.Point(240, 16);
        this.textBox_BytesSent.Name = "textBox_BytesSent";
        this.textBox_BytesSent.ReadOnly = true;
        this.textBox_BytesSent.Size = new System.Drawing.Size(104, 20);
        this.textBox_BytesSent.TabIndex = 35;
        // 
        // label_BytesSent
        // 
        this.label_BytesSent.Location = new System.Drawing.Point(128, 24);
        this.label_BytesSent.Name = "label_BytesSent";
        this.label_BytesSent.Size = new System.Drawing.Size(104, 16);
        this.label_BytesSent.TabIndex = 34;
        // 
        // label_FilesUploadForm_NumberFrom
        // 
        this.label_FilesUploadForm_NumberFrom.Location = new System.Drawing.Point(248, 232);
        this.label_FilesUploadForm_NumberFrom.Name = "label_FilesUploadForm_NumberFrom";
        this.label_FilesUploadForm_NumberFrom.Size = new System.Drawing.Size(32, 16);
        this.label_FilesUploadForm_NumberFrom.TabIndex = 33;
        // 
        // label_FilesUploadForm_UploadedFiles
        // 
        this.label_FilesUploadForm_UploadedFiles.Location = new System.Drawing.Point(14, 232);
        this.label_FilesUploadForm_UploadedFiles.Name = "label_FilesUploadForm_UploadedFiles";
        this.label_FilesUploadForm_UploadedFiles.Size = new System.Drawing.Size(146, 16);
        this.label_FilesUploadForm_UploadedFiles.TabIndex = 32;
        // 
        // textBox_FilesUploadForm_TotalFilesNum
        // 
        this.textBox_FilesUploadForm_TotalFilesNum.Location = new System.Drawing.Point(312, 224);
        this.textBox_FilesUploadForm_TotalFilesNum.Name = "textBox_FilesUploadForm_TotalFilesNum";
        this.textBox_FilesUploadForm_TotalFilesNum.ReadOnly = true;
        this.textBox_FilesUploadForm_TotalFilesNum.Size = new System.Drawing.Size(48, 20);
        this.textBox_FilesUploadForm_TotalFilesNum.TabIndex = 31;
        // 
        // textBox_FilesUploadForm_CurrentFileNum
        // 
        this.textBox_FilesUploadForm_CurrentFileNum.Location = new System.Drawing.Point(168, 224);
        this.textBox_FilesUploadForm_CurrentFileNum.Name = "textBox_FilesUploadForm_CurrentFileNum";
        this.textBox_FilesUploadForm_CurrentFileNum.ReadOnly = true;
        this.textBox_FilesUploadForm_CurrentFileNum.Size = new System.Drawing.Size(48, 20);
        this.textBox_FilesUploadForm_CurrentFileNum.TabIndex = 30;
        // 
        // label_FilesUploadForm_TotalUploadingProgress
        // 
        this.label_FilesUploadForm_TotalUploadingProgress.Location = new System.Drawing.Point(16, 80);
        this.label_FilesUploadForm_TotalUploadingProgress.Name = "label_FilesUploadForm_TotalUploadingProgress";
        this.label_FilesUploadForm_TotalUploadingProgress.Size = new System.Drawing.Size(114, 16);
        this.label_FilesUploadForm_TotalUploadingProgress.TabIndex = 29;
        // 
        // label_FilesUploadForm_CurrentUploadedFileProgress
        // 
        this.label_FilesUploadForm_CurrentUploadedFileProgress.Location = new System.Drawing.Point(16, 24);
        this.label_FilesUploadForm_CurrentUploadedFileProgress.Name = "label_FilesUploadForm_CurrentUploadedFileProgress";
        this.label_FilesUploadForm_CurrentUploadedFileProgress.Size = new System.Drawing.Size(106, 16);
        this.label_FilesUploadForm_CurrentUploadedFileProgress.TabIndex = 28;
        // 
        // textBox_FilesUploadForm_RemoteFolder
        // 
        this.textBox_FilesUploadForm_RemoteFolder.Location = new System.Drawing.Point(168, 192);
        this.textBox_FilesUploadForm_RemoteFolder.Name = "textBox_FilesUploadForm_RemoteFolder";
        this.textBox_FilesUploadForm_RemoteFolder.ReadOnly = true;
        this.textBox_FilesUploadForm_RemoteFolder.Size = new System.Drawing.Size(192, 20);
        this.textBox_FilesUploadForm_RemoteFolder.TabIndex = 27;
        // 
        // label_FilesUploadForm_RemoteFolder
        // 
        this.label_FilesUploadForm_RemoteFolder.Location = new System.Drawing.Point(14, 200);
        this.label_FilesUploadForm_RemoteFolder.Name = "label_FilesUploadForm_RemoteFolder";
        this.label_FilesUploadForm_RemoteFolder.Size = new System.Drawing.Size(146, 16);
        this.label_FilesUploadForm_RemoteFolder.TabIndex = 26;
        // 
        // label_FilesUploadForm_CurrentFileName
        // 
        this.label_FilesUploadForm_CurrentFileName.Location = new System.Drawing.Point(14, 160);
        this.label_FilesUploadForm_CurrentFileName.Name = "label_FilesUploadForm_CurrentFileName";
        this.label_FilesUploadForm_CurrentFileName.Size = new System.Drawing.Size(146, 24);
        this.label_FilesUploadForm_CurrentFileName.TabIndex = 25;
        // 
        // textBox_FilesUploadForm_CurrentFileName
        // 
        this.textBox_FilesUploadForm_CurrentFileName.Location = new System.Drawing.Point(168, 160);
        this.textBox_FilesUploadForm_CurrentFileName.Name = "textBox_FilesUploadForm_CurrentFileName";
        this.textBox_FilesUploadForm_CurrentFileName.ReadOnly = true;
        this.textBox_FilesUploadForm_CurrentFileName.Size = new System.Drawing.Size(192, 20);
        this.textBox_FilesUploadForm_CurrentFileName.TabIndex = 24;
        // 
        // progressBar_FilesUploadForm_TotalUploaded
        // 
        this.progressBar_FilesUploadForm_TotalUploaded.Location = new System.Drawing.Point(16, 104);
        this.progressBar_FilesUploadForm_TotalUploaded.Name = "progressBar_FilesUploadForm_TotalUploaded";
        this.progressBar_FilesUploadForm_TotalUploaded.Size = new System.Drawing.Size(472, 16);
        this.progressBar_FilesUploadForm_TotalUploaded.TabIndex = 23;
        // 
        // button_FilesUploadForm_StopUpload
        // 
        this.button_FilesUploadForm_StopUpload.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_FilesUploadForm_StopUpload.Location = new System.Drawing.Point(376, 192);
        this.button_FilesUploadForm_StopUpload.Name = "button_FilesUploadForm_StopUpload";
        this.button_FilesUploadForm_StopUpload.Size = new System.Drawing.Size(56, 23);
        this.button_FilesUploadForm_StopUpload.TabIndex = 22;
        this.button_FilesUploadForm_StopUpload.Click += new System.EventHandler(this.button_FilesUploadForm_StopUpload_Click);
        // 
        // progressBar_FileUploadForm_CurrentFileUploaded
        // 
        this.progressBar_FileUploadForm_CurrentFileUploaded.Location = new System.Drawing.Point(16, 48);
        this.progressBar_FileUploadForm_CurrentFileUploaded.Name = "progressBar_FileUploadForm_CurrentFileUploaded";
        this.progressBar_FileUploadForm_CurrentFileUploaded.Size = new System.Drawing.Size(472, 16);
        this.progressBar_FileUploadForm_CurrentFileUploaded.TabIndex = 21;
        // 
        // comboBox_FilesUploadForm_SegmentSize
        // 
        this.comboBox_FilesUploadForm_SegmentSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox_FilesUploadForm_SegmentSize.Items.AddRange(new object[] {
            "1024",
            "2048",
            "4096",
            "8192",
            "16384",
            "32768",
            "65536",
            "131072"});
        this.comboBox_FilesUploadForm_SegmentSize.Location = new System.Drawing.Point(376, 160);
        this.comboBox_FilesUploadForm_SegmentSize.Name = "comboBox_FilesUploadForm_SegmentSize";
        this.comboBox_FilesUploadForm_SegmentSize.Size = new System.Drawing.Size(112, 21);
        this.comboBox_FilesUploadForm_SegmentSize.TabIndex = 42;
        // 
        // label_FilesUploadForm_SegmentSize
        // 
        this.label_FilesUploadForm_SegmentSize.Location = new System.Drawing.Point(376, 144);
        this.label_FilesUploadForm_SegmentSize.Name = "label_FilesUploadForm_SegmentSize";
        this.label_FilesUploadForm_SegmentSize.Size = new System.Drawing.Size(112, 16);
        this.label_FilesUploadForm_SegmentSize.TabIndex = 43;
        // 
        // button_FilesUploadForm_PauseUpload
        // 
        this.button_FilesUploadForm_PauseUpload.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_FilesUploadForm_PauseUpload.Location = new System.Drawing.Point(432, 192);
        this.button_FilesUploadForm_PauseUpload.Name = "button_FilesUploadForm_PauseUpload";
        this.button_FilesUploadForm_PauseUpload.Size = new System.Drawing.Size(56, 23);
        this.button_FilesUploadForm_PauseUpload.TabIndex = 44;
        this.button_FilesUploadForm_PauseUpload.Click += new System.EventHandler(this.button_FilesUploadForm_PauseUpload_Click);
        // 
        // pictureBox_FilesUploadForm_HorLine2
        // 
        this.pictureBox_FilesUploadForm_HorLine2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_FilesUploadForm_HorLine2.Image")));
        this.pictureBox_FilesUploadForm_HorLine2.Location = new System.Drawing.Point(16, 264);
        this.pictureBox_FilesUploadForm_HorLine2.Name = "pictureBox_FilesUploadForm_HorLine2";
        this.pictureBox_FilesUploadForm_HorLine2.Size = new System.Drawing.Size(472, 2);
        this.pictureBox_FilesUploadForm_HorLine2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox_FilesUploadForm_HorLine2.TabIndex = 47;
        this.pictureBox_FilesUploadForm_HorLine2.TabStop = false;
        // 
        // button_FilesUploadForm_Details
        // 
        this.button_FilesUploadForm_Details.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_FilesUploadForm_Details.Location = new System.Drawing.Point(376, 223);
        this.button_FilesUploadForm_Details.Name = "button_FilesUploadForm_Details";
        this.button_FilesUploadForm_Details.Size = new System.Drawing.Size(112, 21);
        this.button_FilesUploadForm_Details.TabIndex = 46;
        this.button_FilesUploadForm_Details.Text = "Details >>";
        this.button_FilesUploadForm_Details.Click += new System.EventHandler(this.button_FilesUploadForm_Details_Click);
        // 
        // tabControl_FilesUploadForm_Tasks
        // 
        this.tabControl_FilesUploadForm_Tasks.Controls.Add(this.tabPage_Tasks);
        this.tabControl_FilesUploadForm_Tasks.Controls.Add(this.tabPage_Errors);
        this.tabControl_FilesUploadForm_Tasks.Location = new System.Drawing.Point(16, 288);
        this.tabControl_FilesUploadForm_Tasks.Multiline = true;
        this.tabControl_FilesUploadForm_Tasks.Name = "tabControl_FilesUploadForm_Tasks";
        this.tabControl_FilesUploadForm_Tasks.SelectedIndex = 0;
        this.tabControl_FilesUploadForm_Tasks.Size = new System.Drawing.Size(472, 216);
        this.tabControl_FilesUploadForm_Tasks.TabIndex = 45;
        // 
        // tabPage_Tasks
        // 
        this.tabPage_Tasks.Controls.Add(this.listView_FilesUploadForm_Tasks);
        this.tabPage_Tasks.Location = new System.Drawing.Point(4, 22);
        this.tabPage_Tasks.Name = "tabPage_Tasks";
        this.tabPage_Tasks.Size = new System.Drawing.Size(464, 190);
        this.tabPage_Tasks.TabIndex = 2;
        this.tabPage_Tasks.Text = "Tasks";
        // 
        // listView_FilesUploadForm_Tasks
        // 
        this.listView_FilesUploadForm_Tasks.AllowColumnReorder = true;
        this.listView_FilesUploadForm_Tasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_TasksTabPage_TasksDescription,
            this.columnHeader_TasksTabPage_Time});
        this.listView_FilesUploadForm_Tasks.FullRowSelect = true;
        this.listView_FilesUploadForm_Tasks.Location = new System.Drawing.Point(8, 8);
        this.listView_FilesUploadForm_Tasks.Name = "listView_FilesUploadForm_Tasks";
        this.listView_FilesUploadForm_Tasks.Size = new System.Drawing.Size(448, 176);
        this.listView_FilesUploadForm_Tasks.SmallImageList = this.imageList_Tasks;
        this.listView_FilesUploadForm_Tasks.TabIndex = 1;
        this.listView_FilesUploadForm_Tasks.UseCompatibleStateImageBehavior = false;
        this.listView_FilesUploadForm_Tasks.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader_TasksTabPage_TasksDescription
        // 
        this.columnHeader_TasksTabPage_TasksDescription.Text = "Task description";
        this.columnHeader_TasksTabPage_TasksDescription.Width = 350;
        // 
        // columnHeader_TasksTabPage_Time
        // 
        this.columnHeader_TasksTabPage_Time.Text = "Time";
        this.columnHeader_TasksTabPage_Time.Width = 73;
        // 
        // imageList_Tasks
        // 
        this.imageList_Tasks.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Tasks.ImageStream")));
        this.imageList_Tasks.TransparentColor = System.Drawing.Color.Transparent;
        this.imageList_Tasks.Images.SetKeyName(0, "");
        this.imageList_Tasks.Images.SetKeyName(1, "");
        // 
        // tabPage_Errors
        // 
        this.tabPage_Errors.Controls.Add(this.listView_FilesUploadForm_Errors);
        this.tabPage_Errors.Location = new System.Drawing.Point(4, 22);
        this.tabPage_Errors.Name = "tabPage_Errors";
        this.tabPage_Errors.Size = new System.Drawing.Size(464, 190);
        this.tabPage_Errors.TabIndex = 1;
        this.tabPage_Errors.Text = "Errors";
        // 
        // listView_FilesUploadForm_Errors
        // 
        this.listView_FilesUploadForm_Errors.AllowColumnReorder = true;
        this.listView_FilesUploadForm_Errors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ErrorsTabPage_ErrorDescription,
            this.columnHeader_ErrorsTabPage_Time});
        this.listView_FilesUploadForm_Errors.FullRowSelect = true;
        this.listView_FilesUploadForm_Errors.Location = new System.Drawing.Point(8, 8);
        this.listView_FilesUploadForm_Errors.Name = "listView_FilesUploadForm_Errors";
        this.listView_FilesUploadForm_Errors.Size = new System.Drawing.Size(448, 176);
        this.listView_FilesUploadForm_Errors.SmallImageList = this.imageList_Tasks;
        this.listView_FilesUploadForm_Errors.TabIndex = 0;
        this.listView_FilesUploadForm_Errors.UseCompatibleStateImageBehavior = false;
        this.listView_FilesUploadForm_Errors.View = System.Windows.Forms.View.Details;
        // 
        // columnHeader_ErrorsTabPage_ErrorDescription
        // 
        this.columnHeader_ErrorsTabPage_ErrorDescription.Text = "Error description";
        this.columnHeader_ErrorsTabPage_ErrorDescription.Width = 350;
        // 
        // columnHeader_ErrorsTabPage_Time
        // 
        this.columnHeader_ErrorsTabPage_Time.Text = "Time";
        this.columnHeader_ErrorsTabPage_Time.Width = 73;
        // 
        // pictureBox_FilesUploadForm_HorLine1
        // 
        this.pictureBox_FilesUploadForm_HorLine1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_FilesUploadForm_HorLine1.Image")));
        this.pictureBox_FilesUploadForm_HorLine1.Location = new System.Drawing.Point(16, 136);
        this.pictureBox_FilesUploadForm_HorLine1.Name = "pictureBox_FilesUploadForm_HorLine1";
        this.pictureBox_FilesUploadForm_HorLine1.Size = new System.Drawing.Size(472, 2);
        this.pictureBox_FilesUploadForm_HorLine1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox_FilesUploadForm_HorLine1.TabIndex = 48;
        this.pictureBox_FilesUploadForm_HorLine1.TabStop = false;
        // 
        // FilesUploadForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(502, 278);
        this.ControlBox = false;
        this.Controls.Add(this.pictureBox_FilesUploadForm_HorLine1);
        this.Controls.Add(this.pictureBox_FilesUploadForm_HorLine2);
        this.Controls.Add(this.button_FilesUploadForm_Details);
        this.Controls.Add(this.tabControl_FilesUploadForm_Tasks);
        this.Controls.Add(this.button_FilesUploadForm_PauseUpload);
        this.Controls.Add(this.label_FilesUploadForm_SegmentSize);
        this.Controls.Add(this.comboBox_FilesUploadForm_SegmentSize);
        this.Controls.Add(this.textBox_FilesUploadForm_CurrentFileName);
        this.Controls.Add(this.textBox_TotalSentFrom);
        this.Controls.Add(this.textBox_TotalBytesSent);
        this.Controls.Add(this.textBox_SentFrom);
        this.Controls.Add(this.textBox_BytesSent);
        this.Controls.Add(this.textBox_FilesUploadForm_TotalFilesNum);
        this.Controls.Add(this.textBox_FilesUploadForm_CurrentFileNum);
        this.Controls.Add(this.textBox_FilesUploadForm_RemoteFolder);
        this.Controls.Add(this.label_TotalSentFrom);
        this.Controls.Add(this.label_TotalBytesSent);
        this.Controls.Add(this.label_SentFrom);
        this.Controls.Add(this.label_BytesSent);
        this.Controls.Add(this.label_FilesUploadForm_NumberFrom);
        this.Controls.Add(this.label_FilesUploadForm_UploadedFiles);
        this.Controls.Add(this.label_FilesUploadForm_TotalUploadingProgress);
        this.Controls.Add(this.label_FilesUploadForm_CurrentUploadedFileProgress);
        this.Controls.Add(this.label_FilesUploadForm_RemoteFolder);
        this.Controls.Add(this.label_FilesUploadForm_CurrentFileName);
        this.Controls.Add(this.progressBar_FilesUploadForm_TotalUploaded);
        this.Controls.Add(this.button_FilesUploadForm_StopUpload);
        this.Controls.Add(this.progressBar_FileUploadForm_CurrentFileUploaded);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(504, 280);
        this.MinimumSize = new System.Drawing.Size(504, 280);
        this.Name = "FilesUploadForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Shown += new System.EventHandler(this.FilesUploadForm_Shown);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FilesUploadForm_HorLine2)).EndInit();
        this.tabControl_FilesUploadForm_Tasks.ResumeLayout(false);
        this.tabPage_Tasks.ResumeLayout(false);
        this.tabPage_Errors.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FilesUploadForm_HorLine1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    #endregion

    #region Invoke Delegates

    delegate string delegate_ReturningStringMethod();
    delegate bool delegate_ReturningBoolMethod();

    delegate int delegate_ReturningIntMethod();
    delegate long delegate_ReturningLongMethod();
    delegate decimal delegate_ReturningDecimalMethod();

    delegate ListView.ListViewItemCollection delegate_ReturningListViewItemCollectionMethod();
    delegate ImageList delegate_ReturningImageListMethod();
    delegate TrackBar delegate_ReturningTrackBarMethod();
    delegate TreeView delegate_ReturningTreeViewMethod();


    #endregion

    public string CurrentUploadingFileName
    {
        set
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_FilesUploadForm_CurrentFileName.Text = value;
            });
        }

        get
        {
            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_FilesUploadForm_CurrentFileName.Text;
            });
        }
    }

    public int CurrentFileNum
    {
        set
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_FilesUploadForm_CurrentFileNum.Text = value.ToString();
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return int.Parse(this.textBox_FilesUploadForm_CurrentFileNum.Text);
            });
        }
    }

    public int TotalFilesNum
    {
        set
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_FilesUploadForm_TotalFilesNum.Text = value.ToString();
            });
        }

        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return int.Parse(this.textBox_FilesUploadForm_TotalFilesNum.Text);
            });
        }
    }

    public string UploadFolder
    {
        set
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.textBox_FilesUploadForm_RemoteFolder.Text = value;
            });
        }

        get
        {
            return (string)this.Invoke((delegate_ReturningStringMethod)delegate
            {
                return this.textBox_FilesUploadForm_RemoteFolder.Text;
            });
        }
    }

    public int UploadedSegmentSize
    {
        get
        {
            if (this.IsHandleCreated == false) return 0;

            return (int)this.Invoke((delegate_ReturningIntMethod)delegate
            {
                return int.Parse(comboBox_FilesUploadForm_SegmentSize.Text);
            });
        }
    }

    public long UploadProgress
    {
        set
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (this.progressBar_FileUploadForm_CurrentFileUploaded.Maximum != 0)
                {
                    this.progressBar_FileUploadForm_CurrentFileUploaded.Value = (int)value;
                }

                this.textBox_BytesSent.Text = ObjCopy.obj_MainClientForm.SpreadToHundreds(value.ToString());
            });
        }
    }

    public long UploadProgress_MaxValue
    {
        set
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (value <= int.MaxValue) progressBar_FileUploadForm_CurrentFileUploaded.Maximum = (int)value;
                else progressBar_FileUploadForm_CurrentFileUploaded.Maximum = 0;

                textBox_SentFrom.Text = ObjCopy.obj_MainClientForm.SpreadToHundreds(value.ToString());
            });
        }
    }

    public long TotalUploadProgress
    {
        set
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (progressBar_FilesUploadForm_TotalUploaded.Maximum != 0)
                    progressBar_FilesUploadForm_TotalUploaded.Value = (int)value;

                textBox_TotalBytesSent.Text = ObjCopy.obj_MainClientForm.SpreadToHundreds(value.ToString());
            });
        }
    }

    public long TotalUploadProgress_MaxValue
    {
        set
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (value <= int.MaxValue) progressBar_FilesUploadForm_TotalUploaded.Maximum = (int)value;
                else progressBar_FilesUploadForm_TotalUploaded.Maximum = 0;

                textBox_TotalSentFrom.Text = ObjCopy.obj_MainClientForm.SpreadToHundreds(value.ToString());
            });
        }
    }


    static bool bool_UploadPaused = false;

    private void button_FilesUploadForm_PauseUpload_Click(object sender, System.EventArgs e)
    {
        if (UploadPaused == false)
        {
            UploadPaused = true;
            this.button_FilesUploadForm_PauseUpload.Text = ClientStringFactory.GetString(260, ClientSettingsEnvironment.CurrentLanguage);
        }

        else
        {
            UploadPaused = false;
            this.button_FilesUploadForm_PauseUpload.Text = ClientStringFactory.GetString(259, ClientSettingsEnvironment.CurrentLanguage);
        }
    }

    private void button_FilesUploadForm_Details_Click(object sender, System.EventArgs e)
    {
        if (this.MaximumSize.Height == 536)
        {
            this.MaximumSize = new System.Drawing.Size(504, 280);
            this.MinimumSize = new System.Drawing.Size(504, 280);
            this.button_FilesUploadForm_Details.Text = ClientStringFactory.GetString(340, ClientSettingsEnvironment.CurrentLanguage);
        }

        else
        {
            this.MaximumSize = new System.Drawing.Size(504, 536);
            this.MinimumSize = new System.Drawing.Size(504, 536);
            this.button_FilesUploadForm_Details.Text = ClientStringFactory.GetString(341, ClientSettingsEnvironment.CurrentLanguage);
        }
    }

    private void button_FilesUploadForm_StopUpload_Click(object sender, System.EventArgs e)
    {
        UploadPaused = true;

        if (DialogResult.No == MessageBox.Show(ClientStringFactory.GetString(263, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            UploadPaused = false;
            return;
        }


        if (MainTcpClient.IsConnected)
        {
            try
            {
                new Thread(new ThreadStart(new RemoteCallAction().DeleteAllUploadingTasks)).Start();
            }

            catch
            {
            }
        }

        if (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Count > 0 && DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0].UINT != 0)
            (DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles[0]).fileStream_UploadingFile.Close();

        DatabaseOfUploadingFiles.list_DatabaseOfUploadingFiles.Clear();

        ObjCopy.obj_MainClientForm.ChangeUploadProgress();

        UploadPaused = false;

        return;
    }



    public void AddError(string string_ErrorDescription)
    {
        this.Invoke((MethodInvoker)delegate
        {
            ListViewItem listViewItem_NewError = new ListViewItem(string_ErrorDescription, listView_FilesUploadForm_Errors.Items.Count);

            listViewItem_NewError.SubItems.Add(System.DateTime.Now.ToLongTimeString());

            listViewItem_NewError.ImageIndex = 0;

            listView_FilesUploadForm_Errors.Items.Add(listViewItem_NewError);

            this.MaximumSize = new System.Drawing.Size(504, 536);
            this.MinimumSize = new System.Drawing.Size(504, 536);
            this.button_FilesUploadForm_Details.Text = ClientStringFactory.GetString(341, ClientSettingsEnvironment.CurrentLanguage);

            this.tabControl_FilesUploadForm_Tasks.SelectedIndex = tabControl_FilesUploadForm_Tasks.Controls.IndexOf(tabPage_Errors);
        });
    }

    public void AddTask(string string_TaskDescription)
    {
        this.Invoke((MethodInvoker)delegate
        {
            ListViewItem listViewItem_NewTask = new ListViewItem(string_TaskDescription, listView_FilesUploadForm_Tasks.Items.Count);

            listViewItem_NewTask.SubItems.Add(System.DateTime.Now.ToLongTimeString());

            listViewItem_NewTask.ImageIndex = 1;

            listView_FilesUploadForm_Tasks.Items.Add(listViewItem_NewTask);

            this.MaximumSize = new System.Drawing.Size(504, 536);
            this.MinimumSize = new System.Drawing.Size(504, 536);

            this.button_FilesUploadForm_Details.Text = ClientStringFactory.GetString(341, ClientSettingsEnvironment.CurrentLanguage);

            tabControl_FilesUploadForm_Tasks.SelectedIndex = tabControl_FilesUploadForm_Tasks.Controls.IndexOf(tabPage_Tasks);
        });
    }

    public bool EnableStopButton
    {
        set
        {
            button_FilesUploadForm_StopUpload.Enabled = value;
        }
    }

    public bool UploadPaused
    {
        get
        {
            return bool_UploadPaused;
        }

        set
        {
            bool_UploadPaused = value;
        }

    }

    private void FilesUploadForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }
}

