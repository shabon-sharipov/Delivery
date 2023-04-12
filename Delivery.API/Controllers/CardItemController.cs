using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.CardItemRequest;
using Delivery.Application.Response.CardItemResponse;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardItemController : ControllerBase
    {
        private readonly ICardItemService CardItemervice;

        public CardItemController(ICardItemService _CardItemervice)
        {
            CardItemervice = _CardItemervice;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardItemResponse>> GetById(ulong id)
        {
            var entity = await CardItemervice.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CardItemResponse>>> GetAll(int pageSize, int pageNamber)
        {
            var entity = await CardItemervice.GetAll(pageNamber, pageSize, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<CardItemResponse>> Post(CreateCardItemRequest CardItem)
        {
            var entity = await CardItemervice.Create(CardItem, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CardItemResponse>> Put(UpdateCardItemRequest CardItem, ulong id)
        {
            var entity = await CardItemervice.Update(CardItem, id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            var entity = CardItemervice.Delete(id, CancellationToken.None);
            return Ok(entity);
        }
    }
}