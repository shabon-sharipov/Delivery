﻿using Delivery.Application.Common.Interfaces;
using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Respons.SenderResponse;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private readonly ISenderService _senderService;

        public SenderController(ISenderService senderService)
        {
            _senderService = senderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SenderResponse>> GetById(ulong id)
        {
            var entity = await _senderService.Get(id, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<SenderResponse>> Post(CreateSenderRequest sender)
        {
            var entity = await _senderService.Create(sender, CancellationToken.None);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult<SenderResponse>> Put(CreateSenderRequest sender, ulong id)
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