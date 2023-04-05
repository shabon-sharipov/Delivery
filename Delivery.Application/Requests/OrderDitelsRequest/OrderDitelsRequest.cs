using Delivery.Application.Requests;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Requests.OrderDitelsRequest
{
    public abstract class OrderDitelsRequest : BaseRequest
    {
        public ulong OrderId { get; set; }
        public ulong ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
