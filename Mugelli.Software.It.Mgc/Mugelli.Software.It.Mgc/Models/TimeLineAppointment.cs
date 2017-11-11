using System.Collections.Generic;

namespace Mugelli.Software.It.Mgc.Models
{
    public class TimeLineAppointment
    {
        public string Time { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public bool IsLast { get; set; }
    }

    public class AppointmentsGroupped : List<Appointment>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        //public AppointmentsGroupped(string name, string shortname, List<Appointment> items)
        //{
         //   Name = name;
         //   ShortName = shortname;
         //   foreach (var item in items)
         //   {
         //       Items.Add(item);
        //    }
        //}

        //public List<Appointment> List { get; set; }
    }
}