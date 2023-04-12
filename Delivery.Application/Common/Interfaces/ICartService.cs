using Delivery.Application.Requests.CardItemRequest;
using Delivery.Application.Requests.CartRequests;
using Delivery.Application.Response.CardItemResponse;
using Delivery.Application.Response.CartRespons;

namespace Delivery.Application.Common.Interfaces
{
    public interface ICartService : IBaseService<Cart, CartResponse, CartRequest>
    {
        Task<CreateCardItemResponse> CreateCartItem(CreateCardItemRequest cartItem, CancellationToken cancellationToken);
        Task<bool> DeleteCartItem(ulong Id, CancellationToken cancellationToken);
    }
}
