using System;
using System.Globalization;
using Mugelli.Software.It.Mgc.Models.Types;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Converters
{
    public class TypeEventTextConverter : IValueConverter
    {
        //public static IsEmptyConverter Instance = new IsEmptyConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (EventType)value;
            return type.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (EventType)value;
            return type.ToString();
        }
    }
}