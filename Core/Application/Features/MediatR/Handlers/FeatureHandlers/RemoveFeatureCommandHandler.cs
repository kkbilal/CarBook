using Application.Features.MediatR.Commands.FeatureCommands;
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
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
           var feature = _repository.GetByIdAsync(request.Id);
            if (feature == null)
            {
                throw new KeyNotFoundException($"Feature with ID {request.Id} not found.");
            }
            await _repository.RemoveAsync(feature.Result);
        }
    }
}
