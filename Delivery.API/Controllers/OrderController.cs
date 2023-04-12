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
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaggedOrderListItemResponse>> GetAll(int pageSize, int pageNumber)
        {
            var entity = await _orderService.GetAll(pageSize, pageNumber, CancellationToken.None);
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetById(ulong id)
        {
            var entity = await _orderService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost("Order")]
        public async Task<ActionResult<OrderResponse>> Post(CreateOrderRequest order)
        {
            var entity = await _orderService.Create(order, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult<OrderResponse>> Put(UpdateOrderRequest order, ulong id)
        {
            var entity = await _orderService.Update(order, id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("Order/{id}")]
        public IActionResult Delete(ulong id)
        {
            var entity = _orderService.Delete(id, CancellationToken.None);
            return Ok();
        }

        [HttpPost("OrderDetels")]
        public async Task<ActionResult<OrderDetails>> PostOrderDetails(OrderDetails orderDetails)
        {
            var entity = await _orderService.CreateOrderDitels(orderDetails, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("OrderDetails/{id}")]
        public IActionResult DeleteOrderDetails(ulong id)
        {
            var entity = _orderService.DeleteOrderDitels(id, CancellationToken.None);
            return Ok();
        }
    }
}
