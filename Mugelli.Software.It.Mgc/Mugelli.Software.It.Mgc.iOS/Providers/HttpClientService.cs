//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Mugelli.Software.It.Mgc.Commons;
//using Mugelli.Software.It.Mgc.iOS.Providers;
//using Mugelli.Software.It.Mgc.Services;
//using Xamarin.Forms;

//[assembly: Dependency(typeof(HttpClientService))]
//namespace Mugelli.Software.It.Mgc.iOS.Providers
//{
//    public class HttpClientService : IHttpClientService
//    {
//        public async Task<object> GetAsync()
//        {
//            var client = new HttpClient();
//            var uri = new Uri(string.Format(RssFeedCommon.Url));

//            var response = await client.GetAsync(uri);
//            if (!response.IsSuccessStatusCode) return null;
//            return await response.Content.ReadAsStringAsync();
//        }
//    }
//}