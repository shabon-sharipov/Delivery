using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.MerchantRequest;
using Delivery.Application.Response.MerchantResponse;
using Delivery.Domain.Model;
using Moq;
using NUnit.Framework;


namespace Delivery.Application.Tests.Services.MerchantService;


public class CreateMerchantServiceTests
{
    private readonly Mock<IRepository<Merchant>> _repository;
    private readonly Mock<IMapper> _mapper;

    public CreateMerchantServiceTests()
    {
        _repository = new Mock<IRepository<Merchant>>();
        _mapper = new Mock<IMapper>();
    }

    [Test]
    public void Create_RequestIsNull_ReturnHttpStatusCodeException()
    {
        // Arrange
        int statusCode = 500;
        string message =
            "An exception has been raised that is likely due to a transient failure. Consider enabling transient error resiliency by adding 'EnableRetryOnFailure' to the 'UseSqlServer' call.";
        var MerchantService = new Application.Services.MerchantService(_repository.Object, _mapper.Object);
        
        try
        {
            MerchantService.Create(null, CancellationToken.None);
        }
        catch (HttpStatusCodeException ex)
        {
            // Assert
            Assert.Equals(statusCode,  ex.StatusCode);
            Assert.Equals(message, ex.Message);
        }
    }


    [Test]
    public async Task Create_RequestIsNotNull_ReturnMerchantData()
    {
        var MerchantRequest = new CreateMerchantRequest
            { Name = "Create_Merchant_Test", ShortDiscreption = "", MerchantCategoryId = 0, IsActive = ""};
        
        var Merchant = new Merchant
            { Id = 1, Name = "Create_Merchant_Test", ShortDiscreption = "", MerchantCategoryId = 0,IsActive="" };
        
        var MerchantResponse = new CreateMerchantResponse
            { Id = 1, Name = "Create_Merchant_Test", ShortDiscreption = "", MerchantCategoryId = 0, IsActive = "" };
        
        var MerchantService = new Application.Services.MerchantService(_repository.Object, _mapper.Object);
        
        _mapper.Setup(m => m.Map<CreateMerchantRequest, Merchant>(MerchantRequest)).Returns(Merchant);
        _mapper.Setup(m => m.Map<Merchant, MerchantResponse>(Merchant)).Returns(MerchantResponse);
        
        var resultMerchantService = await MerchantService.Create(MerchantRequest, CancellationToken.None);

        _repository.Verify(r => r.AddAsync(It.IsAny<Merchant>(), CancellationToken.None));
        _repository.Verify(r => r.SaveChangesAsync(CancellationToken.None));

        var result = resultMerchantService as CreateMerchantResponse;

        Assert.That(result.Name, Is.EqualTo(Merchant.Name));
    }
    
    
}