using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class AppearancesConfiguration : IEntityTypeConfiguration<Appearances>
    {
        public void Configure(EntityTypeBuilder<Appearances> builder)
        {
            builder.HasKey(e => new { e.YearId, e.TeamId, e.PlayerId }).HasName("Appearances$Index_70924BF9_C76C_4076");

            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");
            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");

            builder.HasOne(d => d.Player)
                                .WithMany(p => p.Appearances)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_Appearances_People");

            builder.HasOne(d => d.Teams)
                                .WithMany(p => p.Appearances)
                                .HasForeignKey(d => new { d.YearId, d.LeagueId, d.TeamId })
                                .HasConstraintName("FK_Appearances_Teams");
        }
    }
}

