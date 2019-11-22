using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thoughtsmithy.BarStoolLeague.Data;
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

        // GET: api/Fielding?page=3&pageSize=50
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fielding>>> GetFielding(int page = 0, int pageSize = 50)
        {
            return await _context.Fielding.Skip(page * pageSize).Take(pageSize).ToListAsync();
        }


        // GET: api/Fielding/aaronha1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Fielding>>> GetFielding(string id)
        {
            var result = await _context.Fielding.Where(f => f.PlayerId.Equals(id)).ToListAsync();

            if (result == null)
                return NotFound();

            return result;
        }

        // GET: api/Fielding/aaronha1/1974
        [HttpGet("{id}/{year}")]
        public async Task<ActionResult<IEnumerable<Fielding>>> GetFielding(string id, short year)
        {
            var result = await _context.Fielding.Where(f => f.PlayerId.Equals(id) && f.YearId.Equals(year)).ToListAsync();

            if (result == null)
                return NotFound();

            return result;
        }

        // GET: api/Fielding/aaronha1/1974/1
        [HttpGet("{id}/{year}/{stint}")]
        public async Task<ActionResult<IEnumerable<Fielding>>> GetFielding(string id, short year, short stint)
        {
            var result = await _context.Fielding.Where(f => f.PlayerId.Equals(id) && f.YearId.Equals(year) && f.Stint.Equals(stint)).ToListAsync();

            if (result == null)
                return NotFound();

            return result;
        }

        // GET: api/Fielding/aaronha1/1974/1/OF
        [HttpGet("{id}/{year}/{stint}/{pos}")]
        public async Task<ActionResult<Fielding>> GetFielding(string id, short year, short stint, string pos)
        {
            var result = await _context.Fielding.FindAsync( id, year, stint, pos );

            if (result == null)
                return NotFound();

            return result;
        }
    }
}



