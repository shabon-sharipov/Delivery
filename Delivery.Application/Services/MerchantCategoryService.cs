using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.CategoryCustomerRequest;
using Delivery.Domain.Model;
using Delivery.Application.Common.Interfaces.Repositories;
using AutoMapper;
using Delivery.Application.Response.CategoryCustomerResponse;
using Delivery.Domain.Abstract;
using Delivery.Application.Exceptions;

namespace Delivery.Application.Services
{
    public class MerchantCategoryService : BaseService<MerchantCategory, MerchantCategoryResponse, MerchantCategoryRequest>, IMerchantCategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public MerchantCategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async override Task<MerchantCategoryResponse> Create(MerchantCategoryRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(MerchantCategory));

            var createCategoryCustomerRequest = request as CreateMerchantCategoryRequest;
            var entity = _mapper.Map<CreateMerchantCategoryRequest, MerchantCategory>(createCategoryCustomerRequest);
            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Category, MerchantCategoryResponse>(entity);
        }

        public async override Task<MerchantCategoryResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(MerchantCategory));

            return _mapper.Map<Category, MerchantCategoryResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(MerchantCategory));

            _repository.Delete(entity);
            _repository.SaveChanges();
            return true;

        }

        public async override Task<MerchantCategoryResponse> Update(MerchantCategoryRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(MerchantCategory));

            var updateCategoryCustomerRequest = request as UpdateCustomeMerchantrRequest;

            var result = _mapper.Map(updateCategoryCustomerRequest, entity);

            _repository.Update(entity);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Category, MerchantCategoryResponse>(result);
        }
    }
}
