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
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public RemoveServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.ServiceId);
            if (service == null)
            {
                throw new KeyNotFoundException($"Service with ID {request.ServiceId} not found.");
            }
            await _repository.RemoveAsync(service);
        }
    }
}
