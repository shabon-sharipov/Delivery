using Delivery.Domain.Enam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.OrderResponse
{
    public class UpdateOrderResponse : OrderResponse
    {
        public ulong Id { get; set; }
        public string AvailableFrom { get; set; }
        public string AvailableTo { get; set; }
        public string PhoneNumber { get; set; }
        public string IsPayment { get; set; }
        public decimal TotalPrice { get; set; }
        public ulong DriverId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
