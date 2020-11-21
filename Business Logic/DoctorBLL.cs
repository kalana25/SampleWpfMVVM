using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Business_Logic
{
    public class DoctorBLL
    {
        public IEnumerable<ConfigurationDetail> RetrieveAllGenders()
        {
            try
            {
                SystemConfigurationBLL systemConfigurationBll = new SystemConfigurationBLL();
                return systemConfigurationBll.RetrieveConfigurationDetails("GEND");
            }
            catch
            {throw;}
        }
        public IEnumerable<Doctor> RetrieveAllDoctors()
        {
            try
            {
                using (DBContext dbcon = new DBContext())
                {
                    IEnumerable<Doctor> doctors = null;
                    doctors = dbcon.Doctors.ToList();
                    return doctors;
                }
            }
            catch
            { throw; }
        } 
        public int InsertDoctor(Doctor doc)
        {
            try
            {
                int result = 0;
                using (DBContext dbContext = new DBContext())
                {
                    dbContext.Doctors.Add(doc);
                    result = dbContext.SaveChanges();
                }
                return result;
            }
            catch
            {throw; }
        }
    }
}
