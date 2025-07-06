using Application.Features.MediatR.Queries.ServiceQueries;
using Application.Features.MediatR.Results.ServiceResults;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Handlers.ServiceHandler
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var serviceList = await _repository.GetAllAsync();
            
            return serviceList.Select(p => new GetServiceQueryResult
            {
                ServiceId = p.ServiceId,
                Title = p.Title,
                Description = p.Description,
                IconUrl = p.IconUrl
               
            }).ToList();
        }
    }
}
