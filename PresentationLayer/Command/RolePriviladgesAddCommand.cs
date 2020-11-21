using System;
using System.Windows.Input;
using DataModel;
using PresentationLayer.ViewModel;

namespace PresentationLayer.Command
{
    public class RolePriviladgesAddCommand:ICommand
    {
        public RolePriviladgesViewModel RolePriviladgesViewModel { get; set; }
        public RolePriviladgesAddCommand(RolePriviladgesViewModel rolePriviladgesViewModel)
        {
            RolePriviladgesViewModel = rolePriviladgesViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            RolePriviladgesViewModel.AddPriviladges(parameter as Priviladge);
        }
    }
}
