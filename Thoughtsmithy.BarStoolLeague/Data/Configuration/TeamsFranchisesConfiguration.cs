using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class TeamsFranchisesConfiguration : IEntityTypeConfiguration<TeamsFranchises>
    {
        public void Configure(EntityTypeBuilder<TeamsFranchises> builder)
        {
            builder.HasKey(e => e.FranchId).HasName("TeamsFranchises$Index_D181F923_2BF9_4281");

            builder.Property(e => e.FranchId).HasMaxLength(3).HasColumnName("franchID");
            builder.Property(e => e.NAassoc).HasMaxLength(3);
            builder.Property(e => e.Active).HasMaxLength(2).HasColumnName("active");
            builder.Property(e => e.FranchName).HasMaxLength(50).HasColumnName("franchName");
        }

    }
}
