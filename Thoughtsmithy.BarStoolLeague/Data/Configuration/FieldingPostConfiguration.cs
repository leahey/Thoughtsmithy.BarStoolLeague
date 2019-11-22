using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class FieldingPostConfiguration : IEntityTypeConfiguration<FieldingPost>
    {
        public void Configure(EntityTypeBuilder<FieldingPost> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.Round, e.Pos }).HasName("FieldingPost$Index_E1DA201A_3B38_486D");

            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.Round).HasMaxLength(10).HasColumnName("round");
            builder.Property(e => e.Pos).HasMaxLength(2).HasColumnName("POS");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");
            builder.Property(e => e.YearId).HasColumnName("yearID");

            builder.HasOne(d => d.Player)
                                .WithMany(p => p.FieldingPost)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_FieldingPost_People");
        }

    }
}
