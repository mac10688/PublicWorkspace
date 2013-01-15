//Houssem Dellai
//houssem.dellai@ieee.org
//full tutorial here :
//http://www.c-sharpcorner.com/UploadFile/ae35ca/working-with-creating-a-local-database-in-wp7/
//http://msdn.microsoft.com/en-us/library/hh202860%28v=VS.92%29.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;

using System.Text;

namespace F5debugWpfLocalDatabase
{
    public partial class MainPage : PhoneApplicationPage
    {

        private const string strConnectionString = @"isostore:/EmployeeDB.sdf";

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //create database
            using (EmployeeDataContext Empdb = new EmployeeDataContext(strConnectionString))
            {
                if (Empdb.DatabaseExists() == false)
                {
                    Empdb.CreateDatabase();
                    MessageBox.Show("Employee Database Created Successfully!!!");
                }
                else
                {
                    MessageBox.Show("Employee Database already exists!!!");
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //Adding data to the local database
            using (EmployeeDataContext Empdb = new EmployeeDataContext(strConnectionString))
            {
                Employee newEmployee = new Employee
                {
                    EmployeeID = Convert.ToInt32(txtEmpid.Text),
                    EmployeeAge = txtAge.Text.ToString(),
                    EmployeeName = txtName.Text.ToString()
                };

                Empdb.Employees.InsertOnSubmit(newEmployee);
                Empdb.SubmitChanges();
                MessageBox.Show("Employee Added Successfully!!!");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            using (EmployeeDataContext Empdb = new EmployeeDataContext(strConnectionString))
            {
                IQueryable<Employee> EmpQuery = from Emp in Empdb.Employees where Emp.EmployeeName == txtName.Text select Emp;
                Employee EmpRemove = EmpQuery.FirstOrDefault();
                Empdb.Employees.DeleteOnSubmit(EmpRemove);
                Empdb.SubmitChanges();
                MessageBox.Show("Employee Deleted Successfully!!!");
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            IList<Employee> EmployeesList = this.GetEmployeeList();
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("Employee Details");
            foreach (Employee emp in EmployeesList)
            {
                strBuilder.AppendLine("Name - " + emp.EmployeeName + " Age - " + emp.EmployeeAge);
            }
            MessageBox.Show(strBuilder.ToString());
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            //delete database
            using (EmployeeDataContext Empdb = new EmployeeDataContext(strConnectionString))
            {
                if (Empdb.DatabaseExists())
                {
                    Empdb.DeleteDatabase();
                    MessageBox.Show("Employee Database Deleted Successfully!!!");
                }
            }
        }

        public IList<Employee> GetEmployeeList()
        {
            // Fetching data from local database
            IList<Employee> EmployeeList = null;
            using (EmployeeDataContext Empdb = new EmployeeDataContext(strConnectionString))
            {
                IQueryable<Employee> EmpQuery = from Emp in Empdb.Employees select Emp;
                EmployeeList = EmpQuery.ToList();
            }
            return EmployeeList;
        }
    }
}