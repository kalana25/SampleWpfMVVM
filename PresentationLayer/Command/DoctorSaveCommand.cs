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
    public class DoctorSaveCommand:ICommand
    {
        public DoctorViewModel DoctorViewModel { get; set; }


        public DoctorSaveCommand(DoctorViewModel docVm)
        {
            DoctorViewModel = docVm;
        }

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                Doctor doc = parameter as Doctor;
                if (!string.IsNullOrEmpty(doc.RegisterNo) && !string.IsNullOrEmpty(doc.FirstName) &&
                    !string.IsNullOrEmpty(doc.LastName) && !string.IsNullOrEmpty(doc.Gender))
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
            DoctorViewModel.InsertDoctor(parameter as Doctor);
        }

        #endregion
    }
}
