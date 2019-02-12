using System;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Navigations;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class InfoViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        public InfoViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CloseModal = new RelayCommand(() =>  _navigationService.PopModal());
        }

        public ICommand CloseModal { get; set; }
    }
}
