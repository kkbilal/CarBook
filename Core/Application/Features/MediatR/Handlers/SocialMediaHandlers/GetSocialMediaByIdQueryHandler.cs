using Application.Features.MediatR.Queries.PricingQueries;
using Application.Features.MediatR.Queries.SocialMediaQueries;
using Application.Features.MediatR.Results.PricingResults;
using Application.Features.MediatR.Results.SocialMediaResults;
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
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var SocialMedia = await _repository.GetByIdAsync(request.SocialMediaId);

            if (SocialMedia == null)
            {
                throw new Exception("SocialMedia not found");
            }

            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaId = SocialMedia.SocialMediaId,
                Name = SocialMedia.Name,
            };
        }
    }
}
