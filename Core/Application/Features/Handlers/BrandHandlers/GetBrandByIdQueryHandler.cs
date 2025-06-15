using Application.Features.Queries.BrandQueries;
using Application.Features.Results.BrandResults;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
           
            var brand = await _repository.GetByIdAsync(query.Id);
            if (brand == null)
            {
                throw new KeyNotFoundException($"Brand with ID {query.Id} not found.");
            }

            return new GetBrandByIdQueryResult 
            {
                BrandId = brand.BrandId,
                Name= brand.Name
                
            };  
        }
    }
}
