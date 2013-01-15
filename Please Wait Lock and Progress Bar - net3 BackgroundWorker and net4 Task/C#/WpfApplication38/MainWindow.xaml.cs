using System;
using System.Windows;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApplication38
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        bool _Section1Locked;
        public bool Section1Locked
        {
            get
            {
                return _Section1Locked;
            }
            set
            {
                if (_Section1Locked != value)
                {
                    _Section1Locked = value;
                    RaisePropertyChanged("Section1Locked");
                }
            }
        }

        bool _Section2Locked;
        public bool Section2Locked
        {
            get
            {
                return _Section2Locked;
            }
            set
            {
                if (_Section2Locked != value)
                {
                    _Section2Locked = value;
                    RaisePropertyChanged("Section2Locked");
                }
            }
        }


        double _Progress1;
        public double Progress1
        {
            get
            {
                return _Progress1;
            }
            set
            {
                if (_Progress1 != value)
                {
                    _Progress1 = value;
                    RaisePropertyChanged("Progress1");
                }
            }
        }

        double _Progress2;
        public double Progress2
        {
            get
            {
                return _Progress2;
            }
            set
            {
                if (_Progress2 != value)
                {
                    _Progress2 = value;
                    RaisePropertyChanged("Progress2");
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Section1Locked = true;

            var bgw = new BackgroundWorker { WorkerReportsProgress = true };
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            bgw.RunWorkerAsync();
        }

        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress1 = e.ProgressPercentage;
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgw = sender as BackgroundWorker;
            for(var a=0; a < 10; a++)
                {
                    Thread.Sleep(500);
                    bgw.ReportProgress(a * 10);
                }
            e.Result = "MEGA";
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Section1Locked = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Section2Locked = true;
            Task.Factory.StartNew(() => 
            {
                for(var a=0; a < 10; a++)
                {
                    Thread.Sleep(500);
                    Progress2 = a * 10;
                }
            })
            .ContinueWith(ret =>
                {
                    Section2Locked = false;
                });
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
