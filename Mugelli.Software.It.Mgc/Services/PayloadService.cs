using System.Threading.Tasks;
using Mugelli.Software.It.Mgc.Commons;
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
            switch (obj.Type)
            {
                case ConstantCommon.AdvertisingMessage:
                    Task.Factory.StartNew(async () =>
                    {
                        var advert = await FirebaseRestHelper.Instance.GetAdvertising(obj.Id);
                        _navigationService.NavigateTo(PageStacks.CommunicationDetailPage, advert);
                    });
                    break;
                case ConstantCommon.NewsgMessage:
                    _navigationService.NavigateTo(PageStacks.NewsDetailPage, new NewsDetail());
                    break;
                case ConstantCommon.CalendarMessage:
                    _navigationService.NavigateTo(PageStacks.CalendarDetailPage, new Appointment());
                    break;
            }
        }
    }
}
