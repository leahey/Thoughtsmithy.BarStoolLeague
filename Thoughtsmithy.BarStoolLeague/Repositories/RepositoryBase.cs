using System;
using System.Linq;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey>
    {
        protected readonly BarStoolLeagueContext DbContext;

        public RepositoryBase(BarStoolLeagueContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
