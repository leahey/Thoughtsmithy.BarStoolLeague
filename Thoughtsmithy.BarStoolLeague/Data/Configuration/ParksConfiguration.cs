using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class ParksConfiguration : IEntityTypeConfiguration<Parks>
    {
        public void Configure(EntityTypeBuilder<Parks> builder)
        {
            builder.Property(e => e.City).HasMaxLength(255).HasColumnName("city");
            builder.Property(e => e.Country).HasMaxLength(255).HasColumnName("country");
            builder.Property(e => e.ParkAlias).HasMaxLength(255).HasColumnName("yearID");
            builder.Property(e => e.ParkKey).HasMaxLength(255).HasColumnName("parkkey");
            builder.Property(e => e.ParkName).HasMaxLength(255).HasColumnName("parkname");
            builder.Property(e => e.State).HasMaxLength(255).HasColumnName("state");
        }

    }
}
