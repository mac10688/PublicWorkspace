using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MyScheduleAppWP7v1
{
    public partial class AddEventPage : PhoneApplicationPage
    {
        public AddEventPage()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Event evnt = new Event();

            evnt.EventID = 0;//to be set in the DB class
            evnt.EventName = TextBoxEventName.Text.ToString();
            evnt.EventPlace = TextBoxPlace.Text.ToString();
            try
            {
                evnt.DateFrom = new DateTime(int.Parse(TextBoxFromYear.Text.ToString()),
                                                int.Parse(TextBoxFromMonth.Text.ToString()),
                                                int.Parse(TextBoxFromDay.Text.ToString()),
                                                int.Parse(TextBoxFromHour.Text.ToString()),
                                                int.Parse(TextBoxFromMinute.Text.ToString()),
                                                0);

                evnt.DateTo = new DateTime(int.Parse(TextBoxToYear.Text.ToString()),
                                                int.Parse(TextBoxToMonth.Text.ToString()),
                                                int.Parse(TextBoxToDay.Text.ToString()),
                                                int.Parse(TextBoxToHour.Text.ToString()),
                                                int.Parse(TextBoxToMinute.Text.ToString()),
                                                0);

                DatabaseClass databaseClass = new DatabaseClass();

                if (databaseClass.AddEvent(evnt))
                {
                    MessageBox.Show("Event added successfully!");

                    NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative)); //when navigating to PivotPage1, the UI will
                    // be automaticlally updated
                }
                else
                {
                    MessageBox.Show("Error occured when trying to add event to Database!");
                }
            }
            catch (Exception exc) { MessageBox.Show("Error in DateTime format!" + exc.ToString()); }
        }
    }
}