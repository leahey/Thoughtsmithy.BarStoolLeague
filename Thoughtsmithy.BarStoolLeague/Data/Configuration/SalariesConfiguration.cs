using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class SalariesConfiguration : IEntityTypeConfiguration<Salaries>
    {
        public void Configure(EntityTypeBuilder<Salaries> builder)
        {
            builder.HasKey(e => new { e.YearId, e.TeamId, e.LeagueId, e.PlayerId }).HasName("Salaries$Index_E5568031_00FA_49CA");

            builder.Property(e => e.TeamId).HasMaxLength(3).HasColumnName("teamID");
            builder.Property(e => e.LeagueId).HasMaxLength(2).HasColumnName("lgID");
            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.Salary).HasColumnName("salary");

            builder.HasOne(d => d.Player)
                                .WithMany(p => p.Salaries)
                                .HasForeignKey(d => d.PlayerId)
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_Salaries_People");

            builder.HasOne(d => d.Teams)
                                .WithMany(p => p.Salaries)
                                .HasForeignKey(d => new { d.YearId, d.LeagueId, d.TeamId })
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_Salaries_Teams");
        }

    }
}
