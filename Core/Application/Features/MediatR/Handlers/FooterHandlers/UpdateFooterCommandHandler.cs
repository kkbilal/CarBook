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
    public class UpdateFooterCommandHandler : IRequestHandler<UpdateFooterCommand>
    {
        private readonly IRepository<Footer> _repository;

        public UpdateFooterCommandHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
        {
            var footer =await _repository.GetByIdAsync(request.FooterId);
            if (footer == null)
            {
                throw new KeyNotFoundException($"Footer with ID {request.FooterId} not found.");
            }
            footer.Mail = request.Mail;
            footer.Description = request.Description;
            footer.Adress = request.Adress;
            footer.Phone = request.Phone;
            footer.FooterId = request.FooterId;

            await _repository.UpdateAsync(footer);
            
        }
    }
}
