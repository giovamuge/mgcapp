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
}
