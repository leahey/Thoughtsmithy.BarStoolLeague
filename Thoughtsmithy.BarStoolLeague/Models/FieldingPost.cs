using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class FieldingPost
    {
        public string PlayerId { get; set; }
        public short YearId { get; set; }
        public string TeamId { get; set; }
        public string LeagueId { get; set; }
        public string Round { get; set; }
        public string Pos { get; set; }
        public short? G { get; set; }
        public short? GS { get; set; }
        public short? InnOuts { get; set; }
        public short? PO { get; set; }
        public short? A { get; set; }
        public short? E { get; set; }
        public short? DP { get; set; }
        public short? TP { get; set; }
        public short? PB { get; set; }
        public short? SB { get; set; }
        public short? CS { get; set; }

        public virtual Person Player { get; set; }
    }
}
