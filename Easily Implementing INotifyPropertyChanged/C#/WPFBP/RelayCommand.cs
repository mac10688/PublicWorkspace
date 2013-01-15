using System;
using System.Text;
using System.Windows.Input;

namespace WPFBP
{
    //Taken from the web and used without change as it is not relevant to the point
    //of this project (INotifyPropertyChanged made easy).
    //Yes, this is useful boilerplate code for WPF, but it is irrelevant to
    //INotifyPropertyChanged, especially in other environments like Windows Forms.
    public class RelayCommand : ICommand
    {
        #region Members
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;
        #endregion

        #region Constructors
        public RelayCommand(Action execute)
            : this(execute, null)
        { }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region ICommand Members
        public event EventHandler CanExecuteChanged
        {
            add
            {

                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {

                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
        [System.Diagnostics.DebuggerStepThrough]
        public Boolean CanExecute(Object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }
        public void Execute(Object parameter)
        {
            _execute();
        }
        #endregion
    }
}
