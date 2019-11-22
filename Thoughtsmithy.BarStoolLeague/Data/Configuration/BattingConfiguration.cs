using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class BattingConfiguration : IEntityTypeConfiguration<Batting>
    {
        public void Configure(EntityTypeBuilder<Batting> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.Stint }).HasName("Batting$Index_7170BE9D_268A_46B8");

            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e._2B).HasColumnName("2B");
            builder.Property(e => e._3B).HasColumnName("3B");
            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");

            builder.HasOne(d => d.Player)
                                .WithMany(p => p.Batting)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_Batting_People");
        }

    }
}
