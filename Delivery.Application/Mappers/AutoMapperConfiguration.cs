using AutoMapper;
using Delivery.Application.Requests.CardItemRequest;
using Delivery.Application.Requests.CategoryCustomerRequest;
using Delivery.Application.Requests.CategoryProductRequest;
using Delivery.Application.Requests.CustomerRequest;
using Delivery.Application.Requests.MerchantBranch;
using Delivery.Application.Requests.MerchantRequest;
using Delivery.Application.Requests.OrderFromCartRequests;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Requests.ProductsRequest;
using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Response.CardItemResponse;
using Delivery.Application.Response.CategoryCustomerResponse;
using Delivery.Application.Response.CategoryProductResponse;
using Delivery.Application.Response.CustomerResponse;
using Delivery.Application.Response.MerchantBranchResponse;
using Delivery.Application.Response.MerchantResponse;
using Delivery.Application.Response.OrderFromCartResponses;
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
            CreateMap<Product, PaggedListProductItemResponse>();
            CreateMap<Product, GetProductResponse>();
            CreateMap<Product, UpdateProductResponse>();


            CreateMap<CreateCategoryProductRequest, ProductCategory>();
            CreateMap<UpdateCategoryProductRequest, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryResponse>();


            CreateMap<CreateMerchantCategoryRequest, MerchantCategory>();
            CreateMap<UpdateCategoryProductRequest, MerchantCategory>();
            CreateMap<MerchantCategory, MerchantCategoryResponse>();


            CreateMap<CreateDriverRequest, Driver>();
            CreateMap<UpdateDriverRequest, Driver>();
            CreateMap<Driver, CreateDriverResponse>();
            CreateMap<Driver, UpdateDriverResponse>();
            CreateMap<Driver, GetDriverResponse>();
            CreateMap<Driver, PaggedListDriverItemResponse>();

            CreateMap<CreateOrderRequest, Order>();
            CreateMap<UpdateOrderRequest, Order>();
            CreateMap<Order, CreateOrderResponse>();
            CreateMap<Order, UpdateOrderResponse>();
            CreateMap<Order, PaggedOrderListItemResponse>();
            CreateMap<Order, GetOrderResponse>()
    .ForMember(or => or.TotalPrice, o => o.MapFrom(o => o.OrderDetails.Sum(o => o.UnitPrice * o.Quantity)));

            CreateMap<OrderFromCartRequest, Order>();
            CreateMap<Order, OrderFromCartResponse>();

            CreateMap<CreateOrderDitelsRequest, OrderDetails>();
            CreateMap<OrderDetails, CreateOrderDitelsResponse>();
            CreateMap<UpdateOrderDitelsRequest, OrderDetails>();
            CreateMap<OrderDetails, UpdateOrderDitelsResponse>();
            CreateMap<OrderDetails, PaggedOrderDitelsListItemResponse>();
            CreateMap<OrderDetails, GetOrderDitelsResponse>()
                .ForMember(or => or.TotalPrice, o => o.MapFrom(o => o.UnitPrice * o.Quantity));

            CreateMap<CreateMerchantRequest, Merchant>();
            CreateMap<Merchant, CreateMerchantResponse>();
            CreateMap<Merchant, GetMerchantResponse>();
            CreateMap<UpdateMerchantRequest, Merchant>();
            CreateMap<Merchant, UpdateMerchantResponse>();
            CreateMap<Merchant, PaggedMerchantListItemResponse>();

            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<Customer, CreateCustomerResponse>();
            CreateMap<Customer, GetCustomerResponse>();
            CreateMap<UpdateCustomerRequest, Customer>();
            CreateMap<Customer, UpdateCustomerResponse>();
            CreateMap<Customer, PaggedListCustomerItemResponse>();


            CreateMap<CreateMerchantBranchRequest, MerchantBranch>();
            CreateMap<MerchantBranch, MerchantBranchResponse>();
            CreateMap<UpdateMerchantBranchRequest, MerchantBranch>();
            CreateMap<MerchantBranch, UpdateMerchantBranchResponse>();
            CreateMap<MerchantBranch, GetMerchantBranchResponse>();

            CreateMap<CartItem, CreateCardItemResponse>();
            CreateMap<CreateCardItemRequest, CartItem>();
            CreateMap<UpdateCardItemRequest, CartItem>();
            CreateMap<CartItem, PaggedListCardItemResponse>();
            CreateMap<CartItem, UpdateCardItemResponse>();
            CreateMap<CartItem, GetCardItemResponse>()
                 .ForMember(or => or.TotalPrice, o => o.MapFrom(o => o.UnitPrice * o.Quantity));

            CreateMap<CreateCartRequest, Cart>();
            CreateMap<Cart, CreateCartRespons>();
            CreateMap<Cart, GetCartResponse>()
                 .ForMember(or => or.TotalPrice, o => o.MapFrom(o => o.Items.Sum(o => o.UnitPrice * o.Quantity)));
        }

    }
}
