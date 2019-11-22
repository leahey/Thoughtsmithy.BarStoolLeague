using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class FieldingOFConfiguration : IEntityTypeConfiguration<FieldingOF>
    {
        public void Configure(EntityTypeBuilder<FieldingOF> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.Stint }).HasName("FieldingOF$Index_8983CB74_6371_424E");

            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.YearId).HasMaxLength(9).HasColumnName("yearID");
            builder.Property(e => e.Stint).HasMaxLength(9).HasColumnName("stint");

            builder.HasOne(d => d.player)
                                .WithMany(p => p.FieldingOF)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_FieldingOF_People");
        }

    }
}
