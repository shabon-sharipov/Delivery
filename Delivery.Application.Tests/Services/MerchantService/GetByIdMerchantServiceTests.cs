using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Response.MerchantResponse;
using Delivery.Domain.Model;
using Moq;
using NUnit.Framework;

namespace Delivery.Application.Tests.Services.MerchantService;

public class GetByIdMerchantServiceTests
{
    private readonly Mock<IRepository<Merchant>> _repository;
    private readonly Mock<IMapper> _mapper;

    public GetByIdMerchantServiceTests()
    {
        _repository = new Mock<IRepository<Merchant>>();
        _mapper = new Mock<IMapper>();
        
    }
    
    ulong MerchantId = 1;

    [Test]
    public Task Get_GetMerchantDataByIdWhenIdIsNull_ReturnException()
    {
        _repository.Setup(c => c.FindAsync(MerchantId, CancellationToken.None))
            .Returns(Task.FromResult<Merchant>(null));
        var service = new Application.Services.MerchantService(_repository.Object, _mapper.Object);

        Assert.ThrowsAsync<HttpStatusCodeException>(async () => await service.Get(MerchantId, CancellationToken.None));
     _repository.Verify(x => x.FindAsync(MerchantId, CancellationToken.None));
     return Task.CompletedTask;
    }

    [Test]
    public async Task Get_GetMerchantDataByIdWhenIdIsNotNull_ReturnMerchantData()
    {
        var Merchant = new Merchant
            { Id = 1, Name = "Get_Merchant_Test", ShortDiscreption = "", IsActive = "", MerchantCategoryId = 0 };
        var MerchantResponse = new GetMerchantResponse
            { Id = 1, Name = "Get_Merchant_Test", ShortDiscreption = "", IsActive = "", MerchantCategoryId = 0 };
        
        _repository.Setup(c => c.FindAsync(MerchantId, CancellationToken.None)).ReturnsAsync(Merchant);
        _mapper.Setup(m => m.Map<Merchant, GetMerchantResponse>(Merchant)).Returns(MerchantResponse);

        var service = new Application.Services.MerchantService(_repository.Object, _mapper.Object);
        var entity = await service.Get(MerchantId, CancellationToken.None);
        
        _repository.Verify(o => o.FindAsync(MerchantId, CancellationToken.None));

        var result = entity as GetMerchantResponse;
        Assert.That("Get_Merchant_Test", Is.EqualTo(result.Name));
    }
}