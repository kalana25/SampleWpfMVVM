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
    public class AppointmentSaveCommand:ICommand
    {
        public AppointmentViewModel AppointmentViewModel { get; set; }
        public AppointmentSaveCommand(AppointmentViewModel apointmnetVm)
        {
            AppointmentViewModel = apointmnetVm;
        }
        
        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                Appointment appntm = parameter as Appointment;
                if (appntm.Date.HasValue && appntm.Date != DateTime.MinValue && appntm.DoctorId!=0 && appntm.PatientId!=0 && appntm.StartTime.HasValue && appntm.EndTime.HasValue)
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
            AppointmentViewModel.SaveAppointmet(parameter as Appointment);
        }

        #endregion
    }
}
