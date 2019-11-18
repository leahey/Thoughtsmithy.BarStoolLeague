using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class AwardsPlayersConfiguration : IEntityTypeConfiguration<AwardsPlayers>
    {
        public void Configure(EntityTypeBuilder<AwardsPlayers> builder)
        {
            builder.HasKey(e => new { e.YearId, e.AwardId, e.LgId, e.PlayerId }).HasName("AwardsPlayers$Index_99C7A5A6_27CA_44FC");

            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.AwardId).HasColumnName("awardID").HasMaxLength(255);
            builder.Property(e => e.LgId).HasColumnName("lgID").HasMaxLength(2);
            builder.Property(e => e.PlayerId).HasColumnName("playerID").HasMaxLength(9);
            builder.Property(e => e.Notes).HasColumnName("notes").HasMaxLength(100);
            builder.Property(e => e.Tie).HasColumnName("tie").HasMaxLength(1);
        }
    }
}
