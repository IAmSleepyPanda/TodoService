using System.Threading.Tasks;

namespace DomainContext
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class, new();
        Task SaveAsync();
    }
}
