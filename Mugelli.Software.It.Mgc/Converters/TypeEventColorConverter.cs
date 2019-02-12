using System;
using System.Globalization;
using Mugelli.Software.It.Mgc.Models.Types;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Converters
{
    public class TypeEventColorConverter : IValueConverter
    {
        //public static IsEmptyConverter Instance = new IsEmptyConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (EventType) value;
            return GetColor(type);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (EventType) value;
            return GetColor(type);
        }

        //TODO:da fixare
        public object GetColor(EventType type)
        {
            object result;
            const string defaultValue = "#ccc";

            switch (type)
            {
                case EventType.Ammi:
                    return Application.Current.Resources.TryGetValue("PinkLight", out result)
                        ? result
                        : defaultValue;
                case EventType.Mgc:
                    return Application.Current.Resources.TryGetValue("PurplePrimary", out result)
                        ? result
                        : defaultValue;
                case EventType.Giovanissimi:
                    return Application.Current.Resources.TryGetValue("IndigoLight", out result)
                        ? result
                        : defaultValue;
                case EventType.Oblati:
                    return Application.Current.Resources.TryGetValue("BlueDark", out result)
                        ? result
                        : defaultValue;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}