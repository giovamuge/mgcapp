using System;
using System.Web;
using Mugelli.Software.It.Mgc.Extensions;
using Newtonsoft.Json;

namespace Mugelli.Software.It.Mgc.Models
{
    public class FeedRssItem
    {
        private string _content;
        private string _title;

        public string Title
        {
            get => _title;
            set => _title =  value/*HttpUtility.HtmlEncode(value)*/;
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

        public string HeroImage { get; set; } = "PiccoloPrincipe.jpg";
    }
}