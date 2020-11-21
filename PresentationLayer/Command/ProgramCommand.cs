using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PresentationLayer.ViewModel;

namespace PresentationLayer.Command
{
    public class ProgramCommand:ICommand
    {
        public ProgramViewModel ProgmViwModel { get; set; }

        public ProgramCommand(ProgramViewModel pgvm)
        {
            this.ProgmViwModel = pgvm;
        }
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                DataModel.Program tempObj=parameter as DataModel.Program;
                if (string.IsNullOrEmpty(tempObj.Name) || string.IsNullOrEmpty(tempObj.ProgramCode))
                    return false;
                    return true;
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
            ProgmViwModel.InsertProgram(parameter as DataModel.Program);
        }
    }
}
