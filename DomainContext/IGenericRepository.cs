using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DomainContext
{
    /// <summary>
    /// Provides generic repository for working with database
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Gets first or default entity by filter
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Entity</returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Gets list of entities by filter
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>List of entities</returns>
        Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Inserts entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Deletes Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>List of entities</returns>
        Task<IEnumerable<TEntity>> AllAsync();
    }
}
