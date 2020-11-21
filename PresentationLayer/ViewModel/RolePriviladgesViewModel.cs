using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using PresentationLayer.Command;
using Business_Logic;
using DataModel;

namespace PresentationLayer.ViewModel
{
    public class RolePriviladgesViewModel:INotifyPropertyChanged
    {
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

        private IEnumerable<DataModel.Program> _programs;
        public IEnumerable<DataModel.Program> Programs
        {
            get { return _programs; }
            set
            {
                _programs = value;
                OnPropertyChanged("Programs");
            }
        }
        
        
        public RolePriviladgesAddCommand RolePriviladgesAddCommand { get; set; }
        public RolePriviladgesClearCommand RolePriviladgesClearCommand { get; set; }
        public RolePriviladgesSaveCommand RolePriviladgesSaveCommand { get; set; }
        public ObservableCollection<Priviladge> Priviladges { get; set; }
        public RolePriviladgesViewModel()
        {
            RolePriviladgesSaveCommand=new RolePriviladgesSaveCommand(this);
            RolePriviladgesClearCommand=new RolePriviladgesClearCommand(this);
            RolePriviladgesAddCommand=new RolePriviladgesAddCommand(this);
            Roles = GetAllRoles();
            Programs = GetAllPrograms();
            Priviladges=new ObservableCollection<Priviladge>();
        }

        public IEnumerable<DataModel.Role> GetAllRoles()
        {
            RoleBLL roleBll = new RoleBLL();
            return roleBll.RetrieveAllRoles();
        }

        public IEnumerable<DataModel.Program> GetAllPrograms()
        {
            ProgramBll programBll = new ProgramBll();
            return programBll.RetrieveAllPrograms();
        }

        public void AddPriviladges(Priviladge privObj)
        {
            try
            {
                Priviladge tempObj=new Priviladge();
                tempObj.Id = privObj.Id;
                tempObj.ProgramCode = privObj.ProgramCode;
                tempObj.Role = privObj.Role;
                tempObj.RoleId = privObj.RoleId;

                #region Attach Program
                DataModel.Program tempPrgrm=new DataModel.Program();
                tempPrgrm.Name = privObj.Program.Name;
                tempPrgrm.ProgramCode = privObj.Program.ProgramCode;
                tempPrgrm.Description = privObj.Program.Description;
                tempObj.Program = tempPrgrm;
                #endregion

                Priviladges.Add(tempObj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearPriviladges(ObservableCollection<Priviladge> priviladges)
        {
            try
            {
                priviladges.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SavePriviladges(ObservableCollection<Priviladge> priviladges )
        {
            PriviladgeBLL priviBll=new PriviladgeBLL();
            int result = priviBll.InsertPriviladge(priviladges);
            if (result > 0)
            {
                MessageBox.Show("Successfully Saved.");
            }
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
