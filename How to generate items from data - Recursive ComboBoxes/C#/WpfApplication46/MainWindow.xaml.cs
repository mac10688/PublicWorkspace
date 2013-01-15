using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WpfApplication46
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MyViewModel();
        }

        public class MyViewModel
        {
            public class TypeModel
            {
                public string Name { get; set; }
                public ObservableCollection<TypeModel> Fields { get; set; }
                public bool HasChildren
                {
                    get { return (Fields != null && Fields.Count > 0); }
                }
            }
            
            public ObservableCollection<TypeModel> Types { get; set; }

            public MyViewModel()
            {
                Types = new ObservableCollection<TypeModel>();
                for (var a = 0; a < 5; a++)
                {
                    var lvl1 = new TypeModel { Name = "Type " + a, Fields = new ObservableCollection<TypeModel>() };
                    for (var b = 0; b < 5; b++)
                    {
                        var lvl2 = new TypeModel { Name = lvl1.Name + "." + b, Fields = new ObservableCollection<TypeModel>() };
                        for (var c = 0; c < 5; c++)
                        {
                            var lvl3 = new TypeModel { Name = lvl2.Name + "." + c, Fields = new ObservableCollection<TypeModel>() };
                            for (var d = 0; d < 5; d++)
                                lvl3.Fields.Add(new TypeModel { Name = lvl3.Name + "." + d, Fields = new ObservableCollection<TypeModel>() });
                            lvl2.Fields.Add(lvl3);
                        }
                        lvl1.Fields.Add(lvl2);
                    }
                    Types.Add(lvl1);
                }
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as TextBlock;
            txtResult.Text = "Selected: " + tb.Text;
        }
    }
}
