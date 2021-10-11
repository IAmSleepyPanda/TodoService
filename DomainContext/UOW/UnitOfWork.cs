using System.Threading.Tasks;
using DomainContext.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DomainContext.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly TodoContext Context;

        public UnitOfWork(DbContextOptions options)
        {
            Context = new TodoContext(options);
        }

        public IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class, new() =>
            new GenericRepository<TEntity>(Context);



        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
