using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Mugelli.Software.It.Mgc.ViewModel;
using Mugelli.Software.It.Mgc.Models;

namespace Mugelli.Software.It.Mgc.Pages
{
    public partial class NewsPage : ContentPage
    {
        private NewsViewModel _vm;

        public NewsPage()
        {
            InitializeComponent();
            _vm = BindingContext as NewsViewModel;
            _vm.OnInit();
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e != null && e.Item is FeedRssItem item)
            {
                _vm.OnReadArticle(item);
            }
        }
    }
}
