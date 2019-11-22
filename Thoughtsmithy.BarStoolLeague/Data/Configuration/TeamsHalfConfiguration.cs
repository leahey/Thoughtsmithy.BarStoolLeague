using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class TeamsHalfConfiguration : IEntityTypeConfiguration<TeamsHalf>
    {
        public void Configure(EntityTypeBuilder<TeamsHalf> builder)
        {
            builder.HasKey(e => new { e.YearId, e.TeamId, e.LeagueId, e.Half }).HasName("TeamsHalf$Index_3FD773F5_2FC0_415C");

            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.Half).HasMaxLength(1);
            builder.Property(e => e.DivWin).HasMaxLength(1);
            builder.Property(e => e.DivId).HasMaxLength(1).HasColumnName("divID");

            builder.HasOne(d => d.Teams)
                                .WithMany(p => p.TeamsHalf)
                                .HasForeignKey(d => new { d.YearId, d.LeagueId, d.TeamId })
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_TeamsHalf_Teams");
        }

    }
}
