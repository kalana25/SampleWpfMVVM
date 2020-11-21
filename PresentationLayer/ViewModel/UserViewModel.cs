using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Business_Logic;
using PresentationLayer.Command;
using DataModel;

namespace PresentationLayer.ViewModel
{
    public class UserViewModel:INotifyPropertyChanged
    {
        public UserSaveCommand UsrSaveCommand { get; set; }
        public UserClearCommand usrClearCommand { get; set; }

        private IEnumerable<DataModel.Role> _roles;
        public IEnumerable<DataModel.Role> Roles
        {
            get { return _roles; }
            set
            {
                _roles = value;
                OnPropertyChanged("Roles");
            }
        }

        public UserViewModel()
        {
            UsrSaveCommand=new UserSaveCommand(this);
            usrClearCommand=new UserClearCommand(this);
            Roles = GetAllRoles();
        }

        public IEnumerable<DataModel.Role> GetAllRoles()
        {
            RoleBLL roleBll=new RoleBLL();
            return roleBll.RetrieveAllRoles();
        }

        public void InsertUser(DataModel.User user)
        {
            try
            {
                UserBll userBll=new UserBll();
                int result = userBll.InsertUser(user);
                if (result > 0)
                {
                    MessageBox.Show("Successfully Saved.");
                    ClearUser(user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearUser(User usr)
        {
            usr.UserId = 0;
            usr.UserName = null;
            usr.Password = null;
            usr.RoleId = 0;
        }




        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion
    }
}
