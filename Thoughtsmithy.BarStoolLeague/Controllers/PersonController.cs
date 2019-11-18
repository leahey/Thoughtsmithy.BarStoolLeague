using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly BarStoolLeagueContext _context;

        public PersonController(BarStoolLeagueContext context)
        {
            _context = context;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        // GET: api/Person/aaronha01
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(string id)
        {
            var trimmedId = id.Trim('"');
            var person = await _context.Persons.Where(p => p.PlayerId.Equals(trimmedId)).FirstAsync();
            
            // Because we have no primary key, can't use Find()
            //var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

    }
}
