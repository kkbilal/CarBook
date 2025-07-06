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
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var existingFeature =await _repository.GetByIdAsync(request.FeatureId);
            if (existingFeature == null)
            {
                throw new KeyNotFoundException($"Feature with ID {request.FeatureId} not found.");
            }
            existingFeature.FeatureId = request.FeatureId;
            existingFeature.Name = request.Name;

            await _repository.UpdateAsync(existingFeature);
        }
    }
}
