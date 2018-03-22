﻿using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.MessagingCenters;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Services;
using Mugelli.Software.It.Mgc.Stacks;
using Xamarin.Forms;

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
            ShowGalleryImage = new RelayCommand<object>(OnShowGalleryImage);
            GoBack = new RelayCommand(OnBack);

            MessagingCenter.Subscribe<BrowserPhotosMessage>(this, nameof(BrowserPhotosMessage), (sender) => {});
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

        private void OnShowGalleryImage(object sender)
        {
            MessagingCenter.Send(new BrowserPhotosMessage(), nameof(BrowserPhotosMessage));
            //_statusBar.HideStatusBar();
            //_navigationService.NavigateTo(PageStacks.GalleryImagePage, Images);
        //    new PhotoBrowser
        //    {
        //        Photos = new List<Photo>
        //{
        //    new Photo
        //    {
        //        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Vincent.jpg",
        //        Title = "Vincent"
        //    },
        //    new Photo
        //    {
        //        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Jules.jpg",
        //        Title = "Jules"
        //    },
        //    new Photo
        //    {
        //        URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Korben.jpg",
        //        Title = "Korben"
        //    }
        //},
            //    ActionButtonPressed = (index) =>
            //    {
            //        Debug.WriteLine($"Clicked {index}");
            //    }
            //}.Show();
        }

        private void OnBack()
        {
            _navigationService.GoBack();
        }
    }
}