using Delivery.Application.Requests.CategoryProductRequest;
using Delivery.Application.Respons.CategoryProductResponse;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Common.Interfaces
{
    public interface ICategoryProductServices : IBaseService<CategoryProduct, CategoryProductResponse, CategoryProductRequest>
    {
    }
}
