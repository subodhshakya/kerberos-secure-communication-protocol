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
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;

namespace KerberosCommon.Util
{
    public class Utility
    {
        public static byte[] GetBytes(string str)
        {
            return System.Text.Encoding.UTF8.GetBytes(str);         
        }

        public static string GetString(byte[] bytes)
        {
            string result = System.Text.Encoding.UTF8.GetString(bytes);
            return result;
        }

        /// <summary>
        /// Store service key generated to a file
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="serviceKey"></param>
        public static void StoreServiceKeyCSV(string serviceName,string serviceKey)
        {
            var csv = new StringBuilder();
           
            var newLine = string.Format("{0}:{1}{2}", serviceName, serviceKey, Environment.NewLine);
            csv.Append(newLine);
            string keystorePath = ConfigurationManager.AppSettings["servicekeystorepath"];
            File.AppendAllText(keystorePath, csv.ToString());
        }

        /// <summary>
        /// Get a service key using name of service
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string,string> GetServiceKeyDictionary()
        {
            string keystorePath = ConfigurationManager.AppSettings["servicekeystorepath"];
            var reader = new StreamReader(File.OpenRead(keystorePath));
            Dictionary<string, string> keyDictionary = new Dictionary<string, string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(':');

                keyDictionary.Add(values[0],values[1]);                
            }
            return keyDictionary;
        }

        /// <summary>
        /// Stores client server session key to CSV file
        /// </summary>
        /// <param name="username"></param>
        /// <param name="clientServerSessionKey"></param>
        public static void StoreClientServerSessionKeyCSV(string username, string clientServerSessionKey)
        {
            var csv = new StringBuilder();

            var newLine = string.Format("{0}:{1}{2}", username, clientServerSessionKey, Environment.NewLine);
            csv.Append(newLine);
            string clientserversessionkeystorePath = ConfigurationManager.AppSettings["clientserversessionkeystorepath"];
            File.AppendAllText(clientserversessionkeystorePath, csv.ToString());
        }

        /// <summary>
        /// Get client server session key and load into dictionary.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetClientServerSessionKeyDictionary()
        {
            string clientserversessionkeystorePath = ConfigurationManager.AppSettings["clientserversessionkeystorepath"];
            var reader = new StreamReader(File.OpenRead(clientserversessionkeystorePath));
            Dictionary<string, string> keyDictionary = new Dictionary<string, string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(':');

                keyDictionary.Add(values[0], values[1]);
            }
            return keyDictionary;
        }
    }
}
