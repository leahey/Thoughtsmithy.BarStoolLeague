using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Thoughtsmithy.BarStoolLeague.Models.Configurations;

namespace Thoughtsmithy.BarStoolLeague.Models
{
    public partial class BarStoolLeagueContext : DbContext
    {
        public BarStoolLeagueContext()
        {
        }

        public BarStoolLeagueContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<AllstarFull> AllstarFull { get; set; }
        public virtual DbSet<Appearances> Appearances { get; set; }
        public virtual DbSet<AwardsManagers> AwardsManagers { get; set; }
        public virtual DbSet<AwardsPlayers> AwardsPlayers { get; set; }
        public virtual DbSet<AwardsShareManagers> AwardsShareManagers { get; set; }
        public virtual DbSet<AwardsSharePlayers> AwardsSharePlayers { get; set; }
        public virtual DbSet<Batting> Batting { get; set; }
        public virtual DbSet<BattingPost> BattingPost { get; set; }
        public virtual DbSet<CollegePlaying> CollegePlaying { get; set; }
        public virtual DbSet<Fielding> Fielding { get; set; }
        public virtual DbSet<FieldingOf> FieldingOf { get; set; }
        public virtual DbSet<FieldingOfsplit> FieldingOfsplit { get; set; }
        public virtual DbSet<FieldingPost> FieldingPost { get; set; }
        public virtual DbSet<HallOfFame> HallOfFame { get; set; }
        public virtual DbSet<HomeGames> HomeGames { get; set; }
        //public virtual DbSet<Managers> Managers { get; set; }
        //public virtual DbSet<ManagersHalf> ManagersHalf { get; set; }
        //public virtual DbSet<Parks> Parks { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Pitching> Pitching { get; set; }
        //public virtual DbSet<PitchingPost> PitchingPost { get; set; }
        //public virtual DbSet<Salaries> Salaries { get; set; }
        //public virtual DbSet<Schools> Schools { get; set; }
        //public virtual DbSet<SeriesPost> SeriesPost { get; set; }
        //public virtual DbSet<Teams> Teams { get; set; }
        //public virtual DbSet<TeamsFranchises> TeamsFranchises { get; set; }
        //public virtual DbSet<TeamsHalf> TeamsHalf { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ROBERTLEAHEY-I9\\SQLEXPRESS;Initial Catalog=LahmansBaseballDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AllstarFullConfiguration());
            modelBuilder.ApplyConfiguration(new AppearanceConfiguration());
            modelBuilder.ApplyConfiguration(new AwardsManagersConfiguration());
            modelBuilder.ApplyConfiguration(new AwardsPlayersConfiguration());
            modelBuilder.ApplyConfiguration(new BattingConfiguration());
            modelBuilder.ApplyConfiguration(new FieldingConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PitchingConfiguration());


    
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
