using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Respons.OrderResponse;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Services
{
    public class OrderService : BaseService<Order, OrderResponse, OrderRequest>, IOrderService
    {

    }
}
