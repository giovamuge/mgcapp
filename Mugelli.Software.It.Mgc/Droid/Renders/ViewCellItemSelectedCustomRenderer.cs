using Mugelli.Software.It.Mgc.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Resource = Mugelli.Software.It.Mgc.Droid.Resources.Resource;

[assembly: ExportRenderer(typeof(ViewCell), typeof(ViewCellItemSelectedCustomRenderer))]
namespace Mugelli.Software.It.Mgc.Droid.Renders
{
    public class ViewCellItemSelectedCustomRenderer : ViewCellRenderer
    {
        protected override global::Android.Views.View GetCellCore(Cell item, global::Android.Views.View convertView, global::Android.Views.ViewGroup parent, global::Android.Content.Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context);

            cell.SetBackgroundResource(Resource.Drawable.ViewCellBackground);

            return cell;
        }
    }
}