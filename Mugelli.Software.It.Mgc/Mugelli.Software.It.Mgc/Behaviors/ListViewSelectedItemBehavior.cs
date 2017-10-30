using System.Windows.Input;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Behaviors
{
    public class ListViewSelectedItemBehavior : Behavior<ListView>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ListViewSelectedItemBehavior), null);

        public static readonly BindableProperty InputConverterProperty =
            BindableProperty.Create("Converter", typeof(IValueConverter), typeof(ListViewSelectedItemBehavior), null);

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public IValueConverter Converter
        {
            get => (IValueConverter) GetValue(InputConverterProperty);
            set => SetValue(InputConverterProperty, value);
        }
    }
}