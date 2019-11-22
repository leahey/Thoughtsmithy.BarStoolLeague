using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People");

            builder.HasKey(e => e.PlayerId);

            builder.Property(e => e.PlayerId).HasMaxLength(9).HasColumnName("playerID");
            builder.Property(e => e.Bats).HasMaxLength(255).HasColumnName("bats");
            builder.Property(e => e.bbrefID).HasMaxLength(255);
            builder.Property(e => e.BirthCity).HasMaxLength(255).HasColumnName("birthCity");
            builder.Property(e => e.BirthCountry).HasMaxLength(255).HasColumnName("birthCountry");
            builder.Property(e => e.BirthState).HasMaxLength(255).HasColumnName("birthState");
            builder.Property(e => e.DeathCity).HasMaxLength(255).HasColumnName("deathCity");
            builder.Property(e => e.DeathCountry).HasMaxLength(255).HasColumnName("deathCountry");
            builder.Property(e => e.DeathState).HasMaxLength(255).HasColumnName("deathState");
            builder.Property(e => e.Debut).HasMaxLength(255).HasColumnName("debut");
            builder.Property(e => e.FinalGame).HasMaxLength(255).HasColumnName("finalGame");
            builder.Property(e => e.NameFirst).HasMaxLength(255).HasColumnName("nameFirst");
            builder.Property(e => e.NameGiven).HasMaxLength(255).HasColumnName("nameGiven");
            builder.Property(e => e.NameLast).HasMaxLength(255).HasColumnName("nameLast");
            builder.Property(e => e.RetroID).HasMaxLength(255).HasColumnName("retroID");
            builder.Property(e => e.Throws).HasMaxLength(255).HasColumnName("throws");
        }

    }
}
