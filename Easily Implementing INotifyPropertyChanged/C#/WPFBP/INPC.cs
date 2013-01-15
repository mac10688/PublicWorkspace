using System;
using System.Text;
using System.ComponentModel;

namespace WPFBP
{
    public static class INPC
    {
        /// <summary>
        /// Extension method that sets a new value in a variable and then executes the event handler if the new value
        /// differs from the old one.  Used to easily implement INotifyPropeprtyChanged.
        /// </summary>
        /// <typeparam name="T">The type of values being handled (usually the type of the property).</typeparam>
        /// <param name="handler">The event handler to execute in the event of actual value change.</param>
        /// <param name="newValue">The new value to set.</param>
        /// <param name="oldValue">The old value to replace (and the value holder).</param>
        /// <param name="propertyName">The property's name as required by <typeparamref name="System.ComponentModel.PropertyChangedEventArgs"/>.</param>
        /// <param name="sender">The object to be appointed as the executioner of the handler.</param>
        /// <returns>A boolean value that indicates if the new value was truly different from the old value according to <code>object.Equals()</code>.</returns>
        public static bool SetAndRaise<T>(this PropertyChangedEventHandler handler, T newValue, ref T oldValue, string propertyName, object sender)
        {
            //Either the new or old values can be null, but the static
            //method Object.Equals() takes care of it.
            bool changed = !Object.Equals(oldValue, newValue);
            if (changed)
            {
                //Save the new value.
                oldValue = newValue;
                ISmartNotify isn = sender as ISmartNotify;
                //Raise the event
                if (handler != null && (isn == null || isn.NotifyChanges))
                {
                    handler(sender, new PropertyChangedEventArgs(propertyName));
                }
                else if (isn != null && !isn.NotifyChanges)
                {
                    //The event was muted (regardless of the state of the handler).  Report it.
                    isn.ReportMutedChange(propertyName);
                }
            }
            //Signal what happened.
            return changed;
        }
    }
}
