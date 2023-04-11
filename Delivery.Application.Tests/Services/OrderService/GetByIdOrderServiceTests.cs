using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Response.OrderResponse;
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
    public class GetByIdOrderServiceTests
    {
        private readonly Mock<IRepository<Order>> _repository;
        private readonly Mock<IMapper> _mapper;

        public GetByIdOrderServiceTests()
        {
            _repository = new Mock<IRepository<Order>>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task GetById_Order_Tests()
        {
            ulong orderId = 2;
            var order = new Order() { AvailableTo = "Ulitsa A.Samadov, Dom 24", DriverId = 4,};
            var orderResponse = new CreateOrderResponse() { AvailableTo = "Ulitsa A.Samadov, Dom 24", DriverId = 4, };

            _repository.Setup(o => o.FindAsync(orderId, CancellationToken.None)).ReturnsAsync(order);
            _mapper.Setup(m => m.Map<Order, OrderResponse>(order)).Returns(orderResponse);

            var service = new Application.Services.OrderService(_repository.Object, _mapper.Object);
            var entity = await service.Get(orderId, CancellationToken.None);

            _repository.Verify(o => o.FindAsync(orderId, CancellationToken.None));

            var result = entity as GetOrderResponse;

            Assert.That("Ulitsa A.Samadov, Dom 24", Is.EqualTo(result.AvailableTo));
        }
    }
}
