using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Response.CartRespons;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Tests.Services.CartService
{
    public class GetCartServiceTests
    {
        private readonly Mock<IRepository<Cart>> _repository;
        private readonly Mock<IMapper> _mapper;

        public GetCartServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepository<Cart>>();
        }

        [Test]
        public async Task GetById_Cart_Tests()
        {
            ulong cartId = 5;
            var cart = new Cart() { CustomerId = 10 };
            var cartResponse = new GetCartResponse() { CustomerId = 10 };

            _repository.Setup(c => c.FindAsync(cartId, CancellationToken.None)).ReturnsAsync(cart);
            _mapper.Setup(m => m.Map<Cart, CartResponse>(cart)).Returns(cartResponse);

            var service = new Application.Services.CartService(_repository.Object, _mapper.Object);
            var entity = await service.Get(cartId, CancellationToken.None);

            _repository.Verify(c => c.FindAsync(cartId, CancellationToken.None));
            var result = entity as GetCartResponse;
            Assert.That(10, Is.EqualTo(result.CustomerId));
        }
        [Test]
        public async Task GetById_Cart_Should_have_error_when_CartId_is_null()
        {
            ulong cartId = 5;
            _repository.Setup(d => d.FindAsync(cartId, CancellationToken.None)).Returns(Task.FromResult<Cart>(null));
            var service = new Application.Services.CartService(_repository.Object, _mapper.Object);

            Assert.ThrowsAsync<HttpStatusCodeException>(async () => await service.Get(cartId, CancellationToken.None));
            _repository.Verify(d => d.FindAsync(cartId, CancellationToken.None));
        }

        [Test]
        public async Task GetById_Cart_Should_have_error_when_CartId_is_empty()
        {
            ulong cartId = 5;
            _repository.Setup(d => d.FindAsync(cartId, CancellationToken.None));
            var service = new Application.Services.CartService(_repository.Object, _mapper.Object);

            Assert.ThrowsAsync<HttpStatusCodeException>(async () => await service.Get(cartId, CancellationToken.None));
            _repository.Verify(d => d.FindAsync(cartId, CancellationToken.None));
        }
        [Test]
        public async Task GetById_Cart_Should_have_error_when_CartId_is_true()
        {
            ulong cartId = 5;
            _repository.Setup(d => d.FindAsync(cartId, CancellationToken.None));
            var service = new Application.Services.CartService(_repository.Object, _mapper.Object);

            Assert.ThrowsAsync<HttpStatusCodeException>(async () => await service.Get(cartId, CancellationToken.None));
            _repository.Verify(d => d.FindAsync(cartId, CancellationToken.None));
        }
    }
}
