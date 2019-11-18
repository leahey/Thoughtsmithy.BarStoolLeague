using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class HomeGamesConfiguration : IEntityTypeConfiguration<HomeGames>
    {
        public void Configure(EntityTypeBuilder<HomeGames> builder)
        {
            builder.HasNoKey();
            builder.Property(e => e.Attendance).HasColumnName("attendance");
            builder.Property(e => e.Games).HasColumnName("games");
            builder.Property(e => e.Leaguekey).HasColumnName("leaguekey").HasMaxLength(255);
            builder.Property(e => e.Openings).HasColumnName("openings");
            builder.Property(e => e.Parkkey).HasColumnName("parkkey").HasMaxLength(255);
            builder.Property(e => e.Spanfirst).HasColumnName("spanfirst").HasMaxLength(255);
            builder.Property(e => e.Spanlast).HasColumnName("spanlast").HasMaxLength(255);
            builder.Property(e => e.Teamkey).HasColumnName("teamkey").HasMaxLength(255);
            builder.Property(e => e.Yearkey).HasColumnName("yearkey");
        }
    }
}
