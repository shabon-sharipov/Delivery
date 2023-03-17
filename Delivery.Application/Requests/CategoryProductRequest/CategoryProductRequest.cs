using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Requests.CategoryProductRequest
{
    public abstract class CategoryProductRequest : BaseRequest
    {
        public string Name { get; set; }
        public string ShortDescreption { get; set; }
    }
}
