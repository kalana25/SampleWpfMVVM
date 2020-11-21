using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DataModel
{
    public class SystemConfiguration:INotifyPropertyChanged
    {
        
        private string _code;
        [Key]
        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _descrip;
        public string Description
        {
            get { return _descrip; }
            set
            {
                _descrip = value;
                OnPropertyChanged("Description");
            }
        }
        public virtual ICollection<ConfigurationDetail> ConfigurationDetails { get; set; }

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
