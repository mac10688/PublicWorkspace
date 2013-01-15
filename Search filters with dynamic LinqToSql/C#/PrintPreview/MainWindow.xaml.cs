//Call dll netFramework 4.0
using PrintPreview.Management;
using PrintPreview.Class;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

//PrtintPreview project
namespace PrintPreview
{
    /// <summary>
    /// Logic for interaction MainWindow.xaml
    /// </summary>
    /// 

    //Public Class MainWindow
    public partial class MainWindow : Window
    {
        //Public Connstructor of MainWindowClass
        public MainWindow()
        {
            //Method InitializeComponent
            InitializeComponent();
        }

        //Loaded event of Window_Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {           
            /* This event is checked and if the first startup after installation and if the specified database file to 
             * internal CheckFileExist method validations that are in the class exists, 
             * otherwise the user is prompted with a message box if you want to create the file. sdf */
            if (Properties.Settings.Default.path.Equals("PrimoAvvio") || Validations.CheckFirstFileExist().Equals(true))
            {
                // Call the method CrteateFirstDataBase
                DataBaseManagement.CreateFirstDataBase();
            }

            /*ChangeContentRadioButton method is called after loading the Form FrmSearch and verification 
             * which is currently selected in the culture and operating system using the CultureInfo class, 
             * are supported in the project two cultures, English and Italian.
             */
            FrmMainInitializingApplication.ChangeItemComboBox(dgvMain.Children.OfType<ComboBox>().ToArray());
            FrmMainInitializingApplication.ChangeContentButton(dgvMain.Children.OfType<Button>().ToArray());
            FrmMainInitializingApplication.ChangeContentLabel(dgvMain.Children.OfType<Label>().ToArray());
            FrmMainInitializingApplication.ChangeHeaderText(dgvMain.Children.OfType<DataGrid>().ToArray());
        }

        //Click event of btn_Load
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            /*Always using the method CheckFileExist check if the file exists DataBase, 
             * if you populate the DataGrid in dgvDati and dgvJob using queries that found in the methods and LaodData LoadJobData that found in the class                          * DataBaseManagement*/
            if (Validations.CheckFileExist().Equals(false))
            {
                dgvDati.ItemsSource = DataBaseManagement.LoadData().ItemsSource;
                dgvjob.ItemsSource = DataBaseManagement.LoadJobData().ItemsSource;
            }
        }

        //Click event of btn_Insert
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            /*Always using the method CheckFileExist check if the file exists DataBase, 
             * more by the method CheckTextBoxEmpty verify that all objects TextBox and ComboBox also been colpilati properly, 
             * to avoid leaving empty fields on the tables, if they are not filled in all the 'you will be warned via a messagebox.             
             */
            if (Validations.CheckFileExist().Equals(false) && (Validations.CheckTextBoxEmpty(txtName.Text, txtSurname.Text, txtAddress.Text, txtZipCode.Text, txtCity.Text,
               cbxState.Text,cbxActivity.Text).Equals(false)))

            {
                /*I call the method InsertData the static class DataBaseManagement passing as arguments the content of the TextBox and ComboBox for the insertion of a                  *new user in the tables.
                 */
                DataBaseManagement.InsertData(txtName.Text, txtSurname.Text, txtAddress.Text, txtZipCode.Text, txtCity.Text, cbxState.Text, cbxActivity.Text);
            }
        }

        //Click event of btnDelete
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            /*Always using the method CheckFileExist check if the file exists DataBase, 
             * more by the method CheckTextBoxForDelete verify that all objects TextBox and ComboBox also been colpilati properly before proceeding with the deletion               *of data, if they are not all completed the user will warned via a messagebox.
             */
            if (Validations.CheckFileExist().Equals(false) && (Validations.CheckTextBoxForDelete(txtName.Text,txtSurname.Text).Equals(false)))
            {
                /*I call the method DeleteData the static class DataBaseManagement passing as arguments the content of the TextBox and ComboBox for to delete the                       * specific user in the tables.
                 */
                DataBaseManagement.DeleteData(txtName.Text,txtSurname.Text);
            }
        }

        //Click event of btnUpdate
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            /*Always using the method CheckFileExist check if the file exists DataBase, 
             * more by the method CheckTextBoxEmpty verify that all objects TextBox and ComboBox also been colpilati properly, 
             * to avoid leaving empty fields on the tables, if they are not filled in all the 'you will be warned via a messagebox.             
             */
            if (Validations.CheckFileExist().Equals(false) && (Validations.CheckTextBoxEmpty(txtName.Text, txtSurname.Text, txtAddress.Text, txtZipCode.Text, txtCity.Text,
               cbxState.Text, cbxActivity.Text).Equals(false)))
            {
                /*I call the method InsertData the static class DataBaseManagement passing as arguments the content of the TextBox and ComboBox for to update                           * the current user in the tables.
                 */
                DataBaseManagement.UpdateData(txtName.Text, txtSurname.Text, txtAddress.Text, txtZipCode.Text, txtCity.Text, cbxState.Text, cbxActivity.Text);
            }
        }

        //Click event of btnCreateDataBase
        private void btnCreateDataBase_Click(object sender, RoutedEventArgs e)
        {
            //Call method CreateNewDataBase
            DataBaseManagement.CreateNewDataBase();
        }

        //Click event of btnConnectDataBase
        private void btnConnectDataBase_Click(object sender, RoutedEventArgs e)
        {
            //Call method ConnectDataBase
            DataBaseManagement.ConnectDataBase();
        }

        //Click event of btnSearch
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            /*Always using the method CheckFileExist check if the file exists DataBase, 
             *if the file exists I declare a new instance of Florm FrmSearch and visualize user 
             */
            if (Validations.CheckFileExist().Equals(false))
            {
                var search = new Search();
                search.Owner = this;
                search.ShowDialog();
            }
        }

        //Click event of btnSearch
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //Close Application PrintPreview
            App.Current.Shutdown();
        }
    }
}
