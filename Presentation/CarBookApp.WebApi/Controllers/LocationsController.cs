using Application.Features.MediatR.Commands.LocationCommands;
using Application.Features.MediatR.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetLocations")]
        public async Task<IActionResult> GetLocations()
        {
            var query = new GetLocationQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("GetLocationById/{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var query = new GetLocationByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost("CreateLocation")]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid location data.");
            }
            await _mediator.Send(command);
            return Ok("Location Added Succesfully");
        }
        [HttpPut("UpdateLocation")]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid location data.");
            }
            await _mediator.Send(command);
            return Ok("Location Updated Succesfully");
        }
        [HttpDelete("DeleteLocation/{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var command = new RemoveLocationCommand(id);
            await _mediator.Send(command);
            return Ok("Location Deleted Succesfully");
        }

    }
}
