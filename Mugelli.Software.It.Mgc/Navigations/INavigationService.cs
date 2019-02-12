using System;
using System.Threading.Tasks;
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

        Task PushModal(string pageKey, object paramter);

        Task PopModal();
    }
}