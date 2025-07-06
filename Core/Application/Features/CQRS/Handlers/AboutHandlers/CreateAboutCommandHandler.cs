using Application.Features.CQRS.Commands.AboutCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _repository = aboutRepository;
        }
        public async Task Handle(CreateAboutCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            await _repository.AddAsync(new About
            {
                Description = command.Description,
                ImageUrl = command.ImageUrl,
                Title = command.Title
            });

        }
    }
}
