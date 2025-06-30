using Application.Interfaces;
using CarBookApp.Domain.Entities;
using CarBookApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Persistence.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarListWithBrand()
        {
            var cars = _context.Cars.Include(x=>x.Brand).ToList();
            return cars;
        }
    }
}
