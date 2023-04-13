using Delivery.Application.Requests;
using Delivery.Domain.Enam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.OrderFromCartResponses
{
    public class OrderFromCartResponse : BaseRequest
    {
        public ulong Id { get; set; }
        public string ShipAddress { get; set; }
        public DateTime ShipDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ulong CustomerId { get; set; }
        public ulong DriverId { get; set; }
        public virtual IEnumerable<GetOrderDitelsResponse> OrderDetails { get; set; }
        public decimal TotalPrice { get; set; }
        public string AvailableTo { get; set; }
        public bool IsPayment { get; set; }
    }
}
