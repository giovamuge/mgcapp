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

            LoadApplication(new App());

            //If debug you should reset the token each time.
#if DEBUG
            //FirebasePushNotificationManager.Initialize(this,true);
            //FirebasePushNotificationManager.Initialize(this,
            //new[]
            //{
            //    new NotificationUserCategory("message",new List<NotificationUserAction> {
            //        new NotificationUserAction("Reply","Reply", NotificationActionType.Foreground),
            //        new NotificationUserAction("Forward","Forward", NotificationActionType.Foreground)

            //    }),
            //    new NotificationUserCategory("alldevices",new List<NotificationUserAction>  {
            //        new NotificationUserAction("Accept","Visualizza", NotificationActionType.Default, "check"),
            //        new NotificationUserAction("Reject","Cancella", NotificationActionType.Default, "cancel")
            //    })
            //}, tru
#else
			var options = new FirebaseOptions.Builder()
                                 .SetApplicationId("1:402954439752:android:2d2810dce428328e")
                                 .SetApiKey("AIzaSyD2ANVRy4K4md-ASE0jhRbDdJCOoY34p8Y")
                                 .SetDatabaseUrl("https://mgc-news.firebaseio.com/")
                                 .Build();
            
            var fire = FirebaseApp.InitializeApp(this, options, "mgc");

            FirebasePushNotificationManager.ProcessIntent(Intent);//Subscribing to single topic
            //CrossFirebasePushNotification.Current.Subscribe("alldevices");
            FirebaseMessaging.Instance.SubscribeToTopic("alldevices");
            //FirebasePushNotificationManager.Initialize(this, false);  
            FirebasePushNotificationManager.Initialize(this,
                new NotificationUserCategory[]
                {
                    new NotificationUserCategory("message",new List<NotificationUserAction> {
                        new NotificationUserAction("Reply","Reply", NotificationActionType.Foreground),
                        new NotificationUserAction("Forward","Forward", NotificationActionType.Foreground)

                    }),
                    new NotificationUserCategory("alldevices",new List<NotificationUserAction>  {
                        new NotificationUserAction("Accept","Visualizza", NotificationActionType.Default, "check"),
                        new NotificationUserAction("Reject","Cancella", NotificationActionType.Default, "cancel")
                    })
                }, false);
#endif

            //Handle notification when app is closed here
            //CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            //{
            //    System.Diagnostics.Debug.WriteLine("Received");
            //    //SendNotification(p.Data["body"]);
            //};

            //CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            //{
            //    System.Diagnostics.Debug.WriteLine("Opened");
            //    foreach (var data in p.Data)
            //    {
            //        System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
            //    }

            //    if (!string.IsNullOrEmpty(p.Identifier))
            //    {
            //        System.Diagnostics.Debug.WriteLine($"ActionId: {p.Identifier}");
            //    }

            //};



            //If debug you should reset the token each time.
            //#if DEBUG
            //            FirebasePushNotificationManager.Initialize(this,true);
            //#else
            //            FirebasePushNotificationManager.Initialize(this, false);
            //#endif

            ////Handle notification when app is closed here
            //CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            //{


            //};

            ////Set the default notification channel for your app when running Android Oreo
            //if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            //{
            //    //Change for your default notification channel id here
            //    FirebasePushNotificationManager.DefaultNotificationChannelId = "DefaultChannel";

            //    //Change for your default notification channel name here
            //    FirebasePushNotificationManager.DefaultNotificationChannelName = "General";
            //}

            if (!IsPlayServicesAvailable())  return;
            //Firebase.Iid.FirebaseInstanceId.Instance.GetToken();
            Firebase.Messaging.FirebaseMessaging.Instance.SubscribeToTopic("testt");
            Log.Debug("Token", "InstanceID token: " + FirebaseInstanceId.Instance.Token);
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
    }
}
