using Delivery.Domain.Enam;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.OrderResponse
{
    public class CreateOrderResponse : OrderResponse
    {
        public string ShipAddress { get; set; }
        public ulong CustomerId { get; set; }
        public ulong DriverId { get; set; }
        public ulong CardId { get; set; }
        public decimal TotalPrice { get; set; }
        public string AvailableTo { get; set; }
    }
}
