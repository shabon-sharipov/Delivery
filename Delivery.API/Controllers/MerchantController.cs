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

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaggedMerchantListItemResponse>> GetAll(int pageSize, int pageNumber)
        {
           var entity = merchantService.GetAll(pageSize, pageNumber, CancellationToken.None);
           return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MerchantResponse>> GetById(ulong id)
        {
            var entity = await merchantService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<MerchantResponse>> Post(CreateMerchantRequest merchant)
        {
            var entity = await merchantService.Create(merchant, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult<MerchantResponse>> Put(UpdateMerchantRequest merchant, ulong id)
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
