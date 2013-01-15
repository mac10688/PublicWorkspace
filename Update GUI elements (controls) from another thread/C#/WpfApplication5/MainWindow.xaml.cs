using System;
using System.Windows;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace WpfApplication5
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        string _LabelContent;
        public string LabelContent
        {
            get
            {
                return _LabelContent;
            }
            set
            {
                if (_LabelContent != value)
                {
                    _LabelContent = value;
                    RaisePropertyChanged("LabelContent");
                }
            }
        }

        public ObservableCollection<string> ListItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ListItems = new ObservableCollection<string>();
            DataContext = this;

            Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        var item = DateTime.Now.ToString();

                        //Objects can be updated directly
                        LabelContent = item;

                        //in .net 3.5 Collection needs UI update, so use Dispatcher
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                            {
                                ListItems.Add(item);
                            }));
                    }
                });
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
