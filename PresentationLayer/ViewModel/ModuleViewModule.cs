using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Business_Logic;
using PresentationLayer.Command;
using DataModel;

namespace PresentationLayer.ViewModel
{
    public class ModuleViewModule
    {
        public ModuleClearCommand ModuleClearCommand { get; set; }
        public ModuleSaveCommand ModuleSaveCommand { get; set; }

        public ModuleViewModule()
        {
            this.ModuleClearCommand=new ModuleClearCommand(this);
            this.ModuleSaveCommand=new ModuleSaveCommand(this);
        }


        public void ClearModule(Module module)
        {
            module.ModuleId = null;
            module.Name = null;
            module.Description = null;
        }

        public void InsertModule(Module module)
        {
            ModuleBLL moduleBll=new ModuleBLL();
            int result = moduleBll.InsertModule(module);
            if (result > 0)
            {
                MessageBox.Show("Successfully saved.");
                ClearModule(module);
            }
        }
    }
}
