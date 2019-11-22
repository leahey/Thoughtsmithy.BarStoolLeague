using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class HallOfFameConfiguration : IEntityTypeConfiguration<HallOfFame>
    {
        public void Configure(EntityTypeBuilder<HallOfFame> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.VotedBy }).HasName("HallOfFame$PrimaryKey");

            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.YearId).HasColumnType("smalldatetime").HasColumnName("yearID");
            builder.Property(e => e.VotedBy).HasMaxLength(64).HasColumnName("votedBy");
            builder.Property(e => e.Category).HasMaxLength(20).HasColumnName("category");
            builder.Property(e => e.Inducted).HasMaxLength(1).HasColumnName("inducted");
            builder.Property(e => e.Needed_note).HasMaxLength(25).HasColumnName("needed.note");

            builder.HasOne(d => d.Player)
                                .WithMany(p => p.HallOfFame)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_HallOfFame_People");
        }

    }
}
