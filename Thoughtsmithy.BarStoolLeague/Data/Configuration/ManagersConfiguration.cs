using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class ManagersConfiguration : IEntityTypeConfiguration<Managers>
    {
        public void Configure(EntityTypeBuilder<Managers> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.TeamId, e.InSeason }).HasName("Managers$Index_836DE8E8_FEBD_469A");

            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.PlayerManager).HasMaxLength(1).HasColumnName("plyrMgr");
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.InSeason).HasColumnName("inseason");
            builder.Property(e => e.Rank).HasColumnName("rank");
            builder.Property(e => e.Games).HasColumnName("G");
            builder.Property(e => e.Won).HasColumnName("W");
            builder.Property(e => e.Lost).HasColumnName("L");

            builder.HasOne(d => d.Player)
                                .WithMany(p => p.Managers)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_Managers_People");

            builder.HasOne(d => d.Teams)
                                .WithMany(p => p.Managers)
                                .HasForeignKey(d => new { d.YearId, d.LeagueId, d.TeamId })
                                .HasConstraintName("FK_Managers_Teams");
        }

    }
}
