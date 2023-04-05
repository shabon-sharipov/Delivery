using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Response.SenderResponse;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Services
{
    public class DriverService : BaseService<Driver, DriverResponse, DriverRequest>, IDriverService
    {
        private readonly IRepository<Driver> _repository;
        private readonly IMapper _mapper;

        public DriverService(IRepository<Driver> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async override Task<DriverResponse> Create(DriverRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException(nameof(Driver));

            var createSenderRequest = request as CreateDriverRequest;
            var entity = _mapper.Map<CreateDriverRequest, Driver>(createSenderRequest);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Driver, CreateDriverResponse>(entity);
        }

        public override async Task<DriverResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);

            if (entity == null)
                throw new NullReferenceException(nameof(Driver));

            return _mapper.Map<Driver, GetDriverResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Driver));

            _repository.Delete(entity);
            _repository.SaveChanges();

            return true;
        }

        public override async Task<DriverResponse> Update(DriverRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Driver));

            var updateSenderRequset = request as UpdateDriverRequest;
            var result = _mapper.Map(updateSenderRequset, entity);

            _repository.Update(entity);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<Driver, UpdateDriverResponse>(result);

        }

        public override async Task<IEnumerable<DriverResponse>> GetAll(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var entities = _repository.GetAll(pageSize, pageNumber, cancellationToken);

            return _mapper.Map<IEnumerable<PaggedListDriverItemResponse>>(entities);
        }
    }
}
