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
    public class GetServiceQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _repository;

        public GetServiceQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var pricingList = await _repository.GetAllAsync();
            
            return pricingList.Select(p => new GetPricingQueryResult
            {
                PricingId = p.PricingId,
                Name = p.Name,
               
            }).ToList();
        }
    }
}
