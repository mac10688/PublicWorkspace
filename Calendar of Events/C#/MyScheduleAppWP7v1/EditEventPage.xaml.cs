using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace MyScheduleAppWP7v1
{
    public partial class EditEventPage : PhoneApplicationPage
    {

        public Event evntToEdit;

        public EditEventPage()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            //edit the event
            Event evnt = new Event();

            evnt.EventID = evntToEdit.EventID;
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

                if (databaseClass.EditEvent(evnt))
                {
                    MessageBox.Show("Event edited successfully!");
                }

                NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative)); //when navigating to PivotPage1, the UI will
                // be automaticlally updated
            }
            catch (Exception exc) { MessageBox.Show("Error in DateTime format!" + exc.ToString()); }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //view the event to edit
            TextBoxEventName.Text = evntToEdit.EventName;
            TextBoxPlace.Text = evntToEdit.EventPlace;

            TextBoxFromYear.Text   = evntToEdit.DateFrom.Year.ToString();
            TextBoxFromMonth.Text  = evntToEdit.DateFrom.Month.ToString();
            TextBoxFromDay.Text    = evntToEdit.DateFrom.Day.ToString();
            TextBoxFromHour.Text   = evntToEdit.DateFrom.Hour.ToString();
            TextBoxFromMinute.Text = evntToEdit.DateFrom.Minute.ToString();

            TextBoxToYear.Text   = evntToEdit.DateTo.Year.ToString();
            TextBoxToMonth.Text  = evntToEdit.DateTo.Month.ToString();
            TextBoxToDay.Text    = evntToEdit.DateTo.Day.ToString();
            TextBoxToHour.Text   = evntToEdit.DateTo.Hour.ToString();
            TextBoxToMinute.Text = evntToEdit.DateTo.Minute.ToString();

            //Id is not to be viewed
        }
    }
}