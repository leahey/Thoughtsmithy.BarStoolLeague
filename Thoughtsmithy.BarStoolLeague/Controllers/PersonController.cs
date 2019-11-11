using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Thoughtsmithy.BarStoolLeague.Models;
using Thoughtsmithy.BarStoolLeague.Repositories;

namespace Thoughtsmithy.BarStoolLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository peopleRepository) => _repository = peopleRepository;

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IQueryable<Person>>> GetPersons() => Ok(await _repository.GetAsync());

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(string id)
        {
            var person = await _repository.GetByIdAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        //private async Task<bool> PeopleExistsAsync(string id) => await _repository.ContainsAsync(p => p.PlayerId == id);

        #region write methods
        //// PUT: api/People/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPeople(string id, People person)
        //{
        //    if (id != person.PeopleId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(person).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PeopleExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/People
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<People>> PostPeople(People person)
        //{
        //    _context.Peoples.Add(person);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (PeopleExists(person.PeopleId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction(nameof(GetPeople), new { id = person.PeopleId }, person);
        //}

        //// DELETE: api/People/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<People>> DeletePeople(string id)
        //{
        //    var person = await _context.Peoples.FindAsync(id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Peoples.Remove(person);
        //    await _context.SaveChangesAsync();

        //    return person;
        //}
        #endregion

    }
}
