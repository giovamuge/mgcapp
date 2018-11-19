
using Android.App;
using Android.OS;
using Android.Content;
using Android.Support.V4.App;
using Android.Preferences;
using Java.Lang;

namespace Mugelli.Software.It.Mgc.Droid
{
    /*
     * Utility methods used in this sample.
     */
    public class Utils
    {
        public const string KeyLocationUpdatesRequested = "location-updates-requested";
        public const string KeyLocationUpdatesResult = "location-update-result";
        public const string ChannelId = "channel_mgcnews_01";
        public const string GroupKey = "group_mgcnews_01";

        public static void SetRequestingLocationUpdates(Context context, bool value)
        {
            PreferenceManager.GetDefaultSharedPreferences(context)
                    .Edit()
                    .PutBoolean(KeyLocationUpdatesRequested, value)
                    .Apply();
        }

        public static bool GetRequestingLocationUpdates(Context context)
        {
            return PreferenceManager.GetDefaultSharedPreferences(context)
                    .GetBoolean(KeyLocationUpdatesRequested, false);
        }

        private static string ToStringWithPoint(double value)
        {
            return value.ToString().Replace(',', '.');
        }

        /*
         * Posts a notification in the notification bar when a transition is detected.
         * If the user clicks the notification, control goes to the MainActivity.
         */
        public static void SendNotification(Context context, string notificationDetails)
        {
            // Create an explicit content Intent that starts the main Activity.
            var notificationIntent = new Intent(context, typeof(MainActivity));

            notificationIntent.PutExtra("from_notification", true);

            // Construct a task stack.
            var stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(context);

            // Add the main Activity to the task stack as the parent.
            stackBuilder.AddParentStack(Class.FromType(typeof(MainActivity)));

            // Push the content Intent onto the stack.
            stackBuilder.AddNextIntent(notificationIntent);

            // Get a PendingIntent containing the entire back stack.
            var notificationPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

            BuildNotification(context, Resource.Drawable.icon, "Location Update", notificationDetails, notificationPendingIntent,
                 out NotificationCompat.Builder builder, out NotificationManager mNotificationManager);

            // Issue the notification
            mNotificationManager.Notify(0, builder.Build());
        }

        /*
         * Build a notification.
         */
        public static void BuildNotification(Context context, int icon, string title, string notificationDetails, PendingIntent notificationPendingIntent,
             out NotificationCompat.Builder builder, out NotificationManager mNotificationManager)
        {
            // Get a notification builder that's compatible with platform versions >= 4
            builder = new NotificationCompat.Builder(context);

            // Define the notification settings.
            builder.SetSmallIcon(icon)
                    // In a real app, you may want to use a library like Volley
                    // to decode the Bitmap.
                    //TODO: da implementare la versione 
                    //.SetLargeIcon(BitmapFactory.DecodeResource(context.Resources, Resource.Mipmap.ic_launcher))
                    //.SetColor(Color.Red)
                    .SetContentTitle(title)
                    .SetGroup(GroupKey)
                    .SetGroupSummary(true)
                    .SetAutoCancel(true)
                    .SetContentText(notificationDetails)
                    .SetContentIntent(notificationPendingIntent);

            // Dismiss notification once the user touches it.
            builder.SetAutoCancel(true);

            // Get an instance of the Notification manager
            mNotificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;

            // Android O requires a Notification Channel.
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                string name = context.GetString(Resource.String.app_name);
                // Create the channel for the notification
                // Create the channel for the notification
                // TODO: da impostare l'importnza della notifica
                NotificationChannel mChannel = new NotificationChannel(ChannelId, name, NotificationImportance.High);

                // Set the Notification Channel for the Notification Manager.
                mNotificationManager.CreateNotificationChannel(mChannel);

                // Channel ID
                builder.SetChannelId(ChannelId);
            }
        }
    }
}
