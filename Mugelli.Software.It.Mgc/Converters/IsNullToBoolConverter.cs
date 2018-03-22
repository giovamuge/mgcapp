using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using System.Linq;

namespace Mugelli.Software.It.Mgc.Converters
{
    public class IsNullToBoolConverter : IValueConverter
    {
        //public static IsNullToBoolConverter Instance = new IsNullToBoolConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
                return string.IsNullOrEmpty((string) value);

            if (value is IList)
                return ((IList)value)?.Count <= 0;
            
            return value == null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
                return string.IsNullOrEmpty((string) value);

            if (value is IList)
                return ((IList)value)?.Count <= 0;
            
            return value == null;
        }
    }
}