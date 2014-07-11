/************************************************************
 * Authors: Subodh Shakya
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.06.2014
 * Description: Socket class for client to communicate with server. Provides connection functionality using System.Net.Sockets
 *************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Socket
{
    public class SocketClient
    {
        private System.Net.Sockets.Socket sender { get; set; }

        //Data Buffer for incoming data
        byte[] dataBuffer = new byte[1024];

        public SocketClient()
        {
            sender = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Connect(int portNo)
        {
            // Get ip of host.
            IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
            
            // pull ipAddress from configuration file
            IPAddress ipAddress = System.Net.IPAddress.Parse(ConfigurationManager.AppSettings["ipaddress"]);            
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, portNo);
            // Connect to remote end point.
            sender.Connect(remoteEndPoint);
            return true;
        }

        public bool Send(byte[] message)
        { 
            // Message Sending Implementation
            try
            {
                int sentBytes = sender.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        
        public byte[] Receive()        
        {
            // Receive message from remote
            try
            {
                int receiveBytes = sender.Receive(dataBuffer);
                byte[] receiveBytesRec = new byte[receiveBytes];
                Array.Copy(dataBuffer, 0, receiveBytesRec, 0, receiveBytes);
                            
                return receiveBytesRec;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Release()
        {
            try
            {
                // Releasing the socket here.
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
