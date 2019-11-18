using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class HallOfFameConfiguration : IEntityTypeConfiguration<HallOfFame>
    {
        public void Configure(EntityTypeBuilder<HallOfFame> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.Yearid, e.VotedBy }).HasName("HallOfFame$PrimaryKey");
            builder.Property(e => e.PlayerId).HasColumnName("playerID").HasMaxLength(10);
            builder.Property(e => e.Yearid).HasColumnName("yearid");
            builder.Property(e => e.VotedBy).HasColumnName("votedBy").HasMaxLength(64);
            builder.Property(e => e.Ballots).HasColumnName("ballots");
            builder.Property(e => e.Category).HasColumnName("category").HasMaxLength(20);
            builder.Property(e => e.Inducted).HasColumnName("inducted").HasMaxLength(1);
            builder.Property(e => e.Needed).HasColumnName("needed");
            builder.Property(e => e.NeededNote).HasColumnName("needed_note").HasMaxLength(25);
            builder.Property(e => e.Votes).HasColumnName("votes");
        }
    }
}
