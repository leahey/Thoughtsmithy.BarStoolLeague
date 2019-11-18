using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class CollegePlayingConfiguration : IEntityTypeConfiguration<CollegePlaying>
    {
        public void Configure(EntityTypeBuilder<CollegePlaying> builder)
        {
            builder.HasNoKey();
            builder.Property(e => e.PlayerId).IsRequired().HasColumnName("playerID").HasMaxLength(9);
            builder.Property(e => e.SchoolId).HasColumnName("schoolID").HasMaxLength(15);
            builder.Property(e => e.YearId).HasColumnName("yearID");
        }
    }
}
