using System;
using Mugelli.Software.It.Mgc.Commons;
using Mugelli.Software.It.Mgc.Extensions;
using Mugelli.Software.It.Mgc.Models.Types;

namespace Mugelli.Software.It.Mgc.Models
{
    public class Communication
    {
        private EventType _type;
        public string Title { get; set; }
        public string Content { get; set; }

        public EventType Type
        {
            get => LogicsCommon.GetTypeByDescription($"{Title}{Content}");
            set => _type = value;
        }

        public DateTime Date { get; set; }
        public string Author { get; set; }

        public string ShortContent
        {
            get => Content.Truncate(500, true);
            set => Content = value;
        }
    }

    public class CommunicationLess
    {
        private EventType _type;
        public string Title { get; set; }
        public string Content { get; set; }

        public EventType type
        {
            get => _type;
            set => _type = LogicsCommon.GetTypeByDescription($"{Title}{Content}");
        }

        public DateTime Date { get; set; }
        public string Author { get; set; }
    }
}