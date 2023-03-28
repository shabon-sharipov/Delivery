using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Domain.Abstract;
using Delivery.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbSet<T> _dbSet;
        private readonly EFContext _context;

        public Repository(EFContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public async Task<IQueryable<T>> GetAllAsync(int pageSize, int PageNumber, CancellationToken cancellationToken)
        {
            return _dbSet.Skip(pageSize * PageNumber).Take(pageSize);
        }

        public IQueryable<T> GetAll(int pageSize, int PageNumber, CancellationToken cancellationToken)
        {
            return _dbSet.Skip(pageSize * PageNumber).Take(pageSize);
        }

        public T Find(ulong id) => _dbSet.Find(id);
        public async Task<T> FindAsync(ulong id, CancellationToken cancellationToken = default) => await _dbSet.FindAsync(id);

        public void Add(T entity) => _dbSet.Add(entity);
        public void Add(IEnumerable<T> entities) => _dbSet.AddRange(entities);

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default) => await _dbSet.AddAsync(entity, cancellationToken);

        public async Task AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default) => await _dbSet.AddRangeAsync(entities, cancellationToken);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public int SaveChanges() => _context.SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync(cancellationToken);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Update(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);
    }
}
