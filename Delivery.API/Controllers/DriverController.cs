using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Response.SenderResponse;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _senderService;

        public DriverController(IDriverService senderService)
        {
            _senderService = senderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DriverResponse>> GetById(ulong id)
        {
            var entity = await _senderService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<DriverResponse>>> GetAll(int pageSize, int pageNamber, CancellationToken cancellationToken)
        {
            var result = await _senderService.GetAll(pageSize, pageNamber, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<DriverResponse>> Post(CreateDriverRequest sender)
        {
            var entity = await _senderService.Create(sender, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult<DriverResponse>> Put(UpdateDriverRequest sender, ulong id)
        {
            var entity = await _senderService.Update(sender, id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            var entity = _senderService.Delete(id, CancellationToken.None);
            return Ok(entity);
        }
    }
}
