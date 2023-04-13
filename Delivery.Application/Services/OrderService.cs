using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.OrderFromCartRequests;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Response.OrderFromCartResponses;
using Delivery.Application.Response.OrderResponse;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Services
{
    public class OrderService : BaseService<Order, OrderResponse, OrderRequest>, IOrderService
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<OrderDetails> _repositoryOrderDetails;
        private readonly IRepository<Cart> _repositoryCart;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repository, IRepository<OrderDetails> repositoryOrderDetails, IMapper mapper, IRepository<Cart> repositoryCart)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryOrderDetails = repositoryOrderDetails;
            _repositoryCart = repositoryCart;
        }

        public async Task<IEnumerable<OrderResponse>> GetAll(int PageSize, int PageNumber, CancellationToken cancellationToken)
        {
            var products = _repository.GetAll(PageSize, PageNumber, cancellationToken);
            return _mapper.Map<IEnumerable<PaggedOrderListItemResponse>>(products);
        }

        public override async Task<OrderResponse> Create(OrderRequest request, CancellationToken cancellationToken)
        {
            //if (request == null)
            //    throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Order));

            //var cart = await _repositoryCart.FindAsync(request.CardId, cancellationToken);
            //if (cart == null)
            //    throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Cart));

            //var createOrderRequest = request as CreateOrderRequest;
            //var entity = _mapper.Map<CreateOrderRequest, Order>(createOrderRequest);
            //entity.OrderDetails = MoveItemsFromCartToOrder(cart.CardItems);

            //await _repository.AddAsync(entity, cancellationToken);
            //await _repository.SaveChangesAsync(cancellationToken);

            return null;//_mapper.Map<Order, CreateOrderResponse>(entity);
        }

        public override async Task<OrderResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Order));

            return _mapper.Map<Order, GetOrderResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Order));

            _repository.Delete(entity);
            _repository.SaveChanges();
            return true;
        }

        public override async Task<OrderResponse> Update(OrderRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Order));

            var updateOrderRequest = request as UpdateOrderRequest;

            var result = _mapper.Map(updateOrderRequest, entity);

            _repository.Update(entity);
            await _repository.SaveChangesAsync(CancellationToken.None);
            return _mapper.Map<Order, UpdateOrderResponse>(result);
        }

        public async Task<OrderFromCartResponse> CreateOrder(OrderFromCartRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, nameof(OrderFromCartRequest));

            var cart = _repositoryCart.Set().FirstOrDefault(u => u.CurrentUserId == request.UserId);

            if (cart == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Cart));

            var order = new Order()
            {
                ShipAddress = request.ShipAddress,
                AvailableTo = request.ShipAddress,
                ShipDate = request.ShipDate,
                Customer = cart.Person, //TODO: Rename to Customer
                OrderStatus = Domain.Enam.OrderStatus.Active
            };
            MoveItemsFromCartToOrder(order, cart);
            await _repository.AddAsync(order, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Order, OrderFromCartResponse>(order); ;
        }

        public bool DeleteCartItem(ulong Id, CancellationToken cancellationToken)
        {
            var entity = _repositoryCart.Find(Id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(CartItem));

            _repositoryCart.Delete(entity);
            _repositoryCart.SaveChanges();
            return true;
        }

        public void MoveItemsFromCartToOrder(Order order, Cart cart)
        {
            foreach (var cartItems in cart.CardItems)
            {
                order.OrderDetails.Add(new OrderDetails
                {
                    ProductId = cartItems.ProductId,
                    Quantity = cartItems.Quantity,
                    UnitPrice = cartItems.UnitPrice,
                    OrderId = order.Id
                });
            }
        }
    }
}
