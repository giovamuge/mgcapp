using System.Threading.Tasks;

namespace Mugelli.Software.It.Mgc.Services
{
    public interface IHttpClientService
    {
        Task<object> GetAsync();
    }
}