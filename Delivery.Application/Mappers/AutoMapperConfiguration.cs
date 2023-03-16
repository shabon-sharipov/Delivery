using AutoMapper;
using Delivery.Application.Requests.CategoryProductRequest;
using Delivery.Application.Requests.ProductsRequest;
using Delivery.Application.Respons.CategoryProductResponse;
using Delivery.Application.Respons.ProductRespons;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Mappers
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductRequest, Product>();

            CreateMap<CategoryProduct, CategoryProductResponse>();
            CreateMap<CategoryProductRequest, CategoryProduct>();
        }
    }
}
