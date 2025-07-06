using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.BannerResults;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var banner = await _repository.GetByIdAsync(query.Id);
            if (banner == null)
            {
                throw new KeyNotFoundException($"Banner with ID {query.Id} not found.");
            }
            return new GetBannerByIdQueryResult
            {
                BannerId = banner.BannerId,
                Title = banner.Title,
                Description = banner.Description,
                VideoDescription = banner.VideoDescription,
                VideoUrl = banner.VideoUrl
            };
        }
    }
}
