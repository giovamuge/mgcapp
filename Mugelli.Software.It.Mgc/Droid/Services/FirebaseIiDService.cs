using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Support.V4.App;
using Android.Util;
using Firebase.Iid;
using Firebase.Messaging;
using Mugelli.Software.It.Mgc.MessagingCenters;
using Newtonsoft.Json;

namespace Mugelli.Software.It.Mgc.Droid.Services
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class FirebaseIiDService : FirebaseInstanceIdService
    {
        const string TAG = nameof(FirebaseIiDService);
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);

            FirebaseMessaging.Instance.SubscribeToTopic("calendars");
            FirebaseMessaging.Instance.SubscribeToTopic("news");
            FirebaseMessaging.Instance.SubscribeToTopic("advertisings");
        }

        void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.
        }
    }


    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";

        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "From: " + message.From);
            Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);

            SendNotification(message.GetNotification());
        }

        protected void SendNotification(RemoteMessage.Notification payloadNotification)
        {
            //try
            //{
            //    //var payload = JsonConvert.DeserializeObject<PayloadMessage>(payloadStrify);
            //    var payload = new PayloadMessage
            //    {
            //        Title = payloadNotification.Title,
            //        Body = payloadNotification.Body,
            //        Id = payloadNotification.ClickAction,
            //        Type = payloadNotification.Tag
            //    };
            //    // Set up an intent so that tapping the notifications returns to this app:
            //    var intent = new Intent(this, typeof(MainActivity));
            //    intent.PutExtra("payload", JsonConvert.SerializeObject(payload));

            //    // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            //    const int pendingIntentId = 0;
            //    var pendingIntent =
            //        PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.OneShot);

            //    // Instantiate the builder and set notification elements, including pending intent:
            //    var builder = new Notification.Builder(this)
            //        .SetContentIntent(pendingIntent)
            //        .SetContentTitle(payload.Title)
            //        .SetContentText(payload.Body)
            //        .SetSmallIcon(Resource.Drawable.icon);

            //    // Build the notification:
            //    var notification = builder.Build();

            //    // Get the notification manager:
            //    var notificationManager =
            //        GetSystemService(NotificationService) as NotificationManager;

            //    // Publish the notification:
            //    //var notificationId = payload.Id.GetHashCode();
            //    var notificationId = 0;
            //    notificationManager.Notify(notificationId, notification);
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }
    }
}
