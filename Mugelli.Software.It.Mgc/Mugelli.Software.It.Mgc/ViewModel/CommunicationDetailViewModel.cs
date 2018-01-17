using System;
using GalaSoft.MvvmLight;
using Mugelli.Software.It.Mgc.Models;

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

        public CommunicationDetailViewModel() { }
    }
}
