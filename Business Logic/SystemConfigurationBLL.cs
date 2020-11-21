using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Business_Logic
{
    public class SystemConfigurationBLL
    {
        public int InsertConfigurationDetail(ConfigurationDetail configDetail)
        {
            int result = 0;
            try
            {
                using (DBContext dbcon = new DBContext())
                {
                    dbcon.ConfigurationDetails.Add(configDetail);
                    result=dbcon.SaveChanges();
                }
                return result;
            }
            catch
            {   throw;  }
        }

        public IEnumerable<SystemConfiguration> RetrieveSystemConfiguration()
        {         
            try
            {
                IEnumerable<SystemConfiguration> systemConfigurations = null;
                using (DBContext dbcon = new DBContext())
                {
                    systemConfigurations = dbcon.SystemConfigurations.ToList();
                }
                return systemConfigurations;
            }
            catch
            { throw;}
        }

        public IEnumerable<ConfigurationDetail> RetrieveConfigurationDetails(string code)
        {
            try
            {
                IEnumerable<ConfigurationDetail> result = null;
                using (DBContext dbcon = new DBContext())
                {
                    result = dbcon.ConfigurationDetails.Where(x => x.Code == code).ToList();
                }
                return result;
            }
            catch
            {throw;}
        } 
    }
}
