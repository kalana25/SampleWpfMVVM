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
    public class SectionClearCommand:ICommand
    {
        public SectionViewModule SectionViewModule { get; set; }

        public SectionClearCommand(SectionViewModule svm)
        {
            SectionViewModule = svm;
        }

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                Section sec = parameter as Section;
                if (!string.IsNullOrEmpty(sec.SectionId) || !string.IsNullOrEmpty(sec.Name) ||
                    !string.IsNullOrEmpty(sec.Description)||!string.IsNullOrEmpty(sec.ModuleId))
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
            SectionViewModule.ClearSection(parameter as Section);
        }

        #endregion
    }
}
