using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataModel;
using PresentationLayer.ViewModel;

namespace PresentationLayer.Command
{
    public class RoleDeleteCommand : ICommand
    {
        private readonly RoleListViewModel viewModel;

        public RoleDeleteCommand(RoleListViewModel rolLstVm)
        {
            viewModel = rolLstVm;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            // Check for permission access for delete and if role associated with another record...

            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.DeleteRole(parameter as Role);
        }
    }
}
