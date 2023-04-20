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
        private readonly Mock<IRepository<OrderDetails>> _repositoryOrderDetails;
        private readonly Mock<IRepository<Cart>> _repositoryCart;
        private readonly Mock<IRepository<CartItem>> _cartItemRepository;
        private readonly Mock<IRepository<Merchant>> _merchantRepositoryMock;

        public UpdateOrderServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepository<Order>>();
            _repositoryOrderDetails = new Mock<IRepository<OrderDetails>>();
            _repositoryCart = new Mock<IRepository<Cart>>();
            _cartItemRepository=new Mock<IRepository<CartItem>>();
            _merchantRepositoryMock=new Mock<IRepository<Merchant>>();
        }

        [Test]
        public async Task Update_Order_Test()
        {
            ulong orderId = 2;
            var order = new Order { OrderStatus = OrderStatus.Open, ShipAddress = "Unvermag" };
            var orderRequest = new UpdateOrderRequest { OrderStatus = OrderStatus.Open };
            var orderResponse = new UpdateOrderResponse { OrderStatus = OrderStatus.Open, ShipAddress="Panjshanbe" };

            _repository.Setup(p => p.FindAsync(orderId, CancellationToken.None)).ReturnsAsync(order);

            _mapper.Setup(m => m.Map<UpdateOrderRequest, Order>(orderRequest,order)).Returns(order);
            _mapper.Setup(m => m.Map<Order, UpdateOrderResponse>(order)).Returns(orderResponse);

            var service = new Application.Services.OrderService(_repository.Object, _repositoryOrderDetails.Object, _mapper.Object, _repositoryCart.Object, _cartItemRepository.Object, _merchantRepositoryMock.Object);

            var entity = await service.Update(orderRequest, orderId, CancellationToken.None);

            _repository.Verify(m => m.FindAsync(orderId, CancellationToken.None));
            _repository.Verify(m => m.Update(It.IsAny<Order>()));
            _repository.Verify(m => m.SaveChangesAsync(CancellationToken.None));

            var result = entity as UpdateOrderResponse;

            Assert.That("Panjshanbe", Is.EqualTo(result.ShipAddress));
        }

        [Test]
        public async Task Update_Order_Should_have_error_when_OrderId_is_null()
        {
            ulong orderId = 2;
            var order = new CreateOrderRequest() { OrderStatus= OrderStatus.Cancel };
            _repository.Setup(o => o.FindAsync(orderId, CancellationToken.None)).Returns(Task.FromResult<Order>(null));

            var service = new Application.Services.OrderService(_repository.Object, _repositoryOrderDetails.Object, _mapper.Object, _repositoryCart.Object, _cartItemRepository.Object, _merchantRepositoryMock.Object);

            _repository.Verify(x => x.FindAsync(orderId, CancellationToken.None));

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.Update(order, orderId, CancellationToken.None));
        }
    }
}
