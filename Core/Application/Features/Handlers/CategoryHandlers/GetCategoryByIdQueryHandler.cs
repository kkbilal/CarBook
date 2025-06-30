using Application.Features.Queries.CategoryQueries;
using Application.Features.Results.CategoryResult;
using Application.Interfaces;
using CarBookApp.Application.Features.Results.AboutResults;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var category = await _repository.GetByIdAsync(query.Id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }

            return new GetCategoryByIdQueryResult 
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
        }
    }
}
