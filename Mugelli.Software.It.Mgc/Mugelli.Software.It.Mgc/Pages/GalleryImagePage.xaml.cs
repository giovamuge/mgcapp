using System;
using System.Collections.Generic;
using Mugelli.Software.It.Mgc.Extensions;
using Mugelli.Software.It.Mgc.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mugelli.Software.It.Mgc.Services;

namespace Mugelli.Software.It.Mgc.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryImagePage : ContentPage
    {
        public GalleryImagePage(List<string> param)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            var viewModel = (ImageGalleryViewModel) BindingContext;
            viewModel.Images = param;
        }
    }
}