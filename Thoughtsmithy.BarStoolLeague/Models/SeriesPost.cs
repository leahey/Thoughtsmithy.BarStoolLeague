using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class SeriesPost
    {
        public short YearId { get; set; }
        public string Round { get; set; }
        public string TeamIdWinner { get; set; }
        public string LeagueIdWinner { get; set; }
        public string TeamIdLoser { get; set; }
        public string LeagueIdLoser { get; set; }
        public short? Wins { get; set; }
        public short? Losses { get; set; }
        public short? Ties { get; set; }

        public virtual Teams Teams { get; set; }
        public virtual Teams TeamsNavigation { get; set; }
    }
}
