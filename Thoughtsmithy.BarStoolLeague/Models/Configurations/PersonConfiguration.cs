using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
                builder.ToTable("People");

                builder.HasNoKey();

                builder.Property(e => e.Bats).HasColumnName("bats").HasMaxLength(255);
                builder.Property(e => e.BbrefId).HasColumnName("bbrefID").HasMaxLength(255);
                builder.Property(e => e.BirthCity).HasColumnName("birthCity").HasMaxLength(255);
                builder.Property(e => e.BirthCountry).HasColumnName("birthCountry").HasMaxLength(255);
                builder.Property(e => e.BirthDay).HasColumnName("birthDay");
                builder.Property(e => e.BirthMonth).HasColumnName("birthMonth");
                builder.Property(e => e.BirthState).HasColumnName("birthState").HasMaxLength(255);
                builder.Property(e => e.BirthYear).HasColumnName("birthYear");
                builder.Property(e => e.DeathCity).HasColumnName("deathCity").HasMaxLength(255);
                builder.Property(e => e.DeathCountry).HasColumnName("deathCountry").HasMaxLength(255);
                builder.Property(e => e.DeathDay).HasColumnName("deathDay");
                builder.Property(e => e.DeathMonth).HasColumnName("deathMonth");
                builder.Property(e => e.DeathState)
                    .HasColumnName("deathState")
                    .HasMaxLength(255);

                builder.Property(e => e.DeathYear).HasColumnName("deathYear");

                builder.Property(e => e.Debut)
                    .HasColumnName("debut")
                    .HasMaxLength(255);

                builder.Property(e => e.FinalGame)
                    .HasColumnName("finalGame")
                    .HasMaxLength(255);

                builder.Property(e => e.Height).HasColumnName("height");

                builder.Property(e => e.NameFirst)
                    .HasColumnName("nameFirst")
                    .HasMaxLength(255);

                builder.Property(e => e.NameGiven)
                    .HasColumnName("nameGiven")
                    .HasMaxLength(255);

                builder.Property(e => e.NameLast)
                    .HasColumnName("nameLast")
                    .HasMaxLength(255);

                builder.Property(e => e.PlayerId)
                    .HasColumnName("playerID")
                    .HasMaxLength(255);

                builder.Property(e => e.RetroId)
                    .HasColumnName("retroID")
                    .HasMaxLength(255);

                builder.Property(e => e.Throws)
                    .HasColumnName("throws")
                    .HasMaxLength(255);

                builder.Property(e => e.Weight).HasColumnName("weight");
        }
    }
}
