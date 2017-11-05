using System;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Navigations
{
    public interface INavigationService
    {
        void GoBack();

        void NavigateTo(string pageKey);

        void NavigateTo(string pageKey, object parameter);

        void Configure(string pageKey, Type pageType);

        void Initialize(NavigationPage navigation);
    }
}