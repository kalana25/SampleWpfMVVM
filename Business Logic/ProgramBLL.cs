using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Business_Logic
{
    public class ProgramBll
    {
        public int InsertProgram(Program prgObj)
        {
            int result = 0;
            try
            {
                using (DBContext dbcontext=new DBContext())
                {
                    dbcontext.Programs.AddOrUpdate(prgObj);
                    result = dbcontext.SaveChanges();
                }
                return result;
            }
            catch
            {throw;}
        }

        public IEnumerable<Program> RetrieveAllPrograms()
        {
            IEnumerable<Program> programs = null;
            try
            {
                using (DBContext dbcon = new DBContext())
                {
                    programs = dbcon.Programs.ToList();
                }
            }
            catch{throw;}
            return programs;
        }
    }
}
