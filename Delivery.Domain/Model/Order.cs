using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Model
{
    public class Order: EntityBase
    {
        public IEnumerable<Product> Products { get; set; }
        public string AvailableFrom { get; set; }
        public string AvailableTo { get; set;}
        public int PhoneNumber { get; set; }
        public bool IsPayment { get; set; }
        public decimal TotalPrice { get; set; }
        public ulong SenderId { get; set; }
            


    }
}
