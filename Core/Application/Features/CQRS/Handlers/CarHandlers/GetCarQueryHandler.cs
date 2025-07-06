using Application.Features.CQRS.Results.CarResults;
using Application.Features.CQRS.Results.BrandResults;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarQueryResult>> Handle()
        {
            var cars = await _repository.GetAllAsync();

            return cars.Select(x => new GetCarQueryResult
            {
                BrandId = x.BrandId,
                Model = x.Model,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Km = x.Km,
                Seats = x.Seats,
                Luggage = x.Luggage,
                BigImageUrl = x.BigImageUrl,
                Fuel = x.Fuel,
                Gear = x.Gear,
            }).ToList();
        }
    }
}
