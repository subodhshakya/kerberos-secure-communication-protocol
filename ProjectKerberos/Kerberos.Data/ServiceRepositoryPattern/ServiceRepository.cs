/************************************************************
 * Authors: Binaya Raj Shrestha
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.10.2014
 * Description: ServiceRepository. Repository consisting of methods to access database
 *************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerberos.Data.ServiceRepositoryPattern
{
    public class ServiceRepository: IServiceRepository
    {
        private ServiceContext _ctx;

        public ServiceRepository(ServiceContext ctx)
        {
            _ctx = ctx;
        }

        public bool RegisterService(Service service)
        {
            try
            {
                _ctx.Services.Add(service);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Service> GetAllService()
        {            
            List<Service> serviceList = _ctx.Services.ToList();
            return serviceList;
        }
    }
}
