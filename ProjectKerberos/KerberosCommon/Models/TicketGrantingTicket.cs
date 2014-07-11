/************************************************************
 * Authors: Binaya Raj Shrestha
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.13.2014
 * Description: Model Class to pass through socket via serialization
 *************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerberosCommon.Models
{
    [Serializable]
    public class TicketGrantingTicket
    {
        public string UserID { get; set; }
        public string ClientIP { get; set; }
        public string ExpirationTime { get; set; }
        public string SessionKey { get; set; }
    }
}
