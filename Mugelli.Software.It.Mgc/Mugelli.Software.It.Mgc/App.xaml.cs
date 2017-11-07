using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Xamarin.Auth;
using GalaSoft.MvvmLight.Ioc;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.ViewModel;
using Plugin.DeviceInfo;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());

        public App()
        {
            InitializeComponent();

            var pageStart = NavigationHelper.Init();

            //Task.Factory.StartNew(async () =>
            //{
            var email = $"{CrossDeviceInfo.Current.GenerateAppId(true)}@test.com";
            const string password = "password";
            // Email/Password Auth
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyD2ANVRy4K4md-ASE0jhRbDdJCOoY34p8Y"));

            //var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            var auth = authProvider.SignInWithEmailAndPasswordAsync(email, password).Result;
            if (string.IsNullOrEmpty(auth.FirebaseToken))
            {
                //auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password).Result;
                auth = authProvider.CreateUserWithEmailAndPasswordAsync(email, password).Result;
            }

            // The auth Object will contain auth.User and the Authentication Token from the request
            System.Diagnostics.Debug.WriteLine(auth.FirebaseToken);
            //});

            MainPage = pageStart;
            //Old code
            //MainPage = new RootPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
