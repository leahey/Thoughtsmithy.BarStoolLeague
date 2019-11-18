using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class AwardsManagersConfiguration : IEntityTypeConfiguration<AwardsManagers>
    {
        public void Configure(EntityTypeBuilder<AwardsManagers> builder)
        {
            builder.HasKey(e => new { e.YearId, e.AwardId, e.LgId, e.PlayerId }).HasName("AwardsManagers$Index_5B79AD08_A7C1_426E");

            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.AwardId).HasColumnName("awardID").HasMaxLength(75);
            builder.Property(e => e.LgId).HasColumnName("lgID").HasMaxLength(2);
            builder.Property(e => e.PlayerId).HasColumnName("playerID").HasMaxLength(10);
            builder.Property(e => e.Notes).HasColumnName("notes").HasMaxLength(100);
            builder.Property(e => e.Tie).HasColumnName("tie").HasMaxLength(1);
        }
    }
}
