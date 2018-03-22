using System.Globalization;
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
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("it-IT");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("it-IT");

            CreateResourceDictionary();

            InitializeComponent();

            //Initialize navigation
            var pageStart = NavigationHelper.Init();
            //FirebaseRestHelper.Instance.Init();
            //Initialize auth
            //AuthorizationHelper.Instance.Init();

            MainPage = pageStart;
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

        //needed because of Xamarin Bug  https://bugzilla.xamarin.com/show_bug.cgi?id=60788
        private void CreateResourceDictionary()
        {
            //making sure there is only one dictionary
            if (Resources == null)
                Resources = new ResourceDictionary();
            //making sure there is only one key
            if (!Resources.ContainsKey("ViewModelLocator"))
            {
                Resources.Add("ViewModelLocator", new ViewModelLocator());
            }
            if (!Resources.ContainsKey("MainAccentColor"))
            {
                Resources.Add("MainAccentColor", Color.FromHex("#1e73be"));
            }
            if (!Resources.ContainsKey("LightAccentColor"))
            {
                Resources.Add("LightAccentColor", Color.FromHex("#61a1f1"));
            }
            if (!Resources.ContainsKey("DarkAccentColor"))
            {
                Resources.Add("DarkAccentColor", Color.FromHex("#00488d"));
            }
            if (!Resources.ContainsKey("MainBackgroundColor"))
            {
                Resources.Add("MainBackgroundColor", Color.FromHex("#f4f4f4"));
            }
        }
    }
}
