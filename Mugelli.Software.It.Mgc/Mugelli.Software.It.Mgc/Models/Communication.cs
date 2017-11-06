using System;
using Mugelli.Software.It.Mgc.Models.Types;

namespace Mugelli.Software.It.Mgc.Models
{
    public class Communication
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public EventType Type { get; set; }
        public DateTime Date { get; set; }
    }
}