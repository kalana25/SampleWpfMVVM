using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataModel;

namespace Business_Logic
{
    public class RoleBLL
    {
        public int insertRoll(Role roleObj)
        {
            int result = 0;
            try
            {
                using ( DBContext dbcon=new DBContext())
                {
                    dbcon.Roles.AddOrUpdate(roleObj);
                    result=dbcon.SaveChanges();
                }
                return result;
            }
            catch
            {throw;}
        }

        public bool DeleteRoll(Role role)
        {
            try
            {
                using (DBContext dbcon = new DBContext())
                {
                    var obj = dbcon.Roles.Find(role.RoleId);
                    dbcon.Roles.Remove(obj);
                    return dbcon.SaveChanges() > 0;
                }
            }
            catch
            {
                throw;
            }
        }

        public ICollection<Role> RetrieveAllRoles()
        {
            ICollection<Role> roles = null;
            try
            {
                using (DBContext dbcon=new DBContext())
                {
                    roles = dbcon.Roles.ToList();
                }
            }
            catch {throw;}
            return roles;
        } 
    }
}
