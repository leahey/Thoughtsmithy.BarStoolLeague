using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class TeamsConfiguration : IEntityTypeConfiguration<Teams>
    {
        public void Configure(EntityTypeBuilder<Teams> builder)
        {
            builder.HasKey(e => new { e.YearId, e.LeagueId, e.TeamId }).HasName("Teams$Index_285058F1_D841_4142");

            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");
            builder.Property(e => e.DivWin).HasMaxLength(1);
            builder.Property(e => e.LgWin).HasMaxLength(1);
            builder.Property(e => e.WCWin).HasMaxLength(1);
            builder.Property(e => e.WSWin).HasMaxLength(1);
            builder.Property(e => e._2B).HasColumnName("2B");
            builder.Property(e => e._3B).HasColumnName("3B");
            builder.Property(e => e.divID).HasMaxLength(1);
            builder.Property(e => e.FranchId).HasMaxLength(3).HasColumnName("franchID");
            builder.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            builder.Property(e => e.Park).HasMaxLength(255).HasColumnName("park");
            builder.Property(e => e.Attendance).HasColumnName("attendance");
            builder.Property(e => e.teamIDBR).HasMaxLength(3);
            builder.Property(e => e.teamIDlahman45).HasMaxLength(3);
            builder.Property(e => e.teamIDretro).HasMaxLength(3);

            builder.HasOne(d => d.Franchises)
                                .WithMany(p => p.Teams)
                                .HasForeignKey(d => d.FranchId)
                                .HasConstraintName("FK_Teams_TeamsFranchises");
        }

    }
}
