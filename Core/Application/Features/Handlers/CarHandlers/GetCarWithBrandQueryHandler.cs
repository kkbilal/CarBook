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
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carrepository;

        public GetCarWithBrandQueryHandler(ICarRepository carrepository)
        {
            _carrepository = carrepository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var cars = await _carrepository.GetCarListWithBrand();

            return cars.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.Brand.Name,
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
