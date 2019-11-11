using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Thoughtsmithy.BarStoolLeague.Repositories
{
    /// <summary>
    /// Defines an object which returns data entities of type <typeparamref name="TEntity"/>.
    /// </summary>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Returns <paramref name="pageSize"/> number of objects of type <typeparamref name="TEntity"/>
        /// from the database, as specified by <paramref name="pageIndex"/>.
        /// </summary>
        /// <param name="pageIndex">Specifies the page number of the paged data to return.</param>
        /// <param name="pageSize">Indicates how many records per page.</param>
        Task<IQueryable<TEntity>> GetAsync(int pageIndex = 0, int pageSize = 50);

        /// <summary>
        /// Returns <paramref name="pageSize"/> number of objects of type <typeparamref name="TEntity"/> 
        /// that match the given <paramref name="expression"/>
        /// from the database, as specified by <paramref name="pageIndex"/>. 
        /// </summary>
        /// <param name="expression">The filter criteria for the Get() method.</param>
        /// <param name="pageIndex">Specifies the page number of the paged data to return.</param>
        /// <param name="pageSize">Indicates how many records per page.</param>
        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, 
            int pageIndex = 0, 
            int pageSize = 50);

        /// <summary>
        /// Returns an object of type <tpa
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync<T>(T id);

        /// <summary>
        /// Gets objects of type <typeparamref name="TEntity"/> from the database as filtered 
        /// by the given <paramref name="predicate"/>.
        /// </summary>
        Task<IQueryable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns <c>true</c> if the database contains a record which matches the given 
        /// <paramref name="predicate"/> otherwise, <c>false</c>.
        /// </summary>
        /// <param name="predicate"></param>
        Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns a count of all <typeparamref name="TEntity"/> objects in the database.
        /// </summary>
        int TotalCount { get; }
    }
}
