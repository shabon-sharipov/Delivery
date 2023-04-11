using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.MerchantBranch;
using Delivery.Application.Response.MerchantBranchResponse;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantBranchController : ControllerBase
    {
        private readonly IMerchantBranchService merchantBranchService;

        public MerchantBranchController(IMerchantBranchService _merchantBranchService)
        {
            merchantBranchService = _merchantBranchService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MerchantBranchResponse>> GetById(ulong id)
        {
            var entity = await merchantBranchService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<MerchantBranchResponse>> Post(CreateMerchantBranchRequest request)
        {
            var entity = await merchantBranchService.Create(request, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult<MerchantBranchResponse>> Put(UpdateMerchantBranchRequest request, ulong id)
        {
            var entity=await merchantBranchService.Update(request, id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            var entity = merchantBranchService.Delete(id, CancellationToken.None);

            return Ok(entity);
        }

    }
}
