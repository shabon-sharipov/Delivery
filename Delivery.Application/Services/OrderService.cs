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
        private readonly IRepository<OrderDetails> _repositoryOrderDetails;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> repository, IRepository<OrderDetails> repositoryOrderDetails, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryOrderDetails = repositoryOrderDetails;
        }

        public async Task<IEnumerable<OrderResponse>> GetAll(int PageSize, int PageNumber, CancellationToken cancellationToken)
        {
            var products = _repository.GetAll(PageSize, PageNumber, cancellationToken);
            return _mapper.Map<IEnumerable<PaggedOrderListItemResponse>>(products);
        }

        public override async Task<OrderResponse> Create(OrderRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Order));

            var createOrderRequest = request as CreateOrderRequest;
            var entity = _mapper.Map<CreateOrderRequest, Order>(createOrderRequest);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Order, CreateOrderResponse>(entity);
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

        public async Task<OrderDetails> CreateOrderDitels(OrderDetails orderDetails, CancellationToken cancellationToken)
        {
            await _repositoryOrderDetails.AddAsync(orderDetails, cancellationToken);
            await _repositoryOrderDetails.SaveChangesAsync(cancellationToken);
            return orderDetails;
        }

        public async Task<bool> DeleteOrderDitels(ulong Id, CancellationToken cancellationToken)
        {
            var entit = await _repositoryOrderDetails.FindAsync(Id, CancellationToken.None);
            if (entit == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(OrderDetails));

            _repositoryOrderDetails.Delete(entit);
            await _repositoryOrderDetails.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
