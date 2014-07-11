/************************************************************
 * Authors: Binaya Raj Shrestha
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.12.2014
 * Description: Model Class to pass through socket via serialization
 *************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerberosCommon.Models
{
    /// <summary>
    /// This message is encrypted with service secret key
    /// </summary>
    [Serializable]
    public class TGSResponseAforServiceReq
    {
        public string Username { get; set; }
        public string UserIP { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ClientServerSessionKey { get; set; }
    }
}
