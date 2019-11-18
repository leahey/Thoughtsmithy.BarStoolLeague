using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Thoughtsmithy.BarStoolLeague.Models;

namespace Thoughtsmithy.BarStoolLeague.Repositories
{
    internal class BattingRepository : RepositoryBase<Person, Tuple<string, short, short>>, IBattingRepository
    {
        public BattingRepository(BarStoolLeagueContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// Returns a count of all <typeparamref name="TEntity"/> objects in the database.
        /// </summary>
        public int TotalCount => DbContext.Batting.Count();

        /// <summary>
        /// Returns <c>true</c> if the database contains a record which matches the given 
        /// <paramref name="predicate"/> otherwise, <c>false</c>.
        /// </summary>
        /// <param name="predicate"></param>
        public bool Contains(Expression<Func<Batting, bool>> predicate)
        {
            return DbContext.Batting.Any(predicate);
        }

        /// <summary>
        /// Gets objects of type <typeparamref name="TEntity"/> from the database as filtered 
        /// by the given <paramref name="predicate"/>.
        /// </summary>
        public IQueryable<Batting> Filter(Expression<Func<Batting, bool>> predicate)
        {
            return DbContext.Batting.Where(predicate).ToList() as IQueryable<Batting>;
        }

        /// <summary>
        /// Returns <paramref name="pageSize"/> number of objects of type <typeparamref name="TEntity"/>
        /// from the database, as specified by <paramref name="pageIndex"/>.
        /// </summary>
        /// <param name="pageIndex">Specifies the page number of the paged data to return.</param>
        /// <param name="pageSize">Indicates how many records per page.</param>
        public IQueryable<Batting> Get(int pageIndex = 0, int pageSize = 50)
        {
            return Get(x => true, pageIndex, pageSize);
        }

        /// <summary>
        /// Returns <paramref name="pageSize"/> number of objects of type <typeparamref name="TEntity"/> 
        /// that match the given <paramref name="expression"/>
        /// from the database, as specified by <paramref name="pageIndex"/>. 
        /// </summary>
        /// <param name="expression">The filter criteria for the Get() method.</param>
        /// <param name="pageIndex">Specifies the page number of the paged data to return.</param>
        /// <param name="pageSize">Indicates how many records per page.</param>
        public IQueryable<Batting> Get(Expression<Func<Batting, bool>> expression, int pageIndex = 0, int pageSize = 50)
        {
            var result = DbContext.Batting.Where(expression).ToList();

            if (TotalCount < pageIndex * pageSize)
                return new List<Batting>().AsQueryable();

            return result.Skip(pageIndex * pageSize).Take(pageSize).AsQueryable();
        }

        /// <summary>
        /// Returns the entirety of the <typeparamref name="TEntity"/> table from the Database.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Batting> GetAllAsync()
        {
            return DbContext.Batting.AsQueryable();
        }

        /// <summary>
        /// Returns an object of type <typeparamref name="TEntity"/> as specified by 
        /// <paramref name="id"/> of type <typeparamref name="TKey"/>.
        /// </summary>
        /// <param name="id"></param>
        public Batting GetById(Tuple<string, short, short> id)
        {
            return DbContext.Batting.SingleOrDefault(b =>
                    b.PlayerId == id.Item1
                    && b.YearId == id.Item2
                    && b.Stint == id.Item3
                );
        }
    }
}