using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Business_Logic
{
    public class SectionBLL
    {
        public int InsertSection(Section secObj)
        {
            int result = 0;
            try
            {
                using (DBContext dbContext = new DBContext())
                {
                    dbContext.Sections.Add(secObj);
                    result = dbContext.SaveChanges();
                }
                return result;
            }
            catch
            { throw; }
        }
    }
}
