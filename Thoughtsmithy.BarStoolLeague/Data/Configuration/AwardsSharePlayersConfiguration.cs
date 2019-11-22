using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class AwardsSharePlayersConfiguration : IEntityTypeConfiguration<AwardsSharePlayers>
    {
        public void Configure(EntityTypeBuilder<AwardsSharePlayers> builder)
        {
            builder.HasKey(e => new { e.AwardId, e.YearId, e.LeagueId, e.PlayerId }).HasName("AwardsSharePlayers$Index_020E6DB1_95E2_44F1");

            builder.Property(e => e.AwardId).HasMaxLength(25).HasColumnName("awardID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.PointsWon).HasColumnName("pointsWon");
            builder.Property(e => e.PointsMax).HasColumnName("pointsMax");
            builder.Property(e => e.VotesFirst).HasColumnName("votesFirst");
        }

    }
}
