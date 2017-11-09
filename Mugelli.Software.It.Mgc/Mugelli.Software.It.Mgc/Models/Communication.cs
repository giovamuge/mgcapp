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
            get => _type;
            set => _type = LogicsCommon.GetTypeByDescription($"{Title}{Content}");
        }

        public DateTime Date { get; set; }
        public string Author { get; set; }
    }
}