using Android.App;
using Android.Views;
using Mugelli.Software.It.Mgc.Droid.Provider;
using Mugelli.Software.It.Mgc.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(StatusBar))]

namespace Mugelli.Software.It.Mgc.Droid.Provider
{
    public class StatusBar : IStatusBar
    {
        private WindowManagerFlags _originalFlags;
        
        public void HideStatusBar()
        {
            var activity = (Activity) Forms.Context;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags |= WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attrs;
        }

        public void ShowStatusBar()
        {
            var activity = (Activity) Forms.Context;
            var attrs = activity.Window.Attributes;
            attrs.Flags = _originalFlags;
            activity.Window.Attributes = attrs;
        }
    }
}