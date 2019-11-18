using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class FieldingOfConfiguration : IEntityTypeConfiguration<FieldingOf>
    {
        public void Configure(EntityTypeBuilder<FieldingOf> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.Stint }).HasName("FieldingOF$Index_8983CB74_6371_424E");
            builder.ToTable("FieldingOF");
            builder.Property(e => e.PlayerId).HasColumnName("playerID").HasMaxLength(9);
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.Stint).HasColumnName("stint");
        }
    }
}
