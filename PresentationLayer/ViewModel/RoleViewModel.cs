using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Business_Logic;
using PresentationLayer.Command;

namespace PresentationLayer.ViewModel
{
    public class RoleViewModel
    {
        public RoleSaveCommand rolesaveCommnd { get; set; }
        public RoleClearCommand roleclearCommand { get; set; }
        public RoleViewModel()
        {
            this.rolesaveCommnd=new RoleSaveCommand(this);
            this.roleclearCommand=new RoleClearCommand(this);
        }

        public void InsertRole(DataModel.Role role)
        {
            RoleBLL roleBll=new RoleBLL();
            int result = roleBll.insertRoll(role);
            if (result > 0)
            {
                MessageBox.Show("Successfully Saved.");
                ClearRole(role);
            }
        }

        public void ClearRole(DataModel.Role role)
        {
            role.RoleId = 0;
            role.RoleName = null;
            role.RoleCode = null;
        }
    }
}
