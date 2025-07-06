using Application.Features.MediatR.Queries.PricingQueries;
using Application.Features.MediatR.Queries.ServiceQueries;
using Application.Features.MediatR.Results.PricingResults;
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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.ServiceId);

            if (service == null)
            {
                throw new Exception("Pricing not found");
            }

            return new GetServiceByIdQueryResult
            {
                Description = service.Description,
                IconUrl = service.IconUrl,
                Title = service.Title,
            };
        }
    }
}
