using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class BattingPostConfiguration : IEntityTypeConfiguration<BattingPost>
    {
        public void Configure(EntityTypeBuilder<BattingPost> builder)
        {
            builder.HasKey(e => new { e.YearId, e.Round, e.PlayerId }).HasName("BattingPost$Index_8C81D106_6E96_4318");

            builder.Property(e => e.Round).HasMaxLength(10).HasColumnName("round");
            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e._2B).HasColumnName("2B");
            builder.Property(e => e._3B).HasColumnName("3B");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");

            builder.HasOne(d => d.Player)
                                .WithMany(p => p.BattingPost)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_BattingPost_People");
        }

    }
}
