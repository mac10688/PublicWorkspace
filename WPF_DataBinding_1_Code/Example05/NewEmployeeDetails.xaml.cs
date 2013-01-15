using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Example05
{
    /// <summary>
    /// Interaction logic for NewEmployeeDetails.xaml
    /// </summary>
    public partial class NewEmployeeDetails : Window
    {
        public Employee ReturnValue = null;
        public NewEmployeeDetails()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue = Resources["NewEmployee"] as Employee;
            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ReturnValue = null;
        }
    }
}
