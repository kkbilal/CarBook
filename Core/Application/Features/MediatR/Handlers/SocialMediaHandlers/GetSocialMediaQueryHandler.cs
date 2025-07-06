using Application.Features.MediatR.Queries.SocialMediaQueries;
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
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var SocialMediaList = await _repository.GetAllAsync();
            
            return SocialMediaList.Select(p => new GetSocialMediaQueryResult
            {
                SocialMediaId = p.SocialMediaId,
                Name = p.Name,
               
            }).ToList();
        }
    }
}
