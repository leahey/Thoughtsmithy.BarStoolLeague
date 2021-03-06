﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class PitchingPostConfiguration : IEntityTypeConfiguration<PitchingPost>
    {
        public void Configure(EntityTypeBuilder<PitchingPost> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.Round }).HasName("PitchingPost$Index_E71336E6_AB00_432C");

            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.Round).HasMaxLength(10).HasColumnName("round");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.Wins).HasColumnName("W");
            builder.Property(e => e.Losses).HasColumnName("L");
            builder.Property(e => e.Games).HasColumnName("G");
            builder.Property(e => e.GamesStarted).HasColumnName("GS");


            builder.HasOne(d => d.Player)
                                .WithMany(p => p.PitchingPost)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_PitchingPost_People");
        }
    }
}
