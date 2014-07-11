/************************************************************
 * Authors: Binaya Raj Shrestha
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.10.2014
 * Description: KeyGenerator. Generates key derived from user’s password. Also generates client-KDC session key and client server session key.
 *************************************************************/

using KerberosCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KerberosCommon.Cryptography
{
    public class KeyGenerator
    {
        // Generate user's secret key
        public static string GenerateUsersKey(string password)
        {            
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hashPwd = new MD5CryptoServiceProvider().ComputeHash(Utility.GetBytes(password));            
            string passwordKey = Utility.GetString(hashPwd);
            return passwordKey.Length > 12 ? passwordKey.Remove(12) : passwordKey;
        }

        // Generate Session key
        public static string GenerateSessionKey()
        {
            string sessionKeyString = ":";
            while (sessionKeyString.Contains(":"))
            {
                TripleDES tDES = TripleDES.Create();
                byte[] sessionKeyBytes = tDES.Key;
                sessionKeyString = Encoding.ASCII.GetString(sessionKeyBytes, 0, sessionKeyBytes.Length);
            } 
            return sessionKeyString;
        }
    }
}
