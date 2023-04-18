using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
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
        private readonly Mock<IRepository<OrderDetails>> _repositoryOrderDetails;
        private readonly Mock<IRepository<Cart>> _repositoryCart;
        private readonly Mock<IRepository<CartItem>> _cartItemRepositoryMock;
        public GetByIdOrderServiceTests()
        {
            _repository = new Mock<IRepository<Order>>();
            _mapper = new Mock<IMapper>();
            _repositoryOrderDetails = new Mock<IRepository<OrderDetails>>();
            _repositoryCart = new Mock<IRepository<Cart>>();
            _cartItemRepositoryMock = new Mock<IRepository<CartItem>>();
        }

        [Test]
        public async Task GetById_Order_Tests()
        {
            ulong orderId = 2;
            var order = new Order() { DriverId = 4, };
            var orderResponse = new GetOrderResponse() { AvailableTo = "Ulitsa A.Samadov, Dom 24", DriverId = 4, };

            _repository.Setup(o => o.FindAsync(orderId, CancellationToken.None)).ReturnsAsync(order);
            _mapper.Setup(m => m.Map<Order, GetOrderResponse>(order)).Returns(orderResponse);

            var service = new Application.Services.OrderService(_repository.Object, _repositoryOrderDetails.Object, _mapper.Object, _repositoryCart.Object, _cartItemRepositoryMock.Object);
            var entity = await service.Get(orderId, CancellationToken.None);

            _repository.Verify(o => o.FindAsync(orderId, CancellationToken.None));

            var result = entity as GetOrderResponse;

            Assert.That("Ulitsa A.Samadov, Dom 24", Is.EqualTo(result.AvailableTo));
        }
        
        [Test]
        public async Task GetById_Order_should_have_error_when_OrderId_is_null()
        {
            ulong orderId = 2;
            _repository.Setup(x=>x.FindAsync(orderId, CancellationToken.None)).Returns(Task.FromResult<Order>(null));

            var service = new Application.Services.OrderService(_repository.Object, _repositoryOrderDetails.Object, _mapper.Object, _repositoryCart.Object, _cartItemRepositoryMock.Object);
            Assert.ThrowsAsync<HttpStatusCodeException>(async()=>await service.Get(orderId, CancellationToken.None));
            _repository.Verify(x=>x.FindAsync(orderId, CancellationToken.None));
        }
    }
}
