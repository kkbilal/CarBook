using Application.Features.CQRS.Results.AboutResults;
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
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location =await _repository.GetByIdAsync(request.LocationId);
            if (location == null)
            {
                throw new Exception("Location not found");
            }
            return new GetLocationByIdQueryResult
            {
                LocationId = location.LocationId,
                Name = location.Name,
                
            };
        }
    }
}
