using System.Globalization;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Resources;
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

            InitializeComponent();

            CreateResourceDictionary();

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

            Resources = Mgc.Resources.Converters.Init(Resources);
            Resources = Colors.Init(Resources);
            Resources = Mgc.Resources.Fonts.Init(Resources);
            Resources = Labels.Init(Resources);
        }
    }
}
