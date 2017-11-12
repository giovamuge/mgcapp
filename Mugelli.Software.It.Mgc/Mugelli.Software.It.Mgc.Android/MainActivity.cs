using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using FFImageLoading;
using FFImageLoading.Forms.Droid;
using Firebase.Messaging;
using Plugin.FirebasePushNotification;
using Plugin.FirebasePushNotification.Abstractions;

namespace Mugelli.Software.It.Mgc.Droid
{
    [Activity(Label = "MGC", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
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
                Logger = new CustomLogger(),
                DiskCacheDuration = TimeSpan.FromDays(30),
                FadeAnimationEnabled = true
            };
            ImageService.Instance.Initialize(config);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //CarouselViewRenderer.Init();
            LoadApplication(new App());

            FirebasePushNotificationManager.ProcessIntent(Intent);
            FirebaseMessaging.Instance.SubscribeToTopic("alldevices");


            //If debug you should reset the token each time.
#if DEBUG
            //FirebasePushNotificationManager.Initialize(this,true);
            FirebasePushNotificationManager.Initialize(this,
                new[]
                {
                    new NotificationUserCategory("message",new List<NotificationUserAction> {
                        new NotificationUserAction("Reply","Reply", NotificationActionType.Foreground),
                        new NotificationUserAction("Forward","Forward", NotificationActionType.Foreground)

                    }),
                    new NotificationUserCategory("alldevices",new List<NotificationUserAction>  {
                        new NotificationUserAction("Accept","Visualizza", NotificationActionType.Default, "check"),
                        new NotificationUserAction("Reject","Cancella", NotificationActionType.Default, "cancel")
                    })
                }, true);
#else
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

        //private void SendNotification(string messageBody)
        //{
        //    var intent = new Intent(this, typeof(MainActivity));
        //    intent.AddFlags(ActivityFlags.ClearTop);
        //    var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

        //    var notificationBuilder = new Notification.Builder(this)
        //        .SetSmallIcon(Resource.Drawable.icon)
        //        .SetContentTitle("FCM Message")
        //        .SetContentText(messageBody)
        //        .SetAutoCancel(true)
        //        .SetContentIntent(pendingIntent);

        //    var notificationManager = NotificationManager.FromContext(this);
        //    notificationManager.Notify(0, notificationBuilder.Build());
        //}
    }

    public class CustomLogger : FFImageLoading.Helpers.IMiniLogger
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }

        public void Error(string errorMessage, Exception ex)
        {
            Error(errorMessage + System.Environment.NewLine + ex);
        }
    }
}

