using Application.Features.MediatR.Queries.PricingQueries;
using Application.Features.MediatR.Results.PricingResults;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Handlers.PricingHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetServiceByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var pricing = await _repository.GetByIdAsync(request.PricingId);

            if (pricing == null)
            {
                throw new Exception("Pricing not found");
            }

            return new GetPricingByIdQueryResult
            {
                PricingId = pricing.PricingId,
                Name = pricing.Name
            };
        }
    }
}
