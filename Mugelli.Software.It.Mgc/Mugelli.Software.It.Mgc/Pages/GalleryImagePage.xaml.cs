using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugelli.Software.It.Mgc.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mugelli.Software.It.Mgc.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GalleryImagePage : ContentPage
	{
		public GalleryImagePage (List<string> param)
		{
			InitializeComponent ();

		    NavigationPage.SetHasNavigationBar(this, false);

            var viewModel = (ImageGalleryViewModel) BindingContext;
		    viewModel.Images = param;
		}
	}
}