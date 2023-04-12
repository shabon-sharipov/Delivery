using Delivery.Application.Requests.CardItemRequest;
using Delivery.Application.Response.CardItemResponse;


namespace Delivery.Application.Common.Interfaces
{
    public interface ICardItemService : IBaseService<CardItem, CardItemResponse,  CardItemRequest>
    {

    }
}
