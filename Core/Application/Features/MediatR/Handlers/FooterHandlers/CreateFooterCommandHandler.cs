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
    public class CreateFooterCommandHandler : IRequestHandler<CreateFooterCommand>
    {
        private readonly IRepository<Footer> _repository;

        public CreateFooterCommandHandler(IRepository<Footer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterCommand request, CancellationToken cancellationToken)
        {
            var footer = new Footer
            {
                Mail = request.Mail,
                Description = request.Description,
                Adress = request.Adress,
                Phone = request.Phone
            };
            await _repository.AddAsync(footer); 
        }
    }
}
