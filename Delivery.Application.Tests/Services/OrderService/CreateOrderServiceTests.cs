using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Response.OrderResponse;
using Delivery.Application.Validations.OrderValidations;
using Delivery.Domain.Model;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Tests.Services.OrderService
{
    public class CreateOrderServiceTests
    {
        private readonly Mock<IRepository<Order>> _repository;
        private readonly Mock<IRepository<OrderDetails>> _repositoryOrderDetails;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IRepository<Cart>> _repositoryCart;
        private CreateOrderRequestValidation _validator;

        public CreateOrderServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepository<Order>>();
            _repositoryOrderDetails = new Mock<IRepository<OrderDetails>>();
            _repositoryCart = new Mock<IRepository<Cart>>();
            _validator = new CreateOrderRequestValidation();
        }

        [Test]
        public async Task Create_Order_Test()
        {
            var orderRequest = new CreateOrderRequest()
            {
                AvailableTo = "Ulitsa A.Samadov, Dom 24",
                DriverId = 2
            };

            var order = new Order()
            {
                AvailableTo = "Ulitsa A.Samadov, Dom 24",
                DriverId = 2
            };

            var orderResponse = new CreateOrderResponse()
            {
                AvailableTo = "Ulitsa A.Samadov, Dom 24",
                DriverId = 2
            };

            _mapper.Setup(o => o.Map<CreateOrderRequest, Order>(orderRequest)).Returns(order);
            _mapper.Setup(o => o.Map<Order, CreateOrderResponse>(order)).Returns(orderResponse);

            var service = new Application.Services.OrderService(_repository.Object, _repositoryOrderDetails.Object, _mapper.Object, _repositoryCart.Object);
            var result = await service.Create(orderRequest, CancellationToken.None);

            _repository.Verify(a => a.AddAsync(It.IsAny<Order>(), CancellationToken.None));
            _repository.Verify(a => a.SaveChangesAsync(CancellationToken.None));

            var test = result as CreateOrderResponse;
            Assert.That(test.DriverId, Is.EqualTo(order.DriverId));


        }
        [Test]
        public void Should_have_error_when_Order_ShipAddress_is_empty()
        {
            var order = new CreateOrderRequest() { ShipAddress = " " };
            var result = _validator.TestValidate(order);
            result.ShouldHaveValidationErrorFor(o => o.ShipAddress);
        }
        [Test]
        public void Should_have_error_when_Order_ShipAddress_is_null()
        {
            var order = new CreateOrderRequest() { ShipAddress = null };
            var result = _validator.TestValidate(order);
            result.ShouldHaveValidationErrorFor(o => o.ShipAddress);
        }
    }
}
