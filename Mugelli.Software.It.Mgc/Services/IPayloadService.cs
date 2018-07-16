using System.Threading.Tasks;
using Mugelli.Software.It.Mgc.MessagingCenters;

namespace Mugelli.Software.It.Mgc.Services
{
    public interface IPayloadService
    {
        void OnViewPayload(PayloadMessage obj);
    }
}
