using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Thoughtsmithy.BarStoolLeague.Data.Configuration;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data
{
    public partial class BarStoolLeagueContext : DbContext
    {
        public BarStoolLeagueContext()
        {
        }

        public BarStoolLeagueContext(DbContextOptions<BarStoolLeagueContext> options)
            : base(options)
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
        public virtual DbSet<FieldingOF> FieldingOF { get; set; }
        public virtual DbSet<FieldingOFsplit> FieldingOFsplit { get; set; }
        public virtual DbSet<FieldingPost> FieldingPost { get; set; }
        public virtual DbSet<HallOfFame> HallOfFame { get; set; }
        public virtual DbSet<HomeGames> HomeGames { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<ManagersHalf> ManagersHalf { get; set; }
        public virtual DbSet<Parks> Parks { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Pitching> Pitching { get; set; }
        public virtual DbSet<PitchingPost> PitchingPost { get; set; }
        public virtual DbSet<Salaries> Salaries { get; set; }
        public virtual DbSet<Schools> Schools { get; set; }
        public virtual DbSet<SeriesPost> SeriesPost { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<TeamsFranchises> TeamsFranchises { get; set; }
        public virtual DbSet<TeamsHalf> TeamsHalf { get; set; }

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
            modelBuilder.ApplyConfiguration(new AppearancesConfiguration());
            modelBuilder.ApplyConfiguration(new AwardsManagersConfiguration());
            modelBuilder.ApplyConfiguration(new AwardsPlayersConfiguration());
            modelBuilder.ApplyConfiguration(new AwardsShareManagersConfiguration());
            modelBuilder.ApplyConfiguration(new AwardsSharePlayersConfiguration());
            modelBuilder.ApplyConfiguration(new BattingConfiguration());
            modelBuilder.ApplyConfiguration(new BattingPostConfiguration());
            modelBuilder.ApplyConfiguration(new CollegePlayingConfiguration());
            modelBuilder.ApplyConfiguration(new FieldingConfiguration());
            modelBuilder.ApplyConfiguration(new FieldingOFConfiguration());
            modelBuilder.ApplyConfiguration(new FieldingOFsplitConfiguration());
            modelBuilder.ApplyConfiguration(new FieldingPostConfiguration());
            modelBuilder.ApplyConfiguration(new HallOfFameConfiguration());
            modelBuilder.ApplyConfiguration(new HomeGamesConfiguration());
            modelBuilder.ApplyConfiguration(new ManagersConfiguration());
            modelBuilder.ApplyConfiguration(new ManagersHalfConfiguration());
            modelBuilder.ApplyConfiguration(new ParksConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PitchingConfiguration());
            modelBuilder.ApplyConfiguration(new PitchingPostConfiguration());
            modelBuilder.ApplyConfiguration(new SalariesConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolsConfiguration());
            modelBuilder.ApplyConfiguration(new SeriesPostConfiguration());
            modelBuilder.ApplyConfiguration(new TeamsConfiguration());
            modelBuilder.ApplyConfiguration(new TeamsFranchisesConfiguration());
            modelBuilder.ApplyConfiguration(new TeamsHalfConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
