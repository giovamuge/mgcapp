using Android.Text;
using Android.Widget;
using Mugelli.Software.It.Mgc.Droid.Renders;
using Mugelli.Software.It.Mgc.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HtmlFormatLabel), typeof(HtmlFormatLabelRenderer))]

namespace Mugelli.Software.It.Mgc.Droid.Renders
{
    public class HtmlFormatLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (HtmlFormatLabel) Element;
            if (view == null || string.IsNullOrEmpty(view.Text)) return;

            Control.SetText(Html.FromHtml(view.Text), TextView.BufferType.Spannable);
        }
    }
}