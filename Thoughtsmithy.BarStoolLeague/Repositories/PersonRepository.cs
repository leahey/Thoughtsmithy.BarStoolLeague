using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Repositories
{
    internal class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        /// <summary>
        /// Returns a count of all <typeparamref name="TEntity"/> objects in the database.
        /// </summary>
        public int TotalCount => DbContext.Persons.Count();

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        public PersonRepository(BarStoolLeagueContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// Returns <c>true</c> if the database contains a record which matches the given 
        /// <paramref name="predicate"/> otherwise, <c>false</c>.
        /// </summary>
        public async Task<bool> ContainsAsync(Expression<Func<Person, bool>> predicate)
        {
            return await DbContext.Persons.AnyAsync(predicate);
        }

        /// <summary>
        /// Gets objects of type <see cref="Person"/> from the database as filtered 
        /// by the given <paramref name="predicate"/>.
        /// </summary>
        public async Task<IQueryable<Person>> FilterAsync(Expression<Func<Person, bool>> predicate)
        {
            return await DbContext.Persons.Where(predicate).ToListAsync() as IQueryable<Person>;
        }

        /// <summary>
        /// Returns <paramref name="pageSize"/> number of objects of type <typeparamref name="TEntity"/>
        /// from the database, as specified by <paramref name="pageIndex"/>.
        /// </summary>
        /// <param name="pageIndex">Specifies the page number of the paged data to return.</param>
        /// <param name="pageSize">Indicates how many records per page.</param>
        public async Task<IQueryable<Person>> GetAsync(int pageIndex = 0, int pageSize = 50)
        {
            return await GetAsync(x => true, pageIndex, pageSize);
        }

        /// <summary>
        /// Returns <paramref name="pageSize"/> number of objects of type <typeparamref name="TEntity"/> 
        /// that match the given <paramref name="expression"/>
        /// from the database, as specified by <paramref name="pageIndex"/>. 
        /// </summary>
        /// <param name="expression">The filter criteria for the Get() method.</param>
        /// <param name="pageIndex">Specifies the page number of the paged data to return.</param>
        /// <param name="pageSize">Indicates how many records per page.</param>
        public async Task<IQueryable<Person>> GetAsync(Expression<Func<Person, bool>> expression, int pageIndex = 0, int pageSize = 50)
        {
            var result = await DbContext.Persons.Where(expression).ToListAsync();

            if (TotalCount < pageIndex * pageSize)
                return new List<Person>().AsQueryable();

            return result.Skip(pageIndex * pageSize).Take(pageSize).AsQueryable();
        }

        /// <summary>
        /// Returns an object of type <tpa
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Person> GetByIdAsync<T>(T id)
        {
            return await FilterAsync(p => p.PlayerId.Equals(id)).Result.SingleAsync();
        }
    }
}
