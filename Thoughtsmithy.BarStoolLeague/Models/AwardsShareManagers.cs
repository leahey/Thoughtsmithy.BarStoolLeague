using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class AwardsShareManagers
    {
        public string AwardId { get; set; }
        public short YearId { get; set; }
        public string LeagueId { get; set; }
        public string PlayerId { get; set; }
        public short? PointsWon { get; set; }
        public short? PointsMax { get; set; }
        public short? VotesFirst { get; set; }
    }
}
