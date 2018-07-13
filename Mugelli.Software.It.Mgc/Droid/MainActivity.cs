using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading;
using CarouselView.FormsPlugin.Android;
using FFImageLoading.Forms.Droid;
using Mugelli.Software.It.Mgc.Droid.MessagingCenters;
using Android.Gms.Common;
using Android.Util;
using Firebase.Iid;
using Firebase;
using Firebase.Messaging;
using Mugelli.Software.It.Mgc.MessagingCenters;
using Newtonsoft.Json;

namespace Mugelli.Software.It.Mgc.Droid
{
    [Activity(Label = "MGC", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            CachedImageRenderer.Init(true);

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

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CarouselViewRenderer.Init();

            Stormlion.PhotoBrowser.Droid.Platform.Init(this);
            PhotoBrowserDroidMessage.Subscribe(this);
            PayloadDroidMessage.Subscribe(this);

            LoadApplication(new App());

           
            if (!IsPlayServicesAvailable())  return;

            FirebaseMessaging.Instance.SubscribeToTopic("calendars");
            FirebaseMessaging.Instance.SubscribeToTopic("news");
            FirebaseMessaging.Instance.SubscribeToTopic("advertisings");
            //Log.Debug("Token", "InstanceID token: " + FirebaseInstanceId.Instance.Token);
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
            base.OnResume();

            if (Intent != null && Intent.Extras != null)
            {
                if (Intent.Extras.ContainsKey("payload"))
                {
                    var payloadStrify = Intent.Extras.GetString("payload");
                    var payload = JsonConvert.DeserializeObject<PayloadMessage>(payloadStrify);
                    PayloadDroidMessage.Send(payload);
                }
            }
        }
    }
}
