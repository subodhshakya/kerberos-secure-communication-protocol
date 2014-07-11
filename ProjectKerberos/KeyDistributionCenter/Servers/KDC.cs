/************************************************************
 * Authors: Subodh Shakya
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.12.2014
 * Description: KDC.cs. Authentication server and ticket granting server implemented in this class. 
 * Both server runs in asynchronous mode and processes all the request it get from the client. 
 * It too connects with User Credential database and key store to store user’s credentials and keys (client/KDC session key, 
 * service secret key and client server session key).
 *************************************************************/
using Kerberos.Data;
using Kerberos.Data.KDCRepositoryPattern;
using KerberosCommon.Cryptography;
using KerberosCommon.Models;
using KerberosCommon.Serialization;
using KerberosCommon.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyDistributionCenter.Servers
{
    public class KDC
    {
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private static string sessionKeyKDC;
        private static string username;
        private static string passwordKey;
        private static string clientServerSessionKey;        
        private static KDCForm ParentForm;

        public KDC()
        {               
        }

        public static void StartListening(KDCForm parentForm)
        {
            ParentForm = parentForm;
                    
            ParentForm.SetDisplayText("Started Listening...");
            
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // The DNS name of the computer            
            IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());

            // get IP address from configuration file
            IPAddress ipAddress = System.Net.IPAddress.Parse(ConfigurationManager.AppSettings["ipaddress"]);            
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

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
                Console.WriteLine(e.ToString());
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


                byte[] receiveBytesRec = new byte[bytesRead];
                Array.Copy(state.buffer, 0, receiveBytesRec, 0, bytesRead);

                // deserialize
                var clientMessageObject = Formatter.Deserialize(receiveBytesRec);

                // Check for end-of-file tag. If it is not there, read 
                // more data.
                content = state.sb.ToString();
                content = content.Replace("\0", string.Empty);                
                if (!string.IsNullOrEmpty(content))
                {
                    if ((clientMessageObject is SignUpCredential)
                        || (clientMessageObject is SignInCredentials))
                    {
                        AuthenticationService(handler, clientMessageObject);
                    }
                    else if ((clientMessageObject is Acknowledgement)
                        || (clientMessageObject is ClientSessionKeyEncryptedServReqMessage))
                    {
                        TicketGrantingService(handler, clientMessageObject);
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

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void AuthenticationService(Socket handler, Object clientMessageObject)
        {
            if (clientMessageObject is SignUpCredential)
            {
                SignUpCredential signUpCred = (SignUpCredential)clientMessageObject;
                string signUpPasswordKey = KeyGenerator.GenerateUsersKey(signUpCred.Password);
                User user = new User()
                {
                    Username = signUpCred.Username,
                    Password = signUpPasswordKey
                };
                KDCRepository kdcRepository = new KDCRepository(new KDCContext());
                kdcRepository.AddUser(user);
                kdcRepository.SaveAll();
                ParentForm.SetDisplayText("Username: " + user.Username);
                ParentForm.SetDisplayText("Password key: " + user.Password);
                ParentForm.SetDisplayText("Sign up successful.");

                Send(handler, Utility.GetBytes("signup successful"));
            }
            else if (clientMessageObject is SignInCredentials)
            {
                // Get password from AS database for username based on "Username" attribute of SignInCredentials object
                // based on password, 
                SignInCredentials signInCred = (SignInCredentials)clientMessageObject;
                username = signInCred.Username;
                KDCRepository kdcRepository = new KDCRepository(new KDCContext());
                User user = kdcRepository.GetUser(username);
                passwordKey = user.Password;

                ParentForm.SetDisplayText("Signing in user:" + username);
                ParentForm.SetDisplayText("Password key derived from password:"+passwordKey);
                // Send a session key back to client
                // 1. Generate Key
                sessionKeyKDC = KeyGenerator.GenerateSessionKey();
                ParentForm.SetDisplayText("Client/KDC session key:" + sessionKeyKDC);
                // 2. Create a session object
                Session session = new Session() { Header = "START", SessionKey = sessionKeyKDC, Trailer = "END" };
                // 3. Serialize the session object into bytes
                byte[] serializedSessionObject = Formatter.Serialize(session);
                // 4. Encrypt the serialized bytes using hash generated from user password.
                byte[] encryptedSerializedSessionObject = TripleDESEncryption.Encrypt(serializedSessionObject, user.Password);
                // 5. Send the bytes back to client.
                Send(handler, encryptedSerializedSessionObject);
            }
        }

        private static void TicketGrantingService(Socket handler, Object clientMessageObject)
        {
            if (clientMessageObject is Acknowledgement)
            {
                Acknowledgement ack = (Acknowledgement)clientMessageObject;
                ParentForm.SetDisplayText("Acknowledgement from client.");
                if (!string.IsNullOrEmpty(ack.AcknowledgementMsg))
                {
                    IPEndPoint remoteIpEndPoint = handler.RemoteEndPoint as IPEndPoint;
                    
                    TicketGrantingTicket tgt = new TicketGrantingTicket()
                    {
                        ClientIP = remoteIpEndPoint.Address.ToString(),
                        ExpirationTime = DateTime.Now.AddHours(12).ToString(),
                        SessionKey = sessionKeyKDC,
                        UserID = username
                    };
                    ParentForm.SetDisplayText("****************************");
                    ParentForm.SetDisplayText("Ticket Granting Ticket details:");
                    ParentForm.SetDisplayText("Remote client IP: " + tgt.ClientIP);
                    ParentForm.SetDisplayText("Expiration time: " + tgt.ExpirationTime);
                    ParentForm.SetDisplayText("User ID: " + tgt.UserID);
                    ParentForm.SetDisplayText("****************************");

                    // 1. Serialize the ticket granting ticket into bytes
                    byte[] serializedSessionObject = Formatter.Serialize(tgt);
                    // 2. Encrypt the serialized bytes using hash generated from user password.
                    byte[] encryptedSerializedSessionObject = TripleDESEncryption.Encrypt(serializedSessionObject, passwordKey);
                    // 3. Send the bytes back to client.
                    Send(handler, encryptedSerializedSessionObject);
                }
            }
            else if (clientMessageObject is ClientSessionKeyEncryptedServReqMessage)
            {
                ClientSessionKeyEncryptedServReqMessage clientSessionKeyEncryptMessage = (ClientSessionKeyEncryptedServReqMessage)clientMessageObject;
                byte[] encryptedServReq = clientSessionKeyEncryptMessage.Message;
                byte[] decryptedServReq = TripleDESEncryption.Decrypt(encryptedServReq, sessionKeyKDC);
                object servReqObj = Formatter.Deserialize(decryptedServReq);
                ServiceRequest servReq = (ServiceRequest)servReqObj;
                ParentForm.SetDisplayText("Requested Service: " + servReq.ServiceName);
                // Respond to service request from client
                // Consists of two responses
                // 1. TGSResponseA : ClientID + client IP + Timestamp + client server session key encrypted with service secret key
                IPEndPoint remoteIpEndPoint = handler.RemoteEndPoint as IPEndPoint;
                clientServerSessionKey = KeyGenerator.GenerateSessionKey();
                Utility.StoreClientServerSessionKeyCSV(username, clientServerSessionKey);
                TGSResponseAforServiceReq TGSresponseA = new TGSResponseAforServiceReq()
                {
                    ClientServerSessionKey = clientServerSessionKey,// call method to get client server session key,
                    TimeStamp = DateTime.Now.AddHours(12),
                    UserIP = remoteIpEndPoint.Address.ToString(),
                    Username = username
                };
                
                string servicekey = Utility.GetServiceKeyDictionary()[servReq.ServiceName];
                ParentForm.SetDisplayText("Secret Servicekey :" + servicekey);
                ParentForm.SetDisplayText("************************");
                ParentForm.SetDisplayText("Response encrypted with secret service key to client");
                ParentForm.SetDisplayText("************************");
                ParentForm.SetDisplayText("Encrypted Client server session key passed to client: " + TGSresponseA.ClientServerSessionKey);
                ParentForm.SetDisplayText("Timestamp: " + TGSresponseA.TimeStamp.ToString());
                ParentForm.SetDisplayText("User IP: " + TGSresponseA.UserIP);
                ParentForm.SetDisplayText("Username: " + TGSresponseA.Username);
                ParentForm.SetDisplayText("************************");
                // Serialize TGSresponseA
                byte[] serializedTGSresponseA = Formatter.Serialize(TGSresponseA);
                // Encrypt TGSresponseA with servicekey
                byte[] encryptedSerializedTGSresponseA = TripleDESEncryption.Encrypt(serializedTGSresponseA, servicekey);
                // Send the bytes back to client.
                //Send(handler, encryptedSerializedTGSresponseA);

                // 2. TGSResponseB : Client server session key encrypted with client TGS session key
                TGSResponseBforServiceReq TGSresponseB = new TGSResponseBforServiceReq()
                {
                    ClientServerSessionKey = clientServerSessionKey
                };

                ParentForm.SetDisplayText("Client KDC session key:" + sessionKeyKDC);
                ParentForm.SetDisplayText("************************");
                ParentForm.SetDisplayText("Response encrypted with Client KDC session key");
                ParentForm.SetDisplayText("************************");
                ParentForm.SetDisplayText("Client server session key: " + TGSresponseB.ClientServerSessionKey);
                ParentForm.SetDisplayText("************************");
                // Serialize TGSresponseB 
                byte[] serializedTGSresponseB = Formatter.Serialize(TGSresponseB);
                // Encrypt TGSresponseB with servicekey
                byte[] encryptedSerializedTGSresponseB = TripleDESEncryption.Encrypt(serializedTGSresponseB, sessionKeyKDC);
                                

                TGSResponseforServiceReq tgsResponseforServiceReq = new TGSResponseforServiceReq()
                {
                    EncryptedSerializedTGSresponseA = encryptedSerializedTGSresponseA,
                    EncryptedSerializedTGSresponseB = encryptedSerializedTGSresponseB
                };

                byte[] serializedTGSresponse = Formatter.Serialize(tgsResponseforServiceReq);
                // Send the bytes back to client.
                Send(handler, serializedTGSresponse);
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
