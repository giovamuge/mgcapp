using System.Linq;
using Mugelli.Software.It.Mgc.Extensions;
using Mugelli.Software.It.Mgc.Models.Types;

namespace Mugelli.Software.It.Mgc.Commons
{
    public static class LogicsCommon
    {
        private static readonly string[] AmmiKeyWords =
        {
            "ammi"
        };

        private static readonly string[] GiovanissimiKeyWords =
        {
            "giova",
            "giovanissimi",
            "campeggione"
        };

        private static readonly string[] MgcKeyWords =
        {
            "mgc",
            "movimento"
        };

        private static readonly string[] OblatiKeyWords =
        {
            "oblat"
        };

        public static EventType GetTypeByDescription(string source)
        {
            var sourceParseList = source.ToParseList(new[] {' '});
            if (MgcKeyWords.Any(x => sourceParseList.Any(y => y.Contains(x))))
                return EventType.Mgc;
            
            if (GiovanissimiKeyWords.Any(x => sourceParseList.Any(y => y.Contains(x))))
                return EventType.Giovanissimi;

            //if (AmmiKeyWords.Any(x => sourceParseList.Any(y => y.Contains(x))))
                //return EventType.Ammi;


            return OblatiKeyWords.Any(x => sourceParseList.Any(y => y.Contains(x)))
                ? EventType.Oblati
                : EventType.Mgc;
        }
    }
}