using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Models.Configurations
{
    public class AwardsShareManagersConfiguration : IEntityTypeConfiguration<AwardsShareManagers>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder"> The builder to be used to configure the entity type. </param>
        public void Configure(EntityTypeBuilder<AwardsShareManagers> builder)
        {
            //builder.ToTable
            builder.HasKey(e => new { e.AwardId, e.YearId, e.LgId, e.PlayerId }).HasName("AwardsShareManagers$Index_4D947987_0BEF_4B9B");
            builder.Property(e => e.AwardId).HasColumnName("awardID").HasMaxLength(25);
            builder.Property(e => e.YearId).HasColumnName("yearID");
            builder.Property(e => e.LgId).HasColumnName("lgID").HasMaxLength(2);
            builder.Property(e => e.PlayerId).HasColumnName("playerID").HasMaxLength(10);
            builder.Property(e => e.PointsMax).HasColumnName("pointsMax");
            builder.Property(e => e.PointsWon).HasColumnName("pointsWon");
            builder.Property(e => e.VotesFirst).HasColumnName("votesFirst");
        }
    }




}
