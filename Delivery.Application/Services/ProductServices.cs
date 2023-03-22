﻿using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Requests.ProductsRequest;
using Delivery.Application.Respons.ProductRespons;
using Delivery.Application.Respons.ProductRespons.PaggedList;
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
            var entity = _mapper.Map<CreateProductRequest, Product>(createProductRequset);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            CreateProductResponse result = _mapper.Map<Product, CreateProductResponse>(entity);

            return result;
        }

        public async override Task<IEnumerable<ProductResponse>> GetAll(int PageSize, int PageNumber, CancellationToken cancellationToken)
        {
            var products = _repository.GetAll(PageSize, PageNumber, cancellationToken);

            _mapper.Map<IEnumerable<PaggedListItemResponse>>(products);

            var result = _mapper.Map<IEnumerable<PaggedListItemResponse>>(products);
            return _mapper.Map<IEnumerable<PaggedListItemResponse>>(products);
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

        public async override Task<ProductResponse> Update(ProductRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));
            var updateProductRequset = request as UpdateProductRequest;


            var prductTEst = new Product
            {
                CategoryId = updateProductRequset.CategoryId,
                Name = updateProductRequset.Name,
                Discription = updateProductRequset.Discription,
                Price = updateProductRequset.Price,
                IsActive = updateProductRequset.IsActive
            };

            _mapper.Map<UpdateProductRequest, Product>(updateProductRequset, entity);




            _repository.Update(entity);
            await _repository.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<Product, ProductResponse>(entity);


        }
    }
}