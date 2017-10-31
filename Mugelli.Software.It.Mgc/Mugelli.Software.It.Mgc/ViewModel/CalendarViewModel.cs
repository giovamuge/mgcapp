using GalaSoft.MvvmLight;
using Mugelli.Software.It.Mgc.Helper;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class CalendarViewModel : ViewModelBase
    {
        public string Title { get; set; } = "Calendario";
        public string Icon { get; set; } = OnPlatformHelper.IconOniOS("Calendar_50px.png");
    }
}