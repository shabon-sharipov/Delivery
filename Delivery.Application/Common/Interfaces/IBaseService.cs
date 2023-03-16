using Delivery.Application.Requests;
using Delivery.Application.Respons;
using Delivery.Domain.Model;
using System.Reflection.Emit;

namespace Delivery.Application.Common.Interfaces
{
    public interface IBaseService<TEntity, IResponse, IRequest>
        where TEntity : EntityBase
        where IRequest : BaseRequest
        where IResponse : BaseResponse
    {
        Task<IResponse> Get(ulong id, CancellationToken cancellationToken);
        Task<IEnumerable<IResponse>> GetAll(int pageSize, int pageNumber, CancellationToken cancellationToken);
        Task<IResponse> Create(IRequest request, CancellationToken cancellationToken);
        Task<IResponse> Update(IRequest request, ulong id, CancellationToken cancellationToken);
        bool Delete(ulong id, CancellationToken cancellationToken);
    }
}

