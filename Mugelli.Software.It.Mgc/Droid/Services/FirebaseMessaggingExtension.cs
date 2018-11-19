using System.Collections.Generic;
using Firebase.Messaging;

namespace Mugelli.Software.It.Mgc.Droid.Services
{
    public static class FirebaseMessaggingExtension
    {
        public static bool TryNotification(this RemoteMessage remote, out RemoteMessage.Notification notification)
        {
            try
            {
                notification = remote.GetNotification();
                return true;
            }
            catch
            {
                notification = null;
                return false;
            }
        }

        public static bool TryDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, out TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                value = dictionary[key];
                return true;
            }

            value = default(TValue);
            return false;
        }
    }
}
