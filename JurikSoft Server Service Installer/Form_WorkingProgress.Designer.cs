
    partial class Form_WorkingProgress
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
            this.button_WorkingProgress_Cancel = new System.Windows.Forms.Button();
            this.progressBar_WorkingProgress_Progree = new System.Windows.Forms.ProgressBar();
            this.listBox_WorkingProgress_Progress = new System.Windows.Forms.ListView();
            this.columnHeader_WorkingProgress_Operation = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_WorkingProgress_OperationResult = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // button_WorkingProgress_Cancel
            // 
            this.button_WorkingProgress_Cancel.Location = new System.Drawing.Point(12, 233);
            this.button_WorkingProgress_Cancel.Name = "button_WorkingProgress_Cancel";
            this.button_WorkingProgress_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_WorkingProgress_Cancel.TabIndex = 0;
            this.button_WorkingProgress_Cancel.Text = "Cancel";
            this.button_WorkingProgress_Cancel.UseVisualStyleBackColor = true;
            this.button_WorkingProgress_Cancel.Click += new System.EventHandler(this.button_WorkingProgress_Cancel_Click);
            // 
            // progressBar_WorkingProgress_Progree
            // 
            this.progressBar_WorkingProgress_Progree.Location = new System.Drawing.Point(94, 234);
            this.progressBar_WorkingProgress_Progree.Name = "progressBar_WorkingProgress_Progree";
            this.progressBar_WorkingProgress_Progree.Size = new System.Drawing.Size(378, 22);
            this.progressBar_WorkingProgress_Progree.TabIndex = 2;
            // 
            // listBox_WorkingProgress_Progress
            // 
            this.listBox_WorkingProgress_Progress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_WorkingProgress_Operation,
            this.columnHeader_WorkingProgress_OperationResult});
            this.listBox_WorkingProgress_Progress.FullRowSelect = true;
            this.listBox_WorkingProgress_Progress.GridLines = true;
            this.listBox_WorkingProgress_Progress.Location = new System.Drawing.Point(12, 12);
            this.listBox_WorkingProgress_Progress.Name = "listBox_WorkingProgress_Progress";
            this.listBox_WorkingProgress_Progress.Size = new System.Drawing.Size(460, 215);
            this.listBox_WorkingProgress_Progress.TabIndex = 5;
            this.listBox_WorkingProgress_Progress.UseCompatibleStateImageBehavior = false;
            this.listBox_WorkingProgress_Progress.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_WorkingProgress_Operation
            // 
            this.columnHeader_WorkingProgress_Operation.Text = "Operation";
            this.columnHeader_WorkingProgress_Operation.Width = 261;
            // 
            // columnHeader_WorkingProgress_OperationResult
            // 
            this.columnHeader_WorkingProgress_OperationResult.Text = "Results";
            this.columnHeader_WorkingProgress_OperationResult.Width = 175;
            // 
            // Form_WorkingProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 268);
            this.ControlBox = false;
            this.Controls.Add(this.listBox_WorkingProgress_Progress);
            this.Controls.Add(this.progressBar_WorkingProgress_Progree);
            this.Controls.Add(this.button_WorkingProgress_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(326, 300);
            this.Name = "Form_WorkingProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Working Progress";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_WorkingProgress_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_WorkingProgress_Cancel;
        private System.Windows.Forms.ProgressBar progressBar_WorkingProgress_Progree;
        private System.Windows.Forms.ListView listBox_WorkingProgress_Progress;
        private System.Windows.Forms.ColumnHeader columnHeader_WorkingProgress_Operation;
        private System.Windows.Forms.ColumnHeader columnHeader_WorkingProgress_OperationResult;
    }
