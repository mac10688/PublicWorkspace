﻿﻿﻿// Houssem Dellai    
// houssem.dellai@ieee.org    
// +216 95 325 964    
// Studying Software Engineering    
// in the National Engineering School of Sfax (ENIS)   

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Phone.Controls;

namespace MyScheduleAppWP7v1
{
    public partial class PivotPage1 : PhoneApplicationPage
    {

        DatabaseClass databaseClass = new DatabaseClass();
        int selectedEventId = -1;
        List<Event> eventsListPerDay;

        public PivotPage1()
        {
            InitializeComponent();
            ShowEvents();
        }

        private void ShowEvents()
        {
            IList<Event> eventsList = databaseClass.GetEventsList();

            //eventsListPerDay = TransformToEventsListPerDay(eventsList);
            IEnumerable<Event> queryeventsListPerDay = eventsList.OrderBy(evt => evt.DateFrom);
            eventsListPerDay = queryeventsListPerDay.ToList();

            string[] Month = { "Jan", "Fev", "Mar", "Avr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            DateTime ThisDay = eventsListPerDay[0].DateFrom;

            //create panoramaItem and the ListBox
            List<ListBox> Listlistbox = new List<ListBox>();
            Listlistbox.Add(new ListBox());

            List<PivotItem> Listpivotitem = new List<PivotItem>();
            Listpivotitem.Add(new PivotItem());
            Listpivotitem[0].Header = ThisDay.DayOfWeek.ToString().Substring(0, 3)
                                          + "," + Month[ThisDay.Month - 1]
                                          + " " + ThisDay.Day.ToString();

            Listpivotitem[0].Content = Listlistbox[0];
            pivotControl.Items.Add(Listpivotitem[0]);

            int listboxindex = 0;

            for (int i = 0; i < eventsListPerDay.Count; i++)// Event evnt in eventsListPerDay)
            {
                //look for events of today from EventsList
                Event evnt = eventsListPerDay[i];

                TextBlock textBlockHour = new TextBlock();
                textBlockHour.Text = evnt.DateFrom.Hour.ToString()
                                     + ":" + evnt.DateFrom.Minute.ToString()
                                     + " to " + evnt.DateTo.Hour.ToString()
                                     + ":" + evnt.DateTo.Minute.ToString();
                textBlockHour.Foreground = new SolidColorBrush(Colors.Magenta);
                textBlockHour.FontSize = 20;

                TextBlock textBlockNameAndPlace = new TextBlock();
                textBlockNameAndPlace.Text = evnt.EventName.ToString() + "\n " + evnt.EventPlace.ToString();
                textBlockNameAndPlace.Foreground = new SolidColorBrush(Colors.White);
                textBlockNameAndPlace.FontSize = 20;

                StackPanel stackPanel1 = new StackPanel();
                stackPanel1.Width = 311;
                stackPanel1.Children.Add(textBlockHour);
                stackPanel1.Children.Add(textBlockNameAndPlace);

                Button button = new Button();
                button.Background = new SolidColorBrush(Colors.Red);
                button.Height = 100;
                button.Width = 90;
                button.BorderThickness = new Thickness(0, 0, 0, 0);
                button.Margin = new Thickness(0, 0, 9, 0);
                button.Name = eventsListPerDay[i].EventID.ToString();
                button.Click += new RoutedEventHandler(button_Click);

                StackPanel stackPanel2 = new StackPanel();
                stackPanel2.Orientation = System.Windows.Controls.Orientation.Horizontal;
                stackPanel2.Children.Add(button);
                stackPanel2.Children.Add(stackPanel1);

                if (evnt.DateFrom.Day == ThisDay.Day)
                {
                    Listlistbox[listboxindex].Items.Add(stackPanel2);
                }

                else
                {
                    listboxindex++;
                    ThisDay = eventsListPerDay[i].DateFrom;
                    i--;

                    Listpivotitem.Add(new PivotItem());
                    Listpivotitem[listboxindex].Header = ThisDay.DayOfWeek.ToString().Substring(0, 3)
                                          + "," + Month[ThisDay.Month - 1]
                                          + " " + ThisDay.Day.ToString();
                    Listlistbox.Add(new ListBox());
                    Listpivotitem[listboxindex].Content = Listlistbox[listboxindex];

                    pivotControl.Items.Add(Listpivotitem[listboxindex]);
                }
            }
        }

       
        private void AddEvent_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddEventPage.xaml", UriKind.Relative));
        }

        private void EditEvent_Click(object sender, EventArgs e)
        {
            if (selectedEventId == -1)//no item selected
            {
                MessageBox.Show("Select an event please !");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to edit this event ?",
                                                            "Alert",
                                                            MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {

                    NavigationService.Navigate(new Uri("/EditEventPage.xaml", UriKind.Relative));
                }
                else
                {
                    //when cancel, unselect the selected button
                    Button btn = new Button();
                    btn = (Button)FindName(selectedEventId.ToString());
                    btn.Background = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void DeleteEvent_Click(object sender, EventArgs e)
        {

            if (selectedEventId == -1)//no item selected
            {
                MessageBox.Show("Select an event please !");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this event ?", 
                                                            "Alert", 
                                                            MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {

                    if (databaseClass.DeleteEvent(selectedEventId))
                    {
                        MessageBox.Show("Event deleted successfully!");
                        Refresh_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("There were an error when trying to delete!");
                    }
                }
                else
                {
                    //when cancel, unselect the selected button
                    Button btn = new Button();
                    btn = (Button) FindName(selectedEventId.ToString());
                    btn.Background = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            // clear the UI
            int l = pivotControl.Items.Count;
            for(int i=0; i<l; i++)
            {
                pivotControl.Items.RemoveAt(0);
            }

            //show the events
            ShowEvents();
        }

        public void button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationBar.Mode = Microsoft.Phone.Shell.ApplicationBarMode.Default;
            Button btn = (Button)sender;
            btn.Background = new SolidColorBrush(Colors.Yellow);
            selectedEventId = int.Parse(btn.Name.ToString());
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Content is EditEventPage)
            {
                //get the event with the specified ID
                Event vnt = new Event();
                foreach(Event ev in eventsListPerDay)
                {
                    if (ev.EventID == selectedEventId)
                    {
                        vnt = ev;
                        break;
                    }
                }

                //pass the event to the EditEventPage
                (e.Content as EditEventPage).evntToEdit = vnt;
            }
        }	
    }
}