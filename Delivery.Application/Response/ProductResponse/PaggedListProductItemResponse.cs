using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.ProductResponse
{
    public class PaggedListProductItemResponse : ProductResponse
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
