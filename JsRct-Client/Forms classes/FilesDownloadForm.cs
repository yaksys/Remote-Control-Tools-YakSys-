using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

/// <summary>
/// Summary description for FilesDownloadForm.
/// </summary>
public class FilesDownloadForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.PictureBox pictureBox_FilesDownloadForm_HorLine1;
    private System.Windows.Forms.PictureBox pictureBox_FilesDownloadForm_HorLine2;
    private System.Windows.Forms.Button button_FilesDownloadForm_Details;
    private System.Windows.Forms.TabControl tabControl_FilesDownloadForm_Tasks;
    private System.Windows.Forms.TabPage tabPage_Tasks;
    private System.Windows.Forms.ListView listView_FilesDownloadForm_Tasks;
    private System.Windows.Forms.TabPage tabPage_Errors;
    private System.Windows.Forms.ListView listView_FilesDownloadForm_Errors;
    private System.Windows.Forms.ColumnHeader columnHeader_TasksTabPage_TasksDescription;
    private System.Windows.Forms.ColumnHeader columnHeader_TasksTabPage_Time;
    private System.Windows.Forms.ColumnHeader columnHeader_ErrorsTabPage_ErrorDescription;
    private System.Windows.Forms.ColumnHeader columnHeader_ErrorsTabPage_Time;
    private System.Windows.Forms.Button button_FilesDownloadForm_PauseDownload;
    private System.Windows.Forms.ComboBox comboBox_FilesDownloadForm_SegmentSize;
    private System.Windows.Forms.Label label_FilesDownloadForm_SegmentSize;
    private System.Windows.Forms.TextBox textBox_TotalReceiveFrom;
    private System.Windows.Forms.TextBox textBox_TotalReceivedBytes;
    private System.Windows.Forms.TextBox textBox_ReceivedFrom;
    private System.Windows.Forms.TextBox textBox_ReceivedBytes;
    private System.Windows.Forms.TextBox textBox_FilesDownloadForm_TotalFilesNum;
    private System.Windows.Forms.TextBox textBox_FilesDownloadForm_CurrentFileNum;
    private System.Windows.Forms.TextBox textBox_FilesDownloadForm_DownloadFolder;
    private System.Windows.Forms.TextBox textBox_FilesDownloadForm_CurrentFileName;
    private System.Windows.Forms.Label label_TotalReceiveFrom;
    private System.Windows.Forms.Label label_TotalReceivedBytes;
    private System.Windows.Forms.Label label_ReceivedFrom;
    private System.Windows.Forms.Label label_ReceivedBytes;
    private System.Windows.Forms.Label label_FilesDownloadForm_NumberFrom;
    private System.Windows.Forms.Label label_FilesDownloadForm_DownloadedFiles;
    private System.Windows.Forms.Label label_FilesDownloadForm_TotalDownloading;
    private System.Windows.Forms.Label label_FilesDownloadForm_CurrentDownloading;
    private System.Windows.Forms.Label label_FilesDownloadForm_DownloadFolder;
    private System.Windows.Forms.Label label_FilesDownloadForm_CurrentFileName;
    private System.Windows.Forms.ProgressBar progressBar_FilesDownloadForm_TotalDownloading;
    private System.Windows.Forms.Button button_FilesDownloadForm_StopDownload;
    private System.Windows.Forms.ProgressBar progressBar_FilesDownloadForm_CurrentDownloading;
    private System.Windows.Forms.ImageList imageList_Tasks;
    private System.ComponentModel.IContainer components;


    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesDownloadForm));
        this.pictureBox_FilesDownloadForm_HorLine1 = new System.Windows.Forms.PictureBox();
        this.pictureBox_FilesDownloadForm_HorLine2 = new System.Windows.Forms.PictureBox();
        this.button_FilesDownloadForm_Details = new System.Windows.Forms.Button();
        this.tabControl_FilesDownloadForm_Tasks = new System.Windows.Forms.TabControl();
        this.tabPage_Tasks = new System.Windows.Forms.TabPage();
        this.listView_FilesDownloadForm_Tasks = new System.Windows.Forms.ListView();
        this.columnHeader_TasksTabPage_TasksDescription = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_TasksTabPage_Time = new System.Windows.Forms.ColumnHeader();
        this.imageList_Tasks = new System.Windows.Forms.ImageList(this.components);
        this.tabPage_Errors = new System.Windows.Forms.TabPage();
        this.listView_FilesDownloadForm_Errors = new System.Windows.Forms.ListView();
        this.columnHeader_ErrorsTabPage_ErrorDescription = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_ErrorsTabPage_Time = new System.Windows.Forms.ColumnHeader();
        this.button_FilesDownloadForm_PauseDownload = new System.Windows.Forms.Button();
        this.comboBox_FilesDownloadForm_SegmentSize = new System.Windows.Forms.ComboBox();
        this.label_FilesDownloadForm_SegmentSize = new System.Windows.Forms.Label();
        this.textBox_TotalReceiveFrom = new System.Windows.Forms.TextBox();
        this.textBox_TotalReceivedBytes = new System.Windows.Forms.TextBox();
        this.textBox_ReceivedFrom = new System.Windows.Forms.TextBox();
        this.textBox_ReceivedBytes = new System.Windows.Forms.TextBox();
        this.textBox_FilesDownloadForm_TotalFilesNum = new System.Windows.Forms.TextBox();
        this.textBox_FilesDownloadForm_CurrentFileNum = new System.Windows.Forms.TextBox();
        this.textBox_FilesDownloadForm_DownloadFolder = new System.Windows.Forms.TextBox();
        this.textBox_FilesDownloadForm_CurrentFileName = new System.Windows.Forms.TextBox();
        this.label_TotalReceiveFrom = new System.Windows.Forms.Label();
        this.label_TotalReceivedBytes = new System.Windows.Forms.Label();
        this.label_ReceivedFrom = new System.Windows.Forms.Label();
        this.label_ReceivedBytes = new System.Windows.Forms.Label();
        this.label_FilesDownloadForm_NumberFrom = new System.Windows.Forms.Label();
        this.label_FilesDownloadForm_DownloadedFiles = new System.Windows.Forms.Label();
        this.label_FilesDownloadForm_TotalDownloading = new System.Windows.Forms.Label();
        this.label_FilesDownloadForm_CurrentDownloading = new System.Windows.Forms.Label();
        this.label_FilesDownloadForm_DownloadFolder = new System.Windows.Forms.Label();
        this.label_FilesDownloadForm_CurrentFileName = new System.Windows.Forms.Label();
        this.progressBar_FilesDownloadForm_TotalDownloading = new System.Windows.Forms.ProgressBar();
        this.button_FilesDownloadForm_StopDownload = new System.Windows.Forms.Button();
        this.progressBar_FilesDownloadForm_CurrentDownloading = new System.Windows.Forms.ProgressBar();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FilesDownloadForm_HorLine1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FilesDownloadForm_HorLine2)).BeginInit();
        this.tabControl_FilesDownloadForm_Tasks.SuspendLayout();
        this.tabPage_Tasks.SuspendLayout();
        this.tabPage_Errors.SuspendLayout();
        this.SuspendLayout();
        // 
        // pictureBox_FilesDownloadForm_HorLine1
        // 
        this.pictureBox_FilesDownloadForm_HorLine1.Location = new System.Drawing.Point(16, 128);
        this.pictureBox_FilesDownloadForm_HorLine1.Name = "pictureBox_FilesDownloadForm_HorLine1";
        this.pictureBox_FilesDownloadForm_HorLine1.Size = new System.Drawing.Size(472, 2);
        this.pictureBox_FilesDownloadForm_HorLine1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox_FilesDownloadForm_HorLine1.TabIndex = 57;
        this.pictureBox_FilesDownloadForm_HorLine1.TabStop = false;
        // 
        // pictureBox_FilesDownloadForm_HorLine2
        // 
        this.pictureBox_FilesDownloadForm_HorLine2.Location = new System.Drawing.Point(16, 256);
        this.pictureBox_FilesDownloadForm_HorLine2.Name = "pictureBox_FilesDownloadForm_HorLine2";
        this.pictureBox_FilesDownloadForm_HorLine2.Size = new System.Drawing.Size(472, 2);
        this.pictureBox_FilesDownloadForm_HorLine2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox_FilesDownloadForm_HorLine2.TabIndex = 56;
        this.pictureBox_FilesDownloadForm_HorLine2.TabStop = false;
        // 
        // button_FilesDownloadForm_Details
        // 
        this.button_FilesDownloadForm_Details.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_FilesDownloadForm_Details.Location = new System.Drawing.Point(376, 216);
        this.button_FilesDownloadForm_Details.Name = "button_FilesDownloadForm_Details";
        this.button_FilesDownloadForm_Details.Size = new System.Drawing.Size(112, 21);
        this.button_FilesDownloadForm_Details.TabIndex = 55;
        this.button_FilesDownloadForm_Details.Text = "Details >>";
        this.button_FilesDownloadForm_Details.Click += new System.EventHandler(this.button_FilesDownloadForm_Details_Click);
        // 
        // tabControl_FilesDownloadForm_Tasks
        // 
        this.tabControl_FilesDownloadForm_Tasks.Controls.Add(this.tabPage_Tasks);
        this.tabControl_FilesDownloadForm_Tasks.Controls.Add(this.tabPage_Errors);
        this.tabControl_FilesDownloadForm_Tasks.Location = new System.Drawing.Point(16, 280);
        this.tabControl_FilesDownloadForm_Tasks.Multiline = true;
        this.tabControl_FilesDownloadForm_Tasks.Name = "tabControl_FilesDownloadForm_Tasks";
        this.tabControl_FilesDownloadForm_Tasks.SelectedIndex = 0;
        this.tabControl_FilesDownloadForm_Tasks.Size = new System.Drawing.Size(472, 216);
        this.tabControl_FilesDownloadForm_Tasks.TabIndex = 54;
        // 
        // tabPage_Tasks
        // 
        this.tabPage_Tasks.Controls.Add(this.listView_FilesDownloadForm_Tasks);
        this.tabPage_Tasks.Location = new System.Drawing.Point(4, 22);
        this.tabPage_Tasks.Name = "tabPage_Tasks";
        this.tabPage_Tasks.Size = new System.Drawing.Size(464, 190);
        this.tabPage_Tasks.TabIndex = 2;
        this.tabPage_Tasks.Text = "Tasks";
        // 
        // listView_FilesDownloadForm_Tasks
        // 
        this.listView_FilesDownloadForm_Tasks.AllowColumnReorder = true;
        this.listView_FilesDownloadForm_Tasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_TasksTabPage_TasksDescription,
            this.columnHeader_TasksTabPage_Time});
        this.listView_FilesDownloadForm_Tasks.FullRowSelect = true;
        this.listView_FilesDownloadForm_Tasks.Location = new System.Drawing.Point(8, 8);
        this.listView_FilesDownloadForm_Tasks.Name = "listView_FilesDownloadForm_Tasks";
        this.listView_FilesDownloadForm_Tasks.Size = new System.Drawing.Size(448, 176);
        this.listView_FilesDownloadForm_Tasks.SmallImageList = this.imageList_Tasks;
        this.listView_FilesDownloadForm_Tasks.TabIndex = 1;
        this.listView_FilesDownloadForm_Tasks.UseCompatibleStateImageBehavior = false;
        this.listView_FilesDownloadForm_Tasks.View = System.Windows.Forms.View.Details;
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
        this.tabPage_Errors.Controls.Add(this.listView_FilesDownloadForm_Errors);
        this.tabPage_Errors.Location = new System.Drawing.Point(4, 22);
        this.tabPage_Errors.Name = "tabPage_Errors";
        this.tabPage_Errors.Size = new System.Drawing.Size(464, 190);
        this.tabPage_Errors.TabIndex = 1;
        this.tabPage_Errors.Text = "Errors";
        this.tabPage_Errors.Visible = false;
        // 
        // listView_FilesDownloadForm_Errors
        // 
        this.listView_FilesDownloadForm_Errors.AllowColumnReorder = true;
        this.listView_FilesDownloadForm_Errors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ErrorsTabPage_ErrorDescription,
            this.columnHeader_ErrorsTabPage_Time});
        this.listView_FilesDownloadForm_Errors.FullRowSelect = true;
        this.listView_FilesDownloadForm_Errors.Location = new System.Drawing.Point(8, 8);
        this.listView_FilesDownloadForm_Errors.Name = "listView_FilesDownloadForm_Errors";
        this.listView_FilesDownloadForm_Errors.Size = new System.Drawing.Size(448, 176);
        this.listView_FilesDownloadForm_Errors.SmallImageList = this.imageList_Tasks;
        this.listView_FilesDownloadForm_Errors.TabIndex = 0;
        this.listView_FilesDownloadForm_Errors.UseCompatibleStateImageBehavior = false;
        this.listView_FilesDownloadForm_Errors.View = System.Windows.Forms.View.Details;
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
        // button_FilesDownloadForm_PauseDownload
        // 
        this.button_FilesDownloadForm_PauseDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_FilesDownloadForm_PauseDownload.Location = new System.Drawing.Point(432, 184);
        this.button_FilesDownloadForm_PauseDownload.Name = "button_FilesDownloadForm_PauseDownload";
        this.button_FilesDownloadForm_PauseDownload.Size = new System.Drawing.Size(56, 23);
        this.button_FilesDownloadForm_PauseDownload.TabIndex = 53;
        this.button_FilesDownloadForm_PauseDownload.Text = "Pause";
        this.button_FilesDownloadForm_PauseDownload.Click += new System.EventHandler(this.button_FilesDownloadForm_PauseDownload_Click);
        // 
        // comboBox_FilesDownloadForm_SegmentSize
        // 
        this.comboBox_FilesDownloadForm_SegmentSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox_FilesDownloadForm_SegmentSize.Items.AddRange(new object[] {
            "1024",
            "2048",
            "4096",
            "8192",
            "16384",
            "32768",
            "65536",
            "131072"});
        this.comboBox_FilesDownloadForm_SegmentSize.Location = new System.Drawing.Point(376, 152);
        this.comboBox_FilesDownloadForm_SegmentSize.Name = "comboBox_FilesDownloadForm_SegmentSize";
        this.comboBox_FilesDownloadForm_SegmentSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.comboBox_FilesDownloadForm_SegmentSize.Size = new System.Drawing.Size(112, 21);
        this.comboBox_FilesDownloadForm_SegmentSize.TabIndex = 52;
        this.comboBox_FilesDownloadForm_SegmentSize.SelectedIndexChanged += new System.EventHandler(this.comboBox_FilesDownloadForm_SegmentSize_SelectedIndexChanged);
        // 
        // label_FilesDownloadForm_SegmentSize
        // 
        this.label_FilesDownloadForm_SegmentSize.Location = new System.Drawing.Point(376, 136);
        this.label_FilesDownloadForm_SegmentSize.Name = "label_FilesDownloadForm_SegmentSize";
        this.label_FilesDownloadForm_SegmentSize.Size = new System.Drawing.Size(112, 16);
        this.label_FilesDownloadForm_SegmentSize.TabIndex = 51;
        // 
        // textBox_TotalReceiveFrom
        // 
        this.textBox_TotalReceiveFrom.Location = new System.Drawing.Point(384, 64);
        this.textBox_TotalReceiveFrom.Name = "textBox_TotalReceiveFrom";
        this.textBox_TotalReceiveFrom.ReadOnly = true;
        this.textBox_TotalReceiveFrom.Size = new System.Drawing.Size(104, 20);
        this.textBox_TotalReceiveFrom.TabIndex = 50;
        // 
        // textBox_TotalReceivedBytes
        // 
        this.textBox_TotalReceivedBytes.Location = new System.Drawing.Point(240, 64);
        this.textBox_TotalReceivedBytes.Name = "textBox_TotalReceivedBytes";
        this.textBox_TotalReceivedBytes.ReadOnly = true;
        this.textBox_TotalReceivedBytes.Size = new System.Drawing.Size(104, 20);
        this.textBox_TotalReceivedBytes.TabIndex = 48;
        // 
        // textBox_ReceivedFrom
        // 
        this.textBox_ReceivedFrom.Location = new System.Drawing.Point(384, 8);
        this.textBox_ReceivedFrom.Name = "textBox_ReceivedFrom";
        this.textBox_ReceivedFrom.ReadOnly = true;
        this.textBox_ReceivedFrom.Size = new System.Drawing.Size(104, 20);
        this.textBox_ReceivedFrom.TabIndex = 46;
        // 
        // textBox_ReceivedBytes
        // 
        this.textBox_ReceivedBytes.Location = new System.Drawing.Point(240, 8);
        this.textBox_ReceivedBytes.Name = "textBox_ReceivedBytes";
        this.textBox_ReceivedBytes.ReadOnly = true;
        this.textBox_ReceivedBytes.Size = new System.Drawing.Size(104, 20);
        this.textBox_ReceivedBytes.TabIndex = 44;
        // 
        // textBox_FilesDownloadForm_TotalFilesNum
        // 
        this.textBox_FilesDownloadForm_TotalFilesNum.Location = new System.Drawing.Point(312, 216);
        this.textBox_FilesDownloadForm_TotalFilesNum.Name = "textBox_FilesDownloadForm_TotalFilesNum";
        this.textBox_FilesDownloadForm_TotalFilesNum.ReadOnly = true;
        this.textBox_FilesDownloadForm_TotalFilesNum.Size = new System.Drawing.Size(48, 20);
        this.textBox_FilesDownloadForm_TotalFilesNum.TabIndex = 40;
        // 
        // textBox_FilesDownloadForm_CurrentFileNum
        // 
        this.textBox_FilesDownloadForm_CurrentFileNum.Location = new System.Drawing.Point(168, 216);
        this.textBox_FilesDownloadForm_CurrentFileNum.Name = "textBox_FilesDownloadForm_CurrentFileNum";
        this.textBox_FilesDownloadForm_CurrentFileNum.ReadOnly = true;
        this.textBox_FilesDownloadForm_CurrentFileNum.Size = new System.Drawing.Size(48, 20);
        this.textBox_FilesDownloadForm_CurrentFileNum.TabIndex = 39;
        // 
        // textBox_FilesDownloadForm_DownloadFolder
        // 
        this.textBox_FilesDownloadForm_DownloadFolder.Location = new System.Drawing.Point(168, 184);
        this.textBox_FilesDownloadForm_DownloadFolder.Name = "textBox_FilesDownloadForm_DownloadFolder";
        this.textBox_FilesDownloadForm_DownloadFolder.ReadOnly = true;
        this.textBox_FilesDownloadForm_DownloadFolder.Size = new System.Drawing.Size(192, 20);
        this.textBox_FilesDownloadForm_DownloadFolder.TabIndex = 36;
        // 
        // textBox_FilesDownloadForm_CurrentFileName
        // 
        this.textBox_FilesDownloadForm_CurrentFileName.Location = new System.Drawing.Point(168, 152);
        this.textBox_FilesDownloadForm_CurrentFileName.Name = "textBox_FilesDownloadForm_CurrentFileName";
        this.textBox_FilesDownloadForm_CurrentFileName.ReadOnly = true;
        this.textBox_FilesDownloadForm_CurrentFileName.Size = new System.Drawing.Size(192, 20);
        this.textBox_FilesDownloadForm_CurrentFileName.TabIndex = 33;
        // 
        // label_TotalReceiveFrom
        // 
        this.label_TotalReceiveFrom.Location = new System.Drawing.Point(352, 72);
        this.label_TotalReceiveFrom.Name = "label_TotalReceiveFrom";
        this.label_TotalReceiveFrom.Size = new System.Drawing.Size(32, 16);
        this.label_TotalReceiveFrom.TabIndex = 49;
        this.label_TotalReceiveFrom.Text = "from";
        // 
        // label_TotalReceivedBytes
        // 
        this.label_TotalReceivedBytes.Location = new System.Drawing.Point(144, 72);
        this.label_TotalReceivedBytes.Name = "label_TotalReceivedBytes";
        this.label_TotalReceivedBytes.Size = new System.Drawing.Size(96, 16);
        this.label_TotalReceivedBytes.TabIndex = 47;
        // 
        // label_ReceivedFrom
        // 
        this.label_ReceivedFrom.Location = new System.Drawing.Point(352, 16);
        this.label_ReceivedFrom.Name = "label_ReceivedFrom";
        this.label_ReceivedFrom.Size = new System.Drawing.Size(56, 16);
        this.label_ReceivedFrom.TabIndex = 45;
        // 
        // label_ReceivedBytes
        // 
        this.label_ReceivedBytes.Location = new System.Drawing.Point(144, 16);
        this.label_ReceivedBytes.Name = "label_ReceivedBytes";
        this.label_ReceivedBytes.Size = new System.Drawing.Size(96, 16);
        this.label_ReceivedBytes.TabIndex = 43;
        // 
        // label_FilesDownloadForm_NumberFrom
        // 
        this.label_FilesDownloadForm_NumberFrom.Location = new System.Drawing.Point(248, 224);
        this.label_FilesDownloadForm_NumberFrom.Name = "label_FilesDownloadForm_NumberFrom";
        this.label_FilesDownloadForm_NumberFrom.Size = new System.Drawing.Size(32, 16);
        this.label_FilesDownloadForm_NumberFrom.TabIndex = 42;
        this.label_FilesDownloadForm_NumberFrom.Text = "from";
        // 
        // label_FilesDownloadForm_DownloadedFiles
        // 
        this.label_FilesDownloadForm_DownloadedFiles.Location = new System.Drawing.Point(16, 224);
        this.label_FilesDownloadForm_DownloadedFiles.Name = "label_FilesDownloadForm_DownloadedFiles";
        this.label_FilesDownloadForm_DownloadedFiles.Size = new System.Drawing.Size(144, 16);
        this.label_FilesDownloadForm_DownloadedFiles.TabIndex = 41;
        this.label_FilesDownloadForm_DownloadedFiles.Text = "Downloaded files";
        // 
        // label_FilesDownloadForm_TotalDownloading
        // 
        this.label_FilesDownloadForm_TotalDownloading.Location = new System.Drawing.Point(16, 72);
        this.label_FilesDownloadForm_TotalDownloading.Name = "label_FilesDownloadForm_TotalDownloading";
        this.label_FilesDownloadForm_TotalDownloading.Size = new System.Drawing.Size(120, 16);
        this.label_FilesDownloadForm_TotalDownloading.TabIndex = 38;
        this.label_FilesDownloadForm_TotalDownloading.Text = "Total downloading";
        // 
        // label_FilesDownloadForm_CurrentDownloading
        // 
        this.label_FilesDownloadForm_CurrentDownloading.Location = new System.Drawing.Point(16, 16);
        this.label_FilesDownloadForm_CurrentDownloading.Name = "label_FilesDownloadForm_CurrentDownloading";
        this.label_FilesDownloadForm_CurrentDownloading.Size = new System.Drawing.Size(120, 16);
        this.label_FilesDownloadForm_CurrentDownloading.TabIndex = 37;
        // 
        // label_FilesDownloadForm_DownloadFolder
        // 
        this.label_FilesDownloadForm_DownloadFolder.Location = new System.Drawing.Point(16, 184);
        this.label_FilesDownloadForm_DownloadFolder.Name = "label_FilesDownloadForm_DownloadFolder";
        this.label_FilesDownloadForm_DownloadFolder.Size = new System.Drawing.Size(144, 32);
        this.label_FilesDownloadForm_DownloadFolder.TabIndex = 35;
        this.label_FilesDownloadForm_DownloadFolder.Text = "Download folder:";
        // 
        // label_FilesDownloadForm_CurrentFileName
        // 
        this.label_FilesDownloadForm_CurrentFileName.Location = new System.Drawing.Point(16, 152);
        this.label_FilesDownloadForm_CurrentFileName.Name = "label_FilesDownloadForm_CurrentFileName";
        this.label_FilesDownloadForm_CurrentFileName.Size = new System.Drawing.Size(144, 24);
        this.label_FilesDownloadForm_CurrentFileName.TabIndex = 34;
        this.label_FilesDownloadForm_CurrentFileName.Text = "Current file name:";
        // 
        // progressBar_FilesDownloadForm_TotalDownloading
        // 
        this.progressBar_FilesDownloadForm_TotalDownloading.Location = new System.Drawing.Point(16, 96);
        this.progressBar_FilesDownloadForm_TotalDownloading.Name = "progressBar_FilesDownloadForm_TotalDownloading";
        this.progressBar_FilesDownloadForm_TotalDownloading.Size = new System.Drawing.Size(472, 16);
        this.progressBar_FilesDownloadForm_TotalDownloading.TabIndex = 32;
        // 
        // button_FilesDownloadForm_StopDownload
        // 
        this.button_FilesDownloadForm_StopDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_FilesDownloadForm_StopDownload.Location = new System.Drawing.Point(376, 184);
        this.button_FilesDownloadForm_StopDownload.Name = "button_FilesDownloadForm_StopDownload";
        this.button_FilesDownloadForm_StopDownload.Size = new System.Drawing.Size(56, 23);
        this.button_FilesDownloadForm_StopDownload.TabIndex = 31;
        this.button_FilesDownloadForm_StopDownload.Text = "Stop";
        this.button_FilesDownloadForm_StopDownload.Click += new System.EventHandler(this.button_FilesDownloadForm_StopDownload_Click);
        // 
        // progressBar_FilesDownloadForm_CurrentDownloading
        // 
        this.progressBar_FilesDownloadForm_CurrentDownloading.Location = new System.Drawing.Point(16, 40);
        this.progressBar_FilesDownloadForm_CurrentDownloading.Name = "progressBar_FilesDownloadForm_CurrentDownloading";
        this.progressBar_FilesDownloadForm_CurrentDownloading.Size = new System.Drawing.Size(472, 16);
        this.progressBar_FilesDownloadForm_CurrentDownloading.TabIndex = 30;
        // 
        // FilesDownloadForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(504, 509);
        this.ControlBox = false;
        this.Controls.Add(this.pictureBox_FilesDownloadForm_HorLine1);
        this.Controls.Add(this.pictureBox_FilesDownloadForm_HorLine2);
        this.Controls.Add(this.button_FilesDownloadForm_Details);
        this.Controls.Add(this.tabControl_FilesDownloadForm_Tasks);
        this.Controls.Add(this.button_FilesDownloadForm_PauseDownload);
        this.Controls.Add(this.comboBox_FilesDownloadForm_SegmentSize);
        this.Controls.Add(this.label_FilesDownloadForm_SegmentSize);
        this.Controls.Add(this.textBox_TotalReceiveFrom);
        this.Controls.Add(this.textBox_TotalReceivedBytes);
        this.Controls.Add(this.textBox_ReceivedFrom);
        this.Controls.Add(this.textBox_ReceivedBytes);
        this.Controls.Add(this.textBox_FilesDownloadForm_TotalFilesNum);
        this.Controls.Add(this.textBox_FilesDownloadForm_CurrentFileNum);
        this.Controls.Add(this.textBox_FilesDownloadForm_DownloadFolder);
        this.Controls.Add(this.textBox_FilesDownloadForm_CurrentFileName);
        this.Controls.Add(this.label_TotalReceiveFrom);
        this.Controls.Add(this.label_TotalReceivedBytes);
        this.Controls.Add(this.label_ReceivedFrom);
        this.Controls.Add(this.label_ReceivedBytes);
        this.Controls.Add(this.label_FilesDownloadForm_NumberFrom);
        this.Controls.Add(this.label_FilesDownloadForm_DownloadedFiles);
        this.Controls.Add(this.label_FilesDownloadForm_TotalDownloading);
        this.Controls.Add(this.label_FilesDownloadForm_CurrentDownloading);
        this.Controls.Add(this.label_FilesDownloadForm_DownloadFolder);
        this.Controls.Add(this.label_FilesDownloadForm_CurrentFileName);
        this.Controls.Add(this.progressBar_FilesDownloadForm_TotalDownloading);
        this.Controls.Add(this.button_FilesDownloadForm_StopDownload);
        this.Controls.Add(this.progressBar_FilesDownloadForm_CurrentDownloading);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FilesDownloadForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "FilesDownloadForm";
        this.Shown += new System.EventHandler(this.FilesDownloadForm_Shown);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FilesDownloadForm_HorLine1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FilesDownloadForm_HorLine2)).EndInit();
        this.tabControl_FilesDownloadForm_Tasks.ResumeLayout(false);
        this.tabPage_Tasks.ResumeLayout(false);
        this.tabPage_Errors.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    #endregion

    public FilesDownloadForm()
    {
        InitializeComponent();

        this.comboBox_FilesDownloadForm_SegmentSize.SelectedIndex = 5;

        Show();
    }
    
    public void ChangeControlsLanguage()
    {

        this.button_FilesDownloadForm_Details.Text = ClientStringFactory.GetString(340, ClientSettingsEnvironment.CurrentLanguage);
        this.button_FilesDownloadForm_StopDownload.Text = ClientStringFactory.GetString(35, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesDownloadForm_CurrentFileName.Text = ClientStringFactory.GetString(36, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesDownloadForm_DownloadFolder.Text = ClientStringFactory.GetString(37, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesDownloadForm_CurrentDownloading.Text = ClientStringFactory.GetString(38, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesDownloadForm_TotalDownloading.Text = ClientStringFactory.GetString(244, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesDownloadForm_DownloadedFiles.Text = ClientStringFactory.GetString(39, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesDownloadForm_NumberFrom.Text = ClientStringFactory.GetString(40, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ReceivedBytes.Text = ClientStringFactory.GetString(41, ClientSettingsEnvironment.CurrentLanguage);
        this.label_ReceivedFrom.Text = ClientStringFactory.GetString(40, ClientSettingsEnvironment.CurrentLanguage);
        this.label_TotalReceiveFrom.Text = ClientStringFactory.GetString(40, ClientSettingsEnvironment.CurrentLanguage);
        this.label_TotalReceivedBytes.Text = ClientStringFactory.GetString(41, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FilesDownloadForm_SegmentSize.Text = ClientStringFactory.GetString(256, ClientSettingsEnvironment.CurrentLanguage);
        this.Text = ClientStringFactory.GetString(247, ClientSettingsEnvironment.CurrentLanguage);

        this.tabPage_Errors.Text = ClientStringFactory.GetString(343, ClientSettingsEnvironment.CurrentLanguage);
        this.tabPage_Tasks.Text = ClientStringFactory.GetString(346, ClientSettingsEnvironment.CurrentLanguage);

        this.columnHeader_ErrorsTabPage_ErrorDescription.Text = ClientStringFactory.GetString(315, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_ErrorsTabPage_Time.Text = ClientStringFactory.GetString(20, ClientSettingsEnvironment.CurrentLanguage);

        this.columnHeader_TasksTabPage_TasksDescription.Text = ClientStringFactory.GetString(315, ClientSettingsEnvironment.CurrentLanguage);
        this.columnHeader_TasksTabPage_Time.Text = ClientStringFactory.GetString(20, ClientSettingsEnvironment.CurrentLanguage);


        if (!DownloadPaused)
            this.button_FilesDownloadForm_PauseDownload.Text = ClientStringFactory.GetString(259, ClientSettingsEnvironment.CurrentLanguage);

        else
            this.button_FilesDownloadForm_PauseDownload.Text = ClientStringFactory.GetString(260, ClientSettingsEnvironment.CurrentLanguage);

        tabControl_FilesDownloadForm_Tasks.SelectedIndex = tabControl_FilesDownloadForm_Tasks.Controls.IndexOf(tabPage_Errors);

    }


    public string CurrentDownloadingFileName
    {
        set
        {
            textBox_FilesDownloadForm_CurrentFileName.Text = value;
        }

        get
        {
            return textBox_FilesDownloadForm_CurrentFileName.Text;
        }
    }

    public int CurrentFileNum
    {
        set
        {
            textBox_FilesDownloadForm_CurrentFileNum.Text = value.ToString();
        }

        get
        {
            return int.Parse(textBox_FilesDownloadForm_CurrentFileNum.Text);
        }
    }

    public int TotalFilesNum
    {
        set
        {
            textBox_FilesDownloadForm_TotalFilesNum.Text = value.ToString();
        }

        get
        {
            return int.Parse(textBox_FilesDownloadForm_TotalFilesNum.Text);
        }
    }

    public string DownloadFolder
    {
        set
        {
            textBox_FilesDownloadForm_DownloadFolder.Text = value;
        }

        get
        {
            return textBox_FilesDownloadForm_DownloadFolder.Text;
        }
    }

    public long DownloadProgress
    {
        set
        {
            if (progressBar_FilesDownloadForm_CurrentDownloading.Maximum != 0)
                progressBar_FilesDownloadForm_CurrentDownloading.Value = (int)value;

            textBox_ReceivedBytes.Text = ObjCopy.obj_MainClientForm.SpreadToHundreds(value.ToString());
        }
    }

    public long DownloadProgress_MaxValue
    {
        set
        {
            if (value <= int.MaxValue) progressBar_FilesDownloadForm_CurrentDownloading.Maximum = (int)value;
            else progressBar_FilesDownloadForm_CurrentDownloading.Maximum = 0;

            textBox_ReceivedFrom.Text = ObjCopy.obj_MainClientForm.SpreadToHundreds(value.ToString());
        }
    }

    public long TotalDownloadProgress
    {
        set
        {
            textBox_TotalReceivedBytes.Text = ObjCopy.obj_MainClientForm.SpreadToHundreds(value.ToString());

            if (progressBar_FilesDownloadForm_TotalDownloading.Maximum > 0)
                progressBar_FilesDownloadForm_TotalDownloading.Value = (int)value;

        }
    }

    public long TotalDownloadProgress_MaxValue
    {
        set
        {
            textBox_TotalReceiveFrom.Text = ObjCopy.obj_MainClientForm.SpreadToHundreds(value.ToString());

            if (value <= int.MaxValue)
            {
                progressBar_FilesDownloadForm_TotalDownloading.Maximum = (int)value;
            }
            else
            {
                progressBar_FilesDownloadForm_TotalDownloading.Maximum = 0;
            }
        }

    }

    public int DownloadedSegmentSize //!! ÁÀÃ! ÂÛÇÎÂ ÍÅ ÈÇ ÒÎÃÎ ÏÎÒÎÊÀ!!! 
    {
        get
        {
            return int.Parse(comboBox_FilesDownloadForm_SegmentSize.Text);            
        }
    }


    static bool bool_DownloadPaused = false;
    public bool DownloadPaused
    {
        get
        {
            return bool_DownloadPaused;
        }

        set
        {
            bool_DownloadPaused = value;
        }

    }


    private void button_FilesDownloadForm_StopDownload_Click(object sender, System.EventArgs e)
    {
        DownloadPaused = true;

        if (DialogResult.No == MessageBox.Show(ClientStringFactory.GetString(262, ClientSettingsEnvironment.CurrentLanguage), ClientStringFactory.GetString(1, ClientSettingsEnvironment.CurrentLanguage), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
        {
            DownloadPaused = false;
            return;
        }

        if (MainTcpClient.IsConnected)
        {
            try
            {
                new Thread(new ThreadStart(new RemoteCallAction().DeleteAllDownloadingTasks)).Start();
            }

            catch
            {
            }
        }


        if (DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Count > 0 && DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList[0].UINT != 0)
        {
            DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList[0].DownloadingFileStream.Close();
        }

        DatabaseOfDownloadingFiles.DatabaseOfDownloadingFilesList.Clear();
        ObjCopy.obj_MainClientForm.ChangeDownloadProgress();

        DownloadPaused = false;

        return;
    }

    private void button_FilesDownloadForm_PauseDownload_Click(object sender, System.EventArgs e)
    {
        if (DownloadPaused == false)
        {
            DownloadPaused = true;
            this.button_FilesDownloadForm_PauseDownload.Text = ClientStringFactory.GetString(260, ClientSettingsEnvironment.CurrentLanguage);
        }

        else
        {
            DownloadPaused = false;
            this.button_FilesDownloadForm_PauseDownload.Text = ClientStringFactory.GetString(259, ClientSettingsEnvironment.CurrentLanguage);
        }
    }

    private void button_FilesDownloadForm_Details_Click(object sender, System.EventArgs e)
    {
        if (this.MaximumSize.Height == 536)
        {
            this.MaximumSize = new System.Drawing.Size(504, 280);
            this.MinimumSize = new System.Drawing.Size(504, 280);
            this.button_FilesDownloadForm_Details.Text = ClientStringFactory.GetString(340, ClientSettingsEnvironment.CurrentLanguage);
        }

        else
        {
            this.MaximumSize = new System.Drawing.Size(504, 536);
            this.MinimumSize = new System.Drawing.Size(504, 536);
            this.button_FilesDownloadForm_Details.Text = ClientStringFactory.GetString(341, ClientSettingsEnvironment.CurrentLanguage);
        }
    }


    public void AddError(string string_ErrorDescription)
    {
        ListViewItem listViewItem_NewError = new ListViewItem(string_ErrorDescription, listView_FilesDownloadForm_Errors.Items.Count);

        listViewItem_NewError.SubItems.Add(System.DateTime.Now.ToLongTimeString());

        listViewItem_NewError.ImageIndex = 0;

        listView_FilesDownloadForm_Errors.Items.Add(listViewItem_NewError);

        this.MaximumSize = new System.Drawing.Size(504, 536);
        this.MinimumSize = new System.Drawing.Size(504, 536);

        this.button_FilesDownloadForm_Details.Text = ClientStringFactory.GetString(341, ClientSettingsEnvironment.CurrentLanguage);

        this.tabControl_FilesDownloadForm_Tasks.SelectedIndex = this.tabControl_FilesDownloadForm_Tasks.Controls.IndexOf(tabPage_Errors);
    }

    public void AddTask(string string_TaskDescription)
    {
        ListViewItem listViewItem_NewTask = new ListViewItem(string_TaskDescription, listView_FilesDownloadForm_Tasks.Items.Count);

        listViewItem_NewTask.SubItems.Add(System.DateTime.Now.ToLongTimeString());

        listViewItem_NewTask.ImageIndex = 1;

        listView_FilesDownloadForm_Tasks.Items.Add(listViewItem_NewTask);

      

        this.MaximumSize = new System.Drawing.Size(504, 536);
        this.MinimumSize = new System.Drawing.Size(504, 536);

        this.button_FilesDownloadForm_Details.Text = ClientStringFactory.GetString(341, ClientSettingsEnvironment.CurrentLanguage);

        this.tabControl_FilesDownloadForm_Tasks.SelectedIndex = this.tabControl_FilesDownloadForm_Tasks.Controls.IndexOf(tabPage_Tasks);
    }


    private void comboBox_FilesDownloadForm_SegmentSize_SelectedIndexChanged(object sender, System.EventArgs e)
    {

    }


    public bool EnableStopButton
    {
        set
        {
            this.button_FilesDownloadForm_StopDownload.Enabled = value;
        }
    }

    private void FilesDownloadForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }

}

