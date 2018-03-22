using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Firebase.Xamarin.Auth;
using GalaSoft.MvvmLight.Ioc;
using Mugelli.Software.It.Mgc.MessagingCenters;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Services;
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
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("it-IT");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("it-IT");

            InitializeComponent();

            //Initialize navigation
            var pageStart = NavigationHelper.Init();
            //FirebaseRestHelper.Instance.Init();
            //Initialize auth
            //AuthorizationHelper.Instance.Init();

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
