using System;
using Microsoft.Phone.Controls;

namespace MyScheduleAppWP7v1
{

    // Because you may need to use this project as a part of another big one,
    // I left the MainPage empty
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            NavigationService.Navigate(new Uri("/PivotPage1.xaml"));
        }
    }
}