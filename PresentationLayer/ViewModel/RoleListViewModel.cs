using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DataModel;
using Business_Logic;
using PresentationLayer.Command;

namespace PresentationLayer.ViewModel
{
    public class RoleListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Role> _roles;
        public ObservableCollection<Role> Roles
        {
            get { return _roles; }
            set 
            { 
                _roles = value;
                OnPropertyChanged("Roles");
            }
        }

        public RoleDeleteCommand  RoleDeleteCommand { get; set; }

        public RoleListViewModel()
        {
            Roles = new ObservableCollection<Role>(GetAllRoles());
            RoleDeleteCommand = new RoleDeleteCommand(this);
        }

        public void DeleteRole(Role role)
        {
            RoleBLL bll = new RoleBLL();
            if (bll.DeleteRoll(role))
            {
                Roles.Remove(role);
            }
        }

        private ICollection<Role> GetAllRoles()
        {
            RoleBLL bll = new RoleBLL();
            return bll.RetrieveAllRoles();
        }

        #region Implement INotifiedProperty Changed

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }

        #endregion
    }
}
