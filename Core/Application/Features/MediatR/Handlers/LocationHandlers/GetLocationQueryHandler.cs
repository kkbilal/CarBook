using Application.Features.MediatR.Queries.LocationQueries;
using Application.Features.MediatR.Results.LocationResults;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var locations =await _repository.GetAllAsync();
            var result = locations.Select(location => new GetLocationQueryResult
            {
                LocationId = location.LocationId,
                Name = location.Name,
                
            }).ToList();
            return result;
        }
    }
}
