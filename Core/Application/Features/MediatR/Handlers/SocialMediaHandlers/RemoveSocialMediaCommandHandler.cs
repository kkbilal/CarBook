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
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var SocialMedia = await _repository.GetByIdAsync(request.SocialMediaId);
            if (SocialMedia == null)
            {
                throw new KeyNotFoundException($"SocialMedia with ID {request.SocialMediaId} not found.");
            }
            await _repository.RemoveAsync(SocialMedia);
        }
    }
}
