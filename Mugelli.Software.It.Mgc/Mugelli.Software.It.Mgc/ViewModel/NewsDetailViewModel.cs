using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Services;
using Mugelli.Software.It.Mgc.Stacks;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class NewsDetailViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IStatusBar _statusBar;
        private FeedRssItem _article;

        private List<string> _images;

        public NewsDetailViewModel(INavigationService navigationService, IStatusBar statusBar)
        {
            _navigationService = navigationService;
            _statusBar = statusBar;
            ShowGalleryImage = new RelayCommand(OnShowGalleryImage);
            GoBack = new RelayCommand(OnBack);
        }

        public FeedRssItem Article
        {
            get => _article;
            set
            {
                RaisePropertyChanged(nameof(Article), _article, value);
                _article = value;

                Images = _article.Images;
            }
        }

        public List<string> Images
        {
            get => _images;
            set
            {
                RaisePropertyChanged(nameof(Images), _images, value);
                _images = value;
            }
        }

        public ICommand ShowGalleryImage { get; set; }
        public ICommand GoBack { get; set; }

        private void OnShowGalleryImage()
        {
            //_statusBar.HideStatusBar();
            _navigationService.NavigateTo(PageStacks.GalleryImagePage, Images);
        }

        private void OnBack()
        {
            _navigationService.GoBack();
        }
    }
}