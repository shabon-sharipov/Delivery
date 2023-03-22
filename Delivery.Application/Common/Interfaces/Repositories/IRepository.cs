using Delivery.Domain.Model;

namespace Delivery.Application.Common.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> GetAll(int pageSize, int pageNumber, CancellationToken cancellation);
        Task<IQueryable<TEntity>> GetAllAsync(int pageSize, int pageNumber, CancellationToken cancellation);

        TEntity Find(ulong id);
        Task<TEntity> FindAsync(ulong id, CancellationToken cancellationToken = default);

        void Add(TEntity entity);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        void Add(IEnumerable<TEntity> entities);
        Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        void Delete(TEntity entity);

        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
