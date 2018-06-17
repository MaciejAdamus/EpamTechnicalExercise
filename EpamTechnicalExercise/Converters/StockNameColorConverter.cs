using EpamTechnicalExercise.Model.StockModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace EpamTechnicalExercise.Converters
{
    public class StockNameColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Stock stock)
            {
                if (stock.MarketValue < 0 || stock.TransactionCost > stock.TransactionCostTolerance)
                    return Brushes.Red;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
