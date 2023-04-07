using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.CustomerRequest;
using Delivery.Application.Response.CustomerResponse;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Services
{
    public class CustomerService : BaseService<Customer, CustomerResponse, CustomerRequest>, ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }


        public async Task<IEnumerable<CustomerResponse>> GetAll(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var customers = _repository.GetAll(pageSize, pageNumber, cancellationToken);
            return _mapper.Map<IEnumerable<PaggedListCustomerItemResponse>>(customers);
        }


        public async override Task<CustomerResponse> Create(CustomerRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Customer)); 

            var createCustomerRequest = request as CreateCustomerRequest;
            var entity = _mapper.Map<CreateCustomerRequest, Customer>(createCustomerRequest);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Customer, CreateCustomerResponse>(entity);
        }

        public async override Task<CustomerResponse> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, cancellationToken);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound,nameof(Customer));

            return _mapper.Map<Customer, GetCustomerResponse>(entity);
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Customer));

            _repository.Delete(entity);
            _repository.SaveChanges();
            return true;
        }

        public async override Task<CustomerResponse> Update(CustomerRequest request, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Customer));

            var updateOrderRequest = request as UpdateCustomerRequest;
            var result = _mapper.Map(updateOrderRequest, entity);

            _repository.Update(entity);
            await _repository.SaveChangesAsync(CancellationToken.None);
            return _mapper.Map<Customer, UpdateCustomerResponse>(result);
        }
    }
}
