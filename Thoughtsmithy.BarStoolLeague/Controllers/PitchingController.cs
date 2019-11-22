using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thoughtsmithy.BarStoolLeague;
using Thoughtsmithy.BarStoolLeague.Data;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PitchingController : ControllerBase
    {
        private readonly BarStoolLeagueContext _context;

        public PitchingController(BarStoolLeagueContext context)
        {
            _context = context;
        }

        // GET: api/Pitching
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pitching>>> GetPitching()
        {
            return await _context.Pitching.ToListAsync();
        }

        // GET: api/Pitching/aaronha01/1974/1
        [HttpGet("{id}/{year}/{stint}")]
        public async Task<ActionResult<Pitching>> GetPitching(string id, short year, short stint)
        {
            var pitching = await _context.Pitching.FindAsync(id, year, stint);

            if (pitching == null)
            {
                return NotFound();
            }

            return pitching;
        }

    }
}
