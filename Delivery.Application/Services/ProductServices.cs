using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Requests.ProductsRequest;
using Delivery.Application.Respons.ProductRespons;
using Delivery.Domain.Model;
namespace Delivery.Application.Services
{
    public class ProductServices : BaseService<Product, ProductResponse, ProductRequest>, IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductServices(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<ProductResponse> Create(ProductRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException(nameof(Product));

            var createProductRequset = request as CreateProductRequest;
            Product entity = _mapper.Map<CreateProductRequest, Product>(createProductRequset);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Product, CreateProductResponse>(entity); 
        }

        public async override Task<IEnumerable<ProductResponse>> GetAll(int PageSize, int PageNumber, CancellationToken cancellationToken)
        {
            var products = _repository.GetAll(PageSize, PageNumber, cancellationToken);

            return _mapper.Map<IEnumerable<ProductPaggedListItemResponse>>(products);
        }

        public async override Task<ProductResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            Product entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            return _mapper.Map<Product, GetProductResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            _repository.Delete(entity);
            _repository.SaveChanges();
            return true;
        }

        public async override Task<ProductResponse> Update(ProductRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            var updateProductRequset = request as UpdateProductRequest;
            _mapper.Map<UpdateProductRequest, Product>(updateProductRequset, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<Product, UpdateProductResponse>(entity);
        }
    }
}