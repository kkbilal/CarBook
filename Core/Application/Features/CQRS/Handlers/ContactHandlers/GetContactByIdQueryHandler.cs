using Application.Features.CQRS.Queries.ContactQueries;
using Application.Features.CQRS.Results.ContactResult;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var contact = await _repository.GetByIdAsync(query.Id);
            if (contact == null)
            {
                throw new Exception("Contact not found");
            }

            return new GetContactByIdQueryResult
            {
                Name = contact.Name,
                ContactId = contact.ContactId,
            };
        }
    }
}
