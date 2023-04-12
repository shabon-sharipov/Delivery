using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.CardItemRequest;
using Delivery.Application.Requests.CartRequests;
using Delivery.Application.Response.CardItemResponse;
using Delivery.Application.Response.CartRespons;
using Delivery.Domain.Model;
using NuGet.Configuration;

namespace Delivery.Application.Services
{
    public class CartService : BaseService<Cart, CartResponse, CartRequest>, ICartService
    {
        private readonly IRepository<Cart> _repository;
        private readonly IRepository<CartItem> _repositoryCartItem;
        private readonly IMapper _mapper;

        public CartService(IRepository<Cart> repository, IMapper mapper, IRepository<CartItem> repositoryCartItem)
        {
            _repository = repository;
            _repositoryCartItem = repositoryCartItem;
            _mapper = mapper;
        }

        public override async Task<CartResponse> Create(CartRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Cart)); ;

            var createCardItemRequset = request as CreateCartRequest;
            var entity = _mapper.Map<CreateCartRequest, Cart>(createCardItemRequset);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Cart, CreateCartRespons>(entity);
        }

        public async override Task<IEnumerable<CartResponse>> GetAll(int PageSize, int PageNumber, CancellationToken cancellationToken)
        {
            var CardItems = _repository.GetAll(PageSize, PageNumber, cancellationToken);

            return null; // _mapper.Map<IEnumerable<PaggedListCardItemResponse>>(CardItems);
        }

        public async override Task<CartResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(CartItem)); ;

            return _mapper.Map<Cart, GetCartResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Cart));

            _repository.Delete(entity);
            _repository.SaveChanges();
            return true;
        }

        public override Task<CartResponse> Update(CartRequest request, ulong id, CancellationToken cancellationToken)
        {
            return base.Update(request, id, cancellationToken);
        }

        public async Task<CreateCardItemResponse> CreateCartItem(CreateCardItemRequest cartItem, CancellationToken cancellationToken)
        {
            if (cartItem == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(CartItem));

            var entity = _mapper.Map<CreateCardItemRequest, CartItem>(cartItem);
            entity.TotalPrice = entity.UnitPrice * entity.Quantity;
            await _repositoryCartItem.AddAsync(entity, cancellationToken);
            await _repositoryCartItem.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CartItem, CreateCardItemResponse>(entity); ;
        }

        public async Task<bool> DeleteCartItem(ulong Id, CancellationToken cancellationToken)
        {
            var entity = await _repositoryCartItem.FindAsync(Id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(CartItem));

            _repositoryCartItem.Delete(entity);
            await _repositoryCartItem.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}