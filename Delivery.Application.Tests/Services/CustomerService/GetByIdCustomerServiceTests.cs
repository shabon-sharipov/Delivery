using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Response.CustomerResponse;
using Moq;
using NUnit.Framework;

namespace Delivery.Application.Tests.Services.CustomerService;

public class GetByIdCustomerServiceTests
{
    private readonly Mock<IRepository<Customer>> _repository;
    private readonly Mock<IMapper> _mapper;

    public GetByIdCustomerServiceTests()
    {
        _repository = new Mock<IRepository<Customer>>();
        _mapper = new Mock<IMapper>();
        
    }
    
    ulong customerId = 1;

    [Test]
    public Task Get_GetCustomerDataByIdWhenIdIsNull_ReturnException()
    {
        _repository.Setup(c => c.FindAsync(customerId, CancellationToken.None))
            .Returns(Task.FromResult<Customer>(null));
        var service = new Application.Services.CustomerService(_repository.Object, _mapper.Object);

        Assert.ThrowsAsync<HttpStatusCodeException>(async () => await service.Get(customerId, CancellationToken.None));
     _repository.Verify(x => x.FindAsync(customerId, CancellationToken.None));
     return Task.CompletedTask;
    }

    [Test]
    public async Task Get_GetCustomerDataByIdWhenIdIsNotNull_ReturnCustomerData()
    {
        var customer = new Customer
            { Id = 1, FirstName = "", LastName = "", PhoneNumber = "", Address = "", DataOfBirth = DateTime.UtcNow };
        var customerResponse = new GetCustomerResponse
            { Id = 1, FirstName = "", LastName = "", PhoneNumber = "", Address = "", DataOfBirth = DateTime.UtcNow };
        
        _repository.Setup(c => c.FindAsync(customerId, CancellationToken.None)).ReturnsAsync(customer);
        _mapper.Setup(m => m.Map<Customer, GetCustomerResponse>(customer)).Returns(customerResponse);

        var service = new Application.Services.CustomerService(_repository.Object, _mapper.Object);
        var entity = await service.Get(customerId, CancellationToken.None);
        
        _repository.Verify(o => o.FindAsync(customerId, CancellationToken.None));

        var result = entity as GetCustomerResponse;
        Assert.That("", Is.EqualTo(result.FirstName));
    }
}