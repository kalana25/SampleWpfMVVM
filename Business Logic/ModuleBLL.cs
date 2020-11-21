using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Business_Logic
{
    public class ModuleBLL
    {
        public int InsertModule(Module modulObj)
        {
            try
            {
                int result = 0;
                using (DBContext dbcon = new DBContext())
                {
                    dbcon.Modules.Add(modulObj);
                    result = dbcon.SaveChanges();
                }
                return result;
            }
            catch
            { throw;}
        }

        public IEnumerable<Module> RetrieveAllModules()
        {
            IEnumerable<Module> modules = null;
            try
            {
                using (DBContext dbcon = new DBContext())
                {
                    modules = dbcon.Modules.ToList();
                }
            }
            catch { throw; }
            return modules;
        } 

    }
}
