using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Helper;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Services;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class ComunicationsViewModel : ViewModelBase
    {
        public ComunicationsViewModel()
        {
            RefreshCommand = new RelayCommand(OnRefresh);

            OnRefresh();
        }

        public ICommand RefreshCommand { get; set; }

        public List<Communication> CommunicationsList { get; set; }

        public string Title { get; set; } = "Avvisi";
        public string Icon { get; set; } = OnPlatformHelper.IconOniOS("Advertising_50px.png");

        public bool IsRefreshing { get; set; }

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
    }
}