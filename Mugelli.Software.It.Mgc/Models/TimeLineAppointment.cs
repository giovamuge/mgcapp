using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        public AppointmentsGroupped(string name, string shortname, IEnumerable<Appointment> items)
        {
            Name = name;
            ShortName = shortname;
            AddRange(items);
        }
    }

    public class ObservableGroupCollection<TS, T> : ObservableCollection<T>
    {
        public ObservableGroupCollection(IGrouping<TS, T> group)
            : base(group)
        {
            Key = group.Key;
        }

        public TS Key { get; }
    }
}