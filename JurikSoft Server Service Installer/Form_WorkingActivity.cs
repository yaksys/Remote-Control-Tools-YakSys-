using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


public partial class Form_WorkingActivity : Form
{
    public Form_WorkingActivity()
    {
        InitializeComponent();
    
        Form_Main.CallerSuccessfullyCompleteJobEvent += new Form_Main.InstallationEventHandler(Form_Main_CallerSuccessfullyCompleteJobEvent);

        ChangeControlsLanguage();
    }


    public void ChangeControlsLanguage()
    {
        this.Text = StringFactory.GetString(73, CommonEnvironment.CurrentLanguage);
                
        this.button_WorkingActivity_Cancel.Text = StringFactory.GetString(27, CommonEnvironment.CurrentLanguage);

    }

    void Form_Main_CallerSuccessfullyCompleteJobEvent(string string_Message)
    {
        if (this.IsHandleCreated == false)
        {
            return;
        }

        this.Invoke((MethodInvoker)delegate
        {
            this.progressBar_WorkingActivity_Activity.Value = this.progressBar_WorkingActivity_Activity.Maximum;

            this.progressBar_WorkingActivity_Activity.Style = ProgressBarStyle.Continuous;
        });

        this.CloseWindow();
    }

    private void button_WorkingActivity_Cancel_Click(object sender, EventArgs e)
    {
        if (WorkingActivityProcessAborted != null)
        {
            WorkingActivityProcessAborted(StringFactory.GetString(65, CommonEnvironment.CurrentLanguage));
        }

        this.CloseWindow();
    }

    private void CloseWindow()
    {
        this.Invoke((MethodInvoker)delegate
        {
            this.Close();
        });
    }

    public delegate void InstallationEventHandler(string string_Message);
    public static event InstallationEventHandler WorkingActivityProcessAborted;

    private void Form_WorkingActivity_FormClosing(object sender, FormClosingEventArgs e)
    {
        Form_Main.CallerSuccessfullyCompleteJobEvent -= new Form_Main.InstallationEventHandler(Form_Main_CallerSuccessfullyCompleteJobEvent);
    }

}
