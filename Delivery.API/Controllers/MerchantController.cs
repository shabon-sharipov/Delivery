using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.MerchantRequest;
using Delivery.Application.Response.MerchantResponse;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantService merchantService;

        public MerchantController(IMerchantService _merchantService)
        {
            merchantService = _merchantService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MerchantResponse>> GetById(ulong id)
        {
            var entity = merchantService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<MerchantResponse>> Post(CreateMerchantRequest merchant)
        {
            var entity = await merchantService.Create(merchant, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult<MerchantResponse>> Put(CreateMerchantRequest merchant, ulong id)
        {
            var entity = await merchantService.Update(merchant, id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            var entity = merchantService.Delete(id, CancellationToken.None);
            return Ok();
        }
    }
}
