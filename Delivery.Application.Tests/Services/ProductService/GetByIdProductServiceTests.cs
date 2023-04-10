using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Response.ProductResponse;
using Delivery.Application.Services;
using Delivery.Domain.Model;
using Moq;
using NUnit.Framework;

namespace Delivery.Application.Tests.Services.ProductService
{
    public class GetByIdProductServiceTests
    {
        private readonly Mock<IRepository<Product>> _repository;
        private readonly Mock<IMapper> _mapper;


        public GetByIdProductServiceTests()
        {
            _repository = new Mock<IRepository<Product>>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task GetById_Product_Tests()
        {
            ulong productId = 1;
            var product = new Product() { Name = "Soup", CategoryId = 1 };
            var productResponse = new GetProductResponse() { Name = "Soup", CategoryId = 1 };

            _repository.Setup(p => p.FindAsync(productId, CancellationToken.None)).ReturnsAsync(product);

            _mapper.Setup(m => m.Map<Product, ProductResponse>(product)).Returns(productResponse);

            var service = new ProductServices(_repository.Object, _mapper.Object);
            var entity = await service.Get(productId, CancellationToken.None);

            _repository.Verify(p => p.FindAsync(productId, CancellationToken.None));

            var result = entity as GetProductResponse;

            Assert.That("Soup", Is.EqualTo(result.Name));
        }

        [Test]
        public async Task GetById_Product_Should_have_error_when_ProductId_is_null()
        {
            ulong productId = 1;
            _repository.Setup(p => p.FindAsync(productId, CancellationToken.None)).Returns(Task.FromResult<Product>(null));

            var service = new ProductServices(_repository.Object, _mapper.Object);

            Assert.ThrowsAsync<HttpStatusCodeException>(async () => await service.Get(productId, CancellationToken.None));
            _repository.Verify(p => p.FindAsync(productId, CancellationToken.None));
        }
    }
}
