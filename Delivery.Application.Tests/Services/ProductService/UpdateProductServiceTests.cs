//using AutoMapper;
//using Delivery.Application.Common.Interfaces.Repositories;
//using Delivery.Application.Exceptions;
//using Delivery.Application.Requests.ProductsRequest;
//using Delivery.Application.Response.ProductResponse;
//using Delivery.Application.Services;
//using Delivery.Domain.Model;
//using Moq;
//using NUnit.Framework;

//namespace Delivery.Application.Tests.Services.ProductService
//{

//    public class UpdateProductServiceTests
//    {
//        private readonly Mock<IRepository<Product>> _repository;
//        private readonly Mock<IMapper> _mapper;

//        public UpdateProductServiceTests()
//        {
//            _repository = new Mock<IRepository<Product>>();
//            _mapper = new Mock<IMapper>();
//        }

//        [Test]
//        public async Task UpdateProduct_Test()
//        {
//            ulong productId = 1;
//            var product = new Product() { Name = "Soup" };

//            var productRequest = new UpdateProductRequest() { Name = "Pizza" };

//            var productResponse = new UpdateProductResponse() { Name = "Pizza" };

//            _repository.Setup(p => p.FindAsync(productId, CancellationToken.None)).ReturnsAsync(product);

//            _mapper.Setup(m => m.Map(productRequest, product));
//            _mapper.Setup(m => m.Map<Product, UpdateProductResponse>(product)).Returns(productResponse);


//            var servise = new ProductServices(_repository.Object, _mapper.Object);
//            var entity = await servise.Update(productRequest, productId, CancellationToken.None);

//            _repository.Verify(p => p.FindAsync(productId, CancellationToken.None));
//            _repository.Verify(p => p.Update(It.IsAny<Product>()));
//            _repository.Verify(p => p.SaveChangesAsync(CancellationToken.None));

//            var result = entity as UpdateProductResponse;

//            Assert.That(productResponse.Name, Is.EqualTo(result.Name));
//        }

//        [Test]
//        public async Task Update_Product_Should_have_error_when_ProductId_is_null()
//        {
//            ulong productId = 1;
//            var product = new CreateProductRequest() { Name = "Pizza" };
//            _repository.Setup(p => p.FindAsync(productId, CancellationToken.None)).Returns(Task.FromResult<Product>(null));

//            var service = new ProductServices(_repository.Object,_mapper.Object);

//            Assert.ThrowsAsync<HttpStatusCodeException>(async () => await service.Update(product, productId, CancellationToken.None));
//            _repository.Verify(p => p.FindAsync(productId, CancellationToken.None));
//        }
//    }
//}
