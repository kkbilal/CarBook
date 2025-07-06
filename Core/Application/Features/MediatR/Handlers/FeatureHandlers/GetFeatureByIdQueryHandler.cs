using Application.Features.MediatR.Queries.FeatureQueries;
using Application.Features.MediatR.Results;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.Id);
            if (feature == null)
            {
                throw new Exception("Feature not found");
            }
            return new GetFeatureByIdQueryResult
            {
                Name = feature.Name,
                FeatureId = feature.FeatureId,
            };
        }
    }
}
