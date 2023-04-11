using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.OrderRequest;
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
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderResponse>> GetAll(int PageSize, int PageNumber, CancellationToken cancellationToken)
        {
            var products = _repository.GetAll(PageSize, PageNumber, cancellationToken);
            return _mapper.Map<IEnumerable<PaggedOrderListItemResponse>>(products);
        }

        public async override Task<OrderResponse> Create(OrderRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Order));

            var createOrderRequest = request as CreateOrderRequest;
            var entity = _mapper.Map<CreateOrderRequest, Order>(createOrderRequest);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Order, CreateOrderResponse>(entity);
        }

        public async override Task<OrderResponse> Get(ulong id, CancellationToken cancellationToken)
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

        public async override Task<OrderResponse> Update(OrderRequest request, ulong id, CancellationToken cancellationToken)
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
    }
}
