using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Mugelli.Software.It.Mgc.MessagingCenters;
using Ricardo.LibMWPhotoBrowser.iOS;
using Stormlion.PhotoBrowser;
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
                var photos = images.Select(x => new Photo { URL = x }).ToList();
                var pb = new PhotoBrowser
                {
                    Photos = photos,
                    ActionButtonPressed = (index) =>
                    {
                        //Debug.WriteLine($"Clicked {index}");
                    }
                };
                pb.Show();
            });
        }
    }
}
