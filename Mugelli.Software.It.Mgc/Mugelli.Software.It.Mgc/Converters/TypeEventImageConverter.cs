using System;
using System.Globalization;
using Mugelli.Software.It.Mgc.Models.Types;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Converters
{
    public class TypeEventImageConverter : IValueConverter
    {
        //public static IsEmptyConverter Instance = new IsEmptyConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (EventType)value;
            return GetColor(type);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (EventType)value;
            return GetColor(type);
        }

        //TODO:da fixare
        public object GetColor(EventType type)
        {
            switch (type)
            {
                case EventType.Ammi:
                    return "Pink_Filled_Circle_100px.png";
                case EventType.Mgc:
                    return "Purple_Filled_Circle_100px.png";
                case EventType.Giovanissimi:
                    return "Indigo_Filled_Circle_100px.png";
                case EventType.Oblati:
                    return "Blue_Filled_Circle_100px.png";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}