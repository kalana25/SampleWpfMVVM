using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataModel;
using Business_Logic;
using PresentationLayer.Command;

namespace PresentationLayer.ViewModel
{
    public class DoctorViewModel:INotifyPropertyChanged
    {
        private IEnumerable<ConfigurationDetail> _genderConfigDetails;
        public IEnumerable<ConfigurationDetail> GenderConfigDetail
        {
            get { return _genderConfigDetails; }
            set
            {
                _genderConfigDetails = value;
                OnPropertyChanged("GenderConfigDetail");
            }
        }

        public DoctorSaveCommand DoctorSaveCommand { get; set; }
        public DoctorClearCommand DoctorClearCommand { get; set; }

        public DoctorViewModel()
        {
            GenderConfigDetail = GetGender();
            DoctorSaveCommand=new DoctorSaveCommand(this);
            DoctorClearCommand=new DoctorClearCommand(this);
        }

        public IEnumerable<ConfigurationDetail> GetGender()
        {
            DoctorBLL doctorBll=new DoctorBLL();
            return doctorBll.RetrieveAllGenders();
        }

        public void InsertDoctor(Doctor doctor)
        {
            try
            {
                DoctorBLL doctorBll=new DoctorBLL();
                int result = doctorBll.InsertDoctor(doctor);
                if (result > 0)
                {
                    MessageBox.Show("Successfully saved");
                    ClearDoctor(doctor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearDoctor(Doctor doc)
        {
            try
            {
                doc.FirstName = string.Empty;
                doc.LastName = string.Empty;
                doc.OtherName = string.Empty;
                doc.Gender = string.Empty;
                doc.Age = 0;
                doc.ContactNo = string.Empty;
                doc.Id = 0;
                doc.Experiance = 0;
                doc.Speciality = string.Empty;
                doc.RegisterNo = string.Empty;
                doc.Email = string.Empty;
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
