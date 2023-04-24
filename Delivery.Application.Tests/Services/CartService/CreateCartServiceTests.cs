using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Validations.CartValidations;
using Delivery.Application.Validations.SenderValidations;
using Delivery.Domain.Model;
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
        private readonly Mock<IRepository<CartItem>> _repositoryCartItem;
        private readonly Mock<IRepository<Product>> _repositoryProductMock;
       
       
        private CreateCartRequestValidation _validator;

        public CreateCartServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepository<Cart>>();
            _repositoryCartItem = new Mock<IRepository<CartItem>>();
            _repositoryProductMock = new Mock<IRepository<Product>>();
           
           
            _validator = new CreateCartRequestValidation();
        }

        [Test]
        public async Task Create_Cart_Tests()
        {
            var cartRequest = new CreateCartRequest() { CustomerId = 10 };
            var cart = new Cart() { CustomerId = 10 };
            var cartResponse = new CreateCartResponse() { CustomerId = 10 };

            _mapper.Setup(c => c.Map<CreateCartRequest, Cart>(cartRequest)).Returns(cart);
            _mapper.Setup(c => c.Map<Cart, CreateCartResponse>(cart)).Returns(cartResponse);

            var service = new Application.Services.CartService(_repository.Object, _mapper.Object,
                _repositoryCartItem.Object, _repositoryProductMock.Object);
            
            var result = await service.Create(cartRequest, CancellationToken.None);

            _repository.Verify(c => c.AddAsync(It.IsAny<Cart>(), CancellationToken.None));
            _repository.Verify(c => c.SaveChangesAsync(CancellationToken.None));

            var entity = result as CreateCartResponse;
            Assert.That(entity.CustomerId, Is.EqualTo(cart.CustomerId));
        }

        
    }
}
