using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PresentationLayer.Command;
using DataModel;
using Business_Logic;

namespace PresentationLayer.ViewModel
{
    public class PatientViewModel:INotifyPropertyChanged
    {
        public PatientClearCommand PatientClearCommand { get; set; }
        public PatientSaveCommand PatientSaveCommand { get; set; }

        private IEnumerable<ConfigurationDetail> _genderConfigDetails;
        public IEnumerable<ConfigurationDetail> GenderConfigDetails
        {   
            get { return _genderConfigDetails; }
            set
            {
                _genderConfigDetails = value;
                OnPropertyChanged("GenderConfigDetails");
            }
        }
        

        public PatientViewModel()
        {
            PatientClearCommand=new PatientClearCommand(this);
            PatientSaveCommand=new PatientSaveCommand(this);
            GenderConfigDetails = GetGender();
        }

        public IEnumerable<ConfigurationDetail> GetGender()
        {
            PatientBLL patientBll = new PatientBLL();
            return patientBll.RetrieveAllGenders();
        }

        public void InsertPatient(Patient patient)
        {
            try
            {
                PatientBLL patientBll=new PatientBLL();
                int result = patientBll.InsertPatient(patient);
                if (result > 0)
                {
                    MessageBox.Show("Insert Successfully");
                    ClearPatient(patient);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearPatient(Patient patient)
        {
            try
            {
                patient.Id = 0;
                patient.FirstName = null;
                patient.LastName = null;
                patient.OtherName = null;
                patient.Address = null;
                patient.Age = 0;
                patient.ContactNo = null;
                patient.Gender = null;
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
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
