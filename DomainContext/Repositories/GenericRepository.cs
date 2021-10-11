using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DomainContext.Repositories
{
    /// <summary>
    /// Provides generic repository for working with database
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        protected readonly TodoContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(TodoContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Gets first or default entity by filter
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Entity</returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = DbSet;
            query = Filter(query, filter);

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets list of entities by filter
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>List of entities</returns>
        public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = DbSet;
            query = Filter(query, filter);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Inserts entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Insert(TEntity entity)
        {
            if (CheckEntityIsNotNull(entity)) 
                DbSet.Add(entity);
        }

        /// <summary>
        /// Deletes Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Delete(TEntity entity)
        {
            if (CheckEntityIsNotNull(entity))
                DbSet.Remove(entity);
        }

        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<IEnumerable<TEntity>> AllAsync() => await DbSet.ToListAsync();

        /// <summary>
        /// Filter entities
        /// </summary>
        /// <param name="data">Entities for filter</param>
        /// <param name="filter">Filter expression</param>
        /// <returns>List of filtered entities</returns>
        protected virtual IQueryable<TEntity>
            Filter(IQueryable<TEntity> data, Expression<Func<TEntity, bool>> filter) =>
            filter == null ? data : data.Where(filter);

        /// <summary>
        /// Checks entity is not null
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Result of check</returns>
        private bool CheckEntityIsNotNull(TEntity entity) => entity != null;
    }
}
