using Delivery.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.CategoryProductResponse
{
    public class CategoryProductResponse : BaseResponse
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string ShortDescreption { get; set; }
    }
}