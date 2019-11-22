using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class SchoolsConfiguration : IEntityTypeConfiguration<Schools>
    {
        public void Configure(EntityTypeBuilder<Schools> builder)
        {
            builder.HasKey(e => e.SchoolId).HasName("Schools$Index_3D308CF0_821E_4DAB");

            builder.Property(e => e.SchoolId).HasMaxLength(15).HasColumnName("schoolID");
            builder.Property(e => e.City).HasMaxLength(55).HasColumnName("city");
            builder.Property(e => e.Country).HasMaxLength(55).HasColumnName("country");
            builder.Property(e => e.FullName).HasMaxLength(255).HasColumnName("name_full");
            builder.Property(e => e.State).HasMaxLength(55).HasColumnName("state");
        }

    }
}
