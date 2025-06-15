using Application.Features.Commands.BannerCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var existingBanner = await _repository.GetByIdAsync(command.BannerId);
            if (existingBanner != null)
            {
                existingBanner.Title = command.Title;
                existingBanner.Description = command.Description;
                existingBanner.VideoDescription = command.VideoDescription;
                existingBanner.VideoUrl = command.VideoUrl;

                await _repository.UpdateAsync(existingBanner);
            }
            else
            {
                throw new Exception("Banner not found");
            }
        }
    }
}
