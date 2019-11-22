using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;
public class HomeGamesConfiguration : IEntityTypeConfiguration<HomeGames>
{
    public void Configure(EntityTypeBuilder<HomeGames> builder)
    {
        builder.HasNoKey();

        builder.Property(e => e.LeagueKey).HasMaxLength(255).HasColumnName("leaguekey");
        builder.Property(e => e.ParkKey).HasMaxLength(255).HasColumnName("parkkey");
        builder.Property(e => e.SpanFirst).HasMaxLength(255).HasColumnName("spanfirst");
        builder.Property(e => e.SpanLast).HasMaxLength(255).HasColumnName("spanlast");
        builder.Property(e => e.TeamKey).HasMaxLength(255).HasColumnName("teamkey");
        builder.Property(e => e.Games).HasMaxLength(255).HasColumnName("games");
        builder.Property(e => e.Openings).HasMaxLength(255).HasColumnName("openings");
        builder.Property(e => e.Attendance).HasMaxLength(255).HasColumnName("attendence");
    }

}