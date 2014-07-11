/************************************************************
 * Authors: Binaya Raj Shrestha
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.09.2014
 * Description: IKDCRepository.  Interface to access database.
 *************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerberos.Data.KDCRepositoryPattern
{
    /// <summary>
    /// Interface to access database.
    /// </summary>
    interface IKDCRepository
    {
        // add new user to database
        bool AddUser(User user);

        // get user
        User GetUser(string username);
    }
}
