using Application.Features.MediatR.Commands.FeatureCommands;
using Application.Features.MediatR.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// get all features
        /// summary>
        [HttpGet]
        public async Task<IActionResult> GetAllFeatures()
        {
            var query = new GetFeatureQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            var query = new GetFeatureByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            
            return Ok("Feature created successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature([FromBody] UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Feature updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            var command = new RemoveFeatureCommand(id);
            await _mediator.Send(command);
            return Ok("Feature removed successfully");
        }
    }
}
