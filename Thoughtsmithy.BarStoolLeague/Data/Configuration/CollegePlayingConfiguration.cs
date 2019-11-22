using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class CollegePlayingConfiguration : IEntityTypeConfiguration<CollegePlaying>
    {
        public void Configure(EntityTypeBuilder<CollegePlaying> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.PlayerId).IsRequired().HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.SchoolId).HasMaxLength(15).HasColumnName("schoolID");
            builder.Property(e => e.YearId).HasColumnName("yearID");
        }

    }
}
