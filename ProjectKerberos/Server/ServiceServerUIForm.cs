/************************************************************
 * Authors: Subodh Shakya
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.14.2014
 * Description: ServiceServerUIForm.cs. Interface to start service providing server and see event log
 *************************************************************/

using Kerberos.Data;
using Kerberos.Data.ServiceRepositoryPattern;
using KerberosCommon.Cryptography;
using KerberosCommon.Util;
using Server.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServiceServerUIForm : Form
    {
        delegate void SetTextCallback(string text);

        public ServiceServerUIForm()
        {
            InitializeComponent();
        }

        private void backgroundWorkerServiceServer_DoWork(object sender, DoWorkEventArgs e)
        {
            SocketServer.StartListening(this);
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            backgroundWorkerServiceServer.RunWorkerAsync();
            DisplayMessage("Service server started...");
        }

        private void buttonRegisterService_Click(object sender, EventArgs e)
        {
            ServiceRepository serviceRepo = new ServiceRepository(new ServiceContext());
            string serviceName = textBoxServiceName.Text;
            Service service = new Service()
            {
                ServiceName = serviceName,
                ServiceKey = KeyGenerator.GenerateSessionKey()
            };            
            serviceRepo.RegisterService(service);
            Utility.StoreServiceKeyCSV(service.ServiceName, service.ServiceKey);
        }

        private void buttonRefreshService_Click(object sender, EventArgs e)
        {
            ServiceRepository serviceRepo = new ServiceRepository(new ServiceContext());
            List<Service> serviceList = serviceRepo.GetAllService();
            List<KerberosCommon.Models.Service> serviceModelList = new List<KerberosCommon.Models.Service>();
            foreach (Service service in serviceList)
            {
                serviceModelList.Add(new KerberosCommon.Models.Service() { ServiceKey = service.ServiceKey, ServiceName = service.ServiceName });
            }
            listBoxServices.DataSource = serviceModelList;
        }

        public void DisplayMessage(string message)
        {
            message = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() +"  "+ message;
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
