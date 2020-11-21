using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Data
{
    public class Priviladge:INotifyPropertyChanged
    {
        private bool add;

        public bool Add
        {
            get { return add; }
            set
            {
                add = value;
                OnPropertyChanged("Add");
            }
        }
        private bool edit;

        public bool Edit
        {
            get { return edit; }
            set
            {
                edit = value;
                OnPropertyChanged("Edit");
            }
        }
        private bool delete;

        public bool Delete
        {
            get { return delete; }
            set
            {
                delete = value;
                OnPropertyChanged("Delete");
            }
        }
        private bool view;

        public bool View
        {
            get { return view; }
            set
            {
                view = value;
                OnPropertyChanged("View");
            }
        }
        private bool approve;

        public bool Approve
        {
            get { return approve; }
            set
            {
                approve = value; 
                OnPropertyChanged("Approve");
            }
        }
        private bool unapprove;

        public bool Unapprove
        {
            get { return unapprove; }
            set
            {
                unapprove = value;
                OnPropertyChanged("Unapprove");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(name));
            }
        }
    }
}
