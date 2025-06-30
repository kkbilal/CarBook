using Application.Features.Commands.ContactCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveContactCommand command)
        {
            

            var contact = await _repository.GetByIdAsync(command.Id);

            if (contact == null)
            {
                throw new KeyNotFoundException($"Contact with ID {command.Id} not found.");
            }

            await _repository.RemoveAsync(contact);
        }
    }
}
