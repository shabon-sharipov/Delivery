using Delivery.Application.Exceptions;
using Delivery.Application.Requests.OrderFromCartRequests;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Response.OrderFromCartResponses;
using Delivery.Application.Response.OrderResponse;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Common.Interfaces
{
    public interface IOrderService : IBaseService<Order, OrderResponse, OrderRequest>
    {
        Task<OrderFromCartResponse> CreateOrder(OrderFromCartRequest orderDetails, CancellationToken cancellationToken);
        bool DeleteCartItem(ulong Id, CancellationToken cancellationToken);

    }
}
