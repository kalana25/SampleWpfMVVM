using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Business_Logic;
using DataModel;
using  PresentationLayer.Command;

namespace PresentationLayer.ViewModel
{
    public class AppointmentViewModel:INotifyPropertyChanged
    {
        public AppointmentSaveCommand AppointmentSaveCommand { get; set; }

        private IEnumerable<Doctor> _doctors;
        public IEnumerable<Doctor> Doctors
        {
            get { return _doctors; }
            set
            {
                _doctors = value;
                OnPropertyChanged("Doctors");
            }
        }

        private IEnumerable<Patient> _patients;
        public IEnumerable<Patient> Patients
        {
            get { return _patients; }
            set
            {
                _patients = value;
                OnPropertyChanged("Patients");
            }
        }

        private Appointment _nextAppointment;
        public Appointment NextAppointment
        {
            get { return _nextAppointment; }
            set
            {
                _nextAppointment = value;
                OnPropertyChanged("NextAppointment");
            }
        }
        

        public AppointmentViewModel()
        {
            AppointmentSaveCommand=new AppointmentSaveCommand(this);
            Doctors = GetDoctors();
            Patients = GetPatients();
            //NextAppointment = GetAppointment();
        }
        private IEnumerable<Doctor> GetDoctors()
        {
            DoctorBLL doctorBll=new DoctorBLL();
            return doctorBll.RetrieveAllDoctors();
        }

        private IEnumerable<Patient> GetPatients()
        {
            PatientBLL patientBll=new PatientBLL();
            return patientBll.RetrieveAllPatints();
        }

        private Appointment GetAppointment()
        {
            AppointmentBLL appointmentBll = new AppointmentBLL();
            return appointmentBll.GetNextAppointment();
        }

        public void SaveAppointmet(Appointment appointment)
        {
            try
            {
                AppointmentBLL appointmentBll=new AppointmentBLL();
                int result=appointmentBll.InsertAppointment(appointment);
                if (result > 0)
                {
                    appointment.DayCount++;
                    MessageBox.Show("Successfully Saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(propName));
        }
        #endregion
    }
}
