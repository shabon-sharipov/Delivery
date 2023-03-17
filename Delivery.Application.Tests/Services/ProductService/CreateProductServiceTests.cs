using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Services;
using Delivery.Domain.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Tests.Services
{
    public class CreateProductServiceTests
    {
        private readonly Mock<IRepository<Product>> _repository;

        public CreateProductServiceTests()
        {
            _repository = new Mock<IRepository<Product>>();
        }

        [Test]
        public async Task Create_Product_Test()
        {
            //var product = new Product() { Id = 1, Name = "Soup", Price = 20 };
            //var service = new ProductServices(_repository.Object);
            //var result = await service.Create(product,CancellationToken.None);

            //_repository.Verify(r => r.AddAsync(It.IsAny<Product>(), CancellationToken.None));
            //_repository.Verify(r => r.SaveChangesAsync(CancellationToken.None));

            //Assert.That(result.Id, Is.EqualTo(product.Id));
        }

        //[Test]
        //public async Task Create_Product_Should_have_error_when_Product_is_null()
        //{
        //Fluit Validation
        //}
    }
}
