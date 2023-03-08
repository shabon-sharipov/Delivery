using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Services;
using Delivery.Domain.Model;
using Moq;
using NUnit.Framework;

namespace Delivery.Application.Tests.Services.ProductService
{

    public class UpdateProductServiceTests
    {
        private readonly Mock<IRepository<Product>> _repository;

        public UpdateProductServiceTests()
        {
            _repository = new Mock<IRepository<Product>>();

        }

        [Test]
        public async Task UpdateProduct_Test()
        {
            ulong productId = 1;
            var product = new Product() { Name = "Pizza" };
            _repository.Setup(p => p.FindAsync(productId, CancellationToken.None)).ReturnsAsync(new Product() { Id = 1, Name = "Soup" });

            var servise = new ProductServices(_repository.Object);

            var result = await servise.Update(product, productId, CancellationToken.None);

            _repository.Verify(p => p.FindAsync(productId, CancellationToken.None));
            _repository.Verify(p => p.Update(It.IsAny<Product>()));
            _repository.Verify(p => p.SaveChangesAsync(CancellationToken.None));

            Assert.That(product.Name, Is.EqualTo(result.Name));
        }

        [Test]
        public async Task Update_Product_Should_have_error_when_ProductId_is_null()
        {
            ulong productId = 1;
            var product = new Product() { Name = "Pizza" };
            _repository.Setup(p => p.FindAsync(productId, CancellationToken.None)).Returns(Task.FromResult<Product>(null));

            var service = new ProductServices(_repository.Object);

            Assert.ThrowsAsync<NullReferenceException>(async () => await service.Update(product, productId, CancellationToken.None));
            _repository.Verify(p => p.FindAsync(productId, CancellationToken.None));
        }
    }
}
