using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using YakSys.XMLConfigImporter;
using YakSys.XMLConfigImporter.YakSysRctClient;
using YakSys.XMLConfigImporter.YakSysRctClient.Version110;

public class FileManagerObjectPropertiesForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.TextBox textBox_FileManagerObjectPropertiesForm_ObjectName;
    private System.Windows.Forms.PictureBox pictureBox_FileManagerObjectPropertiesForm_TypeIcon;
    private System.Windows.Forms.PictureBox pictureBox_FileManagerObjectPropertiesForm_HorLine1;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_ObjectType;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_ObjectAccessedTime;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_Location;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_Size;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_ObjectCreatedTime;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_ObjectModifiedTime;
    private System.Windows.Forms.CheckBox checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute;
    private System.Windows.Forms.CheckBox checkBox_FileManagerObjectPropertiesForm_HiddenAttribute;
    private System.Windows.Forms.PictureBox pictureBox_FileManagerObjectPropertiesForm_HorLine3;
    private System.Windows.Forms.PictureBox pictureBox_FileManagerObjectPropertiesForm_HorLine2;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension;
    private System.Windows.Forms.Button button_FileManagerObjectPropertiesForm_OK;
    private System.Windows.Forms.Button button_FileManagerObjectPropertiesForm_Cancel;
    private System.Windows.Forms.GroupBox groupBox_FileManagerObjectPropertiesForm_Attribues;
    private System.Windows.Forms.CheckBox checkBox_FileManagerObjectPropertiesForm_System;
    private System.Windows.Forms.CheckBox checkBox_FileManagerObjectPropertiesForm_Archive;
    private System.Windows.Forms.ImageList imageList_FileManagerObjects;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_SizeText;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_ObjectCreatedTimeText;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_ObjectModifiedTimeText;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_ObjectAccessedTimeText;
    private System.Windows.Forms.CheckBox checkBox_FileManagerObjectPropertiesForm_NotContentIndexed;
    private System.Windows.Forms.CheckBox checkBox_FileManagerObjectPropertiesForm_Offline;
    private System.Windows.Forms.TextBox textBox_FileManagerObjectPropertiesForm_ObjectTypeText;
    private System.Windows.Forms.Label label_FileManagerObjectPropertiesForm_ObjectTypeText;
    private System.Windows.Forms.TextBox textBox_FileManagerObjectPropertiesForm_LocationText;
    private System.ComponentModel.IContainer components;
    
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManagerObjectPropertiesForm));
        this.textBox_FileManagerObjectPropertiesForm_ObjectName = new System.Windows.Forms.TextBox();
        this.pictureBox_FileManagerObjectPropertiesForm_TypeIcon = new System.Windows.Forms.PictureBox();
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine1 = new System.Windows.Forms.PictureBox();
        this.label_FileManagerObjectPropertiesForm_ObjectType = new System.Windows.Forms.Label();
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTime = new System.Windows.Forms.Label();
        this.label_FileManagerObjectPropertiesForm_Location = new System.Windows.Forms.Label();
        this.label_FileManagerObjectPropertiesForm_Size = new System.Windows.Forms.Label();
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTime = new System.Windows.Forms.Label();
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTime = new System.Windows.Forms.Label();
        this.checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute = new System.Windows.Forms.CheckBox();
        this.checkBox_FileManagerObjectPropertiesForm_HiddenAttribute = new System.Windows.Forms.CheckBox();
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine3 = new System.Windows.Forms.PictureBox();
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine2 = new System.Windows.Forms.PictureBox();
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension = new System.Windows.Forms.Label();
        this.button_FileManagerObjectPropertiesForm_OK = new System.Windows.Forms.Button();
        this.button_FileManagerObjectPropertiesForm_Cancel = new System.Windows.Forms.Button();
        this.groupBox_FileManagerObjectPropertiesForm_Attribues = new System.Windows.Forms.GroupBox();
        this.checkBox_FileManagerObjectPropertiesForm_Archive = new System.Windows.Forms.CheckBox();
        this.checkBox_FileManagerObjectPropertiesForm_NotContentIndexed = new System.Windows.Forms.CheckBox();
        this.checkBox_FileManagerObjectPropertiesForm_Offline = new System.Windows.Forms.CheckBox();
        this.checkBox_FileManagerObjectPropertiesForm_System = new System.Windows.Forms.CheckBox();
        this.imageList_FileManagerObjects = new System.Windows.Forms.ImageList(this.components);
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText = new System.Windows.Forms.Label();
        this.label_FileManagerObjectPropertiesForm_SizeText = new System.Windows.Forms.Label();
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTimeText = new System.Windows.Forms.Label();
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTimeText = new System.Windows.Forms.Label();
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTimeText = new System.Windows.Forms.Label();
        this.textBox_FileManagerObjectPropertiesForm_ObjectTypeText = new System.Windows.Forms.TextBox();
        this.label_FileManagerObjectPropertiesForm_ObjectTypeText = new System.Windows.Forms.Label();
        this.textBox_FileManagerObjectPropertiesForm_LocationText = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FileManagerObjectPropertiesForm_TypeIcon)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FileManagerObjectPropertiesForm_HorLine1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FileManagerObjectPropertiesForm_HorLine3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FileManagerObjectPropertiesForm_HorLine2)).BeginInit();
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.SuspendLayout();
        this.SuspendLayout();
        // 
        // textBox_FileManagerObjectPropertiesForm_ObjectName
        // 
        this.textBox_FileManagerObjectPropertiesForm_ObjectName.Cursor = System.Windows.Forms.Cursors.Default;
        this.textBox_FileManagerObjectPropertiesForm_ObjectName.Location = new System.Drawing.Point(64, 24);
        this.textBox_FileManagerObjectPropertiesForm_ObjectName.Multiline = true;
        this.textBox_FileManagerObjectPropertiesForm_ObjectName.Name = "textBox_FileManagerObjectPropertiesForm_ObjectName";
        this.textBox_FileManagerObjectPropertiesForm_ObjectName.ReadOnly = true;
        this.textBox_FileManagerObjectPropertiesForm_ObjectName.Size = new System.Drawing.Size(256, 24);
        this.textBox_FileManagerObjectPropertiesForm_ObjectName.TabIndex = 3;
        // 
        // pictureBox_FileManagerObjectPropertiesForm_TypeIcon
        // 
        this.pictureBox_FileManagerObjectPropertiesForm_TypeIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_FileManagerObjectPropertiesForm_TypeIcon.Image")));
        this.pictureBox_FileManagerObjectPropertiesForm_TypeIcon.Location = new System.Drawing.Point(16, 16);
        this.pictureBox_FileManagerObjectPropertiesForm_TypeIcon.Name = "pictureBox_FileManagerObjectPropertiesForm_TypeIcon";
        this.pictureBox_FileManagerObjectPropertiesForm_TypeIcon.Size = new System.Drawing.Size(28, 34);
        this.pictureBox_FileManagerObjectPropertiesForm_TypeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        this.pictureBox_FileManagerObjectPropertiesForm_TypeIcon.TabIndex = 1;
        this.pictureBox_FileManagerObjectPropertiesForm_TypeIcon.TabStop = false;
        // 
        // pictureBox_FileManagerObjectPropertiesForm_HorLine1
        // 
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_FileManagerObjectPropertiesForm_HorLine1.Image")));
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine1.Location = new System.Drawing.Point(8, 64);
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine1.Name = "pictureBox_FileManagerObjectPropertiesForm_HorLine1";
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine1.Size = new System.Drawing.Size(312, 2);
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine1.TabIndex = 2;
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine1.TabStop = false;
        // 
        // label_FileManagerObjectPropertiesForm_ObjectType
        // 
        this.label_FileManagerObjectPropertiesForm_ObjectType.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_ObjectType.Location = new System.Drawing.Point(16, 80);
        this.label_FileManagerObjectPropertiesForm_ObjectType.Name = "label_FileManagerObjectPropertiesForm_ObjectType";
        this.label_FileManagerObjectPropertiesForm_ObjectType.Size = new System.Drawing.Size(120, 16);
        this.label_FileManagerObjectPropertiesForm_ObjectType.TabIndex = 0;
        this.label_FileManagerObjectPropertiesForm_ObjectType.Text = "Type:";
        // 
        // label_FileManagerObjectPropertiesForm_ObjectAccessedTime
        // 
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTime.Location = new System.Drawing.Point(16, 256);
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTime.Name = "label_FileManagerObjectPropertiesForm_ObjectAccessedTime";
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTime.Size = new System.Drawing.Size(120, 16);
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTime.TabIndex = 4;
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTime.Text = "Accessed:";
        // 
        // label_FileManagerObjectPropertiesForm_Location
        // 
        this.label_FileManagerObjectPropertiesForm_Location.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_Location.Location = new System.Drawing.Point(16, 144);
        this.label_FileManagerObjectPropertiesForm_Location.Name = "label_FileManagerObjectPropertiesForm_Location";
        this.label_FileManagerObjectPropertiesForm_Location.Size = new System.Drawing.Size(120, 16);
        this.label_FileManagerObjectPropertiesForm_Location.TabIndex = 5;
        this.label_FileManagerObjectPropertiesForm_Location.Text = "Location:";
        // 
        // label_FileManagerObjectPropertiesForm_Size
        // 
        this.label_FileManagerObjectPropertiesForm_Size.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_Size.Location = new System.Drawing.Point(16, 168);
        this.label_FileManagerObjectPropertiesForm_Size.Name = "label_FileManagerObjectPropertiesForm_Size";
        this.label_FileManagerObjectPropertiesForm_Size.Size = new System.Drawing.Size(120, 16);
        this.label_FileManagerObjectPropertiesForm_Size.TabIndex = 6;
        this.label_FileManagerObjectPropertiesForm_Size.Text = "Size:";
        // 
        // label_FileManagerObjectPropertiesForm_ObjectCreatedTime
        // 
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTime.Location = new System.Drawing.Point(16, 208);
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTime.Name = "label_FileManagerObjectPropertiesForm_ObjectCreatedTime";
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTime.Size = new System.Drawing.Size(120, 16);
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTime.TabIndex = 8;
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTime.Text = "Created:";
        // 
        // label_FileManagerObjectPropertiesForm_ObjectModifiedTime
        // 
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTime.Location = new System.Drawing.Point(16, 232);
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTime.Name = "label_FileManagerObjectPropertiesForm_ObjectModifiedTime";
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTime.Size = new System.Drawing.Size(120, 16);
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTime.TabIndex = 9;
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTime.Text = "Modified:";
        // 
        // checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute
        // 
        this.checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute.Location = new System.Drawing.Point(8, 24);
        this.checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute.Name = "checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute";
        this.checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute.Size = new System.Drawing.Size(128, 16);
        this.checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute.TabIndex = 10;
        this.checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute.Text = "Read-only";
        // 
        // checkBox_FileManagerObjectPropertiesForm_HiddenAttribute
        // 
        this.checkBox_FileManagerObjectPropertiesForm_HiddenAttribute.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_FileManagerObjectPropertiesForm_HiddenAttribute.Location = new System.Drawing.Point(136, 24);
        this.checkBox_FileManagerObjectPropertiesForm_HiddenAttribute.Name = "checkBox_FileManagerObjectPropertiesForm_HiddenAttribute";
        this.checkBox_FileManagerObjectPropertiesForm_HiddenAttribute.Size = new System.Drawing.Size(80, 16);
        this.checkBox_FileManagerObjectPropertiesForm_HiddenAttribute.TabIndex = 11;
        this.checkBox_FileManagerObjectPropertiesForm_HiddenAttribute.Text = "Hidden";
        // 
        // pictureBox_FileManagerObjectPropertiesForm_HorLine3
        // 
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_FileManagerObjectPropertiesForm_HorLine3.Image")));
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine3.Location = new System.Drawing.Point(8, 192);
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine3.Name = "pictureBox_FileManagerObjectPropertiesForm_HorLine3";
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine3.Size = new System.Drawing.Size(312, 2);
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine3.TabIndex = 12;
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine3.TabStop = false;
        // 
        // pictureBox_FileManagerObjectPropertiesForm_HorLine2
        // 
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_FileManagerObjectPropertiesForm_HorLine2.Image")));
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine2.Location = new System.Drawing.Point(8, 128);
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine2.Name = "pictureBox_FileManagerObjectPropertiesForm_HorLine2";
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine2.Size = new System.Drawing.Size(312, 2);
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine2.TabIndex = 13;
        this.pictureBox_FileManagerObjectPropertiesForm_HorLine2.TabStop = false;
        // 
        // label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension
        // 
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension.Location = new System.Drawing.Point(16, 104);
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension.Name = "label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension";
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension.Size = new System.Drawing.Size(120, 16);
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension.TabIndex = 14;
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension.Text = "Contains or Extension:";
        // 
        // button_FileManagerObjectPropertiesForm_OK
        // 
        this.button_FileManagerObjectPropertiesForm_OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_FileManagerObjectPropertiesForm_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_FileManagerObjectPropertiesForm_OK.Location = new System.Drawing.Point(80, 368);
        this.button_FileManagerObjectPropertiesForm_OK.Name = "button_FileManagerObjectPropertiesForm_OK";
        this.button_FileManagerObjectPropertiesForm_OK.Size = new System.Drawing.Size(80, 23);
        this.button_FileManagerObjectPropertiesForm_OK.TabIndex = 15;
        this.button_FileManagerObjectPropertiesForm_OK.Text = "OK";
        this.button_FileManagerObjectPropertiesForm_OK.Click += new System.EventHandler(this.button_FileManagerObjectPropertiesForm_OK_Click);
        // 
        // button_FileManagerObjectPropertiesForm_Cancel
        // 
        this.button_FileManagerObjectPropertiesForm_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_FileManagerObjectPropertiesForm_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_FileManagerObjectPropertiesForm_Cancel.Location = new System.Drawing.Point(160, 368);
        this.button_FileManagerObjectPropertiesForm_Cancel.Name = "button_FileManagerObjectPropertiesForm_Cancel";
        this.button_FileManagerObjectPropertiesForm_Cancel.Size = new System.Drawing.Size(80, 23);
        this.button_FileManagerObjectPropertiesForm_Cancel.TabIndex = 16;
        this.button_FileManagerObjectPropertiesForm_Cancel.Text = "Cancel";
        // 
        // groupBox_FileManagerObjectPropertiesForm_Attribues
        // 
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.Controls.Add(this.checkBox_FileManagerObjectPropertiesForm_Archive);
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.Controls.Add(this.checkBox_FileManagerObjectPropertiesForm_NotContentIndexed);
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.Controls.Add(this.checkBox_FileManagerObjectPropertiesForm_Offline);
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.Controls.Add(this.checkBox_FileManagerObjectPropertiesForm_System);
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.Controls.Add(this.checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute);
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.Controls.Add(this.checkBox_FileManagerObjectPropertiesForm_HiddenAttribute);
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.Location = new System.Drawing.Point(16, 280);
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.Name = "groupBox_FileManagerObjectPropertiesForm_Attribues";
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.Size = new System.Drawing.Size(304, 80);
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.TabIndex = 18;
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.TabStop = false;
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.Text = "Attribues";
        // 
        // checkBox_FileManagerObjectPropertiesForm_Archive
        // 
        this.checkBox_FileManagerObjectPropertiesForm_Archive.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_FileManagerObjectPropertiesForm_Archive.Location = new System.Drawing.Point(216, 48);
        this.checkBox_FileManagerObjectPropertiesForm_Archive.Name = "checkBox_FileManagerObjectPropertiesForm_Archive";
        this.checkBox_FileManagerObjectPropertiesForm_Archive.Size = new System.Drawing.Size(80, 16);
        this.checkBox_FileManagerObjectPropertiesForm_Archive.TabIndex = 15;
        this.checkBox_FileManagerObjectPropertiesForm_Archive.Text = "Archive";
        // 
        // checkBox_FileManagerObjectPropertiesForm_NotContentIndexed
        // 
        this.checkBox_FileManagerObjectPropertiesForm_NotContentIndexed.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_FileManagerObjectPropertiesForm_NotContentIndexed.Location = new System.Drawing.Point(8, 48);
        this.checkBox_FileManagerObjectPropertiesForm_NotContentIndexed.Name = "checkBox_FileManagerObjectPropertiesForm_NotContentIndexed";
        this.checkBox_FileManagerObjectPropertiesForm_NotContentIndexed.Size = new System.Drawing.Size(128, 16);
        this.checkBox_FileManagerObjectPropertiesForm_NotContentIndexed.TabIndex = 13;
        this.checkBox_FileManagerObjectPropertiesForm_NotContentIndexed.Text = "NotContentIndexed";
        // 
        // checkBox_FileManagerObjectPropertiesForm_Offline
        // 
        this.checkBox_FileManagerObjectPropertiesForm_Offline.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_FileManagerObjectPropertiesForm_Offline.Location = new System.Drawing.Point(136, 48);
        this.checkBox_FileManagerObjectPropertiesForm_Offline.Name = "checkBox_FileManagerObjectPropertiesForm_Offline";
        this.checkBox_FileManagerObjectPropertiesForm_Offline.Size = new System.Drawing.Size(80, 16);
        this.checkBox_FileManagerObjectPropertiesForm_Offline.TabIndex = 14;
        this.checkBox_FileManagerObjectPropertiesForm_Offline.Text = "Offline";
        // 
        // checkBox_FileManagerObjectPropertiesForm_System
        // 
        this.checkBox_FileManagerObjectPropertiesForm_System.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.checkBox_FileManagerObjectPropertiesForm_System.Location = new System.Drawing.Point(216, 24);
        this.checkBox_FileManagerObjectPropertiesForm_System.Name = "checkBox_FileManagerObjectPropertiesForm_System";
        this.checkBox_FileManagerObjectPropertiesForm_System.Size = new System.Drawing.Size(80, 16);
        this.checkBox_FileManagerObjectPropertiesForm_System.TabIndex = 12;
        this.checkBox_FileManagerObjectPropertiesForm_System.Text = "System";
        // 
        // imageList_FileManagerObjects
        // 
        this.imageList_FileManagerObjects.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_FileManagerObjects.ImageStream")));
        this.imageList_FileManagerObjects.TransparentColor = System.Drawing.Color.Transparent;
        this.imageList_FileManagerObjects.Images.SetKeyName(0, "");
        this.imageList_FileManagerObjects.Images.SetKeyName(1, "");
        // 
        // label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText
        // 
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText.Location = new System.Drawing.Point(144, 104);
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText.Name = "label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText";
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText.Size = new System.Drawing.Size(176, 16);
        this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText.TabIndex = 20;
        // 
        // label_FileManagerObjectPropertiesForm_SizeText
        // 
        this.label_FileManagerObjectPropertiesForm_SizeText.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_SizeText.Location = new System.Drawing.Point(144, 168);
        this.label_FileManagerObjectPropertiesForm_SizeText.Name = "label_FileManagerObjectPropertiesForm_SizeText";
        this.label_FileManagerObjectPropertiesForm_SizeText.Size = new System.Drawing.Size(176, 16);
        this.label_FileManagerObjectPropertiesForm_SizeText.TabIndex = 22;
        // 
        // label_FileManagerObjectPropertiesForm_ObjectCreatedTimeText
        // 
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTimeText.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTimeText.Location = new System.Drawing.Point(144, 208);
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTimeText.Name = "label_FileManagerObjectPropertiesForm_ObjectCreatedTimeText";
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTimeText.Size = new System.Drawing.Size(176, 16);
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTimeText.TabIndex = 23;
        // 
        // label_FileManagerObjectPropertiesForm_ObjectModifiedTimeText
        // 
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTimeText.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTimeText.Location = new System.Drawing.Point(144, 232);
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTimeText.Name = "label_FileManagerObjectPropertiesForm_ObjectModifiedTimeText";
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTimeText.Size = new System.Drawing.Size(176, 16);
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTimeText.TabIndex = 24;
        // 
        // label_FileManagerObjectPropertiesForm_ObjectAccessedTimeText
        // 
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTimeText.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTimeText.Location = new System.Drawing.Point(144, 256);
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTimeText.Name = "label_FileManagerObjectPropertiesForm_ObjectAccessedTimeText";
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTimeText.Size = new System.Drawing.Size(176, 16);
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTimeText.TabIndex = 25;
        // 
        // textBox_FileManagerObjectPropertiesForm_ObjectTypeText
        // 
        this.textBox_FileManagerObjectPropertiesForm_ObjectTypeText.Location = new System.Drawing.Point(136, 80);
        this.textBox_FileManagerObjectPropertiesForm_ObjectTypeText.Name = "textBox_FileManagerObjectPropertiesForm_ObjectTypeText";
        this.textBox_FileManagerObjectPropertiesForm_ObjectTypeText.Size = new System.Drawing.Size(184, 20);
        this.textBox_FileManagerObjectPropertiesForm_ObjectTypeText.TabIndex = 26;
        this.textBox_FileManagerObjectPropertiesForm_ObjectTypeText.Text = "textBox1";
        // 
        // label_FileManagerObjectPropertiesForm_ObjectTypeText
        // 
        this.label_FileManagerObjectPropertiesForm_ObjectTypeText.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_FileManagerObjectPropertiesForm_ObjectTypeText.Location = new System.Drawing.Point(144, 80);
        this.label_FileManagerObjectPropertiesForm_ObjectTypeText.Name = "label_FileManagerObjectPropertiesForm_ObjectTypeText";
        this.label_FileManagerObjectPropertiesForm_ObjectTypeText.Size = new System.Drawing.Size(176, 16);
        this.label_FileManagerObjectPropertiesForm_ObjectTypeText.TabIndex = 19;
        // 
        // textBox_FileManagerObjectPropertiesForm_LocationText
        // 
        this.textBox_FileManagerObjectPropertiesForm_LocationText.Location = new System.Drawing.Point(136, 136);
        this.textBox_FileManagerObjectPropertiesForm_LocationText.Name = "textBox_FileManagerObjectPropertiesForm_LocationText";
        this.textBox_FileManagerObjectPropertiesForm_LocationText.ReadOnly = true;
        this.textBox_FileManagerObjectPropertiesForm_LocationText.Size = new System.Drawing.Size(184, 20);
        this.textBox_FileManagerObjectPropertiesForm_LocationText.TabIndex = 26;
        // 
        // FileManagerObjectPropertiesForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(338, 400);
        this.Controls.Add(this.textBox_FileManagerObjectPropertiesForm_LocationText);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_ObjectAccessedTimeText);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_ObjectModifiedTimeText);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_ObjectCreatedTimeText);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_SizeText);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_ObjectTypeText);
        this.Controls.Add(this.groupBox_FileManagerObjectPropertiesForm_Attribues);
        this.Controls.Add(this.button_FileManagerObjectPropertiesForm_Cancel);
        this.Controls.Add(this.button_FileManagerObjectPropertiesForm_OK);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension);
        this.Controls.Add(this.pictureBox_FileManagerObjectPropertiesForm_HorLine2);
        this.Controls.Add(this.pictureBox_FileManagerObjectPropertiesForm_HorLine3);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_ObjectModifiedTime);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_ObjectCreatedTime);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_Size);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_Location);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_ObjectAccessedTime);
        this.Controls.Add(this.label_FileManagerObjectPropertiesForm_ObjectType);
        this.Controls.Add(this.pictureBox_FileManagerObjectPropertiesForm_HorLine1);
        this.Controls.Add(this.pictureBox_FileManagerObjectPropertiesForm_TypeIcon);
        this.Controls.Add(this.textBox_FileManagerObjectPropertiesForm_ObjectName);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(344, 432);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(344, 432);
        this.Name = "FileManagerObjectPropertiesForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Shown += new System.EventHandler(this.FileManagerObjectPropertiesForm_Shown);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FileManagerObjectPropertiesForm_TypeIcon)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FileManagerObjectPropertiesForm_HorLine1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FileManagerObjectPropertiesForm_HorLine3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FileManagerObjectPropertiesForm_HorLine2)).EndInit();
        this.groupBox_FileManagerObjectPropertiesForm_Attribues.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    #endregion

    public void ChangeControlsLanguage()
    {
        this.label_FileManagerObjectPropertiesForm_ObjectType.Text = ClientStringFactory.GetString(378, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTime.Text = ClientStringFactory.GetString(364, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FileManagerObjectPropertiesForm_Location.Text = ClientStringFactory.GetString(363, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FileManagerObjectPropertiesForm_Size.Text = ClientStringFactory.GetString(365, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTime.Text = ClientStringFactory.GetString(366, ClientSettingsEnvironment.CurrentLanguage);
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTime.Text = ClientStringFactory.GetString(367, ClientSettingsEnvironment.CurrentLanguage);

        this.button_FileManagerObjectPropertiesForm_Cancel.Text = ClientStringFactory.GetString(5, ClientSettingsEnvironment.CurrentLanguage);

        this.groupBox_FileManagerObjectPropertiesForm_Attribues.Text = ClientStringFactory.GetString(372, ClientSettingsEnvironment.CurrentLanguage);

        this.checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute.Text = ClientStringFactory.GetString(368, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_FileManagerObjectPropertiesForm_HiddenAttribute.Text = ClientStringFactory.GetString(369, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_FileManagerObjectPropertiesForm_System.Text = ClientStringFactory.GetString(373, ClientSettingsEnvironment.CurrentLanguage);
        this.checkBox_FileManagerObjectPropertiesForm_Archive.Text = ClientStringFactory.GetString(374, ClientSettingsEnvironment.CurrentLanguage);

        checkBox_FileManagerObjectPropertiesForm_NotContentIndexed.Text = ClientStringFactory.GetString(375, ClientSettingsEnvironment.CurrentLanguage);
        checkBox_FileManagerObjectPropertiesForm_Offline.Text = ClientStringFactory.GetString(376, ClientSettingsEnvironment.CurrentLanguage);
    }

    public FileManagerObjectPropertiesForm(int int_FileManagerObjectType, string string_ObjectName, string string_ObjectFullName, string string_ObjectSize,
 
    string string_ObjectContainsFoldersOrExtension, string string_ObjectContainsFiles, string string_FileAttributes, string string_CreatedTime, string string_ModifiedTime, string string_AccessedTime)
    {

        InitializeComponent();

        ChangeControlsLanguage();

        textBox_FileManagerObjectPropertiesForm_ObjectName.Text = string_ObjectName;

        this.Text = ClientStringFactory.GetString(377, ClientSettingsEnvironment.CurrentLanguage) + " " + string_ObjectName;

        this.label_FileManagerObjectPropertiesForm_SizeText.Text = string_AccessedTime;
        this.label_FileManagerObjectPropertiesForm_ObjectCreatedTimeText.Text = string_CreatedTime;
        this.label_FileManagerObjectPropertiesForm_ObjectModifiedTimeText.Text = string_ModifiedTime;
        this.label_FileManagerObjectPropertiesForm_ObjectAccessedTimeText.Text = string_AccessedTime;

        if (int_FileManagerObjectType == 0)
        {
            pictureBox_FileManagerObjectPropertiesForm_TypeIcon.Image = imageList_FileManagerObjects.Images[0];
            this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension.Text = ClientStringFactory.GetString(370, ClientSettingsEnvironment.CurrentLanguage);
            this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText.Text = string_ObjectContainsFoldersOrExtension + " " + ClientStringFactory.GetString(380, ClientSettingsEnvironment.CurrentLanguage) + ", " + string_ObjectContainsFiles + " " + ClientStringFactory.GetString(379, ClientSettingsEnvironment.CurrentLanguage);
            this.label_FileManagerObjectPropertiesForm_SizeText.Text = ObjCopy.obj_MainClientForm.SpreadToHundreds(string_ObjectSize) + " " + ClientStringFactory.GetString(345, ClientSettingsEnvironment.CurrentLanguage);
            this.label_FileManagerObjectPropertiesForm_ObjectTypeText.Text = ClientStringFactory.GetString(216, ClientSettingsEnvironment.CurrentLanguage);
            this.textBox_FileManagerObjectPropertiesForm_LocationText.Text = string_ObjectFullName.ToUpper().Remove(string_ObjectFullName.LastIndexOf("\\") + 1, string_ObjectFullName.Length - string_ObjectFullName.LastIndexOf("\\") - 1);
        }

        if (int_FileManagerObjectType == 1)
        {
            pictureBox_FileManagerObjectPropertiesForm_TypeIcon.Image = imageList_FileManagerObjects.Images[1];
            this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtension.Text = ClientStringFactory.GetString(371, ClientSettingsEnvironment.CurrentLanguage);
            this.label_FileManagerObjectPropertiesForm_ObjectContainsOrExtensionText.Text = string_ObjectContainsFoldersOrExtension;
            this.label_FileManagerObjectPropertiesForm_SizeText.Text = ObjCopy.obj_MainClientForm.SpreadToHundreds(string_ObjectSize) + " " + ClientStringFactory.GetString(345, ClientSettingsEnvironment.CurrentLanguage);
            this.label_FileManagerObjectPropertiesForm_ObjectTypeText.Text = ClientStringFactory.GetString(200, ClientSettingsEnvironment.CurrentLanguage);
            this.textBox_FileManagerObjectPropertiesForm_LocationText.Text = string_ObjectFullName.ToUpper();
        }

        if (string_FileAttributes.IndexOf("Hidden") != -1) checkBox_FileManagerObjectPropertiesForm_HiddenAttribute.Checked = true;
        if (string_FileAttributes.IndexOf("ReadOnly") != -1) checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute.Checked = true;
        if (string_FileAttributes.IndexOf("System") != -1) checkBox_FileManagerObjectPropertiesForm_System.Checked = true;
        if (string_FileAttributes.IndexOf("Archive") != -1) checkBox_FileManagerObjectPropertiesForm_Archive.Checked = true;
        if (string_FileAttributes.IndexOf("NotContentIndexed") != -1) checkBox_FileManagerObjectPropertiesForm_NotContentIndexed.Checked = true;
        if (string_FileAttributes.IndexOf("Offline") != -1) checkBox_FileManagerObjectPropertiesForm_Offline.Checked = true;

    }

    private void button_FileManagerObjectPropertiesForm_OK_Click(object sender, System.EventArgs e)
    {
        string string_SelectedAttributes = String.Empty;

        if (checkBox_FileManagerObjectPropertiesForm_HiddenAttribute.Checked) string_SelectedAttributes += " Hidden";
        if (checkBox_FileManagerObjectPropertiesForm_ReadOnlyAttribute.Checked) string_SelectedAttributes += " ReadOnly";
        if (checkBox_FileManagerObjectPropertiesForm_System.Checked) string_SelectedAttributes += " System";
        if (checkBox_FileManagerObjectPropertiesForm_Archive.Checked) string_SelectedAttributes += " Archive";
        if (checkBox_FileManagerObjectPropertiesForm_NotContentIndexed.Checked) string_SelectedAttributes += " NotContentIndexed";
        if (checkBox_FileManagerObjectPropertiesForm_Offline.Checked) string_SelectedAttributes += " Offline";

        RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

        obj_RemoteCallAction.LastSelectedNameOfFolderOrFileWithPath =
        this.textBox_FileManagerObjectPropertiesForm_LocationText.Text + "\\" + this.textBox_FileManagerObjectPropertiesForm_ObjectName.Text;

        obj_RemoteCallAction.SetFileManagerObjectAttributes(string_SelectedAttributes);
    }

    private void FileManagerObjectPropertiesForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }

}

