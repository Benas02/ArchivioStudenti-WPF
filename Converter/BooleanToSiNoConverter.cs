using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFDemo.Converter
{
    internal class BooleanToSiNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Sì" : "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
