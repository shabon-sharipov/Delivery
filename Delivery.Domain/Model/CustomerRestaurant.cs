using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Model
{
    public class CustomerRestaurant : EntityBase
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ShortDiscreption { get; set; }
        public string IsActive { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
