using System;
using System.Collections.Generic;
using Mugelli.Software.It.Mgc.Commons;
using Mugelli.Software.It.Mgc.Models.Types;

namespace Mugelli.Software.It.Mgc.Models
{
    public class Appointment
    {
        private EventType _type;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }

        public EventType Type
        {
            get => LogicsCommon.GetTypeByDescription($"{Title}{Description}");
            set => _type = value;
        }

        public List<TimeLineAppointment> TimeLine { get; set; }
    }
}