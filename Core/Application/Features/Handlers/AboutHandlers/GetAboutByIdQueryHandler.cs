using Application.Interfaces;
using CarBookApp.Application.Features.Queries.AboutQueries;
using CarBookApp.Application.Features.Results.AboutResults;
using CarBookApp.Domain.Entities;


namespace Application.Features.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            if (value == null)
            {
                throw new Exception("About not found");
            }
            return new GetAboutByIdQueryResult 
            {
                AboutId = value.AboutId,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl
            };
        }
    }
}
