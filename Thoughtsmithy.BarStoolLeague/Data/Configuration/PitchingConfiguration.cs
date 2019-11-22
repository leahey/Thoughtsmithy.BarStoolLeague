using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class PitchingConfiguration : IEntityTypeConfiguration<Pitching>
    {
        public void Configure(EntityTypeBuilder<Pitching> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.Stint }).HasName("Pitching$Index_481778A5_18F2_430E");

            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.Stint).HasColumnName("stint");
            builder.Property(e => e.Games).HasColumnName("G");
            builder.Property(e => e.GamesStarted).HasColumnName("GS");
            builder.Property(e => e.Wins).HasColumnName("W");
            builder.Property(e => e.Losses).HasColumnName("L");

            builder.HasOne(d => d.Player)
                                .WithMany(p => p.Pitching)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_Pitching_People");
        }

    }
}
