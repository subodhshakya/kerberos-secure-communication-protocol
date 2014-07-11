namespace KeyDistributionCenter
{
    partial class KDCForm
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.backgroundWorkerKDC = new System.ComponentModel.BackgroundWorker();
            this.groupBoxEventLog = new System.Windows.Forms.GroupBox();
            this.textBoxEventLog = new System.Windows.Forms.TextBox();
            this.groupBoxEventLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(525, 396);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // backgroundWorkerKDC
            // 
            this.backgroundWorkerKDC.WorkerReportsProgress = true;
            this.backgroundWorkerKDC.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerKDC_DoWork);
            // 
            // groupBoxEventLog
            // 
            this.groupBoxEventLog.Controls.Add(this.textBoxEventLog);
            this.groupBoxEventLog.Location = new System.Drawing.Point(41, 12);
            this.groupBoxEventLog.Name = "groupBoxEventLog";
            this.groupBoxEventLog.Size = new System.Drawing.Size(400, 400);
            this.groupBoxEventLog.TabIndex = 1;
            this.groupBoxEventLog.TabStop = false;
            this.groupBoxEventLog.Text = "Event Log";
            // 
            // textBoxEventLog
            // 
            this.textBoxEventLog.Location = new System.Drawing.Point(13, 21);
            this.textBoxEventLog.Multiline = true;
            this.textBoxEventLog.Name = "textBoxEventLog";
            this.textBoxEventLog.ReadOnly = true;
            this.textBoxEventLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEventLog.Size = new System.Drawing.Size(372, 364);
            this.textBoxEventLog.TabIndex = 0;
            // 
            // KDCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.groupBoxEventLog);
            this.Controls.Add(this.buttonStart);
            this.Name = "KDCForm";
            this.Text = "Key Distribution Center";
            this.groupBoxEventLog.ResumeLayout(false);
            this.groupBoxEventLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.ComponentModel.BackgroundWorker backgroundWorkerKDC;
        private System.Windows.Forms.GroupBox groupBoxEventLog;
        private System.Windows.Forms.TextBox textBoxEventLog;
    }
}

