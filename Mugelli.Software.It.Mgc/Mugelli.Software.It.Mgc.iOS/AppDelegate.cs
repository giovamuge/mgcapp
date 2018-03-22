using System;
using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.iOS;
using FFImageLoading;
using FFImageLoading.Forms.Touch;
using Foundation;
using Mugelli.Software.It.Mgc.iOS.Providers;
using Mugelli.Software.It.Mgc.MessagingCenters;
using Stormlion.PhotoBrowser;
using UIKit;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            CachedImageRenderer.Init();
            CarouselViewRenderer.Init();

            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                Logger = new CustomLogger(),
                DiskCacheDuration = TimeSpan.FromDays(30),
                FadeAnimationEnabled = true
            };
            ImageService.Instance.Initialize(config);

            MessagingCenter.Subscribe<BrowserPhotosMessage>(this, nameof(BrowserPhotosMessage), (sender) =>
            {

                var pb = new PhotoBrowser
                {
                    Photos = new List<Photo>
                    {
                        new Photo
                        {
                            URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Vincent.jpg",
                            Title = "Vincent"
                        },
                        new Photo
                        {
                            URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Jules.jpg",
                            Title = "Jules"
                        },
                        new Photo
                        {
                            URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Korben.jpg",
                            Title = "Korben"
                        }
                    },
                    ActionButtonPressed = (index) =>
                    {
                            //Debug.WriteLine($"Clicked {index}");
                    }
                };

                pb.Show();
            });

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
