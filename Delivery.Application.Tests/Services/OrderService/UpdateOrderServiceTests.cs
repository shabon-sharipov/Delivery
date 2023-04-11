using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Response.OrderResponse;
using Delivery.Domain.Enam;
using Delivery.Domain.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Tests.Services.OrderService
{
    public class UpdateOrderServiceTests
    {
        private readonly Mock<IRepository<Order>> _repository;
        private readonly Mock<IMapper> _mapper;

        public UpdateOrderServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepository<Order>>();
        }

        [Test]
        public async Task Update_Order_Test()
        {
            ulong orderId = 2;
            var order = new Order { OrderStatus = OrderStatus.Open };
            var orderRequest = new UpdateOrderRequest { OrderStatus = OrderStatus.Open };
            var orderResponse = new UpdateOrderResponse { OrderStatus = OrderStatus.Open };

            _repository.Setup(p => p.FindAsync(orderId, CancellationToken.None));

            _mapper.Setup(m => m.Map<UpdateOrderRequest, Order>(orderRequest)).Returns(order);
            _mapper.Setup(m=>m.Map<Order, UpdateOrderResponse>(order)).Returns(orderResponse);

            var service = new Application.Services.OrderService(_repository.Object, _mapper.Object);
            var entity = await service.Update(orderRequest, orderId, CancellationToken.None);

            _repository.Verify(m => m.FindAsync(orderId, CancellationToken.None));
            _repository.Verify(m=>m.Update(It.IsAny<Order>()));
            _repository.Verify(m => m.SaveChangesAsync(CancellationToken.None));

            var result = entity as UpdateOrderResponse;

            Assert.That(orderResponse.AvailableFrom, Is.EqualTo(result.AvailableFrom));
        }

        [Test]
        public async Task Update_Order_Should_have_error_when_OrderId_is_null()
        {
            ulong orderId = 1;
            var order = new CreateOrderRequest() { PhoneNumber = "+99288415707" };
            _repository.Setup(o => o.FindAsync(orderId, CancellationToken.None)).Returns(Task.FromResult<Order>(null));

            var service = new Application.Services.OrderService(_repository.Object, _mapper.Object);
            Assert.ThrowsAsync<NullReferenceException>(async () => await service.Update(order, orderId, CancellationToken.None));

            _repository.Verify(o=>o.FindAsync(orderId, CancellationToken.None));
        }
    }
}
