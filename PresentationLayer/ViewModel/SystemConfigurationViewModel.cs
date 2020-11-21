using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using DataModel;
using Business_Logic;
using PresentationLayer.Command;

namespace PresentationLayer.ViewModel
{
    public class SystemConfigurationViewModel:INotifyPropertyChanged
    {
        public SystemConfigSaveCommand SysConfgSaveCommnd { get; set; }
        public SystemConfigClearCommand SystemConfigClearCommnd { get; set; }

        private IEnumerable<SystemConfiguration> _systemConfigurations;
        public IEnumerable<SystemConfiguration> SystemConfigurations
        {
            get { return _systemConfigurations; }
            set
            {
                _systemConfigurations = value;
                OnPropertyChanged("SystemConfigurations");
            }
        }
        public IEnumerable<SystemConfiguration> GetAllSystemConfigurations()
        {
            SystemConfigurationBLL sysConfigBll=new SystemConfigurationBLL();
            return sysConfigBll.RetrieveSystemConfiguration();
        }
        public SystemConfigurationViewModel()
        {
            SystemConfigurations = GetAllSystemConfigurations();
            SysConfgSaveCommnd=new SystemConfigSaveCommand(this);
            SystemConfigClearCommnd=new SystemConfigClearCommand(this);
        }

        public void InsertSystemConfigDetail(ConfigurationDetail confgDetails)
        {
            try
            {
                SystemConfigurationBLL sysConfigurationBll=new SystemConfigurationBLL();
                int result = sysConfigurationBll.InsertConfigurationDetail(confgDetails);
                if (result > 0)
                {
                    MessageBox.Show("Successfully saved.");
                    ClearConfigurationDetail(confgDetails);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearConfigurationDetail(ConfigurationDetail configurationDetail)
        {
            configurationDetail.Code = null;
            configurationDetail.ConfigDetailCode = null;
            configurationDetail.ConfigDetailName = null;
            configurationDetail.ConfigDetailDescrp = null;
        }

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
