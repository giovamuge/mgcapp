using Foundation;
using Mugelli.Software.It.Mgc.iOS.Renders;
using Mugelli.Software.It.Mgc.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HtmlFormatLabel), typeof(HtmlFormatLabelRenderer))]

namespace Mugelli.Software.It.Mgc.iOS.Renders
{
    public class HtmlFormatLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (HtmlFormatLabel) Element;
            if (view == null) return;

            var attr = new NSAttributedStringDocumentAttributes();
            var nsError = new NSError();
            attr.DocumentType = NSDocumentType.HTML;

            Control.AttributedText = new NSAttributedString(view.Text, attr, ref nsError);
        }
    }
}