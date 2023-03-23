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
    public class SenderService : BaseService<Sender, SenderResponse, CreateSenderRequest>, ISenderService
    {
        private readonly IRepository<Sender> _repository;
        private readonly IMapper _mapper;

        public SenderService(IRepository<Sender> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async override Task<SenderResponse> Create(CreateSenderRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException(nameof(Sender));

            var entity = _mapper.Map<CreateSenderRequest, Sender>(request);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<Sender, SenderResponse>(entity);
        }

        public override async Task<SenderResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);

            if (entity == null)
                throw new NullReferenceException(nameof(Sender));

            return _mapper.Map<Sender, SenderResponse>(entity);
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

        public override async Task<SenderResponse> Update(CreateSenderRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Sender));

            var result = _mapper.Map(request, entity);

            _repository.Update(entity);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<Sender, SenderResponse>(result);

        }
    }
}
