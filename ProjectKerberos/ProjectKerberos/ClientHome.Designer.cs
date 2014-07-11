namespace CS670ProjectKerberos
{
    partial class ClientHome
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
            this.listBoxService = new System.Windows.Forms.ListBox();
            this.buttonRefreshServiceList = new System.Windows.Forms.Button();
            this.groupBoxService = new System.Windows.Forms.GroupBox();
            this.buttonRequestService = new System.Windows.Forms.Button();
            this.menuStripClientHome = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxWeather = new System.Windows.Forms.GroupBox();
            this.buttonWeatherOfWeek = new System.Windows.Forms.Button();
            this.buttonWeatherToday = new System.Windows.Forms.Button();
            this.textBoxDisplayServiceOutput = new System.Windows.Forms.TextBox();
            this.groupBoxCurrency = new System.Windows.Forms.GroupBox();
            this.buttonUSD_EUR = new System.Windows.Forms.Button();
            this.buttonExitService = new System.Windows.Forms.Button();
            this.groupBoxService.SuspendLayout();
            this.menuStripClientHome.SuspendLayout();
            this.groupBoxWeather.SuspendLayout();
            this.groupBoxCurrency.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxService
            // 
            this.listBoxService.FormattingEnabled = true;
            this.listBoxService.Location = new System.Drawing.Point(16, 19);
            this.listBoxService.Name = "listBoxService";
            this.listBoxService.Size = new System.Drawing.Size(162, 95);
            this.listBoxService.TabIndex = 0;
            // 
            // buttonRefreshServiceList
            // 
            this.buttonRefreshServiceList.Location = new System.Drawing.Point(103, 120);
            this.buttonRefreshServiceList.Name = "buttonRefreshServiceList";
            this.buttonRefreshServiceList.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshServiceList.TabIndex = 1;
            this.buttonRefreshServiceList.Text = "Refresh";
            this.buttonRefreshServiceList.UseVisualStyleBackColor = true;
            this.buttonRefreshServiceList.Click += new System.EventHandler(this.buttonRefreshServiceList_Click);
            // 
            // groupBoxService
            // 
            this.groupBoxService.Controls.Add(this.buttonRequestService);
            this.groupBoxService.Controls.Add(this.listBoxService);
            this.groupBoxService.Controls.Add(this.buttonRefreshServiceList);
            this.groupBoxService.Location = new System.Drawing.Point(401, 42);
            this.groupBoxService.Name = "groupBoxService";
            this.groupBoxService.Size = new System.Drawing.Size(196, 151);
            this.groupBoxService.TabIndex = 2;
            this.groupBoxService.TabStop = false;
            this.groupBoxService.Text = "Service";
            // 
            // buttonRequestService
            // 
            this.buttonRequestService.Location = new System.Drawing.Point(16, 120);
            this.buttonRequestService.Name = "buttonRequestService";
            this.buttonRequestService.Size = new System.Drawing.Size(75, 23);
            this.buttonRequestService.TabIndex = 4;
            this.buttonRequestService.Text = "Request";
            this.buttonRequestService.UseVisualStyleBackColor = true;
            this.buttonRequestService.Click += new System.EventHandler(this.buttonRequestService_Click);
            // 
            // menuStripClientHome
            // 
            this.menuStripClientHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripClientHome.Location = new System.Drawing.Point(0, 0);
            this.menuStripClientHome.Name = "menuStripClientHome";
            this.menuStripClientHome.Size = new System.Drawing.Size(624, 24);
            this.menuStripClientHome.TabIndex = 3;
            this.menuStripClientHome.Text = "menuClientHome";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signOutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // groupBoxWeather
            // 
            this.groupBoxWeather.Controls.Add(this.buttonWeatherOfWeek);
            this.groupBoxWeather.Controls.Add(this.buttonWeatherToday);
            this.groupBoxWeather.Location = new System.Drawing.Point(12, 273);
            this.groupBoxWeather.Name = "groupBoxWeather";
            this.groupBoxWeather.Size = new System.Drawing.Size(168, 68);
            this.groupBoxWeather.TabIndex = 4;
            this.groupBoxWeather.TabStop = false;
            this.groupBoxWeather.Text = "Weather";
            this.groupBoxWeather.Visible = false;
            // 
            // buttonWeatherOfWeek
            // 
            this.buttonWeatherOfWeek.Location = new System.Drawing.Point(87, 19);
            this.buttonWeatherOfWeek.Name = "buttonWeatherOfWeek";
            this.buttonWeatherOfWeek.Size = new System.Drawing.Size(75, 40);
            this.buttonWeatherOfWeek.TabIndex = 2;
            this.buttonWeatherOfWeek.Text = "Weather Of Week";
            this.buttonWeatherOfWeek.UseVisualStyleBackColor = true;
            this.buttonWeatherOfWeek.Click += new System.EventHandler(this.buttonWeatherOfWeek_Click);
            // 
            // buttonWeatherToday
            // 
            this.buttonWeatherToday.Location = new System.Drawing.Point(6, 19);
            this.buttonWeatherToday.Name = "buttonWeatherToday";
            this.buttonWeatherToday.Size = new System.Drawing.Size(75, 40);
            this.buttonWeatherToday.TabIndex = 1;
            this.buttonWeatherToday.Text = "Weather Today";
            this.buttonWeatherToday.UseVisualStyleBackColor = true;
            this.buttonWeatherToday.Click += new System.EventHandler(this.buttonWeatherToday_Click);
            // 
            // textBoxDisplayServiceOutput
            // 
            this.textBoxDisplayServiceOutput.Location = new System.Drawing.Point(12, 28);
            this.textBoxDisplayServiceOutput.Multiline = true;
            this.textBoxDisplayServiceOutput.Name = "textBoxDisplayServiceOutput";
            this.textBoxDisplayServiceOutput.ReadOnly = true;
            this.textBoxDisplayServiceOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDisplayServiceOutput.Size = new System.Drawing.Size(358, 218);
            this.textBoxDisplayServiceOutput.TabIndex = 0;
            // 
            // groupBoxCurrency
            // 
            this.groupBoxCurrency.Controls.Add(this.buttonUSD_EUR);
            this.groupBoxCurrency.Location = new System.Drawing.Point(186, 273);
            this.groupBoxCurrency.Name = "groupBoxCurrency";
            this.groupBoxCurrency.Size = new System.Drawing.Size(184, 68);
            this.groupBoxCurrency.TabIndex = 5;
            this.groupBoxCurrency.TabStop = false;
            this.groupBoxCurrency.Text = "Currency Exchange Rate";
            this.groupBoxCurrency.Visible = false;
            // 
            // buttonUSD_EUR
            // 
            this.buttonUSD_EUR.Location = new System.Drawing.Point(6, 19);
            this.buttonUSD_EUR.Name = "buttonUSD_EUR";
            this.buttonUSD_EUR.Size = new System.Drawing.Size(75, 40);
            this.buttonUSD_EUR.TabIndex = 3;
            this.buttonUSD_EUR.Text = "USD - EUR";
            this.buttonUSD_EUR.UseVisualStyleBackColor = true;
            this.buttonUSD_EUR.Click += new System.EventHandler(this.buttonUSD_EUR_Click);
            // 
            // buttonExitService
            // 
            this.buttonExitService.Location = new System.Drawing.Point(401, 199);
            this.buttonExitService.Name = "buttonExitService";
            this.buttonExitService.Size = new System.Drawing.Size(196, 30);
            this.buttonExitService.TabIndex = 6;
            this.buttonExitService.Text = "ExitService";
            this.buttonExitService.UseVisualStyleBackColor = true;
            this.buttonExitService.Click += new System.EventHandler(this.buttonExitService_Click);
            // 
            // ClientHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.buttonExitService);
            this.Controls.Add(this.groupBoxCurrency);
            this.Controls.Add(this.groupBoxWeather);
            this.Controls.Add(this.groupBoxService);
            this.Controls.Add(this.textBoxDisplayServiceOutput);
            this.Controls.Add(this.menuStripClientHome);
            this.MainMenuStrip = this.menuStripClientHome;
            this.Name = "ClientHome";
            this.Text = "Client Home";
            this.groupBoxService.ResumeLayout(false);
            this.menuStripClientHome.ResumeLayout(false);
            this.menuStripClientHome.PerformLayout();
            this.groupBoxWeather.ResumeLayout(false);
            this.groupBoxCurrency.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxService;
        private System.Windows.Forms.Button buttonRefreshServiceList;
        private System.Windows.Forms.GroupBox groupBoxService;
        private System.Windows.Forms.MenuStrip menuStripClientHome;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.Button buttonRequestService;
        private System.Windows.Forms.GroupBox groupBoxWeather;
        private System.Windows.Forms.Button buttonWeatherOfWeek;
        private System.Windows.Forms.Button buttonWeatherToday;
        private System.Windows.Forms.TextBox textBoxDisplayServiceOutput;
        private System.Windows.Forms.GroupBox groupBoxCurrency;
        private System.Windows.Forms.Button buttonUSD_EUR;
        private System.Windows.Forms.Button buttonExitService;
    }
}