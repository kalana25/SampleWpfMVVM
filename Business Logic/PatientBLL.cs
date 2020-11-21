using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Business_Logic
{
    public class PatientBLL
    {
        public IEnumerable<ConfigurationDetail> RetrieveAllGenders()
        {
            SystemConfigurationBLL systemConfigurationBll = new SystemConfigurationBLL();
            return systemConfigurationBll.RetrieveConfigurationDetails("GEND");
        }

        public IEnumerable<Patient> RetrieveAllPatints()
        {
            try
            {
                using (DBContext dbcon = new DBContext())
                {
                    IEnumerable<Patient> patients = null;
                    patients = dbcon.Patients.ToList();
                    return patients;
                }
            }
            catch
            {throw;}
        }

        public int InsertPatient(Patient patient)
        {
            try
            {
                int result = 0;
                using (DBContext dbContext = new DBContext())
                {
                    dbContext.Patients.Add(patient);
                    result = dbContext.SaveChanges();
                }
                return result;
            }
            catch
            { throw; }
        }
    }
}
