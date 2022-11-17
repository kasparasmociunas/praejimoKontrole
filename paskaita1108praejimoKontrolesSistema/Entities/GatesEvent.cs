using System;
using System.Diagnostics.Metrics;

namespace paskaita1108praejimoKontrolesSistema.Entities
{
    public class GatesEvent
    {
        public int EventId { get; set; }
        public int GateNumber { get; set; }
        public Human Human { get; set; }
        public DateTime Timestamp { get; set; }
        public string Direction { get; set; }







    }
}

