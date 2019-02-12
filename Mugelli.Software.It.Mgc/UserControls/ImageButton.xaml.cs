using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.UserControls
{
    public partial class ImageButton : ContentView
    {
        public static readonly BindableProperty CommandProperty =
              BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(Button), null);

        public static readonly BindableProperty ButtonBackgroundColorProperty =
            BindableProperty.Create(nameof(ButtonBackgroundColor), typeof(Color), typeof(ImageButton),
                Color.Transparent);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(ImageButton), null);

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(nameof(Source), typeof(FileImageSource), typeof(ImageButton), null);

        public ImageButton()
        {
            InitializeComponent();
            Root.BindingContext = this;
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public Color ButtonBackgroundColor
        {
            get => (Color)GetValue(ButtonBackgroundColorProperty);
            set => SetValue(ButtonBackgroundColorProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public FileImageSource Source
        {
            get => (FileImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public event EventHandler Clicked;

        private async void HandleClick(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);

            await Root.ScaleTo(1.2, 100);
            await Root.ScaleTo(1, 100);
        }
    }
}
