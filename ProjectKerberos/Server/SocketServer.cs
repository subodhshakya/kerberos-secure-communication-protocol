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
using KerberosCommon.Models;
using KerberosCommon.Serialization;
using KerberosCommon.Util;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{    
    class SocketServer
    {
        private static ServiceServerUIForm ParentForm;
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);        
        private static string clientServerSessionKey;

        public SocketServer()
        {            
        }

        public static void StartListening(ServiceServerUIForm parentForm)
        {
            ParentForm = parentForm;
            ParentForm.SetDisplayText("Started Listening...");
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // The DNS name of the computer            
            IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = System.Net.IPAddress.Parse(ConfigurationManager.AppSettings["ipaddress"]);            
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11001);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.                    
                    ParentForm.SetDisplayText("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                ParentForm.SetDisplayText(e.ToString());
            }
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadMessageCallback), state);
        }

        public static void ReadMessageCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // deserialize
                var clientMessageObject = Formatter.Deserialize(state.buffer);

                // Check for end-of-file tag. If it is not there, read 
                // more data.
                content = state.sb.ToString();
                content = content.Replace("\0", string.Empty);

                if (!string.IsNullOrEmpty(content))
                {
                    // All the data has been read from the 
                    // client. Display it on the console.                                        
                    if (clientMessageObject is ServiceListRequest)
                    {
                        ParentForm.SetDisplayText("Client requested list of services from service server.");
                        // Request for list of service from client.
                        ServiceListRequest serviceListReq = (ServiceListRequest)clientMessageObject;                       

                        // Get list of service and send it back to client.
                        ServiceRepository serviceRepo = new ServiceRepository(new ServiceContext());
                        List<Kerberos.Data.Service> serviceList = serviceRepo.GetAllService();
                        List<KerberosCommon.Models.Service> serviceModelList = new List<KerberosCommon.Models.Service>();
                        foreach (Kerberos.Data.Service service in serviceList)
                        {
                            serviceModelList.Add(new KerberosCommon.Models.Service() { ServiceKey = service.ServiceKey, ServiceName = service.ServiceName });
                        }
                        ServiceList servList = new ServiceList()
                        {
                            Services = serviceModelList
                        };
                        // 1. Serialize the servicelist object into bytes
                        byte[] serializedServiceListObject = Formatter.Serialize(servList);
                        // 2. Send the bytes back to client.
                        ParentForm.SetDisplayText("Service server replied with list of services.");
                        Send(handler, serializedServiceListObject);
                    }
                    else if (clientMessageObject is ClientTGSResponseAforServiceReq)
                    {
                        ClientTGSResponseAforServiceReq clientTGSResponseA = (ClientTGSResponseAforServiceReq)clientMessageObject;
                        ParentForm.SetDisplayText("Client Session key Encrypted with Service secret key received (client pass it after getting from TGS.)");
                        string servicekey = Utility.GetServiceKeyDictionary()[clientTGSResponseA.ServiceName];
                        byte[] encryptedTGSResponseA = clientTGSResponseA.EncryptedTGSResponseAforServiceReq;
                        byte[] decryptedTGSResponseA = TripleDESEncryption.Decrypt(encryptedTGSResponseA, servicekey);
                        object TGSResponseAObj = Formatter.Deserialize(decryptedTGSResponseA);
                        TGSResponseAforServiceReq tGSResponseAforServiceReq = (TGSResponseAforServiceReq)TGSResponseAObj;
                        clientServerSessionKey = tGSResponseAforServiceReq.ClientServerSessionKey;
                        ParentForm.SetDisplayText("Shared Client Server Session Key: " + clientServerSessionKey);
                        Acknowledgement ack = new Acknowledgement()
                        {
                            Header = "START",
                            AcknowledgementMsg = "ACK",
                            Trailer = "END"
                        };
                        byte[] serializedACK = Formatter.Serialize(ack);
                        ParentForm.SetDisplayText("Acknowledgement Sent after getting client server session key.");
                        Send(handler, serializedACK);
                    }
                    else if (clientMessageObject is ClientNewAuthenticator)
                    {
                        if (!string.IsNullOrEmpty(clientServerSessionKey))
                        {
                            ParentForm.SetDisplayText("Client new autheticator received (to authenticate itself to service server).");
                            ClientNewAuthenticator clientNewAuthenticator = (ClientNewAuthenticator)clientMessageObject;                            
                            byte[] decryptedClientNewAuthenticator = TripleDESEncryption.Decrypt(clientNewAuthenticator.EncryptedSerializedNewAuthenticator, clientServerSessionKey);
                            object clientNewAuthenticatorObj = Formatter.Deserialize(decryptedClientNewAuthenticator);
                            NewAuthenticator newAuthenticator = (NewAuthenticator)clientNewAuthenticatorObj;
                            DateTime newTimeStamp = newAuthenticator.TimeStamp.AddMinutes(1);
                            ParentForm.SetDisplayText("Timestamp in client's new authenticator:" + newTimeStamp.ToString());
                            IncrementedTimeStamp incrementedTimeStamp = new IncrementedTimeStamp()
                            {
                                NewTimeStamp = newTimeStamp
                            };

                            ParentForm.SetDisplayText("Incremented timestamp sent from service server:" + incrementedTimeStamp.NewTimeStamp.ToString());
                            byte[] serializedNewTimeStamp = Formatter.Serialize(incrementedTimeStamp);
                            byte[] encryptedSerializedNewTimeStamp = TripleDESEncryption.Encrypt(serializedNewTimeStamp, clientServerSessionKey);
                            ClientNewAuthenticator clientNewAuthResponse = new ClientNewAuthenticator() 
                            { EncryptedSerializedNewAuthenticator = encryptedSerializedNewTimeStamp };
                            byte[] serializedClientNewAuthResponse = Formatter.Serialize(clientNewAuthResponse);
                            Send(handler, serializedClientNewAuthResponse);
                        }
                    }
                    else if (clientMessageObject is ChatMessage)
                    {                                                
                        ChatMessage chatMessage = (ChatMessage)clientMessageObject;
                                          
                        byte[] decryptedChatMessage = TripleDESEncryption.Decrypt(chatMessage.Message, clientServerSessionKey);
                        object chatMessageObj = Formatter.Deserialize(decryptedChatMessage);
                        Chat chat = (Chat)chatMessageObj;
                        
                        // response the service method request in the chat message
                        if (!chat.Message.ToUpper().Equals("BYE"))
                        {
                            if (chat.ServiceName.ToUpper().Equals("WEATHER"))
                            {
                                if (chat.Message.ToUpper().Equals("TODAYTEMPERATURE"))
                                {
                                    // call service to get today's temperature
                                    List<string> temperatureTodayList = new Weather().GetTemperatureToday();
                                    ReplyServiceMessage(chat.ServiceName.ToUpper(), temperatureTodayList, handler);
                                }
                                else if (chat.Message.ToUpper().Equals("WEEKTEMPERATURE"))
                                {
                                    // call service to get week's temperature
                                    List<string> temperatureWeeklyList = new Weather().GetTemperatureOfWeek();
                                    ReplyServiceMessage(chat.ServiceName.ToUpper(), temperatureWeeklyList, handler);
                                }
                            }
                            else if (chat.ServiceName.ToUpper().Equals("CURRENCY"))
                            {
                                if (chat.Message.ToUpper().Equals("USDEUREXCHANGE"))
                                {
                                    // call service to get today's temperature
                                    List<string> currencyExchangeList = new Currency().GetUSDEUR();
                                    ReplyServiceMessage(chat.ServiceName.ToUpper(), currencyExchangeList, handler);
                                }
                            }
                        }
                        else
                        {
                            List<string> byeMessage = new List<string>();
                            byeMessage.Add("Service end");
                            ReplyServiceMessage("END", byeMessage, handler);
                        }
                    }
                }
                else
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadMessageCallback), state);
                }
            }
        }

        private static void ReplyServiceMessage(string serviceName,List<string> messages,Socket handler)
        {
            ChatReply chatReply = new ChatReply()
            {
                ServiceName = serviceName,
                Message = messages
            };

            byte[] serializedChatReply = Formatter.Serialize(chatReply);
            byte[] encryptedSerializedChatReply = TripleDESEncryption.Encrypt(serializedChatReply, clientServerSessionKey);
            
            Send(handler, encryptedSerializedChatReply);
        }

        private static void Send(Socket handler, byte[] byteData)
        {
            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendMessageCallback), handler);
        }

        private static void SendMessageCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    // State object for reading client data asynchronously
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 2048;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }
}
