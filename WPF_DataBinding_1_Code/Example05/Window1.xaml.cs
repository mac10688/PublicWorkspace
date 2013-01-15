using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        public Window1()
        {
            InitializeComponent();
        }

        private void cmdAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            NewEmployeeDetails ned = new NewEmployeeDetails();
            bool? employeeEntered = ned.ShowDialog();
            if ((employeeEntered.HasValue) && (employeeEntered.Value == true))
            {
                ObservableCollection<Employee> oc = Resources["myEmployeeList"] as ObservableCollection<Employee>;
                oc.Add(ned.ReturnValue);
            }
        }
    }
}
