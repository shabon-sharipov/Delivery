using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Requests.CategoryProductRequest;
using Delivery.Application.Respons.CategoryProductResponse;
using Delivery.Application.Respons.ProductRespons;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Services
{
    public class CategoryProductServices : BaseService<CategoryProduct, CategoryProductResponse, CreateCategoryProductRequest>, ICategoryProductServices
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryProductServices(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async override Task<CategoryProductResponse> Create(CreateCategoryProductRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException(nameof(CategoryProduct));

            var entity = _mapper.Map<CreateCategoryProductRequest, CategoryProduct>(request);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CategoryProduct, CategoryProductResponse>(entity);
        }

        public async override Task<CategoryProductResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new NullReferenceException(nameof(CategoryProduct));

            return _mapper.Map<Category, CategoryProductResponse>(entity);
        }

        public  override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            _repository.Delete(entity);
            _repository.SaveChanges();
            return true;
        }

        //public async override Task<CategoryProductResponse> Update(CreateCategoryProductRequest request, ulong id, CancellationToken cancellationToken)
        //{
        //    var entity = await _repository.FindAsync(id, CancellationToken.None);
        //    if (entity == null)
        //        throw new NullReferenceException(nameof(Product));

        //    var result = _mapper.Map<UpdateCategoryProductRequest, CategProduct>(request, entity);
        //    _repository.Update(entity);
        //    await _repository.SaveChangesAsync(CancellationToken.None);

        //    return _mapper.Map<Product, ProductResponse>(entity);
        //}
    }
}
