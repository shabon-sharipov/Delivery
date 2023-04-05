using Delivery.Domain.Abstract;
using Delivery.Domain.Enam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Model
{
    public class Order : EntityBase
    {
        public string ShipAddress { get; set; }
        public DateTime ShipDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public ulong CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public ulong DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual IEnumerable<OrderDetails> OrderDetails { get; set; }
        public string AvailableFrom { get; set; }

        public string AvailableTo { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPayment { get; set; }
    }
}
