using Application.Features.MediatR.Commands.ServiceCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Handlers.ServiceHandler
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var pricing = await _repository.GetByIdAsync(request.ServiceId);
            if (pricing == null)
            {
                throw new KeyNotFoundException($"Pricing with ID {request.ServiceId} not found.");
            }
            pricing.ServiceId = request.ServiceId;
            pricing.Title = request.Title;
            pricing.Description = request.Description;
            pricing.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(pricing);
        }
    }
}
