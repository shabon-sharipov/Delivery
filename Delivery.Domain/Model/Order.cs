using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Model
{
    public class Order: EntityBase
    {
        public List<Product> Products { get; set; }
        public string AvailableFrom { get; set; }
        public string AvailableTo { get; set;}
        public int PhoneNumber { get; set; }
        public float IsPayment { get; set; }
        public float TotalPrice { get; set; }
        public int SenderId { get; set; }
            


    }
}
