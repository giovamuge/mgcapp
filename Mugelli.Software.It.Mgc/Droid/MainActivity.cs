using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading;
using CarouselView.FormsPlugin.Android;
using Plugin.FirebasePushNotification;
using FFImageLoading.Forms.Droid;

namespace Mugelli.Software.It.Mgc.Droid
{
    [Activity(Label = "MGC", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            CachedImageRenderer.Init();

            var config = new FFImageLoading.Config.Configuration
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                DiskCacheDuration = TimeSpan.FromDays(30),
                FadeAnimationEnabled = true,
                FadeAnimationForCachedImages = false
            };
            ImageService.Instance.Initialize(config);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CarouselViewRenderer.Init();
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
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Received");
                //SendNotification(p.Data["body"]);
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                }

                if (!string.IsNullOrEmpty(p.Identifier))
                {
                    System.Diagnostics.Debug.WriteLine($"ActionId: {p.Identifier}");
                }

            };
        }
    }
}
