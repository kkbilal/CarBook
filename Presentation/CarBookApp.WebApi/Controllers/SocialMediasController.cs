using Application.Features.MediatR.Commands.SocialMediaCommands;
using Application.Features.MediatR.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetSocialMedias()
        {
            var query = new GetSocialMediaQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var query = new GetSocialMediaByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia([FromBody] CreateSocialMediaCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid SocialMedia data.");
            }
            await _mediator.Send(command);
            return Ok("SocialMedia Created Successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSocialMedia(int id, [FromBody] UpdateSocialMediaCommand command)
        {

            await _mediator.Send(command);

            return Ok("SocialMedia Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var command = new RemoveSocialMediaCommand(id);
            await _mediator.Send(command);
            return Ok("Service Deleted Successfully");
        }
    }
}
