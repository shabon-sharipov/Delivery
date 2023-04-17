using Delivery.Domain.Enam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.ChangeOrderStatusResponses
{
    public class ChangeOrderStatusResponse : BaseResponse
    {
        public OrderStatus OrderStatus { get; set; }

    }
}
