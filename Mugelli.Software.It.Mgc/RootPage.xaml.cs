﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Mugelli.Software.It.Mgc.Pages;
using Mugelli.Software.It.Mgc.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mugelli.Software.It.Mgc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : TabbedPage
    {
        public static readonly BindableProperty ChildrenProperty =
            BindableProperty.Create<RootPage, IEnumerable>(x => x.Children, null, BindingMode.TwoWay,
                propertyChanged: OnItemsSourcePropertyChanged);

        private readonly RootViewModel _viewModel;

        public RootPage()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }

            _viewModel = (RootViewModel)BindingContext;
            Appearing += OnApparingEvent;
        }


        async void OnApparingEvent(object sender, System.EventArgs e)
        {
            await _viewModel.InitializePayload();
        }


        public new IEnumerable<Page> Children
        {
            get => base.Children;
            set => SetValue(ChildrenProperty, value);
        }

        private static void OnItemsSourcePropertyChanged(BindableObject bindable, IEnumerable value,
            IEnumerable newValue)
        {
            var tabbedPage = (TabbedPage)bindable;
            var notifyCollection = newValue as INotifyCollectionChanged;
            if (notifyCollection != null)
                notifyCollection.CollectionChanged += (sender, args) =>
                {
                    if (args.NewItems != null)
                        foreach (var newItem in args.NewItems)
                            tabbedPage.Children.Add((Page)newItem);
                    if (args.OldItems != null)
                        foreach (var oldItem in args.OldItems)
                            tabbedPage.Children.Remove((Page)oldItem);
                };

            if (newValue == null) return;

            tabbedPage.Children.Clear();

            foreach (var item in newValue) tabbedPage.Children.Add((Page)item);
        }
    }
}