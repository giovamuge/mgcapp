using Xamarin.Forms;
using Mugelli.Software.It.Mgc.ViewModel;

namespace Mugelli.Software.It.Mgc.Pages
{
    public partial class NewsPage : ContentPage
    {
        private NewsViewModel _vm;

        public NewsPage()
        {
            InitializeComponent();
            _vm = BindingContext as NewsViewModel;
            //_vm.OnInit();
        }
    }
}
