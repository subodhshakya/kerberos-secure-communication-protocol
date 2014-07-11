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
    [Serializable]
    public class ServiceList
    {
        public List<Service> Services { get; set; }
    }
}
