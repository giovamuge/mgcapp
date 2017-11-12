﻿using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading;
using FFImageLoading.Forms.Touch;
using Foundation;
using Mugelli.Software.It.Mgc.iOS.Providers;
using UIKit;

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
            //CarouselViewRenderer.Init();

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

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
