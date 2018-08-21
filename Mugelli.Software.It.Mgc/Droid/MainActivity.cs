using System;

using Android.App;
using Android.Content.PM;
using Android.Gms.Common;
using Android.Util;
using Android.OS;
using Android.Content;

using Mugelli.Software.It.Mgc.Droid.MessagingCenters;
using Mugelli.Software.It.Mgc.MessagingCenters;

using FFImageLoading;
using CarouselView.FormsPlugin.Android;
using Firebase.Messaging;
using Newtonsoft.Json;

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
            if (Intent != null && Intent.Extras != null)
            {
                if (Intent.Extras.ContainsKey("payload"))
                {
                    var payloadStrify = Intent.Extras.GetString("payload");
                    var payload = JsonConvert.DeserializeObject<PayloadMessage>(payloadStrify);
                    PayloadDroidMessage.Send(payload);
                }
            }
            base.OnResume();
        }

        protected override void OnPause()
        {
            var payload = new PayloadMessage
            {
                Title = "Test notification",
                Body = "Send notification on pause application",
                Id = "164a23d68d9ee542",
                Type = "mgc"
            };
            // Set up an intent so that tapping the notifications returns to this app:
            var intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("payload", JsonConvert.SerializeObject(payload));

            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            const int pendingIntentId = 0;
            var pendingIntent =
                PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.OneShot);

            // Build the notification:
            Notification notification;

            // Instantiate the builder and set notification elements, including pending intent:
            using (var builder = new Notification.Builder(this)
                .SetContentIntent(pendingIntent)
                .SetContentTitle(payload.Title)
                .SetContentText(payload.Body)
                .SetSmallIcon(Resource.Drawable.icon))
            {
                notification = builder.Build();
            }

            // Get the notification manager:
            var notificationManager =
                GetSystemService(NotificationService) as NotificationManager;

            // Publish the notification:
            //var notificationId = payload.Id.GetHashCode();
            var notificationId = 0;
            notificationManager.Notify(notificationId, notification);

            base.OnPause();
        }
    }
}
