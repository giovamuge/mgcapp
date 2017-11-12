using Mugelli.Software.It.Mgc.iOS.Providers;
using Mugelli.Software.It.Mgc.Services;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBar))]
namespace Mugelli.Software.It.Mgc.iOS.Providers
{
    public class StatusBar : IStatusBar
    {
        public StatusBar() { }

        public void HideStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = true;
        }

        public void ShowStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
        }
    }
}