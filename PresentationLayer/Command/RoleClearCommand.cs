using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationLayer.ViewModel;

namespace PresentationLayer.Command
{
    public class RoleClearCommand:ICommand
    {
        public RoleViewModel rolevm { get; set; }
        public RoleClearCommand(RoleViewModel roleviewModel)
        {
            this.rolevm = roleviewModel;
        }
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                DataModel.Role roleObject = parameter as DataModel.Role;
                if (!string.IsNullOrEmpty(roleObject.RoleCode) || !string.IsNullOrEmpty(roleObject.RoleName))
                    return true;
                return false;
            }
            return false;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            rolevm.ClearRole(parameter as DataModel.Role);
        }
    }
}
