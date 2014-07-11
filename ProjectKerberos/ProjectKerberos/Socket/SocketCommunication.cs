/************************************************************
 * Authors: Subodh Shakya
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.06.2014
 * Description: SocketCommunication class for client to communicate with server. Provides connection functionality send message and decrypt the received message
 *************************************************************/

using Client.Socket;
using KerberosCommon.Cryptography;
using KerberosCommon.Models;
using KerberosCommon.Serialization;
using KerberosCommon.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CS670ProjectKerberos.Socket
{
    public class SocketCommunication
    {
        private SocketClient sClient;
        protected string delimiterChar;
        protected string internalDelimiterChar;

        public SocketCommunication()
        {
            sClient = new SocketClient();
            delimiterChar = ",";
            internalDelimiterChar = ":";
        }

        public SocketClient TheSocketClient()
        {
            return sClient;
        }

        public byte[] SendMessage(int portNo,Object serializableObject)
        {            
            bool connectStatus = sClient.Connect(portNo);
            // serialize
            byte[] buffer = Formatter.Serialize(serializableObject);
            sClient.Send(buffer);

            byte[] responseByte = sClient.Receive();
            string responseMessage = Utility.GetString(responseByte);            
            sClient.Release();
            return responseByte;
        }

        public byte[] DecryptMessage(byte[] encryptedDataByte,string key)
        {
            // Decrypt the dataByte using password key
            byte[] decryptedDataByte = TripleDESEncryption.Decrypt(encryptedDataByte, key);
            return decryptedDataByte;
        }
    }
}
