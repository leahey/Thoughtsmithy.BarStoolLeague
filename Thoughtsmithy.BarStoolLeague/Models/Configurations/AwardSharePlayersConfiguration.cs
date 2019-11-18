using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class AwardSharePlayersConfiguration : IEntityTypeConfiguration<AwardsSharePlayers>
    {
        public void Configure(EntityTypeBuilder<AwardsSharePlayers> builder)
        {
            builder.HasKey(e => new { e.AwardId, e.YearId, e.LgId, e.PlayerId }).HasName("AwardsSharePlayers$Index_020E6DB1_95E2_44F1");
            builder.Property(e => e.AwardId).HasColumnName("awardID").HasMaxLength(25);
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.LgId).HasColumnName("lgID").HasMaxLength(2);
            builder.Property(e => e.PlayerId).HasColumnName("playerID").HasMaxLength(9);
            builder.Property(e => e.PointsMax).HasColumnName("pointsMax");
            builder.Property(e => e.PointsWon).HasColumnName("pointsWon");
            builder.Property(e => e.VotesFirst).HasColumnName("votesFirst");
        }
    }
}
