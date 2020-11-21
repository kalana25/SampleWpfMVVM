using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Business_Logic
{
    public class UserBll
    {
        public int InsertUser(User userObj)
        {
            int result = 0;
            try
            {
                using (DBContext dbContext=new DBContext())
                {
                    dbContext.Users.AddOrUpdate(userObj);
                    result=dbContext.SaveChanges();
                }
                return result;
            }
            catch
            {throw;}
        }
    }
}
