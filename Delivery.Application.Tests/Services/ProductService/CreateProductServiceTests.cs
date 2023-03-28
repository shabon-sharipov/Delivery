using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Requests.ProductsRequest;
using Delivery.Application.Response.ProductResponse;
using Delivery.Application.Services;
using Delivery.Application.Validations.ProductValidations;
using Delivery.Domain.Model;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;

namespace Delivery.Application.Tests.Services.ProductService
{
    public class CreateProductServiceTests
    {
        private readonly Mock<IRepository<Product>> _repository;
        private readonly Mock<IMapper> _mapper;

        private CreateProductValidation _validator;

        public CreateProductServiceTests()
        {
            _repository = new Mock<IRepository<Product>>();
            _mapper = new Mock<IMapper>();
            _validator = new CreateProductValidation();
        }

        [Test]
        public async Task Create_Product_Test()
        {
            var productRequest = new CreateProductRequest() { Name = "Soup", Price = 20, CategoryId = 2, Discription = "1234512345123451234512345" };
            var product = new Product() { Name = "Soup", Price = 20, CategoryId = 2, Discription = "1234512345123451234512345" };
            var productResponse = new CreateProductResponse() { Name = "Soup", Price = 20, CategoryId = 2, Discription = "1234512345123451234512345" };

            _mapper.Setup(m => m.Map<CreateProductRequest, Product>(productRequest))
                .Returns(product);

            _mapper.Setup(m => m.Map<Product, ProductResponse>(product))
                .Returns(productResponse);

            var service = new ProductServices(_repository.Object, _mapper.Object);
            var result = await service.Create(productRequest, CancellationToken.None);

            _repository.Verify(r => r.AddAsync(It.IsAny<Product>(), CancellationToken.None));
            _repository.Verify(r => r.SaveChangesAsync(CancellationToken.None));

            var test = result as CreateProductResponse;

            Assert.That(test.Price, Is.EqualTo(product.Price));
        }

        [Test]
        public void Should_have_error_when_Product_Name_is_empty()
        {
            var product = new CreateProductRequest() { Name = "" };
            var result = _validator.TestValidate(product);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Test]
        public void Should_have_error_when_Product_Name_is_null()
        {
            var product = new CreateProductRequest() { Name = null };
            var result = _validator.TestValidate(product);
            result.ShouldHaveValidationErrorFor(p => p.Name);
        }

        [Test]
        public void Should_have_error_when_Product_Discroption_small_twenty()
        {
            var product = new CreateProductRequest() { Discription = "!234567891234567890" };
            var result = _validator.TestValidate(product);
            result.ShouldHaveValidationErrorFor(p => p.Discription);
        }

        [Test]
        public void Should_have_error_when_Product_Price_zero()
        {
            var product = new CreateProductRequest() { Price = 0 };
            var result = _validator.TestValidate(product);
            result.ShouldHaveValidationErrorFor(p => p.Price);
        }

    }
}
