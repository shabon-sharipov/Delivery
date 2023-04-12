using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.CardItemRequest;
using Delivery.Application.Response.CardItemResponse;
using Delivery.Domain.Model;
namespace Delivery.Application.Services
{
    public class CardItemService : BaseService<CardItem, CardItemResponse, CardItemRequest>, ICardItemService
    {
        private readonly IRepository<CardItem> _repository;
        private readonly IMapper _mapper;

        public CardItemService(IRepository<CardItem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<CardItemResponse> Create(CardItemRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(CardItem));;

            var createCardItemRequset = request as CreateCardItemRequest;
            CardItem entity = _mapper.Map<CreateCardItemRequest, CardItem>(createCardItemRequset);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CardItem, CreateCardItemResponse>(entity);
        }

        public async override Task<IEnumerable<CardItemResponse>> GetAll(int PageSize, int PageNumber, CancellationToken cancellationToken)
        {
            var CardItems = _repository.GetAll(PageSize, PageNumber, cancellationToken);

            return _mapper.Map<IEnumerable<PaggedListCardItemtResponse>>(CardItems);
        }

        public async override Task<CardItemResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            CardItem entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(CardItem));;

            return _mapper.Map<CardItem, GetCardItemResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(CardItem));;

            _repository.Delete(entity);
            _repository.SaveChanges();
            return true;
        }

        public async override Task<CardItemResponse> Update(CardItemRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(CardItem));;

            var updateCardItemRequset = request as UpdateCardItemRequest;

            _mapper.Map<UpdateCardItemRequest, CardItem>(updateCardItemRequset, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<CardItem, UpdateCardItemResponse>(entity);
        }
    }
}