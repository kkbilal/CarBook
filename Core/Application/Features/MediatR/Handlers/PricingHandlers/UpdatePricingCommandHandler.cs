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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdateServiceCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var pricing = await _repository.GetByIdAsync(request.PricingId);
            if (pricing == null)
            {
                throw new KeyNotFoundException($"Pricing with ID {request.PricingId} not found.");
            }
            pricing.PricingId = request.PricingId;
            pricing.Name = request.Name;
            await _repository.UpdateAsync(pricing);
        }
    }
}
