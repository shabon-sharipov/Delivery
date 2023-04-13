using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.CardItemRequest;
using Delivery.Application.Requests.CartRequests;
using Delivery.Application.Response.CardItemResponse;
using Delivery.Application.Response.CartRespons;
using Delivery.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.Options;
using NuGet.Configuration;

namespace Delivery.Application.Services
{
    public class CartService : BaseService<Cart, CartResponse, CartRequest>, ICartService
    {
        private readonly IRepository<Cart> _repositoryCartMock;
        private readonly IRepository<CartItem> _repositoryCartItemMock;
        private readonly IRepository<Product> _repositoryProductMock;
        private readonly IMapper _mapper;

        public CartService(IRepository<Cart> repository, IMapper mapper, IRepository<CartItem> repositoryCartItem, IRepository<Product> repositoryProductMock)
        {
            _repositoryCartMock = repository;
            _repositoryCartItemMock = repositoryCartItem;
            _mapper = mapper;
            _repositoryProductMock = repositoryProductMock;
        }

        public override async Task<CartResponse> Create(CartRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Cart)); ;

            var createCardItemRequset = request as CreateCartRequest;
            var entity = _mapper.Map<CreateCartRequest, Cart>(createCardItemRequset);

            await _repositoryCartMock.AddAsync(entity, cancellationToken);
            await _repositoryCartMock.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Cart, CreateCartRespons>(entity);
        }

        public async override Task<CartResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repositoryCartMock.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(CartItem)); ;
            return _mapper.Map<Cart, GetCartResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repositoryCartMock.Find(id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Cart));

            _repositoryCartMock.Delete(entity);
            _repositoryCartMock.SaveChanges();
            return true;
        }

        public override Task<CartResponse> Update(CartRequest request, ulong id, CancellationToken cancellationToken)
        {
            return base.Update(request, id, cancellationToken);
        }

        public async Task<CreateCardItemResponse> CreateCartItem(CreateCardItemRequest cartItem, CancellationToken cancellationToken)
        {
            await ValidationBeforCreateCartItem(cartItem, cancellationToken);

            var entity = _mapper.Map<CreateCardItemRequest, CartItem>(cartItem);
            await _repositoryCartItemMock.AddAsync(entity, cancellationToken);
            await _repositoryCartItemMock.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CartItem, CreateCardItemResponse>(entity); ;
        }

        public async Task<bool> DeleteCartItem(ulong Id, CancellationToken cancellationToken)
        {
            var entity = await _repositoryCartItemMock.FindAsync(Id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(CartItem));

            _repositoryCartItemMock.Delete(entity);
            await _repositoryCartItemMock.SaveChangesAsync(cancellationToken);

            return true;
        }

        #region Validation

        public async Task<bool> ValidationBeforCreateCartItem(CreateCardItemRequest createCardItemRequest, CancellationToken cancellationToken)
        {
            if (createCardItemRequest == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(CartItem));

            var product = await _repositoryProductMock.FindAsync(createCardItemRequest.ProductId, cancellationToken);
            if (product == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Product));

            var cart = await _repositoryCartMock.FindAsync(createCardItemRequest.CardId, cancellationToken);
            if (cart == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Cart));

            return true;
        }

        #endregion
    }
}