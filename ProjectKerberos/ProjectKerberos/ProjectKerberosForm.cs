/************************************************************
 * Authors: Subodh Shakya
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.07.2014
 * Description: ProjectKerberosForm(Signin screen). Help user to sign into the system.
 *************************************************************/

using Client.Socket;
using CS670ProjectKerberos.Socket;
using KerberosCommon.Cryptography;
using KerberosCommon.Models;
using KerberosCommon.Serialization;
using KerberosCommon.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS670ProjectKerberos
{
    public partial class ProjectKerberosForm : Form
    {
        private string username;
        private string password;
        private string sessionKey;
        public ProjectKerberosForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sign into the system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string clientMessage = string.Empty;
            SocketCommunication socketComm = new SocketCommunication();
            string[] message = {"username:"+textBoxUsername.Text,"password:"+textBoxPassword.Text};
            
            username = textBoxUsername.Text;
            password = textBoxPassword.Text;
            SignInCredentials signInCred = new SignInCredentials()
            {
                Username = username,
                Password = password
            };
            byte[] receivedBytes = new SocketCommunication().SendMessage(11000, signInCred);
            string passwordKey = KeyGenerator.GenerateUsersKey(signInCred.Password);
            byte[] decryptedDataByte = socketComm.DecryptMessage(receivedBytes, passwordKey);
            // Deserialize the dataByte
            Object serverMessageObject = Formatter.Deserialize(decryptedDataByte);
            Session session = (Session)serverMessageObject;
            sessionKey = session.SessionKey;
            // Send ACK
            Acknowledgement ack = new Acknowledgement()
            {
                Header = "START",
                AcknowledgementMsg = "ACK",
                Trailer = "END"
            };

            // receivedBytes hold TGT
            receivedBytes = new SocketCommunication().SendMessage(11000, ack);
       
            ClientHome clientHome = new ClientHome(username,password,receivedBytes,sessionKey);
            clientHome.Show();
            this.Hide();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {                               
            SignUpScreen signUpScreen = new SignUpScreen();
            signUpScreen.Show();
            this.Hide();
        }
    }
}
