using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.MerchantBranch;
using Delivery.Application.Response.MerchantBranchResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Services
{
    public class MerchantBranchService : BaseService<MerchantBranch, MerchantBranchResponse, MerchantBranchRequest>, IMerchantBranchService
    {
        private readonly IRepository<MerchantBranch> _repository;
        private readonly IMapper _mapper;

        public MerchantBranchService(IRepository<MerchantBranch> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async override Task<MerchantBranchResponse> Create(MerchantBranchRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(MerchantBranch));

            var createMerchantBranchRequest = request as CreateMerchantBranchRequest;
            var entity = _mapper.Map<MerchantBranchRequest, MerchantBranch>(createMerchantBranchRequest);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<MerchantBranch, MerchantBranchResponse>(entity);
        }

        public async Task<MerchantBranchResponse> Update(MerchantBranchRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(MerchantBranch));

            var updateMerchantBranchRequest = request as UpdateMerchantBranchRequest;

            var result = _mapper.Map(updateMerchantBranchRequest, entity);

            _repository.Update(entity);
            await _repository.SaveChangesAsync(CancellationToken.None);
            return _mapper.Map<MerchantBranch, UpdateMerchantBranchResponse>(result);
        }

        public async override Task<MerchantBranchResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(MerchantBranch));

            return _mapper.Map<MerchantBranch, GetMerchantBranchResponse>(entity);
        }
        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(MerchantBranch));

            _repository.Delete(entity);
            _repository.SaveChanges();
            return true;
        }

    }
}
