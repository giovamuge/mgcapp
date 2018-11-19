using Android.App;
using Android.Content;
using Firebase.Messaging;
using FirebaseMessagging = Firebase.Messaging;

namespace Mugelli.Software.It.Mgc.Droid.Services
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseMessagingService : FirebaseMessagging.FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";

        /*
         * Called when message is received.
         */
        public override void OnMessageReceived(RemoteMessage message)
        {
            // TODO(developer): Handle FCM messages here.
            // If the application is in the foreground handle both data and notification messages here.
            // Also if you intend on generating your own notifications as a result of a received FCM
            // message, here is where that should be initiated. See sendNotification method below.
            //Log.Debug(TAG, "From: " + message.From);
            //Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);

            var utils = new FirebaseMessaggingUtil(this);

            if (message.TryNotification(out RemoteMessage.Notification notification) && notification != null)
            {
                utils.SendNotification(notification, message.Data);
                return;
            }

            utils.SendNotification(message.Data);
        }
    }
}
