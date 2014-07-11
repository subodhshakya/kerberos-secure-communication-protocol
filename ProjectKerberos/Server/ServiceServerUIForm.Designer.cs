namespace Server
{
    partial class ServiceServerUIForm
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
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.backgroundWorkerServiceServer = new System.ComponentModel.BackgroundWorker();
            this.listBoxServices = new System.Windows.Forms.ListBox();
            this.groupBoxService = new System.Windows.Forms.GroupBox();
            this.groupBoxServiceList = new System.Windows.Forms.GroupBox();
            this.buttonRefreshService = new System.Windows.Forms.Button();
            this.groupBoxRegisterService = new System.Windows.Forms.GroupBox();
            this.textBoxServiceName = new System.Windows.Forms.TextBox();
            this.labelServiceName = new System.Windows.Forms.Label();
            this.buttonRegisterService = new System.Windows.Forms.Button();
            this.groupBoxEventLog = new System.Windows.Forms.GroupBox();
            this.textBoxEventLog = new System.Windows.Forms.TextBox();
            this.groupBoxService.SuspendLayout();
            this.groupBoxServiceList.SuspendLayout();
            this.groupBoxRegisterService.SuspendLayout();
            this.groupBoxEventLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(531, 403);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(75, 23);
            this.buttonStartServer.TabIndex = 0;
            this.buttonStartServer.Text = "Start Server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // backgroundWorkerServiceServer
            // 
            this.backgroundWorkerServiceServer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerServiceServer_DoWork);
            // 
            // listBoxServices
            // 
            this.listBoxServices.FormattingEnabled = true;
            this.listBoxServices.Location = new System.Drawing.Point(12, 21);
            this.listBoxServices.Name = "listBoxServices";
            this.listBoxServices.Size = new System.Drawing.Size(150, 134);
            this.listBoxServices.TabIndex = 1;
            // 
            // groupBoxService
            // 
            this.groupBoxService.Controls.Add(this.groupBoxServiceList);
            this.groupBoxService.Controls.Add(this.groupBoxRegisterService);
            this.groupBoxService.Location = new System.Drawing.Point(24, 24);
            this.groupBoxService.Name = "groupBoxService";
            this.groupBoxService.Size = new System.Drawing.Size(195, 329);
            this.groupBoxService.TabIndex = 2;
            this.groupBoxService.TabStop = false;
            this.groupBoxService.Text = "Services";
            // 
            // groupBoxServiceList
            // 
            this.groupBoxServiceList.Controls.Add(this.listBoxServices);
            this.groupBoxServiceList.Controls.Add(this.buttonRefreshService);
            this.groupBoxServiceList.Location = new System.Drawing.Point(7, 122);
            this.groupBoxServiceList.Name = "groupBoxServiceList";
            this.groupBoxServiceList.Size = new System.Drawing.Size(179, 193);
            this.groupBoxServiceList.TabIndex = 4;
            this.groupBoxServiceList.TabStop = false;
            this.groupBoxServiceList.Text = "Service List";
            // 
            // buttonRefreshService
            // 
            this.buttonRefreshService.Location = new System.Drawing.Point(16, 161);
            this.buttonRefreshService.Name = "buttonRefreshService";
            this.buttonRefreshService.Size = new System.Drawing.Size(142, 23);
            this.buttonRefreshService.TabIndex = 2;
            this.buttonRefreshService.Text = "Refresh";
            this.buttonRefreshService.UseVisualStyleBackColor = true;
            this.buttonRefreshService.Click += new System.EventHandler(this.buttonRefreshService_Click);
            // 
            // groupBoxRegisterService
            // 
            this.groupBoxRegisterService.Controls.Add(this.textBoxServiceName);
            this.groupBoxRegisterService.Controls.Add(this.labelServiceName);
            this.groupBoxRegisterService.Controls.Add(this.buttonRegisterService);
            this.groupBoxRegisterService.Location = new System.Drawing.Point(7, 20);
            this.groupBoxRegisterService.Name = "groupBoxRegisterService";
            this.groupBoxRegisterService.Size = new System.Drawing.Size(179, 96);
            this.groupBoxRegisterService.TabIndex = 3;
            this.groupBoxRegisterService.TabStop = false;
            this.groupBoxRegisterService.Text = "Register Service";
            // 
            // textBoxServiceName
            // 
            this.textBoxServiceName.Location = new System.Drawing.Point(13, 37);
            this.textBoxServiceName.Name = "textBoxServiceName";
            this.textBoxServiceName.Size = new System.Drawing.Size(150, 20);
            this.textBoxServiceName.TabIndex = 6;
            // 
            // labelServiceName
            // 
            this.labelServiceName.AutoSize = true;
            this.labelServiceName.Location = new System.Drawing.Point(10, 21);
            this.labelServiceName.Name = "labelServiceName";
            this.labelServiceName.Size = new System.Drawing.Size(35, 13);
            this.labelServiceName.TabIndex = 5;
            this.labelServiceName.Text = "Name";
            // 
            // buttonRegisterService
            // 
            this.buttonRegisterService.Location = new System.Drawing.Point(17, 63);
            this.buttonRegisterService.Name = "buttonRegisterService";
            this.buttonRegisterService.Size = new System.Drawing.Size(142, 23);
            this.buttonRegisterService.TabIndex = 4;
            this.buttonRegisterService.Text = "Register";
            this.buttonRegisterService.UseVisualStyleBackColor = true;
            this.buttonRegisterService.Click += new System.EventHandler(this.buttonRegisterService_Click);
            // 
            // groupBoxEventLog
            // 
            this.groupBoxEventLog.Controls.Add(this.textBoxEventLog);
            this.groupBoxEventLog.Location = new System.Drawing.Point(225, 24);
            this.groupBoxEventLog.Name = "groupBoxEventLog";
            this.groupBoxEventLog.Size = new System.Drawing.Size(381, 329);
            this.groupBoxEventLog.TabIndex = 3;
            this.groupBoxEventLog.TabStop = false;
            this.groupBoxEventLog.Text = "Event Log";
            // 
            // textBoxEventLog
            // 
            this.textBoxEventLog.Location = new System.Drawing.Point(13, 23);
            this.textBoxEventLog.Multiline = true;
            this.textBoxEventLog.Name = "textBoxEventLog";
            this.textBoxEventLog.ReadOnly = true;
            this.textBoxEventLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEventLog.Size = new System.Drawing.Size(354, 292);
            this.textBoxEventLog.TabIndex = 0;
            // 
            // ServiceServerUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.groupBoxEventLog);
            this.Controls.Add(this.groupBoxService);
            this.Controls.Add(this.buttonStartServer);
            this.Name = "ServiceServerUIForm";
            this.Text = "ServiceServerUIForm";
            this.groupBoxService.ResumeLayout(false);
            this.groupBoxServiceList.ResumeLayout(false);
            this.groupBoxRegisterService.ResumeLayout(false);
            this.groupBoxRegisterService.PerformLayout();
            this.groupBoxEventLog.ResumeLayout(false);
            this.groupBoxEventLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartServer;
        private System.ComponentModel.BackgroundWorker backgroundWorkerServiceServer;
        private System.Windows.Forms.ListBox listBoxServices;
        private System.Windows.Forms.GroupBox groupBoxService;
        private System.Windows.Forms.Button buttonRefreshService;
        private System.Windows.Forms.GroupBox groupBoxRegisterService;
        private System.Windows.Forms.Button buttonRegisterService;
        private System.Windows.Forms.GroupBox groupBoxServiceList;
        private System.Windows.Forms.GroupBox groupBoxEventLog;
        private System.Windows.Forms.Label labelServiceName;
        private System.Windows.Forms.TextBox textBoxServiceName;
        private System.Windows.Forms.TextBox textBoxEventLog;
    }
}