using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Services;
using Delivery.Domain.Model;
using Moq;
using NUnit.Framework;

namespace Delivery.Application.Tests.Services.ProductService
{
    public class GetByIdProductServiceTests
    {
        private readonly Mock<IRepository<Product>> _repository;

        public GetByIdProductServiceTests()
        {
            _repository = new Mock<IRepository<Product>>();
        }

        [Test]
        public async Task GetById_Product_Tests()
        {
            ulong productId = 1;
            _repository.Setup(p => p.FindAsync(productId, CancellationToken.None)).ReturnsAsync(new Product() { Name = "Soup", Category = "1" });

            var service = new ProductServices(_repository.Object);
            var result = await service.Get(productId, CancellationToken.None);

            _repository.Verify(p => p.FindAsync(productId, CancellationToken.None));

            Assert.That("Soup", Is.EqualTo(result.Name));
        }

        [Test]
        public async Task GetById_Product_Should_have_error_when_ProductId_is_null()
        {
            ulong productId = 1;
            _repository.Setup(p => p.FindAsync(productId, CancellationToken.None)).Returns(Task.FromResult<Product>(null));

            var service = new ProductServices(_repository.Object);

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.Get(productId, CancellationToken.None));
            _repository.Verify(p => p.FindAsync(productId, CancellationToken.None));
        }
    }
}
