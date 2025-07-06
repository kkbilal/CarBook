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
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var car = new Car
            {
                BrandId = command.BrandId,
                Model = command.Model,
                Name = command.Name,
                ImageUrl = command.ImageUrl,
                Km = command.Km,
                Seats = command.Seats,
                Luggage = command.Luggage,
                BigImageUrl = command.BigImageUrl,
                Fuel = command.Fuel,
                Gear = command.Gear,

            };

            await _repository.AddAsync(car);
        }
    }
}
