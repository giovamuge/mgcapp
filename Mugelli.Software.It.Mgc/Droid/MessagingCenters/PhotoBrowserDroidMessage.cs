using System;
using System.Linq;
using Mugelli.Software.It.Mgc.MessagingCenters;
using Stormlion.PhotoBrowser;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Droid.MessagingCenters
{
    public static class PhotoBrowserDroidMessage
    {
        public static void Subscribe(MainActivity app)
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

                pb.Show();
            });
        }
    }
}
