//Call dll netFramework 4.0
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6;

//Call NameSpace PrintPreviewClass
using PrintPreview.Class;
//Call NameSpace PrintPreviewResources
using PrintPreview.Resources;

//PrtintPreview project
namespace PrintPreview
{
    /// <summary>
    /// Logic for interaction MainWindow.xaml
    /// </summary>
    /// 

    //Public Class PrevievDialog
    public partial class PreviewDialog : Window
    {
        /*List of type Person, this class is used to load all the occurrences found during the execution of Linq query search.*/
        List<Person> Persons = new List<Person>();
        //number of line of ListBox Control
        int righe = 0;
        // CurrentPage number
        int PageNumber = 0;
        // TotalPage number
        int PageNumbers = 0;
        // index for searching the text between the lines
        int valoren = 0;

        // Constructor of the class PreviewDialog
        public PreviewDialog()
        {
            // Call method InitializeComponent
            InitializeComponent();
        }

        /*This method enhances the list of type Person with the results of research through queries so that they are then visible to the user for selection and                 *printing data.*/
        public void LoadData(string name, string surname, string address, string zipcode, string city)
        {
            Persons.Add(new Person { Name = name, SurName = surname, Address = address, ZipCode = zipcode, City = city });
        }

        //Loaded event of PreviewDialog_Loaded
        private void PreviewDialog_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            /*ChangeContentRadioButton method is called after loading the Form FrmSearch and verification 
             * which is currently selected in the culture and operating system using the CultureInfo class, 
             * are supported in the project two cultures, English and Italian.
             */
            FrmPrintPreviewInitializingApplication.ChangeContentButton(dgvPreviewDialog.Children.OfType<System.Windows.Controls.Button>().ToArray());
            FrmPrintPreviewInitializingApplication.ChangeContentLabel(dgvPreviewDialog.Children.OfType<System.Windows.Controls.Label>().ToArray());
            FrmPrintPreviewInitializingApplication.ChangeContentTextBlock(dgvPreviewDialog.Children.OfType<System.Windows.Controls.TextBlock>().ToArray());

            var step = 1;
            PageNumber = 1;
            PageNumbers = 1;

            //First page
            //calculate number of pages
            for (var page = 0; page < Persons.Count; page++)
            {
                step += 1;

                if (step > 24)
                {
                    step = 0;
                    PageNumbers += 1;
                }
            }

            /*Displaying the total number of pages*/
            PageTextBox.Text = PageNumber.ToString() + "/" + PageNumbers.ToString();
            ToPageTextBox.Text = PageNumbers.ToString();
            /*Calling the method Preview*/
            Preview(1);
        }

        //Preview Method
        /*This method executes the display list data type of person that we have enhanced the search query using the Search class, 
         * and displays all results in a ListBox.
         */
        private void Preview(int PageNumber)        
        {
            ListBoxPreviewDialog.Items.Clear();

            var arrivo = 0;
            var itemnumber = 0;
            var n = 0;

            var lname = string.Empty;
            var lname1 = string.Empty;
            var lname2 = string.Empty;
            var codeCity = string.Empty;
            var codeCity1 = string.Empty;
            var codeCity2 = string.Empty;

            righe = 0;
            arrivo = Persons.Count;


            for (n = (PageNumber - 1) * 24 + 1; n <= arrivo; n += 3)
            {
                righe = righe + 1;
                itemnumber = n - 1;
                ListBoxPreviewDialog.Items.Add("");
                ListBoxPreviewDialog.Items.Add("");

                if ((n + 2) <= arrivo)
                {
                    lname = Persons[itemnumber].Name + " " + Persons[itemnumber].SurName;
                    lname1 = Persons[itemnumber + 1].Name + " " + Persons[itemnumber + 1].SurName;
                    lname2 = Persons[itemnumber + 2].Name + " " + Persons[itemnumber + 2].SurName;
                    codeCity = Persons[itemnumber].ZipCode + " " + Persons[itemnumber].City;
                    codeCity1 = Persons[itemnumber + 1].ZipCode + " " + Persons[itemnumber + 1].City;
                    codeCity2 = Persons[itemnumber + 2].ZipCode + " " + Persons[itemnumber + 2].City;

                    ListBoxPreviewDialog.Items.Add("        " + lname.PadRight(31) + " " + lname1.PadRight(31) + " " + lname2.PadRight(31) + " ");
                    ListBoxPreviewDialog.Items.Add("        " + Persons[itemnumber].Address.PadRight(31) + " " + Persons[itemnumber + 1].Address.PadRight(31) + " " + Persons[itemnumber + 2].Address.PadRight(31) + " ");
                    ListBoxPreviewDialog.Items.Add("        " + codeCity.PadRight(31) + " " + codeCity1.PadRight(31) + " " + codeCity2.PadRight(31) + " ");

                    ListBoxPreviewDialog.FontSize = 10.5;
                    ListBoxPreviewDialog.Items.Add("");
                    ListBoxPreviewDialog.Items.Add("");
                    ListBoxPreviewDialog.FontSize = 10;


                    if (righe == 8)
                    {
                        righe = 0;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }


                if ((n + 2) > arrivo)
                {
                    if ((n + 2) > arrivo + 1)
                    {
                        lname = Persons[itemnumber].Name + " " + Persons[itemnumber].SurName;
                        codeCity = Persons[itemnumber].ZipCode + " " + Persons[itemnumber].City;
                        ListBoxPreviewDialog.Items.Add("        " + lname.PadRight(31));
                        ListBoxPreviewDialog.Items.Add("        " + Persons[itemnumber].Address.PadRight(31));
                        ListBoxPreviewDialog.Items.Add("        " + codeCity.PadRight(31));
                    }

                    if ((n + 2) == arrivo + 1)
                    {
                        lname = Persons[itemnumber].Name + " " + Persons[itemnumber].SurName;
                        lname1 = Persons[itemnumber + 1].Name + " " + Persons[itemnumber + 1].SurName;
                        codeCity = Persons[itemnumber].ZipCode + " " + Persons[itemnumber].City;
                        codeCity1 = Persons[itemnumber + 1].ZipCode + " " + Persons[itemnumber + 1].City;

                        ListBoxPreviewDialog.Items.Add("        " + lname.PadRight(31) + " " + lname1.PadRight(31));
                        ListBoxPreviewDialog.Items.Add("        " + Persons[itemnumber].Address.PadRight(35) + " " + Persons[itemnumber + 1].Address.PadRight(31));
                        ListBoxPreviewDialog.Items.Add("        " + codeCity.PadRight(31) + " " + codeCity1.PadRight(31));
                    }
                }
            }
            PageTextBox.Text = PageNumber + "/" + PageNumbers;
        }

        // Cick event of FirstButton
        private void FirstButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            //Preview the method name by invoking the home page
            Preview(1);
        }

        // Cick event of PreviousButton
        private void PreviousButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            PageNumber = PageNumber - 1;

            if (PageNumber < 1)
            {
                PageNumber = 1;
            }

            //Preview the method name by invoking the previous page
            Preview(PageNumber);
        }

        // Cick event of NextButton
        private void NextButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            PageNumber = PageNumber + 1;

            if (PageNumber > PageNumbers)
            {
                PageNumber = PageNumbers;
            }

            //Preview the method name by invoking the nextpage
            Preview(PageNumber);
        }

        // Cick event of LastButton
        private void LastButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            PageNumber = PageNumbers;

            //Preview the method name by invoking the last page
            Preview(PageNumber);
        }

        //TextGhanged event of GotoTextBox
        /*this event handles the display of scrolling to display the data in the ListBox
         */
        private void GotoTextBox_TextChanged(System.Object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(GotoTextBox.Text))
            {
                System.Windows.Forms.MessageBox.Show(MessageEn.PreviewDialogGotoTextBox_TextChanged,System.Windows.Forms.Application.ProductName.ToString(),
                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            if (double.Parse(GotoTextBox.Text) <= 1 || double.Parse(GotoTextBox.Text) <= PageNumbers)
            {
                PageNumber = int.Parse(GotoTextBox.Text);
                Preview(PageNumber);
            }
        }

        //TextChanged event of SearchTextBox
        private void SearchTextBox_TextChanged(System.Object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //reset the value of the variable Valoren
            valoren = 0;
        }

        //Click event of SearchButton
        private void SearchButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            //Call Find method
            Find();
        }

        //Find method
        /*This method searches the specified text within the list of type person and then run the display of the search string in the ListBox
         */
        private void Find()
        {
            try
            {
                var n = 0;
                var result = 0;
                var stringa = string.Empty;

                foreach (var www_loopVariable in Persons)
                {
                    var www = www_loopVariable;
                    stringa = www.Name + www.SurName + www.ZipCode + www.Address + www.City;
                    n += 1;

                    if (stringa.Contains(SearchTextBox.Text.ToUpper()))
                    {
                        result = (n / 24) + 1;
                        GotoTextBox.Text = result.ToString();
                        valoren = n;
                        SearchTextBox.Text = "";
                        return;
                    }
                }
            }

            catch (Exception ex)
            {
               System.Windows.Forms.MessageBox.Show(ex.Message,System.Windows.Forms.Application.ProductName.ToString(),MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
            }
        }

        //Click event of PrintButton
        /*This sub runs through the Printer Control PowerPacks available in the package (which must be installed to be working) 
         * to print the results displayed in the ListBox, reproducing exactly the view inside. 
         * Everything will be sent directly to the system printer (default) or a choice by the user, 
         * and can also print the PDF file if it is installed a printer for PDF files.
         */
        private void PrintButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            var prnt = new Printer();

            var arrivo = 0;
            var fine = 0;
            var itemnumber = 0;
            var n = 0;
            var numberFromPage = 0;
            var numberToPage = 0;

            var lname = string.Empty;
            var lname1 = string.Empty;
            var lname2 = string.Empty;
            var codeCity = string.Empty;
            var codeCity1 = string.Empty;
            var codeCity2 = string.Empty;

            arrivo = Persons.Count;
            fine = (int.Parse(ToPageTextBox.Text) - 1) * 24 + 24;
            righe = 0;

            prnt.FontName = "Lucida Console";
            prnt.FontSize = 10;

            if (fine > arrivo)
            {
                fine = arrivo;
            }

            if (int.TryParse(FromPageTextBox.Text, out numberFromPage).Equals(false) || int.TryParse(ToPageTextBox.Text, out numberToPage).Equals(false))
            {
               System.Windows.Forms.MessageBox.Show(MessageEn.PreviewDialogPrintButton_Click,
                   System.Windows.Forms.Application.ProductName.ToString(),MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            if (numberFromPage > numberToPage)
            {
                System.Windows.Forms.MessageBox.Show(MessageEn.PreviewDialogPrintButton_Click_1,
                   System.Windows.Forms.Application.ProductName.ToString(),MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            for (n = (int.Parse(FromPageTextBox.Text) - 1) * 24 + 1; n <= fine; n += 3)
            {
                righe = righe + 1;
                itemnumber = n - 1;
                prnt.Print("");
                prnt.Print("");

                if ((n + 2) <= arrivo)
                {
                    lname = Persons[itemnumber].Name + " " + Persons[itemnumber].SurName;
                    lname1 = Persons[itemnumber + 1].Name + " " + Persons[itemnumber + 1].SurName;
                    lname2 = Persons[itemnumber + 2].Name + " " + Persons[itemnumber + 2].SurName;
                    codeCity = Persons[itemnumber].ZipCode + " " + Persons[itemnumber].City;
                    codeCity1 = Persons[itemnumber + 1].ZipCode + " " + Persons[itemnumber + 1].City;
                    codeCity2 = Persons[itemnumber + 2].ZipCode + " " + Persons[itemnumber + 2].City;

                    prnt.Print("        " + lname.PadRight(31) + " " + lname1.PadRight(31) + " " + lname2.PadRight(31) + " ");
                    prnt.Print("        " + Persons[itemnumber].Address.PadRight(31) + " " + Persons[itemnumber + 1].Address.PadRight(31) + " " + Persons[itemnumber + 2].Address.PadRight(31) + " ");
                    prnt.Print("        " + codeCity.PadRight(31) + " " + codeCity1.PadRight(31) + " " + codeCity2.PadRight(31) + " ");

                    prnt.Print("");
                    prnt.Print("");
                    if (righe == 8) { righe = 0; prnt.NewPage(); }
                }


                if ((n + 2) > arrivo)
                {
                    if ((n + 2) > arrivo + 1)
                    {
                        lname = Persons[itemnumber].Name + " " + Persons[itemnumber].SurName;
                        codeCity = Persons[itemnumber].ZipCode + " " + Persons[itemnumber].City;
                        prnt.Print("        " + lname.PadRight(31));
                        prnt.Print("        " + Persons[itemnumber].Address.PadRight(31));
                        prnt.Print("        " + codeCity.PadRight(31));
                    }

                    if ((n + 2) == arrivo + 1)
                    {
                        lname = Persons[itemnumber].Name + " " + Persons[itemnumber].SurName;
                        lname1 = Persons[itemnumber + 1].Name + " " + Persons[itemnumber + 1].SurName;
                        codeCity = Persons[itemnumber].ZipCode + " " + Persons[itemnumber].City;
                        codeCity1 = Persons[itemnumber + 1].ZipCode + " " + Persons[itemnumber + 1].City;

                        prnt.Print("        " + lname.PadRight(31) + " " + lname1.PadRight(31));
                        prnt.Print("        " + Persons[itemnumber].Address.PadRight(31) + " " + Persons[itemnumber + 1].Address.PadRight(31));
                        prnt.Print("        " + codeCity.PadRight(31) + " " + codeCity1.PadRight(31));
                    }
                }
            }
            prnt.EndDoc();
        }
    }
}
