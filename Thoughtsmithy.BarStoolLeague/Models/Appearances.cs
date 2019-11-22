using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class Appearances
    {
        public short YearId { get; set; }
        public string TeamId { get; set; }
        public string LeagueId { get; set; }
        public string PlayerId { get; set; }
        public short? G_all { get; set; }
        public short? GS { get; set; }
        public short? G_batting { get; set; }
        public short? G_defense { get; set; }
        public short? G_p { get; set; }
        public short? G_c { get; set; }
        public short? G_1b { get; set; }
        public short? G_2b { get; set; }
        public short? G_3b { get; set; }
        public short? G_ss { get; set; }
        public short? G_lf { get; set; }
        public short? G_cf { get; set; }
        public short? G_rf { get; set; }
        public short? G_of { get; set; }
        public short? G_dh { get; set; }
        public short? G_ph { get; set; }
        public short? G_pr { get; set; }

        public virtual Teams Teams { get; set; }
        public virtual Person Player { get; set; }
    }
}
