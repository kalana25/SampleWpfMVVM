using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationLayer.ViewModel;
using DataModel;

namespace PresentationLayer.Command
{
    public class UserClearCommand:ICommand
    {
        public UserViewModel UserViewModel { get;set; }
        public UserClearCommand(UserViewModel usrvm)
        {
            this.UserViewModel = usrvm;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                User tempUser = parameter as User;
                if (!string.IsNullOrEmpty(tempUser.Password) || !string.IsNullOrEmpty(tempUser.UserName) || tempUser.RoleId != 0)
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
            UserViewModel.ClearUser(parameter as User);
        }
    }
}
