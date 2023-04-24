using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.CartResponse
{
    public class UpdateCartResponse : CartResponse
    {
        public ulong CustomerId { get; set; }
    }
}
