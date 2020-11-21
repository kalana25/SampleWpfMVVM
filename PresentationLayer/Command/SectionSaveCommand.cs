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
    public class SectionSaveCommand:ICommand
    {
        public SectionViewModule SectionViewModule { get; set; }
        public SectionSaveCommand(SectionViewModule svm)
        {
            SectionViewModule = svm;
        }

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                Section temp = parameter as Section;
                if (!string.IsNullOrEmpty(temp.SectionId) && !string.IsNullOrEmpty(temp.Name) &&
                    !string.IsNullOrEmpty(temp.ModuleId))
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
          SectionViewModule.InsertSection(parameter as Section);  
        }

        #endregion
    }
}
