using Mugelli.Software.It.Mgc.Models;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class CalendarDetailViewModel : BaseViewModel
    {
        private Appointment _appointment;

        public Appointment Appointment
        {
            get => _appointment;
            set
            {
                RaisePropertyChanged(nameof(Appointment), _appointment, value);
                _appointment = value;
            }
        }

        public string Title { get; set; } = "Programma";

        public CalendarDetailViewModel() { }
    }
}