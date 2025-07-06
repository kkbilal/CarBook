using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var car = await _repository.GetByIdAsync(command.CarId);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {command.CarId} not found.");
            }

            car.BrandId = command.BrandId;
            car.Model = command.Model;
            car.Name = command.Name;
            car.ImageUrl = command.ImageUrl;
            car.Km = command.Km;
            car.Seats = command.Seats;
            car.Luggage = command.Luggage;
            car.BigImageUrl = command.BigImageUrl;
            car.Fuel = command.Fuel;
            car.Gear = command.Gear;

            await _repository.UpdateAsync(car);
        }
    }
}
