using Delivery.Domain.Model;
using System.Reflection.Emit;

namespace Delivery.Application.Common.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Get(ulong id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAll(int PageSize, int PageNumber, CancellationToken cancellationToken);
        Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> Update(TEntity entity, ulong id, CancellationToken cancellationToken);
        bool Delete(ulong id, CancellationToken cancellationToken);
    }
}

