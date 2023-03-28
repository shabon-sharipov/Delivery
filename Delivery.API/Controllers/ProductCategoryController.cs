using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.CategoryProductRequest;
using Delivery.Application.Requests.ProductsRequest;

using Delivery.Application.Response.CategoryProductResponse;
using Delivery.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ICategoryProductServices _productService;

        public ProductCategoryController(ICategoryProductServices productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategoryResponse>> Post(CreateCategoryProductRequest request)
        {
            var entity = await _productService.Create(request, CancellationToken.None);
            return Ok(entity);
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProductCategoryResponse>> GetById(ulong id)
        {
            var entity = await _productService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ProductCategoryResponse>>> GetAll(int pageSize, int pageNamber, CancellationToken cancellationToken)
        {
            var result = await _productService.GetAll(pageSize, pageNamber, cancellationToken);
            return Ok(result);
        }

        [HttpPut("id")]
        public async Task<ActionResult<ProductCategoryResponse>> Put(UpdateCategoryProductRequest product, ulong id)
        {
            var entity = await _productService.Update(product, id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("id")]
        public IActionResult Delete(ulong id)
        {
            var entity = _productService.Delete(id, CancellationToken.None);
            return Ok(entity);
        }
    }
}
