using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class AppearanceConfiguration : IEntityTypeConfiguration<Appearances>
    {
        public void Configure(EntityTypeBuilder<Appearances> builder)
        {
            builder.HasKey(e => new { e.YearId, e.TeamId, e.PlayerId }).HasName("Appearances$Index_70924BF9_C76C_4076");
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.TeamId).HasColumnName("teamID").HasMaxLength(3);
            builder.Property(e => e.PlayerId).HasColumnName("playerID").HasMaxLength(9);
            builder.Property(e => e.G1b).HasColumnName("G_1b");
            builder.Property(e => e.G2b).HasColumnName("G_2b");
            builder.Property(e => e.G3b).HasColumnName("G_3b");
            builder.Property(e => e.GAll).HasColumnName("G_all");
            builder.Property(e => e.GBatting).HasColumnName("G_batting");
            builder.Property(e => e.GC).HasColumnName("G_c");
            builder.Property(e => e.GCf).HasColumnName("G_cf");
            builder.Property(e => e.GDefense).HasColumnName("G_defense");
            builder.Property(e => e.GDh).HasColumnName("G_dh");
            builder.Property(e => e.GLf).HasColumnName("G_lf");
            builder.Property(e => e.GOf).HasColumnName("G_of");
            builder.Property(e => e.GP).HasColumnName("G_p");
            builder.Property(e => e.GPh).HasColumnName("G_ph");
            builder.Property(e => e.GPr).HasColumnName("G_pr");
            builder.Property(e => e.GRf).HasColumnName("G_rf");
            builder.Property(e => e.GSs).HasColumnName("G_ss");
            builder.Property(e => e.Gs).HasColumnName("GS");
            builder.Property(e => e.LgId).HasColumnName("lgID").HasMaxLength(2);
        }
    }
}
