using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Enam
{
    public enum OrderStatus
    {
        Open = 1,
        Active = 2,
        Shipping = 3,
        Closed = 4,
        Cancel = 5
    }
}
