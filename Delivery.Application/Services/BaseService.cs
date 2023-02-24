using Delivery.Application.Common.Interfaces;
using Delivery.Domain.Model;

namespace Delivery.Application.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : EntityBase
    {
        public virtual TEntity Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Get(ulong id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Update(TEntity entity, ulong id)
        {
            throw new NotImplementedException();
        }
    }
}