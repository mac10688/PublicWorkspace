using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinkedObjectSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public MyObject top;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvas1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(canvas1);
            MyObject myObj = new MyObject(canvas1, p.X, p.Y, top);
            top = myObj;
        }
    }
}
