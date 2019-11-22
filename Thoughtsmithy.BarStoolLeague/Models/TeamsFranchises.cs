using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class TeamsFranchises
    {
        public TeamsFranchises()
        {
            Teams = new HashSet<Teams>();
        }

        public string FranchId { get; set; }
        public string FranchName { get; set; }
        public string Active { get; set; }
        public string NAassoc { get; set; }

        public virtual ICollection<Teams> Teams { get; set; }
    }
}
