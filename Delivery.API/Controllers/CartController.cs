using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.CardItemRequest;
using Delivery.Application.Requests.CartRequests;
using Delivery.Application.Response.CardItemResponse;
using Delivery.Application.Response.CartRespons;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService _CardItemervice)
        {
            _cartService = _CardItemervice;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartItemResponse>> GetById(ulong id)
        {
            var entity = await _cartService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CartItemResponse>>> GetAll(int pageSize, int pageNamber)
        {
            var entity = await _cartService.GetAll(pageNamber, pageSize, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost("Cart")]
        public async Task<ActionResult<CartResponse>> Post(CreateCartRequest Cart)
        {
            var entity = await _cartService.Create(Cart, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("Cart/{id}")]
        public IActionResult Delete(ulong id)
        {
            var entity = _cartService.Delete(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost("CartItem")]
        public async Task<ActionResult<CartItemResponse>> PostCartItem(CreateCardItemRequest Cart)
        {
            var entity = await _cartService.CreateCartItem(Cart, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("CartItem/{id}")]
        public IActionResult DeleteCartItem(ulong id)
        {
            var entity = _cartService.Delete(id, CancellationToken.None);
            return Ok(entity);
        }
    }
}