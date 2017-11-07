using System;
using System.Threading.Tasks;
using Firebase.Xamarin.Auth;
using Plugin.DeviceInfo;

namespace Mugelli.Software.It.Mgc.Navigations
{
    public class AuthorizationHelper
    {
        private static volatile AuthorizationHelper _instance;
        private static readonly object SyncRoot = new object();

        private string Token { get; set; }

        private AuthorizationHelper() { }

        public static AuthorizationHelper Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new AuthorizationHelper();
                }

                return _instance;
            }
        }

        public void Init()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyD2ANVRy4K4md-ASE0jhRbDdJCOoY34p8Y"));

            Task.Factory.StartNew(async () =>
            {
                if (!CrossDeviceInfo.IsSupported) return;
                var email = $"{CrossDeviceInfo.Current.Id}@test.com";
                const string password = "password";

                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                if (string.IsNullOrEmpty(auth.FirebaseToken))
                {
                    auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                }

                Token = auth.FirebaseToken;
                //The auth Object will contain auth.User and the Authentication Token from the request
                System.Diagnostics.Debug.WriteLine(Token);
            });
        }
    }
}