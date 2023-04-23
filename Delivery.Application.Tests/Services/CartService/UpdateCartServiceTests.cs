using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Response.CartResponse;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Tests.Services.CartService
{
    public class UpdateCartServiceTests
    {
        private readonly Mock<IRepository<Cart>> _repository;
        private readonly Mock<IMapper> _mapper;

        public UpdateCartServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepository<Cart>>();
        }

        [Test]
        public async Task Update_Cart_Tests()
        {
            ulong customerId = 5;
            var cart = new Cart() { CustomerId = 11 };
            var cartRequest = new UpdateCartRequest() {CustomerId = 11 };
            var cartResponse = new UpdateCartResponse() { CustomerId = 11 };

            _repository.Setup(p => p.FindAsync(customerId, CancellationToken.None)).ReturnsAsync(cart);

            _mapper.Setup(m => m.Map<UpdateCartRequest, Cart>(cartRequest, cart)).Returns(cart);
            _mapper.Setup(m => m.Map<Cart, UpdateCartResponse>(cart)).Returns(cartResponse);

            var service = new Application.Services.CartService(_repository.Object, _mapper.Object);
            var entity = await service.Update(cartRequest, customerId, CancellationToken.None);

            _repository.Verify(m => m.FindAsync(customerId, CancellationToken.None));
            _repository.Verify(m => m.Update(It.IsAny<Cart>()));
            _repository.Verify(m => m.SaveChangesAsync(CancellationToken.None));

            var result = entity as UpdateCartResponse;

            Assert.That(cartResponse.CustomerId, Is.EqualTo(result.CustomerId));
        }
        [Test]
        public async Task Update_Cart_Should_have_error_when_CartId_is_empty()
        {
            ulong cartId = 10;
            var cart = new UpdateCartRequest() { CustomerId = 11};
            _repository.Setup(d => d.FindAsync(cartId, CancellationToken.None));

            var service = new Application.Services.CartService(_repository.Object, _mapper.Object);
            Assert.ThrowsAsync<HttpStatusCodeException>(async () => await service.Update(cart, cartId, CancellationToken.None));
            _repository.Verify(d => d.FindAsync(cartId, CancellationToken.None));
        }
        [Test]
        public async Task Update_Cart_Should_have_error_when_CartId_is_null()
        {
            ulong cartId = 10;
            var cart = new UpdateCartRequest() { CustomerId = 11 };
            _repository.Setup(d => d.FindAsync(cartId, CancellationToken.None)).Returns(Task.FromResult<Cart>(null));

            var service = new Application.Services.CartService(_repository.Object, _mapper.Object);
            Assert.ThrowsAsync<HttpStatusCodeException>(async () => await service.Update(cart, cartId, CancellationToken.None));
            _repository.Verify(d => d.FindAsync(cartId, CancellationToken.None));
        }
    }
}
