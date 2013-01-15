using System;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace INPC.Converters
{
    /// <summary>
    /// Simple helper class to transform a boolean value into a Style object.
    /// Used to take advantage of WPF's data binding mechanism in order to
    /// demonstrate that the PropertyChanged event doesn't fire when the
    /// old and new values are equal.
    /// 
    /// Feel free to transform it into a generic class and stuff it into 
    /// your own WPF boilerplate DLL.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Style))]
    public class BoolToStyleConverter : IValueConverter
    {
        public Style TrueStyle { get; set; }
        public Style FalseStyle { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? TrueStyle : FalseStyle;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
