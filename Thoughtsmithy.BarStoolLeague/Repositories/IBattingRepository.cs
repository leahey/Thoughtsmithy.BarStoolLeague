using System;
using System.Linq;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Repositories
{
    public interface IBattingRepository : IRepository<Batting, Tuple<string, short, short>>
    {

    }
}
