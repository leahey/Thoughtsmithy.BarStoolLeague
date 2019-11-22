using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class ManagersHalf
    {
        public string PlayerId { get; set; }
        public short YearId { get; set; }
        public string TeamId { get; set; }
        public string LeagueId { get; set; }
        public short? InSeason { get; set; }
        public short Half { get; set; }
        public short? Games { get; set; }
        public short? Won { get; set; }
        public short? Lost { get; set; }
        public short? Rank { get; set; }

        public virtual Teams Teams { get; set; }
        public virtual Person Player { get; set; }
    }
}
