using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Exceptions;
using Delivery.Application.Requests.MerchantRequest;
using Delivery.Application.Response.MerchantResponse;
using Delivery.Domain.Model;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Delivery.Application.Tests.Services.MerchantService;

public class UpdateMerchantServiceTests
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IRepository<Merchant>> _repository;

    public UpdateMerchantServiceTests()
    {
        _repository = new Mock<IRepository<Merchant>>();
        _mapper = new Mock<IMapper>();
    }

    private ulong MerchantId = 1;
    
    [Test]
    public async Task Update_UpdateMerchantDataByIdWhenIdIsNull_ReturnMerchantData()
    {
        var Merchant = new CreateMerchantRequest
            { Name = "Update_Merchant_Test", ShortDiscreption = "", IsActive = "", MerchantCategoryId = 0};
       
        _repository.Setup(o => o.FindAsync(MerchantId, CancellationToken.None))
            .Returns(Task.FromResult<Merchant>(null));

        var service = new Application.Services.MerchantService(_repository.Object, _mapper.Object);

        Assert.ThrowsAsync<HttpStatusCodeException>(async () =>
            await service.Update(Merchant, MerchantId, CancellationToken.None));;
        
        _repository.Verify(x => x.FindAsync(MerchantId, CancellationToken.None));
    }

    [Test]
    public async Task Update_UpdateMerchantDataByIdWhenIdIsNotNull_ReturnMerchantData()
    {
        var Merchant = new Merchant
            {Id = 1, Name = "Update_Merchant_Test", ShortDiscreption = "", IsActive = "", MerchantCategoryId = 0 };
        var MerchantRequest = new UpdateMerchantRequest 
            { Name = "Update_Merchant_Test", ShortDiscreption = "", IsActive = "", MerchantCategoryId = 0 };
        var MerchantResponse = new UpdateMerchantResponse
            { Id = 1, Name = "Update_Merchant_Test", ShortDiscreption = "", IsActive = "", MerchantCategoryId = 0 };
        
        _repository.Setup(r => r.FindAsync(MerchantId, CancellationToken.None)).ReturnsAsync(Merchant);
        
        _mapper.Setup(c => c.Map(MerchantRequest, Merchant));
        _mapper.Setup(c => c.Map<Merchant, UpdateMerchantResponse>(Merchant)).Returns(MerchantResponse);

        var service = new Application.Services.MerchantService(_repository.Object, _mapper.Object);
        var entity = await service.Update(MerchantRequest, MerchantId, CancellationToken.None);
        
        _repository.Verify(c => c.FindAsync(MerchantId, CancellationToken.None));
        _repository.Verify(c => c.Update(It.IsAny<Merchant>()));
        _repository.Verify(c => c.SaveChangesAsync(CancellationToken.None));

        var result = entity as UpdateMerchantResponse;
        
        Assert.That(MerchantResponse.Name, Is.EqualTo("Update_Merchant_Test"));
    }
    
}