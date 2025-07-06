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
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
        {

            var contact = await _repository.GetAllAsync();


            return contact.Select(x => new GetContactQueryResult
            {
                ContactId = x.ContactId,
                Name = x.Name,


            }).ToList();
        }
    }
}
