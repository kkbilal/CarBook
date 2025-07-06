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
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCarCommand command)
        {
            var car = await _repository.GetByIdAsync(command.Id);
            if (car == null)
            {
                throw new Exception("Car not found");
            }

            await _repository.RemoveAsync(car);
        }
    }
}
