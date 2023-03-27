using AutoMapper;
using Delivery.Application.Requests.CategoryCustomerRequest;
using Delivery.Application.Requests.CategoryProductRequest;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Requests.ProductsRequest;
using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Respons.CategoryCustomerResponse;
using Delivery.Application.Respons.CategoryProductResponse;
using Delivery.Application.Respons.OrderResponse;
using Delivery.Application.Respons.ProductRespons;
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
            CreateMap<Product, CreateProductResponse>();
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, ProductPaggedListItemResponse>();
            CreateMap<Product, GetProductResponse>();
            CreateMap<Product, UpdateProductResponse>();


            CreateMap<CreateCategoryProductRequest, CategoryProduct>();
            CreateMap<UpdateCategoryProductRequest, CategoryProduct>();
            CreateMap<CategoryProduct, CategoryProductResponse>();


            CreateMap<CreateCategoryCustomerRequest, CategoryCustomer>();
            CreateMap<UpdateCategoryProductRequest, CategoryCustomer>();
            CreateMap<CategoryCustomer, CategoryCustomerResponse>();


            CreateMap<CreateSenderRequest, Sender>();
            CreateMap<UpdateSenderRequest, Sender>();
            CreateMap<Sender, CreateSenderResponse>();
            CreateMap<Sender, UpdateSenderResponse>();
            CreateMap<Sender, GetSenderResponse>();
            CreateMap<Sender, SenderPaggedListItemResponse>();

            CreateMap<CreateOrderRequest, Order>();
            CreateMap<Order, CreateOrderResponse>();
            CreateMap<Order, GetOrderResponse>();
            CreateMap<UpdateOrderRequest, Order>();
            CreateMap<Order, UpdateOrderResponse>();
        }

    }
}
