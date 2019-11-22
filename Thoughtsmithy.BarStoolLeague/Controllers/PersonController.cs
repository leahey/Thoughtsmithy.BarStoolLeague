using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thoughtsmithy.BarStoolLeague.Data;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly BarStoolLeagueContext context;

        public PersonController(BarStoolLeagueContext context)
        {
            this.context = context;
        }

        // GET: api/Person?page=3&pageSize=50
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons(int page = 0, int pageSize = 50)
        {
            return await context.Persons.Skip(page * pageSize).Take(pageSize).ToListAsync();
        }

        // GET: api/Person/byId?id=aaronha01
        [HttpGet("byId")]
        public async Task<ActionResult<Person>> GetPerson(string id)
        {
            var trimmedId = id.Trim('"');
            //var person = await context.Persons.Where(p => p.PlayerId.Equals(trimmedId)).FirstAsync();
            
            // Because we have no primary key, can't use Find()
            var person = await context.Persons.FindAsync(id);
            // TODO: nb: this may no longer be true with PersonConfiguration forcing a key.

            if (person == null)
                return NotFound();

            return person;
        }

        // GET: api/Person/byName?lastName=Aaron&firstName=Hank
        [HttpGet("byName")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson(string lastName, string firstName)
        {
            // I can't BELIEVE I'm using .ToUpper for comparison, but String.Compare() is throwing
            // during the query execution.
            var trimmedLastName = lastName.Trim().ToUpper();
            var trimmedFirstName = firstName.Trim().ToUpper();

            var result = await context.Persons
                .Where(p => p.NameLast.ToUpper() == trimmedLastName)
                .Where(p => p.NameFirst.ToUpper().Contains(trimmedFirstName))
                .ToListAsync();

            if (result.Count == 0)
                return NotFound();

            return result;
        }
    }
}
