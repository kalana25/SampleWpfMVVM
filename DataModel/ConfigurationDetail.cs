using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel
{
    public class ConfigurationDetail:INotifyPropertyChanged
    {
        private string _configDetailCode;
        [Key]
        public string ConfigDetailCode
        {
            get { return _configDetailCode; }
            set
            {
                _configDetailCode = value;
                OnPropertyChanged("ConfigDetailCode");
            }
        }

        private string _configDetailName;
        public string ConfigDetailName
        {
            get { return _configDetailName; }
            set
            {
                _configDetailName = value;
                OnPropertyChanged("ConfigDetailName");
            }
        }

        private string _configDetailDescrp;
        public string ConfigDetailDescrp
        {
            get { return _configDetailDescrp; }
            set
            {
                _configDetailDescrp = value;
                OnPropertyChanged("ConfigDetailDescrp");
            }
        }

        private string _code;
        [Required]
        [ForeignKey("SystemConfiguration")]
        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        public virtual SystemConfiguration SystemConfiguration { get; set; }

        #region Implement INotifyProperty changed

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
