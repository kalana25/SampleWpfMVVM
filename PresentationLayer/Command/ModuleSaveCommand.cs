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
    public class ModuleSaveCommand:ICommand
    {
        public ModuleViewModule ModuleViewModule { get; set; }
        public ModuleSaveCommand(ModuleViewModule moduleVm)
        {
            this.ModuleViewModule = moduleVm;
        }

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                Module mod = parameter as Module;
                if (!string.IsNullOrEmpty(mod.ModuleId) && !string.IsNullOrEmpty(mod.Name))
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
            ModuleViewModule.InsertModule(parameter as Module);
        }

        #endregion
    }
}
