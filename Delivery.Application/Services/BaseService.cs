using Delivery.Application.Common.Interfaces;
using Delivery.Domain.Model;

namespace Delivery.Application.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : EntityBase
    {
        public virtual async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(ulong id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> Get(ulong id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> Update(TEntity entity, ulong id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}