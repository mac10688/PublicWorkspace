//Call dll netFramework 4.0
using PrintPreview.DataBase;
using System.Linq;
using System.Windows.Forms;

//PrtintPreview project
namespace PrintPreview.Management
{
    //Static class DataBaseManagement
    public static class DataBaseManagement
    {
        /*This method is invoked when you first start the application ,
         * and through a messagebox asking you if you want to create a database file. sdf
         * If the user decides to create the file will create an instance of the class ContactDataContext 
         * with the corresponding parameter of the path given by the FileName property of the control SaveFileDialog 
         * for connecting and using the method CreateDatabase will create the Database with related tables mapped i
         * nside of the file Contact.dbml of LinqToSql.
         * Will be valued the variable path and settings saved and passed as a parameter each 
         * time and request connection to the Database Created
         */
        public static void CreateFirstDataBase()
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "File sdf|*.sdf";


            if (System.Windows.Forms.MessageBox.Show(string.Format("{0}{1}{2}{3}{4}", "File",
                    "  ", Properties.Settings.Default.path, "  ", "not found ,want to create the file?"),
                     System.Windows.Forms.Application.ProductName.ToString(), MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question).Equals(System.Windows.Forms.DialogResult.Yes) &&
                dialog.ShowDialog().Equals(System.Windows.Forms.DialogResult.OK))
            {
                using (var ctx = new ContactDataContext(dialog.FileName))
                {
                    ctx.CreateDatabase();
                    Properties.Settings.Default.path = dialog.FileName;
                    Properties.Settings.Default.Save();
                }
            }
        }

        /*This method and is nearly similar to the previous method, except that the user can decide when to create a new database, 
         * this method is not called the first time.
         */
        public static void CreateNewDataBase()
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "File sdf|*.sdf";
            var dialogresult = dialog.ShowDialog();

            if (dialogresult.Equals(System.Windows.Forms.DialogResult.Cancel)) return;

            if (dialogresult.Equals(System.Windows.Forms.DialogResult.OK) && (!System.IO.File.Exists(dialog.FileName)))
            {
                using (var ctx = new ContactDataContext(dialog.FileName))
                {
                    ctx.CreateDatabase();
                    Properties.Settings.Default.path = dialog.FileName;
                    Properties.Settings.Default.Save();
                }
                return;
            }

            System.Windows.Forms.MessageBox.Show(string.Format("{0}{1}{2}{3}{4}{5}", "File", "  "
                , dialog.FileName, "  ", "already exsist", "  ", "choose a different name"));
        }

        /*This method using an OpenFileDialog control allows you to connect to a File .Sdf 
         * and enhances the path variable settings so that it is available for all interactions 
         * with the database that you performed and the connection
         */
        public static void ConnectDataBase()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "File sdf|*.sdf";
            var dialogresult = dialog.ShowDialog();

            if (dialogresult.Equals(System.Windows.Forms.DialogResult.Cancel)) return;

            if (dialogresult.Equals(System.Windows.Forms.DialogResult.OK))
            {
                System.Windows.Forms.MessageBox.Show(string.Format("{0}{1}{2}{3}{4}", "Connecting to the database", "  ", dialog.FileName, "  ", "successful.",
                    Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information));
                Properties.Settings.Default.path = dialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        /*This method of type DataGrid, using code ctx.PERSON; select all data from the DataBase of the Person table 
         * and returns a datagrid with its property ItemSource.
         */
        public static System.Windows.Controls.DataGrid LoadData()
        {
            var dgvDati = new System.Windows.Controls.DataGrid();

            using (var ctx = new ContactDataContext(Properties.Settings.Default.path))
            {
                var selectperson = ctx.PERSON;
                dgvDati.ItemsSource = selectperson;
            }

            return dgvDati;
        }

        /*This method of type DataGrid, using code ctx.JOB; select all data from the DataBase of the job table 
         * and returns a datagrid with its property ItemSource.
         */
        public static System.Windows.Controls.DataGrid LoadJobData()
        {
            var dgvDati = new System.Windows.Controls.DataGrid();

            using (var ctx = new ContactDataContext(Properties.Settings.Default.path))
            {
                var selectjob = ctx.JOB;
                dgvDati.ItemsSource = selectjob;
            }

            return dgvDati;
        }

        /*This method means the method InsertOnSubmit status insert data into a pending state, 
         * then the method SubmitChanges performs the necessary changes within the database, this method requires the necessary arguments for entering data, 
         * all the while using the class that exposes all ContactDataContext methods 
         * needed in the iteration with the data as we shall see in subsequent methods.
         */
        public static void InsertData(string name, string surname, string address, string zipcode, string city, string state, string activity)
        {
            using (var ctx = new ContactDataContext(Properties.Settings.Default.path))
            {
                var newperson = new PERSON
                {
                    NAME = name.ToUpper(),
                    SURNAME = surname.ToUpper(),
                    ADDRESS = address.ToUpper(),
                    ZIPCODE = zipcode.ToUpper(),
                    CITY = city.ToUpper()
                };

                ctx.PERSON.InsertOnSubmit(newperson);
                ctx.SubmitChanges();


                var newjob = new JOB
                {
                    IDPERSON = newperson.ID,
                    STATE = state,
                    ACTIVITY = activity
                };

                ctx.JOB.InsertOnSubmit(newjob);
                ctx.SubmitChanges();
            }
        }

        /*This method means the method DeleteOnSubmit status delete data into a pending state, 
         * then the method SubmitChanges performs the necessary changes within the database, this method requires the necessary arguments for deleting data, 
         * all the while using the class that exposes all ContactDataContext methods 
         * needed in the iteration with the data as we shall see in subsequent methods.
         * Is then performed using a foreach loop iteration variable iddeletejob and will be eliminated on all data that 
         * satisfy the predicate in the Where operator, for both the table job for the person table.
         */
        public static void DeleteData(string name, string surname)
        {
            using (var ctx = new ContactDataContext(Properties.Settings.Default.path))
            {
                try
                {
                    var ideletejob = ctx.PERSON.Where(w => w.NAME.Equals(name) && w.SURNAME.Equals(surname));

                    foreach (var item in ideletejob.ToList())
                    {
                        var deletejob = ctx.JOB.Where(w => w.IDPERSON.Equals(item.ID));

                        if (!deletejob.Any()) return;
                        ctx.JOB.DeleteOnSubmit(deletejob.First());

                        var deleteperson = ctx.PERSON
                            .Where(w => w.NAME.Equals(name) && w.SURNAME.Equals(surname));

                        if (!deleteperson.Any()) return;

                        ctx.PERSON.DeleteOnSubmit(deleteperson.First());
                        ctx.SubmitChanges();
                    }
                }

                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        /*This method means the method SubmitChanges performs the necessary changes within the database, 
         * this method requires the necessary arguments for the update data, all the while by ContactDataContext class that exposes all the methods needed in the               *iteration with the data, runs a foreach loop on the variable idupdateperson and updated all the data that meets the conditions 
         * of the predicate in the Where operator.
         */
        public static void UpdateData(string name, string surname, string address, string zipcode, string city, string state, string activity)
        {
            using (var ctx = new ContactDataContext(Properties.Settings.Default.path))
            {
                var idperson = ctx.PERSON.Where(w => w.NAME.Equals(name) && w.SURNAME.Equals(surname));

                foreach (var itemperson in idperson.ToList())
                {
                    var updateperson = ctx.PERSON.Where(w => w.NAME.Equals(name) && w.SURNAME.Equals(surname));

                    itemperson.NAME = name.ToUpper();
                    itemperson.SURNAME = surname.ToUpper();
                    itemperson.ADDRESS = address.ToUpper();
                    itemperson.ZIPCODE = zipcode.ToUpper();
                    itemperson.CITY = city.ToUpper();

                    var idjob = ctx.JOB.Where(w => w.IDPERSON.Equals(itemperson.ID));

                    foreach (var itemjob in idjob.ToList())
                    {
                        var updatejob = ctx.JOB.Where(w => w.ID.Equals(itemperson.ID));

                        itemjob.STATE = state;
                        itemjob.ACTIVITY = activity;
                    }

                    ctx.SubmitChanges();
                }
            }
        }
    }
}