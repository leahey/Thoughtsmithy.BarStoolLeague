using System;
using System.Linq;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Repositories
{
    public abstract class RepositoryBase<TEntity>
    {
        protected readonly BarStoolLeagueContext DbContext;

        public RepositoryBase(BarStoolLeagueContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
