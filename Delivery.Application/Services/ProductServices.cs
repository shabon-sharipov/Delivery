using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Requests.PaggedList;
using Delivery.Application.Requests.ProductsRequest;
using Delivery.Application.Respons.ProductRespons;
using Delivery.Domain.Model;
namespace Delivery.Application.Services
{
    public class ProductServices : BaseService<Product, ProductResponse, UpdateProductRequest>, IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductServices(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<ProductResponse> Create(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException(nameof(Product));

            var entity = _mapper.Map<UpdateProductRequest, Product>(request);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductResponse>(entity);
        }

        public override Task<IEnumerable<ProductResponse>> GetAll(int PageSize, int PageNumber, CancellationToken cancellationToken)
        {
            //var products = _repository.GetAll(PageSize, PageNumber, cancellationToken);

            // _mapper.Map<List<PaggedListItemResponse>>(products);
            // _mapper.Map<List<PaggedListItemResponse>>(products);
            return null;
        }

        public async override Task<ProductResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            return _mapper.Map<Product, ProductResponse>(entity);
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

        public async override Task<ProductResponse> Update(UpdateProductRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            _mapper.Map(request, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<Product, ProductResponse>(entity);
        }
    }
}