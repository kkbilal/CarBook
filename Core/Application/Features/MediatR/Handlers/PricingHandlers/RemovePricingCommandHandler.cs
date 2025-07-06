using Application.Features.MediatR.Commands.PricingCommands;
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
    public class RemoveServiceCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public RemoveServiceCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var pricing = await _repository.GetByIdAsync(request.PricingId);
            if (pricing == null)
            {
                throw new KeyNotFoundException($"Pricing with ID {request.PricingId} not found.");
            }
            await _repository.RemoveAsync(pricing);
        }
    }
}
