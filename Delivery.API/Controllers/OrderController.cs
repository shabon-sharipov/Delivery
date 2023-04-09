using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Response.OrderResponse;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaggedOrderListItemResponse>> GetAll(int pageSize, int pageNumber)
        {
            var entity = await orderService.GetAll(pageSize, pageNumber, CancellationToken.None);
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetById(ulong id)
        {
            var entity = await orderService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Post(CreateOrderRequest order)
        {
            var entity = await orderService.Create(order, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult<OrderResponse>> Put(UpdateOrderRequest order, ulong id)
        {
            var entity = await orderService.Update(order, id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            var entity = orderService.Delete(id, CancellationToken.None);
            return Ok();
        }

    }
}
