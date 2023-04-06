using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.MerchantRequest;
using Delivery.Application.Response.MerchantResponse;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Services
{
    public class MerchantService : BaseService<Merchant, MerchantResponse, MerchantRequest>, IMerchantService
    {
        private readonly IRepository<Merchant> _repozitory;
        private readonly IMapper _mapper;

        public MerchantService(IRepository<Merchant> repository, IMapper mapper)
        {
            _repozitory = repository;
            _mapper = mapper;
        }


        public async override Task<MerchantResponse> Create(MerchantRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Merchant));

            var createMerchantRequest = request as CreateMerchantRequest;
            var entity = _mapper.Map<CreateMerchantRequest, Merchant>(createMerchantRequest);

            await _repozitory.AddAsync(entity, cancellationToken);
            await _repozitory.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Merchant, CreateMerchantResponse>(entity);
        }

        public async override Task<MerchantResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repozitory.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Merchant));

            return _mapper.Map<Merchant, GetMerchantResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repozitory.Find(id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Merchant));

            _repozitory.Delete(entity);
            _repozitory.SaveChanges();
            return true;
        }

        public override async Task<MerchantResponse> Update(MerchantRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repozitory.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Merchant));

            var updateMerchantRequest = request as UpdateMerchantRequest;
            var result = _mapper.Map(updateMerchantRequest, entity);

            _repozitory.Update(entity);
            await _repozitory.SaveChangesAsync(CancellationToken.None);
            return _mapper.Map<Merchant, UpdateMerchantResponse>(result);
        }
    }
}
