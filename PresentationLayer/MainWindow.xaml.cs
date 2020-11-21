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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new Usercontrol.RoleManagement.RoleList(this);
        }

        private void Program_Click(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new Usercontrol.Program();
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new Usercontrol.User();
        }

        private void Module_Click(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new Usercontrol.Module();
        }

        private void Section_Click(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new Usercontrol.Section();
        }

        private void patient_Click(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new Usercontrol.Patient();
        }

        private void doctor_Click(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new Usercontrol.Doctor();
        }

        private void sysconfigure_Click(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new Usercontrol.SystemConfiguration();
        }

        private void Privileges_Click(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new Usercontrol.UserPrivilages();
        }

        private void appointment_Click(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = new Usercontrol.Appointment();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.ContentControl.Content = null;
        }
    }
}
