using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Services;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class ImageGalleryViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IStatusBar _statusBar;
        private List<string> _images;

        public ImageGalleryViewModel(INavigationService navigationService, IStatusBar statusBar)
        {
            _navigationService = navigationService;
            _statusBar = statusBar;

            GoBack = new RelayCommand(OnToBack);
        }

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

        private void OnToBack()
        {
            _navigationService.GoBack();
            _statusBar.ShowStatusBar();
        }
    }
}