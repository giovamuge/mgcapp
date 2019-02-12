using System;
using System.Collections.Generic;
using Mugelli.Software.It.Mgc.ViewModel;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Pages
{
    public partial class GalleryImagePage : ContentPage
    {
        public GalleryImagePage(List<string> param)
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }

            var viewModel = (ImageGalleryViewModel)BindingContext;
            viewModel.Images = param;
        }
    }
}
