using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Mugelli.Software.It.Mgc.Commons;
using Mugelli.Software.It.Mgc.Extensions;
using Mugelli.Software.It.Mgc.Models;
using Newtonsoft.Json;

namespace Mugelli.Software.It.Mgc.Services
{
    public class RssFeddService : IRssFeedService
    {
        public async Task<FeedRss> GetRss()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(new Uri(RssFeedCommon.Url));
                if (!response.IsSuccessStatusCode) return null;
                var content = await response.Content.ReadAsStringAsync();
                //var data = ConvertXml(content);
                return JsonConvert.DeserializeObject<FeedRss>(content);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static object ConvertXml(string xml)
        {
            //try
            //{
            //    var serializer = new XmlSerializer(typeof(object));
            //    var i = 0;
            //    foreach (var item in xml.ToParseList())
            //    {
            //        xml.Remove(i);
            //        if(item = "<item>")
            //            continue;

            //        i++;
            //    }


            //    var stringReader = new StringReader(xml);
            //    var result = serializer.Deserialize(stringReader);
            //    return result;
            //}
            //catch (Exception ex)
            //{
            return null;
            //}
        }

        //private string TextToRemoved = @"<?xml version=\"1.0\" encoding=\"UTF-8\"?><rss version=\"2.0\"\r\n\txmlns:content=\"http://purl.org/rss/1.0/modules/content/\"\r\n\txmlns:wfw=\"http://wellformedweb.org/CommentAPI/\"\r\n\txmlns:dc=\"http://purl.org/dc/elements/1.1/\"\r\n\txmlns:atom=\"http://www.w3.org/2005/Atom\"\r\n\txmlns:sy=\"http://purl.org/rss/1.0/modules/syndication/\"\r\n\txmlns:slash=\"http://purl.org/rss/1.0/modules/slash/\"\r\n\t>";
    }
}