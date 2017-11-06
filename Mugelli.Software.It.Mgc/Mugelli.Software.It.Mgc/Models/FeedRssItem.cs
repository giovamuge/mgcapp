using System;
using System.Net;
using System.Text.RegularExpressions;
using Mugelli.Software.It.Mgc.Extensions;
using Newtonsoft.Json;

namespace Mugelli.Software.It.Mgc.Models
{
    public class FeedRssItem
    {
        private string _content;

        private string _heroImage;
        private string _title;

        public string Title
        {
            get => _title;
            set => _title = WebUtility.HtmlDecode(value);
        }

        public string Url { get; set; }

        [JsonProperty("content_html")]
        public string ContentHtml { get; set; }

        public string Content
        {
            get => ContentHtml.StripHtml().Truncate(25);
            set => _content = value;
        }

        [JsonProperty("date_published")]
        public DateTime DatePublished { get; set; }

        public Author Author { get; set; }

        public string HeroImage
        {
            get => GetHeroImage(ContentHtml);
            set => _heroImage = value;
        }

        private static string GetHeroImage(string value)
        {
            var r = new Regex(@"<img (.+?)>");
            foreach (Match m in r.Matches(value))
            {
                var img = m.Groups[0].Value;
                if (!img.Contains("src")) continue;
                
                var pattern = new Regex(@"(?<=\bsrc="")[^""]*");
                var src = pattern.Match(value).Groups[0].Value;
                return src;
                //if (Uri.TryCreate(src, UriKind.RelativeOrAbsolute, out var result))
                //    return result;
            }
            //Default value
            //return new Uri("PiccoloPrincipe.jpg");
            return "PiccoloPrincipe.jpg";
        }

    }
}