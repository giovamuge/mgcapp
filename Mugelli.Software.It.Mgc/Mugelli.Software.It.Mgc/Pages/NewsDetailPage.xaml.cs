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
	    public NewsDetailPage (News news)
        {
            InitializeComponent ();

            var viewModel = BindingContext as NewsDetailViewModel;
            if (viewModel != null) viewModel.Article = news;
        }
    }
}