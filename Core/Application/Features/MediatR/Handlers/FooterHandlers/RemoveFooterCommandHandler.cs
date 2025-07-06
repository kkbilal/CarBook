using Application.Features.MediatR.Commands.FooterCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Handlers.FooterHandlers
{
    public class RemoveFooterCommandHandler : IRequestHandler<RemoveFooterCommand>
    {
        private readonly IRepository<Footer> _repository;

        public RemoveFooterCommandHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterCommand request, CancellationToken cancellationToken)
        {
            var footer =await _repository.GetByIdAsync(request.FooterId);
            if (footer == null)
            {
                throw new KeyNotFoundException($"Footer with ID {request.FooterId} not found.");
            }
            await _repository.RemoveAsync(footer);
        }
    }
}
