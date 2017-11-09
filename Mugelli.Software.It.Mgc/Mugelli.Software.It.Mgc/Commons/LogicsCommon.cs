﻿using System.Linq;
using Mugelli.Software.It.Mgc.Models.Types;

namespace Mugelli.Software.It.Mgc.Commons
{
    public static class LogicsCommon
    {
        private static readonly string[] AmmiKeyWords =
        {
            "famiglia",
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
            if (MgcKeyWords.Any(source.Equals))
                return EventType.Mgc;

            if (AmmiKeyWords.Any(source.Equals))
                return EventType.Ammi;

            if (GiovanissimiKeyWords.Any(source.Equals))
                return EventType.Giovanissimi;

            return OblatiKeyWords.Any(source.Equals) 
                ? EventType.Oblati 
                : EventType.Mgc;
        }
    }
}