using Application.Features.MediatR.Commands.PricingCommands;
using Application.Features.MediatR.Commands.ServiceCommands;
using Application.Features.MediatR.Queries.PricingQueries;
using Application.Features.MediatR.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var query = new GetServiceQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var query = new GetServiceByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid Service data.");
            }
            await _mediator.Send(command);
            return Ok("Service Created Successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateServiceCommand command)
        {

            await _mediator.Send(command);

            return Ok("Service Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var command = new RemoveServiceCommand(id);
            await _mediator.Send(command);
            return Ok("Service Deleted Successfully");
        }
    }
}
