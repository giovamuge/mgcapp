using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.UserControls
{
    public class ImageGallery : ScrollView
    {
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create<ImageGallery, IList>(
                view => view.ItemsSource,
                default(IList),
                BindingMode.TwoWay,
                propertyChanging: (bindableObject, oldValue, newValue) =>
                {
                    ((ImageGallery) bindableObject).ItemsSourceChanging();
                },
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    ((ImageGallery) bindableObject).ItemsSourceChanged(bindableObject, oldValue, newValue);
                }
            );

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create<ImageGallery, object>(
                view => view.SelectedItem,
                null,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) => { ((ImageGallery) bindable).UpdateSelectedIndex(); }
            );

        public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create<ImageGallery, int>(
                carousel => carousel.SelectedIndex,
                0,
                BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) => { ((ImageGallery) bindable).UpdateSelectedItem(); }
            );

        private readonly StackLayout _imageStack;

        public ImageGallery()
        {
            Orientation = ScrollOrientation.Horizontal;

            _imageStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            Content = _imageStack;
        }

        public IList<View> Children => _imageStack.Children;

        public IList ItemsSource
        {
            get => (IList) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public DataTemplate ItemTemplate { get; set; }

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public int SelectedIndex
        {
            get => (int) GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        private void ItemsSourceChanging()
        {
            if (ItemsSource == null)
                return;
        }

        private void ItemsSourceChanged(BindableObject bindable, IList oldValue, IList newValue)
        {
            if (ItemsSource == null)
                return;

            var notifyCollection = newValue as INotifyCollectionChanged;
            if (notifyCollection != null)
                notifyCollection.CollectionChanged += (sender, args) =>
                {
                    if (args.NewItems != null)
                        foreach (var newItem in args.NewItems)
                        {
                            var view = (View) ItemTemplate.CreateContent();
                            var bindableObject = view as BindableObject;
                            if (bindableObject != null)
                                bindableObject.BindingContext = newItem;
                            _imageStack.Children.Add(view);
                        }
                    if (args.OldItems != null)
                        _imageStack.Children.RemoveAt(args.OldStartingIndex);
                };
        }

        private void UpdateSelectedIndex()
        {
            if (SelectedItem == BindingContext)
                return;

            SelectedIndex = Children
                .Select(c => c.BindingContext)
                .ToList()
                .IndexOf(SelectedItem);
        }

        private void UpdateSelectedItem()
        {
            SelectedItem = SelectedIndex > -1 ? Children[SelectedIndex].BindingContext : null;
        }
    }
}