using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DataModel
{
    public class Doctor:Person
    {
        private string _speciality;
        public string Speciality
        {
            get { return _speciality; }
            set
            {
                _speciality = value;
                OnPropertyChanged("Speciality");
            }
        }

        private int _experiance;
        public int Experiance
        {
            get { return _experiance; }
            set
            {
                _experiance = value;
                OnPropertyChanged("Experiance");
            }
        }

        private string _registerNo;

        [Required]
        public string RegisterNo
        {
            get { return _registerNo; }
            set
            {
                _registerNo = value;
                OnPropertyChanged("RegisterNo");
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        

    }
}
