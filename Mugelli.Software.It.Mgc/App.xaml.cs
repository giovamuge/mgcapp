using System.Globalization;
using Mugelli.Software.It.Mgc.Converters;
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
            if (!Resources.ContainsKey("SelectedItemEventArgsToSelectedItemConverter"))
            {
                Resources.Add("SelectedItemEventArgsToSelectedItemConverter", new SelectedItemEventArgsToSelectedItemConverter());
            }
            if (!Resources.ContainsKey("InverseBoolConverter"))
            {
                Resources.Add("InverseBoolConverter", new InverseBoolConverter());
            }
            if (!Resources.ContainsKey("IsEmptyConverter"))
            {
                Resources.Add("IsEmptyConverter", new IsEmptyConverter());
            }
            if (!Resources.ContainsKey("IsNotNullToBoolConverter"))
            {
                Resources.Add("IsNotNullToBoolConverter", new IsNotNullToBoolConverter());
            }
            if (!Resources.ContainsKey("IsNullToBoolConverter"))
            {
                Resources.Add("IsNullToBoolConverter", new IsNullToBoolConverter());
            }
            if (!Resources.ContainsKey("NullIntValueConverter"))
            {
                Resources.Add("NullIntValueConverter", new NullIntValueConverter());
            }
            if (!Resources.ContainsKey("TypeEventColorConverter"))
            {
                Resources.Add("TypeEventColorConverter", new TypeEventColorConverter());
            }
            if (!Resources.ContainsKey("TypeEventImageConverter"))
            {
                Resources.Add("TypeEventImageConverter", new TypeEventImageConverter());
            }
            if (!Resources.ContainsKey("TypeEventTextConverter"))
            {
                Resources.Add("TypeEventTextConverter", new TypeEventTextConverter());
            }
            if (!Resources.ContainsKey("NotBooleanConverter"))
            {
                Resources.Add("NotBooleanConverter", new NotBooleanConverter());
            }




            if (!Resources.ContainsKey("PrimaryTextColor"))
            {
                Resources.Add("PrimaryTextColor", Color.FromHex("#333"));
            }
            if (!Resources.ContainsKey("SecondaryTextColor"))
            {
                Resources.Add("SecondaryTextColor", Color.FromHex("#FFFFFF"));
            }
            if (!Resources.ContainsKey("MgcColor"))
            {
                Resources.Add("MgcColor", Color.FromHex("#63388a"));
            }
            if (!Resources.ContainsKey("AsphaltPrimary"))
            {
                Resources.Add("AsphaltPrimary", Color.FromHex("#5c7d90"));
            }
            if (!Resources.ContainsKey("RedPrimary"))
            {
                Resources.Add("RedPrimary", Color.FromHex("#F56D50"));
            }
            if (!Resources.ContainsKey("GrayUltraLight"))
            {
                Resources.Add("GrayUltraLight", Color.FromHex("#FFFFFF"));
            }
            if (!Resources.ContainsKey("GrayPrimary"))
            {
                Resources.Add("GrayPrimary", Color.FromHex("#B9B9B9"));
            }
            if (!Resources.ContainsKey("GrayLight"))
            {
                Resources.Add("GrayLight", Color.FromHex("#F2F2F2"));
            }
            if (!Resources.ContainsKey("GrayDark"))
            {
                Resources.Add("GrayDark", Color.FromHex("#959595"));
            }
            if (!Resources.ContainsKey("GrayMedium"))
            {
                Resources.Add("GrayMedium", Color.FromHex("#B9B9B9"));
            }


            if (!Resources.ContainsKey("TitleFont"))
            {
                Resources.Add("TitleFont", (double)20);
            }
            if (!Resources.ContainsKey("HandleFont"))
            {
                Resources.Add("HandleFont", (double)12);
            }
            if (!Resources.ContainsKey("BodyFont"))
            {
                Resources.Add("BodyFont", (double)12);
            }
            if (!Resources.ContainsKey("HeaderFont"))
            {
                Resources.Add("HeaderFont", (double)30);
            }
            if (!Resources.ContainsKey("SubHeaderFont"))
            {
                Resources.Add("SubHeaderFont", (double)18);
            }
            if (!Resources.ContainsKey("TitleMediumFont"))
            {
                Resources.Add("TitleMediumFont", (double)20);
            }
            if (!Resources.ContainsKey("BodyMediumFont"))
            {
                Resources.Add("BodyMediumFont", (double)18);
            }


            if (!Resources.ContainsKey("RegularFontFamily"))
            {
                Resources.Add("RegularFontFamily", new
                {
                    Android = "sans-serif",
                    iOS = "HelveticaNeue"
                });
            }
        }
    }
}
