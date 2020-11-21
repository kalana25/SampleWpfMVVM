using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataModel;
using PresentationLayer.ViewModel;

namespace PresentationLayer.Command
{
    public class RolePriviladgesSaveCommand:ICommand
    {
        public RolePriviladgesViewModel RolePriviladgesViewModel { get; set; }
        public RolePriviladgesSaveCommand(RolePriviladgesViewModel rpvm)
        {
            this.RolePriviladgesViewModel = rpvm;
        }
        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }
            return ((parameter as ObservableCollection<Priviladge>).Count != 0);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            RolePriviladgesViewModel.SavePriviladges(parameter as ObservableCollection<Priviladge>);
        }
    }
}
