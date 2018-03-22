using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Navigations;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class CommunicationDetailViewModel : ViewModelBase
    {
        private Communication _communication;

        public Communication Communication
        {
            get => _communication;
            set
            {
                RaisePropertyChanged(nameof(Communication), _communication, value);
                _communication = value;
            }
        }

        public string Title { get; set; }
        public ICommand GoBack { get; set; }

        private readonly INavigationService _navigationService;

        public CommunicationDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoBack = new RelayCommand(_navigationService.GoBack); 
        }
    }
}
