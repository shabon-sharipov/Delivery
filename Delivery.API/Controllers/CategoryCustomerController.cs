using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.CategoryCustomerRequest;
using Delivery.Application.Response.CategoryCustomerResponse;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CategoryCustomerController : ControllerBase
{
    private readonly IMerchantCategoryService _categoryCustomerService;

    public CategoryCustomerController(IMerchantCategoryService categoryCustomerService)
    {
        _categoryCustomerService = categoryCustomerService;
    }

    [HttpPost]
    public async Task<ActionResult<MerchantCategoryResponse>> Post(CreateMerchantCustomerRequest request)
    {
        var entity = await _categoryCustomerService.Create(request, CancellationToken.None);
        return Ok(entity);
    }

    [HttpGet("id")]
    public async Task<ActionResult<MerchantCategoryResponse>> GetById(ulong id)
    {
        var entity = await _categoryCustomerService.Get(id, CancellationToken.None);
        return Ok(entity);
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<MerchantCategoryResponse>>> GetAll(int pageSize, int pageNamber, CancellationToken cancellationToken)
    {
        var result = await _categoryCustomerService.GetAll(pageSize, pageNamber, cancellationToken);
        return Ok(result);
    }

    [HttpPut("id")]
    public async Task<ActionResult<MerchantCategoryResponse>> Put(UpdateCustomeMerchantrRequest product, ulong id)
    {
        var entity = await _categoryCustomerService.Update(product, id, CancellationToken.None);
        return Ok(entity);
    }

    [HttpDelete("id")]
    public IActionResult Delete(ulong id)
    {
        var entity = _categoryCustomerService.Delete(id, CancellationToken.None);
        return Ok(entity);
    }
}
