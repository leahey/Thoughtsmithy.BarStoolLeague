using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class Parks
    {
        public int ID { get; set; }
        public string ParkAlias { get; set; }
        public string ParkKey { get; set; }
        public string ParkName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
