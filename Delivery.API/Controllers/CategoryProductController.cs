using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.CategoryProductRequest;
using Delivery.Application.Requests.ProductsRequest;
using Delivery.Application.Respons.CategoryProductResponse;
using Delivery.Application.Respons.ProductRespons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryProductController : ControllerBase
    {
        private readonly ICategoryProductServices productService;

        public CategoryProductController(ICategoryProductServices _productService)
        {
            productService = _productService;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryProductResponse>> Post(CreateCategoryProductRequest request)
        {
            var entity = await productService.Create(request, CancellationToken.None);
            return Ok(entity);
        }

    }
}
