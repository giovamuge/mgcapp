using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Converters
{
    public class IsNotNullToBoolConverter : IValueConverter
    {
        //public static IsNotNullToBoolConverter Instance = new IsNotNullToBoolConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string)
                return !string.IsNullOrEmpty((string) value);

            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
                return !string.IsNullOrEmpty((string) value);

            return value != null;
        }
    }
}