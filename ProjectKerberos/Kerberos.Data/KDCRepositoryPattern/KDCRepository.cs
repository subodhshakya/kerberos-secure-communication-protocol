/************************************************************
 * Authors: Binaya Raj Shrestha
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.09.2014
 * Description: KDCRepository. Repository consisting of methods to access database
 *************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerberos.Data.KDCRepositoryPattern
{
    public class KDCRepository:IKDCRepository
    {
        private KDCContext _ctx;

        public KDCRepository(KDCContext ctx)
        {
            _ctx = ctx;
        }

        public bool AddUser(User user)
        {
            try
            {
                _ctx.Users.Add(user);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUser(string username)
        {
            return _ctx.Users.Where(b => b.Username == username).FirstOrDefault();                
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
