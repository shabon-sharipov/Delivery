using AutoMapper;
using Delivery.Application.Requests.CategoryCustomerRequest;
using Delivery.Application.Requests.CategoryProductRequest;
using Delivery.Application.Requests.ProductsRequest;
using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Respons.CategoryCustomerResponse;
using Delivery.Application.Respons.CategoryProductResponse;
using Delivery.Application.Respons.ProductRespons;
using Delivery.Application.Respons.ProductRespons.PaggedList;
using Delivery.Application.Respons.SenderResponse;
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



            CreateMap<IEnumerable<Product>, IEnumerable<PaggedListItemResponse>>();


            CreateMap<CategoryCustomer, CategoryCustomerResponse>();
            CreateMap<CategoryCustomerRequest, CategoryCustomer>();

            CreateMap<Sender, SenderResponse>();
            CreateMap<SenderRequest, Sender>();
        }
    }
}
