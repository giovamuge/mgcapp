using GalaSoft.MvvmLight;
using Mugelli.Software.It.Mgc.Helper;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class ComunicationsViewModel : ViewModelBase
    {
        public string Title { get; set; } = "Avvisi";
        public string Icon { get; set; } = OnPlatformHelper.IconOniOS("Advertising_50px.png");
    }
}