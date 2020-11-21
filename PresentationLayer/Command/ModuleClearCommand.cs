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
    public class ModuleClearCommand:ICommand
    {
        public ModuleViewModule ModuleViewModule { get; set; }
        public ModuleClearCommand(ModuleViewModule moduleVm)
        {
            this.ModuleViewModule = moduleVm;
        }

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                Module module = parameter as Module;
                if (!string.IsNullOrEmpty(module.ModuleId) || !string.IsNullOrEmpty(module.Name) || !string.IsNullOrEmpty(module.Description))
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
            ModuleViewModule.ClearModule(parameter as Module);
        }

        #endregion
    }
}
