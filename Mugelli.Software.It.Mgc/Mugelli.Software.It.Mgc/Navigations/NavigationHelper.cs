using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Mugelli.Software.It.Mgc.Pages;
using Mugelli.Software.It.Mgc.Stacks;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Navigations
{
    public static class NavigationHelper
    {
        public static NavigationPage Init()
        {
            INavigationService navigation;

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                // Setup navigation service:
                navigation = new NavigationService();

                //Registration navigation
                navigation.Configure(PageStacks.RootPage, typeof(RootPage));
                navigation.Configure(PageStacks.NewsDetailPage, typeof(NewsDetailPage));
                navigation.Configure(PageStacks.CalendarDetailPage, typeof(CalendarDetailPage));

                // Register NavigationService in IoC container:
                SimpleIoc.Default.Register(() => navigation);
            }
            else
            {
                navigation = SimpleIoc.Default.GetInstance<INavigationService>();
            }

            var start = new NavigationPage(new RootPage());
            navigation.Initialize(start);

            return start;
        }
    }
}
