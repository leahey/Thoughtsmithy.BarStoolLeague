using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class FieldingConfiguration : IEntityTypeConfiguration<Fielding>
    {
        public void Configure(EntityTypeBuilder<Fielding> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.Stint, e.Pos }).HasName("Fielding$Index_97751AED_0076_4367");

            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.Stint).HasColumnName("stint");
            builder.Property(e => e.Pos).HasMaxLength(2).HasColumnName("POS");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");

            builder.HasOne(d => d.Player)
                                .WithMany(p => p.Fielding)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_Fielding_People");
        }

    }
}
