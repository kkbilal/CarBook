using Application.Features.CQRS.Commands.ContactCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand command)
        {
            var contact = new Contact
            {
                Name = command.Name,
                Email = command.Email,
                CreatedAt = DateTime.UtcNow,
                Message = command.Message,
                Subject = command.Subject,

            };

            await _repository.AddAsync(contact);
        }
    }
}
