using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Mugelli.Software.It.Mgc.MessagingCenters;
using Ricardo.LibMWPhotoBrowser.iOS;
using UIKit;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.iOS.MessaggingCenters
{
    public static class PhotoBrowseriOSMessage
    {
        public static void Subscribe(AppDelegate app)
        {
            MessagingCenter.Subscribe<BrowserPhotosMessage>(app, nameof(BrowserPhotosMessage), (sender) =>
            {
                var images = sender?.Images;
                var b = new CustomMWPhotoBrower(images);
                b.Show();
                
                //var photos = images.Select(x => new Photo { URL = x }).ToList();
                //var ph = new List<Photo>
                //    {
                //        new Photo
                //        {
                //            URL = "http://www.sime.it/it/media/images/homepage_top/banner_simeprofessional.jpg",
                //            Title = "Vincent"
                //        },
                //        new Photo
                //        {
                //            URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Jules.jpg",
                //            Title = "Jules"
                //        },
                //        new Photo
                //        {
                //            URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Korben.jpg",
                //            Title = "Korben"
                //    }
                //};
                //var photos = ph.ToList();
                //var pb = new PhotoBrowser
                //{
                //    Photos = photos,
                //    ActionButtonPressed = (index) =>
                //    {
                //        //Debug.WriteLine($"Clicked {index}");
                //    }
                //};


                //var _mainBrowser = new MyMWPhotoBrower(pb);
                //_mainBrowser.Show();
                //pb.Show();

                //var pb = new PhotoBrowser
                //{
                //    Photos = new List<Photo>
                //    {
                //        new Photo
                //        {
                //            URL = "https://upload.wikimedia.org/wikipedia/en/thumb/6/63/IMG_%28business%29.svg/1200px-IMG_%28business%29.svg.png",
                //            Title = "Vincent"
                //        },
                //        new Photo
                //        {
                //            URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Jules.jpg",
                //            Title = "Jules"
                //        },
                //        new Photo
                //        {
                //            URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Korben.jpg",
                //            Title = "Korben"
                //        }
                //    },
                //    ActionButtonPressed = (index) =>
                //    {
                //        //Debug.WriteLine($"Clicked {index}");
                //    }
                //};

            });
        }


       

        //public class MyMWPhotoBrower : MWPhotoBrowserDelegate
        //{
        //    protected PhotoBrowser _photoBrowser;

        //    protected List<MWPhoto> _photos = new List<MWPhoto>();

        //    public MyMWPhotoBrower(PhotoBrowser photoBrowser)
        //    {
        //        _photoBrowser = photoBrowser;
        //    }

        //    public void Show()
        //    {
        //        _photos = new List<MWPhoto>();

        //        foreach (Photo p in _photoBrowser.Photos)
        //        {
        //            MWPhoto mp = MWPhoto.FromUrl(new Foundation.NSUrl(p.URL));

        //            if (!string.IsNullOrWhiteSpace(p.Title))
        //            {
        //                mp.Caption = p.Title;
        //            }

        //            _photos.Add(mp);
        //        }

        //        MWPhotoBrowser browser = new MWPhotoBrowser(this);

        //        browser.DisplayActionButton = _photoBrowser.ActionButtonPressed != null;
        //        browser.SetCurrentPhoto((nuint)_photoBrowser.StartIndex);

        //        UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(new UINavigationController(browser), true, null);
        //    }

        //    public override MWPhoto GetPhoto(MWPhotoBrowser photoBrowser, nuint index) => _photos[(int)index];

        //    public override nuint NumberOfPhotosInPhotoBrowser(MWPhotoBrowser photoBrowser) => (nuint)_photos.Count;

        //    public override void OnActionButtonPressed(MWPhotoBrowser photoBrowser, nuint index)
        //    {
        //        _photoBrowser.ActionButtonPressed?.Invoke((int)index);
        //    }

        //    public void Close()
        //    {
        //        UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
        //    }
        //}

        //public class PhotoBrowserImplementation : IPhotoBrowser
        //{
        //    protected static MyMWPhotoBrower _mainBrowser;

        //    public void Show(PhotoBrowser photoBrowser)
        //    {
        //        _mainBrowser = new MyMWPhotoBrower(photoBrowser);
        //        _mainBrowser.Show();
        //    }

        //    public void Close()
        //    {
        //        if (_mainBrowser != null)
        //        {
        //            _mainBrowser.Close();
        //            _mainBrowser = null;
        //        }
        //    }
        //}

        //public class Platform
        //{
        //    public static void Init()
        //    {
        //        DependencyService.Register<PhotoBrowserImplementation>();
        //    }
        //}
    }

    public class CustomMWPhotoBrower : MWPhotoBrowserDelegate
    {
        //protected PhotoBrowser _photoBrowser;

        protected List<MWPhoto> _photos = new List<MWPhoto>();
        protected List<string> _urls = new List<string>();

        public CustomMWPhotoBrower(List<string> urls)
        {
            _urls = urls;
        }

        public void Show()
        {
            _photos = new List<MWPhoto>();

            //foreach (var url in _urls)
            //{
            //    MWPhoto mp = MWPhoto.FromUrl(new Foundation.NSUrl(url));
            //    _photos.Add(mp);
            //}


            foreach (string url in _urls)
            {
                using (var nsurl = new NSUrl(url))
                {
                    _photos.Add(MWPhoto.FromUrl(nsurl));
                }
            }

            MWPhotoBrowser browser = new MWPhotoBrowser(this);

            //browser.DisplayActionButton = _photoBrowser.ActionButtonPressed != null;
            //browser.SetCurrentPhoto((nuint)_photoBrowser.StartIndex);

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(new UINavigationController(browser), true, null);
        }

        public override MWPhoto GetPhoto(MWPhotoBrowser photoBrowser, nuint index) => _photos[(int)index];

        public override nuint NumberOfPhotosInPhotoBrowser(MWPhotoBrowser photoBrowser) => (nuint)_photos.Count;

        //public override void OnActionButtonPressed(MWPhotoBrowser photoBrowser, nuint index)
        //{
        //    _photoBrowser.ActionButtonPressed?.Invoke((int)index);
        //}

        public void Close()
        {
            UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
        }
    }
}
