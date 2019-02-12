using System.Threading.Tasks;
using Mugelli.Software.It.Mgc.Models;

namespace Mugelli.Software.It.Mgc.Services
{
    public interface IRssFeedService
    {
        Task<FeedRss> GetRss();
    }
}