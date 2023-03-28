using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests;
using Delivery.Application.Response;
using Delivery.Domain.Abstract;

namespace Delivery.Application.Services
{
    public abstract class BaseService<TEntity, IResponse, IRequest> : IBaseService<TEntity, IResponse, IRequest>
        where TEntity : EntityBase
        where IRequest : BaseRequest
        where IResponse : BaseResponse
    {
        public virtual Task<IResponse> Create(IRequest entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(ulong id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<IResponse>> GetAll(int PageSize, int PageNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IResponse> Update(IRequest request, ulong id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}