using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INotifyPropertyChangedSnippets.View
{
    /// <summary>
    /// This project uses the snippets shown in the attached zip. 
    /// Unzip them into your snippets folder (C:\Users\[USERNAME]\Documents\Visual Studio 2010\Code Snippets\Visual C#\My Code Snippets)
    /// </summary>

    class MainViewModel : ViewModelBase
    {
        //created by typing "propn" and pressing the Tab key
        string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName != value)                //Put breakpoint here. Hit when you type into textbox
                {
                    _FirstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }

    }
}
