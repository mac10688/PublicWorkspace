//Call dll netFramework 4.0
using System.IO;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Linq;
using System.Globalization;

using PrintPreview.Resources;

//PrtintPreview project
namespace PrintPreview.Class
{
    //Static class Validations
    static class Validations
    {
        /*This method checks whether the database file. Sdf in the location specified by the parameter assigned to the Exist method, 
         * returns true if the file exists and false if it already exists a file. Sdf in the path specified.
         */
        public static bool CheckFirstFileExist()
        {           
            var result = false;

            if (!File.Exists(PrintPreview.Properties.Settings.Default.path))
            {
                result = true;
            }

            else
            {
                result = false;
            }
            return result;
        }

        /*This method checks if the file specified as a parameter to the method Exist () exists, 
         *otherwise the user will be warned by a messagebox
         *If the file does not exist result is true, otherwise false
         */
        public static bool CheckFileExist()
        {
            var result = false;
            var cultureinfoIt = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");
            var cultureinfoEn = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            if (!File.Exists(PrintPreview.Properties.Settings.Default.path))
            {
                if (System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfoEn))
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("{0}{1}{2}{3}{4}", MessageEn.ValidationsChechFileExist, "  ",
                             Properties.Settings.Default.path, "  ", MessageEn.ValidationsChechFileExist1),
                             System.Windows.Forms.Application.ProductName.ToString(CultureInfo.InvariantCulture), MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                    result = true;                 
                }

                if (System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfoIt))
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("{0}{1}{2}{3}{4}", MessageIt.ValidationsChechFileExist, "  ",
                             Properties.Settings.Default.path, "  ", MessageIt.ValidationsChechFileExist1),
                             System.Windows.Forms.Application.ProductName.ToString(CultureInfo.InvariantCulture), MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                    result = true;
                }

            }

            else
            {
                result = false;
            }
            return result;
        }

        /*This method ensures that there is at least one control and one or more controls ReadioButton checkbox selected, 
         * otherwise the search will be performed and the user will be warned by a messagebox, 
         * the interesting piece of code and data from the use of LinqToObjects, and by 'where operator also called operator              
         * of restriction, which filters a sequence of values ​​on the basis of a predicate. 
         * In our case the predicate and verify if a RadioButton control or checkboxes are selected.
         * The end result of this method and an int value which means how many checks have been selected
         */
        public static int ChechBoxAndRadioButtonChecked(Grid dgv)
        {
            var radiobuttonselect = dgv.Children.OfType<System.Windows.Controls.RadioButton>().Where(w => w.IsChecked.Equals(true)).Count();
            var checkboxselect = dgv.Children.OfType<System.Windows.Controls.CheckBox>().Where(w => w.IsChecked.Equals(true)).Count();

            var cultureinfoIt = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");
            var cultureinfoEn = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            if (radiobuttonselect.Equals(0) || checkboxselect.Equals(0))
            {
                if (System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfoEn))
                {
                    System.Windows.Forms.MessageBox.Show(MessageEn.ValidationsChechBoxAndRadioButtonChecked,
                        Application.ProductName.ToString(CultureInfo.InvariantCulture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfoIt))
                {
                    System.Windows.Forms.MessageBox.Show(MessageIt.ValidationsChechBoxAndRadioButtonChecked,
                        Application.ProductName.ToString(CultureInfo.InvariantCulture), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return radiobuttonselect + checkboxselect;
        } 

        /*This method simply checks if the user has enhanced all the required fields for editing and entering data in the DataBase, 
         * if only one of the fields has not been exploited, the user is notified with a MessageBox
         */
        public static bool CheckTextBoxEmpty(string txtname, string txtsurname, string txtaddress, string txtzipcode, string txtcity,string cbxstate,string cbxactivity)
        {
            var result = false;

            var cultureinfoIt = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");
            var cultureinfoEn = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            if (string.IsNullOrEmpty(txtname) || string.IsNullOrEmpty(txtsurname) || string.IsNullOrEmpty(txtaddress)
                || string.IsNullOrEmpty(txtzipcode) || string.IsNullOrEmpty(txtcity) 
                || string.IsNullOrEmpty(cbxstate) || string.IsNullOrEmpty(cbxactivity))
            {

                var cultureinfo = System.Globalization.CultureInfo.CurrentCulture;

                if (!System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfoEn))
                {
                    System.Windows.Forms.MessageBox.Show(MessageEn.ValidationsCheckTextBoxEmpty, Application.ProductName.ToString(CultureInfo.InvariantCulture),
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    result = true;
                }

                if (System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfoIt))
                {
                    System.Windows.Forms.MessageBox.Show(MessageIt.ValidationsCheckTextBoxEmpty, Application.ProductName.ToString(CultureInfo.InvariantCulture),
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    result = true;
                }
            }
            return result;
        }

        /*This method simply checks if the user has enhanced all the required fields for elimination data in the DataBase, 
         * if only one of the fields has not been exploited, the user is notified with a MessageBox
         */
        public static bool CheckTextBoxForDelete(string txtname, string txtsurname)
        {
            var result = false;

            var cultureinfoIt = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");
            var cultureinfoEn = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            if (string.IsNullOrEmpty(txtname) || string.IsNullOrEmpty(txtsurname))
            {
                if (!System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfoEn))
                {
                    System.Windows.Forms.MessageBox.Show(MessageEn.ValidationsCheckTextBoxForDelete, Application.ProductName.ToString(CultureInfo.InvariantCulture),
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    result = true;
                }

                if (System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfoIt))
                {
                    System.Windows.Forms.MessageBox.Show(MessageIt.ValidationsCheckTextBoxForDelete, Application.ProductName.ToString(CultureInfo.InvariantCulture),
                         MessageBoxButtons.OK, MessageBoxIcon.Error);

                    result = true;
                }
            }
            return result;
        }
    }
}