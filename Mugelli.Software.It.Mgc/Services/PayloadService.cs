using Mugelli.Software.It.Mgc.MessagingCenters;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Stacks;

namespace Mugelli.Software.It.Mgc.Services
{
    public class PayloadService : IPayloadService
    {
        private readonly INavigationService _navigationService;

        public PayloadService(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnViewPayload(PayloadMessage obj)
        {
            _navigationService.NavigateTo(PageStacks.CommunicationDetailPage, new Communication());
        }
    }
}
