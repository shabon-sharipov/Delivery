using Delivery.Application.Common.Interfaces;
using Delivery.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(ulong id)
        {
            var entity = await productService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll(int pageSize, int pageNamber)
        {
            var entity = await productService.GetAll(pageNamber, pageSize, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            var entity = await productService.Create(product, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(Product product, ulong id)
        {
            var entity = await productService.Update(product, id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            var entity = productService.Delete(id, CancellationToken.None);
            return Ok(entity);
        }
    }
}