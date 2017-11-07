using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Helper;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Services;
using Mugelli.Software.It.Mgc.Stacks;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class NewsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly IRssFeedService _rssFeedService;

        //public List<News> NewsList { get; set; }
        private List<FeedRssItem> _newsList;

        public NewsViewModel(INavigationService navigationService, IRssFeedService rssFeedService)
        {
            _navigationService = navigationService;
            _rssFeedService = rssFeedService;

            ReadArticleCommand = new RelayCommand<FeedRssItem>(OnReadArticle);
            NavigateMgcSite = new RelayCommand(() => Device.OpenUri(new Uri("http://www.mgcfirenze.net/it")));
            RefreshCommand = new RelayCommand(OnRefresh);

            OnRefresh();
        }

        private void OnRefresh()
        {
            IsRefreshing = true;
            Task.Factory.StartNew(async () =>
            {
                var rss = await _rssFeedService.GetRss();
                NewsList = rss.Items;
                IsRefreshing = false;
            });
        }
        
        public string Title { get; set; } = "News";
        public string Icon { get; set; } = OnPlatformHelper.IconOniOS("News_50px.png");

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                RaisePropertyChanged(nameof(IsRefreshing), _isRefreshing, value);
                _isRefreshing = value;
            }
        }

        public FeedRssItem ReadArticleSelected { get; set; }

        public List<FeedRssItem> NewsList
        {
            get => _newsList;
            set
            {
                RaisePropertyChanged(nameof(NewsList), _newsList, value);
                _newsList = value;
            }
        }

        public ICommand ReadArticleCommand { get; set; }
        public ICommand NavigateMgcSite { get; set; }
        public ICommand RefreshCommand { get; set; }

        private void OnReadArticle(FeedRssItem news)
        {
            _navigationService.NavigateTo(PageStacks.NewsDetailPage, news);

            // imposta selected item a null
            ReadArticleSelected = null;
        }
    }
}