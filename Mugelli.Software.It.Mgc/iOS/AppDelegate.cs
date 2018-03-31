using System;
using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.iOS;
using FFImageLoading;
using FFImageLoading.Forms.Touch;
using Foundation;
using Mugelli.Software.It.Mgc.iOS.MessaggingCenters;
using Mugelli.Software.It.Mgc.MessagingCenters;
using Stormlion.PhotoBrowser.iOS;
//using Stormlion.PhotoBrowser;
//using Stormlion.PhotoBrowser.iOS;
using UIKit;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
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
                DiskCacheDuration = TimeSpan.FromDays(30),
                FadeAnimationEnabled = true
            };
            ImageService.Instance.Initialize(config);

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
			Xamarin.Calabash.Start();
#endif

            Platform.Init();
            PhotoBrowseriOSMessage.Subscribe(this);

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
