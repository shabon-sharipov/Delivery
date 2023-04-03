using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Response.OrderResponse;
using Delivery.Application.Validations.OrderValidations;
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
    public class CreateOrderServiceTests
    {
        private readonly Mock<IRepository<Order>> _repository;
        private readonly Mock<IMapper> _mapper;
        private CreateOrderRequestValidation _validation;

        public CreateOrderServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepository<Order>>();
            _validation = new CreateOrderRequestValidation();
        }

        [Test]
        public async Task Create_Order_Test()
        {
            var orderRequest = new CreateOrderRequest()
            {
                AvailableFrom = "Restourant Forel",
                AvailableTo = "Ulitsa A.Samadov, Dom 24",
                PhoneNumber = "+992111442277",
                TotalPrice = 54,
                SenderId = 2
            };

            var order = new Order()
            {
                AvailableFrom = "Restourant Forel",
                AvailableTo = "Ulitsa A.Samadov, Dom 24",
                PhoneNumber = "+992111442277",
                TotalPrice = 54,
                SenderId = 2
            };

            var orderResponse = new CreateOrderResponse()
            {
                AvailableFrom = "Restourant Forel",
                AvailableTo = "Ulitsa A.Samadov, Dom 24",
                PhoneNumber = "+992111442277",
                TotalPrice = 54,
                SenderId = 2
            };

            _mapper.Setup(o => o.Map<CreateOrderRequest, Order>(orderRequest)).Returns(order);
            _mapper.Setup(o => o.Map<Order, CreateOrderResponse>(order)).Returns(orderResponse);

            var service = new OrderService(_repository.Object,_mapper.Object);
            var result = await service.Create(orderRequest, CancellationToken.None);

            _repository.Verify(a => a.AddAsync(It.IsAny<Order>(), CancellationToken.None));
            _repository.Verify(a => a.SaveChangesAsync(CancellationToken.None));

            var test = result as CreateOrderResponse;
            Assert.That(test.TotalPrice, Is.EqualTo(order.TotalPrice));


        }
        

    }
}
