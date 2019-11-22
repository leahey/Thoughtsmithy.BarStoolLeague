using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class AllstarFullConfiguration : IEntityTypeConfiguration<AllstarFull>
    {
        public void Configure(EntityTypeBuilder<AllstarFull> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.GameNum }).HasName("AllstarFull$Index_2BD68208_C8B4_4347");
            
            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.GameId).HasMaxLength(12).HasColumnName("gameID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");
            builder.Property(e => e.StartingPos).HasColumnName("startingPos");


            builder.HasOne(d => d.Player)
                .WithMany(p => p.AllstarFull)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllstarFull_People");

            builder.HasOne(d => d.Teams)
                .WithMany(p => p.AllstarFull)
                .HasForeignKey(d => new { d.YearId, d.LeagueId, d.TeamId })
                .HasConstraintName("FK_AllstarFull_Teams");
        }
    }
}
