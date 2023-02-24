using Delivery.Application.Common.Interfaces;
using Delivery.Domain.Model;

namespace Delivery.Application.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : EntityBase
    {
        public TEntity Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Delete(ulong id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(ulong id)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity, ulong id)
        {
            throw new NotImplementedException();
        }
    }
}