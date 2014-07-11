/************************************************************
 * Authors: Subodh Shakya
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.08.2014
 * Description: SignUpScreen. Help user create a new account.
 *************************************************************/
using CS670ProjectKerberos.Socket;
using KerberosCommon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS670ProjectKerberos
{
    public partial class SignUpScreen : Form
    {
        public SignUpScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sign up button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxUsername.Text) && !string.IsNullOrEmpty(textBoxPassword.Text) && !string.IsNullOrEmpty(textBoxConfirmPassword.Text))
            {
                if (textBoxPassword.Text.Equals(textBoxConfirmPassword.Text))
                {                    
                    SocketCommunication socketComm = new SocketCommunication();                    
                    SignUpCredential signUpCredential = new SignUpCredential()
                    {
                        Username = textBoxUsername.Text,
                        Password = textBoxPassword.Text
                    };                    
                    new SocketCommunication().SendMessage(11000, signUpCredential);   
                }
                else
                {
                    MessageBox.Show("Password mismatch!");
                }
                new ProjectKerberosForm().Show();
                this.Hide();
            }
        }
    }
}
