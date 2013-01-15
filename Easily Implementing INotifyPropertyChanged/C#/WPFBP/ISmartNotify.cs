using System;

namespace WPFBP
{
    /// <summary>
    /// Interface used to fine-tune the change notification system of INotifyPropertyChanged.
    /// This is primarily useful when regulating how fast a user interface should receive 
    /// notifications.
    /// 
    /// A typical implementation of this class is thread-safe because this kind of regulation 
    /// is usually seen in multi-threaded scenarios only.
    /// </summary>
    public interface ISmartNotify
    {
        /// <summary>
        /// Gets a boolean value indicating if the object is allowing immediate change notification.
        /// </summary>
        bool NotifyChanges { get; }
        /// <summary>
        /// Called by the INotifyPropertyChanged event raiser to report a change without actually
        /// raising the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property whose value has changed.</param>
        void ReportMutedChange(string propertyName);
    }
}
