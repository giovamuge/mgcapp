using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Converters
{
    public class NullIntValueConverter : IValueConverter
    {
        //public static NullIntValueConverter Instance = new NullIntValueConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? string.Empty : value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                return null;

            if (int.TryParse((string)value, out int i))
                return i;

            return null;
        }
    }
}