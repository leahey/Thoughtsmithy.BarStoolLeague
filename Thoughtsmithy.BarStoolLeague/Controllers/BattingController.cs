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

        // GET: api/Batting?page=3&pageSize=50
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batting>>> GetBatting(int page = 0, int pageSize = 50)
        {
            return await _context.Batting.Skip(page * pageSize).Take(pageSize).ToListAsync();
        }

        // GET: api/Batting/aaronha01
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Batting>>> GetBatting(string id)
        {
            var result = await _context.Batting.Where(b => b.PlayerId.Equals(id)).ToListAsync();

            if (result == null)
                return NotFound();

            return result;
        }

        // GET: api/Batting/aaronha01/1974
        [HttpGet("{id}/{year}")]
        public async Task<ActionResult<IEnumerable<Batting>>> GetBatting(string id, short year)
        {
            var result = await _context.Batting.Where(b => b.PlayerId.Equals(id) && b.YearId == year).ToListAsync();

            if (result == null)
                return NotFound();

            return result;
        }

        // GET: api/Batting/aaronha01/1974/1
        [HttpGet("{id}/{year}/{stint}")]
        public async Task<ActionResult<Batting>> GetBatting(string id, short year, short stint)
        {
            var batting = await _context.Batting.FindAsync(id, year, stint);

            if (batting == null)
                return NotFound();

            return batting;
        }

    }
}
