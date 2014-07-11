/************************************************************
 * Authors: Subodh Shakya
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.07.2014
 * Description: Home screen. User can use various service provided by the service providing server by interacting with it from home screen.
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
    public partial class ClientHome : Form
    {
        private string username;
        private string password;
        private byte[] receivedByte;
        private string sessionKeyKDC;
        private NewAuthenticator newAuthenticator;
        private IncrementedTimeStamp incrementedTimeStamp;
        private string clientServerSessionKey;
        private bool clientServerSessionKeyShared = false;
        private string selectedServiceName;
        public ClientHome(String usrName, String pwd, byte[] recByte,string sesKey)
        {
            username = usrName;
            password = pwd;
            sessionKeyKDC = sesKey;
            receivedByte = recByte;
            InitializeComponent();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ProjectKerberosForm().Show();
        }

        /// <summary>
        /// Get available service list from service providing server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefreshServiceList_Click(object sender, EventArgs e)
        {
            ServiceListRequest serviceListRequest = new ServiceListRequest() { Username = username };
            byte[] receivedMessage = new SocketCommunication().SendMessage(11001, serviceListRequest);

            // Deserialize the dataByte
            Object serverMessageObject = Formatter.Deserialize(receivedMessage);
            ServiceList serviceList = (ServiceList)serverMessageObject;
            listBoxService.DataSource = serviceList.Services;
        }

        /// <summary>
        /// Request an access for particular service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRequestService_Click(object sender, EventArgs e)
        {
            ServiceRequest servReqSelected = new ServiceRequest()
            {
                Auth = new Authenticator() { Username = username, TimeStamp = DateTime.Now.AddHours(12) },
                EncryptedTGT = receivedByte,
                ServiceName = listBoxService.GetItemText(listBoxService.SelectedItem)                 
            };

            // Serialize the session object into bytes
            byte[] serializedServReqObject = Formatter.Serialize(servReqSelected);
            // Encrypt the serialized bytes using hash generated from user password.
            byte[] encryptedServReqObject = TripleDESEncryption.Encrypt(serializedServReqObject, sessionKeyKDC);

            ClientSessionKeyEncryptedServReqMessage clientSessionServReqMessage = new ClientSessionKeyEncryptedServReqMessage() 
            { 
                Username = username,
                Message = encryptedServReqObject 
            };       

            // Send the bytes to server.
            byte[] receivedMessage = new SocketCommunication().SendMessage(11000, clientSessionServReqMessage);

            Object serverMessageObject = Formatter.Deserialize(receivedMessage);
            TGSResponseforServiceReq tgsResponseForServiceReq = (TGSResponseforServiceReq)serverMessageObject;

            byte[] decryptedDataByte = new SocketCommunication().DecryptMessage(tgsResponseForServiceReq.EncryptedSerializedTGSresponseB, sessionKeyKDC);
            
            // Deserialize the dataByte
            serverMessageObject = Formatter.Deserialize(decryptedDataByte);
            TGSResponseBforServiceReq tgsResponseB = (TGSResponseBforServiceReq)serverMessageObject;
            clientServerSessionKey = tgsResponseB.ClientServerSessionKey;

            // send the bytes to service server
            // a. send EncryptedSerializedTGSresponseA as it is
            ClientTGSResponseAforServiceReq clientTGSResponseAforServiceReq = new ClientTGSResponseAforServiceReq() 
            { ServiceName = servReqSelected.ServiceName, EncryptedTGSResponseAforServiceReq = tgsResponseForServiceReq.EncryptedSerializedTGSresponseA };
            selectedServiceName = servReqSelected.ServiceName;
            byte[] receivedMessageServiceServer = new SocketCommunication().SendMessage(11001, clientTGSResponseAforServiceReq);
            
            // Deserialize the acknowledgment
            serverMessageObject = Formatter.Deserialize(receivedMessageServiceServer);
            Acknowledgement aCKtgsResponseB = (Acknowledgement)serverMessageObject;
                        
            // b. send New Authenticator object
            newAuthenticator = new NewAuthenticator()
            {
                Username = username,
                TimeStamp = DateTime.Now
            };

            // Serialize the session object into bytes
            byte[] serializedNewAuthenticator = Formatter.Serialize(newAuthenticator);
            // Encrypt the serialized bytes using hash generated from user password.
            byte[] encryptedSerializedNewAuthenticator = TripleDESEncryption.Encrypt(serializedNewAuthenticator, tgsResponseB.ClientServerSessionKey);

            ClientNewAuthenticator clientNewAuthenticator = new ClientNewAuthenticator()
            {
                EncryptedSerializedNewAuthenticator = encryptedSerializedNewAuthenticator
            };

            byte[] receivedMessageClientNewAuthentication = new SocketCommunication().SendMessage(11001, clientNewAuthenticator);
            serverMessageObject = Formatter.Deserialize(receivedMessageClientNewAuthentication);
            ClientNewAuthenticator clientNewAuthenticationServerResponse = (ClientNewAuthenticator)serverMessageObject;
            byte[] decryptedNewAuthenticationDataByte = new SocketCommunication().DecryptMessage(clientNewAuthenticationServerResponse.EncryptedSerializedNewAuthenticator, tgsResponseB.ClientServerSessionKey);
            serverMessageObject = Formatter.Deserialize(decryptedNewAuthenticationDataByte);
            incrementedTimeStamp = (IncrementedTimeStamp)serverMessageObject;
            if (Math.Abs(incrementedTimeStamp.NewTimeStamp.Minute - newAuthenticator.TimeStamp.Minute) == 1)
            {
                if (!string.IsNullOrEmpty(selectedServiceName))
                {
                    if (selectedServiceName.ToUpper().Equals("WEATHER"))
                    {
                        groupBoxWeather.Visible = true;
                    }
                    else if (selectedServiceName.ToUpper().Equals("CURRENCY"))
                    {
                        groupBoxCurrency.Visible = true;
                    }
                }
                clientServerSessionKeyShared = true;
            }
            else
            {
                MessageBox.Show("Opps Timeout");
            }
        }

        /// <summary>
        /// Request for a service (Today's temperature)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWeatherToday_Click(object sender, EventArgs e)
        {
            byte[] chatMessageReply = SendChatMessage("TODAYTEMPERATURE");
            ProcessChatResponseMessage(chatMessageReply);            
        }

        /// <summary>
        /// Processes chat response message from service providing server
        /// </summary>
        /// <param name="chatMsgReply"></param>
        private void ProcessChatResponseMessage(byte[] chatMsgReply)
        {
            ClearDisplay();
            byte[] decryptedNewAuthenticationDataByte = new SocketCommunication().DecryptMessage(chatMsgReply, clientServerSessionKey);
            Object serverReplyMessageObject = Formatter.Deserialize(decryptedNewAuthenticationDataByte);
            if (serverReplyMessageObject is ChatReply)
            {
                ChatReply chatReply = (ChatReply)serverReplyMessageObject;
                foreach (string msg in chatReply.Message)
                {
                    DisplayMessage(msg);
                }
            }
            
        }

        /// <summary>
        /// Request for a service (1 week's temperature)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWeatherOfWeek_Click(object sender, EventArgs e)
        {
            byte[] chatMessageReply = SendChatMessage("WEEKTEMPERATURE");
            ProcessChatResponseMessage(chatMessageReply);
        }

        /// <summary>
        /// Sends chat message to service providing server.
        /// </summary>
        /// <param name="serviceFunctionName"></param>
        /// <returns></returns>
        private byte[] SendChatMessage(string serviceFunctionName)
        {
            if (clientServerSessionKeyShared && !string.IsNullOrEmpty(clientServerSessionKey))
            {
                Chat chat = new Chat()
                {
                    ServiceName = selectedServiceName,
                    Message = serviceFunctionName
                };

                byte[] serializedChatMessage = Formatter.Serialize(chat);
                byte[] encryptedSerializedChatMessage = TripleDESEncryption.Encrypt(serializedChatMessage, clientServerSessionKey);
                ChatMessage chatMessage = new ChatMessage()
                {
                    Message = encryptedSerializedChatMessage
                };
                byte[] receivedChatMessage = new SocketCommunication().SendMessage(11001, chatMessage);
                return receivedChatMessage;
            }
            return null;
        }

        public void DisplayMessage(string message)
        {            
            textBoxDisplayServiceOutput.AppendText(message);
            textBoxDisplayServiceOutput.AppendText(Environment.NewLine);
        }

        public void ClearDisplay()
        {
            textBoxDisplayServiceOutput.Text = string.Empty;
        }

        /// <summary>
        /// Request a service (USD to EUR currency conversion)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUSD_EUR_Click(object sender, EventArgs e)
        {
            byte[] chatMessageReply = SendChatMessage("USDEUREXCHANGE");
            ProcessChatResponseMessage(chatMessageReply);
        }

        /// <summary>
        /// Send "BYE" message to end the use of service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExitService_Click(object sender, EventArgs e)
        {
            groupBoxCurrency.Visible = false;
            groupBoxWeather.Visible = false;
            byte[] chatMessageReply = SendChatMessage("BYE");
            ProcessChatResponseMessage(chatMessageReply);
        }
    }
}
