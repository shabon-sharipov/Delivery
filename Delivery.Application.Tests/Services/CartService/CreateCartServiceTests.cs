using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Validations.CartValidations;
using Delivery.Application.Validations.SenderValidations;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Tests.Services.CartService
{
    public class CreateCartServiceTests
    {
        private readonly Mock<IRepository<Cart>> _repository;
        private readonly Mock<IMapper> _mapper;
        private CreateCartRequestValidation _validator;

        public CreateCartServiceTests()
        {
            _validator = new CreateCartRequestValidation();
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepository<Cart>>();
        }

        [Test]
        public async Task Create_Cart_Tests()
        {
            var cartRequest = new CreateCartRequest() { CustomerId = 10 };
            var cart = new Cart() { CustomerId = 10 };
            var cartResponse = new CreateCartResponse() { CustomerId = 10 };

            _mapper.Setup(c => c.Map<CreateCartRequest, Cart>(cartRequest)).Returns(cart);
            _mapper.Setup(c => c.Map<Cart, CreateCartResponse>(cart)).Returns(cartResponse);
            var service = new Application.Services.CartService(_repository.Object, _mapper.Object);
            
            var result = await service.Create(cartRequest, CancellationToken.None);

            _repository.Verify(c => c.AddAsync(It.IsAny<Cart>(), CancellationToken.None));
            _repository.Verify(c => c.SaveChangesAsync(CancellationToken.None));

            var entity = result as CreateCartResponse;
            Assert.That(entity.CustomerId, Is.EqualTo(cart.CustomerId));
        }

       
    }
}
