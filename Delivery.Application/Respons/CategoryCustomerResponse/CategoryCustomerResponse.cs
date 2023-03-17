using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Respons.CategoryCustomerResponse
{
    public class CategoryCustomerResponse : BaseResponse
    {
        public ulong id { get; set; }
        public string Name { get; set; }
        public string ShortDescreption { get; set; }
    }
}
