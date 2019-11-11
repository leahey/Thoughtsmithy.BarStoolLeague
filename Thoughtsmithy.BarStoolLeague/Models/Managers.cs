﻿using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class Managers
    {
        public string PlayerId { get; set; }
        public short YearId { get; set; }
        public string TeamId { get; set; }
        public string LgId { get; set; }
        public short Inseason { get; set; }
        public short? G { get; set; }
        public short? W { get; set; }
        public short? L { get; set; }
        public short? Rank { get; set; }
        public string PlyrMgr { get; set; }
    }
}
