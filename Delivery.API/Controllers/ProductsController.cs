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
        public IActionResult Get(ulong id)
        {
            var entity = productService.Get(id);
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            var entity = productService.Create(product);
            return Ok(entity);
        }

        [HttpPut("{id}")] 
        public IActionResult Put(Product product, ulong id)
        {
            var entity = productService.Update(product, id);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            var entity = productService.Delete(id);
            return Ok(entity);
        }
    }
}