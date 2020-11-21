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
    public class SystemConfigClearCommand:ICommand
    {
        public SystemConfigurationViewModel SystmConfigVm { protected get; set; }
        public SystemConfigClearCommand(SystemConfigurationViewModel sysConfigViewModel)
        {
            this.SystmConfigVm = sysConfigViewModel;
        }

        #region Implement ICommand
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                ConfigurationDetail configurationDetail = parameter as ConfigurationDetail;
                if (
                    !string.IsNullOrEmpty(configurationDetail.Code) ||
                                          !string.IsNullOrEmpty(configurationDetail.ConfigDetailCode) ||
                                          !string.IsNullOrEmpty(configurationDetail.ConfigDetailName) ||
                                          !string.IsNullOrEmpty(configurationDetail.ConfigDetailDescrp))
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
            SystmConfigVm.ClearConfigurationDetail(parameter as ConfigurationDetail);
        }

        #endregion
    }
}
