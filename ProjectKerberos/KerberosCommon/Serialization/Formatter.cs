/************************************************************
 * Authors: Subodh Shakya
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.12.2014
 * Description: Formatter Class.Serializes and deserializes objects to sent it through socket. 
 *************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KerberosCommon.Serialization
{
    public class Formatter
    {
        public static byte[] Serialize(Object serializableObject)
        {
            MemoryStream fs = new MemoryStream();

            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(fs, serializableObject);

            byte[] buffer = fs.ToArray();
            return buffer;
        }

        public static Object Deserialize(byte[] dataBytes)
        {
            BinaryFormatter formattor = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(dataBytes);

            Object clientMessageObject = formattor.Deserialize(ms);
            return clientMessageObject;
        }
    }    
}
