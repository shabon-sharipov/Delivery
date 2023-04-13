using Delivery.Domain.Enam;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Requests.OrderRequest
{
    public abstract class OrderRequest : BaseRequest
    {
        public string ShipAddress { get; set; }
        public DateTime ShipDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ulong CustomerId { get; set; }
        public string AvailableTo { get; set; }
        public bool IsPayment { get; set; }
    }
}
