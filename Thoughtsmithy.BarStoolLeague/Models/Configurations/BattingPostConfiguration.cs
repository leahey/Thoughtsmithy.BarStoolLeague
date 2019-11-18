﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class BattingPostConfiguration : IEntityTypeConfiguration<BattingPost>
    {
        public void Configure(EntityTypeBuilder<BattingPost> builder)
        {
            builder.HasKey(e => new { e.YearId, e.Round, e.PlayerId }).HasName("BattingPost$Index_8C81D106_6E96_4318");
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.Round).HasColumnName("round").HasMaxLength(10);
            builder.Property(e => e.PlayerId).HasColumnName("playerID").HasMaxLength(9);
            builder.Property(e => e.Ab).HasColumnName("AB");
            builder.Property(e => e.Bb).HasColumnName("BB");
            builder.Property(e => e.Cs).HasColumnName("CS");
            builder.Property(e => e.Gidp).HasColumnName("GIDP");
            builder.Property(e => e.Hbp).HasColumnName("HBP");
            builder.Property(e => e.Hr).HasColumnName("HR");
            builder.Property(e => e.Ibb).HasColumnName("IBB");
            builder.Property(e => e.LgId).HasColumnName("lgID").HasMaxLength(2);
            builder.Property(e => e.Rbi).HasColumnName("RBI");
            builder.Property(e => e.Sb).HasColumnName("SB");
            builder.Property(e => e.Sf).HasColumnName("SF");
            builder.Property(e => e.Sh).HasColumnName("SH");
            builder.Property(e => e.So).HasColumnName("SO");
            builder.Property(e => e.TeamId).HasColumnName("teamID").HasMaxLength(3);
            builder.Property(e => e._2b).HasColumnName("2B");
            builder.Property(e => e._3b).HasColumnName("3B");
        }
    }
}