using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class AwardsShareManagersConfiguration : IEntityTypeConfiguration<AwardsShareManagers>
    {
        public void Configure(EntityTypeBuilder<AwardsShareManagers> builder)
        {
            builder.HasKey(e => new { e.AwardId, e.YearId, e.LeagueId, e.PlayerId }).HasName("AwardsShareManagers$Index_4D947987_0BEF_4B9B");

            builder.Property(e => e.AwardId).HasMaxLength(25).HasColumnName("awardID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.PlayerId).HasMaxLength(10).HasColumnName("playerID");
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.PointsWon).HasColumnName("pointsWon");
            builder.Property(e => e.PointsMax).HasColumnName("pointsmax");
            builder.Property(e => e.VotesFirst).HasColumnName("votesFirst");
        }

    }
}
