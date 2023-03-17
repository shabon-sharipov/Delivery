using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.CategoryCustomerRequest;
using Delivery.Application.Respons.CategoryCustomerResponse;
using Delivery.Domain.Model;
using Delivery.Application.Common.Interfaces.Repositories;
using AutoMapper;

namespace Delivery.Application.Services
{
    public class CategoryCustomerService : BaseService<CategoryCustomer, CategoryCustomerResponse, CreateCategoryCustomerRequest>, ICategoryCustomerService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryCustomerService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async override Task<CategoryCustomerResponse> Create(CreateCategoryCustomerRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException(nameof(CategoryCustomer));

            var entity = _mapper.Map<CreateCategoryCustomerRequest, CategoryCustomer>(request);
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

        public async override Task<CategoryCustomerResponse> Update(CreateCategoryCustomerRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new NullReferenceException(nameof(CategoryCustomer));

            var result = _mapper.Map<CreateCategoryCustomerRequest, CategoryCustomerResponse>(request);

            _repository.Update(entity);
            await _repository.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
