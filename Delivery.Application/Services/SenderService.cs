using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Respons.SenderResponse;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Services
{
    public class SenderService : BaseService<Sender, SenderResponse, SenderRequest>, ISenderService
    {
        private readonly IRepository<Sender> _repository;
        private readonly IMapper _mapper;

        public SenderService(IRepository<Sender> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async override Task<SenderResponse> Create(SenderRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException(nameof(Sender));

            var createSenderRequest = request as CreateSenderRequest;
            var entity = _mapper.Map<CreateSenderRequest, Sender>(createSenderRequest);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Sender, CreateSenderResponse>(entity);
        }

        public override async Task<SenderResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);

            if (entity == null)
                throw new NullReferenceException(nameof(Sender));

            return _mapper.Map<Sender, GetSenderResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Sender));

            _repository.Delete(entity);
            _repository.SaveChanges();

            return true;
        }

        public override async Task<SenderResponse> Update(SenderRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Sender));

            var updateSenderRequset = request as UpdateSenderRequest;
            var result = _mapper.Map(updateSenderRequset, entity);

            _repository.Update(entity);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<Sender, UpdateSenderResponse>(result);

        }

        public override async Task<IEnumerable<SenderResponse>> GetAll(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var entities = _repository.GetAll(pageSize, pageNumber, cancellationToken);

            return _mapper.Map<IEnumerable<SenderPaggedListItemResponse>>(entities);
        }
    }
}
