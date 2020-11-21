using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PresentationLayer;

namespace PresentationLayer.Usercontrol.RoleManagement
{
    /// <summary>
    /// Interaction logic for RoleList.xaml
    /// </summary>
    public partial class RoleList : UserControl
    {
        private readonly MainWindow mainWindow;
        public RoleList(MainWindow mainWin)
        {
            InitializeComponent();
            this.mainWindow = mainWin;
        }

        private void addRole_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ContentControl.Content = new Usercontrol.Role();
        }
    }
}
