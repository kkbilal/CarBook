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
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand command)
        {
            var contact = await _repository.GetByIdAsync(command.ContactId);
            
            contact.ContactId = command.ContactId;   
            contact.Name = command.Name;
            contact.Email = command.Email;
            contact.Subject = command.Subject;
            contact.Message = command.Message;
            contact.CreatedAt = DateTime.UtcNow;
            

            await _repository.UpdateAsync(contact);
        }
    }
}
