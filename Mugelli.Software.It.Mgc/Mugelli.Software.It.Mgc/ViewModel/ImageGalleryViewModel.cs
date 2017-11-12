using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Navigations;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class ImageGalleryViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private List<string> _images;

        public List<string> Images
        {
            get => _images;
            set
            {
                RaisePropertyChanged(nameof(Images), _images, value);
                _images = value;
            }
        }

        public ICommand GoBack { get; set; }

        public ImageGalleryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoBack = new RelayCommand(OnToBack);
        }

        private void OnToBack()
        {
            _navigationService.GoBack();
        }
    }
}
