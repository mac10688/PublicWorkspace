//Call dll netFramework 4.0
using PrintPreview.Class;
using PrintPreview.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

//PrtintPreview project
namespace PrintPreview
{
    /// <summary>
    /// Logic for interaction MainWindow.xaml
    /// </summary>
    /// 

    //Public Class Search
    public partial class Search : Window
    {
        //Public Connstructor of Search
        public Search()
        {
            //Method InitializeComponent
            InitializeComponent();
        }

        //Loaded event of Window_Loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*ChangeContentRadioButton method is called after loading the Form FrmSearch and verification 
             * which is currently selected in the culture and operating system using the CultureInfo class, 
             * are supported in the project two cultures, English and Italian.
             */
            FrmSearchInitializingApplication.ChangeContentRadioButton(dgvSearch.Children.OfType<RadioButton>().ToArray());
            FrmSearchInitializingApplication.ChangeContentCheckBox(dgvSearch.Children.OfType<CheckBox>().ToArray());
            FrmSearchInitializingApplication.ChangeContentButton(dgvSearch.Children.OfType<Button>().ToArray());
        }

        //Click event of btnFind
        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            /*This Linq query performs a search based on what the user selects the Search form, 
             * the form includes three RadioButton and CheckBox controls sixteen, 
             * first of all check if the user has selected at least one RadioButton and one or more checkboxes, 
             * otherwise it will be perceived from a messagebox.
             * Next check out what has been selected, this is by LinqToObjects query, 
             * first retrieves the name of the selected RadioButton control and the second the name or names of the selected checkboxes, 
             * which is becoming the operator and Where the predicate inside.

             *This query and the search for or interested in the tasks assigned to each person.

                         var result = ctx.GetTable <Job> ()
                         . Where (w => w.ACTIVITY.Equals (_activity.Content.ToString (). ToUpper ()) && w.STATE.Equals (_state.ToUpper ()))
                         . Join (ctx.PERSON, job => job.ID, cust => cust.ID, (job, name) => new {name.NAME, name.SURNAME, name.ADDRESS, name.ZIPCODE, name.CITY} )
                         . OrderBy (a => a.SURNAME)
                         . Distinct ()
                         . ToList ();

             *A check is performed on the Job table if there are people who work a year and a corresponding duty, 
             *will join the two tables placed in the Job and person using the ID field will be extracted and all the information 
             *of the person or persons who fulfill the conditions specified in Where previous predicate operator, 
             *then using the OrderBy operator will be sorted in ascending according to the specified predicate, 
             *in this case by name, will be eliminated any double occurrences, and this task Distinct operator, 
             *he will remove all occurrences double and the method ToList convert the result of the query 
             *that will anominustype type in a list and we'll look at why
             */
            if (Validations.ChechBoxAndRadioButtonChecked(dgvSearch) < 2)
            {
                return;
            }

            var print = new PreviewDialog();
            var _state = string.Empty;

            using (var ctx = new ContactDataContext(Properties.Settings.Default.path))
            {              
                foreach (var myRadioButton in dgvSearch.Children.OfType<RadioButton>().Where(myRadioButton => myRadioButton.IsChecked.Equals(true)))
                {
                   _state = myRadioButton.Content.ToString();
                }

                foreach (var myCheckBox in dgvSearch.Children.OfType<CheckBox>().Where(myCheckBox => myCheckBox.IsChecked.Equals(true)))
                {
                    var _activity = myCheckBox;
                    var result =  ctx.GetTable<JOB>()
                        .Where(w =>w.ACTIVITY.Equals(_activity.Content.ToString().ToUpper()) && w.STATE.Equals(_state.ToUpper()))
                        .Join( ctx.PERSON, job => job.ID, cust => cust.ID,(job, name) => new  {name.NAME, name.SURNAME, name.ADDRESS, name.ZIPCODE, name.CITY })
                        .OrderBy(a => a.SURNAME)
                        .Distinct()
                        .ToList();

                    foreach (var item in result)
                    {
                        /*The method of the class LoadData PreviewDialog populates a list of such Persons passing all the data found by the search query, 
                         * which is why we converted the result of the query in a list, in the class PreviewDialog will find the list of 
                         * such person and the method LoadData
                         */
                        print.LoadData(item.NAME, item.SURNAME, item.ADDRESS, item.ZIPCODE, item.CITY);
                    }
                }
                print.ShowDialog();
            }
        }

        //Click event of btnClose
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }    
}