using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataModel;
using PresentationLayer.ViewModel;

namespace PresentationLayer.Command
{
    public class SystemConfigSaveCommand:ICommand
    {
        public SystemConfigurationViewModel SystemConfigurationViewModel { get; set; }
        public SystemConfigSaveCommand(SystemConfigurationViewModel sysConfigVmModel)
        {
            this.SystemConfigurationViewModel = sysConfigVmModel;
        }

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                ConfigurationDetail confgDtDetail = parameter as ConfigurationDetail;
                if (!string.IsNullOrEmpty(confgDtDetail.ConfigDetailCode) &&
                    !string.IsNullOrEmpty(confgDtDetail.ConfigDetailName) && !string.IsNullOrEmpty(confgDtDetail.Code))
                    return true;
                return false;
            }
            return false;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            SystemConfigurationViewModel.InsertSystemConfigDetail(parameter as ConfigurationDetail);
        }

        #endregion
    }
}
