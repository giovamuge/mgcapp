using System;
using System.Threading.Tasks;
using CarouselView.FormsPlugin.iOS;
using FFImageLoading;
using Firebase.CloudMessaging;
using Foundation;
using Mugelli.Software.It.Mgc.Helpers;
using Mugelli.Software.It.Mgc.iOS.MessaggingCenters;
using UIKit;
using UserNotifications;
using Xamarin.Forms.Platform.iOS;

namespace Mugelli.Software.It.Mgc.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate, IUNUserNotificationCenterDelegate, IMessagingDelegate
    {
        public event EventHandler<UserInfoEventArgs> MessageReceived;

        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // Initialize ffimageloading
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();

            // Initialize catouselview
            CarouselViewRenderer.Init();

            // Set config for ffimageloading
            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                DiskCacheDuration = TimeSpan.FromDays(30),
                FadeAnimationEnabled = true
            };

            // Inizialize ffimageloading
            ImageService.Instance.Initialize(config);

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
            Xamarin.Calabash.Start();
#endif
            // Photo browser initialize
            Stormlion.PhotoBrowser.iOS.Platform.Init();

            // Photo broser set bus messagging
            PhotoBrowseriOSMessage.Subscribe(this);

            // Initialize Xamarin Forms
            LoadApplication(new App());

            Firebase.Core.App.Configure();

            // Register your app for remote notifications.
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // For iOS 10 display notification (sent via APNS)
                UNUserNotificationCenter.Current.Delegate = this;

                var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
                UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) =>
                {
                    Console.WriteLine(granted);
                });
            }
            else
            {
                // iOS 9 or before
                var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
                var settings = UIUserNotificationSettings.GetSettingsForTypes(allNotificationTypes, null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }

            UIApplication.SharedApplication.RegisterForRemoteNotifications();

            Messaging.SharedInstance.Delegate = this;

            // To connect with FCM. FCM manages the connection, closing it
            // when your app goes into the background and reopening it 
            // whenever the app is foregrounded.
            Messaging.SharedInstance.ShouldEstablishDirectChannel = true;


            var token = Messaging.SharedInstance.FcmToken ?? "";
            Console.WriteLine($"FCM token: {token}");

            return base.FinishedLaunching(app, options);
        }

        [Export("messaging:didReceiveRegistrationToken:")]
        public void DidReceiveRegistrationToken(Messaging messaging, string fcmToken)
        {
            // Monitor token generation: To be notified whenever the token is updated.

            LogInformation(nameof(DidReceiveRegistrationToken), $"Firebase registration token: {fcmToken}");

            if (string.IsNullOrEmpty(fcmToken)) return;
            Task.Run(SubscribeTopicAsync);

            // TODO: If necessary send token to application server.
            // Note: This callback is fired at each app startup and whenever a new token is generated.
        }

        async Task SubscribeTopicAsync()
        {
            await Messaging.SharedInstance.SubscribeAsync("news");
            await Messaging.SharedInstance.SubscribeAsync("calendars");
            await Messaging.SharedInstance.SubscribeAsync("advertisings");
        }

        // You'll need this method if you set "FirebaseAppDelegateProxyEnabled": NO in GoogleService-Info.plist
        //public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
        //{
        //  Messaging.SharedInstance.ApnsToken = deviceToken;
        //}

        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            // Handle Notification messages in the background and foreground.
            // Handle Data messages for iOS 9 and below.

            // If you are receiving a notification message while your app is in the background,
            // this callback will not be fired till the user taps on the notification launching the application.
            // TODO: Handle data of notification

            // With swizzling disabled you must let Messaging know about the message, for Analytics
            //Messaging.SharedInstance.AppDidReceiveMessage (userInfo);

            HandleMessage(userInfo);

            HendleData(userInfo);

            // Print full message.
            LogInformation(nameof(DidReceiveRemoteNotification), userInfo);

            completionHandler(UIBackgroundFetchResult.NewData);
        }

        [Export("messaging:didReceiveMessage:")]
        public void DidReceiveMessage(Messaging messaging, RemoteMessage remoteMessage)
        {
            // Handle Data messages for iOS 10 and above.
            HandleMessage(remoteMessage.AppData);

            LogInformation(nameof(DidReceiveMessage), remoteMessage.AppData);
        }

        private void HandleMessage(NSDictionary message)
        {
            if (MessageReceived == null)
                return;

            MessageType messageType;
            if (message.ContainsKey(new NSString("aps")))
                messageType = MessageType.Notification;
            else
                messageType = MessageType.Data;

            var e = new UserInfoEventArgs(message, messageType);
            MessageReceived(this, e);
        }

        private void HendleData(NSDictionary data)
        {
            var nsId = new NSString("id");
            if (data.ContainsKey(nsId) && data.TryGetValue(nsId, out NSObject payloadId))
            {
                Settings.PayloadId = (payloadId is NSString).ToString() ?? string.Empty;
            }

            var nsType = new NSString("type");
            if (data.ContainsKey(nsType) && data.TryGetValue(nsType, out NSObject payloadType))
            {
                Settings.PayloadType = (payloadType is NSString).ToString() ?? string.Empty;
            }
        }

        public static void ShowMessage(string title, string message, UIViewController fromViewController, Action actionForOk = null)
        {
            var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            //alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (obj) => actionForOk?.Invoke()));
            fromViewController.PresentViewController(alert, true, null);
        }

        void LogInformation(string methodName, object information) => Console.WriteLine($"\nMethod name: {methodName}\nInformation: {information}");
    }

    public class UserInfoEventArgs : EventArgs
    {
        public NSDictionary UserInfo { get; private set; }
        public MessageType MessageType { get; private set; }

        public UserInfoEventArgs(NSDictionary userInfo, MessageType messageType)
        {
            UserInfo = userInfo;
            MessageType = messageType;
        }
    }

    public enum MessageType
    {
        Notification,
        Data
    }

}
