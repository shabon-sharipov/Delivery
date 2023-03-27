using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Respons.OrderResponse
{
    public class UpdateOrderResponse : OrderResponse
    {
        public string OrderId { get; set; }
        public string PhoneNumber { get; set; }
        public string IsPayment { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
