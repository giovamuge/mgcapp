using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugelli.Software.It.Mgc.Models.Types;

namespace Mugelli.Software.It.Mgc.Models
{
    public class Appointment
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public EventType Type { get; set; }
        public List<TimeLineAppointment> TimeLine { get; set; }
    }

    public class TimeLineAppointment
    {
        public string Time { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public bool IsLast { get; set; }
    }
}
