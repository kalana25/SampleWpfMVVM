using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DataModel
{
    public class Program:INotifyPropertyChanged
    {
        
        private string _programCode;
        [Key]
        public string ProgramCode
        {
            get { return _programCode; }
            set
            {
                _programCode = value;
                OnPropertyChanged("ProgramCode");
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        public virtual ICollection<Priviladge> Priviladges { get; set; }
        public virtual Section Section { get; set; }

        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
