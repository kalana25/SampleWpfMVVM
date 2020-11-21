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
    public class DoctorClearCommand:ICommand
    {
        public DoctorViewModel DoctorViewModel { get; set; }
        public DoctorClearCommand(DoctorViewModel docVm)
        {
            DoctorViewModel = docVm;
        }

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                Doctor doc = parameter as Doctor;
                if (!string.IsNullOrEmpty(doc.FirstName) || !string.IsNullOrEmpty(doc.LastName) ||
                    !string.IsNullOrEmpty(doc.OtherName) || !string.IsNullOrEmpty(doc.Gender) ||
                    !string.IsNullOrEmpty(doc.ContactNo) || doc.Age != 0 || !string.IsNullOrEmpty(doc.Speciality) ||
                    doc.Experiance != 0 || !string.IsNullOrEmpty(doc.RegisterNo) || !string.IsNullOrEmpty(doc.Email))
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
            DoctorViewModel.ClearDoctor(parameter as Doctor);
        }

        #endregion
    }
}
