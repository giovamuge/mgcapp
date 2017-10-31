using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Mugelli.Software.It.Mgc.Droid.Renders
{
    public class ElementRenderer : VisualElementRenderer<Xamarin.Forms.View>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            SetBackgroundResource(Resource.Drawable.ViewCellBackground);

            base.OnElementChanged(e);
        }
    }
}