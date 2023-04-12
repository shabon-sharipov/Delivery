using Delivery.Application.Exceptions;
using Delivery.Application.Requests.OrderRequest;
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
        Task<OrderDetails> CreateOrderDitels(OrderDetails orderDetails, CancellationToken cancellationToken);
        Task<bool> DeleteOrderDitels(ulong Id, CancellationToken cancellationToken);

    }
}
