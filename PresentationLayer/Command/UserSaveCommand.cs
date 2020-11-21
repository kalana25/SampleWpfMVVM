using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using  PresentationLayer.ViewModel;
using  DataModel;

namespace PresentationLayer.Command
{
    public class UserSaveCommand:ICommand
    {
        public UserViewModel UserViewModel { get; set; }
        public UserSaveCommand(UserViewModel uvm)
        {
            UserViewModel = uvm;
        }

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                User temUsr = parameter as User;
                if (!string.IsNullOrEmpty(temUsr.Password) && !string.IsNullOrEmpty(temUsr.UserName) &&
                    temUsr.RoleId != 0)
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
            UserViewModel.InsertUser(parameter as User);
        }

        #endregion
    }
}
