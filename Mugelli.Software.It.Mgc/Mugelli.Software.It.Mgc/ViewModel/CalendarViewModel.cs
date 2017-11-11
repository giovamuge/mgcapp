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

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class CalendarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private List<Appointment> _appointments;

        private Appointment _appointmentSelected;

        private List<AppointmentsGroupped> _appointmentsGroupped;

        private bool _isRefreshing;

        public CalendarViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowAppointmentCommand = new RelayCommand(OnShowAppointment);
            RefreshCommand = new RelayCommand(OnRefresh);

            OnRefresh();
        }

        public ICommand RefreshCommand { get; set; }

        public string Title { get; set; } = "Calendario";
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

        public Appointment AppointmentSelected
        {
            get => _appointmentSelected;
            set
            {
                RaisePropertyChanged(nameof(AppointmentSelected), _appointmentSelected, value);
                _appointmentSelected = value;
            }
        }

        private void OnRefresh()
        {
            IsRefreshing = true;
            Task.Factory.StartNew(async () =>
            {
                var calendars = await FirebaseRestHelper.Instance.GetCalendar();

                var groupped = calendars.GroupBy(x => new {x.Date.Month, x.Date.Year}).Select(x =>
                    new AppointmentsGroupped(
                        $"{ConstantCommon.Month[x.Key.Month - 1]} {x.Key.Year}",
                        $"{ConstantCommon.ShortMonth[x.Key.Month - 1]} {x.Key.Year}",
                        x)).ToList();

                AppointmentsGroupped = groupped;

                IsRefreshing = false;
            });
        }

        private void OnShowAppointment()
        {
            _navigationService.NavigateTo(PageStacks.CalendarDetailPage, AppointmentSelected);
        }
    }
}