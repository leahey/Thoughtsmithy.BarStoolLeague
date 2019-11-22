using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class ManagersHalfConfiguration : IEntityTypeConfiguration<ManagersHalf>
    {
        public void Configure(EntityTypeBuilder<ManagersHalf> builder)
        {
            builder.HasKey(e => new { e.YearId, e.TeamId, e.PlayerId, e.Half }).HasName("ManagersHalf$Index_C2906EEF_9F52_4968");

            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");
            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.Half).HasColumnName("half");
            builder.Property(e => e.InSeason).HasColumnName("inseason");
            builder.Property(e => e.Games).HasColumnName("G");
            builder.Property(e => e.Won).HasColumnName("W");
            builder.Property(e => e.Lost).HasColumnName("L");
            builder.Property(e => e.Rank).HasColumnName("rank");

            builder.HasOne(d => d.Player)
                                .WithMany(p => p.ManagersHalf)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_ManagersHalf_People");

            builder.HasOne(d => d.Teams)
                                .WithMany(p => p.ManagersHalf)
                                .HasForeignKey(d => new { d.YearId, d.LeagueId, d.TeamId })
                                .HasConstraintName("FK_ManagersHalf_Teams");
        }

    }
}
