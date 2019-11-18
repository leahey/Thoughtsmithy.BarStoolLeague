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
    public class BattingController : ControllerBase
    {
        private readonly BarStoolLeagueContext _context;

        public BattingController(BarStoolLeagueContext context)
        {
            _context = context;
        }

        // GET: api/Battings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batting>>> GetBatting()
        {
            return await _context.Batting.ToListAsync();
        }

        // GET: api/Battings/aaronha01/1974/1
        [HttpGet("{id}/{year}/{stint}")]
        public async Task<ActionResult<Batting>> GetBatting(string id, short year, short stint)
        {
            var batting = await _context.Batting.FindAsync(id, year, stint);

            if (batting == null)
            {
                return NotFound();
            }

            return batting;
        }

    }
}
