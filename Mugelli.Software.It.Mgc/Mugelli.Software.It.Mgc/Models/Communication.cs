using System;
using Mugelli.Software.It.Mgc.Commons;
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
    }

    public class CommunicationLess
    {
        private EventType _type;
        public string title { get; set; }
        public string content { get; set; }

        public EventType type
        {
            get => _type;
            set => _type = LogicsCommon.GetTypeByDescription($"{title}{content}");
        }

        public DateTime date { get; set; }
        public string author { get; set; }
    }
}