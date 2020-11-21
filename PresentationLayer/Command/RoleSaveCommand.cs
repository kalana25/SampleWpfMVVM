using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationLayer.ViewModel;

namespace PresentationLayer.Command
{
    public class RoleSaveCommand:ICommand
    {
        public RoleViewModel roleViewModel { get; set; }
        public RoleSaveCommand(RoleViewModel rolvm)
        {
            this.roleViewModel = rolvm;
        }

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                DataModel.Role roleObject = parameter as DataModel.Role;
                if (!string.IsNullOrEmpty(roleObject.RoleCode) && !string.IsNullOrEmpty(roleObject.RoleName))
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
            roleViewModel.InsertRole(parameter as DataModel.Role);
        }

        #endregion
    }
}
