using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Role
    {
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public string RoleCode { get; set; }

        public virtual ICollection<Priviladge> Priviladges { get; set; }

        public Role()
        {
            
        }

        public virtual  ICollection<User> Users { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
    }
}
