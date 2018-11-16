using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Commons;
using Mugelli.Software.It.Mgc.Helper;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Services;
using Mugelli.Software.It.Mgc.Stacks;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class CalendarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private List<Appointment> _appointments;

        private List<AppointmentsGroupped> _appointmentsGroupped;

        private bool _isRefreshing;

        public CalendarViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowAppointmentCommand = new RelayCommand<Appointment>(OnShowAppointment);
            RefreshCommand = new RelayCommand(OnRefresh);

            OnRefresh();
        }

        public ICommand RefreshCommand { get; set; }

        public string Title { get; set; } = "Calendar";
        public string Icon { get; set; } = OnPlatformHelper.IconOniOS("Calendar_50px.png");

        public List<Appointment> Appointments
        {
            get => _appointments;
            set
            {
                RaisePropertyChanged(nameof(Appointments), _appointments, value);
                _appointments = value;
            }
        }

        public List<AppointmentsGroupped> AppointmentsGroupped
        {
            get => _appointmentsGroupped;
            set
            {
                RaisePropertyChanged(nameof(AppointmentsGroupped), _appointmentsGroupped, value);
                _appointmentsGroupped = value;
            }
        }

        public ICommand ShowAppointmentCommand { get; set; }

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
                var calendars = await FirebaseRestHelper.Instance.GetCalendar();

                var groupped = calendars.OrderBy(x => x.Date).GroupBy(x => new {x.Date.Month, x.Date.Year}).Select(x =>
                    new AppointmentsGroupped(
                        $"{ConstantCommon.Month[x.Key.Month - 1]} {x.Key.Year}",
                        $"{ConstantCommon.ShortMonth[x.Key.Month - 1]} {x.Key.Year}",
                        x)).ToList();

                AppointmentsGroupped = groupped;

                IsRefreshing = false;
            });
        }

        private void OnShowAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                Device.BeginInvokeOnMainThread(async () => await Application.Current.MainPage.DisplayAlert("Errore", "Non è possibile visualizzare l'appuntamento, contatta Giova per risolvere il bug", "Ok"));
                return;
            }

            _navigationService.NavigateTo(PageStacks.CalendarDetailPage, appointment);
            //AppointmentSelected = null;
        }
    }
}