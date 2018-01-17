using System;
using Mugelli.Software.It.Mgc.Models;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class CommunicationDetailViewModel: BaseViewModel
    {
        private Communication _comm;

        public Communication Comm
        {
            get => _comm;
            set
            {
                RaisePropertyChanged(nameof(Communication), _comm, value);
                _comm = value;
            }
        }

        public string Title { get; set; }

        public CommunicationDetailViewModel() { }
    }
}
