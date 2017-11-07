using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Mugelli.Software.It.Mgc.Extensions;
using Newtonsoft.Json;

namespace Mugelli.Software.It.Mgc.Models
{
    public class FeedRssItem
    {
        private string _content;
        private string _contentHtml;
        private string _heroImage;
        private string _title;

        public string Title
        {
            get => _title;
            set => _title = WebUtility.HtmlDecode(value);
        }

        public string Url { get; set; }

        [JsonProperty("content_html")]
        public string ContentHtml
        {
            get => _contentHtml;
            set => _contentHtml = WebUtility.HtmlDecode(value);
        }

        public string Content
        {
            get => ContentHtml.StripHtml();
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
                return RemoveSize(src);
                //if (Uri.TryCreate(src, UriKind.RelativeOrAbsolute, out var result))
                //    return result;
            }
            //Default value
            //return new Uri("PiccoloPrincipe.jpg");
            return "PiccoloPrincipe.jpg";
        }

        private static List<string> GetImages(string value)
        {
            return (from Match m in new Regex(@"<img (.+?)>").Matches(value)
                select m.Groups[0].Value
                into img
                where img.Contains("src")
                select new Regex(@"(?<=\bsrc="")[^""]*")
                into pattern
                select RemoveSize(pattern.Match(value).Groups[0].Value)).ToList();
        }

        private static string RemoveSize(string value)
        {
            var slash = value.Split('/');
            var name = slash[slash.Length - 1];
            var namesplit = name.Split('-');
            var size = namesplit[namesplit.Length - 1];
            return value.Replace($"-{size}", ".jpg");
        }
    }
}