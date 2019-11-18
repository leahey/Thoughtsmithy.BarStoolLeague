using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class AllstarFullConfiguration : IEntityTypeConfiguration<AllstarFull>
    {
        public void Configure(EntityTypeBuilder<AllstarFull> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.YearId, e.GameNum }).HasName("AllstarFull$Index_2BD68208_C8B4_4347");
            builder.Property(e => e.PlayerId).HasColumnName("playerID").HasMaxLength(9);
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.GameNum).HasColumnName("gameNum");
            builder.Property(e => e.GameId).HasColumnName("gameID").HasMaxLength(12);
            builder.Property(e => e.Gp).HasColumnName("GP");
            builder.Property(e => e.LgId).HasColumnName("lgID").HasMaxLength(2);
            builder.Property(e => e.StartingPos).HasColumnName("startingPos");
            builder.Property(e => e.TeamId).HasColumnName("teamID").HasMaxLength(3);
        }
    }
}
