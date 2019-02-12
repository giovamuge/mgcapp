using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Converters
{
    public class SelectedItemEventArgsToSelectedItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as SelectedItemChangedEventArgs;
            return eventArgs != null ? eventArgs.SelectedItem : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}