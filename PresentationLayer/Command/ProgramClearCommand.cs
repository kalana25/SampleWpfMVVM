using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationLayer.ViewModel;

namespace PresentationLayer.Command
{
    public class ProgramClearCommand:ICommand
    {
        public ProgramViewModel PrgmVM { get; set; }
        public ProgramClearCommand(ProgramViewModel pgrmvm)
        {
            this.PrgmVM = pgrmvm;
        }
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                DataModel.Program tempPrgmObj = parameter as DataModel.Program;
                if (!string.IsNullOrEmpty(tempPrgmObj.Description) || !string.IsNullOrEmpty(tempPrgmObj.Name) || !string.IsNullOrEmpty(tempPrgmObj.ProgramCode))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            PrgmVM.ClearProgram(parameter as DataModel.Program);
        }
    }
}
