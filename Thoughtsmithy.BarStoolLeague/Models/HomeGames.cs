using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class HomeGames
    {
        public int? YearKey { get; set; }
        public string LeagueKey { get; set; }
        public string TeamKey { get; set; }
        public string ParkKey { get; set; }
        public string SpanFirst { get; set; }
        public string SpanLast { get; set; }
        public int? Games { get; set; }
        public int? Openings { get; set; }
        public int? Attendance { get; set; }
    }
}
