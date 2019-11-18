using System;
using System.Linq;

namespace Thoughtsmithy.BarStoolLeague.Repositories
{
    public interface IPitchingRepository : IRepository<Pitching, Tuple<string, short, short>>
    {

    }
}
