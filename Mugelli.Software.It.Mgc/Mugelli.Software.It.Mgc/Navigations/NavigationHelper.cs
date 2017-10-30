using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Navigations
{
    public static class NavigationHelper
    {
        public static NavigationPage Init()
        {
            var navigation = new NavigationService();

            //Registration navigation
            //nav.Configure(Locator.FirstPage, typeof(FirstPage));
            //nav.Configure(Locator.SecondPage, typeof(SecondPage));
            //nav.Configure(Locator.ThirdPage, typeof(ThirdPage));
            
            SimpleIoc.Default.Register<INavigationService>(() => navigation);

            var start = new NavigationPage(new RootPage());
            navigation.Initialize(start);

            return start;
        }
    }
}
