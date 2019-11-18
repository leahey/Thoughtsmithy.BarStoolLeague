using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Thoughtsmithy.BarStoolLeague.Repositories
{
    /// <summary>
    /// Defines an object which returns data entities of type <typeparamref name="TEntity"/>.
    /// </summary>
    public interface IRepository<TEntity, TKey>
        where TEntity : class
    {
        /// <summary>
        /// Returns the entirety of the <typeparamref name="TEntity"/> table from the Database.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAllAsync();

        /// <summary>
        /// Returns <paramref name="pageSize"/> number of objects of type <typeparamref name="TEntity"/>
        /// from the database, as specified by <paramref name="pageIndex"/>.
        /// </summary>
        /// <param name="pageIndex">Specifies the page number of the paged data to return.</param>
        /// <param name="pageSize">Indicates how many records per page.</param>
        IQueryable<TEntity> Get(int pageIndex = 0, int pageSize = 50);

        /// <summary>
        /// Returns <paramref name="pageSize"/> number of objects of type <typeparamref name="TEntity"/> 
        /// that match the given <paramref name="expression"/>
        /// from the database, as specified by <paramref name="pageIndex"/>. 
        /// </summary>
        /// <param name="expression">The filter criteria for the Get() method.</param>
        /// <param name="pageIndex">Specifies the page number of the paged data to return.</param>
        /// <param name="pageSize">Indicates how many records per page.</param>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, 
            int pageIndex = 0, 
            int pageSize = 50);

        /// <summary>
        /// Returns an object of type <typeparamref name="TEntity"/> as specified by 
        /// <paramref name="id"/> of type <typeparamref name="TKey"/>.
        /// </summary>
        /// <param name="id"></param>
        TEntity GetById(TKey id);

        /// <summary>
        /// Gets objects of type <typeparamref name="TEntity"/> from the database as filtered 
        /// by the given <paramref name="predicate"/>.
        /// </summary>
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns <c>true</c> if the database contains a record which matches the given 
        /// <paramref name="predicate"/> otherwise, <c>false</c>.
        /// </summary>
        /// <param name="predicate"></param>
        bool Contains(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns a count of all <typeparamref name="TEntity"/> objects in the database.
        /// </summary>
        int TotalCount { get; }
    }
}
