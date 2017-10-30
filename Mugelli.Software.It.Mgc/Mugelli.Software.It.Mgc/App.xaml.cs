using GalaSoft.MvvmLight.Ioc;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.ViewModel;
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
