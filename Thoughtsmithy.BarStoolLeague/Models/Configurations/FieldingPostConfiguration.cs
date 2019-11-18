using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class FieldingPostConfiguration : IEntityTypeConfiguration<FieldingPost>
    {
        public void Configure(EntityTypeBuilder<FieldingPost> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.Round, e.Pos }).HasName("FieldingPost$Index_E1DA201A_3B38_486D");
            builder.Property(e => e.PlayerId).HasColumnName("playerID").HasMaxLength(9);
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.Round).HasColumnName("round").HasMaxLength(10);
            builder.Property(e => e.Pos).HasColumnName("POS").HasMaxLength(2);
            builder.Property(e => e.Cs).HasColumnName("CS");
            builder.Property(e => e.Dp).HasColumnName("DP");
            builder.Property(e => e.Gs).HasColumnName("GS");
            builder.Property(e => e.LgId).HasColumnName("lgID").HasMaxLength(2);
            builder.Property(e => e.Pb).HasColumnName("PB");
            builder.Property(e => e.Po).HasColumnName("PO");
            builder.Property(e => e.Sb).HasColumnName("SB");
            builder.Property(e => e.TeamId).HasColumnName("teamID").HasMaxLength(3);
            builder.Property(e => e.Tp).HasColumnName("TP");
        }
    }
}
