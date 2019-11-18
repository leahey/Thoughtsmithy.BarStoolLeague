using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class PitchingConfiguration : IEntityTypeConfiguration<Pitching>
    {
        public void Configure(EntityTypeBuilder<Pitching> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.Stint }).HasName("Pitching$Index_481778A5_18F2_430E");
            builder.Property(e => e.PlayerId).HasColumnName("playerID").HasMaxLength(9);
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.Stint).HasColumnName("stint");
            builder.Property(e => e.Baopp).HasColumnName("BAOpp");
            builder.Property(e => e.Bb).HasColumnName("BB");
            builder.Property(e => e.Bfp).HasColumnName("BFP");
            builder.Property(e => e.Bk).HasColumnName("BK");
            builder.Property(e => e.Cg).HasColumnName("CG");
            builder.Property(e => e.Er).HasColumnName("ER");
            builder.Property(e => e.Era).HasColumnName("ERA");
            builder.Property(e => e.Gf).HasColumnName("GF");
            builder.Property(e => e.Gidp).HasColumnName("GIDP");
            builder.Property(e => e.Gs).HasColumnName("GS");
            builder.Property(e => e.Hbp).HasColumnName("HBP");
            builder.Property(e => e.Hr).HasColumnName("HR");
            builder.Property(e => e.Ibb).HasColumnName("IBB");
            builder.Property(e => e.Ipouts).HasColumnName("IPouts");
            builder.Property(e => e.LgId).HasColumnName("lgID").HasMaxLength(2);
            builder.Property(e => e.Sf).HasColumnName("SF");
            builder.Property(e => e.Sh).HasColumnName("SH");
            builder.Property(e => e.Sho).HasColumnName("SHO");
            builder.Property(e => e.So).HasColumnName("SO");
            builder.Property(e => e.Sv).HasColumnName("SV");
            builder.Property(e => e.TeamId).HasColumnName("teamID").HasMaxLength(3);
            builder.Property(e => e.Wp).HasColumnName("WP");
        }
    }
}
