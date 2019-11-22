using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class BattingPost
    {
        public short YearId { get; set; }
        public string Round { get; set; }
        public string PlayerId { get; set; }
        public string TeamId { get; set; }
        public string LeagueId { get; set; }
        public short? G { get; set; }
        public short? AB { get; set; }
        public short? R { get; set; }
        public short? H { get; set; }
        public short? _2B { get; set; }
        public short? _3B { get; set; }
        public short? HR { get; set; }
        public short? RBI { get; set; }
        public short? SB { get; set; }
        public short? CS { get; set; }
        public short? BB { get; set; }
        public short? SO { get; set; }
        public short? IBB { get; set; }
        public short? HBP { get; set; }
        public short? SH { get; set; }
        public short? SF { get; set; }
        public short? GIDP { get; set; }

        public virtual Person Player { get; set; }
    }
}
