using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class FieldingOF
    {
        public string PlayerId { get; set; }
        public short YearId { get; set; }
        public short Stint { get; set; }
        public short? Glf { get; set; }
        public short? Gcf { get; set; }
        public short? Grf { get; set; }

        public virtual Person player { get; set; }
    }
}
