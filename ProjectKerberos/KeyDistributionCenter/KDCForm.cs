using KeyDistributionCenter.Servers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyDistributionCenter
{
    public partial class KDCForm : Form
    {
        delegate void SetTextCallback(string text);

        public KDCForm()
        {
            InitializeComponent();
        }

        private void backgroundWorkerKDC_DoWork(object sender, DoWorkEventArgs e)
        {
            KDC.StartListening(this);
        }

        private void backgroundWorkerKDC_ProgressChanged(object sender, ProgressChangedEventArgs e)
        { 

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            backgroundWorkerKDC.RunWorkerAsync();
            DisplayMessage("Key distribution service started...");            
        }

        public void DisplayMessage(string message)
        {
            message = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  " + message;
            textBoxEventLog.AppendText(message);
            textBoxEventLog.AppendText(Environment.NewLine);
        }

        public void SetDisplayText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBoxEventLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(DisplayMessage);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                DisplayMessage(text);
            }
        }
    }
}
