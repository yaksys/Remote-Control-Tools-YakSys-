using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

public class EventPropertiesForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.Label label_EventProperties_Date;
    private System.Windows.Forms.Label label_EventProperties_Time;
    private System.Windows.Forms.Label label_EventProperties_Type;
    private System.Windows.Forms.Label label_EventProperties_User;
    private System.Windows.Forms.Label label_EventProperties_Computer;
    private System.Windows.Forms.Label label_EventProperties_Source;
    private System.Windows.Forms.Label label_EventProperties_Category;
    private System.Windows.Forms.Label label_EventProperties_EventID;
    private System.Windows.Forms.Label label_EventProperties_Description;
    private System.Windows.Forms.Button button_EventProperties_NextEvent;
    private System.Windows.Forms.Button button_EventProperties_PrevEvent;
    private System.Windows.Forms.TextBox textBox_EventProperties_EventDescription;
    private System.Windows.Forms.Button button_EventProperties_CopyToClipboard;
    private System.Windows.Forms.TextBox textBox_EventProperties_Date;
    private System.Windows.Forms.TextBox textBox_EventProperties_Time;
    private System.Windows.Forms.TextBox textBox_EventProperties_Type;
    private System.Windows.Forms.TextBox textBox_EventProperties_User;
    private System.Windows.Forms.TextBox textBox_EventProperties_Computer;
    private System.Windows.Forms.TextBox textBox_EventProperties_Source;
    private System.Windows.Forms.TextBox textBox_EventProperties_Category;
    private System.Windows.Forms.TextBox textBox_EventProperties_EventID;
    private int int_EventNumberInCollection = 0;
    private ListView listView_SystemEvents_Events;
    private System.Windows.Forms.TextBox textBox_EventProperties_Information;
    private System.Windows.Forms.Button button_EventProperties_OK;

    private System.ComponentModel.Container components = null;

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventPropertiesForm));
        this.label_EventProperties_Date = new System.Windows.Forms.Label();
        this.label_EventProperties_Time = new System.Windows.Forms.Label();
        this.label_EventProperties_Type = new System.Windows.Forms.Label();
        this.label_EventProperties_User = new System.Windows.Forms.Label();
        this.label_EventProperties_Computer = new System.Windows.Forms.Label();
        this.label_EventProperties_Source = new System.Windows.Forms.Label();
        this.label_EventProperties_Category = new System.Windows.Forms.Label();
        this.label_EventProperties_EventID = new System.Windows.Forms.Label();
        this.label_EventProperties_Description = new System.Windows.Forms.Label();
        this.button_EventProperties_NextEvent = new System.Windows.Forms.Button();
        this.button_EventProperties_PrevEvent = new System.Windows.Forms.Button();
        this.textBox_EventProperties_EventDescription = new System.Windows.Forms.TextBox();
        this.button_EventProperties_CopyToClipboard = new System.Windows.Forms.Button();
        this.textBox_EventProperties_Date = new System.Windows.Forms.TextBox();
        this.textBox_EventProperties_Time = new System.Windows.Forms.TextBox();
        this.textBox_EventProperties_Type = new System.Windows.Forms.TextBox();
        this.textBox_EventProperties_User = new System.Windows.Forms.TextBox();
        this.textBox_EventProperties_Computer = new System.Windows.Forms.TextBox();
        this.textBox_EventProperties_Source = new System.Windows.Forms.TextBox();
        this.textBox_EventProperties_Category = new System.Windows.Forms.TextBox();
        this.textBox_EventProperties_EventID = new System.Windows.Forms.TextBox();
        this.textBox_EventProperties_Information = new System.Windows.Forms.TextBox();
        this.button_EventProperties_OK = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // label_EventProperties_Date
        // 
        this.label_EventProperties_Date.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_EventProperties_Date.Location = new System.Drawing.Point(16, 32);
        this.label_EventProperties_Date.Name = "label_EventProperties_Date";
        this.label_EventProperties_Date.Size = new System.Drawing.Size(80, 16);
        this.label_EventProperties_Date.TabIndex = 0;
        // 
        // label_EventProperties_Time
        // 
        this.label_EventProperties_Time.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_EventProperties_Time.Location = new System.Drawing.Point(16, 48);
        this.label_EventProperties_Time.Name = "label_EventProperties_Time";
        this.label_EventProperties_Time.Size = new System.Drawing.Size(80, 16);
        this.label_EventProperties_Time.TabIndex = 1;
        // 
        // label_EventProperties_Type
        // 
        this.label_EventProperties_Type.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_EventProperties_Type.Location = new System.Drawing.Point(16, 64);
        this.label_EventProperties_Type.Name = "label_EventProperties_Type";
        this.label_EventProperties_Type.Size = new System.Drawing.Size(80, 16);
        this.label_EventProperties_Type.TabIndex = 2;
        // 
        // label_EventProperties_User
        // 
        this.label_EventProperties_User.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_EventProperties_User.Location = new System.Drawing.Point(16, 80);
        this.label_EventProperties_User.Name = "label_EventProperties_User";
        this.label_EventProperties_User.Size = new System.Drawing.Size(80, 16);
        this.label_EventProperties_User.TabIndex = 3;
        // 
        // label_EventProperties_Computer
        // 
        this.label_EventProperties_Computer.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_EventProperties_Computer.Location = new System.Drawing.Point(16, 96);
        this.label_EventProperties_Computer.Name = "label_EventProperties_Computer";
        this.label_EventProperties_Computer.Size = new System.Drawing.Size(80, 16);
        this.label_EventProperties_Computer.TabIndex = 4;
        // 
        // label_EventProperties_Source
        // 
        this.label_EventProperties_Source.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_EventProperties_Source.Location = new System.Drawing.Point(216, 32);
        this.label_EventProperties_Source.Name = "label_EventProperties_Source";
        this.label_EventProperties_Source.Size = new System.Drawing.Size(56, 16);
        this.label_EventProperties_Source.TabIndex = 5;
        // 
        // label_EventProperties_Category
        // 
        this.label_EventProperties_Category.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_EventProperties_Category.Location = new System.Drawing.Point(216, 48);
        this.label_EventProperties_Category.Name = "label_EventProperties_Category";
        this.label_EventProperties_Category.Size = new System.Drawing.Size(56, 16);
        this.label_EventProperties_Category.TabIndex = 6;
        // 
        // label_EventProperties_EventID
        // 
        this.label_EventProperties_EventID.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_EventProperties_EventID.Location = new System.Drawing.Point(216, 64);
        this.label_EventProperties_EventID.Name = "label_EventProperties_EventID";
        this.label_EventProperties_EventID.Size = new System.Drawing.Size(64, 16);
        this.label_EventProperties_EventID.TabIndex = 7;
        // 
        // label_EventProperties_Description
        // 
        this.label_EventProperties_Description.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.label_EventProperties_Description.Location = new System.Drawing.Point(16, 120);
        this.label_EventProperties_Description.Name = "label_EventProperties_Description";
        this.label_EventProperties_Description.Size = new System.Drawing.Size(64, 16);
        this.label_EventProperties_Description.TabIndex = 9;
        // 
        // button_EventProperties_NextEvent
        // 
        this.button_EventProperties_NextEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_EventProperties_NextEvent.Location = new System.Drawing.Point(152, 336);
        this.button_EventProperties_NextEvent.Name = "button_EventProperties_NextEvent";
        this.button_EventProperties_NextEvent.Size = new System.Drawing.Size(88, 23);
        this.button_EventProperties_NextEvent.TabIndex = 10;
        this.button_EventProperties_NextEvent.Text = "Next Event";
        this.button_EventProperties_NextEvent.Click += new System.EventHandler(this.button_EventProperties_NextEvent_Click);
        // 
        // button_EventProperties_PrevEvent
        // 
        this.button_EventProperties_PrevEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_EventProperties_PrevEvent.Location = new System.Drawing.Point(64, 336);
        this.button_EventProperties_PrevEvent.Name = "button_EventProperties_PrevEvent";
        this.button_EventProperties_PrevEvent.Size = new System.Drawing.Size(88, 23);
        this.button_EventProperties_PrevEvent.TabIndex = 11;
        this.button_EventProperties_PrevEvent.Text = "Prev Event";
        this.button_EventProperties_PrevEvent.Click += new System.EventHandler(this.button_EventProperties_PrevEvent_Click);
        // 
        // textBox_EventProperties_EventDescription
        // 
        this.textBox_EventProperties_EventDescription.Location = new System.Drawing.Point(16, 136);
        this.textBox_EventProperties_EventDescription.Multiline = true;
        this.textBox_EventProperties_EventDescription.Name = "textBox_EventProperties_EventDescription";
        this.textBox_EventProperties_EventDescription.ReadOnly = true;
        this.textBox_EventProperties_EventDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.textBox_EventProperties_EventDescription.Size = new System.Drawing.Size(408, 184);
        this.textBox_EventProperties_EventDescription.TabIndex = 15;
        // 
        // button_EventProperties_CopyToClipboard
        // 
        this.button_EventProperties_CopyToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        this.button_EventProperties_CopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("button_EventProperties_CopyToClipboard.Image")));
        this.button_EventProperties_CopyToClipboard.Location = new System.Drawing.Point(16, 336);
        this.button_EventProperties_CopyToClipboard.Name = "button_EventProperties_CopyToClipboard";
        this.button_EventProperties_CopyToClipboard.Size = new System.Drawing.Size(40, 23);
        this.button_EventProperties_CopyToClipboard.TabIndex = 12;
        this.button_EventProperties_CopyToClipboard.Click += new System.EventHandler(this.button_EventProperties_CopyToClipboard_Click);
        // 
        // textBox_EventProperties_Date
        // 
        this.textBox_EventProperties_Date.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textBox_EventProperties_Date.Location = new System.Drawing.Point(104, 32);
        this.textBox_EventProperties_Date.Name = "textBox_EventProperties_Date";
        this.textBox_EventProperties_Date.ReadOnly = true;
        this.textBox_EventProperties_Date.Size = new System.Drawing.Size(104, 13);
        this.textBox_EventProperties_Date.TabIndex = 16;
        // 
        // textBox_EventProperties_Time
        // 
        this.textBox_EventProperties_Time.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textBox_EventProperties_Time.Location = new System.Drawing.Point(104, 48);
        this.textBox_EventProperties_Time.Name = "textBox_EventProperties_Time";
        this.textBox_EventProperties_Time.ReadOnly = true;
        this.textBox_EventProperties_Time.Size = new System.Drawing.Size(104, 13);
        this.textBox_EventProperties_Time.TabIndex = 17;
        // 
        // textBox_EventProperties_Type
        // 
        this.textBox_EventProperties_Type.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textBox_EventProperties_Type.Location = new System.Drawing.Point(104, 64);
        this.textBox_EventProperties_Type.Name = "textBox_EventProperties_Type";
        this.textBox_EventProperties_Type.ReadOnly = true;
        this.textBox_EventProperties_Type.Size = new System.Drawing.Size(104, 13);
        this.textBox_EventProperties_Type.TabIndex = 18;
        // 
        // textBox_EventProperties_User
        // 
        this.textBox_EventProperties_User.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textBox_EventProperties_User.Location = new System.Drawing.Point(104, 80);
        this.textBox_EventProperties_User.Name = "textBox_EventProperties_User";
        this.textBox_EventProperties_User.ReadOnly = true;
        this.textBox_EventProperties_User.Size = new System.Drawing.Size(104, 13);
        this.textBox_EventProperties_User.TabIndex = 19;
        // 
        // textBox_EventProperties_Computer
        // 
        this.textBox_EventProperties_Computer.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textBox_EventProperties_Computer.Location = new System.Drawing.Point(104, 96);
        this.textBox_EventProperties_Computer.Name = "textBox_EventProperties_Computer";
        this.textBox_EventProperties_Computer.ReadOnly = true;
        this.textBox_EventProperties_Computer.Size = new System.Drawing.Size(104, 13);
        this.textBox_EventProperties_Computer.TabIndex = 20;
        // 
        // textBox_EventProperties_Source
        // 
        this.textBox_EventProperties_Source.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textBox_EventProperties_Source.Location = new System.Drawing.Point(288, 32);
        this.textBox_EventProperties_Source.Name = "textBox_EventProperties_Source";
        this.textBox_EventProperties_Source.ReadOnly = true;
        this.textBox_EventProperties_Source.Size = new System.Drawing.Size(144, 13);
        this.textBox_EventProperties_Source.TabIndex = 21;
        // 
        // textBox_EventProperties_Category
        // 
        this.textBox_EventProperties_Category.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textBox_EventProperties_Category.Location = new System.Drawing.Point(288, 48);
        this.textBox_EventProperties_Category.Name = "textBox_EventProperties_Category";
        this.textBox_EventProperties_Category.ReadOnly = true;
        this.textBox_EventProperties_Category.Size = new System.Drawing.Size(144, 13);
        this.textBox_EventProperties_Category.TabIndex = 22;
        // 
        // textBox_EventProperties_EventID
        // 
        this.textBox_EventProperties_EventID.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textBox_EventProperties_EventID.Location = new System.Drawing.Point(288, 64);
        this.textBox_EventProperties_EventID.Name = "textBox_EventProperties_EventID";
        this.textBox_EventProperties_EventID.ReadOnly = true;
        this.textBox_EventProperties_EventID.Size = new System.Drawing.Size(144, 13);
        this.textBox_EventProperties_EventID.TabIndex = 23;
        // 
        // textBox_EventProperties_Information
        // 
        this.textBox_EventProperties_Information.Location = new System.Drawing.Point(16, 8);
        this.textBox_EventProperties_Information.Name = "textBox_EventProperties_Information";
        this.textBox_EventProperties_Information.ReadOnly = true;
        this.textBox_EventProperties_Information.Size = new System.Drawing.Size(184, 20);
        this.textBox_EventProperties_Information.TabIndex = 24;
        // 
        // button_EventProperties_OK
        // 
        this.button_EventProperties_OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.button_EventProperties_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.button_EventProperties_OK.Location = new System.Drawing.Point(344, 336);
        this.button_EventProperties_OK.Name = "button_EventProperties_OK";
        this.button_EventProperties_OK.Size = new System.Drawing.Size(75, 23);
        this.button_EventProperties_OK.TabIndex = 25;
        this.button_EventProperties_OK.Text = "OK";
        // 
        // EventPropertiesForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.CancelButton = this.button_EventProperties_OK;
        this.ClientSize = new System.Drawing.Size(440, 374);
        this.Controls.Add(this.button_EventProperties_OK);
        this.Controls.Add(this.textBox_EventProperties_Information);
        this.Controls.Add(this.textBox_EventProperties_EventID);
        this.Controls.Add(this.textBox_EventProperties_Category);
        this.Controls.Add(this.textBox_EventProperties_Source);
        this.Controls.Add(this.textBox_EventProperties_Computer);
        this.Controls.Add(this.textBox_EventProperties_User);
        this.Controls.Add(this.textBox_EventProperties_Type);
        this.Controls.Add(this.textBox_EventProperties_Time);
        this.Controls.Add(this.textBox_EventProperties_Date);
        this.Controls.Add(this.textBox_EventProperties_EventDescription);
        this.Controls.Add(this.button_EventProperties_CopyToClipboard);
        this.Controls.Add(this.button_EventProperties_PrevEvent);
        this.Controls.Add(this.button_EventProperties_NextEvent);
        this.Controls.Add(this.label_EventProperties_Description);
        this.Controls.Add(this.label_EventProperties_EventID);
        this.Controls.Add(this.label_EventProperties_Category);
        this.Controls.Add(this.label_EventProperties_Source);
        this.Controls.Add(this.label_EventProperties_Computer);
        this.Controls.Add(this.label_EventProperties_User);
        this.Controls.Add(this.label_EventProperties_Type);
        this.Controls.Add(this.label_EventProperties_Time);
        this.Controls.Add(this.label_EventProperties_Date);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(448, 408);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(448, 408);
        this.Name = "EventPropertiesForm";
        this.ShowInTaskbar = false;
        this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Event Properties";
        this.Shown += new System.EventHandler(this.EventPropertiesForm_Shown);
        this.ResumeLayout(false);
        this.PerformLayout();

    }
    #endregion

    public EventPropertiesForm(int int_EventNumber, ListView listView_Necessary)
    {
        InitializeComponent();
        int_EventNumberInCollection = int_EventNumber;
        listView_SystemEvents_Events = listView_Necessary;
        InsertEventInformation();
    }


    public void ChangeControlsLanguage()
    {
        this.label_EventProperties_Date.Text = ClientStringFactory.GetString(19, ClientSettingsEnvironment.CurrentLanguage) + ":";
        this.label_EventProperties_Time.Text = ClientStringFactory.GetString(20, ClientSettingsEnvironment.CurrentLanguage) + ":";
        this.label_EventProperties_Type.Text = ClientStringFactory.GetString(21, ClientSettingsEnvironment.CurrentLanguage) + ":";

        this.label_EventProperties_User.Text = ClientStringFactory.GetString(22, ClientSettingsEnvironment.CurrentLanguage) + ":";
        this.label_EventProperties_Computer.Text = ClientStringFactory.GetString(23, ClientSettingsEnvironment.CurrentLanguage) + ":";
        this.label_EventProperties_Source.Text = ClientStringFactory.GetString(24, ClientSettingsEnvironment.CurrentLanguage) + ":";
        this.label_EventProperties_Category.Text = ClientStringFactory.GetString(25, ClientSettingsEnvironment.CurrentLanguage) + ":";
        this.label_EventProperties_Description.Text = ClientStringFactory.GetString(27, ClientSettingsEnvironment.CurrentLanguage) + ":";
        this.button_EventProperties_NextEvent.Text = ClientStringFactory.GetString(28, ClientSettingsEnvironment.CurrentLanguage);
        this.button_EventProperties_PrevEvent.Text = ClientStringFactory.GetString(29, ClientSettingsEnvironment.CurrentLanguage);
        this.label_EventProperties_EventID.Text = ClientStringFactory.GetString(26, ClientSettingsEnvironment.CurrentLanguage) + ":";

    }

    private void InsertEventInformation()
    {
        if (LocalAction.list_EventsData.Count <= 1)
        {
            this.button_EventProperties_PrevEvent.Enabled = false;
            this.button_EventProperties_NextEvent.Enabled = false;
        }

        if (int_EventNumberInCollection == 1)
        {
            this.button_EventProperties_PrevEvent.Enabled = true;
        }
        if (int_EventNumberInCollection == LocalAction.list_EventsData.Count - 2)
        {
            this.button_EventProperties_NextEvent.Enabled = true;
        }

        this.textBox_EventProperties_Information.Text = "Event " + (int_EventNumberInCollection + 1) + " from " + LocalAction.list_EventsData.Count;

        EventsData eventsData_SelectedEvent = LocalAction.list_EventsData[int_EventNumberInCollection];

        this.textBox_EventProperties_EventDescription.Text = eventsData_SelectedEvent.EventMessage;

        this.textBox_EventProperties_Type.Text = listView_SystemEvents_Events.Items[int_EventNumberInCollection].SubItems[0].Text;
        this.textBox_EventProperties_Date.Text = listView_SystemEvents_Events.Items[int_EventNumberInCollection].SubItems[1].Text;
        this.textBox_EventProperties_Time.Text = listView_SystemEvents_Events.Items[int_EventNumberInCollection].SubItems[2].Text;
        this.textBox_EventProperties_Source.Text = listView_SystemEvents_Events.Items[int_EventNumberInCollection].SubItems[3].Text;
        this.textBox_EventProperties_Category.Text = listView_SystemEvents_Events.Items[int_EventNumberInCollection].SubItems[4].Text;
        this.textBox_EventProperties_EventID.Text = listView_SystemEvents_Events.Items[int_EventNumberInCollection].SubItems[5].Text;
        this.textBox_EventProperties_User.Text = listView_SystemEvents_Events.Items[int_EventNumberInCollection].SubItems[6].Text;
        this.textBox_EventProperties_Computer.Text = listView_SystemEvents_Events.Items[int_EventNumberInCollection].SubItems[7].Text;

        if (int_EventNumberInCollection + 1 == LocalAction.list_EventsData.Count)
        {
            this.button_EventProperties_NextEvent.Enabled = false;
            return;
        }

        if (int_EventNumberInCollection == 0)
        {
            this.button_EventProperties_PrevEvent.Enabled = false;
            return;
        }
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


    private void button_EventProperties_NextEvent_Click(object sender, System.EventArgs e)
    {
        if (int_EventNumberInCollection == LocalAction.list_EventsData.Count)
        {
            button_EventProperties_NextEvent.Enabled = false;
            return;
        }

        int_EventNumberInCollection++;

        InsertEventInformation();
    }

    private void button_EventProperties_PrevEvent_Click(object sender, System.EventArgs e)
    {
        if (int_EventNumberInCollection == 0)
            button_EventProperties_PrevEvent.Enabled = false;

        int_EventNumberInCollection--;
        InsertEventInformation();
    }

    private void button_EventProperties_CopyToClipboard_Click(object sender, System.EventArgs e)
    {
        Clipboard.SetDataObject(
            this.label_EventProperties_Type.Text + "\n" + textBox_EventProperties_Type.Text + "\n\n" +
            this.label_EventProperties_Source.Text + "\n" + textBox_EventProperties_Source.Text + "\n\n" +
            this.label_EventProperties_Category.Text + "\n" + textBox_EventProperties_Category.Text + "\n\n" +
            this.label_EventProperties_EventID.Text + "\n" + textBox_EventProperties_EventID.Text + "\n\n" +
            this.label_EventProperties_Date.Text + "\n" + textBox_EventProperties_Date.Text + "\n\n" +
            this.label_EventProperties_Time.Text + "\n" + textBox_EventProperties_Time.Text + "\n\n" +
            this.label_EventProperties_User.Text + "\n" + textBox_EventProperties_User.Text + "\n\n" +
            this.label_EventProperties_Computer.Text + "\n" + textBox_EventProperties_Computer.Text + "\n\n\n" +
            this.label_EventProperties_Description.Text + "\n\n" + textBox_EventProperties_EventDescription.Text
            , true);
    }

    private void EventPropertiesForm_Shown(object sender, EventArgs e)
    {
        this.Activate();
    }
}

