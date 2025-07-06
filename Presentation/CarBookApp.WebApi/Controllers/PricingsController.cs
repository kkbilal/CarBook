using Application.Features.MediatR.Commands.PricingCommands;
using Application.Features.MediatR.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetPricings()
        {
            var query = new GetPricingQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingById(int id)
        {
            var query = new GetPricingByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing([FromBody] CreatePricingCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid pricing data.");
            }
            await _mediator.Send(command);
            return Ok("Pricing Created Successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePricing(int id, [FromBody] UpdatePricingCommand command)
        {
           
            await _mediator.Send(command);
            
            return Ok("Pricing Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            var command = new RemovePricingCommand(id);
            await _mediator.Send(command);
            return Ok("Pricing Deleted Successfully");
        }
    }
}
