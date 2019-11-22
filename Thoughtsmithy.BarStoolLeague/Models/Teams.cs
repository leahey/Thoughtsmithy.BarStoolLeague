using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class Teams
    {
        public Teams()
        {
            AllstarFull = new HashSet<AllstarFull>();
            Appearances = new HashSet<Appearances>();
            Managers = new HashSet<Managers>();
            ManagersHalf = new HashSet<ManagersHalf>();
            Salaries = new HashSet<Salaries>();
            SeriesPostTeams = new HashSet<SeriesPost>();
            SeriesPostTeamsNavigation = new HashSet<SeriesPost>();
            TeamsHalf = new HashSet<TeamsHalf>();
        }

        public short YearId { get; set; }
        public string LeagueId { get; set; }
        public string TeamId { get; set; }
        public string FranchId { get; set; }
        public string divID { get; set; }
        public short? Rank { get; set; }
        public short? G { get; set; }
        public short? Ghome { get; set; }
        public short? W { get; set; }
        public short? L { get; set; }
        public string DivWin { get; set; }
        public string WCWin { get; set; }
        public string LgWin { get; set; }
        public string WSWin { get; set; }
        public short? R { get; set; }
        public short? AB { get; set; }
        public short? H { get; set; }
        public short? _2B { get; set; }
        public short? _3B { get; set; }
        public short? HR { get; set; }
        public short? BB { get; set; }
        public short? SO { get; set; }
        public short? SB { get; set; }
        public short? CS { get; set; }
        public short? HBP { get; set; }
        public short? SF { get; set; }
        public short? RA { get; set; }
        public short? ER { get; set; }
        public double? ERA { get; set; }
        public short? CG { get; set; }
        public short? SHO { get; set; }
        public short? SV { get; set; }
        public int? IPouts { get; set; }
        public short? HA { get; set; }
        public short? HRA { get; set; }
        public short? BBA { get; set; }
        public short? SOA { get; set; }
        public int? E { get; set; }
        public int? DP { get; set; }
        public double? FP { get; set; }
        public string Name { get; set; }
        public string Park { get; set; }
        public int? Attendance { get; set; }
        public int? BPF { get; set; }
        public int? PPF { get; set; }
        public string teamIDBR { get; set; }
        public string teamIDlahman45 { get; set; }
        public string teamIDretro { get; set; }

        public virtual TeamsFranchises Franchises { get; set; }
        public virtual ICollection<AllstarFull> AllstarFull { get; set; }
        public virtual ICollection<Appearances> Appearances { get; set; }
        public virtual ICollection<Managers> Managers { get; set; }
        public virtual ICollection<ManagersHalf> ManagersHalf { get; set; }
        public virtual ICollection<Salaries> Salaries { get; set; }
        public virtual ICollection<SeriesPost> SeriesPostTeams { get; set; }
        public virtual ICollection<SeriesPost> SeriesPostTeamsNavigation { get; set; }
        public virtual ICollection<TeamsHalf> TeamsHalf { get; set; }
    }
}
