﻿using Microsoft.EntityFrameworkCore;
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
        //public virtual DbSet<AwardsSharePlayers> AwardsSharePlayers { get; set; }
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
            modelBuilder.ApplyConfiguration(new AwardsShareManagersConfiguration());
            modelBuilder.ApplyConfiguration(new BattingConfiguration());
            modelBuilder.ApplyConfiguration(new BattingPostConfiguration());
            modelBuilder.ApplyConfiguration(new CollegePlayingConfiguration());
            modelBuilder.ApplyConfiguration(new FieldingConfiguration());
            modelBuilder.ApplyConfiguration(new FieldingOfConfiguration());
            modelBuilder.ApplyConfiguration(new FieldingOfsplitConfiguration());
            modelBuilder.ApplyConfiguration(new FieldingPostConfiguration());
            modelBuilder.ApplyConfiguration(new HallOfFameConfiguration());
            modelBuilder.ApplyConfiguration(new HomeGamesConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PitchingConfiguration());


    
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}



//            #region managers
//            modelBuilder.Entity<Managers>(entity =>
//            {
//                entity.HasKey(e => new { e.YearId, e.TeamId, e.Inseason })
//                    .HasName("Managers$Index_836DE8E8_FEBD_469A");

//entity.Property(e => e.YearId).HasColumnName("yearID");

//entity.Property(e => e.TeamId)
//                    .HasColumnName("teamID")
//                    .HasMaxLength(3);

//entity.Property(e => e.Inseason).HasColumnName("inseason");

//entity.Property(e => e.LgId)
//                    .HasColumnName("lgID")
//                    .HasMaxLength(2);

//entity.Property(e => e.PlayerId)
//                    .HasColumnName("playerID")
//                    .HasMaxLength(10);

//entity.Property(e => e.PlyrMgr)
//                    .HasColumnName("plyrMgr")
//                    .HasMaxLength(1);

//entity.Property(e => e.Rank).HasColumnName("rank");
//            });
//            #endregion

//            #region ManagersHalf
//            modelBuilder.Entity<ManagersHalf>(entity =>
//            {
//                entity.HasKey(e => new { e.YearId, e.TeamId, e.PlayerId, e.Half })
//                    .HasName("ManagersHalf$Index_C2906EEF_9F52_4968");

//entity.Property(e => e.YearId).HasColumnName("yearID");

//entity.Property(e => e.TeamId)
//                    .HasColumnName("teamID")
//                    .HasMaxLength(3);

//entity.Property(e => e.PlayerId)
//                    .HasColumnName("playerID")
//                    .HasMaxLength(10);

//entity.Property(e => e.Half).HasColumnName("half");

//entity.Property(e => e.Inseason).HasColumnName("inseason");

//entity.Property(e => e.LgId)
//                    .HasColumnName("lgID")
//                    .HasMaxLength(2);

//entity.Property(e => e.Rank).HasColumnName("rank");
//            });
//            #endregion

//            #region Parks
//            modelBuilder.Entity<Parks>(entity =>
//            {
//                entity.Property(e => e.Id).HasColumnName("ID");

//entity.Property(e => e.City)
//                    .HasColumnName("city")
//                    .HasMaxLength(255);

//entity.Property(e => e.Country)
//                    .HasColumnName("country")
//                    .HasMaxLength(255);

//entity.Property(e => e.Parkalias)
//                    .HasColumnName("parkalias")
//                    .HasMaxLength(255);

//entity.Property(e => e.Parkkey)
//                    .HasColumnName("parkkey")
//                    .HasMaxLength(255);

//entity.Property(e => e.Parkname)
//                    .HasColumnName("parkname")
//                    .HasMaxLength(255);

//entity.Property(e => e.State)
//                    .HasColumnName("state")
//                    .HasMaxLength(255);
//            });

//            #endregion



//            #region PitchingPost
//            modelBuilder.Entity<PitchingPost>(entity =>
//            {
//                entity.HasKey(e => new { e.PlayerId, e.YearId, e.Round })
//                    .HasName("PitchingPost$Index_E71336E6_AB00_432C");

//entity.Property(e => e.PlayerId)
//                    .HasColumnName("playerID")
//                    .HasMaxLength(9);

//entity.Property(e => e.YearId).HasColumnName("yearID");

//entity.Property(e => e.Round)
//                    .HasColumnName("round")
//                    .HasMaxLength(10);

//entity.Property(e => e.Baopp).HasColumnName("BAOpp");

//entity.Property(e => e.Bb).HasColumnName("BB");

//entity.Property(e => e.Bfp).HasColumnName("BFP");

//entity.Property(e => e.Bk).HasColumnName("BK");

//entity.Property(e => e.Cg).HasColumnName("CG");

//entity.Property(e => e.Er).HasColumnName("ER");

//entity.Property(e => e.Era).HasColumnName("ERA");

//entity.Property(e => e.Gf).HasColumnName("GF");

//entity.Property(e => e.Gidp).HasColumnName("GIDP");

//entity.Property(e => e.Gs).HasColumnName("GS");

//entity.Property(e => e.Hbp).HasColumnName("HBP");

//entity.Property(e => e.Hr).HasColumnName("HR");

//entity.Property(e => e.Ibb).HasColumnName("IBB");

//entity.Property(e => e.Ipouts).HasColumnName("IPouts");

//entity.Property(e => e.LgId)
//                    .HasColumnName("lgID")
//                    .HasMaxLength(2);

//entity.Property(e => e.Sf).HasColumnName("SF");

//entity.Property(e => e.Sh).HasColumnName("SH");

//entity.Property(e => e.Sho).HasColumnName("SHO");

//entity.Property(e => e.So).HasColumnName("SO");

//entity.Property(e => e.Sv).HasColumnName("SV");

//entity.Property(e => e.TeamId)
//                    .HasColumnName("teamID")
//                    .HasMaxLength(3);

//entity.Property(e => e.Wp).HasColumnName("WP");
//            });
//            #endregion

//            #region Salaries
//            modelBuilder.Entity<Salaries>(entity =>
//            {
//                entity.HasKey(e => new { e.YearId, e.TeamId, e.LgId, e.PlayerId })
//                    .HasName("Salaries$Index_E5568031_00FA_49CA");

//entity.Property(e => e.YearId).HasColumnName("yearID");

//entity.Property(e => e.TeamId)
//                    .HasColumnName("teamID")
//                    .HasMaxLength(3);

//entity.Property(e => e.LgId)
//                    .HasColumnName("lgID")
//                    .HasMaxLength(2);

//entity.Property(e => e.PlayerId)
//                    .HasColumnName("playerID")
//                    .HasMaxLength(9);

//entity.Property(e => e.Salary).HasColumnName("salary");
//            });

//            #endregion
//            #region schools
//            modelBuilder.Entity<Schools>(entity =>
//            {
//                entity.HasKey(e => e.SchoolId)
//                    .HasName("Schools$Index_3D308CF0_821E_4DAB");

//entity.Property(e => e.SchoolId)
//                    .HasColumnName("schoolID")
//                    .HasMaxLength(15);

//entity.Property(e => e.City)
//                    .HasColumnName("city")
//                    .HasMaxLength(55);

//entity.Property(e => e.Country)
//                    .HasColumnName("country")
//                    .HasMaxLength(55);

//entity.Property(e => e.NameFull)
//                    .HasColumnName("name_full")
//                    .HasMaxLength(255);

//entity.Property(e => e.State)
//                    .HasColumnName("state")
//                    .HasMaxLength(55);
//            });
//            #endregion
//            #region SeriesPost

//            modelBuilder.Entity<SeriesPost>(entity =>
//            {
//                entity.HasKey(e => new { e.YearId, e.Round })
//                    .HasName("SeriesPost$Index_4F4214D5_9891_4F3C");

//entity.Property(e => e.YearId).HasColumnName("yearID");

//entity.Property(e => e.Round)
//                    .HasColumnName("round")
//                    .HasMaxLength(5);

//entity.Property(e => e.LgIdloser)
//                    .HasColumnName("lgIDloser")
//                    .HasMaxLength(2);

//entity.Property(e => e.LgIdwinner)
//                    .HasColumnName("lgIDwinner")
//                    .HasMaxLength(2);

//entity.Property(e => e.Losses).HasColumnName("losses");

//entity.Property(e => e.TeamIdloser)
//                    .HasColumnName("teamIDloser")
//                    .HasMaxLength(3);

//entity.Property(e => e.TeamIdwinner)
//                    .HasColumnName("teamIDwinner")
//                    .HasMaxLength(3);

//entity.Property(e => e.Ties).HasColumnName("ties");

//entity.Property(e => e.Wins).HasColumnName("wins");
//            });
//            #endregion

//            #region teams
//            modelBuilder.Entity<Teams>(entity =>
//            {
//                entity.HasKey(e => new { e.YearId, e.LgId, e.TeamId })
//                    .HasName("Teams$Index_285058F1_D841_4142");

//entity.Property(e => e.YearId).HasColumnName("yearID");

//entity.Property(e => e.LgId)
//                    .HasColumnName("lgID")
//                    .HasMaxLength(2);

//entity.Property(e => e.TeamId)
//                    .HasColumnName("teamID")
//                    .HasMaxLength(3);

//entity.Property(e => e.Ab).HasColumnName("AB");

//entity.Property(e => e.Attendance).HasColumnName("attendance");

//entity.Property(e => e.Bb).HasColumnName("BB");

//entity.Property(e => e.Bba).HasColumnName("BBA");

//entity.Property(e => e.Bpf).HasColumnName("BPF");

//entity.Property(e => e.Cg).HasColumnName("CG");

//entity.Property(e => e.Cs).HasColumnName("CS");

//entity.Property(e => e.DivId)
//                    .HasColumnName("divID")
//                    .HasMaxLength(1);

//entity.Property(e => e.DivWin).HasMaxLength(1);

//entity.Property(e => e.Dp).HasColumnName("DP");

//entity.Property(e => e.Er).HasColumnName("ER");

//entity.Property(e => e.Era).HasColumnName("ERA");

//entity.Property(e => e.Fp).HasColumnName("FP");

//entity.Property(e => e.FranchId)
//                    .HasColumnName("franchID")
//                    .HasMaxLength(3);

//entity.Property(e => e.Ha).HasColumnName("HA");

//entity.Property(e => e.Hbp).HasColumnName("HBP");

//entity.Property(e => e.Hr).HasColumnName("HR");

//entity.Property(e => e.Hra).HasColumnName("HRA");

//entity.Property(e => e.Ipouts).HasColumnName("IPouts");

//entity.Property(e => e.LgWin).HasMaxLength(1);

//entity.Property(e => e.Name)
//                    .HasColumnName("name")
//                    .HasMaxLength(50);

//entity.Property(e => e.Park)
//                    .HasColumnName("park")
//                    .HasMaxLength(255);

//entity.Property(e => e.Ppf).HasColumnName("PPF");

//entity.Property(e => e.Ra).HasColumnName("RA");

//entity.Property(e => e.Sb).HasColumnName("SB");

//entity.Property(e => e.Sf).HasColumnName("SF");

//entity.Property(e => e.Sho).HasColumnName("SHO");

//entity.Property(e => e.So).HasColumnName("SO");

//entity.Property(e => e.Soa).HasColumnName("SOA");

//entity.Property(e => e.Sv).HasColumnName("SV");

//entity.Property(e => e.TeamIdbr)
//                    .HasColumnName("teamIDBR")
//                    .HasMaxLength(3);

//entity.Property(e => e.TeamIdlahman45)
//                    .HasColumnName("teamIDlahman45")
//                    .HasMaxLength(3);

//entity.Property(e => e.TeamIdretro)
//                    .HasColumnName("teamIDretro")
//                    .HasMaxLength(3);

//entity.Property(e => e.Wcwin)
//                    .HasColumnName("WCWin")
//                    .HasMaxLength(1);

//entity.Property(e => e.Wswin)
//                    .HasColumnName("WSWin")
//                    .HasMaxLength(1);

//entity.Property(e => e._2b).HasColumnName("2B");

//entity.Property(e => e._3b).HasColumnName("3B");
//            });
//            #endregion

//            #region TeamFranchises
//            modelBuilder.Entity<TeamsFranchises>(entity =>
//            {
//                entity.HasKey(e => e.FranchId)
//                    .HasName("TeamsFranchises$Index_D181F923_2BF9_4281");

//entity.Property(e => e.FranchId)
//                    .HasColumnName("franchID")
//                    .HasMaxLength(3);

//entity.Property(e => e.Active)
//                    .HasColumnName("active")
//                    .HasMaxLength(2);

//entity.Property(e => e.FranchName)
//                    .HasColumnName("franchName")
//                    .HasMaxLength(50);

//entity.Property(e => e.Naassoc)
//                    .HasColumnName("NAassoc")
//                    .HasMaxLength(3);
//            });
//            #endregion

//            #region teamshalf
//            modelBuilder.Entity<TeamsHalf>(entity =>
//            {
//                entity.HasKey(e => new { e.YearId, e.TeamId, e.LgId, e.Half })
//                    .HasName("TeamsHalf$Index_3FD773F5_2FC0_415C");

//entity.Property(e => e.YearId).HasColumnName("yearID");

//entity.Property(e => e.TeamId)
//                    .HasColumnName("teamID")
//                    .HasMaxLength(3);

//entity.Property(e => e.LgId)
//                    .HasColumnName("lgID")
//                    .HasMaxLength(2);

//entity.Property(e => e.Half).HasMaxLength(1);

//entity.Property(e => e.DivId)
//                    .HasColumnName("divID")
//                    .HasMaxLength(1);

//entity.Property(e => e.DivWin).HasMaxLength(1);
//            });
//            #endregion

