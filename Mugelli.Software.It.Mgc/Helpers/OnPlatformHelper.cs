using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Helper
{
    public static class OnPlatformHelper
    {
        // ReSharper disable once InconsistentNaming
        public static string IconOniOS(string icon)
        {
            return Device.RuntimePlatform == Device.iOS ? icon : string.Empty;
        }
    }
}