using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Respons.SenderResponse;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private readonly ISenderService senderService;

        public SenderController(ISenderService _senderService)
        {
            senderService = _senderService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SenderResponse>> GetById(ulong id)
        {
            var entity = await senderService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<SenderResponse>> Post(CreateSenderRequest sender)
        {
            var entity = await senderService.Create(sender, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult<SenderResponse>> Put(CreateSenderRequest sender, ulong id)
        {
            var entity = await senderService.Update(sender, id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            var entity =  senderService.Delete(id, CancellationToken.None);
            return Ok(entity);
        }

    }
}
