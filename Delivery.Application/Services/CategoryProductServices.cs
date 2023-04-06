using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.CategoryProductRequest;
using Delivery.Application.Response.CategoryProductResponse;
using Delivery.Domain.Abstract;
using Delivery.Domain.Model;

namespace Delivery.Application.Services
{
    public class CategoryProductServices : BaseService<ProductCategory, ProductCategoryResponse, CategoryProductRequest>, ICategoryProductServices
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryProductServices(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async override Task<ProductCategoryResponse> Create(CategoryProductRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(ProductCategory));

            var createCategoryProductRequest = request as CreateCategoryProductRequest;
            var entity = _mapper.Map<CreateCategoryProductRequest, ProductCategory>(createCategoryProductRequest);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductCategory, ProductCategoryResponse>(entity);
        }

        public async override Task<ProductCategoryResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(ProductCategory));;

            return _mapper.Map<Category, ProductCategoryResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Product));;

            _repository.Delete(entity);
            _repository.SaveChanges();
            return true;
        }

        public async override Task<ProductCategoryResponse> Update(CategoryProductRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Product));;

            var categoryUpdateRequest = request as UpdateCategoryProductRequest;
            var result = _mapper.Map(categoryUpdateRequest, entity);

            _repository.Update(result);
            await _repository.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<Category, ProductCategoryResponse>(result);
        }
    }
}
