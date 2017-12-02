
partial class Form_WorkingActivity
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
        this.progressBar_WorkingActivity_Activity = new System.Windows.Forms.ProgressBar();
        this.button_WorkingActivity_Cancel = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // progressBar_WorkingActivity_Activity
        // 
        this.progressBar_WorkingActivity_Activity.Location = new System.Drawing.Point(93, 33);
        this.progressBar_WorkingActivity_Activity.Name = "progressBar_WorkingActivity_Activity";
        this.progressBar_WorkingActivity_Activity.Size = new System.Drawing.Size(187, 23);
        this.progressBar_WorkingActivity_Activity.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        this.progressBar_WorkingActivity_Activity.TabIndex = 0;
        this.progressBar_WorkingActivity_Activity.Value = 40;
        // 
        // button_WorkingActivity_Cancel
        // 
        this.button_WorkingActivity_Cancel.Location = new System.Drawing.Point(12, 33);
        this.button_WorkingActivity_Cancel.Name = "button_WorkingActivity_Cancel";
        this.button_WorkingActivity_Cancel.Size = new System.Drawing.Size(75, 23);
        this.button_WorkingActivity_Cancel.TabIndex = 1;
        this.button_WorkingActivity_Cancel.Text = "Cancel";
        this.button_WorkingActivity_Cancel.UseVisualStyleBackColor = true;
        this.button_WorkingActivity_Cancel.Click += new System.EventHandler(this.button_WorkingActivity_Cancel_Click);
        // 
        // Form_WorkingActivity
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(292, 83);
        this.ControlBox = false;
        this.Controls.Add(this.button_WorkingActivity_Cancel);
        this.Controls.Add(this.progressBar_WorkingActivity_Activity);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(298, 115);
        this.MinimumSize = new System.Drawing.Size(298, 115);
        this.Name = "Form_WorkingActivity";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Working Activity";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_WorkingActivity_FormClosing);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ProgressBar progressBar_WorkingActivity_Activity;
    private System.Windows.Forms.Button button_WorkingActivity_Cancel;
}
