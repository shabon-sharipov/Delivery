﻿using AutoMapper;
using Delivery.Application.Requests.CategoryCustomerRequest;
using Delivery.Application.Requests.CategoryProductRequest;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Requests.ProductsRequest;
using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Response.CategoryCustomerResponse;
using Delivery.Application.Response.CategoryProductResponse;
using Delivery.Application.Response.OrderResponse;
using Delivery.Application.Response.ProductResponse;
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


            CreateMap<CreateCategoryProductRequest, ProductCategory>();
            CreateMap<UpdateCategoryProductRequest, ProductCategory>();
            CreateMap<ProductCategory, CategoryProductResponse>();


            CreateMap<CreateMerchantCustomerRequest, MerchantCategory>();
            CreateMap<UpdateCategoryProductRequest, MerchantCategory>();
            CreateMap<MerchantCategory, MerchantCategoryResponse>();


            CreateMap<CreateDriverRequest, Driver>();
            CreateMap<UpdateDriverRequest, Driver>();
            CreateMap<Driver, CreateDriverResponse>();
            CreateMap<Driver, UpdateDriverResponse>();
            CreateMap<Driver, GetDriverResponse>();
            CreateMap<Driver, DriverPaggedListItemResponse>();

            CreateMap<CreateOrderRequest, Order>();
            CreateMap<Order, CreateOrderResponse>();
            CreateMap<Order, GetOrderResponse>();
            CreateMap<UpdateOrderRequest, Order>();
            CreateMap<Order, UpdateOrderResponse>();
        }

    }
}
