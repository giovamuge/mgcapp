using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.FirebasePushNotification;

namespace Mugelli.Software.It.Mgc.Droid
{
    [Activity(Label = "MGC", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            FirebasePushNotificationManager.ProcessIntent(Intent);

            //If debug you should reset the token each time.
#if DEBUG
            FirebasePushNotificationManager.Initialize(this,true);
#else
            FirebasePushNotificationManager.Initialize(this, false);
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
}

