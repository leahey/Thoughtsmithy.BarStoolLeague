﻿using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class AwardsPlayers
    {
        public string PlayerId { get; set; }
        public string AwardId { get; set; }
        public short YearId { get; set; }
        public string LeagueId { get; set; }
        public string Tie { get; set; }
        public string Notes { get; set; }

        public virtual Person Player { get; set; }
    }
}
