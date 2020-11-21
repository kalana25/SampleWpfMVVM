using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataModel
{
    public class Section:INotifyPropertyChanged
    {
        private string _sectionId;
        public string SectionId
        {
            get { return _sectionId; }
            set
            {
                _sectionId = value;
                OnPropertyChanged("SectionId");
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
        public virtual Module Module { get; set; }
        public virtual ICollection<Program> Programs { get; set; }

        #region Implement INotifyProperty Changed

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string Propname)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(Propname));
        }

        #endregion
    }
}
