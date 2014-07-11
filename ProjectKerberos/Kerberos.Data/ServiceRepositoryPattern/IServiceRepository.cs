/************************************************************
 * Authors: Binaya Raj Shrestha
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.09.2014
 * Description: IServiceRepository. Repository consisting of methods to access database
 *************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerberos.Data.ServiceRepositoryPattern
{
    interface IServiceRepository
    {
        // register service
        bool RegisterService(Service service);
    }
}
