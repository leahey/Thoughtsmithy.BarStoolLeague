using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class Salaries
    {
        public short YearId { get; set; }
        public string TeamId { get; set; }
        public string LeagueId { get; set; }
        public string PlayerId { get; set; }
        public double? Salary { get; set; }

        public virtual Teams Teams { get; set; }
        public virtual Person Player { get; set; }
    }
}
