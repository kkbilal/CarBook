using Application.Features.MediatR.Commands.FooterCommands;
using Application.Features.MediatR.Queries.FooterQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FootersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetFooterAsync()
        {
            var query = new GetFooterQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterByIdAsync(int id)
        {
            var query = new GetFooterByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAsync([FromBody] CreateFooterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer created successfully." );
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFooterAsync(int id, [FromBody] UpdateFooterCommand command)
        {
            if (id != command.FooterId)
            {
                return BadRequest("Footer ID mismatch.");
            }
            await _mediator.Send(command);
            return Ok("Footer updated successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFooterAsync(int id)
        {
            var command = new RemoveFooterCommand(id);
            await _mediator.Send(command);
            return Ok("Footer deleted successfully.");
        }
    }
}
