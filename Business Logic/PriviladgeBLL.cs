using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Business_Logic
{
    public class PriviladgeBLL
    {
        public int InsertProgram(Program prgObj)
        {
            int result = 0;
            try
            {
                using (DBContext dbcontext = new DBContext())
                {
                    dbcontext.Programs.AddOrUpdate(prgObj);
                    result = dbcontext.SaveChanges();
                }
                return result;
            }
            catch
            { throw; }
        }

        public int InsertPriviladge(ObservableCollection<Priviladge> priviladges)
        {
            int result = 0;
            try
            {
                foreach (Priviladge priv in priviladges)
                {
                    using (DBContext dbContext=new DBContext())
                    {
                        priv.Program = null;
                        dbContext.Priviladges.AddOrUpdate(priv);
                        result =+ dbContext.SaveChanges();
                    }
                    if (result == 0)
                        throw new Exception("Updating priviladges fail");
                }
                return result;
            }
            catch
            { throw;}
        }

        //public Priviladge GetPrivilage(string progrmCode, int roleId)
        //{
        //    try
        //    {
        //        using (DBContext dbContext = new DBContext())
        //        {
        //            Priviladge priv = dbContext.Priviladges.ToList().SingleOrDefault(x => x.ProgramCode == progrmCode);
        //        } 
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}
    }
}
