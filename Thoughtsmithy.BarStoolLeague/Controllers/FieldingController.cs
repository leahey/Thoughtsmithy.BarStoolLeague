using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldingController : ControllerBase
    {
        private readonly BarStoolLeagueContext _context;

        public FieldingController(BarStoolLeagueContext context)
        {
            _context = context;
        }

        // GET: api/Fielding
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fielding>>> GetFielding()
        {
            return await _context.Fielding.ToListAsync();
        }

        // GET: api/Fielding/aaronha1/1974/1/OF
        [HttpGet("{id}/{year}/{stint}/{pos}")]
        public async Task<ActionResult<Fielding>> GetFielding(string id, short year, short stint, string pos)
        {
            var fielding = await _context.Fielding.FindAsync( id, year, stint, pos );

            if (fielding == null)
            {
                return NotFound();
            }

            return fielding;
        }
    }
}
