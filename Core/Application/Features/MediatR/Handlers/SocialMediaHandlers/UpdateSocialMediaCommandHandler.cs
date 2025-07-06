using Application.Features.MediatR.Commands.SocialMediaCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var social = await _repository.GetByIdAsync(request.SocialMediaId);
            if (social == null)
            {
                throw new KeyNotFoundException($"SocialMedia with ID {request.SocialMediaId} not found.");
            }
            social.SocialMediaId = request.SocialMediaId;
            social.Name = request.Name;
            await _repository.UpdateAsync(social);
        }
    }
}
