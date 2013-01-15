using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;


namespace Example06
{
    [ValueConversion(typeof(double), typeof(System.Windows.Media.Brush))]
    public class TemperatureToColorConverter:IValueConverter
    {
        double _coldTemperature = -273;
        double _hotTemperature = 200;

        


        public double HotTemperature
        {
            get { return _hotTemperature; }
            set { _hotTemperature = value; }
        }

        public double ColdTemperature
        {
            get { return _coldTemperature;  }
            set { _coldTemperature = value; }
        }

        public TemperatureToColorConverter() : this(65,80)
        {
            
        }
        public TemperatureToColorConverter(double lowTemperature, double hotTemperature)
        {
            _coldTemperature = lowTemperature;
            _hotTemperature = hotTemperature;
        }



        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double sourceValue;
            if (Double.TryParse(value.ToString(), out sourceValue))
            {
                if (sourceValue <= _coldTemperature)
                    return Brushes.Blue;
                if (sourceValue >= _hotTemperature)
                    return Brushes.Red;
                return Brushes.Black;
            }
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
