using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using  PresentationLayer.Command;
using Business_Logic;

namespace PresentationLayer.ViewModel
{
    public class ProgramViewModel
    {
        public ProgramCommand ProgramComnd { get; set; }
        public ProgramClearCommand PrgmClearCommand { get; set; }

        public ProgramViewModel()
        {
            this.ProgramComnd=new ProgramCommand(this);
            this.PrgmClearCommand=new ProgramClearCommand(this);
        }

        public void InsertProgram(DataModel.Program prgm)
        {
            ProgramBll prgramBll=new ProgramBll();
            int resul=prgramBll.InsertProgram(prgm);
            if (resul > 0)
            {
                MessageBox.Show("Successfully saved.");
                ClearProgram(prgm);
            }               
        }

        public void ClearProgram(DataModel.Program prgm)
        {
            prgm.ProgramCode = string.Empty;
            prgm.Name = null;
            prgm.Description = null;
        }
    }
}
