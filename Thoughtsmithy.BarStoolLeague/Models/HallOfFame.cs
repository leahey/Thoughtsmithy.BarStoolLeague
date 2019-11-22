using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class HallOfFame
    {
        public string PlayerId { get; set; }
        public DateTime YearId { get; set; }
        public string VotedBy { get; set; }
        public short? Ballots { get; set; }
        public short? Needed { get; set; }
        public short? Votes { get; set; }
        public string Inducted { get; set; }
        public string Category { get; set; }
        public string Needed_note { get; set; }

        public virtual Person Player { get; set; }
    }
}
