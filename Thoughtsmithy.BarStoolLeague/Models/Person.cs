using System;
using System.Collections.Generic;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class Person
    {
        public Person()
        {
            AllstarFull = new HashSet<AllstarFull>();
            Appearances = new HashSet<Appearances>();
            AwardsPlayers = new HashSet<AwardsPlayers>();
            Batting = new HashSet<Batting>();
            BattingPost = new HashSet<BattingPost>();
            Fielding = new HashSet<Fielding>();
            FieldingOF = new HashSet<FieldingOF>();
            FieldingOFsplit = new HashSet<FieldingOFsplit>();
            FieldingPost = new HashSet<FieldingPost>();
            HallOfFame = new HashSet<HallOfFame>();
            Managers = new HashSet<Managers>();
            ManagersHalf = new HashSet<ManagersHalf>();
            Pitching = new HashSet<Pitching>();
            PitchingPost = new HashSet<PitchingPost>();
            Salaries = new HashSet<Salaries>();
        }

        public string PlayerId { get; set; }
        public int? BirthYear { get; set; }
        public int? BirthMonth { get; set; }
        public int? BirthDay { get; set; }
        public string BirthCountry { get; set; }
        public string BirthState { get; set; }
        public string BirthCity { get; set; }
        public int? DeathYear { get; set; }
        public int? DeathMonth { get; set; }
        public int? DeathDay { get; set; }
        public string DeathCountry { get; set; }
        public string DeathState { get; set; }
        public string DeathCity { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string NameGiven { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public string Bats { get; set; }
        public string Throws { get; set; }
        public string Debut { get; set; }
        public string FinalGame { get; set; }
        public string RetroID { get; set; }
        public string bbrefID { get; set; }

        public virtual ICollection<AllstarFull> AllstarFull { get; set; }
        public virtual ICollection<Appearances> Appearances { get; set; }
        public virtual ICollection<AwardsPlayers> AwardsPlayers { get; set; }
        public virtual ICollection<Batting> Batting { get; set; }
        public virtual ICollection<BattingPost> BattingPost { get; set; }
        public virtual ICollection<Fielding> Fielding { get; set; }
        public virtual ICollection<FieldingOF> FieldingOF { get; set; }
        public virtual ICollection<FieldingOFsplit> FieldingOFsplit { get; set; }
        public virtual ICollection<FieldingPost> FieldingPost { get; set; }
        public virtual ICollection<HallOfFame> HallOfFame { get; set; }
        public virtual ICollection<Managers> Managers { get; set; }
        public virtual ICollection<ManagersHalf> ManagersHalf { get; set; }
        public virtual ICollection<Pitching> Pitching { get; set; }
        public virtual ICollection<PitchingPost> PitchingPost { get; set; }
        public virtual ICollection<Salaries> Salaries { get; set; }
    }
}
