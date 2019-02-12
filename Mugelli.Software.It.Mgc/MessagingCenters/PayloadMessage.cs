using System;
using Newtonsoft.Json;

namespace Mugelli.Software.It.Mgc.MessagingCenters
{
    public class PayloadMessage
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Type { get; set; }
    }
}
