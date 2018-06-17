using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace EpamTechnicalExercise.Converters
{
    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                return value.ToString();
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                value = value.ToString().Replace(',', '.');

                if (double.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double i))
                {
                    return i;
                }
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
