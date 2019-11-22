using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class AwardsPlayersConfiguration : IEntityTypeConfiguration<AwardsPlayers>
    {
        public void Configure(EntityTypeBuilder<AwardsPlayers> builder)
        {
            builder.HasKey(e => new { e.YearId, e.AwardId, e.LeagueId, e.PlayerId }).HasName("AwardsPlayers$Index_99C7A5A6_27CA_44FC");

            builder.Property(e => e.AwardId).HasMaxLength(255).HasColumnName("awardID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.Notes).HasMaxLength(100).HasColumnName("notes");
            builder.Property(e => e.Tie).HasMaxLength(1).HasColumnName("tie");

            builder.HasOne(d => d.Player)
                                .WithMany(p => p.AwardsPlayers)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_AwardsPlayers_People");
        }

    }
}
