using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Mugelli.Software.It.Mgc.Pages;
using Mugelli.Software.It.Mgc.Services;
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
                navigation.Configure(PageStacks.GalleryImagePage, typeof(GalleryImagePage));
                navigation.Configure(PageStacks.CommunicationDetailPage, typeof(CommunicationDetailPage));

                // Register NavigationService in IoC container:
                SimpleIoc.Default.Register(() => navigation);
                SimpleIoc.Default.Register<IRssFeedService>(() => new RssFeddService());
                //SimpleIoc.Default.Register(() => DependencyService.Get<IHttpClientService>());
                SimpleIoc.Default.Register(() => DependencyService.Get<IStatusBar>());
            }
            else
            {
                navigation = SimpleIoc.Default.GetInstance<INavigationService>();
            }

            var start = new NavigationPage(new RootPage())
            {
                 BarBackgroundColor = Color.FromHex("#63388a"),
                 BarTextColor = Color.White
            };
            navigation.Initialize(start);

            return start;
        }
    }
}
