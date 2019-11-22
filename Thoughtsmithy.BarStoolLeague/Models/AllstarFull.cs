using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class AllstarFull
    {
        public string PlayerId { get; set; }
        public short YearId { get; set; }
        public short GameNum { get; set; }
        public string GameId { get; set; }
        public string TeamId { get; set; }
        public string LeagueId { get; set; }
        public short? GP { get; set; }
        public short? StartingPos { get; set; }

        public virtual Teams Teams { get; set; }
        public virtual Person Player { get; set; }
    }
}
