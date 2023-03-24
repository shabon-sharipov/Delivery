using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.CategoryCustomerRequest;
using Delivery.Application.Respons.CategoryCustomerResponse;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CategoryCustomerController : ControllerBase
{
    private readonly ICategoryCustomerService _categoryCustomerService;

    public CategoryCustomerController(ICategoryCustomerService categoryCustomerService)
    {
        _categoryCustomerService = categoryCustomerService;
    }

    [HttpPost]
    public async Task<ActionResult<CategoryCustomerResponse>> Post(CreateCategoryCustomerRequest request)
    {
        var entity = await _categoryCustomerService.Create(request, CancellationToken.None);
        return Ok(entity);
    }

    [HttpGet("id")]
    public async Task<ActionResult<CategoryCustomerResponse>> GetById(ulong id)
    {
        var entity = await _categoryCustomerService.Get(id, CancellationToken.None);
        return Ok(entity);
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<CategoryCustomerResponse>>> GetAll(int pageSize, int pageNamber, CancellationToken cancellationToken)
    {
        var result = await _categoryCustomerService.GetAll(pageSize, pageNamber, cancellationToken);
        return Ok(result);
    }

    [HttpPut("id")]
    public async Task<ActionResult<CategoryCustomerResponse>> Put(UpdateCategoryCustomerRequest product, ulong id)
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
