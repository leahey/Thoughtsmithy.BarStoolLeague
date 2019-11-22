using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class PitchingPost
    {
        public string PlayerId { get; set; }
        public short YearId { get; set; }
        public string Round { get; set; }
        public string TeamId { get; set; }
        public string LeagueId { get; set; }
        public short? Wins { get; set; }
        public short? Losses { get; set; }
        public short? Games { get; set; }
        public short? GamesStarted { get; set; }
        public short? CG { get; set; }
        public short? SHO { get; set; }
        public short? SV { get; set; }
        public int? IPouts { get; set; }
        public short? H { get; set; }
        public short? ER { get; set; }
        public short? HR { get; set; }
        public short? BB { get; set; }
        public short? SO { get; set; }
        public double? BAOpp { get; set; }
        public double? ERA { get; set; }
        public short? IBB { get; set; }
        public short? WP { get; set; }
        public short? HBP { get; set; }
        public short? BK { get; set; }
        public short? BFP { get; set; }
        public short? GF { get; set; }
        public short? R { get; set; }
        public short? SH { get; set; }
        public short? SF { get; set; }
        public short? GIDP { get; set; }

        public virtual Person Player { get; set; }
    }
}
