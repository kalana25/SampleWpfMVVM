using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.ComponentModel;
using DataModel;
using PresentationLayer.Command;
using Business_Logic;

namespace PresentationLayer.ViewModel
{
    public class SectionViewModule:INotifyPropertyChanged
    {
        public SectionClearCommand SectinClerComnd { get; set; }
        public SectionSaveCommand SectinSaveComnd { get; set; }

        private IEnumerable<Module> _modules;
        public IEnumerable<Module> Modules
        {
            get { return _modules; }
            set
            {
                _modules = value;
                OnPropertyChanged("Modules");
            }
        }  
        
        public SectionViewModule()
        {
            SectinClerComnd=new SectionClearCommand(this);
            SectinSaveComnd=new SectionSaveCommand(this);
            Modules = GetAllModules();
        }

        public IEnumerable<Module> GetAllModules()
        {
            ModuleBLL moduleBll=new ModuleBLL();
            return moduleBll.RetrieveAllModules();
        }

        public void ClearSection(Section sec)
        {
            sec.SectionId = null;
            sec.Name = null;
            sec.Description = null;
            sec.ModuleId = null;
        }

        public void InsertSection(Section sec)
        {
            try
            {
                SectionBLL secBll = new SectionBLL();
                int result = secBll.InsertSection(sec);
                if (result > 0)
                {
                    MessageBox.Show("Successfully Saved.");
                    ClearSection(sec);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropName)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(PropName));
        }

        #endregion
    }
}
