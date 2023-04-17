using System.Net;
using AutoMapper;
using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Services;
using Delivery.Application.Requests.CustomerRequest;
using Delivery.Application.Response.CustomerResponse;
using Moq;
using NUnit.Framework;

namespace Delivery.Application.Tests.Services.CustomerService;


public class CreateCustomerServiceTests
{
    private readonly Mock<IRepository<Customer>> _repository;
    private readonly Mock<IMapper> _mapper;

    public CreateCustomerServiceTests()
    {
        _repository = new Mock<IRepository<Customer>>();
        _mapper = new Mock<IMapper>();
    }

    [Test]
    public void Create_RequestIsNull_ReturnHttpStatusCodeException()
    {
        // Arrange
        int statusCode = 500;
        string message =
            "An exception has been raised that is likely due to a transient failure. Consider enabling transient error resiliency by adding 'EnableRetryOnFailure' to the 'UseSqlServer' call.";
        var customerService = new Application.Services.CustomerService(_repository.Object, _mapper.Object);
        
        try
        {
            customerService.Create(null, CancellationToken.None);
        }
        catch (HttpStatusCodeException ex)
        {
            // Assert
            Assert.Equals(statusCode,  ex.StatusCode);
            Assert.Equals(message, ex.Message);
        }
    }


    [Test]
    public async Task Create_RequestIsNotNull_ReturnCustomerData()
    {
        var customerRequest = new CreateCustomerRequest
            { FirstName = "", LastName = "", Address = "", PhoneNumber = "", DataOfBirth = DateTime.UtcNow };
        
        var customer = new Customer
            { Id = 1, FirstName = "", LastName = "", Address = "", PhoneNumber = "", DataOfBirth = DateTime.UtcNow };
        
        var customerResponse = new CreateCustomerResponse
            { Id = 1, FirstName = "", LastName = "", Address = "", PhoneNumber = "", DataOfBirth = DateTime.UtcNow };
        
        var customerService = new Application.Services.CustomerService(_repository.Object, _mapper.Object);
        
        _mapper.Setup(m => m.Map<CreateCustomerRequest, Customer>(customerRequest)).Returns(customer);
        _mapper.Setup(m => m.Map<Customer, CustomerResponse>(customer)).Returns(customerResponse);
        
        var resultCustomerService = await customerService.Create(customerRequest, CancellationToken.None);

        _repository.Verify(r => r.AddAsync(It.IsAny<Customer>(), CancellationToken.None));
        _repository.Verify(r => r.SaveChangesAsync(CancellationToken.None));

        var result = resultCustomerService as CreateCustomerResponse;

        Assert.That(result.FirstName, Is.EqualTo(customer.FirstName));
    }
    
    
}