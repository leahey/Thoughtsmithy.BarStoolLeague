using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class AwardsManagersConfiguration : IEntityTypeConfiguration<AwardsManagers>
    {
        public void Configure(EntityTypeBuilder<AwardsManagers> builder)
        {
            builder.HasKey(e => new { e.YearId, e.AwardId, e.LeagueId, e.PlayerId }).HasName("AwardsManagers$Index_5B79AD08_A7C1_426E");

            builder.Property(e => e.AwardId).HasMaxLength(75).HasColumnName("awardID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.PlayerId).HasMaxLength(10).HasColumnName("playerID");
            builder.Property(e => e.Notes).HasMaxLength(100).HasColumnName("notes");
            builder.Property(e => e.Tie).HasMaxLength(1).HasColumnName("tie");
        }

    }
}
