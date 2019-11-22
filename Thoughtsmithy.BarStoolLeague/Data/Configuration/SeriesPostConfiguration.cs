using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class SeriesPostConfiguration : IEntityTypeConfiguration<SeriesPost>
    {
        public void Configure(EntityTypeBuilder<SeriesPost> builder)
        {
            builder.HasKey(e => new { e.YearId, e.Round }).HasName("SeriesPost$Index_4F4214D5_9891_4F3C");

            builder.Property(e => e.Round).HasMaxLength(5).HasColumnName("round");
            builder.Property(e => e.LeagueIdLoser).HasMaxLength(2).HasColumnName("lgIDloser");
            builder.Property(e => e.LeagueIdWinner).HasMaxLength(2).HasColumnName("lgIDwinner");
            builder.Property(e => e.TeamIdLoser).HasMaxLength(3).HasColumnName("teamIDloser");
            builder.Property(e => e.TeamIdWinner).HasMaxLength(3).HasColumnName("teamIDwinner");
            builder.Property(e => e.Wins).HasColumnName("wins");
            builder.Property(e => e.Losses).HasColumnName("losses");
            builder.Property(e => e.Ties).HasColumnName("ties");

            builder.HasOne(d => d.Teams)
                                .WithMany(p => p.SeriesPostTeams)
                                .HasForeignKey(d => new { d.YearId, d.LeagueIdLoser, d.TeamIdLoser })
                                .HasConstraintName("FK_SeriesPost_LosingTeams");

            builder.HasOne(d => d.TeamsNavigation)
                                .WithMany(p => p.SeriesPostTeamsNavigation)
                                .HasForeignKey(d => new { d.YearId, d.LeagueIdWinner, d.TeamIdWinner })
                                .HasConstraintName("FK_SeriesPost_WinningTeams");
        }

    }
}
