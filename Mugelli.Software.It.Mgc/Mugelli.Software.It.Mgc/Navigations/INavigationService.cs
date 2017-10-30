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

    //public interface INavigationService
    //{
    //    void GoBack();

    //    bool CanGoBack();

    //    void NavigateTo(string pageKey);

    //    // Required for interface
    //    void NavigateTo(string pageKey, object parameter);

    //    // Two or more parameters
    //    void NavigateTo(string pageKey, object parameter1, object parameter2, object parameter3 = null,
    //        object parameter4 = null, object parameter5 = null, object parameter6 = null);

    //    //void NavigateTo(string pageKey, object parameter1, object parameter2, object parameter3,
    //    //    object parameter4, object parameter5, object parameter6, bool replaceRoot);

    //    //ConstructorInfo GetConstructor(Type type, object[] parameters);

    //    void Configure(string pageKey, Type pageType);

    //    void SetNewRoot(string pageKey);
    //}
}