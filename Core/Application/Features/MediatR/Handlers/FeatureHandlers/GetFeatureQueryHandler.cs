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
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var features = await _repository.GetAllAsync();
            return features.Select(x=> new GetFeatureQueryResult
            {
                Name = x.Name,
                FeatureId = x.FeatureId,
            }).ToList();

        }
    }
}
