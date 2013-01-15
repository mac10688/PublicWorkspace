using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace INotifyPropertyChangedSnippets.View
{
    class ViewModelBase : INotifyPropertyChanged
    {
        //created by typing "raisepc" and pressing the Tab key (added "internal" predicate, as it is a base class)
        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
