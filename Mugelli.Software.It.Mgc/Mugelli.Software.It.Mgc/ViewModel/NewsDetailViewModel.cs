using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Stacks;
using Mugelli.Software.It.Mgc.UserControls;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class NewsDetailViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private FeedRssItem _article;

        public FeedRssItem Article
        {
            get => _article;
            set
            {
                RaisePropertyChanged(nameof(Article), _article, value);
                _article = value;

                var list = new List<string>()
                {
                    "PiccoloPrincipe.jpg",
                    "GiornataSportiva.jpg",
                    "MensaCaritas.jpg",
                    "Pizzata.jpg"
                };

                Images = _article.Images;

                //foreach (var image in list)
                //{
                //    var img = new Image {Source = image};
                //    ChildrenImage.Add(img);
                //}
            }
        }

        private List<string> _images;

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

        public NewsDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ShowGalleryImage = new RelayCommand(OnShowGalleryImage);
        }

        private void OnShowGalleryImage()
        {
            _navigationService.NavigateTo(PageStacks.GalleryImagePage, Images);
        }
    }
}