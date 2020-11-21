using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataModel
{
    public class Role:INotifyPropertyChanged
    {
        private string _rolename;

        public string RoleName
        {
            get { return _rolename; }
            set
            {
                _rolename = value;
                OnPropertyChanged("RoleName");
            }
        }

        private int _roleid;

        public int RoleId
        {
            get { return _roleid; }
            set
            {
                _roleid = value;
                OnPropertyChanged("RoleId");
            }
        }
        private string _rolecode;

        public string RoleCode
        {
            get { return _rolecode; }
            set
            {
                _rolecode = value;
                OnPropertyChanged("RoleCode");
            }
        }

        public Role()
        {
            
        }
        public virtual ICollection<Priviladge> Priviladges { get; set; }
        public virtual  ICollection<User> Users { get; set; }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propName));
            }
        }

        #endregion
    }
}
