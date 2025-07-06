using Application.Features.CQRS.Commands.ContactCommands;
using Application.Features.CQRS.Handlers.ContactHandlers;
using Application.Features.CQRS.Queries.ContactQueries;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        public ContactsController(CreateContactCommandHandler createContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var result = await _getContactQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ContactById(int id)
        {
            var result = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);

            return Ok("Contact added successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
           
            return Ok("Contact updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContact(int id )
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
           
            return Ok();
        }
    }
}
