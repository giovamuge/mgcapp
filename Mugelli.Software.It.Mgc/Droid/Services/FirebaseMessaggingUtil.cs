using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Support.V4.App;
using Firebase.Messaging;
using FirebaseMessagging = Firebase.Messaging;

namespace Mugelli.Software.It.Mgc.Droid.Services
{
    public class FirebaseMessaggingUtil
    {
        private readonly FirebaseMessagging.FirebaseMessagingService _context;

        public FirebaseMessaggingUtil(FirebaseMessagging.FirebaseMessagingService context)
        {
            _context = context;
        }

        /*
         * Create notification and check is invasion
         */
        public void SendNotification(IDictionary<string, string> data)
        {
            if (data.TryDictionary("title", out string title) && data.TryDictionary("body", out string body))
            {
                SendNotification(title, body, data);
            }
            else
            {
                SendNotification("Notifica Allerta", "Controlla l'applicazione per la notifica", data);
            }
        }

        /*
         * Create notification simple
         */
        public void SendNotification(RemoteMessage.Notification notification, IDictionary<string, string> data)
        {
            SendNotification(notification.Title, notification.Body, data);
        }

        /*
         * Create notification
         */
        void SendNotification(string title, string body, IDictionary<string, string> data)
        {
            var intent = new Intent(_context, typeof(MainActivity));

            intent.AddFlags(ActivityFlags.ClearTop);

            foreach (var key in data.Keys)
            {
                intent.PutExtra(key, data[key]);
            }

            var pendingIntent = PendingIntent.GetActivity(_context, 225 /* Request code */, intent, PendingIntentFlags.OneShot);

            var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
            var notificationBuilder = new NotificationCompat.Builder(_context);
            var notificationManager = NotificationManager.FromContext(_context);

            Utils.BuildNotification(_context, Resource.Drawable.icon, title, body, pendingIntent,
                    out notificationBuilder, out notificationManager);

            // Ottiene un numero random per identificare la notifica
            // ancora non è stato implementato una logica di group message
            //var rdm = new Random();
            notificationManager.Notify(599 /* ID of notification */, notificationBuilder.Build());
        }
    }
}
