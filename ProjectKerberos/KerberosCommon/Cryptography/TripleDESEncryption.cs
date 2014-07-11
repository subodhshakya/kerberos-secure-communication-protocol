/************************************************************
 * Authors: Binaya Raj Shrestha
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.10.2014
 * Description: TripleDESEncryption. Provides cryptography service to encrypt and decrypt the messages. Uses Triple DES for encryption and decryption.
 *************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KerberosCommon.Cryptography
{
    public class TripleDESEncryption
    {
        public static byte[] Encrypt(byte[] dataBytes, string key)
        {
            byte[] keyDataArray = UTF8Encoding.UTF8.GetBytes(key);            

            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            
            //set the secret key for the tripleDES algorithm
            tripleDES.Key = keyDataArray;
            
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tripleDES.Mode = CipherMode.ECB;
            
            //padding mode(if any extra byte added)
            tripleDES.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryptoTransformer = tripleDES.CreateEncryptor();
            
            //transform the specified region of bytes array to resultArray
            byte[] encryptedDataBytes =
              cryptoTransformer.TransformFinalBlock(dataBytes, 0,
              dataBytes.Length);
            //Release resources held by TripleDes Encryptor
            tripleDES.Clear();

            return encryptedDataBytes;
        }

        public static byte[] Decrypt(byte[] encryptedDataBytes, string key)
        {
            byte[] keyDataArray;
            keyDataArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            
            //set the secret key for the tripleDES algorithm
            tripleDES.Key = keyDataArray;
            
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)
            tripleDES.Mode = CipherMode.ECB;

            //padding mode(if any extra byte added)
            tripleDES.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryptoTransformer = tripleDES.CreateDecryptor();
            byte[] decryptedDataByte = cryptoTransformer.TransformFinalBlock(
                                 encryptedDataBytes, 0, encryptedDataBytes.Length);
            
            //Release resources held by TripleDes Encryptor                
            tripleDES.Clear();
            return decryptedDataByte;
        }
    }
}
