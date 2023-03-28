using Delivery.Application.Requests.ProductsRequest;
using Delivery.Application.Response.ProductResponse;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Common.Interfaces
{
    public interface IProductService : IBaseService<Product, ProductResponse, ProductRequest>
    {

    }
}
