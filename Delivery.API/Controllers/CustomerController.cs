using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.CustomerRequest;
using Delivery.Application.Response.CustomerResponse;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService _customerService)
        {
            customerService = _customerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetById(ulong id)
        {
            var entity =await customerService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> Post(CreateCustomerRequest customer)
        {
            var entity = await customerService.Create(customer, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult<CustomerResponse>> Put(CreateCustomerRequest customer, ulong id)
        {
            var entity = await customerService.Update(customer, id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ulong id)
        {
            var entity = customerService.Delete(id, CancellationToken.None);
            return Ok();
        }
    }
}
