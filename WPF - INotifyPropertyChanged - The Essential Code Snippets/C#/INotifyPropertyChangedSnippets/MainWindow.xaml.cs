using System.Windows;
using INotifyPropertyChangedSnippets.View;

namespace INotifyPropertyChangedSnippets
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Wiring the ViewModel into the View
            DataContext = new MainViewModel();
        }
    }
}
