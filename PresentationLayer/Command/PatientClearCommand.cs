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
    public class PatientClearCommand:ICommand
    {
        public PatientViewModel PatientViewModel { get; set; }
        public PatientClearCommand(PatientViewModel pVm)
        {
            this.PatientViewModel = pVm;
        }

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                Patient patient = parameter as Patient;
                if (!string.IsNullOrEmpty(patient.FirstName) || !string.IsNullOrEmpty(patient.LastName) ||
                    !string.IsNullOrEmpty(patient.OtherName) || !string.IsNullOrEmpty(patient.Gender) ||
                    !string.IsNullOrEmpty(patient.ContactNo) || !string.IsNullOrEmpty(patient.Address) ||
                    patient.Age != 0)
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
            this.PatientViewModel.ClearPatient(parameter as Patient);
        }

        #endregion
    }
}
