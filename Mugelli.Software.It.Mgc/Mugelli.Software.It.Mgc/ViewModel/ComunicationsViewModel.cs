using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Helper;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Services;
using Mugelli.Software.It.Mgc.Stacks;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class ComunicationsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ComunicationsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            RefreshCommand = new RelayCommand(OnRefresh);
            ReadCommCommand = new RelayCommand(OnReadCommCommand);

            OnRefresh();
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

        private Communication _readCommSelected { get; set; }
        public Communication ReadCommSelected
        {
            get => _readCommSelected;
            set
            {
                RaisePropertyChanged(nameof(Communication), _readCommSelected, value);
                _readCommSelected = value;
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

        private void OnRefresh()
        {
            IsRefreshing = true;
            Task.Factory.StartNew(async () =>
            {
                var calendars = await FirebaseRestHelper.Instance.GetCommunications();
                CommunicationsList = calendars;
                IsRefreshing = false;
            });
        }

        private void OnReadCommCommand()
        {
            _navigationService.NavigateTo(PageStacks.CommunicationDetailPage, ReadCommSelected);
            ReadCommSelected = null;
        }
    }
}