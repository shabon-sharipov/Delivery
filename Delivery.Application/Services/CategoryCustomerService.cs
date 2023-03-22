using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.CategoryCustomerRequest;
using Delivery.Application.Respons.CategoryCustomerResponse;
using Delivery.Domain.Model;
using Delivery.Application.Common.Interfaces.Repositories;
using AutoMapper;

namespace Delivery.Application.Services
{
    public class CategoryCustomerService : BaseService<CategoryCustomer, CategoryCustomerResponse, CategoryCustomerRequest>, ICategoryCustomerService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryCustomerService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async override Task<CategoryCustomerResponse> Create(CategoryCustomerRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException(nameof(CategoryCustomer));

            var createCategoryCustomerRequest = request as CreateCategoryCustomerRequest;
            var entity = _mapper.Map<CreateCategoryCustomerRequest, CategoryCustomer>(createCategoryCustomerRequest);
            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Category, CategoryCustomerResponse>(entity);
        }

        public async override Task<CategoryCustomerResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new NullReferenceException(nameof(CategoryCustomer));

            return _mapper.Map<Category, CategoryCustomerResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new NullReferenceException(nameof(CategoryCustomer));

            _repository.Delete(entity);
            _repository.SaveChanges();
            return true;

        }

        public async override Task<CategoryCustomerResponse> Update(CategoryCustomerRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new NullReferenceException(nameof(CategoryCustomer));

            var updateCategoryCustomerRequest = request as UpdateCategoryCustomerRequest;

            var result = _mapper.Map(updateCategoryCustomerRequest, entity);

            _repository.Update(entity);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Category, CategoryCustomerResponse>(result);
        }
    }
}
