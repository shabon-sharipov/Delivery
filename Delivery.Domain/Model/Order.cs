using Delivery.Domain.Abstract;
using Delivery.Domain.Enam;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Model
{
    public class Order : EntityBase
    {
        public Order()
        {
            OrderDetails = new Collection<OrderDetails>();
        }

        public string ShipAddress { get; set; }
        public DateTime ShipDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public double PointLat { get; set; }
        public double PointLng { get; set; }

        public ulong MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }

        public ulong CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public ulong? DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; private set; }

        public bool IsPayment { get; set; }
    }
}
