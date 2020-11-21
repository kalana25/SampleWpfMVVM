using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataModel
{
    public class Module:INotifyPropertyChanged
    {
        private string _moduleId;
        public string ModuleId
        {
            get { return _moduleId; }
            set
            {
                _moduleId = value;
                OnPropertyChanged("ModuleId");
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

        public virtual ICollection<Section> Sections  { get; set; }

        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(PropName));
            }
        }

        #endregion
    }
}
