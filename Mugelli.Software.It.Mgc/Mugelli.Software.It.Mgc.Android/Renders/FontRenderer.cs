using System;
using Android.Graphics;
using Android.Widget;
using Mugelli.Software.It.Mgc.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Xamarin.Forms.Button;

[assembly: ExportRenderer(typeof(Label), typeof(FontRenderer.AwesomeLabelRenderer))]
[assembly: ExportRenderer(typeof(Button), typeof(FontRenderer.AwesomeButtonRenderer))]
namespace Mugelli.Software.It.Mgc.Droid.Renders
{
    public class FontRenderer
    {
        public class AwesomeLabelRenderer : LabelRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
                base.OnElementChanged(e);

                AwesomeUtil.CheckAndSetTypeFace(Control);
            }
        }

        public class AwesomeButtonRenderer : ButtonRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
            {
                base.OnElementChanged(e);

                AwesomeUtil.CheckAndSetTypeFace(Control);
            }
        }

        internal static class AwesomeUtil
        {
            public static void CheckAndSetTypeFace(TextView view)
            {
                if (view.Text.Length == 0) return;
                var text = view.Text;
                if (text.Length > 1 || text[0] < 0xf000)
                {
                    return;
                }

                var font = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, "fontawesome.ttf");
                view.Typeface = font;
            }
        }
    }
}
