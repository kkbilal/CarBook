using Application.Features.Queries.CarQueries;
using Application.Features.Results.CarResults;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var car = await _repository.GetByIdAsync(query.Id);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {query.Id} not found.");
            }
            return new GetCarByIdQueryResult
            {
                CarId = car.CarId,
                BrandId = car.BrandId,
                Model = car.Model,
                Name = car.Name,
                ImageUrl = car.ImageUrl,
                Km = car.Km,
                Seats = car.Seats,
                Luggage = car.Luggage,
                BigImageUrl = car.BigImageUrl,
                Fuel = car.Fuel,
                Gear = car.Gear,
            };
        }
    }
}
