using System;

using Android.App;
using Android.Content.PM;
using Android.Gms.Common;
using Android.Util;
using Android.OS;
using Android.Content;

using Mugelli.Software.It.Mgc.Droid.MessagingCenters;
using Mugelli.Software.It.Mgc.MessagingCenters;
using Mugelli.Software.It.Mgc.Helpers;

using FFImageLoading;
using CarouselView.FormsPlugin.Android;
using Firebase.Iid;

namespace Mugelli.Software.It.Mgc.Droid
{
    [Activity(Label = "MGC", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            var config = new FFImageLoading.Config.Configuration
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                DiskCacheDuration = TimeSpan.FromDays(30),
                FadeAnimationEnabled = true,
                FadeAnimationForCachedImages = false,
                AllowUpscale = true
            };
            ImageService.Instance.Initialize(config);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CarouselViewRenderer.Init();

            Stormlion.PhotoBrowser.Droid.Platform.Init(this);
            PhotoBrowserDroidMessage.Subscribe(this);
            PayloadDroidMessage.Subscribe(this);

            LoadApplication(new App());

           
            if (!IsPlayServicesAvailable())  return;
        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Log.Error(nameof(MainActivity), GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
                    Log.Debug(nameof(MainActivity), "This device is not supported");
                    Finish();
                }
                return false;
            }

            Log.Debug(nameof(MainActivity), "Google Play Services is available.");
            return true;
        }

        protected override void OnResume()
        {
            if (Intent != null && Intent.Extras != null)
            {
                string payloadId,
                    payloadType;

                if(Intent.Extras.ContainsKey("id"))
                {
                    payloadId = Intent.Extras.GetString("id");
                    Settings.PayloadId = payloadId;
                }

                if(Intent.Extras.ContainsKey("type"))
                {
                    payloadType = Intent.Extras.GetString("type");
                    Settings.PayloadType = payloadType;
                }
            }
            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }
    }
}
