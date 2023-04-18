using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.CustomerRequest;
using Delivery.Application.Response.CustomerResponse;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Delivery.Application.Tests.Services;

public class UpdateCustomerServiceTests
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IRepository<Customer>> _repository;

    public UpdateCustomerServiceTests()
    {
        _repository = new Mock<IRepository<Customer>>();
        _mapper = new Mock<IMapper>();
    }

    private ulong customerId = 1;
    
    [Test]
    public async Task Update_UpdateCustomerDataByIdWhenIdIsNull_ReturnCustomerData()
    {
        var customer = new CreateCustomerRequest
            { FirstName = "", LastName = "", PhoneNumber = "", Address = "", DataOfBirth = DateTime.UtcNow };
       
        _repository.Setup(o => o.FindAsync(customerId, CancellationToken.None))
            .Returns(Task.FromResult<Customer>(null));

        var service = new Application.Services.CustomerService(_repository.Object, _mapper.Object);

        Assert.ThrowsAsync<HttpStatusCodeException>(async () =>
            await service.Update(customer, customerId, CancellationToken.None));;
        
        _repository.Verify(x => x.FindAsync(customerId, CancellationToken.None));
    }

    [Test]
    public async Task Update_UpdateCustomerDataByIdWhenIdIsNotNull_ReturnCustomerData()
    {
        var customer = new Customer
            {Id = 1, FirstName = "", LastName = "", Address = "", PhoneNumber = "", DataOfBirth = DateTime.UtcNow };
        var customerRequest = new UpdateCustomerRequest 
            { FirstName = "", LastName = "", Address = "", DataOfBirth = DateTime.UtcNow, PhoneNumber = ""};
        var customerResponse = new UpdateCustomerResponse
            { Id = 1, FirstName = "", LastName = "", DataOfBirth = DateTime.UtcNow, PhoneNumber = "", Address = "" };
        
        _repository.Setup(r => r.FindAsync(customerId, CancellationToken.None)).ReturnsAsync(customer);
        
        _mapper.Setup(c => c.Map(customerRequest, customer));
        _mapper.Setup(c => c.Map<Customer, UpdateCustomerResponse>(customer)).Returns(customerResponse);

        var service = new Application.Services.CustomerService(_repository.Object, _mapper.Object);
        var entity = await service.Update(customerRequest, customerId, CancellationToken.None);
        
        _repository.Verify(c => c.FindAsync(customerId, CancellationToken.None));
        _repository.Verify(c => c.Update(It.IsAny<Customer>()));
        _repository.Verify(c => c.SaveChangesAsync(CancellationToken.None));

        var result = entity as UpdateCustomerResponse;
        
        Assert.That(customerResponse.FirstName, Is.EqualTo(""));
    }
    
}