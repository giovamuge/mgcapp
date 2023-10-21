using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Helper;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Models.Types;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Services;
using Mugelli.Software.It.Mgc.Stacks;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class ComunicationsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ComunicationsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            RefreshCommand = new RelayCommand(() => Task.Run(OnRefresh));
            ReadCommCommand = new RelayCommand<Communication>(OnReadCommCommand);

            Task.Run(OnRefresh);
        }

        public ICommand RefreshCommand { get; set; }
        public ICommand ReadCommCommand { get; set; }

        private List<Communication> _communicationList;
        public List<Communication> CommunicationsList
        {
            get => _communicationList;
            set
            {
                RaisePropertyChanged(nameof(CommunicationsList), _communicationList, value);
                _communicationList = value;
            }
        }

        public string Title { get; set; } = "Avvisi";
        public string Icon { get; set; } = OnPlatformHelper.IconOniOS("Advertising_50px.png");

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                RaisePropertyChanged(nameof(IsRefreshing), _isRefreshing, value);
                _isRefreshing = value;
            }
        }

        private async Task OnRefresh()
        {
            IsRefreshing = true;
            var calendars = await FirebaseRestHelper.Instance.GetCommunications();
            CommunicationsList = calendars;
            IsRefreshing = false;
        }

        private void OnReadCommCommand(Communication communication)
        {
            if (communication == null)
            {
                Device.BeginInvokeOnMainThread(async () => await Application.Current.MainPage.DisplayAlert("Errore", "Non è possibile visualizzare l'avviso, contatta Giova per risolvere il bug", "Ok"));
                return;
            }

            _navigationService.NavigateTo(PageStacks.CommunicationDetailPage, communication);
        }
    }
}