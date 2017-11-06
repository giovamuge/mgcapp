using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mugelli.Software.It.Mgc.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsDetailPage : ContentPage
	{
	    private double _imageHeight;

	    public NewsDetailPage (FeedRssItem news)
        {
            InitializeComponent ();

            var viewModel = BindingContext as NewsDetailViewModel;
            if (viewModel != null) viewModel.Article = news;


            ScrollCustom.Scrolled += (sender, e) => Parallax();
            Parallax();
        }

	    private void Parallax()
	    {
	        if (_imageHeight <= 0)
	            _imageHeight = HeroImage.Height;

	        var y = ScrollCustom.ScrollY * .4;
	        if (y >= 0)
	        {
                //Move the Image's Y coordinate a fraction of the ScrollView's Y position
	            HeroImage.Scale = 1;
	            HeroImage.TranslationY = y;
	        }
	        else
	        {
	            //Calculate a scale that equalizes the height vs scroll
	            var newHeight = _imageHeight + (ScrollCustom.ScrollY * -1);
	            HeroImage.Scale = newHeight / _imageHeight;
	            HeroImage.TranslationY = ScrollCustom.ScrollY / 2;
	        }
	    }
    }
}