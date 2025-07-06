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
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var existingAbout = await _repository.GetByIdAsync(command.AboutId);
            if (existingAbout != null)
            {
                existingAbout.Title = command.Title;
                existingAbout.Description = command.Description;
                existingAbout.ImageUrl = command.ImageUrl;

                await _repository.UpdateAsync(existingAbout);
            }
            else
            {
                throw new Exception("About not found");
            }
        }
    }
}
