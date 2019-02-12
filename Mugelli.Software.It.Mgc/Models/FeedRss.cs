using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mugelli.Software.It.Mgc.Models
{
    public class FeedRss
    {
        [JsonProperty("home_page_url")]
        public string HomePageUrl { get; set; }
        [JsonProperty("items")]
        public List<FeedRssItem> Items { get; set; }
    }
}