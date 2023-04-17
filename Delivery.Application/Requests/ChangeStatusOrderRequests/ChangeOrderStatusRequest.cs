using Delivery.Domain.Enam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Requests.ChangeStatusOrderRequests
{
    public class ChangeOrderStatusRequest : BaseRequest
    {
        public OrderStatus OrderStatus { get; set; }
    }
}
